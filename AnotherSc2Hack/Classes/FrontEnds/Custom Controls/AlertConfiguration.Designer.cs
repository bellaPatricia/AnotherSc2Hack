using System.ComponentModel;
using System.Windows.Forms;

namespace AnotherSc2Hack.Classes.FrontEnds.Custom_Controls
{
    partial class AlertConfiguration
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
            this.pnlBottomStrip = new System.Windows.Forms.Panel();
            this.btnOk = new AnotherSc2Hack.Classes.FrontEnds.Custom_Controls.LanguageButton();
            this.btnCancel = new AnotherSc2Hack.Classes.FrontEnds.Custom_Controls.LanguageButton();
            this.icbAlertConfigurationSelection = new AnotherSc2Hack.Classes.FrontEnds.Custom_Controls.ImageCombobox();
            this.lstvAlertConfigurationFilter = new AnotherSc2Hack.Classes.FrontEnds.Custom_Controls.AnotherListview();
            this.chAlertConfigurationFilterUnit = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cmsListviewContext = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmRemoveItems = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlBottomStrip.SuspendLayout();
            this.cmsListviewContext.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBottomStrip
            // 
            this.pnlBottomStrip.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlBottomStrip.Controls.Add(this.btnOk);
            this.pnlBottomStrip.Controls.Add(this.btnCancel);
            this.pnlBottomStrip.Location = new System.Drawing.Point(0, 280);
            this.pnlBottomStrip.Name = "pnlBottomStrip";
            this.pnlBottomStrip.Size = new System.Drawing.Size(348, 62);
            this.pnlBottomStrip.TabIndex = 23;
            this.pnlBottomStrip.Paint += new System.Windows.Forms.PaintEventHandler(this.DrawVerticalBorders);
            // 
            // btnOk
            // 
            this.btnOk.AutoSize = true;
            this.btnOk.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.btnOk.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(193)))), ((int)(((byte)(193)))));
            this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOk.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOk.LanguageFile = "";
            this.btnOk.Location = new System.Drawing.Point(12, 15);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(120, 32);
            this.btnOk.TabIndex = 13;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = false;
            this.btnOk.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.AutoSize = true;
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(193)))), ((int)(((byte)(193)))));
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.LanguageFile = "";
            this.btnCancel.Location = new System.Drawing.Point(216, 15);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(120, 32);
            this.btnCancel.TabIndex = 14;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // icbAlertConfigurationSelection
            // 
            this.icbAlertConfigurationSelection.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.icbAlertConfigurationSelection.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.icbAlertConfigurationSelection.DropDownHeight = 500;
            this.icbAlertConfigurationSelection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.icbAlertConfigurationSelection.DropDownWidth = 179;
            this.icbAlertConfigurationSelection.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.icbAlertConfigurationSelection.FormattingEnabled = true;
            this.icbAlertConfigurationSelection.ImageSize = new System.Drawing.Size(30, 30);
            this.icbAlertConfigurationSelection.InitializeUnits = true;
            this.icbAlertConfigurationSelection.IntegralHeight = false;
            this.icbAlertConfigurationSelection.ItemHeight = 30;
            this.icbAlertConfigurationSelection.Location = new System.Drawing.Point(12, 12);
            this.icbAlertConfigurationSelection.Name = "icbAlertConfigurationSelection";
            this.icbAlertConfigurationSelection.Size = new System.Drawing.Size(324, 36);
            this.icbAlertConfigurationSelection.TabIndex = 29;
            this.icbAlertConfigurationSelection.SelectedIndexChanged += new System.EventHandler(this.icbAlertConfigurationSelection_SelectedIndexChanged);
            // 
            // lstvAlertConfigurationFilter
            // 
            this.lstvAlertConfigurationFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstvAlertConfigurationFilter.AutoArrange = false;
            this.lstvAlertConfigurationFilter.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chAlertConfigurationFilterUnit});
            this.lstvAlertConfigurationFilter.ContextMenuStrip = this.cmsListviewContext;
            this.lstvAlertConfigurationFilter.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstvAlertConfigurationFilter.FullRowSelect = true;
            this.lstvAlertConfigurationFilter.GridLines = true;
            this.lstvAlertConfigurationFilter.Location = new System.Drawing.Point(12, 54);
            this.lstvAlertConfigurationFilter.Name = "lstvAlertConfigurationFilter";
            this.lstvAlertConfigurationFilter.Size = new System.Drawing.Size(324, 212);
            this.lstvAlertConfigurationFilter.TabIndex = 30;
            this.lstvAlertConfigurationFilter.UseCompatibleStateImageBehavior = false;
            this.lstvAlertConfigurationFilter.View = System.Windows.Forms.View.Details;
            this.lstvAlertConfigurationFilter.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lstvAlertConfigurationFilter_KeyDown);
            // 
            // chAlertConfigurationFilterUnit
            // 
            this.chAlertConfigurationFilterUnit.Text = "Unit";
            this.chAlertConfigurationFilterUnit.Width = 202;
            // 
            // cmsListviewContext
            // 
            this.cmsListviewContext.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmRemoveItems});
            this.cmsListviewContext.Name = "cmsListviewContext";
            this.cmsListviewContext.Size = new System.Drawing.Size(158, 26);
            // 
            // tsmRemoveItems
            // 
            this.tsmRemoveItems.Name = "tsmRemoveItems";
            this.tsmRemoveItems.Size = new System.Drawing.Size(157, 22);
            this.tsmRemoveItems.Text = "Remove item(s)";
            // 
            // AlertConfiguration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(348, 342);
            this.Controls.Add(this.lstvAlertConfigurationFilter);
            this.Controls.Add(this.icbAlertConfigurationSelection);
            this.Controls.Add(this.pnlBottomStrip);
            this.Name = "AlertConfiguration";
            this.Text = "AlertConfiguration";
            this.SizeChanged += new System.EventHandler(this.AlertConfiguration_SizeChanged);
            this.pnlBottomStrip.ResumeLayout(false);
            this.pnlBottomStrip.PerformLayout();
            this.cmsListviewContext.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Panel pnlBottomStrip;
        private LanguageButton btnOk;
        private LanguageButton btnCancel;
        private ImageCombobox icbAlertConfigurationSelection;
        private AnotherListview lstvAlertConfigurationFilter;
        private ColumnHeader chAlertConfigurationFilterUnit;
        private ContextMenuStrip cmsListviewContext;
        private ToolStripMenuItem tsmRemoveItems;
    }
}