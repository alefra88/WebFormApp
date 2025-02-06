<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebFormsApp.Login" %>
<!DOCTYPE html>
<html>
<head runat="server">
    <title>Login</title>
    <link href="Styles/bootstrap.css" rel="stylesheet" />
    <script src="Scripts/js/jquery.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h2>Iniciar sesión</h2>
            <div class="form-group">
                <label for="usuario">Usuario</label>
                <input type="text" id="usuario" class="form-control" maxLength="10" runat="server" />
            </div>
            <div class="form-group">
                <label for="contrasena">Contraseña</label>
                <input type="password" id="contrasena" class="form-control" maxLength="10" runat="server" />
            </div>
            <button type="submit" class="btn btn-primary" id="btnLogin" runat="server" OnClick="Login_Click">Ingresar</button>
        </div>
    </form>
</body>
</html>
