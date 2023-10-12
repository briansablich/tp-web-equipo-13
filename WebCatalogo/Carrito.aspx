<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Carrito.aspx.cs" Inherits="WebCatalogo.Carrito" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="table position-relative">
        <thead>
            <tr>
                <th scope="col" class="col-1">Icono</th>
                <th scope="col" class="col-2">Nombre</th>
                <th scope="col" class="col-1">Marca</th>
                <th scope="col" class="col-3">Descripción</th>
                <th scope="col" class="col-2">Precio</th>
                <th scope="col" class="col-2">Cantidad</th>
            </tr>
        </thead>
    </table>

    <asp:Repeater ID="repCarrito" runat="server">
        <ItemTemplate>
            <table class="table position-relative">
                <tbody>
                    <tr>
                        <th scope="row" class="col-1">
                            <img src="<%#Eval("ImagenArt.URLImagen") %>" class="btn-close border display-6 shadow-sm" alt="..." />
                        </th>
                        <td class="col-2"><%#Eval("NombreArt")%> </td>
                        <td class="col-1"><%#Eval("MarcaArt.NombreMarca")%></td>
                        <td class="col-3"><%#Eval("DescripcionArt")%></td>
                        <td class="col-2"><%#Eval("PrecioArt")%></td>
                        <td class="col-2">1 </td>
                    </tr>
                </tbody>
            </table>
        </ItemTemplate>
    </asp:Repeater>

</asp:Content>
