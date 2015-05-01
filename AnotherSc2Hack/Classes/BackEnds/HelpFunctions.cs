using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using System.Windows.Forms;
using AnotherSc2Hack.Classes.BackEnds;
using AnotherSc2Hack.Classes.DataStructures.Preference;
using AnotherSc2Hack.Classes.FrontEnds;
using AnotherSc2Hack.Classes.FrontEnds.Custom_Controls;
using PredefinedTypes = Predefined.PredefinedData;

namespace AnotherSc2Hack
{
    class HelpFunctions
    {
        public static void CheckIfDwmIsEnabled()
        {
            if (Environment.OSVersion.Version.Major >= 6 &&
                InteropCalls.DwmIsCompositionEnabled())
            {
                //Do nothing
            }

            else if (Environment.OSVersion.Version.Major >= 6 &&
                     !InteropCalls.DwmIsCompositionEnabled())
            {
                MessageBox.Show("It seems like you have DWM (Desktop Window Manager)\n" +
                                "disabled. It's highly recommended to enable the DWM.\n" +
                                "To enable the DWM, see this tools thread or visit\n" +
                                "the Microsoft support website.", "Desktop Window Manager (DWM)");
            }
        }

        public static void CheckIfWindowStyleIsFullscreen(PredefinedTypes.WindowStyle w)
        {
            if (w.Equals(PredefinedTypes.WindowStyle.Fullscreen))
                MessageBox.Show("Your windowstyle seems to be \"Fullscreen\".\n" +
                                "If you want to use this tool, change the\n" +
                                "Windowstyle to \"Windowed\" or \"Windowed Fullscreen\"\n" +
                                "to have the best experience!", "Windowstyle");
        }

        public static Boolean HotkeysPressed(params Keys[] keys)
        {
            Boolean blResult = true;

            for (var i = 0; i < keys.Length; i++)
            {
                blResult = blResult && InteropCalls.GetAsyncKeyState(keys[i]) <= -32767;
            }

            return blResult;
        }

        public static Int32 GetValidPlayerCount(List<PredefinedTypes.PlayerStruct> lPlayer)
        {
            var iValidSize = 0;

            if (lPlayer == null ||
                lPlayer.Count <= 0)
                return 0;

            for (var i = 0; i < lPlayer.Count; i++)
            {
                if (!lPlayer[i].Name.StartsWith("\0") && !(lPlayer[i].NameLength <= 0) && !lPlayer[i].Type.Equals(PredefinedTypes.PlayerType.Hostile))
                    iValidSize += 1;
            }

            return iValidSize;
        }

        public static void SetWindowStyle(IntPtr handle, PredefinedTypes.CustomWindowStyles wndStyle)
        {
            if (wndStyle.Equals(PredefinedTypes.CustomWindowStyles.Clickable))
            {
                var initial = InteropCalls.GetWindowLong(handle, (Int32)InteropCalls.Gwl.ExStyle);
                InteropCalls.SetWindowLong(handle, (Int32)InteropCalls.Gwl.ExStyle,
                                            (IntPtr)(initial & ~(Int32)InteropCalls.Ws.ExTransparent));
            }

            else if (wndStyle.Equals(PredefinedTypes.CustomWindowStyles.NotClickable))
            {
                var initial = InteropCalls.GetWindowLong(handle, (Int32)InteropCalls.Gwl.ExStyle);
                InteropCalls.SetWindowLong(handle, (Int32)InteropCalls.Gwl.ExStyle,
                                            (IntPtr)(initial | (Int32)InteropCalls.Ws.ExTransparent));
            }
        }

        public static string GetParent(Control control)
        {
            var strName = String.Empty;

            if (control.Parent != null)
                strName = GetParent(control.Parent) + Constants.ChrLanguageControlSplitSign;

            return strName + control.Name;
        }

        public static void GetParentNames(Control currentControl, ref List<string> names)
        {
            if (currentControl.Parent != null)
            {
                GetParentNames(currentControl.Parent, ref names);
                names.Add(currentControl.Name);
            }
        }

        public static bool CheckParents(Control currentControl, int index, ref string[] controlNames)
        {
            var bResult = currentControl.Name == controlNames[controlNames.Length - index - 1];

            if (!bResult)
                return false;

            if (currentControl.Parent != null && controlNames.Length < index + 1)
                CheckParents(currentControl.Parent, ++index, ref controlNames);

            return true;
        }

        public static string SetWindowTitle()
        {
            var rnd = new Random();

            var iNum = rnd.Next(0xFFF, 0xFFFFFFF);
            

            return iNum.ToString();
        }

        public static long SizeOf(object obj)
        {
            long size = 0;

            try
            {
                var stream = new MemoryStream();
                var objFormatter = new BinaryFormatter();
                objFormatter.Serialize(stream, obj);
                size = stream.Length;
            }
            catch
            {
            }

            return size;
        }

