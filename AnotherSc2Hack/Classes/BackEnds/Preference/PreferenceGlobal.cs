using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnotherSc2Hack.Classes.BackEnds.Preference
{
    public class PreferenceGlobal
    {
        public int DataRefresh { get; set; }
        public int DrawingRefresh { get; set; }
        public string Language { get; set; }
        public Keys ChangeSizeAndPosition { get; set; }
        public bool OnlyDrawWhenUnpaused { get; set; }
        public bool DrawOnlyInForeground { get; set; }

        public PreferenceGlobal()
        {
            DataRefresh = 100;
            DrawingRefresh = 100;
            Language = "English";
            ChangeSizeAndPosition = Keys.NumPad0;
        }
    }
}
