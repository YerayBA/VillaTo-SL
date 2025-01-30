using OfficeOpenXml;

namespace VillaToñíSL.Resources.Pages;

public partial class ProduccionPage : ContentPage
{
    public ProduccionPage()
    {
        InitializeComponent();
    }

    private void OnTextChanged(object sender, TextChangedEventArgs e)
    {
        if (!string.IsNullOrEmpty(e.NewTextValue))
        {
            // Filtrar solo números
            if (!int.TryParse(e.NewTextValue, out _))
            {
                ((Entry)sender).Text = e.OldTextValue; // Restaurar el valor anterior
            }
        }
    }


    private void OnGuardarProduccionClicked(object sender, EventArgs e)
    {
        FechaCosechaLabel.Text = FechaCosecha.Date.ToString("dd/MM/yyyy");
        KilosRecogidosLabel.Text = KilosRecogidos.Text;
        ArbolesRecogidosLabel.Text = ArbolesRecogidos.Text;
        CajasEntregadasLabel.Text = CajasEntregadas.Text;
        PrecioKgVendidoLabel.Text = PrecioKgVendido.Text;
        ImpuestoCosechaLabel.Text = ImpuestoCosecha.Text;

        KilosRecogidos.Text = string.Empty;
        ArbolesRecogidos.Text = string.Empty;
        CajasEntregadas.Text = string.Empty;
        PrecioKgVendido.Text = string.Empty;
        ImpuestoCosecha.Text = string.Empty;
    }

    private async void ExportarDatosExcel(object sender, EventArgs e)
    {
        try
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            var fechaCosecha = FechaCosechaLabel.Text;
            var kilosRecogidos = KilosRecogidosLabel.Text;
            var arbolesRecogidos = ArbolesRecogidosLabel.Text;
            var cajasEntregadas = CajasEntregadasLabel.Text;
            var precioKgVendido = PrecioKgVendidoLabel.Text;
            var ValorBrutoGenerado = int.Parse(kilosRecogidos) * double.Parse(precioKgVendido);
            var ImpuestoCosecha = ImpuestoCosechaLabel.Text;
            var RetenidoCosecha = ((int.Parse(kilosRecogidos) * double.Parse(precioKgVendido)) * double.Parse(ImpuestoCosecha) / 100);
            var ValorNetoGenerado = ValorBrutoGenerado - RetenidoCosecha;

            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Producción");
                worksheet.Cells[1, 1].Value = "Fecha de Cosecha";
                worksheet.Cells[1, 2].Value = "Kilos Recogidos";
                worksheet.Cells[1, 3].Value = "Árboles Recogidos";
                worksheet.Cells[1, 4].Value = "Cajas Entregadas";
                worksheet.Cells[1, 5].Value = "Precio por Kg Vendido";
                worksheet.Cells[1, 6].Value = "Valor Bruto Generado";
                worksheet.Cells[1, 7].Value = "Impuesto Cosecha";
                worksheet.Cells[1, 8].Value = "Valor Neto Generado";

                worksheet.Cells[2, 1].Value = fechaCosecha;
                worksheet.Cells[2, 2].Value = kilosRecogidos + " KG";
                worksheet.Cells[2, 3].Value = arbolesRecogidos;
                worksheet.Cells[2, 4].Value = cajasEntregadas;
                worksheet.Cells[2, 5].Value = precioKgVendido + " euros";
                worksheet.Cells[2, 6].Value = ValorBrutoGenerado + " euros";
                worksheet.Cells[2, 7].Value = RetenidoCosecha + " euros";
                worksheet.Cells[2, 8].Value = ValorNetoGenerado + " euros";

                var desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                var folderName = DateTime.Now.ToString("yyyy-MM-dd") + "_produccion";
                var folderPath = Path.Combine(desktopPath, folderName);

                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
               
                    var file = new FileInfo(Path.Combine(folderPath, "Produccion.xlsx"));
                    package.SaveAs(file);

                }
                else
                {
                   var file = new FileInfo(Path.Combine(folderPath, "Produccion.xlsx"));

                   bool sobreescribir = await DisplayAlert("En la fecha seleccionada ya ha exportado los datos", "Si vuelve a Exportarlos sobreescribirá los datos de la anterior producción", "Aceptar", "Cancelar");

                    if (sobreescribir)
                    {
                        package.SaveAs(file);
                    }
                    else
                    {
                        return;
                    }
                    
                }

               await  DisplayAlert("Mensaje de Exportación", "Datos exportados correctamente en el escritorio", "Aceptar");
            }
        }
        catch (Exception ex)
        {
             await DisplayAlert("Los valores no son correctos, por favor, compruebelos e intentelo de nuevo", ex.Message, "Aceptar");
        }
    }
}
