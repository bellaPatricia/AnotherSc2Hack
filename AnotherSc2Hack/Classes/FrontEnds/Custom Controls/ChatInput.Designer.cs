namespace AnotherSc2Hack.Classes.FrontEnds
{
    partial class ChatInput
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
            this.gbChatInput = new LanguageGroupbox();
            this.txtSize = new System.Windows.Forms.TextBox();
            this.txtPosition = new System.Windows.Forms.TextBox();
            this.txtToggle = new System.Windows.Forms.TextBox();
            this.lblChangeSize = new LanguageLabel();
            this.lblChangePosition = new LanguageLabel();
            this.lblEnablePanel = new LanguageLabel();
            this.gbChatInput.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbChatInput
            // 
            this.gbChatInput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbChatInput.Controls.Add(this.txtSize);
            this.gbChatInput.Controls.Add(this.txtPosition);
            this.gbChatInput.Controls.Add(this.txtToggle);
            this.gbChatInput.Controls.Add(this.lblChangeSize);
            this.gbChatInput.Controls.Add(this.lblChangePosition);
            this.gbChatInput.Controls.Add(this.lblEnablePanel);
            this.gbChatInput.Location = new System.Drawing.Point(0, 0);
            this.gbChatInput.Name = "gbChatInput";
            this.gbChatInput.Size = new System.Drawing.Size(246, 120);
            this.gbChatInput.TabIndex = 27;
            this.gbChatInput.TabStop = false;
            this.gbChatInput.Text = "Chat Input";
            // 
            // txtSize
            // 
            this.txtSize.Location = new System.Drawing.Point(151, 87);
            this.txtSize.Name = "txtSize";
            this.txtSize.Size = new System.Drawing.Size(83, 20);
            this.txtSize.TabIndex = 16;
            // 
            // txtPosition
            // 
            this.txtPosition.Location = new System.Drawing.Point(151, 57);
            this.txtPosition.Name = "txtPosition";
            this.txtPosition.Size = new System.Drawing.Size(83, 20);
            this.txtPosition.TabIndex = 15;
            // 
            // txtToggle
            // 
            this.txtToggle.Location = new System.Drawing.Point(151, 27);
            this.txtToggle.Name = "txtToggle";
            this.txtToggle.Size = new System.Drawing.Size(83, 20);
            this.txtToggle.TabIndex = 14;
            // 
            // lblChangeSize
            // 
            this.lblChangeSize.AutoSize = true;
            this.lblChangeSize.Location = new System.Drawing.Point(12, 90);
            this.lblChangeSize.Name = "lblChangeSize";
            this.lblChangeSize.Size = new System.Drawing.Size(112, 13);
            this.lblChangeSize.TabIndex = 2;
            this.lblChangeSize.Text = "Change Size of Panel:";
            // 
            // lblChangePosition
            // 
            this.lblChangePosition.AutoSize = true;
            this.lblChangePosition.Location = new System.Drawing.Point(12, 60);
            this.lblChangePosition.Name = "lblChangePosition";
            this.lblChangePosition.Size = new System.Drawing.Size(129, 13);
            this.lblChangePosition.TabIndex = 1;
            this.lblChangePosition.Text = "Change Position of Panel:";
            // 
            // lblEnablePanel
            // 
            this.lblEnablePanel.AutoSize = true;
            this.lblEnablePanel.Location = new System.Drawing.Point(12, 30);
            this.lblEnablePanel.Name = "lblEnablePanel";
            this.lblEnablePanel.Size = new System.Drawing.Size(116, 13);
            this.lblEnablePanel.TabIndex = 0;
            this.lblEnablePanel.Text = "Enable/ Disable Panel:";
            // 
            // ChatInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbChatInput);
            this.Name = "ChatInput";
            this.Size = new System.Drawing.Size(246, 120);
            this.gbChatInput.ResumeLayout(false);
            this.gbChatInput.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private LanguageGroupbox gbChatInput;
        public System.Windows.Forms.TextBox txtSize;
        public System.Windows.Forms.TextBox txtPosition;
        public System.Windows.Forms.TextBox txtToggle;
        private LanguageLabel lblChangeSize;
        private LanguageLabel lblChangePosition;
        private LanguageLabel lblEnablePanel;
    }
}
