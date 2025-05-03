using SearachAppSample.Core;
using SearachAppSample.Pages;

namespace SearachAppSample
{
    public partial class FormMain : Form
    {
        ServiceProvider _serviceProvider;

        public FormMain()
        {
            InitializeComponent();
            _serviceProvider = new ServiceProvider();
            _serviceProvider.RegisterSingleton(new EventBus());
            _serviceProvider.RegisterSingleton(new Core.AppContext());
            _serviceProvider.RegisterSingleton(new NavigationService(this, _serviceProvider));
            _serviceProvider.RegisterSingleton(new UcPageMain(_serviceProvider));
        }

        private void FormMain_Shown(object sender, EventArgs e)
        {
            //_serviceProvider.Resolve<NavigationService>().NavigateTo<UcPageMain>();

            Common.RunWithLoadingForm("“Çž’†", false, (token) =>
            {
                this.Invoke(new Action(() =>
                {
                    for (int i = 0; i < 1000000; i++)
                    {
                        label1.Text = i.ToString();
                    }
                }));
            });
        }
    }
}
