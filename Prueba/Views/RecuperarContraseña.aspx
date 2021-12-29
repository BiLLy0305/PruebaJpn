<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RecuperarContraseña.aspx.cs" Inherits="Prueba.Views.RecuperarContraseña" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Recuperar contraseña</title>
    <link href="//maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" rel="stylesheet">
    <script src="//maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js"></script>
    <script src="//cdnjs.cloudflare.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <link href="../css/myStyle.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="wrapper fadeInDown">
            <div id="formContent">
                <!-- Tabs Titles -->
                <br />
                <!-- Icon -->
                <div class="fadeIn first">
                    <h4>Ingrese su Email y fecha de Nacimiento</h4>
                </div>
                <hr />
                <!-- Login Form -->
                 <div style="margin-left: 15%">
                    <asp:TextBox runat="server" CssClass="form-control" ID="txtEmail"  TextMode="Email" Width="80%"></asp:TextBox>
                    <br />
                    <asp:TextBox runat="server" CssClass="form-control" ID="txtFechaN" TextMode="Date" Width="80%"></asp:TextBox>

                </div>
                <br />
                <asp:Button runat="server" ID="btnEnviar" Text="EnviarCorreo" CssClass="btn-primary" OnClick="btnEnviar_Click" />

                 <div runat="server" id="divSuccess" class="alert alert-success" role="alert" visible="false">
                    Favor de revisar su correo!
                </div>

                <div runat="server" id="divAlert" class="alert alert-warning" role="alert" visible="false">
                    Error, Fecha de nacimiento incorrecta favor revisar!
                </div>

            </div>
        </div>
    </form>
</body>
</html>
