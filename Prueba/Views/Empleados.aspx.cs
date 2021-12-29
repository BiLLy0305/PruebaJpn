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
    public partial class Empleados : System.Web.UI.Page
    {
        string nombreUsuario;
        serviceEmpleado service = new serviceEmpleado();
        protected void Page_Load(object sender, EventArgs e)
        {
            nombreUsuario = (string)Session["nombreUsuario"];
            if (!IsPostBack)
            {
                if (nombreUsuario != null)
                {
                    llenarEmpleados();
                }
                else
                {
                    Response.Redirect("~/Login.aspx");
                }
            }
        }

        public void llenarEmpleados()
        {
            grdEmpleados.DataSource = service.getEmpleados();
            grdEmpleados.DataBind();
        }

        protected void grdEmpleados_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {

                if (e.CommandName == "ed")
                {
                    GridViewRow selectedRow = (GridViewRow)((Button)e.CommandSource).NamingContainer;
                    int intRowIndex = Convert.ToInt32(selectedRow.RowIndex);
                    pnlAgregar.Visible = false;
                    pnlLista.Visible = false;
                    pnlModificar.Visible = true;
                    lblCodigo.Text = grdEmpleados.Rows[intRowIndex].Cells[0].Text;
                    txtMDpi.Text = grdEmpleados.Rows[intRowIndex].Cells[0].Text;
                    txtMNombre.Text = grdEmpleados.Rows[intRowIndex].Cells[1].Text;
                    txtMCantidadHijos.Text = grdEmpleados.Rows[intRowIndex].Cells[2].Text;
                    txtMSalarioBase.Text = grdEmpleados.Rows[intRowIndex].Cells[3].Text;

                    double CalculoIgss = 0;
                    CalculoIgss = (Convert.ToDouble(txtMSalarioBase.Text) * 0.0483);
                    lblMIgss.Text = Convert.ToString(CalculoIgss);

                    double calculoIrtra = 0;
                    calculoIrtra = (Convert.ToDouble(txtMSalarioBase.Text) * 0.01);
                    lblMIrtra.Text = Convert.ToString(calculoIrtra);

                    double calculoPaternidad = 0;
                    if (txtMCantidadHijos.Text != string.Empty)
                    {
                        calculoPaternidad = Convert.ToInt32(txtMCantidadHijos.Text) * 133;
                        lblMBonoPaternidad.Text = Convert.ToString(calculoPaternidad);
                    }
                    else
                    {
                        lblMBonoPaternidad.Text = "0";
                    }


                    lblMSalarioTotal.Text = Convert.ToString((Convert.ToDouble(txtMSalarioBase.Text)) + calculoPaternidad + 250);

                    lblMSalarioLiquido.Text = Convert.ToString(Convert.ToDouble(lblMSalarioTotal.Text) - (CalculoIgss) - (calculoIrtra));


                }
                else if (e.CommandName == "de")
                {
                    GridViewRow selectedRow = (GridViewRow)((Button)e.CommandSource).NamingContainer;
                    int intRowIndex = Convert.ToInt32(selectedRow.RowIndex);
                    lblCodigo.Text = grdEmpleados.Rows[intRowIndex].Cells[0].Text;

                    if (service.eliminarEmpleado(Convert.ToInt32(lblCodigo.Text)))
                    {
                        llenarEmpleados();
                        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Registro Eliminado Exitosamente!');", true);
                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void grdEmpleados_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                Empleado nEmpleado = new Empleado
                {
                    dpi = Convert.ToInt64(txtDpi.Text),
                    nombreCompleto = txtNombre.Text,
                    cantidadHijos = Convert.ToInt32(txtCantidadHijos.Text),
                    salarioBase = Convert.ToDouble(txtSalarioBase.Text),
                    salarioLiquido = Convert.ToDouble(lblSalarioLiquido.Text),
                    usuarioCreacion = nombreUsuario
                };

                if (service.crearEmpleado(nEmpleado))
                {
                    limpiarCampos();
                    llenarEmpleados();
                    pnlAgregar.Visible = false;
                    pnlLista.Visible = true;
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Registro Cread@ Exitosamente');", true);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void limpiarCampos()
        {
            txtDpi.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtCantidadHijos.Text = string.Empty;
            txtSalarioBase.Text = string.Empty;
            lblIgss.Text = string.Empty;
            lblIrtra.Text = string.Empty;
            lblBonoPaternidad.Text = string.Empty;
            lblSalarioTotal.Text = string.Empty;
            lblSalarioLiquido.Text = string.Empty;
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            limpiarCampos();
            pnlAgregar.Visible = false;
            pnlLista.Visible = true;
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            pnlAgregar.Visible = true;
            pnlLista.Visible = false;
        }


        protected void txtSalarioBase_TextChanged(object sender, EventArgs e)
        {
            double CalculoIgss = 0;
            CalculoIgss = (Convert.ToDouble(txtSalarioBase.Text) * 0.0483);
            lblIgss.Text = Convert.ToString(CalculoIgss);

            double calculoIrtra = 0;
            calculoIrtra = (Convert.ToDouble(txtSalarioBase.Text) * 0.01);
            lblIrtra.Text = Convert.ToString(calculoIrtra);

            double calculoPaternidad = 0;
            if (txtCantidadHijos.Text != string.Empty)
            {
                calculoPaternidad = Convert.ToInt32(txtCantidadHijos.Text) * 133;
                lblBonoPaternidad.Text = Convert.ToString(calculoPaternidad);
            }
            else
            {
                lblBonoPaternidad.Text = "0";
            }


            lblSalarioTotal.Text = Convert.ToString((Convert.ToDouble(txtSalarioBase.Text)) + calculoPaternidad + 250);

            lblSalarioLiquido.Text = Convert.ToString(Convert.ToDouble(lblSalarioTotal.Text) - (CalculoIgss) - (calculoIrtra));

        }


        protected void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                Empleado mEmpleado = new Empleado
                {
                    dpi = Convert.ToInt64(lblCodigo.Text),
                    nombreCompleto = txtMNombre.Text,
                    cantidadHijos = Convert.ToInt32(txtMCantidadHijos.Text),
                    salarioBase = Convert.ToDouble(txtMSalarioBase.Text),
                    salarioLiquido = Convert.ToDouble(lblMSalarioLiquido.Text)
                };

                if (service.modificarEmpleado(mEmpleado))
                {
                    limpiarCampos();
                    llenarEmpleados();
                    pnlAgregar.Visible = false;
                    pnlModificar.Visible = false;
                    pnlLista.Visible = true;
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Registro Modificad@ Exitosamente');", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Error! al modificar');", true);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnMCancelar_Click(object sender, EventArgs e)
        {
            limpiarCampos();
            pnlModificar.Visible = false;
            pnlAgregar.Visible = false;
            pnlLista.Visible = true;
        }

        protected void txtMSalarioBase_TextChanged(object sender, EventArgs e)
        {

            double CalculoIgss = 0;
            CalculoIgss = (Convert.ToDouble(txtMSalarioBase.Text) * 0.0483);
            lblMIgss.Text = Convert.ToString(CalculoIgss);

            double calculoIrtra = 0;
            calculoIrtra = (Convert.ToDouble(txtMSalarioBase.Text) * 0.01);
            lblMIrtra.Text = Convert.ToString(calculoIrtra);

            double calculoPaternidad = 0;
            if (txtMCantidadHijos.Text != string.Empty)
            {
                calculoPaternidad = Convert.ToInt32(txtMCantidadHijos.Text) * 133;
                lblMBonoPaternidad.Text = Convert.ToString(calculoPaternidad);
            }
            else
            {
                lblMBonoPaternidad.Text = "0";
            }


            lblMSalarioTotal.Text = Convert.ToString((Convert.ToDouble(txtMSalarioBase.Text)) + calculoPaternidad + 250);

            lblMSalarioLiquido.Text = Convert.ToString(Convert.ToDouble(lblMSalarioTotal.Text) - (CalculoIgss) - (calculoIrtra));

        }

        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Menu.aspx");
        }
    }
}