namespace AnotherSc2Hack.Classes.FrontEnds.Container
{
    partial class PanelOverlayBasics
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
            this.pnlLauncher = new AnotherSc2Hack.Classes.FrontEnds.Container.PanelSettingsLauncher();
            this.pnlBasics = new AnotherSc2Hack.Classes.FrontEnds.Container.PanelSettingsBasics();
            this.SuspendLayout();
            // 
            // pnlLauncher
            // 
            this.pnlLauncher.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlLauncher.Location = new System.Drawing.Point(180, 0);
            this.pnlLauncher.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlLauncher.Name = "pnlLauncher";
            this.pnlLauncher.Size = new System.Drawing.Size(268, 261);
            this.pnlLauncher.TabIndex = 1;
            // 
            // pnlBasics
            // 
            this.pnlBasics.Location = new System.Drawing.Point(0, 0);
            this.pnlBasics.Name = "pnlBasics";
            this.pnlBasics.Size = new System.Drawing.Size(173, 346);
            this.pnlBasics.TabIndex = 0;
            // 
            // PanelOverlayBasics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlLauncher);
            this.Controls.Add(this.pnlBasics);
            this.Name = "PanelOverlayBasics";
            this.Size = new System.Drawing.Size(456, 346);
            this.ResumeLayout(false);

        }

        #endregion

        public PanelSettingsBasics pnlBasics;
        public PanelSettingsLauncher pnlLauncher;

    }
}
