FIND ORPHANED FILES


INTRODUCTION:
---------------------------------
This utility detects files that are not referenced by another file.
New 2018 - exclude Inventor IPN, IDW or DWG as these usually don't have parent references.

REQUIREMENTS:
---------------------------------
- Vault Workgroup or Professional 2015


TO USE:
---------------------------------
Run the install and start Vault Explorer.  Right-click on a folder and select the "Find Orphaned Files" command from the context menu.  The Find Orphaned Files window will come up.  Configure the settings you want and click the Find button.  The orphaned files will be displayed in the grid.
To jump to a file, select the file and click the Go To button.  This operation will close the window.


RELEASE NOTES:
---------------------------------
23.0.76.0 - 
	Update to Vault 2018 (Version 23.0, build 76 (RTM), utilty version 1)
	New Option to exclude Inventor file class of type "Design Document" (IPN, IDW, DWG)

3.0.1.0 - Update to Vault 2015
2.0.1.0 - Update to Vault 2014
1.0.1.0 - Initial Release