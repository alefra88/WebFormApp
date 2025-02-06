<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login2.aspx.cs" Inherits="WebFormApp.Login2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <div class="container">
        <h2>Iniciar sesión</h2>

        <div class="form-group">
            <label for="txtCorreo">Correo Electrónico</label>
            <asp:TextBox ID="txtCorreo" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvCorreo" runat="server" ControlToValidate="txtCorreo"
                ErrorMessage="El correo es obligatorio" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
        </div>

        <div class="form-group">
            <label for="txtContrasena">Contraseña</label>
            <asp:TextBox ID="txtContrasena" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvContrasena" runat="server" ControlToValidate="txtContrasena"
                ErrorMessage="La contraseña es obligatoria" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
        </div>

        <div class="form-group">
            <asp:Button ID="btnLogin" runat="server" CssClass="btn btn-primary" Text="Iniciar sesión" OnClick="btnLogin_Click" />
        </div>
    </div>
</asp:Content>
