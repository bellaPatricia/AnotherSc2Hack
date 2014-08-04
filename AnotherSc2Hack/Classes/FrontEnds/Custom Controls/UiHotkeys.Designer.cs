namespace AnotherSc2Hack.Classes.FrontEnds
{
    partial class UiHotkeys
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UiHotkeys));
            this.gbLaunchPanels = new AnotherSc2Hack.Classes.FrontEnds.LanguageGroupbox();
            this.txtHotkey3 = new AnotherSc2Hack.Classes.FrontEnds.KeyTextBox();
            this.txtHotkey2 = new AnotherSc2Hack.Classes.FrontEnds.KeyTextBox();
            this.txtHotkey1 = new AnotherSc2Hack.Classes.FrontEnds.KeyTextBox();
            this.lblHotkey3 = new AnotherSc2Hack.Classes.FrontEnds.LanguageLabel();
            this.lblHotkey2 = new AnotherSc2Hack.Classes.FrontEnds.LanguageLabel();
            this.lblHotkey1 = new AnotherSc2Hack.Classes.FrontEnds.LanguageLabel();
            this.gbLaunchPanels.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbLaunchPanels
            // 
            resources.ApplyResources(this.gbLaunchPanels, "gbLaunchPanels");
            this.gbLaunchPanels.Controls.Add(this.txtHotkey3);
            this.gbLaunchPanels.Controls.Add(this.txtHotkey2);
            this.gbLaunchPanels.Controls.Add(this.txtHotkey1);
            this.gbLaunchPanels.Controls.Add(this.lblHotkey3);
            this.gbLaunchPanels.Controls.Add(this.lblHotkey2);
            this.gbLaunchPanels.Controls.Add(this.lblHotkey1);
            this.gbLaunchPanels.LanguageFile = "";
            this.gbLaunchPanels.Name = "gbLaunchPanels";
            this.gbLaunchPanels.TabStop = false;
            // 
            // txtHotkey3
            // 
            resources.ApplyResources(this.txtHotkey3, "txtHotkey3");
            this.txtHotkey3.HotKeyValue = System.Windows.Forms.Keys.None;
            this.txtHotkey3.Name = "txtHotkey3";
            this.txtHotkey3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtHotkey3_KeyDown);
            // 
            // txtHotkey2
            // 
            resources.ApplyResources(this.txtHotkey2, "txtHotkey2");
            this.txtHotkey2.HotKeyValue = System.Windows.Forms.Keys.None;
            this.txtHotkey2.Name = "txtHotkey2";
            this.txtHotkey2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtHotkey2_KeyDown);
            // 
            // txtHotkey1
            // 
            resources.ApplyResources(this.txtHotkey1, "txtHotkey1");
            this.txtHotkey1.HotKeyValue = System.Windows.Forms.Keys.None;
            this.txtHotkey1.Name = "txtHotkey1";
            this.txtHotkey1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtHotkey1_KeyDown);
            // 
            // lblHotkey3
            // 
            resources.ApplyResources(this.lblHotkey3, "lblHotkey3");
            this.lblHotkey3.LanguageFile = "";
            this.lblHotkey3.Name = "lblHotkey3";
            // 
            // lblHotkey2
            // 
            resources.ApplyResources(this.lblHotkey2, "lblHotkey2");
            this.lblHotkey2.LanguageFile = "";
            this.lblHotkey2.Name = "lblHotkey2";
            // 
            // lblHotkey1
            // 
            resources.ApplyResources(this.lblHotkey1, "lblHotkey1");
            this.lblHotkey1.LanguageFile = "";
            this.lblHotkey1.Name = "lblHotkey1";
            // 
            // UiHotkeys
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbLaunchPanels);
            this.Name = "UiHotkeys";
            this.gbLaunchPanels.ResumeLayout(false);
            this.gbLaunchPanels.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private LanguageGroupbox gbLaunchPanels;
        private LanguageLabel lblHotkey3;
        private LanguageLabel lblHotkey2;
        private LanguageLabel lblHotkey1;
        public KeyTextBox txtHotkey3;
        public KeyTextBox txtHotkey2;
        public KeyTextBox txtHotkey1;
    }
}
