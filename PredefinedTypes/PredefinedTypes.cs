/* PredefinedTypes.cs
 * Written: 31 August 2013
 * by bellaPatricia
 * 
 * This file represents all custom types, enumerations, subclasses and struct used in this tool
 * Those subclasses might be split up into seperate files in the futore
 * 
 * 07-Feb-2014 (bellaPatricia)
 * ===========================
 * Changes various structs to classes
 * Those classes allow you to save codelines and work.
 * In addition, you can manipulate the elements of a class without any nasty structhacking, making the code more readable.
 * 
 * 
 * 
 * NOTE: To use this, you have to recompile in Release mode so it get's refreshed (The assembly is pointed to the release version, not debug)!
 */

using System.Windows.Forms;

namespace PredefinedTypes
{
    public enum IsDeveloper
    {
        Undefined = 0,
        False = 1,
        True = 2
    };

    public enum Automation
    {
        WorkerProduction,
        Inject,
        Production,
        Testing,
    };

    public enum MouseButtons
    {
        MouseLeft,
        MouseRight,
        MouseMiddle,
        MouseLeftDown,
        MouseLeftUp,
        MouseRightDown,
        MouseRightUp,
        MouseMiddleDown,
        MouseMiddleUp,
    };

    public enum GroupSelection
    {
        Group0 = Keys.D0,
        Group1 = Keys.D1,
        Group2 = Keys.D2,
        Group3 = Keys.D3,
        Group4 = Keys.D4,
        Group5 = Keys.D5,
        Group6 = Keys.D6,
        Group7 = Keys.D7,
        Group8 = Keys.D8,
        Group9 = Keys.D9,
    }

    public enum AutomationMethods
    {
        SendMessage,
        PostMessage,
    }

    public enum CustomWindowStyles
    {
        Clickable,
        NotClickable,
    }
}