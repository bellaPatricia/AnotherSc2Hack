namespace AnotherSc2Hack.Classes.FrontEnds
{
    partial class DefineMarks
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
            AnotherSc2Hack.Classes.FrontEnds.Stroke stroke1 = new AnotherSc2Hack.Classes.FrontEnds.Stroke();
            this.cmBxKindOfDrawing = new System.Windows.Forms.ComboBox();
            this.pnlBorder = new AnotherSc2Hack.Classes.FrontEnds.GraphicalPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnColor = new System.Windows.Forms.Button();
            this.dudBorderThikness = new System.Windows.Forms.DomainUpDown();
            this.pnlBorder.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmBxKindOfDrawing
            // 
            this.cmBxKindOfDrawing.FormattingEnabled = true;
            this.cmBxKindOfDrawing.Location = new System.Drawing.Point(12, 12);
            this.cmBxKindOfDrawing.Name = "cmBxKindOfDrawing";
            this.cmBxKindOfDrawing.Size = new System.Drawing.Size(121, 21);
            this.cmBxKindOfDrawing.TabIndex = 0;
            this.cmBxKindOfDrawing.SelectedIndexChanged += new System.EventHandler(this.cmBxKindOfDrawing_SelectedIndexChanged);
            // 
            // pnlBorder
            // 
            this.pnlBorder.BackColor = System.Drawing.Color.Transparent;
            this.pnlBorder.Controls.Add(this.label1);
            this.pnlBorder.Controls.Add(this.btnColor);
            this.pnlBorder.Controls.Add(this.dudBorderThikness);
            this.pnlBorder.Location = new System.Drawing.Point(282, 12);
            this.pnlBorder.Name = "pnlBorder";
            this.pnlBorder.Size = new System.Drawing.Size(158, 79);
            stroke1.Color = System.Drawing.Color.Transparent;
            stroke1.Thickness = 0F;
            this.pnlBorder.Stroke = stroke1;
            this.pnlBorder.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Border thinkness:";
            // 
            // btnColor
            // 
            this.btnColor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnColor.Location = new System.Drawing.Point(6, 8);
            this.btnColor.Name = "btnColor";
            this.btnColor.Size = new System.Drawing.Size(149, 23);
            this.btnColor.TabIndex = 0;
            this.btnColor.Text = "Select Color";
            this.btnColor.UseVisualStyleBackColor = true;
            this.btnColor.Click += new System.EventHandler(this.btnColor_Click);
            // 
            // dudBorderThikness
            // 
            this.dudBorderThikness.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dudBorderThikness.Location = new System.Drawing.Point(98, 37);
            this.dudBorderThikness.Name = "dudBorderThikness";
            this.dudBorderThikness.Size = new System.Drawing.Size(57, 20);
            this.dudBorderThikness.TabIndex = 1;
            this.dudBorderThikness.Text = "domainUpDown1";
            this.dudBorderThikness.SelectedItemChanged += new System.EventHandler(this.dudBorderThikness_SelectedItemChanged);
            // 
            // DefineMarks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(452, 270);
            this.Controls.Add(this.pnlBorder);
            this.Controls.Add(this.cmBxKindOfDrawing);
            this.Name = "DefineMarks";
            this.Text = "DefineMarks";
            this.Load += new System.EventHandler(this.DefineMarks_Load);
            this.pnlBorder.ResumeLayout(false);
            this.pnlBorder.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cmBxKindOfDrawing;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DomainUpDown dudBorderThikness;
        private System.Windows.Forms.Button btnColor;
        private GraphicalPanel pnlBorder;
    }
}