namespace AnotherSc2Hack.Classes.FrontEnds.MainHandler
{
    partial class MainHandler
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainHandler));
            this.tmrGatherInformation = new System.Windows.Forms.Timer(this.components);
            this.btnMaphack = new System.Windows.Forms.Button();
            this.btnUnit = new System.Windows.Forms.Button();
            this.btnResources = new System.Windows.Forms.Button();
            this.btnIncome = new System.Windows.Forms.Button();
            this.btnApm = new System.Windows.Forms.Button();
            this.btnArmy = new System.Windows.Forms.Button();
            this.btnWorker = new System.Windows.Forms.Button();
            this.tcMainTab = new System.Windows.Forms.TabControl();
            this.tcGlobal = new System.Windows.Forms.TabPage();
            this.CustGlobal = new AnotherSc2Hack.Classes.FrontEnds.ControlGlobal();
            this.tcResources = new System.Windows.Forms.TabPage();
            this.ResourceBasics = new AnotherSc2Hack.Classes.FrontEnds.Basics();
            this.ResourceChatInput = new AnotherSc2Hack.Classes.FrontEnds.ChatInput();
            this.ResourceHotkeys = new AnotherSc2Hack.Classes.FrontEnds.Hotkeys();
            this.ResourceInformation = new AnotherSc2Hack.Classes.FrontEnds.Information();
            this.tcIncome = new System.Windows.Forms.TabPage();
            this.IncomeBasics = new AnotherSc2Hack.Classes.FrontEnds.Basics();
            this.IncomeChatInput = new AnotherSc2Hack.Classes.FrontEnds.ChatInput();
            this.IncomeHotkeys = new AnotherSc2Hack.Classes.FrontEnds.Hotkeys();
            this.IncomeInformation = new AnotherSc2Hack.Classes.FrontEnds.Information();
            this.tcWorker = new System.Windows.Forms.TabPage();
            this.WorkerBasics = new AnotherSc2Hack.Classes.FrontEnds.BasicsWor();
            this.WorkerChatInput = new AnotherSc2Hack.Classes.FrontEnds.ChatInput();
            this.WorkerHotkeys = new AnotherSc2Hack.Classes.FrontEnds.Hotkeys();
            this.WorkerInformation = new AnotherSc2Hack.Classes.FrontEnds.Information();
            this.tcMaphack = new System.Windows.Forms.TabPage();
            this.MaphackBasics = new AnotherSc2Hack.Classes.FrontEnds.BasicsMap();
            this.MaphackChatInput = new AnotherSc2Hack.Classes.FrontEnds.ChatInput();
            this.MaphackHotkeys = new AnotherSc2Hack.Classes.FrontEnds.Hotkeys();
            this.MaphackInformation = new AnotherSc2Hack.Classes.FrontEnds.Information();
            this.gbMaphackColorUnits = new AnotherSc2Hack.Classes.FrontEnds.LanguageGroupbox();
            this.btnMaphackDefineaMarking = new System.Windows.Forms.Button();
            this.btnMapUnitColor = new System.Windows.Forms.Button();
            this.btnMapAddUnit = new AnotherSc2Hack.Classes.FrontEnds.LanguageButton();
            this.icbMapUnit = new AnotherSc2Hack.Classes.FrontEnds.ImageCombobox();
            this.imgUnits = new System.Windows.Forms.ImageList(this.components);
            this.lstMapUnits = new System.Windows.Forms.ListBox();
            this.cmsListboxContext = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addAUnitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteAUnitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tcApm = new System.Windows.Forms.TabPage();
            this.ApmBasics = new AnotherSc2Hack.Classes.FrontEnds.Basics();
            this.ApmChatInput = new AnotherSc2Hack.Classes.FrontEnds.ChatInput();
            this.ApmHotkeys = new AnotherSc2Hack.Classes.FrontEnds.Hotkeys();
            this.ApmInformation = new AnotherSc2Hack.Classes.FrontEnds.Information();
            this.tcArmy = new System.Windows.Forms.TabPage();
            this.ArmyBasics = new AnotherSc2Hack.Classes.FrontEnds.Basics();
            this.ArmyChatInput = new AnotherSc2Hack.Classes.FrontEnds.ChatInput();
            this.ArmyHotkeys = new AnotherSc2Hack.Classes.FrontEnds.Hotkeys();
            this.ArmyInformation = new AnotherSc2Hack.Classes.FrontEnds.Information();
            this.tcUnitTab = new System.Windows.Forms.TabPage();
            this.gbUnittabShow = new AnotherSc2Hack.Classes.FrontEnds.LanguageGroupbox();
            this.chBxUnitTabShowBuildings = new AnotherSc2Hack.Classes.FrontEnds.LanguageCheckbox();
            this.chBxUnitTabShowUnits = new AnotherSc2Hack.Classes.FrontEnds.LanguageCheckbox();
            this.UnittabBasics = new AnotherSc2Hack.Classes.FrontEnds.BasicsUnitTab();
            this.UnittabChatInput = new AnotherSc2Hack.Classes.FrontEnds.ChatInput();
            this.UnittabHotkeys = new AnotherSc2Hack.Classes.FrontEnds.Hotkeys();
            this.UnittabInformation = new AnotherSc2Hack.Classes.FrontEnds.Information();
            this.gbUnitPicture = new AnotherSc2Hack.Classes.FrontEnds.LanguageGroupbox();
            this.lblUnitPicturePreview = new AnotherSc2Hack.Classes.FrontEnds.LanguageLabel();
            this.pcBxUnitPreview = new AnotherSc2Hack.Classes.FrontEnds.CustomPictureBox();
            this.txtUnitPictureSize = new System.Windows.Forms.TextBox();
            this.lblUnitPictureSize = new AnotherSc2Hack.Classes.FrontEnds.LanguageLabel();
            this.tcProduction = new System.Windows.Forms.TabPage();
            this.gbProdtabShow = new AnotherSc2Hack.Classes.FrontEnds.LanguageGroupbox();
            this.chBxProdTabShowUpgrades = new AnotherSc2Hack.Classes.FrontEnds.LanguageCheckbox();
            this.chBxProdTabShowBuildings = new AnotherSc2Hack.Classes.FrontEnds.LanguageCheckbox();
            this.chBxProdTabShowUnits = new AnotherSc2Hack.Classes.FrontEnds.LanguageCheckbox();
            this.gbProdPicture = new AnotherSc2Hack.Classes.FrontEnds.LanguageGroupbox();
            this.lblProdPicturePreview = new AnotherSc2Hack.Classes.FrontEnds.LanguageLabel();
            this.pcBxProductionTabPreview = new AnotherSc2Hack.Classes.FrontEnds.CustomPictureBox();
            this.txtProductionTabPictureSize = new System.Windows.Forms.TextBox();
            this.lblProdPictureSize = new AnotherSc2Hack.Classes.FrontEnds.LanguageLabel();
            this.ProductionTabInformation = new AnotherSc2Hack.Classes.FrontEnds.Information();
            this.ProductionTabHotkeys = new AnotherSc2Hack.Classes.FrontEnds.Hotkeys();
            this.ProductionTabChatInput = new AnotherSc2Hack.Classes.FrontEnds.ChatInput();
            this.ProductionTabBasics = new AnotherSc2Hack.Classes.FrontEnds.BasicsProdTab();
            this.tcWorkerAutomation = new System.Windows.Forms.TabPage();
            this.workerProductionBasics = new AnotherSc2Hack.Classes.FrontEnds.AutomationWorker();
            this.workerProductionHotkeys = new AnotherSc2Hack.Classes.FrontEnds.Hotkeys();
            this.tcVarious = new System.Windows.Forms.TabPage();
            this.Custom_Various = new AnotherSc2Hack.Classes.FrontEnds.CustomVarious();
            this.tcBugs = new System.Windows.Forms.TabPage();
            this.CustBugs = new AnotherSc2Hack.Classes.FrontEnds.ControlBugs();
            this.tcCredits = new System.Windows.Forms.TabPage();
            this.label92 = new System.Windows.Forms.Label();
            this.tcBenchmark = new System.Windows.Forms.TabPage();
            this.GlobalBenchmark = new AnotherSc2Hack.Classes.FrontEnds.Benchmark();
            this.tcDebug = new System.Windows.Forms.TabPage();
            this.CustDebug = new AnotherSc2Hack.Classes.FrontEnds.CustomDebug();
            this.btnProduction = new System.Windows.Forms.Button();
            this.btnLostUnits = new System.Windows.Forms.Button();
            this.btnChangeBorderstyle = new System.Windows.Forms.Button();
            this.ttInformation = new System.Windows.Forms.ToolTip(this.components);
            this.tcMainTab.SuspendLayout();
            this.tcGlobal.SuspendLayout();
            this.tcResources.SuspendLayout();
            this.tcIncome.SuspendLayout();
            this.tcWorker.SuspendLayout();
            this.tcMaphack.SuspendLayout();
            this.gbMaphackColorUnits.SuspendLayout();
            this.cmsListboxContext.SuspendLayout();
            this.tcApm.SuspendLayout();
            this.tcArmy.SuspendLayout();
            this.tcUnitTab.SuspendLayout();
            this.gbUnittabShow.SuspendLayout();
            this.gbUnitPicture.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcBxUnitPreview)).BeginInit();
            this.tcProduction.SuspendLayout();
            this.gbProdtabShow.SuspendLayout();
            this.gbProdPicture.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcBxProductionTabPreview)).BeginInit();
            this.tcWorkerAutomation.SuspendLayout();
            this.tcVarious.SuspendLayout();
            this.tcBugs.SuspendLayout();
            this.tcCredits.SuspendLayout();
            this.tcBenchmark.SuspendLayout();
            this.tcDebug.SuspendLayout();
            this.SuspendLayout();
            // 
            // tmrGatherInformation
            // 
            this.tmrGatherInformation.Interval = 10;
            this.tmrGatherInformation.Tick += new System.EventHandler(this.tmrGatherInformation_Tick);
            // 
            // btnMaphack
            // 
            this.btnMaphack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnMaphack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMaphack.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMaphack.Location = new System.Drawing.Point(255, 449);
            this.btnMaphack.Name = "btnMaphack";
            this.btnMaphack.Size = new System.Drawing.Size(75, 23);
            this.btnMaphack.TabIndex = 3;
            this.btnMaphack.Text = "Maphack";
            this.btnMaphack.UseVisualStyleBackColor = true;
            this.btnMaphack.Click += new System.EventHandler(this.btnMaphack_Click);
            // 
            // btnUnit
            // 
            this.btnUnit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnUnit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUnit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUnit.Location = new System.Drawing.Point(498, 449);
            this.btnUnit.Name = "btnUnit";
            this.btnUnit.Size = new System.Drawing.Size(75, 23);
            this.btnUnit.TabIndex = 6;
            this.btnUnit.Text = "Unit";
            this.btnUnit.UseVisualStyleBackColor = true;
            this.btnUnit.Click += new System.EventHandler(this.btnUnit_Click);
            // 
            // btnResources
            // 
            this.btnResources.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnResources.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResources.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResources.Location = new System.Drawing.Point(12, 449);
            this.btnResources.Name = "btnResources";
            this.btnResources.Size = new System.Drawing.Size(75, 23);
            this.btnResources.TabIndex = 0;
            this.btnResources.Text = "Resources";
            this.btnResources.UseVisualStyleBackColor = true;
            this.btnResources.Click += new System.EventHandler(this.btnResources_Click);
            // 
            // btnIncome
            // 
            this.btnIncome.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnIncome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIncome.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIncome.Location = new System.Drawing.Point(93, 449);
            this.btnIncome.Name = "btnIncome";
            this.btnIncome.Size = new System.Drawing.Size(75, 23);
            this.btnIncome.TabIndex = 1;
            this.btnIncome.Text = "Income";
            this.btnIncome.UseVisualStyleBackColor = true;
            this.btnIncome.Click += new System.EventHandler(this.btnIncome_Click);
            // 
            // btnApm
            // 
            this.btnApm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnApm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApm.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApm.Location = new System.Drawing.Point(336, 449);
            this.btnApm.Name = "btnApm";
            this.btnApm.Size = new System.Drawing.Size(75, 23);
            this.btnApm.TabIndex = 4;
            this.btnApm.Text = "Apm";
            this.btnApm.UseVisualStyleBackColor = true;
            this.btnApm.Click += new System.EventHandler(this.btnApm_Click);
            // 
            // btnArmy
            // 
            this.btnArmy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnArmy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnArmy.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnArmy.Location = new System.Drawing.Point(417, 449);
            this.btnArmy.Name = "btnArmy";
            this.btnArmy.Size = new System.Drawing.Size(75, 23);
            this.btnArmy.TabIndex = 5;
            this.btnArmy.Text = "Army";
            this.btnArmy.UseVisualStyleBackColor = true;
            this.btnArmy.Click += new System.EventHandler(this.btnArmy_Click);
            // 
            // btnWorker
            // 
            this.btnWorker.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnWorker.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWorker.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnWorker.Location = new System.Drawing.Point(174, 449);
            this.btnWorker.Name = "btnWorker";
            this.btnWorker.Size = new System.Drawing.Size(75, 23);
            this.btnWorker.TabIndex = 2;
            this.btnWorker.Text = "Worker";
            this.btnWorker.UseVisualStyleBackColor = true;
            this.btnWorker.Click += new System.EventHandler(this.btnWorker_Click);
            // 
            // tcMainTab
            // 
            this.tcMainTab.Controls.Add(this.tcGlobal);
            this.tcMainTab.Controls.Add(this.tcResources);
            this.tcMainTab.Controls.Add(this.tcIncome);
            this.tcMainTab.Controls.Add(this.tcWorker);
            this.tcMainTab.Controls.Add(this.tcMaphack);
            this.tcMainTab.Controls.Add(this.tcApm);
            this.tcMainTab.Controls.Add(this.tcArmy);
            this.tcMainTab.Controls.Add(this.tcUnitTab);
            this.tcMainTab.Controls.Add(this.tcProduction);
            this.tcMainTab.Controls.Add(this.tcWorkerAutomation);
            this.tcMainTab.Controls.Add(this.tcVarious);
            this.tcMainTab.Controls.Add(this.tcBugs);
            this.tcMainTab.Controls.Add(this.tcCredits);
            this.tcMainTab.Controls.Add(this.tcBenchmark);
            this.tcMainTab.Controls.Add(this.tcDebug);
            this.tcMainTab.Location = new System.Drawing.Point(12, 12);
            this.tcMainTab.Name = "tcMainTab";
            this.tcMainTab.SelectedIndex = 0;
            this.tcMainTab.Size = new System.Drawing.Size(948, 431);
            this.tcMainTab.TabIndex = 7;
            this.tcMainTab.SelectedIndexChanged += new System.EventHandler(this.tcMainTab_SelectedIndexChanged);
            // 
            // tcGlobal
            // 
            this.tcGlobal.BackColor = System.Drawing.SystemColors.Control;
            this.tcGlobal.Controls.Add(this.CustGlobal);
            this.tcGlobal.Location = new System.Drawing.Point(4, 22);
            this.tcGlobal.Name = "tcGlobal";
            this.tcGlobal.Size = new System.Drawing.Size(940, 405);
            this.tcGlobal.TabIndex = 7;
            this.tcGlobal.Text = "Global";
            // 
            // CustGlobal
            // 
            this.CustGlobal.Location = new System.Drawing.Point(0, 0);
            this.CustGlobal.Name = "CustGlobal";
            this.CustGlobal.Size = new System.Drawing.Size(935, 406);
            this.CustGlobal.TabIndex = 0;
            // 
            // tcResources
            // 
            this.tcResources.BackColor = System.Drawing.SystemColors.Control;
            this.tcResources.Controls.Add(this.ResourceBasics);
            this.tcResources.Controls.Add(this.ResourceChatInput);
            this.tcResources.Controls.Add(this.ResourceHotkeys);
            this.tcResources.Controls.Add(this.ResourceInformation);
            this.tcResources.Location = new System.Drawing.Point(4, 22);
            this.tcResources.Name = "tcResources";
            this.tcResources.Size = new System.Drawing.Size(940, 405);
            this.tcResources.TabIndex = 2;
            this.tcResources.Text = "Resources";
            // 
            // ResourceBasics
            // 
            this.ResourceBasics.Location = new System.Drawing.Point(30, 18);
            this.ResourceBasics.Name = "ResourceBasics";
            this.ResourceBasics.Size = new System.Drawing.Size(291, 300);
            this.ResourceBasics.TabIndex = 68;
            // 
            // ResourceChatInput
            // 
            this.ResourceChatInput.Location = new System.Drawing.Point(331, 18);
            this.ResourceChatInput.Name = "ResourceChatInput";
            this.ResourceChatInput.Size = new System.Drawing.Size(246, 120);
            this.ResourceChatInput.TabIndex = 67;
            // 
            // ResourceHotkeys
            // 
            this.ResourceHotkeys.Location = new System.Drawing.Point(331, 190);
            this.ResourceHotkeys.Name = "ResourceHotkeys";
            this.ResourceHotkeys.Size = new System.Drawing.Size(246, 128);
            this.ResourceHotkeys.TabIndex = 64;
            // 
            // ResourceInformation
            // 
            this.ResourceInformation.Location = new System.Drawing.Point(590, 18);
            this.ResourceInformation.Name = "ResourceInformation";
            this.ResourceInformation.Size = new System.Drawing.Size(196, 156);
            this.ResourceInformation.TabIndex = 63;
            // 
            // tcIncome
            // 
            this.tcIncome.BackColor = System.Drawing.SystemColors.Control;
            this.tcIncome.Controls.Add(this.IncomeBasics);
            this.tcIncome.Controls.Add(this.IncomeChatInput);
            this.tcIncome.Controls.Add(this.IncomeHotkeys);
            this.tcIncome.Controls.Add(this.IncomeInformation);
            this.tcIncome.Location = new System.Drawing.Point(4, 22);
            this.tcIncome.Name = "tcIncome";
            this.tcIncome.Size = new System.Drawing.Size(940, 405);
            this.tcIncome.TabIndex = 3;
            this.tcIncome.Text = "Income";
            // 
            // IncomeBasics
            // 
            this.IncomeBasics.Location = new System.Drawing.Point(30, 18);
            this.IncomeBasics.Name = "IncomeBasics";
            this.IncomeBasics.Size = new System.Drawing.Size(291, 300);
            this.IncomeBasics.TabIndex = 69;
            // 
            // IncomeChatInput
            // 
            this.IncomeChatInput.Location = new System.Drawing.Point(331, 18);
            this.IncomeChatInput.Name = "IncomeChatInput";
            this.IncomeChatInput.Size = new System.Drawing.Size(246, 120);
            this.IncomeChatInput.TabIndex = 67;
            // 
            // IncomeHotkeys
            // 
            this.IncomeHotkeys.Location = new System.Drawing.Point(331, 190);
            this.IncomeHotkeys.Name = "IncomeHotkeys";
            this.IncomeHotkeys.Size = new System.Drawing.Size(246, 128);
            this.IncomeHotkeys.TabIndex = 65;
            // 
            // IncomeInformation
            // 
            this.IncomeInformation.Location = new System.Drawing.Point(590, 18);
            this.IncomeInformation.Name = "IncomeInformation";
            this.IncomeInformation.Size = new System.Drawing.Size(196, 156);
            this.IncomeInformation.TabIndex = 63;
            // 
            // tcWorker
            // 
            this.tcWorker.BackColor = System.Drawing.SystemColors.Control;
            this.tcWorker.Controls.Add(this.WorkerBasics);
            this.tcWorker.Controls.Add(this.WorkerChatInput);
            this.tcWorker.Controls.Add(this.WorkerHotkeys);
            this.tcWorker.Controls.Add(this.WorkerInformation);
            this.tcWorker.Location = new System.Drawing.Point(4, 22);
            this.tcWorker.Name = "tcWorker";
            this.tcWorker.Size = new System.Drawing.Size(940, 405);
            this.tcWorker.TabIndex = 6;
            this.tcWorker.Text = "Worker";
            // 
            // WorkerBasics
            // 
            this.WorkerBasics.Location = new System.Drawing.Point(30, 18);
            this.WorkerBasics.Name = "WorkerBasics";
            this.WorkerBasics.Size = new System.Drawing.Size(291, 141);
            this.WorkerBasics.TabIndex = 68;
            // 
            // WorkerChatInput
            // 
            this.WorkerChatInput.Location = new System.Drawing.Point(331, 18);
            this.WorkerChatInput.Name = "WorkerChatInput";
            this.WorkerChatInput.Size = new System.Drawing.Size(246, 120);
            this.WorkerChatInput.TabIndex = 67;
            // 
            // WorkerHotkeys
            // 
            this.WorkerHotkeys.Location = new System.Drawing.Point(331, 160);
            this.WorkerHotkeys.Name = "WorkerHotkeys";
            this.WorkerHotkeys.Size = new System.Drawing.Size(246, 128);
            this.WorkerHotkeys.TabIndex = 65;
            // 
            // WorkerInformation
            // 
            this.WorkerInformation.Location = new System.Drawing.Point(590, 18);
            this.WorkerInformation.Name = "WorkerInformation";
            this.WorkerInformation.Size = new System.Drawing.Size(196, 156);
            this.WorkerInformation.TabIndex = 63;
            // 
            // tcMaphack
            // 
            this.tcMaphack.BackColor = System.Drawing.SystemColors.Control;
            this.tcMaphack.Controls.Add(this.MaphackBasics);
            this.tcMaphack.Controls.Add(this.MaphackChatInput);
            this.tcMaphack.Controls.Add(this.MaphackHotkeys);
            this.tcMaphack.Controls.Add(this.MaphackInformation);
            this.tcMaphack.Controls.Add(this.gbMaphackColorUnits);
            this.tcMaphack.Location = new System.Drawing.Point(4, 22);
            this.tcMaphack.Name = "tcMaphack";
            this.tcMaphack.Padding = new System.Windows.Forms.Padding(3);
            this.tcMaphack.Size = new System.Drawing.Size(940, 405);
            this.tcMaphack.TabIndex = 0;
            this.tcMaphack.Text = "Maphack";
            // 
            // MaphackBasics
            // 
            this.MaphackBasics.Location = new System.Drawing.Point(30, 18);
            this.MaphackBasics.Name = "MaphackBasics";
            this.MaphackBasics.Size = new System.Drawing.Size(291, 367);
            this.MaphackBasics.TabIndex = 72;
            // 
            // MaphackChatInput
            // 
            this.MaphackChatInput.Location = new System.Drawing.Point(331, 18);
            this.MaphackChatInput.Name = "MaphackChatInput";
            this.MaphackChatInput.Size = new System.Drawing.Size(246, 120);
            this.MaphackChatInput.TabIndex = 71;
            // 
            // MaphackHotkeys
            // 
            this.MaphackHotkeys.Location = new System.Drawing.Point(331, 228);
            this.MaphackHotkeys.Name = "MaphackHotkeys";
            this.MaphackHotkeys.Size = new System.Drawing.Size(246, 128);
            this.MaphackHotkeys.TabIndex = 70;
            // 
            // MaphackInformation
            // 
            this.MaphackInformation.Location = new System.Drawing.Point(590, 18);
            this.MaphackInformation.Name = "MaphackInformation";
            this.MaphackInformation.Size = new System.Drawing.Size(196, 156);
            this.MaphackInformation.TabIndex = 63;
            // 
            // gbMaphackColorUnits
            // 
            this.gbMaphackColorUnits.Controls.Add(this.btnMaphackDefineaMarking);
            this.gbMaphackColorUnits.Controls.Add(this.btnMapUnitColor);
            this.gbMaphackColorUnits.Controls.Add(this.btnMapAddUnit);
            this.gbMaphackColorUnits.Controls.Add(this.icbMapUnit);
            this.gbMaphackColorUnits.Controls.Add(this.lstMapUnits);
            this.gbMaphackColorUnits.LanguageFile = "";
            this.gbMaphackColorUnits.Location = new System.Drawing.Point(590, 180);
            this.gbMaphackColorUnits.Name = "gbMaphackColorUnits";
            this.gbMaphackColorUnits.Size = new System.Drawing.Size(339, 176);
            this.gbMaphackColorUnits.TabIndex = 69;
            this.gbMaphackColorUnits.TabStop = false;
            this.gbMaphackColorUnits.Text = "Mark Units";
            // 
            // btnMaphackDefineaMarking
            // 
            this.btnMaphackDefineaMarking.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMaphackDefineaMarking.Location = new System.Drawing.Point(158, 136);
            this.btnMaphackDefineaMarking.Name = "btnMaphackDefineaMarking";
            this.btnMaphackDefineaMarking.Size = new System.Drawing.Size(175, 23);
            this.btnMaphackDefineaMarking.TabIndex = 6;
            this.btnMaphackDefineaMarking.Text = "Define Marking";
            this.btnMaphackDefineaMarking.UseVisualStyleBackColor = true;
            this.btnMaphackDefineaMarking.Visible = false;
            this.btnMaphackDefineaMarking.Click += new System.EventHandler(this.btnMaphackDefineaMarking_Click);
            // 
            // btnMapUnitColor
            // 
            this.btnMapUnitColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMapUnitColor.Location = new System.Drawing.Point(158, 95);
            this.btnMapUnitColor.Name = "btnMapUnitColor";
            this.btnMapUnitColor.Size = new System.Drawing.Size(175, 23);
            this.btnMapUnitColor.TabIndex = 4;
            this.btnMapUnitColor.UseVisualStyleBackColor = true;
            this.btnMapUnitColor.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnMapUnitColor_MouseDown);
            // 
            // btnMapAddUnit
            // 
            this.btnMapAddUnit.LanguageFile = "";
            this.btnMapAddUnit.Location = new System.Drawing.Point(158, 24);
            this.btnMapAddUnit.Name = "btnMapAddUnit";
            this.btnMapAddUnit.Size = new System.Drawing.Size(175, 23);
            this.btnMapAddUnit.TabIndex = 5;
            this.btnMapAddUnit.Text = "Add Unit";
            this.btnMapAddUnit.UseVisualStyleBackColor = true;
            this.btnMapAddUnit.Click += new System.EventHandler(this.btnMapAddUnit_Click);
            // 
            // icbMapUnit
            // 
            this.icbMapUnit.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.icbMapUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.icbMapUnit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.icbMapUnit.FormattingEnabled = true;
            this.icbMapUnit.ImageList = this.imgUnits;
            this.icbMapUnit.ItemHeight = 30;
            this.icbMapUnit.Location = new System.Drawing.Point(158, 53);
            this.icbMapUnit.Name = "icbMapUnit";
            this.icbMapUnit.Size = new System.Drawing.Size(175, 36);
            this.icbMapUnit.TabIndex = 3;
            this.icbMapUnit.SelectedIndexChanged += new System.EventHandler(this.icbMapUnit_SelectedIndexChanged);
            // 
            // imgUnits
            // 
            this.imgUnits.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgUnits.ImageStream")));
            this.imgUnits.TransparentColor = System.Drawing.Color.Transparent;
            this.imgUnits.Images.SetKeyName(0, "tu_scv.jpg");
            this.imgUnits.Images.SetKeyName(1, "tu_Mule.jpg");
            this.imgUnits.Images.SetKeyName(2, "tu_marine.jpg");
            this.imgUnits.Images.SetKeyName(3, "tu_marauder.jpg");
            this.imgUnits.Images.SetKeyName(4, "tu_ghost.jpg");
            this.imgUnits.Images.SetKeyName(5, "tu_reaper.jpg");
            this.imgUnits.Images.SetKeyName(6, "tu_hellion.jpg");
            this.imgUnits.Images.SetKeyName(7, "tu_battlehellion.jpg");
            this.imgUnits.Images.SetKeyName(8, "tu_widowmine.jpg");
            this.imgUnits.Images.SetKeyName(9, "tu_tank.jpg");
            this.imgUnits.Images.SetKeyName(10, "tu_thor.jpg");
            this.imgUnits.Images.SetKeyName(11, "tu_medivac.jpg");
            this.imgUnits.Images.SetKeyName(12, "tu_banshee.jpg");
            this.imgUnits.Images.SetKeyName(13, "tu_vikingAir.jpg");
            this.imgUnits.Images.SetKeyName(14, "tu_raven.jpg");
            this.imgUnits.Images.SetKeyName(15, "tu_battlecruiser.jpg");
            this.imgUnits.Images.SetKeyName(16, "pu_probe.jpg");
            this.imgUnits.Images.SetKeyName(17, "pu_mothershipcore.jpg");
            this.imgUnits.Images.SetKeyName(18, "pu_Zealot.jpg");
            this.imgUnits.Images.SetKeyName(19, "pu_Stalker.jpg");
            this.imgUnits.Images.SetKeyName(20, "pu_sentry.jpg");
            this.imgUnits.Images.SetKeyName(21, "pu_ht.jpg");
            this.imgUnits.Images.SetKeyName(22, "pu_DarkTemplar.jpg");
            this.imgUnits.Images.SetKeyName(23, "pu_Archon.jpg");
            this.imgUnits.Images.SetKeyName(24, "pu_immortal.jpg");
            this.imgUnits.Images.SetKeyName(25, "pu_Observer.jpg");
            this.imgUnits.Images.SetKeyName(26, "pu_warpprism.jpg");
            this.imgUnits.Images.SetKeyName(27, "pu_Colossus.jpg");
            this.imgUnits.Images.SetKeyName(28, "pu_pheonix.jpg");
            this.imgUnits.Images.SetKeyName(29, "pu_oracle.jpg");
            this.imgUnits.Images.SetKeyName(30, "pu_Voidray.jpg");
            this.imgUnits.Images.SetKeyName(31, "pu_carrier.jpg");
            this.imgUnits.Images.SetKeyName(32, "pu_tempest.jpg");
            this.imgUnits.Images.SetKeyName(33, "pu_Mothership.jpg");
            this.imgUnits.Images.SetKeyName(34, "zu_larva.jpg");
            this.imgUnits.Images.SetKeyName(35, "zu_drone.jpg");
            this.imgUnits.Images.SetKeyName(36, "zu_overlord.jpg");
            this.imgUnits.Images.SetKeyName(37, "zu_queen.jpg");
            this.imgUnits.Images.SetKeyName(38, "zu_zergling.jpg");
            this.imgUnits.Images.SetKeyName(39, "zu_baneling.jpg");
            this.imgUnits.Images.SetKeyName(40, "zu_roach.jpg");
            this.imgUnits.Images.SetKeyName(41, "zu_hydra.jpg");
            this.imgUnits.Images.SetKeyName(42, "zu_overseer.jpg");
            this.imgUnits.Images.SetKeyName(43, "zu_mutalisk.jpg");
            this.imgUnits.Images.SetKeyName(44, "zu_corruptor.jpg");
            this.imgUnits.Images.SetKeyName(45, "zu_infestor.jpg");
            this.imgUnits.Images.SetKeyName(46, "zu_broodlord.jpg");
            this.imgUnits.Images.SetKeyName(47, "zu_ultra.jpg");
            this.imgUnits.Images.SetKeyName(48, "zu_viper.jpg");
            this.imgUnits.Images.SetKeyName(49, "zu_swarmhost.jpg");
            this.imgUnits.Images.SetKeyName(50, "tb_cc.jpg");
            this.imgUnits.Images.SetKeyName(51, "tb_oc.jpg");
            this.imgUnits.Images.SetKeyName(52, "tb_pf.jpg");
            this.imgUnits.Images.SetKeyName(53, "tb_supply.jpg");
            this.imgUnits.Images.SetKeyName(54, "tb_rax.jpg");
            this.imgUnits.Images.SetKeyName(55, "tb_refinery.jpg");
            this.imgUnits.Images.SetKeyName(56, "tb_ebay.jpg");
            this.imgUnits.Images.SetKeyName(57, "tb_bunker.jpg");
            this.imgUnits.Images.SetKeyName(58, "tb_turret.jpg");
            this.imgUnits.Images.SetKeyName(59, "tb_sensor.jpg");
            this.imgUnits.Images.SetKeyName(60, "tb_ghostacademy.jpg");
            this.imgUnits.Images.SetKeyName(61, "tb_fax.jpg");
            this.imgUnits.Images.SetKeyName(62, "tb_starport.jpg");
            this.imgUnits.Images.SetKeyName(63, "tb_Armory.jpg");
            this.imgUnits.Images.SetKeyName(64, "tb_fusioncore.jpg");
            this.imgUnits.Images.SetKeyName(65, "pb_Nexus.jpg");
            this.imgUnits.Images.SetKeyName(66, "pb_Pylon.jpg");
            this.imgUnits.Images.SetKeyName(67, "pb_Assimilator.jpg");
            this.imgUnits.Images.SetKeyName(68, "pb_gateway.jpg");
            this.imgUnits.Images.SetKeyName(69, "pb_warpgate.jpg");
            this.imgUnits.Images.SetKeyName(70, "pb_forge.jpg");
            this.imgUnits.Images.SetKeyName(71, "pb_cybercore.jpg");
            this.imgUnits.Images.SetKeyName(72, "pb_Cannon.jpg");
            this.imgUnits.Images.SetKeyName(73, "pb_robotics.jpg");
            this.imgUnits.Images.SetKeyName(74, "pb_roboticssupport.jpg");
            this.imgUnits.Images.SetKeyName(75, "pb_stargate.jpg");
            this.imgUnits.Images.SetKeyName(76, "pb_FleetBeacon.jpg");
            this.imgUnits.Images.SetKeyName(77, "pb_twillightCouncil.jpg");
            this.imgUnits.Images.SetKeyName(78, "pb_DarkShrine.jpg");
            this.imgUnits.Images.SetKeyName(79, "pb_templararchives.jpg");
            this.imgUnits.Images.SetKeyName(80, "zb_hatchery.jpg");
            this.imgUnits.Images.SetKeyName(81, "zb_lair.jpg");
            this.imgUnits.Images.SetKeyName(82, "zb_hive.jpg");
            this.imgUnits.Images.SetKeyName(83, "zb_spawningpool.jpg");
            this.imgUnits.Images.SetKeyName(84, "zb_banelingnest.jpg");
            this.imgUnits.Images.SetKeyName(85, "zb_extactor.jpg");
            this.imgUnits.Images.SetKeyName(86, "zb_evochamber.jpg");
            this.imgUnits.Images.SetKeyName(87, "zb_spore.jpg");
            this.imgUnits.Images.SetKeyName(88, "zb_spine.jpg");
            this.imgUnits.Images.SetKeyName(89, "zb_roachwarren.jpg");
            this.imgUnits.Images.SetKeyName(90, "zb_spire.jpg");
            this.imgUnits.Images.SetKeyName(91, "zb_hydraden.jpg");
            this.imgUnits.Images.SetKeyName(92, "zb_infestationpit.jpg");
            this.imgUnits.Images.SetKeyName(93, "zb_nydusworm.jpg");
            this.imgUnits.Images.SetKeyName(94, "zb_nydusnetwork.jpg");
            this.imgUnits.Images.SetKeyName(95, "zb_ultracavery.jpg");
            this.imgUnits.Images.SetKeyName(96, "zb_greaterspire.jpg");
            this.imgUnits.Images.SetKeyName(97, "zb_creeptumor.jpg");
            this.imgUnits.Images.SetKeyName(98, "zu_banelingcocoon.png");
            this.imgUnits.Images.SetKeyName(99, "zu_broodlordcocoon.png");
            this.imgUnits.Images.SetKeyName(100, "zu_overseercocoon.png");
            this.imgUnits.Images.SetKeyName(101, "zu_locust.png");
            this.imgUnits.Images.SetKeyName(102, "zu_changeling.jpg");
            // 
            // lstMapUnits
            // 
            this.lstMapUnits.ContextMenuStrip = this.cmsListboxContext;
            this.lstMapUnits.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.lstMapUnits.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstMapUnits.FormattingEnabled = true;
            this.lstMapUnits.Location = new System.Drawing.Point(18, 25);
            this.lstMapUnits.Name = "lstMapUnits";
            this.lstMapUnits.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstMapUnits.Size = new System.Drawing.Size(131, 134);
            this.lstMapUnits.TabIndex = 0;
            this.lstMapUnits.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.lstMapUnits_DrawItem);
            this.lstMapUnits.SelectedIndexChanged += new System.EventHandler(this.lstMapUnits_SelectedIndexChanged);
            this.lstMapUnits.KeyUp += new System.Windows.Forms.KeyEventHandler(this.lstMapUnits_KeyUp);
            // 
            // cmsListboxContext
            // 
            this.cmsListboxContext.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addAUnitToolStripMenuItem,
            this.deleteAUnitToolStripMenuItem});
            this.cmsListboxContext.Name = "cmsListboxContext";
            this.cmsListboxContext.Size = new System.Drawing.Size(144, 48);
            // 
            // addAUnitToolStripMenuItem
            // 
            this.addAUnitToolStripMenuItem.Name = "addAUnitToolStripMenuItem";
            this.addAUnitToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.addAUnitToolStripMenuItem.Text = "Add A Unit";
            this.addAUnitToolStripMenuItem.Click += new System.EventHandler(this.addAUnitToolStripMenuItem_Click);
            // 
            // deleteAUnitToolStripMenuItem
            // 
            this.deleteAUnitToolStripMenuItem.Name = "deleteAUnitToolStripMenuItem";
            this.deleteAUnitToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.deleteAUnitToolStripMenuItem.Text = "Delete A Unit";
            this.deleteAUnitToolStripMenuItem.Click += new System.EventHandler(this.deleteAUnitToolStripMenuItem_Click);
            // 
            // tcApm
            // 
            this.tcApm.BackColor = System.Drawing.SystemColors.Control;
            this.tcApm.Controls.Add(this.ApmBasics);
            this.tcApm.Controls.Add(this.ApmChatInput);
            this.tcApm.Controls.Add(this.ApmHotkeys);
            this.tcApm.Controls.Add(this.ApmInformation);
            this.tcApm.Location = new System.Drawing.Point(4, 22);
            this.tcApm.Name = "tcApm";
            this.tcApm.Size = new System.Drawing.Size(940, 405);
            this.tcApm.TabIndex = 5;
            this.tcApm.Text = "Apm";
            // 
            // ApmBasics
            // 
            this.ApmBasics.Location = new System.Drawing.Point(30, 18);
            this.ApmBasics.Name = "ApmBasics";
            this.ApmBasics.Size = new System.Drawing.Size(291, 300);
            this.ApmBasics.TabIndex = 70;
            // 
            // ApmChatInput
            // 
            this.ApmChatInput.Location = new System.Drawing.Point(331, 18);
            this.ApmChatInput.Name = "ApmChatInput";
            this.ApmChatInput.Size = new System.Drawing.Size(246, 120);
            this.ApmChatInput.TabIndex = 67;
            // 
            // ApmHotkeys
            // 
            this.ApmHotkeys.Location = new System.Drawing.Point(331, 190);
            this.ApmHotkeys.Name = "ApmHotkeys";
            this.ApmHotkeys.Size = new System.Drawing.Size(246, 128);
            this.ApmHotkeys.TabIndex = 65;
            // 
            // ApmInformation
            // 
            this.ApmInformation.Location = new System.Drawing.Point(590, 18);
            this.ApmInformation.Name = "ApmInformation";
            this.ApmInformation.Size = new System.Drawing.Size(196, 156);
            this.ApmInformation.TabIndex = 63;
            // 
            // tcArmy
            // 
            this.tcArmy.BackColor = System.Drawing.SystemColors.Control;
            this.tcArmy.Controls.Add(this.ArmyBasics);
            this.tcArmy.Controls.Add(this.ArmyChatInput);
            this.tcArmy.Controls.Add(this.ArmyHotkeys);
            this.tcArmy.Controls.Add(this.ArmyInformation);
            this.tcArmy.Location = new System.Drawing.Point(4, 22);
            this.tcArmy.Name = "tcArmy";
            this.tcArmy.Size = new System.Drawing.Size(940, 405);
            this.tcArmy.TabIndex = 4;
            this.tcArmy.Text = "Army";
            // 
            // ArmyBasics
            // 
            this.ArmyBasics.Location = new System.Drawing.Point(30, 18);
            this.ArmyBasics.Name = "ArmyBasics";
            this.ArmyBasics.Size = new System.Drawing.Size(291, 300);
            this.ArmyBasics.TabIndex = 72;
            // 
            // ArmyChatInput
            // 
            this.ArmyChatInput.Location = new System.Drawing.Point(331, 18);
            this.ArmyChatInput.Name = "ArmyChatInput";
            this.ArmyChatInput.Size = new System.Drawing.Size(246, 120);
            this.ArmyChatInput.TabIndex = 67;
            // 
            // ArmyHotkeys
            // 
            this.ArmyHotkeys.Location = new System.Drawing.Point(331, 190);
            this.ArmyHotkeys.Name = "ArmyHotkeys";
            this.ArmyHotkeys.Size = new System.Drawing.Size(246, 128);
            this.ArmyHotkeys.TabIndex = 65;
            // 
            // ArmyInformation
            // 
            this.ArmyInformation.Location = new System.Drawing.Point(590, 18);
            this.ArmyInformation.Name = "ArmyInformation";
            this.ArmyInformation.Size = new System.Drawing.Size(196, 156);
            this.ArmyInformation.TabIndex = 63;
            // 
            // tcUnitTab
            // 
            this.tcUnitTab.BackColor = System.Drawing.SystemColors.Control;
            this.tcUnitTab.Controls.Add(this.gbUnittabShow);
            this.tcUnitTab.Controls.Add(this.UnittabBasics);
            this.tcUnitTab.Controls.Add(this.UnittabChatInput);
            this.tcUnitTab.Controls.Add(this.UnittabHotkeys);
            this.tcUnitTab.Controls.Add(this.UnittabInformation);
            this.tcUnitTab.Controls.Add(this.gbUnitPicture);
            this.tcUnitTab.Location = new System.Drawing.Point(4, 22);
            this.tcUnitTab.Name = "tcUnitTab";
            this.tcUnitTab.Padding = new System.Windows.Forms.Padding(3);
            this.tcUnitTab.Size = new System.Drawing.Size(940, 405);
            this.tcUnitTab.TabIndex = 1;
            this.tcUnitTab.Text = "UnitTab";
            // 
            // gbUnittabShow
            // 
            this.gbUnittabShow.Controls.Add(this.chBxUnitTabShowBuildings);
            this.gbUnittabShow.Controls.Add(this.chBxUnitTabShowUnits);
            this.gbUnittabShow.LanguageFile = "";
            this.gbUnittabShow.Location = new System.Drawing.Point(331, 144);
            this.gbUnittabShow.Name = "gbUnittabShow";
            this.gbUnittabShow.Size = new System.Drawing.Size(246, 64);
            this.gbUnittabShow.TabIndex = 68;
            this.gbUnittabShow.TabStop = false;
            this.gbUnittabShow.Text = "Show";
            // 
            // chBxUnitTabShowBuildings
            // 
            this.chBxUnitTabShowBuildings.AutoSize = true;
            this.chBxUnitTabShowBuildings.LanguageFile = "";
            this.chBxUnitTabShowBuildings.Location = new System.Drawing.Point(172, 30);
            this.chBxUnitTabShowBuildings.Name = "chBxUnitTabShowBuildings";
            this.chBxUnitTabShowBuildings.Size = new System.Drawing.Size(68, 17);
            this.chBxUnitTabShowBuildings.TabIndex = 1;
            this.chBxUnitTabShowBuildings.Text = "Buildings";
            this.chBxUnitTabShowBuildings.UseVisualStyleBackColor = true;
            this.chBxUnitTabShowBuildings.CheckedChanged += new System.EventHandler(this.chBxUnitTabShowBuildings_CheckedChanged);
            // 
            // chBxUnitTabShowUnits
            // 
            this.chBxUnitTabShowUnits.AutoSize = true;
            this.chBxUnitTabShowUnits.LanguageFile = "";
            this.chBxUnitTabShowUnits.Location = new System.Drawing.Point(14, 30);
            this.chBxUnitTabShowUnits.Name = "chBxUnitTabShowUnits";
            this.chBxUnitTabShowUnits.Size = new System.Drawing.Size(50, 17);
            this.chBxUnitTabShowUnits.TabIndex = 0;
            this.chBxUnitTabShowUnits.Text = "Units";
            this.chBxUnitTabShowUnits.UseVisualStyleBackColor = true;
            this.chBxUnitTabShowUnits.CheckedChanged += new System.EventHandler(this.chBxUnitTabShowUnits_CheckedChanged);
            // 
            // UnittabBasics
            // 
            this.UnittabBasics.Location = new System.Drawing.Point(30, 18);
            this.UnittabBasics.Name = "UnittabBasics";
            this.UnittabBasics.Size = new System.Drawing.Size(291, 384);
            this.UnittabBasics.TabIndex = 67;
            // 
            // UnittabChatInput
            // 
            this.UnittabChatInput.Location = new System.Drawing.Point(331, 18);
            this.UnittabChatInput.Name = "UnittabChatInput";
            this.UnittabChatInput.Size = new System.Drawing.Size(246, 120);
            this.UnittabChatInput.TabIndex = 66;
            // 
            // UnittabHotkeys
            // 
            this.UnittabHotkeys.Location = new System.Drawing.Point(331, 271);
            this.UnittabHotkeys.Name = "UnittabHotkeys";
            this.UnittabHotkeys.Size = new System.Drawing.Size(246, 128);
            this.UnittabHotkeys.TabIndex = 65;
            // 
            // UnittabInformation
            // 
            this.UnittabInformation.Location = new System.Drawing.Point(590, 18);
            this.UnittabInformation.Name = "UnittabInformation";
            this.UnittabInformation.Size = new System.Drawing.Size(196, 156);
            this.UnittabInformation.TabIndex = 62;
            // 
            // gbUnitPicture
            // 
            this.gbUnitPicture.Controls.Add(this.lblUnitPicturePreview);
            this.gbUnitPicture.Controls.Add(this.pcBxUnitPreview);
            this.gbUnitPicture.Controls.Add(this.txtUnitPictureSize);
            this.gbUnitPicture.Controls.Add(this.lblUnitPictureSize);
            this.gbUnitPicture.LanguageFile = "";
            this.gbUnitPicture.Location = new System.Drawing.Point(590, 214);
            this.gbUnitPicture.Name = "gbUnitPicture";
            this.gbUnitPicture.Size = new System.Drawing.Size(196, 128);
            this.gbUnitPicture.TabIndex = 61;
            this.gbUnitPicture.TabStop = false;
            this.gbUnitPicture.Text = "Picturesize";
            // 
            // lblUnitPicturePreview
            // 
            this.lblUnitPicturePreview.AutoSize = true;
            this.lblUnitPicturePreview.LanguageFile = "";
            this.lblUnitPicturePreview.Location = new System.Drawing.Point(12, 60);
            this.lblUnitPicturePreview.Name = "lblUnitPicturePreview";
            this.lblUnitPicturePreview.Size = new System.Drawing.Size(48, 13);
            this.lblUnitPicturePreview.TabIndex = 3;
            this.lblUnitPicturePreview.Text = "Preview:";
            // 
            // pcBxUnitPreview
            // 
            this.pcBxUnitPreview.DrawingFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pcBxUnitPreview.DrawingPoint = ((System.Drawing.PointF)(resources.GetObject("pcBxUnitPreview.DrawingPoint")));
            this.pcBxUnitPreview.DrawingText = "";
            this.pcBxUnitPreview.Image = global::AnotherSc2Hack.Properties.Resources.tu_Mule;
            this.pcBxUnitPreview.Location = new System.Drawing.Point(89, 53);
            this.pcBxUnitPreview.Name = "pcBxUnitPreview";
            this.pcBxUnitPreview.Size = new System.Drawing.Size(45, 45);
            this.pcBxUnitPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcBxUnitPreview.TabIndex = 2;
            this.pcBxUnitPreview.TabStop = false;
            // 
            // txtUnitPictureSize
            // 
            this.txtUnitPictureSize.Location = new System.Drawing.Point(89, 27);
            this.txtUnitPictureSize.Name = "txtUnitPictureSize";
            this.txtUnitPictureSize.Size = new System.Drawing.Size(83, 20);
            this.txtUnitPictureSize.TabIndex = 1;
            this.txtUnitPictureSize.TextChanged += new System.EventHandler(this.txtUnitPictureSize_TextChanged);
            // 
            // lblUnitPictureSize
            // 
            this.lblUnitPictureSize.AutoSize = true;
            this.lblUnitPictureSize.LanguageFile = "";
            this.lblUnitPictureSize.Location = new System.Drawing.Point(12, 30);
            this.lblUnitPictureSize.Name = "lblUnitPictureSize";
            this.lblUnitPictureSize.Size = new System.Drawing.Size(50, 13);
            this.lblUnitPictureSize.TabIndex = 0;
            this.lblUnitPictureSize.Text = "Size (px):";
            // 
            // tcProduction
            // 
            this.tcProduction.BackColor = System.Drawing.SystemColors.Control;
            this.tcProduction.Controls.Add(this.gbProdtabShow);
            this.tcProduction.Controls.Add(this.gbProdPicture);
            this.tcProduction.Controls.Add(this.ProductionTabInformation);
            this.tcProduction.Controls.Add(this.ProductionTabHotkeys);
            this.tcProduction.Controls.Add(this.ProductionTabChatInput);
            this.tcProduction.Controls.Add(this.ProductionTabBasics);
            this.tcProduction.Location = new System.Drawing.Point(4, 22);
            this.tcProduction.Name = "tcProduction";
            this.tcProduction.Size = new System.Drawing.Size(940, 405);
            this.tcProduction.TabIndex = 13;
            this.tcProduction.Text = "Production";
            // 
            // gbProdtabShow
            // 
            this.gbProdtabShow.Controls.Add(this.chBxProdTabShowUpgrades);
            this.gbProdtabShow.Controls.Add(this.chBxProdTabShowBuildings);
            this.gbProdtabShow.Controls.Add(this.chBxProdTabShowUnits);
            this.gbProdtabShow.LanguageFile = "";
            this.gbProdtabShow.Location = new System.Drawing.Point(331, 144);
            this.gbProdtabShow.Name = "gbProdtabShow";
            this.gbProdtabShow.Size = new System.Drawing.Size(246, 64);
            this.gbProdtabShow.TabIndex = 69;
            this.gbProdtabShow.TabStop = false;
            this.gbProdtabShow.Text = "Show";
            // 
            // chBxProdTabShowUpgrades
            // 
            this.chBxProdTabShowUpgrades.AutoSize = true;
            this.chBxProdTabShowUpgrades.LanguageFile = "";
            this.chBxProdTabShowUpgrades.Location = new System.Drawing.Point(168, 30);
            this.chBxProdTabShowUpgrades.Name = "chBxProdTabShowUpgrades";
            this.chBxProdTabShowUpgrades.Size = new System.Drawing.Size(72, 17);
            this.chBxProdTabShowUpgrades.TabIndex = 2;
            this.chBxProdTabShowUpgrades.Text = "Upgrades";
            this.chBxProdTabShowUpgrades.UseVisualStyleBackColor = true;
            this.chBxProdTabShowUpgrades.CheckedChanged += new System.EventHandler(this.chBxProdTabShowUpgrades_CheckedChanged);
            // 
            // chBxProdTabShowBuildings
            // 
            this.chBxProdTabShowBuildings.AutoSize = true;
            this.chBxProdTabShowBuildings.LanguageFile = "";
            this.chBxProdTabShowBuildings.Location = new System.Drawing.Point(81, 30);
            this.chBxProdTabShowBuildings.Name = "chBxProdTabShowBuildings";
            this.chBxProdTabShowBuildings.Size = new System.Drawing.Size(68, 17);
            this.chBxProdTabShowBuildings.TabIndex = 1;
            this.chBxProdTabShowBuildings.Text = "Buildings";
            this.chBxProdTabShowBuildings.UseVisualStyleBackColor = true;
            this.chBxProdTabShowBuildings.CheckedChanged += new System.EventHandler(this.chBxProdTabShowBuildings_CheckedChanged);
            // 
            // chBxProdTabShowUnits
            // 
            this.chBxProdTabShowUnits.AutoSize = true;
            this.chBxProdTabShowUnits.LanguageFile = "";
            this.chBxProdTabShowUnits.Location = new System.Drawing.Point(14, 30);
            this.chBxProdTabShowUnits.Name = "chBxProdTabShowUnits";
            this.chBxProdTabShowUnits.Size = new System.Drawing.Size(50, 17);
            this.chBxProdTabShowUnits.TabIndex = 0;
            this.chBxProdTabShowUnits.Text = "Units";
            this.chBxProdTabShowUnits.UseVisualStyleBackColor = true;
            this.chBxProdTabShowUnits.CheckedChanged += new System.EventHandler(this.chBxProdTabShowUnits_CheckedChanged);
            // 
            // gbProdPicture
            // 
            this.gbProdPicture.Controls.Add(this.lblProdPicturePreview);
            this.gbProdPicture.Controls.Add(this.pcBxProductionTabPreview);
            this.gbProdPicture.Controls.Add(this.txtProductionTabPictureSize);
            this.gbProdPicture.Controls.Add(this.lblProdPictureSize);
            this.gbProdPicture.LanguageFile = "";
            this.gbProdPicture.Location = new System.Drawing.Point(590, 189);
            this.gbProdPicture.Name = "gbProdPicture";
            this.gbProdPicture.Size = new System.Drawing.Size(196, 128);
            this.gbProdPicture.TabIndex = 62;
            this.gbProdPicture.TabStop = false;
            this.gbProdPicture.Text = "Picturesize";
            // 
            // lblProdPicturePreview
            // 
            this.lblProdPicturePreview.AutoSize = true;
            this.lblProdPicturePreview.LanguageFile = "";
            this.lblProdPicturePreview.Location = new System.Drawing.Point(12, 60);
            this.lblProdPicturePreview.Name = "lblProdPicturePreview";
            this.lblProdPicturePreview.Size = new System.Drawing.Size(48, 13);
            this.lblProdPicturePreview.TabIndex = 3;
            this.lblProdPicturePreview.Text = "Preview:";
            // 
            // pcBxProductionTabPreview
            // 
            this.pcBxProductionTabPreview.DrawingFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pcBxProductionTabPreview.DrawingPoint = ((System.Drawing.PointF)(resources.GetObject("pcBxProductionTabPreview.DrawingPoint")));
            this.pcBxProductionTabPreview.DrawingText = "";
            this.pcBxProductionTabPreview.Image = global::AnotherSc2Hack.Properties.Resources.tu_Mule;
            this.pcBxProductionTabPreview.Location = new System.Drawing.Point(89, 53);
            this.pcBxProductionTabPreview.Name = "pcBxProductionTabPreview";
            this.pcBxProductionTabPreview.Size = new System.Drawing.Size(45, 45);
            this.pcBxProductionTabPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcBxProductionTabPreview.TabIndex = 2;
            this.pcBxProductionTabPreview.TabStop = false;
            // 
            // txtProductionTabPictureSize
            // 
            this.txtProductionTabPictureSize.Location = new System.Drawing.Point(89, 27);
            this.txtProductionTabPictureSize.Name = "txtProductionTabPictureSize";
            this.txtProductionTabPictureSize.Size = new System.Drawing.Size(83, 20);
            this.txtProductionTabPictureSize.TabIndex = 1;
            this.txtProductionTabPictureSize.TextChanged += new System.EventHandler(this.txtProdPictureSize_TextChanged);
            // 
            // lblProdPictureSize
            // 
            this.lblProdPictureSize.AutoSize = true;
            this.lblProdPictureSize.LanguageFile = "";
            this.lblProdPictureSize.Location = new System.Drawing.Point(12, 30);
            this.lblProdPictureSize.Name = "lblProdPictureSize";
            this.lblProdPictureSize.Size = new System.Drawing.Size(50, 13);
            this.lblProdPictureSize.TabIndex = 0;
            this.lblProdPictureSize.Text = "Size (px):";
            // 
            // ProductionTabInformation
            // 
            this.ProductionTabInformation.Location = new System.Drawing.Point(590, 18);
            this.ProductionTabInformation.Name = "ProductionTabInformation";
            this.ProductionTabInformation.Size = new System.Drawing.Size(196, 156);
            this.ProductionTabInformation.TabIndex = 3;
            // 
            // ProductionTabHotkeys
            // 
            this.ProductionTabHotkeys.Location = new System.Drawing.Point(331, 219);
            this.ProductionTabHotkeys.Name = "ProductionTabHotkeys";
            this.ProductionTabHotkeys.Size = new System.Drawing.Size(246, 128);
            this.ProductionTabHotkeys.TabIndex = 2;
            // 
            // ProductionTabChatInput
            // 
            this.ProductionTabChatInput.Location = new System.Drawing.Point(331, 18);
            this.ProductionTabChatInput.Name = "ProductionTabChatInput";
            this.ProductionTabChatInput.Size = new System.Drawing.Size(246, 120);
            this.ProductionTabChatInput.TabIndex = 1;
            // 
            // ProductionTabBasics
            // 
            this.ProductionTabBasics.Location = new System.Drawing.Point(30, 18);
            this.ProductionTabBasics.Name = "ProductionTabBasics";
            this.ProductionTabBasics.Size = new System.Drawing.Size(291, 367);
            this.ProductionTabBasics.TabIndex = 0;
            // 
            // tcWorkerAutomation
            // 
            this.tcWorkerAutomation.AutoScroll = true;
            this.tcWorkerAutomation.BackColor = System.Drawing.SystemColors.Control;
            this.tcWorkerAutomation.Controls.Add(this.workerProductionBasics);
            this.tcWorkerAutomation.Controls.Add(this.workerProductionHotkeys);
            this.tcWorkerAutomation.Location = new System.Drawing.Point(4, 22);
            this.tcWorkerAutomation.Name = "tcWorkerAutomation";
            this.tcWorkerAutomation.Size = new System.Drawing.Size(940, 405);
            this.tcWorkerAutomation.TabIndex = 15;
            this.tcWorkerAutomation.Text = "Worker Production";
            // 
            // workerProductionBasics
            // 
            this.workerProductionBasics.Location = new System.Drawing.Point(30, 18);
            this.workerProductionBasics.Name = "workerProductionBasics";
            this.workerProductionBasics.Size = new System.Drawing.Size(527, 273);
            this.workerProductionBasics.TabIndex = 3;
            // 
            // workerProductionHotkeys
            // 
            this.workerProductionHotkeys.Location = new System.Drawing.Point(563, 18);
            this.workerProductionHotkeys.Name = "workerProductionHotkeys";
            this.workerProductionHotkeys.Size = new System.Drawing.Size(246, 128);
            this.workerProductionHotkeys.TabIndex = 1;
            // 
            // tcVarious
            // 
            this.tcVarious.BackColor = System.Drawing.SystemColors.Control;
            this.tcVarious.Controls.Add(this.Custom_Various);
            this.tcVarious.Location = new System.Drawing.Point(4, 22);
            this.tcVarious.Name = "tcVarious";
            this.tcVarious.Size = new System.Drawing.Size(940, 405);
            this.tcVarious.TabIndex = 14;
            this.tcVarious.Text = "Various";
            // 
            // Custom_Various
            // 
            this.Custom_Various.Location = new System.Drawing.Point(30, 18);
            this.Custom_Various.Name = "Custom_Various";
            this.Custom_Various.Size = new System.Drawing.Size(310, 170);
            this.Custom_Various.TabIndex = 0;
            // 
            // tcBugs
            // 
            this.tcBugs.BackColor = System.Drawing.SystemColors.Control;
            this.tcBugs.Controls.Add(this.CustBugs);
            this.tcBugs.Location = new System.Drawing.Point(4, 22);
            this.tcBugs.Name = "tcBugs";
            this.tcBugs.Size = new System.Drawing.Size(940, 405);
            this.tcBugs.TabIndex = 9;
            this.tcBugs.Text = "Bugs";
            // 
            // CustBugs
            // 
            this.CustBugs.Location = new System.Drawing.Point(30, 18);
            this.CustBugs.Name = "CustBugs";
            this.CustBugs.Size = new System.Drawing.Size(669, 392);
            this.CustBugs.TabIndex = 0;
            // 
            // tcCredits
            // 
            this.tcCredits.BackColor = System.Drawing.SystemColors.Control;
            this.tcCredits.Controls.Add(this.label92);
            this.tcCredits.Location = new System.Drawing.Point(4, 22);
            this.tcCredits.Name = "tcCredits";
            this.tcCredits.Size = new System.Drawing.Size(940, 405);
            this.tcCredits.TabIndex = 8;
            this.tcCredits.Text = "Credits";
            this.tcCredits.Paint += new System.Windows.Forms.PaintEventHandler(this.tcCredits_Paint);
            // 
            // label92
            // 
            this.label92.AutoSize = true;
            this.label92.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label92.Location = new System.Drawing.Point(369, 16);
            this.label92.Name = "label92";
            this.label92.Size = new System.Drawing.Size(174, 24);
            this.label92.TabIndex = 0;
            this.label92.Text = "Special thanks to:";
            // 
            // tcBenchmark
            // 
            this.tcBenchmark.BackColor = System.Drawing.SystemColors.Control;
            this.tcBenchmark.Controls.Add(this.GlobalBenchmark);
            this.tcBenchmark.Location = new System.Drawing.Point(4, 22);
            this.tcBenchmark.Name = "tcBenchmark";
            this.tcBenchmark.Size = new System.Drawing.Size(940, 405);
            this.tcBenchmark.TabIndex = 12;
            this.tcBenchmark.Text = "Benchmark";
            // 
            // GlobalBenchmark
            // 
            this.GlobalBenchmark.Location = new System.Drawing.Point(5, 3);
            this.GlobalBenchmark.Name = "GlobalBenchmark";
            this.GlobalBenchmark.Size = new System.Drawing.Size(390, 309);
            this.GlobalBenchmark.TabIndex = 0;
            // 
            // tcDebug
            // 
            this.tcDebug.BackColor = System.Drawing.SystemColors.Control;
            this.tcDebug.Controls.Add(this.CustDebug);
            this.tcDebug.Location = new System.Drawing.Point(4, 22);
            this.tcDebug.Name = "tcDebug";
            this.tcDebug.Size = new System.Drawing.Size(940, 405);
            this.tcDebug.TabIndex = 11;
            this.tcDebug.Text = "Debug";
            // 
            // CustDebug
            // 
            this.CustDebug.Location = new System.Drawing.Point(0, 0);
            this.CustDebug.Name = "CustDebug";
            this.CustDebug.Size = new System.Drawing.Size(902, 445);
            this.CustDebug.TabIndex = 0;
            // 
            // btnProduction
            // 
            this.btnProduction.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnProduction.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProduction.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProduction.Location = new System.Drawing.Point(579, 449);
            this.btnProduction.Name = "btnProduction";
            this.btnProduction.Size = new System.Drawing.Size(78, 23);
            this.btnProduction.TabIndex = 7;
            this.btnProduction.Text = "Production";
            this.btnProduction.UseVisualStyleBackColor = true;
            this.btnProduction.Click += new System.EventHandler(this.btnProduction_Click);
            // 
            // btnLostUnits
            // 
            this.btnLostUnits.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnLostUnits.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLostUnits.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLostUnits.Location = new System.Drawing.Point(663, 449);
            this.btnLostUnits.Name = "btnLostUnits";
            this.btnLostUnits.Size = new System.Drawing.Size(78, 23);
            this.btnLostUnits.TabIndex = 8;
            this.btnLostUnits.Text = "Lost Units";
            this.btnLostUnits.UseVisualStyleBackColor = true;
            this.btnLostUnits.Visible = false;
            this.btnLostUnits.Click += new System.EventHandler(this.btnLostUnits_Click);
            // 
            // btnChangeBorderstyle
            // 
            this.btnChangeBorderstyle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnChangeBorderstyle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChangeBorderstyle.Location = new System.Drawing.Point(865, 449);
            this.btnChangeBorderstyle.Name = "btnChangeBorderstyle";
            this.btnChangeBorderstyle.Size = new System.Drawing.Size(95, 23);
            this.btnChangeBorderstyle.TabIndex = 27;
            this.btnChangeBorderstyle.Text = "Adjust Panels";
            this.btnChangeBorderstyle.UseVisualStyleBackColor = true;
            this.btnChangeBorderstyle.Click += new System.EventHandler(this.btnChangeBorderstyle_Click);
            // 
            // ttInformation
            // 
            this.ttInformation.AutomaticDelay = 1;
            this.ttInformation.ForeColor = System.Drawing.SystemColors.Desktop;
            this.ttInformation.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            // 
            // MainHandler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(972, 484);
            this.Controls.Add(this.btnChangeBorderstyle);
            this.Controls.Add(this.btnLostUnits);
            this.Controls.Add(this.btnProduction);
            this.Controls.Add(this.tcMainTab);
            this.Controls.Add(this.btnWorker);
            this.Controls.Add(this.btnApm);
            this.Controls.Add(this.btnArmy);
            this.Controls.Add(this.btnIncome);
            this.Controls.Add(this.btnResources);
            this.Controls.Add(this.btnUnit);
            this.Controls.Add(this.btnMaphack);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainHandler";
            this.Text = "MainHandler";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainHandler_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainHandler_FormClosed);
            this.Load += new System.EventHandler(this.MainHandler_Load);
            this.tcMainTab.ResumeLayout(false);
            this.tcGlobal.ResumeLayout(false);
            this.tcResources.ResumeLayout(false);
            this.tcIncome.ResumeLayout(false);
            this.tcWorker.ResumeLayout(false);
            this.tcMaphack.ResumeLayout(false);
            this.gbMaphackColorUnits.ResumeLayout(false);
            this.cmsListboxContext.ResumeLayout(false);
            this.tcApm.ResumeLayout(false);
            this.tcArmy.ResumeLayout(false);
            this.tcUnitTab.ResumeLayout(false);
            this.gbUnittabShow.ResumeLayout(false);
            this.gbUnittabShow.PerformLayout();
            this.gbUnitPicture.ResumeLayout(false);
            this.gbUnitPicture.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcBxUnitPreview)).EndInit();
            this.tcProduction.ResumeLayout(false);
            this.gbProdtabShow.ResumeLayout(false);
            this.gbProdtabShow.PerformLayout();
            this.gbProdPicture.ResumeLayout(false);
            this.gbProdPicture.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcBxProductionTabPreview)).EndInit();
            this.tcWorkerAutomation.ResumeLayout(false);
            this.tcVarious.ResumeLayout(false);
            this.tcBugs.ResumeLayout(false);
            this.tcCredits.ResumeLayout(false);
            this.tcCredits.PerformLayout();
            this.tcBenchmark.ResumeLayout(false);
            this.tcDebug.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer tmrGatherInformation;
        private System.Windows.Forms.TabControl tcMainTab;
        private System.Windows.Forms.TabPage tcGlobal;
        private System.Windows.Forms.TabPage tcResources;
        private System.Windows.Forms.TabPage tcIncome;
        private System.Windows.Forms.TabPage tcWorker;
        private System.Windows.Forms.TabPage tcMaphack;
        private System.Windows.Forms.TabPage tcApm;
        private System.Windows.Forms.TabPage tcArmy;
        private System.Windows.Forms.TabPage tcUnitTab;
        private System.Windows.Forms.ImageList imgUnits;
        private System.Windows.Forms.TabPage tcCredits;
        private System.Windows.Forms.Label label92;
        private System.Windows.Forms.TabPage tcBugs;
        private System.Windows.Forms.TabPage tcDebug;
        private LanguageGroupbox gbMaphackColorUnits;
        private LanguageButton btnMapAddUnit;
        private System.Windows.Forms.Button btnMapUnitColor;
        private ImageCombobox icbMapUnit;
        private System.Windows.Forms.ListBox lstMapUnits;
        private LanguageGroupbox gbUnitPicture;
        private LanguageLabel lblUnitPictureSize;
        private LanguageLabel lblUnitPicturePreview;
        private CustomPictureBox pcBxUnitPreview;

        public System.Windows.Forms.Button btnMaphack;
        public System.Windows.Forms.Button btnUnit;
        public System.Windows.Forms.Button btnResources;
        public System.Windows.Forms.Button btnIncome;
        public System.Windows.Forms.Button btnApm;
        public System.Windows.Forms.Button btnArmy;
        public System.Windows.Forms.Button btnWorker;
        public System.Windows.Forms.Button btnProduction;

        public System.Windows.Forms.TextBox txtUnitPictureSize;
        public System.Windows.Forms.TabPage tcBenchmark;
        public Benchmark GlobalBenchmark;
        public Information UnittabInformation;
        public Information ResourceInformation;
        public Information IncomeInformation;
        public Information WorkerInformation;
        public Information MaphackInformation;
        public Information ApmInformation;
        public Information ArmyInformation;
        public Hotkeys ResourceHotkeys;
        public Hotkeys IncomeHotkeys;
        public Hotkeys WorkerHotkeys;
        public Hotkeys MaphackHotkeys;
        public Hotkeys ApmHotkeys;
        public Hotkeys ArmyHotkeys;
        public Hotkeys UnittabHotkeys;
        public ChatInput UnittabChatInput;
        public ChatInput ResourceChatInput;
        public ChatInput IncomeChatInput;
        public ChatInput WorkerChatInput;
        public ChatInput MaphackChatInput;
        public ChatInput ApmChatInput;
        public ChatInput ArmyChatInput;
        public Basics ResourceBasics;
        public Basics IncomeBasics;
        public Basics ApmBasics;
        public Basics ArmyBasics;
        public BasicsWor WorkerBasics;
        public BasicsMap MaphackBasics;
        public BasicsUnitTab UnittabBasics;
        public ControlBugs CustBugs;
        private CustomDebug CustDebug;
        private System.Windows.Forms.TabPage tcProduction;
        private LanguageGroupbox gbProdPicture;
        private LanguageLabel lblProdPicturePreview;
        private CustomPictureBox pcBxProductionTabPreview;
        public System.Windows.Forms.TextBox txtProductionTabPictureSize;
        private LanguageLabel lblProdPictureSize;
        public Information ProductionTabInformation;
        public Hotkeys ProductionTabHotkeys;
        public ChatInput ProductionTabChatInput;
        public BasicsProdTab ProductionTabBasics;
        public System.Windows.Forms.Button btnLostUnits;
        private System.Windows.Forms.TabPage tcVarious;
        private CustomVarious Custom_Various;
        internal ControlGlobal CustGlobal;
        public System.Windows.Forms.Button btnChangeBorderstyle;
        private System.Windows.Forms.ContextMenuStrip cmsListboxContext;
        private System.Windows.Forms.ToolStripMenuItem addAUnitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteAUnitToolStripMenuItem;
        private AutomationWorker workerProductionBasics;
        public Hotkeys workerProductionHotkeys;
        private System.Windows.Forms.TabPage tcWorkerAutomation;
        private LanguageGroupbox gbUnittabShow;
        private LanguageCheckbox chBxUnitTabShowBuildings;
        private LanguageCheckbox chBxUnitTabShowUnits;
        private LanguageGroupbox gbProdtabShow;
        private LanguageCheckbox chBxProdTabShowUpgrades;
        private LanguageCheckbox chBxProdTabShowBuildings;
        private LanguageCheckbox chBxProdTabShowUnits;
        private System.Windows.Forms.Button btnMaphackDefineaMarking;
        private System.Windows.Forms.ToolTip ttInformation;
    }
}