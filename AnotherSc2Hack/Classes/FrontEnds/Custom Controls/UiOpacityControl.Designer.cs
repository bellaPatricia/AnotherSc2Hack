using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace AnotherSc2Hack.Classes.FrontEnds.Custom_Controls
{
    partial class UiOpacityControl
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
            this.lblOpacity = new Label();
            this.tbOpacity = new TrackBar();
            ((ISupportInitialize)(this.tbOpacity)).BeginInit();
            this.SuspendLayout();
            // 
            // lblOpacity
            // 
            this.lblOpacity.Anchor = ((AnchorStyles)((((AnchorStyles.Top | AnchorStyles.Bottom) 
            | AnchorStyles.Left) 
            | AnchorStyles.Right)));
            this.lblOpacity.ImeMode = ImeMode.NoControl;
            this.lblOpacity.Location = new Point(-3, 35);
            this.lblOpacity.Name = "lblOpacity";
            this.lblOpacity.Size = new Size(153, 13);
            this.lblOpacity.TabIndex = 14;
            this.lblOpacity.Text = "Blubb";
            // 
            // tbOpacity
            // 
            this.tbOpacity.Anchor = ((AnchorStyles)((((AnchorStyles.Top | AnchorStyles.Bottom) 
            | AnchorStyles.Left) 
            | AnchorStyles.Right)));
            this.tbOpacity.ImeMode = ImeMode.NoControl;
            this.tbOpacity.Location = new Point(0, 3);
            this.tbOpacity.Maximum = 100;
            this.tbOpacity.Name = "tbOpacity";
            this.tbOpacity.Size = new Size(147, 45);
            this.tbOpacity.TabIndex = 13;
            this.tbOpacity.Scroll += new EventHandler(this.tbOpacity_Scroll);
            this.tbOpacity.ValueChanged += new EventHandler(this.tbOpacity_ValueChanged);
            // 
            // UiOpacityControl
            // 
            this.AutoScaleDimensions = new SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.Controls.Add(this.lblOpacity);
            this.Controls.Add(this.tbOpacity);
            this.Name = "UiOpacityControl";
            this.Size = new Size(150, 53);
            ((ISupportInitialize)(this.tbOpacity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public Label lblOpacity;
        public TrackBar tbOpacity;
    }
}
