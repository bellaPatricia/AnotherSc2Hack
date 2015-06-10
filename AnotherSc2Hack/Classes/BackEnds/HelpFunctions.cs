using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using AnotherSc2Hack.Classes.DataStructures.Preference;
using AnotherSc2Hack.Classes.FrontEnds.Custom_Controls;
using PredefinedTypes;

namespace AnotherSc2Hack.Classes.BackEnds
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

        public static void CheckIfWindowStyleIsFullscreen(PredefinedData.WindowStyle w)
        {
            if (w.Equals(PredefinedData.WindowStyle.Fullscreen))
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

        public static Int32 GetValidPlayerCount(List<PredefinedData.PlayerStruct> lPlayer)
        {
            var iValidSize = 0;

            if (lPlayer == null ||
                lPlayer.Count <= 0)
                return 0;

            for (var i = 0; i < lPlayer.Count; i++)
            {
                if (!lPlayer[i].Name.StartsWith("\0") && !(lPlayer[i].NameLength <= 0) && !lPlayer[i].Type.Equals(PredefinedData.PlayerType.Hostile))
                    iValidSize += 1;
            }

            return iValidSize;
        }

        public static void SetWindowStyle(IntPtr handle, PredefinedData.CustomWindowStyles wndStyle)
        {
            if (wndStyle.Equals(PredefinedData.CustomWindowStyles.Clickable))
            {
                var initial = InteropCalls.GetWindowLong(handle, (Int32)InteropCalls.Gwl.ExStyle);
                InteropCalls.SetWindowLong(handle, (Int32)InteropCalls.Gwl.ExStyle,
                                            (IntPtr)(initial & ~(Int32)InteropCalls.Ws.ExTransparent));
            }

            else if (wndStyle.Equals(PredefinedData.CustomWindowStyles.NotClickable))
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

        public static void InitResolution(ref PreferenceManager pSettings, string text, string header)
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

            new AnotherMessageBox().Show(text, header);
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
        public static Int32 GetMaximumHealth(PredefinedData.UnitId id)
        {
            switch (id)
            {
                case PredefinedData.UnitId.PbAssimilator:
                    return 450;

                case PredefinedData.UnitId.PbCannon:
                    return 150;

                case PredefinedData.UnitId.PbCybercore:
                    return 550;

                case PredefinedData.UnitId.PbDarkshrine:
                    return 500;

                case PredefinedData.UnitId.PbFleetbeacon:
                    return 500;

                case PredefinedData.UnitId.PbForge:
                    return 400;

                case PredefinedData.UnitId.PbGateway:
                    return 500;

                case PredefinedData.UnitId.PbNexus:
                    return 1000;

                case PredefinedData.UnitId.PbPylon:
                    return 200;

                case PredefinedData.UnitId.PbRoboticsbay:
                    return 450;

                case PredefinedData.UnitId.PbRoboticssupportbay:
                    return 500;

                case PredefinedData.UnitId.PbStargate:
                    return 600;

                case PredefinedData.UnitId.PbTemplararchives:
                    return 500;

                case PredefinedData.UnitId.PbTwilightcouncil:
                    return 500;

                case PredefinedData.UnitId.PbWarpgate:
                    return 500;



                case PredefinedData.UnitId.TbArmory:
                    return 750;

                case PredefinedData.UnitId.TbAutoTurret:
                    return 150;

                case PredefinedData.UnitId.TbBarracksGround:
                    return 1000;

                case PredefinedData.UnitId.TbBunker:
                    return 400;

                case PredefinedData.UnitId.TbCcAir:
                    return 1500;

                case PredefinedData.UnitId.TbCcGround:
                    return 1500;

                case PredefinedData.UnitId.TbEbay:
                    return 850;

                case PredefinedData.UnitId.TbFactoryAir:
                    return 1250;

                case PredefinedData.UnitId.TbFactoryGround:
                    return 1250;

                case PredefinedData.UnitId.TbFusioncore:
                    return 750;

                case PredefinedData.UnitId.TbGhostacademy:
                    return 1250;

                case PredefinedData.UnitId.TbOrbitalAir:
                    return 1500;

                case PredefinedData.UnitId.TbOrbitalGround:
                    return 1500;

                case PredefinedData.UnitId.TbPlanetary:
                    return 1500;

                case PredefinedData.UnitId.TbRaxAir:
                    return 1000;

                case PredefinedData.UnitId.TbReactor:
                    return 400;

                case PredefinedData.UnitId.TbReactorFactory:
                    return 400;

                case PredefinedData.UnitId.TbReactorRax:
                    return 400;

                case PredefinedData.UnitId.TbReactorStarport:
                    return 400;

                case PredefinedData.UnitId.TbRefinery:
                    return 500;

                case PredefinedData.UnitId.TbSensortower:
                    return 200;

                case PredefinedData.UnitId.TbStarportAir:
                    return 1300;

                case PredefinedData.UnitId.TbStarportGround:
                    return 1300;

                case PredefinedData.UnitId.TbSupplyGround:
                    return 400;

                case PredefinedData.UnitId.TbSupplyHidden:
                    return 400;

                case PredefinedData.UnitId.TbTechlab:
                    return 400;

                case PredefinedData.UnitId.TbTechlabFactory:
                    return 400;

                case PredefinedData.UnitId.TbTechlabRax:
                    return 400;

                case PredefinedData.UnitId.TbTechlabStarport:
                    return 400;

                case PredefinedData.UnitId.TbTurret:
                    return 250;


                case PredefinedData.UnitId.ZbBanelingNest:
                    return 850;

                case PredefinedData.UnitId.ZbCreeptumor:
                    return 50;

                case PredefinedData.UnitId.ZbCreepTumorBuilding:
                    return 50;

                case PredefinedData.UnitId.ZbCreepTumorMissle:
                    return 50;

                case PredefinedData.UnitId.ZbCreeptumorBurrowed:
                    return 50;

                case PredefinedData.UnitId.ZbEvolutionChamber:
                    return 750;

                case PredefinedData.UnitId.ZbExtractor:
                    return 500;

                case PredefinedData.UnitId.ZbGreaterspire:
                    return 1000;

                case PredefinedData.UnitId.ZbHatchery:
                    return 1500;

                case PredefinedData.UnitId.ZbHive:
                    return 2500;

                case PredefinedData.UnitId.ZbHydraDen:
                    return 850;

                case PredefinedData.UnitId.ZbInfestationPit:
                    return 850;

                case PredefinedData.UnitId.ZbLiar:
                    return 2000;

                case PredefinedData.UnitId.ZbNydusNetwork:
                    return 850;

                case PredefinedData.UnitId.ZbNydusWorm:
                    return 200;

                case PredefinedData.UnitId.ZbRoachWarren:
                    return 850;

                case PredefinedData.UnitId.ZbSpawningPool:
                    return 1000;

                case PredefinedData.UnitId.ZbSpineCrawler:
                    return 300;

                case PredefinedData.UnitId.ZbSpire:
                    return 850;

                case PredefinedData.UnitId.ZbSporeCrawler:
                    return 400;

                case PredefinedData.UnitId.ZbUltraCavern:
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

        public static PredefinedData.UnitId GetUnitIdFromLogicalId(PredefinedData.UnitId structureBuildFrom, Int32 logicalId, Int32 maximumTime, Int32 mineralCost, Int32 vespineCost)
        {
            if (logicalId.Equals(0))
                return PredefinedData.UnitId.NbXelNagaTower;

            if (!logicalId.Equals(-1))
            {

                var strStuff = Convert.ToString(logicalId, 16);
                strStuff = "1" + strStuff.Substring(1);

                var inumber = int.Parse(strStuff, NumberStyles.HexNumber);

                logicalId = inumber;
            }

            #region Terran 

            #region CC - Orbital - PF

            if (structureBuildFrom.Equals(PredefinedData.UnitId.TbCcGround))
            {
                //E.G. Upgrade to Lair/ Hive
                if (logicalId == -1)
                {
                    if (mineralCost == 150 && vespineCost == 0)
                        return PredefinedData.UnitId.TupUpgradeToOrbital;

                    if (mineralCost == 150 && vespineCost == 150)
                        return PredefinedData.UnitId.TupUpgradeToPlanetary;
                }

                return PredefinedData.UnitId.TuScv;
            }

            if (structureBuildFrom.Equals(PredefinedData.UnitId.TbPlanetary))
                return PredefinedData.UnitId.TuScv;

            if (structureBuildFrom.Equals(PredefinedData.UnitId.TbOrbitalGround))
                return PredefinedData.UnitId.TuScv;

            #endregion

            #region Barracks

            if (structureBuildFrom.Equals(PredefinedData.UnitId.TbBarracksGround))
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
                        return PredefinedData.UnitId.TuMarine;

                    case 2949120:
                        return PredefinedData.UnitId.TuReaper;

                    case 2621440:
                        return PredefinedData.UnitId.TuGhost;

                    case 1966080:
                        return PredefinedData.UnitId.TuMarauder;
                }
            }

            #endregion

            #region Factory

            else if (structureBuildFrom.Equals(PredefinedData.UnitId.TbFactoryGround))
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
                    return PredefinedData.UnitId.TuHellion;

                if (logicalId.Equals(65542))
                    return PredefinedData.UnitId.TuHellbat;

                switch (maximumTime)
                {
                    case 3932160:
                        return PredefinedData.UnitId.TuThor;

                    case 2621440:
                        return PredefinedData.UnitId.TuWidowMine;

                    case 2949120:
                        return PredefinedData.UnitId.TuSiegetank;
                }
            }

            #endregion

            #region Starport

            else if (structureBuildFrom.Equals(PredefinedData.UnitId.TbStarportGround))
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
                    return PredefinedData.UnitId.TuVikingAir;

                if (mineralCost.Equals(100) &&
                    vespineCost.Equals(100))
                    return PredefinedData.UnitId.TuMedivac;

                if (mineralCost.Equals(100) &&
                    vespineCost.Equals(200))
                    return PredefinedData.UnitId.TuRaven;

                if (mineralCost.Equals(150) &&
                    vespineCost.Equals(100))
                    return PredefinedData.UnitId.TuBanshee;

                if (mineralCost.Equals(400) &&
                    vespineCost.Equals(300))
                    return PredefinedData.UnitId.TuBattlecruiser;
            }

            #endregion

            /* - Upgrades - */

            #region Engineering Bay

            if (structureBuildFrom.Equals(PredefinedData.UnitId.TbEbay))
            {
                if (logicalId.Equals(0x10002))
                    return PredefinedData.UnitId.TupInfantryWeapon1;

                if (logicalId.Equals(0x10003))
                    return PredefinedData.UnitId.TupInfantryWeapon2;

                if (logicalId.Equals(0x10004))
                    return PredefinedData.UnitId.TupInfantryWeapon3;

                if (logicalId.Equals(0x10006))
                    return PredefinedData.UnitId.TupInfantryArmor1;

                if (logicalId.Equals(0x10007))
                    return PredefinedData.UnitId.TupInfantryArmor2;

                if (logicalId.Equals(0x10008))
                    return PredefinedData.UnitId.TupInfantryArmor3;

                if (mineralCost.Equals(100) &&
                    vespineCost.Equals(100) &&
                    maximumTime.Equals(5242880))
                    return PredefinedData.UnitId.TupHighSecAutoTracking;

                if (mineralCost.Equals(100) &&
                    vespineCost.Equals(100) &&
                    maximumTime.Equals(7208960))
                    return PredefinedData.UnitId.TupNeosteelFrame;

                if (mineralCost.Equals(150) &&
                    vespineCost.Equals(150) &&
                    maximumTime.Equals(9175040))
                    return PredefinedData.UnitId.TupStructureArmor;
            }

            #endregion

            #region GhostAcademy

            else if (structureBuildFrom.Equals(PredefinedData.UnitId.TbGhostacademy))
            {
                if (mineralCost.Equals(150))
                    return PredefinedData.UnitId.TupPersonalCloak;

                if (mineralCost.Equals(100))
                {
                    if (logicalId.Equals(0x10000))
                        return PredefinedData.UnitId.TuNuke;

                    return PredefinedData.UnitId.TupMoebiusReactor;
                }
                    
            }

            #endregion

            #region FusionCore

            else if (structureBuildFrom.Equals(PredefinedData.UnitId.TbFusioncore))
            {
                if (maximumTime.Equals(3932160))
                    return PredefinedData.UnitId.TupWeaponRefit;

                if (maximumTime.Equals(5242880))
                    return PredefinedData.UnitId.TupBehemothReactor;
            }

            #endregion

            #region Armory

            else if (structureBuildFrom.Equals(PredefinedData.UnitId.TbArmory))
            {
                if (mineralCost.Equals(100) &&
                    vespineCost.Equals(100) &&
                    maximumTime.Equals(10485760) &&
                    logicalId.Equals(65536))
                    return PredefinedData.UnitId.TupVehicleWeapon1;

                if (mineralCost.Equals(175) &&
                    vespineCost.Equals(175) &&
                    maximumTime.Equals(12451840) &&
                    logicalId.Equals(65537))
                    return PredefinedData.UnitId.TupVehicleWeapon2;

                if (mineralCost.Equals(250) &&
                    vespineCost.Equals(250) &&
                    maximumTime.Equals(14417920) &&
                    logicalId.Equals(65538))
                    return PredefinedData.UnitId.TupVehicleWeapon3;

                if (mineralCost.Equals(100) &&
                    vespineCost.Equals(100) &&
                    maximumTime.Equals(10485760) &&
                    logicalId.Equals(65547))
                    return PredefinedData.UnitId.TupShipWeapon1;

                if (mineralCost.Equals(175) &&
                    vespineCost.Equals(175) &&
                    maximumTime.Equals(12451840) &&
                    logicalId.Equals(65548))
                    return PredefinedData.UnitId.TupShipWeapon2;

                if (mineralCost.Equals(250) &&
                    vespineCost.Equals(250) &&
                    maximumTime.Equals(14417920) &&
                    logicalId.Equals(65549))
                    return PredefinedData.UnitId.TupShipWeapon3;

                if (mineralCost.Equals(100) &&
                    vespineCost.Equals(100) &&
                    maximumTime.Equals(10485760) &&
                    logicalId.Equals(65539))
                    return PredefinedData.UnitId.TupVehicleShipPlanting1;

                if (mineralCost.Equals(175) &&
                    vespineCost.Equals(175) &&
                    maximumTime.Equals(12451840) &&
                    logicalId.Equals(65540))
                    return PredefinedData.UnitId.TupVehicleShipPlanting2;

                if (mineralCost.Equals(250) &&
                    vespineCost.Equals(250) &&
                    maximumTime.Equals(14417920) &&
                    logicalId.Equals(65541))
                    return PredefinedData.UnitId.TupVehicleShipPlanting3;
            }

            #endregion

            #region Techlab Barracks

            else if (structureBuildFrom.Equals(PredefinedData.UnitId.TbTechlabRax))
            {
                if (maximumTime.Equals(11141120))
                    return PredefinedData.UnitId.TupStim;

                if (maximumTime.Equals(7208960))
                    return PredefinedData.UnitId.TupCombatShields;

                if (maximumTime.Equals(3932160))
                    return PredefinedData.UnitId.TupConcussiveShells;
            }

            #endregion

            #region Techlab Factory

            else if (structureBuildFrom.Equals(PredefinedData.UnitId.TbTechlabFactory))
            {
                if (logicalId.Equals(65537))
                    return PredefinedData.UnitId.TupBlueFlame;

                if (logicalId.Equals(65539))
                    return PredefinedData.UnitId.TupTransformatorServos;

                if (logicalId.Equals(65540))
                    return PredefinedData.UnitId.TupDrillingClaws;
            }

            #endregion

            #region Techlab Starport

            else if (structureBuildFrom.Equals(PredefinedData.UnitId.TbTechlabStarport))
            {
                if (logicalId.Equals(65536))
                    return PredefinedData.UnitId.TupCloakingField;

                if (logicalId.Equals(65539))
                    return PredefinedData.UnitId.TupCorvidReactor;

                if (logicalId.Equals(65543))
                    return PredefinedData.UnitId.TupDurableMeterials;

                if (logicalId.Equals(65538))
                    return PredefinedData.UnitId.TupCaduceusReactor;
            }

            #endregion

            #endregion

            #region Protoss

            if (structureBuildFrom.Equals(PredefinedData.UnitId.PuMothershipCore))
            {
                //E.G. Upgrade to Lair/ Hive
                if (logicalId == -1)
                {
                    if (mineralCost == 300 && vespineCost == 300)
                        return PredefinedData.UnitId.PupUpgradeToMothership;
                }
            }

            #region Units

            #region Nexus

            if (structureBuildFrom.Equals(PredefinedData.UnitId.PbNexus))
            {
                switch (maximumTime)
                {
                    case 1114112:
                        return PredefinedData.UnitId.PuProbe;

                    case 1966080:
                        return PredefinedData.UnitId.PuMothershipCore;
                }
            }

            #endregion

            #region Gateway

            if (structureBuildFrom.Equals(PredefinedData.UnitId.PbGateway))
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
                    return PredefinedData.UnitId.PuZealot;

                if (mineralCost.Equals(125) &&
                    vespineCost.Equals(50))
                    return PredefinedData.UnitId.PuStalker;

                if (mineralCost.Equals(50) &&
                    vespineCost.Equals(100))
                    return PredefinedData.UnitId.PuSentry;

                if (mineralCost.Equals(50) &&
                    vespineCost.Equals(150))
                    return PredefinedData.UnitId.PuHightemplar;

                if (mineralCost.Equals(125) &&
                    vespineCost.Equals(125))
                    return PredefinedData.UnitId.PuDarktemplar;
            }

            #endregion

            #region Stargate

            else if (structureBuildFrom.Equals(PredefinedData.UnitId.PbStargate))
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
                    return PredefinedData.UnitId.PuPhoenix;

                if (mineralCost.Equals(150) &&
                    vespineCost.Equals(150))
                    return PredefinedData.UnitId.PuOracle;

                if (mineralCost.Equals(250) &&
                    vespineCost.Equals(150))
                    return PredefinedData.UnitId.PuVoidray;

                if (mineralCost.Equals(300) &&
                    vespineCost.Equals(200))
                    return PredefinedData.UnitId.PuTempest;

                if (mineralCost.Equals(350) &&
                    vespineCost.Equals(250))
                    return PredefinedData.UnitId.PuCarrier;
            }

            #endregion

            #region Robotics

            if (structureBuildFrom.Equals(PredefinedData.UnitId.PbRoboticsbay))
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
                    return PredefinedData.UnitId.PuObserver;

                if (mineralCost.Equals(200))
                    return PredefinedData.UnitId.PuWarpprismTransport;

                if (mineralCost.Equals(300))
                    return PredefinedData.UnitId.PuColossus;

                if (mineralCost.Equals(250))
                    return PredefinedData.UnitId.PuImmortal;
            }

            #endregion

            #endregion

            #region Upgrades

            #region Forge

            if (structureBuildFrom.Equals(PredefinedData.UnitId.PbForge))
            {
                if (logicalId.Equals(0x10000))
                    return PredefinedData.UnitId.PupGroundW1;

                if (logicalId.Equals(0x10001))
                    return PredefinedData.UnitId.PupGroundW2;

                if (logicalId.Equals(0x10002))
                    return PredefinedData.UnitId.PupGroundW3;

                if (logicalId.Equals(0x10003))
                    return PredefinedData.UnitId.PupGroundA1;

                if (logicalId.Equals(0x10004))
                    return PredefinedData.UnitId.PupGroundA2;

                if (logicalId.Equals(0x10005))
                    return PredefinedData.UnitId.PupGroundA3;

                if (logicalId.Equals(0x10006))
                    return PredefinedData.UnitId.PupS1;

                if (logicalId.Equals(0x10007))
                    return PredefinedData.UnitId.PupS2;

                if (logicalId.Equals(0x10008))
                    return PredefinedData.UnitId.PupS3;
            }

            #endregion

            #region CyberCore

            if (structureBuildFrom.Equals(PredefinedData.UnitId.PbCybercore))
            {
                if (logicalId.Equals(0x10000))
                    return PredefinedData.UnitId.PupAirW1;

                if (logicalId.Equals(0x10001))
                    return PredefinedData.UnitId.PupAirW2;

                if (logicalId.Equals(0x10002))
                    return PredefinedData.UnitId.PupAirW3;

                if (logicalId.Equals(0x10003))
                    return PredefinedData.UnitId.PupAirA1;

                if (logicalId.Equals(0x10004))
                    return PredefinedData.UnitId.PupAirA2;

                if (logicalId.Equals(0x10005))
                    return PredefinedData.UnitId.PupAirA3;

                if (logicalId.Equals(0x10006))
                    return PredefinedData.UnitId.PupWarpGate;
            }

            #endregion

            #region Robotics Support Bay

            if (structureBuildFrom.Equals(PredefinedData.UnitId.PbRoboticssupportbay))
            {
                if (logicalId.Equals(0x10001))
                    return PredefinedData.UnitId.PupGraviticBooster;

                if (logicalId.Equals(0x10002))
                    return PredefinedData.UnitId.PupGraviticDrive;

                if (logicalId.Equals(0x10005))
                    return PredefinedData.UnitId.PupExtendedThermalLance;   
            }

            #endregion

            #region Twilight Council

            if (structureBuildFrom.Equals(PredefinedData.UnitId.PbTwilightcouncil))
            {
                if (logicalId.Equals(0x10000))
                    return PredefinedData.UnitId.PupCharge;

                if (logicalId.Equals(0x10001))
                    return PredefinedData.UnitId.PupBlink;
            }

            #endregion

            #region Fleet Beacon

            if (structureBuildFrom.Equals(PredefinedData.UnitId.PbFleetbeacon))
            {
                if (logicalId.Equals(0x10000))
                    return PredefinedData.UnitId.PupGravitonCatapult;

                if (logicalId.Equals(0x10002))
                    return PredefinedData.UnitId.PupAnionPulseCrystals;
            }

            #endregion

            #region Templar Archives

            if (structureBuildFrom.Equals(PredefinedData.UnitId.PbTemplararchives))
            {
                if (logicalId.Equals(0x10004))
                    return PredefinedData.UnitId.PupStorm;
            }

            #endregion



            #endregion

            #endregion

            #region Zerg



            if (structureBuildFrom.Equals(PredefinedData.UnitId.ZbHatchery) ||
                structureBuildFrom.Equals(PredefinedData.UnitId.ZbLiar) ||
                structureBuildFrom.Equals(PredefinedData.UnitId.ZbHive))
            {
                if (logicalId.Equals(0x10001))
                    return PredefinedData.UnitId.ZupPneumatizedCarapace;

                if (logicalId.Equals(0x10002))
                    return PredefinedData.UnitId.ZupVentralSacs;

                if (logicalId.Equals(0x10003))
                    return PredefinedData.UnitId.ZupBurrow;

                //E.G. Upgrade to Lair/ Hive
                if (logicalId == -1)
                {
                    if (mineralCost == 150 && vespineCost == 100)
                        return PredefinedData.UnitId.ZupUpgradeToLair;

                    if (mineralCost == 200 && vespineCost == 150)
                        return PredefinedData.UnitId.ZupUpgradeToHive;
                }

                return PredefinedData.UnitId.ZuQueen;
            }

            if (structureBuildFrom.Equals(PredefinedData.UnitId.ZbSpire))
            {
                //E.G. Upgrade to Lair/ Hive
                if (logicalId == -1)
                {
                    if (mineralCost == 100 && vespineCost == 150)
                        return PredefinedData.UnitId.ZupUpgradeToGreaterSpire;
                }
            }

            #region Units

            if (structureBuildFrom.Equals(PredefinedData.UnitId.ZuBanelingCocoon))
            {
                if (maximumTime.Equals(1310720))
                    return PredefinedData.UnitId.ZuBaneling;
            }

            if (structureBuildFrom.Equals(PredefinedData.UnitId.ZuBroodlordCocoon))
            {
                //E.G. Upgrade to Lair/ Hive
                if (logicalId == -1)
                {
                    if (mineralCost == 150 && vespineCost == 150)
                        return PredefinedData.UnitId.ZupUpgradeToBroodlord;
                }
            }

            if (structureBuildFrom.Equals(PredefinedData.UnitId.ZuOverseerCocoon))
            {
                //E.G. Upgrade to Lair/ Hive
                if (logicalId == -1)
                {
                    if (mineralCost == 50 && vespineCost == 50)
                        return PredefinedData.UnitId.ZupUpgradeToOverseer;
                }
            }

            /* For the eggs, we have to cchack using other values.. 
             Player 2 has the Type waay different. */
            if (structureBuildFrom.Equals(PredefinedData.UnitId.ZuEgg))
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
                    return PredefinedData.UnitId.ZuDrone;

                if (maximumTime.Equals(1572864))
                    return PredefinedData.UnitId.ZuZergling;

                if (maximumTime.Equals(1638400))
                    return PredefinedData.UnitId.ZuOverlord;

                if (maximumTime.Equals(1769472))
                    return PredefinedData.UnitId.ZuRoach;

                if (maximumTime.Equals(2162688))
                {
                    if (vespineCost.Equals(50))
                        return PredefinedData.UnitId.ZuHydralisk;

                        return PredefinedData.UnitId.ZuMutalisk;
                }

                if (maximumTime.Equals(2621440))
                {
                    if (mineralCost.Equals(150))
                        return PredefinedData.UnitId.ZuCorruptor;

                    if (mineralCost.Equals(200))
                        return PredefinedData.UnitId.ZuSwarmHost;

                    if (mineralCost.Equals(100))
                        return PredefinedData.UnitId.ZuViper;
                }

                if (maximumTime.Equals(3276800))
                    return PredefinedData.UnitId.ZuInfestor;

                if (maximumTime.Equals(3604480))
                    return PredefinedData.UnitId.ZuUltra;



            }

            #endregion

            #region Upgrades

            #region Evolution Chamber

            if (structureBuildFrom.Equals(PredefinedData.UnitId.ZbEvolutionChamber))
            {
                if (logicalId.Equals(0x10000))
                    return PredefinedData.UnitId.ZupGroundM1;

                if (logicalId.Equals(0x10001))
                    return PredefinedData.UnitId.ZupGroundM2;

                if (logicalId.Equals(0x10002))
                    return PredefinedData.UnitId.ZupGroundM3;

                if (logicalId.Equals(0x10003))
                    return PredefinedData.UnitId.ZupGroundA1;

                if (logicalId.Equals(0x10004))
                    return PredefinedData.UnitId.ZupGroundA2;

                if (logicalId.Equals(0x10005))
                    return PredefinedData.UnitId.ZupGroundA3;

                if (logicalId.Equals(0x10006))
                    return PredefinedData.UnitId.ZupGroundW1;

                if (logicalId.Equals(0x10007))
                    return PredefinedData.UnitId.ZupGroundW2;

                if (logicalId.Equals(0x10008))
                    return PredefinedData.UnitId.ZupGroundW3;
            }

            #endregion

            #region Spire/ Greater Spire

            if (structureBuildFrom.Equals(PredefinedData.UnitId.ZbSpire) ||
                structureBuildFrom.Equals(PredefinedData.UnitId.ZbGreaterspire))
            {
                if (logicalId.Equals(0x10000))
                    return PredefinedData.UnitId.ZupAirW1;

                if (logicalId.Equals(0x10001))
                    return PredefinedData.UnitId.ZupAirW2;

                if (logicalId.Equals(0x10002))
                    return PredefinedData.UnitId.ZupAirW3;

                if (logicalId.Equals(0x10003))
                    return PredefinedData.UnitId.ZupAirA1;

                if (logicalId.Equals(0x10004))
                    return PredefinedData.UnitId.ZupAirA2;

                if (logicalId.Equals(0x10005))
                    return PredefinedData.UnitId.ZupAirA3;
            }

            #endregion

            #region Hydra Den

            if (structureBuildFrom.Equals(PredefinedData.UnitId.ZbHydraDen))
            {
                if (logicalId.Equals(0x10002))
                    return PredefinedData.UnitId.ZupGroovedSpines;

                if (logicalId.Equals(0x10003))
                    return PredefinedData.UnitId.ZupMuscularAugments;
            }

            #endregion

            #region Roach Warran

            if (structureBuildFrom.Equals(PredefinedData.UnitId.ZbRoachWarren))
            {
                if (logicalId.Equals(0x10001))
                    return PredefinedData.UnitId.ZupGlialReconstruction;

                if (logicalId.Equals(0x10002))
                    return PredefinedData.UnitId.ZupTunnelingClaws;
            }

            #endregion

            #region Infestation Pit

            if (structureBuildFrom.Equals(PredefinedData.UnitId.ZbInfestationPit))
            {
                if (logicalId.Equals(0x10002))
                    return PredefinedData.UnitId.ZupPathoglenGlands;

                if (logicalId.Equals(0x10003))
                    return PredefinedData.UnitId.ZupNeutralParasite;

                if (logicalId.Equals(0x10004))
                    return PredefinedData.UnitId.ZupEnduringLocusts;
            }

            #endregion

            #region Spawning Pool

            if (structureBuildFrom.Equals(PredefinedData.UnitId.ZbSpawningPool))
            {
                if (logicalId.Equals(0x10000))
                    return PredefinedData.UnitId.ZupAdrenalGlands;

                if (logicalId.Equals(0x10001))
                    return PredefinedData.UnitId.ZupMetabolicBoost;
            }

            #endregion

            #region Baneling Nest

            if (structureBuildFrom.Equals(PredefinedData.UnitId.ZbBanelingNest))
            {
                if (logicalId.Equals(0x10000))
                    return PredefinedData.UnitId.ZupCentrifugalHooks;
            }

            #endregion

            #region Ultra Cavern

            if (structureBuildFrom.Equals(PredefinedData.UnitId.ZbUltraCavern))
            {
                if (logicalId.Equals(0x10002))
                    return PredefinedData.UnitId.ZupChitinousPlating;
            }

            #endregion


            #endregion

            /* Missing: Broodlord Cocoon and Overseer Cocoon - Cant be found.. */
            #endregion

            return PredefinedData.UnitId.NbXelNagaTower;
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

        public static Int32 CountUnitTypePerPlayer(List<PredefinedData.Unit> lUnit, PredefinedData.UnitId id, Int32 playerNumber)
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
