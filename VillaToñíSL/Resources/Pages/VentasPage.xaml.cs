using Microcharts;
using SkiaSharp;

namespace VillaToñíSL.Resources.Pages;

public partial class VentasPage : ContentPage
{

    private List<ChartEntry> ventas1 = new List<ChartEntry>();

    public VentasPage()
	{
       
        InitializeComponent();
        
    }

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


    private async void OnGuardarVentaClicked(object sender, EventArgs e)
    {
        string mes = Mes.SelectedItem.ToString();
        string ventaMes = ValorVenta.Text;

        if (string.IsNullOrEmpty(mes))
        {
            await DisplayAlert("Error", "Por favor, selecciona un mes.", "Aceptar");
            return;
        }


        if (string.IsNullOrEmpty(ventaMes))
        {
            bool aceptar = await DisplayAlert("Advertencia", "No has introducido un valor a la venta, se aplicará automaticamente valor 0", "Aceptar", "Cancelar");

            if (aceptar)
            {
                ventaMes = "0";
            }
            else
            {
                return;

            }

            if (!Double.TryParse(ventaMes, out double venta))
            {
                await DisplayAlert("Error", "Por favor, introduce un valor numérico válido para la venta.", "Aceptar");
                return;
            }

            if (Double.Parse(ventaMes) > 100000 || Double.Parse(ventaMes) < 0)
            {
                await DisplayAlert("Error", "El valor de la venta debe comprenderse entre 0 y 100.000 euros", "Aceptar");
                return;
            }


        }

    
        CargarGraficoVentas(ventaMes, mes);

    }
}


