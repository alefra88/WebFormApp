<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="WebFormApp.Usuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
 <div class="container">
        <h2>Usuarios Registrados</h2>

        <asp:GridView ID="gvUsuarios" runat="server" CssClass="table table-striped" AutoGenerateColumns="False" OnRowCommand="gvUsuarios_RowCommand">
            <Columns>
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre" />
                <asp:BoundField DataField="ApellidoPaterno" HeaderText="Apellido Paterno" SortExpression="ApellidoPaterno" />
                <asp:BoundField DataField="ApellidoMaterno" HeaderText="Apellido Materno" SortExpression="ApellidoMaterno" />
                <asp:BoundField DataField="CorreoElectronico" HeaderText="Correo Electrónico" SortExpression="CorreoElectronico" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button runat="server" CommandName="VerDetalle" CommandArgument='<%# Eval("IdUsuario") %>' Text="Consultar" CssClass="btn btn-info" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>

        <hr />
       
        
    </div>
</asp:Content>
