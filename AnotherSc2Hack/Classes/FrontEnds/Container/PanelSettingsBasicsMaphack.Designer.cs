using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using AnotherSc2Hack.Classes.FrontEnds.Custom_Controls;

namespace AnotherSc2Hack.Classes.FrontEnds.Container
{
    partial class PanelSettingsBasicsMaphack
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
            this.OpacityControl = new UiOpacityControl();
            this.lblBasics = new LanguageLabel();
            this.aChBxRemoveDestinationLine = new AnotherCheckbox();
            this.aChBxDefensiveStructures = new AnotherCheckbox();
            this.btnColorDestinationline = new LanguageButton();
            this.aChBxRemoveCamera = new AnotherCheckbox();
            this.aChBxRemoveVisionArea = new AnotherCheckbox();
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
            // OpacityControl
            // 
            this.OpacityControl.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.OpacityControl.Location = new Point(7, 164);
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
            // aChBxRemoveDestinationLine
            // 
            this.aChBxRemoveDestinationLine.Checked = false;
            this.aChBxRemoveDestinationLine.Clickable = true;
            this.aChBxRemoveDestinationLine.Cursor = Cursors.Hand;
            this.aChBxRemoveDestinationLine.DisplayText = "Remove Destinationline";
            this.aChBxRemoveDestinationLine.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.aChBxRemoveDestinationLine.Location = new Point(167, 94);
            this.aChBxRemoveDestinationLine.Name = "aChBxRemoveDestinationLine";
            this.aChBxRemoveDestinationLine.RightToLeft = RightToLeft.No;
            this.aChBxRemoveDestinationLine.Size = new Size(197, 30);
            this.aChBxRemoveDestinationLine.TabIndex = 1;
            this.aChBxRemoveDestinationLine.TextAlign = AnotherCheckbox.TextAlignment.Right;
            // 
            // aChBxDefensiveStructures
            // 
            this.aChBxDefensiveStructures.Checked = false;
            this.aChBxDefensiveStructures.Clickable = true;
            this.aChBxDefensiveStructures.Cursor = Cursors.Hand;
            this.aChBxDefensiveStructures.DisplayText = "Color Defensives";
            this.aChBxDefensiveStructures.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.aChBxDefensiveStructures.Location = new Point(167, 126);
            this.aChBxDefensiveStructures.Name = "aChBxDefensiveStructures";
            this.aChBxDefensiveStructures.RightToLeft = RightToLeft.No;
            this.aChBxDefensiveStructures.Size = new Size(150, 30);
            this.aChBxDefensiveStructures.TabIndex = 2;
            this.aChBxDefensiveStructures.TextAlign = AnotherCheckbox.TextAlignment.Right;
            // 
            // btnColorDestinationline
            // 
            this.btnColorDestinationline.BackColor = Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.btnColorDestinationline.FlatAppearance.BorderColor = Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(193)))), ((int)(((byte)(193)))));
            this.btnColorDestinationline.FlatStyle = FlatStyle.Flat;
            this.btnColorDestinationline.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.btnColorDestinationline.LanguageFile = "";
            this.btnColorDestinationline.Location = new Point(370, 94);
            this.btnColorDestinationline.Name = "btnColorDestinationline";
            this.btnColorDestinationline.Size = new Size(29, 30);
            this.btnColorDestinationline.TabIndex = 15;
            this.btnColorDestinationline.Text = "...";
            this.btnColorDestinationline.UseVisualStyleBackColor = false;
            // 
            // aChBxRemoveCamera
            // 
            this.aChBxRemoveCamera.Checked = false;
            this.aChBxRemoveCamera.Clickable = true;
            this.aChBxRemoveCamera.Cursor = Cursors.Hand;
            this.aChBxRemoveCamera.DisplayText = "Remove Camera";
            this.aChBxRemoveCamera.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.aChBxRemoveCamera.Location = new Point(167, 30);
            this.aChBxRemoveCamera.Name = "aChBxRemoveCamera";
            this.aChBxRemoveCamera.RightToLeft = RightToLeft.No;
            this.aChBxRemoveCamera.Size = new Size(148, 30);
            this.aChBxRemoveCamera.TabIndex = 3;
            this.aChBxRemoveCamera.TextAlign = AnotherCheckbox.TextAlignment.Right;
            // 
            // aChBxRemoveVisionArea
            // 
            this.aChBxRemoveVisionArea.Checked = false;
            this.aChBxRemoveVisionArea.Clickable = true;
            this.aChBxRemoveVisionArea.Cursor = Cursors.Hand;
            this.aChBxRemoveVisionArea.DisplayText = "Remove Vision-Area";
            this.aChBxRemoveVisionArea.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.aChBxRemoveVisionArea.Location = new Point(167, 62);
            this.aChBxRemoveVisionArea.Name = "aChBxRemoveVisionArea";
            this.aChBxRemoveVisionArea.RightToLeft = RightToLeft.No;
            this.aChBxRemoveVisionArea.Size = new Size(174, 30);
            this.aChBxRemoveVisionArea.TabIndex = 4;
            this.aChBxRemoveVisionArea.TextAlign = AnotherCheckbox.TextAlignment.Right;
            // 
            // PanelSettingsBasicsMaphack
            // 
            this.AutoScaleDimensions = new SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.Controls.Add(this.aChBxRemoveVisionArea);
            this.Controls.Add(this.aChBxRemoveCamera);
            this.Controls.Add(this.btnColorDestinationline);
            this.Controls.Add(this.aChBxDefensiveStructures);
            this.Controls.Add(this.aChBxRemoveDestinationLine);
            this.Controls.Add(this.lblBasics);
            this.Controls.Add(this.OpacityControl);
            this.Controls.Add(this.aChBxRemoveYourself);
            this.Controls.Add(this.aChBxRemoveNeutral);
            this.Controls.Add(this.aChBxRemoveAllie);
            this.Controls.Add(this.aChBxRemoveAi);
            this.Name = "PanelSettingsBasicsMaphack";
            this.Size = new Size(455, 246);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public AnotherCheckbox aChBxRemoveAi;
        public AnotherCheckbox aChBxRemoveAllie;
        public AnotherCheckbox aChBxRemoveNeutral;
        public AnotherCheckbox aChBxRemoveYourself;
        private LanguageLabel lblBasics;
        public UiOpacityControl OpacityControl;
        public AnotherCheckbox aChBxRemoveDestinationLine;
        public AnotherCheckbox aChBxDefensiveStructures;
        public LanguageButton btnColorDestinationline;
        public AnotherCheckbox aChBxRemoveCamera;
        public AnotherCheckbox aChBxRemoveVisionArea;

    }
}
