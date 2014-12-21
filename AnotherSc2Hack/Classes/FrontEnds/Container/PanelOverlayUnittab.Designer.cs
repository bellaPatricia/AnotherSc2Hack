namespace AnotherSc2Hack.Classes.FrontEnds.Container
{
    partial class PanelOverlayUnittab
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
            this.pnlBasics = new AnotherSc2Hack.Classes.FrontEnds.Container.PanelSettingsBasicUnittab();
            this.pnlLauncher = new AnotherSc2Hack.Classes.FrontEnds.Container.PanelSettingsLauncher();
            this.pnlSpecial = new AnotherSc2Hack.Classes.FrontEnds.Container.PanelSettingsSpecialUnittab();
            this.SuspendLayout();
            // 
            // pnlBasics
            // 
            this.pnlBasics.Location = new System.Drawing.Point(0, 0);
            this.pnlBasics.Name = "pnlBasics";
            this.pnlBasics.Size = new System.Drawing.Size(429, 349);
            this.pnlBasics.TabIndex = 0;
            // 
            // pnlLauncher
            // 
            this.pnlLauncher.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlLauncher.Location = new System.Drawing.Point(436, 0);
            this.pnlLauncher.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlLauncher.Name = "pnlLauncher";
            this.pnlLauncher.Size = new System.Drawing.Size(268, 261);
            this.pnlLauncher.TabIndex = 1;
            // 
            // pnlSpecial
            // 
            this.pnlSpecial.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlSpecial.Location = new System.Drawing.Point(711, 0);
            this.pnlSpecial.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.pnlSpecial.Name = "pnlSpecial";
            this.pnlSpecial.Size = new System.Drawing.Size(193, 261);
            this.pnlSpecial.TabIndex = 2;
            // 
            // PanelOverlayUnittab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlSpecial);
            this.Controls.Add(this.pnlLauncher);
            this.Controls.Add(this.pnlBasics);
            this.Name = "PanelOverlayUnittab";
            this.Size = new System.Drawing.Size(912, 348);
            this.ResumeLayout(false);

        }

        #endregion

        public PanelSettingsBasicUnittab pnlBasics;
        public PanelSettingsLauncher pnlLauncher;
        public PanelSettingsSpecialUnittab pnlSpecial;

    }
}
