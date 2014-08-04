namespace AnotherSc2Hack.Classes.FrontEnds
{
    partial class UiInformation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UiInformation));
            this.gbInformation = new AnotherSc2Hack.Classes.FrontEnds.LanguageGroupbox();
            this.txtHeight = new System.Windows.Forms.TextBox();
            this.txtWidth = new System.Windows.Forms.TextBox();
            this.txtPosY = new System.Windows.Forms.TextBox();
            this.txtPosX = new System.Windows.Forms.TextBox();
            this.lblHeight = new AnotherSc2Hack.Classes.FrontEnds.LanguageLabel();
            this.lblWidth = new AnotherSc2Hack.Classes.FrontEnds.LanguageLabel();
            this.lblPosY = new AnotherSc2Hack.Classes.FrontEnds.LanguageLabel();
            this.lblPosX = new AnotherSc2Hack.Classes.FrontEnds.LanguageLabel();
            this.gbInformation.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbInformation
            // 
            resources.ApplyResources(this.gbInformation, "gbInformation");
            this.gbInformation.Controls.Add(this.txtHeight);
            this.gbInformation.Controls.Add(this.txtWidth);
            this.gbInformation.Controls.Add(this.txtPosY);
            this.gbInformation.Controls.Add(this.txtPosX);
            this.gbInformation.Controls.Add(this.lblHeight);
            this.gbInformation.Controls.Add(this.lblWidth);
            this.gbInformation.Controls.Add(this.lblPosY);
            this.gbInformation.Controls.Add(this.lblPosX);
            this.gbInformation.LanguageFile = "";
            this.gbInformation.Name = "gbInformation";
            this.gbInformation.TabStop = false;
            // 
            // txtHeight
            // 
            resources.ApplyResources(this.txtHeight, "txtHeight");
            this.txtHeight.Name = "txtHeight";
            // 
            // txtWidth
            // 
            resources.ApplyResources(this.txtWidth, "txtWidth");
            this.txtWidth.Name = "txtWidth";
            // 
            // txtPosY
            // 
            resources.ApplyResources(this.txtPosY, "txtPosY");
            this.txtPosY.Name = "txtPosY";
            // 
            // txtPosX
            // 
            resources.ApplyResources(this.txtPosX, "txtPosX");
            this.txtPosX.Name = "txtPosX";
            // 
            // lblHeight
            // 
            resources.ApplyResources(this.lblHeight, "lblHeight");
            this.lblHeight.LanguageFile = "";
            this.lblHeight.Name = "lblHeight";
            // 
            // lblWidth
            // 
            resources.ApplyResources(this.lblWidth, "lblWidth");
            this.lblWidth.LanguageFile = "";
            this.lblWidth.Name = "lblWidth";
            // 
            // lblPosY
            // 
            resources.ApplyResources(this.lblPosY, "lblPosY");
            this.lblPosY.LanguageFile = "";
            this.lblPosY.Name = "lblPosY";
            // 
            // lblPosX
            // 
            resources.ApplyResources(this.lblPosX, "lblPosX");
            this.lblPosX.LanguageFile = "";
            this.lblPosX.Name = "lblPosX";
            // 
            // UiInformation
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbInformation);
            this.Name = "UiInformation";
            this.gbInformation.ResumeLayout(false);
            this.gbInformation.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private LanguageGroupbox gbInformation;
        public System.Windows.Forms.TextBox txtHeight;
        public System.Windows.Forms.TextBox txtWidth;
        public System.Windows.Forms.TextBox txtPosY;
        public System.Windows.Forms.TextBox txtPosX;
        private LanguageLabel lblHeight;
        private LanguageLabel lblWidth;
        private LanguageLabel lblPosY;
        private LanguageLabel lblPosX;
    }
}
