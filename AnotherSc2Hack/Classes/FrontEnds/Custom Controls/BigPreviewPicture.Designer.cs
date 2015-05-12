namespace AnotherSc2Hack.Classes.FrontEnds.Custom_Controls
{
    partial class BigPreviewPicture
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
            this.pcbBigPicture = new System.Windows.Forms.PictureBox();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.lblImageposition = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pcbBigPicture)).BeginInit();
            this.pnlBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // pcbBigPicture
            // 
            this.pcbBigPicture.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pcbBigPicture.BackColor = System.Drawing.SystemColors.Control;
            this.pcbBigPicture.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.pcbBigPicture.Location = new System.Drawing.Point(5, 5);
            this.pcbBigPicture.Name = "pcbBigPicture";
            this.pcbBigPicture.Size = new System.Drawing.Size(743, 427);
            this.pcbBigPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pcbBigPicture.TabIndex = 0;
            this.pcbBigPicture.TabStop = false;
            this.pcbBigPicture.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.pcbBigPicture_MouseDoubleClick);
            this.pcbBigPicture.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pcbBigPicture_MouseDown);
            this.pcbBigPicture.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pcbBigPicture_MouseMove);
            this.pcbBigPicture.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pcbBigPicture_MouseUp);
            // 
            // btnPrevious
            // 
            this.btnPrevious.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.btnPrevious.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(193)))), ((int)(((byte)(193)))));
            this.btnPrevious.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrevious.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrevious.Location = new System.Drawing.Point(13, 17);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(27, 32);
            this.btnPrevious.TabIndex = 15;
            this.btnPrevious.Text = "<";
            this.btnPrevious.UseVisualStyleBackColor = false;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // btnNext
            // 
            this.btnNext.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.btnNext.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(193)))), ((int)(((byte)(193)))));
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNext.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNext.Location = new System.Drawing.Point(145, 17);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(27, 32);
            this.btnNext.TabIndex = 16;
            this.btnNext.Text = ">";
            this.btnNext.UseVisualStyleBackColor = false;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // pnlBottom
            // 
            this.pnlBottom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlBottom.BackColor = System.Drawing.SystemColors.Control;
            this.pnlBottom.Controls.Add(this.lblImageposition);
            this.pnlBottom.Controls.Add(this.btnPrevious);
            this.pnlBottom.Controls.Add(this.btnNext);
            this.pnlBottom.Location = new System.Drawing.Point(0, 438);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(753, 62);
            this.pnlBottom.TabIndex = 18;
            this.pnlBottom.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlBottom_Paint);
            // 
            // lblImageposition
            // 
            this.lblImageposition.AutoSize = true;
            this.lblImageposition.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblImageposition.Location = new System.Drawing.Point(361, 21);
            this.lblImageposition.Name = "lblImageposition";
            this.lblImageposition.Size = new System.Drawing.Size(31, 20);
            this.lblImageposition.TabIndex = 33;
            this.lblImageposition.Text = "0/0";
            // 
            // BigPreviewPicture
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(79)))), ((int)(((byte)(90)))));
            this.ClientSize = new System.Drawing.Size(753, 500);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pcbBigPicture);
            this.Name = "BigPreviewPicture";
            this.Text = "Plugin Preview";
            this.Load += new System.EventHandler(this.BigPreviewPicture_Load);
            this.Resize += new System.EventHandler(this.BigPreviewPicture_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.pcbBigPicture)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            this.pnlBottom.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pcbBigPicture;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Label lblImageposition;
    }
}