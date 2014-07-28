﻿using System;
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
using Predefined;

namespace AnotherSc2Hack.Classes.FrontEnds.MainHandler
{
    public partial class MainHandler
    {
        #region Resources

        private void cmBxResRemAi_SelectedIndexChanged(object sender, EventArgs e)
        {
            PSettings.ResourceRemoveAi = Convert.ToBoolean(ResourceBasics.cmBxRemAi.Text);
        }

        private void cmBxResRemAllie_SelectedIndexChanged(object sender, EventArgs e)
        {
            PSettings.ResourceRemoveAllie = Convert.ToBoolean(ResourceBasics.cmBxRemAllie.Text);
        }

        private void cmBxResRemNeutral_SelectedIndexChanged(object sender, EventArgs e)
        {
            PSettings.ResourceRemoveNeutral = Convert.ToBoolean(ResourceBasics.cmBxRemNeutral.Text);
        }

        private void cmBxResRemLocalplayer_SelectedIndexChanged(object sender, EventArgs e)
        {
            PSettings.ResourceRemoveLocalplayer = Convert.ToBoolean(ResourceBasics.cmBxRemLocalplayer.Text);
        }

        private void btnResFontName_Click(object sender, EventArgs e)
        {
        FontAgain:

            try
            {
                var fd = new FontDialog();
                fd.Font = new Font(ResourceBasics.btnFontName.Text, 15);
                var result = fd.ShowDialog();

                if (result.Equals(DialogResult.OK))
                {
                    ResourceBasics.btnFontName.Text = fd.Font.Name;
                    ResourceBasics.btnFontName.Font = new Font(fd.Font.Name, Font.Size, FontStyle.Regular);
                    PSettings.ResourceFontName = fd.Font.Name;
                }
            }

            catch
            {
                MessageBox.Show("Only TrueType Fonts are allowed!");
                goto FontAgain;
            }
        }

        private void tbResOpacity_Scroll(object sender, EventArgs e)
        {
            if (ResourceBasics.tbOpacity.Value > 0)
                ResourceBasics.lblOpacity.Text = "Opacity: " + (ResourceBasics.tbOpacity.Value * 1).ToString(CultureInfo.InvariantCulture) + "%";

            else
                ResourceBasics.tbOpacity.Value = 1;

            PSettings.ResourceOpacity = (double)ResourceBasics.tbOpacity.Value / 100;
        }

        private void txtResTogglePanel_TextChanged(object sender, EventArgs e)
        {
            if (ResourceChatInput.txtToggle.Text.Length > 0)
                PSettings.ResourceTogglePanel = ResourceChatInput.txtToggle.Text;
        }

        private void txtResPositionPanel_TextChanged(object sender, EventArgs e)
        {
            if (ResourceChatInput.txtPosition.Text.Length > 0)
                PSettings.ResourceChangePositionPanel = ResourceChatInput.txtPosition.Text;
        }

        private void txtResChangeSizePanel_TextChanged(object sender, EventArgs e)
        {
            if (ResourceChatInput.txtSize.Text.Length > 0)
                PSettings.ResourceChangeSizePanel = ResourceChatInput.txtSize.Text;
        }

        private void txtResHotkey1_KeyDown(object sender, KeyEventArgs e)
        {
            ResourceHotkeys.txtHotkey1.Text = e.KeyCode.ToString();
            PSettings.ResourceHotkey1 = e.KeyCode;
            e.SuppressKeyPress = true;
        }

        private void txtResHotkey2_KeyDown(object sender, KeyEventArgs e)
        {
            ResourceHotkeys.txtHotkey2.Text = e.KeyCode.ToString();
            PSettings.ResourceHotkey2 = e.KeyCode;
            e.SuppressKeyPress = true;
        }

        private void txtResHotkey3_KeyDown(object sender, KeyEventArgs e)
        {
            ResourceHotkeys.txtHotkey3.Text = e.KeyCode.ToString();
            PSettings.ResourceHotkey3 = e.KeyCode;
            e.SuppressKeyPress = true;
        }

        private void chBxResDrawBackground_CheckedChanged(object sender, EventArgs e)
        {
            PSettings.ResourceDrawBackground = ResourceBasics.chBxDrawBackground.Checked;
        }

        private void cmBxResRemClanTag_SelectedIndexChanged(object sender, EventArgs e)
        {
            PSettings.ResourceRemoveClanTag = Convert.ToBoolean(ResourceBasics.cmBxRemClanTag.Text);
        }

        #endregion

        #region Income

        private void cmBxIncRemAi_SelectedIndexChanged(object sender, EventArgs e)
        {
            PSettings.IncomeRemoveAi = Convert.ToBoolean(IncomeBasics.cmBxRemAi.Text);
        }

        private void cmBxIncRemAllie_SelectedIndexChanged(object sender, EventArgs e)
        {
            PSettings.IncomeRemoveAllie = Convert.ToBoolean(IncomeBasics.cmBxRemAllie.Text);
        }

        private void cmBxIncRemNeutral_SelectedIndexChanged(object sender, EventArgs e)
        {
            PSettings.IncomeRemoveNeutral = Convert.ToBoolean(IncomeBasics.cmBxRemNeutral.Text);
        }

        private void cmBxIncRemLocalplayer_SelectedIndexChanged(object sender, EventArgs e)
        {
            PSettings.IncomeRemoveLocalplayer = Convert.ToBoolean(IncomeBasics.cmBxRemLocalplayer.Text);
        }

        private void btnIncFontName_Click(object sender, EventArgs e)
        {
        FontAgain:

            try
            {
                var fd = new FontDialog();
                fd.Font = new Font(IncomeBasics.btnFontName.Text, 15);
                var result = fd.ShowDialog();

                if (result.Equals(DialogResult.OK))
                {
                    IncomeBasics.btnFontName.Text = fd.Font.Name;
                    IncomeBasics.btnFontName.Font = new Font(fd.Font.Name, Font.Size, FontStyle.Regular);
                    PSettings.IncomeFontName = fd.Font.Name;
                }
            }

            catch
            {
                MessageBox.Show("Only TrueType Fonts are allowed!");
                goto FontAgain;
            }
        }

        private void tbIncOpacity_Scroll(object sender, EventArgs e)
        {
            if (IncomeBasics.tbOpacity.Value > 0)
                IncomeBasics.lblOpacity.Text = "Opacity: " + (IncomeBasics.tbOpacity.Value * 1).ToString(CultureInfo.InvariantCulture) + "%";

            else
                IncomeBasics.tbOpacity.Value = 1;

            PSettings.IncomeOpacity = (double)IncomeBasics.tbOpacity.Value / 100;
        }

        private void txtIncTogglePanel_TextChanged(object sender, EventArgs e)
        {
            if (IncomeChatInput.txtToggle.Text.Length > 0)
                PSettings.IncomeTogglePanel = IncomeChatInput.txtToggle.Text;
        }

        private void txtIncPositionPanel_TextChanged(object sender, EventArgs e)
        {
            if (IncomeChatInput.txtPosition.Text.Length > 0)
                PSettings.IncomeChangePositionPanel = IncomeChatInput.txtPosition.Text;
        }

        private void txtIncChangeSizePanel_TextChanged(object sender, EventArgs e)
        {
            if (IncomeChatInput.txtSize.Text.Length > 0)
                PSettings.IncomeChangeSizePanel = IncomeChatInput.txtSize.Text;
        }

