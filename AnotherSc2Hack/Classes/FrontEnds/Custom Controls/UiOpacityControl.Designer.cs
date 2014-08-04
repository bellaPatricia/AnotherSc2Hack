namespace AnotherSc2Hack.Classes.FrontEnds
{
    partial class UiOpacityControl
    {
        /// <summary> 
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Komponenten-Designer generierter Code

        /// <summary> 
        /// Erforderliche Methode für die Designerunterstützung. 
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UiOpacityControl));
            this.lblOpacity = new System.Windows.Forms.Label();
            this.tbOpacity = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.tbOpacity)).BeginInit();
            this.SuspendLayout();
            // 
            // lblOpacity
            // 
            resources.ApplyResources(this.lblOpacity, "lblOpacity");
            this.lblOpacity.Name = "lblOpacity";
            // 
            // tbOpacity
            // 
            resources.ApplyResources(this.tbOpacity, "tbOpacity");
            this.tbOpacity.Maximum = 100;
            this.tbOpacity.Name = "tbOpacity";
            this.tbOpacity.Scroll += new System.EventHandler(this.tbOpacity_Scroll);
            this.tbOpacity.ValueChanged += new System.EventHandler(this.tbOpacity_ValueChanged);
            // 
            // UiOpacityControl
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblOpacity);
            this.Controls.Add(this.tbOpacity);
            this.Name = "UiOpacityControl";
            ((System.ComponentModel.ISupportInitialize)(this.tbOpacity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label lblOpacity;
        public System.Windows.Forms.TrackBar tbOpacity;
    }
}
