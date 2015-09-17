using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using PredefinedTypes;
using Interop = Utilities.InteropCalls.InteropCalls;

namespace AnotherSc2Hack.Classes.BackEnds
{
    class Simulation
    {

        public class Keyboard
        {
            #region Easy Key- Press (Keydown + KeyUp)


            /// <summary>
            /// This will press an undefined amount of keys.
            /// The first key gets pressed and released, then the next key.
            /// </summary>
            /// <param name="handle">The target handle</param>
            /// <param name="key">The key you wish to use</param>
            public static void PressKeysOneByOne(IntPtr handle, params Keys[] key)
            {
                foreach (var t in key)
                {
                    Interop.SendMessage(handle, (uint) Interop.WMessages.Keydown, (IntPtr) t,
                        (IntPtr) Interop.WMessages.Keyup);
                }
            }

            /// <summary>
            /// This will press an undefined amount of keys.
            /// The first key gets pressed and released, then the next key.
            /// </summary>
            /// <param name="handle">The target handle</param>
            /// <param name="times">How often you'd like to execute this</param>
            /// <param name="key">The key you wish to use</param>
            public static void PressKeysOneByOne(IntPtr handle,  Int32 times, params Keys[] key)
            {
                for (var j = 0; j < times; j++)
                {
                    foreach (var t in key)
                    {
                        Interop.SendMessage(handle, (uint) Interop.WMessages.Keydown, (IntPtr) t,
                            (IntPtr) Interop.WMessages.Keyup);
                    }
                }
            }

            /// <summary>
            /// This will press (and hold) an undefined amount of keys.
            /// The keypress will begin with the first item and end with the last item.
            /// The keydown will begin with the first item and end with the last item.
            /// </summary>
            /// <param name="handle">The target handle</param>
            /// <param name="key">The key you wish to use</param>
            public static void PressKeysDownAndUpSync(IntPtr handle, params Keys[] key)
            {
                foreach (var t in key)
                {
                    Interop.SendMessage(handle, (uint)Interop.WMessages.Keydown, (IntPtr)t,
                        IntPtr.Zero);
                }


                foreach (var t in key)
                {
                    Interop.SendMessage(handle, (uint)Interop.WMessages.Keyup, (IntPtr)t,
                        IntPtr.Zero);
                }
            }

            /// <summary>
            /// This will press (and hold) an undefined amount of keys.
            /// The keypress will begin with the first item and end with the last item.
            /// The keydown will begin with the last item and end with the first item.
            /// </summary>
            /// <param name="handle">The target handle</param>
            /// <param name="key">The key you wish to use</param>
            public static void PressKeysDownAndUpAsync(IntPtr handle, params Keys[] key)
            {
                foreach (var t in key)
                {
                    Interop.SendMessage(handle, (uint)Interop.WMessages.Keydown, (IntPtr)t,
                        IntPtr.Zero);
                }

                for (var i = key.Length - 1; i >= 0; i--)
                {
                    Interop.SendMessage(handle, (uint)Interop.WMessages.Keyup, (IntPtr)key[i],
                                             IntPtr.Zero);
                }
            }

            #endregion

            public static void PressKey(IntPtr handle, Interop.WMessages msg, params Keys[] keys)
            {
                foreach (var k in keys)
                {
                    Interop.SendMessage(handle, (uint)msg, (IntPtr)k,
                        IntPtr.Zero);
                }
            }

            public static void Keyboard_SimulateKey(IntPtr handle, Keys key, Int32 times)
            {
                for (var i = 0; i < times; i++)
                {
                    /* Key Down */
                    Interop.SendMessage(handle, (uint) Interop.WMessages.Keydown, (IntPtr) key, IntPtr.Zero);

                    /* Key Up */
                    Interop.SendMessage(handle, (uint) Interop.WMessages.Keyup, (IntPtr) key, IntPtr.Zero);

                    Thread.Sleep(1);
                }
            }

