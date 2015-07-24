using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AnotherSc2Hack.Classes.DataStructures.Preference;
using AnotherSc2Hack.Classes.FrontEnds.MainHandler;
using PredefinedTypes;
using Utilities.ExtensionMethods;

namespace AnotherSc2Hack.Classes.FrontEnds.Custom_Controls
{
    public partial class AlertConfiguration : Form
    {
        public AlertConfiguration()
        {
            InitializeComponent();
        }

        public PreferenceManager PSettings { get; private set; }
        public AlertConfiguration(PreferenceManager pSettings)
        {
            PSettings = pSettings;

            InitializeComponent();

            AddUnitsToListview();
        }

        protected override void OnShown(EventArgs e)
        {
            Console.WriteLine("Shown");

            base.OnShown(e);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void lstvMaphackBasicsUnitFilter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Delete)
                return;

            RemoveSelectedItems();
        }

        private void RemoveSelectedItems()
        {
            foreach (ListViewItem selectedItem in lstvMaphackBasicsUnitFilter.SelectedItems)
            {
                var id =
                (UnitId)
                    Enum.Parse(typeof(UnitId), selectedItem.Text);

                RemoveUnitFromSettings(id);
            }

            ClearListview();
        }

        public void ClearListview()
        {
            foreach (ListViewItem item in lstvMaphackBasicsUnitFilter.Items)
            {
                var id =
                (UnitId)
                    Enum.Parse(typeof(UnitId), item.Text);

                if (!PSettings.PreferenceAll.OverlayAlert.UnitIds.Contains(id))
                {
                    var iOldIndex = lstvMaphackBasicsUnitFilter.SelectedIndices[0];
                    lstvMaphackBasicsUnitFilter.Items.Remove(item);

                }

            }

            lstvMaphackBasicsUnitFilter.Columns[0].Width = -2;
        }

        private void RemoveUnitFromSettings(UnitId unitId)
        {
            if (PSettings.PreferenceAll.OverlayAlert.UnitIds.Contains(unitId))
                PSettings.PreferenceAll.OverlayAlert.UnitIds.Remove(unitId);
        }

        private void icbMaphackBasicsUnitSelection_SelectedIndexChanged(object sender, EventArgs e)
        {
            var unit = (ImageComboItem)icbMaphackBasicsUnitSelection.SelectedItem;
            AddUnit(unit.UnitId);
        }

        private void AddUnit(UnitId unitId)
        {
            if (PSettings.PreferenceAll.OverlayAlert.UnitIds.Contains(unitId))
            {
                //new AnotherMessageBox().Show(_lstrMaphackFilterMessageAddUnitText.ToString(), _lstrMaphackFilterMessageAddUnitHeader.ToString());

                var items = lstvMaphackBasicsUnitFilter.Items.Find(unitId.ToString(), false);

                if (items.Length <= 0)
                    return;

                foreach (ListViewItem item in lstvMaphackBasicsUnitFilter.Items)
                {
                    item.Selected = false;
                }

                items[0].Selected = true;

                return;
            }

            AddUnitsToListview();
            AddUnitToSettings(unitId);
        }

        public void AddUnitsToListview()
        {
            foreach (var key in PSettings.PreferenceAll.OverlayAlert.UnitIds)
            {
                var items = lstvMaphackBasicsUnitFilter.Items.Find(key.ToString(), false);

                if (items.Length <= 0)
                {
                    var lvi = new ListViewItem(key.ToString());
                    lvi.Name = key.ToString();

                    if (lstvMaphackBasicsUnitFilter.Items.Count%2 == 0)
                        lvi.BackColor = Color.WhiteSmoke;

                    lstvMaphackBasicsUnitFilter.Items.Add(lvi);
                    lstvMaphackBasicsUnitFilter.Columns[0].Width = -2;
                }

            }

            ClearListview();
        }

        private void AddUnitToSettings(UnitId unitId)
        {
            if (!PSettings.PreferenceAll.OverlayAlert.UnitIds.Contains(unitId))
                PSettings.PreferenceAll.OverlayAlert.UnitIds.Add(unitId);
        }
    }
}
