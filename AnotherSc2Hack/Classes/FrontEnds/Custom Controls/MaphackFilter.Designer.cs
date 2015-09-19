using System.ComponentModel;
using System.Windows.Forms;

namespace AnotherSc2Hack.Classes.FrontEnds.Custom_Controls
{
    partial class MaphackFilter
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.btnMaphackFilterDiscardAndClose = new System.Windows.Forms.Button();
            this.btnMaphackFilterSaveAndClose = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.btnMaphackFiltersNewRule = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMaphackFilterAttributes = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnMaphackFilterLogicalAnd = new System.Windows.Forms.Button();
            this.btnMaphackFilterLogicalOr = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnMaphackFilterConfirmRule = new System.Windows.Forms.Button();
            this.pnlMaphackFilterRuleContainer = new System.Windows.Forms.Panel();
            this.icbSigns = new ImageCombobox();
            this.chBxMaphackFilterUseSigns = new AnotherCheckbox();
            this.btnMaphackFilterColor = new System.Windows.Forms.Button();
            this.chBxMaphackFilterUseColor = new AnotherCheckbox();
            this.txtMaphackFilterRuleName = new AnotherSc2Hack.Classes.FrontEnds.Custom_Controls.AnotherTextbox();
            this.icbMaphackFilterUnits = new ImageCombobox();
            this.icbMaphackFilterUnitProperties = new ImageCombobox();
            this.lstvMaphackFilterCurrentFilters = new AnotherListview();
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pnlFooter.SuspendLayout();
            this.pnlMaphackFilterRuleContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlFooter
            // 
            this.pnlFooter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlFooter.Controls.Add(this.btnMaphackFilterDiscardAndClose);
            this.pnlFooter.Controls.Add(this.btnMaphackFilterSaveAndClose);
            this.pnlFooter.Location = new System.Drawing.Point(0, 508);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(1256, 62);
            this.pnlFooter.TabIndex = 0;
            this.pnlFooter.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlFooter_Paint);
            // 
            // btnMaphackFilterDiscardAndClose
            // 
            this.btnMaphackFilterDiscardAndClose.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMaphackFilterDiscardAndClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.btnMaphackFilterDiscardAndClose.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(193)))), ((int)(((byte)(193)))));
            this.btnMaphackFilterDiscardAndClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMaphackFilterDiscardAndClose.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMaphackFilterDiscardAndClose.Location = new System.Drawing.Point(1095, 14);
            this.btnMaphackFilterDiscardAndClose.Name = "btnMaphackFilterDiscardAndClose";
            this.btnMaphackFilterDiscardAndClose.Size = new System.Drawing.Size(149, 32);
            this.btnMaphackFilterDiscardAndClose.TabIndex = 15;
            this.btnMaphackFilterDiscardAndClose.Text = "Discard and Close";
            this.btnMaphackFilterDiscardAndClose.UseVisualStyleBackColor = false;
            // 
            // btnMaphackFilterSaveAndClose
            // 
            this.btnMaphackFilterSaveAndClose.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btnMaphackFilterSaveAndClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.btnMaphackFilterSaveAndClose.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(193)))), ((int)(((byte)(193)))));
            this.btnMaphackFilterSaveAndClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMaphackFilterSaveAndClose.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMaphackFilterSaveAndClose.Location = new System.Drawing.Point(12, 14);
            this.btnMaphackFilterSaveAndClose.Name = "btnMaphackFilterSaveAndClose";
            this.btnMaphackFilterSaveAndClose.Size = new System.Drawing.Size(149, 32);
            this.btnMaphackFilterSaveAndClose.TabIndex = 14;
            this.btnMaphackFilterSaveAndClose.Text = "Save and Close";
            this.btnMaphackFilterSaveAndClose.UseVisualStyleBackColor = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(78)))), ((int)(((byte)(90)))));
            this.label5.Location = new System.Drawing.Point(15, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(146, 20);
            this.label5.TabIndex = 24;
            this.label5.Text = "Current Filter- rules";
            // 
            // btnMaphackFiltersNewRule
            // 
            this.btnMaphackFiltersNewRule.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btnMaphackFiltersNewRule.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.btnMaphackFiltersNewRule.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(193)))), ((int)(((byte)(193)))));
            this.btnMaphackFiltersNewRule.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMaphackFiltersNewRule.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMaphackFiltersNewRule.Location = new System.Drawing.Point(19, 435);
            this.btnMaphackFiltersNewRule.Name = "btnMaphackFiltersNewRule";
            this.btnMaphackFiltersNewRule.Size = new System.Drawing.Size(235, 32);
            this.btnMaphackFiltersNewRule.TabIndex = 16;
            this.btnMaphackFiltersNewRule.Text = "New Rule";
            this.btnMaphackFiltersNewRule.UseVisualStyleBackColor = false;
            this.btnMaphackFiltersNewRule.Click += new System.EventHandler(this.btnMaphackFiltersNewRule_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(78)))), ((int)(((byte)(90)))));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 20);
            this.label1.TabIndex = 26;
            this.label1.Text = "New Rule";
            // 
            // txtMaphackFilterAttributes
            // 
            this.txtMaphackFilterAttributes.ForeColor = System.Drawing.Color.Black;
            this.txtMaphackFilterAttributes.Location = new System.Drawing.Point(848, 276);
            this.txtMaphackFilterAttributes.Multiline = true;
            this.txtMaphackFilterAttributes.Name = "txtMaphackFilterAttributes";
            this.txtMaphackFilterAttributes.Size = new System.Drawing.Size(342, 153);
            this.txtMaphackFilterAttributes.TabIndex = 30;
            this.txtMaphackFilterAttributes.TextChanged += new System.EventHandler(this.txtMaphackFilterAttributes_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(78)))), ((int)(((byte)(90)))));
            this.label3.Location = new System.Drawing.Point(3, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 20);
            this.label3.TabIndex = 31;
            this.label3.Text = "Units";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(78)))), ((int)(((byte)(90)))));
            this.label6.Location = new System.Drawing.Point(1013, 168);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(112, 20);
            this.label6.TabIndex = 34;
            this.label6.Text = "Unit Properties";
            // 
            // btnMaphackFilterLogicalAnd
            // 
            this.btnMaphackFilterLogicalAnd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.btnMaphackFilterLogicalAnd.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(193)))), ((int)(((byte)(193)))));
            this.btnMaphackFilterLogicalAnd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMaphackFilterLogicalAnd.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMaphackFilterLogicalAnd.Location = new System.Drawing.Point(848, 207);
            this.btnMaphackFilterLogicalAnd.Name = "btnMaphackFilterLogicalAnd";
            this.btnMaphackFilterLogicalAnd.Size = new System.Drawing.Size(55, 32);
            this.btnMaphackFilterLogicalAnd.TabIndex = 16;
            this.btnMaphackFilterLogicalAnd.Text = "And";
            this.btnMaphackFilterLogicalAnd.UseVisualStyleBackColor = false;
            this.btnMaphackFilterLogicalAnd.Click += new System.EventHandler(this.btnMaphackFilterLogicalAnd_Click);
            // 
            // btnMaphackFilterLogicalOr
            // 
            this.btnMaphackFilterLogicalOr.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.btnMaphackFilterLogicalOr.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(193)))), ((int)(((byte)(193)))));
            this.btnMaphackFilterLogicalOr.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMaphackFilterLogicalOr.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMaphackFilterLogicalOr.Location = new System.Drawing.Point(909, 207);
            this.btnMaphackFilterLogicalOr.Name = "btnMaphackFilterLogicalOr";
            this.btnMaphackFilterLogicalOr.Size = new System.Drawing.Size(55, 32);
            this.btnMaphackFilterLogicalOr.TabIndex = 36;
            this.btnMaphackFilterLogicalOr.Text = "Or";
            this.btnMaphackFilterLogicalOr.UseVisualStyleBackColor = false;
            this.btnMaphackFilterLogicalOr.Click += new System.EventHandler(this.btnMaphackFilterLogicalOr_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(78)))), ((int)(((byte)(90)))));
            this.label4.Location = new System.Drawing.Point(844, 184);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 20);
            this.label4.TabIndex = 37;
            this.label4.Text = "Operators";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(78)))), ((int)(((byte)(90)))));
            this.label7.Location = new System.Drawing.Point(844, 253);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(50, 20);
            this.label7.TabIndex = 38;
            this.label7.Text = "Result";
            // 
            // btnMaphackFilterConfirmRule
            // 
            this.btnMaphackFilterConfirmRule.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.btnMaphackFilterConfirmRule.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(193)))), ((int)(((byte)(193)))));
            this.btnMaphackFilterConfirmRule.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMaphackFilterConfirmRule.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMaphackFilterConfirmRule.Location = new System.Drawing.Point(7, 420);
            this.btnMaphackFilterConfirmRule.Name = "btnMaphackFilterConfirmRule";
            this.btnMaphackFilterConfirmRule.Size = new System.Drawing.Size(342, 32);
            this.btnMaphackFilterConfirmRule.TabIndex = 39;
            this.btnMaphackFilterConfirmRule.Text = "Confirm";
            this.btnMaphackFilterConfirmRule.UseVisualStyleBackColor = false;
            this.btnMaphackFilterConfirmRule.Click += new System.EventHandler(this.btnMaphackFilterConfirmRule_Click);
            // 
            // pnlMaphackFilterRuleContainer
            // 
            this.pnlMaphackFilterRuleContainer.Controls.Add(this.icbSigns);
            this.pnlMaphackFilterRuleContainer.Controls.Add(this.chBxMaphackFilterUseSigns);
            this.pnlMaphackFilterRuleContainer.Controls.Add(this.btnMaphackFilterColor);
            this.pnlMaphackFilterRuleContainer.Controls.Add(this.chBxMaphackFilterUseColor);
            this.pnlMaphackFilterRuleContainer.Controls.Add(this.label1);
            this.pnlMaphackFilterRuleContainer.Controls.Add(this.btnMaphackFilterConfirmRule);
            this.pnlMaphackFilterRuleContainer.Controls.Add(this.txtMaphackFilterRuleName);
            this.pnlMaphackFilterRuleContainer.Controls.Add(this.label3);
            this.pnlMaphackFilterRuleContainer.Controls.Add(this.icbMaphackFilterUnits);
            this.pnlMaphackFilterRuleContainer.Location = new System.Drawing.Point(280, 15);
            this.pnlMaphackFilterRuleContainer.Name = "pnlMaphackFilterRuleContainer";
            this.pnlMaphackFilterRuleContainer.Size = new System.Drawing.Size(363, 452);
            this.pnlMaphackFilterRuleContainer.TabIndex = 40;
            // 
            // icbSigns
            // 
            this.icbSigns.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.icbSigns.DropDownHeight = 500;
            this.icbSigns.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.icbSigns.DropDownWidth = 179;
            this.icbSigns.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.icbSigns.ImageSize = new System.Drawing.Size(26, 26);
            this.icbSigns.InitializeUnits = false;
            this.icbSigns.IntegralHeight = false;
            this.icbSigns.ItemHeight = 26;
            this.icbSigns.Location = new System.Drawing.Point(144, 205);
            this.icbSigns.Name = "icbSigns";
            this.icbSigns.Size = new System.Drawing.Size(102, 32);
            this.icbSigns.TabIndex = 43;
            // 
            // chBxMaphackFilterUseSigns
            // 
            this.chBxMaphackFilterUseSigns.Checked = false;
            this.chBxMaphackFilterUseSigns.Clickable = true;
            this.chBxMaphackFilterUseSigns.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chBxMaphackFilterUseSigns.DisplayText = "Use Signs";
            this.chBxMaphackFilterUseSigns.Location = new System.Drawing.Point(144, 169);
            this.chBxMaphackFilterUseSigns.Name = "chBxMaphackFilterUseSigns";
            this.chBxMaphackFilterUseSigns.Size = new System.Drawing.Size(102, 30);
            this.chBxMaphackFilterUseSigns.TabIndex = 42;
            this.chBxMaphackFilterUseSigns.TextAlign = AnotherCheckbox.TextAlignment.Right;
            // 
            // btnMaphackFilterColor
            // 
            this.btnMaphackFilterColor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btnMaphackFilterColor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.btnMaphackFilterColor.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(193)))), ((int)(((byte)(193)))));
            this.btnMaphackFilterColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMaphackFilterColor.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMaphackFilterColor.Location = new System.Drawing.Point(7, 205);
            this.btnMaphackFilterColor.Name = "btnMaphackFilterColor";
            this.btnMaphackFilterColor.Size = new System.Drawing.Size(103, 32);
            this.btnMaphackFilterColor.TabIndex = 41;
            this.btnMaphackFilterColor.UseVisualStyleBackColor = false;
            // 
            // chBxMaphackFilterUseColor
            // 
            this.chBxMaphackFilterUseColor.Checked = false;
            this.chBxMaphackFilterUseColor.Clickable = true;
            this.chBxMaphackFilterUseColor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chBxMaphackFilterUseColor.DisplayText = "Use Color";
            this.chBxMaphackFilterUseColor.Location = new System.Drawing.Point(7, 169);
            this.chBxMaphackFilterUseColor.Name = "chBxMaphackFilterUseColor";
            this.chBxMaphackFilterUseColor.Size = new System.Drawing.Size(103, 30);
            this.chBxMaphackFilterUseColor.TabIndex = 40;
            this.chBxMaphackFilterUseColor.TextAlign = AnotherCheckbox.TextAlignment.Right;
            // 
            // txtMaphackFilterRuleName
            // 
            this.txtMaphackFilterRuleName.ForeColor = System.Drawing.Color.Gray;
            this.txtMaphackFilterRuleName.Location = new System.Drawing.Point(7, 33);
            this.txtMaphackFilterRuleName.Name = "txtMaphackFilterRuleName";
            this.txtMaphackFilterRuleName.Size = new System.Drawing.Size(342, 27);
            this.txtMaphackFilterRuleName.TabIndex = 28;
            this.txtMaphackFilterRuleName.Text = "Rule Name";
            this.txtMaphackFilterRuleName.Watermark = "Rule Name";
            // 
            // icbMaphackFilterUnits
            // 
            this.icbMaphackFilterUnits.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.icbMaphackFilterUnits.DropDownHeight = 500;
            this.icbMaphackFilterUnits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.icbMaphackFilterUnits.DropDownWidth = 179;
            this.icbMaphackFilterUnits.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.icbMaphackFilterUnits.ImageSize = new System.Drawing.Size(30, 30);
            this.icbMaphackFilterUnits.InitializeUnits = true;
            this.icbMaphackFilterUnits.IntegralHeight = false;
            this.icbMaphackFilterUnits.ItemHeight = 30;
            this.icbMaphackFilterUnits.Location = new System.Drawing.Point(7, 123);
            this.icbMaphackFilterUnits.Name = "icbMaphackFilterUnits";
            this.icbMaphackFilterUnits.Size = new System.Drawing.Size(226, 36);
            this.icbMaphackFilterUnits.TabIndex = 5;
            this.icbMaphackFilterUnits.SelectedIndexChanged += new System.EventHandler(this.icbMaphackFilterUnits_SelectedIndexChanged);
            // 
            // icbMaphackFilterUnitProperties
            // 
            this.icbMaphackFilterUnitProperties.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.icbMaphackFilterUnitProperties.DropDownHeight = 500;
            this.icbMaphackFilterUnitProperties.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.icbMaphackFilterUnitProperties.DropDownWidth = 179;
            this.icbMaphackFilterUnitProperties.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.icbMaphackFilterUnitProperties.ImageSize = new System.Drawing.Size(0, 0);
            this.icbMaphackFilterUnitProperties.InitializeUnits = false;
            this.icbMaphackFilterUnitProperties.IntegralHeight = false;
            this.icbMaphackFilterUnitProperties.ItemHeight = 30;
            this.icbMaphackFilterUnitProperties.Location = new System.Drawing.Point(1017, 210);
            this.icbMaphackFilterUnitProperties.Name = "icbMaphackFilterUnitProperties";
            this.icbMaphackFilterUnitProperties.Size = new System.Drawing.Size(157, 36);
            this.icbMaphackFilterUnitProperties.TabIndex = 35;
            this.icbMaphackFilterUnitProperties.SelectedIndexChanged += new System.EventHandler(this.icbMaphackFilterUnitProperties_SelectedIndexChanged);
            // 
            // lstvMaphackFilterCurrentFilters
            // 
            this.lstvMaphackFilterCurrentFilters.AutoArrange = false;
            this.lstvMaphackFilterCurrentFilters.CheckBoxes = true;
            this.lstvMaphackFilterCurrentFilters.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader7,
            this.columnHeader8});
            this.lstvMaphackFilterCurrentFilters.Enabled = false;
            this.lstvMaphackFilterCurrentFilters.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstvMaphackFilterCurrentFilters.FullRowSelect = true;
            this.lstvMaphackFilterCurrentFilters.GridLines = true;
            this.lstvMaphackFilterCurrentFilters.Location = new System.Drawing.Point(19, 48);
            this.lstvMaphackFilterCurrentFilters.Name = "lstvMaphackFilterCurrentFilters";
            this.lstvMaphackFilterCurrentFilters.Size = new System.Drawing.Size(235, 381);
            this.lstvMaphackFilterCurrentFilters.TabIndex = 25;
            this.lstvMaphackFilterCurrentFilters.UseCompatibleStateImageBehavior = false;
            this.lstvMaphackFilterCurrentFilters.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Rule Name";
            this.columnHeader7.Width = 133;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Applies to";
            this.columnHeader8.Width = 98;
            // 
            // MaphackFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1256, 570);
            this.Controls.Add(this.pnlMaphackFilterRuleContainer);
            this.Controls.Add(this.btnMaphackFiltersNewRule);
            this.Controls.Add(this.lstvMaphackFilterCurrentFilters);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtMaphackFilterAttributes);
            this.Controls.Add(this.icbMaphackFilterUnitProperties);
            this.Controls.Add(this.btnMaphackFilterLogicalOr);
            this.Controls.Add(this.btnMaphackFilterLogicalAnd);
            this.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "MaphackFilter";
            this.Text = "MaphackFilter";
            this.pnlFooter.ResumeLayout(false);
            this.pnlMaphackFilterRuleContainer.ResumeLayout(false);
            this.pnlMaphackFilterRuleContainer.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Panel pnlFooter;
        private Button btnMaphackFilterSaveAndClose;
        private Button btnMaphackFilterDiscardAndClose;
        private AnotherListview lstvMaphackFilterCurrentFilters;
        private ColumnHeader columnHeader7;
        private ColumnHeader columnHeader8;
        private Label label5;
        private Button btnMaphackFiltersNewRule;
        private Label label1;
        private AnotherTextbox txtMaphackFilterRuleName;
        private TextBox txtMaphackFilterAttributes;
        private Label label3;
        private ImageCombobox icbMaphackFilterUnits;
        private Label label6;
        private ImageCombobox icbMaphackFilterUnitProperties;
        private Button btnMaphackFilterLogicalAnd;
        private Button btnMaphackFilterLogicalOr;
        private Label label4;
        private Label label7;
        private Button btnMaphackFilterConfirmRule;
        private Panel pnlMaphackFilterRuleContainer;
        private AnotherCheckbox chBxMaphackFilterUseColor;
        private AnotherCheckbox chBxMaphackFilterUseSigns;
        private Button btnMaphackFilterColor;
        private ImageCombobox icbSigns;
    }
}