        public static void InitResolution(ref PreferenceManager pSettings)
        {
            Int32 iWidth = Screen.PrimaryScreen.Bounds.Width,
                  iHeidth = Screen.PrimaryScreen.Bounds.Height;

            #region 1920x1080

            if (iWidth >= 1920 - 10 && iWidth < 1920 + 10 &&
                iHeidth >= 1080 - 10 && iHeidth < 1080 + 10)
            {
                pSettings.PreferenceAll.OverlayResources.X = 1312;
                pSettings.PreferenceAll.OverlayResources.Y = 44;
                pSettings.PreferenceAll.OverlayResources.Width = 550;
                pSettings.PreferenceAll.OverlayResources.Height = 40;

                pSettings.PreferenceAll.OverlayIncome.X = 1312;
                pSettings.PreferenceAll.OverlayIncome.Y = 328;
                pSettings.PreferenceAll.OverlayIncome.Width = 550;
                pSettings.PreferenceAll.OverlayIncome.Height = 40;

                pSettings.PreferenceAll.OverlayApm.X = 5;
                pSettings.PreferenceAll.OverlayApm.Y = 64;
                pSettings.PreferenceAll.OverlayApm.Width = 550;
                pSettings.PreferenceAll.OverlayApm.Height = 40;

                pSettings.PreferenceAll.OverlayArmy.X = 1312;
                pSettings.PreferenceAll.OverlayArmy.Y = 629;
                pSettings.PreferenceAll.OverlayArmy.Width = 550;
                pSettings.PreferenceAll.OverlayArmy.Height = 40;

                pSettings.PreferenceAll.OverlayWorker.X = 1319;
                pSettings.PreferenceAll.OverlayWorker.Y = 826;
                pSettings.PreferenceAll.OverlayWorker.Width = 150;
                pSettings.PreferenceAll.OverlayWorker.Height = 40;

                pSettings.PreferenceAll.OverlayMaphack.X = 28;
                pSettings.PreferenceAll.OverlayMaphack.Y = 808;
                pSettings.PreferenceAll.OverlayMaphack.Width = 262;
                pSettings.PreferenceAll.OverlayMaphack.Height = 258;

                pSettings.PreferenceAll.OverlayUnits.X = 5;
                pSettings.PreferenceAll.OverlayUnits.Y = 364;

                pSettings.PreferenceAll.OverlayProduction.X = 5;
                pSettings.PreferenceAll.OverlayProduction.Y = 200;
            }

            #endregion

            #region 1680x1050

            else if (iWidth >= 1680 - 10 && iWidth < 1680 + 10 &&
                     iHeidth >= 1050 - 10 && iHeidth < 1050 + 10)
            {
                pSettings.PreferenceAll.OverlayResources.X = 1144;
                pSettings.PreferenceAll.OverlayResources.Y = 72;
                pSettings.PreferenceAll.OverlayResources.Width = 501;
                pSettings.PreferenceAll.OverlayResources.Height = 36;

                pSettings.PreferenceAll.OverlayIncome.X = 1144;
                pSettings.PreferenceAll.OverlayIncome.Y = 279;
                pSettings.PreferenceAll.OverlayIncome.Width = 501;
                pSettings.PreferenceAll.OverlayIncome.Height = 36;

                pSettings.PreferenceAll.OverlayApm.X = 7;
                pSettings.PreferenceAll.OverlayApm.Y = 70;
                pSettings.PreferenceAll.OverlayApm.Width = 515;
                pSettings.PreferenceAll.OverlayApm.Height = 36;

                pSettings.PreferenceAll.OverlayArmy.X = 1144;
                pSettings.PreferenceAll.OverlayArmy.Y = 288;
                pSettings.PreferenceAll.OverlayArmy.Width = 501;
                pSettings.PreferenceAll.OverlayArmy.Height = 36;

                pSettings.PreferenceAll.OverlayWorker.X = 1031;
                pSettings.PreferenceAll.OverlayWorker.Y = 859;
                pSettings.PreferenceAll.OverlayWorker.Width = 103;
                pSettings.PreferenceAll.OverlayWorker.Height = 30;

                pSettings.PreferenceAll.OverlayMaphack.X = 26;
                pSettings.PreferenceAll.OverlayMaphack.Y = 787;
                pSettings.PreferenceAll.OverlayMaphack.Width = 254;
                pSettings.PreferenceAll.OverlayMaphack.Height = 250;

                pSettings.PreferenceAll.OverlayUnits.X = 5;
                pSettings.PreferenceAll.OverlayUnits.Y = 364;

                pSettings.PreferenceAll.OverlayProduction.X = 5;
                pSettings.PreferenceAll.OverlayProduction.Y = 200;
            }

            #endregion

            #region 1600x900

            else if (iWidth >= 1600 - 10 && iWidth < 1600 + 10 &&
                     iHeidth >= 900 - 10 && iHeidth < 900 + 10)
            {
                pSettings.PreferenceAll.OverlayResources.X = 1146;
                pSettings.PreferenceAll.OverlayResources.Y = 61;
                pSettings.PreferenceAll.OverlayResources.Width = 419;
                pSettings.PreferenceAll.OverlayResources.Height = 30;

                pSettings.PreferenceAll.OverlayIncome.X = 1146;
                pSettings.PreferenceAll.OverlayIncome.Y = 171;
                pSettings.PreferenceAll.OverlayIncome.Width = 419;
                pSettings.PreferenceAll.OverlayIncome.Height = 30;

                pSettings.PreferenceAll.OverlayApm.X = 3;
                pSettings.PreferenceAll.OverlayApm.Y = 67;
                pSettings.PreferenceAll.OverlayApm.Width = 405;
                pSettings.PreferenceAll.OverlayApm.Height = 29;

                pSettings.PreferenceAll.OverlayArmy.X = 1146;
                pSettings.PreferenceAll.OverlayArmy.Y = 288;
                pSettings.PreferenceAll.OverlayArmy.Width = 419;
                pSettings.PreferenceAll.OverlayArmy.Height = 30;

                pSettings.PreferenceAll.OverlayWorker.X = 1033;
                pSettings.PreferenceAll.OverlayWorker.Y = 732;
                pSettings.PreferenceAll.OverlayWorker.Width = 103;
                pSettings.PreferenceAll.OverlayWorker.Height = 30;

                pSettings.PreferenceAll.OverlayMaphack.X = 24;
                pSettings.PreferenceAll.OverlayMaphack.Y = 674;
                pSettings.PreferenceAll.OverlayMaphack.Width = 218;
                pSettings.PreferenceAll.OverlayMaphack.Height = 214;

                pSettings.PreferenceAll.OverlayUnits.X = 5;
                pSettings.PreferenceAll.OverlayUnits.Y = 364;

                pSettings.PreferenceAll.OverlayProduction.X = 5;
                pSettings.PreferenceAll.OverlayProduction.Y = 200;
            }

            #endregion

            #region 1440x900

            else if (iWidth >= 1440 - 10 && iWidth < 1440 + 10 &&
                     iHeidth >= 900 - 10 && iHeidth < 900 + 10)
            {
                pSettings.PreferenceAll.OverlayResources.X = 985;
                pSettings.PreferenceAll.OverlayResources.Y = 62;
                pSettings.PreferenceAll.OverlayResources.Width = 419;
                pSettings.PreferenceAll.OverlayResources.Height = 30;

                pSettings.PreferenceAll.OverlayIncome.X = 985;
                pSettings.PreferenceAll.OverlayIncome.Y = 128;
                pSettings.PreferenceAll.OverlayIncome.Width = 419;
                pSettings.PreferenceAll.OverlayIncome.Height = 30;

                pSettings.PreferenceAll.OverlayApm.X = 3;
                pSettings.PreferenceAll.OverlayApm.Y = 80;
                pSettings.PreferenceAll.OverlayApm.Width = 419;
                pSettings.PreferenceAll.OverlayApm.Height = 30;

                pSettings.PreferenceAll.OverlayArmy.X = 985;
                pSettings.PreferenceAll.OverlayArmy.Y = 198;
                pSettings.PreferenceAll.OverlayArmy.Width = 419;
                pSettings.PreferenceAll.OverlayArmy.Height = 30;

                pSettings.PreferenceAll.OverlayWorker.X = 874;
                pSettings.PreferenceAll.OverlayWorker.Y = 732;
                pSettings.PreferenceAll.OverlayWorker.Width = 103;
                pSettings.PreferenceAll.OverlayWorker.Height = 30;

                pSettings.PreferenceAll.OverlayMaphack.X = 24;
                pSettings.PreferenceAll.OverlayMaphack.Y = 674;
                pSettings.PreferenceAll.OverlayMaphack.Width = 218;
                pSettings.PreferenceAll.OverlayMaphack.Height = 214;

                pSettings.PreferenceAll.OverlayUnits.X = 5;
                pSettings.PreferenceAll.OverlayUnits.Y = 364;

                pSettings.PreferenceAll.OverlayProduction.X = 5;
                pSettings.PreferenceAll.OverlayProduction.Y = 200;
            }

            #endregion

            #region 1400x1050

            else if (iWidth >= 1400 - 10 && iWidth < 1400 + 10 &&
                     iHeidth >= 1050 - 10 && iHeidth < 1050 + 10)
            {
                pSettings.PreferenceAll.OverlayResources.X = 878;
                pSettings.PreferenceAll.OverlayResources.Y = 73;
                pSettings.PreferenceAll.OverlayResources.Width = 474;
                pSettings.PreferenceAll.OverlayResources.Height = 34;

                pSettings.PreferenceAll.OverlayIncome.X = 878;
                pSettings.PreferenceAll.OverlayIncome.Y = 162;
                pSettings.PreferenceAll.OverlayIncome.Width = 474;
                pSettings.PreferenceAll.OverlayIncome.Height = 34;

                pSettings.PreferenceAll.OverlayApm.X = 12;
                pSettings.PreferenceAll.OverlayApm.Y = 77;
                pSettings.PreferenceAll.OverlayApm.Width = 474;
                pSettings.PreferenceAll.OverlayApm.Height = 34;

                pSettings.PreferenceAll.OverlayArmy.X = 878;
                pSettings.PreferenceAll.OverlayArmy.Y = 261;
                pSettings.PreferenceAll.OverlayArmy.Width = 474;
                pSettings.PreferenceAll.OverlayArmy.Height = 34;

                pSettings.PreferenceAll.OverlayWorker.X = 722;
                pSettings.PreferenceAll.OverlayWorker.Y = 858;
                pSettings.PreferenceAll.OverlayWorker.Width = 137;
                pSettings.PreferenceAll.OverlayWorker.Height = 40;

                pSettings.PreferenceAll.OverlayMaphack.X = 27;
                pSettings.PreferenceAll.OverlayMaphack.Y = 787;
                pSettings.PreferenceAll.OverlayMaphack.Width = 252;
                pSettings.PreferenceAll.OverlayMaphack.Height = 248;

                pSettings.PreferenceAll.OverlayUnits.X = 5;
                pSettings.PreferenceAll.OverlayUnits.Y = 364;

                pSettings.PreferenceAll.OverlayProduction.X = 5;
                pSettings.PreferenceAll.OverlayProduction.Y = 200;
            }

            #endregion

            #region 1366x768

            else if (iWidth >= 1366 - 10 && iWidth < 1366 + 10 &&
                     iHeidth >= 768 - 10 && iHeidth < 768 + 10)
            {
                pSettings.PreferenceAll.OverlayResources.X = 970;
                pSettings.PreferenceAll.OverlayResources.Y = 52;
                pSettings.PreferenceAll.OverlayResources.Width = 378;
                pSettings.PreferenceAll.OverlayResources.Height = 27;

                pSettings.PreferenceAll.OverlayIncome.X = 970;
                pSettings.PreferenceAll.OverlayIncome.Y = 52;
                pSettings.PreferenceAll.OverlayIncome.Width = 378;
                pSettings.PreferenceAll.OverlayIncome.Height = 27;

                pSettings.PreferenceAll.OverlayApm.X = 2;
                pSettings.PreferenceAll.OverlayApm.Y = 73;
                pSettings.PreferenceAll.OverlayApm.Width = 378;
                pSettings.PreferenceAll.OverlayApm.Height = 27;

                pSettings.PreferenceAll.OverlayArmy.X = 970;
                pSettings.PreferenceAll.OverlayArmy.Y = 163;
                pSettings.PreferenceAll.OverlayArmy.Width = 378;
                pSettings.PreferenceAll.OverlayArmy.Height = 277;

                pSettings.PreferenceAll.OverlayWorker.X = 868;
                pSettings.PreferenceAll.OverlayWorker.Y = 627;
                pSettings.PreferenceAll.OverlayWorker.Width = 103;
                pSettings.PreferenceAll.OverlayWorker.Height = 30;

                pSettings.PreferenceAll.OverlayMaphack.X = 26;
                pSettings.PreferenceAll.OverlayMaphack.Y = 574;
                pSettings.PreferenceAll.OverlayMaphack.Width = 187;
                pSettings.PreferenceAll.OverlayMaphack.Height = 183;

                pSettings.PreferenceAll.OverlayUnits.X = 5;
                pSettings.PreferenceAll.OverlayUnits.Y = 364;

                pSettings.PreferenceAll.OverlayProduction.X = 5;
                pSettings.PreferenceAll.OverlayProduction.Y = 200;
            }

            #endregion

            #region 1360x1024

            else if (iWidth >= 1360 - 10 && iWidth < 1360 + 10 &&
                     iHeidth >= 1024 - 10 && iHeidth < 1024 + 10)
            {
                pSettings.PreferenceAll.OverlayResources.X = 848;
                pSettings.PreferenceAll.OverlayResources.Y = 70;
                pSettings.PreferenceAll.OverlayResources.Width = 474;
                pSettings.PreferenceAll.OverlayResources.Height = 35;

                pSettings.PreferenceAll.OverlayIncome.X = 848;
                pSettings.PreferenceAll.OverlayIncome.Y = 160;
                pSettings.PreferenceAll.OverlayIncome.Width = 474;
                pSettings.PreferenceAll.OverlayIncome.Height = 35;

                pSettings.PreferenceAll.OverlayApm.X = 1;
                pSettings.PreferenceAll.OverlayApm.Y = 85;
                pSettings.PreferenceAll.OverlayApm.Width = 474;
                pSettings.PreferenceAll.OverlayApm.Height = 35;

                pSettings.PreferenceAll.OverlayArmy.X = 848;
                pSettings.PreferenceAll.OverlayArmy.Y = 247;
                pSettings.PreferenceAll.OverlayArmy.Width = 474;
                pSettings.PreferenceAll.OverlayArmy.Height = 35;

                pSettings.PreferenceAll.OverlayWorker.X = 701;
                pSettings.PreferenceAll.OverlayWorker.Y = 835;
                pSettings.PreferenceAll.OverlayWorker.Width = 137;
                pSettings.PreferenceAll.OverlayWorker.Height = 40;

                pSettings.PreferenceAll.OverlayMaphack.X = 25;
                pSettings.PreferenceAll.OverlayMaphack.Y = 766;
                pSettings.PreferenceAll.OverlayMaphack.Width = 249;
                pSettings.PreferenceAll.OverlayMaphack.Height = 244;

                pSettings.PreferenceAll.OverlayUnits.X = 5;
                pSettings.PreferenceAll.OverlayUnits.Y = 364;

                pSettings.PreferenceAll.OverlayProduction.X = 5;
                pSettings.PreferenceAll.OverlayProduction.Y = 200;
            }

            #endregion

            #region 1280x720

            else if (iWidth >= 1280 - 10 && iWidth < 1280 + 10 &&
                     iHeidth >= 720 - 10 && iHeidth < 720 + 10)
            {
                pSettings.PreferenceAll.OverlayResources.X = 906;
                pSettings.PreferenceAll.OverlayResources.Y = 46;
                pSettings.PreferenceAll.OverlayResources.Width = 364;
                pSettings.PreferenceAll.OverlayResources.Height = 26;

                pSettings.PreferenceAll.OverlayIncome.X = 906;
                pSettings.PreferenceAll.OverlayIncome.Y = 107;
                pSettings.PreferenceAll.OverlayIncome.Width = 364;
                pSettings.PreferenceAll.OverlayIncome.Height = 26;

                pSettings.PreferenceAll.OverlayApm.X = 9;
                pSettings.PreferenceAll.OverlayApm.Y = 127;
                pSettings.PreferenceAll.OverlayApm.Width = 364;
                pSettings.PreferenceAll.OverlayApm.Height = 26;

                pSettings.PreferenceAll.OverlayArmy.X = 906;
                pSettings.PreferenceAll.OverlayArmy.Y = 170;
                pSettings.PreferenceAll.OverlayArmy.Width = 364;
                pSettings.PreferenceAll.OverlayArmy.Height = 26;

                pSettings.PreferenceAll.OverlayWorker.X = 806;
                pSettings.PreferenceAll.OverlayWorker.Y = 586;
                pSettings.PreferenceAll.OverlayWorker.Width = 103;
                pSettings.PreferenceAll.OverlayWorker.Height = 30;

                pSettings.PreferenceAll.OverlayMaphack.X = 17;
                pSettings.PreferenceAll.OverlayMaphack.Y = 540;
                pSettings.PreferenceAll.OverlayMaphack.Width = 178;
                pSettings.PreferenceAll.OverlayMaphack.Height = 177;

                pSettings.PreferenceAll.OverlayUnits.X = 5;
                pSettings.PreferenceAll.OverlayUnits.Y = 364;

                pSettings.PreferenceAll.OverlayProduction.X = 5;
                pSettings.PreferenceAll.OverlayProduction.Y = 200;
            }

            #endregion

            #region Any other resolution

            else
            {
                var result = MessageBox.Show("Your reoslution is not supported!\nDo you wish to change all positions to X=0 and Y=0?", "Resolution not supported!", MessageBoxButtons.YesNo);

                if (result.Equals(DialogResult.Yes))
                {
                    pSettings.PreferenceAll.OverlayResources.X = 0;
                    pSettings.PreferenceAll.OverlayResources.Y = 0;

                    pSettings.PreferenceAll.OverlayIncome.X = 0;
                    pSettings.PreferenceAll.OverlayIncome.Y = 0;

                    pSettings.PreferenceAll.OverlayApm.X = 0;
                    pSettings.PreferenceAll.OverlayApm.Y = 0;

                    pSettings.PreferenceAll.OverlayArmy.X = 0;
                    pSettings.PreferenceAll.OverlayArmy.Y = 0;

                    pSettings.PreferenceAll.OverlayWorker.X = 0;
                    pSettings.PreferenceAll.OverlayWorker.Y = 0;

                    pSettings.PreferenceAll.OverlayMaphack.X = 0;
                    pSettings.PreferenceAll.OverlayMaphack.Y = 0;

                    pSettings.PreferenceAll.OverlayUnits.X = 0;
                    pSettings.PreferenceAll.OverlayUnits.Y = 0;

                    pSettings.PreferenceAll.OverlayProduction.X = 0;
                    pSettings.PreferenceAll.OverlayProduction.Y = 0;
                }


            }

            #endregion

            new AnotherMessageBox().Show("Panel's size and position\n" +
                            "were adjusted successfully!\n\n" + 
            "Please reload the panels!", "Panelposition changed!");
        }

