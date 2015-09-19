using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using AnotherSc2Hack.Classes.FrontEnds.Custom_Controls;
using Utilities.Events;

namespace AnotherSc2Hack.Classes.FrontEnds.Container
{
    partial class PanelSettingsSpecialUnittab
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
            this.lblSpecial = new LanguageLabel();
            this.lblSize = new LanguageLabel();
            this.ntxtSize = new NumberTextBox();
            this.lblPreview = new LanguageLabel();
            this.pnlPreview = new Panel();
            this.SuspendLayout();
            // 
            // lblSpecial
            // 
            this.lblSpecial.AutoSize = true;
            this.lblSpecial.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            this.lblSpecial.ForeColor = Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(78)))), ((int)(((byte)(90)))));
            this.lblSpecial.LanguageFile = "";
            this.lblSpecial.Location = new Point(3, 3);
            this.lblSpecial.Name = "lblSpecial";
            this.lblSpecial.Size = new Size(57, 20);
            this.lblSpecial.TabIndex = 23;
            this.lblSpecial.Text = "Special";
            // 
            // lblSize
            // 
            this.lblSize.AutoSize = true;
            this.lblSize.LanguageFile = "";
            this.lblSize.Location = new Point(3, 34);
            this.lblSize.Name = "lblSize";
            this.lblSize.Size = new Size(39, 20);
            this.lblSize.TabIndex = 24;
            this.lblSize.Text = "Size:";
            // 
            // ntxtSize
            // 
            this.ntxtSize.Location = new Point(86, 31);
            this.ntxtSize.Name = "ntxtSize";
            this.ntxtSize.Number = 45;
            this.ntxtSize.Size = new Size(100, 27);
            this.ntxtSize.TabIndex = 25;
            this.ntxtSize.Text = "45";
            this.ntxtSize.NumberChanged += new NumberChangeHandler(this.ntxtSize_NumberChanged);
            // 
            // lblPreview
            // 
            this.lblPreview.AutoSize = true;
            this.lblPreview.LanguageFile = "";
            this.lblPreview.Location = new Point(3, 64);
            this.lblPreview.Name = "lblPreview";
            this.lblPreview.Size = new Size(63, 20);
            this.lblPreview.TabIndex = 26;
            this.lblPreview.Text = "Preview:";
            // 
            // pnlPreview
            // 
            this.pnlPreview.Location = new Point(86, 64);
            this.pnlPreview.Name = "pnlPreview";
            this.pnlPreview.Size = new Size(45, 45);
            this.pnlPreview.TabIndex = 27;
            this.pnlPreview.Paint += new PaintEventHandler(this.pnlPreview_Paint);
            // 
            // PanelSettingsSpecialUnittab
            // 
            this.AutoScaleDimensions = new SizeF(8F, 20F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.Controls.Add(this.pnlPreview);
            this.Controls.Add(this.lblPreview);
            this.Controls.Add(this.ntxtSize);
            this.Controls.Add(this.lblSize);
            this.Controls.Add(this.lblSpecial);
            this.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new Padding(3, 5, 3, 5);
            this.Name = "PanelSettingsSpecialUnittab";
            this.Size = new Size(193, 119);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private LanguageLabel lblSpecial;
        private LanguageLabel lblSize;
        public NumberTextBox ntxtSize;
        private LanguageLabel lblPreview;
        public Panel pnlPreview;
    }
}
