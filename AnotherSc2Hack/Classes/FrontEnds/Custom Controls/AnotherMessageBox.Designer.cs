namespace AnotherSc2Hack.Classes.FrontEnds.Custom_Controls
{
    partial class AnotherMessageBox
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
            this.btnOk = new System.Windows.Forms.Button();
            this.lblMainText = new System.Windows.Forms.Label();
            this.pnlBottomContainer = new System.Windows.Forms.Panel();
            this.pnlBottomContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.btnOk.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(193)))), ((int)(((byte)(193)))));
            this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOk.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOk.Location = new System.Drawing.Point(500, 8);
            this.btnOk.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(100, 30);
            this.btnOk.TabIndex = 1;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = false;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // lblMainText
            // 
            this.lblMainText.AutoSize = true;
            this.lblMainText.Location = new System.Drawing.Point(15, 15);
            this.lblMainText.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMainText.Name = "lblMainText";
            this.lblMainText.Size = new System.Drawing.Size(50, 20);
            this.lblMainText.TabIndex = 0;
            this.lblMainText.Text = "label1";
            // 
            // pnlBottomContainer
            // 
            this.pnlBottomContainer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlBottomContainer.Controls.Add(this.btnOk);
            this.pnlBottomContainer.Location = new System.Drawing.Point(0, 178);
            this.pnlBottomContainer.Name = "pnlBottomContainer";
            this.pnlBottomContainer.Padding = new System.Windows.Forms.Padding(15, 0, 15, 0);
            this.pnlBottomContainer.Size = new System.Drawing.Size(622, 45);
            this.pnlBottomContainer.TabIndex = 2;
            // 
            // AnotherMessageBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(622, 223);
            this.Controls.Add(this.pnlBottomContainer);
            this.Controls.Add(this.lblMainText);
            this.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AnotherMessageBox";
            this.Text = "AnotherMessageBox";
            this.pnlBottomContainer.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Label lblMainText;
        private System.Windows.Forms.Panel pnlBottomContainer;


    }
}