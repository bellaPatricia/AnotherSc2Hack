using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using AnotherSc2Hack.Classes.FrontEnds.Custom_Controls;

namespace AnotherSc2Hack.Classes.FrontEnds.Container
{
    partial class PanelSettingsLauncher
    {
        /// <summary> 
        /// Erforderliche Designervariable.
        /// </summary>
        private IContainer components = null;

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
            this.lblHotkey1 = new LanguageLabel();
            this.ktxtHotkey1 = new KeyTextBox();
            this.ktxtHotkey2 = new KeyTextBox();
            this.lblHotkey2 = new LanguageLabel();
            this.ktxtHotkey3 = new KeyTextBox();
            this.lblHotkey3 = new LanguageLabel();
            this.lblToggle = new LanguageLabel();
            this.txtToggle = new TextBox();
            this.txtResize = new TextBox();
            this.lblResize = new LanguageLabel();
            this.txtReposition = new TextBox();
            this.lblReposition = new LanguageLabel();
            this.lblChat = new LanguageLabel();
            this.lblHotkeys = new LanguageLabel();
            this.SuspendLayout();
            // 
            // lblHotkey1
            // 
            this.lblHotkey1.AutoSize = true;
            this.lblHotkey1.LanguageFile = "";
            this.lblHotkey1.Location = new Point(3, 165);
            this.lblHotkey1.Name = "lblHotkey1";
            this.lblHotkey1.Size = new Size(71, 20);
            this.lblHotkey1.TabIndex = 0;
            this.lblHotkey1.Text = "Hotkey 1:";
            // 
            // ktxtHotkey1
            // 
            this.ktxtHotkey1.HotKeyValue = Keys.None;
            this.ktxtHotkey1.Location = new Point(163, 162);
            this.ktxtHotkey1.Name = "ktxtHotkey1";
            this.ktxtHotkey1.Size = new Size(100, 27);
            this.ktxtHotkey1.TabIndex = 1;
            // 
            // ktxtHotkey2
            // 
            this.ktxtHotkey2.HotKeyValue = Keys.None;
            this.ktxtHotkey2.Location = new Point(163, 195);
            this.ktxtHotkey2.Name = "ktxtHotkey2";
            this.ktxtHotkey2.Size = new Size(100, 27);
            this.ktxtHotkey2.TabIndex = 3;
            // 
            // lblHotkey2
            // 
            this.lblHotkey2.AutoSize = true;
            this.lblHotkey2.LanguageFile = "";
            this.lblHotkey2.Location = new Point(3, 198);
            this.lblHotkey2.Name = "lblHotkey2";
            this.lblHotkey2.Size = new Size(71, 20);
            this.lblHotkey2.TabIndex = 2;
            this.lblHotkey2.Text = "Hotkey 2:";
            // 
            // ktxtHotkey3
            // 
            this.ktxtHotkey3.HotKeyValue = Keys.None;
            this.ktxtHotkey3.Location = new Point(163, 228);
            this.ktxtHotkey3.Name = "ktxtHotkey3";
            this.ktxtHotkey3.Size = new Size(100, 27);
            this.ktxtHotkey3.TabIndex = 5;
            // 
            // lblHotkey3
            // 
            this.lblHotkey3.AutoSize = true;
            this.lblHotkey3.LanguageFile = "";
            this.lblHotkey3.Location = new Point(3, 231);
            this.lblHotkey3.Name = "lblHotkey3";
            this.lblHotkey3.Size = new Size(71, 20);
            this.lblHotkey3.TabIndex = 4;
            this.lblHotkey3.Text = "Hotkey 3:";
            // 
            // lblToggle
            // 
            this.lblToggle.AutoSize = true;
            this.lblToggle.LanguageFile = "";
            this.lblToggle.Location = new Point(3, 34);
            this.lblToggle.Name = "lblToggle";
            this.lblToggle.Size = new Size(99, 20);
            this.lblToggle.TabIndex = 6;
            this.lblToggle.Text = "Toggle Panel:";
            // 
            // txtToggle
            // 
            this.txtToggle.Location = new Point(163, 31);
            this.txtToggle.Name = "txtToggle";
            this.txtToggle.Size = new Size(100, 27);
            this.txtToggle.TabIndex = 7;
            // 
            // txtResize
            // 
            this.txtResize.Location = new Point(163, 64);
            this.txtResize.Name = "txtResize";
            this.txtResize.Size = new Size(100, 27);
            this.txtResize.TabIndex = 9;
            // 
            // lblResize
            // 
            this.lblResize.AutoSize = true;
            this.lblResize.LanguageFile = "";
            this.lblResize.Location = new Point(3, 67);
            this.lblResize.Name = "lblResize";
            this.lblResize.Size = new Size(94, 20);
            this.lblResize.TabIndex = 8;
            this.lblResize.Text = "Resize Panel:";
            // 
            // txtReposition
            // 
            this.txtReposition.Location = new Point(163, 97);
            this.txtReposition.Name = "txtReposition";
            this.txtReposition.Size = new Size(100, 27);
            this.txtReposition.TabIndex = 11;
            // 
            // lblReposition
            // 
            this.lblReposition.AutoSize = true;
            this.lblReposition.LanguageFile = "";
            this.lblReposition.Location = new Point(3, 100);
            this.lblReposition.Name = "lblReposition";
            this.lblReposition.Size = new Size(123, 20);
            this.lblReposition.TabIndex = 10;
            this.lblReposition.Text = "Reposition Panel:";
            // 
            // lblChat
            // 
            this.lblChat.AutoSize = true;
            this.lblChat.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            this.lblChat.ForeColor = Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(78)))), ((int)(((byte)(90)))));
            this.lblChat.LanguageFile = "";
            this.lblChat.Location = new Point(3, 3);
            this.lblChat.Name = "lblChat";
            this.lblChat.Size = new Size(191, 20);
            this.lblChat.TabIndex = 12;
            this.lblChat.Text = "Launch using ingame chat";
            // 
            // lblHotkeys
            // 
            this.lblHotkeys.AutoSize = true;
            this.lblHotkeys.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            this.lblHotkeys.ForeColor = Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(78)))), ((int)(((byte)(90)))));
            this.lblHotkeys.LanguageFile = "";
            this.lblHotkeys.Location = new Point(3, 135);
            this.lblHotkeys.Name = "lblHotkeys";
            this.lblHotkeys.Size = new Size(162, 20);
            this.lblHotkeys.TabIndex = 13;
            this.lblHotkeys.Text = "Launch using Hotkeys";
            // 
            // PanelSettingsLauncher
            // 
            this.AutoScaleDimensions = new SizeF(8F, 20F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.Controls.Add(this.lblHotkeys);
            this.Controls.Add(this.lblChat);
            this.Controls.Add(this.txtReposition);
            this.Controls.Add(this.lblReposition);
            this.Controls.Add(this.txtResize);
            this.Controls.Add(this.lblResize);
            this.Controls.Add(this.txtToggle);
            this.Controls.Add(this.lblToggle);
            this.Controls.Add(this.ktxtHotkey3);
            this.Controls.Add(this.lblHotkey3);
            this.Controls.Add(this.ktxtHotkey2);
            this.Controls.Add(this.lblHotkey2);
            this.Controls.Add(this.ktxtHotkey1);
            this.Controls.Add(this.lblHotkey1);
            this.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new Padding(4, 5, 4, 5);
            this.Name = "PanelSettingsLauncher";
            this.Size = new Size(268, 261);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private LanguageLabel lblHotkey1;
        public KeyTextBox ktxtHotkey1;
        public KeyTextBox ktxtHotkey2;
        private LanguageLabel lblHotkey2;
        public KeyTextBox ktxtHotkey3;
        private LanguageLabel lblHotkey3;
        private LanguageLabel lblToggle;
        public TextBox txtToggle;
        public TextBox txtResize;
        private LanguageLabel lblResize;
        public TextBox txtReposition;
        private LanguageLabel lblReposition;
        private LanguageLabel lblChat;
        private LanguageLabel lblHotkeys;
    }
}
