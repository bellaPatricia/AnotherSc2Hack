using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Net.NetworkInformation;
using System.Security;
using System.Windows.Forms;
using AnotherSc2Hack.Classes.BackEnds;
using AnotherSc2Hack.Classes.FrontEnds.Rendering;
using Predefined;

namespace AnotherSc2Hack.Classes.FrontEnds.MainHandler
{
    public partial class MainHandler
    {
        #region Resources


        private void btnResourceFontName_Click(object sender, EventArgs e)
        {
        FontAgain:

            try
            {
                var fd = new FontDialog();
                fd.Font = new Font(ResourceUiBasics.btnFontName.Text, 15);
                var result = fd.ShowDialog();

                if (result.Equals(DialogResult.OK))
                {
                    ResourceUiBasics.btnFontName.Text = fd.Font.Name;
                    ResourceUiBasics.btnFontName.Font = new Font(fd.Font.Name, Font.Size, FontStyle.Regular);
                    PSettings.ResourceFontName = fd.Font.Name;
                }
            }

            catch
            {
                MessageBox.Show("Only TrueType Fonts are allowed!");
                goto FontAgain;
            }
        }

        private void tbResourceOpacity_Scroll(object sender, EventArgs e)
        {
            PSettings.ResourceOpacity = (double)ResourceUiBasics.OcUiOpacity.tbOpacity.Value / 100;
        }

        private void txtResTogglePanel_TextChanged(object sender, EventArgs e)
        {
            if (ResourceUiChatInput.txtToggle.Text.Length > 0)
                PSettings.ResourceTogglePanel = ResourceUiChatInput.txtToggle.Text;
        }

        private void txtResPositionPanel_TextChanged(object sender, EventArgs e)
        {
            if (ResourceUiChatInput.txtPosition.Text.Length > 0)
                PSettings.ResourceChangePositionPanel = ResourceUiChatInput.txtPosition.Text;
        }

        private void txtResChangeSizePanel_TextChanged(object sender, EventArgs e)
        {
            if (ResourceUiChatInput.txtSize.Text.Length > 0)
                PSettings.ResourceChangeSizePanel = ResourceUiChatInput.txtSize.Text;
        }

        private void txtResHotkey1_KeyDown(object sender, KeyEventArgs e)
        {
            ResourceUiHotkeys.txtHotkey1.Text = e.KeyCode.ToString();
            PSettings.ResourceHotkey1 = e.KeyCode;
            e.SuppressKeyPress = true;
        }

        private void txtResHotkey2_KeyDown(object sender, KeyEventArgs e)
        {
            ResourceUiHotkeys.txtHotkey2.Text = e.KeyCode.ToString();
            PSettings.ResourceHotkey2 = e.KeyCode;
            e.SuppressKeyPress = true;
        }

        private void txtResHotkey3_KeyDown(object sender, KeyEventArgs e)
        {
            ResourceUiHotkeys.txtHotkey3.Text = e.KeyCode.ToString();
            PSettings.ResourceHotkey3 = e.KeyCode;
            e.SuppressKeyPress = true;
        }

        private void chBxResourceDrawBackground_CheckedChanged(object sender, EventArgs e)
        {
            PSettings.ResourceDrawBackground = ResourceUiBasics.chBxDrawBackground.Checked;
        }

        void chBxResourceRemoveNeutral_CheckedChanged(object sender, EventArgs e)
        {
            PSettings.ResourceRemoveNeutral = ResourceUiBasics.chBxRemoveNeutral.Checked;
        }

        void chBxResourceRemoveLocalplayer_CheckedChanged(object sender, EventArgs e)
        {
            PSettings.IncomeRemoveLocalplayer = IncomeUiBasics.chBxRemoveLocalplayer.Checked;
        }

        void chBxResourceRemoveClantag_CheckedChanged(object sender, EventArgs e)
        {
            PSettings.ApmRemoveClanTag = ApmUiBasics.chBxRemoveClantag.Checked;
        }

        void chBxResourceRemoveAllie_CheckedChanged(object sender, EventArgs e)
        {
            PSettings.ResourceRemoveAllie = ResourceUiBasics.chBxRemoveAllie.Checked;
        }

        void chBxResourceRemoveAi_CheckedChanged(object sender, EventArgs e)
        {
            PSettings.ResourceRemoveAi = ResourceUiBasics.chBxRemoveAi.Checked;
        }

        #endregion

        #region Income

     
        private void btnIncomeFontName_Click(object sender, EventArgs e)
        {
        FontAgain:

            try
            {
                var fd = new FontDialog();
                fd.Font = new Font(IncomeUiBasics.btnFontName.Text, 15);
                var result = fd.ShowDialog();

                if (result.Equals(DialogResult.OK))
                {
                    IncomeUiBasics.btnFontName.Text = fd.Font.Name;
                    IncomeUiBasics.btnFontName.Font = new Font(fd.Font.Name, Font.Size, FontStyle.Regular);
                    PSettings.IncomeFontName = fd.Font.Name;
                }
            }

            catch
            {
                MessageBox.Show("Only TrueType Fonts are allowed!");
                goto FontAgain;
            }
        }

        private void tbIncomeOpacity_Scroll(object sender, EventArgs e)
        {
            /*if (IncomeUiBasics.tbOpacityf.Value > 0)
                IncomeUiBasics.lblOpacity.Text = "Opacity: " + (IncomeUiBasics.tbOpacityf.Value * 1).ToString(CultureInfo.InvariantCulture) + "%";

            else
                IncomeUiBasics.tbOpacityf.Value = 1;*/

            PSettings.IncomeOpacity = (double)IncomeUiBasics.OcUiOpacity.tbOpacity.Value / 100;
        }

        private void txtIncTogglePanel_TextChanged(object sender, EventArgs e)
        {
            if (IncomeUiChatInput.txtToggle.Text.Length > 0)
                PSettings.IncomeTogglePanel = IncomeUiChatInput.txtToggle.Text;
        }

        private void txtIncPositionPanel_TextChanged(object sender, EventArgs e)
        {
            if (IncomeUiChatInput.txtPosition.Text.Length > 0)
                PSettings.IncomeChangePositionPanel = IncomeUiChatInput.txtPosition.Text;
        }

        private void txtIncChangeSizePanel_TextChanged(object sender, EventArgs e)
        {
            if (IncomeUiChatInput.txtSize.Text.Length > 0)
                PSettings.IncomeChangeSizePanel = IncomeUiChatInput.txtSize.Text;
        }

        private void txtIncHotkey1_KeyDown(object sender, KeyEventArgs e)
        {
            IncomeUiHotkeys.txtHotkey1.Text = e.KeyCode.ToString();
            PSettings.IncomeHotkey1 = e.KeyCode;
            e.SuppressKeyPress = true;
        }

        private void txtIncHotkey2_KeyDown(object sender, KeyEventArgs e)
        {
            IncomeUiHotkeys.txtHotkey2.Text = e.KeyCode.ToString();
            PSettings.IncomeHotkey2 = e.KeyCode;
            e.SuppressKeyPress = true;
        }

        private void txtIncHotkey3_KeyDown(object sender, KeyEventArgs e)
        {
            IncomeUiHotkeys.txtHotkey3.Text = e.KeyCode.ToString();
            PSettings.IncomeHotkey3 = e.KeyCode;
            e.SuppressKeyPress = true;
        }

        private void chBxIncomeDrawBackground_CheckedChanged(object sender, EventArgs e)
        {
            PSettings.IncomeDrawBackground = IncomeUiBasics.chBxDrawBackground.Checked;
        }

        void chBxIncomeRemoveNeutral_CheckedChanged(object sender, EventArgs e)
        {
            PSettings.IncomeRemoveNeutral = IncomeUiBasics.chBxRemoveNeutral.Checked;
        }

        void chBxIncomeRemoveLocalplayer_CheckedChanged(object sender, EventArgs e)
        {
            PSettings.IncomeRemoveLocalplayer = IncomeUiBasics.chBxRemoveLocalplayer.Checked;
        }

        void chBxIncomeRemoveClantag_CheckedChanged(object sender, EventArgs e)
        {
            PSettings.ApmRemoveClanTag = ApmUiBasics.chBxRemoveClantag.Checked;
        }

        void chBxIncomeRemoveAllie_CheckedChanged(object sender, EventArgs e)
        {
            PSettings.IncomeRemoveAllie = IncomeUiBasics.chBxRemoveAllie.Checked;
        }

        void chBxIncomeRemoveAi_CheckedChanged(object sender, EventArgs e)
        {
            PSettings.IncomeRemoveAi = IncomeUiBasics.chBxRemoveAi.Checked;
        }

  
        #endregion

        #region Worker

        private void btnWorFontName_Click(object sender, EventArgs e)
        {
        FontAgain:

            try
            {
                var fd = new FontDialog();
                fd.Font = new Font(WorkerUiWorkerBasics.btnFontName.Text, 15);
                var result = fd.ShowDialog();

                if (result.Equals(DialogResult.OK))
                {
                    WorkerUiWorkerBasics.btnFontName.Text = fd.Font.Name;
                    WorkerUiWorkerBasics.btnFontName.Font = new Font(fd.Font.Name, Font.Size, FontStyle.Regular);
                    PSettings.WorkerFontName = fd.Font.Name;
                }
            }

            catch
            {
                MessageBox.Show("Only TrueType Fonts are allowed!");
                goto FontAgain;
            }
        }

        private void txtWorTogglePanel_TextChanged(object sender, EventArgs e)
        {
            if (WorkerUiChatInput.txtToggle.Text.Length > 0)
                PSettings.WorkerTogglePanel = WorkerUiChatInput.txtToggle.Text;
        }

        private void txtWorPositionPanel_TextChanged(object sender, EventArgs e)
        {
            if (WorkerUiChatInput.txtPosition.Text.Length > 0)
                PSettings.WorkerChangePositionPanel = WorkerUiChatInput.txtPosition.Text;
        }

        private void txtWorChangeSizePanel_TextChanged(object sender, EventArgs e)
        {
            if (WorkerUiChatInput.txtSize.Text.Length > 0)
                PSettings.WorkerChangeSizePanel = WorkerUiChatInput.txtSize.Text;
        }

        private void txtWorHotkey1_KeyDown(object sender, KeyEventArgs e)
        {
            WorkerUiHotkeys.txtHotkey1.Text = e.KeyCode.ToString();
            PSettings.WorkerHotkey1 = e.KeyCode;
            e.SuppressKeyPress = true;
        }

        private void txtWorHotkey2_KeyDown(object sender, KeyEventArgs e)
        {
            WorkerUiHotkeys.txtHotkey2.Text = e.KeyCode.ToString();
            PSettings.WorkerHotkey2 = e.KeyCode;
            e.SuppressKeyPress = true;
        }

        private void txtWorHotkey3_KeyDown(object sender, KeyEventArgs e)
        {
            WorkerUiHotkeys.txtHotkey3.Text = e.KeyCode.ToString();
            PSettings.WorkerHotkey3 = e.KeyCode;
            e.SuppressKeyPress = true;
        }

        private void chBxWorDrawBackground_CheckedChanged(object sender, EventArgs e)
        {
            PSettings.WorkerDrawBackground = WorkerUiWorkerBasics.chBxDrawBackground.Checked;
        }

        void tbWorkerOpacity_Scroll(object sender, EventArgs e)
        {
            PSettings.WorkerOpacity = (double)WorkerUiWorkerBasics.OcUiOpacity.tbOpacity.Value / 100;
        }

        #endregion

        #region Apm


        private void btnApmFontName_Click(object sender, EventArgs e)
        {

        FontAgain:

            try
            {
                var fd = new FontDialog();
                fd.Font = new Font(ApmUiBasics.btnFontName.Text, 15);
                var result = fd.ShowDialog();

                if (result.Equals(DialogResult.OK))
                {
                    ApmUiBasics.btnFontName.Text = fd.Font.Name;
                    ApmUiBasics.btnFontName.Font = new Font(fd.Font.Name, Font.Size, FontStyle.Regular);
                    PSettings.ApmFontName = fd.Font.Name;
                }
            }

            catch
            {
                MessageBox.Show("Only TrueType Fonts are allowed!");
                goto FontAgain;
            }
        }

        private void tbApmOpacity_Scroll(object sender, EventArgs e)
        {
           /* if (ApmUiBasics.tbOpacityf.Value > 0)
                ApmUiBasics.lblOpacity.Text = "Opacity: " + (ApmUiBasics.tbOpacityf.Value * 1).ToString(CultureInfo.InvariantCulture) + "%";

            else
                ApmUiBasics.tbOpacityf.Value = 1;*/

            PSettings.ApmOpacity = (double)ApmUiBasics.OcUiOpacity.tbOpacity.Value / 100;
        }

        private void txtApmTogglePanel_TextChanged(object sender, EventArgs e)
        {
            if (ApmUiChatInput.txtToggle.Text.Length > 0)
                PSettings.ApmTogglePanel = ApmUiChatInput.txtToggle.Text;
        }

        private void txtApmPositionPanel_TextChanged(object sender, EventArgs e)
        {
            if (ApmUiChatInput.txtPosition.Text.Length > 0)
                PSettings.ApmChangePositionPanel = ApmUiChatInput.txtPosition.Text;
        }

        private void txtApmChangeSizePanel_TextChanged(object sender, EventArgs e)
        {
            if (ApmUiChatInput.txtSize.Text.Length > 0)
                PSettings.ApmChangeSizePanel = ApmUiChatInput.txtSize.Text;
        }

        private void txtApmHotkey1_KeyDown(object sender, KeyEventArgs e)
        {
            ApmUiHotkeys.txtHotkey1.Text = e.KeyCode.ToString();
            PSettings.ApmHotkey1 = e.KeyCode;
            e.SuppressKeyPress = true;
        }

        private void txtApmHotkey2_KeyDown(object sender, KeyEventArgs e)
        {
            ApmUiHotkeys.txtHotkey2.Text = e.KeyCode.ToString();
            PSettings.ApmHotkey2 = e.KeyCode;
            e.SuppressKeyPress = true;
        }

        private void txtApmHotkey3_KeyDown(object sender, KeyEventArgs e)
        {
            ApmUiHotkeys.txtHotkey3.Text = e.KeyCode.ToString();
            PSettings.ApmHotkey3 = e.KeyCode;
            e.SuppressKeyPress = true;
        }

        private void chBxApmDrawBackground_CheckedChanged(object sender, EventArgs e)
        {
            PSettings.ApmDrawBackground = ApmUiBasics.chBxDrawBackground.Checked;
        }

        void chBxApmRemoveNeutral_CheckedChanged(object sender, EventArgs e)
        {
            PSettings.ApmRemoveNeutral = ApmUiBasics.chBxRemoveNeutral.Checked;
        }

        void chBxApmRemoveLocalplayer_CheckedChanged(object sender, EventArgs e)
        {
            PSettings.ApmRemoveLocalplayer = ApmUiBasics.chBxRemoveLocalplayer.Checked;
        }

        void chBxApmRemoveClantag_CheckedChanged(object sender, EventArgs e)
        {
            PSettings.ApmRemoveClanTag = ApmUiBasics.chBxRemoveClantag.Checked;
        }

        void chBxApmRemoveAllie_CheckedChanged(object sender, EventArgs e)
        {
            PSettings.ApmRemoveAllie = ApmUiBasics.chBxRemoveAllie.Checked;
        }

        void chBxApmRemoveAi_CheckedChanged(object sender, EventArgs e)
        {
            PSettings.ApmRemoveAi = ApmUiBasics.chBxRemoveAi.Checked;
        }

        #endregion

        #region Army

        void chBxArmyRemoveNeutral_CheckedChanged(object sender, EventArgs e)
        {
            PSettings.ArmyRemoveNeutral = ArmyUiBasics.chBxRemoveNeutral.Checked;
        }

        void chBxArmyRemoveLocalplayer_CheckedChanged(object sender, EventArgs e)
        {
            PSettings.ArmyRemoveLocalplayer = ArmyUiBasics.chBxRemoveLocalplayer.Checked;
        }

        void chBxArmyRemoveClantag_CheckedChanged(object sender, EventArgs e)
        {
            PSettings.ArmyRemoveClanTag = ArmyUiBasics.chBxRemoveClantag.Checked;
        }

        void chBxArmyRemoveAllie_CheckedChanged(object sender, EventArgs e)
        {
            PSettings.ArmyRemoveAllie = ArmyUiBasics.chBxRemoveAllie.Checked;
        }

