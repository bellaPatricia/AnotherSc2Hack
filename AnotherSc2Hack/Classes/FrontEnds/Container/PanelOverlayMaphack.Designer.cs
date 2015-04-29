namespace AnotherSc2Hack.Classes.FrontEnds.Container
{
    partial class PanelOverlayMaphack
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
            this.components = new System.ComponentModel.Container();
            this.btnMaphackBasicsUnitColor = new System.Windows.Forms.Button();
            this.cmsListviewContext = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmRemoveItems = new System.Windows.Forms.ToolStripMenuItem();
            this.lblMaphackFilter = new AnotherSc2Hack.Classes.FrontEnds.LanguageLabel();
            this.icbMaphackBasicsUnitSelection = new AnotherSc2Hack.Classes.FrontEnds.ImageCombobox();
            this.lstvMaphackBasicsUnitFilter = new AnotherSc2Hack.Classes.FrontEnds.AnotherListview();
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pnlLauncher = new AnotherSc2Hack.Classes.FrontEnds.Container.PanelSettingsLauncher();
            this.pnlBasics = new AnotherSc2Hack.Classes.FrontEnds.Container.PanelSettingsBasicsMaphack();
            this.cmsListviewContext.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnMaphackBasicsUnitColor
            // 
            this.btnMaphackBasicsUnitColor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.btnMaphackBasicsUnitColor.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(193)))), ((int)(((byte)(193)))));
            this.btnMaphackBasicsUnitColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMaphackBasicsUnitColor.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMaphackBasicsUnitColor.Location = new System.Drawing.Point(924, 72);
            this.btnMaphackBasicsUnitColor.Name = "btnMaphackBasicsUnitColor";
            this.btnMaphackBasicsUnitColor.Size = new System.Drawing.Size(20, 189);
            this.btnMaphackBasicsUnitColor.TabIndex = 29;
            this.btnMaphackBasicsUnitColor.UseVisualStyleBackColor = false;
            this.btnMaphackBasicsUnitColor.Click += new System.EventHandler(this.btnMaphackBasicsUnitColor_Click);
            // 
            // cmsListviewContext
            // 
            this.cmsListviewContext.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmRemoveItems});
            this.cmsListviewContext.Name = "cmsListviewContext";
            this.cmsListviewContext.Size = new System.Drawing.Size(158, 26);
            this.cmsListviewContext.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.cmsListviewContext_ItemClicked);
            // 
            // tsmRemoveItems
            // 
            this.tsmRemoveItems.Name = "tsmRemoveItems";
            this.tsmRemoveItems.Size = new System.Drawing.Size(157, 22);
            this.tsmRemoveItems.Text = "Remove item(s)";
            // 
            // lblMaphackFilter
            // 
            this.lblMaphackFilter.AutoSize = true;
            this.lblMaphackFilter.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaphackFilter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(78)))), ((int)(((byte)(90)))));
            this.lblMaphackFilter.LanguageFile = "";
            this.lblMaphackFilter.Location = new System.Drawing.Point(708, 3);
            this.lblMaphackFilter.Name = "lblMaphackFilter";
            this.lblMaphackFilter.Size = new System.Drawing.Size(112, 20);
            this.lblMaphackFilter.TabIndex = 30;
            this.lblMaphackFilter.Text = "Maphack Filter";
            // 
            // icbMaphackBasicsUnitSelection
            // 
            this.icbMaphackBasicsUnitSelection.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.icbMaphackBasicsUnitSelection.DropDownHeight = 500;
            this.icbMaphackBasicsUnitSelection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.icbMaphackBasicsUnitSelection.DropDownWidth = 179;
            this.icbMaphackBasicsUnitSelection.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.icbMaphackBasicsUnitSelection.FormattingEnabled = true;
            this.icbMaphackBasicsUnitSelection.ImageSize = new System.Drawing.Size(30, 30);
            this.icbMaphackBasicsUnitSelection.InitializeUnits = true;
            this.icbMaphackBasicsUnitSelection.IntegralHeight = false;
            this.icbMaphackBasicsUnitSelection.ItemHeight = 30;
            this.icbMaphackBasicsUnitSelection.Location = new System.Drawing.Point(712, 30);
            this.icbMaphackBasicsUnitSelection.Name = "icbMaphackBasicsUnitSelection";
            this.icbMaphackBasicsUnitSelection.Size = new System.Drawing.Size(232, 36);
            this.icbMaphackBasicsUnitSelection.TabIndex = 28;
            this.icbMaphackBasicsUnitSelection.SelectedIndexChanged += new System.EventHandler(this.icbMaphackBasicsUnitSelection_SelectedIndexChanged);
            // 
            // lstvMaphackBasicsUnitFilter
            // 
            this.lstvMaphackBasicsUnitFilter.AutoArrange = false;
            this.lstvMaphackBasicsUnitFilter.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader7});
            this.lstvMaphackBasicsUnitFilter.ContextMenuStrip = this.cmsListviewContext;
            this.lstvMaphackBasicsUnitFilter.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstvMaphackBasicsUnitFilter.FullRowSelect = true;
            this.lstvMaphackBasicsUnitFilter.GridLines = true;
            this.lstvMaphackBasicsUnitFilter.Location = new System.Drawing.Point(712, 72);
            this.lstvMaphackBasicsUnitFilter.Name = "lstvMaphackBasicsUnitFilter";
            this.lstvMaphackBasicsUnitFilter.Size = new System.Drawing.Size(206, 189);
            this.lstvMaphackBasicsUnitFilter.TabIndex = 27;
            this.lstvMaphackBasicsUnitFilter.UseCompatibleStateImageBehavior = false;
            this.lstvMaphackBasicsUnitFilter.View = System.Windows.Forms.View.Details;
            this.lstvMaphackBasicsUnitFilter.SelectedIndexChanged += new System.EventHandler(this.lstvMaphackBasicsUnitFilter_SelectedIndexChanged);
            this.lstvMaphackBasicsUnitFilter.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lstvMaphackBasicsUnitFilter_KeyDown);
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Unit";
            this.columnHeader7.Width = 202;
            // 
            // pnlLauncher
            // 
            this.pnlLauncher.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlLauncher.Location = new System.Drawing.Point(416, 0);
            this.pnlLauncher.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlLauncher.Name = "pnlLauncher";
            this.pnlLauncher.Size = new System.Drawing.Size(268, 261);
            this.pnlLauncher.TabIndex = 1;
            // 
            // pnlBasics
            // 
            this.pnlBasics.Location = new System.Drawing.Point(0, 0);
            this.pnlBasics.Name = "pnlBasics";
            this.pnlBasics.Size = new System.Drawing.Size(409, 402);
            this.pnlBasics.TabIndex = 0;
            // 
            // PanelOverlayMaphack
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblMaphackFilter);
            this.Controls.Add(this.btnMaphackBasicsUnitColor);
            this.Controls.Add(this.icbMaphackBasicsUnitSelection);
            this.Controls.Add(this.lstvMaphackBasicsUnitFilter);
            this.Controls.Add(this.pnlLauncher);
            this.Controls.Add(this.pnlBasics);
            this.Name = "PanelOverlayMaphack";
            this.Size = new System.Drawing.Size(1006, 274);
            this.cmsListviewContext.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public PanelSettingsBasicsMaphack pnlBasics;
        public PanelSettingsLauncher pnlLauncher;
        public System.Windows.Forms.Button btnMaphackBasicsUnitColor;
        private ImageCombobox icbMaphackBasicsUnitSelection;
        private AnotherListview lstvMaphackBasicsUnitFilter;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private LanguageLabel lblMaphackFilter;
        private System.Windows.Forms.ContextMenuStrip cmsListviewContext;
        private System.Windows.Forms.ToolStripMenuItem tsmRemoveItems;

    }
}
