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
            this.gpData = new System.Windows.Forms.GroupBox();
            this.lblDataInterval = new System.Windows.Forms.Label();
            this.lblDataIterations = new System.Windows.Forms.Label();
            this.gpDrawing = new System.Windows.Forms.GroupBox();
            this.lblDrawingResIterations = new System.Windows.Forms.Label();
            this.lblDrawingInterval = new System.Windows.Forms.Label();
            this.lblDrawingIncIterations = new System.Windows.Forms.Label();
            this.lblDrawingApmIterations = new System.Windows.Forms.Label();
            this.lblDrawingArmIterations = new System.Windows.Forms.Label();
            this.lblDrawingWorIterations = new System.Windows.Forms.Label();
            this.lblDrawingMapIterations = new System.Windows.Forms.Label();
            this.lblDrawingUniIterations = new System.Windows.Forms.Label();
            this.gpData.SuspendLayout();
            this.gpDrawing.SuspendLayout();
            this.SuspendLayout();
            // 
            // gpData
            // 
            this.gpData.Controls.Add(this.lblDataIterations);
            this.gpData.Controls.Add(this.lblDataInterval);
            this.gpData.Location = new System.Drawing.Point(20, 20);
            this.gpData.Name = "gpData";
            this.gpData.Size = new System.Drawing.Size(166, 100);
            this.gpData.TabIndex = 0;
            this.gpData.TabStop = false;
            this.gpData.Text = "Data";
            // 
            // lblDataInterval
            // 
            this.lblDataInterval.AutoSize = true;
            this.lblDataInterval.Location = new System.Drawing.Point(20, 30);
            this.lblDataInterval.Name = "lblDataInterval";
            this.lblDataInterval.Size = new System.Drawing.Size(94, 13);
            this.lblDataInterval.TabIndex = 0;
            this.lblDataInterval.Text = "Interval: Unknown";
            // 
            // lblDataIterations
            // 
            this.lblDataIterations.AutoSize = true;
            this.lblDataIterations.Location = new System.Drawing.Point(20, 60);
            this.lblDataIterations.Name = "lblDataIterations";
            this.lblDataIterations.Size = new System.Drawing.Size(102, 13);
            this.lblDataIterations.TabIndex = 1;
            this.lblDataIterations.Text = "Iterations: Unknown";
            // 
            // gpDrawing
            // 
            this.gpDrawing.Controls.Add(this.lblDrawingUniIterations);
            this.gpDrawing.Controls.Add(this.lblDrawingMapIterations);
            this.gpDrawing.Controls.Add(this.lblDrawingWorIterations);
            this.gpDrawing.Controls.Add(this.lblDrawingArmIterations);
            this.gpDrawing.Controls.Add(this.lblDrawingApmIterations);
            this.gpDrawing.Controls.Add(this.lblDrawingIncIterations);
            this.gpDrawing.Controls.Add(this.lblDrawingResIterations);
            this.gpDrawing.Controls.Add(this.lblDrawingInterval);
            this.gpDrawing.Location = new System.Drawing.Point(192, 20);
            this.gpDrawing.Name = "gpDrawing";
            this.gpDrawing.Size = new System.Drawing.Size(182, 275);
            this.gpDrawing.TabIndex = 2;
            this.gpDrawing.TabStop = false;
            this.gpDrawing.Text = "Drawing";
            // 
            // lblDrawingResIterations
            // 
            this.lblDrawingResIterations.AutoSize = true;
            this.lblDrawingResIterations.Location = new System.Drawing.Point(20, 60);
            this.lblDrawingResIterations.Name = "lblDrawingResIterations";
            this.lblDrawingResIterations.Size = new System.Drawing.Size(127, 13);
            this.lblDrawingResIterations.TabIndex = 1;
            this.lblDrawingResIterations.Text = "Res. Iterations: Unknown";
            // 
            // lblDrawingInterval
            // 
            this.lblDrawingInterval.AutoSize = true;
            this.lblDrawingInterval.Location = new System.Drawing.Point(20, 30);
            this.lblDrawingInterval.Name = "lblDrawingInterval";
            this.lblDrawingInterval.Size = new System.Drawing.Size(94, 13);
            this.lblDrawingInterval.TabIndex = 0;
            this.lblDrawingInterval.Text = "Interval: Unknown";
            // 
            // lblDrawingIncIterations
            // 
            this.lblDrawingIncIterations.AutoSize = true;
            this.lblDrawingIncIterations.Location = new System.Drawing.Point(20, 90);
            this.lblDrawingIncIterations.Name = "lblDrawingIncIterations";
            this.lblDrawingIncIterations.Size = new System.Drawing.Size(123, 13);
            this.lblDrawingIncIterations.TabIndex = 2;
            this.lblDrawingIncIterations.Text = "Inc. Iterations: Unknown";
            // 
            // lblDrawingApmIterations
            // 
            this.lblDrawingApmIterations.AutoSize = true;
            this.lblDrawingApmIterations.Location = new System.Drawing.Point(20, 120);
            this.lblDrawingApmIterations.Name = "lblDrawingApmIterations";
            this.lblDrawingApmIterations.Size = new System.Drawing.Size(126, 13);
            this.lblDrawingApmIterations.TabIndex = 3;
            this.lblDrawingApmIterations.Text = "ApmCurrent Iterations: Unknown";
            // 
            // lblDrawingArmIterations
            // 
            this.lblDrawingArmIterations.AutoSize = true;
            this.lblDrawingArmIterations.Location = new System.Drawing.Point(20, 150);
            this.lblDrawingArmIterations.Name = "lblDrawingArmIterations";
            this.lblDrawingArmIterations.Size = new System.Drawing.Size(126, 13);
            this.lblDrawingArmIterations.TabIndex = 4;
            this.lblDrawingArmIterations.Text = "Arm. Iterations: Unknown";
            // 
            // lblDrawingWorIterations
            // 
            this.lblDrawingWorIterations.AutoSize = true;
            this.lblDrawingWorIterations.Location = new System.Drawing.Point(20, 180);
            this.lblDrawingWorIterations.Name = "lblDrawingWorIterations";
            this.lblDrawingWorIterations.Size = new System.Drawing.Size(128, 13);
            this.lblDrawingWorIterations.TabIndex = 5;
            this.lblDrawingWorIterations.Text = "Wor. Iterations: Unknown";
            // 
            // lblDrawingMapIterations
            // 
            this.lblDrawingMapIterations.AutoSize = true;
            this.lblDrawingMapIterations.Location = new System.Drawing.Point(20, 210);
            this.lblDrawingMapIterations.Name = "lblDrawingMapIterations";
            this.lblDrawingMapIterations.Size = new System.Drawing.Size(129, 13);
            this.lblDrawingMapIterations.TabIndex = 6;
            this.lblDrawingMapIterations.Text = "Map. Iterations: Unknown";
            // 
            // lblDrawingUniIterations
            // 
            this.lblDrawingUniIterations.AutoSize = true;
            this.lblDrawingUniIterations.Location = new System.Drawing.Point(20, 240);
            this.lblDrawingUniIterations.Name = "lblDrawingUniIterations";
            this.lblDrawingUniIterations.Size = new System.Drawing.Size(124, 13);
            this.lblDrawingUniIterations.TabIndex = 7;
            this.lblDrawingUniIterations.Text = "Uni. Iterations: Unknown";
            // 
            // Benchmark
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gpDrawing);
            this.Controls.Add(this.gpData);
            this.Name = "Benchmark";
            this.Size = new System.Drawing.Size(390, 319);
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
