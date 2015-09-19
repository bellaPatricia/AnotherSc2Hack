using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using AnotherSc2Hack.Classes.FrontEnds.Custom_Controls;

namespace AnotherSc2Hack.Classes.FrontEnds.Container
{
    partial class PanelOverlayMaphack
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
            this.components = new System.ComponentModel.Container();
            this.btnMaphackBasicsUnitColor = new Button();
            this.cmsListviewContext = new ContextMenuStrip(this.components);
            this.tsmRemoveItems = new ToolStripMenuItem();
            this.lblMaphackFilter = new LanguageLabel();
            this.icbMaphackBasicsUnitSelection = new ImageCombobox();
            this.lstvMaphackBasicsUnitFilter = new AnotherListview();
            this.chMaphackfilterUnit = ((ColumnHeader)(new ColumnHeader()));
            this.pnlLauncher = new PanelSettingsLauncher();
            this.pnlBasics = new PanelSettingsBasicsMaphack();
            this.cmsListviewContext.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnMaphackBasicsUnitColor
            // 
            this.btnMaphackBasicsUnitColor.BackColor = Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.btnMaphackBasicsUnitColor.FlatAppearance.BorderColor = Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(193)))), ((int)(((byte)(193)))));
            this.btnMaphackBasicsUnitColor.FlatStyle = FlatStyle.Flat;
            this.btnMaphackBasicsUnitColor.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.btnMaphackBasicsUnitColor.Location = new Point(924, 72);
            this.btnMaphackBasicsUnitColor.Name = "btnMaphackBasicsUnitColor";
            this.btnMaphackBasicsUnitColor.Size = new Size(20, 189);
            this.btnMaphackBasicsUnitColor.TabIndex = 29;
            this.btnMaphackBasicsUnitColor.UseVisualStyleBackColor = false;
            this.btnMaphackBasicsUnitColor.Click += new EventHandler(this.btnMaphackBasicsUnitColor_Click);
            // 
            // cmsListviewContext
            // 
            this.cmsListviewContext.Items.AddRange(new ToolStripItem[] {
            this.tsmRemoveItems});
            this.cmsListviewContext.Name = "cmsListviewContext";
            this.cmsListviewContext.Size = new Size(158, 26);
            this.cmsListviewContext.ItemClicked += new ToolStripItemClickedEventHandler(this.cmsListviewContext_ItemClicked);
            // 
            // tsmRemoveItems
            // 
            this.tsmRemoveItems.Name = "tsmRemoveItems";
            this.tsmRemoveItems.Size = new Size(157, 22);
            this.tsmRemoveItems.Text = "Remove item(s)";
            // 
            // lblMaphackFilter
            // 
            this.lblMaphackFilter.AutoSize = true;
            this.lblMaphackFilter.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            this.lblMaphackFilter.ForeColor = Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(78)))), ((int)(((byte)(90)))));
            this.lblMaphackFilter.LanguageFile = "";
            this.lblMaphackFilter.Location = new Point(708, 3);
            this.lblMaphackFilter.Name = "lblMaphackFilter";
            this.lblMaphackFilter.Size = new Size(112, 20);
            this.lblMaphackFilter.TabIndex = 30;
            this.lblMaphackFilter.Text = "Maphack Filter";
            // 
            // icbMaphackBasicsUnitSelection
            // 
            this.icbMaphackBasicsUnitSelection.DrawMode = DrawMode.OwnerDrawFixed;
            this.icbMaphackBasicsUnitSelection.DropDownHeight = 500;
            this.icbMaphackBasicsUnitSelection.DropDownStyle = ComboBoxStyle.DropDownList;
            this.icbMaphackBasicsUnitSelection.DropDownWidth = 179;
            this.icbMaphackBasicsUnitSelection.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.icbMaphackBasicsUnitSelection.FormattingEnabled = true;
            this.icbMaphackBasicsUnitSelection.ImageSize = new Size(30, 30);
            this.icbMaphackBasicsUnitSelection.InitializeUnits = true;
            this.icbMaphackBasicsUnitSelection.IntegralHeight = false;
            this.icbMaphackBasicsUnitSelection.ItemHeight = 30;
            this.icbMaphackBasicsUnitSelection.Location = new Point(712, 30);
            this.icbMaphackBasicsUnitSelection.Name = "icbMaphackBasicsUnitSelection";
            this.icbMaphackBasicsUnitSelection.Size = new Size(232, 36);
            this.icbMaphackBasicsUnitSelection.TabIndex = 28;
            this.icbMaphackBasicsUnitSelection.SelectedIndexChanged += new EventHandler(this.icbMaphackBasicsUnitSelection_SelectedIndexChanged);
            // 
            // lstvMaphackBasicsUnitFilter
            // 
            this.lstvMaphackBasicsUnitFilter.AutoArrange = false;
            this.lstvMaphackBasicsUnitFilter.Columns.AddRange(new ColumnHeader[] {
            this.chMaphackfilterUnit});
            this.lstvMaphackBasicsUnitFilter.ContextMenuStrip = this.cmsListviewContext;
            this.lstvMaphackBasicsUnitFilter.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.lstvMaphackBasicsUnitFilter.FullRowSelect = true;
            this.lstvMaphackBasicsUnitFilter.GridLines = true;
            this.lstvMaphackBasicsUnitFilter.Location = new Point(712, 72);
            this.lstvMaphackBasicsUnitFilter.Name = "lstvMaphackBasicsUnitFilter";
            this.lstvMaphackBasicsUnitFilter.Size = new Size(206, 189);
            this.lstvMaphackBasicsUnitFilter.TabIndex = 27;
            this.lstvMaphackBasicsUnitFilter.UseCompatibleStateImageBehavior = false;
            this.lstvMaphackBasicsUnitFilter.View = View.Details;
            this.lstvMaphackBasicsUnitFilter.SelectedIndexChanged += new EventHandler(this.lstvMaphackBasicsUnitFilter_SelectedIndexChanged);
            this.lstvMaphackBasicsUnitFilter.KeyDown += new KeyEventHandler(this.lstvMaphackBasicsUnitFilter_KeyDown);
            // 
            // chMaphackfilterUnit
            // 
            this.chMaphackfilterUnit.Text = "Unit";
            this.chMaphackfilterUnit.Width = 202;
            // 
            // pnlLauncher
            // 
            this.pnlLauncher.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.pnlLauncher.Location = new Point(416, 0);
            this.pnlLauncher.Margin = new Padding(4, 5, 4, 5);
            this.pnlLauncher.Name = "pnlLauncher";
            this.pnlLauncher.Size = new Size(268, 261);
            this.pnlLauncher.TabIndex = 1;
            // 
            // pnlBasics
            // 
            this.pnlBasics.Location = new Point(0, 0);
            this.pnlBasics.Name = "pnlBasics";
            this.pnlBasics.Size = new Size(409, 402);
            this.pnlBasics.TabIndex = 0;
            // 
            // PanelOverlayMaphack
            // 
            this.AutoScaleDimensions = new SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.Controls.Add(this.lblMaphackFilter);
            this.Controls.Add(this.btnMaphackBasicsUnitColor);
            this.Controls.Add(this.icbMaphackBasicsUnitSelection);
            this.Controls.Add(this.lstvMaphackBasicsUnitFilter);
            this.Controls.Add(this.pnlLauncher);
            this.Controls.Add(this.pnlBasics);
            this.Name = "PanelOverlayMaphack";
            this.Size = new Size(1006, 274);
            this.cmsListviewContext.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public PanelSettingsBasicsMaphack pnlBasics;
        public PanelSettingsLauncher pnlLauncher;
        public Button btnMaphackBasicsUnitColor;
        private ImageCombobox icbMaphackBasicsUnitSelection;
        private AnotherListview lstvMaphackBasicsUnitFilter;
        private ColumnHeader chMaphackfilterUnit;
        private LanguageLabel lblMaphackFilter;
        private ContextMenuStrip cmsListviewContext;
        private ToolStripMenuItem tsmRemoveItems;

    }
}
