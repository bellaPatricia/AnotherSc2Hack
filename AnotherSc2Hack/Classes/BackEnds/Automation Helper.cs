using System;
using System.Windows.Forms;
using PredefinedTypes;
using Interop = Utilities.InteropCalls.InteropCalls;

namespace AnotherSc2Hack.Classes.BackEnds
{
    class AutomationHelper
    {
        private readonly IntPtr _myHandle;
        private readonly AutomationMethods _myMethod;

        public AutomationHelper(IntPtr handle, AutomationMethods method)
        {
            _myHandle = handle;
            _myMethod = method;
        }

        public void SelectGroup(GroupSelection group)
        {
            if (_myMethod.Equals(AutomationMethods.SendMessage))
            {
                Interop.SendMessage(_myHandle, (uint)Interop.WMessages.Keydown, (IntPtr)group, IntPtr.Zero);
                Interop.SendMessage(_myHandle, (uint)Interop.WMessages.Keyup, (IntPtr)group, IntPtr.Zero);
            }

            else if (_myMethod.Equals(AutomationMethods.PostMessage))
            {
                Interop.PostMessage(_myHandle, (uint)Interop.WMessages.Keydown, (IntPtr)group, IntPtr.Zero);
                Interop.PostMessage(_myHandle, (uint)Interop.WMessages.Keyup, (IntPtr)group, IntPtr.Zero);
            }
        }

        public void AssignGroup(GroupSelection group)
        {
            if (_myMethod.Equals(AutomationMethods.SendMessage))
            {
                Interop.SendMessage(_myHandle, (uint)Interop.WMessages.Keydown, (IntPtr)Keys.ControlKey, IntPtr.Zero);
                Interop.SendMessage(_myHandle, (uint) Interop.WMessages.Keydown, (IntPtr) group,
                                         (IntPtr) Interop.WMessages.Keyup);
                Interop.SendMessage(_myHandle, (uint)Interop.WMessages.Keyup, (IntPtr)Keys.ControlKey, IntPtr.Zero);
            }

            else if (_myMethod.Equals(AutomationMethods.PostMessage))
            {
                Interop.PostMessage(_myHandle, (uint)Interop.WMessages.Keydown, (IntPtr)Keys.ControlKey, IntPtr.Zero);
                Interop.PostMessage(_myHandle, (uint)Interop.WMessages.Keydown, (IntPtr)group,
                                         (IntPtr)Interop.WMessages.Keyup);
                Interop.PostMessage(_myHandle, (uint)Interop.WMessages.Keyup, (IntPtr)Keys.ControlKey, IntPtr.Zero);
            }
        }

        public void PerformCompleteKeypress(Keys key)
        {
            if (_myMethod.Equals(AutomationMethods.SendMessage))
            {
                Interop.SendMessage(_myHandle, (uint)Interop.WMessages.Keydown,
                                         (IntPtr)key, IntPtr.Zero);

                Interop.SendMessage(_myHandle, (uint)Interop.WMessages.Keyup,
                                         (IntPtr)key, IntPtr.Zero);
            }



            else if (_myMethod.Equals(AutomationMethods.PostMessage))
            {
                Interop.PostMessage(_myHandle, (uint)Interop.WMessages.Keydown,
                                         (IntPtr)key, IntPtr.Zero);

                Interop.PostMessage(_myHandle, (uint)Interop.WMessages.Keyup,
                                         (IntPtr)key, IntPtr.Zero);
            }
        }
    }
}
