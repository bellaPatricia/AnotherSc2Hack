namespace AnotherSc2Hack.Classes.FrontEnds.Container
{
    partial class PanelOverlayWorker
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
            this.aChBxDrawBackground = new AnotherSc2Hack.Classes.FrontEnds.AnotherCheckbox();
            this.languageLabel1 = new AnotherSc2Hack.Classes.FrontEnds.LanguageLabel();
            this.btnSetFont = new LanguageButton();
            this.OpacityControl = new AnotherSc2Hack.Classes.FrontEnds.UiOpacityControl();
            this.pnlLauncher = new AnotherSc2Hack.Classes.FrontEnds.Container.PanelSettingsLauncher();
            this.SuspendLayout();
            // 
            // aChBxDrawBackground
            // 
            this.aChBxDrawBackground.Checked = false;
            this.aChBxDrawBackground.Clickable = true;
            this.aChBxDrawBackground.Cursor = System.Windows.Forms.Cursors.Hand;
            this.aChBxDrawBackground.DisplayText = "Draw Background";
            this.aChBxDrawBackground.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aChBxDrawBackground.Location = new System.Drawing.Point(7, 30);
            this.aChBxDrawBackground.Name = "aChBxDrawBackground";
            this.aChBxDrawBackground.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.aChBxDrawBackground.Size = new System.Drawing.Size(157, 30);
            this.aChBxDrawBackground.TabIndex = 5;
            this.aChBxDrawBackground.TextAlign = AnotherSc2Hack.Classes.FrontEnds.AnotherCheckbox.TextAlignment.Right;
            // 
            // languageLabel1
            // 
            this.languageLabel1.AutoSize = true;
            this.languageLabel1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.languageLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(78)))), ((int)(((byte)(90)))));
            this.languageLabel1.LanguageFile = "";
            this.languageLabel1.Location = new System.Drawing.Point(3, 3);
            this.languageLabel1.Name = "languageLabel1";
            this.languageLabel1.Size = new System.Drawing.Size(52, 20);
            this.languageLabel1.TabIndex = 14;
            this.languageLabel1.Text = "Basics";
            // 
            // btnSetFont
            // 
            this.btnSetFont.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.btnSetFont.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(193)))), ((int)(((byte)(193)))));
            this.btnSetFont.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSetFont.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSetFont.Location = new System.Drawing.Point(7, 63);
            this.btnSetFont.Name = "btnSetFont";
            this.btnSetFont.Size = new System.Drawing.Size(157, 29);
            this.btnSetFont.TabIndex = 15;
            this.btnSetFont.Text = "Set Font";
            this.btnSetFont.UseVisualStyleBackColor = false;
            // 
            // OpacityControl
            // 
            this.OpacityControl.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OpacityControl.Location = new System.Drawing.Point(7, 100);
            this.OpacityControl.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.OpacityControl.Name = "OpacityControl";
            this.OpacityControl.Number = 0;
            this.OpacityControl.Size = new System.Drawing.Size(153, 91);
            this.OpacityControl.TabIndex = 16;
            // 
            // pnlLauncher
            // 
            this.pnlLauncher.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlLauncher.Location = new System.Drawing.Point(180, 0);
            this.pnlLauncher.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlLauncher.Name = "pnlLauncher";
            this.pnlLauncher.Size = new System.Drawing.Size(268, 261);
            this.pnlLauncher.TabIndex = 17;
            // 
            // PanelOverlayWorker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlLauncher);
            this.Controls.Add(this.OpacityControl);
            this.Controls.Add(this.btnSetFont);
            this.Controls.Add(this.languageLabel1);
            this.Controls.Add(this.aChBxDrawBackground);
            this.Name = "PanelOverlayWorker";
            this.Size = new System.Drawing.Size(451, 262);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public AnotherCheckbox aChBxDrawBackground;
        private LanguageLabel languageLabel1;
        public LanguageButton btnSetFont;
        public UiOpacityControl OpacityControl;
        public PanelSettingsLauncher pnlLauncher;
    }
}
