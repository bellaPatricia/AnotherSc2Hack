using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Net;
using System.Windows.Forms;

namespace AnotherSc2Hack.Classes.FrontEnds
{
    public partial class Plugins : Form
    {
        private const String StrPluginLink =
            @"https://dl.dropboxusercontent.com/u/62845853/AnotherSc2Hack/UpdateFiles/Plugins.txt";

        public Plugins()
        {
            InitializeComponent();
        }

        public void GetPluginData(bool silent = false)
        {
            var client = new WebClient();

            var strSource = client.DownloadString(StrPluginLink);

            if (silent)
            {

            }

            else
            {
                
            }
        }
    }
}
