using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AnotherSc2Hack.Classes.BackEnds.Gameinfo;

namespace AnotherSc2Hack.Classes.FrontEnds.Customize
{
    public partial class Customizer : Form
    {
        public Customizer()
        {
            InitializeComponent();
        }

        private void Customizer_Load(object sender, EventArgs e)
        {
            LoadPlayerDataIntoListview(lwPlayerData);
        }

        private void LoadPlayerDataIntoListview(ListView lw)
        {
            var properties = TypeDescriptor.GetProperties(typeof(Player));

            for (int index = 0; index < properties.Count; index++)
            {
                var property = properties[index];
                var lwi = new ListViewItem();

                lwi.Text = property.Name;
                lwi.SubItems.Add(new ListViewItem.ListViewSubItem(lwi, property.PropertyType.ToString()));

                lw.Items.Add(lwi);

            }
        }
    }
}
