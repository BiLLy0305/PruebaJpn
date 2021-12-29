<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Palindromos.aspx.cs" Inherits="Prueba.Views.Palindromos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Palindromos</title>
    <link href="../css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../js/bootstrap.min.js" rel="stylesheet" type="text/javascript" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Panel runat="server" ID="pnlPalindromos" BackColor="White">
                <div class="row">
                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                        <div class="ibox float-e-margins">
                            <div class="ibox-title">
                                <h3>Palindromos</h3>
                            </div>
                            <br />
                            <div style="margin-left: 10%; margin-right: 10%">

                                <div class="form-group">
                                    <label>Texto:&nbsp;<span class="text-danger">*</span></label>
                                    <asp:TextBox ID="txtTexto" CssClass="form-control" runat="server" required="true"></asp:TextBox>
                                </div>

                                <div class="form-group">
                                    <asp:Label runat="server" ID="lblCantidad"></asp:Label>
                                </div>

                                <div class="form-group">
                                    <asp:Label runat="server" ID="lblResultado"></asp:Label>
                                </div>


                                <table>
                                    <tr>
                                        <td>
                                            <asp:Button runat="server" ID="btnBuscar" CssClass="btn btn-primary" Text="Buscar" OnClick="btnBuscar_Click" />
                                        </td>
                                        <td>
                                            <asp:Button runat="server" ID="btnCancelar" CssClass="btn btn-danger" OnClick="btnCancelar_Click" Text="Cancelar" UseSubmitBehavior="false" />
                                        </td>
                                        <td>
                                            <asp:Button runat="server" ID="btnRegresar" CssClass="btn btn-danger" Text="Salir" PostBackUrl="~/Menu.aspx" OnClick="btnRegresar_Click"></asp:Button>
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
