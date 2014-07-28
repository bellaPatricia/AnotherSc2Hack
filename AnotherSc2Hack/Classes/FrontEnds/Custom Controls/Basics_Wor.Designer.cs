namespace AnotherSc2Hack.Classes.FrontEnds
{
    partial class BasicsWor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BasicsWor));
            this.gbBasicOptions = new AnotherSc2Hack.Classes.FrontEnds.LanguageGroupbox();
            this.chBxDrawBackground = new AnotherSc2Hack.Classes.FrontEnds.LanguageCheckbox();
            this.lblFontName = new AnotherSc2Hack.Classes.FrontEnds.LanguageLabel();
            this.lblOpacityText = new AnotherSc2Hack.Classes.FrontEnds.LanguageLabel();
            this.btnFontName = new System.Windows.Forms.Button();
            this.lblOpacity = new System.Windows.Forms.Label();
            this.tbOpacity = new System.Windows.Forms.TrackBar();
            this.gbBasicOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbOpacity)).BeginInit();
            this.SuspendLayout();
            // 
            // gbBasicOptions
            // 
            resources.ApplyResources(this.gbBasicOptions, "gbBasicOptions");
            this.gbBasicOptions.Controls.Add(this.chBxDrawBackground);
            this.gbBasicOptions.Controls.Add(this.lblFontName);
            this.gbBasicOptions.Controls.Add(this.lblOpacityText);
            this.gbBasicOptions.Controls.Add(this.btnFontName);
            this.gbBasicOptions.Controls.Add(this.lblOpacity);
            this.gbBasicOptions.Controls.Add(this.tbOpacity);
            this.gbBasicOptions.LanguageFile = "";
            this.gbBasicOptions.Name = "gbBasicOptions";
            this.gbBasicOptions.TabStop = false;
            // 
            // chBxDrawBackground
            // 
            resources.ApplyResources(this.chBxDrawBackground, "chBxDrawBackground");
            this.chBxDrawBackground.LanguageFile = "";
            this.chBxDrawBackground.Name = "chBxDrawBackground";
            this.chBxDrawBackground.UseVisualStyleBackColor = true;
            // 
            // lblFontName
            // 
            resources.ApplyResources(this.lblFontName, "lblFontName");
            this.lblFontName.LanguageFile = "";
            this.lblFontName.Name = "lblFontName";
            // 
            // lblOpacityText
            // 
            resources.ApplyResources(this.lblOpacityText, "lblOpacityText");
            this.lblOpacityText.LanguageFile = "";
            this.lblOpacityText.Name = "lblOpacityText";
            // 
            // btnFontName
            // 
            resources.ApplyResources(this.btnFontName, "btnFontName");
            this.btnFontName.Name = "btnFontName";
            this.btnFontName.UseVisualStyleBackColor = true;
            // 
            // lblOpacity
            // 
            resources.ApplyResources(this.lblOpacity, "lblOpacity");
            this.lblOpacity.Name = "lblOpacity";
            // 
            // tbOpacity
            // 
            resources.ApplyResources(this.tbOpacity, "tbOpacity");
            this.tbOpacity.Maximum = 100;
            this.tbOpacity.Name = "tbOpacity";
            // 
            // BasicsWor
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbBasicOptions);
            this.Name = "BasicsWor";
            this.gbBasicOptions.ResumeLayout(false);
            this.gbBasicOptions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbOpacity)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private LanguageGroupbox gbBasicOptions;
        private LanguageLabel lblFontName;
        private LanguageLabel lblOpacityText;
        public LanguageCheckbox chBxDrawBackground;
        public System.Windows.Forms.Button btnFontName;
        public System.Windows.Forms.Label lblOpacity;
        public System.Windows.Forms.TrackBar tbOpacity;
    }
}