        private void txtIncHotkey1_KeyDown(object sender, KeyEventArgs e)
        {
            IncomeHotkeys.txtHotkey1.Text = e.KeyCode.ToString();
            PSettings.IncomeHotkey1 = e.KeyCode;
            e.SuppressKeyPress = true;
        }

        private void txtIncHotkey2_KeyDown(object sender, KeyEventArgs e)
        {
            IncomeHotkeys.txtHotkey2.Text = e.KeyCode.ToString();
            PSettings.IncomeHotkey2 = e.KeyCode;
            e.SuppressKeyPress = true;
        }

        private void txtIncHotkey3_KeyDown(object sender, KeyEventArgs e)
        {
            IncomeHotkeys.txtHotkey3.Text = e.KeyCode.ToString();
            PSettings.IncomeHotkey3 = e.KeyCode;
            e.SuppressKeyPress = true;
        }

        private void chBxIncDrawBackground_CheckedChanged(object sender, EventArgs e)
        {
            PSettings.IncomeDrawBackground = IncomeBasics.chBxDrawBackground.Checked;
        }

        private void cmBxIncRemClanTag_SelectedIndexChanged(object sender, EventArgs e)
        {
            PSettings.IncomeRemoveClanTag = Convert.ToBoolean(IncomeBasics.cmBxRemClanTag.Text);
        }

        #endregion

        #region Worker

        private void btnWorFontName_Click(object sender, EventArgs e)
        {
        FontAgain:

            try
            {
                var fd = new FontDialog();
                fd.Font = new Font(WorkerBasics.btnFontName.Text, 15);
                var result = fd.ShowDialog();

                if (result.Equals(DialogResult.OK))
                {
                    WorkerBasics.btnFontName.Text = fd.Font.Name;
                    WorkerBasics.btnFontName.Font = new Font(fd.Font.Name, Font.Size, FontStyle.Regular);
                    PSettings.WorkerFontName = fd.Font.Name;
                }
            }

            catch
            {
                MessageBox.Show("Only TrueType Fonts are allowed!");
                goto FontAgain;
            }
        }

        private void tbWorOpacity_Scroll(object sender, EventArgs e)
        {
            if (WorkerBasics.tbOpacity.Value > 0)
                WorkerBasics.lblOpacity.Text = "Opacity: " + (WorkerBasics.tbOpacity.Value * 1).ToString(CultureInfo.InvariantCulture) + "%";

            else
                WorkerBasics.tbOpacity.Value = 1;

            PSettings.WorkerOpacity = (double)WorkerBasics.tbOpacity.Value / 100;
        }

        private void txtWorTogglePanel_TextChanged(object sender, EventArgs e)
        {
            if (WorkerChatInput.txtToggle.Text.Length > 0)
                PSettings.WorkerTogglePanel = WorkerChatInput.txtToggle.Text;
        }

        private void txtWorPositionPanel_TextChanged(object sender, EventArgs e)
        {
            if (WorkerChatInput.txtPosition.Text.Length > 0)
                PSettings.WorkerChangePositionPanel = WorkerChatInput.txtPosition.Text;
        }

        private void txtWorChangeSizePanel_TextChanged(object sender, EventArgs e)
        {
            if (WorkerChatInput.txtSize.Text.Length > 0)
                PSettings.WorkerChangeSizePanel = WorkerChatInput.txtSize.Text;
        }

        private void txtWorHotkey1_KeyDown(object sender, KeyEventArgs e)
        {
            WorkerHotkeys.txtHotkey1.Text = e.KeyCode.ToString();
            PSettings.WorkerHotkey1 = e.KeyCode;
            e.SuppressKeyPress = true;
        }

        private void txtWorHotkey2_KeyDown(object sender, KeyEventArgs e)
        {
            WorkerHotkeys.txtHotkey2.Text = e.KeyCode.ToString();
            PSettings.WorkerHotkey2 = e.KeyCode;
            e.SuppressKeyPress = true;
        }

        private void txtWorHotkey3_KeyDown(object sender, KeyEventArgs e)
        {
            WorkerHotkeys.txtHotkey3.Text = e.KeyCode.ToString();
            PSettings.WorkerHotkey3 = e.KeyCode;
            e.SuppressKeyPress = true;
        }

        private void chBxWorDrawBackground_CheckedChanged(object sender, EventArgs e)
        {
            PSettings.WorkerDrawBackground = WorkerBasics.chBxDrawBackground.Checked;
        }

        #endregion

        #region Apm

        private void cmBxApmRemAi_SelectedIndexChanged(object sender, EventArgs e)
        {
            PSettings.ApmRemoveAi = Convert.ToBoolean(ApmBasics.cmBxRemAi.Text);
        }

        private void cmBxApmRemAllie_SelectedIndexChanged(object sender, EventArgs e)
        {
            PSettings.ApmRemoveAllie = Convert.ToBoolean(ApmBasics.cmBxRemAllie.Text);
        }

        private void cmBxApmRemNeutral_SelectedIndexChanged(object sender, EventArgs e)
        {
            PSettings.ApmRemoveNeutral = Convert.ToBoolean(ApmBasics.cmBxRemNeutral.Text);
        }

        private void cmBxApmRemLocalplayer_SelectedIndexChanged(object sender, EventArgs e)
        {
            PSettings.ApmRemoveLocalplayer = Convert.ToBoolean(ApmBasics.cmBxRemLocalplayer.Text);
        }

