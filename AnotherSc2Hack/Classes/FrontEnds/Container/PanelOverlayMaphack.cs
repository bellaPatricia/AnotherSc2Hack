using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AnotherSc2Hack.Classes.ExtensionMethods;
using AnotherSc2Hack.Classes.FrontEnds.MainHandler;
using Predefined;

namespace AnotherSc2Hack.Classes.FrontEnds.Container
{
    public partial class PanelOverlayMaphack : UserControl
    {
        public Color SelectedUnitColor { get; private set; }
        public Dictionary<PredefinedData.UnitId, Color> LUnitFilter { get; private set; }
        

        public PanelOverlayMaphack()
        {
            InitializeComponent();

            LUnitFilter = new Dictionary<PredefinedData.UnitId, Color>();
            SelectedUnitColor = Color.Red;
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

            SelectedUnitColor = cl.Color;

            foreach (ListViewItem selectedItem in lstvMaphackBasicsUnitFilter.SelectedItems)
            {
                var id =
                (PredefinedData.UnitId)
                    Enum.Parse(typeof(PredefinedData.UnitId), selectedItem.Text);

                LUnitFilter[id] = cl.Color;
            }

            RefreshListview();
        }

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

            
           
            SyncPreferences();
        }

        private void SyncPreferences()
        {
            var myParent = (NewMainHandler)this.FindParent(String.Empty, typeof(NewMainHandler));
            

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
        }

        private void lstvMaphackBasicsUnitFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstvMaphackBasicsUnitFilter.SelectedIndices.Count != 1)
                return;

            var id =
                (PredefinedData.UnitId)
                    Enum.Parse(typeof (PredefinedData.UnitId), lstvMaphackBasicsUnitFilter.SelectedItems[0].Text);

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

        private void RemoveSelectedItems()
        {
            foreach (ListViewItem selectedItem in lstvMaphackBasicsUnitFilter.SelectedItems)
            {
                var id =
                (PredefinedData.UnitId)
                    Enum.Parse(typeof (PredefinedData.UnitId), selectedItem.Text);

                LUnitFilter.Remove(id);
            }

           RefreshListview();
        }

        private void lstvMaphackBasicsUnitFilter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Delete)
                return;

            RemoveSelectedItems();
        }
    }
}
