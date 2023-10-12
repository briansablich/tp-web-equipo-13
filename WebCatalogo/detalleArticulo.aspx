﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="detalleArticulo.aspx.cs" Inherits="WebCatalogo.detalleArticulo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div style="max-width:600px; width:100%" >

        <div id="carouselExample" class="carousel slide" <%--style="position: center;"--%> >

            <div class="carousel-inner" style="min-height:600px" >
                <asp:Repeater ID="repCarouselImagenes" runat="server">
                    <ItemTemplate>

                        <div class="carousel-item active" style="min-height:600px" <%--style="width: 500px; height: 500px; overflow: hidden; object-position: center; text-align: center; justify-content: center; align-items: center;"--%>>
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
        </div>

    </div>

</asp:Content>
