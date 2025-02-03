namespace VillaToñíSL.Resources.Pages.ConfiguracionPages;

public partial class ConfigurarAparienciaPage : ContentPage
{

	public ConfigurarAparienciaPage()
	{
		InitializeComponent();
	}

    public async void OnChangeImageClicked(object sender, EventArgs e)
    {
        var result = await FilePicker.PickAsync(new PickOptions
        {
            PickerTitle = "Selecciona una imagen",
            FileTypes = FilePickerFileType.Images
        });

        if (result != null)
        {
            var stream = await result.OpenReadAsync();
            CoverImage.Source = ImageSource.FromStream(() => stream);
        }
    }

	public void OnSaveChangesClicked(object sender, EventArgs e)
    {
        OnChangeColorClicked(sender, e);
    }

	public void OnChangeColorClicked(object sender, EventArgs e)
    {
        string selectedColor = ButtonColorPicker.SelectedItem as string;
        Color backgroundColor = Colors.White;

        switch (selectedColor)
        {
            case "Rojo":
                backgroundColor = Colors.Red;
                break;
            case "Verde":
                backgroundColor = Colors.LightGreen;
                break;
            case "Azul":
                backgroundColor = Colors.Blue;
                break;
            case "Amarillo":
                backgroundColor = Colors.Yellow;
                break;
            case "Naranja":
                backgroundColor = Colors.Orange;
                break;
        }


        ConfiguracionGlobal.BackgroundColor = backgroundColor;

        BotonGuardar.BackgroundColor = backgroundColor;
        CambiarImagen.BackgroundColor = backgroundColor;
        ButtonColorPicker.BackgroundColor = backgroundColor;
        FontSizeSlider.ThumbColor = backgroundColor;
        FontSizeSlider.MinimumTrackColor = backgroundColor;


    }
}