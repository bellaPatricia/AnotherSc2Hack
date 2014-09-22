using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PredefinedTypes = Predefined.PredefinedData;

namespace PluginWorkerTrainer
{
    public class Various
    {
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

        public static Boolean HotkeysPressed(params Keys[] keys)
        {
            Boolean blResult = true;

            for (var i = 0; i < keys.Length; i++)
            {
                blResult = blResult && InteropCalls.GetAsyncKeyState((uint)keys[i]) <= -32767;
            }

            return blResult;
        }
    }
}