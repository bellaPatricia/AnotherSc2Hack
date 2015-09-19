using System;
using System.Windows.Forms;
using AnotherSc2Hack.Classes.BackEnds;

namespace AnotherSc2Hack.Classes.FrontEnds.Trainer
{
    public partial class Trainer : Form
    {
        readonly GameInfo _gInformation;
        private Int32 _iPlayerIndex = 0;

        private void Init()
        {
            InitializeComponent();
            FillListView();
        }

        public Trainer()
        {
            Init();
        }

        public Trainer(GameInfo inf)
        {
            _gInformation = inf;
            _gInformation.Memory.DesiredAccess = Memory.AllAccess;

            Init();
        }

        ~Trainer()
        {
            _gInformation.Memory.DesiredAccess = Memory.VmRead;
        }

        private void tmrMainTick_Tick(object sender, EventArgs e)
        {

        }

        private void FillListView()
        {
            /*
            var properties = TypeDescriptor.GetProperties(typeof(Player));

            for (int index = 0; index < properties.Count; index++)
            {
                var property = properties[index];
                var lwi = new ListViewItem();

                lwi.Text = property.Name;
                lwi.SubItems.Add(new ListViewItem.ListViewSubItem(lwi, property.PropertyType.ToString()));

                lvPlayerdata.Items.Add(lwi);

            }*/
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (_gInformation.Player == null)
                return;

            if (_iPlayerIndex + 1 < _gInformation.Player.Count)
                _iPlayerIndex++;

        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (_gInformation.Player == null)
                return;

            if (_iPlayerIndex == 0)
            {
                //Do nothing
            }

            else
                _iPlayerIndex--;


        }
    }
}
