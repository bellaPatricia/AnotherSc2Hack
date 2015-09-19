using System.ComponentModel;
using System.Windows.Forms;

namespace AnotherSc2Hack.Classes.FrontEnds.Trainer
{
    partial class Trainer
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
            this.tmrMainTick = new System.Windows.Forms.Timer(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.lblPlayername = new System.Windows.Forms.Label();
            this.lvPlayerdata = new System.Windows.Forms.ListView();
            this.chProperty = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chPropertyValue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chPropertyType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tmrMainTick
            // 
            this.tmrMainTick.Interval = 16;
            this.tmrMainTick.Tick += new System.EventHandler(this.tmrMainTick_Tick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lvPlayerdata);
            this.groupBox1.Controls.Add(this.lblPlayername);
            this.groupBox1.Controls.Add(this.btnPrevious);
            this.groupBox1.Controls.Add(this.btnNext);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(261, 440);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Playerdata";
            // 
            // btnNext
            // 
            this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNext.Location = new System.Drawing.Point(227, 19);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(28, 23);
            this.btnNext.TabIndex = 0;
            this.btnNext.Text = ">";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnPrevious
            // 
            this.btnPrevious.Location = new System.Drawing.Point(6, 19);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(28, 23);
            this.btnPrevious.TabIndex = 1;
            this.btnPrevious.Text = "<";
            this.btnPrevious.UseVisualStyleBackColor = true;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // lblPlayername
            // 
            this.lblPlayername.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPlayername.AutoSize = true;
            this.lblPlayername.Location = new System.Drawing.Point(99, 24);
            this.lblPlayername.Name = "lblPlayername";
            this.lblPlayername.Size = new System.Drawing.Size(35, 13);
            this.lblPlayername.TabIndex = 2;
            this.lblPlayername.Text = "label1";
            // 
            // lvPlayerdata
            // 
            this.lvPlayerdata.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvPlayerdata.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chProperty,
            this.chPropertyValue,
            this.chPropertyType});
            this.lvPlayerdata.Location = new System.Drawing.Point(6, 48);
            this.lvPlayerdata.Name = "lvPlayerdata";
            this.lvPlayerdata.Size = new System.Drawing.Size(249, 386);
            this.lvPlayerdata.TabIndex = 3;
            this.lvPlayerdata.UseCompatibleStateImageBehavior = false;
            this.lvPlayerdata.View = System.Windows.Forms.View.Details;
            // 
            // chProperty
            // 
            this.chProperty.Text = "Property";
            this.chProperty.Width = 74;
            // 
            // chPropertyValue
            // 
            this.chPropertyValue.Text = "Value";
            this.chPropertyValue.Width = 108;
            // 
            // chPropertyType
            // 
            this.chPropertyType.Text = "Type";
            // 
            // Trainer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(575, 464);
            this.Controls.Add(this.groupBox1);
            this.Name = "Trainer";
            this.Text = "Trainer";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Timer tmrMainTick;
        private GroupBox groupBox1;
        private ListView lvPlayerdata;
        private ColumnHeader chProperty;
        private ColumnHeader chPropertyValue;
        private ColumnHeader chPropertyType;
        private Label lblPlayername;
        private Button btnPrevious;
        private Button btnNext;
    }
}