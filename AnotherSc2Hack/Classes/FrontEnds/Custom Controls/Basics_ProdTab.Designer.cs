namespace AnotherSc2Hack.Classes.FrontEnds
{
    partial class BasicsProdTab
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
            this.gbBasicOptions = new LanguageGroupbox();
            this.cmBxRemChronoboost = new System.Windows.Forms.ComboBox();
            this.lblRemoveChronoboost = new LanguageLabel();
            this.lblRemoveClantag = new LanguageLabel();
            this.cmBxRemClanTag = new System.Windows.Forms.ComboBox();
            this.lblFontName = new LanguageLabel();
            this.btnFontName = new System.Windows.Forms.Button();
            this.lblRemoveAi = new LanguageLabel();
            this.lblRemoveAllie = new LanguageLabel();
            this.lblRemoveNeutral = new LanguageLabel();
            this.lblOpacity = new System.Windows.Forms.Label();
            this.lblRemoveLocalplayer = new LanguageLabel();
            this.tbOpacity = new System.Windows.Forms.TrackBar();
            this.cmBxRemAi = new System.Windows.Forms.ComboBox();
            this.lblOpacityText = new LanguageLabel();
            this.cmBxRemAllie = new System.Windows.Forms.ComboBox();
            this.cmBxSplitBuildings = new System.Windows.Forms.ComboBox();
            this.cmBxRemNeutral = new System.Windows.Forms.ComboBox();
            this.lblSplitBuildings = new LanguageLabel();
            this.cmBxRemLocalplayer = new System.Windows.Forms.ComboBox();
            this.gbBasicOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbOpacity)).BeginInit();
            this.SuspendLayout();
            // 
            // gbBasicOptions
            // 
            this.gbBasicOptions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbBasicOptions.Controls.Add(this.cmBxRemChronoboost);
            this.gbBasicOptions.Controls.Add(this.lblRemoveChronoboost);
            this.gbBasicOptions.Controls.Add(this.lblRemoveClantag);
            this.gbBasicOptions.Controls.Add(this.cmBxRemClanTag);
            this.gbBasicOptions.Controls.Add(this.lblFontName);
            this.gbBasicOptions.Controls.Add(this.btnFontName);
            this.gbBasicOptions.Controls.Add(this.lblRemoveAi);
            this.gbBasicOptions.Controls.Add(this.lblRemoveAllie);
            this.gbBasicOptions.Controls.Add(this.lblRemoveNeutral);
            this.gbBasicOptions.Controls.Add(this.lblOpacity);
            this.gbBasicOptions.Controls.Add(this.lblRemoveLocalplayer);
            this.gbBasicOptions.Controls.Add(this.tbOpacity);
            this.gbBasicOptions.Controls.Add(this.cmBxRemAi);
            this.gbBasicOptions.Controls.Add(this.lblOpacityText);
            this.gbBasicOptions.Controls.Add(this.cmBxRemAllie);
            this.gbBasicOptions.Controls.Add(this.cmBxSplitBuildings);
            this.gbBasicOptions.Controls.Add(this.cmBxRemNeutral);
            this.gbBasicOptions.Controls.Add(this.lblSplitBuildings);
            this.gbBasicOptions.Controls.Add(this.cmBxRemLocalplayer);
            this.gbBasicOptions.Location = new System.Drawing.Point(0, 0);
            this.gbBasicOptions.Name = "gbBasicOptions";
            this.gbBasicOptions.Size = new System.Drawing.Size(291, 327);
            this.gbBasicOptions.TabIndex = 60;
            this.gbBasicOptions.TabStop = false;
            this.gbBasicOptions.Text = "Basic Panel Options";
            // 
            // cmBxRemChronoboost
            // 
            this.cmBxRemChronoboost.FormattingEnabled = true;
            this.cmBxRemChronoboost.Items.AddRange(new object[] {
            "True",
            "False"});
            this.cmBxRemChronoboost.Location = new System.Drawing.Point(153, 208);
            this.cmBxRemChronoboost.Name = "cmBxRemChronoboost";
            this.cmBxRemChronoboost.Size = new System.Drawing.Size(121, 21);
            this.cmBxRemChronoboost.TabIndex = 62;
            // 
            // lblRemoveChronoboost
            // 
            this.lblRemoveChronoboost.AutoSize = true;
            this.lblRemoveChronoboost.Location = new System.Drawing.Point(25, 211);
            this.lblRemoveChronoboost.Name = "lblRemoveChronoboost";
            this.lblRemoveChronoboost.Size = new System.Drawing.Size(113, 13);
            this.lblRemoveChronoboost.TabIndex = 61;
            this.lblRemoveChronoboost.Text = "Remove Chronoboost:";
            // 
            // lblRemoveClantag
            // 
            this.lblRemoveClantag.AutoSize = true;
            this.lblRemoveClantag.Location = new System.Drawing.Point(25, 180);
            this.lblRemoveClantag.Name = "lblRemoveClantag";
            this.lblRemoveClantag.Size = new System.Drawing.Size(93, 13);
            this.lblRemoveClantag.TabIndex = 59;
            this.lblRemoveClantag.Text = "Remove ClanTag:";
            // 
            // cmBxRemClanTag
            // 
            this.cmBxRemClanTag.FormattingEnabled = true;
            this.cmBxRemClanTag.Items.AddRange(new object[] {
            "True",
            "False"});
            this.cmBxRemClanTag.Location = new System.Drawing.Point(153, 177);
            this.cmBxRemClanTag.Name = "cmBxRemClanTag";
            this.cmBxRemClanTag.Size = new System.Drawing.Size(121, 21);
            this.cmBxRemClanTag.TabIndex = 60;
            // 
            // lblFontName
            // 
            this.lblFontName.AutoSize = true;
            this.lblFontName.Location = new System.Drawing.Point(25, 242);
            this.lblFontName.Name = "lblFontName";
            this.lblFontName.Size = new System.Drawing.Size(62, 13);
            this.lblFontName.TabIndex = 57;
            this.lblFontName.Text = "Font Name:";
            // 
            // btnFontName
            // 
            this.btnFontName.Location = new System.Drawing.Point(153, 237);
            this.btnFontName.Name = "btnFontName";
            this.btnFontName.Size = new System.Drawing.Size(121, 23);
            this.btnFontName.TabIndex = 58;
            this.btnFontName.Text = "FontName:";
            this.btnFontName.UseVisualStyleBackColor = true;
            // 
            // lblRemoveAi
            // 
            this.lblRemoveAi.AutoSize = true;
            this.lblRemoveAi.Location = new System.Drawing.Point(25, 30);
            this.lblRemoveAi.Name = "lblRemoveAi";
            this.lblRemoveAi.Size = new System.Drawing.Size(62, 13);
            this.lblRemoveAi.TabIndex = 44;
            this.lblRemoveAi.Text = "Remove Ai:";
            // 
            // lblRemoveAllie
            // 
            this.lblRemoveAllie.AutoSize = true;
            this.lblRemoveAllie.Location = new System.Drawing.Point(25, 60);
            this.lblRemoveAllie.Name = "lblRemoveAllie";
            this.lblRemoveAllie.Size = new System.Drawing.Size(72, 13);
            this.lblRemoveAllie.TabIndex = 45;
            this.lblRemoveAllie.Text = "Remove Allie:";
            // 
            // lblRemoveNeutral
            // 
            this.lblRemoveNeutral.AutoSize = true;
            this.lblRemoveNeutral.Location = new System.Drawing.Point(25, 90);
            this.lblRemoveNeutral.Name = "lblRemoveNeutral";
            this.lblRemoveNeutral.Size = new System.Drawing.Size(87, 13);
            this.lblRemoveNeutral.TabIndex = 46;
            this.lblRemoveNeutral.Text = "Remove Neutral:";
            // 
            // lblOpacity
            // 
            this.lblOpacity.AutoSize = true;
            this.lblOpacity.Location = new System.Drawing.Point(150, 304);
            this.lblOpacity.Name = "lblOpacity";
            this.lblOpacity.Size = new System.Drawing.Size(35, 13);
            this.lblOpacity.TabIndex = 56;
            this.lblOpacity.Text = "label9";
            // 
            // lblRemoveLocalplayer
            // 
            this.lblRemoveLocalplayer.AutoSize = true;
            this.lblRemoveLocalplayer.Location = new System.Drawing.Point(25, 120);
            this.lblRemoveLocalplayer.Name = "lblRemoveLocalplayer";
            this.lblRemoveLocalplayer.Size = new System.Drawing.Size(107, 13);
            this.lblRemoveLocalplayer.TabIndex = 47;
            this.lblRemoveLocalplayer.Text = "Remove Localplayer:";
            // 
            // tbOpacity
            // 
            this.tbOpacity.Location = new System.Drawing.Point(153, 272);
            this.tbOpacity.Maximum = 100;
            this.tbOpacity.Name = "tbOpacity";
            this.tbOpacity.Size = new System.Drawing.Size(121, 45);
            this.tbOpacity.TabIndex = 55;
            // 
            // cmBxRemAi
            // 
            this.cmBxRemAi.FormattingEnabled = true;
            this.cmBxRemAi.Items.AddRange(new object[] {
            "True",
            "False"});
            this.cmBxRemAi.Location = new System.Drawing.Point(153, 27);
            this.cmBxRemAi.Name = "cmBxRemAi";
            this.cmBxRemAi.Size = new System.Drawing.Size(121, 21);
            this.cmBxRemAi.TabIndex = 48;
            // 
            // lblOpacityText
            // 
            this.lblOpacityText.AutoSize = true;
            this.lblOpacityText.Location = new System.Drawing.Point(25, 272);
            this.lblOpacityText.Name = "lblOpacityText";
            this.lblOpacityText.Size = new System.Drawing.Size(46, 13);
            this.lblOpacityText.TabIndex = 54;
            this.lblOpacityText.Text = "Opacity:";
            // 
            // cmBxRemAllie
            // 
            this.cmBxRemAllie.FormattingEnabled = true;
            this.cmBxRemAllie.Items.AddRange(new object[] {
            "True",
            "False"});
            this.cmBxRemAllie.Location = new System.Drawing.Point(153, 57);
            this.cmBxRemAllie.Name = "cmBxRemAllie";
            this.cmBxRemAllie.Size = new System.Drawing.Size(121, 21);
            this.cmBxRemAllie.TabIndex = 49;
            // 
            // cmBxSplitBuildings
            // 
            this.cmBxSplitBuildings.FormattingEnabled = true;
            this.cmBxSplitBuildings.Items.AddRange(new object[] {
            "True",
            "False"});
            this.cmBxSplitBuildings.Location = new System.Drawing.Point(153, 147);
            this.cmBxSplitBuildings.Name = "cmBxSplitBuildings";
            this.cmBxSplitBuildings.Size = new System.Drawing.Size(121, 21);
            this.cmBxSplitBuildings.TabIndex = 53;
            // 
            // cmBxRemNeutral
            // 
            this.cmBxRemNeutral.FormattingEnabled = true;
            this.cmBxRemNeutral.Items.AddRange(new object[] {
            "True",
            "False"});
            this.cmBxRemNeutral.Location = new System.Drawing.Point(153, 87);
            this.cmBxRemNeutral.Name = "cmBxRemNeutral";
            this.cmBxRemNeutral.Size = new System.Drawing.Size(121, 21);
            this.cmBxRemNeutral.TabIndex = 50;
            // 
            // lblSplitBuildings
            // 
            this.lblSplitBuildings.AutoSize = true;
            this.lblSplitBuildings.Location = new System.Drawing.Point(25, 150);
            this.lblSplitBuildings.Name = "lblSplitBuildings";
            this.lblSplitBuildings.Size = new System.Drawing.Size(107, 13);
            this.lblSplitBuildings.TabIndex = 52;
            this.lblSplitBuildings.Text = "Split Buildings/ Units:";
            // 
            // cmBxRemLocalplayer
            // 
            this.cmBxRemLocalplayer.FormattingEnabled = true;
            this.cmBxRemLocalplayer.Items.AddRange(new object[] {
            "True",
            "False"});
            this.cmBxRemLocalplayer.Location = new System.Drawing.Point(153, 117);
            this.cmBxRemLocalplayer.Name = "cmBxRemLocalplayer";
            this.cmBxRemLocalplayer.Size = new System.Drawing.Size(121, 21);
            this.cmBxRemLocalplayer.TabIndex = 51;
            // 
            // BasicsProdTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbBasicOptions);
            this.Name = "BasicsProdTab";
            this.Size = new System.Drawing.Size(291, 358);
            this.gbBasicOptions.ResumeLayout(false);
            this.gbBasicOptions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbOpacity)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private LanguageGroupbox gbBasicOptions;
        private LanguageLabel lblRemoveClantag;
        private LanguageLabel lblFontName;
        private LanguageLabel lblRemoveAi;
        private LanguageLabel lblRemoveAllie;
        private LanguageLabel lblRemoveNeutral;
        private LanguageLabel lblRemoveLocalplayer;
        private LanguageLabel lblOpacityText;
        private LanguageLabel lblSplitBuildings;
        public System.Windows.Forms.ComboBox cmBxRemClanTag;
        public System.Windows.Forms.Button btnFontName;
        public System.Windows.Forms.Label lblOpacity;
        public System.Windows.Forms.TrackBar tbOpacity;
        public System.Windows.Forms.ComboBox cmBxRemAi;
        public System.Windows.Forms.ComboBox cmBxRemAllie;
        public System.Windows.Forms.ComboBox cmBxSplitBuildings;
        public System.Windows.Forms.ComboBox cmBxRemNeutral;
        public System.Windows.Forms.ComboBox cmBxRemLocalplayer;
        public System.Windows.Forms.ComboBox cmBxRemChronoboost;
        private LanguageLabel lblRemoveChronoboost;
    }
}
