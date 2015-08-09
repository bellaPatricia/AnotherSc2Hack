using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AnotherSc2Hack.Classes.BackEnds;
using AnotherSc2Hack.Classes.DataStructures.Preference;
using AnotherSc2Hack.Classes.FrontEnds.MainHandler;
using PredefinedTypes;
using Utilities.ExtensionMethods;

namespace AnotherSc2Hack.Classes.FrontEnds.Custom_Controls
{
    public partial class AlertConfiguration : Form
    {
        private readonly LanguageString _lstrAnotherMessageBoxOk = new LanguageString("lstrAnotherMessageBoxOk", "Ok");
        private readonly LanguageString _lstrAnotherMessageBoxCancel = new LanguageString("lstrAnotherMessageBoxCancel", "Cancel");
        private readonly LanguageString _lstrChMaphackFilterUnit = new LanguageString("lstrChMaphackFilterUnit", "Unit");
        private readonly LanguageString _lstrMaphackFilterRemoveItem = new LanguageString("lstrMaphackFilterRemoveItem", "Remove selection");
        private readonly LanguageString _lstrMaphackFilterMessageAddUnitText = new LanguageString("lstrMaphackFilterMessageAddUnitText", "Unit is already used!");
        private readonly LanguageString _lstrMaphackFilterMessageAddUnitHeader = new LanguageString("lstrMaphackFilterMessageAddUnitHeader", "Ouch!");

        public AlertConfiguration()
        {
            InitializeComponent();
        }

        public PreferenceManager PSettings { get; private set; }
        public AlertConfiguration(PreferenceManager pSettings)
        {
            PSettings = pSettings;

            InitializeComponent();

            btnOk.Text = _lstrAnotherMessageBoxOk.Text;
            btnCancel.Text = _lstrAnotherMessageBoxCancel.Text;
            chAlertConfigurationFilterUnit.Text = _lstrChMaphackFilterUnit.Text;
            tsmRemoveItems.Text = _lstrMaphackFilterRemoveItem.Text;
            tsmRemoveItems.Click += TsmRemoveItems_Click;

            AddUnitsToListview();

            Text = "Alert";
        }

        public override sealed string Text
        {
            get { return base.Text; }
            set { base.Text = value; }
        }

        private void TsmRemoveItems_Click(object sender, EventArgs e)
        {
            RemoveSelectedItems();   
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void lstvAlertConfigurationFilter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control &&
                e.KeyCode == Keys.A)
            {
                foreach (ListViewItem item in lstvAlertConfigurationFilter.Items)
                {
                    item.Selected = true;
                }
            }


            if (e.KeyCode != Keys.Delete)
                return;

            RemoveSelectedItems();
        }

        private void RemoveSelectedItems()
        {
            foreach (ListViewItem selectedItem in lstvAlertConfigurationFilter.SelectedItems)
            {
                var id =
                (UnitId)
                    Enum.Parse(typeof(UnitId), selectedItem.Text);

                RemoveUnitFromSettings(id);
            }

            RemoveItemFromListview();
        }

        private void RemoveItemFromListview()
        {
            foreach (ListViewItem item in lstvAlertConfigurationFilter.Items)
            {
                var id =
                (UnitId)
                    Enum.Parse(typeof(UnitId), item.Text);

                if (!PSettings.PreferenceAll.OverlayAlert.UnitIds.Contains(id))
                {
                    var iOldIndex = lstvAlertConfigurationFilter.SelectedIndices[0];
                    lstvAlertConfigurationFilter.Items.Remove(item);

                }

            }

            lstvAlertConfigurationFilter.Columns[0].Width = -2;
            RefrestListviewItems();
        }

        private void RefrestListviewItems()
        {
            for (var i = 0; i < lstvAlertConfigurationFilter.Items.Count; i++)
            {
                var itemColor = Color.White;
                if (i%2 == 0)
                {
                    itemColor = Color.WhiteSmoke;
                }

                lstvAlertConfigurationFilter.Items[i].BackColor = itemColor;
            }
        }

        private void RemoveUnitFromSettings(UnitId unitId)
        {
            if (PSettings.PreferenceAll.OverlayAlert.UnitIds.Contains(unitId))
                PSettings.PreferenceAll.OverlayAlert.UnitIds.Remove(unitId);
        }

        private void icbAlertConfigurationSelection_SelectedIndexChanged(object sender, EventArgs e)
        {
            var unit = (ImageComboItem)icbAlertConfigurationSelection.SelectedItem;
            AddUnit(unit.UnitId);
        }

        private void AddUnit(UnitId unitId)
        {
            if (PSettings.PreferenceAll.OverlayAlert.UnitIds.Contains(unitId))
            {
                new AnotherMessageBox().Show(_lstrMaphackFilterMessageAddUnitText.ToString(), _lstrMaphackFilterMessageAddUnitHeader.ToString());

                var items = lstvAlertConfigurationFilter.Items.Find(unitId.ToString(), false);

                if (items.Length <= 0)
                    return;

                foreach (ListViewItem item in lstvAlertConfigurationFilter.Items)
                {
                    item.Selected = false;
                }

                items[0].Selected = true;

                return;
            }

            AddUnitToSettings(unitId);
            AddUnitsToListview();
            
        }

        private void AddUnitsToListview()
        {
            foreach (var key in PSettings.PreferenceAll.OverlayAlert.UnitIds)
            {
                var items = lstvAlertConfigurationFilter.Items.Find(key.ToString(), false);

                if (items.Length <= 0)
                {
                    var lvi = new ListViewItem(key.ToString());
                    lvi.Name = key.ToString();

                    if (lstvAlertConfigurationFilter.Items.Count%2 == 0)
                        lvi.BackColor = Color.WhiteSmoke;

                    lstvAlertConfigurationFilter.Items.Add(lvi);
                    lstvAlertConfigurationFilter.Columns[0].Width = -2;
                }

            }

            RemoveItemFromListview();
        }

        private void AddUnitToSettings(UnitId unitId)
        {
            if (!PSettings.PreferenceAll.OverlayAlert.UnitIds.Contains(unitId))
                PSettings.PreferenceAll.OverlayAlert.UnitIds.Add(unitId);
        }

        //Draw a new border on the top and bottom of the panel
        private void DrawVerticalBorders(object sender, PaintEventArgs e)
        {
            var send = (Panel)sender;

            e.Graphics.DrawLine(new Pen(new SolidBrush(Color.FromArgb(193, 193, 193))), 0, 0, Width, 0);
            e.Graphics.DrawLine(new Pen(new SolidBrush(Color.FromArgb(193, 193, 193))), 0, send.Height - 1, Width, send.Height - 1);
        }

        private void AlertConfiguration_SizeChanged(object sender, EventArgs e)
        {
            chAlertConfigurationFilterUnit.Width = -2;
        }
    }
}
