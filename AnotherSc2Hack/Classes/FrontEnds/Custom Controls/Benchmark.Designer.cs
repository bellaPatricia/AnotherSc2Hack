namespace AnotherSc2Hack.Classes.FrontEnds
{
    partial class Benchmark
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Benchmark));
            this.gpData = new System.Windows.Forms.GroupBox();
            this.lblDataIterations = new System.Windows.Forms.Label();
            this.lblDataInterval = new System.Windows.Forms.Label();
            this.gpDrawing = new System.Windows.Forms.GroupBox();
            this.lblDrawingUniIterations = new System.Windows.Forms.Label();
            this.lblDrawingMapIterations = new System.Windows.Forms.Label();
            this.lblDrawingWorIterations = new System.Windows.Forms.Label();
            this.lblDrawingArmIterations = new System.Windows.Forms.Label();
            this.lblDrawingApmIterations = new System.Windows.Forms.Label();
            this.lblDrawingIncIterations = new System.Windows.Forms.Label();
            this.lblDrawingResIterations = new System.Windows.Forms.Label();
            this.lblDrawingInterval = new System.Windows.Forms.Label();
            this.gpData.SuspendLayout();
            this.gpDrawing.SuspendLayout();
            this.SuspendLayout();
            // 
            // gpData
            // 
            resources.ApplyResources(this.gpData, "gpData");
            this.gpData.Controls.Add(this.lblDataIterations);
            this.gpData.Controls.Add(this.lblDataInterval);
            this.gpData.Name = "gpData";
            this.gpData.TabStop = false;
            // 
            // lblDataIterations
            // 
            resources.ApplyResources(this.lblDataIterations, "lblDataIterations");
            this.lblDataIterations.Name = "lblDataIterations";
            // 
            // lblDataInterval
            // 
            resources.ApplyResources(this.lblDataInterval, "lblDataInterval");
            this.lblDataInterval.Name = "lblDataInterval";
            // 
            // gpDrawing
            // 
            resources.ApplyResources(this.gpDrawing, "gpDrawing");
            this.gpDrawing.Controls.Add(this.lblDrawingUniIterations);
            this.gpDrawing.Controls.Add(this.lblDrawingMapIterations);
            this.gpDrawing.Controls.Add(this.lblDrawingWorIterations);
            this.gpDrawing.Controls.Add(this.lblDrawingArmIterations);
            this.gpDrawing.Controls.Add(this.lblDrawingApmIterations);
            this.gpDrawing.Controls.Add(this.lblDrawingIncIterations);
            this.gpDrawing.Controls.Add(this.lblDrawingResIterations);
            this.gpDrawing.Controls.Add(this.lblDrawingInterval);
            this.gpDrawing.Name = "gpDrawing";
            this.gpDrawing.TabStop = false;
            // 
            // lblDrawingUniIterations
            // 
            resources.ApplyResources(this.lblDrawingUniIterations, "lblDrawingUniIterations");
            this.lblDrawingUniIterations.Name = "lblDrawingUniIterations";
            // 
            // lblDrawingMapIterations
            // 
            resources.ApplyResources(this.lblDrawingMapIterations, "lblDrawingMapIterations");
            this.lblDrawingMapIterations.Name = "lblDrawingMapIterations";
            // 
            // lblDrawingWorIterations
            // 
            resources.ApplyResources(this.lblDrawingWorIterations, "lblDrawingWorIterations");
            this.lblDrawingWorIterations.Name = "lblDrawingWorIterations";
            // 
            // lblDrawingArmIterations
            // 
            resources.ApplyResources(this.lblDrawingArmIterations, "lblDrawingArmIterations");
            this.lblDrawingArmIterations.Name = "lblDrawingArmIterations";
            // 
            // lblDrawingApmIterations
            // 
            resources.ApplyResources(this.lblDrawingApmIterations, "lblDrawingApmIterations");
            this.lblDrawingApmIterations.Name = "lblDrawingApmIterations";
            // 
            // lblDrawingIncIterations
            // 
            resources.ApplyResources(this.lblDrawingIncIterations, "lblDrawingIncIterations");
            this.lblDrawingIncIterations.Name = "lblDrawingIncIterations";
            // 
            // lblDrawingResIterations
            // 
            resources.ApplyResources(this.lblDrawingResIterations, "lblDrawingResIterations");
            this.lblDrawingResIterations.Name = "lblDrawingResIterations";
            // 
            // lblDrawingInterval
            // 
            resources.ApplyResources(this.lblDrawingInterval, "lblDrawingInterval");
            this.lblDrawingInterval.Name = "lblDrawingInterval";
            // 
            // Benchmark
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gpDrawing);
            this.Controls.Add(this.gpData);
            this.Name = "Benchmark";
            this.gpData.ResumeLayout(false);
            this.gpData.PerformLayout();
            this.gpDrawing.ResumeLayout(false);
            this.gpDrawing.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gpData;
        public System.Windows.Forms.Label lblDataIterations;
        public System.Windows.Forms.Label lblDataInterval;
        private System.Windows.Forms.GroupBox gpDrawing;
        public System.Windows.Forms.Label lblDrawingUniIterations;
        public System.Windows.Forms.Label lblDrawingMapIterations;
        public System.Windows.Forms.Label lblDrawingWorIterations;
        public System.Windows.Forms.Label lblDrawingArmIterations;
        public System.Windows.Forms.Label lblDrawingApmIterations;
        public System.Windows.Forms.Label lblDrawingIncIterations;
        public System.Windows.Forms.Label lblDrawingResIterations;
        public System.Windows.Forms.Label lblDrawingInterval;
    }
}
