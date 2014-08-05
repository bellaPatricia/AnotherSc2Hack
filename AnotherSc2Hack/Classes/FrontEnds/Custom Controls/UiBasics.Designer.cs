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
            this.gbBasicOptions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbBasicOptions.Controls.Add(this.OcUiOpacity);
            this.gbBasicOptions.Controls.Add(this.chBxDrawBackground);
            this.gbBasicOptions.Controls.Add(this.chBxRemoveClantag);
            this.gbBasicOptions.Controls.Add(this.chBxRemoveLocalplayer);
            this.gbBasicOptions.Controls.Add(this.chBxRemoveNeutral);
            this.gbBasicOptions.Controls.Add(this.chBxRemoveAllie);
            this.gbBasicOptions.Controls.Add(this.chBxRemoveAi);
            this.gbBasicOptions.Controls.Add(this.btnFontName);
            this.gbBasicOptions.LanguageFile = "";
            this.gbBasicOptions.Location = new System.Drawing.Point(0, 0);
            this.gbBasicOptions.Name = "gbBasicOptions";
            this.gbBasicOptions.Size = new System.Drawing.Size(210, 248);
            this.gbBasicOptions.TabIndex = 16;
            this.gbBasicOptions.TabStop = false;
            this.gbBasicOptions.Text = "Basic Panel Options";
            // 
            // OcUiOpacity
            // 
            this.OcUiOpacity.Location = new System.Drawing.Point(25, 192);
            this.OcUiOpacity.Name = "OcUiOpacity";
            this.OcUiOpacity.Size = new System.Drawing.Size(150, 53);
            this.OcUiOpacity.TabIndex = 21;
            // 
            // chBxDrawBackground
            // 
            this.chBxDrawBackground.AutoSize = true;
            this.chBxDrawBackground.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chBxDrawBackground.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.chBxDrawBackground.LanguageFile = "";
            this.chBxDrawBackground.Location = new System.Drawing.Point(25, 140);
            this.chBxDrawBackground.Name = "chBxDrawBackground";
            this.chBxDrawBackground.Size = new System.Drawing.Size(112, 17);
            this.chBxDrawBackground.TabIndex = 20;
            this.chBxDrawBackground.Text = "Draw Background";
            this.chBxDrawBackground.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chBxDrawBackground.UseVisualStyleBackColor = true;
            // 
            // chBxRemoveClantag
            // 
            this.chBxRemoveClantag.AutoSize = true;
            this.chBxRemoveClantag.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chBxRemoveClantag.LanguageFile = "";
            this.chBxRemoveClantag.Location = new System.Drawing.Point(25, 117);
            this.chBxRemoveClantag.Name = "chBxRemoveClantag";
            this.chBxRemoveClantag.Size = new System.Drawing.Size(105, 17);
            this.chBxRemoveClantag.TabIndex = 19;
            this.chBxRemoveClantag.Text = "Remove Clantag";
            this.chBxRemoveClantag.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chBxRemoveClantag.UseVisualStyleBackColor = true;
            // 
            // chBxRemoveLocalplayer
            // 
            this.chBxRemoveLocalplayer.AutoSize = true;
            this.chBxRemoveLocalplayer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chBxRemoveLocalplayer.LanguageFile = "";
            this.chBxRemoveLocalplayer.Location = new System.Drawing.Point(25, 94);
            this.chBxRemoveLocalplayer.Name = "chBxRemoveLocalplayer";
            this.chBxRemoveLocalplayer.Size = new System.Drawing.Size(107, 17);
            this.chBxRemoveLocalplayer.TabIndex = 18;
            this.chBxRemoveLocalplayer.Text = "Remove Yourself";
            this.chBxRemoveLocalplayer.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chBxRemoveLocalplayer.UseVisualStyleBackColor = true;
            // 
            // chBxRemoveNeutral
            // 
            this.chBxRemoveNeutral.AutoSize = true;
            this.chBxRemoveNeutral.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chBxRemoveNeutral.LanguageFile = "";
            this.chBxRemoveNeutral.Location = new System.Drawing.Point(25, 71);
            this.chBxRemoveNeutral.Name = "chBxRemoveNeutral";
            this.chBxRemoveNeutral.Size = new System.Drawing.Size(103, 17);
            this.chBxRemoveNeutral.TabIndex = 17;
            this.chBxRemoveNeutral.Text = "Remove Neutral";
            this.chBxRemoveNeutral.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chBxRemoveNeutral.UseVisualStyleBackColor = true;
            // 
            // chBxRemoveAllie
            // 
            this.chBxRemoveAllie.AutoSize = true;
            this.chBxRemoveAllie.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chBxRemoveAllie.LanguageFile = "";
            this.chBxRemoveAllie.Location = new System.Drawing.Point(25, 48);
            this.chBxRemoveAllie.Name = "chBxRemoveAllie";
            this.chBxRemoveAllie.Size = new System.Drawing.Size(88, 17);
            this.chBxRemoveAllie.TabIndex = 16;
            this.chBxRemoveAllie.Text = "Remove Allie";
            this.chBxRemoveAllie.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chBxRemoveAllie.UseVisualStyleBackColor = true;
            // 
            // chBxRemoveAi
            // 
            this.chBxRemoveAi.AutoSize = true;
            this.chBxRemoveAi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chBxRemoveAi.LanguageFile = "";
            this.chBxRemoveAi.Location = new System.Drawing.Point(25, 25);
            this.chBxRemoveAi.Name = "chBxRemoveAi";
            this.chBxRemoveAi.Size = new System.Drawing.Size(78, 17);
            this.chBxRemoveAi.TabIndex = 15;
            this.chBxRemoveAi.Text = "Remove Ai";
            this.chBxRemoveAi.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chBxRemoveAi.UseVisualStyleBackColor = true;
            // 
            // btnFontName
            // 
            this.btnFontName.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFontName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFontName.LanguageFile = "";
            this.btnFontName.Location = new System.Drawing.Point(25, 163);
            this.btnFontName.Name = "btnFontName";
            this.btnFontName.Size = new System.Drawing.Size(121, 23);
            this.btnFontName.TabIndex = 10;
            this.btnFontName.Text = "FontName:";
            this.btnFontName.UseVisualStyleBackColor = true;
            // 
            // UiBasics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbBasicOptions);
            this.Name = "UiBasics";
            this.Size = new System.Drawing.Size(210, 248);
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
