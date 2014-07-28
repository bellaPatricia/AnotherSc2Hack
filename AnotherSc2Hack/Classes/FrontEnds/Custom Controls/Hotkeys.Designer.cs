namespace AnotherSc2Hack.Classes.FrontEnds
{
    partial class Hotkeys
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
            this.gbLaunchPanels = new LanguageGroupbox();
            this.txtHotkey3 = new KeyTextBox();
            this.txtHotkey2 = new KeyTextBox();
            this.txtHotkey1 = new KeyTextBox();
            this.lblHotkey3 = new LanguageLabel();
            this.lblHotkey2 = new LanguageLabel();
            this.lblHotkey1 = new LanguageLabel();
            this.gbLaunchPanels.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbLaunchPanels
            // 
            this.gbLaunchPanels.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbLaunchPanels.Controls.Add(this.txtHotkey3);
            this.gbLaunchPanels.Controls.Add(this.txtHotkey2);
            this.gbLaunchPanels.Controls.Add(this.txtHotkey1);
            this.gbLaunchPanels.Controls.Add(this.lblHotkey3);
            this.gbLaunchPanels.Controls.Add(this.lblHotkey2);
            this.gbLaunchPanels.Controls.Add(this.lblHotkey1);
            this.gbLaunchPanels.Location = new System.Drawing.Point(0, 0);
            this.gbLaunchPanels.Name = "gbLaunchPanels";
            this.gbLaunchPanels.Size = new System.Drawing.Size(246, 128);
            this.gbLaunchPanels.TabIndex = 28;
            this.gbLaunchPanels.TabStop = false;
            this.gbLaunchPanels.Text = "Launch Panel";
            // 
            // txtHotkey3
            // 
            this.txtHotkey3.HotKeyValue = System.Windows.Forms.Keys.None;
            this.txtHotkey3.Location = new System.Drawing.Point(151, 87);
            this.txtHotkey3.Name = "txtHotkey3";
            this.txtHotkey3.Size = new System.Drawing.Size(83, 20);
            this.txtHotkey3.TabIndex = 2;
            this.txtHotkey3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtHotkey3_KeyDown);
            // 
            // txtHotkey2
            // 
            this.txtHotkey2.HotKeyValue = System.Windows.Forms.Keys.None;
            this.txtHotkey2.Location = new System.Drawing.Point(151, 57);
            this.txtHotkey2.Name = "txtHotkey2";
            this.txtHotkey2.Size = new System.Drawing.Size(83, 20);
            this.txtHotkey2.TabIndex = 1;
            this.txtHotkey2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtHotkey2_KeyDown);
            // 
            // txtHotkey1
            // 
            this.txtHotkey1.HotKeyValue = System.Windows.Forms.Keys.None;
            this.txtHotkey1.Location = new System.Drawing.Point(151, 27);
            this.txtHotkey1.Name = "txtHotkey1";
            this.txtHotkey1.Size = new System.Drawing.Size(83, 20);
            this.txtHotkey1.TabIndex = 0;
            this.txtHotkey1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtHotkey1_KeyDown);
            // 
            // lblHotkey3
            // 
            this.lblHotkey3.AutoSize = true;
            this.lblHotkey3.Location = new System.Drawing.Point(12, 90);
            this.lblHotkey3.Name = "lblHotkey3";
            this.lblHotkey3.Size = new System.Drawing.Size(53, 13);
            this.lblHotkey3.TabIndex = 2;
            this.lblHotkey3.Text = "Hotkey 3:";
            // 
            // lblHotkey2
            // 
            this.lblHotkey2.AutoSize = true;
            this.lblHotkey2.Location = new System.Drawing.Point(12, 60);
            this.lblHotkey2.Name = "lblHotkey2";
            this.lblHotkey2.Size = new System.Drawing.Size(53, 13);
            this.lblHotkey2.TabIndex = 1;
            this.lblHotkey2.Text = "Hotkey 2:";
            // 
            // lblHotkey1
            // 
            this.lblHotkey1.AutoSize = true;
            this.lblHotkey1.Location = new System.Drawing.Point(12, 30);
            this.lblHotkey1.Name = "lblHotkey1";
            this.lblHotkey1.Size = new System.Drawing.Size(53, 13);
            this.lblHotkey1.TabIndex = 0;
            this.lblHotkey1.Text = "Hotkey 1:";
            // 
            // Hotkeys
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbLaunchPanels);
            this.Name = "Hotkeys";
            this.Size = new System.Drawing.Size(246, 128);
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
