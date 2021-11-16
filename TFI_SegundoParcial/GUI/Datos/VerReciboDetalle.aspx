<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VerReciboDetalle.aspx.cs" MasterPageFile="~/Site.Master"
    Inherits="GUI.Datos.VerReciboDetalle" UICulture="es" Culture="es-AR" %>

<%@ Register Src="~/User_Controls/UC_MensajeModal.ascx" TagPrefix="uc1" TagName="UC_MensajeModal" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <br />
    <div class="form-group col-md-12">
        <asp:TextBox ID="DatosEmpleado" runat="server" TextMode="MultiLine" Enabled="false" Style="resize: none; overflow: hidden" Height="125px" Width="300px"></asp:TextBox>
    </div>

    <div class="form-group col-md-12">
        <asp:GridView ID="grvEmpleadoRecibo" runat="server" Caption="Detalle"
            AutoGenerateColumns="False" EnableTheming="true" OnRowDataBound="grvEmpleadoRecibo_RowDataBound">
            <AlternatingRowStyle BackColor="#CCFFFF" />
            <Columns>
                <asp:BoundField DataField="Concepto.DescripcionConcepto" HeaderText="Detalle">
                    <HeaderStyle CssClass="th" />
                </asp:BoundField>
                <asp:BoundField DataField="Concepto.Porcentaje" ItemStyle-HorizontalAlign="Center" HeaderText="Porcentaje">
                    <HeaderStyle CssClass="th" />
                </asp:BoundField>
                <asp:BoundField DataField="MontoParcial" DataFormatString="{0:C}" HeaderText="Monto parcial">
                    <HeaderStyle CssClass="th" />
                </asp:BoundField>
            </Columns>
        </asp:GridView>
    </div>

    <div class="form-group">
        <asp:Button ID="btnImprimirPDF" CssClass="btn btn-primary " runat="server" Text="Ver PDF" OnClick="btnImprimirPDF_Click" />
        <asp:Button ID="btnCancelar" CssClass="btn btn-secondary" runat="server" Text="Volver" OnClick="btnCancelar_Click" />
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
