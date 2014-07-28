namespace AnotherSc2Hack.Classes.FrontEnds
{
    partial class UnitInformation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UnitInformation));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtUnitNum = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lstUnitInformation = new System.Windows.Forms.ListBox();
            this.btnPrev = new System.Windows.Forms.Button();
            this.lblUnitNum = new System.Windows.Forms.Label();
            this.btnNext = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Controls.Add(this.txtUnitNum);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lstUnitInformation);
            this.groupBox1.Controls.Add(this.btnPrev);
            this.groupBox1.Controls.Add(this.lblUnitNum);
            this.groupBox1.Controls.Add(this.btnNext);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // txtUnitNum
            // 
            resources.ApplyResources(this.txtUnitNum, "txtUnitNum");
            this.txtUnitNum.Name = "txtUnitNum";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // lstUnitInformation
            // 
            resources.ApplyResources(this.lstUnitInformation, "lstUnitInformation");
            this.lstUnitInformation.FormattingEnabled = true;
            this.lstUnitInformation.Name = "lstUnitInformation";
            // 
            // btnPrev
            // 
            resources.ApplyResources(this.btnPrev, "btnPrev");
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.UseVisualStyleBackColor = true;
            // 
            // lblUnitNum
            // 
            resources.ApplyResources(this.lblUnitNum, "lblUnitNum");
            this.lblUnitNum.Name = "lblUnitNum";
            // 
            // btnNext
            // 
            resources.ApplyResources(this.btnNext, "btnNext");
            this.btnNext.Name = "btnNext";
            this.btnNext.UseVisualStyleBackColor = true;
            // 
            // UnitInformation
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "UnitInformation";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.Button btnPrev;
        public System.Windows.Forms.Button btnNext;
        public System.Windows.Forms.Label lblUnitNum;
        public System.Windows.Forms.ListBox lstUnitInformation;
        public System.Windows.Forms.TextBox txtUnitNum;
        private System.Windows.Forms.Label label1;
    }
}
