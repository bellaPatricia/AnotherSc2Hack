namespace AnotherSc2Hack.Classes.FrontEnds
{
    partial class CustomVarious
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
            this.components = new System.ComponentModel.Container();
            this.gbPersonalOverlay = new AnotherSc2Hack.Classes.FrontEnds.LanguageGroupbox();
            this.gbClock = new AnotherSc2Hack.Classes.FrontEnds.LanguageGroupbox();
            this.chBxClock = new AnotherSc2Hack.Classes.FrontEnds.LanguageCheckbox();
            this.gbApm = new AnotherSc2Hack.Classes.FrontEnds.LanguageGroupbox();
            this.txtApmAlertLimit = new System.Windows.Forms.TextBox();
            this.chBxApmAlert = new AnotherSc2Hack.Classes.FrontEnds.LanguageCheckbox();
            this.chBxApm = new AnotherSc2Hack.Classes.FrontEnds.LanguageCheckbox();
            this.ttVarious = new System.Windows.Forms.ToolTip(this.components);
            this.gbPersonalOverlay.SuspendLayout();
            this.gbClock.SuspendLayout();
            this.gbApm.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbPersonalOverlay
            // 
            this.gbPersonalOverlay.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbPersonalOverlay.Controls.Add(this.gbClock);
            this.gbPersonalOverlay.Controls.Add(this.gbApm);
            this.gbPersonalOverlay.LanguageFile = "";
            this.gbPersonalOverlay.Location = new System.Drawing.Point(0, 0);
            this.gbPersonalOverlay.Name = "gbPersonalOverlay";
            this.gbPersonalOverlay.Size = new System.Drawing.Size(311, 176);
            this.gbPersonalOverlay.TabIndex = 0;
            this.gbPersonalOverlay.TabStop = false;
            this.gbPersonalOverlay.Text = "Persönliches Overlay";
            // 
            // gbClock
            // 
            this.gbClock.Controls.Add(this.chBxClock);
            this.gbClock.LanguageFile = "";
            this.gbClock.Location = new System.Drawing.Point(24, 107);
            this.gbClock.Name = "gbClock";
            this.gbClock.Size = new System.Drawing.Size(261, 45);
            this.gbClock.TabIndex = 3;
            this.gbClock.TabStop = false;
            this.gbClock.Text = "Uhr";
            // 
            // chBxClock
            // 
            this.chBxClock.AutoSize = true;
            this.chBxClock.LanguageFile = "";
            this.chBxClock.Location = new System.Drawing.Point(24, 19);
            this.chBxClock.Name = "chBxClock";
            this.chBxClock.Size = new System.Drawing.Size(105, 17);
            this.chBxClock.TabIndex = 1;
            this.chBxClock.Text = "Uhrzeit anzeigen";
            this.ttVarious.SetToolTip(this.chBxClock, "This will show the current time.\r\nBased on your system\'s clock.\r\n\r\nThis is printe" +
        "d as 24h clock!");
            this.chBxClock.UseVisualStyleBackColor = true;
            // 
            // gbApm
            // 
            this.gbApm.Controls.Add(this.txtApmAlertLimit);
            this.gbApm.Controls.Add(this.chBxApmAlert);
            this.gbApm.Controls.Add(this.chBxApm);
            this.gbApm.LanguageFile = "";
            this.gbApm.Location = new System.Drawing.Point(24, 19);
            this.gbApm.Name = "gbApm";
            this.gbApm.Size = new System.Drawing.Size(261, 82);
            this.gbApm.TabIndex = 2;
            this.gbApm.TabStop = false;
            this.gbApm.Text = "Apm";
            // 
            // txtApmAlertLimit
            // 
            this.txtApmAlertLimit.Location = new System.Drawing.Point(142, 46);
            this.txtApmAlertLimit.Name = "txtApmAlertLimit";
            this.txtApmAlertLimit.Size = new System.Drawing.Size(100, 20);
            this.txtApmAlertLimit.TabIndex = 2;
            this.ttVarious.SetToolTip(this.txtApmAlertLimit, "This is the minimum APM amount.\r\nThe color of the APM- window will\r\nchange to red" +
        "!");
            this.txtApmAlertLimit.TextChanged += new System.EventHandler(this.txtApmAlertLimit_TextChanged);
            // 
            // chBxApmAlert
            // 
            this.chBxApmAlert.AutoSize = true;
            this.chBxApmAlert.LanguageFile = "";
            this.chBxApmAlert.Location = new System.Drawing.Point(24, 49);
            this.chBxApmAlert.Name = "chBxApmAlert";
            this.chBxApmAlert.Size = new System.Drawing.Size(91, 17);
            this.chBxApmAlert.TabIndex = 1;
            this.chBxApmAlert.Text = "Apm Meldung";
            this.ttVarious.SetToolTip(this.chBxApmAlert, "Allows you to know when your APM\r\nis dropping. Could improve your speed!");
            this.chBxApmAlert.UseVisualStyleBackColor = true;
            // 
            // chBxApm
            // 
            this.chBxApm.AutoSize = true;
            this.chBxApm.LanguageFile = "";
            this.chBxApm.Location = new System.Drawing.Point(24, 19);
            this.chBxApm.Name = "chBxApm";
            this.chBxApm.Size = new System.Drawing.Size(93, 17);
            this.chBxApm.TabIndex = 0;
            this.chBxApm.Text = "Apm anzeigen";
            this.ttVarious.SetToolTip(this.chBxApm, "Shows your current APM\r\n(only in game you play!)");
            this.chBxApm.UseVisualStyleBackColor = true;
            // 
            // CustomVarious
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbPersonalOverlay);
            this.Name = "CustomVarious";
            this.Size = new System.Drawing.Size(311, 176);
            this.gbPersonalOverlay.ResumeLayout(false);
            this.gbClock.ResumeLayout(false);
            this.gbClock.PerformLayout();
            this.gbApm.ResumeLayout(false);
            this.gbApm.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private LanguageGroupbox gbPersonalOverlay;
        public LanguageCheckbox chBxClock;
        public LanguageCheckbox chBxApm;
        private LanguageGroupbox gbClock;
        private LanguageGroupbox gbApm;
        public System.Windows.Forms.TextBox txtApmAlertLimit;
        public LanguageCheckbox chBxApmAlert;
        private System.Windows.Forms.ToolTip ttVarious;
    }
}
