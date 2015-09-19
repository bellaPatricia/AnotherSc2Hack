using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using AnotherSc2Hack.Classes.FrontEnds.Custom_Controls;

namespace AnotherSc2Hack.Classes.FrontEnds.Container
{
    partial class PanelOverlayWorker
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
            this.aChBxDrawBackground = new AnotherCheckbox();
            this.lblBasics = new LanguageLabel();
            this.btnSetFont = new LanguageButton();
            this.OpacityControl = new UiOpacityControl();
            this.pnlLauncher = new PanelSettingsLauncher();
            this.SuspendLayout();
            // 
            // aChBxDrawBackground
            // 
            this.aChBxDrawBackground.Checked = false;
            this.aChBxDrawBackground.Clickable = true;
            this.aChBxDrawBackground.Cursor = Cursors.Hand;
            this.aChBxDrawBackground.DisplayText = "Draw Background";
            this.aChBxDrawBackground.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.aChBxDrawBackground.Location = new Point(7, 30);
            this.aChBxDrawBackground.Name = "aChBxDrawBackground";
            this.aChBxDrawBackground.RightToLeft = RightToLeft.No;
            this.aChBxDrawBackground.Size = new Size(157, 30);
            this.aChBxDrawBackground.TabIndex = 5;
            this.aChBxDrawBackground.TextAlign = AnotherCheckbox.TextAlignment.Right;
            // 
            // lblBasics
            // 
            this.lblBasics.AutoSize = true;
            this.lblBasics.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            this.lblBasics.ForeColor = Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(78)))), ((int)(((byte)(90)))));
            this.lblBasics.LanguageFile = "";
            this.lblBasics.Location = new Point(3, 3);
            this.lblBasics.Name = "lblBasics";
            this.lblBasics.Size = new Size(52, 20);
            this.lblBasics.TabIndex = 14;
            this.lblBasics.Text = "Basics";
            // 
            // btnSetFont
            // 
            this.btnSetFont.BackColor = Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.btnSetFont.FlatAppearance.BorderColor = Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(193)))), ((int)(((byte)(193)))));
            this.btnSetFont.FlatStyle = FlatStyle.Flat;
            this.btnSetFont.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.btnSetFont.LanguageFile = "";
            this.btnSetFont.Location = new Point(7, 63);
            this.btnSetFont.Name = "btnSetFont";
            this.btnSetFont.Size = new Size(157, 29);
            this.btnSetFont.TabIndex = 15;
            this.btnSetFont.Text = "Set Font";
            this.btnSetFont.UseVisualStyleBackColor = false;
            // 
            // OpacityControl
            // 
            this.OpacityControl.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.OpacityControl.Location = new Point(7, 100);
            this.OpacityControl.Margin = new Padding(4, 5, 4, 5);
            this.OpacityControl.Name = "OpacityControl";
            this.OpacityControl.Number = 0;
            this.OpacityControl.Size = new Size(153, 91);
            this.OpacityControl.TabIndex = 16;
            // 
            // pnlLauncher
            // 
            this.pnlLauncher.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.pnlLauncher.Location = new Point(180, 0);
            this.pnlLauncher.Margin = new Padding(4, 5, 4, 5);
            this.pnlLauncher.Name = "pnlLauncher";
            this.pnlLauncher.Size = new Size(268, 261);
            this.pnlLauncher.TabIndex = 17;
            // 
            // PanelOverlayWorker
            // 
            this.AutoScaleDimensions = new SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.Controls.Add(this.pnlLauncher);
            this.Controls.Add(this.OpacityControl);
            this.Controls.Add(this.btnSetFont);
            this.Controls.Add(this.lblBasics);
            this.Controls.Add(this.aChBxDrawBackground);
            this.Name = "PanelOverlayWorker";
            this.Size = new Size(451, 262);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public AnotherCheckbox aChBxDrawBackground;
        private LanguageLabel lblBasics;
        public LanguageButton btnSetFont;
        public UiOpacityControl OpacityControl;
        public PanelSettingsLauncher pnlLauncher;
    }
}
