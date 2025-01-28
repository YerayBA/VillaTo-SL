using Newtonsoft.Json.Linq;

namespace VillaToñíSL.Resources.Pages;

public partial class ClimaPage : ContentPage
{
    private const string ApiUrl = "https://www.el-tiempo.net/api/json/v1/provincias/01/municipios";

    public ClimaPage()
    {
        InitializeComponent();
        _ = GetWeatherDataAsync();
    }

    private async Task GetWeatherDataAsync()
    {
        using HttpClient client = new ();
        HttpResponseMessage response = await client.GetAsync(ApiUrl);
        if (response.IsSuccessStatusCode)
        {
            string content = await response.Content.ReadAsStringAsync();
            JObject json = JObject.Parse(content);
            var archezData = json["Provincias"].FirstOrDefault(c => c["name"].ToString() == "Alava");

            if (archezData != null)
            {

                double temperature = archezData["temperatura_actual"].ToObject<double>();
                int humidity = archezData["humedad"].ToObject<int>();
                double precipitation = archezData["precipitacion"].ToObject<double>();

                // Aquí puedes actualizar la UI con los datos obtenidos

            }
        }
    }
}
