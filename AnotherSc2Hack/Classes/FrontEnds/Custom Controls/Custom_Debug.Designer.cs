using AnotherSc2Hack.Classes.FontEnds;

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
            this.btnDebugExportIds = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.MapInfo = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lstGameinformation = new System.Windows.Forms.ListBox();
            this.UnitInfo = new UnitInformation();
            this.PlayerInfo = new PlayerInformation();
            this.lblPlayerObjects = new System.Windows.Forms.Label();
            this.lblUnitObjects = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnDebugExportIds
            // 
            this.btnDebugExportIds.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDebugExportIds.Location = new System.Drawing.Point(684, 324);
            this.btnDebugExportIds.Name = "btnDebugExportIds";
            this.btnDebugExportIds.Size = new System.Drawing.Size(200, 38);
            this.btnDebugExportIds.TabIndex = 1;
            this.btnDebugExportIds.Text = "Export current UnitId\'s with Names to file";
            this.btnDebugExportIds.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.MapInfo);
            this.groupBox1.Location = new System.Drawing.Point(684, 18);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 109);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "MapInformation";
            // 
            // MapInfo
            // 
            this.MapInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MapInfo.FormattingEnabled = true;
            this.MapInfo.Location = new System.Drawing.Point(6, 19);
            this.MapInfo.Name = "MapInfo";
            this.MapInfo.Size = new System.Drawing.Size(188, 82);
            this.MapInfo.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lstGameinformation);
            this.groupBox2.Location = new System.Drawing.Point(684, 133);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 185);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Gameinformation";
            // 
            // lstGameinformation
            // 
            this.lstGameinformation.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstGameinformation.FormattingEnabled = true;
            this.lstGameinformation.Location = new System.Drawing.Point(6, 19);
            this.lstGameinformation.Name = "lstGameinformation";
            this.lstGameinformation.Size = new System.Drawing.Size(188, 147);
            this.lstGameinformation.TabIndex = 0;
            // 
            // UnitInfo
            // 
            this.UnitInfo.Location = new System.Drawing.Point(357, 18);
            this.UnitInfo.Name = "UnitInfo";
            this.UnitInfo.Size = new System.Drawing.Size(321, 344);
            this.UnitInfo.TabIndex = 4;
            // 
            // PlayerInfo
            // 
            this.PlayerInfo.Location = new System.Drawing.Point(30, 18);
            this.PlayerInfo.Name = "PlayerInfo";
            this.PlayerInfo.Size = new System.Drawing.Size(321, 344);
            this.PlayerInfo.TabIndex = 3;
            // 
            // lblPlayerObjects
            // 
            this.lblPlayerObjects.AutoSize = true;
            this.lblPlayerObjects.Location = new System.Drawing.Point(27, 365);
            this.lblPlayerObjects.Name = "lblPlayerObjects";
            this.lblPlayerObjects.Size = new System.Drawing.Size(81, 13);
            this.lblPlayerObjects.TabIndex = 7;
            this.lblPlayerObjects.Text = "Player Objects: ";
            // 
            // lblUnitObjects
            // 
            this.lblUnitObjects.AutoSize = true;
            this.lblUnitObjects.Location = new System.Drawing.Point(354, 365);
            this.lblUnitObjects.Name = "lblUnitObjects";
            this.lblUnitObjects.Size = new System.Drawing.Size(68, 13);
            this.lblUnitObjects.TabIndex = 8;
            this.lblUnitObjects.Text = "Unit Objects:";
            // 
            // CustomDebug
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblUnitObjects);
            this.Controls.Add(this.lblPlayerObjects);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.UnitInfo);
            this.Controls.Add(this.PlayerInfo);
            this.Controls.Add(this.btnDebugExportIds);
            this.Name = "CustomDebug";
            this.Size = new System.Drawing.Size(895, 385);
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
