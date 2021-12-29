<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Empleados.aspx.cs" Inherits="Prueba.Views.Empleados" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Empleados</title>
    <link href="../css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../js/bootstrap.min.js" rel="stylesheet" type="text/javascript" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <asp:Panel runat="server" ID="pnlLista">
                <div class="row">
                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                        <div class="ibox float-e-margins">
                            <div class="ibox-title">
                                <h4>Listado de Empleados</h4>
                            </div>
                            <div class="ibox-content">
                                <div class="table-responsive">
                                    <asp:GridView runat="server" ID="grdEmpleados"
                                        AutoGenerateColumns="false" CssClass="table table-striped table-bordered table-hover"
                                        OnRowCommand="grdEmpleados_RowCommand"
                                        OnPageIndexChanging="grdEmpleados_PageIndexChanging"
                                        AllowPaging="true"
                                        PageSize="8">
                                        <Columns>
                                            <asp:BoundField DataField="DPI" HeaderText="Dpi" />
                                            <asp:BoundField DataField="NOMBRECOMPLETO" HeaderText="Nombre" />
                                            <asp:BoundField DataField="CANTIDADHIJOS" HeaderText="Hijos" />
                                            <asp:BoundField DataField="SALARIOBASE" HeaderText="Salario Base" />
                                            <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="200px">
                                                <ItemTemplate>
                                                    <asp:Button ID="btnEdit" runat="server" Text="Editar" CssClass="btn btn-warning" CommandName="ed" />
                                                    <asp:Button ID="btnDelete" runat="server" Text="Eliminar" CssClass="btn btn-danger" CommandName="de" OnClientClick="return confirm('¿Esta seguro de eliminar el registro?');" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                                <asp:Button runat="server" ID="btnNuevo" CssClass="btn btn-default" Text="Crear Empleado" OnClick="btnNuevo_Click"></asp:Button>
                                <asp:Button runat="server" ID="btnRegresar" CssClass="btn btn-danger" Text="Salir" PostBackUrl="~/Menu.aspx" OnClick="btnRegresar_Click"></asp:Button>

                                <asp:Label runat="server" ID="lblMensaje" ForeColor="Red" Visible="false"></asp:Label>
                            </div>
                        </div>
                    </div>
                </div>
            </asp:Panel>
            <br />

            <asp:Panel runat="server" ID="pnlAgregar" Visible="false" BackColor="White">
                <div class="row">
                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                        <div class="ibox float-e-margins">
                            <div class="ibox-title">
                                <h3>Crear Empleado </h3>
                            </div>
                            <br />
                            <div style="margin-left: 10%; margin-right: 10%">

                                <div class="form-group">
                                    <label>Dpi:&nbsp;<span class="text-danger">*</span></label>
                                    <asp:TextBox ID="txtDpi" TextMode="Number" CssClass="form-control" runat="server" required="true"></asp:TextBox>
                                </div>

                                <div class="form-group">
                                    <label>Nombre Completo:&nbsp;<span class="text-danger">*</span></label>
                                    <asp:TextBox ID="txtNombre" CssClass="form-control" runat="server" MaxLength="128"></asp:TextBox>
                                </div>

                                <div class="form-group">
                                    <label>Cantidad Hijos:</label>
                                    <asp:TextBox ID="txtCantidadHijos" TextMode="Number" CssClass="form-control" runat="server" required="true"></asp:TextBox>
                                </div>

                                <div class="form-group">
                                    <label>Salario Base:&nbsp;<span class="text-danger">*</span></label>
                                    <asp:TextBox ID="txtSalarioBase" CssClass="form-control" runat="server" OnTextChanged="txtSalarioBase_TextChanged" AutoPostBack="true"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <label>Igss:</label>
                                    <asp:Label ID="lblIgss" runat="server"></asp:Label>
                                </div>
                                <div class="form-group">
                                    <label>Irtra:</label>
                                    <asp:Label ID="lblIrtra" runat="server"></asp:Label>
                                </div>
                                <div class="form-group">
                                    <label>Bono Paternidad:</label>
                                    <asp:Label ID="lblBonoPaternidad" runat="server"></asp:Label>
                                </div>
                                <div class="form-group">
                                    <label>Salario Total:</label>
                                    <asp:Label ID="lblSalarioTotal" runat="server"></asp:Label>
                                </div>
                                <div class="form-group">
                                    <label>Salario Liquido:</label>
                                    <asp:Label ID="lblSalarioLiquido" runat="server"></asp:Label>
                                </div>
                                <table>
                                    <tr>
                                        <td>
                                            <asp:Button runat="server" ID="btnGuardar" CssClass="btn btn-primary" Text="Guardar" OnClick="btnGuardar_Click" />
                                        </td>
                                        <td>
                                            <asp:Button runat="server" ID="btnCancelar" CssClass="btn btn-danger" OnClick="btnCancelar_Click" Text="Cancelar" UseSubmitBehavior="false" />
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
            </asp:Panel>

            <asp:Panel runat="server" ID="pnlModificar" Visible="false" BackColor="White">
                <div class="row">
                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                        <div class="ibox float-e-margins">
                            <div class="ibox-title">
                                <h3>Modificar Empleado </h3>
                            </div>
                            <br />
                            <div style="margin-left: 10%; margin-right: 10%">
                                <asp:Label runat="server" ID="lblCodigo" Visible="false"></asp:Label>
                                <div class="form-group">
                                    <label>Dpi:&nbsp;<span class="text-danger">*</span></label>
                                    <asp:TextBox ID="txtMDpi" TextMode="Number" CssClass="form-control" runat="server" required="true" Enabled="false"></asp:TextBox>
                                </div>

                                <div class="form-group">
                                    <label>Nombre Completo:&nbsp;<span class="text-danger">*</span></label>
                                    <asp:TextBox ID="txtMNombre" CssClass="form-control" runat="server" MaxLength="128"></asp:TextBox>
                                </div>

                                <div class="form-group">
                                    <label>Cantidad Hijos:</label>
                                    <asp:TextBox ID="txtMCantidadHijos" TextMode="Number" CssClass="form-control" runat="server" required="true"></asp:TextBox>
                                </div>

                                <div class="form-group">
                                    <label>Salario Base:&nbsp;<span class="text-danger">*</span></label>
                                    <asp:TextBox ID="txtMSalarioBase" CssClass="form-control" runat="server" OnTextChanged="txtMSalarioBase_TextChanged" AutoPostBack="true"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <label>Igss:</label>
                                    <asp:Label ID="lblMIgss" runat="server"></asp:Label>
                                </div>
                                <div class="form-group">
                                    <label>Irtra:</label>
                                    <asp:Label ID="lblMIrtra" runat="server"></asp:Label>
                                </div>
                                <div class="form-group">
                                    <label>Bono Paternidad:</label>
                                    <asp:Label ID="lblMBonoPaternidad" runat="server"></asp:Label>
                                </div>
                                <div class="form-group">
                                    <label>Salario Total:</label>
                                    <asp:Label ID="lblMSalarioTotal" runat="server"></asp:Label>
                                </div>
                                <div class="form-group">
                                    <label>Salario Liquido:</label>
                                    <asp:Label ID="lblMSalarioLiquido" runat="server"></asp:Label>
                                </div>
                                <table>
                                    <tr>
                                        <td>
                                            <asp:Button runat="server" ID="btnModificar" CssClass="btn btn-primary" Text="Modificar" OnClick="btnModificar_Click" />
                                        </td>
                                        <td>
                                            <asp:Button runat="server" ID="btnMCancelar" CssClass="btn btn-danger" OnClick="btnMCancelar_Click" Text="Cancelar" />
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
            </asp:Panel>

        </div>
    </form>
</body>
</html>