            public static void Keyboard_SimulateKeys(IntPtr handle, List<Keys> keys)
            {
                /* Key Down */
                foreach (var t in keys)
                    Interop.SendMessage(handle, (uint) Interop.WMessages.Keydown, (IntPtr) t,
                        IntPtr.Zero);

                /* Key Up */
                foreach (var t in keys)
                    Interop.SendMessage(handle, (uint) Interop.WMessages.Keyup, (IntPtr) t, IntPtr.Zero);
            }

            public static void Keyboard_SimulateKey(IntPtr handle, Keys key)
            {
                Interop.SendMessage(handle, (uint) Interop.WMessages.Keydown, (IntPtr) key,
                                         (IntPtr) Interop.WMessages.Keyup);
            }
        }

        public class Mouse
        {
            public static Int32 MakeLParam(Point ptr)
            {
                return ((ptr.Y << 16) | (ptr.X & 0xffff));
            }

            public static IntPtr MakeLParam(int loWord, int hiWord)
            {
                return (IntPtr)((hiWord << 16) | (loWord & 0xffff));
            }

            public static void Click(IntPtr handle, PredefinedTypes.MouseButtons btn, params Point[] position)
            {
                foreach (var t in position)
                {
                    switch (btn)
                    {
                        case PredefinedTypes.MouseButtons.MouseLeft:
                            Interop.SendMessage(handle, (uint) Interop.WMessages.Lbuttondown, IntPtr.Zero,
                                (IntPtr) MakeLParam(t));
                            Interop.SendMessage(handle, (uint)Interop.WMessages.Lbuttonup, IntPtr.Zero,
                                (IntPtr)MakeLParam(t));
                            break;

                        case PredefinedTypes.MouseButtons.MouseRight:
                            Interop.SendMessage(handle, (uint) Interop.WMessages.Rbuttondown, IntPtr.Zero,
                                (IntPtr) MakeLParam(t));
                            Interop.SendMessage(handle, (uint)Interop.WMessages.Rbuttonup, IntPtr.Zero,
                                (IntPtr)MakeLParam(t));
                            break;

                        case PredefinedTypes.MouseButtons.MouseMiddle:
                            Interop.SendMessage(handle, (uint)Interop.WMessages.Mbuttondown, IntPtr.Zero,
                                (IntPtr)MakeLParam(t));
                            Interop.SendMessage(handle, (uint)Interop.WMessages.Mbuttonup, IntPtr.Zero,
                                (IntPtr)MakeLParam(t));
                            break;

                        case PredefinedTypes.MouseButtons.MouseLeftDown:
                            Interop.SendMessage(handle, (uint)Interop.WMessages.Lbuttondown, IntPtr.Zero,
                                (IntPtr)MakeLParam(t));
                            break;

                        case PredefinedTypes.MouseButtons.MouseLeftUp:
                            Interop.SendMessage(handle, (uint)Interop.WMessages.Lbuttonup, IntPtr.Zero,
                                (IntPtr)MakeLParam(t));
                            break;

                        case PredefinedTypes.MouseButtons.MouseRightDown:
                            Interop.SendMessage(handle, (uint)Interop.WMessages.Rbuttondown, IntPtr.Zero,
                                (IntPtr)MakeLParam(t));
                            break;

                        case PredefinedTypes.MouseButtons.MouseRightUp:
                            Interop.SendMessage(handle, (uint)Interop.WMessages.Rbuttonup, IntPtr.Zero,
                                (IntPtr)MakeLParam(t));
                            break;

                        case PredefinedTypes.MouseButtons.MouseMiddleDown:
                            Interop.SendMessage(handle, (uint)Interop.WMessages.Mbuttondown, IntPtr.Zero,
                                (IntPtr)MakeLParam(t));
                            break;

                        case PredefinedTypes.MouseButtons.MouseMiddleUp:
                            Interop.SendMessage(handle, (uint)Interop.WMessages.Mbuttonup, IntPtr.Zero,
                                (IntPtr)MakeLParam(t));
                            break;
                    }
                }
            }
        }
    }
}
