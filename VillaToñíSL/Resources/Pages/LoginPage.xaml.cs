namespace VillaToñíSL.Resources.Pages;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
	}
	
	public void OnLoginButtonClicked(object sender, EventArgs e)
    {
		var usuario = UsernameEntry.Text;
		var password = PasswordEntry.Text;

		if(usuario == "admin" && password == "admin")

            Navigation.PushAsync(new MainPage());

        else
            DisplayAlert("Error", "Usuario o contraseña incorrectos", "OK");
    }

	public void OnRegisterButtonClicked(object obj, EventArgs e)
    {
		DisplayAlert("Registro", "Para Obtener una cuenta mande un correo a VillaToñiSL@gmail.com", "OK");
    }
}