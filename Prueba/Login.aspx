<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Prueba.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>

    <link href="//maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" rel="stylesheet">
    <script src="//maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js"></script>
    <script src="//cdnjs.cloudflare.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <link href="css/myStyle.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="wrapper fadeInDown">
            <div id="formContent">
                <!-- Tabs Titles -->
                <br />
                <!-- Icon -->
                <div class="fadeIn first">
                    <h4>Iniciar Sesion</h4>
                </div>
                <br />
                <!-- Login Form -->
                <div style="margin-left: 15%">
                    <asp:TextBox runat="server" CssClass="form-control" ID="txtEmail" placeHolder="Email" TextMode="Email" Width="80%"></asp:TextBox>
                    <br />
                    <asp:TextBox runat="server" CssClass="form-control" ID="txtPass" placeHolder="Password" TextMode="Password" Width="80%"></asp:TextBox>

                </div>
                <br />
                <asp:Button runat="server" ID="btnEntrar" Text="Entrar" CssClass="btn-primary" OnClick="btnEntrar_Click" />

                <div runat="server" id="divAlert" class="alert alert-warning" role="alert" visible="false">
                    Error, favor de revisar sus credenciales!
                </div>

                <!-- Remind Passowrd -->
                <div id="formFooter">
                    <a class="underlineHover" href="Views/RecuperarContraseña.aspx">Recuperar Contraseña?</a>
                </div>
                <br />


            </div>
        </div>
    </form>
</body>
</html>
