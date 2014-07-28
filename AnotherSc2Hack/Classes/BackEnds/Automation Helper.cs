using System;
using System.Windows.Forms;
using PredefinedTypes = Predefined.PredefinedData;

namespace AnotherSc2Hack.Classes.BackEnds
{
    class AutomationHelper
    {
        private readonly IntPtr _myHandle = IntPtr.Zero;
        private readonly PredefinedTypes.AutomationMethods _myMethod = PredefinedTypes.AutomationMethods.PostMessage;

        public AutomationHelper(IntPtr handle, PredefinedTypes.AutomationMethods method)
        {
            _myHandle = handle;
            _myMethod = method;
        }

        public void SelectGroup(PredefinedTypes.GroupSelection group)
        {
            if (_myMethod.Equals(PredefinedTypes.AutomationMethods.SendMessage))
            {
                InteropCalls.SendMessage(_myHandle, (uint)InteropCalls.WMessages.Keydown, (IntPtr)group, IntPtr.Zero);
                InteropCalls.SendMessage(_myHandle, (uint)InteropCalls.WMessages.Keyup, (IntPtr)group, IntPtr.Zero);
            }

            else if (_myMethod.Equals(PredefinedTypes.AutomationMethods.PostMessage))
            {
                InteropCalls.PostMessage(_myHandle, (uint)InteropCalls.WMessages.Keydown, (IntPtr)group, IntPtr.Zero);
                InteropCalls.PostMessage(_myHandle, (uint)InteropCalls.WMessages.Keyup, (IntPtr)group, IntPtr.Zero);
            }
        }

        public void AssignGroup(PredefinedTypes.GroupSelection group)
        {
            if (_myMethod.Equals(PredefinedTypes.AutomationMethods.SendMessage))
            {
                InteropCalls.SendMessage(_myHandle, (uint)InteropCalls.WMessages.Keydown, (IntPtr)Keys.ControlKey, IntPtr.Zero);
                InteropCalls.SendMessage(_myHandle, (uint) InteropCalls.WMessages.Keydown, (IntPtr) group,
                                         (IntPtr) InteropCalls.WMessages.Keyup);
                InteropCalls.SendMessage(_myHandle, (uint)InteropCalls.WMessages.Keyup, (IntPtr)Keys.ControlKey, IntPtr.Zero);
            }

            else if (_myMethod.Equals(PredefinedTypes.AutomationMethods.PostMessage))
            {
                InteropCalls.PostMessage(_myHandle, (uint)InteropCalls.WMessages.Keydown, (IntPtr)Keys.ControlKey, IntPtr.Zero);
                InteropCalls.PostMessage(_myHandle, (uint)InteropCalls.WMessages.Keydown, (IntPtr)group,
                                         (IntPtr)InteropCalls.WMessages.Keyup);
                InteropCalls.PostMessage(_myHandle, (uint)InteropCalls.WMessages.Keyup, (IntPtr)Keys.ControlKey, IntPtr.Zero);
            }
        }

        public void PerformCompleteKeypress(Keys key)
        {
            if (_myMethod.Equals(PredefinedTypes.AutomationMethods.SendMessage))
            {
                InteropCalls.SendMessage(_myHandle, (uint)InteropCalls.WMessages.Keydown,
                                         (IntPtr)key, IntPtr.Zero);

                InteropCalls.SendMessage(_myHandle, (uint)InteropCalls.WMessages.Keyup,
                                         (IntPtr)key, IntPtr.Zero);
            }



            else if (_myMethod.Equals(PredefinedTypes.AutomationMethods.PostMessage))
            {
                InteropCalls.PostMessage(_myHandle, (uint)InteropCalls.WMessages.Keydown,
                                         (IntPtr)key, IntPtr.Zero);

                InteropCalls.PostMessage(_myHandle, (uint)InteropCalls.WMessages.Keyup,
                                         (IntPtr)key, IntPtr.Zero);
            }
        }
    }
}
