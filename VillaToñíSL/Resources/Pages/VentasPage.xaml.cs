using Microcharts;
using SkiaSharp;

namespace VillaToñíSL.Resources.Pages;

public partial class VentasPage : ContentPage
{
	public VentasPage()
	{
       
        InitializeComponent();
        
    }

    
private List<ChartEntry> ventas1 = new List<ChartEntry>();

    private void CargarGraficoVentas(string ventas, string mes)
    {
        ventas1.Add(new ChartEntry(int.Parse(ventas))
        {
            Label = mes,
            ValueLabel = ventas + " euros",
            Color = SKColor.Parse("#3498db")
        });

        GraficoVentas.Chart = new LineChart
        {
            Entries = ventas1,
            LabelTextSize = 20,
            LineMode = LineMode.Spline,
            LineSize = 8,
            PointMode = PointMode.Circle,
            PointSize = 18,
            BackgroundColor = SKColors.Transparent,
            LabelOrientation = Orientation.Horizontal,
            ValueLabelOrientation = Orientation.Horizontal
        };
    }


    private void OnGuardarVentaClicked(object sender, EventArgs e)
    {
        string mes = Mes.SelectedItem.ToString(); 

        string ventaMes = ValorVenta.Text;

        if (!Double.TryParse(ventaMes, out double venta))
        {
            DisplayAlert("Error", "Por favor, introduce un valor numérico válido para la venta.", "Aceptar");
            return;
        }

        if (Double.Parse(ventaMes) > 100000 || Double.Parse(ventaMes) < 0)
        {
            DisplayAlert("Error", "El valor de la venta debe comprenderse entre 0 y 100.000 euros", "Aceptar");
            return;
        }

        


        CargarGraficoVentas(ventaMes, mes);


    }
}

