<%@ Page Title="Vedi " Language="C#" MasterPageFile="~/Management/MasterPage.master" AutoEventWireup="true" CodeFile="View.aspx.cs" Inherits="Management_Functions_Gallery_View" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script>
        window.onload = function () { selectMenuVoice("MainMenuItemGallery") };
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="main-content">
        <div class="content-wrapper">
            <!-- Basic form layout section start -->
            <section id="basic-form-layouts">
                <div class="row">
                    <div class="col-sm-12">
                        <div class="content-header">Modifica Foto Sito Web</div>
                    </div>

                </div>
                <div class="row">
                    <div class="col-sm-12">
                        <asp:Literal ID="lblResult" runat="server" />

                    </div>
                </div>

                <div class="row">
                    <div class="col-md-9">
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
                                                        <label for="projectinput1">Nome</label>
                                                        <asp:RequiredFieldValidator ID="rvf1" runat="server" ErrorMessage="*" ForeColor="Red" Display="Dynamic"
                                                            ControlToValidate="txtNome" ValidationGroup="EditNews" SetFocusOnError="true" />
                                                        <asp:TextBox runat="server" class="form-control" ID="txtNome" />
                                                    </div>                                                    
                                                    <div class="form-group">
                                                        <label for="projectinput8">Contenuto</label>
                                                        <asp:RequiredFieldValidator ID="rfv2" runat="server" ErrorMessage="*" ForeColor="Red" Display="Dynamic"
                                                            ControlToValidate="txtContenuto" ValidationGroup="EditNews" SetFocusOnError="true" />
                                                        <ckeditor:ckeditorcontrol id="txtContenuto" basepath="/ckeditor/" runat="server"></ckeditor:ckeditorcontrol>
                                                    </div>
                                                </div>
                                            </div>                                          
                                     
                                        </div>

                                        <div class="form-actions right">

                                            <asp:LinkButton Text="Annulla" runat="server" class="btn btn-warning"
                                                UseSubmitBehavior="false" ID="bttAnnulla" PostBackUrl="~/Management/Functions/Gallery/" />

                                            <button class="btn btn-raised btn-success" id="Loading" type="button" disabled="" style="display: none">
                                                <span class="spinner-border spinner-border-sm" role="status" aria-hidden="true"></span>&nbsp; Carico
                                            </button>

                                            <asp:LinkButton runat="server" ID="bttEdit" ValidationGroup="EditNews" class="btn btn-raised btn-success"
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
                    <div class="col-md-3">
                        <div class="card">
                            <div class="card-body">
                                <div class="form">
                                    <div class="form-body">
                                        <div class="row">
                                            <div class="col-md-12">
                                                <div class="form-group">
                                                    <label for="companyName">Immagine News</label>
                                                    <asp:Image Style="width: 100%" runat="server" ID="ImgNews" ClientIDMode="Static" />
                                                </div>
                                            </div>
                                        </div>

                                        <div class="row">

                                            <div class="col-md-12 col-sm-12">
                                                <div class="form-group">
                                                    <label for="companyName">No. Posizione</label>
                                                    <asp:Image Style="width: 100%" runat="server" ID="Image3" ClientIDMode="Static" />
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="*" ForeColor="Red" Display="Dynamic"
                                                        ControlToValidate="txtPosNo" ValidationGroup="EditNews" SetFocusOnError="true" />
                                                    <asp:TextBox runat="server" class="form-control" ID="txtPosNo" />
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </section>
        </div>
    </div>
</asp:Content>

