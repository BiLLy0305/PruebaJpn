<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CambioPass.aspx.cs" Inherits="Prueba.Views.CambioPass" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Cambio Password</title>
    <link href="//maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" rel="stylesheet">
    <script src="//maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js"></script>
    <script src="//cdnjs.cloudflare.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <link href="../css/myStyle.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="row">
            <br />
            <br />

            <div style="margin-left: 30%; margin-right: 10%">
                <h4>Cambio de Contraseña</h4>
                <br />
                <div class="form-group">
                    <label>Ingrese la nueva Contraseña:&nbsp;<span class="text-danger">*</span></label>
                    <asp:TextBox ID="txtPass" CssClass="form-control" runat="server" TextMode="Password"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label>Ingrese de nuevo la nueva Contraseña:&nbsp;<span class="text-danger">*</span></label>
                    <asp:TextBox ID="txtPass2" CssClass="form-control" runat="server" TextMode="Password"></asp:TextBox>
                </div>
                <div class="form-group">
                    <asp:Button runat="server" ID="btnGuardar" CssClass="btn btn-primary" Text="Guardar" OnClick="btnGuardar_Click" />
                </div>
                <div runat="server" id="divAlert" class="alert alert-warning" role="alert" visible="false">
                    Contraseña no coincide, favor revisar!
                </div>
                <div runat="server" id="divTE" class="alert alert-warning" role="alert" visible="false">
                    Error, link  Expirado!
                </div>
                <div runat="server" id="divSuccess" class="alert alert-success" role="alert" visible="false">
                    Cambio de password Exitoso!
                    <div>
                        <asp:Button runat="server" ID="btnLogin" CssClass="btn btn-info" Text="Regresar a Login" OnClick="btnLogin_Click" />
                    </div>
                </div>

            </div>

        </div>
    </form>
</body>
</html>