        void chBxArmyRemoveAi_CheckedChanged(object sender, EventArgs e)
        {
            PSettings.ArmyRemoveAi = ArmyUiBasics.chBxRemoveAi.Checked;
        }

        private void btnArmyFontName_Click(object sender, EventArgs e)
        {
        FontAgain:

            try
            {
                var fd = new FontDialog();
                fd.Font = new Font(ArmyUiBasics.btnFontName.Text, 15);
                var result = fd.ShowDialog();

                if (result.Equals(DialogResult.OK))
                {
                    ArmyUiBasics.btnFontName.Text = fd.Font.Name;
                    ArmyUiBasics.btnFontName.Font = new Font(fd.Font.Name, Font.Size, FontStyle.Regular);
                    PSettings.ArmyFontName = fd.Font.Name;
                }
            }

            catch
            {
                MessageBox.Show("Only TrueType Fonts are allowed!");
                goto FontAgain;
            }
        }

        private void tbArmyOpacity_Scroll(object sender, EventArgs e)
        {
            PSettings.ArmyOpacity = (double)ArmyUiBasics.OcUiOpacity.tbOpacity.Value / 100;
        }

        private void txtArmTogglePanel_TextChanged(object sender, EventArgs e)
        {
            if (ArmyUiChatInput.txtToggle.Text.Length > 0)
                PSettings.ArmyTogglePanel = ArmyUiChatInput.txtToggle.Text;
        }

        private void txtArmPositionPanel_TextChanged(object sender, EventArgs e)
        {
            if (ApmUiChatInput.txtPosition.Text.Length > 0)
                PSettings.ArmyChangePositionPanel = ApmUiChatInput.txtPosition.Text;
        }

        private void txtArmChangeSizePanel_TextChanged(object sender, EventArgs e)
        {
            if (ArmyUiChatInput.txtSize.Text.Length > 0)
                PSettings.ArmyChangeSizePanel = ArmyUiChatInput.txtSize.Text;
        }

        private void txtArmHotkey1_KeyDown(object sender, KeyEventArgs e)
        {
            ArmyUiHotkeys.txtHotkey1.Text = e.KeyCode.ToString();
            PSettings.ArmyHotkey1 = e.KeyCode;
            e.SuppressKeyPress = true;
        }

        private void txtArmHotkey2_KeyDown(object sender, KeyEventArgs e)
        {
            ArmyUiHotkeys.txtHotkey2.Text = e.KeyCode.ToString();
            PSettings.ArmyHotkey2 = e.KeyCode;
            e.SuppressKeyPress = true;
        }

        private void txtArmHotkey3_KeyDown(object sender, KeyEventArgs e)
        {
            ArmyUiHotkeys.txtHotkey3.Text = e.KeyCode.ToString();
            PSettings.ArmyHotkey3 = e.KeyCode;
            e.SuppressKeyPress = true;
        }

        private void chBxArmyDrawBackground_CheckedChanged(object sender, EventArgs e)
        {
            PSettings.ArmyDrawBackground = ArmyUiBasics.chBxDrawBackground.Checked;
        }

        #endregion

        #region Unittab

        void chBxUnitTabRemoveSpellcounter_CheckedChanged(object sender, EventArgs e)
        {
            PSettings.UnitTabRemoveSpellCounter = UnittabUiUnitTabBasic.chBxRemoveSpellcounter.Checked;
        }

        void chBxUnitTabRemoveChronoboost_CheckedChanged(object sender, EventArgs e)
        {
            PSettings.UnitTabRemoveChronoboost = UnittabUiUnitTabBasic.chBxRemoveChronoboost.Checked;
        }

        void chBxUnitTabRemoveClantag_CheckedChanged(object sender, EventArgs e)
        {
            PSettings.UnitTabRemoveClanTag = UnittabUiUnitTabBasic.chBxRemoveClantag.Checked;
        }

        void chBxUnitTabRemoveProductionLine_CheckedChanged(object sender, EventArgs e)
        {
            PSettings.UnitTabRemoveProdLine = UnittabUiUnitTabBasic.chBxRemoveProductionLine.Checked;
        }

        void chBxUnitTabSplitBuildingsUnits_CheckedChanged(object sender, EventArgs e)
        {
            PSettings.UnitTabSplitUnitsAndBuildings = UnittabUiUnitTabBasic.chBxSplitBuildingsUnits.Checked;
        }

        void chBxUnitTabRemoveLocalplayer_CheckedChanged(object sender, EventArgs e)
        {
            PSettings.UnitTabRemoveLocalplayer = UnittabUiUnitTabBasic.chBxRemoveLocalplayer.Checked;
        }

        void chBxUnitTabRemoveNeutral_CheckedChanged(object sender, EventArgs e)
        {
            PSettings.UnitTabRemoveNeutral = UnittabUiUnitTabBasic.chBxRemoveNeutral.Checked;
        }

        void chBxUnitTabRemoveAllie_CheckedChanged(object sender, EventArgs e)
        {
            PSettings.UnitTabRemoveAllie = UnittabUiUnitTabBasic.chBxRemoveAllie.Checked;
        }

        void chBxUnitTabRemoveAi_CheckedChanged(object sender, EventArgs e)
        {
            PSettings.UnitTabRemoveAi = UnittabUiUnitTabBasic.chBxRemoveAi.Checked;
        }

        private void tbUnitTabOpacity_Scroll(object sender, EventArgs e)
        {
            PSettings.UnitTabOpacity = (double)UnittabUiUnitTabBasic.OcUiOpacity.tbOpacity.Value / 100;
        }

        private void txtUnitTogglePanel_TextChanged(object sender, EventArgs e)
        {
            if (UnittabUiChatInput.txtToggle.Text.Length > 0)
                PSettings.UnitTogglePanel = UnittabUiChatInput.txtToggle.Text;
        }

        private void txtUnitPositionPanel_TextChanged(object sender, EventArgs e)
        {
            if (UnittabUiChatInput.txtPosition.Text.Length > 0)
                PSettings.UnitChangePositionPanel = UnittabUiChatInput.txtPosition.Text;
        }

        private void txtUnitChangeSizePanel_TextChanged(object sender, EventArgs e)
        {
            if (UnittabUiChatInput.txtSize.Text.Length > 0)
                PSettings.UnitChangeSizePanel = UnittabUiChatInput.txtSize.Text;
        }

        private void txtUnitHotkey1_KeyDown(object sender, KeyEventArgs e)
        {
            UnittabUiHotkeys.txtHotkey1.Text = e.KeyCode.ToString();
            PSettings.UnitHotkey1 = e.KeyCode;
            e.SuppressKeyPress = true;
        }

        private void txtUnitHotkey2_KeyDown(object sender, KeyEventArgs e)
        {
            UnittabUiHotkeys.txtHotkey2.Text = e.KeyCode.ToString();
            PSettings.UnitHotkey2 = e.KeyCode;
            e.SuppressKeyPress = true;
        }

        private void txtUnitHotkey3_KeyDown(object sender, KeyEventArgs e)
        {
            UnittabUiHotkeys.txtHotkey3.Text = e.KeyCode.ToString();
            PSettings.UnitHotkey3 = e.KeyCode;
            e.SuppressKeyPress = true;
        }

        private void txtUnitPictureSize_TextChanged(object sender, EventArgs e)
        {
            if (txtUnitPictureSize.Text.Length <= 0)
                return;

            int iPictureSize;

            if (Int32.TryParse(txtUnitPictureSize.Text, out iPictureSize))
            {
                if (iPictureSize < 1)
                {
                    iPictureSize = 1;
                    txtUnitPictureSize.Text = "1";
                }

                if (iPictureSize >= Screen.PrimaryScreen.Bounds.Width)
                {
                    iPictureSize = Screen.PrimaryScreen.Bounds.Width - 1;
                    txtUnitPictureSize.Text = (Screen.PrimaryScreen.Bounds.Width - 1).ToString(CultureInfo.InvariantCulture);
                }

                PSettings.UnitPictureSize = iPictureSize;

                pcBxUnitPreview.Size = new Size(iPictureSize, iPictureSize);
                pcBxUnitPreview.DrawingBrush = Brushes.White;
                pcBxUnitPreview.DrawingFont = new Font(PSettings.UnitTabFontName, (PSettings.UnitPictureSize / 4.5f));
                pcBxUnitPreview.DrawingPoint = new PointF(5, 5);
                pcBxUnitPreview.DrawingText = iPictureSize.ToString(CultureInfo.InvariantCulture);
            }

            /* Remove non- digits */
            if (!char.IsDigit(txtUnitPictureSize.Text[txtUnitPictureSize.Text.Length - 1]))
            {
                txtUnitPictureSize.Text = txtUnitPictureSize.Text.Remove(txtUnitPictureSize.Text.Length - 1);
                txtUnitPictureSize.Select(txtUnitPictureSize.Text.Length, 0);
            }
        }

        private void btnUniFontName_Click(object sender, EventArgs e)
        {
        FontAgain:

            try
            {
                var fd = new FontDialog();
                fd.Font = new Font(UnittabUiUnitTabBasic.btnFontName.Text, 15);
                var result = fd.ShowDialog();

                if (result.Equals(DialogResult.OK))
                {
                    UnittabUiUnitTabBasic.btnFontName.Text = fd.Font.Name;
                    UnittabUiUnitTabBasic.btnFontName.Font = new Font(fd.Font.Name, Font.Size, FontStyle.Regular);
                    PSettings.UnitTabFontName = fd.Font.Name;
                }
            }

            catch
            {
                MessageBox.Show("Only TrueType Fonts are allowed!");
                goto FontAgain;
            }
        }

        void chBxUnitTabShowUnits_CheckedChanged(object sender, EventArgs e)
        {
            PSettings.UnitTabShowUnits = UnittabUiUnitTabBasic.chBxShowUnits.Checked;
        }

        void chBxUnitTabShowBuildings_CheckedChanged(object sender, EventArgs e)
        {
            PSettings.UnitTabShowBuildings = UnittabUiUnitTabBasic.chBxShowBuildings.Checked;
        }



        #endregion

        #region Production

        private void tbProOpacity_Scroll(object sender, EventArgs e)
        {

            PSettings.ProdTabOpacity = (double)ProductionTabUiProductionTabBasics.OcUiOpacity.tbOpacity.Value / 100;
        }

        private void txtProdTogglePanel_TextChanged(object sender, EventArgs e)
        {
            if (ProductionTabUiChatInput.txtToggle.Text.Length > 0)
                PSettings.ProdTogglePanel = ProductionTabUiChatInput.txtToggle.Text;
        }

        private void txtProdPositionPanel_TextChanged(object sender, EventArgs e)
        {
            if (ProductionTabUiChatInput.txtPosition.Text.Length > 0)
                PSettings.ProdChangePositionPanel = ProductionTabUiChatInput.txtPosition.Text;
        }

        private void txtProdChangeSizePanel_TextChanged(object sender, EventArgs e)
        {
            if (ProductionTabUiChatInput.txtSize.Text.Length > 0)
                PSettings.ProdChangeSizePanel = ProductionTabUiChatInput.txtSize.Text;
        }

        private void txtProdHotkey1_KeyDown(object sender, KeyEventArgs e)
        {
            ProductionTabUiHotkeys.txtHotkey1.Text = e.KeyCode.ToString();
            PSettings.ProdHotkey1 = e.KeyCode;
            e.SuppressKeyPress = true;
        }

        private void txtProdHotkey2_KeyDown(object sender, KeyEventArgs e)
        {
            ProductionTabUiHotkeys.txtHotkey2.Text = e.KeyCode.ToString();
            PSettings.ProdHotkey2 = e.KeyCode;
            e.SuppressKeyPress = true;
        }

        private void txtProdHotkey3_KeyDown(object sender, KeyEventArgs e)
        {
            ProductionTabUiHotkeys.txtHotkey3.Text = e.KeyCode.ToString();
            PSettings.ProdHotkey3 = e.KeyCode;
            e.SuppressKeyPress = true;
        }

        private void txtProdPictureSize_TextChanged(object sender, EventArgs e)
        {
            if (txtProductionTabPictureSize.Text.Length <= 0)
                return;

            int iPictureSize;

            if (Int32.TryParse(txtProductionTabPictureSize.Text, out iPictureSize))
            {
                if (iPictureSize < 1)
                {
                    iPictureSize = 1;
                    txtProductionTabPictureSize.Text = "1";
                }

                if (iPictureSize >= Screen.PrimaryScreen.Bounds.Width)
                {
                    iPictureSize = Screen.PrimaryScreen.Bounds.Width - 1;
                    txtProductionTabPictureSize.Text = (Screen.PrimaryScreen.Bounds.Width - 1).ToString(CultureInfo.InvariantCulture);
                }

                PSettings.ProdPictureSize = iPictureSize;

                pcBxProductionTabPreview.Size = new Size(iPictureSize, iPictureSize);
                pcBxProductionTabPreview.DrawingBrush = Brushes.White;
                pcBxProductionTabPreview.DrawingFont = new Font(PSettings.ProdTabFontName, (PSettings.ProdPictureSize / 4.5f));
                pcBxProductionTabPreview.DrawingPoint = new PointF(5, 5);
                pcBxProductionTabPreview.DrawingText = iPictureSize.ToString(CultureInfo.InvariantCulture);
            }

            /* Remove non- digits */
            if (!char.IsDigit(txtProductionTabPictureSize.Text[txtProductionTabPictureSize.Text.Length - 1]))
            {
                txtProductionTabPictureSize.Text = txtProductionTabPictureSize.Text.Remove(txtProductionTabPictureSize.Text.Length - 1);
                txtProductionTabPictureSize.Select(txtProductionTabPictureSize.Text.Length, 0);
            }
        }

        private void btnProFontName_Click(object sender, EventArgs e)
        {
        FontAgain:

            try
            {
                var fd = new FontDialog();
                fd.Font = new Font(ProductionTabUiProductionTabBasics.btnFontName.Text, 15);
                var result = fd.ShowDialog();

                if (result.Equals(DialogResult.OK))
                {
                    ProductionTabUiProductionTabBasics.btnFontName.Text = fd.Font.Name;
                    ProductionTabUiProductionTabBasics.btnFontName.Font = new Font(fd.Font.Name, Font.Size, FontStyle.Regular);
                    PSettings.ProdTabFontName = fd.Font.Name;
                }
            }

            catch
            {
                MessageBox.Show("Only TrueType Fonts are allowed!");
                goto FontAgain;
            }
        }

        void chBxProductionTabRemoveChronoboost_CheckedChanged(object sender, EventArgs e)
        {
            PSettings.ProdTabRemoveChronoboost = ProductionTabUiProductionTabBasics.chBxRemoveChronoboost.Checked;
        }

        void chBxProductionTabSplitBuildingsUnits_CheckedChanged(object sender, EventArgs e)
        {
            PSettings.ProdTabSplitUnitsAndBuildings = ProductionTabUiProductionTabBasics.chBxSplitBuildingsUnits.Checked;
        }

        void chBxProductionTabRemoveClantag_CheckedChanged(object sender, EventArgs e)
        {
            PSettings.ProdTabRemoveClanTag = ProductionTabUiProductionTabBasics.chBxRemoveClantag.Checked;
        }

        void chBxProductionTabRemoveLocalplayer_CheckedChanged(object sender, EventArgs e)
        {
            PSettings.ProdTabRemoveLocalplayer = ProductionTabUiProductionTabBasics.chBxRemoveLocalplayer.Checked;
        }

        void chBxProductionTabRemoveNeutral_CheckedChanged(object sender, EventArgs e)
        {
            PSettings.ProdTabRemoveNeutral = ProductionTabUiProductionTabBasics.chBxRemoveNeutral.Checked;
        }

        void chBxProductionTabRemoveAllie_CheckedChanged(object sender, EventArgs e)
        {
            PSettings.ProdTabRemoveAllie = ProductionTabUiProductionTabBasics.chBxRemoveAllie.Checked;
        }

        void chBxProductionTabRemoveAi_CheckedChanged(object sender, EventArgs e)
        {
            PSettings.ProdTabRemoveAi = ProductionTabUiProductionTabBasics.chBxRemoveAi.Checked;
        }

        void chBxProductionTabShowUpgrades_CheckedChanged(object sender, EventArgs e)
        {
            PSettings.ProdTabShowUpgrades = ProductionTabUiProductionTabBasics.chBxShowUpgrades.Checked;
        }

