using System;
using System.Windows.Forms;
using PredefinedTypes;
using PredefinedTypes = PredefinedTypes.PredefinedData;

namespace AnotherSc2Hack.Classes.BackEnds
{
    class AutomationHelper
    {
        private readonly IntPtr _myHandle = IntPtr.Zero;
        private readonly PredefinedData.AutomationMethods _myMethod = PredefinedData.AutomationMethods.PostMessage;

        public AutomationHelper(IntPtr handle, PredefinedData.AutomationMethods method)
        {
            _myHandle = handle;
            _myMethod = method;
        }

        public void SelectGroup(PredefinedData.GroupSelection group)
        {
            if (_myMethod.Equals(PredefinedData.AutomationMethods.SendMessage))
            {
                InteropCalls.SendMessage(_myHandle, (uint)InteropCalls.WMessages.Keydown, (IntPtr)group, IntPtr.Zero);
                InteropCalls.SendMessage(_myHandle, (uint)InteropCalls.WMessages.Keyup, (IntPtr)group, IntPtr.Zero);
            }

            else if (_myMethod.Equals(PredefinedData.AutomationMethods.PostMessage))
            {
                InteropCalls.PostMessage(_myHandle, (uint)InteropCalls.WMessages.Keydown, (IntPtr)group, IntPtr.Zero);
                InteropCalls.PostMessage(_myHandle, (uint)InteropCalls.WMessages.Keyup, (IntPtr)group, IntPtr.Zero);
            }
        }

        public void AssignGroup(PredefinedData.GroupSelection group)
        {
            if (_myMethod.Equals(PredefinedData.AutomationMethods.SendMessage))
            {
                InteropCalls.SendMessage(_myHandle, (uint)InteropCalls.WMessages.Keydown, (IntPtr)Keys.ControlKey, IntPtr.Zero);
                InteropCalls.SendMessage(_myHandle, (uint) InteropCalls.WMessages.Keydown, (IntPtr) group,
                                         (IntPtr) InteropCalls.WMessages.Keyup);
                InteropCalls.SendMessage(_myHandle, (uint)InteropCalls.WMessages.Keyup, (IntPtr)Keys.ControlKey, IntPtr.Zero);
            }

            else if (_myMethod.Equals(PredefinedData.AutomationMethods.PostMessage))
            {
                InteropCalls.PostMessage(_myHandle, (uint)InteropCalls.WMessages.Keydown, (IntPtr)Keys.ControlKey, IntPtr.Zero);
                InteropCalls.PostMessage(_myHandle, (uint)InteropCalls.WMessages.Keydown, (IntPtr)group,
                                         (IntPtr)InteropCalls.WMessages.Keyup);
                InteropCalls.PostMessage(_myHandle, (uint)InteropCalls.WMessages.Keyup, (IntPtr)Keys.ControlKey, IntPtr.Zero);
            }
        }

        public void PerformCompleteKeypress(Keys key)
        {
            if (_myMethod.Equals(PredefinedData.AutomationMethods.SendMessage))
            {
                InteropCalls.SendMessage(_myHandle, (uint)InteropCalls.WMessages.Keydown,
                                         (IntPtr)key, IntPtr.Zero);

                InteropCalls.SendMessage(_myHandle, (uint)InteropCalls.WMessages.Keyup,
                                         (IntPtr)key, IntPtr.Zero);
            }



            else if (_myMethod.Equals(PredefinedData.AutomationMethods.PostMessage))
            {
                InteropCalls.PostMessage(_myHandle, (uint)InteropCalls.WMessages.Keydown,
                                         (IntPtr)key, IntPtr.Zero);

                InteropCalls.PostMessage(_myHandle, (uint)InteropCalls.WMessages.Keyup,
                                         (IntPtr)key, IntPtr.Zero);
            }
        }
    }
}
