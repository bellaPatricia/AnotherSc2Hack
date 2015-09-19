using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using AnotherSc2Hack.Classes.FrontEnds.Custom_Controls;

namespace AnotherSc2Hack.Classes.FrontEnds.Container
{
    partial class PanelSettingsBasics
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
            this.aChBxRemoveAi = new AnotherCheckbox();
            this.aChBxRemoveAllie = new AnotherCheckbox();
            this.aChBxRemoveNeutral = new AnotherCheckbox();
            this.aChBxRemoveYourself = new AnotherCheckbox();
            this.aChBxRemoveClantags = new AnotherCheckbox();
            this.OpacityControl = new UiOpacityControl();
            this.lblBasics = new LanguageLabel();
            this.aChBxDrawBackground = new AnotherCheckbox();
            this.btnSetFont = new LanguageButton();
            this.SuspendLayout();
            // 
            // aChBxRemoveAi
            // 
            this.aChBxRemoveAi.Checked = false;
            this.aChBxRemoveAi.Clickable = true;
            this.aChBxRemoveAi.Cursor = Cursors.Hand;
            this.aChBxRemoveAi.DisplayText = "Remove Ai";
            this.aChBxRemoveAi.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.aChBxRemoveAi.Location = new Point(7, 30);
            this.aChBxRemoveAi.Name = "aChBxRemoveAi";
            this.aChBxRemoveAi.RightToLeft = RightToLeft.No;
            this.aChBxRemoveAi.Size = new Size(111, 30);
            this.aChBxRemoveAi.TabIndex = 0;
            this.aChBxRemoveAi.TextAlign = AnotherCheckbox.TextAlignment.Right;
            // 
            // aChBxRemoveAllie
            // 
            this.aChBxRemoveAllie.Checked = false;
            this.aChBxRemoveAllie.Clickable = true;
            this.aChBxRemoveAllie.Cursor = Cursors.Hand;
            this.aChBxRemoveAllie.DisplayText = "Remove Allie";
            this.aChBxRemoveAllie.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.aChBxRemoveAllie.Location = new Point(7, 62);
            this.aChBxRemoveAllie.Name = "aChBxRemoveAllie";
            this.aChBxRemoveAllie.RightToLeft = RightToLeft.No;
            this.aChBxRemoveAllie.Size = new Size(127, 30);
            this.aChBxRemoveAllie.TabIndex = 1;
            this.aChBxRemoveAllie.TextAlign = AnotherCheckbox.TextAlignment.Right;
            // 
            // aChBxRemoveNeutral
            // 
            this.aChBxRemoveNeutral.Checked = false;
            this.aChBxRemoveNeutral.Clickable = true;
            this.aChBxRemoveNeutral.Cursor = Cursors.Hand;
            this.aChBxRemoveNeutral.DisplayText = "Remove Neutral";
            this.aChBxRemoveNeutral.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.aChBxRemoveNeutral.Location = new Point(7, 94);
            this.aChBxRemoveNeutral.Name = "aChBxRemoveNeutral";
            this.aChBxRemoveNeutral.RightToLeft = RightToLeft.No;
            this.aChBxRemoveNeutral.Size = new Size(146, 30);
            this.aChBxRemoveNeutral.TabIndex = 1;
            this.aChBxRemoveNeutral.TextAlign = AnotherCheckbox.TextAlignment.Right;
            // 
            // aChBxRemoveYourself
            // 
            this.aChBxRemoveYourself.Checked = false;
            this.aChBxRemoveYourself.Clickable = true;
            this.aChBxRemoveYourself.Cursor = Cursors.Hand;
            this.aChBxRemoveYourself.DisplayText = "Remove Yourself";
            this.aChBxRemoveYourself.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.aChBxRemoveYourself.Location = new Point(7, 126);
            this.aChBxRemoveYourself.Name = "aChBxRemoveYourself";
            this.aChBxRemoveYourself.RightToLeft = RightToLeft.No;
            this.aChBxRemoveYourself.Size = new Size(150, 30);
            this.aChBxRemoveYourself.TabIndex = 2;
            this.aChBxRemoveYourself.TextAlign = AnotherCheckbox.TextAlignment.Right;
            // 
            // aChBxRemoveClantags
            // 
            this.aChBxRemoveClantags.Checked = false;
            this.aChBxRemoveClantags.Clickable = true;
            this.aChBxRemoveClantags.Cursor = Cursors.Hand;
            this.aChBxRemoveClantags.DisplayText = "Remove Clantags";
            this.aChBxRemoveClantags.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.aChBxRemoveClantags.Location = new Point(7, 158);
            this.aChBxRemoveClantags.Name = "aChBxRemoveClantags";
            this.aChBxRemoveClantags.RightToLeft = RightToLeft.No;
            this.aChBxRemoveClantags.Size = new Size(154, 30);
            this.aChBxRemoveClantags.TabIndex = 3;
            this.aChBxRemoveClantags.TextAlign = AnotherCheckbox.TextAlignment.Right;
            // 
            // OpacityControl
            // 
            this.OpacityControl.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.OpacityControl.Location = new Point(7, 260);
            this.OpacityControl.Margin = new Padding(4, 5, 4, 5);
            this.OpacityControl.Name = "OpacityControl";
            this.OpacityControl.Number = 0;
            this.OpacityControl.Size = new Size(153, 91);
            this.OpacityControl.TabIndex = 4;
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
            this.lblBasics.TabIndex = 13;
            this.lblBasics.Text = "Basics";
            // 
            // aChBxDrawBackground
            // 
            this.aChBxDrawBackground.Checked = false;
            this.aChBxDrawBackground.Clickable = true;
            this.aChBxDrawBackground.Cursor = Cursors.Hand;
            this.aChBxDrawBackground.DisplayText = "Draw Background";
            this.aChBxDrawBackground.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.aChBxDrawBackground.Location = new Point(7, 190);
            this.aChBxDrawBackground.Name = "aChBxDrawBackground";
            this.aChBxDrawBackground.RightToLeft = RightToLeft.No;
            this.aChBxDrawBackground.Size = new Size(157, 30);
            this.aChBxDrawBackground.TabIndex = 4;
            this.aChBxDrawBackground.TextAlign = AnotherCheckbox.TextAlignment.Right;
            // 
            // btnSetFont
            // 
            this.btnSetFont.BackColor = Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.btnSetFont.FlatAppearance.BorderColor = Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(193)))), ((int)(((byte)(193)))));
            this.btnSetFont.FlatStyle = FlatStyle.Flat;
            this.btnSetFont.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.btnSetFont.LanguageFile = "";
            this.btnSetFont.Location = new Point(7, 223);
            this.btnSetFont.Name = "btnSetFont";
            this.btnSetFont.Size = new Size(157, 29);
            this.btnSetFont.TabIndex = 14;
            this.btnSetFont.Text = "Set Font";
            this.btnSetFont.UseVisualStyleBackColor = false;
            // 
            // PanelSettingsBasics
            // 
            this.AutoScaleDimensions = new SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.Controls.Add(this.btnSetFont);
            this.Controls.Add(this.aChBxDrawBackground);
            this.Controls.Add(this.lblBasics);
            this.Controls.Add(this.OpacityControl);
            this.Controls.Add(this.aChBxRemoveClantags);
            this.Controls.Add(this.aChBxRemoveYourself);
            this.Controls.Add(this.aChBxRemoveNeutral);
            this.Controls.Add(this.aChBxRemoveAllie);
            this.Controls.Add(this.aChBxRemoveAi);
            this.Name = "PanelSettingsBasics";
            this.Size = new Size(173, 346);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public AnotherCheckbox aChBxRemoveAi;
        public AnotherCheckbox aChBxRemoveAllie;
        public AnotherCheckbox aChBxRemoveNeutral;
        public AnotherCheckbox aChBxRemoveYourself;
        public AnotherCheckbox aChBxRemoveClantags;
        private LanguageLabel lblBasics;
        public AnotherCheckbox aChBxDrawBackground;
        public LanguageButton btnSetFont;
        public UiOpacityControl OpacityControl;

    }
}
