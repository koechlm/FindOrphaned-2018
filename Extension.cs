using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Autodesk.Connectivity.Explorer.Extensibility;
using Autodesk.Connectivity.WebServices;
using Autodesk.Connectivity.WebServicesTools;
using Autodesk.DataManagement.Client.Framework.Vault.Currency.Connections;

namespace FindOrphaned
{
    public class Extension : IExplorerExtension
    {

        #region Fields

        private static string s_FolderContextMenuCommandSiteId = "FindOrphaned.ContextMenu";
        private static string s_FindOrphanedFilesCommandId = "FindOrphaned.FindOrphanedFilesCommand";

        #endregion

        public Extension()
        {
        }

        #region IExtension Members

        public IEnumerable<CommandSite> CommandSites()
        {
            CommandSite folderContextMenu = new CommandSite(s_FolderContextMenuCommandSiteId, "FindOrphaned")
            {
                DeployAsPulldownMenu = false,
                Location = CommandSiteLocation.FolderContextMenu,
            };
            CommandItem findOrphanedFilesCmd = new CommandItem(s_FindOrphanedFilesCommandId, "Find Orphaned Files ...")
            {
                Description = "Finds orphaned files in selected folder",
                Hint = "Find orphaded files in folder",
                MultiSelectEnabled = true,
                NavigationTypes = new SelectionTypeId[] { SelectionTypeId.Folder },
                ToolbarPaintStyle = PaintStyle.TextAndGlyph,
                Image = Resources.Resource.OnesAndZeros
            };

            findOrphanedFilesCmd.Execute += new EventHandler<CommandItemEventArgs>(Handle_FindOrphanedFilesCmd_Execute);

            folderContextMenu.AddCommand(findOrphanedFilesCmd);
            return new CommandSite[] { folderContextMenu };
        }

        public IEnumerable<CustomEntityHandler> CustomEntityHandlers()
        {
            return null;
        }

        public IEnumerable<DetailPaneTab> DetailTabs()
        {
            return null;
        }

        public IEnumerable<string> HiddenCommands()
        {
            return null;
        }

        public void OnLogOff(IApplication application)
        {
        }

        public void OnLogOn(IApplication application)
        {
        }

        public void OnShutdown(IApplication application)
        {
        }

        public void OnStartup(IApplication application)
        {
            Util.Init();
        }

        #endregion

        private void Handle_FindOrphanedFilesCmd_Execute(object sender, CommandItemEventArgs e)
        {
            Util.DoAction(delegate
            {
                IEnumerable<long> folderIds = from s in e.Context.CurrentSelectionSet
                                              where s.TypeId == SelectionTypeId.Folder
                                              select s.Id;

                if (folderIds.Any() == false)
                {
                    return;
                }
                Connection conn = e.Context.Application.Connection;
                Folder[] folders = conn.WebServiceManager.DocumentService.GetFoldersByIds(folderIds.ToArray());

                using (FindOrphanedFilesForm frm = new FindOrphanedFilesForm())
                {
                    frm.Connection = e.Context.Application.Connection;

                    frm.Folders.AddRange(folders);
                    if (frm.ShowDialog() != DialogResult.OK)
                    {
                        return;
                    }
                    if (frm.SelectedFile != null)
                    {
                        e.Context.GoToLocation = new LocationContext(SelectionTypeId.File, frm.SelectedFile.Path);
                    }
                }
            });
        }
    }
}
