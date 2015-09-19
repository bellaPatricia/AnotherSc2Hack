using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using AnotherSc2Hack.Classes.FrontEnds.Custom_Controls;

namespace AnotherSc2Hack.Classes.FrontEnds.Container
{
    partial class PanelSettingsBasicProductiontab
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
            this.btnSetFont = new LanguageButton();
            this.lblBasics = new LanguageLabel();
            this.OpacityControl = new UiOpacityControl();
            this.aChBxRemoveClantags = new AnotherCheckbox();
            this.aChBxRemoveYourself = new AnotherCheckbox();
            this.aChBxRemoveNeutral = new AnotherCheckbox();
            this.aChBxRemoveAllie = new AnotherCheckbox();
            this.aChBxRemoveAi = new AnotherCheckbox();
            this.aChBxRemoveChronoboost = new AnotherCheckbox();
            this.aChBxSplitUnitsBuildings = new AnotherCheckbox();
            this.aChBxDisplayBuildings = new AnotherCheckbox();
            this.aChBxDisplayUnits = new AnotherCheckbox();
            this.aChBxTransparentImages = new AnotherCheckbox();
            this.aChBxDisplayUpgrades = new AnotherCheckbox();
            this.SuspendLayout();
            // 
            // btnSetFont
            // 
            this.btnSetFont.BackColor = Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.btnSetFont.FlatAppearance.BorderColor = Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(193)))), ((int)(((byte)(193)))));
            this.btnSetFont.FlatStyle = FlatStyle.Flat;
            this.btnSetFont.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.btnSetFont.LanguageFile = "";
            this.btnSetFont.Location = new Point(7, 222);
            this.btnSetFont.Name = "btnSetFont";
            this.btnSetFont.Size = new Size(183, 29);
            this.btnSetFont.TabIndex = 23;
            this.btnSetFont.Text = "Set Font";
            this.btnSetFont.UseVisualStyleBackColor = false;
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
            this.lblBasics.TabIndex = 22;
            this.lblBasics.Text = "Basics";
            // 
            // OpacityControl
            // 
            this.OpacityControl.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.OpacityControl.Location = new Point(7, 259);
            this.OpacityControl.Margin = new Padding(4, 5, 4, 5);
            this.OpacityControl.Name = "OpacityControl";
            this.OpacityControl.Number = 0;
            this.OpacityControl.Size = new Size(183, 91);
            this.OpacityControl.TabIndex = 21;
            // 
            // aChBxRemoveClantags
            // 
            this.aChBxRemoveClantags.AutoSize = true;
            this.aChBxRemoveClantags.Checked = false;
            this.aChBxRemoveClantags.Clickable = true;
            this.aChBxRemoveClantags.Cursor = Cursors.Hand;
            this.aChBxRemoveClantags.DisplayText = "Remove Clantags";
            this.aChBxRemoveClantags.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.aChBxRemoveClantags.Location = new Point(7, 158);
            this.aChBxRemoveClantags.Name = "aChBxRemoveClantags";
            this.aChBxRemoveClantags.RightToLeft = RightToLeft.No;
            this.aChBxRemoveClantags.Size = new Size(154, 30);
            this.aChBxRemoveClantags.TabIndex = 19;
            this.aChBxRemoveClantags.TextAlign = AnotherCheckbox.TextAlignment.Right;
            // 
            // aChBxRemoveYourself
            // 
            this.aChBxRemoveYourself.AutoSize = true;
            this.aChBxRemoveYourself.Checked = false;
            this.aChBxRemoveYourself.Clickable = true;
            this.aChBxRemoveYourself.Cursor = Cursors.Hand;
            this.aChBxRemoveYourself.DisplayText = "Remove Yourself";
            this.aChBxRemoveYourself.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.aChBxRemoveYourself.Location = new Point(7, 126);
            this.aChBxRemoveYourself.Name = "aChBxRemoveYourself";
            this.aChBxRemoveYourself.RightToLeft = RightToLeft.No;
            this.aChBxRemoveYourself.Size = new Size(150, 30);
            this.aChBxRemoveYourself.TabIndex = 18;
            this.aChBxRemoveYourself.TextAlign = AnotherCheckbox.TextAlignment.Right;
            // 
            // aChBxRemoveNeutral
            // 
            this.aChBxRemoveNeutral.AutoSize = true;
            this.aChBxRemoveNeutral.Checked = false;
            this.aChBxRemoveNeutral.Clickable = true;
            this.aChBxRemoveNeutral.Cursor = Cursors.Hand;
            this.aChBxRemoveNeutral.DisplayText = "Remove Neutral";
            this.aChBxRemoveNeutral.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.aChBxRemoveNeutral.Location = new Point(7, 94);
            this.aChBxRemoveNeutral.Name = "aChBxRemoveNeutral";
            this.aChBxRemoveNeutral.RightToLeft = RightToLeft.No;
            this.aChBxRemoveNeutral.Size = new Size(146, 30);
            this.aChBxRemoveNeutral.TabIndex = 16;
            this.aChBxRemoveNeutral.TextAlign = AnotherCheckbox.TextAlignment.Right;
            // 
            // aChBxRemoveAllie
            // 
            this.aChBxRemoveAllie.AutoSize = true;
            this.aChBxRemoveAllie.Checked = false;
            this.aChBxRemoveAllie.Clickable = true;
            this.aChBxRemoveAllie.Cursor = Cursors.Hand;
            this.aChBxRemoveAllie.DisplayText = "Remove Allie";
            this.aChBxRemoveAllie.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.aChBxRemoveAllie.Location = new Point(7, 62);
            this.aChBxRemoveAllie.Name = "aChBxRemoveAllie";
            this.aChBxRemoveAllie.RightToLeft = RightToLeft.No;
            this.aChBxRemoveAllie.Size = new Size(127, 30);
            this.aChBxRemoveAllie.TabIndex = 17;
            this.aChBxRemoveAllie.TextAlign = AnotherCheckbox.TextAlignment.Right;
            // 
            // aChBxRemoveAi
            // 
            this.aChBxRemoveAi.AutoSize = true;
            this.aChBxRemoveAi.Checked = false;
            this.aChBxRemoveAi.Clickable = true;
            this.aChBxRemoveAi.Cursor = Cursors.Hand;
            this.aChBxRemoveAi.DisplayText = "Remove Ai";
            this.aChBxRemoveAi.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.aChBxRemoveAi.Location = new Point(7, 30);
            this.aChBxRemoveAi.Name = "aChBxRemoveAi";
            this.aChBxRemoveAi.RightToLeft = RightToLeft.No;
            this.aChBxRemoveAi.Size = new Size(111, 30);
            this.aChBxRemoveAi.TabIndex = 15;
            this.aChBxRemoveAi.TextAlign = AnotherCheckbox.TextAlignment.Right;
            // 
            // aChBxRemoveChronoboost
            // 
            this.aChBxRemoveChronoboost.AutoSize = true;
            this.aChBxRemoveChronoboost.Checked = false;
            this.aChBxRemoveChronoboost.Clickable = true;
            this.aChBxRemoveChronoboost.Cursor = Cursors.Hand;
            this.aChBxRemoveChronoboost.DisplayText = "Remove Chronoboost";
            this.aChBxRemoveChronoboost.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.aChBxRemoveChronoboost.Location = new Point(7, 190);
            this.aChBxRemoveChronoboost.Name = "aChBxRemoveChronoboost";
            this.aChBxRemoveChronoboost.RightToLeft = RightToLeft.No;
            this.aChBxRemoveChronoboost.Size = new Size(183, 30);
            this.aChBxRemoveChronoboost.TabIndex = 21;
            this.aChBxRemoveChronoboost.TextAlign = AnotherCheckbox.TextAlignment.Right;
            // 
            // aChBxSplitUnitsBuildings
            // 
            this.aChBxSplitUnitsBuildings.AutoSize = true;
            this.aChBxSplitUnitsBuildings.Checked = false;
            this.aChBxSplitUnitsBuildings.Clickable = true;
            this.aChBxSplitUnitsBuildings.Cursor = Cursors.Hand;
            this.aChBxSplitUnitsBuildings.DisplayText = "Split Units/ Buildings";
            this.aChBxSplitUnitsBuildings.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.aChBxSplitUnitsBuildings.Location = new Point(211, 30);
            this.aChBxSplitUnitsBuildings.Name = "aChBxSplitUnitsBuildings";
            this.aChBxSplitUnitsBuildings.RightToLeft = RightToLeft.No;
            this.aChBxSplitUnitsBuildings.Size = new Size(177, 30);
            this.aChBxSplitUnitsBuildings.TabIndex = 23;
            this.aChBxSplitUnitsBuildings.TextAlign = AnotherCheckbox.TextAlignment.Right;
            // 
            // aChBxDisplayBuildings
            // 
            this.aChBxDisplayBuildings.AutoSize = true;
            this.aChBxDisplayBuildings.Checked = false;
            this.aChBxDisplayBuildings.Clickable = true;
            this.aChBxDisplayBuildings.Cursor = Cursors.Hand;
            this.aChBxDisplayBuildings.DisplayText = "Display Buildings";
            this.aChBxDisplayBuildings.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.aChBxDisplayBuildings.Location = new Point(211, 94);
            this.aChBxDisplayBuildings.Name = "aChBxDisplayBuildings";
            this.aChBxDisplayBuildings.RightToLeft = RightToLeft.No;
            this.aChBxDisplayBuildings.Size = new Size(153, 30);
            this.aChBxDisplayBuildings.TabIndex = 24;
            this.aChBxDisplayBuildings.TextAlign = AnotherCheckbox.TextAlignment.Right;
            // 
            // aChBxDisplayUnits
            // 
            this.aChBxDisplayUnits.AutoSize = true;
            this.aChBxDisplayUnits.Checked = false;
            this.aChBxDisplayUnits.Clickable = true;
            this.aChBxDisplayUnits.Cursor = Cursors.Hand;
            this.aChBxDisplayUnits.DisplayText = "Display Units";
            this.aChBxDisplayUnits.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.aChBxDisplayUnits.Location = new Point(211, 126);
            this.aChBxDisplayUnits.Name = "aChBxDisplayUnits";
            this.aChBxDisplayUnits.RightToLeft = RightToLeft.No;
            this.aChBxDisplayUnits.Size = new Size(125, 30);
            this.aChBxDisplayUnits.TabIndex = 25;
            this.aChBxDisplayUnits.TextAlign = AnotherCheckbox.TextAlignment.Right;
            // 
            // aChBxTransparentImages
            // 
            this.aChBxTransparentImages.AutoSize = true;
            this.aChBxTransparentImages.Checked = false;
            this.aChBxTransparentImages.Clickable = true;
            this.aChBxTransparentImages.Cursor = Cursors.Hand;
            this.aChBxTransparentImages.DisplayText = "Transparent Images";
            this.aChBxTransparentImages.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.aChBxTransparentImages.Location = new Point(211, 158);
            this.aChBxTransparentImages.Name = "aChBxTransparentImages";
            this.aChBxTransparentImages.RightToLeft = RightToLeft.No;
            this.aChBxTransparentImages.Size = new Size(169, 30);
            this.aChBxTransparentImages.TabIndex = 26;
            this.aChBxTransparentImages.TextAlign = AnotherCheckbox.TextAlignment.Right;
            // 
            // aChBxDisplayUpgrades
            // 
            this.aChBxDisplayUpgrades.AutoSize = true;
            this.aChBxDisplayUpgrades.Checked = false;
            this.aChBxDisplayUpgrades.Clickable = true;
            this.aChBxDisplayUpgrades.Cursor = Cursors.Hand;
            this.aChBxDisplayUpgrades.DisplayText = "Display Upgrades";
            this.aChBxDisplayUpgrades.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.aChBxDisplayUpgrades.Location = new Point(211, 62);
            this.aChBxDisplayUpgrades.Name = "aChBxDisplayUpgrades";
            this.aChBxDisplayUpgrades.RightToLeft = RightToLeft.No;
            this.aChBxDisplayUpgrades.Size = new Size(156, 30);
            this.aChBxDisplayUpgrades.TabIndex = 25;
            this.aChBxDisplayUpgrades.TextAlign = AnotherCheckbox.TextAlignment.Right;
            // 
            // PanelSettingsBasicProductiontab
            // 
            this.AutoScaleDimensions = new SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.Controls.Add(this.aChBxDisplayUpgrades);
            this.Controls.Add(this.aChBxTransparentImages);
            this.Controls.Add(this.aChBxDisplayUnits);
            this.Controls.Add(this.aChBxDisplayBuildings);
            this.Controls.Add(this.aChBxSplitUnitsBuildings);
            this.Controls.Add(this.aChBxRemoveChronoboost);
            this.Controls.Add(this.btnSetFont);
            this.Controls.Add(this.lblBasics);
            this.Controls.Add(this.OpacityControl);
            this.Controls.Add(this.aChBxRemoveClantags);
            this.Controls.Add(this.aChBxRemoveYourself);
            this.Controls.Add(this.aChBxRemoveNeutral);
            this.Controls.Add(this.aChBxRemoveAllie);
            this.Controls.Add(this.aChBxRemoveAi);
            this.Name = "PanelSettingsBasicProductiontab";
            this.Size = new Size(399, 349);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public LanguageButton btnSetFont;
        private LanguageLabel lblBasics;
        public UiOpacityControl OpacityControl;
        public AnotherCheckbox aChBxRemoveClantags;
        public AnotherCheckbox aChBxRemoveYourself;
        public AnotherCheckbox aChBxRemoveNeutral;
        public AnotherCheckbox aChBxRemoveAllie;
        public AnotherCheckbox aChBxRemoveAi;
        public AnotherCheckbox aChBxRemoveChronoboost;
        public AnotherCheckbox aChBxSplitUnitsBuildings;
        public AnotherCheckbox aChBxDisplayBuildings;
        public AnotherCheckbox aChBxDisplayUnits;
        public AnotherCheckbox aChBxTransparentImages;
        public AnotherCheckbox aChBxDisplayUpgrades;
    }
}
