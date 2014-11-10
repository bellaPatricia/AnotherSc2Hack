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
            this.pgrBarMain = new System.Windows.Forms.ProgressBar();
            this.rtbItems = new System.Windows.Forms.RichTextBox();
            this.rtbLog = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnStartUpdate
            // 
            this.btnStartUpdate.Enabled = false;
            this.btnStartUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStartUpdate.Location = new System.Drawing.Point(6, 486);
            this.btnStartUpdate.Name = "btnStartUpdate";
            this.btnStartUpdate.Size = new System.Drawing.Size(87, 27);
            this.btnStartUpdate.TabIndex = 0;
            this.btnStartUpdate.Text = "Download";
            this.btnStartUpdate.UseVisualStyleBackColor = true;
            this.btnStartUpdate.Click += new System.EventHandler(this.btnStartUpdate_Click);
            // 
            // btnClose
            // 
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Location = new System.Drawing.Point(793, 486);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(87, 27);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pgrBarMain
            // 
            this.pgrBarMain.Location = new System.Drawing.Point(100, 486);
            this.pgrBarMain.Name = "pgrBarMain";
            this.pgrBarMain.Size = new System.Drawing.Size(687, 27);
            this.pgrBarMain.Step = 1;
            this.pgrBarMain.TabIndex = 3;
            // 
            // rtbItems
            // 
            this.rtbItems.Location = new System.Drawing.Point(6, 61);
            this.rtbItems.Name = "rtbItems";
            this.rtbItems.Size = new System.Drawing.Size(874, 417);
            this.rtbItems.TabIndex = 4;
            this.rtbItems.Text = "";
            // 
            // rtbLog
            // 
            this.rtbLog.BackColor = System.Drawing.Color.Wheat;
            this.rtbLog.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbLog.Location = new System.Drawing.Point(886, 80);
            this.rtbLog.Name = "rtbLog";
            this.rtbLog.Size = new System.Drawing.Size(319, 432);
            this.rtbLog.TabIndex = 5;
            this.rtbLog.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(883, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "Log:";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1214, 526);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rtbLog);
            this.Controls.Add(this.rtbItems);
            this.Controls.Add(this.pgrBarMain);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnStartUpdate);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
        private System.Windows.Forms.ProgressBar pgrBarMain;
        private System.Windows.Forms.RichTextBox rtbItems;
        private System.Windows.Forms.RichTextBox rtbLog;
        private System.Windows.Forms.Label label1;
    }
}