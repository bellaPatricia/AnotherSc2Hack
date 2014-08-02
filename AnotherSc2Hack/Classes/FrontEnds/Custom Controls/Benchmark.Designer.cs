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
            this.lblDrawingUnitpanelIterations = new System.Windows.Forms.Label();
            this.lblDrawingMaphackpanelIterations = new System.Windows.Forms.Label();
            this.lblDrawingWorkerpanelIterations = new System.Windows.Forms.Label();
            this.lblDrawingArmypanelIterations = new System.Windows.Forms.Label();
            this.lblDrawingApmpanelIterations = new System.Windows.Forms.Label();
            this.lblDrawingIncomepanelIterations = new System.Windows.Forms.Label();
            this.lblDrawingResourcepanelIterations = new System.Windows.Forms.Label();
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
            this.gpDrawing.Controls.Add(this.lblDrawingUnitpanelIterations);
            this.gpDrawing.Controls.Add(this.lblDrawingMaphackpanelIterations);
            this.gpDrawing.Controls.Add(this.lblDrawingWorkerpanelIterations);
            this.gpDrawing.Controls.Add(this.lblDrawingArmypanelIterations);
            this.gpDrawing.Controls.Add(this.lblDrawingApmpanelIterations);
            this.gpDrawing.Controls.Add(this.lblDrawingIncomepanelIterations);
            this.gpDrawing.Controls.Add(this.lblDrawingResourcepanelIterations);
            this.gpDrawing.Controls.Add(this.lblDrawingInterval);
            this.gpDrawing.Name = "gpDrawing";
            this.gpDrawing.TabStop = false;
            // 
            // lblDrawingUnitpanelIterations
            // 
            resources.ApplyResources(this.lblDrawingUnitpanelIterations, "lblDrawingUnitpanelIterations");
            this.lblDrawingUnitpanelIterations.Name = "lblDrawingUnitpanelIterations";
            // 
            // lblDrawingMaphackpanelIterations
            // 
            resources.ApplyResources(this.lblDrawingMaphackpanelIterations, "lblDrawingMaphackpanelIterations");
            this.lblDrawingMaphackpanelIterations.Name = "lblDrawingMaphackpanelIterations";
            // 
            // lblDrawingWorkerpanelIterations
            // 
            resources.ApplyResources(this.lblDrawingWorkerpanelIterations, "lblDrawingWorkerpanelIterations");
            this.lblDrawingWorkerpanelIterations.Name = "lblDrawingWorkerpanelIterations";
            // 
            // lblDrawingArmypanelIterations
            // 
            resources.ApplyResources(this.lblDrawingArmypanelIterations, "lblDrawingArmypanelIterations");
            this.lblDrawingArmypanelIterations.Name = "lblDrawingArmypanelIterations";
            // 
            // lblDrawingApmpanelIterations
            // 
            resources.ApplyResources(this.lblDrawingApmpanelIterations, "lblDrawingApmpanelIterations");
            this.lblDrawingApmpanelIterations.Name = "lblDrawingApmpanelIterations";
            // 
            // lblDrawingIncomepanelIterations
            // 
            resources.ApplyResources(this.lblDrawingIncomepanelIterations, "lblDrawingIncomepanelIterations");
            this.lblDrawingIncomepanelIterations.Name = "lblDrawingIncomepanelIterations";
            // 
            // lblDrawingResourcepanelIterations
            // 
            resources.ApplyResources(this.lblDrawingResourcepanelIterations, "lblDrawingResourcepanelIterations");
            this.lblDrawingResourcepanelIterations.Name = "lblDrawingResourcepanelIterations";
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
        public System.Windows.Forms.Label lblDrawingUnitpanelIterations;
        public System.Windows.Forms.Label lblDrawingMaphackpanelIterations;
        public System.Windows.Forms.Label lblDrawingWorkerpanelIterations;
        public System.Windows.Forms.Label lblDrawingArmypanelIterations;
        public System.Windows.Forms.Label lblDrawingApmpanelIterations;
        public System.Windows.Forms.Label lblDrawingIncomepanelIterations;
        public System.Windows.Forms.Label lblDrawingResourcepanelIterations;
        public System.Windows.Forms.Label lblDrawingInterval;
    }
}
