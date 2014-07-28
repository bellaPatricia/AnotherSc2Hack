namespace AnotherSc2Hack.Classes.FrontEnds
{
    partial class Renderer
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
            this.tmrRefreshGraphic = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // tmrRefreshGraphic
            // 
            this.tmrRefreshGraphic.Tick += new System.EventHandler(this.tmrRefreshGraphic_Tick);
            // 
            // Renderer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(89, 31);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Renderer";
            this.Text = "Renderer";
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Renderer_FormClosing);
            this.Load += new System.EventHandler(this.Renderer_2_Load);
            this.ResizeEnd += new System.EventHandler(this.Renderer_ResizeEnd);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Renderer_2_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Renderer_2_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Renderer_2_MouseUp);
            this.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.Renderer_2_MouseWheel);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Timer tmrRefreshGraphic;
    }
}