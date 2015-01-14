using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PredefinedTypes = Predefined.PredefinedData;
using AnotherSc2Hack.Classes.FrontEnds;

namespace AnotherSc2Hack.Classes.FrontEnds.Custom_Controls
{
    public partial class MaphackFilter : Form
    {
        public MaphackFilter()
        {
            InitializeComponent();

            FillProperties();
        }

        private void pnlFooter_Paint(object sender, PaintEventArgs e)
        {
            var send = (Panel)sender;

            e.Graphics.DrawLine(new Pen(new SolidBrush(Color.FromArgb(193, 193, 193))), 0, 0, Width, 0);
            e.Graphics.DrawLine(new Pen(new SolidBrush(Color.FromArgb(193, 193, 193))), 0, send.Height - 1, Width, send.Height - 1);
        }

        private void FillProperties()
        {
            icbMaphackFilterUnitProperties.Items.Clear();

            var propertyNames = Enum.GetNames(typeof(PredefinedTypes.TargetFilterFlag));

            for (var i = 0; i < propertyNames.Length; i++)
            {
                icbMaphackFilterUnitProperties.Items.Add(new ImageComboItem(propertyNames[i]));
            }
        }

        private void icbMaphackFilterUnits_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (icbMaphackFilterUnits.SelectedIndex > -1 &&
                icbMaphackFilterUnits.SelectedIndex < icbMaphackFilterUnits.Items.Count)
            {
                txtMaphackFilterAttributes.AppendText(icbMaphackFilterUnits.SelectedItem.ToString());
                ChangeEnabledStatus(false);
            }
        }

        private void btnMaphackFilterLogicalAnd_Click(object sender, EventArgs e)
        {
            txtMaphackFilterAttributes.AppendText("[AND]");
            ChangeEnabledStatus(true);
        }

        private void btnMaphackFilterLogicalOr_Click(object sender, EventArgs e)
        {
            txtMaphackFilterAttributes.AppendText("[OR]");
            ChangeEnabledStatus(true);
        }

        private void btnMaphackFiltersNewRule_Click(object sender, EventArgs e)
        {
            pnlMaphackFilterRuleContainer.Visible = true;

            txtMaphackFilterRuleName.Text = String.Empty;
            icbMaphackFilterUnits.SelectedIndex = -1;
            icbMaphackFilterUnitProperties.SelectedIndex = -1;
            txtMaphackFilterAttributes.Text = String.Empty;

        }

        private void btnMaphackFilterConfirmRule_Click(object sender, EventArgs e)
        {

        }

        private void icbMaphackFilterUnitProperties_SelectedIndexChanged(object sender, EventArgs e)
        {
            

            if (icbMaphackFilterUnitProperties.SelectedIndex > -1 &&
               icbMaphackFilterUnitProperties.SelectedIndex < icbMaphackFilterUnits.Items.Count)
            {
                txtMaphackFilterAttributes.AppendText(icbMaphackFilterUnitProperties.SelectedItem.ToString());
                ChangeEnabledStatus(false);
            }
        }

        private void ChangeEnabledStatus(bool status)
        {
            icbMaphackFilterUnits.Enabled = status;
            icbMaphackFilterUnitProperties.Enabled = status;
        }
    }

    public struct Rule
    {
        public String Name;
        

    }
}
