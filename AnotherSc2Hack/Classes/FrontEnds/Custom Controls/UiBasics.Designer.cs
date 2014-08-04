namespace AnotherSc2Hack.Classes.FrontEnds
{
    partial class UiBasics
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UiBasics));
            this.gbBasicOptions = new AnotherSc2Hack.Classes.FrontEnds.LanguageGroupbox();
            this.OcUiOpacity = new AnotherSc2Hack.Classes.FrontEnds.UiOpacityControl();
            this.chBxDrawBackground = new AnotherSc2Hack.Classes.FrontEnds.LanguageCheckbox();
            this.chBxRemoveClantag = new AnotherSc2Hack.Classes.FrontEnds.LanguageCheckbox();
            this.chBxRemoveLocalplayer = new AnotherSc2Hack.Classes.FrontEnds.LanguageCheckbox();
            this.chBxRemoveNeutral = new AnotherSc2Hack.Classes.FrontEnds.LanguageCheckbox();
            this.chBxRemoveAllie = new AnotherSc2Hack.Classes.FrontEnds.LanguageCheckbox();
            this.chBxRemoveAi = new AnotherSc2Hack.Classes.FrontEnds.LanguageCheckbox();
            this.btnFontName = new AnotherSc2Hack.Classes.FrontEnds.LanguageButton();
            this.gbBasicOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbBasicOptions
            // 
            resources.ApplyResources(this.gbBasicOptions, "gbBasicOptions");
            this.gbBasicOptions.Controls.Add(this.OcUiOpacity);
            this.gbBasicOptions.Controls.Add(this.chBxDrawBackground);
            this.gbBasicOptions.Controls.Add(this.chBxRemoveClantag);
            this.gbBasicOptions.Controls.Add(this.chBxRemoveLocalplayer);
            this.gbBasicOptions.Controls.Add(this.chBxRemoveNeutral);
            this.gbBasicOptions.Controls.Add(this.chBxRemoveAllie);
            this.gbBasicOptions.Controls.Add(this.chBxRemoveAi);
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
            // chBxRemoveClantag
            // 
            resources.ApplyResources(this.chBxRemoveClantag, "chBxRemoveClantag");
            this.chBxRemoveClantag.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chBxRemoveClantag.LanguageFile = "";
            this.chBxRemoveClantag.Name = "chBxRemoveClantag";
            this.chBxRemoveClantag.UseVisualStyleBackColor = true;
            // 
            // chBxRemoveLocalplayer
            // 
            resources.ApplyResources(this.chBxRemoveLocalplayer, "chBxRemoveLocalplayer");
            this.chBxRemoveLocalplayer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chBxRemoveLocalplayer.LanguageFile = "";
            this.chBxRemoveLocalplayer.Name = "chBxRemoveLocalplayer";
            this.chBxRemoveLocalplayer.UseVisualStyleBackColor = true;
            // 
            // chBxRemoveNeutral
            // 
            resources.ApplyResources(this.chBxRemoveNeutral, "chBxRemoveNeutral");
            this.chBxRemoveNeutral.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chBxRemoveNeutral.LanguageFile = "";
            this.chBxRemoveNeutral.Name = "chBxRemoveNeutral";
            this.chBxRemoveNeutral.UseVisualStyleBackColor = true;
            // 
            // chBxRemoveAllie
            // 
            resources.ApplyResources(this.chBxRemoveAllie, "chBxRemoveAllie");
            this.chBxRemoveAllie.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chBxRemoveAllie.LanguageFile = "";
            this.chBxRemoveAllie.Name = "chBxRemoveAllie";
            this.chBxRemoveAllie.UseVisualStyleBackColor = true;
            // 
            // chBxRemoveAi
            // 
            resources.ApplyResources(this.chBxRemoveAi, "chBxRemoveAi");
            this.chBxRemoveAi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chBxRemoveAi.LanguageFile = "";
            this.chBxRemoveAi.Name = "chBxRemoveAi";
            this.chBxRemoveAi.UseVisualStyleBackColor = true;
            // 
            // btnFontName
            // 
            this.btnFontName.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.btnFontName, "btnFontName");
            this.btnFontName.LanguageFile = "";
            this.btnFontName.Name = "btnFontName";
            this.btnFontName.UseVisualStyleBackColor = true;
            // 
            // UiBasics
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbBasicOptions);
            this.Name = "UiBasics";
            this.gbBasicOptions.ResumeLayout(false);
            this.gbBasicOptions.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public LanguageGroupbox gbBasicOptions;
        public LanguageButton btnFontName;
        public LanguageCheckbox chBxRemoveAi;
        public LanguageCheckbox chBxRemoveClantag;
        public LanguageCheckbox chBxRemoveLocalplayer;
        public LanguageCheckbox chBxRemoveNeutral;
        public LanguageCheckbox chBxRemoveAllie;
        public LanguageCheckbox chBxDrawBackground;
        public UiOpacityControl OcUiOpacity;
    }
}
