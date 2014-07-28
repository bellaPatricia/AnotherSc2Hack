namespace AnotherSc2Hack.Classes.FrontEnds
{
    partial class ControlBugs
    {
        /// <summary> 
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Komponenten-Designer generierter Code

        /// <summary> 
        /// Erforderliche Methode für die Designerunterstützung. 
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.gbCreateThreadOnD3Scene = new LanguageGroupbox();
            this.btnCreateNewPost = new LanguageButton();
            this.groupBox25 = new System.Windows.Forms.GroupBox();
            this.label95 = new System.Windows.Forms.Label();
            this.btnEmailSend = new System.Windows.Forms.Button();
            this.label94 = new System.Windows.Forms.Label();
            this.txtEmailBody = new System.Windows.Forms.TextBox();
            this.txtEmailSubject = new System.Windows.Forms.TextBox();
            this.cmBxEmailSubject = new System.Windows.Forms.ComboBox();
            this.label93 = new System.Windows.Forms.Label();
            this.gbCreateThreadOnD3Scene.SuspendLayout();
            this.groupBox25.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbCreateThreadOnD3Scene
            // 
            this.gbCreateThreadOnD3Scene.Controls.Add(this.btnCreateNewPost);
            this.gbCreateThreadOnD3Scene.Location = new System.Drawing.Point(507, 0);
            this.gbCreateThreadOnD3Scene.Name = "gbCreateThreadOnD3Scene";
            this.gbCreateThreadOnD3Scene.Size = new System.Drawing.Size(163, 69);
            this.gbCreateThreadOnD3Scene.TabIndex = 4;
            this.gbCreateThreadOnD3Scene.TabStop = false;
            this.gbCreateThreadOnD3Scene.Text = "Create post on D3Scene";
            // 
            // btnCreateNewPost
            // 
            this.btnCreateNewPost.Location = new System.Drawing.Point(33, 28);
            this.btnCreateNewPost.Name = "btnCreateNewPost";
            this.btnCreateNewPost.Size = new System.Drawing.Size(87, 23);
            this.btnCreateNewPost.TabIndex = 1;
            this.btnCreateNewPost.Text = "Open Thread";
            this.btnCreateNewPost.UseVisualStyleBackColor = true;
            // 
            // groupBox25
            // 
            this.groupBox25.Controls.Add(this.label95);
            this.groupBox25.Controls.Add(this.btnEmailSend);
            this.groupBox25.Controls.Add(this.label94);
            this.groupBox25.Controls.Add(this.txtEmailBody);
            this.groupBox25.Controls.Add(this.txtEmailSubject);
            this.groupBox25.Controls.Add(this.cmBxEmailSubject);
            this.groupBox25.Controls.Add(this.label93);
            this.groupBox25.Enabled = false;
            this.groupBox25.Location = new System.Drawing.Point(0, 0);
            this.groupBox25.Name = "groupBox25";
            this.groupBox25.Size = new System.Drawing.Size(501, 393);
            this.groupBox25.TabIndex = 3;
            this.groupBox25.TabStop = false;
            this.groupBox25.Text = "Send Email";
            this.groupBox25.Visible = false;
            // 
            // label95
            // 
            this.label95.AutoSize = true;
            this.label95.Location = new System.Drawing.Point(29, 56);
            this.label95.Name = "label95";
            this.label95.Size = new System.Drawing.Size(34, 13);
            this.label95.TabIndex = 5;
            this.label95.Text = "Body:";
            // 
            // btnEmailSend
            // 
            this.btnEmailSend.Enabled = false;
            this.btnEmailSend.Location = new System.Drawing.Point(32, 339);
            this.btnEmailSend.Name = "btnEmailSend";
            this.btnEmailSend.Size = new System.Drawing.Size(446, 27);
            this.btnEmailSend.TabIndex = 1;
            this.btnEmailSend.Text = "Send";
            this.btnEmailSend.UseVisualStyleBackColor = true;
            // 
            // label94
            // 
            this.label94.AutoSize = true;
            this.label94.Location = new System.Drawing.Point(78, 284);
            this.label94.Name = "label94";
            this.label94.Size = new System.Drawing.Size(314, 52);
            this.label94.TabIndex = 4;
            this.label94.Text = "Please be as accurate as you can be!\r\n\r\nIf you have problems to speak English, us" +
    "e your native language.\r\nI\'ll use google translator and see what I can do.";
            // 
            // txtEmailBody
            // 
            this.txtEmailBody.Location = new System.Drawing.Point(81, 53);
            this.txtEmailBody.Multiline = true;
            this.txtEmailBody.Name = "txtEmailBody";
            this.txtEmailBody.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtEmailBody.Size = new System.Drawing.Size(397, 216);
            this.txtEmailBody.TabIndex = 3;
            // 
            // txtEmailSubject
            // 
            this.txtEmailSubject.Enabled = false;
            this.txtEmailSubject.Location = new System.Drawing.Point(338, 26);
            this.txtEmailSubject.Name = "txtEmailSubject";
            this.txtEmailSubject.Size = new System.Drawing.Size(140, 20);
            this.txtEmailSubject.TabIndex = 2;
            // 
            // cmBxEmailSubject
            // 
            this.cmBxEmailSubject.FormattingEnabled = true;
            this.cmBxEmailSubject.Items.AddRange(new object[] {
            "Bug",
            "Suggestion",
            "Other"});
            this.cmBxEmailSubject.Location = new System.Drawing.Point(81, 30);
            this.cmBxEmailSubject.Name = "cmBxEmailSubject";
            this.cmBxEmailSubject.Size = new System.Drawing.Size(121, 21);
            this.cmBxEmailSubject.TabIndex = 1;
            // 
            // label93
            // 
            this.label93.AutoSize = true;
            this.label93.Location = new System.Drawing.Point(29, 33);
            this.label93.Name = "label93";
            this.label93.Size = new System.Drawing.Size(46, 13);
            this.label93.TabIndex = 0;
            this.label93.Text = "Subject:";
            // 
            // ControlBugs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbCreateThreadOnD3Scene);
            this.Controls.Add(this.groupBox25);
            this.Name = "ControlBugs";
            this.Size = new System.Drawing.Size(669, 392);
            this.gbCreateThreadOnD3Scene.ResumeLayout(false);
            this.groupBox25.ResumeLayout(false);
            this.groupBox25.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private LanguageGroupbox gbCreateThreadOnD3Scene;
        private System.Windows.Forms.GroupBox groupBox25;
        private System.Windows.Forms.Label label95;
        private System.Windows.Forms.Label label94;
        private System.Windows.Forms.Label label93;
        public LanguageButton btnCreateNewPost;
        public System.Windows.Forms.Button btnEmailSend;
        public System.Windows.Forms.TextBox txtEmailBody;
        public System.Windows.Forms.TextBox txtEmailSubject;
        public System.Windows.Forms.ComboBox cmBxEmailSubject;
    }
}
