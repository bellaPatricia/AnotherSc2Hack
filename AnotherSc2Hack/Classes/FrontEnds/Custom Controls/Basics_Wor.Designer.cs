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
            this.gbBasicOptions = new LanguageGroupbox();
            this.chBxDrawBackground = new LanguageCheckbox();
            this.lblFontName = new LanguageLabel();
            this.lblOpacityText = new LanguageLabel();
            this.btnFontName = new System.Windows.Forms.Button();
            this.lblOpacity = new System.Windows.Forms.Label();
            this.tbOpacity = new System.Windows.Forms.TrackBar();
            this.gbBasicOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbOpacity)).BeginInit();
            this.SuspendLayout();
            // 
            // gbBasicOptions
            // 
            this.gbBasicOptions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbBasicOptions.Controls.Add(this.chBxDrawBackground);
            this.gbBasicOptions.Controls.Add(this.lblFontName);
            this.gbBasicOptions.Controls.Add(this.lblOpacityText);
            this.gbBasicOptions.Controls.Add(this.btnFontName);
            this.gbBasicOptions.Controls.Add(this.lblOpacity);
            this.gbBasicOptions.Controls.Add(this.tbOpacity);
            this.gbBasicOptions.Location = new System.Drawing.Point(0, 0);
            this.gbBasicOptions.Name = "gbBasicOptions";
            this.gbBasicOptions.Size = new System.Drawing.Size(291, 141);
            this.gbBasicOptions.TabIndex = 47;
            this.gbBasicOptions.TabStop = false;
            this.gbBasicOptions.Text = "Basic Panel Options";
            // 
            // chBxDrawBackground
            // 
            this.chBxDrawBackground.AutoSize = true;
            this.chBxDrawBackground.Location = new System.Drawing.Point(25, 60);
            this.chBxDrawBackground.Name = "chBxDrawBackground";
            this.chBxDrawBackground.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chBxDrawBackground.Size = new System.Drawing.Size(109, 17);
            this.chBxDrawBackground.TabIndex = 47;
            this.chBxDrawBackground.Text = "DrawBackground";
            this.chBxDrawBackground.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chBxDrawBackground.UseVisualStyleBackColor = true;
            // 
            // lblFontName
            // 
            this.lblFontName.AutoSize = true;
            this.lblFontName.Location = new System.Drawing.Point(25, 30);
            this.lblFontName.Name = "lblFontName";
            this.lblFontName.Size = new System.Drawing.Size(62, 13);
            this.lblFontName.TabIndex = 39;
            this.lblFontName.Text = "Font Name:";
            // 
            // lblOpacityText
            // 
            this.lblOpacityText.AutoSize = true;
            this.lblOpacityText.Location = new System.Drawing.Point(25, 90);
            this.lblOpacityText.Name = "lblOpacityText";
            this.lblOpacityText.Size = new System.Drawing.Size(46, 13);
            this.lblOpacityText.TabIndex = 40;
            this.lblOpacityText.Text = "Opacity:";
            // 
            // btnFontName
            // 
            this.btnFontName.Location = new System.Drawing.Point(153, 25);
            this.btnFontName.Name = "btnFontName";
            this.btnFontName.Size = new System.Drawing.Size(121, 23);
            this.btnFontName.TabIndex = 41;
            this.btnFontName.Text = "FontName:";
            this.btnFontName.UseVisualStyleBackColor = true;
            // 
            // lblOpacity
            // 
            this.lblOpacity.AutoSize = true;
            this.lblOpacity.Location = new System.Drawing.Point(150, 122);
            this.lblOpacity.Name = "lblOpacity";
            this.lblOpacity.Size = new System.Drawing.Size(35, 13);
            this.lblOpacity.TabIndex = 43;
            this.lblOpacity.Text = "label9";
            // 
            // tbOpacity
            // 
            this.tbOpacity.Location = new System.Drawing.Point(153, 90);
            this.tbOpacity.Maximum = 100;
            this.tbOpacity.Name = "tbOpacity";
            this.tbOpacity.Size = new System.Drawing.Size(121, 45);
            this.tbOpacity.TabIndex = 42;
            // 
            // BasicsWor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbBasicOptions);
            this.Name = "BasicsWor";
            this.Size = new System.Drawing.Size(291, 141);
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
