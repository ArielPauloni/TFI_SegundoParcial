<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Empleados.aspx.cs" Inherits="GUI.Datos.Empleados"  MasterPageFile="~/Site.Master"%>

<%@ Register Src="~/User_Controls/UC_MensajeModal.ascx" TagPrefix="uc1" TagName="UC_MensajeModal" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <br />
    
    <div class="form-group col-md-12">
        <asp:GridView ID="grvEmpleado" runat="server" AllowSorting="True" Caption="Empleados de Recibo"
            AutoGenerateColumns="False" AllowPaging="True" DataKeyNames="legajo" PageSize="15" EnableTheming="True"
            OnPageIndexChanging="grvEmpleado_PageIndexChanging" OnRowCancelingEdit="grvEmpleado_RowCancelingEdit"
            OnRowEditing="grvEmpleado_RowEditing" OnRowUpdating="grvEmpleado_RowUpdating" OnRowDataBound="grvEmpleado_RowDataBound">
            <AlternatingRowStyle BackColor="#CCFFFF" />
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton runat="server" ID="btn_Edit" class="btn btn-mini" CommandName="Edit"><i class="fa fa-edit" aria-hidden="true"></i>
                        </asp:LinkButton>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:LinkButton runat="server" ID="btn_Update" class="btn btn-mini" CommandName="Update"><i class="fa fa-check" aria-hidden="true"></i>
                        </asp:LinkButton>
                        <asp:LinkButton runat="server" ID="btn_Undo" class="btn btn-mini" CommandName="Cancel"><i class="fa fa-undo" aria-hidden="true"></i>
                        </asp:LinkButton>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Legajo">
                    <ItemTemplate>
                        <asp:Label ID="lbl_legajo" runat="server" Text='<%#Eval("legajo") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText=" Apellido ">
                    <ItemTemplate>
                        <asp:Label ID="lbl_Apellido" runat="server" Text='<%#Eval("Apellido") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txt_Apellido" runat="server" Text='<%#Eval("Apellido") %>'></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText=" Nombre ">
                    <ItemTemplate>
                        <asp:Label ID="lbl_Nombre" runat="server" Text='<%#Eval("Nombre") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txt_Nombre" runat="server" Text='<%#Eval("Nombre") %>'></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Fecha Ingreso" HeaderStyle-CssClass="th" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lbl_FechaIngreso" runat="server" Text='<%#Eval("FechaIngreso", "{0:dd/MM/yyyy}") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txt_FechaIngreso" runat="server" TextMode="Date" Width="100%" Text='<%#Eval("FechaIngreso") %>'></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Puesto/Categoria" HeaderStyle-CssClass="th">
                    <ItemTemplate>
                        <asp:Label ID="lbl_Sueldo" runat="server" Text='<%#Eval("Sueldo") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:DropDownList ID="ddl_Sueldo" runat="server"></asp:DropDownList>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText=" Inactivo " HeaderStyle-CssClass="th" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <%--<asp:CheckBox ID="chk_Activo" runat="server" Enabled="false" Checked='<%#Eval("Activo") %>'></asp:CheckBox>--%>
                        <asp:CheckBox ID="chk_Activo" runat="server" Enabled="false"></asp:CheckBox>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>

     <div class="form-group col-md-12">
        <br />
        <asp:Button ID="btnCrearNuevoEmpleado" CssClass="btn btn-primary" runat="server" Text="Crear Nuevo Empleado" OnClick="btnCrearNuevoEmpleado_Click" />
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