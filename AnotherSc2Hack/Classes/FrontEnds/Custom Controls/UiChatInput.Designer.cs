namespace AnotherSc2Hack.Classes.FrontEnds
{
    partial class UiChatInput
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UiChatInput));
            this.gbChatInput = new AnotherSc2Hack.Classes.FrontEnds.LanguageGroupbox();
            this.txtSize = new System.Windows.Forms.TextBox();
            this.txtPosition = new System.Windows.Forms.TextBox();
            this.txtToggle = new System.Windows.Forms.TextBox();
            this.lblChangeSize = new AnotherSc2Hack.Classes.FrontEnds.LanguageLabel();
            this.lblChangePosition = new AnotherSc2Hack.Classes.FrontEnds.LanguageLabel();
            this.lblEnablePanel = new AnotherSc2Hack.Classes.FrontEnds.LanguageLabel();
            this.gbChatInput.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbChatInput
            // 
            resources.ApplyResources(this.gbChatInput, "gbChatInput");
            this.gbChatInput.Controls.Add(this.txtSize);
            this.gbChatInput.Controls.Add(this.txtPosition);
            this.gbChatInput.Controls.Add(this.txtToggle);
            this.gbChatInput.Controls.Add(this.lblChangeSize);
            this.gbChatInput.Controls.Add(this.lblChangePosition);
            this.gbChatInput.Controls.Add(this.lblEnablePanel);
            this.gbChatInput.LanguageFile = "";
            this.gbChatInput.Name = "gbChatInput";
            this.gbChatInput.TabStop = false;
            // 
            // txtSize
            // 
            resources.ApplyResources(this.txtSize, "txtSize");
            this.txtSize.Name = "txtSize";
            // 
            // txtPosition
            // 
            resources.ApplyResources(this.txtPosition, "txtPosition");
            this.txtPosition.Name = "txtPosition";
            // 
            // txtToggle
            // 
            resources.ApplyResources(this.txtToggle, "txtToggle");
            this.txtToggle.Name = "txtToggle";
            // 
            // lblChangeSize
            // 
            resources.ApplyResources(this.lblChangeSize, "lblChangeSize");
            this.lblChangeSize.LanguageFile = "";
            this.lblChangeSize.Name = "lblChangeSize";
            // 
            // lblChangePosition
            // 
            resources.ApplyResources(this.lblChangePosition, "lblChangePosition");
            this.lblChangePosition.LanguageFile = "";
            this.lblChangePosition.Name = "lblChangePosition";
            // 
            // lblEnablePanel
            // 
            resources.ApplyResources(this.lblEnablePanel, "lblEnablePanel");
            this.lblEnablePanel.LanguageFile = "";
            this.lblEnablePanel.Name = "lblEnablePanel";
            // 
            // UiChatInput
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbChatInput);
            this.Name = "UiChatInput";
            this.gbChatInput.ResumeLayout(false);
            this.gbChatInput.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private LanguageGroupbox gbChatInput;
        public System.Windows.Forms.TextBox txtSize;
        public System.Windows.Forms.TextBox txtPosition;
        public System.Windows.Forms.TextBox txtToggle;
        private LanguageLabel lblChangeSize;
        private LanguageLabel lblChangePosition;
        private LanguageLabel lblEnablePanel;
    }
}
