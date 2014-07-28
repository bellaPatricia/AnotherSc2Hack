namespace AnotherSc2Hack.Classes.FrontEnds
{
    partial class Information
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
            this.gbInformation = new AnotherSc2Hack.Classes.FrontEnds.LanguageGroupbox();
            this.txtHeight = new System.Windows.Forms.TextBox();
            this.txtWidth = new System.Windows.Forms.TextBox();
            this.txtPosY = new System.Windows.Forms.TextBox();
            this.txtPosX = new System.Windows.Forms.TextBox();
            this.lblHeight = new AnotherSc2Hack.Classes.FrontEnds.LanguageLabel();
            this.lblWidth = new AnotherSc2Hack.Classes.FrontEnds.LanguageLabel();
            this.lblPosY = new AnotherSc2Hack.Classes.FrontEnds.LanguageLabel();
            this.lblPosX = new AnotherSc2Hack.Classes.FrontEnds.LanguageLabel();
            this.gbInformation.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbInformation
            // 
            this.gbInformation.Controls.Add(this.txtHeight);
            this.gbInformation.Controls.Add(this.txtWidth);
            this.gbInformation.Controls.Add(this.txtPosY);
            this.gbInformation.Controls.Add(this.txtPosX);
            this.gbInformation.Controls.Add(this.lblHeight);
            this.gbInformation.Controls.Add(this.lblWidth);
            this.gbInformation.Controls.Add(this.lblPosY);
            this.gbInformation.Controls.Add(this.lblPosX);
            this.gbInformation.LanguageFile = "";
            this.gbInformation.Location = new System.Drawing.Point(0, 0);
            this.gbInformation.Name = "gbInformation";
            this.gbInformation.Size = new System.Drawing.Size(196, 156);
            this.gbInformation.TabIndex = 30;
            this.gbInformation.TabStop = false;
            this.gbInformation.Text = "Information";
            // 
            // txtHeight
            // 
            this.txtHeight.Enabled = false;
            this.txtHeight.Location = new System.Drawing.Point(89, 117);
            this.txtHeight.Name = "txtHeight";
            this.txtHeight.Size = new System.Drawing.Size(83, 20);
            this.txtHeight.TabIndex = 7;
            // 
            // txtWidth
            // 
            this.txtWidth.Enabled = false;
            this.txtWidth.Location = new System.Drawing.Point(89, 87);
            this.txtWidth.Name = "txtWidth";
            this.txtWidth.Size = new System.Drawing.Size(83, 20);
            this.txtWidth.TabIndex = 6;
            // 
            // txtPosY
            // 
            this.txtPosY.Enabled = false;
            this.txtPosY.Location = new System.Drawing.Point(89, 57);
            this.txtPosY.Name = "txtPosY";
            this.txtPosY.Size = new System.Drawing.Size(83, 20);
            this.txtPosY.TabIndex = 5;
            // 
            // txtPosX
            // 
            this.txtPosX.Enabled = false;
            this.txtPosX.Location = new System.Drawing.Point(89, 27);
            this.txtPosX.Name = "txtPosX";
            this.txtPosX.Size = new System.Drawing.Size(83, 20);
            this.txtPosX.TabIndex = 4;
            // 
            // lblHeight
            // 
            this.lblHeight.AutoSize = true;
            this.lblHeight.LanguageFile = "";
            this.lblHeight.Location = new System.Drawing.Point(12, 120);
            this.lblHeight.Name = "lblHeight";
            this.lblHeight.Size = new System.Drawing.Size(41, 13);
            this.lblHeight.TabIndex = 3;
            this.lblHeight.Text = "Height:";
            // 
            // lblWidth
            // 
            this.lblWidth.AutoSize = true;
            this.lblWidth.LanguageFile = "";
            this.lblWidth.Location = new System.Drawing.Point(12, 90);
            this.lblWidth.Name = "lblWidth";
            this.lblWidth.Size = new System.Drawing.Size(38, 13);
            this.lblWidth.TabIndex = 2;
            this.lblWidth.Text = "Width:";
            // 
            // lblPosY
            // 
            this.lblPosY.AutoSize = true;
            this.lblPosY.LanguageFile = "";
            this.lblPosY.Location = new System.Drawing.Point(12, 60);
            this.lblPosY.Name = "lblPosY";
            this.lblPosY.Size = new System.Drawing.Size(57, 13);
            this.lblPosY.TabIndex = 1;
            this.lblPosY.Text = "Position Y:";
            // 
            // lblPosX
            // 
            this.lblPosX.AutoSize = true;
            this.lblPosX.LanguageFile = "";
            this.lblPosX.Location = new System.Drawing.Point(12, 30);
            this.lblPosX.Name = "lblPosX";
            this.lblPosX.Size = new System.Drawing.Size(57, 13);
            this.lblPosX.TabIndex = 0;
            this.lblPosX.Text = "Position X:";
            // 
            // Information
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbInformation);
            this.Name = "Information";
            this.Size = new System.Drawing.Size(196, 156);
            this.gbInformation.ResumeLayout(false);
            this.gbInformation.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private LanguageGroupbox gbInformation;
        public System.Windows.Forms.TextBox txtHeight;
        public System.Windows.Forms.TextBox txtWidth;
        public System.Windows.Forms.TextBox txtPosY;
        public System.Windows.Forms.TextBox txtPosX;
        private LanguageLabel lblHeight;
        private LanguageLabel lblWidth;
        private LanguageLabel lblPosY;
        private LanguageLabel lblPosX;
    }
}
