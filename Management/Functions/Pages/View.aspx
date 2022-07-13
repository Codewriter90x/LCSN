<%@ Page Title="Vedi Pagina" Language="C#" MasterPageFile="~/Management/MasterPage.master" AutoEventWireup="true" CodeFile="View.aspx.cs" Inherits="Management_Functions_Pages_View" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script>
        window.onload = function () { selectMenuVoice("MainMenuItemPages") };
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="main-content">
        <div class="content-wrapper">
            <!-- Basic form layout section start -->
            <section id="basic-form-layouts">
                <div class="row">
                    <div class="col-sm-12">
                        <div class="content-header">Modifica Pagina Sito Web</div>
                    </div>

                </div>
                <div class="row">
                    <div class="col-sm-12">
                        <asp:Literal ID="lblResult" runat="server" />

                    </div>
                </div>

                <div class="row">
                    <div class="col-md-12">
                        <div class="card">
                            <!--<div class="card-header">
                                    <h4 class="card-title" id="basic-layout-form">Dettagli articolo</h4>
                                    <p class="mb-0">
                                        This is the most basic and default form having form sections. To add form section use
                                        <code>.form-section</code> class with any heading tags. This form has the buttons on
                                        the bottom left corner which is the default position.
                                    </p>
                                </div>-->
                            <div class="card-body">
                                <div class="px-3">
                                    <div class="form">
                                        <div class="form-body">
                                            <h4 class="form-section"><i class="fa fa-rss"></i>Dati di base</h4>
                                            <div class="row">
                                                <div class="col-md-12">
                                                    <div class="form-group">
                                                        <label for="projectinput1">Titolo</label>
                                                        <asp:RequiredFieldValidator ID="rvf1" runat="server" ErrorMessage="*" ForeColor="Red" Display="Dynamic"
                                                            ControlToValidate="txtTitolo" ValidationGroup="ModifyPageWS" SetFocusOnError="true" />
                                                        <asp:TextBox runat="server" class="form-control" ID="txtTitolo" />
                                                    </div>
                                                    <div class="form-group">
                                                        <label for="projectinput8">Contenuto</label>
                                                        <asp:RequiredFieldValidator ID="rfv2" runat="server" ErrorMessage="*" ForeColor="Red" Display="Dynamic"
                                                            ControlToValidate="txtContenuto" ValidationGroup="ModifyPageWS" SetFocusOnError="true" />
                                                        <asp:TextBox ID="txtContenuto" BasePath="/ckeditor/" runat="server"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>


                                            <h4 class="form-section">
                                                <i class="fa fa-facebook"></i>
                                                <i class="fa fa-google"></i>
                                                <i class="fa fa-instagram"></i>
                                                <i class="fa fa-twitter"></i>Profilo social
                                            </h4>

                                            <div class="row">
                                                <div class="col-md-12">
                                                    <div class="form-group">
                                                        <label for="companyName">Descrizione Pagina <small>
                                                            <asp:Label runat="server" ID="lblMetaDescPageLenght" Text="Min 80 Max 200 caratteri" /></small></label>
                                                        <asp:RequiredFieldValidator ID="rfv3" runat="server" ErrorMessage="*" ForeColor="Red" Display="Dynamic"
                                                            ControlToValidate="txtDescrizione" ValidationGroup="ModifyPageWS" SetFocusOnError="true" />
                                                        <asp:TextBox runat="server" TextMode="MultiLine" class="form-control" ID="txtDescrizione" />
                                                    </div>
                                                </div>
                                                <div class="col-md-12">
                                                    <div class="form-group">
                                                        <label for="companyName">Tag Pagina</label>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" ForeColor="Red" Display="Dynamic"
                                                            ControlToValidate="txtTag" ValidationGroup="ModifyPageWS" SetFocusOnError="true" />
                                                        <asp:TextBox runat="server" class="form-control" ID="txtTag" placeholder="Separa i tag utilizzando la virgola" />
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-4">
                                                    <p>
                                                        <label for="companyName">Immagine per Social</label>
                                                        <asp:Image Style="width: 100%" runat="server" ID="ImgSocialImage" ClientIDMode="Static"/>
                                                    </p>
                                                </div>
                                                <div class="col-md-8">
                                                    <div class="form-group">
                                                        <label for="companyName">Titolo per Social</label>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ForeColor="Red" Display="Dynamic"
                                                            ControlToValidate="txtSocialTitle" ValidationGroup="ModifyPageWS" SetFocusOnError="true" />
                                                        <asp:TextBox runat="server" class="form-control" ID="txtSocialTitle" />
                                                    </div>

                                                    <div class="form-group">
                                                        <label for="companyName">Descrizione per Social <small>
                                                            <asp:Label runat="server" ID="lblSocialDescPage" Text="Min 80 Max 200 caratteri" /></small></label>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*" ForeColor="Red" Display="Dynamic"
                                                            ControlToValidate="txtSocialDesc" ValidationGroup="ModifyPageWS" SetFocusOnError="true" />
                                                        <asp:TextBox runat="server" class="form-control" ID="txtSocialDesc" />
                                                    </div>
                                                    <div class="form-group">
                                                        <label for="companyName">Immagine per Social</label>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*" ForeColor="Red" Display="Dynamic" autocomplete="off"
                                                            ControlToValidate="txtSocialImage" ValidationGroup="ModifyPageWS" SetFocusOnError="true" />
                                                        <asp:TextBox runat="server" class="form-control" ID="txtSocialImage" placeholder="http://" onkeyup="UpdateImg()" ClientIDMode="Static"/>
                                                        <script>
                                                            function UpdateImg() {
                                                                document.getElementById("ImgSocialImage").src = document.getElementById("txtSocialImage").value;
                                                            }
                                                            UpdateImg();
                                                        </script>
                                                    </div>
                                                </div>

                                            </div>
                                        </div>

                                        <div class="form-actions right">

                                            <asp:LinkButton Text="Annulla" runat="server" class="btn btn-warning"
                                                UseSubmitBehavior="false" ID="bttAnnulla" PostBackUrl="~/Management/Functions/Pages/" />

                                            <button class="btn btn-raised btn-success" id="Loading" type="button" disabled="" style="display: none">
                                                <span class="spinner-border spinner-border-sm" role="status" aria-hidden="true"></span>&nbsp; Carico
                                            </button>

                                            <asp:LinkButton runat="server" ID="bttEdit" ValidationGroup="ModifyPageWS" class="btn btn-raised btn-success"
                                                OnClientClick="if ( Page_ClientValidate() ) {this.style.display = 'none'; document.getElementById('Loading').style.display = 'inline-block'}"
                                                UseSubmitBehavior="false" OnClick="bttEdit_Click">
                                                    <i class="fa fa-check-square-o"></i>&nbsp;Aggiorna
                                            </asp:LinkButton>

                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>



                </div>
            </section>
            <!-- // Basic form layout section end -->
        </div>
    </div>
</asp:Content>

