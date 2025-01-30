using Microcharts;
using SkiaSharp;

namespace VillaToñíSL.Resources.Pages;

public partial class VentasPage : ContentPage
{
	public VentasPage()
	{
       
        InitializeComponent();
        
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await Task.Delay(100); // Para dar tiempo a que los controles se inicialicen correctamente
        CargarGraficoVentas();
    }

    private void CargarGraficoVentas()
    {
        // Datos de ventas (simulados)
        var ventas = new List<ChartEntry>
            {
                new ChartEntry(1000) { Label = "Enero", ValueLabel = "5000", Color = SKColor.Parse("#3498db") },
                new ChartEntry(7000) { Label = "Febrero", ValueLabel = "7000", Color = SKColor.Parse("#2ecc71") },
                new ChartEntry(500) { Label = "Marzo", ValueLabel = "6500", Color = SKColor.Parse("#f1c40f") },
                new ChartEntry(8000) { Label = "Abril", ValueLabel = "8000", Color = SKColor.Parse("#e74c3c") },
                new ChartEntry(30) { Label = "Mayo", ValueLabel = "9000", Color = SKColor.Parse("#9b59b6") }
            };

        // Configurar gráfico de barras
        SalesChart.Chart = new LineChart
        {
            Entries = ventas,
            LabelTextSize = 20,
            LineMode = LineMode.Spline, // Hace que las líneas sean suaves
            LineSize = 8,
            PointMode = PointMode.Circle,
            PointSize = 18,
            BackgroundColor = SKColors.Transparent
        };



    }

    private void OnGuardarVentaClicked(object sender, EventArgs e)
    {
        
    }
}

