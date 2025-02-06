﻿<%@ Page Title="Inicio" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebFormApp.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h2>Bienvenido al Panel de Administración</h2>

        <p>Seleccione una de las opciones:</p>

        <div class="form-group">
            <asp:Button ID="btnCrearUsuario" runat="server" CssClass="btn btn-primary" Text="Crear Nuevo Usuario" OnClick="btnCrearUsuario_Click" />
        </div>

        <div class="form-group">
            <asp:Button ID="btnVerUsuarios" runat="server" CssClass="btn btn-secondary" Text="Ver Usuarios" OnClick="btnVerUsuarios_Click" />
        </div>

    </div>
</asp:Content>
