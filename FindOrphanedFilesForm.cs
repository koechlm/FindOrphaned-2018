using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;
using Autodesk.Connectivity.WebServices;
using Autodesk.Connectivity.WebServicesTools;
using Autodesk.DataManagement.Client.Framework.Vault.Currency.Connections;
using System.Drawing;

namespace FindOrphaned
{
    public partial class FindOrphanedFilesForm : Form
    {
        public FindOrphanedFilesForm()
        {
            InitializeComponent();
            Folders = new List<Folder>();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            if (disposing && (Worker != null))
            {
                Worker.Dispose();
                Worker = null;
            }
            base.Dispose(disposing);
        }

        public Connection Connection { get; set; }

        public List<Folder> Folders { get; private set; }
        public FilePath SelectedFile { get; private set; }

        private bool IncludeHidden { get; set; }
        private bool IncludeSubFolders { get; set; }
        private bool ExcludeDrawings { get; set; }

        private BackgroundWorker Worker { get; set; }

        private void Handle_Form_Load(object sender, EventArgs e)
        {
            Util.DoAction(delegate
            {
                StringBuilder sb = new StringBuilder();

                foreach (Folder folder in Folders)
                {
                    if (sb.Length > 0)
                    {
                        sb.Append(";");
                    }
                    sb.Append(folder.FullName);
                }
                _textBoxFolders.Text = sb.ToString();
                Worker = new BackgroundWorker();
                Worker.WorkerSupportsCancellation = true;
                Worker.WorkerReportsProgress = true;
                Worker.DoWork += new DoWorkEventHandler(Handle_Worker_DoWork);
                Worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(Handle_Worker_RunWorkerCompleted);
            });
        }

        private void Handle_BtnFind_Click(object sender, EventArgs e)
        {
            Util.DoAction(delegate
            {
                Worker.RunWorkerAsync();
            });
            Util.PrintErrors();
        }

        private void Handle_BtnStop_Click(object sender, EventArgs e)
        {
            Util.DoAction(delegate
            {
                Worker.CancelAsync();
            });
            Util.PrintErrors();
        }

        private void Handle_BtnGoToFile_Click(object sender, EventArgs e)
        {
            Util.DoAction(delegate
            {
                if (_listView.SelectedItems.Count > 0)
                {
                    ListViewItem selectedItem = _listView.SelectedItems[0];

                    SelectedFile = selectedItem.Tag as FilePath;
                }
                DialogResult = DialogResult.OK;
                Close();
            });
        }

        private void Handle_BtnClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void Handle_Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            Util.DoAction(delegate
            {
                _btnFind.InvokeIfRequired(() => _btnFind.Enabled = false);
                _btnGoToFile.InvokeIfRequired(() => _btnGoToFile.Enabled = false);
                _btnClose.InvokeIfRequired(() => _btnClose.Enabled = false);
                _btnStop.InvokeIfRequired(() => _btnStop.Enabled = true);
                _listView.InvokeIfRequired(() => _listView.Items.Clear());
                IncludeSubFolders = _checkBoxIncludeSubFolders.Checked;
                IncludeHidden = _checkBoxIncludeHidden.Checked;
                ExcludeDrawings = _chckBxDesignDocExclude.Checked;

                FindOrphanedFilesAction findAction = new FindOrphanedFilesAction
                {
                    ServiceManager = this.Connection.WebServiceManager,
                    IncludeHiddenFiles = _checkBoxIncludeHidden.Checked,
                    IncludeSubFolders = _checkBoxIncludeSubFolders.Checked,
                    ExcludeDrawings = _chckBxDesignDocExclude.Checked,
                };

                findAction.ContinueProcessing += new EventHandler<CancelEventArgs>(Handle_FindAction_ContinueProcessing);
                findAction.FileFound += new EventHandler<FileFoundEventArgs>(Handle_FindAction_FileFound);
                findAction.FindFiles(Folders);

            });
        }

        private void Handle_FindAction_ContinueProcessing(object sender, CancelEventArgs e)
        {
            if (Worker.IsBusy && Worker.CancellationPending)
            {
                e.Cancel = true;
            }
        }

        private void Handle_FindAction_FileFound(object sender, FileFoundEventArgs e)
        {
            Util.DoAction(delegate
            {
                FilePath filePath = e.FilePath;

                if (filePath == null)
                {
                    return;
                }
                ListViewItem newItem = new ListViewItem();

                newItem.Text = filePath.File.Name;
                newItem.SubItems.Add(GetFolderName(e.FilePath.Path));
                newItem.SubItems.Add(filePath.File.Cat.CatName);
                newItem.SubItems.Add(filePath.File.FileLfCyc.LfCycStateName);
                newItem.ImageIndex = GetImageIndex(filePath.File.Name);
                newItem.Tag = e.FilePath;
                _listView.InvokeIfRequired(() => _listView.Items.Add(newItem));
            });
        }

        private void Handle_Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            _btnFind.InvokeIfRequired(() => _btnFind.Enabled = true);
            _btnClose.InvokeIfRequired(() => _btnClose.Enabled = true);
            _btnStop.InvokeIfRequired(() => _btnStop.Enabled = false);
        }

        private void Handle_ListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListView listView = sender as ListView;
            bool enable = false;

            if (listView != null)
            {
                if (listView.SelectedItems.Count > 0)
                {
                    enable = true;
                }
            }
            _btnGoToFile.Enabled = enable;
        }

        private int GetImageIndex(string fileName)
        {
            string ext = System.IO.Path.GetExtension(fileName);

            if (_imageList.Images.ContainsKey(ext) == false)
            {
                Image fileIcon = ShellFileIcon.GetFileIcon(fileName, ShellFileIcon.FileIconSize.Small);

                _imageList.Images.Add(ext, fileIcon);
            }
            return _imageList.Images.IndexOfKey(ext);
        }

        private static string GetFolderName(string path)
        {
            int index = path.LastIndexOf('/');

            if (index > 0)
            {
                return path.Substring(0, index);
            }
            return path;
        }
    }
}
