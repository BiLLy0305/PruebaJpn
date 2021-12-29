using Prueba.Models;
using Prueba.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Prueba.Views
{
    public partial class RecuperarContraseña : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        serviceEmail sEmail = new serviceEmail();
        serviceUsuario serviceUsuario = new serviceUsuario();
        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            Guid g = Guid.NewGuid();
            string GuidString = Convert.ToBase64String(g.ToByteArray());

            GuidString = GuidString.Replace("=", "").Replace("+", "");


            Usuario nUsuario = new Usuario
            {
                email = txtEmail.Text,
                fechaNacimiento = Convert.ToDateTime(txtFechaN.Text),
                tokenR = GuidString
            };
            if (serviceUsuario.existeUsuarioRee(nUsuario))
            {
                if (serviceUsuario.actualizarToken(nUsuario))
                {
                    divAlert.Visible = false;
                    divSuccess.Visible = true;
                    sEmail.EnviarEmail(nUsuario.email, nUsuario.tokenR);
                    limpiarCampos();

                }
            }
            else
            {
                divAlert.Visible = true;
                divSuccess.Visible = false;
            }
        }

        public void limpiarCampos()
        {
            txtEmail.Text = string.Empty;
            txtFechaN.Text = string.Empty;
        }
    }
}