namespace AnotherSc2Hack.Classes.FrontEnds
{
    partial class Basics
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Basics));
            this.gbBasicOptions = new AnotherSc2Hack.Classes.FrontEnds.LanguageGroupbox();
            this.lblRemoveClantag = new AnotherSc2Hack.Classes.FrontEnds.LanguageLabel();
            this.cmBxRemClanTag = new System.Windows.Forms.ComboBox();
            this.chBxDrawBackground = new AnotherSc2Hack.Classes.FrontEnds.LanguageCheckbox();
            this.cmBxRemAi = new System.Windows.Forms.ComboBox();
            this.lblRemoveAi = new AnotherSc2Hack.Classes.FrontEnds.LanguageLabel();
            this.lblRemoveAllie = new AnotherSc2Hack.Classes.FrontEnds.LanguageLabel();
            this.lblOpacity = new System.Windows.Forms.Label();
            this.lblRemoveNeutral = new AnotherSc2Hack.Classes.FrontEnds.LanguageLabel();
            this.tbOpacity = new System.Windows.Forms.TrackBar();
            this.lblRemoveLocalplayer = new AnotherSc2Hack.Classes.FrontEnds.LanguageLabel();
            this.btnFontName = new AnotherSc2Hack.Classes.FrontEnds.LanguageButton();
            this.lblFontName = new AnotherSc2Hack.Classes.FrontEnds.LanguageLabel();
            this.cmBxRemLocalplayer = new System.Windows.Forms.ComboBox();
            this.lblOpacityText = new AnotherSc2Hack.Classes.FrontEnds.LanguageLabel();
            this.cmBxRemNeutral = new System.Windows.Forms.ComboBox();
            this.cmBxRemAllie = new System.Windows.Forms.ComboBox();
            this.gbBasicOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbOpacity)).BeginInit();
            this.SuspendLayout();
            // 
            // gbBasicOptions
            // 
            resources.ApplyResources(this.gbBasicOptions, "gbBasicOptions");
            this.gbBasicOptions.Controls.Add(this.lblRemoveClantag);
            this.gbBasicOptions.Controls.Add(this.cmBxRemClanTag);
            this.gbBasicOptions.Controls.Add(this.chBxDrawBackground);
            this.gbBasicOptions.Controls.Add(this.cmBxRemAi);
            this.gbBasicOptions.Controls.Add(this.lblRemoveAi);
            this.gbBasicOptions.Controls.Add(this.lblRemoveAllie);
            this.gbBasicOptions.Controls.Add(this.lblOpacity);
            this.gbBasicOptions.Controls.Add(this.lblRemoveNeutral);
            this.gbBasicOptions.Controls.Add(this.tbOpacity);
            this.gbBasicOptions.Controls.Add(this.lblRemoveLocalplayer);
            this.gbBasicOptions.Controls.Add(this.btnFontName);
            this.gbBasicOptions.Controls.Add(this.lblFontName);
            this.gbBasicOptions.Controls.Add(this.cmBxRemLocalplayer);
            this.gbBasicOptions.Controls.Add(this.lblOpacityText);
            this.gbBasicOptions.Controls.Add(this.cmBxRemNeutral);
            this.gbBasicOptions.Controls.Add(this.cmBxRemAllie);
            this.gbBasicOptions.LanguageFile = "";
            this.gbBasicOptions.Name = "gbBasicOptions";
            this.gbBasicOptions.TabStop = false;
            // 
            // lblRemoveClantag
            // 
            resources.ApplyResources(this.lblRemoveClantag, "lblRemoveClantag");
            this.lblRemoveClantag.LanguageFile = "";
            this.lblRemoveClantag.Name = "lblRemoveClantag";
            // 
            // cmBxRemClanTag
            // 
            resources.ApplyResources(this.cmBxRemClanTag, "cmBxRemClanTag");
            this.cmBxRemClanTag.FormattingEnabled = true;
            this.cmBxRemClanTag.Items.AddRange(new object[] {
            resources.GetString("cmBxRemClanTag.Items"),
            resources.GetString("cmBxRemClanTag.Items1")});
            this.cmBxRemClanTag.Name = "cmBxRemClanTag";
            // 
            // chBxDrawBackground
            // 
            resources.ApplyResources(this.chBxDrawBackground, "chBxDrawBackground");
            this.chBxDrawBackground.LanguageFile = "";
            this.chBxDrawBackground.Name = "chBxDrawBackground";
            this.chBxDrawBackground.UseVisualStyleBackColor = true;
            // 
            // cmBxRemAi
            // 
            resources.ApplyResources(this.cmBxRemAi, "cmBxRemAi");
            this.cmBxRemAi.FormattingEnabled = true;
            this.cmBxRemAi.Items.AddRange(new object[] {
            resources.GetString("cmBxRemAi.Items"),
            resources.GetString("cmBxRemAi.Items1")});
            this.cmBxRemAi.Name = "cmBxRemAi";
            // 
            // lblRemoveAi
            // 
            resources.ApplyResources(this.lblRemoveAi, "lblRemoveAi");
            this.lblRemoveAi.LanguageFile = "";
            this.lblRemoveAi.Name = "lblRemoveAi";
            // 
            // lblRemoveAllie
            // 
            resources.ApplyResources(this.lblRemoveAllie, "lblRemoveAllie");
            this.lblRemoveAllie.LanguageFile = "";
            this.lblRemoveAllie.Name = "lblRemoveAllie";
            // 
            // lblOpacity
            // 
            resources.ApplyResources(this.lblOpacity, "lblOpacity");
            this.lblOpacity.Name = "lblOpacity";
            // 
            // lblRemoveNeutral
            // 
            resources.ApplyResources(this.lblRemoveNeutral, "lblRemoveNeutral");
            this.lblRemoveNeutral.LanguageFile = "";
            this.lblRemoveNeutral.Name = "lblRemoveNeutral";
            // 
            // tbOpacity
            // 
            resources.ApplyResources(this.tbOpacity, "tbOpacity");
            this.tbOpacity.Maximum = 100;
            this.tbOpacity.Name = "tbOpacity";
            // 
            // lblRemoveLocalplayer
            // 
            resources.ApplyResources(this.lblRemoveLocalplayer, "lblRemoveLocalplayer");
            this.lblRemoveLocalplayer.LanguageFile = "";
            this.lblRemoveLocalplayer.Name = "lblRemoveLocalplayer";
            // 
            // btnFontName
            // 
            resources.ApplyResources(this.btnFontName, "btnFontName");
            this.btnFontName.LanguageFile = "";
            this.btnFontName.Name = "btnFontName";
            this.btnFontName.UseVisualStyleBackColor = true;
            // 
            // lblFontName
            // 
            resources.ApplyResources(this.lblFontName, "lblFontName");
            this.lblFontName.LanguageFile = "";
            this.lblFontName.Name = "lblFontName";
            // 
            // cmBxRemLocalplayer
            // 
            resources.ApplyResources(this.cmBxRemLocalplayer, "cmBxRemLocalplayer");
            this.cmBxRemLocalplayer.FormattingEnabled = true;
            this.cmBxRemLocalplayer.Items.AddRange(new object[] {
            resources.GetString("cmBxRemLocalplayer.Items"),
            resources.GetString("cmBxRemLocalplayer.Items1")});
            this.cmBxRemLocalplayer.Name = "cmBxRemLocalplayer";
            // 
            // lblOpacityText
            // 
            resources.ApplyResources(this.lblOpacityText, "lblOpacityText");
            this.lblOpacityText.LanguageFile = "";
            this.lblOpacityText.Name = "lblOpacityText";
            // 
            // cmBxRemNeutral
            // 
            resources.ApplyResources(this.cmBxRemNeutral, "cmBxRemNeutral");
            this.cmBxRemNeutral.FormattingEnabled = true;
            this.cmBxRemNeutral.Items.AddRange(new object[] {
            resources.GetString("cmBxRemNeutral.Items"),
            resources.GetString("cmBxRemNeutral.Items1")});
            this.cmBxRemNeutral.Name = "cmBxRemNeutral";
            // 
            // cmBxRemAllie
            // 
            resources.ApplyResources(this.cmBxRemAllie, "cmBxRemAllie");
            this.cmBxRemAllie.FormattingEnabled = true;
            this.cmBxRemAllie.Items.AddRange(new object[] {
            resources.GetString("cmBxRemAllie.Items"),
            resources.GetString("cmBxRemAllie.Items1")});
            this.cmBxRemAllie.Name = "cmBxRemAllie";
            // 
            // Basics
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbBasicOptions);
            this.Name = "Basics";
            this.gbBasicOptions.ResumeLayout(false);
            this.gbBasicOptions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbOpacity)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private LanguageLabel lblRemoveClantag;
        private LanguageLabel lblRemoveAi;
        private LanguageLabel lblRemoveAllie;
        private LanguageLabel lblRemoveNeutral;
        private LanguageLabel lblRemoveLocalplayer;
        private LanguageLabel lblFontName;
        private LanguageLabel lblOpacityText;
        public LanguageGroupbox gbBasicOptions;
        public System.Windows.Forms.ComboBox cmBxRemClanTag;
        public LanguageCheckbox chBxDrawBackground;
        public System.Windows.Forms.ComboBox cmBxRemAi;
        public System.Windows.Forms.Label lblOpacity;
        public System.Windows.Forms.TrackBar tbOpacity;
        public LanguageButton btnFontName;
        public System.Windows.Forms.ComboBox cmBxRemLocalplayer;
        public System.Windows.Forms.ComboBox cmBxRemNeutral;
        public System.Windows.Forms.ComboBox cmBxRemAllie;
    }
}
