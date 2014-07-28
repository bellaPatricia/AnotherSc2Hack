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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlBugs));
            this.gbCreateThreadOnD3Scene = new AnotherSc2Hack.Classes.FrontEnds.LanguageGroupbox();
            this.btnCreateNewPost = new AnotherSc2Hack.Classes.FrontEnds.LanguageButton();
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
            resources.ApplyResources(this.gbCreateThreadOnD3Scene, "gbCreateThreadOnD3Scene");
            this.gbCreateThreadOnD3Scene.Controls.Add(this.btnCreateNewPost);
            this.gbCreateThreadOnD3Scene.LanguageFile = "";
            this.gbCreateThreadOnD3Scene.Name = "gbCreateThreadOnD3Scene";
            this.gbCreateThreadOnD3Scene.TabStop = false;
            // 
            // btnCreateNewPost
            // 
            resources.ApplyResources(this.btnCreateNewPost, "btnCreateNewPost");
            this.btnCreateNewPost.LanguageFile = "";
            this.btnCreateNewPost.Name = "btnCreateNewPost";
            this.btnCreateNewPost.UseVisualStyleBackColor = true;
            // 
            // groupBox25
            // 
            resources.ApplyResources(this.groupBox25, "groupBox25");
            this.groupBox25.Controls.Add(this.label95);
            this.groupBox25.Controls.Add(this.btnEmailSend);
            this.groupBox25.Controls.Add(this.label94);
            this.groupBox25.Controls.Add(this.txtEmailBody);
            this.groupBox25.Controls.Add(this.txtEmailSubject);
            this.groupBox25.Controls.Add(this.cmBxEmailSubject);
            this.groupBox25.Controls.Add(this.label93);
            this.groupBox25.Name = "groupBox25";
            this.groupBox25.TabStop = false;
            // 
            // label95
            // 
            resources.ApplyResources(this.label95, "label95");
            this.label95.Name = "label95";
            // 
            // btnEmailSend
            // 
            resources.ApplyResources(this.btnEmailSend, "btnEmailSend");
            this.btnEmailSend.Name = "btnEmailSend";
            this.btnEmailSend.UseVisualStyleBackColor = true;
            // 
            // label94
            // 
            resources.ApplyResources(this.label94, "label94");
            this.label94.Name = "label94";
            // 
            // txtEmailBody
            // 
            resources.ApplyResources(this.txtEmailBody, "txtEmailBody");
            this.txtEmailBody.Name = "txtEmailBody";
            // 
            // txtEmailSubject
            // 
            resources.ApplyResources(this.txtEmailSubject, "txtEmailSubject");
            this.txtEmailSubject.Name = "txtEmailSubject";
            // 
            // cmBxEmailSubject
            // 
            resources.ApplyResources(this.cmBxEmailSubject, "cmBxEmailSubject");
            this.cmBxEmailSubject.FormattingEnabled = true;
            this.cmBxEmailSubject.Items.AddRange(new object[] {
            resources.GetString("cmBxEmailSubject.Items"),
            resources.GetString("cmBxEmailSubject.Items1"),
            resources.GetString("cmBxEmailSubject.Items2")});
            this.cmBxEmailSubject.Name = "cmBxEmailSubject";
            // 
            // label93
            // 
            resources.ApplyResources(this.label93, "label93");
            this.label93.Name = "label93";
            // 
            // ControlBugs
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbCreateThreadOnD3Scene);
            this.Controls.Add(this.groupBox25);
            this.Name = "ControlBugs";
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
