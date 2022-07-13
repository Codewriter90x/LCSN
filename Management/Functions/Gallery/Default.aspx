<%@ Page Title="Gestione Galleria" Language="C#" MasterPageFile="~/Management/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Management_Functions_Gallery_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script>
        window.onload = function () { selectMenuVoice("MainMenuItemGallery") };
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
          <div class="main-content">
        <div class="content-wrapper">
            <div class="row">
                <div class="col-sm-12 col-md-5">
                    <div class="content-header">Gestione area Galleria</div>
                    <p class="content-sub-header">Aggiungi, modifica e visualizza dettagli relativa alla tua galleria.</p>
                </div>
            </div>
            <section id="extended">
                <div class="row">

                    <div class="col-sm-12">
                        <div class="card">
                            <div class="card-header">
                                <div class="row">
                                    <div class="col-lg-9 col-md-6 col-sm-12">
                                        <h4 class="card-title">Lista Prodotti</h4>
                                    </div>
                                    <div class="col-lg-3 col-md-6 col-sm-12 ">
                                        <div class="text-right">
                                            <asp:HyperLink NavigateUrl="~/Gestione/Funzioni/Blog/Nuovo" runat="server">
                                                <span class="badge badge-primary mr-1 badge-lg right">
                                                    <i class="fa fa-plus"></i> Crea Nuovo</span>
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
                                                <th style="text-align:left;"><asp:literal text="Nome" runat="server"/></th>
                                                <th style="text-align: center"><i class="ft-eye font-medium-3 mr-2 "></i></th>
                                                <th><asp:literal text="Data Ins" runat="server" /></th>
                                            </tr>
                                            <tr class="unstyled">
                                                <td style="text-align:left;">
                                                    <asp:TextBox runat="server" ClientIDMode="Static" CssClass="form-control form-control-sm" autocomplete="off" 
                                                        ID="txtNome" placeholder="Nome" AutoCompleteType="None" onkeyup="GetPhotos()" />
                                                </td>
                                                <td style="text-align:center;">
                                                    <asp:DropDownList runat="server" ClientIDMode="Static" CssClass="form-control form-control-sm"
                                                                      ID="DdlTableSatatus" onchange="GetPhotos()">
                                                        <asp:ListItem Text="" Value="" />
                                                        <asp:ListItem Text="Nascosti" Value="0" meta:resourcekey="ddlTableFilterInProgress" />
                                                        <asp:ListItem Text="Visibili" Value="1" meta:resourcekey="ddlTableFilterCompleted" />
                                                    </asp:DropDownList>
                                                </td> 
                                                <td style="text-align:center;">
                                                    <asp:TextBox runat="server" ClientIDMode="Static" CssClass="form-control form-control-sm" autocomplete="off" 
                                                        ID="txtCreazione" placeholder="Data Inserimento" AutoCompleteType="None" onkeyup="GetPhotos()" />
                                                </td>
                                            </tr>
                                        </thead>
                                        <tbody id="tableContentPhotos">

                                            <tr class='dataItem'>
                                                <td colspan="7"><i class="ft-loader spinner"></i>&nbsp;<asp:literal text="Caricamento dati in corso..." runat="server" meta:resourcekey="lblDataLoading" /></td>
                                            </tr>
                                            <script type="text/javascript">

                                                function GetPhotos() {
                                                    var txtNome = document.getElementById("txtNome").value;
                                                    var ddlTableSatatus = document.getElementById("<%=DdlTableSatatus.ClientID%>");
                                                    var SelStatus = ddlTableSatatus.options[ddlTableSatatus.selectedIndex].value;

                                                    $.ajax({
                                                        type: "POST",
                                                        url: "//admin.Laboratorioforgia.it/App_Services/DynamicGalleryLoader.asmx/GetPhotos",
                                                        data: "{'ID':'', 'Title':'" + txtNome + "'}",
                                                        contentType: "application/json",
                                                        datatype: "json",
                                                        success: function (responseFromServer) {
                                                            console.log(responseFromServer);
                                                            var data = responseFromServer.d;
                                                            var composer = "";

                                                            for (i = 0; i < data.length; i++) {
                                                                composer += "<tr class='dataItem'>";
                                                                composer += "<td style='text-align: left;'>" 
                                                                composer += "<a href='//admin.laboratorioforgia.it/Management/Functions/Gallery/View/" + data[i]['ID'] + "/gallery'>" + data[i]['Title'] + "</td>";
                                                                composer += "<td>" + data[i]['Visible'] + "</td>";
                                                                composer += "<td style='text-align: left;'>" + data[i]['DateIns'] + "</td>";
                                                                composer += "</tr>";
                                                            }
                                                            $(".dataItem").remove();
                                                            document.getElementById("tableContentPhotos").innerHTML += composer;

                                                            //let audio = new Audio('//admin.gomyro.com/Assets/Audio/clearly.mp3');
                                                            //audio.play();
                                                        },
                                                        error: function (responseFromServer) {
                                                            console.log(responseFromServer);
                                                        }
                                                    });
                                                };
                                                GetPhotos();

                                            </script>




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

