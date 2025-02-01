namespace VillaToñíSL.Resources.Pages;

public partial class ConfiguracionPage : ContentPage
{
	public ConfiguracionPage()
	{
		InitializeComponent();
	}

	public void guardarCambios()
    {
        //Opciones para desarrollar:
        //1. Pestaña "Temas". Cambiar el icono central del menú dependiendo del tipo de produccion que tenga. Si tiene naranjas, poner una narana y cambiar todo el color de la app a naranja. Para esto, hay que refactorizar los Styles y sacarlos a un archivo independiente y usarlo en todas las pantallas.
        //2. Pestaña "Datos" .Datos de la persona que usa la app. Nombre, direccion (para poder modificar la consulta a la API del tiempo), Telefono, Email (Crear un login/sesion?).
        //3. "Pestaña "Contacto" Apartado de contacto.
        //4. Securizacion en funcion de los permisos que se tengan para usar la aplicacion. (patron, trabajador, administrativo...etc).


    }
}