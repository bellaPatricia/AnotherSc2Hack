namespace Sc2Hack_UpdateManager.Classes.Fontend
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnStartUpdate = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblHeader = new System.Windows.Forms.Label();
            this.pgrBarMain = new System.Windows.Forms.ProgressBar();
            this.rtbItems = new System.Windows.Forms.RichTextBox();
            this.lstFilelist = new System.Windows.Forms.ListView();
            this.cHFile = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cHStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // btnStartUpdate
            // 
            this.btnStartUpdate.Enabled = false;
            this.btnStartUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStartUpdate.Location = new System.Drawing.Point(193, 421);
            this.btnStartUpdate.Name = "btnStartUpdate";
            this.btnStartUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnStartUpdate.TabIndex = 0;
            this.btnStartUpdate.Text = "Download";
            this.btnStartUpdate.UseVisualStyleBackColor = true;
            this.btnStartUpdate.Click += new System.EventHandler(this.btnStartUpdate_Click);
            // 
            // btnClose
            // 
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Location = new System.Drawing.Point(987, 421);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblHeader
            // 
            this.lblHeader.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.Location = new System.Drawing.Point(308, 27);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(0, 23);
            this.lblHeader.TabIndex = 2;
            // 
            // pgrBarMain
            // 
            this.pgrBarMain.Location = new System.Drawing.Point(274, 421);
            this.pgrBarMain.Name = "pgrBarMain";
            this.pgrBarMain.Size = new System.Drawing.Size(707, 23);
            this.pgrBarMain.Step = 1;
            this.pgrBarMain.TabIndex = 3;
            // 
            // rtbItems
            // 
            this.rtbItems.Location = new System.Drawing.Point(193, 53);
            this.rtbItems.Name = "rtbItems";
            this.rtbItems.Size = new System.Drawing.Size(869, 362);
            this.rtbItems.TabIndex = 4;
            this.rtbItems.Text = "";
            // 
            // lstFilelist
            // 
            this.lstFilelist.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.cHFile,
            this.cHStatus});
            this.lstFilelist.Location = new System.Drawing.Point(12, 53);
            this.lstFilelist.Name = "lstFilelist";
            this.lstFilelist.Size = new System.Drawing.Size(175, 391);
            this.lstFilelist.TabIndex = 5;
            this.lstFilelist.UseCompatibleStateImageBehavior = false;
            this.lstFilelist.View = System.Windows.Forms.View.Details;
            // 
            // cHFile
            // 
            this.cHFile.Text = "File";
            this.cHFile.Width = 119;
            // 
            // cHStatus
            // 
            this.cHStatus.Text = "Status";
            this.cHStatus.Width = 46;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1074, 456);
            this.Controls.Add(this.lstFilelist);
            this.Controls.Add(this.rtbItems);
            this.Controls.Add(this.pgrBarMain);
            this.Controls.Add(this.lblHeader);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnStartUpdate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "MainWindow";
            this.Text = "Updater";
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStartUpdate;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.ProgressBar pgrBarMain;
        private System.Windows.Forms.RichTextBox rtbItems;
        private System.Windows.Forms.ListView lstFilelist;
        private System.Windows.Forms.ColumnHeader cHFile;
        private System.Windows.Forms.ColumnHeader cHStatus;
    }
}