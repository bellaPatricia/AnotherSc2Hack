namespace AnotherSc2Hack.Classes.FrontEnds.Customize
{
    partial class Customizer
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
            this.lwPlayerData = new System.Windows.Forms.ListView();
            this.chName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // lwPlayerData
            // 
            this.lwPlayerData.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chName,
            this.chType});
            this.lwPlayerData.Location = new System.Drawing.Point(12, 12);
            this.lwPlayerData.Name = "lwPlayerData";
            this.lwPlayerData.Size = new System.Drawing.Size(402, 129);
            this.lwPlayerData.TabIndex = 0;
            this.lwPlayerData.UseCompatibleStateImageBehavior = false;
            this.lwPlayerData.View = System.Windows.Forms.View.Details;
            // 
            // chName
            // 
            this.chName.Text = "Name";
            this.chName.Width = 128;
            // 
            // chType
            // 
            this.chType.Text = "Type";
            this.chType.Width = 92;
            // 
            // Customizer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1244, 252);
            this.Controls.Add(this.lwPlayerData);
            this.Name = "Customizer";
            this.Text = "Customizer";
            this.Load += new System.EventHandler(this.Customizer_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lwPlayerData;
        private System.Windows.Forms.ColumnHeader chName;
        private System.Windows.Forms.ColumnHeader chType;
    }
}