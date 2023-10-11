<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebCatalogo.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row row-cols-1 row-cols-md-3 g-4">

        <asp:Repeater ID="repArticulosCards" runat="server">
            <ItemTemplate>

                <div class="col">
                    <div class="card">
                        <img src="" class="card-img-top" alt="...">
                        <div class="card-body">
                            <h5 class="card-title"><%#Eval("NombreArt")%></h5>
                            <p class="card-text"><%#Eval("DescripcionArt")%></p>
                            <asp:Button ID="btnAgregar" runat="server" Text="Agregar" />
                            <asp:Button ID="btnDetalle" runat="server" Text="Detalle" />
                        </div>
                    </div>
                </div>

            </ItemTemplate>
        </asp:Repeater>

    </div>

</asp:Content>
