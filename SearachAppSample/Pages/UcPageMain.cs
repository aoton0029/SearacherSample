using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SearachAppSample.Pages.Menus;

namespace SearachAppSample.Pages
{
    public partial class UcPageMain : UserControl
    {
        private readonly ServiceProvider _provider;
        UcMenuData _menuData;
        UcMenuSearch _menuSearch;

        public UcPageMain(ServiceProvider provider)
        {
            InitializeComponent();
            _menuData = new UcMenuData(provider) { Dock = DockStyle.Fill };
            _menuSearch = new UcMenuSearch(provider) { Dock = DockStyle.Fill };

            pnlMenu.Controls.Clear();
            pnlMenu.Controls.Add(_menuSearch);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            pnlMenu.Controls.Clear();
            pnlMenu.Controls.Add(_menuSearch);
        }

        private void btnData_Click(object sender, EventArgs e)
        {
            pnlMenu.Controls.Clear();
            pnlMenu.Controls.Add(_menuData);
        }
    }
}
