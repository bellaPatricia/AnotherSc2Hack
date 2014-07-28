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
            this.gbAutoWorker.Location = new System.Drawing.Point(0, 0);
            this.gbAutoWorker.Name = "gbAutoWorker";
            this.gbAutoWorker.Size = new System.Drawing.Size(514, 266);
            this.gbAutoWorker.TabIndex = 1;
            this.gbAutoWorker.TabStop = false;
            this.gbAutoWorker.Text = "Worker Production";
            // 
            // ntxtBuildNextWorkerAt
            // 
            this.ntxtBuildNextWorkerAt.Location = new System.Drawing.Point(444, 238);
            this.ntxtBuildNextWorkerAt.Name = "ntxtBuildNextWorkerAt";
            this.ntxtBuildNextWorkerAt.Number = 0;
            this.ntxtBuildNextWorkerAt.Size = new System.Drawing.Size(52, 20);
            this.ntxtBuildNextWorkerAt.TabIndex = 27;
            // 
            // lblAutoWorkerNextWorkerPercentage
            // 
            this.lblAutoWorkerNextWorkerPercentage.AutoSize = true;
            this.lblAutoWorkerNextWorkerPercentage.LanguageFile = "";
            this.lblAutoWorkerNextWorkerPercentage.Location = new System.Drawing.Point(278, 241);
            this.lblAutoWorkerNextWorkerPercentage.Name = "lblAutoWorkerNextWorkerPercentage";
            this.lblAutoWorkerNextWorkerPercentage.Size = new System.Drawing.Size(162, 13);
            this.lblAutoWorkerNextWorkerPercentage.TabIndex = 26;
            this.lblAutoWorkerNextWorkerPercentage.Text = "Next worker at (%) of first worker:";
            // 
            // ktxtBackupGroupKey
            // 
            this.ktxtBackupGroupKey.HotKeyValue = System.Windows.Forms.Keys.None;
            this.ktxtBackupGroupKey.Location = new System.Drawing.Point(444, 207);
            this.ktxtBackupGroupKey.Name = "ktxtBackupGroupKey";
            this.ktxtBackupGroupKey.Size = new System.Drawing.Size(52, 20);
            this.ktxtBackupGroupKey.TabIndex = 25;
            // 
            // lblAutoWorkerBackupGroup
            // 
            this.lblAutoWorkerBackupGroup.AutoSize = true;
            this.lblAutoWorkerBackupGroup.LanguageFile = "";
            this.lblAutoWorkerBackupGroup.Location = new System.Drawing.Point(278, 210);
            this.lblAutoWorkerBackupGroup.Name = "lblAutoWorkerBackupGroup";
            this.lblAutoWorkerBackupGroup.Size = new System.Drawing.Size(121, 13);
            this.lblAutoWorkerBackupGroup.TabIndex = 24;
            this.lblAutoWorkerBackupGroup.Text = "Key For Backup- Group:";
            // 
            // ktxtMainbuildingGroupKey
            // 
            this.ktxtMainbuildingGroupKey.HotKeyValue = System.Windows.Forms.Keys.None;
            this.ktxtMainbuildingGroupKey.Location = new System.Drawing.Point(444, 177);
            this.ktxtMainbuildingGroupKey.Name = "ktxtMainbuildingGroupKey";
            this.ktxtMainbuildingGroupKey.Size = new System.Drawing.Size(52, 20);
            this.ktxtMainbuildingGroupKey.TabIndex = 23;
            // 
            // lblAutoWorkerKeyMainGroup
            // 
            this.lblAutoWorkerKeyMainGroup.AutoSize = true;
            this.lblAutoWorkerKeyMainGroup.LanguageFile = "";
            this.lblAutoWorkerKeyMainGroup.Location = new System.Drawing.Point(278, 180);
            this.lblAutoWorkerKeyMainGroup.Name = "lblAutoWorkerKeyMainGroup";
            this.lblAutoWorkerKeyMainGroup.Size = new System.Drawing.Size(133, 13);
            this.lblAutoWorkerKeyMainGroup.TabIndex = 22;
            this.lblAutoWorkerKeyMainGroup.Text = "Key For Nexus/ CC Group:";
            // 
            // ktxtOrbitalUpgradeKey
            // 
            this.ktxtOrbitalUpgradeKey.HotKeyValue = System.Windows.Forms.Keys.None;
            this.ktxtOrbitalUpgradeKey.Location = new System.Drawing.Point(444, 147);
            this.ktxtOrbitalUpgradeKey.Name = "ktxtOrbitalUpgradeKey";
            this.ktxtOrbitalUpgradeKey.Size = new System.Drawing.Size(52, 20);
            this.ktxtOrbitalUpgradeKey.TabIndex = 21;
            // 
            // lblAutoWorkerKeyOrbital
            // 
            this.lblAutoWorkerKeyOrbital.AutoSize = true;
            this.lblAutoWorkerKeyOrbital.LanguageFile = "";
            this.lblAutoWorkerKeyOrbital.Location = new System.Drawing.Point(278, 150);
            this.lblAutoWorkerKeyOrbital.Name = "lblAutoWorkerKeyOrbital";
            this.lblAutoWorkerKeyOrbital.Size = new System.Drawing.Size(79, 13);
            this.lblAutoWorkerKeyOrbital.TabIndex = 20;
            this.lblAutoWorkerKeyOrbital.Text = "Key For Orbital:";
            // 
            // ntxtDisableWhenApmIsOver
            // 
            this.ntxtDisableWhenApmIsOver.Location = new System.Drawing.Point(191, 207);
            this.ntxtDisableWhenApmIsOver.Name = "ntxtDisableWhenApmIsOver";
            this.ntxtDisableWhenApmIsOver.Number = 0;
            this.ntxtDisableWhenApmIsOver.Size = new System.Drawing.Size(52, 20);
            this.ntxtDisableWhenApmIsOver.TabIndex = 19;
            // 
            // ktxtProbeBuildingKey
            // 
            this.ktxtProbeBuildingKey.HotKeyValue = System.Windows.Forms.Keys.None;
            this.ktxtProbeBuildingKey.Location = new System.Drawing.Point(444, 117);
            this.ktxtProbeBuildingKey.Name = "ktxtProbeBuildingKey";
            this.ktxtProbeBuildingKey.Size = new System.Drawing.Size(52, 20);
            this.ktxtProbeBuildingKey.TabIndex = 18;
            // 
            // ktxtScvBuildingKey
            // 
            this.ktxtScvBuildingKey.HotKeyValue = System.Windows.Forms.Keys.None;
            this.ktxtScvBuildingKey.Location = new System.Drawing.Point(444, 87);
            this.ktxtScvBuildingKey.Name = "ktxtScvBuildingKey";
            this.ktxtScvBuildingKey.Size = new System.Drawing.Size(52, 20);
            this.ktxtScvBuildingKey.TabIndex = 17;
            // 
            // chBxAutoUpgradeToOc
            // 
            this.chBxAutoUpgradeToOc.AutoSize = true;
            this.chBxAutoUpgradeToOc.LanguageFile = "";
            this.chBxAutoUpgradeToOc.Location = new System.Drawing.Point(278, 60);
            this.chBxAutoUpgradeToOc.Name = "chBxAutoUpgradeToOc";
            this.chBxAutoUpgradeToOc.Size = new System.Drawing.Size(192, 17);
            this.chBxAutoUpgradeToOc.TabIndex = 16;
            this.chBxAutoUpgradeToOc.Text = "Upgrade CC\'s to OC\'s automatically";
            this.chBxAutoUpgradeToOc.UseVisualStyleBackColor = true;
            // 
            // lblAutoWorkerKeyProbe
            // 
            this.lblAutoWorkerKeyProbe.AutoSize = true;
            this.lblAutoWorkerKeyProbe.LanguageFile = "";
            this.lblAutoWorkerKeyProbe.Location = new System.Drawing.Point(278, 120);
            this.lblAutoWorkerKeyProbe.Name = "lblAutoWorkerKeyProbe";
            this.lblAutoWorkerKeyProbe.Size = new System.Drawing.Size(77, 13);
            this.lblAutoWorkerKeyProbe.TabIndex = 15;
            this.lblAutoWorkerKeyProbe.Text = "Key For Probe:";
            // 
            // lblAutoWorkerKeyScv
            // 
            this.lblAutoWorkerKeyScv.AutoSize = true;
            this.lblAutoWorkerKeyScv.LanguageFile = "";
            this.lblAutoWorkerKeyScv.Location = new System.Drawing.Point(278, 90);
            this.lblAutoWorkerKeyScv.Name = "lblAutoWorkerKeyScv";
            this.lblAutoWorkerKeyScv.Size = new System.Drawing.Size(70, 13);
            this.lblAutoWorkerKeyScv.TabIndex = 14;
            this.lblAutoWorkerKeyScv.Text = "Key For SCV:";
            // 
            // chBxDisableWhenWorkerIsSelected
            // 
            this.chBxDisableWhenWorkerIsSelected.AutoSize = true;
            this.chBxDisableWhenWorkerIsSelected.LanguageFile = "";
            this.chBxDisableWhenWorkerIsSelected.Location = new System.Drawing.Point(278, 30);
            this.chBxDisableWhenWorkerIsSelected.Name = "chBxDisableWhenWorkerIsSelected";
            this.chBxDisableWhenWorkerIsSelected.Size = new System.Drawing.Size(183, 17);
            this.chBxDisableWhenWorkerIsSelected.TabIndex = 13;
            this.chBxDisableWhenWorkerIsSelected.Text = "Disable when Worker is Selected";
            this.chBxDisableWhenWorkerIsSelected.UseVisualStyleBackColor = true;
            // 
            // chBxDisableWhenSelecting
            // 
            this.chBxDisableWhenSelecting.AutoSize = true;
            this.chBxDisableWhenSelecting.LanguageFile = "";
            this.chBxDisableWhenSelecting.Location = new System.Drawing.Point(25, 240);
            this.chBxDisableWhenSelecting.Name = "chBxDisableWhenSelecting";
            this.chBxDisableWhenSelecting.Size = new System.Drawing.Size(137, 17);
            this.chBxDisableWhenSelecting.TabIndex = 12;
            this.chBxDisableWhenSelecting.Text = "Disable when Selecting";
            this.chBxDisableWhenSelecting.UseVisualStyleBackColor = true;
            // 
            // lblAutoWorkerApmOver
            // 
            this.lblAutoWorkerApmOver.AutoSize = true;
            this.lblAutoWorkerApmOver.LanguageFile = "";
            this.lblAutoWorkerApmOver.Location = new System.Drawing.Point(25, 210);
            this.lblAutoWorkerApmOver.Name = "lblAutoWorkerApmOver";
            this.lblAutoWorkerApmOver.Size = new System.Drawing.Size(134, 13);
            this.lblAutoWorkerApmOver.TabIndex = 11;
            this.lblAutoWorkerApmOver.Text = "Disable when APM is over:";
            // 
            // rdbRoundWorkerProduction
            // 
            this.rdbRoundWorkerProduction.AutoSize = true;
            this.rdbRoundWorkerProduction.LanguageFile = "";
            this.rdbRoundWorkerProduction.Location = new System.Drawing.Point(25, 180);
            this.rdbRoundWorkerProduction.Name = "rdbRoundWorkerProduction";
            this.rdbRoundWorkerProduction.Size = new System.Drawing.Size(182, 17);
            this.rdbRoundWorkerProduction.TabIndex = 10;
            this.rdbRoundWorkerProduction.TabStop = true;
            this.rdbRoundWorkerProduction.Text = "Round Based Worker Production";
            this.rdbRoundWorkerProduction.UseVisualStyleBackColor = true;
            // 
            // rdbDirectWorkerProduction
            // 
            this.rdbDirectWorkerProduction.AutoSize = true;
            this.rdbDirectWorkerProduction.LanguageFile = "";
            this.rdbDirectWorkerProduction.Location = new System.Drawing.Point(25, 150);
            this.rdbDirectWorkerProduction.Name = "rdbDirectWorkerProduction";
            this.rdbDirectWorkerProduction.Size = new System.Drawing.Size(145, 17);
            this.rdbDirectWorkerProduction.TabIndex = 9;
            this.rdbDirectWorkerProduction.TabStop = true;
            this.rdbDirectWorkerProduction.Text = "Direct Worker Production";
            this.rdbDirectWorkerProduction.UseVisualStyleBackColor = true;
            // 
            // ntxtMaynardWorkerCount
            // 
            this.ntxtMaynardWorkerCount.Location = new System.Drawing.Point(191, 117);
            this.ntxtMaynardWorkerCount.Name = "ntxtMaynardWorkerCount";
            this.ntxtMaynardWorkerCount.Number = 0;
            this.ntxtMaynardWorkerCount.Size = new System.Drawing.Size(52, 20);
            this.ntxtMaynardWorkerCount.TabIndex = 8;
            // 
            // ntxtMaximumWorkersPerBase
            // 
            this.ntxtMaximumWorkersPerBase.Location = new System.Drawing.Point(191, 87);
            this.ntxtMaximumWorkersPerBase.Name = "ntxtMaximumWorkersPerBase";
            this.ntxtMaximumWorkersPerBase.Number = 0;
            this.ntxtMaximumWorkersPerBase.Size = new System.Drawing.Size(52, 20);
            this.ntxtMaximumWorkersPerBase.TabIndex = 7;
            // 
            // ntxtMaximumWorkersInGame
            // 
            this.ntxtMaximumWorkersInGame.Location = new System.Drawing.Point(191, 57);
            this.ntxtMaximumWorkersInGame.Name = "ntxtMaximumWorkersInGame";
            this.ntxtMaximumWorkersInGame.Number = 0;
            this.ntxtMaximumWorkersInGame.Size = new System.Drawing.Size(52, 20);
            this.ntxtMaximumWorkersInGame.TabIndex = 5;
            // 
            // chBxAutomationEnableWorkerProduction
            // 
            this.chBxAutomationEnableWorkerProduction.AutoSize = true;
            this.chBxAutomationEnableWorkerProduction.LanguageFile = "";
            this.chBxAutomationEnableWorkerProduction.Location = new System.Drawing.Point(25, 30);
            this.chBxAutomationEnableWorkerProduction.Name = "chBxAutomationEnableWorkerProduction";
            this.chBxAutomationEnableWorkerProduction.Size = new System.Drawing.Size(147, 17);
            this.chBxAutomationEnableWorkerProduction.TabIndex = 4;
            this.chBxAutomationEnableWorkerProduction.Text = "Enable Workerproduction";
            this.chBxAutomationEnableWorkerProduction.UseVisualStyleBackColor = true;
            // 
            // lblAutoWorkerMaxWorkers
            // 
            this.lblAutoWorkerMaxWorkers.AutoSize = true;
            this.lblAutoWorkerMaxWorkers.LanguageFile = "";
            this.lblAutoWorkerMaxWorkers.Location = new System.Drawing.Point(25, 60);
            this.lblAutoWorkerMaxWorkers.Name = "lblAutoWorkerMaxWorkers";
            this.lblAutoWorkerMaxWorkers.Size = new System.Drawing.Size(157, 13);
            this.lblAutoWorkerMaxWorkers.TabIndex = 2;
            this.lblAutoWorkerMaxWorkers.Text = "Maximum Workers in the Game:";
            // 
            // lblAutoWorkerMaynardingPuffer
            // 
            this.lblAutoWorkerMaynardingPuffer.AutoSize = true;
            this.lblAutoWorkerMaynardingPuffer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Strikeout, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAutoWorkerMaynardingPuffer.LanguageFile = "";
            this.lblAutoWorkerMaynardingPuffer.Location = new System.Drawing.Point(25, 120);
            this.lblAutoWorkerMaynardingPuffer.Name = "lblAutoWorkerMaynardingPuffer";
            this.lblAutoWorkerMaynardingPuffer.Size = new System.Drawing.Size(152, 13);
            this.lblAutoWorkerMaynardingPuffer.TabIndex = 1;
            this.lblAutoWorkerMaynardingPuffer.Text = "Puffer for Worker- Maynarding:";
            // 
            // lblAutoWorkerMaxWorkersPewBase
            // 
            this.lblAutoWorkerMaxWorkersPewBase.AutoSize = true;
            this.lblAutoWorkerMaxWorkersPewBase.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Strikeout, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAutoWorkerMaxWorkersPewBase.LanguageFile = "";
            this.lblAutoWorkerMaxWorkersPewBase.Location = new System.Drawing.Point(25, 90);
            this.lblAutoWorkerMaxWorkersPewBase.Name = "lblAutoWorkerMaxWorkersPewBase";
            this.lblAutoWorkerMaxWorkersPewBase.Size = new System.Drawing.Size(142, 13);
            this.lblAutoWorkerMaxWorkersPewBase.TabIndex = 0;
            this.lblAutoWorkerMaxWorkersPewBase.Text = "Maximum Workers per Base:";
            // 
            // AutomationWorker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbAutoWorker);
            this.Name = "AutomationWorker";
            this.Size = new System.Drawing.Size(514, 268);
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
