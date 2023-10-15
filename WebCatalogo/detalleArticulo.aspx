<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="detalleArticulo.aspx.cs" Inherits="WebCatalogo.detalleArticulo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div style="max-width: 600px; width: 100%;">

        <div id="carouselExample" class="carousel slide" <%--style="position: center;"--%>>

            <div class="carousel-inner" style="min-height: 600px">
                <asp:Repeater ID="repCarouselImagenes" runat="server">
                    <ItemTemplate>
                        <div class="<%# Container.ItemIndex == 0 ? "carousel-item active" : "carousel-item" %>" style="min-height: 600px" >
                            <img src="<%#Eval("URLImagen")%>" <%--style="width: 100%; height: 100%; object-fit: cover;"--%> class="d-block w-100" alt="...">
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>

            <button class="carousel-control-prev" type="button" data-bs-target="#carouselExample" data-bs-slide="prev">
                <span class="carousel-control-prev-icon" style="background-color: grey; border-radius: 40%;" aria-hidden="true"></span>
                <span class="visually-hidden">Previous</span>
            </button>

            <button class="carousel-control-next" type="button" data-bs-target="#carouselExample" data-bs-slide="next">
                <span class="carousel-control-next-icon" style="background-color: grey; border-radius: 40%; position: absolute; top: 50%; transform: translateY(-50%); right: 7%"
                    aria-hidden="true"></span>
                <span class="visually-hidden">Next</span>
            </button>

            <div style="text-align: center">
                <asp:Label ID="lblNombre" runat="server" Text="" CssClass="h3"></asp:Label>
                <br />
                <asp:Label ID="lblDescripcion" runat="server" Text="" CssClass="h4"></asp:Label>
                <br />
                <asp:Label ID="lblPrecio" runat="server" Text="" CssClass="display-5"></asp:Label>
                <div style="text-align: center; padding:10px 10px;">
                    <asp:Button ID="btnAgregar" CssClass="btn btn-primary" runat="server" Text="Agregar" OnClick="btnAgregar_Click" />
                    <asp:Button ID="btnVolver" CssClass="btn btn-secondary" runat="server" Text="Volver" OnClick="btnVolver_Click" />
                </div>
            </div>

        </div>

    </div>

</asp:Content>
