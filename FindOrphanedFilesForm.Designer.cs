namespace FindOrphaned
{
    partial class FindOrphanedFilesForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FindOrphanedFilesForm));
            this._btnFind = new System.Windows.Forms.Button();
            this._btnStop = new System.Windows.Forms.Button();
            this._btnClose = new System.Windows.Forms.Button();
            this._checkBoxIncludeSubFolders = new System.Windows.Forms.CheckBox();
            this._listView = new System.Windows.Forms.ListView();
            this._colName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this._colPath = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this._colCategory = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this._colState = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this._imageList = new System.Windows.Forms.ImageList(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this._textBoxFolders = new System.Windows.Forms.TextBox();
            this._checkBoxIncludeHidden = new System.Windows.Forms.CheckBox();
            this._btnGoToFile = new System.Windows.Forms.Button();
            this._chckBxDesignDocExclude = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // _btnFind
            // 
            this._btnFind.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._btnFind.Location = new System.Drawing.Point(506, 28);
            this._btnFind.Name = "_btnFind";
            this._btnFind.Size = new System.Drawing.Size(75, 23);
            this._btnFind.TabIndex = 0;
            this._btnFind.Text = "Find";
            this._btnFind.UseVisualStyleBackColor = true;
            this._btnFind.Click += new System.EventHandler(this.Handle_BtnFind_Click);
            // 
            // _btnStop
            // 
            this._btnStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._btnStop.Enabled = false;
            this._btnStop.Location = new System.Drawing.Point(506, 57);
            this._btnStop.Name = "_btnStop";
            this._btnStop.Size = new System.Drawing.Size(75, 23);
            this._btnStop.TabIndex = 0;
            this._btnStop.Text = "Stop";
            this._btnStop.UseVisualStyleBackColor = true;
            this._btnStop.Click += new System.EventHandler(this.Handle_BtnStop_Click);
            // 
            // _btnClose
            // 
            this._btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._btnClose.Location = new System.Drawing.Point(506, 115);
            this._btnClose.Name = "_btnClose";
            this._btnClose.Size = new System.Drawing.Size(75, 23);
            this._btnClose.TabIndex = 0;
            this._btnClose.Text = "Close";
            this._btnClose.UseVisualStyleBackColor = true;
            this._btnClose.Click += new System.EventHandler(this.Handle_BtnClose_Click);
            // 
            // _checkBoxIncludeSubFolders
            // 
            this._checkBoxIncludeSubFolders.AutoSize = true;
            this._checkBoxIncludeSubFolders.Checked = true;
            this._checkBoxIncludeSubFolders.CheckState = System.Windows.Forms.CheckState.Checked;
            this._checkBoxIncludeSubFolders.Location = new System.Drawing.Point(16, 58);
            this._checkBoxIncludeSubFolders.Name = "_checkBoxIncludeSubFolders";
            this._checkBoxIncludeSubFolders.Size = new System.Drawing.Size(120, 17);
            this._checkBoxIncludeSubFolders.TabIndex = 1;
            this._checkBoxIncludeSubFolders.Text = "Include Sub Folders";
            this._checkBoxIncludeSubFolders.UseVisualStyleBackColor = true;
            // 
            // _listView
            // 
            this._listView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this._colName,
            this._colPath,
            this._colCategory,
            this._colState});
            this._listView.FullRowSelect = true;
            this._listView.HideSelection = false;
            this._listView.Location = new System.Drawing.Point(13, 154);
            this._listView.Name = "_listView";
            this._listView.Size = new System.Drawing.Size(568, 289);
            this._listView.SmallImageList = this._imageList;
            this._listView.TabIndex = 2;
            this._listView.UseCompatibleStateImageBehavior = false;
            this._listView.View = System.Windows.Forms.View.Details;
            this._listView.SelectedIndexChanged += new System.EventHandler(this.Handle_ListView_SelectedIndexChanged);
            // 
            // _colName
            // 
            this._colName.Text = "Name";
            this._colName.Width = 120;
            // 
            // _colPath
            // 
            this._colPath.Text = "Path";
            this._colPath.Width = 200;
            // 
            // _colCategory
            // 
            this._colCategory.Text = "Category";
            this._colCategory.Width = 120;
            // 
            // _colState
            // 
            this._colState.Text = "State";
            this._colState.Width = 120;
            // 
            // _imageList
            // 
            this._imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("_imageList.ImageStream")));
            this._imageList.TransparentColor = System.Drawing.Color.Transparent;
            this._imageList.Images.SetKeyName(0, "Document.ico");
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Look In";
            // 
            // _textBoxFolders
            // 
            this._textBoxFolders.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._textBoxFolders.Location = new System.Drawing.Point(13, 32);
            this._textBoxFolders.Name = "_textBoxFolders";
            this._textBoxFolders.ReadOnly = true;
            this._textBoxFolders.Size = new System.Drawing.Size(487, 20);
            this._textBoxFolders.TabIndex = 4;
            // 
            // _checkBoxIncludeHidden
            // 
            this._checkBoxIncludeHidden.AutoSize = true;
            this._checkBoxIncludeHidden.Location = new System.Drawing.Point(16, 81);
            this._checkBoxIncludeHidden.Name = "_checkBoxIncludeHidden";
            this._checkBoxIncludeHidden.Size = new System.Drawing.Size(98, 17);
            this._checkBoxIncludeHidden.TabIndex = 1;
            this._checkBoxIncludeHidden.Text = "Include Hidden";
            this._checkBoxIncludeHidden.UseVisualStyleBackColor = true;
            // 
            // _btnGoToFile
            // 
            this._btnGoToFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._btnGoToFile.Enabled = false;
            this._btnGoToFile.Location = new System.Drawing.Point(506, 86);
            this._btnGoToFile.Name = "_btnGoToFile";
            this._btnGoToFile.Size = new System.Drawing.Size(75, 23);
            this._btnGoToFile.TabIndex = 0;
            this._btnGoToFile.Text = "Go To";
            this._btnGoToFile.UseVisualStyleBackColor = true;
            this._btnGoToFile.Click += new System.EventHandler(this.Handle_BtnGoToFile_Click);
            // 
            // _chckBxDesignDocExclude
            // 
            this._chckBxDesignDocExclude.AutoSize = true;
            this._chckBxDesignDocExclude.Location = new System.Drawing.Point(16, 115);
            this._chckBxDesignDocExclude.Name = "_chckBxDesignDocExclude";
            this._chckBxDesignDocExclude.Size = new System.Drawing.Size(263, 17);
            this._chckBxDesignDocExclude.TabIndex = 5;
            this._chckBxDesignDocExclude.Text = "Exclude Design Documentation (IPN, IDW, DWG)";
            this._chckBxDesignDocExclude.UseVisualStyleBackColor = true;
            // 
            // FindOrphanedFilesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(593, 455);
            this.Controls.Add(this._chckBxDesignDocExclude);
            this.Controls.Add(this._textBoxFolders);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._listView);
            this.Controls.Add(this._checkBoxIncludeHidden);
            this.Controls.Add(this._checkBoxIncludeSubFolders);
            this.Controls.Add(this._btnClose);
            this.Controls.Add(this._btnGoToFile);
            this.Controls.Add(this._btnStop);
            this.Controls.Add(this._btnFind);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FindOrphanedFilesForm";
            this.ShowInTaskbar = false;
            this.Text = "Find Orphaned Files";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Handle_Form_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button _btnFind;
        private System.Windows.Forms.Button _btnStop;
        private System.Windows.Forms.Button _btnClose;
        private System.Windows.Forms.CheckBox _checkBoxIncludeSubFolders;
        private System.Windows.Forms.CheckBox _checkBoxIncludeHidden;
        private System.Windows.Forms.ListView _listView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox _textBoxFolders;
        private System.Windows.Forms.Button _btnGoToFile;
        private System.Windows.Forms.ColumnHeader _colName;
        private System.Windows.Forms.ColumnHeader _colPath;
        private System.Windows.Forms.ColumnHeader _colCategory;
        private System.Windows.Forms.ColumnHeader _colState;
        private System.Windows.Forms.ImageList _imageList;
        private System.Windows.Forms.CheckBox _chckBxDesignDocExclude;
    }
}