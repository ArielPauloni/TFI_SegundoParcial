﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NuevaCategoria.aspx.cs" Inherits="GUI.Datos.NuevaCategoria" MasterPageFile="~/Site.Master" %>

<%@ Register Src="~/User_Controls/UC_MensajeModal.ascx" TagPrefix="uc1" TagName="UC_MensajeModal" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <br />
    <div class="container">
        <div class="form-row">
            <div class="form-group col-md-6">
                <asp:Label ID="lblDescripcionCategoria" runat="server" Text="Categoría"></asp:Label>
                <asp:TextBox ID="txtCategoria" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
        </div>
    </div>
    <div class="form-group">
        <asp:Button ID="btnGrabar" CssClass="btn btn-primary " runat="server" Text="Grabar" OnClick="btnGrabar_Click" />
        <asp:Button ID="btnCancelar" CssClass="btn btn-secondary" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" />
    </div>

    <div class="modal fade" id="MensajeModal" tabindex="-1" role="dialog" aria-labelledby="MensajeModalTitle" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered" role="document">
            <asp:UpdatePanel runat="server" ID="UpPanelDialog" UpdateMode="Conditional">
                <ContentTemplate>
                    <uc1:UC_MensajeModal runat="server" ID="UC_MensajeModal" />
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>

    <script type="text/javascript">
        function mostrarMensaje() {
            $('#MensajeModal').modal({ backdrop: 'static', keyboard: false, toggle: true });
        }
    </script>
</asp:Content>
