﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Carrito.aspx.cs" Inherits="WebCatalogo.Carrito" %>

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
                <th scope="col" class="col-1">Precio</th>
                <!--<th scope="col" class="col-1 text-center">Cantidad</th>-->
                <th scope="col" class="col-2 text-lg-center">Acción</th>
            </tr>
        </thead>

        <asp:Repeater ID="repCarrito" runat="server" OnItemCommand="repCarrito_ItemCommand">
            <ItemTemplate>
                <tbody>
                    <tr>
                        <th scope="row" class="col-1">
                            <img src="<%#Eval("ImagenArt.URLImagen") %>" class="btn-close border display-6 shadow-sm" alt="..." />
                        </th>
                        <td class="col-2"><%#Eval("NombreArt")%> </td>
                        <td class="col-1"><%#Eval("MarcaArt.NombreMarca")%></td>
                        <td class="col-3"><%#Eval("DescripcionArt")%></td>
                        <td class="col-1"><%#Eval("PrecioArt","{0:F2}")%></td>
                        <!--<td class="col-1 text-center">1 </td>-->
                        <td class="col-2 text-center">
                            <asp:LinkButton ID="btnEliminar" CssClass="btn btn-outline-danger" runat="server" Text="Eliminar" CommandName="Eliminar" CommandArgument='<%#Eval("ID") %>' />
                            <asp:LinkButton ID="btnVerDetalle" CssClass="btn btn-outline-primary" runat="server" Text="Detalles" CommandName="VerDetalle" CommandArgument='<%#Eval("ID") %>' />
                        </td>
                    </tr>
                </tbody>
            </ItemTemplate>
        </asp:Repeater>

    </table>

</asp:Content>