        public static Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }

        public static byte[] imageToByteArray(Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            return ms.ToArray();
        }


        public static void RemoveNonDigits(TextBox txtBox)
        {
            if (txtBox.Text.Length <= 0)
                return;
            
            if (txtBox.Text.StartsWith("\0"))
                return;

            for (var i = 0; i < txtBox.Text.Length; i++)
            {
                if (char.IsDigit(txtBox.Text[i]))
                    continue;

                txtBox.Text = txtBox.Text.Remove(i, 1);
                txtBox.Select(i, 0);
            }
        }

        /* As the actual max- health of units is lost, I map them manually.. */
        public static Int32 GetMaximumHealth(PredefinedTypes.UnitId id)
        {
            switch (id)
            {
                case PredefinedTypes.UnitId.PbAssimilator:
                    return 450;

                case PredefinedTypes.UnitId.PbCannon:
                    return 150;

                case PredefinedTypes.UnitId.PbCybercore:
                    return 550;

                case PredefinedTypes.UnitId.PbDarkshrine:
                    return 500;

                case PredefinedTypes.UnitId.PbFleetbeacon:
                    return 500;

                case PredefinedTypes.UnitId.PbForge:
                    return 400;

                case PredefinedTypes.UnitId.PbGateway:
                    return 500;

                case PredefinedTypes.UnitId.PbNexus:
                    return 1000;

                case PredefinedTypes.UnitId.PbPylon:
                    return 200;

                case PredefinedTypes.UnitId.PbRoboticsbay:
                    return 450;

                case PredefinedTypes.UnitId.PbRoboticssupportbay:
                    return 500;

                case PredefinedTypes.UnitId.PbStargate:
                    return 600;

                case PredefinedTypes.UnitId.PbTemplararchives:
                    return 500;

                case PredefinedTypes.UnitId.PbTwilightcouncil:
                    return 500;

                case PredefinedTypes.UnitId.PbWarpgate:
                    return 500;



                case PredefinedTypes.UnitId.TbArmory:
                    return 750;

                case PredefinedTypes.UnitId.TbAutoTurret:
                    return 150;

                case PredefinedTypes.UnitId.TbBarracksGround:
                    return 1000;

                case PredefinedTypes.UnitId.TbBunker:
                    return 400;

                case PredefinedTypes.UnitId.TbCcAir:
                    return 1500;

                case PredefinedTypes.UnitId.TbCcGround:
                    return 1500;

                case PredefinedTypes.UnitId.TbEbay:
                    return 850;

                case PredefinedTypes.UnitId.TbFactoryAir:
                    return 1250;

                case PredefinedTypes.UnitId.TbFactoryGround:
                    return 1250;

                case PredefinedTypes.UnitId.TbFusioncore:
                    return 750;

                case PredefinedTypes.UnitId.TbGhostacademy:
                    return 1250;

                case PredefinedTypes.UnitId.TbOrbitalAir:
                    return 1500;

                case PredefinedTypes.UnitId.TbOrbitalGround:
                    return 1500;

                case PredefinedTypes.UnitId.TbPlanetary:
                    return 1500;

                case PredefinedTypes.UnitId.TbRaxAir:
                    return 1000;

                case PredefinedTypes.UnitId.TbReactor:
                    return 400;

                case PredefinedTypes.UnitId.TbReactorFactory:
                    return 400;

                case PredefinedTypes.UnitId.TbReactorRax:
                    return 400;

                case PredefinedTypes.UnitId.TbReactorStarport:
                    return 400;

                case PredefinedTypes.UnitId.TbRefinery:
                    return 500;

                case PredefinedTypes.UnitId.TbSensortower:
                    return 200;

                case PredefinedTypes.UnitId.TbStarportAir:
                    return 1300;

                case PredefinedTypes.UnitId.TbStarportGround:
                    return 1300;

                case PredefinedTypes.UnitId.TbSupplyGround:
                    return 400;

                case PredefinedTypes.UnitId.TbSupplyHidden:
                    return 400;

                case PredefinedTypes.UnitId.TbTechlab:
                    return 400;

                case PredefinedTypes.UnitId.TbTechlabFactory:
                    return 400;

                case PredefinedTypes.UnitId.TbTechlabRax:
                    return 400;

                case PredefinedTypes.UnitId.TbTechlabStarport:
                    return 400;

                case PredefinedTypes.UnitId.TbTurret:
                    return 250;


                case PredefinedTypes.UnitId.ZbBanelingNest:
                    return 850;

                case PredefinedTypes.UnitId.ZbCreeptumor:
                    return 50;

                case PredefinedTypes.UnitId.ZbCreepTumorBuilding:
                    return 50;

                case PredefinedTypes.UnitId.ZbCreepTumorMissle:
                    return 50;

                case PredefinedTypes.UnitId.ZbCreeptumorBurrowed:
                    return 50;

                case PredefinedTypes.UnitId.ZbEvolutionChamber:
                    return 750;

                case PredefinedTypes.UnitId.ZbExtractor:
                    return 500;

                case PredefinedTypes.UnitId.ZbGreaterspire:
                    return 1000;

                case PredefinedTypes.UnitId.ZbHatchery:
                    return 1500;

                case PredefinedTypes.UnitId.ZbHive:
                    return 2500;

                case PredefinedTypes.UnitId.ZbHydraDen:
                    return 850;

                case PredefinedTypes.UnitId.ZbInfestationPit:
                    return 850;

                case PredefinedTypes.UnitId.ZbLiar:
                    return 2000;

                case PredefinedTypes.UnitId.ZbNydusNetwork:
                    return 850;

                case PredefinedTypes.UnitId.ZbNydusWorm:
                    return 200;

                case PredefinedTypes.UnitId.ZbRoachWarren:
                    return 850;

                case PredefinedTypes.UnitId.ZbSpawningPool:
                    return 1000;

                case PredefinedTypes.UnitId.ZbSpineCrawler:
                    return 300;

                case PredefinedTypes.UnitId.ZbSpire:
                    return 850;

                case PredefinedTypes.UnitId.ZbSporeCrawler:
                    return 400;

                case PredefinedTypes.UnitId.ZbUltraCavern:
                    return 850;

                default:
                    return 0;
            }
        }

