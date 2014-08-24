/* 
 * Class to test some weird stuff (mainly temporary)
 * But I want to have it seperated from the actual code and keep it clean.. 
 * 24 - August - 2014
 * bellaPatricia */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using PredefinedTypes = Predefined.PredefinedData;

namespace AnotherSc2Hack.Classes
{
    public static class TempTestShitPlaing
    {
        public static void GetAllUnitIds()
        {
            var stuff = Enum.GetValues(typeof (PredefinedTypes.UnitId));

            foreach (var s in stuff)
            {
                Debug.WriteLine((int)s + ";1");
            }
        }
    }
}
