using System.ComponentModel;
using System.Windows.Forms;

namespace AnotherSc2Hack.Classes.FrontEnds.Rendering
{
    partial class BaseRenderer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaseRenderer));
            this.tmrRefreshGraphic = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // tmrRefreshGraphic
            // 
            this.tmrRefreshGraphic.Tick += new System.EventHandler(this.tmrRefreshGraphic_Tick);
            // 
            // BaseRenderer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(146, 41);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "BaseRenderer";
            this.Text = "BaseRenderer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BaseRenderer_FormClosing);
            this.Load += new System.EventHandler(this.BaseRenderer_Load);
            this.ResizeEnd += new System.EventHandler(this.BaseRenderer_ResizeEnd);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BaseRenderer_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.BaseRenderer_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.BaseRenderer_MouseUp);
            this.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.BaseRenderer_MouseWheel);
            this.Resize += new System.EventHandler(this.BaseRenderer_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        public Timer tmrRefreshGraphic;
    }
}