        public class HelpGraphics
        {


            public static void DrawRoundRect(Graphics g,
       Rectangle r, int d, Pen p)
            {

                var gp =
                        new GraphicsPath();

                gp.AddArc(r.X, r.Y, d, d, 180, 90);
                gp.AddArc(r.X + r.Width - d, r.Y, d, d, 270, 90);
                gp.AddArc(r.X + r.Width - d, r.Y + r.Height - d, d, d, 0, 90);
                gp.AddArc(r.X, r.Y + r.Height - d, d, d, 90, 90);
                gp.AddLine(r.X, r.Y + r.Height - d, r.X, r.Y + d / 2);

                g.DrawPath(p, gp);
            }

            public static void DrawRoundRect(Graphics g, Pen p, float x, float y, float width, float height, float radius)
            {
                g.CompositingQuality = CompositingQuality.HighQuality;
                g.SmoothingMode = SmoothingMode.HighQuality;
                g.PixelOffsetMode = PixelOffsetMode.HighQuality; 
                var gp = new GraphicsPath();

                gp.AddLine(x + radius, y, x + width - (radius * 2), y); // Line
                gp.AddArc(x + width - (radius * 2), y, radius * 2, radius * 2, 270, 90); // Corner
                gp.AddLine(x + width, y + radius, x + width, y + height - (radius * 2)); // Line
                gp.AddArc(x + width - (radius * 2), y + height - (radius * 2), radius * 2, radius * 2, 0, 90); // Corner
                gp.AddLine(x + width - (radius * 2), y + height, x + radius, y + height); // Line
                gp.AddArc(x, y + height - (radius * 2), radius * 2, radius * 2, 90, 90); // Corner
                gp.AddLine(x, y + height - (radius * 2), x, y + radius); // Line
                gp.AddArc(x, y, radius * 2, radius * 2, 180, 90); // Corner
                gp.CloseFigure();

                g.DrawPath(p, gp);
                gp.Dispose();

                g.CompositingQuality = CompositingQuality.HighSpeed;
                g.SmoothingMode = SmoothingMode.HighSpeed;
                g.PixelOffsetMode = PixelOffsetMode.HighSpeed; 
            }

