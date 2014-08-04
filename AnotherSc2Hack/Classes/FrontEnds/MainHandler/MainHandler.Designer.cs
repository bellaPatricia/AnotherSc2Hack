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
            this.ResourceUiBasics = new AnotherSc2Hack.Classes.FrontEnds.UiBasics();
            this.ResourceUiChatInput = new AnotherSc2Hack.Classes.FrontEnds.UiChatInput();
            this.ResourceUiHotkeys = new AnotherSc2Hack.Classes.FrontEnds.UiHotkeys();
            this.ResourceUiInformation = new AnotherSc2Hack.Classes.FrontEnds.UiInformation();
            this.tcIncome = new System.Windows.Forms.TabPage();
            this.IncomeUiBasics = new AnotherSc2Hack.Classes.FrontEnds.UiBasics();
            this.IncomeUiChatInput = new AnotherSc2Hack.Classes.FrontEnds.UiChatInput();
            this.IncomeUiHotkeys = new AnotherSc2Hack.Classes.FrontEnds.UiHotkeys();
            this.IncomeUiInformation = new AnotherSc2Hack.Classes.FrontEnds.UiInformation();
            this.tcWorker = new System.Windows.Forms.TabPage();
            this.WorkerUiWorkerBasics = new AnotherSc2Hack.Classes.FrontEnds.UiWorkerBasics();
            this.WorkerUiChatInput = new AnotherSc2Hack.Classes.FrontEnds.UiChatInput();
            this.WorkerUiHotkeys = new AnotherSc2Hack.Classes.FrontEnds.UiHotkeys();
            this.WorkerUiInformation = new AnotherSc2Hack.Classes.FrontEnds.UiInformation();
            this.tcMaphack = new System.Windows.Forms.TabPage();
            this.MaphackUiMaphackBasics = new AnotherSc2Hack.Classes.FrontEnds.UiMaphackBasics();
            this.MaphackUiChatInput = new AnotherSc2Hack.Classes.FrontEnds.UiChatInput();
            this.MaphackUiHotkeys = new AnotherSc2Hack.Classes.FrontEnds.UiHotkeys();
            this.MaphackUiInformation = new AnotherSc2Hack.Classes.FrontEnds.UiInformation();
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
            this.ApmUiBasics = new AnotherSc2Hack.Classes.FrontEnds.UiBasics();
            this.ApmUiChatInput = new AnotherSc2Hack.Classes.FrontEnds.UiChatInput();
            this.ApmUiHotkeys = new AnotherSc2Hack.Classes.FrontEnds.UiHotkeys();
            this.ApmUiInformation = new AnotherSc2Hack.Classes.FrontEnds.UiInformation();
            this.tcArmy = new System.Windows.Forms.TabPage();
            this.ArmyUiBasics = new AnotherSc2Hack.Classes.FrontEnds.UiBasics();
            this.ArmyUiChatInput = new AnotherSc2Hack.Classes.FrontEnds.UiChatInput();
            this.ArmyUiHotkeys = new AnotherSc2Hack.Classes.FrontEnds.UiHotkeys();
            this.ArmyUiInformation = new AnotherSc2Hack.Classes.FrontEnds.UiInformation();
            this.tcUnitTab = new System.Windows.Forms.TabPage();
            this.gbUnittabShow = new AnotherSc2Hack.Classes.FrontEnds.LanguageGroupbox();
            this.chBxUnitTabShowBuildings = new AnotherSc2Hack.Classes.FrontEnds.LanguageCheckbox();
            this.chBxUnitTabShowUnits = new AnotherSc2Hack.Classes.FrontEnds.LanguageCheckbox();
            this.UnittabUiUnitTabBasic = new AnotherSc2Hack.Classes.FrontEnds.UiUnitTabBasic();
            this.UnittabUiChatInput = new AnotherSc2Hack.Classes.FrontEnds.UiChatInput();
            this.UnittabUiHotkeys = new AnotherSc2Hack.Classes.FrontEnds.UiHotkeys();
            this.UnittabUiInformation = new AnotherSc2Hack.Classes.FrontEnds.UiInformation();
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
            this.ProductionTabUiInformation = new AnotherSc2Hack.Classes.FrontEnds.UiInformation();
            this.ProductionTabUiHotkeys = new AnotherSc2Hack.Classes.FrontEnds.UiHotkeys();
            this.ProductionTabUiChatInput = new AnotherSc2Hack.Classes.FrontEnds.UiChatInput();
            this.ProductionTabUiProductionTabBasics = new AnotherSc2Hack.Classes.FrontEnds.UiProductionTabBasics();
            this.tcWorkerAutomation = new System.Windows.Forms.TabPage();
            this.workerProductionBasics = new AnotherSc2Hack.Classes.FrontEnds.AutomationWorker();
            this.WorkerProductionUiHotkeys = new AnotherSc2Hack.Classes.FrontEnds.UiHotkeys();
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
            resources.ApplyResources(this.btnMaphack, "btnMaphack");
            this.btnMaphack.Name = "btnMaphack";
            this.ttInformation.SetToolTip(this.btnMaphack, resources.GetString("btnMaphack.ToolTip"));
            this.btnMaphack.UseVisualStyleBackColor = true;
            this.btnMaphack.Click += new System.EventHandler(this.btnMaphack_Click);
            // 
            // btnUnit
            // 
            resources.ApplyResources(this.btnUnit, "btnUnit");
            this.btnUnit.Name = "btnUnit";
            this.ttInformation.SetToolTip(this.btnUnit, resources.GetString("btnUnit.ToolTip"));
            this.btnUnit.UseVisualStyleBackColor = true;
            this.btnUnit.Click += new System.EventHandler(this.btnUnit_Click);
            // 
            // btnResources
            // 
            resources.ApplyResources(this.btnResources, "btnResources");
            this.btnResources.Name = "btnResources";
            this.ttInformation.SetToolTip(this.btnResources, resources.GetString("btnResources.ToolTip"));
            this.btnResources.UseVisualStyleBackColor = true;
            this.btnResources.Click += new System.EventHandler(this.btnResources_Click);
            // 
            // btnIncome
            // 
            resources.ApplyResources(this.btnIncome, "btnIncome");
            this.btnIncome.Name = "btnIncome";
            this.ttInformation.SetToolTip(this.btnIncome, resources.GetString("btnIncome.ToolTip"));
            this.btnIncome.UseVisualStyleBackColor = true;
            this.btnIncome.Click += new System.EventHandler(this.btnIncome_Click);
            // 
            // btnApm
            // 
            resources.ApplyResources(this.btnApm, "btnApm");
            this.btnApm.Name = "btnApm";
            this.ttInformation.SetToolTip(this.btnApm, resources.GetString("btnApm.ToolTip"));
            this.btnApm.UseVisualStyleBackColor = true;
            this.btnApm.Click += new System.EventHandler(this.btnApm_Click);
            // 
            // btnArmy
            // 
            resources.ApplyResources(this.btnArmy, "btnArmy");
            this.btnArmy.Name = "btnArmy";
            this.ttInformation.SetToolTip(this.btnArmy, resources.GetString("btnArmy.ToolTip"));
            this.btnArmy.UseVisualStyleBackColor = true;
            this.btnArmy.Click += new System.EventHandler(this.btnArmy_Click);
            // 
            // btnWorker
            // 
            resources.ApplyResources(this.btnWorker, "btnWorker");
            this.btnWorker.Name = "btnWorker";
            this.ttInformation.SetToolTip(this.btnWorker, resources.GetString("btnWorker.ToolTip"));
            this.btnWorker.UseVisualStyleBackColor = true;
            this.btnWorker.Click += new System.EventHandler(this.btnWorker_Click);
            // 
            // tcMainTab
            // 
            resources.ApplyResources(this.tcMainTab, "tcMainTab");
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
            this.tcMainTab.Name = "tcMainTab";
            this.tcMainTab.SelectedIndex = 0;
            this.ttInformation.SetToolTip(this.tcMainTab, resources.GetString("tcMainTab.ToolTip"));
            this.tcMainTab.SelectedIndexChanged += new System.EventHandler(this.tcMainTab_SelectedIndexChanged);
            // 
            // tcGlobal
            // 
            resources.ApplyResources(this.tcGlobal, "tcGlobal");
            this.tcGlobal.BackColor = System.Drawing.SystemColors.Control;
            this.tcGlobal.Controls.Add(this.CustGlobal);
            this.tcGlobal.Name = "tcGlobal";
            this.ttInformation.SetToolTip(this.tcGlobal, resources.GetString("tcGlobal.ToolTip"));
            // 
            // CustGlobal
            // 
            resources.ApplyResources(this.CustGlobal, "CustGlobal");
            this.CustGlobal.Name = "CustGlobal";
            this.ttInformation.SetToolTip(this.CustGlobal, resources.GetString("CustGlobal.ToolTip"));
            // 
            // tcResources
            // 
            resources.ApplyResources(this.tcResources, "tcResources");
            this.tcResources.BackColor = System.Drawing.SystemColors.Control;
            this.tcResources.Controls.Add(this.ResourceUiBasics);
            this.tcResources.Controls.Add(this.ResourceUiChatInput);
            this.tcResources.Controls.Add(this.ResourceUiHotkeys);
            this.tcResources.Controls.Add(this.ResourceUiInformation);
            this.tcResources.Name = "tcResources";
            this.ttInformation.SetToolTip(this.tcResources, resources.GetString("tcResources.ToolTip"));
            // 
            // ResourceUiBasics
            // 
            resources.ApplyResources(this.ResourceUiBasics, "ResourceUiBasics");
            this.ResourceUiBasics.Name = "ResourceUiBasics";
            this.ttInformation.SetToolTip(this.ResourceUiBasics, resources.GetString("ResourceUiBasics.ToolTip"));
            // 
            // ResourceUiChatInput
            // 
            resources.ApplyResources(this.ResourceUiChatInput, "ResourceUiChatInput");
            this.ResourceUiChatInput.Name = "ResourceUiChatInput";
            this.ttInformation.SetToolTip(this.ResourceUiChatInput, resources.GetString("ResourceUiChatInput.ToolTip"));
            // 
            // ResourceUiHotkeys
            // 
            resources.ApplyResources(this.ResourceUiHotkeys, "ResourceUiHotkeys");
            this.ResourceUiHotkeys.Name = "ResourceUiHotkeys";
            this.ttInformation.SetToolTip(this.ResourceUiHotkeys, resources.GetString("ResourceUiHotkeys.ToolTip"));
            // 
            // ResourceUiInformation
            // 
            resources.ApplyResources(this.ResourceUiInformation, "ResourceUiInformation");
            this.ResourceUiInformation.Name = "ResourceUiInformation";
            this.ttInformation.SetToolTip(this.ResourceUiInformation, resources.GetString("ResourceUiInformation.ToolTip"));
            // 
            // tcIncome
            // 
            resources.ApplyResources(this.tcIncome, "tcIncome");
            this.tcIncome.BackColor = System.Drawing.SystemColors.Control;
            this.tcIncome.Controls.Add(this.IncomeUiBasics);
            this.tcIncome.Controls.Add(this.IncomeUiChatInput);
            this.tcIncome.Controls.Add(this.IncomeUiHotkeys);
            this.tcIncome.Controls.Add(this.IncomeUiInformation);
            this.tcIncome.Name = "tcIncome";
            this.ttInformation.SetToolTip(this.tcIncome, resources.GetString("tcIncome.ToolTip"));
            // 
            // IncomeUiBasics
            // 
            resources.ApplyResources(this.IncomeUiBasics, "IncomeUiBasics");
            this.IncomeUiBasics.Name = "IncomeUiBasics";
            this.ttInformation.SetToolTip(this.IncomeUiBasics, resources.GetString("IncomeUiBasics.ToolTip"));
            // 
            // IncomeUiChatInput
            // 
            resources.ApplyResources(this.IncomeUiChatInput, "IncomeUiChatInput");
            this.IncomeUiChatInput.Name = "IncomeUiChatInput";
            this.ttInformation.SetToolTip(this.IncomeUiChatInput, resources.GetString("IncomeUiChatInput.ToolTip"));
            // 
            // IncomeUiHotkeys
            // 
            resources.ApplyResources(this.IncomeUiHotkeys, "IncomeUiHotkeys");
            this.IncomeUiHotkeys.Name = "IncomeUiHotkeys";
            this.ttInformation.SetToolTip(this.IncomeUiHotkeys, resources.GetString("IncomeUiHotkeys.ToolTip"));
            // 
            // IncomeUiInformation
            // 
            resources.ApplyResources(this.IncomeUiInformation, "IncomeUiInformation");
            this.IncomeUiInformation.Name = "IncomeUiInformation";
            this.ttInformation.SetToolTip(this.IncomeUiInformation, resources.GetString("IncomeUiInformation.ToolTip"));
            // 
            // tcWorker
            // 
            resources.ApplyResources(this.tcWorker, "tcWorker");
            this.tcWorker.BackColor = System.Drawing.SystemColors.Control;
            this.tcWorker.Controls.Add(this.WorkerUiWorkerBasics);
            this.tcWorker.Controls.Add(this.WorkerUiChatInput);
            this.tcWorker.Controls.Add(this.WorkerUiHotkeys);
            this.tcWorker.Controls.Add(this.WorkerUiInformation);
            this.tcWorker.Name = "tcWorker";
            this.ttInformation.SetToolTip(this.tcWorker, resources.GetString("tcWorker.ToolTip"));
            // 
            // WorkerUiWorkerBasics
            // 
            resources.ApplyResources(this.WorkerUiWorkerBasics, "WorkerUiWorkerBasics");
            this.WorkerUiWorkerBasics.Name = "WorkerUiWorkerBasics";
            this.ttInformation.SetToolTip(this.WorkerUiWorkerBasics, resources.GetString("WorkerUiWorkerBasics.ToolTip"));
            // 
            // WorkerUiChatInput
            // 
            resources.ApplyResources(this.WorkerUiChatInput, "WorkerUiChatInput");
            this.WorkerUiChatInput.Name = "WorkerUiChatInput";
            this.ttInformation.SetToolTip(this.WorkerUiChatInput, resources.GetString("WorkerUiChatInput.ToolTip"));
            // 
            // WorkerUiHotkeys
            // 
            resources.ApplyResources(this.WorkerUiHotkeys, "WorkerUiHotkeys");
            this.WorkerUiHotkeys.Name = "WorkerUiHotkeys";
            this.ttInformation.SetToolTip(this.WorkerUiHotkeys, resources.GetString("WorkerUiHotkeys.ToolTip"));
            // 
            // WorkerUiInformation
            // 
            resources.ApplyResources(this.WorkerUiInformation, "WorkerUiInformation");
            this.WorkerUiInformation.Name = "WorkerUiInformation";
            this.ttInformation.SetToolTip(this.WorkerUiInformation, resources.GetString("WorkerUiInformation.ToolTip"));
            // 
            // tcMaphack
            // 
            resources.ApplyResources(this.tcMaphack, "tcMaphack");
            this.tcMaphack.BackColor = System.Drawing.SystemColors.Control;
            this.tcMaphack.Controls.Add(this.MaphackUiMaphackBasics);
            this.tcMaphack.Controls.Add(this.MaphackUiChatInput);
            this.tcMaphack.Controls.Add(this.MaphackUiHotkeys);
            this.tcMaphack.Controls.Add(this.MaphackUiInformation);
            this.tcMaphack.Controls.Add(this.gbMaphackColorUnits);
            this.tcMaphack.Name = "tcMaphack";
            this.ttInformation.SetToolTip(this.tcMaphack, resources.GetString("tcMaphack.ToolTip"));
            // 
            // MaphackUiMaphackBasics
            // 
            resources.ApplyResources(this.MaphackUiMaphackBasics, "MaphackUiMaphackBasics");
            this.MaphackUiMaphackBasics.Name = "MaphackUiMaphackBasics";
            this.ttInformation.SetToolTip(this.MaphackUiMaphackBasics, resources.GetString("MaphackUiMaphackBasics.ToolTip"));
            // 
            // MaphackUiChatInput
            // 
            resources.ApplyResources(this.MaphackUiChatInput, "MaphackUiChatInput");
            this.MaphackUiChatInput.Name = "MaphackUiChatInput";
            this.ttInformation.SetToolTip(this.MaphackUiChatInput, resources.GetString("MaphackUiChatInput.ToolTip"));
            // 
            // MaphackUiHotkeys
            // 
            resources.ApplyResources(this.MaphackUiHotkeys, "MaphackUiHotkeys");
            this.MaphackUiHotkeys.Name = "MaphackUiHotkeys";
            this.ttInformation.SetToolTip(this.MaphackUiHotkeys, resources.GetString("MaphackUiHotkeys.ToolTip"));
            // 
            // MaphackUiInformation
            // 
            resources.ApplyResources(this.MaphackUiInformation, "MaphackUiInformation");
            this.MaphackUiInformation.Name = "MaphackUiInformation";
            this.ttInformation.SetToolTip(this.MaphackUiInformation, resources.GetString("MaphackUiInformation.ToolTip"));
            // 
            // gbMaphackColorUnits
            // 
            resources.ApplyResources(this.gbMaphackColorUnits, "gbMaphackColorUnits");
            this.gbMaphackColorUnits.Controls.Add(this.btnMaphackDefineaMarking);
            this.gbMaphackColorUnits.Controls.Add(this.btnMapUnitColor);
            this.gbMaphackColorUnits.Controls.Add(this.btnMapAddUnit);
            this.gbMaphackColorUnits.Controls.Add(this.icbMapUnit);
            this.gbMaphackColorUnits.Controls.Add(this.lstMapUnits);
            this.gbMaphackColorUnits.LanguageFile = "";
            this.gbMaphackColorUnits.Name = "gbMaphackColorUnits";
            this.gbMaphackColorUnits.TabStop = false;
            this.ttInformation.SetToolTip(this.gbMaphackColorUnits, resources.GetString("gbMaphackColorUnits.ToolTip"));
            // 
            // btnMaphackDefineaMarking
            // 
            resources.ApplyResources(this.btnMaphackDefineaMarking, "btnMaphackDefineaMarking");
            this.btnMaphackDefineaMarking.Name = "btnMaphackDefineaMarking";
            this.ttInformation.SetToolTip(this.btnMaphackDefineaMarking, resources.GetString("btnMaphackDefineaMarking.ToolTip"));
            this.btnMaphackDefineaMarking.UseVisualStyleBackColor = true;
            this.btnMaphackDefineaMarking.Click += new System.EventHandler(this.btnMaphackDefineaMarking_Click);
            // 
            // btnMapUnitColor
            // 
            resources.ApplyResources(this.btnMapUnitColor, "btnMapUnitColor");
            this.btnMapUnitColor.Name = "btnMapUnitColor";
            this.ttInformation.SetToolTip(this.btnMapUnitColor, resources.GetString("btnMapUnitColor.ToolTip"));
            this.btnMapUnitColor.UseVisualStyleBackColor = true;
            this.btnMapUnitColor.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnMapUnitColor_MouseDown);
            // 
            // btnMapAddUnit
            // 
            resources.ApplyResources(this.btnMapAddUnit, "btnMapAddUnit");
            this.btnMapAddUnit.LanguageFile = "";
            this.btnMapAddUnit.Name = "btnMapAddUnit";
            this.ttInformation.SetToolTip(this.btnMapAddUnit, resources.GetString("btnMapAddUnit.ToolTip"));
            this.btnMapAddUnit.UseVisualStyleBackColor = true;
            this.btnMapAddUnit.Click += new System.EventHandler(this.btnMapAddUnit_Click);
            // 
            // icbMapUnit
            // 
            resources.ApplyResources(this.icbMapUnit, "icbMapUnit");
            this.icbMapUnit.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.icbMapUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.icbMapUnit.FormattingEnabled = true;
            this.icbMapUnit.ImageList = this.imgUnits;
            this.icbMapUnit.Name = "icbMapUnit";
            this.ttInformation.SetToolTip(this.icbMapUnit, resources.GetString("icbMapUnit.ToolTip"));
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
            resources.ApplyResources(this.lstMapUnits, "lstMapUnits");
            this.lstMapUnits.ContextMenuStrip = this.cmsListboxContext;
            this.lstMapUnits.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.lstMapUnits.FormattingEnabled = true;
            this.lstMapUnits.Name = "lstMapUnits";
            this.lstMapUnits.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.ttInformation.SetToolTip(this.lstMapUnits, resources.GetString("lstMapUnits.ToolTip"));
            this.lstMapUnits.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.lstMapUnits_DrawItem);
            this.lstMapUnits.SelectedIndexChanged += new System.EventHandler(this.lstMapUnits_SelectedIndexChanged);
            this.lstMapUnits.KeyUp += new System.Windows.Forms.KeyEventHandler(this.lstMapUnits_KeyUp);
            // 
            // cmsListboxContext
            // 
            resources.ApplyResources(this.cmsListboxContext, "cmsListboxContext");
            this.cmsListboxContext.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addAUnitToolStripMenuItem,
            this.deleteAUnitToolStripMenuItem});
            this.cmsListboxContext.Name = "cmsListboxContext";
            this.ttInformation.SetToolTip(this.cmsListboxContext, resources.GetString("cmsListboxContext.ToolTip"));
            // 
            // addAUnitToolStripMenuItem
            // 
            resources.ApplyResources(this.addAUnitToolStripMenuItem, "addAUnitToolStripMenuItem");
            this.addAUnitToolStripMenuItem.Name = "addAUnitToolStripMenuItem";
            this.addAUnitToolStripMenuItem.Click += new System.EventHandler(this.addAUnitToolStripMenuItem_Click);
            // 
            // deleteAUnitToolStripMenuItem
            // 
            resources.ApplyResources(this.deleteAUnitToolStripMenuItem, "deleteAUnitToolStripMenuItem");
            this.deleteAUnitToolStripMenuItem.Name = "deleteAUnitToolStripMenuItem";
            this.deleteAUnitToolStripMenuItem.Click += new System.EventHandler(this.deleteAUnitToolStripMenuItem_Click);
            // 
            // tcApm
            // 
            resources.ApplyResources(this.tcApm, "tcApm");
            this.tcApm.BackColor = System.Drawing.SystemColors.Control;
            this.tcApm.Controls.Add(this.ApmUiBasics);
            this.tcApm.Controls.Add(this.ApmUiChatInput);
            this.tcApm.Controls.Add(this.ApmUiHotkeys);
            this.tcApm.Controls.Add(this.ApmUiInformation);
            this.tcApm.Name = "tcApm";
            this.ttInformation.SetToolTip(this.tcApm, resources.GetString("tcApm.ToolTip"));
            // 
            // ApmUiBasics
            // 
            resources.ApplyResources(this.ApmUiBasics, "ApmUiBasics");
            this.ApmUiBasics.Name = "ApmUiBasics";
            this.ttInformation.SetToolTip(this.ApmUiBasics, resources.GetString("ApmUiBasics.ToolTip"));
            // 
            // ApmUiChatInput
            // 
            resources.ApplyResources(this.ApmUiChatInput, "ApmUiChatInput");
            this.ApmUiChatInput.Name = "ApmUiChatInput";
            this.ttInformation.SetToolTip(this.ApmUiChatInput, resources.GetString("ApmUiChatInput.ToolTip"));
            // 
            // ApmUiHotkeys
            // 
            resources.ApplyResources(this.ApmUiHotkeys, "ApmUiHotkeys");
            this.ApmUiHotkeys.Name = "ApmUiHotkeys";
            this.ttInformation.SetToolTip(this.ApmUiHotkeys, resources.GetString("ApmUiHotkeys.ToolTip"));
            // 
            // ApmUiInformation
            // 
            resources.ApplyResources(this.ApmUiInformation, "ApmUiInformation");
            this.ApmUiInformation.Name = "ApmUiInformation";
            this.ttInformation.SetToolTip(this.ApmUiInformation, resources.GetString("ApmUiInformation.ToolTip"));
            // 
            // tcArmy
            // 
            resources.ApplyResources(this.tcArmy, "tcArmy");
            this.tcArmy.BackColor = System.Drawing.SystemColors.Control;
            this.tcArmy.Controls.Add(this.ArmyUiBasics);
            this.tcArmy.Controls.Add(this.ArmyUiChatInput);
            this.tcArmy.Controls.Add(this.ArmyUiHotkeys);
            this.tcArmy.Controls.Add(this.ArmyUiInformation);
            this.tcArmy.Name = "tcArmy";
            this.ttInformation.SetToolTip(this.tcArmy, resources.GetString("tcArmy.ToolTip"));
            // 
            // ArmyUiBasics
            // 
            resources.ApplyResources(this.ArmyUiBasics, "ArmyUiBasics");
            this.ArmyUiBasics.Name = "ArmyUiBasics";
            this.ttInformation.SetToolTip(this.ArmyUiBasics, resources.GetString("ArmyUiBasics.ToolTip"));
            // 
            // ArmyUiChatInput
            // 
            resources.ApplyResources(this.ArmyUiChatInput, "ArmyUiChatInput");
            this.ArmyUiChatInput.Name = "ArmyUiChatInput";
            this.ttInformation.SetToolTip(this.ArmyUiChatInput, resources.GetString("ArmyUiChatInput.ToolTip"));
            // 
            // ArmyUiHotkeys
            // 
            resources.ApplyResources(this.ArmyUiHotkeys, "ArmyUiHotkeys");
            this.ArmyUiHotkeys.Name = "ArmyUiHotkeys";
            this.ttInformation.SetToolTip(this.ArmyUiHotkeys, resources.GetString("ArmyUiHotkeys.ToolTip"));
            // 
            // ArmyUiInformation
            // 
            resources.ApplyResources(this.ArmyUiInformation, "ArmyUiInformation");
            this.ArmyUiInformation.Name = "ArmyUiInformation";
            this.ttInformation.SetToolTip(this.ArmyUiInformation, resources.GetString("ArmyUiInformation.ToolTip"));
            // 
            // tcUnitTab
            // 
            resources.ApplyResources(this.tcUnitTab, "tcUnitTab");
            this.tcUnitTab.BackColor = System.Drawing.SystemColors.Control;
            this.tcUnitTab.Controls.Add(this.gbUnittabShow);
            this.tcUnitTab.Controls.Add(this.UnittabUiUnitTabBasic);
            this.tcUnitTab.Controls.Add(this.UnittabUiChatInput);
            this.tcUnitTab.Controls.Add(this.UnittabUiHotkeys);
            this.tcUnitTab.Controls.Add(this.UnittabUiInformation);
            this.tcUnitTab.Controls.Add(this.gbUnitPicture);
            this.tcUnitTab.Name = "tcUnitTab";
            this.ttInformation.SetToolTip(this.tcUnitTab, resources.GetString("tcUnitTab.ToolTip"));
            // 
            // gbUnittabShow
            // 
            resources.ApplyResources(this.gbUnittabShow, "gbUnittabShow");
            this.gbUnittabShow.Controls.Add(this.chBxUnitTabShowBuildings);
            this.gbUnittabShow.Controls.Add(this.chBxUnitTabShowUnits);
            this.gbUnittabShow.LanguageFile = "";
            this.gbUnittabShow.Name = "gbUnittabShow";
            this.gbUnittabShow.TabStop = false;
            this.ttInformation.SetToolTip(this.gbUnittabShow, resources.GetString("gbUnittabShow.ToolTip"));
            // 
            // chBxUnitTabShowBuildings
            // 
            resources.ApplyResources(this.chBxUnitTabShowBuildings, "chBxUnitTabShowBuildings");
            this.chBxUnitTabShowBuildings.LanguageFile = "";
            this.chBxUnitTabShowBuildings.Name = "chBxUnitTabShowBuildings";
            this.ttInformation.SetToolTip(this.chBxUnitTabShowBuildings, resources.GetString("chBxUnitTabShowBuildings.ToolTip"));
            this.chBxUnitTabShowBuildings.UseVisualStyleBackColor = true;
            this.chBxUnitTabShowBuildings.CheckedChanged += new System.EventHandler(this.chBxUnitTabShowBuildings_CheckedChanged);
            // 
            // chBxUnitTabShowUnits
            // 
            resources.ApplyResources(this.chBxUnitTabShowUnits, "chBxUnitTabShowUnits");
            this.chBxUnitTabShowUnits.LanguageFile = "";
            this.chBxUnitTabShowUnits.Name = "chBxUnitTabShowUnits";
            this.ttInformation.SetToolTip(this.chBxUnitTabShowUnits, resources.GetString("chBxUnitTabShowUnits.ToolTip"));
            this.chBxUnitTabShowUnits.UseVisualStyleBackColor = true;
            this.chBxUnitTabShowUnits.CheckedChanged += new System.EventHandler(this.chBxUnitTabShowUnits_CheckedChanged);
            // 
            // UnittabUiUnitTabBasic
            // 
            resources.ApplyResources(this.UnittabUiUnitTabBasic, "UnittabUiUnitTabBasic");
            this.UnittabUiUnitTabBasic.Name = "UnittabUiUnitTabBasic";
            this.ttInformation.SetToolTip(this.UnittabUiUnitTabBasic, resources.GetString("UnittabUiUnitTabBasic.ToolTip"));
            // 
            // UnittabUiChatInput
            // 
            resources.ApplyResources(this.UnittabUiChatInput, "UnittabUiChatInput");
            this.UnittabUiChatInput.Name = "UnittabUiChatInput";
            this.ttInformation.SetToolTip(this.UnittabUiChatInput, resources.GetString("UnittabUiChatInput.ToolTip"));
            // 
            // UnittabUiHotkeys
            // 
            resources.ApplyResources(this.UnittabUiHotkeys, "UnittabUiHotkeys");
            this.UnittabUiHotkeys.Name = "UnittabUiHotkeys";
            this.ttInformation.SetToolTip(this.UnittabUiHotkeys, resources.GetString("UnittabUiHotkeys.ToolTip"));
            // 
            // UnittabUiInformation
            // 
            resources.ApplyResources(this.UnittabUiInformation, "UnittabUiInformation");
            this.UnittabUiInformation.Name = "UnittabUiInformation";
            this.ttInformation.SetToolTip(this.UnittabUiInformation, resources.GetString("UnittabUiInformation.ToolTip"));
            // 
            // gbUnitPicture
            // 
            resources.ApplyResources(this.gbUnitPicture, "gbUnitPicture");
            this.gbUnitPicture.Controls.Add(this.lblUnitPicturePreview);
            this.gbUnitPicture.Controls.Add(this.pcBxUnitPreview);
            this.gbUnitPicture.Controls.Add(this.txtUnitPictureSize);
            this.gbUnitPicture.Controls.Add(this.lblUnitPictureSize);
            this.gbUnitPicture.LanguageFile = "";
            this.gbUnitPicture.Name = "gbUnitPicture";
            this.gbUnitPicture.TabStop = false;
            this.ttInformation.SetToolTip(this.gbUnitPicture, resources.GetString("gbUnitPicture.ToolTip"));
            // 
            // lblUnitPicturePreview
            // 
            resources.ApplyResources(this.lblUnitPicturePreview, "lblUnitPicturePreview");
            this.lblUnitPicturePreview.LanguageFile = "";
            this.lblUnitPicturePreview.Name = "lblUnitPicturePreview";
            this.ttInformation.SetToolTip(this.lblUnitPicturePreview, resources.GetString("lblUnitPicturePreview.ToolTip"));
            // 
            // pcBxUnitPreview
            // 
            resources.ApplyResources(this.pcBxUnitPreview, "pcBxUnitPreview");
            this.pcBxUnitPreview.DrawingFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pcBxUnitPreview.DrawingPoint = ((System.Drawing.PointF)(resources.GetObject("pcBxUnitPreview.DrawingPoint")));
            this.pcBxUnitPreview.DrawingText = "";
            this.pcBxUnitPreview.Image = global::AnotherSc2Hack.Properties.Resources.tu_Mule;
            this.pcBxUnitPreview.Name = "pcBxUnitPreview";
            this.pcBxUnitPreview.TabStop = false;
            this.ttInformation.SetToolTip(this.pcBxUnitPreview, resources.GetString("pcBxUnitPreview.ToolTip"));
            // 
            // txtUnitPictureSize
            // 
            resources.ApplyResources(this.txtUnitPictureSize, "txtUnitPictureSize");
            this.txtUnitPictureSize.Name = "txtUnitPictureSize";
            this.ttInformation.SetToolTip(this.txtUnitPictureSize, resources.GetString("txtUnitPictureSize.ToolTip"));
            this.txtUnitPictureSize.TextChanged += new System.EventHandler(this.txtUnitPictureSize_TextChanged);
            // 
            // lblUnitPictureSize
            // 
            resources.ApplyResources(this.lblUnitPictureSize, "lblUnitPictureSize");
            this.lblUnitPictureSize.LanguageFile = "";
            this.lblUnitPictureSize.Name = "lblUnitPictureSize";
            this.ttInformation.SetToolTip(this.lblUnitPictureSize, resources.GetString("lblUnitPictureSize.ToolTip"));
            // 
            // tcProduction
            // 
            resources.ApplyResources(this.tcProduction, "tcProduction");
            this.tcProduction.BackColor = System.Drawing.SystemColors.Control;
            this.tcProduction.Controls.Add(this.gbProdtabShow);
            this.tcProduction.Controls.Add(this.gbProdPicture);
            this.tcProduction.Controls.Add(this.ProductionTabUiInformation);
            this.tcProduction.Controls.Add(this.ProductionTabUiHotkeys);
            this.tcProduction.Controls.Add(this.ProductionTabUiChatInput);
            this.tcProduction.Controls.Add(this.ProductionTabUiProductionTabBasics);
            this.tcProduction.Name = "tcProduction";
            this.ttInformation.SetToolTip(this.tcProduction, resources.GetString("tcProduction.ToolTip"));
            // 
            // gbProdtabShow
            // 
            resources.ApplyResources(this.gbProdtabShow, "gbProdtabShow");
            this.gbProdtabShow.Controls.Add(this.chBxProdTabShowUpgrades);
            this.gbProdtabShow.Controls.Add(this.chBxProdTabShowBuildings);
            this.gbProdtabShow.Controls.Add(this.chBxProdTabShowUnits);
            this.gbProdtabShow.LanguageFile = "";
            this.gbProdtabShow.Name = "gbProdtabShow";
            this.gbProdtabShow.TabStop = false;
            this.ttInformation.SetToolTip(this.gbProdtabShow, resources.GetString("gbProdtabShow.ToolTip"));
            // 
            // chBxProdTabShowUpgrades
            // 
            resources.ApplyResources(this.chBxProdTabShowUpgrades, "chBxProdTabShowUpgrades");
            this.chBxProdTabShowUpgrades.LanguageFile = "";
            this.chBxProdTabShowUpgrades.Name = "chBxProdTabShowUpgrades";
            this.ttInformation.SetToolTip(this.chBxProdTabShowUpgrades, resources.GetString("chBxProdTabShowUpgrades.ToolTip"));
            this.chBxProdTabShowUpgrades.UseVisualStyleBackColor = true;
            this.chBxProdTabShowUpgrades.CheckedChanged += new System.EventHandler(this.chBxProdTabShowUpgrades_CheckedChanged);
            // 
            // chBxProdTabShowBuildings
            // 
            resources.ApplyResources(this.chBxProdTabShowBuildings, "chBxProdTabShowBuildings");
            this.chBxProdTabShowBuildings.LanguageFile = "";
            this.chBxProdTabShowBuildings.Name = "chBxProdTabShowBuildings";
            this.ttInformation.SetToolTip(this.chBxProdTabShowBuildings, resources.GetString("chBxProdTabShowBuildings.ToolTip"));
            this.chBxProdTabShowBuildings.UseVisualStyleBackColor = true;
            this.chBxProdTabShowBuildings.CheckedChanged += new System.EventHandler(this.chBxProdTabShowBuildings_CheckedChanged);
            // 
            // chBxProdTabShowUnits
            // 
            resources.ApplyResources(this.chBxProdTabShowUnits, "chBxProdTabShowUnits");
            this.chBxProdTabShowUnits.LanguageFile = "";
            this.chBxProdTabShowUnits.Name = "chBxProdTabShowUnits";
            this.ttInformation.SetToolTip(this.chBxProdTabShowUnits, resources.GetString("chBxProdTabShowUnits.ToolTip"));
            this.chBxProdTabShowUnits.UseVisualStyleBackColor = true;
            this.chBxProdTabShowUnits.CheckedChanged += new System.EventHandler(this.chBxProdTabShowUnits_CheckedChanged);
            // 
            // gbProdPicture
            // 
            resources.ApplyResources(this.gbProdPicture, "gbProdPicture");
            this.gbProdPicture.Controls.Add(this.lblProdPicturePreview);
            this.gbProdPicture.Controls.Add(this.pcBxProductionTabPreview);
            this.gbProdPicture.Controls.Add(this.txtProductionTabPictureSize);
            this.gbProdPicture.Controls.Add(this.lblProdPictureSize);
            this.gbProdPicture.LanguageFile = "";
            this.gbProdPicture.Name = "gbProdPicture";
            this.gbProdPicture.TabStop = false;
            this.ttInformation.SetToolTip(this.gbProdPicture, resources.GetString("gbProdPicture.ToolTip"));
            // 
            // lblProdPicturePreview
            // 
            resources.ApplyResources(this.lblProdPicturePreview, "lblProdPicturePreview");
            this.lblProdPicturePreview.LanguageFile = "";
            this.lblProdPicturePreview.Name = "lblProdPicturePreview";
            this.ttInformation.SetToolTip(this.lblProdPicturePreview, resources.GetString("lblProdPicturePreview.ToolTip"));
            // 
            // pcBxProductionTabPreview
            // 
            resources.ApplyResources(this.pcBxProductionTabPreview, "pcBxProductionTabPreview");
            this.pcBxProductionTabPreview.DrawingFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pcBxProductionTabPreview.DrawingPoint = ((System.Drawing.PointF)(resources.GetObject("pcBxProductionTabPreview.DrawingPoint")));
            this.pcBxProductionTabPreview.DrawingText = "";
            this.pcBxProductionTabPreview.Image = global::AnotherSc2Hack.Properties.Resources.tu_Mule;
            this.pcBxProductionTabPreview.Name = "pcBxProductionTabPreview";
            this.pcBxProductionTabPreview.TabStop = false;
            this.ttInformation.SetToolTip(this.pcBxProductionTabPreview, resources.GetString("pcBxProductionTabPreview.ToolTip"));
            // 
            // txtProductionTabPictureSize
            // 
            resources.ApplyResources(this.txtProductionTabPictureSize, "txtProductionTabPictureSize");
            this.txtProductionTabPictureSize.Name = "txtProductionTabPictureSize";
            this.ttInformation.SetToolTip(this.txtProductionTabPictureSize, resources.GetString("txtProductionTabPictureSize.ToolTip"));
            this.txtProductionTabPictureSize.TextChanged += new System.EventHandler(this.txtProdPictureSize_TextChanged);
            // 
            // lblProdPictureSize
            // 
            resources.ApplyResources(this.lblProdPictureSize, "lblProdPictureSize");
            this.lblProdPictureSize.LanguageFile = "";
            this.lblProdPictureSize.Name = "lblProdPictureSize";
            this.ttInformation.SetToolTip(this.lblProdPictureSize, resources.GetString("lblProdPictureSize.ToolTip"));
            // 
            // ProductionTabUiInformation
            // 
            resources.ApplyResources(this.ProductionTabUiInformation, "ProductionTabUiInformation");
            this.ProductionTabUiInformation.Name = "ProductionTabUiInformation";
            this.ttInformation.SetToolTip(this.ProductionTabUiInformation, resources.GetString("ProductionTabUiInformation.ToolTip"));
            // 
            // ProductionTabUiHotkeys
            // 
            resources.ApplyResources(this.ProductionTabUiHotkeys, "ProductionTabUiHotkeys");
            this.ProductionTabUiHotkeys.Name = "ProductionTabUiHotkeys";
            this.ttInformation.SetToolTip(this.ProductionTabUiHotkeys, resources.GetString("ProductionTabUiHotkeys.ToolTip"));
            // 
            // ProductionTabUiChatInput
            // 
            resources.ApplyResources(this.ProductionTabUiChatInput, "ProductionTabUiChatInput");
            this.ProductionTabUiChatInput.Name = "ProductionTabUiChatInput";
            this.ttInformation.SetToolTip(this.ProductionTabUiChatInput, resources.GetString("ProductionTabUiChatInput.ToolTip"));
            // 
            // ProductionTabUiProductionTabBasics
            // 
            resources.ApplyResources(this.ProductionTabUiProductionTabBasics, "ProductionTabUiProductionTabBasics");
            this.ProductionTabUiProductionTabBasics.Name = "ProductionTabUiProductionTabBasics";
            this.ttInformation.SetToolTip(this.ProductionTabUiProductionTabBasics, resources.GetString("ProductionTabUiProductionTabBasics.ToolTip"));
            // 
            // tcWorkerAutomation
            // 
            resources.ApplyResources(this.tcWorkerAutomation, "tcWorkerAutomation");
            this.tcWorkerAutomation.BackColor = System.Drawing.SystemColors.Control;
            this.tcWorkerAutomation.Controls.Add(this.workerProductionBasics);
            this.tcWorkerAutomation.Controls.Add(this.WorkerProductionUiHotkeys);
            this.tcWorkerAutomation.Name = "tcWorkerAutomation";
            this.ttInformation.SetToolTip(this.tcWorkerAutomation, resources.GetString("tcWorkerAutomation.ToolTip"));
            // 
            // workerProductionBasics
            // 
            resources.ApplyResources(this.workerProductionBasics, "workerProductionBasics");
            this.workerProductionBasics.Name = "workerProductionBasics";
            this.ttInformation.SetToolTip(this.workerProductionBasics, resources.GetString("workerProductionBasics.ToolTip"));
            // 
            // WorkerProductionUiHotkeys
            // 
            resources.ApplyResources(this.WorkerProductionUiHotkeys, "WorkerProductionUiHotkeys");
            this.WorkerProductionUiHotkeys.Name = "WorkerProductionUiHotkeys";
            this.ttInformation.SetToolTip(this.WorkerProductionUiHotkeys, resources.GetString("WorkerProductionUiHotkeys.ToolTip"));
            // 
            // tcVarious
            // 
            resources.ApplyResources(this.tcVarious, "tcVarious");
            this.tcVarious.BackColor = System.Drawing.SystemColors.Control;
            this.tcVarious.Controls.Add(this.Custom_Various);
            this.tcVarious.Name = "tcVarious";
            this.ttInformation.SetToolTip(this.tcVarious, resources.GetString("tcVarious.ToolTip"));
            // 
            // Custom_Various
            // 
            resources.ApplyResources(this.Custom_Various, "Custom_Various");
            this.Custom_Various.Name = "Custom_Various";
            this.ttInformation.SetToolTip(this.Custom_Various, resources.GetString("Custom_Various.ToolTip"));
            // 
            // tcBugs
            // 
            resources.ApplyResources(this.tcBugs, "tcBugs");
            this.tcBugs.BackColor = System.Drawing.SystemColors.Control;
            this.tcBugs.Controls.Add(this.CustBugs);
            this.tcBugs.Name = "tcBugs";
            this.ttInformation.SetToolTip(this.tcBugs, resources.GetString("tcBugs.ToolTip"));
            // 
            // CustBugs
            // 
            resources.ApplyResources(this.CustBugs, "CustBugs");
            this.CustBugs.Name = "CustBugs";
            this.ttInformation.SetToolTip(this.CustBugs, resources.GetString("CustBugs.ToolTip"));
            // 
            // tcCredits
            // 
            resources.ApplyResources(this.tcCredits, "tcCredits");
            this.tcCredits.BackColor = System.Drawing.SystemColors.Control;
            this.tcCredits.Controls.Add(this.label92);
            this.tcCredits.Name = "tcCredits";
            this.ttInformation.SetToolTip(this.tcCredits, resources.GetString("tcCredits.ToolTip"));
            this.tcCredits.Paint += new System.Windows.Forms.PaintEventHandler(this.tcCredits_Paint);
            // 
            // label92
            // 
            resources.ApplyResources(this.label92, "label92");
            this.label92.Name = "label92";
            this.ttInformation.SetToolTip(this.label92, resources.GetString("label92.ToolTip"));
            // 
            // tcBenchmark
            // 
            resources.ApplyResources(this.tcBenchmark, "tcBenchmark");
            this.tcBenchmark.BackColor = System.Drawing.SystemColors.Control;
            this.tcBenchmark.Controls.Add(this.GlobalBenchmark);
            this.tcBenchmark.Name = "tcBenchmark";
            this.ttInformation.SetToolTip(this.tcBenchmark, resources.GetString("tcBenchmark.ToolTip"));
            // 
            // GlobalBenchmark
            // 
            resources.ApplyResources(this.GlobalBenchmark, "GlobalBenchmark");
            this.GlobalBenchmark.Name = "GlobalBenchmark";
            this.ttInformation.SetToolTip(this.GlobalBenchmark, resources.GetString("GlobalBenchmark.ToolTip"));
            // 
            // tcDebug
            // 
            resources.ApplyResources(this.tcDebug, "tcDebug");
            this.tcDebug.BackColor = System.Drawing.SystemColors.Control;
            this.tcDebug.Controls.Add(this.CustDebug);
            this.tcDebug.Name = "tcDebug";
            this.ttInformation.SetToolTip(this.tcDebug, resources.GetString("tcDebug.ToolTip"));
            // 
            // CustDebug
            // 
            resources.ApplyResources(this.CustDebug, "CustDebug");
            this.CustDebug.Name = "CustDebug";
            this.ttInformation.SetToolTip(this.CustDebug, resources.GetString("CustDebug.ToolTip"));
            // 
            // btnProduction
            // 
            resources.ApplyResources(this.btnProduction, "btnProduction");
            this.btnProduction.Name = "btnProduction";
            this.ttInformation.SetToolTip(this.btnProduction, resources.GetString("btnProduction.ToolTip"));
            this.btnProduction.UseVisualStyleBackColor = true;
            this.btnProduction.Click += new System.EventHandler(this.btnProduction_Click);
            // 
            // btnLostUnits
            // 
            resources.ApplyResources(this.btnLostUnits, "btnLostUnits");
            this.btnLostUnits.Name = "btnLostUnits";
            this.ttInformation.SetToolTip(this.btnLostUnits, resources.GetString("btnLostUnits.ToolTip"));
            this.btnLostUnits.UseVisualStyleBackColor = true;
            this.btnLostUnits.Click += new System.EventHandler(this.btnLostUnits_Click);
            // 
            // btnChangeBorderstyle
            // 
            resources.ApplyResources(this.btnChangeBorderstyle, "btnChangeBorderstyle");
            this.btnChangeBorderstyle.Name = "btnChangeBorderstyle";
            this.ttInformation.SetToolTip(this.btnChangeBorderstyle, resources.GetString("btnChangeBorderstyle.ToolTip"));
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
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
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
            this.ttInformation.SetToolTip(this, resources.GetString("$this.ToolTip"));
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
        public UiInformation UnittabUiInformation;
        public UiInformation ResourceUiInformation;
        public UiInformation IncomeUiInformation;
        public UiInformation WorkerUiInformation;
        public UiInformation MaphackUiInformation;
        public UiInformation ApmUiInformation;
        public UiInformation ArmyUiInformation;
        public UiHotkeys ResourceUiHotkeys;
        public UiHotkeys IncomeUiHotkeys;
        public UiHotkeys WorkerUiHotkeys;
        public UiHotkeys MaphackUiHotkeys;
        public UiHotkeys ApmUiHotkeys;
        public UiHotkeys ArmyUiHotkeys;
        public UiHotkeys UnittabUiHotkeys;
        public UiChatInput UnittabUiChatInput;
        public UiChatInput ResourceUiChatInput;
        public UiChatInput IncomeUiChatInput;
        public UiChatInput WorkerUiChatInput;
        public UiChatInput MaphackUiChatInput;
        public UiChatInput ApmUiChatInput;
        public UiChatInput ArmyUiChatInput;
        public UiBasics ResourceUiBasics;
        public UiBasics IncomeUiBasics;
        public UiBasics ApmUiBasics;
        public UiBasics ArmyUiBasics;
        public UiWorkerBasics WorkerUiWorkerBasics;
        public UiMaphackBasics MaphackUiMaphackBasics;
        public UiUnitTabBasic UnittabUiUnitTabBasic;
        public ControlBugs CustBugs;
        private CustomDebug CustDebug;
        private System.Windows.Forms.TabPage tcProduction;
        private LanguageGroupbox gbProdPicture;
        private LanguageLabel lblProdPicturePreview;
        private CustomPictureBox pcBxProductionTabPreview;
        public System.Windows.Forms.TextBox txtProductionTabPictureSize;
        private LanguageLabel lblProdPictureSize;
        public UiInformation ProductionTabUiInformation;
        public UiHotkeys ProductionTabUiHotkeys;
        public UiChatInput ProductionTabUiChatInput;
        public UiProductionTabBasics ProductionTabUiProductionTabBasics;
        public System.Windows.Forms.Button btnLostUnits;
        private System.Windows.Forms.TabPage tcVarious;
        public CustomVarious Custom_Various;
        internal ControlGlobal CustGlobal;
        public System.Windows.Forms.Button btnChangeBorderstyle;
        private System.Windows.Forms.ContextMenuStrip cmsListboxContext;
        private System.Windows.Forms.ToolStripMenuItem addAUnitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteAUnitToolStripMenuItem;
        private AutomationWorker workerProductionBasics;
        public UiHotkeys WorkerProductionUiHotkeys;
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