        private void btnApmFontName_Click(object sender, EventArgs e)
        {

        FontAgain:

            try
            {
                var fd = new FontDialog();
                fd.Font = new Font(ApmBasics.btnFontName.Text, 15);
                var result = fd.ShowDialog();

                if (result.Equals(DialogResult.OK))
                {
                    ApmBasics.btnFontName.Text = fd.Font.Name;
                    ApmBasics.btnFontName.Font = new Font(fd.Font.Name, Font.Size, FontStyle.Regular);
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
            if (ApmBasics.tbOpacity.Value > 0)
                ApmBasics.lblOpacity.Text = "Opacity: " + (ApmBasics.tbOpacity.Value * 1).ToString(CultureInfo.InvariantCulture) + "%";

            else
                ApmBasics.tbOpacity.Value = 1;

            PSettings.ApmOpacity = (double)ApmBasics.tbOpacity.Value / 100;
        }

        private void txtApmTogglePanel_TextChanged(object sender, EventArgs e)
        {
            if (ApmChatInput.txtToggle.Text.Length > 0)
                PSettings.ApmTogglePanel = ApmChatInput.txtToggle.Text;
        }

        private void txtApmPositionPanel_TextChanged(object sender, EventArgs e)
        {
            if (ApmChatInput.txtPosition.Text.Length > 0)
                PSettings.ApmChangePositionPanel = ApmChatInput.txtPosition.Text;
        }

        private void txtApmChangeSizePanel_TextChanged(object sender, EventArgs e)
        {
            if (ApmChatInput.txtSize.Text.Length > 0)
                PSettings.ApmChangeSizePanel = ApmChatInput.txtSize.Text;
        }

        private void txtApmHotkey1_KeyDown(object sender, KeyEventArgs e)
        {
            ApmHotkeys.txtHotkey1.Text = e.KeyCode.ToString();
            PSettings.ApmHotkey1 = e.KeyCode;
            e.SuppressKeyPress = true;
        }

        private void txtApmHotkey2_KeyDown(object sender, KeyEventArgs e)
        {
            ApmHotkeys.txtHotkey2.Text = e.KeyCode.ToString();
            PSettings.ApmHotkey2 = e.KeyCode;
            e.SuppressKeyPress = true;
        }

        private void txtApmHotkey3_KeyDown(object sender, KeyEventArgs e)
        {
            ApmHotkeys.txtHotkey3.Text = e.KeyCode.ToString();
            PSettings.ApmHotkey3 = e.KeyCode;
            e.SuppressKeyPress = true;
        }

        private void chBxApmDrawBackground_CheckedChanged(object sender, EventArgs e)
        {
            PSettings.ApmDrawBackground = ApmBasics.chBxDrawBackground.Checked;
        }

        private void cmBxApmRemClanTag_SelectedIndexChanged(object sender, EventArgs e)
        {
            PSettings.ApmRemoveClanTag = Convert.ToBoolean(ApmBasics.cmBxRemClanTag.Text);
        }


        #endregion

        #region Army

        private void cmBxArmRemAi_SelectedIndexChanged(object sender, EventArgs e)
        {
            PSettings.ArmyRemoveAi = Convert.ToBoolean(ArmyBasics.cmBxRemAi.Text);
        }

        private void cmBxArmRemAllie_SelectedIndexChanged(object sender, EventArgs e)
        {
            PSettings.ArmyRemoveAllie = Convert.ToBoolean(ArmyBasics.cmBxRemAllie.Text);
        }

        private void cmBxArmRemNeutral_SelectedIndexChanged(object sender, EventArgs e)
        {
            PSettings.ArmyRemoveNeutral = Convert.ToBoolean(ArmyBasics.cmBxRemNeutral.Text);
        }

        private void cmBxArmRemLocalplayer_SelectedIndexChanged(object sender, EventArgs e)
        {
            PSettings.ArmyRemoveLocalplayer = Convert.ToBoolean(ArmyBasics.cmBxRemLocalplayer.Text);
        }

        private void btnArmFontName_Click(object sender, EventArgs e)
        {
        FontAgain:

            try
            {
                var fd = new FontDialog();
                fd.Font = new Font(ArmyBasics.btnFontName.Text, 15);
                var result = fd.ShowDialog();

                if (result.Equals(DialogResult.OK))
                {
                    ArmyBasics.btnFontName.Text = fd.Font.Name;
                    ArmyBasics.btnFontName.Font = new Font(fd.Font.Name, Font.Size, FontStyle.Regular);
                    PSettings.ArmyFontName = fd.Font.Name;
                }
            }

            catch
            {
                MessageBox.Show("Only TrueType Fonts are allowed!");
                goto FontAgain;
            }
        }

        private void tbArmOpacity_Scroll(object sender, EventArgs e)
        {
            if (ArmyBasics.tbOpacity.Value > 0)
                ArmyBasics.lblOpacity.Text = "Opacity: " + (ArmyBasics.tbOpacity.Value * 1).ToString(CultureInfo.InvariantCulture) + "%";

            else
                ArmyBasics.tbOpacity.Value = 1;

            PSettings.ArmyOpacity = (double)ArmyBasics.tbOpacity.Value / 100;
        }

        private void txtArmTogglePanel_TextChanged(object sender, EventArgs e)
        {
            if (ArmyChatInput.txtToggle.Text.Length > 0)
                PSettings.ArmyTogglePanel = ArmyChatInput.txtToggle.Text;
        }

        private void txtArmPositionPanel_TextChanged(object sender, EventArgs e)
        {
            if (ApmChatInput.txtPosition.Text.Length > 0)
                PSettings.ArmyChangePositionPanel = ApmChatInput.txtPosition.Text;
        }

        private void txtArmChangeSizePanel_TextChanged(object sender, EventArgs e)
        {
            if (ArmyChatInput.txtSize.Text.Length > 0)
                PSettings.ArmyChangeSizePanel = ArmyChatInput.txtSize.Text;
        }

        private void txtArmHotkey1_KeyDown(object sender, KeyEventArgs e)
        {
            ArmyHotkeys.txtHotkey1.Text = e.KeyCode.ToString();
            PSettings.ArmyHotkey1 = e.KeyCode;
            e.SuppressKeyPress = true;
        }

        private void txtArmHotkey2_KeyDown(object sender, KeyEventArgs e)
        {
            ArmyHotkeys.txtHotkey2.Text = e.KeyCode.ToString();
            PSettings.ArmyHotkey2 = e.KeyCode;
            e.SuppressKeyPress = true;
        }

        private void txtArmHotkey3_KeyDown(object sender, KeyEventArgs e)
        {
            ArmyHotkeys.txtHotkey3.Text = e.KeyCode.ToString();
            PSettings.ArmyHotkey3 = e.KeyCode;
            e.SuppressKeyPress = true;
        }

        private void chBxArmDrawBackground_CheckedChanged(object sender, EventArgs e)
        {
            PSettings.ArmyDrawBackground = ArmyBasics.chBxDrawBackground.Checked;
        }

        private void cmBxArmRemClanTag_SelectedIndexChanged(object sender, EventArgs e)
        {
            PSettings.ArmyRemoveClanTag = Convert.ToBoolean(ArmyBasics.cmBxRemClanTag.Text);
        }


        #endregion

        #region Unittab

        private void cmBxUniRemAi_SelectedIndexChanged(object sender, EventArgs e)
        {
            PSettings.UnitTabRemoveAi = Convert.ToBoolean(UnittabBasics.cmBxRemAi.Text);
        }

        private void cmBxUniRemAllie_SelectedIndexChanged(object sender, EventArgs e)
        {
            PSettings.UnitTabRemoveAllie = Convert.ToBoolean(UnittabBasics.cmBxRemAllie.Text);
        }

        private void cmBxUniRemNeutral_SelectedIndexChanged(object sender, EventArgs e)
        {
            PSettings.UnitTabRemoveNeutral = Convert.ToBoolean(UnittabBasics.cmBxRemNeutral.Text);
        }

        private void cmBxUniRemLocalplayer_SelectedIndexChanged(object sender, EventArgs e)
        {
            PSettings.UnitTabRemoveLocalplayer = Convert.ToBoolean(UnittabBasics.cmBxRemLocalplayer.Text);
        }

        private void cmBxUniSplitBuildings_SelectedIndexChanged(object sender, EventArgs e)
        {
            PSettings.UnitTabSplitUnitsAndBuildings = Convert.ToBoolean(UnittabBasics.cmBxSplitBuildings.Text);
        }

        private void cmBxUniRemProdLine_SelectedIndexChanged(object sender, EventArgs e)
        {
            PSettings.UnitTabRemoveProdLine = Convert.ToBoolean(UnittabBasics.cmBxRemProdLine.Text);
        }

        private void tbUniOpacity_Scroll(object sender, EventArgs e)
        {
            if (UnittabBasics.tbOpacity.Value > 0)
                UnittabBasics.lblOpacity.Text = "Opacity: " + (UnittabBasics.tbOpacity.Value * 1).ToString(CultureInfo.InvariantCulture) + "%";

            else
                UnittabBasics.tbOpacity.Value = 1;

            PSettings.UnitTabOpacity = (double)UnittabBasics.tbOpacity.Value / 100;
        }

        private void txtUnitTogglePanel_TextChanged(object sender, EventArgs e)
        {
            if (UnittabChatInput.txtToggle.Text.Length > 0)
                PSettings.UnitTogglePanel = UnittabChatInput.txtToggle.Text;
        }

        private void txtUnitPositionPanel_TextChanged(object sender, EventArgs e)
        {
            if (UnittabChatInput.txtPosition.Text.Length > 0)
                PSettings.UnitChangePositionPanel = UnittabChatInput.txtPosition.Text;
        }

        private void txtUnitChangeSizePanel_TextChanged(object sender, EventArgs e)
        {
            if (UnittabChatInput.txtSize.Text.Length > 0)
                PSettings.UnitChangeSizePanel = UnittabChatInput.txtSize.Text;
        }

        private void txtUnitHotkey1_KeyDown(object sender, KeyEventArgs e)
        {
            UnittabHotkeys.txtHotkey1.Text = e.KeyCode.ToString();
            PSettings.UnitHotkey1 = e.KeyCode;
            e.SuppressKeyPress = true;
        }

        private void txtUnitHotkey2_KeyDown(object sender, KeyEventArgs e)
        {
            UnittabHotkeys.txtHotkey2.Text = e.KeyCode.ToString();
            PSettings.UnitHotkey2 = e.KeyCode;
            e.SuppressKeyPress = true;
        }

        private void txtUnitHotkey3_KeyDown(object sender, KeyEventArgs e)
        {
            UnittabHotkeys.txtHotkey3.Text = e.KeyCode.ToString();
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
                fd.Font = new Font(UnittabBasics.btnFontName.Text, 15);
                var result = fd.ShowDialog();

                if (result.Equals(DialogResult.OK))
                {
                    UnittabBasics.btnFontName.Text = fd.Font.Name;
                    UnittabBasics.btnFontName.Font = new Font(fd.Font.Name, Font.Size, FontStyle.Regular);
                    PSettings.UnitTabFontName = fd.Font.Name;
                }
            }

            catch
            {
                MessageBox.Show("Only TrueType Fonts are allowed!");
                goto FontAgain;
            }
        }

        private void cmBxUniRemClanTag_SelectedIndexChanged(object sender, EventArgs e)
        {
            PSettings.UnitTabRemoveClanTag = Convert.ToBoolean(UnittabBasics.cmBxRemClanTag.Text);
        }

        private void chBxUnitTabShowUnits_CheckedChanged(object sender, EventArgs e)
        {
            PSettings.UnitShowUnits = chBxUnitTabShowUnits.Checked;
        }

        private void chBxUnitTabShowBuildings_CheckedChanged(object sender, EventArgs e)
        {
            PSettings.UnitShowBuildings = chBxUnitTabShowBuildings.Checked;
        }

        void cmBxRemSpellCounter_SelectedIndexChanged(object sender, EventArgs e)
        {
            PSettings.UnitTabRemoveSpellCounter = Convert.ToBoolean(UnittabBasics.cmBxRemSpellCounter.Text);
        }

        void cmBxRemChronoboost_SelectedIndexChanged(object sender, EventArgs e)
        {
            PSettings.UnitTabRemoveChronoboost = Convert.ToBoolean(UnittabBasics.cmBxRemChronoboost.Text);
        }


        #endregion

        #region Production

        private void chBxProdTabShowUnits_CheckedChanged(object sender, EventArgs e)
        {
            PSettings.ProdTabShowUnits = chBxProdTabShowUnits.Checked;
        }

        private void chBxProdTabShowBuildings_CheckedChanged(object sender, EventArgs e)
        {
            PSettings.ProdTabShowBuildings = chBxProdTabShowBuildings.Checked;
        }

        private void chBxProdTabShowUpgrades_CheckedChanged(object sender, EventArgs e)
        {
            PSettings.ProdTabShowUpgrades = chBxProdTabShowUpgrades.Checked;
        }

        private void cmBxProRemAi_SelectedIndexChanged(object sender, EventArgs e)
        {
            PSettings.ProdTabRemoveAi = Convert.ToBoolean(ProductionTabBasics.cmBxRemAi.Text);
        }

        private void cmBxProRemAllie_SelectedIndexChanged(object sender, EventArgs e)
        {
            PSettings.ProdTabRemoveAllie = Convert.ToBoolean(ProductionTabBasics.cmBxRemAllie.Text);
        }

        private void cmBxProRemNeutral_SelectedIndexChanged(object sender, EventArgs e)
        {
            PSettings.ProdTabRemoveNeutral = Convert.ToBoolean(ProductionTabBasics.cmBxRemNeutral.Text);
        }

        private void cmBxProRemLocalplayer_SelectedIndexChanged(object sender, EventArgs e)
        {
            PSettings.ProdTabRemoveLocalplayer = Convert.ToBoolean(ProductionTabBasics.cmBxRemLocalplayer.Text);
        }

        private void cmBxProSplitBuildings_SelectedIndexChanged(object sender, EventArgs e)
        {
            PSettings.ProdTabSplitUnitsAndBuildings = Convert.ToBoolean(ProductionTabBasics.cmBxSplitBuildings.Text);
        }

        private void tbProOpacity_Scroll(object sender, EventArgs e)
        {
            if (ProductionTabBasics.tbOpacity.Value > 0)
                ProductionTabBasics.lblOpacity.Text = "Opacity: " + (ProductionTabBasics.tbOpacity.Value * 1).ToString(CultureInfo.InvariantCulture) + "%";

            else
                ProductionTabBasics.tbOpacity.Value = 1;

            PSettings.ProdTabOpacity = (double)ProductionTabBasics.tbOpacity.Value / 100;
        }

        private void txtProdTogglePanel_TextChanged(object sender, EventArgs e)
        {
            if (ProductionTabChatInput.txtToggle.Text.Length > 0)
                PSettings.ProdTogglePanel = ProductionTabChatInput.txtToggle.Text;
        }

        private void txtProdPositionPanel_TextChanged(object sender, EventArgs e)
        {
            if (ProductionTabChatInput.txtPosition.Text.Length > 0)
                PSettings.ProdChangePositionPanel = ProductionTabChatInput.txtPosition.Text;
        }

        private void txtProdChangeSizePanel_TextChanged(object sender, EventArgs e)
        {
            if (ProductionTabChatInput.txtSize.Text.Length > 0)
                PSettings.ProdChangeSizePanel = ProductionTabChatInput.txtSize.Text;
        }

        private void txtProdHotkey1_KeyDown(object sender, KeyEventArgs e)
        {
            ProductionTabHotkeys.txtHotkey1.Text = e.KeyCode.ToString();
            PSettings.ProdHotkey1 = e.KeyCode;
            e.SuppressKeyPress = true;
        }

        private void txtProdHotkey2_KeyDown(object sender, KeyEventArgs e)
        {
            ProductionTabHotkeys.txtHotkey2.Text = e.KeyCode.ToString();
            PSettings.ProdHotkey2 = e.KeyCode;
            e.SuppressKeyPress = true;
        }

        private void txtProdHotkey3_KeyDown(object sender, KeyEventArgs e)
        {
            ProductionTabHotkeys.txtHotkey3.Text = e.KeyCode.ToString();
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
                fd.Font = new Font(ProductionTabBasics.btnFontName.Text, 15);
                var result = fd.ShowDialog();

                if (result.Equals(DialogResult.OK))
                {
                    ProductionTabBasics.btnFontName.Text = fd.Font.Name;
                    ProductionTabBasics.btnFontName.Font = new Font(fd.Font.Name, Font.Size, FontStyle.Regular);
                    PSettings.ProdTabFontName = fd.Font.Name;
                }
            }

            catch
            {
                MessageBox.Show("Only TrueType Fonts are allowed!");
                goto FontAgain;
            }
        }

