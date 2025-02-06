<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DetalleUsuario.aspx.cs" Inherits="WebFormApp.DetalleUsuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Detalles del Usuario</h2>

    
    <div class="form-group">
        <asp:Label ID="lblNombre" runat="server" Text="Nombre:" CssClass="control-label"></asp:Label>
        <asp:TextBox ID="txtNombre" runat="server" ReadOnly="true" CssClass="form-control"></asp:TextBox>
    </div>

    <div class="form-group">
        <asp:Label ID="lblApellidoPaterno" runat="server" Text="Apellido Paterno:" CssClass="control-label"></asp:Label>
        <asp:TextBox ID="txtApellidoPaterno" runat="server" ReadOnly="true" CssClass="form-control"></asp:TextBox>
    </div>

    <div class="form-group">
        <asp:Label ID="lblApellidoMaterno" runat="server" Text="Apellido Materno:" CssClass="control-label"></asp:Label>
        <asp:TextBox ID="txtApellidoMaterno" runat="server" ReadOnly="true" CssClass="form-control"></asp:TextBox>
    </div>

    <div class="form-group">
        <asp:Label ID="lblFechaNacimiento" runat="server" Text="Fecha de Nacimiento:" CssClass="control-label"></asp:Label>
        <asp:TextBox ID="txtFechaNacimiento" runat="server" ReadOnly="true" CssClass="form-control" TextMode="Date"></asp:TextBox>
    </div>

    <div class="form-group">
        <asp:Label ID="lblCorreo" runat="server" Text="Correo Electrónico:" CssClass="control-label"></asp:Label>
        <asp:TextBox ID="txtCorreo" runat="server" ReadOnly="true" CssClass="form-control"></asp:TextBox>
    </div>

    <div class="form-group">
        <asp:Button ID="btnRegresar" runat="server" Text="Regresar" OnClick="btnRegresar_Click" CssClass="btn btn-primary" />
    </div>
</asp:Content>
