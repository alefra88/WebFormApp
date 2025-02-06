<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AltaUsuarios2.aspx.cs" Inherits="WebFormApp.AltaUsuarios2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <div class="container">
        <h2>Alta de Usuarios</h2>

        <div class="form-group">
            <label for="txtNombre">Nombre</label>
            <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" MaxLength="50"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvNombre" runat="server" ControlToValidate="txtNombre"
                ErrorMessage="El nombre es obligatorio" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
        </div>

        <div class="form-group">
            <label for="txtApellidoPaterno">Apellido Paterno</label>
            <asp:TextBox ID="txtApellidoPaterno" runat="server" CssClass="form-control" MaxLength="50"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvApellidoPaterno" runat="server" ControlToValidate="txtApellidoPaterno"
                ErrorMessage="El apellido paterno es obligatorio" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
        </div>

        <div class="form-group">
            <label for="txtApellidoMaterno">Apellido Materno</label>
            <asp:TextBox ID="txtApellidoMaterno" runat="server" CssClass="form-control" MaxLength="50"></asp:TextBox>
        </div>

        <div class="form-group">
            <label for="txtFechaNacimiento">Fecha de Nacimiento</label>
            <asp:TextBox ID="txtFechaNacimiento" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvFechaNacimiento" runat="server" ControlToValidate="txtFechaNacimiento"
                ErrorMessage="La fecha de nacimiento es obligatoria" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
        </div>

        <div class="form-group">
            <label for="txtCorreo">Correo Electrónico</label>
            <asp:TextBox ID="txtCorreo" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvCorreo" runat="server" ControlToValidate="txtCorreo"
                ErrorMessage="El correo es obligatorio" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="revCorreo" runat="server"
                ControlToValidate="txtCorreo"
                ValidationExpression="^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"
                ErrorMessage="Formato de correo incorrecto"
                ForeColor="Red" Display="Dynamic">
            </asp:RegularExpressionValidator>
        </div>

        <div class="form-group">
            <asp:Button runat="server" CssClass="btn btn-primary" Text="Guardar" OnClick="btnGuardar_Click" />
        </div>
    </div>
</asp:Content>
