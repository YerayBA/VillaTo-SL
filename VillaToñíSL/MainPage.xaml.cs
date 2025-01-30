using VillaToñíSL.Resources.Pages;

namespace VillaToñíSL
{
    public partial class MainPage : ContentPage
    {
        

        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnGestiondeLotes(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LotesPage());
        }

        private async void OnReportes(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ReportesPage());
        }

        private async void OnInventarios(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new InventariosPage());
        }

        private async void OnConfiguracion(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ConfiguracionPage());
        }

        private async void OnProduccion(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ProduccionPage());
        }

        private async void OnVentas(object sender, EventArgs e)
        {
            try
            {
                await Navigation.PushAsync(new VentasPage());
            }
            catch (Exception Ex) 
            {
                Console.WriteLine(Ex.ToString());

            }
        }

        private async void OnTareas(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TareasPage());
        }

        private async void OnClima(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ClimaPage());
        }

    }
}
