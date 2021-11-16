<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NuevoSueldo.aspx.cs" Inherits="GUI.Datos.NuevoSueldo"  MasterPageFile="~/Site.Master"%>

<%@ Register Src="~/User_Controls/UC_MensajeModal.ascx" TagPrefix="uc1" TagName="UC_MensajeModal" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <br />
    <div class="form-group col-md-12 bg-info">
        <div class="form-row">
            <div class="form-group col-md-6">
                <asp:Label ID="lblCategoria" runat="server" Text="Categoría"></asp:Label>
                <asp:DropDownList ID="ddlCategoria" CssClass="form-control" runat="server"></asp:DropDownList>
            </div>
            <div class="form-group col-md-6">
                <asp:Label ID="lblSueldoBase" runat="server" Text="Sueldo Base ($)"></asp:Label>
                <asp:TextBox ID="txtSueldoBase" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="form-row">
            <div class="form-group col-md-6">
                <asp:Label ID="lblPuesto" runat="server" Text="Puesto"></asp:Label>
                <asp:TextBox ID="txtPuesto" CssClass="form-control" runat="server"></asp:TextBox>
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