            /// The following is from Arun Reginald Zaheeruddin
            /// The article about rounded rectangles can be found here:
            /// http://www.codeproject.com/Articles/5649/Extended-Graphics-An-implementation-of-Rounded-Rec
            /// 
            /// All credits go to him and/ or his article!
            public static void FillRoundRectangle(Graphics g, Brush brush,
 float x, float y,
 float width, float height, float radius)
            {
                var oldQuality = g.SmoothingMode;

                g.SmoothingMode = SmoothingMode.HighQuality;
                var rectangle = new RectangleF(x, y, width, height);
                var path = GetRoundedRect(rectangle, radius);
                g.FillPath(brush, path);
                g.SmoothingMode = oldQuality;
            }

            private static GraphicsPath GetRoundedRect(RectangleF baseRect,
               float radius)
            {
                // if corner radius is less than or equal to zero, 
                // return the original rectangle 
                if (radius <= 0.0F)
                {
                    var mPath = new GraphicsPath();
                    mPath.AddRectangle(baseRect);
                    mPath.CloseFigure();
                    return mPath;
                }

                // if the corner radius is greater than or equal to 
                // half the width, or height (whichever is shorter) 
                // then return a capsule instead of a lozenge 
                if (radius >= (Math.Min(baseRect.Width, baseRect.Height)) / 2.0)
                    return GetCapsule(baseRect);

                // create the arc for the rectangle sides and declare 
                // a graphics path object for the drawing 
                var diameter = radius * 2.0F;
                var sizeF = new SizeF(diameter, diameter);
                var arc = new RectangleF(baseRect.Location, sizeF);
                var path = new GraphicsPath();

                // top left arc 
                path.AddArc(arc, 180, 90);

                // top right arc 
                arc.X = baseRect.Right - diameter;
                path.AddArc(arc, 270, 90);

                // bottom right arc 
                arc.Y = baseRect.Bottom - diameter;
                path.AddArc(arc, 0, 90);

                // bottom left arc
                arc.X = baseRect.Left;
                path.AddArc(arc, 90, 90);

                path.CloseFigure();
                return path;
            }
            private static GraphicsPath GetCapsule(RectangleF baseRect)
            {
                var path = new GraphicsPath();
                try
                {
                    float diameter;
                    RectangleF arc;
                    if (baseRect.Width > baseRect.Height)
                    {
                        // return horizontal capsule 
                        diameter = baseRect.Height;
                        var sizeF = new SizeF(diameter, diameter);
                        arc = new RectangleF(baseRect.Location, sizeF);
                        path.AddArc(arc, 90, 180);
                        arc.X = baseRect.Right - diameter;
                        path.AddArc(arc, 270, 180);
                    }
                    else if (baseRect.Width < baseRect.Height)
                    {
                        // return vertical capsule 
                        diameter = baseRect.Width;
                        var sizeF = new SizeF(diameter, diameter);
                        arc = new RectangleF(baseRect.Location, sizeF);
                        path.AddArc(arc, 180, 180);
                        arc.Y = baseRect.Bottom - diameter;
                        path.AddArc(arc, 0, 180);
                    }
                    else
                    {
                        // return circle 
                        path.AddEllipse(baseRect);
                    }
                }
                catch
                {
                    path.AddEllipse(baseRect);
                }

                finally
                {
                    path.CloseFigure();
                }


                return path;
            } 

            
        }

