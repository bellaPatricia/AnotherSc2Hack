namespace AnotherSc2Hack.Classes.FrontEnds.MainHandler
{
    partial class NewMainHandler
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewMainHandler));
            this.pnlLeftSelection = new System.Windows.Forms.Panel();
            this.pnlMainArea = new System.Windows.Forms.Panel();
            this.lblTabname = new System.Windows.Forms.Label();
            this.pnlApplication = new System.Windows.Forms.Panel();
            this.btnReposition = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.chBxOnlyDrawInForeground = new AnotherSc2Hack.Classes.FrontEnds.AnotherCheckbox();
            this.ktxtReposition = new AnotherSc2Hack.Classes.FrontEnds.KeyTextBox();
            this.ntxtGraphicsRefresh = new AnotherSc2Hack.Classes.FrontEnds.NumberTextBox();
            this.ntxtMemoryRefresh = new AnotherSc2Hack.Classes.FrontEnds.NumberTextBox();
            this.cpnlApplication = new AnotherSc2Hack.Classes.FrontEnds.Custom_Controls.ClickablePanel();
            this.cpnlOverlays = new AnotherSc2Hack.Classes.FrontEnds.Custom_Controls.ClickablePanel();
            this.cpnlPlugins = new AnotherSc2Hack.Classes.FrontEnds.Custom_Controls.ClickablePanel();
            this.cpnlAutomation = new AnotherSc2Hack.Classes.FrontEnds.Custom_Controls.ClickablePanel();
            this.pnlLeftSelection.SuspendLayout();
            this.pnlMainArea.SuspendLayout();
            this.pnlApplication.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlLeftSelection
            // 
            this.pnlLeftSelection.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pnlLeftSelection.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(79)))), ((int)(((byte)(90)))));
            this.pnlLeftSelection.Controls.Add(this.cpnlApplication);
            this.pnlLeftSelection.Controls.Add(this.cpnlOverlays);
            this.pnlLeftSelection.Controls.Add(this.cpnlPlugins);
            this.pnlLeftSelection.Controls.Add(this.cpnlAutomation);
            this.pnlLeftSelection.Location = new System.Drawing.Point(0, 0);
            this.pnlLeftSelection.Name = "pnlLeftSelection";
            this.pnlLeftSelection.Size = new System.Drawing.Size(152, 386);
            this.pnlLeftSelection.TabIndex = 5;
            // 
            // pnlMainArea
            // 
            this.pnlMainArea.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlMainArea.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.pnlMainArea.Controls.Add(this.lblTabname);
            this.pnlMainArea.Controls.Add(this.pnlApplication);
            this.pnlMainArea.Location = new System.Drawing.Point(152, 0);
            this.pnlMainArea.Name = "pnlMainArea";
            this.pnlMainArea.Size = new System.Drawing.Size(699, 386);
            this.pnlMainArea.TabIndex = 6;
            this.pnlMainArea.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlMainArea_Paint);
            // 
            // lblTabname
            // 
            this.lblTabname.AutoSize = true;
            this.lblTabname.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTabname.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(78)))), ((int)(((byte)(90)))));
            this.lblTabname.Location = new System.Drawing.Point(15, 15);
            this.lblTabname.Name = "lblTabname";
            this.lblTabname.Size = new System.Drawing.Size(118, 30);
            this.lblTabname.TabIndex = 1;
            this.lblTabname.Text = "Application";
            // 
            // pnlApplication
            // 
            this.pnlApplication.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlApplication.Controls.Add(this.chBxOnlyDrawInForeground);
            this.pnlApplication.Controls.Add(this.btnReposition);
            this.pnlApplication.Controls.Add(this.ktxtReposition);
            this.pnlApplication.Controls.Add(this.label3);
            this.pnlApplication.Controls.Add(this.ntxtGraphicsRefresh);
            this.pnlApplication.Controls.Add(this.ntxtMemoryRefresh);
            this.pnlApplication.Controls.Add(this.label2);
            this.pnlApplication.Controls.Add(this.label1);
            this.pnlApplication.Location = new System.Drawing.Point(0, 80);
            this.pnlApplication.Name = "pnlApplication";
            this.pnlApplication.Size = new System.Drawing.Size(699, 306);
            this.pnlApplication.TabIndex = 0;
            // 
            // btnReposition
            // 
            this.btnReposition.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReposition.Location = new System.Drawing.Point(15, 141);
            this.btnReposition.Name = "btnReposition";
            this.btnReposition.Size = new System.Drawing.Size(283, 32);
            this.btnReposition.TabIndex = 7;
            this.btnReposition.Text = "Reset panel position and size";
            this.btnReposition.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(15, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Reposition key:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(15, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(155, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Graphics Refresh (ms):";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(159, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Memory Reading (ms):";
            // 
            // chBxOnlyDrawInForeground
            // 
            this.chBxOnlyDrawInForeground.Checked = false;
            this.chBxOnlyDrawInForeground.DisplayText = "Only draw when SCII is in foreground";
            this.chBxOnlyDrawInForeground.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chBxOnlyDrawInForeground.Location = new System.Drawing.Point(15, 105);
            this.chBxOnlyDrawInForeground.Name = "chBxOnlyDrawInForeground";
            this.chBxOnlyDrawInForeground.Size = new System.Drawing.Size(283, 30);
            this.chBxOnlyDrawInForeground.TabIndex = 8;
            // 
            // ktxtReposition
            // 
            this.ktxtReposition.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ktxtReposition.HotKeyValue = System.Windows.Forms.Keys.None;
            this.ktxtReposition.Location = new System.Drawing.Point(198, 72);
            this.ktxtReposition.Name = "ktxtReposition";
            this.ktxtReposition.Size = new System.Drawing.Size(100, 27);
            this.ktxtReposition.TabIndex = 5;
            // 
            // ntxtGraphicsRefresh
            // 
            this.ntxtGraphicsRefresh.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ntxtGraphicsRefresh.Location = new System.Drawing.Point(198, 42);
            this.ntxtGraphicsRefresh.Name = "ntxtGraphicsRefresh";
            this.ntxtGraphicsRefresh.Number = 1;
            this.ntxtGraphicsRefresh.Size = new System.Drawing.Size(100, 27);
            this.ntxtGraphicsRefresh.TabIndex = 3;
            this.ntxtGraphicsRefresh.Text = "1";
            // 
            // ntxtMemoryRefresh
            // 
            this.ntxtMemoryRefresh.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ntxtMemoryRefresh.Location = new System.Drawing.Point(198, 12);
            this.ntxtMemoryRefresh.Name = "ntxtMemoryRefresh";
            this.ntxtMemoryRefresh.Number = 1;
            this.ntxtMemoryRefresh.Size = new System.Drawing.Size(100, 27);
            this.ntxtMemoryRefresh.TabIndex = 2;
            this.ntxtMemoryRefresh.Text = "1";
            // 
            // cpnlApplication
            // 
            this.cpnlApplication.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(79)))), ((int)(((byte)(90)))));
            this.cpnlApplication.DisplayColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(193)))), ((int)(((byte)(193)))));
            this.cpnlApplication.DisplayText = "Application";
            this.cpnlApplication.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cpnlApplication.Icon = ((System.Drawing.Image)(resources.GetObject("cpnlApplication.Icon")));
            this.cpnlApplication.IsClicked = false;
            this.cpnlApplication.IsHovering = false;
            this.cpnlApplication.Location = new System.Drawing.Point(0, 40);
            this.cpnlApplication.Name = "cpnlApplication";
            this.cpnlApplication.Size = new System.Drawing.Size(152, 40);
            this.cpnlApplication.TabIndex = 0;
            this.cpnlApplication.TextSize = 11F;
            this.cpnlApplication.Click += new System.EventHandler(this.cpnlApplication_Click);
            // 
            // cpnlOverlays
            // 
            this.cpnlOverlays.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(79)))), ((int)(((byte)(90)))));
            this.cpnlOverlays.DisplayColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(193)))), ((int)(((byte)(193)))));
            this.cpnlOverlays.DisplayText = "Overlays";
            this.cpnlOverlays.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cpnlOverlays.Icon = ((System.Drawing.Image)(resources.GetObject("cpnlOverlays.Icon")));
            this.cpnlOverlays.IsClicked = false;
            this.cpnlOverlays.IsHovering = false;
            this.cpnlOverlays.Location = new System.Drawing.Point(0, 80);
            this.cpnlOverlays.Name = "cpnlOverlays";
            this.cpnlOverlays.Size = new System.Drawing.Size(152, 40);
            this.cpnlOverlays.TabIndex = 1;
            this.cpnlOverlays.TextSize = 11F;
            this.cpnlOverlays.Click += new System.EventHandler(this.cpnlOverlays_Click);
            // 
            // cpnlPlugins
            // 
            this.cpnlPlugins.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(79)))), ((int)(((byte)(90)))));
            this.cpnlPlugins.DisplayColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(193)))), ((int)(((byte)(193)))));
            this.cpnlPlugins.DisplayText = "Plugins";
            this.cpnlPlugins.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cpnlPlugins.Icon = ((System.Drawing.Image)(resources.GetObject("cpnlPlugins.Icon")));
            this.cpnlPlugins.IsClicked = false;
            this.cpnlPlugins.IsHovering = false;
            this.cpnlPlugins.Location = new System.Drawing.Point(0, 160);
            this.cpnlPlugins.Name = "cpnlPlugins";
            this.cpnlPlugins.Size = new System.Drawing.Size(152, 40);
            this.cpnlPlugins.TabIndex = 3;
            this.cpnlPlugins.TextSize = 11F;
            this.cpnlPlugins.Click += new System.EventHandler(this.cpnlPlugins_Click);
            // 
            // cpnlAutomation
            // 
            this.cpnlAutomation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(79)))), ((int)(((byte)(90)))));
            this.cpnlAutomation.DisplayColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(193)))), ((int)(((byte)(193)))));
            this.cpnlAutomation.DisplayText = "Automation";
            this.cpnlAutomation.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cpnlAutomation.Icon = ((System.Drawing.Image)(resources.GetObject("cpnlAutomation.Icon")));
            this.cpnlAutomation.IsClicked = false;
            this.cpnlAutomation.IsHovering = false;
            this.cpnlAutomation.Location = new System.Drawing.Point(0, 120);
            this.cpnlAutomation.Name = "cpnlAutomation";
            this.cpnlAutomation.Size = new System.Drawing.Size(152, 40);
            this.cpnlAutomation.TabIndex = 2;
            this.cpnlAutomation.TextSize = 11F;
            this.cpnlAutomation.Click += new System.EventHandler(this.cpnlAutomation_Click);
            // 
            // NewMainHandler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(850, 385);
            this.Controls.Add(this.pnlMainArea);
            this.Controls.Add(this.pnlLeftSelection);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "NewMainHandler";
            this.Text = "NewMainHandler";
            this.Load += new System.EventHandler(this.NewMainHandler_Load);
            this.Resize += new System.EventHandler(this.NewMainHandler_Resize);
            this.pnlLeftSelection.ResumeLayout(false);
            this.pnlMainArea.ResumeLayout(false);
            this.pnlMainArea.PerformLayout();
            this.pnlApplication.ResumeLayout(false);
            this.pnlApplication.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Custom_Controls.ClickablePanel cpnlApplication;
        private Custom_Controls.ClickablePanel cpnlOverlays;
        private Custom_Controls.ClickablePanel cpnlAutomation;
        private Custom_Controls.ClickablePanel cpnlPlugins;
        private System.Windows.Forms.Panel pnlLeftSelection;
        private System.Windows.Forms.Panel pnlMainArea;
        private System.Windows.Forms.Panel pnlApplication;
        private System.Windows.Forms.Label lblTabname;
        private NumberTextBox ntxtGraphicsRefresh;
        private NumberTextBox ntxtMemoryRefresh;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private KeyTextBox ktxtReposition;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnReposition;
        private AnotherCheckbox chBxOnlyDrawInForeground;

    }
}