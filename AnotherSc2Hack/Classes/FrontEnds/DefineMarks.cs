using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AnotherSc2Hack.Classes.FrontEnds
{
    public partial class DefineMarks : Form
    {
        public UnitMarks Marks { get; set; }

        public DefineMarks()
        {
            InitializeComponent();
            Marks = new UnitMarks();
        }

        private void DefineMarks_Load(object sender, EventArgs e)
        {
            #region Combobox for the Markmethod

            var values = Enum.GetValues(typeof (MarkMethod));

            foreach (var value in values)
            {
                cmBxKindOfDrawing.Items.Add(value.ToString());
            }

            cmBxKindOfDrawing.SelectedIndex = 0;

            #endregion

            #region Domain up-down for pixel- count

            const int iLimit = 1000;
            for(var i = iLimit; i > 0; i--)
            {
                dudBorderThikness.Items.Add(i + " px");
            }

            dudBorderThikness.SelectedIndex = dudBorderThikness.Items.Count - 1;

            #endregion


        }

        private void btnColor_Click(object sender, EventArgs e)
        {
            var clDia = new ColorDialog();

            var result = clDia.ShowDialog();


            if (!result.Equals(DialogResult.OK)) return;

            btnColor.BackColor = clDia.Color;
            btnColor.Text = clDia.Color.Name;
            Marks.Color = clDia.Color;
        }

        private void dudBorderThikness_SelectedItemChanged(object sender, EventArgs e)
        {
            if (dudBorderThikness.SelectedIndex <= -1)
                return;

            var strItem = dudBorderThikness.SelectedItem.ToString();
            var strNumber = strItem.Substring(0, strItem.IndexOf(" ", System.StringComparison.Ordinal));

            var iNumber = Int32.Parse(strNumber);

            Marks.BorderThinkness = iNumber;
        }

        private void cmBxKindOfDrawing_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmBxKindOfDrawing.SelectedIndex <= -1)
                return;

            var values = Enum.GetValues(typeof (MarkMethod));

            for (int index = 0; index < values.Length; index++)
            {
                var value = values.GetValue(index);
                if (value.ToString().Equals(cmBxKindOfDrawing.SelectedItem.ToString()))
                    Marks.KindOfMarking = (MarkMethod)index;
            }
        }

    }

    public class UnitMarks
    {
        public String UnitName { get; set; }
        public MarkMethod KindOfMarking { get; set; }
        public Color Color { get; set; }
        public Char Letter { get; set; }
        public Point[] Points { get; set; }
        public Int32 BorderThinkness { get; set; }

        public UnitMarks()
        {
            UnitName = "";
            KindOfMarking = MarkMethod.Drawing;
            Color = Color.Red;
            Letter = '#';
            Points = new Point[2];
            Points[0] = new Point(0, 5);
            Points[1] = new Point(5, 5);
            BorderThinkness = 1;
        }


    }


    

    public enum MarkMethod
    {
        Drawing,
        Geometry,
        Letters
    }
}
