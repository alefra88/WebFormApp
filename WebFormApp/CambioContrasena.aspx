<%@ Page Title="Cambio de Contraseña" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CambioContrasena.aspx.cs" Inherits="WebFormApp.CambioContrasena" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-4">
        <h2 class="text-center">Cambio de Contraseña</h2>
        
        <div class="mb-3">
            <label for="txtNuevaContrasena" class="form-label">Nueva Contraseña:</label>
            <asp:TextBox ID="txtNuevaContrasena" runat="server" CssClass="form-control" TextMode="Password" required="true"></asp:TextBox>
        </div>

        <div class="mb-3">
            <label for="txtConfirmarContrasena" class="form-label">Confirmar Nueva Contraseña:</label>
            <asp:TextBox ID="txtConfirmarContrasena" runat="server" CssClass="form-control" TextMode="Password" required="true"></asp:TextBox>
        </div>

        <div class="text-center">
            <asp:Button ID="btnGuardar" runat="server" Text="Guardar Cambios" CssClass="btn btn-primary" OnClick="btnGuardar_Click" />
        </div>
    </div>
</asp:Content>