        void chBxProductionTabShowUnits_CheckedChanged(object sender, EventArgs e)
        {
            PSettings.ProdTabShowUnits = ProductionTabUiProductionTabBasics.chBxShowUnits.Checked;
        }

        void chBxProductionTabShowBuildings_CheckedChanged(object sender, EventArgs e)
        {
            PSettings.ProdTabShowBuildings = ProductionTabUiProductionTabBasics.chBxShowBuildings.Checked;
        }




        #endregion

        #region Maphack

        private void addAUnitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddUnitsFromIcbToLst();
        }

        private void deleteAUnitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Select an item and click >>[Del]<<", "Delete item");
        }

        private void lstMapUnits_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Delete))
            {

                if (lstMapUnits.SelectedIndex >= 0)
                {
                    var iOldIndex = lstMapUnits.SelectedIndex;

                    var item = lstMapUnits.Items[lstMapUnits.SelectedIndex];
                    PSettings.MaphackUnitIds.Remove(
                        (PredefinedData.UnitId)Enum.Parse(typeof(PredefinedData.UnitId), item.ToString()));
                    lstMapUnits.Items.Remove(item);

                    if (lstMapUnits.Items.Count > iOldIndex)
                        lstMapUnits.SelectedItem = lstMapUnits.Items[iOldIndex];

                    else if (lstMapUnits.Items.Count > 0)
                        lstMapUnits.SelectedItem = lstMapUnits.Items[lstMapUnits.Items.Count - 1];

                }

            }
        }

        private void lstMapUnits_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstMapUnits.SelectedItems.Count == 1)
            {
                btnMapUnitColor.BackColor = PSettings.MaphackUnitColors[lstMapUnits.SelectedIndex];
                icbMapUnit.Text = lstMapUnits.SelectedItem.ToString();
            }
        }

        private void AddUnitsFromIcbToLst()
        {
            lstMapUnits.SelectedIndex = -1;

            /* Add a random entry */
            var rnd = new Random();
            var iNewItemToAdd = rnd.Next(0, icbMapUnit.Items.Count);

            foreach (var item in lstMapUnits.Items)
            {
                if (item.ToString().Equals(icbMapUnit.Items[iNewItemToAdd].ToString()))
                    MessageBox.Show("The item \"" + item + "\" already exists!", "Double items found!");
            }

            lstMapUnits.Items.Add(icbMapUnit.Items[iNewItemToAdd]);

            const PredefinedData.UnitId id = PredefinedData.UnitId.TuScv;

            if (PSettings.MaphackUnitIds == null)
                PSettings.MaphackUnitIds = new List<PredefinedData.UnitId>();

            if (PSettings.MaphackUnitColors == null)
                PSettings.MaphackUnitColors = new List<Color>();

            /* Random Color */
            var iRed = rnd.Next(0, 255);
            var iGreen = rnd.Next(0, 255);
            var iBlue = rnd.Next(0, 255);

            PSettings.MaphackUnitIds.Add(id);
            PSettings.MaphackUnitColors.Add(Color.FromArgb(255, iRed, iGreen, iBlue));


            lstMapUnits.SelectedIndex = lstMapUnits.Items.Count - 1;
        }

        private void btnMapAddUnit_Click(object sender, EventArgs e)
        {
            AddUnitsFromIcbToLst();

        }

        private void icbMapUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (var i = 0; i < lstMapUnits.Items.Count; i++)
            {
                for (var j = 0; j < lstMapUnits.SelectedItems.Count; j++)
                {
                    if (lstMapUnits.Items[i].Equals(lstMapUnits.SelectedItems[j]))
                    {
                        PSettings.MaphackUnitIds[i] = (PredefinedData.UnitId)Enum.Parse(typeof(PredefinedData.UnitId), icbMapUnit.Text);
                        //PSettings.MaphackUnitColors[i] = btnMapUnitColor.BackColor;

                        foreach (var item in lstMapUnits.Items)
                        {
                            if (item.ToString() == lstMapUnits.SelectedItem.ToString())
                                continue;

                            if (item.ToString().Equals(icbMapUnit.Text))
                                MessageBox.Show("The item \"" + item + "\" already exists!", "Double items found!");
                        }

                        lstMapUnits.Items[i] = icbMapUnit.Text;
                    }
                }
            }


        }

        private void btnMapUnitColor_MouseDown(object sender, MouseEventArgs e)
        {
            var clDia = new ColorDialog();

            var result = new DialogResult();


            if (e.Button.Equals(MouseButtons.Left))
                result = clDia.ShowDialog();

            for (var i = 0; i < lstMapUnits.Items.Count; i++)
            {
                for (var j = 0; j < lstMapUnits.SelectedItems.Count; j++)
                {
                    if (lstMapUnits.Items[i].Equals(lstMapUnits.SelectedItems[j]))
                    {
                        if (e.Button.Equals(MouseButtons.Right))
                        {
                            btnMapUnitColor.BackColor = Color.Transparent;
                            PSettings.MaphackUnitColors[i] = Color.Transparent;
                        }

                        else if (e.Button.Equals(MouseButtons.Left))
                        {
                            if (result.Equals(DialogResult.OK))
                                PSettings.MaphackUnitColors[i] = clDia.Color;

                            btnMapUnitColor.BackColor = PSettings.MaphackUnitColors[i];
                        }
                    }
                }
            }

            lstMapUnits.Invalidate();
        }

        void chBxMaphackRemoveNeutral_CheckedChanged(object sender, EventArgs e)
        {
            PSettings.MaphackRemoveNeutral = MaphackUiMaphackBasics.chBxRemoveNeutral.Checked;
        }

        void chBxMaphackRemoveLocalplayer_CheckedChanged(object sender, EventArgs e)
        {
            PSettings.MaphackRemoveLocalplayer = MaphackUiMaphackBasics.chBxRemoveLocalplayer.Checked;
        }

        void chBxMaphackRemoveAllie_CheckedChanged(object sender, EventArgs e)
        {
            PSettings.MaphackRemoveAllie = MaphackUiMaphackBasics.chBxRemoveAllie.Checked;
        }

        void chBxMaphackRemoveAi_CheckedChanged(object sender, EventArgs e)
        {
            PSettings.MaphackRemoveAi = MaphackUiMaphackBasics.chBxRemoveAi.Checked;
        }

        private void ChBxMaphackDisableDestinationLineCheckedChanged(object sender, EventArgs e)
        {
            PSettings.MaphackDisableDestinationLine = MaphackUiMaphackBasics.chBxMaphackDisableDestinationLine.Checked;
        }

        private void tbMaphackOpacity_Scroll(object sender, EventArgs e)
        {
            PSettings.MaphackOpacity = (double)MaphackUiMaphackBasics.OcUiOpacity.tbOpacity.Value / 100;
        }

        private void lstMapUnits_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();

            if (e.Index > -1)
                e.Graphics.DrawString(lstMapUnits.Items[e.Index].ToString(), new Font(Font.Name, Font.Size, FontStyle.Bold), new SolidBrush(PSettings.MaphackUnitColors[e.Index]), e.Bounds);

            e.DrawFocusRectangle();
        }

        private void btnMaphackDestinationLine_Click(object sender, EventArgs e)
        {
            var clDia = new ColorDialog();

            var cl = clDia.ShowDialog();

            if (cl.Equals(DialogResult.OK))
                PSettings.MaphackDestinationColor = clDia.Color;

            MaphackUiMaphackBasics.btnDestinationLine.BackColor = PSettings.MaphackDestinationColor;
        }

        private void txtMaphackTogglePanel_TextChanged(object sender, EventArgs e)
        {
            if (MaphackUiChatInput.txtToggle.Text.Length > 0)
                PSettings.MaphackTogglePanel = MaphackUiChatInput.txtToggle.Text;
        }

        private void txtMaphackPositionPanel_TextChanged(object sender, EventArgs e)
        {
            if (MaphackUiChatInput.txtPosition.Text.Length > 0)
                PSettings.MaphackChangePositionPanel = MaphackUiChatInput.txtPosition.Text;
        }

        private void txtMaphackChangeSizePanel_TextChanged(object sender, EventArgs e)
        {
            if (MaphackUiChatInput.txtSize.Text.Length > 0)
                PSettings.MaphackChangeSizePanel = MaphackUiChatInput.txtSize.Text;
        }

        private void txtMaphackHotkey1_KeyDown(object sender, KeyEventArgs e)
        {
            MaphackUiHotkeys.txtHotkey1.Text = e.KeyCode.ToString();
            PSettings.MaphackHotkey1 = e.KeyCode;
            e.SuppressKeyPress = true;
        }

        private void txtMaphackHotkey2_KeyDown(object sender, KeyEventArgs e)
        {
            MaphackUiHotkeys.txtHotkey2.Text = e.KeyCode.ToString();
            PSettings.MaphackHotkey2 = e.KeyCode;
            e.SuppressKeyPress = true;
        }

        private void txtMaphackHotkey3_KeyDown(object sender, KeyEventArgs e)
        {
            MaphackUiHotkeys.txtHotkey3.Text = e.KeyCode.ToString();
            PSettings.MaphackHotkey3 = e.KeyCode;
            e.SuppressKeyPress = true;
        }

        private void ChBxMaphackMaphackColorDefensiveStructuresYellowCheckedChanged(object sender, EventArgs e)
        {
            PSettings.MaphackColorDefensivestructuresYellow = MaphackUiMaphackBasics.chBxMaphackColorDefensiveStructuresYellow.Checked;
        }

        private void ChBxMaphackMaphackRemVisionAreaCheckedChanged(object sender, EventArgs e)
        {
            PSettings.MaphackRemoveVisionArea = MaphackUiMaphackBasics.chBxMaphackRemVisionArea.Checked;
        }

        private void ChBxMaphackMapRemCameraCheckedChanged(object sender, EventArgs e)
        {
            PSettings.MaphackRemoveCamera = MaphackUiMaphackBasics.chBxMaphackRemCamera.Checked;
        }

        /* Throw images and Strings into the Imageboxes [Maphack] */
        private void SetImageCombolist()
        {
            #region Image Combobox Global Units

            /* Terran Buildings */
            icbMapUnit.Items.Add(new ImageComboItem("TbCcGround", 50, true));
            icbMapUnit.Items.Add(new ImageComboItem("TbOrbitalGround", 51, true));
            icbMapUnit.Items.Add(new ImageComboItem("TbPlanetary", 52, true));
            icbMapUnit.Items.Add(new ImageComboItem("TbSupplyGround", 53, true));
            icbMapUnit.Items.Add(new ImageComboItem("TbBarracksGround", 54, true));
            icbMapUnit.Items.Add(new ImageComboItem("TbRefinery", 55, true));
            icbMapUnit.Items.Add(new ImageComboItem("TbEbay", 56, true));
            icbMapUnit.Items.Add(new ImageComboItem("TbBunker", 57, true));
            icbMapUnit.Items.Add(new ImageComboItem("TbTurret", 58, true));
            icbMapUnit.Items.Add(new ImageComboItem("TbSensortower", 59, true));
            icbMapUnit.Items.Add(new ImageComboItem("TbGhostacademy", 60, true));
            icbMapUnit.Items.Add(new ImageComboItem("TbFactoryGround", 61, true));
            icbMapUnit.Items.Add(new ImageComboItem("TbStarportGround", 62, true));
            icbMapUnit.Items.Add(new ImageComboItem("TbArmory", 63, true));
            icbMapUnit.Items.Add(new ImageComboItem("TbFusioncore", 64, true));

            /* Protoss Buildings */
            icbMapUnit.Items.Add(new ImageComboItem("PbNexus", 65, true));
            icbMapUnit.Items.Add(new ImageComboItem("PbPylon", 66, true));
            icbMapUnit.Items.Add(new ImageComboItem("PbAssimilator", 67, true));
            icbMapUnit.Items.Add(new ImageComboItem("PbGateway", 68, true));
            icbMapUnit.Items.Add(new ImageComboItem("PbWarpgate", 69, true));
            icbMapUnit.Items.Add(new ImageComboItem("PbForge", 70, true));
            icbMapUnit.Items.Add(new ImageComboItem("PbCybercore", 71, true));
            icbMapUnit.Items.Add(new ImageComboItem("PbCannon", 72, true));
            icbMapUnit.Items.Add(new ImageComboItem("PbRoboticsbay", 73, true));
            icbMapUnit.Items.Add(new ImageComboItem("PbRoboticssupportbay", 74, true));
            icbMapUnit.Items.Add(new ImageComboItem("PbStargate", 75, true));
            icbMapUnit.Items.Add(new ImageComboItem("PbFleetbeacon", 76, true));
            icbMapUnit.Items.Add(new ImageComboItem("PbTwilightcouncil", 77, true));
            icbMapUnit.Items.Add(new ImageComboItem("PbDarkshrine", 78, true));
            icbMapUnit.Items.Add(new ImageComboItem("PbTemplararchives", 79, true));

            /* Zerg Buildings */
            icbMapUnit.Items.Add(new ImageComboItem("ZbHatchery", 80, true));
            icbMapUnit.Items.Add(new ImageComboItem("ZbLiar", 81, true));
            icbMapUnit.Items.Add(new ImageComboItem("ZbHive", 82, true));
            icbMapUnit.Items.Add(new ImageComboItem("ZbSpawningPool", 83, true));
            icbMapUnit.Items.Add(new ImageComboItem("ZbBanelingNest", 84, true));
            icbMapUnit.Items.Add(new ImageComboItem("ZbExtractor", 85, true));
            icbMapUnit.Items.Add(new ImageComboItem("ZbEvolutionChamber", 86, true));
            icbMapUnit.Items.Add(new ImageComboItem("ZbSporeCrawler", 87, true));
            icbMapUnit.Items.Add(new ImageComboItem("ZbSpineCrawler", 88, true));
            icbMapUnit.Items.Add(new ImageComboItem("ZbRoachWarren", 89, true));
            icbMapUnit.Items.Add(new ImageComboItem("ZbSpire", 90, true));
            icbMapUnit.Items.Add(new ImageComboItem("ZbHydraDen", 91, true));
            icbMapUnit.Items.Add(new ImageComboItem("ZbInfestationPit", 92, true));
            icbMapUnit.Items.Add(new ImageComboItem("ZbNydusWorm", 93, true));
            icbMapUnit.Items.Add(new ImageComboItem("ZbNydusNetwork", 94, true));
            icbMapUnit.Items.Add(new ImageComboItem("ZbUltraCavern", 95, true));
            icbMapUnit.Items.Add(new ImageComboItem("ZbGreaterspire", 96, true));
            icbMapUnit.Items.Add(new ImageComboItem("ZbCreeptumor", 97, true));

            /* Terran Units */
            icbMapUnit.Items.Add(new ImageComboItem("TuScv", 0, true));
            icbMapUnit.Items.Add(new ImageComboItem("TuMule", 1, true));
            icbMapUnit.Items.Add(new ImageComboItem("TuMarine", 2, true));
            icbMapUnit.Items.Add(new ImageComboItem("TuMarauder", 3, true));
            icbMapUnit.Items.Add(new ImageComboItem("TuGhost", 4, true));
            icbMapUnit.Items.Add(new ImageComboItem("TuReaper", 5, true));
            icbMapUnit.Items.Add(new ImageComboItem("TuHellion", 6, true));
            icbMapUnit.Items.Add(new ImageComboItem("TuHellbat", 7, true));
            icbMapUnit.Items.Add(new ImageComboItem("TuWidowMine", 8, true));
            icbMapUnit.Items.Add(new ImageComboItem("TuSiegetank", 9, true));
            icbMapUnit.Items.Add(new ImageComboItem("TuThor", 10, true));
            icbMapUnit.Items.Add(new ImageComboItem("TuMedivac", 11, true));
            icbMapUnit.Items.Add(new ImageComboItem("TuBanshee", 12, true));
            icbMapUnit.Items.Add(new ImageComboItem("TuVikingAir", 13, true));
            icbMapUnit.Items.Add(new ImageComboItem("TuRaven", 14, true));
            icbMapUnit.Items.Add(new ImageComboItem("TuBattlecruiser", 15, true));

            /* Protoss Units */
            icbMapUnit.Items.Add(new ImageComboItem("PuProbe", 16, true));
            icbMapUnit.Items.Add(new ImageComboItem("PuMothershipCore", 17, true));
            icbMapUnit.Items.Add(new ImageComboItem("PuZealot", 18, true));
            icbMapUnit.Items.Add(new ImageComboItem("PuStalker", 19, true));
            icbMapUnit.Items.Add(new ImageComboItem("PuSentry", 20, true));
            icbMapUnit.Items.Add(new ImageComboItem("PuHightemplar", 21, true));
            icbMapUnit.Items.Add(new ImageComboItem("PuDarktemplar", 22, true));
            icbMapUnit.Items.Add(new ImageComboItem("PuArchon", 23, true));
            icbMapUnit.Items.Add(new ImageComboItem("PuImmortal", 24, true));
            icbMapUnit.Items.Add(new ImageComboItem("PuObserver", 25, true));
            icbMapUnit.Items.Add(new ImageComboItem("PuWarpprismTransport", 26, true));
            icbMapUnit.Items.Add(new ImageComboItem("PuColossus", 27, true));
            icbMapUnit.Items.Add(new ImageComboItem("PuPhoenix", 28, true));
            icbMapUnit.Items.Add(new ImageComboItem("PuOracle", 29, true));
            icbMapUnit.Items.Add(new ImageComboItem("PuVoidray", 30, true));
            icbMapUnit.Items.Add(new ImageComboItem("PuCarrier", 31, true));
            icbMapUnit.Items.Add(new ImageComboItem("PuTempest", 32, true));
            icbMapUnit.Items.Add(new ImageComboItem("PuMothership", 33, true));

            /* Zerg Units */
            icbMapUnit.Items.Add(new ImageComboItem("ZuLarva", 34, true));
            icbMapUnit.Items.Add(new ImageComboItem("ZuDrone", 35, true));
            icbMapUnit.Items.Add(new ImageComboItem("ZuOverlord", 36, true));
            icbMapUnit.Items.Add(new ImageComboItem("ZuQueen", 37, true));
            icbMapUnit.Items.Add(new ImageComboItem("ZuZergling", 38, true));
            icbMapUnit.Items.Add(new ImageComboItem("ZuBanelingCocoon", 98, true));
            icbMapUnit.Items.Add(new ImageComboItem("ZuBaneling", 39, true));
            icbMapUnit.Items.Add(new ImageComboItem("ZuRoach", 40, true));
            icbMapUnit.Items.Add(new ImageComboItem("ZuHydralisk", 41, true));
            icbMapUnit.Items.Add(new ImageComboItem("ZuOverseerCocoon", 100, true));
            icbMapUnit.Items.Add(new ImageComboItem("ZuOverseer", 42, true));
            icbMapUnit.Items.Add(new ImageComboItem("ZuMutalisk", 43, true));
            icbMapUnit.Items.Add(new ImageComboItem("ZuCorruptor", 44, true));
            icbMapUnit.Items.Add(new ImageComboItem("ZuInfestor", 45, true));
            icbMapUnit.Items.Add(new ImageComboItem("ZuBroodlordCocoon", 99, true));
            icbMapUnit.Items.Add(new ImageComboItem("ZuBroodlord", 46, true));
            icbMapUnit.Items.Add(new ImageComboItem("ZuUltra", 47, true));
            icbMapUnit.Items.Add(new ImageComboItem("ZuViper", 48, true));
            icbMapUnit.Items.Add(new ImageComboItem("ZuSwarmHost", 49, true));
            icbMapUnit.Items.Add(new ImageComboItem("ZuLocust", 101, true));
            icbMapUnit.Items.Add(new ImageComboItem("ZuChangeling", 102, true));

            #endregion
        }

        #endregion

        #region Debug

        /* Export a file with all information (ID's and Names) of units */
        private void btnExportFile_Click(object sender, EventArgs e)
        {
            ExportUnitIdsToFile();
        }


        private byte _bMaxPlayer;
        private short _sMaxUnit;
        private byte _bPlayerNum;
        private short _sUnitNum;
        private void btnPlayerBack_Click(object sender, EventArgs e)
        {
            if (_bPlayerNum > 0 && _bPlayerNum < _bMaxPlayer)
                _bPlayerNum -= 1;

            CustDebug.PlayerInfo.lblPlayerNum.Text = _bPlayerNum.ToString(CultureInfo.InvariantCulture) + "/" + (_bMaxPlayer - 1).ToString(CultureInfo.InvariantCulture);
            SetPlayerListboxInformation();
        }

        private void btnPlayerNext_Click(object sender, EventArgs e)
        {
            if (_bPlayerNum < _bMaxPlayer - 1)
                _bPlayerNum += 1;

            CustDebug.PlayerInfo.lblPlayerNum.Text = _bPlayerNum.ToString(CultureInfo.InvariantCulture) + "/" + (_bMaxPlayer - 1).ToString(CultureInfo.InvariantCulture);
            SetPlayerListboxInformation();
        }

        private void btnUnitBack_Click(object sender, EventArgs e)
        {
            if (_sUnitNum > 0 && _sUnitNum < _sMaxUnit)
                _sUnitNum -= 1;

            CustDebug.UnitInfo.lblUnitNum.Text = _sUnitNum.ToString(CultureInfo.InvariantCulture) + "/" + (_sMaxUnit - 1).ToString(CultureInfo.InvariantCulture);
            SetUnitListboxInformation();
        }

        private void btnUnitNext_Click(object sender, EventArgs e)
        {
            if (_sUnitNum < _sMaxUnit - 1 && _sUnitNum > -1)
                _sUnitNum += 1;

            CustDebug.UnitInfo.lblUnitNum.Text = _sUnitNum.ToString(CultureInfo.InvariantCulture) + "/" + (_sMaxUnit - 1).ToString(CultureInfo.InvariantCulture);
            SetUnitListboxInformation();
        }

        private void txtUnitNum_TextChanged(object sender, EventArgs e)
        {
            if (CustDebug.UnitInfo.txtUnitNum.Text.Length <= 0)
                return;

            int iDummy;
            if (Int32.TryParse(CustDebug.UnitInfo.txtUnitNum.Text, out iDummy))
            {
                if (iDummy < 0)
                {
                    CustDebug.UnitInfo.txtUnitNum.Text = "0";
                    iDummy = 0;
                    CustDebug.UnitInfo.txtUnitNum.Select(0.ToString(CultureInfo.InvariantCulture).Length, 0);
                }

                if (iDummy > _sMaxUnit - 1)
                {
                    CustDebug.UnitInfo.txtUnitNum.Text = (_sMaxUnit - 1).ToString(CultureInfo.InvariantCulture);
                    iDummy = _sMaxUnit - 1;
                    CustDebug.UnitInfo.txtUnitNum.Select(_sMaxUnit.ToString(CultureInfo.InvariantCulture).Length, 0);
                }

                _sUnitNum = (short)iDummy;
                SetUnitListboxInformation();
            }

            /* Remove non- digits */
            if (!char.IsDigit(CustDebug.UnitInfo.txtUnitNum.Text[CustDebug.UnitInfo.txtUnitNum.Text.Length - 1]))
            {
                CustDebug.UnitInfo.txtUnitNum.Text = CustDebug.UnitInfo.txtUnitNum.Text.Remove(CustDebug.UnitInfo.txtUnitNum.Text.Length - 1);
                CustDebug.UnitInfo.txtUnitNum.Select(CustDebug.UnitInfo.txtUnitNum.Text.Length, 0);
            }
        }

        private void PlayerInfo_Load(object sender, EventArgs e)
        {
            SetPlayerListboxInformation();
        }

        private void UnitInfo_Load(object sender, EventArgs e)
        {
            SetUnitListboxInformation();
        }

        /* Insert the basic playerinfo into the listbox */
        private void SetPlayerListboxInformation()
        {

            if (GInformation == null)
                return;

            if (GInformation.Player == null)
                return;

            if (GInformation.Player.Count <= 0)
                return;


            try
            {

                _bMaxPlayer = (byte)GInformation.Player.Count;

                if (CustDebug.PlayerInfo.lstPlayerInformation.Items.Count <= 0)
                {

                    CustDebug.PlayerInfo.lstPlayerInformation.Items.Clear();
                    CustDebug.PlayerInfo.lblPlayerNum.Text = _bPlayerNum.ToString(CultureInfo.InvariantCulture) + "/" +
                                                             (_bMaxPlayer - 1).ToString(CultureInfo.InvariantCulture);


                    CustDebug.PlayerInfo.lstPlayerInformation.Items.Add("IsLocalplayer: " +
                                                                        GInformation.Player[_bPlayerNum].IsLocalplayer);

                    CustDebug.PlayerInfo.lstPlayerInformation.Items.Add("Camera X: " +
                                                                        GInformation.Player[_bPlayerNum].CameraPositionX);
                    CustDebug.PlayerInfo.lstPlayerInformation.Items.Add("Camera Y: " +
                                                                        GInformation.Player[_bPlayerNum].CameraPositionY);
                    CustDebug.PlayerInfo.lstPlayerInformation.Items.Add("Camera Distance: " +
                                                                        GInformation.Player[_bPlayerNum].CameraDistance);
                    CustDebug.PlayerInfo.lstPlayerInformation.Items.Add("Camera Angle: " +
                                                                        GInformation.Player[_bPlayerNum].CameraAngle);
                    CustDebug.PlayerInfo.lstPlayerInformation.Items.Add("Camera Rotation: " +
                                                                        GInformation.Player[_bPlayerNum].CameraRotation);
                    CustDebug.PlayerInfo.lstPlayerInformation.Items.Add("Team: " + GInformation.Player[_bPlayerNum].Team);
                    CustDebug.PlayerInfo.lstPlayerInformation.Items.Add("Type: " + GInformation.Player[_bPlayerNum].Type);
                    CustDebug.PlayerInfo.lstPlayerInformation.Items.Add("Status: " +
                                                                        GInformation.Player[_bPlayerNum].Status);
                    CustDebug.PlayerInfo.lstPlayerInformation.Items.Add("Name: " + GInformation.Player[_bPlayerNum].Name);
                    CustDebug.PlayerInfo.lstPlayerInformation.Items.Add("Color: " +
                                                                        GInformation.Player[_bPlayerNum].Color.Name);
                    CustDebug.PlayerInfo.lstPlayerInformation.Items.Add("Account ID: " +
                                                                        GInformation.Player[_bPlayerNum].AccountId);
                    CustDebug.PlayerInfo.lstPlayerInformation.Items.Add("Apm: " + GInformation.Player[_bPlayerNum].Apm);
                    CustDebug.PlayerInfo.lstPlayerInformation.Items.Add("Epm: " + GInformation.Player[_bPlayerNum].Epm);
                    CustDebug.PlayerInfo.lstPlayerInformation.Items.Add("Workers: " +
                                                                        GInformation.Player[_bPlayerNum].Worker);
                    CustDebug.PlayerInfo.lstPlayerInformation.Items.Add("Minerals: " +
                                                                        GInformation.Player[_bPlayerNum].Minerals);
                    CustDebug.PlayerInfo.lstPlayerInformation.Items.Add("Vespine: " +
                                                                        GInformation.Player[_bPlayerNum].Gas);
                    CustDebug.PlayerInfo.lstPlayerInformation.Items.Add("Minerals Income: " +
                                                                        GInformation.Player[_bPlayerNum].MineralsIncome);
                    CustDebug.PlayerInfo.lstPlayerInformation.Items.Add("Vespine Income: " +
                                                                        GInformation.Player[_bPlayerNum].GasIncome);
                    CustDebug.PlayerInfo.lstPlayerInformation.Items.Add("Minerals Army: " +
                                                                        GInformation.Player[_bPlayerNum].MineralsArmy);
                    CustDebug.PlayerInfo.lstPlayerInformation.Items.Add("Vespine Army: " +
                                                                        GInformation.Player[_bPlayerNum].GasArmy);
                }

                else
                {
                    CustDebug.PlayerInfo.lstPlayerInformation.Items[0] = "Name: " +
                                                                         GInformation.Player[_bPlayerNum].Name;
                    CustDebug.PlayerInfo.lstPlayerInformation.Items[1] = "IsLocalplayer: " +
                                                                         GInformation.Player[_bPlayerNum].IsLocalplayer;
                    CustDebug.PlayerInfo.lstPlayerInformation.Items[2] = "Camera X: " +
                                                                         GInformation.Player[_bPlayerNum]
                                                                             .CameraPositionX;
                    CustDebug.PlayerInfo.lstPlayerInformation.Items[3] = "Camera Y: " +
                                                                         GInformation.Player[_bPlayerNum]
                                                                             .CameraPositionY;
                    CustDebug.PlayerInfo.lstPlayerInformation.Items[4] = "Camera Distance: " +
                                                                         GInformation.Player[_bPlayerNum].CameraDistance;
                    CustDebug.PlayerInfo.lstPlayerInformation.Items[5] = "Camera Angle: " +
                                                                         GInformation.Player[_bPlayerNum].CameraAngle;
                    CustDebug.PlayerInfo.lstPlayerInformation.Items[6] = "Camera Rotation: " +
                                                                         GInformation.Player[_bPlayerNum].CameraRotation;
                    CustDebug.PlayerInfo.lstPlayerInformation.Items[7] = "Team: " +
                                                                         GInformation.Player[_bPlayerNum].Team;
                    CustDebug.PlayerInfo.lstPlayerInformation.Items[8] = "Type: " +
                                                                         GInformation.Player[_bPlayerNum].Type;
                    CustDebug.PlayerInfo.lstPlayerInformation.Items[9] = "Status: " +
                                                                         GInformation.Player[_bPlayerNum].Status;
                    CustDebug.PlayerInfo.lstPlayerInformation.Items[10] = "Color: " +
                                                                          GInformation.Player[_bPlayerNum].Color.Name;
                    CustDebug.PlayerInfo.lstPlayerInformation.Items[11] = "Account ID: " +
                                                                          GInformation.Player[_bPlayerNum].AccountId;
                    CustDebug.PlayerInfo.lstPlayerInformation.Items[12] = "Apm: " + GInformation.Player[_bPlayerNum].Apm +
                                                                          " - [" +
                                                                          GInformation.Player[_bPlayerNum].ApmAverage +
                                                                          "]";
                    CustDebug.PlayerInfo.lstPlayerInformation.Items[13] = "Epm: " + GInformation.Player[_bPlayerNum].Epm +
                                                                          " - [" +
                                                                          GInformation.Player[_bPlayerNum].EpmAverage +
                                                                          "]";
                    CustDebug.PlayerInfo.lstPlayerInformation.Items[14] = "Workers: " +
                                                                          GInformation.Player[_bPlayerNum].Worker;
                    CustDebug.PlayerInfo.lstPlayerInformation.Items[15] = "Minerals: " +
                                                                          GInformation.Player[_bPlayerNum].Minerals;
                    CustDebug.PlayerInfo.lstPlayerInformation.Items[16] = "Vespine: " +
                                                                          GInformation.Player[_bPlayerNum].Gas;
                    CustDebug.PlayerInfo.lstPlayerInformation.Items[17] = "Minerals Income: " +
                                                                          GInformation.Player[_bPlayerNum]
                                                                              .MineralsIncome;
                    CustDebug.PlayerInfo.lstPlayerInformation.Items[18] = "Vespine Income: " +
                                                                          GInformation.Player[_bPlayerNum].GasIncome;
                    CustDebug.PlayerInfo.lstPlayerInformation.Items[19] = "Minerals Army: " +
                                                                          GInformation.Player[_bPlayerNum].MineralsArmy;
                    CustDebug.PlayerInfo.lstPlayerInformation.Items[20] = "Vespine Army: " +
                                                                          GInformation.Player[_bPlayerNum].GasArmy;

                }
            }
            catch { }

            CustDebug.lblPlayerObjects.Text = "Player Objects (in memory): " + PredefinedData.PlayerStruct.ClassObjectCount;
        }

        /* Insert the basic unitinfo into the listbox */
        private void SetUnitListboxInformation()
        {
            if (GInformation == null)
                return;

            if (GInformation.Unit == null)
                return;

            if (GInformation.Unit.Count <= 0)
                return;




            _sMaxUnit = (short)GInformation.Unit.Count;
            CustDebug.UnitInfo.lblUnitNum.Text = _sUnitNum.ToString(CultureInfo.InvariantCulture) + "/" + (_sMaxUnit - 1).ToString(CultureInfo.InvariantCulture);

            if (CustDebug.UnitInfo.lstUnitInformation.Items.Count <= 0)
            {
                CustDebug.UnitInfo.lstUnitInformation.Items.Clear();
                CustDebug.UnitInfo.lblUnitNum.Text = _sUnitNum.ToString(CultureInfo.InvariantCulture) + "/" +
                                                     (_sMaxUnit - 1).ToString(CultureInfo.InvariantCulture);


                CustDebug.UnitInfo.lstUnitInformation.Items.Add("Unit Id: " + (int)GInformation.Unit[_sUnitNum].Id);
                CustDebug.UnitInfo.lstUnitInformation.Items.Add("Unit Name: " + GInformation.Unit[_sUnitNum].Name);
                CustDebug.UnitInfo.lstUnitInformation.Items.Add("Unit RawName: " + GInformation.Unit[_sUnitNum].RawName);
                CustDebug.UnitInfo.lstUnitInformation.Items.Add("Unit Max Hp: " +
                                                                GInformation.Unit[_sUnitNum].MaximumHealth);
                CustDebug.UnitInfo.lstUnitInformation.Items.Add("Unit Size: " + GInformation.Unit[_sUnitNum].Size);
                CustDebug.UnitInfo.lstUnitInformation.Items.Add("Number of Queued Units: " +
                                                                GInformation.Unit[_sUnitNum].ProdNumberOfQueuedUnits);
                CustDebug.UnitInfo.lstUnitInformation.Items.Add("Model- Pointer: " +
                                                                GInformation.Unit[_sUnitNum].ModelPointer.ToString("X8"));
                CustDebug.UnitInfo.lstUnitInformation.Items.Add("TargetFilter: " +
                                                                GInformation.Unit[_sUnitNum].TargetFilter);
                CustDebug.UnitInfo.lstUnitInformation.Items.Add("RandomFlag: " + GInformation.Unit[_sUnitNum].RandomFlag);

                if (GInformation.Player.Count > GInformation.Unit[_sUnitNum].Owner)
                    CustDebug.UnitInfo.lstUnitInformation.Items.Add("Owner: " + GInformation.Unit[_sUnitNum].Owner +
                                                                    " (" +
                                                                    GInformation.Player[
                                                                        GInformation.Unit[_sUnitNum].Owner]
                                                                        .Name + ")");
                CustDebug.UnitInfo.lstUnitInformation.Items.Add("Pos. X: " + GInformation.Unit[_sUnitNum].PositionX);
                CustDebug.UnitInfo.lstUnitInformation.Items.Add("Pos. Y: " + GInformation.Unit[_sUnitNum].PositionY);
                CustDebug.UnitInfo.lstUnitInformation.Items.Add("Dest. Pos. X: " +
                                                                GInformation.Unit[_sUnitNum].DestinationPositionX);
                CustDebug.UnitInfo.lstUnitInformation.Items.Add("Dest. Pos. Y: " +
                                                                GInformation.Unit[_sUnitNum].DestinationPositionY);
                CustDebug.UnitInfo.lstUnitInformation.Items.Add("Time Till Death " +
                                                                GInformation.Unit[_sUnitNum].AliveSince);
                CustDebug.UnitInfo.lstUnitInformation.Items.Add("Hp Damage: " + GInformation.Unit[_sUnitNum].DamageTaken);
                CustDebug.UnitInfo.lstUnitInformation.Items.Add("Energy: " + GInformation.Unit[_sUnitNum].Energy);
                CustDebug.UnitInfo.lstUnitInformation.Items.Add("IsAlive: " + GInformation.Unit[_sUnitNum].IsAlive);
                CustDebug.UnitInfo.lstUnitInformation.Items.Add("IsCloaked: " + GInformation.Unit[_sUnitNum].IsCloaked);
                CustDebug.UnitInfo.lstUnitInformation.Items.Add("IsStructure: " +
                                                                GInformation.Unit[_sUnitNum].IsStructure);
                CustDebug.UnitInfo.lstUnitInformation.Items.Add("IsUnderConstruction: " +
                                                                GInformation.Unit[_sUnitNum].IsUnderConstruction);
                CustDebug.UnitInfo.lstUnitInformation.Items.Add("IsAir: " + GInformation.Unit[_sUnitNum].IsAir);
                CustDebug.UnitInfo.lstUnitInformation.Items.Add("IsArmored: " + GInformation.Unit[_sUnitNum].IsArmored);
                CustDebug.UnitInfo.lstUnitInformation.Items.Add("IsBiological: " +
                                                                GInformation.Unit[_sUnitNum].IsBiological);
                CustDebug.UnitInfo.lstUnitInformation.Items.Add("IsBurried: " + GInformation.Unit[_sUnitNum].IsBurried);
                CustDebug.UnitInfo.lstUnitInformation.Items.Add("IsDetector: " + GInformation.Unit[_sUnitNum].IsDetector);
                CustDebug.UnitInfo.lstUnitInformation.Items.Add("IsGround: " + GInformation.Unit[_sUnitNum].IsGround);
                CustDebug.UnitInfo.lstUnitInformation.Items.Add("IsHallucination: " +
                                                                GInformation.Unit[_sUnitNum].IsHallucination);
                CustDebug.UnitInfo.lstUnitInformation.Items.Add("IsLight: " + GInformation.Unit[_sUnitNum].IsLight);
                CustDebug.UnitInfo.lstUnitInformation.Items.Add("IsMassive: " + GInformation.Unit[_sUnitNum].IsMassive);
                CustDebug.UnitInfo.lstUnitInformation.Items.Add("IsMechanical: " +
                                                                GInformation.Unit[_sUnitNum].IsMechanical);
                CustDebug.UnitInfo.lstUnitInformation.Items.Add("IsPsionic: " + GInformation.Unit[_sUnitNum].IsPsionic);
                CustDebug.UnitInfo.lstUnitInformation.Items.Add("IsRobotic: " + GInformation.Unit[_sUnitNum].IsRobotic);
                CustDebug.UnitInfo.lstUnitInformation.Items.Add("IsVisible: " + GInformation.Unit[_sUnitNum].IsVisible);
            }

            else
            {
                CustDebug.UnitInfo.lstUnitInformation.Items[0] = "Unit Id: " + (int)GInformation.Unit[_sUnitNum].Id + " - [0x" + ((int)GInformation.Unit[_sUnitNum].Id).ToString("X4") + "]";
                CustDebug.UnitInfo.lstUnitInformation.Items[1] = "Unit Name: " + GInformation.Unit[_sUnitNum].Name;
                CustDebug.UnitInfo.lstUnitInformation.Items[2] = "Unit RawName: " + GInformation.Unit[_sUnitNum].RawName;
                CustDebug.UnitInfo.lstUnitInformation.Items[3] = "Unit Max Hp: " + GInformation.Unit[_sUnitNum].MaximumHealth;
                CustDebug.UnitInfo.lstUnitInformation.Items[4] = "Unit Size: " + GInformation.Unit[_sUnitNum].Size;
                CustDebug.UnitInfo.lstUnitInformation.Items[5] = "Number of Queued Units: " + GInformation.Unit[_sUnitNum].ProdNumberOfQueuedUnits;
                CustDebug.UnitInfo.lstUnitInformation.Items[6] = "Model- Pointer: 0x" + GInformation.Unit[_sUnitNum].ModelPointer.ToString("X8");
                CustDebug.UnitInfo.lstUnitInformation.Items[7] = "TargetFilter: " +
                                                                GInformation.Unit[_sUnitNum].TargetFilter;
                CustDebug.UnitInfo.lstUnitInformation.Items[8] = "RandomFlag: " + GInformation.Unit[_sUnitNum].RandomFlag;
                CustDebug.UnitInfo.lstUnitInformation.Items[9] = "Owner: " + GInformation.Unit[_sUnitNum].Owner +
                                                                    " (" +
                                                                    GInformation.Player[
                                                                        GInformation.Unit[_sUnitNum].Owner]
                                                                        .Name + ")";
                CustDebug.UnitInfo.lstUnitInformation.Items[10] = "Pos. X: " + GInformation.Unit[_sUnitNum].PositionX;
                CustDebug.UnitInfo.lstUnitInformation.Items[11] = "Pos. Y: " + GInformation.Unit[_sUnitNum].PositionY;
                CustDebug.UnitInfo.lstUnitInformation.Items[12] = "Dest. Pos. X: " +
                                                                  GInformation.Unit[_sUnitNum].DestinationPositionX;
                CustDebug.UnitInfo.lstUnitInformation.Items[13] = "Dest. Pos. Y: " +
                                                                GInformation.Unit[_sUnitNum].DestinationPositionY;
                CustDebug.UnitInfo.lstUnitInformation.Items[14] = "Alive -timer: " +
                                                                GInformation.Unit[_sUnitNum].AliveSince;
                CustDebug.UnitInfo.lstUnitInformation.Items[15] = "Hp Damage: " + GInformation.Unit[_sUnitNum].DamageTaken;
                CustDebug.UnitInfo.lstUnitInformation.Items[16] = "Energy: " + GInformation.Unit[_sUnitNum].Energy;
                CustDebug.UnitInfo.lstUnitInformation.Items[17] = "IsAlive: " + GInformation.Unit[_sUnitNum].IsAlive;
                CustDebug.UnitInfo.lstUnitInformation.Items[18] = "IsCloaked: " + GInformation.Unit[_sUnitNum].IsCloaked;
                CustDebug.UnitInfo.lstUnitInformation.Items[19] = "IsStructure: " +
                                                                GInformation.Unit[_sUnitNum].IsStructure;
                CustDebug.UnitInfo.lstUnitInformation.Items[20] = "IsUnderConstruction: " +
                                                                GInformation.Unit[_sUnitNum].IsUnderConstruction;
                CustDebug.UnitInfo.lstUnitInformation.Items[21] = "IsAir: " + GInformation.Unit[_sUnitNum].IsAir;
                CustDebug.UnitInfo.lstUnitInformation.Items[22] = "IsArmored: " + GInformation.Unit[_sUnitNum].IsArmored;
                CustDebug.UnitInfo.lstUnitInformation.Items[23] = "IsBiological: " +
                                                                GInformation.Unit[_sUnitNum].IsBiological;
                CustDebug.UnitInfo.lstUnitInformation.Items[24] = "IsBurried: " + GInformation.Unit[_sUnitNum].IsBurried;
                CustDebug.UnitInfo.lstUnitInformation.Items[25] = "IsDetector: " + GInformation.Unit[_sUnitNum].IsDetector;
                CustDebug.UnitInfo.lstUnitInformation.Items[26] = "IsGround: " + GInformation.Unit[_sUnitNum].IsGround;
                CustDebug.UnitInfo.lstUnitInformation.Items[27] = "IsHallucination: " +
                                                                GInformation.Unit[_sUnitNum].IsHallucination;
                CustDebug.UnitInfo.lstUnitInformation.Items[28] = "IsLight: " + GInformation.Unit[_sUnitNum].IsLight;
                CustDebug.UnitInfo.lstUnitInformation.Items[29] = "IsMassive: " + GInformation.Unit[_sUnitNum].IsMassive;
                CustDebug.UnitInfo.lstUnitInformation.Items[30] = "IsMechanical: " +
                                                                GInformation.Unit[_sUnitNum].IsMechanical;
                CustDebug.UnitInfo.lstUnitInformation.Items[31] = "IsPsionic: " + GInformation.Unit[_sUnitNum].IsPsionic;
                CustDebug.UnitInfo.lstUnitInformation.Items[32] = "IsRobotic: " + GInformation.Unit[_sUnitNum].IsRobotic;
                CustDebug.UnitInfo.lstUnitInformation.Items[33] = "IsVisible: " + GInformation.Unit[_sUnitNum].IsVisible;

            }


            CustDebug.lblUnitObjects.Text = "Unit Objects (in memory): " + PredefinedData.Unit.ClassObjectCount;
        }

        private void SetGameInformationListBox()
        {
            if (GInformation == null)
                return;

            if (CustDebug.lstGameinformation.Items.Count <= 0)
            {
                CustDebug.lstGameinformation.Items.Add("Chatinput: " + GInformation.Gameinfo.ChatInput);
                CustDebug.lstGameinformation.Items.Add("Chat Open: " + GInformation.Gameinfo.ChatIsOpen);
                CustDebug.lstGameinformation.Items.Add("Fps: " + GInformation.Gameinfo.Fps);
                CustDebug.lstGameinformation.Items.Add("IsIngame: " + GInformation.Gameinfo.IsIngame);
                CustDebug.lstGameinformation.Items.Add("IsTeamcolored: " + GInformation.Gameinfo.IsTeamcolor);
                CustDebug.lstGameinformation.Items.Add("IsPaused: " + GInformation.Gameinfo.Pause);
                CustDebug.lstGameinformation.Items.Add("Gamespeed: " + GInformation.Gameinfo.Speed);
                CustDebug.lstGameinformation.Items.Add("Windowstyle: " + GInformation.Gameinfo.Style);
                CustDebug.lstGameinformation.Items.Add("Gametimer: " + GInformation.Gameinfo.Timer);
                CustDebug.lstGameinformation.Items.Add("Gametype: " + GInformation.Gameinfo.Type);
                CustDebug.lstGameinformation.Items.Add("Valid Playercount: " + GInformation.Gameinfo.ValidPlayerCount);
            }

            else
            {
                CustDebug.lstGameinformation.Items[0] = ("Chatinput: " + GInformation.Gameinfo.ChatInput);
                CustDebug.lstGameinformation.Items[1] = ("Chat Open: " + GInformation.Gameinfo.ChatIsOpen);
                CustDebug.lstGameinformation.Items[2] = ("Fps: " + GInformation.Gameinfo.Fps);
                CustDebug.lstGameinformation.Items[3] = ("IsIngame: " + GInformation.Gameinfo.IsIngame);
                CustDebug.lstGameinformation.Items[4] = ("IsTeamcolored: " + GInformation.Gameinfo.IsTeamcolor);
                CustDebug.lstGameinformation.Items[5] = ("IsPaused: " + GInformation.Gameinfo.Pause);
                CustDebug.lstGameinformation.Items[6] = ("Gamespeed: " + GInformation.Gameinfo.Speed);
                CustDebug.lstGameinformation.Items[7] = ("Windowstyle: " + GInformation.Gameinfo.Style);
                CustDebug.lstGameinformation.Items[8] = ("Gametimer: " + GInformation.Gameinfo.Timer);
                CustDebug.lstGameinformation.Items[9] = ("Gametype: " + GInformation.Gameinfo.Type);
                CustDebug.lstGameinformation.Items[10] = ("Valid Playercount: " + GInformation.Gameinfo.ValidPlayerCount);
            }
        }

        /* Insert basic mapinformation */
        private void SetMapListboxInformation()
        {
            CustDebug.MapInfo.Items.Clear();

            try
            {
                CustDebug.MapInfo.Items.Add("Left: " + GInformation.Map.Left);
                CustDebug.MapInfo.Items.Add("Right: " + GInformation.Map.Right);
                CustDebug.MapInfo.Items.Add("Top: " + GInformation.Map.Top);
                CustDebug.MapInfo.Items.Add("Bottom: " + GInformation.Map.Bottom);
                CustDebug.MapInfo.Items.Add("Playable Width: " + GInformation.Map.PlayableWidth);
                CustDebug.MapInfo.Items.Add("Playable Height: " + GInformation.Map.PlayableHeight);
            }

            catch { }
        }

        #endregion

        #region Worker Automartion/ Production

        void rdbRoundWorkerProduction_CheckedChanged(object sender, EventArgs e)
        {
            PSettings.WorkerAutomationModeRound = workerProductionBasics.rdbRoundWorkerProduction.Checked;
        }

        void rdbDirectWorkerProduction_CheckedChanged(object sender, EventArgs e)
        {
            PSettings.WorkerAutomationModeDirect = workerProductionBasics.rdbDirectWorkerProduction.Checked;
        }

        void ntxtMaynardWorkerCount_TextChanged(object sender, EventArgs e)
        {
            PSettings.WorkerAutomationPufferWorker = workerProductionBasics.ntxtMaynardWorkerCount.Number;
        }

        void ntxtMaximumWorkersPerBase_TextChanged(object sender, EventArgs e)
        {
            PSettings.WorkerAutomationMaximumWorkersPerBase = workerProductionBasics.ntxtMaximumWorkersPerBase.Number;
        }

        void ntxtMaximumWorkersInGame_TextChanged(object sender, EventArgs e)
        {
            PSettings.WorkerAutomationMaximumWorkers = workerProductionBasics.ntxtMaximumWorkersInGame.Number;
        }

        void ntxtStartNextWorkerAt_TextChanged(object sender, EventArgs e)
        {
            PSettings.WorkerAutomationStartNextWorkerAt = workerProductionBasics.ntxtBuildNextWorkerAt.Number;
        }

        void ntxtDisableWhenApmIsOver_TextChanged(object sender, EventArgs e)
        {
            PSettings.WorkerAutomationApmProtection = workerProductionBasics.ntxtDisableWhenApmIsOver.Number;
        }

        void chBxDisableWhenWorkerIsSelected_CheckedChanged(object sender, EventArgs e)
        {
            PSettings.WorkerAutomationDisableWhenWorkerIsSelected =
                workerProductionBasics.chBxDisableWhenWorkerIsSelected.Checked;
        }

        void chBxDisableWhenSelecting_CheckedChanged(object sender, EventArgs e)
        {
            PSettings.WorkerAutomationDisableWhenSelecting = workerProductionBasics.chBxDisableWhenSelecting.Checked;
        }

        void chBxAutomationEnableWorkerProduction_CheckedChanged(object sender, EventArgs e)
        {/*
            PSettings.WorkerAutomation = workerProductionBasics.chBxAutomationEnableWorkerProduction.Checked;

            if (workerProductionBasics.chBxAutomationEnableWorkerProduction.Checked)
            {
                if (_aWorkerProduction == null)
                    _aWorkerProduction = new Automation(this, PredefinedData.Automation.Testing);
                    
                else
                    _aWorkerProduction.StartWorkerProduction();
            }

            else
                _aWorkerProduction.StopWorkerProduction();
            */
        }

        void chBxAutoUpgradeToOc_CheckedChanged(object sender, EventArgs e)
        {
            PSettings.WorkerAutomationAutoupgradeToOc = workerProductionBasics.chBxAutoUpgradeToOc.Checked;
        }

        void txtHotkey3_KeyDown(object sender, KeyEventArgs e)
        {
            PSettings.WorkerAutomationHotkey3 = e.KeyCode;
        }

        void txtHotkey2_KeyDown(object sender, KeyEventArgs e)
        {
            PSettings.WorkerAutomationHotkey2 = e.KeyCode;
        }

        void txtHotkey1_KeyDown(object sender, KeyEventArgs e)
        {
            PSettings.WorkerAutomationHotkey1 = e.KeyCode;
        }

        void ktxtScvBuildingKey_KeyDown(object sender, KeyEventArgs e)
        {
            PSettings.WorkerAutomationScvKey = workerProductionBasics.ktxtScvBuildingKey.HotKeyValue;
        }

        void ktxtProbeBuildingKey_KeyDown(object sender, KeyEventArgs e)
        {
            PSettings.WorkerAutomationProbeKey = workerProductionBasics.ktxtProbeBuildingKey.HotKeyValue;
        }

        void ktxtOrbitalUpgradeKey_KeyDown(object sender, KeyEventArgs e)
        {
            PSettings.WorkerAutomationOrbitalKey = workerProductionBasics.ktxtOrbitalUpgradeKey.HotKeyValue;
        }

        void ktxtMainbuildingGroupKey_KeyDown(object sender, KeyEventArgs e)
        {
            PSettings.WorkerAutomationMainbuildingGroup = workerProductionBasics.ktxtMainbuildingGroupKey.HotKeyValue;
        }

        void ktxtBackupGroupKey_KeyDown(object sender, KeyEventArgs e)
        {
            PSettings.WorkerAutomationBackupGroup = workerProductionBasics.ktxtBackupGroupKey.HotKeyValue;
        }

        #endregion

        #region Global

        private void AssignMethodsToEvents()
        {
            #region UiHotkeys - Keydown

            ResourceUiHotkeys.txtHotkey1.KeyDown += txtResHotkey1_KeyDown;
            ResourceUiHotkeys.txtHotkey2.KeyDown += txtResHotkey2_KeyDown;
            ResourceUiHotkeys.txtHotkey3.KeyDown += txtResHotkey3_KeyDown;

            IncomeUiHotkeys.txtHotkey1.KeyDown += txtIncHotkey1_KeyDown;
            IncomeUiHotkeys.txtHotkey2.KeyDown += txtIncHotkey2_KeyDown;
            IncomeUiHotkeys.txtHotkey3.KeyDown += txtIncHotkey3_KeyDown;

            WorkerUiHotkeys.txtHotkey1.KeyDown += txtWorHotkey1_KeyDown;
            WorkerUiHotkeys.txtHotkey2.KeyDown += txtWorHotkey2_KeyDown;
            WorkerUiHotkeys.txtHotkey3.KeyDown += txtWorHotkey3_KeyDown;

            ApmUiHotkeys.txtHotkey1.KeyDown += txtApmHotkey1_KeyDown;
            ApmUiHotkeys.txtHotkey2.KeyDown += txtApmHotkey2_KeyDown;
            ApmUiHotkeys.txtHotkey3.KeyDown += txtApmHotkey3_KeyDown;

            ArmyUiHotkeys.txtHotkey1.KeyDown += txtArmHotkey1_KeyDown;
            ArmyUiHotkeys.txtHotkey2.KeyDown += txtArmHotkey2_KeyDown;
            ArmyUiHotkeys.txtHotkey3.KeyDown += txtArmHotkey3_KeyDown;

            MaphackUiHotkeys.txtHotkey1.KeyDown += txtMaphackHotkey1_KeyDown;
            MaphackUiHotkeys.txtHotkey2.KeyDown += txtMaphackHotkey2_KeyDown;
            MaphackUiHotkeys.txtHotkey3.KeyDown += txtMaphackHotkey3_KeyDown;

            UnittabUiHotkeys.txtHotkey1.KeyDown += txtUnitHotkey1_KeyDown;
            UnittabUiHotkeys.txtHotkey2.KeyDown += txtUnitHotkey2_KeyDown;
            UnittabUiHotkeys.txtHotkey3.KeyDown += txtUnitHotkey3_KeyDown;

            ProductionTabUiHotkeys.txtHotkey1.KeyDown += txtProdHotkey1_KeyDown;
            ProductionTabUiHotkeys.txtHotkey2.KeyDown += txtProdHotkey2_KeyDown;
            ProductionTabUiHotkeys.txtHotkey3.KeyDown += txtProdHotkey3_KeyDown;

            WorkerProductionUiHotkeys.txtHotkey1.KeyDown += txtHotkey1_KeyDown;
            WorkerProductionUiHotkeys.txtHotkey2.KeyDown += txtHotkey2_KeyDown;
            WorkerProductionUiHotkeys.txtHotkey3.KeyDown += txtHotkey3_KeyDown;

            #endregion

            #region Chatinput

            ResourceUiChatInput.txtToggle.TextChanged += txtResTogglePanel_TextChanged;
            ResourceUiChatInput.txtPosition.TextChanged += txtResPositionPanel_TextChanged;
            ResourceUiChatInput.txtSize.TextChanged += txtResChangeSizePanel_TextChanged;

            IncomeUiChatInput.txtToggle.TextChanged += txtIncTogglePanel_TextChanged;
            IncomeUiChatInput.txtPosition.TextChanged += txtIncPositionPanel_TextChanged;
            IncomeUiChatInput.txtSize.TextChanged += txtIncChangeSizePanel_TextChanged;

            WorkerUiChatInput.txtToggle.TextChanged += txtWorTogglePanel_TextChanged;
            WorkerUiChatInput.txtPosition.TextChanged += txtWorPositionPanel_TextChanged;
            WorkerUiChatInput.txtSize.TextChanged += txtWorChangeSizePanel_TextChanged;

            ApmUiChatInput.txtToggle.TextChanged += txtApmTogglePanel_TextChanged;
            ApmUiChatInput.txtPosition.TextChanged += txtApmPositionPanel_TextChanged;
            ApmUiChatInput.txtSize.TextChanged += txtApmChangeSizePanel_TextChanged;

            ArmyUiChatInput.txtToggle.TextChanged += txtArmTogglePanel_TextChanged;
            ArmyUiChatInput.txtPosition.TextChanged += txtArmPositionPanel_TextChanged;
            ArmyUiChatInput.txtSize.TextChanged += txtArmChangeSizePanel_TextChanged;

            MaphackUiChatInput.txtToggle.TextChanged += txtMaphackTogglePanel_TextChanged;
            MaphackUiChatInput.txtPosition.TextChanged += txtMaphackPositionPanel_TextChanged;
            MaphackUiChatInput.txtSize.TextChanged += txtMaphackChangeSizePanel_TextChanged;

            UnittabUiChatInput.txtToggle.TextChanged += txtUnitTogglePanel_TextChanged;
            UnittabUiChatInput.txtPosition.TextChanged += txtUnitPositionPanel_TextChanged;
            UnittabUiChatInput.txtSize.TextChanged += txtUnitChangeSizePanel_TextChanged;

            ProductionTabUiChatInput.txtToggle.TextChanged += txtProdTogglePanel_TextChanged;
            ProductionTabUiChatInput.txtPosition.TextChanged += txtProdPositionPanel_TextChanged;
            ProductionTabUiChatInput.txtSize.TextChanged += txtProdChangeSizePanel_TextChanged;

            #endregion

            #region UiBasics

            ResourceUiBasics.chBxRemoveAi.CheckedChanged += chBxResourceRemoveAi_CheckedChanged;
            ResourceUiBasics.chBxRemoveAllie.CheckedChanged += chBxResourceRemoveAllie_CheckedChanged;
            ResourceUiBasics.chBxRemoveClantag.CheckedChanged += chBxResourceRemoveClantag_CheckedChanged;
            ResourceUiBasics.chBxRemoveLocalplayer.CheckedChanged += chBxResourceRemoveLocalplayer_CheckedChanged;
            ResourceUiBasics.chBxDrawBackground.CheckedChanged += chBxResourceDrawBackground_CheckedChanged;
            ResourceUiBasics.chBxRemoveNeutral.CheckedChanged += chBxResourceRemoveNeutral_CheckedChanged;
            ResourceUiBasics.btnFontName.Click += btnResourceFontName_Click;
            ResourceUiBasics.OcUiOpacity.tbOpacity.Scroll += tbResourceOpacity_Scroll;

            IncomeUiBasics.chBxRemoveAi.CheckedChanged += chBxIncomeRemoveAi_CheckedChanged;
            IncomeUiBasics.chBxRemoveAllie.CheckedChanged += chBxIncomeRemoveAllie_CheckedChanged;
            IncomeUiBasics.chBxRemoveClantag.CheckedChanged += chBxIncomeRemoveClantag_CheckedChanged;
            IncomeUiBasics.chBxRemoveLocalplayer.CheckedChanged += chBxIncomeRemoveLocalplayer_CheckedChanged;
            IncomeUiBasics.chBxRemoveNeutral.CheckedChanged += chBxIncomeRemoveNeutral_CheckedChanged;
            IncomeUiBasics.chBxDrawBackground.CheckedChanged += chBxIncomeDrawBackground_CheckedChanged;
            IncomeUiBasics.btnFontName.Click += btnIncomeFontName_Click;
            IncomeUiBasics.OcUiOpacity.tbOpacity.Scroll += tbIncomeOpacity_Scroll;

            ApmUiBasics.chBxRemoveAi.CheckedChanged += chBxApmRemoveAi_CheckedChanged;
            ApmUiBasics.chBxRemoveAllie.CheckedChanged += chBxApmRemoveAllie_CheckedChanged;
            ApmUiBasics.chBxRemoveClantag.CheckedChanged += chBxApmRemoveClantag_CheckedChanged;
            ApmUiBasics.chBxRemoveNeutral.CheckedChanged += chBxApmRemoveNeutral_CheckedChanged;
            ApmUiBasics.chBxRemoveLocalplayer.CheckedChanged += chBxApmRemoveLocalplayer_CheckedChanged;
            ApmUiBasics.chBxDrawBackground.CheckedChanged += chBxApmDrawBackground_CheckedChanged;
            ApmUiBasics.btnFontName.Click += btnApmFontName_Click;
            ApmUiBasics.OcUiOpacity.tbOpacity.Scroll += tbApmOpacity_Scroll;

            ArmyUiBasics.chBxRemoveAi.CheckedChanged += chBxArmyRemoveAi_CheckedChanged;
            ArmyUiBasics.chBxRemoveAllie.CheckedChanged += chBxArmyRemoveAllie_CheckedChanged;
            ArmyUiBasics.chBxRemoveClantag.CheckedChanged += chBxArmyRemoveClantag_CheckedChanged;
            ArmyUiBasics.chBxRemoveNeutral.CheckedChanged += chBxArmyRemoveNeutral_CheckedChanged;
            ArmyUiBasics.chBxRemoveLocalplayer.CheckedChanged += chBxArmyRemoveLocalplayer_CheckedChanged;
            ArmyUiBasics.chBxDrawBackground.CheckedChanged += chBxArmyDrawBackground_CheckedChanged;
            ArmyUiBasics.btnFontName.Click += btnArmyFontName_Click;
            ArmyUiBasics.OcUiOpacity.tbOpacity.Scroll += tbArmyOpacity_Scroll;

            WorkerUiWorkerBasics.chBxDrawBackground.CheckedChanged += chBxWorDrawBackground_CheckedChanged;
            WorkerUiWorkerBasics.btnFontName.Click += btnWorFontName_Click;
            WorkerUiWorkerBasics.OcUiOpacity.tbOpacity.Scroll += tbWorkerOpacity_Scroll;

            MaphackUiMaphackBasics.chBxRemoveAi.CheckedChanged += chBxMaphackRemoveAi_CheckedChanged;
            MaphackUiMaphackBasics.chBxRemoveAllie.CheckedChanged += chBxMaphackRemoveAllie_CheckedChanged;
            MaphackUiMaphackBasics.chBxRemoveNeutral.CheckedChanged += chBxMaphackRemoveNeutral_CheckedChanged;
            MaphackUiMaphackBasics.chBxRemoveLocalplayer.CheckedChanged += chBxMaphackRemoveLocalplayer_CheckedChanged;
            MaphackUiMaphackBasics .chBxMaphackColorDefensiveStructuresYellow.CheckedChanged += ChBxMaphackMaphackColorDefensiveStructuresYellowCheckedChanged;
            MaphackUiMaphackBasics.chBxMaphackDisableDestinationLine.CheckedChanged += ChBxMaphackDisableDestinationLineCheckedChanged;
            MaphackUiMaphackBasics.chBxMaphackRemCamera.CheckedChanged += ChBxMaphackMapRemCameraCheckedChanged;
            MaphackUiMaphackBasics.chBxMaphackRemVisionArea.CheckedChanged += ChBxMaphackMaphackRemVisionAreaCheckedChanged;
            MaphackUiMaphackBasics.btnDestinationLine.Click += btnMaphackDestinationLine_Click;
            MaphackUiMaphackBasics.OcUiOpacity.tbOpacity.Scroll += tbMaphackOpacity_Scroll;

            UnittabUiUnitTabBasic.chBxRemoveAi.CheckedChanged += chBxUnitTabRemoveAi_CheckedChanged;
            UnittabUiUnitTabBasic.chBxRemoveAllie.CheckedChanged += chBxUnitTabRemoveAllie_CheckedChanged;
            UnittabUiUnitTabBasic.chBxRemoveNeutral.CheckedChanged += chBxUnitTabRemoveNeutral_CheckedChanged;
            UnittabUiUnitTabBasic.chBxRemoveLocalplayer.CheckedChanged += chBxUnitTabRemoveLocalplayer_CheckedChanged;
            UnittabUiUnitTabBasic.chBxRemoveClantag.CheckedChanged += chBxUnitTabRemoveClantag_CheckedChanged;
            UnittabUiUnitTabBasic.chBxSplitBuildingsUnits.CheckedChanged += chBxUnitTabSplitBuildingsUnits_CheckedChanged;
            UnittabUiUnitTabBasic.chBxRemoveProductionLine.CheckedChanged += chBxUnitTabRemoveProductionLine_CheckedChanged;
            UnittabUiUnitTabBasic.btnFontName.Click += btnUniFontName_Click;
            UnittabUiUnitTabBasic.OcUiOpacity.tbOpacity.Scroll += tbUnitTabOpacity_Scroll;
            UnittabUiUnitTabBasic.chBxRemoveChronoboost.CheckedChanged += chBxUnitTabRemoveChronoboost_CheckedChanged;
            UnittabUiUnitTabBasic.chBxRemoveSpellcounter.CheckedChanged += chBxUnitTabRemoveSpellcounter_CheckedChanged;
            UnittabUiUnitTabBasic.chBxShowBuildings.CheckedChanged += chBxUnitTabShowBuildings_CheckedChanged;
            UnittabUiUnitTabBasic.chBxShowUnits.CheckedChanged += chBxUnitTabShowUnits_CheckedChanged;

            ProductionTabUiProductionTabBasics.chBxRemoveAi.CheckedChanged += chBxProductionTabRemoveAi_CheckedChanged;
            ProductionTabUiProductionTabBasics.chBxRemoveAllie.CheckedChanged +=chBxProductionTabRemoveAllie_CheckedChanged;
            ProductionTabUiProductionTabBasics.chBxRemoveNeutral.CheckedChanged +=chBxProductionTabRemoveNeutral_CheckedChanged;
            ProductionTabUiProductionTabBasics.chBxRemoveLocalplayer.CheckedChanged +=chBxProductionTabRemoveLocalplayer_CheckedChanged;
            ProductionTabUiProductionTabBasics.chBxRemoveClantag.CheckedChanged +=chBxProductionTabRemoveClantag_CheckedChanged;
            ProductionTabUiProductionTabBasics.chBxSplitBuildingsUnits.CheckedChanged +=chBxProductionTabSplitBuildingsUnits_CheckedChanged;
            ProductionTabUiProductionTabBasics.chBxRemoveChronoboost.CheckedChanged += chBxProductionTabRemoveChronoboost_CheckedChanged;
            ProductionTabUiProductionTabBasics.chBxShowBuildings.CheckedChanged += chBxProductionTabShowBuildings_CheckedChanged;
            ProductionTabUiProductionTabBasics.chBxShowUnits.CheckedChanged += chBxProductionTabShowUnits_CheckedChanged;
            ProductionTabUiProductionTabBasics.chBxShowUpgrades.CheckedChanged += chBxProductionTabShowUpgrades_CheckedChanged;
            ProductionTabUiProductionTabBasics.btnFontName.Click += btnProFontName_Click;
            ProductionTabUiProductionTabBasics.OcUiOpacity.tbOpacity.Scroll += tbProOpacity_Scroll;

            CustBugs.btnCreateNewPost.Click += btnCreateNewPost_Click;
            CustBugs.btnEmailSend.Click += btnEmailSend_Click;
            CustBugs.txtEmailBody.TextChanged += txtEmailBody_TextChanged;
            CustBugs.txtEmailSubject.TextChanged += txtEmailSubject_TextChanged;
            CustBugs.cmBxEmailSubject.SelectedIndexChanged += cmBxEmailSubject_SelectedIndexChanged;

            CustGlobal.txtDataInterval.TextChanged += txtDataInterval_TextChanged;
            CustGlobal.txtDrawingInterval.TextChanged += txtDrawingInterval_TextChanged;
            CustGlobal.chBxGlobalForegroundDraw.CheckedChanged += ChBxGlobalForegroundDrawCheckedChanged;
            CustGlobal.txtGlobalAdjustKey.KeyDown += txtGlobalAdjustKey_KeyDown;
            CustGlobal.btnGlobalSetPosition.Click += BtnGlobalSetPositionClick;
            CustGlobal.btnGetUpdate.Click += btnGetUpdate_Click;
            CustGlobal.btnGlobalDonations.Click += BtnGlobalDonationsClick;
            CustGlobal.lstBxPlugins.SelectedIndexChanged += lstBxPlugins_SelectedIndexChanged;
            CustGlobal.lstBxPlugins.ItemCheck += lstBxPlugins_ItemCheck;
            CustGlobal.cmBxLanguage.SelectedIndexChanged += cmBxLanguage_SelectedIndexChanged;

            workerProductionBasics.ktxtBackupGroupKey.KeyDown += ktxtBackupGroupKey_KeyDown;
            workerProductionBasics.ktxtMainbuildingGroupKey.KeyDown += ktxtMainbuildingGroupKey_KeyDown;
            workerProductionBasics.ktxtOrbitalUpgradeKey.KeyDown += ktxtOrbitalUpgradeKey_KeyDown;
            workerProductionBasics.ktxtProbeBuildingKey.KeyDown += ktxtProbeBuildingKey_KeyDown;
            workerProductionBasics.ktxtScvBuildingKey.KeyDown += ktxtScvBuildingKey_KeyDown;
            workerProductionBasics.chBxAutoUpgradeToOc.CheckedChanged += chBxAutoUpgradeToOc_CheckedChanged;
            workerProductionBasics.chBxAutomationEnableWorkerProduction.CheckedChanged += chBxAutomationEnableWorkerProduction_CheckedChanged;
            workerProductionBasics.chBxDisableWhenSelecting.CheckedChanged += chBxDisableWhenSelecting_CheckedChanged;
            workerProductionBasics.chBxDisableWhenWorkerIsSelected.CheckedChanged += chBxDisableWhenWorkerIsSelected_CheckedChanged;
            workerProductionBasics.ntxtDisableWhenApmIsOver.TextChanged += ntxtDisableWhenApmIsOver_TextChanged;
            workerProductionBasics.ntxtBuildNextWorkerAt.TextChanged += ntxtStartNextWorkerAt_TextChanged;
            workerProductionBasics.ntxtMaximumWorkersInGame.TextChanged += ntxtMaximumWorkersInGame_TextChanged;
            workerProductionBasics.ntxtMaximumWorkersPerBase.TextChanged += ntxtMaximumWorkersPerBase_TextChanged;
            workerProductionBasics.ntxtMaynardWorkerCount.TextChanged += ntxtMaynardWorkerCount_TextChanged;
            workerProductionBasics.rdbDirectWorkerProduction.CheckedChanged += rdbDirectWorkerProduction_CheckedChanged;
            workerProductionBasics.rdbRoundWorkerProduction.CheckedChanged += rdbRoundWorkerProduction_CheckedChanged;

            #endregion

            #region Various

            CustDebug.btnDebugExportIds.Click += btnExportFile_Click;
            CustDebug.PlayerInfo.btnNext.Click += btnPlayerNext_Click;
            CustDebug.PlayerInfo.btnPrev.Click += btnPlayerBack_Click;
            CustDebug.PlayerInfo.Load += PlayerInfo_Load;
            CustDebug.UnitInfo.btnNext.Click += btnUnitNext_Click;
            CustDebug.UnitInfo.btnPrev.Click += btnUnitBack_Click;
            CustDebug.UnitInfo.txtUnitNum.TextChanged += txtUnitNum_TextChanged;
            CustDebug.UnitInfo.Load += UnitInfo_Load;

           

            Custom_Various.chBxApm.CheckedChanged += chBxVarPersonalApm_CheckedChanged;
            Custom_Various.chBxClock.CheckedChanged += chBxVarPersonalClock_CheckedChanged;
            Custom_Various.chBxApmAlert.CheckedChanged += chBxVarPersonalApmAlert_CheckedChanged;
            Custom_Various.txtApmAlertLimit.TextChanged += txtVarApmAlertLimit_TextChanged;



            #endregion
        }

        
        

       
        

        

       

       

        

       

        void cmBxLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            PSettings.GlobalLanguage = CustGlobal.cmBxLanguage.Text;

            var strFile = "english.txt";

            if (CustGlobal.cmBxLanguage.Text == "Deutsch")
            {
                strFile = "german.txt";
            }

            else if (CustGlobal.cmBxLanguage.Text == "English")
            {
                strFile = "english.txt";
            }


            CustGlobal.ChangeLanguageFile(strFile);
            Custom_Various.ChangeLanguageFile(strFile);
            workerProductionBasics.ChangeLanguageFile(strFile);
            WorkerProductionUiHotkeys.ChangeLanguageFile(strFile);
            CustBugs.ChangeLanguageFile(strFile);

            /* UiBasics */
            ResourceUiBasics.ChangeLanguageFile(strFile);
            IncomeUiBasics.ChangeLanguageFile(strFile);
            ArmyUiBasics.ChangeLanguageFile(strFile);
            ApmUiBasics.ChangeLanguageFile(strFile);
            MaphackUiMaphackBasics.ChangeLanguageFile(strFile);
            UnittabUiUnitTabBasic.ChangeLanguageFile(strFile);
            ProductionTabUiProductionTabBasics.ChangeLanguageFile(strFile);
            WorkerUiWorkerBasics.ChangeLanguageFile(strFile);

            /* Chatinput */
            ResourceUiChatInput.ChangeLanguageFile(strFile);
            IncomeUiChatInput.ChangeLanguageFile(strFile);
            WorkerUiChatInput.ChangeLanguageFile(strFile);
            UnittabUiChatInput.ChangeLanguageFile(strFile);
            MaphackUiChatInput.ChangeLanguageFile(strFile);
            ProductionTabUiChatInput.ChangeLanguageFile(strFile);
            ApmUiChatInput.ChangeLanguageFile(strFile);
            ArmyUiChatInput.ChangeLanguageFile(strFile);

            /* UiHotkeys */
            ResourceUiHotkeys.ChangeLanguageFile(strFile);
            IncomeUiHotkeys.ChangeLanguageFile(strFile);
            WorkerUiHotkeys.ChangeLanguageFile(strFile);
            ArmyUiHotkeys.ChangeLanguageFile(strFile);
            ApmUiHotkeys.ChangeLanguageFile(strFile);
            MaphackUiHotkeys.ChangeLanguageFile(strFile);
            UnittabUiHotkeys.ChangeLanguageFile(strFile);
            ProductionTabUiHotkeys.ChangeLanguageFile(strFile);
            WorkerProductionUiHotkeys.ChangeLanguageFile(strFile);

            /* UiInformation */
            ResourceUiInformation.ChangeLanguageFile(strFile);
            IncomeUiInformation.ChangeLanguageFile(strFile);
            WorkerUiInformation.ChangeLanguageFile(strFile);
            ArmyUiInformation.ChangeLanguageFile(strFile);
            ApmUiInformation.ChangeLanguageFile(strFile);
            MaphackUiInformation.ChangeLanguageFile(strFile);
            UnittabUiInformation.ChangeLanguageFile(strFile);
            ProductionTabUiInformation.ChangeLanguageFile(strFile);

            /* Stuff in the main form */
            btnMapAddUnit.LanguageFile = strFile;
            gbMaphackColorUnits.LanguageFile = strFile;
            gbUnitPicture.LanguageFile = strFile;
            gbProdPicture.LanguageFile = strFile;
            lblProdPicturePreview.LanguageFile = strFile;
            lblProdPictureSize.LanguageFile = strFile;
            lblUnitPicturePreview.LanguageFile = strFile;
            lblUnitPictureSize.LanguageFile = strFile;
        }


        void lstBxPlugins_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CustGlobal.lstBxPlugins.Items.Count <= 0)
                return;

            if (CustGlobal.lstBxPlugins.SelectedIndex <= -1)
                return;

            CustGlobal.lblGlobalPluginDescription.Text =
                _lPlugins[CustGlobal.lstBxPlugins.SelectedIndex].GetPluginDescription();
        }

        void lstBxPlugins_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            /* If the item was checked, unload/ deactivate the Plugin immediately */
            if (CustGlobal.lstBxPlugins.Items.Count > e.Index)
            {
                if (e.CurrentValue.Equals(CheckState.Checked))
                {
                    _lPlugins[e.Index].StopPlugin();
                }

                else
                {
                    _lPlugins[e.Index].StartPlugin();
                }
            }

        }

        private void BtnGlobalDonationsClick(object sender, EventArgs e)
        {
            Process.Start("https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=3ZAZS7HNX6DPW");
        }

        /* Datainterval for the gathering- thread */
        private void txtDataInterval_TextChanged(object sender, EventArgs e)
        {
            if (CustGlobal.txtDataInterval.Text.Length <= 0)
                return;

            int iDummy;
            if (Int32.TryParse(CustGlobal.txtDataInterval.Text, out iDummy))
            {
                if (iDummy == 0)
                {
                    CustGlobal.txtDataInterval.Text = "1";
                    iDummy = 1;
                    CustGlobal.txtDataInterval.Select(1.ToString(CultureInfo.InvariantCulture).Length, 0);
                }

                PSettings.GlobalDataRefresh = iDummy;
                GInformation.CSleepTime = iDummy;
                tmrGatherInformation.Interval = iDummy;

                if (iDummy < 10)
                {
                    ttInformation.ToolTipTitle = Constants.TooltipConsts.StrRefreshrateTitle;
                    ttInformation.Show(Constants.TooltipConsts.StrRefreshrate, CustGlobal.txtDataInterval, Constants.TooltipConsts.IremoveTime * 3);
                }

                else
                    ttInformation.Hide(CustGlobal.txtDataInterval);

            }

            else
            {
                ttInformation.ToolTipTitle = Constants.TooltipConsts.StrOnlyDigitsTitle;
                ttInformation.Show(Constants.TooltipConsts.StrOnlyDigits, CustGlobal.txtDataInterval, Constants.TooltipConsts.IremoveTime);
            }

            /* Remove non- digits */
            HelpFunctions.RemoveNonDigits(CustGlobal.txtDataInterval);
        }

        /* Drawinginterval for the refreshing of the panels */
        private void txtDrawingInterval_TextChanged(object sender, EventArgs e)
        {
            if (CustGlobal.txtDrawingInterval.Text.Length <= 0)
                return;

            int iDummy;
            if (Int32.TryParse(CustGlobal.txtDrawingInterval.Text, out iDummy))
            {
                if (iDummy == 0)
                {
                    CustGlobal.txtDrawingInterval.Text = "1";
                    iDummy = 1;
                    CustGlobal.txtDrawingInterval.Select(1.ToString(CultureInfo.InvariantCulture).Length, 0);
                }

                PSettings.GlobalDrawingRefresh = iDummy;

                _lContainer.SetDrawingInterval(PSettings.GlobalDrawingRefresh);


                if (iDummy < 10)
                {
                    ttInformation.ToolTipTitle = Constants.TooltipConsts.StrRefreshrateTitle;
                    ttInformation.Show(Constants.TooltipConsts.StrRefreshrate, CustGlobal.txtDrawingInterval, Constants.TooltipConsts.IremoveTime * 3);
                }

                else
                    ttInformation.Hide(CustGlobal.txtDrawingInterval);

            }

            else
            {
                ttInformation.ToolTipTitle = Constants.TooltipConsts.StrOnlyDigitsTitle;
                ttInformation.Show(Constants.TooltipConsts.StrOnlyDigits, CustGlobal.txtDrawingInterval, Constants.TooltipConsts.IremoveTime);
            }

            /* Remove non- digits */
            HelpFunctions.RemoveNonDigits(CustGlobal.txtDrawingInterval);
        }

        private void MainHandler_FormClosing(object sender, FormClosingEventArgs e)
        {
            PSettings.WritePreferences();

            _lContainer.CloseClean();

            tmrGatherInformation.Enabled = false;
            GInformation.HandleThread(false);

            /* Close Plugins */
            foreach (var i in _lPlugins)
                i.StopPlugin();


        }

        private void MainHandler_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                


                var strPath = Application.StartupPath + "\\";
                var strComplete = Application.ExecutablePath;
                var strFilename = Path.GetFileName(strComplete);
                var strFilenameNoExt = Path.GetFileNameWithoutExtension(strFilename);
                var strExtension = Path.GetExtension(strFilename);

                if (!strFilename.Contains("AnotherSc2Hack"))
                    Environment.Exit(0);

                var strNewFilename = string.Empty;
                if (CustGlobal.txtFilename.Text.Length <= 3 ||
                    CustGlobal.txtFilename.Text.Contains("AnotherSc2Hack"))
                {
                    var rnd = new Random();
                    var result = rnd.Next(50000, 90000);
                    strNewFilename = result.ToString(CultureInfo.InvariantCulture);
                }

                else
                {
                    strNewFilename = CustGlobal.txtFilename.Text;
                }

                if (File.Exists(strPath + strNewFilename + strExtension))
                    File.Delete(strPath + strNewFilename + strExtension);

                File.Move(strComplete, strPath + strNewFilename + strExtension);


                Environment.Exit(0);
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        private DateTime _dtSecond = DateTime.Now;

        private void tmrGatherInformation_Tick(object sender, EventArgs e)
        {
            //_swMainWatch.Reset();
            //_swMainWatch.Start();

            //ThrowInformationToPanels(_rResources);
            //ThrowInformationToPanels(_rIncome);
            //ThrowInformationToPanels(_rWorker);
            //ThrowInformationToPanels(_rApm);
            //ThrowInformationToPanels(_rArmy);
            //ThrowInformationToPanels(_rMaphack);
            //ThrowInformationToPanels(_rUnit);
            //ThrowInformationToPanels(_rProduction);


            // lTimesRefreshed++;

            //_swMainWatch.Stop();
            //Debug.WriteLine("Time to throw the information: " + 1000000 * _swMainWatch.ElapsedTicks / Stopwatch.Frequency + " µs");

            SetBenchmarkData();
            CheckIfDeveloper();


            //            GInformation.CAccessUnitCommands = true;


           // CheckPanelState(PredefinedData.RenderForm.Production);
           // CheckPanelState(PredefinedData.RenderForm.Units);

            RefreshPluginData();

            LaunchPanels();

            #region Reset Process and gameinfo if Sc2 is not started

            if (!Processing.GetProcess(Constants.StrStarcraft2ProcessName))
            {
                ChangeVisibleState(false);
                _bProcessSet = false;
                GInformation.HandleThread(false);

                tmrGatherInformation.Interval = 300;
                Debug.WriteLine("Process not found - 300ms Delay!");
            }


            else
            {
                if (!_bProcessSet)
                {
                    _bProcessSet = true;

                    Process proc;
                    if (Processing.GetProcess(Constants.StrStarcraft2ProcessName, out proc))
                        PSc2Process = proc;


                    if (GInformation == null)
                    {
                        GInformation = new GameInfo(PSettings.GlobalDataRefresh)
                        {
                            Of = new Offsets()
                        };
                    }

                    else if (GInformation != null &&
                             !GInformation.CThreadState)
                    {
                        GInformation.HStarcraft = IntPtr.Zero;
                        GInformation.CStarcraft2 = PSc2Process;
                        GInformation.Of = new Offsets();
                        GInformation.HandleThread(true);
                    }

                    
                    ChangeVisibleState(true);
                    tmrGatherInformation.Interval = PSettings.GlobalDataRefresh;

                    Debug.WriteLine("Process found - " + PSettings.GlobalDataRefresh + "ms Delay!");
                }
            }

            #endregion

            //_swMainWatch.Stop();
            //Debug.WriteLine("Time Refresh the tmrGatherInformation Timer: " + 1000000 * _swMainWatch.ElapsedTicks / Stopwatch.Frequency + " µs");
        }

        /* Setting basic benchmark information */
        private void SetBenchmarkData()
        {
            if ((DateTime.Now - _dtSecond).Seconds < 1) return;

            GlobalBenchmark.lblDataInterval.Text = "Interval: " + GInformation.CSleepTime.ToString(CultureInfo.InvariantCulture) + " ms";
            GlobalBenchmark.lblDataIterations.Text = "Iterations: " + GInformation.IterationsPerSeconds.ToString(CultureInfo.InvariantCulture);
            GlobalBenchmark.lblDrawingInterval.Text = "Interval: " + PSettings.GlobalDrawingRefresh.ToString(CultureInfo.InvariantCulture) +
                                                      " ms";

            foreach (var renderer in _lContainer)
            {
                #region Resource

                if (renderer is ResourcesRenderer)
                {
                    if (renderer.IsHidden)
                        GlobalBenchmark.lblDrawingResourcepanelIterations.Text = "Resource Iterations: Unknown";

                    else
                        GlobalBenchmark.lblDrawingResourcepanelIterations.Text = "Resource Iterations: " + renderer.IterationsPerSeconds;
                }

                #endregion

                #region Income

                if (renderer is IncomeRenderer)
                {
                    if (renderer.IsHidden)
                        GlobalBenchmark.lblDrawingIncomepanelIterations.Text = "Income Iterations: Unknown";

                    else
                        GlobalBenchmark.lblDrawingIncomepanelIterations.Text = "Income Iterations: " + renderer.IterationsPerSeconds;
                }

                #endregion

                #region Worker

                if (renderer is WorkerRenderer)
                {
                    if (renderer.IsHidden)
                        GlobalBenchmark.lblDrawingWorkerpanelIterations.Text = "Worker Iterations: Unknown";

                    else
                        GlobalBenchmark.lblDrawingWorkerpanelIterations.Text = "Worker Iterations: " + renderer.IterationsPerSeconds;
                }

                #endregion

                #region Army

                if (renderer is ArmyRenderer)
                {
                    if (renderer.IsHidden)
                        GlobalBenchmark.lblDrawingArmypanelIterations.Text = "Army Iterations: Unknown";

                    else
                        GlobalBenchmark.lblDrawingArmypanelIterations.Text = "Army Iterations: " + renderer.IterationsPerSeconds;
                }

                #endregion

                #region Apm

                if (renderer is ApmRenderer)
                {
                    if (renderer.IsHidden)
                        GlobalBenchmark.lblDrawingApmpanelIterations.Text = "Apm Iterations: Unknown";

                    else
                        GlobalBenchmark.lblDrawingApmpanelIterations.Text = "Apm Iterations: " + renderer.IterationsPerSeconds;
                }

                #endregion

                #region Maphack

                if (renderer is MaphackRenderer)
                {
                    if (renderer.IsHidden)
                        GlobalBenchmark.lblDrawingMaphackpanelIterations.Text = "Maphack Iterations: Unknown";

                    else
                        GlobalBenchmark.lblDrawingMaphackpanelIterations.Text = "Maphack Iterations: " + renderer.IterationsPerSeconds;
                }

                #endregion

                #region Ûnit

                if (renderer is UnitRenderer)
                {
                    if (renderer.IsHidden)
                        GlobalBenchmark.lblDrawingUnitpanelIterations.Text = "Unit Iterations: Unknown";

                    else
                        GlobalBenchmark.lblDrawingUnitpanelIterations.Text = "Unit Iterations: " + renderer.IterationsPerSeconds;
                }

                #endregion
            }

         
            SetUnitListboxInformation();
            SetPlayerListboxInformation();
            SetGameInformationListBox();


            //Debug.WriteLine("The tmrGatherInformation Timer- loop was refreshed " + lTimesRefreshed + " times in a second!");
            //lTimesRefreshed = 0;
            _dtSecond = DateTime.Now;
        }

        private void ChBxGlobalForegroundDrawCheckedChanged(object sender, EventArgs e)
        {
            PSettings.GlobalDrawOnlyInForeground = CustGlobal.chBxGlobalForegroundDraw.Checked;
        }

        private void txtGlobalAdjustKey_KeyDown(object sender, KeyEventArgs e)
        {
            CustGlobal.txtGlobalAdjustKey.Text = e.KeyCode.ToString();
            PSettings.GlobalChangeSizeAndPosition = e.KeyCode;
            e.SuppressKeyPress = true;
        }

        /* Draw the credits */
        private void tcCredits_Paint(object sender, PaintEventArgs e)
        {
            var iPosYCycle = 75;
            var iPosYString = 70;
            const Int32 iPosXCycle = 220;
            const Int32 iPosXString = 235;

            e.Graphics.FillEllipse(Brushes.Black, iPosXCycle, iPosYCycle, 7, 7);
            e.Graphics.DrawString("Beaving (D3Scene) - Various hacking information, Concepts and Suggestions", Constants.FCenturyGothic12, Brushes.Black, iPosXString, iPosYString);
            iPosYCycle += 30;
            iPosYString += 30;

            e.Graphics.FillEllipse(Brushes.Black, iPosXCycle, iPosYCycle, 7, 7);
            e.Graphics.DrawString("RHCP (D3Scene) - Open Source MH, Gameinteraction, Minimap drawing", Constants.FCenturyGothic12, Brushes.Black, iPosXString, iPosYString);
            iPosYCycle += 30;
            iPosYString += 30;

            e.Graphics.FillEllipse(Brushes.Black, iPosXCycle, iPosYCycle, 7, 7);
            e.Graphics.DrawString("Mr Nukealizer (D3Scene) - Open Source MH, Ideas and Concepts", Constants.FCenturyGothic12, Brushes.Black, iPosXString, iPosYString);
            iPosYCycle += 30;
            iPosYString += 30;

            e.Graphics.FillEllipse(Brushes.Black, iPosXCycle, iPosYCycle, 7, 7);
            e.Graphics.DrawString("MyTeeWun (D3Scene) - Production- Tab (Units, Upgrades)", Constants.FCenturyGothic12, Brushes.Black, iPosXString, iPosYString);
            iPosYCycle += 30;
            iPosYString += 30;

            e.Graphics.FillEllipse(Brushes.Black, iPosXCycle, iPosYCycle, 7, 7);
            e.Graphics.DrawString("mischa (D3Scene) - Production- Tab (Units, Upgrades)- Reasearch", Constants.FCenturyGothic12, Brushes.Black, iPosXString, iPosYString);
            iPosYCycle += 30;
            iPosYString += 30;

            e.Graphics.FillEllipse(Brushes.Black, iPosXCycle, iPosYCycle, 7, 7);
            e.Graphics.DrawString("mr_ice (D3Scene) - Graphical help", Constants.FCenturyGothic12, Brushes.Black, iPosXString, iPosYString);
            iPosYCycle += 30;
            iPosYString += 30;

            e.Graphics.FillEllipse(Brushes.Black, iPosXCycle, iPosYCycle, 7, 7);
            e.Graphics.DrawString("Tracky (D3Scene) - Providing the community, Suggestions/ Ideas", Constants.FCenturyGothic12, Brushes.Black, iPosXString, iPosYString);
            iPosYCycle += 30;
            iPosYString += 30;

            e.Graphics.FillEllipse(Brushes.Black, iPosXCycle, iPosYCycle, 7, 7);
            e.Graphics.DrawString("Dark Mage- (Blizzhackers) - Providing Mirrorfiles, Providing the community", Constants.FCenturyGothic12, Brushes.Black, iPosXString, iPosYString);
            iPosYCycle += 30;
            iPosYString += 30;

            e.Graphics.FillEllipse(Brushes.Black, iPosXCycle, iPosYCycle, 7, 7);
            e.Graphics.DrawString("The unmentioned crowd that give Ideas, Suggestions and Bugreports", Constants.FCenturyGothic12, Brushes.Black, iPosXString, iPosYString);
        }

        /* Initiate download... */
        private void GetPublicInformation()
        {
            var wc = new WebClient { Proxy = null };
            var ping = new Ping();

            try
            {
                var res = ping.Send("Dropbox.com", 10);

                if (res == null || !res.Status.Equals(IPStatus.Success)) return;

                wc.DownloadStringAsync(new Uri(StrOnlinePublicInformation));
                wc.DownloadStringCompleted += wc_PublicInformation_DownloadStringComplete;
            }

            catch
            {
                MethodInvoker inv = delegate
                {
                    CustGlobal.rtbPublicInformation.Text = "No Connection!";
                };

                try
                {
                    Invoke(inv);
                }

                catch
                {
                    /* Do nothing */
                }
            }
        }

        /* When the string is finally downloaded */
        private void wc_PublicInformation_DownloadStringComplete(object sender, DownloadStringCompletedEventArgs downloadStringCompletedEventArgs)
        {
            /* Quick 'n' Dirty */
            MethodInvoker inv = delegate
            {
                CustGlobal.rtbPublicInformation.Text = downloadStringCompletedEventArgs.Result;
            };

            var iCounter = 0;
        InvokeAgain:
            try
            {
                Invoke(inv);
            }

            catch
            {
                if (iCounter >= 5)
                    return;

                iCounter++;
                goto InvokeAgain;
            }
        }

        /* Change position based on resolution */
        private void BtnGlobalSetPositionClick(object sender, EventArgs e)
        {
            var tmpPreferences = PSettings;

            HelpFunctions.InitResolution(ref tmpPreferences);
            PSettings = tmpPreferences;

            // HelpFunctions.AdjustMinimap(GInformation.Gameinfo.IsIngame, PSc2Process.MainWindowHandle, ref _rMaphack);
        }

        /* Change position based on resolution */
        private byte _bProofClickable = 1;
        private void btnChangeBorderstyle_Click(object sender, EventArgs e)
        {
            if (_bProofClickable.Equals(0))
            {
                _bProofClickable = 1;

                _lContainer.SetFormBorderStyle(FormBorderStyle.None);
            }

            else
            {
                _bProofClickable = 0;

                _lContainer.SetFormBorderStyle(FormBorderStyle.SizableToolWindow);
            }
        }

        private void tcMainTab_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tcMainTab.SelectedTab.Equals(tcDebug))
                SetMapListboxInformation();
        }

        private void MainHandler_Load(object sender, EventArgs e)
        {
            CustGlobal.txtFilename.Text = Path.GetFileNameWithoutExtension(Application.ExecutablePath);
        }

        #endregion

        #region Various

        private void chBxVarPersonalApm_CheckedChanged(object sender, EventArgs e)
        {
            PSettings.PersonalApm = Custom_Various.chBxApm.Checked;

            foreach (var renderer in _lContainer)
            {
                if (renderer is PersonalApmRenderer)
                    renderer.ToggleShowHide(PSettings.PersonalApm);
            }
        }

        private void chBxVarPersonalClock_CheckedChanged(object sender, EventArgs e)
        {
            PSettings.PersonalClock = Custom_Various.chBxClock.Checked;

            foreach (var renderer in _lContainer)
            {
                if (renderer is PersonalClockRenderer)
                    renderer.ToggleShowHide(PSettings.PersonalClock);
            }
        }

        private void chBxVarPersonalApmAlert_CheckedChanged(object sender, EventArgs e)
        {
            PSettings.PersonalApmAlert = Custom_Various.chBxApmAlert.Checked;
        }

        private void txtVarApmAlertLimit_TextChanged(object sender, EventArgs e)
        {
            if (Custom_Various.txtApmAlertLimit.Text.Length <= 0)
                return;

            PSettings.PersonalApmAlertLimit = int.Parse(Custom_Various.txtApmAlertLimit.Text);
        }

        #endregion

        #region Send Email

        ///* Doesn't work anymore.. :/ */
        private void btnEmailSend_Click(object sender, EventArgs e)
        {
            if (CustBugs.cmBxEmailSubject.Text.Equals(string.Empty))
            {
                MessageBox.Show("Select an Item!");
                return;
            }

            if (CustBugs.cmBxEmailSubject.SelectedItem.Equals(String.Empty))
            {
                MessageBox.Show("Select a subject!");
                return;
            }

            if (CustBugs.txtEmailBody.Text.Length <= 0)
            {
                MessageBox.Show("Enter a text and tell what's wrong!");
                return;
            }

            var ssSecure = new SecureString();


            Messages.SendEmail("smtp.mail.yahoo.com",
                "ww1ww2worm",
                ssSecure,
                new MailAddress("ww1ww2worm@yahoo.com"),
                CustBugs.txtEmailSubject.Text,
                CustBugs.txtEmailBody.Text,
                "Nothing");


            MessageBox.Show("The Email was sent successfully!", "Email sent");
        }

        private void txtEmailBody_TextChanged(object sender, EventArgs e)
        {
            CustBugs.btnEmailSend.Enabled = CustBugs.txtEmailBody.Text.Length > 0 &&
                                   CustBugs.txtEmailSubject.Text.Length > 0;
        }

        private void txtEmailSubject_TextChanged(object sender, EventArgs e)
        {
            CustBugs.btnEmailSend.Enabled = CustBugs.txtEmailBody.Text.Length > 0 &&
                                   CustBugs.txtEmailSubject.Text.Length > 0;
        }

        private void cmBxEmailSubject_SelectedIndexChanged(object sender, EventArgs e)
        {
            CustBugs.txtEmailSubject.Enabled = CustBugs.cmBxEmailSubject.SelectedItem.Equals("Other");

            /* Set title */
            CustBugs.txtEmailSubject.Text = CustBugs.cmBxEmailSubject.Text;

            /* Enable/ Disable mailbutton */
            CustBugs.btnEmailSend.Enabled = CustBugs.txtEmailBody.Text.Length > 0;
        }

        /* Because I don't know how to send anonymous email to keep my privacy and the users.. */
        private void btnCreateNewPost_Click(object sender, EventArgs e)
        {
            Process.Start("http://www.d3scene.com/forum/newreply.php?p=487274&noquote=1");
        }

        #endregion
    }
}
