<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Recibos.aspx.cs" Inherits="GUI.Datos.Recibos" MasterPageFile="~/Site.Master"
    UICulture="es" Culture="es-AR" %>

<%@ Register Src="~/User_Controls/UC_MensajeModal.ascx" TagPrefix="uc1" TagName="UC_MensajeModal" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <br />

    <div class="container ">
        <div class="form-row">
            <div class="form-group col-md-4">
                <asp:Label ID="lblEmpleado" runat="server" Text="Empleado: "></asp:Label>
                <asp:DropDownList ID="ddlEmpleados" runat="server"></asp:DropDownList>
            </div>
            <div class="form-group col-md-4">
                <asp:Label ID="lblAnioDesde" runat="server" Text="Desde Año: "></asp:Label>
                <asp:DropDownList ID="ddlAnioDesde" runat="server"></asp:DropDownList>
            </div>
            <div class="form-group col-md-4">
                <asp:Label ID="lblAnioHasta" runat="server" Text="Hasta Año: "></asp:Label>
                <asp:DropDownList ID="ddlAnioHasta" runat="server"></asp:DropDownList>
            </div>
        </div>
        <div class="form-row">
            <div class="form-group col-md-4">
                <asp:Label ID="lblMesDesde" runat="server" Text="Desde Mes: "></asp:Label>
                <asp:DropDownList ID="ddlMesDesde" runat="server"></asp:DropDownList>
            </div>
            <div class="form-group col-md-4">
                <asp:Label ID="lblMesHasta" runat="server" Text="Hasta Mes: "></asp:Label>
                <asp:DropDownList ID="ddlMesHasta" runat="server"></asp:DropDownList>
            </div>
            <div class="form-group col-md-4">
                <asp:Label ID="lblSueldo" runat="server" Text="Puesto (Categoría): "></asp:Label>
                <asp:DropDownList ID="ddlSueldo" runat="server"></asp:DropDownList>
            </div>
        </div>
        <div class="form-row">
            <button id="btnFiltrar" runat="server" class="btn btn-info btn-sm fa fa-filter" title="Filtrar" onserverclick="btnFiltrar_ServerClick"></button>
            <button id="btnLimpiarFiltros" runat="server" class="btn btn-info btn-sm fa fa-undo" title="Limpiar Filtros" onserverclick="btnLimpiarFiltros_ServerClick"></button>
        </div>
    </div>

    <div class="form-group col-md-12">
        <asp:Panel runat="server" ScrollBars="Vertical" Height="300px">
            <asp:GridView ID="grvEmpleadosRecibos" runat="server" AllowSorting="true" Caption="Recibos"
                AutoGenerateColumns="False" EnableTheming="true" OnRowDataBound="grvEmpleadosRecibos_RowDataBound"
                OnSorting="grvEmpleadosRecibos_Sorting">
                <AlternatingRowStyle BackColor="#CCFFFF" />
                <Columns>
                    <asp:BoundField DataField="Empleado" HeaderText="Empleado">
                        <HeaderStyle CssClass="th" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Empleado.Sueldo" HeaderText="Puesto (Categoría)">
                        <HeaderStyle CssClass="th" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Recibo.Anio" HeaderText="Año" SortExpression="Recibo.Anio">
                        <HeaderStyle CssClass="th" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Recibo.Mes" HeaderText="Mes" DataFormatString="{0:D2}" ItemStyle-HorizontalAlign="Center" SortExpression="Recibo.Mes">
                        <HeaderStyle CssClass="th" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Recibo.MontoTotal" HeaderText="Monto total percibido" DataFormatString="{0:C}" ItemStyle-HorizontalAlign="Center" SortExpression="Recibo.MontoTotal">
                        <HeaderStyle CssClass="th" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Recibo.CodigoRecibo" ItemStyle-CssClass="hidden" HeaderStyle-CssClass="hidden"></asp:BoundField>
                    <asp:TemplateField HeaderText="Acción">
                        <ItemTemplate>
                            <asp:LinkButton runat="server" ID="btnVerRecibo" class="btn btn-mini" ToolTip="Ver Detalle" OnClick="btnVerRecibo_Click"><i class="fa fa-search-plus" aria-hidden="true"></i>
                            </asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </asp:Panel>
        <hr />
    </div>

    <div class="form-group col-md-12">
        <br />
        <asp:Button ID="btnCrearNuevoRecibo" CssClass="btn btn-primary" runat="server" Text="Crear Nuevo Recibo" OnClick="btnCrearNuevoRecibo_Click" />
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
