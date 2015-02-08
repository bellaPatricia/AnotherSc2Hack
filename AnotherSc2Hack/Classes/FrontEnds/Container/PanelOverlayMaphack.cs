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
using AnotherSc2Hack.Classes.ExtensionMethods;
using AnotherSc2Hack.Classes.FrontEnds.MainHandler;
using Predefined;

namespace AnotherSc2Hack.Classes.FrontEnds.Container
{
    public partial class PanelOverlayMaphack : UserControl
    {
        #region Getter/Setter

        public Dictionary<PredefinedData.UnitId, Color> LUnitFilter { get; private set; }

        #endregion

        #region Constructor

        public PanelOverlayMaphack()
        {
            InitializeComponent();

            LUnitFilter = new Dictionary<PredefinedData.UnitId, Color>();
        }

        #endregion

        #region Event Methods
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
                (PredefinedData.UnitId)
                    Enum.Parse(typeof(PredefinedData.UnitId), selectedItem.Text);

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
                (PredefinedData.UnitId)
                    Enum.Parse(typeof(PredefinedData.UnitId), lstvMaphackBasicsUnitFilter.SelectedItems[0].Text);

            if (LUnitFilter.ContainsKey(id))
                btnMaphackBasicsUnitColor.BackColor = LUnitFilter[id];
        }

        private void cmsListviewContext_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Text.Contains("Remove"))
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
                (PredefinedData.UnitId)
                    Enum.Parse(typeof(PredefinedData.UnitId), item.Text);

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

        private void AddUnitToSettings(PredefinedData.UnitId unitId, Color clColor)
        {
            var myParent = (NewMainHandler)this.FindParent(String.Empty, typeof(NewMainHandler));

            var index = myParent.PSettings.MaphackUnitIds.FindIndex(x => x == unitId);


            if (index == -1)
            {
                myParent.PSettings.MaphackUnitIds.Add(unitId);
                myParent.PSettings.MaphackUnitColors.Add(clColor);
            }

            else
            {
                myParent.PSettings.MaphackUnitIds[index] = unitId;
                myParent.PSettings.MaphackUnitColors[index] = clColor;
            }
        }

        private void RemoveUnitFromSettings(PredefinedData.UnitId unitId)
        {
            var myParent = (NewMainHandler)this.FindParent(String.Empty, typeof(NewMainHandler));

            var index = myParent.PSettings.MaphackUnitIds.FindIndex(x => x == unitId);

            if (index == -1)
                return;

            myParent.PSettings.MaphackUnitIds.RemoveAt(index);
            myParent.PSettings.MaphackUnitColors.RemoveAt(index);
        }

        private void AddUnit(PredefinedData.UnitId unitId)
        {
            if (LUnitFilter.ContainsKey(unitId))
            {
                MessageBox.Show("Unit is already used!", "Ooch!");

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
                (PredefinedData.UnitId)
                    Enum.Parse(typeof(PredefinedData.UnitId), selectedItem.Text);

                LUnitFilter.Remove(id);
                RemoveUnitFromSettings(id);
            }

            RefreshListview();
        }

        #endregion
    }
}
