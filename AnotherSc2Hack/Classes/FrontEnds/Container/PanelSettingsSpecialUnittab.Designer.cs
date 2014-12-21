namespace AnotherSc2Hack.Classes.FrontEnds.Container
{
    partial class PanelSettingsSpecialUnittab
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
            this.languageLabel1 = new AnotherSc2Hack.Classes.FrontEnds.LanguageLabel();
            this.label4 = new AnotherSc2Hack.Classes.FrontEnds.LanguageLabel();
            this.ntxtSize = new AnotherSc2Hack.Classes.FrontEnds.NumberTextBox();
            this.languageLabel2 = new AnotherSc2Hack.Classes.FrontEnds.LanguageLabel();
            this.pnlPreview = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // languageLabel1
            // 
            this.languageLabel1.AutoSize = true;
            this.languageLabel1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.languageLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(78)))), ((int)(((byte)(90)))));
            this.languageLabel1.LanguageFile = "";
            this.languageLabel1.Location = new System.Drawing.Point(3, 3);
            this.languageLabel1.Name = "languageLabel1";
            this.languageLabel1.Size = new System.Drawing.Size(57, 20);
            this.languageLabel1.TabIndex = 23;
            this.languageLabel1.Text = "Special";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.LanguageFile = "";
            this.label4.Location = new System.Drawing.Point(3, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 20);
            this.label4.TabIndex = 24;
            this.label4.Text = "Size:";
            // 
            // ntxtSize
            // 
            this.ntxtSize.Location = new System.Drawing.Point(86, 31);
            this.ntxtSize.Name = "ntxtSize";
            this.ntxtSize.Number = 45;
            this.ntxtSize.Size = new System.Drawing.Size(100, 27);
            this.ntxtSize.TabIndex = 25;
            this.ntxtSize.Text = "45";
            this.ntxtSize.NumberChanged += new AnotherSc2Hack.Classes.FrontEnds.NumberChangeHandler(this.ntxtSize_NumberChanged);
            // 
            // languageLabel2
            // 
            this.languageLabel2.AutoSize = true;
            this.languageLabel2.LanguageFile = "";
            this.languageLabel2.Location = new System.Drawing.Point(3, 64);
            this.languageLabel2.Name = "languageLabel2";
            this.languageLabel2.Size = new System.Drawing.Size(63, 20);
            this.languageLabel2.TabIndex = 26;
            this.languageLabel2.Text = "Preview:";
            // 
            // pnlPreview
            // 
            this.pnlPreview.Location = new System.Drawing.Point(86, 64);
            this.pnlPreview.Name = "pnlPreview";
            this.pnlPreview.Size = new System.Drawing.Size(45, 45);
            this.pnlPreview.TabIndex = 27;
            this.pnlPreview.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlPreview_Paint);
            // 
            // PanelSettingsSpecialUnittab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlPreview);
            this.Controls.Add(this.languageLabel2);
            this.Controls.Add(this.ntxtSize);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.languageLabel1);
            this.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "PanelSettingsSpecialUnittab";
            this.Size = new System.Drawing.Size(193, 119);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private LanguageLabel languageLabel1;
        private LanguageLabel label4;
        public NumberTextBox ntxtSize;
        private LanguageLabel languageLabel2;
        public System.Windows.Forms.Panel pnlPreview;
    }
}
