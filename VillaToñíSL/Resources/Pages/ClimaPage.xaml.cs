using Newtonsoft.Json.Linq;
using System.Text.Json;

namespace VillaToñíSL.Resources.Pages;

public partial class ClimaPage : ContentPage
{
    private const string ApiUrl = "https://www.el-tiempo.net/api/json/v2/provincias/29/municipios/29005";

    public ClimaPage()
    {
        _ = GetWeatherDataAsync();
        InitializeComponent();
        
    }

    private async Task GetWeatherDataAsync()
    {
        using HttpClient client = new();
        HttpResponseMessage response = await client.GetAsync(ApiUrl);
        if (response.IsSuccessStatusCode)
        {
            string responseBody = await response.Content.ReadAsStringAsync();
            using JsonDocument doc = JsonDocument.Parse(responseBody);

            var temperatura = doc.RootElement.GetProperty("temperatura_actual").GetString();
            var probHoy = doc.RootElement.GetProperty("pronostico").GetProperty("hoy").GetProperty("prob_precipitacion");
            var humedad = doc.RootElement.GetProperty("humedad").GetString();
            var viento = doc.RootElement.GetProperty("viento").GetString();
            var estadoCielo = doc.RootElement.GetProperty("stateSky").GetProperty("description");


            lblestadoCielo.Text = $"Estado del Cielo: {estadoCielo}";
            lblTemperatura.Text = $"Temperatura: {temperatura}°C";
            lblProbHoy.Text = $"Probabilidad de precipitación hoy: {probHoy[0]} %";
            lblHumedad.Text = $"Humedad: {humedad}%";
            lblViento.Text = $"Viento: {viento} km/h";
        }
    }
}
