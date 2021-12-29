using Prueba.Models;
using Prueba.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Prueba
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        serviceUsuario service = new serviceUsuario();
        protected void btnEntrar_Click(object sender, EventArgs e)
        {
            try
            {
                Usuario nUsuario = new Usuario
                {
                    email = txtEmail.Text,
                    passw = txtPass.Text
                };

                if (service.existeUsuario(nUsuario))
                {
                    string usuario = nUsuario.nombre;
                    Session["nombreUsuario"] = usuario;
                    Response.Redirect("/Menu.aspx");
                    divAlert.Visible = false;
                }
                else {
                    divAlert.Visible = true;
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}