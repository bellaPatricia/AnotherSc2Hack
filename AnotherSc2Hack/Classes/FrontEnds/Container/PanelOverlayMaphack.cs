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
        }

        private void AddUnit(PredefinedData.UnitId unitId)
        {
            if (LUnitFilter.ContainsKey(unitId))
            {
                MessageBox.Show("Unit is already used!", "Ooch!");
                return;
            }

            var cl = new Color().GetRandomColor();
            LUnitFilter.Add(unitId, cl);

            var lvi = new ListViewItem(unitId.ToString());
            lvi.SubItems.Add(cl.ToArgb().ToString());
            lvi.BackColor = cl;

            lstvMaphackBasicsUnitFilter.Items.Add(lvi);
            lstvMaphackBasicsUnitFilter.Columns[0].Width = -2;
        }
    }
}
