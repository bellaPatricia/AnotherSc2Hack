namespace AnotherSc2Hack.Classes.FrontEnds.Custom_Controls
{
    partial class AlertConfiguration
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
            this.pnlBottomStrip = new System.Windows.Forms.Panel();
            this.btnSave = new AnotherSc2Hack.Classes.FrontEnds.Custom_Controls.LanguageButton();
            this.btrnCancel = new AnotherSc2Hack.Classes.FrontEnds.Custom_Controls.LanguageButton();
            this.icbMaphackBasicsUnitSelection = new AnotherSc2Hack.Classes.FrontEnds.Custom_Controls.ImageCombobox();
            this.lstvMaphackBasicsUnitFilter = new AnotherSc2Hack.Classes.FrontEnds.Custom_Controls.AnotherListview();
            this.chMaphackfilterUnit = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pnlBottomStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBottomStrip
            // 
            this.pnlBottomStrip.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlBottomStrip.Controls.Add(this.btnSave);
            this.pnlBottomStrip.Controls.Add(this.btrnCancel);
            this.pnlBottomStrip.Location = new System.Drawing.Point(0, 406);
            this.pnlBottomStrip.Name = "pnlBottomStrip";
            this.pnlBottomStrip.Size = new System.Drawing.Size(556, 62);
            this.pnlBottomStrip.TabIndex = 23;
            // 
            // btnSave
            // 
            this.btnSave.AutoSize = true;
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(193)))), ((int)(((byte)(193)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.LanguageFile = "";
            this.btnSave.Location = new System.Drawing.Point(12, 15);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(120, 32);
            this.btnSave.TabIndex = 13;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btrnCancel
            // 
            this.btrnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btrnCancel.AutoSize = true;
            this.btrnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.btrnCancel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(193)))), ((int)(((byte)(193)))));
            this.btrnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btrnCancel.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btrnCancel.LanguageFile = "";
            this.btrnCancel.Location = new System.Drawing.Point(424, 15);
            this.btrnCancel.Name = "btrnCancel";
            this.btrnCancel.Size = new System.Drawing.Size(120, 32);
            this.btrnCancel.TabIndex = 14;
            this.btrnCancel.Text = "Cancel";
            this.btrnCancel.UseVisualStyleBackColor = false;
            this.btrnCancel.Click += new System.EventHandler(this.btnCancel_Click);
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
            this.icbMaphackBasicsUnitSelection.Location = new System.Drawing.Point(158, 32);
            this.icbMaphackBasicsUnitSelection.Name = "icbMaphackBasicsUnitSelection";
            this.icbMaphackBasicsUnitSelection.Size = new System.Drawing.Size(232, 36);
            this.icbMaphackBasicsUnitSelection.TabIndex = 29;
            this.icbMaphackBasicsUnitSelection.SelectedIndexChanged += new System.EventHandler(this.icbMaphackBasicsUnitSelection_SelectedIndexChanged);
            // 
            // lstvMaphackBasicsUnitFilter
            // 
            this.lstvMaphackBasicsUnitFilter.AutoArrange = false;
            this.lstvMaphackBasicsUnitFilter.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chMaphackfilterUnit});
            this.lstvMaphackBasicsUnitFilter.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstvMaphackBasicsUnitFilter.FullRowSelect = true;
            this.lstvMaphackBasicsUnitFilter.GridLines = true;
            this.lstvMaphackBasicsUnitFilter.Location = new System.Drawing.Point(175, 140);
            this.lstvMaphackBasicsUnitFilter.Name = "lstvMaphackBasicsUnitFilter";
            this.lstvMaphackBasicsUnitFilter.Size = new System.Drawing.Size(206, 189);
            this.lstvMaphackBasicsUnitFilter.TabIndex = 30;
            this.lstvMaphackBasicsUnitFilter.UseCompatibleStateImageBehavior = false;
            this.lstvMaphackBasicsUnitFilter.View = System.Windows.Forms.View.Details;
            this.lstvMaphackBasicsUnitFilter.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lstvMaphackBasicsUnitFilter_KeyDown);
            // 
            // chMaphackfilterUnit
            // 
            this.chMaphackfilterUnit.Text = "Unit";
            this.chMaphackfilterUnit.Width = 202;
            // 
            // AlertConfiguration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(556, 468);
            this.Controls.Add(this.lstvMaphackBasicsUnitFilter);
            this.Controls.Add(this.icbMaphackBasicsUnitSelection);
            this.Controls.Add(this.pnlBottomStrip);
            this.Name = "AlertConfiguration";
            this.Text = "AlertConfiguration";
            this.pnlBottomStrip.ResumeLayout(false);
            this.pnlBottomStrip.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlBottomStrip;
        private LanguageButton btnSave;
        private LanguageButton btrnCancel;
        private ImageCombobox icbMaphackBasicsUnitSelection;
        private AnotherListview lstvMaphackBasicsUnitFilter;
        private System.Windows.Forms.ColumnHeader chMaphackfilterUnit;
    }
}