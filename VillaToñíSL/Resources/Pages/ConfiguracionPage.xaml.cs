

using VillaToñíSL.Resources.Pages.ConfiguracionPages;


namespace VillaToñíSL.Resources.Pages;


public partial class ConfiguracionPage : ContentPage
{
	public ConfiguracionPage()
	{
		InitializeComponent();
        

    }

    private async void ConfigurarApariencia(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ConfigurarAparienciaPage());
    }

    private async void InfoUsuario(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new InfoUsuario());
    }

    private async void Idiomas(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Idiomas());
    }

    private async void Contacto(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Contacto());
    }

    private async void InfoApp(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new InfoApp());
    }

    private async void SuscripcionPage(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new SuscripcionPage());
    }

    private async void AdminArea(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AdminAreaPage());
    }


    

}