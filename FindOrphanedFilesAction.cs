using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Autodesk.Connectivity.WebServices;
using Autodesk.Connectivity.WebServicesTools;

namespace FindOrphaned
{
    class FileFoundEventArgs : EventArgs
    {
        public FileFoundEventArgs(FilePath filePath)
        {
            FilePath = filePath;
        }

        public FilePath FilePath { get; private set; }
    }

    /// <summary>
    /// Helper class to locate orphaned files = files which are not references by other files.
    /// </summary>
    class FindOrphanedFilesAction
    {
        #region Fields

        private List<FilePath> _files = new List<FilePath>();

        #endregion

        public FindOrphanedFilesAction()
        {
        }

        /// <summary>
        /// The event is used as callback to check if processing can continue or not.
        /// </summary>
        public event EventHandler<CancelEventArgs> ContinueProcessing;

        /// <summary>
        /// The event is fired when orphaned files is found.
        /// </summary>
        public event EventHandler<FileFoundEventArgs> FileFound;

        public bool IncludeHiddenFiles { get; set; }
        public bool IncludeSubFolders { get; set; }
        public bool ExcludeDrawings { get; set; }

        public WebServiceManager ServiceManager { get; set; }

        /// <summary>
        /// Returns result of operation.
        /// </summary>
        public IEnumerable<FilePath> Files
        {
            get { return _files; }
        }

        /// <summary>
        /// Finds orphaned files in given folders.
        /// </summary>
        /// <param name="folders"></param>
        public void FindFiles(IEnumerable<Folder> folders)
        {
            _files.Clear();
            foreach (Folder folder in folders)
            {
                if (CanContinue() == false)
                {
                    return;
                }
                ProcessFolder(folder);
            }
        }

        /// <summary>
        /// Finds orphaned files in given folder.
        /// </summary>
        /// <param name="folder"></param>
        public void FindFiles(Folder folder)
        {
            _files.Clear();
            ProcessFolder(folder);
        }

        private bool CanContinue()
        {
            EventHandler<CancelEventArgs> handler = ContinueProcessing;
            bool result = true;

            if (handler != null)
            {
                CancelEventArgs e = new CancelEventArgs
                {
                    Cancel = false,
                };

                handler(this, e);
                result = (e.Cancel ? false : true);
            }
            return result;
        }

        private void OnFileFound(FileFoundEventArgs e)
        {
            EventHandler<FileFoundEventArgs> handler = FileFound;

            if (handler != null)
            {
                handler(this, e);
            }
        }

        private void ProcessFolder(Folder folder)
        {
            File[] files = ServiceManager.DocumentService.GetLatestFilesByFolderId(folder.Id, IncludeHiddenFiles);

            if (files != null)
            {
                ProcessFiles(folder, files);
            }
            if (IncludeSubFolders)
            {
                Folder[] subFolders = ServiceManager.DocumentService.GetFoldersByParentId(folder.Id, false);

                if (subFolders != null)
                {
                    foreach (Folder subFolder in subFolders)
                    {
                        if (CanContinue() == false)
                        {
                            return;
                        }
                        ProcessFolder(subFolder);
                    }
                }
            }
        }

        private void ProcessFiles(Folder folder, IEnumerable<File> files)
        {
            IEnumerable<long> fileMasterIds = files.Select(f => f.MasterId);
            FileAssocArray[] associations = 
                ServiceManager.DocumentService.GetLatestFileAssociationsByMasterIds(fileMasterIds.ToArray(), FileAssociationTypeEnum.All, false, FileAssociationTypeEnum.None, false, true, IncludeHiddenFiles, false);
            List<long> filesWithReferences = new List<long>();

            if (associations != null)
            {
                foreach (FileAssocArray association in associations)
                {
                    if (association.FileAssocs == null)
                    {
                        continue;
                    }
                    foreach (FileAssoc fileAssoc in association.FileAssocs)
                    {
                        filesWithReferences.Add(fileAssoc.CldFile.MasterId);
                    }
                }
            }
            IEnumerable<long> ids = fileMasterIds.Except(filesWithReferences);

            foreach (long id in ids)
            {
                if (CanContinue() == false)
                {
                    return;
                }
                File file = files.FirstOrDefault(f => f.MasterId == id);

                if (file == null || (file.FileClass == FileClassification.DesignDocument && ExcludeDrawings))
                {
                    continue;
                }
                FilePath filePath = new FilePath
                {
                    File = file,
                    Path = string.Format("{0}/{1}", folder.FullName, file.Name),
                };

                _files.Add(filePath);
                OnFileFound(new FileFoundEventArgs(filePath));
            }
        }
    }
}
