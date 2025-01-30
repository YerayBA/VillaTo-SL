using Microcharts;
using SkiaSharp;

namespace VillaToñíSL.Resources.Pages;

public partial class VentasPage : ContentPage
{
	public VentasPage()
	{
       
        InitializeComponent();
        
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        CargarGraficoVentas();
    }

    private void CargarGraficoVentas()
    {
        // Datos de ventas (simulados)
        var ventas = new List<ChartEntry>
            {
                new ChartEntry(5000) { Label = "Enero", ValueLabel = "5000", Color = SKColor.Parse("#3498db") },
                new ChartEntry(7000) { Label = "Febrero", ValueLabel = "7000", Color = SKColor.Parse("#2ecc71") },
                new ChartEntry(6500) { Label = "Marzo", ValueLabel = "6500", Color = SKColor.Parse("#f1c40f") },
                new ChartEntry(8000) { Label = "Abril", ValueLabel = "8000", Color = SKColor.Parse("#e74c3c") },
                new ChartEntry(9000) { Label = "Mayo", ValueLabel = "9000", Color = SKColor.Parse("#9b59b6") }
            };

        // Configurar gráfico de barras
        var chart = new BarChart
        {
            Entries = ventas,
            LabelTextSize = 24,
            BackgroundColor = SKColors.Transparent
        };

        SalesChart.Chart = chart;
    }
}

