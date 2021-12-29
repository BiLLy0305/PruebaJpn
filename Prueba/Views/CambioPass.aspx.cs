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
    public partial class CambioPass : System.Web.UI.Page
    {
        string token;
        protected void Page_Load(object sender, EventArgs e)
        {
            token = Request.QueryString["t"];
        }

        serviceUsuario service = new serviceUsuario();
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtPass.Text != txtPass2.Text)
                {
                    divAlert.Visible = true;
                    divSuccess.Visible = false;
                    divTE.Visible = false;
                }
                else
                {
                    Usuario nUsuario = new Usuario
                    {
                        tokenR = token,
                        passw = txtPass.Text
                    };
                    if (service.actualizaPass(nUsuario))
                    {
                        divAlert.Visible = false;
                        divSuccess.Visible = true;
                        divTE.Visible = false;
                    }
                    else
                    {
                        divTE.Visible = true;
                        divAlert.Visible = false;
                        divSuccess.Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Login.aspx");
        }
    }
}