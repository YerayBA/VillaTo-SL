namespace VillaToñíSL.Resources.Pages;

public partial class ProduccionPage : ContentPage
{
    public ProduccionPage()
    {
        InitializeComponent();
    }

    private void OnGuardarProduccionClicked(object sender, EventArgs e)
    {
        FechaCosechaLabel.Text = FechaCosecha.Date.ToString("dd/MM/yyyy");
        KilosRecogidosLabel.Text = KilosRecogidos.Text;
        ArbolesRecogidosLabel.Text = ArbolesRecogidos.Text;
        CajasEntregadasLabel.Text = CajasEntregadas.Text;
        PrecioKgVendidoLabel.Text = PrecioKgVendido.Text;

        KilosRecogidos.Text = string.Empty;
        ArbolesRecogidos.Text = string.Empty;
        CajasEntregadas.Text = string.Empty;
        PrecioKgVendido.Text = string.Empty;
      
    }

    private void ExportarDatosExcel(object sender, EventArgs e)
    {
        var fechaCosecha = FechaCosechaLabel.Text;
        var kilosRecogidos = KilosRecogidosLabel.Text;
        var arbolesRecogidos = ArbolesRecogidosLabel.Text;
        var cajasEntregadas = CajasEntregadasLabel.Text;
        var precioKgVendido = PrecioKgVendidoLabel.Text;


        //Funcion exportar datos a excel

    }
}
