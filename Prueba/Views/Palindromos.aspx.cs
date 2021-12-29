using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Prueba.Views
{
    public partial class Palindromos : System.Web.UI.Page
    {
        string nombreUsuario;
        protected void Page_Load(object sender, EventArgs e)
        {
            nombreUsuario = (string)Session["nombreUsuario"];
            if (!IsPostBack)
            {
                if (nombreUsuario != null)
                {

                }
                else
                {
                    Response.Redirect("~/Login.aspx");
                }
            }
        }



        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            string cadena = txtTexto.Text;
            string[] separadas;
            separadas = cadena.Split(' ');
            int contador = 0;
            for (int i = 0; i < separadas.Length; i++)
            {
                if (esPalindroma(separadas[i]))
                {
                    contador++;
                    lblResultado.Text += "* " + separadas[i] + "\r\n";

                }
            }
            lblCantidad.Text = "Cantidad: " + contador;
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            txtTexto.Text = string.Empty;
            lblCantidad.Text = string.Empty;
            lblResultado.Text = string.Empty;
        }

        public Boolean esPalindroma(String cadena)
        {
            if (cadena.Length < 2) return true;
            if (cadena[0] == cadena[cadena.Length - 1]) return esPalindroma(cadena.Substring(1, cadena.Length - 2));
            return false;
        }

        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Menu.aspx");
        }
    }
}