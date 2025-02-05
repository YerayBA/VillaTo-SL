namespace VillaToñíSL
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();


            MainPage = new NavigationPage(new Resources.Pages.LoginPage());
        }
    }
}
