using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using PredefinedTypes;
using PredefinedTypes = PredefinedTypes.PredefinedData;

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
                    InteropCalls.SendMessage(handle, (uint) InteropCalls.WMessages.Keydown, (IntPtr) t,
                        (IntPtr) InteropCalls.WMessages.Keyup);
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
                        InteropCalls.SendMessage(handle, (uint) InteropCalls.WMessages.Keydown, (IntPtr) t,
                            (IntPtr) InteropCalls.WMessages.Keyup);
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
                    InteropCalls.SendMessage(handle, (uint)InteropCalls.WMessages.Keydown, (IntPtr)t,
                        IntPtr.Zero);
                }


                foreach (var t in key)
                {
                    InteropCalls.SendMessage(handle, (uint)InteropCalls.WMessages.Keyup, (IntPtr)t,
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
                    InteropCalls.SendMessage(handle, (uint)InteropCalls.WMessages.Keydown, (IntPtr)t,
                        IntPtr.Zero);
                }

                for (var i = key.Length - 1; i >= 0; i--)
                {
                    InteropCalls.SendMessage(handle, (uint)InteropCalls.WMessages.Keyup, (IntPtr)key[i],
                                             IntPtr.Zero);
                }
            }

            #endregion

            public static void PressKey(IntPtr handle, InteropCalls.WMessages msg, params Keys[] keys)
            {
                foreach (var k in keys)
                {
                    InteropCalls.SendMessage(handle, (uint)msg, (IntPtr)k,
                        IntPtr.Zero);
                }
            }

            public static void Keyboard_SimulateKey(IntPtr handle, Keys key, Int32 times)
            {
                for (var i = 0; i < times; i++)
                {
                    /* Key Down */
                    InteropCalls.SendMessage(handle, (uint) InteropCalls.WMessages.Keydown, (IntPtr) key, IntPtr.Zero);

                    /* Key Up */
                    InteropCalls.SendMessage(handle, (uint) InteropCalls.WMessages.Keyup, (IntPtr) key, IntPtr.Zero);

                    Thread.Sleep(1);
                }
            }

            public static void Keyboard_SimulateKeys(IntPtr handle, List<Keys> keys)
            {
                /* Key Down */
                foreach (var t in keys)
                    InteropCalls.SendMessage(handle, (uint) InteropCalls.WMessages.Keydown, (IntPtr) t,
                        IntPtr.Zero);

                /* Key Up */
                foreach (var t in keys)
                    InteropCalls.SendMessage(handle, (uint) InteropCalls.WMessages.Keyup, (IntPtr) t, IntPtr.Zero);
            }

            public static void Keyboard_SimulateKey(IntPtr handle, Keys key)
            {
                InteropCalls.SendMessage(handle, (uint) InteropCalls.WMessages.Keydown, (IntPtr) key,
                                         (IntPtr) InteropCalls.WMessages.Keyup);
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

            public static void Click(IntPtr handle, PredefinedData.MouseButtons btn, params Point[] position)
            {
                foreach (var t in position)
                {
                    switch (btn)
                    {
                        case PredefinedData.MouseButtons.MouseLeft:
                            InteropCalls.SendMessage(handle, (uint) InteropCalls.WMessages.Lbuttondown, IntPtr.Zero,
                                (IntPtr) MakeLParam(t));
                            InteropCalls.SendMessage(handle, (uint)InteropCalls.WMessages.Lbuttonup, IntPtr.Zero,
                                (IntPtr)MakeLParam(t));
                            break;

                        case PredefinedData.MouseButtons.MouseRight:
                            InteropCalls.SendMessage(handle, (uint) InteropCalls.WMessages.Rbuttondown, IntPtr.Zero,
                                (IntPtr) MakeLParam(t));
                            InteropCalls.SendMessage(handle, (uint)InteropCalls.WMessages.Rbuttonup, IntPtr.Zero,
                                (IntPtr)MakeLParam(t));
                            break;

                        case PredefinedData.MouseButtons.MouseMiddle:
                            InteropCalls.SendMessage(handle, (uint)InteropCalls.WMessages.Mbuttondown, IntPtr.Zero,
                                (IntPtr)MakeLParam(t));
                            InteropCalls.SendMessage(handle, (uint)InteropCalls.WMessages.Mbuttonup, IntPtr.Zero,
                                (IntPtr)MakeLParam(t));
                            break;

                        case PredefinedData.MouseButtons.MouseLeftDown:
                            InteropCalls.SendMessage(handle, (uint)InteropCalls.WMessages.Lbuttondown, IntPtr.Zero,
                                (IntPtr)MakeLParam(t));
                            break;

                        case PredefinedData.MouseButtons.MouseLeftUp:
                            InteropCalls.SendMessage(handle, (uint)InteropCalls.WMessages.Lbuttonup, IntPtr.Zero,
                                (IntPtr)MakeLParam(t));
                            break;

                        case PredefinedData.MouseButtons.MouseRightDown:
                            InteropCalls.SendMessage(handle, (uint)InteropCalls.WMessages.Rbuttondown, IntPtr.Zero,
                                (IntPtr)MakeLParam(t));
                            break;

                        case PredefinedData.MouseButtons.MouseRightUp:
                            InteropCalls.SendMessage(handle, (uint)InteropCalls.WMessages.Rbuttonup, IntPtr.Zero,
                                (IntPtr)MakeLParam(t));
                            break;

                        case PredefinedData.MouseButtons.MouseMiddleDown:
                            InteropCalls.SendMessage(handle, (uint)InteropCalls.WMessages.Mbuttondown, IntPtr.Zero,
                                (IntPtr)MakeLParam(t));
                            break;

                        case PredefinedData.MouseButtons.MouseMiddleUp:
                            InteropCalls.SendMessage(handle, (uint)InteropCalls.WMessages.Mbuttonup, IntPtr.Zero,
                                (IntPtr)MakeLParam(t));
                            break;
                    }
                }
            }
        }
    }
}
