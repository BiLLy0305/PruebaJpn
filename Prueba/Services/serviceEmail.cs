using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Web;


namespace Prueba.Services
{
    public class serviceEmail
    {

        public bool EnviarEmail(string correo, string token)
        {

            MailMessage msg = new MailMessage();


            msg.To.Add(correo);

            msg.From = new MailAddress("pruebaajpn@gmail.com", "Reestrablecer Contraseña", System.Text.Encoding.UTF8);

            msg.Subject = "Reestablecer contraseña";

            msg.SubjectEncoding = System.Text.Encoding.UTF8;

            msg.Body = @"Buen día";

            msg.BodyEncoding = System.Text.Encoding.UTF8;

            msg.IsBodyHtml = true; //Si vas a enviar un correo con contenido html entonces cambia el valor a true
                                   //Aquí es donde se hace lo especial

            string html = @"<h1>Has solicitado un Cambio de contraseña</h1>
                           <p><a href='http://localhost:50662/Views/CambioPass.aspx?t="+token+"'>Clic para cambiar contraseña!</a></p>";

            AlternateView htmlView = AlternateView.CreateAlternateViewFromString(html, Encoding.UTF8, MediaTypeNames.Text.Html);
            //LinkedResource img = new LinkedResource(Server.MapPath("~/images/logob.jpg"), MediaTypeNames.Image.Jpeg);
            //img.ContentId = "imagen";
            //htmlView.LinkedResources.Add(img);
            ////msg.AlternateViews.Add(plainView);
            msg.AlternateViews.Add(htmlView);



            SmtpClient client = new SmtpClient();

            client.Credentials = new System.Net.NetworkCredential("pruebaajpn@gmail.com", "PruebaJapon");

            client.Port = 587;

            client.Host = "smtp.gmail.com";//Este es el smtp valido para Gmail

            client.EnableSsl = true; //Esto es para que vaya a través de SSL que es obligatorio con GMail

            try

            {
                client.Send(msg);

                return true;
            }

            catch (Exception ex)

            {
                return false;
            }

        }


    }
}