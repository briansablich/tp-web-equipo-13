<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebCatalogo.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server" CssClass="contenedor">
    <div>

        <div class="justify-content-center align-items-center mb-4 row row-cols-md-4">
            <div class="form-inline my-2 my-lg-0" style="display: flex;">
                <asp:TextBox ID="txtBuscador" runat="server" Style="margin-right: 3%;" class=" mr-sm-2" placeholder="Buscar..."></asp:TextBox>
                <asp:Button ID="btnBuscador" runat="server" Text="Buscar" class="btn btn-outline-success my-2 my-sm-0" OnClick="btnBuscador_Click" CommandArgument='<%#txtBuscador.Text%>' />
            </div>

            <div style="width: 100%;" class="my-4 my-lg-4">
                <asp:Label ID="lblVacio" Style="font-size: 20px; font-weight: bold;" runat="server" Text="No hay resultados en la busqueda..."></asp:Label>
            </div>
        </div>

        <div class="row row-cols-1 row-cols-md-3 g-4 shadow">
            <asp:Repeater ID="repArticulosCards" runat="server">
                <ItemTemplate>

                    <div class="col">
                        <div class="card" style="min-height:750px">
                            <img src="<%#Eval("ImagenArt.URLImagen")%>"  <%--width="200px" height="300px" padding="10px" class="card-img-top"--%> alt="...">
                            <div class="card-body" style="display:flex; flex-flow:column; justify-content:center; align-items:center; text-align:center;">
                                <h5 class="card-title"><%#Eval("NombreArt")%></h5>
                                <p class="card-text"><%#Eval("MarcaArt.NombreMarca")%></p>
                                <p class="card-text"><%#Eval("DescripcionArt")%></p>
                                <p class="card-text">$ <%#Eval("PrecioArt","{0:F2}")%></p>
                                <div style="padding-top:10px;">
                                    <asp:Button ID="btnAgregar" CssClass="btn btn-primary" runat="server" Text="Agregar" CommandArgument='<%#Eval("ID") %>' CommandName="idArticulo" OnClick="btnAgregar_Click" />
                                    <asp:Button ID="btnDetalle" CssClass="btn btn-secondary" runat="server" Text="Detalle" CommandArgument='<%#Eval("ID")%>' CommandName="idArticulo" OnClick="btnDetalle_Click" />
                                </div>
                            </div>
                        </div>
                    </div>

                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
</asp:Content>
