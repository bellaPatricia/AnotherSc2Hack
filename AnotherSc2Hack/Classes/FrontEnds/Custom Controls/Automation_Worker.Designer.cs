namespace AnotherSc2Hack.Classes.FrontEnds
{
    partial class AutomationWorker
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AutomationWorker));
            this.gbAutoWorker = new AnotherSc2Hack.Classes.FrontEnds.LanguageGroupbox();
            this.ntxtBuildNextWorkerAt = new AnotherSc2Hack.Classes.FrontEnds.NumberTextBox();
            this.lblAutoWorkerNextWorkerPercentage = new AnotherSc2Hack.Classes.FrontEnds.LanguageLabel();
            this.ktxtBackupGroupKey = new AnotherSc2Hack.Classes.FrontEnds.KeyTextBox();
            this.lblAutoWorkerBackupGroup = new AnotherSc2Hack.Classes.FrontEnds.LanguageLabel();
            this.ktxtMainbuildingGroupKey = new AnotherSc2Hack.Classes.FrontEnds.KeyTextBox();
            this.lblAutoWorkerKeyMainGroup = new AnotherSc2Hack.Classes.FrontEnds.LanguageLabel();
            this.ktxtOrbitalUpgradeKey = new AnotherSc2Hack.Classes.FrontEnds.KeyTextBox();
            this.lblAutoWorkerKeyOrbital = new AnotherSc2Hack.Classes.FrontEnds.LanguageLabel();
            this.ntxtDisableWhenApmIsOver = new AnotherSc2Hack.Classes.FrontEnds.NumberTextBox();
            this.ktxtProbeBuildingKey = new AnotherSc2Hack.Classes.FrontEnds.KeyTextBox();
            this.ktxtScvBuildingKey = new AnotherSc2Hack.Classes.FrontEnds.KeyTextBox();
            this.chBxAutoUpgradeToOc = new AnotherSc2Hack.Classes.FrontEnds.LanguageCheckbox();
            this.lblAutoWorkerKeyProbe = new AnotherSc2Hack.Classes.FrontEnds.LanguageLabel();
            this.lblAutoWorkerKeyScv = new AnotherSc2Hack.Classes.FrontEnds.LanguageLabel();
            this.chBxDisableWhenWorkerIsSelected = new AnotherSc2Hack.Classes.FrontEnds.LanguageCheckbox();
            this.chBxDisableWhenSelecting = new AnotherSc2Hack.Classes.FrontEnds.LanguageCheckbox();
            this.lblAutoWorkerApmOver = new AnotherSc2Hack.Classes.FrontEnds.LanguageLabel();
            this.rdbRoundWorkerProduction = new AnotherSc2Hack.Classes.FrontEnds.LanguageRadiobutton();
            this.rdbDirectWorkerProduction = new AnotherSc2Hack.Classes.FrontEnds.LanguageRadiobutton();
            this.ntxtMaynardWorkerCount = new AnotherSc2Hack.Classes.FrontEnds.NumberTextBox();
            this.ntxtMaximumWorkersPerBase = new AnotherSc2Hack.Classes.FrontEnds.NumberTextBox();
            this.ntxtMaximumWorkersInGame = new AnotherSc2Hack.Classes.FrontEnds.NumberTextBox();
            this.chBxAutomationEnableWorkerProduction = new AnotherSc2Hack.Classes.FrontEnds.LanguageCheckbox();
            this.lblAutoWorkerMaxWorkers = new AnotherSc2Hack.Classes.FrontEnds.LanguageLabel();
            this.lblAutoWorkerMaynardingPuffer = new AnotherSc2Hack.Classes.FrontEnds.LanguageLabel();
            this.lblAutoWorkerMaxWorkersPewBase = new AnotherSc2Hack.Classes.FrontEnds.LanguageLabel();
            this.gbAutoWorker.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbAutoWorker
            // 
            resources.ApplyResources(this.gbAutoWorker, "gbAutoWorker");
            this.gbAutoWorker.Controls.Add(this.ntxtBuildNextWorkerAt);
            this.gbAutoWorker.Controls.Add(this.lblAutoWorkerNextWorkerPercentage);
            this.gbAutoWorker.Controls.Add(this.ktxtBackupGroupKey);
            this.gbAutoWorker.Controls.Add(this.lblAutoWorkerBackupGroup);
            this.gbAutoWorker.Controls.Add(this.ktxtMainbuildingGroupKey);
            this.gbAutoWorker.Controls.Add(this.lblAutoWorkerKeyMainGroup);
            this.gbAutoWorker.Controls.Add(this.ktxtOrbitalUpgradeKey);
            this.gbAutoWorker.Controls.Add(this.lblAutoWorkerKeyOrbital);
            this.gbAutoWorker.Controls.Add(this.ntxtDisableWhenApmIsOver);
            this.gbAutoWorker.Controls.Add(this.ktxtProbeBuildingKey);
            this.gbAutoWorker.Controls.Add(this.ktxtScvBuildingKey);
            this.gbAutoWorker.Controls.Add(this.chBxAutoUpgradeToOc);
            this.gbAutoWorker.Controls.Add(this.lblAutoWorkerKeyProbe);
            this.gbAutoWorker.Controls.Add(this.lblAutoWorkerKeyScv);
            this.gbAutoWorker.Controls.Add(this.chBxDisableWhenWorkerIsSelected);
            this.gbAutoWorker.Controls.Add(this.chBxDisableWhenSelecting);
            this.gbAutoWorker.Controls.Add(this.lblAutoWorkerApmOver);
            this.gbAutoWorker.Controls.Add(this.rdbRoundWorkerProduction);
            this.gbAutoWorker.Controls.Add(this.rdbDirectWorkerProduction);
            this.gbAutoWorker.Controls.Add(this.ntxtMaynardWorkerCount);
            this.gbAutoWorker.Controls.Add(this.ntxtMaximumWorkersPerBase);
            this.gbAutoWorker.Controls.Add(this.ntxtMaximumWorkersInGame);
            this.gbAutoWorker.Controls.Add(this.chBxAutomationEnableWorkerProduction);
            this.gbAutoWorker.Controls.Add(this.lblAutoWorkerMaxWorkers);
            this.gbAutoWorker.Controls.Add(this.lblAutoWorkerMaynardingPuffer);
            this.gbAutoWorker.Controls.Add(this.lblAutoWorkerMaxWorkersPewBase);
            this.gbAutoWorker.LanguageFile = "";
            this.gbAutoWorker.Name = "gbAutoWorker";
            this.gbAutoWorker.TabStop = false;
            // 
            // ntxtBuildNextWorkerAt
            // 
            resources.ApplyResources(this.ntxtBuildNextWorkerAt, "ntxtBuildNextWorkerAt");
            this.ntxtBuildNextWorkerAt.Name = "ntxtBuildNextWorkerAt";
            this.ntxtBuildNextWorkerAt.Number = 0;
            // 
            // lblAutoWorkerNextWorkerPercentage
            // 
            resources.ApplyResources(this.lblAutoWorkerNextWorkerPercentage, "lblAutoWorkerNextWorkerPercentage");
            this.lblAutoWorkerNextWorkerPercentage.LanguageFile = "";
            this.lblAutoWorkerNextWorkerPercentage.Name = "lblAutoWorkerNextWorkerPercentage";
            // 
            // ktxtBackupGroupKey
            // 
            resources.ApplyResources(this.ktxtBackupGroupKey, "ktxtBackupGroupKey");
            this.ktxtBackupGroupKey.HotKeyValue = System.Windows.Forms.Keys.None;
            this.ktxtBackupGroupKey.Name = "ktxtBackupGroupKey";
            // 
            // lblAutoWorkerBackupGroup
            // 
            resources.ApplyResources(this.lblAutoWorkerBackupGroup, "lblAutoWorkerBackupGroup");
            this.lblAutoWorkerBackupGroup.LanguageFile = "";
            this.lblAutoWorkerBackupGroup.Name = "lblAutoWorkerBackupGroup";
            // 
            // ktxtMainbuildingGroupKey
            // 
            resources.ApplyResources(this.ktxtMainbuildingGroupKey, "ktxtMainbuildingGroupKey");
            this.ktxtMainbuildingGroupKey.HotKeyValue = System.Windows.Forms.Keys.None;
            this.ktxtMainbuildingGroupKey.Name = "ktxtMainbuildingGroupKey";
            // 
            // lblAutoWorkerKeyMainGroup
            // 
            resources.ApplyResources(this.lblAutoWorkerKeyMainGroup, "lblAutoWorkerKeyMainGroup");
            this.lblAutoWorkerKeyMainGroup.LanguageFile = "";
            this.lblAutoWorkerKeyMainGroup.Name = "lblAutoWorkerKeyMainGroup";
            // 
            // ktxtOrbitalUpgradeKey
            // 
            resources.ApplyResources(this.ktxtOrbitalUpgradeKey, "ktxtOrbitalUpgradeKey");
            this.ktxtOrbitalUpgradeKey.HotKeyValue = System.Windows.Forms.Keys.None;
            this.ktxtOrbitalUpgradeKey.Name = "ktxtOrbitalUpgradeKey";
            // 
            // lblAutoWorkerKeyOrbital
            // 
            resources.ApplyResources(this.lblAutoWorkerKeyOrbital, "lblAutoWorkerKeyOrbital");
            this.lblAutoWorkerKeyOrbital.LanguageFile = "";
            this.lblAutoWorkerKeyOrbital.Name = "lblAutoWorkerKeyOrbital";
            // 
            // ntxtDisableWhenApmIsOver
            // 
            resources.ApplyResources(this.ntxtDisableWhenApmIsOver, "ntxtDisableWhenApmIsOver");
            this.ntxtDisableWhenApmIsOver.Name = "ntxtDisableWhenApmIsOver";
            this.ntxtDisableWhenApmIsOver.Number = 0;
            // 
            // ktxtProbeBuildingKey
            // 
            resources.ApplyResources(this.ktxtProbeBuildingKey, "ktxtProbeBuildingKey");
            this.ktxtProbeBuildingKey.HotKeyValue = System.Windows.Forms.Keys.None;
            this.ktxtProbeBuildingKey.Name = "ktxtProbeBuildingKey";
            // 
            // ktxtScvBuildingKey
            // 
            resources.ApplyResources(this.ktxtScvBuildingKey, "ktxtScvBuildingKey");
            this.ktxtScvBuildingKey.HotKeyValue = System.Windows.Forms.Keys.None;
            this.ktxtScvBuildingKey.Name = "ktxtScvBuildingKey";
            // 
            // chBxAutoUpgradeToOc
            // 
            resources.ApplyResources(this.chBxAutoUpgradeToOc, "chBxAutoUpgradeToOc");
            this.chBxAutoUpgradeToOc.LanguageFile = "";
            this.chBxAutoUpgradeToOc.Name = "chBxAutoUpgradeToOc";
            this.chBxAutoUpgradeToOc.UseVisualStyleBackColor = true;
            // 
            // lblAutoWorkerKeyProbe
            // 
            resources.ApplyResources(this.lblAutoWorkerKeyProbe, "lblAutoWorkerKeyProbe");
            this.lblAutoWorkerKeyProbe.LanguageFile = "";
            this.lblAutoWorkerKeyProbe.Name = "lblAutoWorkerKeyProbe";
            // 
            // lblAutoWorkerKeyScv
            // 
            resources.ApplyResources(this.lblAutoWorkerKeyScv, "lblAutoWorkerKeyScv");
            this.lblAutoWorkerKeyScv.LanguageFile = "";
            this.lblAutoWorkerKeyScv.Name = "lblAutoWorkerKeyScv";
            // 
            // chBxDisableWhenWorkerIsSelected
            // 
            resources.ApplyResources(this.chBxDisableWhenWorkerIsSelected, "chBxDisableWhenWorkerIsSelected");
            this.chBxDisableWhenWorkerIsSelected.LanguageFile = "";
            this.chBxDisableWhenWorkerIsSelected.Name = "chBxDisableWhenWorkerIsSelected";
            this.chBxDisableWhenWorkerIsSelected.UseVisualStyleBackColor = true;
            // 
            // chBxDisableWhenSelecting
            // 
            resources.ApplyResources(this.chBxDisableWhenSelecting, "chBxDisableWhenSelecting");
            this.chBxDisableWhenSelecting.LanguageFile = "";
            this.chBxDisableWhenSelecting.Name = "chBxDisableWhenSelecting";
            this.chBxDisableWhenSelecting.UseVisualStyleBackColor = true;
            // 
            // lblAutoWorkerApmOver
            // 
            resources.ApplyResources(this.lblAutoWorkerApmOver, "lblAutoWorkerApmOver");
            this.lblAutoWorkerApmOver.LanguageFile = "";
            this.lblAutoWorkerApmOver.Name = "lblAutoWorkerApmOver";
            // 
            // rdbRoundWorkerProduction
            // 
            resources.ApplyResources(this.rdbRoundWorkerProduction, "rdbRoundWorkerProduction");
            this.rdbRoundWorkerProduction.LanguageFile = "";
            this.rdbRoundWorkerProduction.Name = "rdbRoundWorkerProduction";
            this.rdbRoundWorkerProduction.TabStop = true;
            this.rdbRoundWorkerProduction.UseVisualStyleBackColor = true;
            // 
            // rdbDirectWorkerProduction
            // 
            resources.ApplyResources(this.rdbDirectWorkerProduction, "rdbDirectWorkerProduction");
            this.rdbDirectWorkerProduction.LanguageFile = "";
            this.rdbDirectWorkerProduction.Name = "rdbDirectWorkerProduction";
            this.rdbDirectWorkerProduction.TabStop = true;
            this.rdbDirectWorkerProduction.UseVisualStyleBackColor = true;
            // 
            // ntxtMaynardWorkerCount
            // 
            resources.ApplyResources(this.ntxtMaynardWorkerCount, "ntxtMaynardWorkerCount");
            this.ntxtMaynardWorkerCount.Name = "ntxtMaynardWorkerCount";
            this.ntxtMaynardWorkerCount.Number = 0;
            // 
            // ntxtMaximumWorkersPerBase
            // 
            resources.ApplyResources(this.ntxtMaximumWorkersPerBase, "ntxtMaximumWorkersPerBase");
            this.ntxtMaximumWorkersPerBase.Name = "ntxtMaximumWorkersPerBase";
            this.ntxtMaximumWorkersPerBase.Number = 0;
            // 
            // ntxtMaximumWorkersInGame
            // 
            resources.ApplyResources(this.ntxtMaximumWorkersInGame, "ntxtMaximumWorkersInGame");
            this.ntxtMaximumWorkersInGame.Name = "ntxtMaximumWorkersInGame";
            this.ntxtMaximumWorkersInGame.Number = 0;
            // 
            // chBxAutomationEnableWorkerProduction
            // 
            resources.ApplyResources(this.chBxAutomationEnableWorkerProduction, "chBxAutomationEnableWorkerProduction");
            this.chBxAutomationEnableWorkerProduction.LanguageFile = "";
            this.chBxAutomationEnableWorkerProduction.Name = "chBxAutomationEnableWorkerProduction";
            this.chBxAutomationEnableWorkerProduction.UseVisualStyleBackColor = true;
            // 
            // lblAutoWorkerMaxWorkers
            // 
            resources.ApplyResources(this.lblAutoWorkerMaxWorkers, "lblAutoWorkerMaxWorkers");
            this.lblAutoWorkerMaxWorkers.LanguageFile = "";
            this.lblAutoWorkerMaxWorkers.Name = "lblAutoWorkerMaxWorkers";
            // 
            // lblAutoWorkerMaynardingPuffer
            // 
            resources.ApplyResources(this.lblAutoWorkerMaynardingPuffer, "lblAutoWorkerMaynardingPuffer");
            this.lblAutoWorkerMaynardingPuffer.LanguageFile = "";
            this.lblAutoWorkerMaynardingPuffer.Name = "lblAutoWorkerMaynardingPuffer";
            // 
            // lblAutoWorkerMaxWorkersPewBase
            // 
            resources.ApplyResources(this.lblAutoWorkerMaxWorkersPewBase, "lblAutoWorkerMaxWorkersPewBase");
            this.lblAutoWorkerMaxWorkersPewBase.LanguageFile = "";
            this.lblAutoWorkerMaxWorkersPewBase.Name = "lblAutoWorkerMaxWorkersPewBase";
            // 
            // AutomationWorker
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbAutoWorker);
            this.Name = "AutomationWorker";
            this.gbAutoWorker.ResumeLayout(false);
            this.gbAutoWorker.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private LanguageGroupbox gbAutoWorker;
        public LanguageCheckbox chBxAutomationEnableWorkerProduction;
        public LanguageLabel lblAutoWorkerMaxWorkers;
        public LanguageLabel lblAutoWorkerMaynardingPuffer;
        public LanguageLabel lblAutoWorkerMaxWorkersPewBase;
        public NumberTextBox ntxtMaximumWorkersInGame;
        public NumberTextBox ntxtMaynardWorkerCount;
        public NumberTextBox ntxtMaximumWorkersPerBase;
        public LanguageLabel lblAutoWorkerApmOver;
        public LanguageLabel lblAutoWorkerKeyProbe;
        public LanguageLabel lblAutoWorkerKeyScv;
        public NumberTextBox ntxtDisableWhenApmIsOver;
        public LanguageRadiobutton rdbRoundWorkerProduction;
        public LanguageRadiobutton rdbDirectWorkerProduction;
        public LanguageCheckbox chBxDisableWhenWorkerIsSelected;
        public LanguageCheckbox chBxDisableWhenSelecting;
        public LanguageCheckbox chBxAutoUpgradeToOc;
        public KeyTextBox ktxtProbeBuildingKey;
        public KeyTextBox ktxtScvBuildingKey;
        public KeyTextBox ktxtOrbitalUpgradeKey;
        public LanguageLabel lblAutoWorkerKeyOrbital;
        public KeyTextBox ktxtBackupGroupKey;
        public LanguageLabel lblAutoWorkerBackupGroup;
        public KeyTextBox ktxtMainbuildingGroupKey;
        public LanguageLabel lblAutoWorkerKeyMainGroup;
        public NumberTextBox ntxtBuildNextWorkerAt;
        public LanguageLabel lblAutoWorkerNextWorkerPercentage;
    }
}
