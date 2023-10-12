<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebCatalogo.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row row-cols-1 row-cols-md-3 g-4 shadow">

        <asp:Repeater ID="repArticulosCards" runat="server">
            <ItemTemplate>

                <div class="col">
                    <div class="card">
                        <img src="<%#Eval("ImagenArt.URLImagen")%>" width= "200px" height="300px" padding="10px" class="card-img-top" alt="...">
                        <div class="card-body">
                            <h5 class="card-title"><%#Eval("NombreArt")%></h5>
                            <p class="card-text"><%#Eval("MarcaArt.NombreMarca")%></p>
                            <p class="card-text"><%#Eval("DescripcionArt")%></p>
                            <p class="card-text"><%#Eval("PrecioArt")%></p>
                            <asp:Button ID="btnAgregar" CssClass="btn btn-primary" runat="server" Text="Agregar" CommandArgument='<%#Eval("ID") %>' CommandName="idArticulo" OnClick="btnAgregar_Click"/>
                            <asp:Button ID="btnDetalle" CssClass="btn btn-primary" runat="server" Text="Detalle" CommandArgument='<%#Eval("ID")%>' CommandName="idArticulo" OnClick="btnDetalle_Click" />
                        </div>
                    </div>
                </div>

            </ItemTemplate>
        </asp:Repeater>

    </div>

</asp:Content>
