using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using PredefinedTypes;

namespace AnotherSc2Hack.Classes.FrontEnds.Custom_Controls
{
    public partial class MaphackFilter : Form
    {
        private List<Rule> _lRules = new List<Rule>();
        private string[] _sValidStrings;
        private string _sAnd = "[AND]";
        private string _sOr = "[OR]";

        public MaphackFilter()
        {
            InitializeComponent();

            FillProperties();
            LoadRules();
           // SetupValidStringArray();
        }

        private void pnlFooter_Paint(object sender, PaintEventArgs e)
        {
            var send = (Panel)sender;

            e.Graphics.DrawLine(new Pen(new SolidBrush(Color.FromArgb(193, 193, 193))), 0, 0, Width, 0);
            e.Graphics.DrawLine(new Pen(new SolidBrush(Color.FromArgb(193, 193, 193))), 0, send.Height - 1, Width, send.Height - 1);
        }

        private void SetupValidStringArray()
        {
            var propertyNames = Enum.GetNames(typeof(TargetFilterFlag));

            for (var i = 0; i < propertyNames.Length; i++)
            {
                icbMaphackFilterUnitProperties.Items.Add(new ImageComboItem(propertyNames[i]));
            }

            var iLength = propertyNames.Length + icbMaphackFilterUnits.Items.Count + 2;
            _sValidStrings = new string[iLength];

            _sValidStrings.SetValue(_sAnd, 0);
            _sValidStrings.SetValue(_sOr, 1);

            var iPos = 2;
            for (var i = 0; i < propertyNames.Length; i++)
            {
                _sValidStrings.SetValue(propertyNames[i], iPos);
                iPos += 1;
            }

            for (var i = 0; i < icbMaphackFilterUnits.Items.Count; i++)
            {
                _sValidStrings.SetValue(icbMaphackFilterUnits.Items[i].ToString(), iPos);
                iPos += 1;
            }
        }

        private void FillProperties()
        {
            icbMaphackFilterUnitProperties.Items.Clear();

            var propertyNames = Enum.GetNames(typeof(TargetFilterFlag));

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
            #region Exceptions

            if (txtMaphackFilterRuleName.Text.Length <= 0)
                return;

            if (txtMaphackFilterAttributes.Text.Length <= 0)
                return;

            #endregion

            #region Add rule into listview

            var rule = new Rule(txtMaphackFilterRuleName.Text, txtMaphackFilterAttributes.Text);
            var lv = new ListViewItem();
            lv.Text = rule.Name;
            lv.SubItems.Add(new ListViewItem.ListViewSubItem(lv, rule.RuleSet));
            lv.BackColor = lstvMaphackFilterCurrentFilters.Items.Count%2 == 0
                ? lstvMaphackFilterCurrentFilters.BackColor
                : Color.Lavender;
            lstvMaphackFilterCurrentFilters.Items.Add(lv);

            #endregion

            #region Reset fields

            txtMaphackFilterRuleName.Text = String.Empty;
            txtMaphackFilterAttributes.Text = String.Empty;
            icbMaphackFilterUnits.SelectedIndex = -1;
            icbMaphackFilterUnitProperties.SelectedIndex = -1;

            #endregion

            _lRules.Add(rule);
        }

        private void LoadRules()
        {
            lstvMaphackFilterCurrentFilters.Enabled = true;
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

        private void txtMaphackFilterAttributes_TextChanged(object sender, EventArgs e)
        {

        }
    }

    public struct Rule
    {
        public string Name;
        public string RuleSet;

        public Rule(string name, string ruleSet)
        {
            Name = name;
            RuleSet = ruleSet;
        }
    }
}
