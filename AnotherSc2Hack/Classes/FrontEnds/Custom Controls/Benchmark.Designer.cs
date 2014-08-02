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
            this.lblDrawingMaphackIterations = new System.Windows.Forms.Label();
            this.lblDrawingWorkerIterations = new System.Windows.Forms.Label();
            this.lblDrawingArmyIterations = new System.Windows.Forms.Label();
            this.lblDrawingApmIterations = new System.Windows.Forms.Label();
            this.lblDrawingIncomeIterations = new System.Windows.Forms.Label();
            this.lblDrawingResourceIterations = new System.Windows.Forms.Label();
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
            this.gpDrawing.Controls.Add(this.lblDrawingMaphackIterations);
            this.gpDrawing.Controls.Add(this.lblDrawingWorkerIterations);
            this.gpDrawing.Controls.Add(this.lblDrawingArmyIterations);
            this.gpDrawing.Controls.Add(this.lblDrawingApmIterations);
            this.gpDrawing.Controls.Add(this.lblDrawingIncomeIterations);
            this.gpDrawing.Controls.Add(this.lblDrawingResourceIterations);
            this.gpDrawing.Controls.Add(this.lblDrawingInterval);
            this.gpDrawing.Name = "gpDrawing";
            this.gpDrawing.TabStop = false;
            // 
            // lblDrawingUniIterations
            // 
            resources.ApplyResources(this.lblDrawingUniIterations, "lblDrawingUniIterations");
            this.lblDrawingUniIterations.Name = "lblDrawingUniIterations";
            // 
            // lblDrawingMaphackIterations
            // 
            resources.ApplyResources(this.lblDrawingMaphackIterations, "lblDrawingMaphackIterations");
            this.lblDrawingMaphackIterations.Name = "lblDrawingMaphackIterations";
            // 
            // lblDrawingWorkerIterations
            // 
            resources.ApplyResources(this.lblDrawingWorkerIterations, "lblDrawingWorkerIterations");
            this.lblDrawingWorkerIterations.Name = "lblDrawingWorkerIterations";
            // 
            // lblDrawingArmyIterations
            // 
            resources.ApplyResources(this.lblDrawingArmyIterations, "lblDrawingArmyIterations");
            this.lblDrawingArmyIterations.Name = "lblDrawingArmyIterations";
            // 
            // lblDrawingApmIterations
            // 
            resources.ApplyResources(this.lblDrawingApmIterations, "lblDrawingApmIterations");
            this.lblDrawingApmIterations.Name = "lblDrawingApmIterations";
            // 
            // lblDrawingIncomeIterations
            // 
            resources.ApplyResources(this.lblDrawingIncomeIterations, "lblDrawingIncomeIterations");
            this.lblDrawingIncomeIterations.Name = "lblDrawingIncomeIterations";
            // 
            // lblDrawingResourceIterations
            // 
            resources.ApplyResources(this.lblDrawingResourceIterations, "lblDrawingResourceIterations");
            this.lblDrawingResourceIterations.Name = "lblDrawingResourceIterations";
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
        public System.Windows.Forms.Label lblDrawingMaphackIterations;
        public System.Windows.Forms.Label lblDrawingWorkerIterations;
        public System.Windows.Forms.Label lblDrawingArmyIterations;
        public System.Windows.Forms.Label lblDrawingApmIterations;
        public System.Windows.Forms.Label lblDrawingIncomeIterations;
        public System.Windows.Forms.Label lblDrawingResourceIterations;
        public System.Windows.Forms.Label lblDrawingInterval;
    }
}
