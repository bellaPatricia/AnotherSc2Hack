namespace AnotherSc2Hack.Classes.FrontEnds
{
    partial class UiWorkerBasics
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UiWorkerBasics));
            this.gbBasicOptions = new AnotherSc2Hack.Classes.FrontEnds.LanguageGroupbox();
            this.OcUiOpacity = new AnotherSc2Hack.Classes.FrontEnds.UiOpacityControl();
            this.chBxDrawBackground = new AnotherSc2Hack.Classes.FrontEnds.LanguageCheckbox();
            this.btnFontName = new System.Windows.Forms.Button();
            this.gbBasicOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbBasicOptions
            // 
            resources.ApplyResources(this.gbBasicOptions, "gbBasicOptions");
            this.gbBasicOptions.Controls.Add(this.OcUiOpacity);
            this.gbBasicOptions.Controls.Add(this.chBxDrawBackground);
            this.gbBasicOptions.Controls.Add(this.btnFontName);
            this.gbBasicOptions.LanguageFile = "";
            this.gbBasicOptions.Name = "gbBasicOptions";
            this.gbBasicOptions.TabStop = false;
            // 
            // OcUiOpacity
            // 
            resources.ApplyResources(this.OcUiOpacity, "OcUiOpacity");
            this.OcUiOpacity.Name = "OcUiOpacity";
            // 
            // chBxDrawBackground
            // 
            resources.ApplyResources(this.chBxDrawBackground, "chBxDrawBackground");
            this.chBxDrawBackground.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chBxDrawBackground.LanguageFile = "";
            this.chBxDrawBackground.Name = "chBxDrawBackground";
            this.chBxDrawBackground.UseVisualStyleBackColor = true;
            // 
            // btnFontName
            // 
            this.btnFontName.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.btnFontName, "btnFontName");
            this.btnFontName.Name = "btnFontName";
            this.btnFontName.UseVisualStyleBackColor = true;
            // 
            // UiWorkerBasics
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbBasicOptions);
            this.Name = "UiWorkerBasics";
            this.gbBasicOptions.ResumeLayout(false);
            this.gbBasicOptions.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private LanguageGroupbox gbBasicOptions;
        public LanguageCheckbox chBxDrawBackground;
        public System.Windows.Forms.Button btnFontName;
        public UiOpacityControl OcUiOpacity;
    }
}