        public static PredefinedTypes.UnitId GetUnitIdFromLogicalId(PredefinedTypes.UnitId structureBuildFrom, Int32 logicalId, Int32 maximumTime, Int32 mineralCost, Int32 vespineCost)
        {
            if (logicalId.Equals(0))
                return PredefinedTypes.UnitId.NbXelNagaTower;

            if (!logicalId.Equals(-1))
            {

                var strStuff = Convert.ToString(logicalId, 16);
                strStuff = "1" + strStuff.Substring(1);

                var inumber = int.Parse(strStuff, NumberStyles.HexNumber);

                logicalId = inumber;
            }

            #region Terran 

            #region CC - Orbital - PF

            if (structureBuildFrom.Equals(PredefinedTypes.UnitId.TbCcGround))
            {
                //E.G. Upgrade to Lair/ Hive
                if (logicalId == -1)
                {
                    if (mineralCost == 150 && vespineCost == 0)
                        return PredefinedTypes.UnitId.TupUpgradeToOrbital;

                    if (mineralCost == 150 && vespineCost == 150)
                        return PredefinedTypes.UnitId.TupUpgradeToPlanetary;
                }

                return PredefinedTypes.UnitId.TuScv;
            }

            if (structureBuildFrom.Equals(PredefinedTypes.UnitId.TbPlanetary))
                return PredefinedTypes.UnitId.TuScv;

            if (structureBuildFrom.Equals(PredefinedTypes.UnitId.TbOrbitalGround))
                return PredefinedTypes.UnitId.TuScv;

            #endregion

            #region Barracks

            if (structureBuildFrom.Equals(PredefinedTypes.UnitId.TbBarracksGround))
            {
                /* Database for the units from the Barracks
                 * Unit         |   Time    |   Min |   Ves |   Sup
                 * -------------|-----------|-------|-------|-------
                 * Marine       |1638400    |   50  |   0   |   1
                 * Reaper       |2949120    |   50  |   50  |   1
                 * Marauder     |1966080    |   100 |   25  |   2
                 * Ghost        |2621440    |   200 |   100 |   2
                 * */

                switch (maximumTime)
                {
                    case 1638400:
                        return PredefinedTypes.UnitId.TuMarine;

                    case 2949120:
                        return PredefinedTypes.UnitId.TuReaper;

                    case 2621440:
                        return PredefinedTypes.UnitId.TuGhost;

                    case 1966080:
                        return PredefinedTypes.UnitId.TuMarauder;
                }
            }

            #endregion

            #region Factory

            else if (structureBuildFrom.Equals(PredefinedTypes.UnitId.TbFactoryGround))
            {
                /* Database for the units from the Barracks
                * Unit         |   Time    |   Min |   Ves |   Sup
                * -------------|-----------|-------|-------|-------
                * Hellion      |1966080    |   100 |   0   |   2
                * Hellbat      |1966080    |   100 |   0   |   2
                * Mine         |2621440    |   75  |   25  |   2
                * Siege Tank   |2949120    |   150 |   125 |   3
                * Thor         |3932160    |   300 |   200 |   6
                * */

                if (logicalId.Equals(65541))
                    return PredefinedTypes.UnitId.TuHellion;

                if (logicalId.Equals(65542))
                    return PredefinedTypes.UnitId.TuHellbat;

                switch (maximumTime)
                {
                    case 3932160:
                        return PredefinedTypes.UnitId.TuThor;

                    case 2621440:
                        return PredefinedTypes.UnitId.TuWidowMine;

                    case 2949120:
                        return PredefinedTypes.UnitId.TuSiegetank;
                }
            }

            #endregion

            #region Starport

            else if (structureBuildFrom.Equals(PredefinedTypes.UnitId.TbStarportGround))
            {
                /* Database for the units from the Barracks
                * Unit         |   Time    |   Min |   Ves |   Sup
                * -------------|-----------|-------|-------|-------
                * Viking       |2752512    |   150 |   75  |   2
                * Medivac      |2752512    |   100 |   100 |   2
                * Raven        |3932160    |   100 |   200 |   2
                * Banshee      |3932160    |   150 |   100 |   3
                * Battlecruiser|5898240    |   400 |   300 |   6
                * */

                if (mineralCost.Equals(150) &&
                    vespineCost.Equals(75))
                    return PredefinedTypes.UnitId.TuVikingAir;

                if (mineralCost.Equals(100) &&
                    vespineCost.Equals(100))
                    return PredefinedTypes.UnitId.TuMedivac;

                if (mineralCost.Equals(100) &&
                    vespineCost.Equals(200))
                    return PredefinedTypes.UnitId.TuRaven;

                if (mineralCost.Equals(150) &&
                    vespineCost.Equals(100))
                    return PredefinedTypes.UnitId.TuBanshee;

                if (mineralCost.Equals(400) &&
                    vespineCost.Equals(300))
                    return PredefinedTypes.UnitId.TuBattlecruiser;
            }

            #endregion

            /* - Upgrades - */

            #region Engineering Bay

            if (structureBuildFrom.Equals(PredefinedTypes.UnitId.TbEbay))
            {
                if (logicalId.Equals(0x10002))
                    return PredefinedTypes.UnitId.TupInfantryWeapon1;

                if (logicalId.Equals(0x10003))
                    return PredefinedTypes.UnitId.TupInfantryWeapon2;

                if (logicalId.Equals(0x10004))
                    return PredefinedTypes.UnitId.TupInfantryWeapon3;

                if (logicalId.Equals(0x10006))
                    return PredefinedTypes.UnitId.TupInfantryArmor1;

                if (logicalId.Equals(0x10007))
                    return PredefinedTypes.UnitId.TupInfantryArmor2;

                if (logicalId.Equals(0x10008))
                    return PredefinedTypes.UnitId.TupInfantryArmor3;

                if (mineralCost.Equals(100) &&
                    vespineCost.Equals(100) &&
                    maximumTime.Equals(5242880))
                    return PredefinedTypes.UnitId.TupHighSecAutoTracking;

                if (mineralCost.Equals(100) &&
                    vespineCost.Equals(100) &&
                    maximumTime.Equals(7208960))
                    return PredefinedTypes.UnitId.TupNeosteelFrame;

                if (mineralCost.Equals(150) &&
                    vespineCost.Equals(150) &&
                    maximumTime.Equals(9175040))
                    return PredefinedTypes.UnitId.TupStructureArmor;
            }

            #endregion

            #region GhostAcademy

            else if (structureBuildFrom.Equals(PredefinedTypes.UnitId.TbGhostacademy))
            {
                if (mineralCost.Equals(150))
                    return PredefinedTypes.UnitId.TupPersonalCloak;

                if (mineralCost.Equals(100))
                {
                    if (logicalId.Equals(0x10000))
                        return PredefinedTypes.UnitId.TuNuke;

                    return PredefinedTypes.UnitId.TupMoebiusReactor;
                }
                    
            }

            #endregion

            #region FusionCore

            else if (structureBuildFrom.Equals(PredefinedTypes.UnitId.TbFusioncore))
            {
                if (maximumTime.Equals(3932160))
                    return PredefinedTypes.UnitId.TupWeaponRefit;

                if (maximumTime.Equals(5242880))
                    return PredefinedTypes.UnitId.TupBehemothReactor;
            }

            #endregion

            #region Armory

            else if (structureBuildFrom.Equals(PredefinedTypes.UnitId.TbArmory))
            {
                if (mineralCost.Equals(100) &&
                    vespineCost.Equals(100) &&
                    maximumTime.Equals(10485760) &&
                    logicalId.Equals(65536))
                    return PredefinedTypes.UnitId.TupVehicleWeapon1;

                if (mineralCost.Equals(175) &&
                    vespineCost.Equals(175) &&
                    maximumTime.Equals(12451840) &&
                    logicalId.Equals(65537))
                    return PredefinedTypes.UnitId.TupVehicleWeapon2;

                if (mineralCost.Equals(250) &&
                    vespineCost.Equals(250) &&
                    maximumTime.Equals(14417920) &&
                    logicalId.Equals(65538))
                    return PredefinedTypes.UnitId.TupVehicleWeapon3;

                if (mineralCost.Equals(100) &&
                    vespineCost.Equals(100) &&
                    maximumTime.Equals(10485760) &&
                    logicalId.Equals(65547))
                    return PredefinedTypes.UnitId.TupShipWeapon1;

                if (mineralCost.Equals(175) &&
                    vespineCost.Equals(175) &&
                    maximumTime.Equals(12451840) &&
                    logicalId.Equals(65548))
                    return PredefinedTypes.UnitId.TupShipWeapon2;

                if (mineralCost.Equals(250) &&
                    vespineCost.Equals(250) &&
                    maximumTime.Equals(14417920) &&
                    logicalId.Equals(65549))
                    return PredefinedTypes.UnitId.TupShipWeapon3;

                if (mineralCost.Equals(100) &&
                    vespineCost.Equals(100) &&
                    maximumTime.Equals(10485760) &&
                    logicalId.Equals(65539))
                    return PredefinedTypes.UnitId.TupVehicleShipPlanting1;

                if (mineralCost.Equals(175) &&
                    vespineCost.Equals(175) &&
                    maximumTime.Equals(12451840) &&
                    logicalId.Equals(65540))
                    return PredefinedTypes.UnitId.TupVehicleShipPlanting2;

                if (mineralCost.Equals(250) &&
                    vespineCost.Equals(250) &&
                    maximumTime.Equals(14417920) &&
                    logicalId.Equals(65541))
                    return PredefinedTypes.UnitId.TupVehicleShipPlanting3;
            }

            #endregion

            #region Techlab Barracks

            else if (structureBuildFrom.Equals(PredefinedTypes.UnitId.TbTechlabRax))
            {
                if (maximumTime.Equals(11141120))
                    return PredefinedTypes.UnitId.TupStim;

                if (maximumTime.Equals(7208960))
                    return PredefinedTypes.UnitId.TupCombatShields;

                if (maximumTime.Equals(3932160))
                    return PredefinedTypes.UnitId.TupConcussiveShells;
            }

            #endregion

            #region Techlab Factory

            else if (structureBuildFrom.Equals(PredefinedTypes.UnitId.TbTechlabFactory))
            {
                if (logicalId.Equals(65537))
                    return PredefinedTypes.UnitId.TupBlueFlame;

                if (logicalId.Equals(65539))
                    return PredefinedTypes.UnitId.TupTransformatorServos;

                if (logicalId.Equals(65540))
                    return PredefinedTypes.UnitId.TupDrillingClaws;
            }

            #endregion

            #region Techlab Starport

            else if (structureBuildFrom.Equals(PredefinedTypes.UnitId.TbTechlabStarport))
            {
                if (logicalId.Equals(65536))
                    return PredefinedTypes.UnitId.TupCloakingField;

                if (logicalId.Equals(65539))
                    return PredefinedTypes.UnitId.TupCorvidReactor;

                if (logicalId.Equals(65543))
                    return PredefinedTypes.UnitId.TupDurableMeterials;

                if (logicalId.Equals(65538))
                    return PredefinedTypes.UnitId.TupCaduceusReactor;
            }

            #endregion

            #endregion

            #region Protoss

            if (structureBuildFrom.Equals(PredefinedTypes.UnitId.PuMothershipCore))
            {
                //E.G. Upgrade to Lair/ Hive
                if (logicalId == -1)
                {
                    if (mineralCost == 300 && vespineCost == 300)
                        return PredefinedTypes.UnitId.PupUpgradeToMothership;
                }
            }

            #region Units

            #region Nexus

            if (structureBuildFrom.Equals(PredefinedTypes.UnitId.PbNexus))
            {
                switch (maximumTime)
                {
                    case 1114112:
                        return PredefinedTypes.UnitId.PuProbe;

                    case 1966080:
                        return PredefinedTypes.UnitId.PuMothershipCore;
                }
            }

            #endregion

            #region Gateway

            if (structureBuildFrom.Equals(PredefinedTypes.UnitId.PbGateway))
            {
                /* Database for the units from the Gateway
                * Unit         |   Time    |   Min |   Ves |   Sup
                * -------------|-----------|-------|-------|-------
                * Zealot       |2490368    |   100 |   0   |   2
                * Stalker      |2752512    |   125 |   50  |   2
                * Sentry       |2424832    |   50  |   100 |   2
                * HT           |3604480    |   50  |   150 |   2
                * DT           |3604480    |   125 |   125 |   2
                * */
                if (mineralCost.Equals(100))
                    return PredefinedTypes.UnitId.PuZealot;

                if (mineralCost.Equals(125) &&
                    vespineCost.Equals(50))
                    return PredefinedTypes.UnitId.PuStalker;

                if (mineralCost.Equals(50) &&
                    vespineCost.Equals(100))
                    return PredefinedTypes.UnitId.PuSentry;

                if (mineralCost.Equals(50) &&
                    vespineCost.Equals(150))
                    return PredefinedTypes.UnitId.PuHightemplar;

                if (mineralCost.Equals(125) &&
                    vespineCost.Equals(125))
                    return PredefinedTypes.UnitId.PuDarktemplar;
            }

            #endregion

            #region Stargate

            else if (structureBuildFrom.Equals(PredefinedTypes.UnitId.PbStargate))
            {
                /* Database for the units from the Gateway
                * Unit         |   Time    |   Min |   Ves |   Sup
                * -------------|-----------|-------|-------|-------
                * Phoenix      |2293760    |   150 |   100 |   2
                * Oracle       |3276800    |   150 |   150 |   3
                * Void Ray     |3932160    |   250 |   150 |   4
                * Tempest      |3932160    |   300 |   200 |   4
                * Carrier      |7864320    |   350 |   250 |   6
                * */

                if (mineralCost.Equals(150) &&
                    vespineCost.Equals(100))
                    return PredefinedTypes.UnitId.PuPhoenix;

                if (mineralCost.Equals(150) &&
                    vespineCost.Equals(150))
                    return PredefinedTypes.UnitId.PuOracle;

                if (mineralCost.Equals(250) &&
                    vespineCost.Equals(150))
                    return PredefinedTypes.UnitId.PuVoidray;

                if (mineralCost.Equals(300) &&
                    vespineCost.Equals(200))
                    return PredefinedTypes.UnitId.PuTempest;

                if (mineralCost.Equals(350) &&
                    vespineCost.Equals(250))
                    return PredefinedTypes.UnitId.PuCarrier;
            }

            #endregion

            #region Robotics

            if (structureBuildFrom.Equals(PredefinedTypes.UnitId.PbRoboticsbay))
            {
                /* Database for the units from the Gateway
                * Unit         |   Time    |   Min |   Ves |   Sup
                * -------------|-----------|-------|-------|-------
                * Observer     |1966080    |   25  |   75  |   1
                * Warp Prism   |3276800    |   200 |   0   |   2
                * Colossus     |4915200    |   300 |   200 |   6
                * Immortal     |3604480    |   250 |   100 |   4
                * */

                if (mineralCost.Equals(25))
                    return PredefinedTypes.UnitId.PuObserver;

                if (mineralCost.Equals(200))
                    return PredefinedTypes.UnitId.PuWarpprismTransport;

                if (mineralCost.Equals(300))
                    return PredefinedTypes.UnitId.PuColossus;

                if (mineralCost.Equals(250))
                    return PredefinedTypes.UnitId.PuImmortal;
            }

            #endregion

            #endregion

            #region Upgrades

            #region Forge

            if (structureBuildFrom.Equals(PredefinedTypes.UnitId.PbForge))
            {
                if (logicalId.Equals(0x10000))
                    return PredefinedTypes.UnitId.PupGroundW1;

                if (logicalId.Equals(0x10001))
                    return PredefinedTypes.UnitId.PupGroundW2;

                if (logicalId.Equals(0x10002))
                    return PredefinedTypes.UnitId.PupGroundW3;

                if (logicalId.Equals(0x10003))
                    return PredefinedTypes.UnitId.PupGroundA1;

                if (logicalId.Equals(0x10004))
                    return PredefinedTypes.UnitId.PupGroundA2;

                if (logicalId.Equals(0x10005))
                    return PredefinedTypes.UnitId.PupGroundA3;

                if (logicalId.Equals(0x10006))
                    return PredefinedTypes.UnitId.PupS1;

                if (logicalId.Equals(0x10007))
                    return PredefinedTypes.UnitId.PupS2;

                if (logicalId.Equals(0x10008))
                    return PredefinedTypes.UnitId.PupS3;
            }

            #endregion

            #region CyberCore

            if (structureBuildFrom.Equals(PredefinedTypes.UnitId.PbCybercore))
            {
                if (logicalId.Equals(0x10000))
                    return PredefinedTypes.UnitId.PupAirW1;

                if (logicalId.Equals(0x10001))
                    return PredefinedTypes.UnitId.PupAirW2;

                if (logicalId.Equals(0x10002))
                    return PredefinedTypes.UnitId.PupAirW3;

                if (logicalId.Equals(0x10003))
                    return PredefinedTypes.UnitId.PupAirA1;

                if (logicalId.Equals(0x10004))
                    return PredefinedTypes.UnitId.PupAirA2;

                if (logicalId.Equals(0x10005))
                    return PredefinedTypes.UnitId.PupAirA3;

                if (logicalId.Equals(0x10006))
                    return PredefinedTypes.UnitId.PupWarpGate;
            }

            #endregion

            #region Robotics Support Bay

            if (structureBuildFrom.Equals(PredefinedTypes.UnitId.PbRoboticssupportbay))
            {
                if (logicalId.Equals(0x10001))
                    return PredefinedTypes.UnitId.PupGraviticBooster;

                if (logicalId.Equals(0x10002))
                    return PredefinedTypes.UnitId.PupGraviticDrive;

                if (logicalId.Equals(0x10005))
                    return PredefinedTypes.UnitId.PupExtendedThermalLance;   
            }

            #endregion

            #region Twilight Council

            if (structureBuildFrom.Equals(PredefinedTypes.UnitId.PbTwilightcouncil))
            {
                if (logicalId.Equals(0x10000))
                    return PredefinedTypes.UnitId.PupCharge;

                if (logicalId.Equals(0x10001))
                    return PredefinedTypes.UnitId.PupBlink;
            }

            #endregion

            #region Fleet Beacon

            if (structureBuildFrom.Equals(PredefinedTypes.UnitId.PbFleetbeacon))
            {
                if (logicalId.Equals(0x10000))
                    return PredefinedTypes.UnitId.PupGravitonCatapult;

                if (logicalId.Equals(0x10002))
                    return PredefinedTypes.UnitId.PupAnionPulseCrystals;
            }

            #endregion

            #region Templar Archives

            if (structureBuildFrom.Equals(PredefinedTypes.UnitId.PbTemplararchives))
            {
                if (logicalId.Equals(0x10004))
                    return PredefinedTypes.UnitId.PupStorm;
            }

            #endregion



            #endregion

            #endregion

            #region Zerg



            if (structureBuildFrom.Equals(PredefinedTypes.UnitId.ZbHatchery) ||
                structureBuildFrom.Equals(PredefinedTypes.UnitId.ZbLiar) ||
                structureBuildFrom.Equals(PredefinedTypes.UnitId.ZbHive))
            {
                if (logicalId.Equals(0x10001))
                    return PredefinedTypes.UnitId.ZupPneumatizedCarapace;

                if (logicalId.Equals(0x10002))
                    return PredefinedTypes.UnitId.ZupVentralSacs;

                if (logicalId.Equals(0x10003))
                    return PredefinedTypes.UnitId.ZupBurrow;

                //E.G. Upgrade to Lair/ Hive
                if (logicalId == -1)
                {
                    if (mineralCost == 150 && vespineCost == 100)
                        return PredefinedTypes.UnitId.ZupUpgradeToLair;

                    if (mineralCost == 200 && vespineCost == 150)
                        return PredefinedTypes.UnitId.ZupUpgradeToHive;
                }

                return PredefinedTypes.UnitId.ZuQueen;
            }

            if (structureBuildFrom.Equals(PredefinedTypes.UnitId.ZbSpire))
            {
                //E.G. Upgrade to Lair/ Hive
                if (logicalId == -1)
                {
                    if (mineralCost == 100 && vespineCost == 150)
                        return PredefinedTypes.UnitId.ZupUpgradeToGreaterSpire;
                }
            }

            #region Units

            if (structureBuildFrom.Equals(PredefinedTypes.UnitId.ZuBanelingCocoon))
            {
                if (maximumTime.Equals(1310720))
                    return PredefinedTypes.UnitId.ZuBaneling;
            }

            if (structureBuildFrom.Equals(PredefinedTypes.UnitId.ZuBroodlordCocoon))
            {
                //E.G. Upgrade to Lair/ Hive
                if (logicalId == -1)
                {
                    if (mineralCost == 150 && vespineCost == 150)
                        return PredefinedTypes.UnitId.ZupUpgradeToBroodlord;
                }
            }

            if (structureBuildFrom.Equals(PredefinedTypes.UnitId.ZuOverseerCocoon))
            {
                //E.G. Upgrade to Lair/ Hive
                if (logicalId == -1)
                {
                    if (mineralCost == 50 && vespineCost == 50)
                        return PredefinedTypes.UnitId.ZupUpgradeToOverseer;
                }
            }

            /* For the eggs, we have to cchack using other values.. 
             Player 2 has the Type waay different. */
            if (structureBuildFrom.Equals(PredefinedTypes.UnitId.ZuEgg))
            {
                /* Database for the units from the egg
                 * Unit         |   Time    |   Min |   Ves |   Sup
                 * -------------|-----------|-------|-------|-------
                 * Drone        |1114112    |   50  |   0   |   1
                 * Zergling     |1572864    |   50  |   0   |   1
                 * Overlord     |1638400    |   100 |   0   |   -
                 * Roach        |1769472    |   75  |   25  |   2
                 * Hydralisk    |2162688    |   100 |   50  |   2 
                 * Mutalsik     |2162688    |   100 |   100 |   2
                 * Corruptor    |2621440    |   150 |   100 |   3
                 * Infestor     |3276800    |   100 |   150 |   2
                 * Swarm Host   |2621440    |   200 |   100 |   3
                 * Viper        |2621440    |   100 |   200 |   3
                 * Ultralisk    |3604480    |   300 |   200 |   6
                 * */

                if (maximumTime.Equals(1114112))
                    return PredefinedTypes.UnitId.ZuDrone;

                if (maximumTime.Equals(1572864))
                    return PredefinedTypes.UnitId.ZuZergling;

                if (maximumTime.Equals(1638400))
                    return PredefinedTypes.UnitId.ZuOverlord;

                if (maximumTime.Equals(1769472))
                    return PredefinedTypes.UnitId.ZuRoach;

                if (maximumTime.Equals(2162688))
                {
                    if (vespineCost.Equals(50))
                        return PredefinedTypes.UnitId.ZuHydralisk;

                        return PredefinedTypes.UnitId.ZuMutalisk;
                }

                if (maximumTime.Equals(2621440))
                {
                    if (mineralCost.Equals(150))
                        return PredefinedTypes.UnitId.ZuCorruptor;

                    if (mineralCost.Equals(200))
                        return PredefinedTypes.UnitId.ZuSwarmHost;

                    if (mineralCost.Equals(100))
                        return PredefinedTypes.UnitId.ZuViper;
                }

                if (maximumTime.Equals(3276800))
                    return PredefinedTypes.UnitId.ZuInfestor;

                if (maximumTime.Equals(3604480))
                    return PredefinedTypes.UnitId.ZuUltra;



            }

            #endregion

            #region Upgrades

            #region Evolution Chamber

            if (structureBuildFrom.Equals(PredefinedTypes.UnitId.ZbEvolutionChamber))
            {
                if (logicalId.Equals(0x10000))
                    return PredefinedTypes.UnitId.ZupGroundM1;

                if (logicalId.Equals(0x10001))
                    return PredefinedTypes.UnitId.ZupGroundM2;

                if (logicalId.Equals(0x10002))
                    return PredefinedTypes.UnitId.ZupGroundM3;

                if (logicalId.Equals(0x10003))
                    return PredefinedTypes.UnitId.ZupGroundA1;

                if (logicalId.Equals(0x10004))
                    return PredefinedTypes.UnitId.ZupGroundA2;

                if (logicalId.Equals(0x10005))
                    return PredefinedTypes.UnitId.ZupGroundA3;

                if (logicalId.Equals(0x10006))
                    return PredefinedTypes.UnitId.ZupGroundW1;

                if (logicalId.Equals(0x10007))
                    return PredefinedTypes.UnitId.ZupGroundW2;

                if (logicalId.Equals(0x10008))
                    return PredefinedTypes.UnitId.ZupGroundW3;
            }

            #endregion

            #region Spire/ Greater Spire

            if (structureBuildFrom.Equals(PredefinedTypes.UnitId.ZbSpire) ||
                structureBuildFrom.Equals(PredefinedTypes.UnitId.ZbGreaterspire))
            {
                if (logicalId.Equals(0x10000))
                    return PredefinedTypes.UnitId.ZupAirW1;

                if (logicalId.Equals(0x10001))
                    return PredefinedTypes.UnitId.ZupAirW2;

                if (logicalId.Equals(0x10002))
                    return PredefinedTypes.UnitId.ZupAirW3;

                if (logicalId.Equals(0x10003))
                    return PredefinedTypes.UnitId.ZupAirA1;

                if (logicalId.Equals(0x10004))
                    return PredefinedTypes.UnitId.ZupAirA2;

                if (logicalId.Equals(0x10005))
                    return PredefinedTypes.UnitId.ZupAirA3;
            }

            #endregion

            #region Hydra Den

            if (structureBuildFrom.Equals(PredefinedTypes.UnitId.ZbHydraDen))
            {
                if (logicalId.Equals(0x10002))
                    return PredefinedTypes.UnitId.ZupGroovedSpines;

                if (logicalId.Equals(0x10003))
                    return PredefinedTypes.UnitId.ZupMuscularAugments;
            }

            #endregion

            #region Roach Warran

            if (structureBuildFrom.Equals(PredefinedTypes.UnitId.ZbRoachWarren))
            {
                if (logicalId.Equals(0x10001))
                    return PredefinedTypes.UnitId.ZupGlialReconstruction;

                if (logicalId.Equals(0x10002))
                    return PredefinedTypes.UnitId.ZupTunnelingClaws;
            }

            #endregion

            #region Infestation Pit

            if (structureBuildFrom.Equals(PredefinedTypes.UnitId.ZbInfestationPit))
            {
                if (logicalId.Equals(0x10002))
                    return PredefinedTypes.UnitId.ZupPathoglenGlands;

                if (logicalId.Equals(0x10003))
                    return PredefinedTypes.UnitId.ZupNeutralParasite;

                if (logicalId.Equals(0x10004))
                    return PredefinedTypes.UnitId.ZupEnduringLocusts;
            }

            #endregion

            #region Spawning Pool

            if (structureBuildFrom.Equals(PredefinedTypes.UnitId.ZbSpawningPool))
            {
                if (logicalId.Equals(0x10000))
                    return PredefinedTypes.UnitId.ZupAdrenalGlands;

                if (logicalId.Equals(0x10001))
                    return PredefinedTypes.UnitId.ZupMetabolicBoost;
            }

            #endregion

            #region Baneling Nest

            if (structureBuildFrom.Equals(PredefinedTypes.UnitId.ZbBanelingNest))
            {
                if (logicalId.Equals(0x10000))
                    return PredefinedTypes.UnitId.ZupCentrifugalHooks;
            }

            #endregion

            #region Ultra Cavern

            if (structureBuildFrom.Equals(PredefinedTypes.UnitId.ZbUltraCavern))
            {
                if (logicalId.Equals(0x10002))
                    return PredefinedTypes.UnitId.ZupChitinousPlating;
            }

            #endregion


            #endregion

            /* Missing: Broodlord Cocoon and Overseer Cocoon - Cant be found.. */
            #endregion

            return PredefinedTypes.UnitId.NbXelNagaTower;
        }

        public static Int32 GetMaximumInteger(params Int32[] valInput)
        {
            var iValue = valInput[0];

            for (var i = 0; i < valInput.Length; i++)
            {
                if (iValue < valInput[i])
                    iValue = valInput[i];
            }

                return iValue;
        }

        public static Int32 CountUnitTypePerPlayer(List<PredefinedTypes.Unit> lUnit, PredefinedTypes.UnitId id, Int32 playerNumber)
        {
            var iBuildingCount = 0;
            for (var i = 0; i < lUnit.Count; i++)
            {
                if (lUnit[i].Id.Equals(id))
                    if (lUnit[i].Owner.Equals(playerNumber))
                        if (!lUnit[i].IsUnderConstruction)
                            iBuildingCount += 1;
            }

            return iBuildingCount;
        }

        public static Image ByteArrayToImage(byte[] byteArrayIn)
        {
            var ms = new MemoryStream(byteArrayIn);
            var returnImage = Image.FromStream(ms);
            return returnImage;
        }

        public static Control findParentByName(Control control, string name)
        {
            while (control.Parent.Name != name)
                control = control.Parent;

            return control;
        }
    }
}
