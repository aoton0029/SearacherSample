using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SearachAppSample.Pages.Menus
{
    public partial class UcMenuData : UserControl
    {
        private readonly ServiceProvider _provider;

        public UcMenuData(ServiceProvider provider)
        {
            InitializeComponent();
            _provider = provider;
        }

        private void btnSNList_Click(object sender, EventArgs e)
        {

        }

        private void btnMacAddress_Click(object sender, EventArgs e)
        {

        }

        private void btnPartsList_Click(object sender, EventArgs e)
        {

        }
    }
}
