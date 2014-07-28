using System.Windows.Forms;

namespace AnotherSc2Hack.Classes.FrontEnds
{
    public partial class Hotkeys : AbstractUserControl
    {
        public Hotkeys()
        {
            InitializeComponent();
        }
        public Keys Hotkey1 { get; private set; }
        public Keys Hotkey2 { get; private set; }
        public Keys Hotkey3 { get; private set; }

        private void txtHotkey1_KeyDown(object sender, KeyEventArgs e)
        {
            Hotkey1 = txtHotkey1.HotKeyValue;
            txtHotkey2.Focus();
        }

        private void txtHotkey2_KeyDown(object sender, KeyEventArgs e)
        {
            Hotkey2 = txtHotkey1.HotKeyValue;
            txtHotkey3.Focus();
        }

        private void txtHotkey3_KeyDown(object sender, KeyEventArgs e)
        {
            Hotkey3 = txtHotkey1.HotKeyValue;
        }
    }
}
