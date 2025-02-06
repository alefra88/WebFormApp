<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebFormsApp.Login" MasterPageFile="~/Site.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
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
</asp:Content>
