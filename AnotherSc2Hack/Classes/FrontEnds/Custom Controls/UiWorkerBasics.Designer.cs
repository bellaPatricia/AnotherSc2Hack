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
            this.gbBasicOptions = new AnotherSc2Hack.Classes.FrontEnds.LanguageGroupbox();
            this.OcUiOpacity = new AnotherSc2Hack.Classes.FrontEnds.UiOpacityControl();
            this.chBxDrawBackground = new AnotherSc2Hack.Classes.FrontEnds.LanguageCheckbox();
            this.btnFontName = new System.Windows.Forms.Button();
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
            this.gbBasicOptions.Controls.Add(this.btnFontName);
            this.gbBasicOptions.LanguageFile = "";
            this.gbBasicOptions.Location = new System.Drawing.Point(0, 0);
            this.gbBasicOptions.Name = "gbBasicOptions";
            this.gbBasicOptions.Size = new System.Drawing.Size(210, 136);
            this.gbBasicOptions.TabIndex = 47;
            this.gbBasicOptions.TabStop = false;
            this.gbBasicOptions.Text = "Basic Panel Options";
            // 
            // OcUiOpacity
            // 
            this.OcUiOpacity.Location = new System.Drawing.Point(25, 77);
            this.OcUiOpacity.Name = "OcUiOpacity";
            this.OcUiOpacity.Size = new System.Drawing.Size(150, 53);
            this.OcUiOpacity.TabIndex = 48;
            // 
            // chBxDrawBackground
            // 
            this.chBxDrawBackground.AutoSize = true;
            this.chBxDrawBackground.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chBxDrawBackground.LanguageFile = "";
            this.chBxDrawBackground.Location = new System.Drawing.Point(25, 25);
            this.chBxDrawBackground.Name = "chBxDrawBackground";
            this.chBxDrawBackground.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chBxDrawBackground.Size = new System.Drawing.Size(109, 17);
            this.chBxDrawBackground.TabIndex = 47;
            this.chBxDrawBackground.Text = "DrawBackground";
            this.chBxDrawBackground.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chBxDrawBackground.UseVisualStyleBackColor = true;
            // 
            // btnFontName
            // 
            this.btnFontName.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFontName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFontName.Location = new System.Drawing.Point(25, 48);
            this.btnFontName.Name = "btnFontName";
            this.btnFontName.Size = new System.Drawing.Size(121, 23);
            this.btnFontName.TabIndex = 41;
            this.btnFontName.Text = "FontName:";
            this.btnFontName.UseVisualStyleBackColor = true;
            // 
            // UiWorkerBasics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbBasicOptions);
            this.Name = "UiWorkerBasics";
            this.Size = new System.Drawing.Size(210, 136);
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
