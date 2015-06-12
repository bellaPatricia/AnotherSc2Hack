/**
 * This class is a container for the entire Maphack (overlay)- controls.
 * Basically, it holds other containers and a few controls to manage the 
 * maphack filter.
 * 
 * The maphack filter is implemented here and so is it's logic.
 * Basically, you add a unit to the filter, the unit's ID get's listed into
 * the listview and the information (unitId & color) get updated.
 * 
 * This works instantly.
 * 
 * 
 * Author: bellaPatricia
 * Date: 08 - February - 2015
 * */

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using AnotherSc2Hack.Classes.BackEnds;
using Utilities.ExtensionMethods;
using AnotherSc2Hack.Classes.FrontEnds.Custom_Controls;
using AnotherSc2Hack.Classes.FrontEnds.MainHandler;
using PredefinedTypes;

namespace AnotherSc2Hack.Classes.FrontEnds.Container
{
    public partial class PanelOverlayMaphack : UserControl
    {
        #region Variables

        private readonly LanguageString _lstrChMaphackFilterUnit = new LanguageString("lstrChMaphackFilterUnit", "Unit");
        private readonly LanguageString _lstrMaphackFilterRemoveItem = new LanguageString("lstrMaphackFilterRemoveItem", "Remove selection");
        private readonly LanguageString _lstrMaphackFilterMessageAddUnitText = new LanguageString("lstrMaphackFilterMessageAddUnitText", "Unit is already used!");
        private readonly LanguageString _lstrMaphackFilterMessageAddUnitHeader = new LanguageString("lstrMaphackFilterMessageAddUnitHeader", "Ouch!");

        #endregion

        #region Getter/Setter

        public Dictionary<UnitId, Color> LUnitFilter { get; private set; }

        #endregion

        #region Constructor

        public PanelOverlayMaphack()
        {
            InitializeComponent();

            LUnitFilter = new Dictionary<UnitId, Color>();

            _lstrChMaphackFilterUnit.TextChanged += _lstrChMaphackFilterUnit_TextChanged;
            _lstrMaphackFilterRemoveItem.TextChanged += _lstrChMaphackFilterRemoveItem_TextChanged;
        }

        #endregion

        #region Event Methods

        void _lstrChMaphackFilterRemoveItem_TextChanged(object sender, EventArgs e)
        {
            tsmRemoveItems.Text = _lstrMaphackFilterRemoveItem.Text;
        }

        void _lstrChMaphackFilterUnit_TextChanged(object sender, EventArgs e)
        {
            chMaphackfilterUnit.Text = _lstrChMaphackFilterUnit.Text;
        }

        private void icbMaphackBasicsUnitSelection_SelectedIndexChanged(object sender, EventArgs e)
        {
            var unit = (ImageComboItem)icbMaphackBasicsUnitSelection.SelectedItem;
            AddUnit(unit.UnitId);
        }

        private void btnMaphackBasicsUnitColor_Click(object sender, EventArgs e)
        {
            var cl = new ColorDialog();

            cl.ShowDialog();

            foreach (ListViewItem selectedItem in lstvMaphackBasicsUnitFilter.SelectedItems)
            {
                var id =
                (UnitId)
                    Enum.Parse(typeof(UnitId), selectedItem.Text);

                LUnitFilter[id] = cl.Color;
                AddUnitToSettings(id, cl.Color);
            }

            RefreshListview();
        }

        private void lstvMaphackBasicsUnitFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstvMaphackBasicsUnitFilter.SelectedIndices.Count != 1)
                return;

            var id =
                (UnitId)
                    Enum.Parse(typeof(UnitId), lstvMaphackBasicsUnitFilter.SelectedItems[0].Text);

            if (LUnitFilter.ContainsKey(id))
                btnMaphackBasicsUnitColor.BackColor = LUnitFilter[id];
        }

        private void cmsListviewContext_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Text == _lstrMaphackFilterRemoveItem.Text)
            {
                RemoveSelectedItems();
            }
        }

        private void lstvMaphackBasicsUnitFilter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Delete)
                return;

            RemoveSelectedItems();
        }

        #endregion

        #region Public Methods


        public void RefreshListview()
        {
            foreach (ListViewItem item in lstvMaphackBasicsUnitFilter.Items)
            {
                var id =
                (UnitId)
                    Enum.Parse(typeof(UnitId), item.Text);

                if (LUnitFilter.ContainsKey(id))
                {
                    item.BackColor = LUnitFilter[id];
                }

                else
                {
                    lstvMaphackBasicsUnitFilter.Items.Remove(item);
                }
            }

            lstvMaphackBasicsUnitFilter.Columns[0].Width = -2;
        }

        public void AddUnitsToListview()
        {
            foreach (var key in LUnitFilter.Keys)
            {
                var items = lstvMaphackBasicsUnitFilter.Items.Find(key.ToString(), false);

                if (items.Length <= 0)
                {
                    var lvi = new ListViewItem(key.ToString());
                    lvi.Name = key.ToString();
                    lvi.BackColor = LUnitFilter[key];

                    lstvMaphackBasicsUnitFilter.Items.Add(lvi);
                    lstvMaphackBasicsUnitFilter.Columns[0].Width = -2;
                }

            }

            RefreshListview();
        }



        #endregion

        #region Private Methods

        private void AddUnitToSettings(UnitId unitId, Color clColor)
        {
            var myParent = (NewMainHandler)this.FindParent(String.Empty, typeof(NewMainHandler));

            var index = myParent.PSettings.PreferenceAll.OverlayMaphack.UnitIds.FindIndex(x => x == unitId);


            if (index == -1)
            {
                myParent.PSettings.PreferenceAll.OverlayMaphack.UnitIds.Add(unitId);
                myParent.PSettings.PreferenceAll.OverlayMaphack.UnitColors.Add(clColor);
            }

            else
            {
                myParent.PSettings.PreferenceAll.OverlayMaphack.UnitIds[index] = unitId;
                myParent.PSettings.PreferenceAll.OverlayMaphack.UnitColors[index] = clColor;
            }
        }

        private void RemoveUnitFromSettings(UnitId unitId)
        {
            var myParent = (NewMainHandler)this.FindParent(String.Empty, typeof(NewMainHandler));

            var index = myParent.PSettings.PreferenceAll.OverlayMaphack.UnitIds.FindIndex(x => x == unitId);

            if (index == -1)
                return;

            myParent.PSettings.PreferenceAll.OverlayMaphack.UnitIds.RemoveAt(index);
            myParent.PSettings.PreferenceAll.OverlayMaphack.UnitColors.RemoveAt(index);
        }

        private void AddUnit(UnitId unitId)
        {
            if (LUnitFilter.ContainsKey(unitId))
            {
                new AnotherMessageBox().Show(_lstrMaphackFilterMessageAddUnitText.ToString(), _lstrMaphackFilterMessageAddUnitHeader.ToString());

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

            var cl = new Color().GetRandomColor();
            LUnitFilter.Add(unitId, cl);

            AddUnitsToListview();
            AddUnitToSettings(unitId, cl);
        }

        private void RemoveSelectedItems()
        {
            foreach (ListViewItem selectedItem in lstvMaphackBasicsUnitFilter.SelectedItems)
            {
                var id =
                (UnitId)
                    Enum.Parse(typeof(UnitId), selectedItem.Text);

                LUnitFilter.Remove(id);
                RemoveUnitFromSettings(id);
            }

            RefreshListview();
        }

        #endregion
    }
}
