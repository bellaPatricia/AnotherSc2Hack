using System;
using System.Windows.Forms;

namespace AnotherSc2Hack.Classes.ExtensionMethods
{
    public static class ExtentControl
    {
        /// <summary>
        /// Finds a parent recursively based on the parenttype or name
        /// </summary>
        /// <param name="control">This control</param>
        /// <param name="parentname">The target parentname</param>
        /// <param name="parentType">The target parenttype</param>
        /// <returns>The parent we wanted to find</returns>
        public static Control FindParent(this Control control, string parentname, Type parentType = null)
        {
            if (control.Parent.Name == parentname)
                return control.Parent;

            if (control.Parent.GetType() == parentType)
                return control.Parent;

            return FindParent(control.Parent, parentname, parentType);
        }
    }
}
