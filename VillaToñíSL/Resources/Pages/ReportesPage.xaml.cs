using System.Net;
using System.Net.Mail;

namespace VillaToñíSL.Resources.Pages;

public partial class ReportesPage : ContentPage
{
    public ReportesPage()
    {
        InitializeComponent();
    }

    public void OnEnviarProblemaClicked(object sender, EventArgs e)
    {
        var tituloProblema = TitutoProblema.Text;
        var descripcionProblema = DescripcionProblema.Text;

        EnviarCorreo(tituloProblema, descripcionProblema);

        TitutoProblema.Text = string.Empty;
        DescripcionProblema.Text = string.Empty;
    }

    private void EnviarCorreo(string titulo, string descripcion)
    {
        var fromAddress = new MailAddress("yerayblanco@hotmail.com", "Yeray");
        var toAddress = new MailAddress("yerayblanco@hotmail.com", "VillaToñiSL");
        const string fromPassword = "Contraseña";
        string subject = "Reporte de Problema: " + titulo;
        string body = "Descripción del problema:\n" + descripcion;

        var smtp = new SmtpClient
        {
            Host = "smtp.live.com",
            Port = 587,
            EnableSsl = true,
            DeliveryMethod = SmtpDeliveryMethod.Network,
            UseDefaultCredentials = false,
            Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
        };

        using (var message = new MailMessage(fromAddress, toAddress)
        {
            Subject = subject,
            Body = body
        })
        {
            smtp.Send(message);
            DisplayAlert("Correo enviado", "El correo ha sido enviado correctamente", "Aceptar");
        }
    }
}
