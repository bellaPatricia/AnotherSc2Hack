namespace AnotherSc2Hack.Classes.FrontEnds.Custom_Controls
{
    partial class MaphackFilter
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this.lstvMaphackFilterCurrentFilters = new AnotherSc2Hack.Classes.FrontEnds.AnotherListview();
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label5 = new System.Windows.Forms.Label();
            this.btnMaphackFiltersNewRule = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMaphackFilterRuleName = new AnotherSc2Hack.Classes.FrontEnds.Custom_Controls.AnotherTextbox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMaphackFilterAttributes = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.icbMapUnit = new AnotherSc2Hack.Classes.FrontEnds.ImageCombobox();
            this.pnlFooter.SuspendLayout();
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
            this.pnlFooter.Size = new System.Drawing.Size(853, 62);
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
            this.btnMaphackFilterDiscardAndClose.Location = new System.Drawing.Point(692, 14);
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
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(78)))), ((int)(((byte)(90)))));
            this.label1.Location = new System.Drawing.Point(292, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 20);
            this.label1.TabIndex = 26;
            this.label1.Text = "New Rule";
            // 
            // txtMaphackFilterRuleName
            // 
            this.txtMaphackFilterRuleName.ForeColor = System.Drawing.Color.Gray;
            this.txtMaphackFilterRuleName.Location = new System.Drawing.Point(296, 48);
            this.txtMaphackFilterRuleName.Name = "txtMaphackFilterRuleName";
            this.txtMaphackFilterRuleName.Size = new System.Drawing.Size(342, 27);
            this.txtMaphackFilterRuleName.TabIndex = 28;
            this.txtMaphackFilterRuleName.Text = "Rule Name";
            this.txtMaphackFilterRuleName.Watermark = "Rule Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(78)))), ((int)(((byte)(90)))));
            this.label2.Location = new System.Drawing.Point(292, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(183, 20);
            this.label2.TabIndex = 29;
            this.label2.Text = "Unit has the attribute(s):";
            // 
            // txtMaphackFilterAttributes
            // 
            this.txtMaphackFilterAttributes.Location = new System.Drawing.Point(296, 295);
            this.txtMaphackFilterAttributes.Multiline = true;
            this.txtMaphackFilterAttributes.Name = "txtMaphackFilterAttributes";
            this.txtMaphackFilterAttributes.Size = new System.Drawing.Size(342, 172);
            this.txtMaphackFilterAttributes.TabIndex = 30;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(292, 132);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 20);
            this.label3.TabIndex = 31;
            this.label3.Text = "Units";
            // 
            // icbMapUnit
            // 
            this.icbMapUnit.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.icbMapUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.icbMapUnit.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.icbMapUnit.ImageSize = new System.Drawing.Size(30, 30);
            this.icbMapUnit.InitializeUnits = true;
            this.icbMapUnit.ItemHeight = 30;
            this.icbMapUnit.Location = new System.Drawing.Point(296, 155);
            this.icbMapUnit.Name = "icbMapUnit";
            this.icbMapUnit.Size = new System.Drawing.Size(342, 36);
            this.icbMapUnit.TabIndex = 5;
            // 
            // MaphackFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(853, 570);
            this.Controls.Add(this.icbMapUnit);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtMaphackFilterAttributes);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtMaphackFilterRuleName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnMaphackFiltersNewRule);
            this.Controls.Add(this.lstvMaphackFilterCurrentFilters);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.pnlFooter);
            this.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "MaphackFilter";
            this.Text = "MaphackFilter";
            this.pnlFooter.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Button btnMaphackFilterSaveAndClose;
        private System.Windows.Forms.Button btnMaphackFilterDiscardAndClose;
        private AnotherListview lstvMaphackFilterCurrentFilters;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnMaphackFiltersNewRule;
        private System.Windows.Forms.Label label1;
        private AnotherTextbox txtMaphackFilterRuleName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMaphackFilterAttributes;
        private System.Windows.Forms.Label label3;
        private ImageCombobox icbMapUnit;
    }
}