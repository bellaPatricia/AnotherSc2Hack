namespace AnotherSc2Hack.Classes.FrontEnds
{
    partial class BasicsMap
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BasicsMap));
            this.gbMaphackBasics = new AnotherSc2Hack.Classes.FrontEnds.LanguageGroupbox();
            this.chBxMaphackRemCamera = new AnotherSc2Hack.Classes.FrontEnds.LanguageCheckbox();
            this.chBxMaphackRemVisionArea = new AnotherSc2Hack.Classes.FrontEnds.LanguageCheckbox();
            this.chBxMaphackColorDefensiveStructuresYellow = new AnotherSc2Hack.Classes.FrontEnds.LanguageCheckbox();
            this.lblOpacity = new System.Windows.Forms.Label();
            this.chBxMaphackDisableDestinationLine = new AnotherSc2Hack.Classes.FrontEnds.LanguageCheckbox();
            this.tbOpacity = new System.Windows.Forms.TrackBar();
            this.lblRemoveAi = new AnotherSc2Hack.Classes.FrontEnds.LanguageLabel();
            this.lblRemoveAllie = new AnotherSc2Hack.Classes.FrontEnds.LanguageLabel();
            this.lblRemoveNeutral = new AnotherSc2Hack.Classes.FrontEnds.LanguageLabel();
            this.btnDestinationLine = new System.Windows.Forms.Button();
            this.lblRemoveLocalplayer = new AnotherSc2Hack.Classes.FrontEnds.LanguageLabel();
            this.lblMaphackDestinationLine = new AnotherSc2Hack.Classes.FrontEnds.LanguageLabel();
            this.cmBxRemAi = new System.Windows.Forms.ComboBox();
            this.cmBxRemAllie = new System.Windows.Forms.ComboBox();
            this.cmBxRemNeutral = new System.Windows.Forms.ComboBox();
            this.cmBxRemLocalplayer = new System.Windows.Forms.ComboBox();
            this.lblOpacityText = new AnotherSc2Hack.Classes.FrontEnds.LanguageLabel();
            this.gbMaphackBasics.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbOpacity)).BeginInit();
            this.SuspendLayout();
            // 
            // gbMaphackBasics
            // 
            resources.ApplyResources(this.gbMaphackBasics, "gbMaphackBasics");
            this.gbMaphackBasics.Controls.Add(this.chBxMaphackRemCamera);
            this.gbMaphackBasics.Controls.Add(this.chBxMaphackRemVisionArea);
            this.gbMaphackBasics.Controls.Add(this.chBxMaphackColorDefensiveStructuresYellow);
            this.gbMaphackBasics.Controls.Add(this.lblOpacity);
            this.gbMaphackBasics.Controls.Add(this.chBxMaphackDisableDestinationLine);
            this.gbMaphackBasics.Controls.Add(this.tbOpacity);
            this.gbMaphackBasics.Controls.Add(this.lblRemoveAi);
            this.gbMaphackBasics.Controls.Add(this.lblRemoveAllie);
            this.gbMaphackBasics.Controls.Add(this.lblRemoveNeutral);
            this.gbMaphackBasics.Controls.Add(this.btnDestinationLine);
            this.gbMaphackBasics.Controls.Add(this.lblRemoveLocalplayer);
            this.gbMaphackBasics.Controls.Add(this.lblMaphackDestinationLine);
            this.gbMaphackBasics.Controls.Add(this.cmBxRemAi);
            this.gbMaphackBasics.Controls.Add(this.cmBxRemAllie);
            this.gbMaphackBasics.Controls.Add(this.cmBxRemNeutral);
            this.gbMaphackBasics.Controls.Add(this.cmBxRemLocalplayer);
            this.gbMaphackBasics.Controls.Add(this.lblOpacityText);
            this.gbMaphackBasics.LanguageFile = "";
            this.gbMaphackBasics.Name = "gbMaphackBasics";
            this.gbMaphackBasics.TabStop = false;
            // 
            // chBxMaphackRemCamera
            // 
            resources.ApplyResources(this.chBxMaphackRemCamera, "chBxMaphackRemCamera");
            this.chBxMaphackRemCamera.LanguageFile = "";
            this.chBxMaphackRemCamera.Name = "chBxMaphackRemCamera";
            this.chBxMaphackRemCamera.UseVisualStyleBackColor = true;
            // 
            // chBxMaphackRemVisionArea
            // 
            resources.ApplyResources(this.chBxMaphackRemVisionArea, "chBxMaphackRemVisionArea");
            this.chBxMaphackRemVisionArea.LanguageFile = "";
            this.chBxMaphackRemVisionArea.Name = "chBxMaphackRemVisionArea";
            this.chBxMaphackRemVisionArea.UseVisualStyleBackColor = true;
            // 
            // chBxMaphackColorDefensiveStructuresYellow
            // 
            resources.ApplyResources(this.chBxMaphackColorDefensiveStructuresYellow, "chBxMaphackColorDefensiveStructuresYellow");
            this.chBxMaphackColorDefensiveStructuresYellow.LanguageFile = "";
            this.chBxMaphackColorDefensiveStructuresYellow.Name = "chBxMaphackColorDefensiveStructuresYellow";
            this.chBxMaphackColorDefensiveStructuresYellow.UseVisualStyleBackColor = true;
            // 
            // lblOpacity
            // 
            resources.ApplyResources(this.lblOpacity, "lblOpacity");
            this.lblOpacity.Name = "lblOpacity";
            // 
            // chBxMaphackDisableDestinationLine
            // 
            resources.ApplyResources(this.chBxMaphackDisableDestinationLine, "chBxMaphackDisableDestinationLine");
            this.chBxMaphackDisableDestinationLine.LanguageFile = "";
            this.chBxMaphackDisableDestinationLine.Name = "chBxMaphackDisableDestinationLine";
            this.chBxMaphackDisableDestinationLine.UseVisualStyleBackColor = true;
            // 
            // tbOpacity
            // 
            resources.ApplyResources(this.tbOpacity, "tbOpacity");
            this.tbOpacity.Maximum = 100;
            this.tbOpacity.Name = "tbOpacity";
            // 
            // lblRemoveAi
            // 
            resources.ApplyResources(this.lblRemoveAi, "lblRemoveAi");
            this.lblRemoveAi.LanguageFile = "";
            this.lblRemoveAi.Name = "lblRemoveAi";
            // 
            // lblRemoveAllie
            // 
            resources.ApplyResources(this.lblRemoveAllie, "lblRemoveAllie");
            this.lblRemoveAllie.LanguageFile = "";
            this.lblRemoveAllie.Name = "lblRemoveAllie";
            // 
            // lblRemoveNeutral
            // 
            resources.ApplyResources(this.lblRemoveNeutral, "lblRemoveNeutral");
            this.lblRemoveNeutral.LanguageFile = "";
            this.lblRemoveNeutral.Name = "lblRemoveNeutral";
            // 
            // btnDestinationLine
            // 
            resources.ApplyResources(this.btnDestinationLine, "btnDestinationLine");
            this.btnDestinationLine.Name = "btnDestinationLine";
            this.btnDestinationLine.UseVisualStyleBackColor = true;
            // 
            // lblRemoveLocalplayer
            // 
            resources.ApplyResources(this.lblRemoveLocalplayer, "lblRemoveLocalplayer");
            this.lblRemoveLocalplayer.LanguageFile = "";
            this.lblRemoveLocalplayer.Name = "lblRemoveLocalplayer";
            // 
            // lblMaphackDestinationLine
            // 
            resources.ApplyResources(this.lblMaphackDestinationLine, "lblMaphackDestinationLine");
            this.lblMaphackDestinationLine.LanguageFile = "";
            this.lblMaphackDestinationLine.Name = "lblMaphackDestinationLine";
            // 
            // cmBxRemAi
            // 
            resources.ApplyResources(this.cmBxRemAi, "cmBxRemAi");
            this.cmBxRemAi.FormattingEnabled = true;
            this.cmBxRemAi.Items.AddRange(new object[] {
            resources.GetString("cmBxRemAi.Items"),
            resources.GetString("cmBxRemAi.Items1")});
            this.cmBxRemAi.Name = "cmBxRemAi";
            // 
            // cmBxRemAllie
            // 
            resources.ApplyResources(this.cmBxRemAllie, "cmBxRemAllie");
            this.cmBxRemAllie.FormattingEnabled = true;
            this.cmBxRemAllie.Items.AddRange(new object[] {
            resources.GetString("cmBxRemAllie.Items"),
            resources.GetString("cmBxRemAllie.Items1")});
            this.cmBxRemAllie.Name = "cmBxRemAllie";
            // 
            // cmBxRemNeutral
            // 
            resources.ApplyResources(this.cmBxRemNeutral, "cmBxRemNeutral");
            this.cmBxRemNeutral.FormattingEnabled = true;
            this.cmBxRemNeutral.Items.AddRange(new object[] {
            resources.GetString("cmBxRemNeutral.Items"),
            resources.GetString("cmBxRemNeutral.Items1")});
            this.cmBxRemNeutral.Name = "cmBxRemNeutral";
            // 
            // cmBxRemLocalplayer
            // 
            resources.ApplyResources(this.cmBxRemLocalplayer, "cmBxRemLocalplayer");
            this.cmBxRemLocalplayer.FormattingEnabled = true;
            this.cmBxRemLocalplayer.Items.AddRange(new object[] {
            resources.GetString("cmBxRemLocalplayer.Items"),
            resources.GetString("cmBxRemLocalplayer.Items1")});
            this.cmBxRemLocalplayer.Name = "cmBxRemLocalplayer";
            // 
            // lblOpacityText
            // 
            resources.ApplyResources(this.lblOpacityText, "lblOpacityText");
            this.lblOpacityText.LanguageFile = "";
            this.lblOpacityText.Name = "lblOpacityText";
            // 
            // BasicsMap
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbMaphackBasics);
            this.Name = "BasicsMap";
            this.gbMaphackBasics.ResumeLayout(false);
            this.gbMaphackBasics.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbOpacity)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private LanguageGroupbox gbMaphackBasics;
        private LanguageLabel lblRemoveAi;
        private LanguageLabel lblRemoveAllie;
        private LanguageLabel lblRemoveNeutral;
        private LanguageLabel lblRemoveLocalplayer;
        private LanguageLabel lblMaphackDestinationLine;
        private LanguageLabel lblOpacityText;
        public LanguageCheckbox chBxMaphackRemCamera;
        public LanguageCheckbox chBxMaphackRemVisionArea;
        public LanguageCheckbox chBxMaphackColorDefensiveStructuresYellow;
        public LanguageCheckbox chBxMaphackDisableDestinationLine;
        public System.Windows.Forms.TrackBar tbOpacity;
        public System.Windows.Forms.Button btnDestinationLine;
        public System.Windows.Forms.ComboBox cmBxRemAi;
        public System.Windows.Forms.ComboBox cmBxRemAllie;
        public System.Windows.Forms.ComboBox cmBxRemNeutral;
        public System.Windows.Forms.ComboBox cmBxRemLocalplayer;
        public System.Windows.Forms.Label lblOpacity;
    }
}
