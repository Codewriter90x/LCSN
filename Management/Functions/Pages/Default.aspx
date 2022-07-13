<%@ Page Title="Gestione Pagine" Language="C#" MasterPageFile="~/Management/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Management_Functions_Pages_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script>
        window.onload = function () { selectMenuVoice("MainMenuItemPages") };
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="main-content">
        <div class="content-wrapper">
            <div class="row">
                <div class="col-sm-12 col-md-5">
                    <div class="content-header">Gestione area Pagine</div>
                    <p class="content-sub-header">Aggiungi, modifica e visualizza dettagli relativi ai tuoi articoli.</p>
                </div>
            </div>

            <section id="extended">
                <div class="row">
                    <div class="col-12">
                        <div class="card">
                            <div class="card-header">
                                <div class="row">
                                    <div class="col-lg-9 col-md-6 col-sm-12">
                                        <h4 class="card-title">Lista Articoli</h4>
                                    </div>
                                    <div class="col-lg-3 col-md-6 col-sm-12 ">
                                        <div class="text-right">
                                            <asp:HyperLink NavigateUrl="~/Management/Functions/Pages/New" runat="server">
                                                <span class="badge badge-primary mr-1 badge-lg right">
                                                    <i class="fa fa-plus"></i> Crea Nuova</span>
                                            </asp:HyperLink>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="card-body">
                                <div class="card-block">
                                    <table class="table table-responsive-md-md text-center">
                                        <thead>
                                            <tr>
                                                <th style="text-align: left">Nome</th>
                                                <th>
                                                    <span data-toggle="tooltip" data-placement="top" title="Descrizione / Tags" data-original-title="Descrizione / Tags">D/T
                                                    </span>
                                                </th>
                                                <th>
                                                    <span data-toggle="tooltip" data-placement="top" title="Social Data" data-original-title="Social Data">S/TDI
                                                    </span>
                                                </th>
                                                <th>Data Creazione</th>

                                            </tr>
                                        </thead>
                                        <tbody>


                                            <asp:ListView ID="ListViewPages" runat="server" EnableModelValidation="True">
                                                <ItemTemplate>
                                                    <tr>
                                                        <td style="text-align: left">
                                                            <asp:HyperLink runat="server" ToolTip='<%# "Codice Pagina: " + Eval("Code") %>'
                                                                NavigateUrl='<%# "view/" + Eval("id") + "/" + Regex.Replace(Eval("Title").ToString(), "[^A-Za-z0-9 _]", "-").ToString().Replace(" ", "_")%>'>
                                                                <%# Eval("Title") %>
                                                            </asp:HyperLink>
                                                        </td>
                                                        <td>
                                                            <%# Eval("GoogleTagsStatus").ToString()%>
                                                        </td>
                                                        <td>
                                                            <%# Eval("SocialTagsStatus").ToString()%>
                                                        </td>  
                                                        <td>
                                                            <%# Eval("DateIns").ToString() %>
                                                        </td>                                                       
                                                    </tr>

                                                </ItemTemplate>
                                                <LayoutTemplate>
                                                    <tr runat="server" id="itemPlaceholder" />
                                                </LayoutTemplate>
                                            </asp:ListView>                                          

                                        </tbody>
                                    </table>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </section>

        </div>
    </div>


</asp:Content>