        private void cmBxProRemClanTag_SelectedIndexChanged(object sender, EventArgs e)
        {
            PSettings.ProdTabRemoveClanTag = Convert.ToBoolean(ProductionTabBasics.cmBxRemClanTag.Text);
        }

        void cmBxProdRemChronoboost_SelectedIndexChanged(object sender, EventArgs e)
        {
            PSettings.ProdTabRemoveChronoboost = Convert.ToBoolean(ProductionTabBasics.cmBxRemChronoboost.Text);
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

        private void cmBxMapRemAi_SelectedIndexChanged(object sender, EventArgs e)
        {
            PSettings.MaphackRemoveAi = Convert.ToBoolean(MaphackBasics.cmBxRemAi.Text);
        }

        private void cmBxMapRemAllie_SelectedIndexChanged(object sender, EventArgs e)
        {
            PSettings.MaphackRemoveAllie = Convert.ToBoolean(MaphackBasics.cmBxRemAllie.Text);
        }

        private void cmBxMapRemNeutral_SelectedIndexChanged(object sender, EventArgs e)
        {
            PSettings.MaphackRemoveNeutral = Convert.ToBoolean(MaphackBasics.cmBxRemNeutral.Text);
        }

        private void cmBxMapRemLocalplayer_SelectedIndexChanged(object sender, EventArgs e)
        {
            PSettings.MaphackRemoveLocalplayer = Convert.ToBoolean(MaphackBasics.cmBxRemLocalplayer.Text);
        }

        private void ChBxMaphackDisableDestinationLineCheckedChanged(object sender, EventArgs e)
        {
            PSettings.MaphackDisableDestinationLine = MaphackBasics.chBxMaphackDisableDestinationLine.Checked;
        }

        private void tbMapOpacity_Scroll(object sender, EventArgs e)
        {
            if (MaphackBasics.tbOpacity.Value > 0)
                MaphackBasics.lblOpacity.Text = "Opacity: " + (MaphackBasics.tbOpacity.Value * 1).ToString(CultureInfo.InvariantCulture) + "%";

            else
                MaphackBasics.tbOpacity.Value = 1;

            PSettings.MaphackOpacity = (double)MaphackBasics.tbOpacity.Value / 100;
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

            MaphackBasics.btnDestinationLine.BackColor = PSettings.MaphackDestinationColor;
        }

        private void txtMapTogglePanel_TextChanged(object sender, EventArgs e)
        {
            if (MaphackChatInput.txtToggle.Text.Length > 0)
                PSettings.MaphackTogglePanel = MaphackChatInput.txtToggle.Text;
        }

        private void txtMapPositionPanel_TextChanged(object sender, EventArgs e)
        {
            if (MaphackChatInput.txtPosition.Text.Length > 0)
                PSettings.MaphackChangePositionPanel = MaphackChatInput.txtPosition.Text;
        }

        private void txtMapChangeSizePanel_TextChanged(object sender, EventArgs e)
        {
            if (MaphackChatInput.txtSize.Text.Length > 0)
                PSettings.MaphackChangeSizePanel = MaphackChatInput.txtSize.Text;
        }

        private void txtMapHotkey1_KeyDown(object sender, KeyEventArgs e)
        {
            MaphackHotkeys.txtHotkey1.Text = e.KeyCode.ToString();
            PSettings.MaphackHotkey1 = e.KeyCode;
            e.SuppressKeyPress = true;
        }

        private void txtMapHotkey2_KeyDown(object sender, KeyEventArgs e)
        {
            MaphackHotkeys.txtHotkey2.Text = e.KeyCode.ToString();
            PSettings.MaphackHotkey2 = e.KeyCode;
            e.SuppressKeyPress = true;
        }

        private void txtMapHotkey3_KeyDown(object sender, KeyEventArgs e)
        {
            MaphackHotkeys.txtHotkey3.Text = e.KeyCode.ToString();
            PSettings.MaphackHotkey3 = e.KeyCode;
            e.SuppressKeyPress = true;
        }

        private void ChBxMaphackMaphackColorDefensiveStructuresYellowCheckedChanged(object sender, EventArgs e)
        {
            PSettings.MaphackColorDefensivestructuresYellow = MaphackBasics.chBxMaphackColorDefensiveStructuresYellow.Checked;
        }

        private void ChBxMaphackMaphackRemVisionAreaCheckedChanged(object sender, EventArgs e)
        {
            PSettings.MaphackRemoveVisionArea = MaphackBasics.chBxMaphackRemVisionArea.Checked;
        }

        private void ChBxMaphackMapRemCameraCheckedChanged(object sender, EventArgs e)
        {
            PSettings.MaphackRemoveCamera = MaphackBasics.chBxMaphackRemCamera.Checked;
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
            var rExportFile = new Renderer(PredefinedData.RenderForm.ExportIdsToFile, this);

            /* Crashes because the element wasn't used... 
             * But it was used. Weird shit */
            try
            {
                rExportFile.Show();
            }

            catch { }
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
            #region Hotkeys - Keydown

            ResourceHotkeys.txtHotkey1.KeyDown += txtResHotkey1_KeyDown;
            ResourceHotkeys.txtHotkey2.KeyDown += txtResHotkey2_KeyDown;
            ResourceHotkeys.txtHotkey3.KeyDown += txtResHotkey3_KeyDown;

            IncomeHotkeys.txtHotkey1.KeyDown += txtIncHotkey1_KeyDown;
            IncomeHotkeys.txtHotkey2.KeyDown += txtIncHotkey2_KeyDown;
            IncomeHotkeys.txtHotkey3.KeyDown += txtIncHotkey3_KeyDown;

            WorkerHotkeys.txtHotkey1.KeyDown += txtWorHotkey1_KeyDown;
            WorkerHotkeys.txtHotkey2.KeyDown += txtWorHotkey2_KeyDown;
            WorkerHotkeys.txtHotkey3.KeyDown += txtWorHotkey3_KeyDown;

            ApmHotkeys.txtHotkey1.KeyDown += txtApmHotkey1_KeyDown;
            ApmHotkeys.txtHotkey2.KeyDown += txtApmHotkey2_KeyDown;
            ApmHotkeys.txtHotkey3.KeyDown += txtApmHotkey3_KeyDown;

            ArmyHotkeys.txtHotkey1.KeyDown += txtArmHotkey1_KeyDown;
            ArmyHotkeys.txtHotkey2.KeyDown += txtArmHotkey2_KeyDown;
            ArmyHotkeys.txtHotkey3.KeyDown += txtArmHotkey3_KeyDown;

            MaphackHotkeys.txtHotkey1.KeyDown += txtMapHotkey1_KeyDown;
            MaphackHotkeys.txtHotkey2.KeyDown += txtMapHotkey2_KeyDown;
            MaphackHotkeys.txtHotkey3.KeyDown += txtMapHotkey3_KeyDown;

            UnittabHotkeys.txtHotkey1.KeyDown += txtUnitHotkey1_KeyDown;
            UnittabHotkeys.txtHotkey2.KeyDown += txtUnitHotkey2_KeyDown;
            UnittabHotkeys.txtHotkey3.KeyDown += txtUnitHotkey3_KeyDown;

            ProductionTabHotkeys.txtHotkey1.KeyDown += txtProdHotkey1_KeyDown;
            ProductionTabHotkeys.txtHotkey2.KeyDown += txtProdHotkey2_KeyDown;
            ProductionTabHotkeys.txtHotkey3.KeyDown += txtProdHotkey3_KeyDown;

            workerProductionHotkeys.txtHotkey1.KeyDown += txtHotkey1_KeyDown;
            workerProductionHotkeys.txtHotkey2.KeyDown += txtHotkey2_KeyDown;
            workerProductionHotkeys.txtHotkey3.KeyDown += txtHotkey3_KeyDown;

            #endregion

            #region Chatinput

            ResourceChatInput.txtToggle.TextChanged += txtResTogglePanel_TextChanged;
            ResourceChatInput.txtPosition.TextChanged += txtResPositionPanel_TextChanged;
            ResourceChatInput.txtSize.TextChanged += txtResChangeSizePanel_TextChanged;

            IncomeChatInput.txtToggle.TextChanged += txtIncTogglePanel_TextChanged;
            IncomeChatInput.txtPosition.TextChanged += txtIncPositionPanel_TextChanged;
            IncomeChatInput.txtSize.TextChanged += txtIncChangeSizePanel_TextChanged;

            WorkerChatInput.txtToggle.TextChanged += txtWorTogglePanel_TextChanged;
            WorkerChatInput.txtPosition.TextChanged += txtWorPositionPanel_TextChanged;
            WorkerChatInput.txtSize.TextChanged += txtWorChangeSizePanel_TextChanged;

            ApmChatInput.txtToggle.TextChanged += txtApmTogglePanel_TextChanged;
            ApmChatInput.txtPosition.TextChanged += txtApmPositionPanel_TextChanged;
            ApmChatInput.txtSize.TextChanged += txtApmChangeSizePanel_TextChanged;

            ArmyChatInput.txtToggle.TextChanged += txtArmTogglePanel_TextChanged;
            ArmyChatInput.txtPosition.TextChanged += txtArmPositionPanel_TextChanged;
            ArmyChatInput.txtSize.TextChanged += txtArmChangeSizePanel_TextChanged;

            MaphackChatInput.txtToggle.TextChanged += txtMapTogglePanel_TextChanged;
            MaphackChatInput.txtPosition.TextChanged += txtMapPositionPanel_TextChanged;
            MaphackChatInput.txtSize.TextChanged += txtMapChangeSizePanel_TextChanged;

            UnittabChatInput.txtToggle.TextChanged += txtUnitTogglePanel_TextChanged;
            UnittabChatInput.txtPosition.TextChanged += txtUnitPositionPanel_TextChanged;
            UnittabChatInput.txtSize.TextChanged += txtUnitChangeSizePanel_TextChanged;

            ProductionTabChatInput.txtToggle.TextChanged += txtProdTogglePanel_TextChanged;
            ProductionTabChatInput.txtPosition.TextChanged += txtProdPositionPanel_TextChanged;
            ProductionTabChatInput.txtSize.TextChanged += txtProdChangeSizePanel_TextChanged;

            #endregion

            #region Basics

            ResourceBasics.cmBxRemAi.SelectedIndexChanged += cmBxResRemAi_SelectedIndexChanged;
            ResourceBasics.cmBxRemAllie.SelectedIndexChanged += cmBxResRemAllie_SelectedIndexChanged;
            ResourceBasics.cmBxRemNeutral.SelectedIndexChanged += cmBxResRemNeutral_SelectedIndexChanged;
            ResourceBasics.cmBxRemLocalplayer.SelectedIndexChanged += cmBxResRemLocalplayer_SelectedIndexChanged;
            ResourceBasics.cmBxRemClanTag.SelectedIndexChanged += cmBxResRemClanTag_SelectedIndexChanged;
            ResourceBasics.chBxDrawBackground.CheckedChanged += chBxResDrawBackground_CheckedChanged;
            ResourceBasics.btnFontName.Click += btnResFontName_Click;
            ResourceBasics.tbOpacity.Scroll += tbResOpacity_Scroll;

            IncomeBasics.cmBxRemAi.SelectedIndexChanged += cmBxIncRemAi_SelectedIndexChanged;
            IncomeBasics.cmBxRemAllie.SelectedIndexChanged += cmBxIncRemAllie_SelectedIndexChanged;
            IncomeBasics.cmBxRemNeutral.SelectedIndexChanged += cmBxIncRemNeutral_SelectedIndexChanged;
            IncomeBasics.cmBxRemLocalplayer.SelectedIndexChanged += cmBxIncRemLocalplayer_SelectedIndexChanged;
            IncomeBasics.cmBxRemClanTag.SelectedIndexChanged += cmBxIncRemClanTag_SelectedIndexChanged;
            IncomeBasics.chBxDrawBackground.CheckedChanged += chBxIncDrawBackground_CheckedChanged;
            IncomeBasics.btnFontName.Click += btnIncFontName_Click;
            IncomeBasics.tbOpacity.Scroll += tbIncOpacity_Scroll;

            ApmBasics.cmBxRemAi.SelectedIndexChanged += cmBxApmRemAi_SelectedIndexChanged;
            ApmBasics.cmBxRemAllie.SelectedIndexChanged += cmBxApmRemAllie_SelectedIndexChanged;
            ApmBasics.cmBxRemNeutral.SelectedIndexChanged += cmBxApmRemNeutral_SelectedIndexChanged;
            ApmBasics.cmBxRemLocalplayer.SelectedIndexChanged += cmBxApmRemLocalplayer_SelectedIndexChanged;
            ApmBasics.cmBxRemClanTag.SelectedIndexChanged += cmBxApmRemClanTag_SelectedIndexChanged;
            ApmBasics.chBxDrawBackground.CheckedChanged += chBxApmDrawBackground_CheckedChanged;
            ApmBasics.btnFontName.Click += btnApmFontName_Click;
            ApmBasics.tbOpacity.Scroll += tbApmOpacity_Scroll;

            ArmyBasics.cmBxRemAi.SelectedIndexChanged += cmBxArmRemAi_SelectedIndexChanged;
            ArmyBasics.cmBxRemAllie.SelectedIndexChanged += cmBxArmRemAllie_SelectedIndexChanged;
            ArmyBasics.cmBxRemNeutral.SelectedIndexChanged += cmBxArmRemNeutral_SelectedIndexChanged;
            ArmyBasics.cmBxRemLocalplayer.SelectedIndexChanged += cmBxArmRemLocalplayer_SelectedIndexChanged;
            ArmyBasics.cmBxRemClanTag.SelectedIndexChanged += cmBxArmRemClanTag_SelectedIndexChanged;
            ArmyBasics.chBxDrawBackground.CheckedChanged += chBxArmDrawBackground_CheckedChanged;
            ArmyBasics.btnFontName.Click += btnArmFontName_Click;
            ArmyBasics.tbOpacity.Scroll += tbArmOpacity_Scroll;

            WorkerBasics.chBxDrawBackground.CheckedChanged += chBxWorDrawBackground_CheckedChanged;
            WorkerBasics.btnFontName.Click += btnWorFontName_Click;
            WorkerBasics.tbOpacity.Scroll += tbWorOpacity_Scroll;

            MaphackBasics.cmBxRemAi.SelectedIndexChanged += cmBxMapRemAi_SelectedIndexChanged;
            MaphackBasics.cmBxRemAllie.SelectedIndexChanged += cmBxMapRemAllie_SelectedIndexChanged;
            MaphackBasics.cmBxRemNeutral.SelectedIndexChanged += cmBxMapRemNeutral_SelectedIndexChanged;
            MaphackBasics.cmBxRemLocalplayer.SelectedIndexChanged += cmBxMapRemLocalplayer_SelectedIndexChanged;
            MaphackBasics.chBxMaphackColorDefensiveStructuresYellow.CheckedChanged +=
                ChBxMaphackMaphackColorDefensiveStructuresYellowCheckedChanged;
            MaphackBasics.chBxMaphackDisableDestinationLine.CheckedChanged += ChBxMaphackDisableDestinationLineCheckedChanged;
            MaphackBasics.chBxMaphackRemCamera.CheckedChanged += ChBxMaphackMapRemCameraCheckedChanged;
            MaphackBasics.chBxMaphackRemVisionArea.CheckedChanged += ChBxMaphackMaphackRemVisionAreaCheckedChanged;
            MaphackBasics.tbOpacity.Scroll += tbMapOpacity_Scroll;
            MaphackBasics.btnDestinationLine.Click += btnMaphackDestinationLine_Click;

            UnittabBasics.cmBxRemAi.SelectedIndexChanged += cmBxUniRemAi_SelectedIndexChanged;
            UnittabBasics.cmBxRemAllie.SelectedIndexChanged += cmBxUniRemAllie_SelectedIndexChanged;
            UnittabBasics.cmBxRemNeutral.SelectedIndexChanged += cmBxUniRemNeutral_SelectedIndexChanged;
            UnittabBasics.cmBxRemLocalplayer.SelectedIndexChanged += cmBxUniRemLocalplayer_SelectedIndexChanged;
            UnittabBasics.cmBxRemClanTag.SelectedIndexChanged += cmBxUniRemClanTag_SelectedIndexChanged;
            UnittabBasics.cmBxSplitBuildings.SelectedIndexChanged += cmBxUniSplitBuildings_SelectedIndexChanged;
            UnittabBasics.cmBxRemProdLine.SelectedIndexChanged += cmBxUniRemProdLine_SelectedIndexChanged;
            UnittabBasics.btnFontName.Click += btnUniFontName_Click;
            UnittabBasics.tbOpacity.Scroll += tbUniOpacity_Scroll;
            UnittabBasics.cmBxRemChronoboost.SelectedIndexChanged += cmBxRemChronoboost_SelectedIndexChanged;
            UnittabBasics.cmBxRemSpellCounter.SelectedIndexChanged += cmBxRemSpellCounter_SelectedIndexChanged;

            ProductionTabBasics.cmBxRemAi.SelectedIndexChanged += cmBxProRemAi_SelectedIndexChanged;
            ProductionTabBasics.cmBxRemAllie.SelectedIndexChanged += cmBxProRemAllie_SelectedIndexChanged;
            ProductionTabBasics.cmBxRemNeutral.SelectedIndexChanged += cmBxProRemNeutral_SelectedIndexChanged;
            ProductionTabBasics.cmBxRemLocalplayer.SelectedIndexChanged += cmBxProRemLocalplayer_SelectedIndexChanged;
            ProductionTabBasics.cmBxRemClanTag.SelectedIndexChanged += cmBxProRemClanTag_SelectedIndexChanged;
            ProductionTabBasics.cmBxSplitBuildings.SelectedIndexChanged += cmBxProSplitBuildings_SelectedIndexChanged;
            ProductionTabBasics.btnFontName.Click += btnProFontName_Click;
            ProductionTabBasics.tbOpacity.Scroll += tbProOpacity_Scroll;
            ProductionTabBasics.cmBxRemChronoboost.SelectedIndexChanged += cmBxProdRemChronoboost_SelectedIndexChanged;

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
            workerProductionHotkeys.ChangeLanguageFile(strFile);
            CustBugs.ChangeLanguageFile(strFile);

            /* Basics */
            ResourceBasics.ChangeLanguageFile(strFile);
            IncomeBasics.ChangeLanguageFile(strFile);
            ArmyBasics.ChangeLanguageFile(strFile);
            ApmBasics.ChangeLanguageFile(strFile);
            MaphackBasics.ChangeLanguageFile(strFile);
            UnittabBasics.ChangeLanguageFile(strFile);
            ProductionTabBasics.ChangeLanguageFile(strFile);
            WorkerBasics.ChangeLanguageFile(strFile);

            /* Chatinput */
            ResourceChatInput.ChangeLanguageFile(strFile);
            IncomeChatInput.ChangeLanguageFile(strFile);
            WorkerChatInput.ChangeLanguageFile(strFile);
            UnittabChatInput.ChangeLanguageFile(strFile);
            MaphackChatInput.ChangeLanguageFile(strFile);
            ProductionTabChatInput.ChangeLanguageFile(strFile);
            ApmChatInput.ChangeLanguageFile(strFile);
            ArmyChatInput.ChangeLanguageFile(strFile);

            /* Hotkeys */
            ResourceHotkeys.ChangeLanguageFile(strFile);
            IncomeHotkeys.ChangeLanguageFile(strFile);
            WorkerHotkeys.ChangeLanguageFile(strFile);
            ArmyHotkeys.ChangeLanguageFile(strFile);
            ApmHotkeys.ChangeLanguageFile(strFile);
            MaphackHotkeys.ChangeLanguageFile(strFile);
            UnittabHotkeys.ChangeLanguageFile(strFile);
            ProductionTabHotkeys.ChangeLanguageFile(strFile);
            workerProductionHotkeys.ChangeLanguageFile(strFile);

            /* Information */
            ResourceInformation.ChangeLanguageFile(strFile);
            IncomeInformation.ChangeLanguageFile(strFile);
            WorkerInformation.ChangeLanguageFile(strFile);
            ArmyInformation.ChangeLanguageFile(strFile);
            ApmInformation.ChangeLanguageFile(strFile);
            MaphackInformation.ChangeLanguageFile(strFile);
            UnittabInformation.ChangeLanguageFile(strFile);
            ProductionTabInformation.ChangeLanguageFile(strFile);

            /* Stuff in the main form */
            gbProdtabShow.LanguageFile = strFile;
            gbUnittabShow.LanguageFile = strFile;
            chBxUnitTabShowBuildings.LanguageFile = strFile;
            chBxUnitTabShowUnits.LanguageFile = strFile;
            chBxProdTabShowBuildings.LanguageFile = strFile;
            chBxProdTabShowUnits.LanguageFile = strFile;
            chBxProdTabShowUpgrades.LanguageFile = strFile;
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

                /* Adjust drawing refreshrate */
                SetDrawingRefresh(_rApm, iDummy);
                SetDrawingRefresh(_rArmy, iDummy);
                SetDrawingRefresh(_rIncome, iDummy);
                SetDrawingRefresh(_rMaphack, iDummy);
                SetDrawingRefresh(_rProduction, iDummy);
                SetDrawingRefresh(_rResources, iDummy);
                SetDrawingRefresh(_rUnit, iDummy);
                SetDrawingRefresh(_rWorker, iDummy);

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

            tmrGatherInformation.Enabled = false;
            GInformation.HandleThread(false);

            /* Close Plugins */
            foreach (var i in _lPlugins)
                i.StopPlugin();
        }

        private void MainHandler_FormClosed(object sender, FormClosedEventArgs e)
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


            CheckPanelState(PredefinedData.RenderForm.Production);
            CheckPanelState(PredefinedData.RenderForm.Units);

            RefreshPluginData();


            #region Launch Panels

            LaunchPanels(ref _rResources, PredefinedData.RenderForm.Resources, PSettings.ResourceTogglePanel, PSettings.ResourceHotkey1, PSettings.ResourceHotkey2, PSettings.ResourceHotkey3);
            LaunchPanels(ref _rIncome, PredefinedData.RenderForm.Income, PSettings.IncomeTogglePanel, PSettings.IncomeHotkey1, PSettings.IncomeHotkey2, PSettings.IncomeHotkey3);
            LaunchPanels(ref _rWorker, PredefinedData.RenderForm.Worker, PSettings.WorkerTogglePanel, PSettings.WorkerHotkey1, PSettings.WorkerHotkey2, PSettings.WorkerHotkey3);
            LaunchPanels(ref _rMaphack, PredefinedData.RenderForm.Maphack, PSettings.MaphackTogglePanel, PSettings.MaphackHotkey1, PSettings.MaphackHotkey2, PSettings.MaphackHotkey3);
            LaunchPanels(ref _rApm, PredefinedData.RenderForm.Apm, PSettings.ApmTogglePanel, PSettings.ApmHotkey1, PSettings.ApmHotkey2, PSettings.ApmHotkey3);
            LaunchPanels(ref _rArmy, PredefinedData.RenderForm.Army, PSettings.ArmyTogglePanel, PSettings.ArmyHotkey1, PSettings.ArmyHotkey2, PSettings.ArmyHotkey3);
            LaunchPanels(ref _rUnit, PredefinedData.RenderForm.Units, PSettings.UnitTogglePanel, PSettings.UnitHotkey1, PSettings.UnitHotkey2, PSettings.UnitHotkey3);
            LaunchPanels(ref _rProduction, PredefinedData.RenderForm.Production, PSettings.ProdTogglePanel, PSettings.ProdHotkey1, PSettings.ProdHotkey2, PSettings.ProdHotkey3);

            #endregion

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


            if (_rResources != null)
            {
                if (_rResources.IsDestroyed)
                    GlobalBenchmark.lblDrawingResIterations.Text = "Resource Iterations: Unknown";
                else
                    GlobalBenchmark.lblDrawingResIterations.Text = "Resource Iterations: " +
                                                                   _rResources.IterationsPerSeconds.ToString(CultureInfo.InvariantCulture);
            }

            if (_rIncome != null)
            {
                if (_rIncome.IsDestroyed)
                    GlobalBenchmark.lblDrawingIncIterations.Text = "Income Iterations: Unknown";

                else
                    GlobalBenchmark.lblDrawingIncIterations.Text = "Income Iterations: " +
                                                                   _rIncome.IterationsPerSeconds.ToString(CultureInfo.InvariantCulture);
            }

            if (_rApm != null)
            {
                if (_rApm.IsDestroyed)
                    GlobalBenchmark.lblDrawingApmIterations.Text = "Apm Iterations: Unknown";

                else
                    GlobalBenchmark.lblDrawingApmIterations.Text = "Apm Iterations: " +
                                                                   _rApm.IterationsPerSeconds.ToString(CultureInfo.InvariantCulture);
            }

            if (_rArmy != null)
            {
                if (_rArmy.IsDestroyed)
                    GlobalBenchmark.lblDrawingArmIterations.Text = "Army Iterations: Unknown";

                else
                    GlobalBenchmark.lblDrawingArmIterations.Text = "Army Iterations: " +
                                                                   _rArmy.IterationsPerSeconds.ToString(CultureInfo.InvariantCulture);
            }

            if (_rWorker != null)
            {
                if (_rWorker.IsDestroyed)
                    GlobalBenchmark.lblDrawingWorIterations.Text = "Worker Iterations: Unknown";

                else
                    GlobalBenchmark.lblDrawingWorIterations.Text = "Worker Iterations: " +
                                                                   _rWorker.IterationsPerSeconds.ToString(CultureInfo.InvariantCulture);
            }

            if (_rMaphack != null)
            {
                if (_rMaphack.IsDestroyed)
                    GlobalBenchmark.lblDrawingMapIterations.Text = "Maphack Iterations: Unknown";

                else
                    GlobalBenchmark.lblDrawingMapIterations.Text = "Maphack Iterations: " +
                                                                   _rMaphack.IterationsPerSeconds.ToString(CultureInfo.InvariantCulture);
            }

            if (_rUnit != null)
            {
                if (_rUnit.IsDestroyed)
                    GlobalBenchmark.lblDrawingUniIterations.Text = "UnitTab Iterations: Unknown";
                else
                    GlobalBenchmark.lblDrawingUniIterations.Text = "UnitTab Iterations: " +
                                                                   _rUnit.IterationsPerSeconds.ToString(CultureInfo.InvariantCulture);
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
                if (HelpFunctions.RendererWindowAvailable(_rResources))
                    _rResources.FormBorderStyle = FormBorderStyle.None;

                if (HelpFunctions.RendererWindowAvailable(_rApm))
                    _rApm.FormBorderStyle = FormBorderStyle.None;

                if (HelpFunctions.RendererWindowAvailable(_rArmy))
                    _rArmy.FormBorderStyle = FormBorderStyle.None;

                if (HelpFunctions.RendererWindowAvailable(_rIncome))
                    _rIncome.FormBorderStyle = FormBorderStyle.None;

                if (HelpFunctions.RendererWindowAvailable(_rMaphack))
                    _rMaphack.FormBorderStyle = FormBorderStyle.None;

                if (HelpFunctions.RendererWindowAvailable(_rPersonalApm))
                    _rPersonalApm.FormBorderStyle = FormBorderStyle.None;

                if (HelpFunctions.RendererWindowAvailable(_rPersonalClock))
                    _rPersonalClock.FormBorderStyle = FormBorderStyle.None;

                if (HelpFunctions.RendererWindowAvailable(_rProduction))
                    _rProduction.FormBorderStyle = FormBorderStyle.None;

                if (HelpFunctions.RendererWindowAvailable(_rUnit))
                    _rUnit.FormBorderStyle = FormBorderStyle.None;

                if (HelpFunctions.RendererWindowAvailable(_rWorker))
                    _rWorker.FormBorderStyle = FormBorderStyle.None;
            }

            else
            {
                _bProofClickable = 0;

                if (HelpFunctions.RendererWindowAvailable(_rResources))
                    _rResources.FormBorderStyle = FormBorderStyle.SizableToolWindow;

                if (HelpFunctions.RendererWindowAvailable(_rApm))
                    _rApm.FormBorderStyle = FormBorderStyle.SizableToolWindow;

                if (HelpFunctions.RendererWindowAvailable(_rArmy))
                    _rArmy.FormBorderStyle = FormBorderStyle.SizableToolWindow;

                if (HelpFunctions.RendererWindowAvailable(_rIncome))
                    _rIncome.FormBorderStyle = FormBorderStyle.SizableToolWindow;

                if (HelpFunctions.RendererWindowAvailable(_rMaphack))
                    _rMaphack.FormBorderStyle = FormBorderStyle.SizableToolWindow;

                if (HelpFunctions.RendererWindowAvailable(_rPersonalApm))
                    _rPersonalApm.FormBorderStyle = FormBorderStyle.SizableToolWindow;

                if (HelpFunctions.RendererWindowAvailable(_rPersonalClock))
                    _rPersonalClock.FormBorderStyle = FormBorderStyle.SizableToolWindow;

                if (HelpFunctions.RendererWindowAvailable(_rProduction))
                    _rProduction.FormBorderStyle = FormBorderStyle.SizableToolWindow;

                if (HelpFunctions.RendererWindowAvailable(_rUnit))
                    _rUnit.FormBorderStyle = FormBorderStyle.SizableToolWindow;

                if (HelpFunctions.RendererWindowAvailable(_rWorker))
                    _rWorker.FormBorderStyle = FormBorderStyle.SizableToolWindow;
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
            HandleButtonClicks(ref _rPersonalApm, PredefinedData.RenderForm.PersonalApm);
        }

        private void chBxVarPersonalClock_CheckedChanged(object sender, EventArgs e)
        {
            PSettings.PersonalClock = Custom_Various.chBxClock.Checked;
            HandleButtonClicks(ref _rPersonalClock, PredefinedData.RenderForm.PersonalClock);
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
