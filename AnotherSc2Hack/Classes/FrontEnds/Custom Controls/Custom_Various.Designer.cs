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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomVarious));
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
            resources.ApplyResources(this.gbPersonalOverlay, "gbPersonalOverlay");
            this.gbPersonalOverlay.Controls.Add(this.gbClock);
            this.gbPersonalOverlay.Controls.Add(this.gbApm);
            this.gbPersonalOverlay.LanguageFile = "";
            this.gbPersonalOverlay.Name = "gbPersonalOverlay";
            this.gbPersonalOverlay.TabStop = false;
            this.ttVarious.SetToolTip(this.gbPersonalOverlay, resources.GetString("gbPersonalOverlay.ToolTip"));
            // 
            // gbClock
            // 
            resources.ApplyResources(this.gbClock, "gbClock");
            this.gbClock.Controls.Add(this.chBxClock);
            this.gbClock.LanguageFile = "";
            this.gbClock.Name = "gbClock";
            this.gbClock.TabStop = false;
            this.ttVarious.SetToolTip(this.gbClock, resources.GetString("gbClock.ToolTip"));
            // 
            // chBxClock
            // 
            resources.ApplyResources(this.chBxClock, "chBxClock");
            this.chBxClock.LanguageFile = "";
            this.chBxClock.Name = "chBxClock";
            this.ttVarious.SetToolTip(this.chBxClock, resources.GetString("chBxClock.ToolTip"));
            this.chBxClock.UseVisualStyleBackColor = true;
            // 
            // gbApm
            // 
            resources.ApplyResources(this.gbApm, "gbApm");
            this.gbApm.Controls.Add(this.txtApmAlertLimit);
            this.gbApm.Controls.Add(this.chBxApmAlert);
            this.gbApm.Controls.Add(this.chBxApm);
            this.gbApm.LanguageFile = "";
            this.gbApm.Name = "gbApm";
            this.gbApm.TabStop = false;
            this.ttVarious.SetToolTip(this.gbApm, resources.GetString("gbApm.ToolTip"));
            // 
            // txtApmAlertLimit
            // 
            resources.ApplyResources(this.txtApmAlertLimit, "txtApmAlertLimit");
            this.txtApmAlertLimit.Name = "txtApmAlertLimit";
            this.ttVarious.SetToolTip(this.txtApmAlertLimit, resources.GetString("txtApmAlertLimit.ToolTip"));
            this.txtApmAlertLimit.TextChanged += new System.EventHandler(this.txtApmAlertLimit_TextChanged);
            // 
            // chBxApmAlert
            // 
            resources.ApplyResources(this.chBxApmAlert, "chBxApmAlert");
            this.chBxApmAlert.LanguageFile = "";
            this.chBxApmAlert.Name = "chBxApmAlert";
            this.ttVarious.SetToolTip(this.chBxApmAlert, resources.GetString("chBxApmAlert.ToolTip"));
            this.chBxApmAlert.UseVisualStyleBackColor = true;
            // 
            // chBxApm
            // 
            resources.ApplyResources(this.chBxApm, "chBxApm");
            this.chBxApm.LanguageFile = "";
            this.chBxApm.Name = "chBxApm";
            this.ttVarious.SetToolTip(this.chBxApm, resources.GetString("chBxApm.ToolTip"));
            this.chBxApm.UseVisualStyleBackColor = true;
            // 
            // CustomVarious
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbPersonalOverlay);
            this.Name = "CustomVarious";
            this.ttVarious.SetToolTip(this, resources.GetString("$this.ToolTip"));
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
