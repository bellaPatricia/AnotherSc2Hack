using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace AnotherSc2Hack.Classes.FrontEnds.Container
{
    partial class PanelOverlayProductiontab
    {
        /// <summary> 
        /// Erforderliche Designervariable.
        /// </summary>
        private IContainer components = null;

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
            this.pnlLauncher = new PanelSettingsLauncher();
            this.pnlSpecial = new PanelSettingsSpecialUnittab();
            this.pnlBasics = new PanelSettingsBasicProductiontab();
            this.SuspendLayout();
            // 
            // pnlLauncher
            // 
            this.pnlLauncher.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.pnlLauncher.Location = new Point(436, 0);
            this.pnlLauncher.Margin = new Padding(4, 5, 4, 5);
            this.pnlLauncher.Name = "pnlLauncher";
            this.pnlLauncher.Size = new Size(268, 261);
            this.pnlLauncher.TabIndex = 1;
            // 
            // pnlSpecial
            // 
            this.pnlSpecial.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.pnlSpecial.Location = new Point(711, 0);
            this.pnlSpecial.Margin = new Padding(3, 5, 3, 5);
            this.pnlSpecial.Name = "pnlSpecial";
            this.pnlSpecial.Size = new Size(193, 261);
            this.pnlSpecial.TabIndex = 2;
            // 
            // pnlBasics
            // 
            this.pnlBasics.Location = new Point(0, 0);
            this.pnlBasics.Name = "pnlBasics";
            this.pnlBasics.Size = new Size(399, 349);
            this.pnlBasics.TabIndex = 3;
            // 
            // PanelOverlayProductiontab
            // 
            this.AutoScaleDimensions = new SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.Controls.Add(this.pnlBasics);
            this.Controls.Add(this.pnlSpecial);
            this.Controls.Add(this.pnlLauncher);
            this.Name = "PanelOverlayProductiontab";
            this.Size = new Size(912, 348);
            this.ResumeLayout(false);

        }

        #endregion

        public PanelSettingsLauncher pnlLauncher;
        public PanelSettingsSpecialUnittab pnlSpecial;
        public PanelSettingsBasicProductiontab pnlBasics;

    }
}
