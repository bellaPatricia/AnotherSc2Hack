using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PluginWorkerTrainer
{
    /// <summary>
    /// Interaktionslogik für Settings.xaml
    /// </summary>
    public partial class Settings : Window
    {
        public Preferences Pref { get; set; }


        private void Init()
        {
            InitializeComponent();

            txtHeight.Text = Pref.Height.ToString();
            txtWidth.Text = Pref.Width.ToString();
            txtLeft.Text = Pref.Left.ToString();
            txtTop.Text = Pref.Top.ToString();
            txtInterval.Text = Pref.Interval.ToString();
            txtHomekey.Text = Pref.HomeKey.ToString();
            txtMinutes.Text = Pref.DisableAfterMinute.ToString();
        }

        public Settings()
        {
            Init();
        }

        public Settings(Preferences pref)
        {
            Pref = pref;
            Init();
        }

        private void txtHomekey_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;

            var txt = (TextBox) sender;
            txt.Text = e.Key.ToString();
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void txtInterval_NumberChanged(NumberTextBox o, EventNumber e)
        {
            if (o.Number > 0)
                Pref.Interval = o.Number;
        }

        private void txtMinutes_NumberChanged(NumberTextBox o, EventNumber e)
        {
            if (o.Number > 0)
                Pref.DisableAfterMinute = o.Number;
            
        }
    }
}
