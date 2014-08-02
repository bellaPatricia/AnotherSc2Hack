namespace AnotherSc2Hack.Classes.FrontEnds
{
    partial class CustomDebug
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomDebug));
            this.btnDebugExportIds = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.MapInfo = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lstGameinformation = new System.Windows.Forms.ListBox();
            this.lblPlayerObjects = new System.Windows.Forms.Label();
            this.lblUnitObjects = new System.Windows.Forms.Label();
            this.UnitInfo = new AnotherSc2Hack.Classes.FrontEnds.UnitInformation();
            this.PlayerInfo = new AnotherSc2Hack.Classes.FrontEnds.PlayerInformation();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnDebugExportIds
            // 
            resources.ApplyResources(this.btnDebugExportIds, "btnDebugExportIds");
            this.btnDebugExportIds.Name = "btnDebugExportIds";
            this.btnDebugExportIds.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Controls.Add(this.MapInfo);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // MapInfo
            // 
            resources.ApplyResources(this.MapInfo, "MapInfo");
            this.MapInfo.FormattingEnabled = true;
            this.MapInfo.Name = "MapInfo";
            // 
            // groupBox2
            // 
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Controls.Add(this.lstGameinformation);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // lstGameinformation
            // 
            resources.ApplyResources(this.lstGameinformation, "lstGameinformation");
            this.lstGameinformation.FormattingEnabled = true;
            this.lstGameinformation.Name = "lstGameinformation";
            // 
            // lblPlayerObjects
            // 
            resources.ApplyResources(this.lblPlayerObjects, "lblPlayerObjects");
            this.lblPlayerObjects.Name = "lblPlayerObjects";
            // 
            // lblUnitObjects
            // 
            resources.ApplyResources(this.lblUnitObjects, "lblUnitObjects");
            this.lblUnitObjects.Name = "lblUnitObjects";
            // 
            // UnitInfo
            // 
            resources.ApplyResources(this.UnitInfo, "UnitInfo");
            this.UnitInfo.Name = "UnitInfo";
            // 
            // PlayerInfo
            // 
            resources.ApplyResources(this.PlayerInfo, "PlayerInfo");
            this.PlayerInfo.Name = "PlayerInfo";
            // 
            // CustomDebug
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblUnitObjects);
            this.Controls.Add(this.lblPlayerObjects);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.UnitInfo);
            this.Controls.Add(this.PlayerInfo);
            this.Controls.Add(this.btnDebugExportIds);
            this.Name = "CustomDebug";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Button btnDebugExportIds;
        public PlayerInformation PlayerInfo;
        public UnitInformation UnitInfo;
        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.ListBox MapInfo;
        private System.Windows.Forms.GroupBox groupBox2;
        public System.Windows.Forms.ListBox lstGameinformation;
        public System.Windows.Forms.Label lblPlayerObjects;
        public System.Windows.Forms.Label lblUnitObjects;

    }
}
