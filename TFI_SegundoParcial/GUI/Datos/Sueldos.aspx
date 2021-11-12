<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Sueldos.aspx.cs" Inherits="GUI.Datos.Sueldos"  MasterPageFile="~/Site.Master"%>

<%@ Register Src="~/User_Controls/UC_MensajeModal.ascx" TagPrefix="uc1" TagName="UC_MensajeModal" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <br />
    <div class="form-group col-md-12">
        <asp:GridView ID="grvSueldo" runat="server" AllowSorting="True" Caption="Sueldos por categoría/puesto"
            AutoGenerateColumns="False" AllowPaging="True" DataKeyNames="codigoSueldo" PageSize="15" EnableTheming="True"
            OnPageIndexChanging="grvSueldo_PageIndexChanging" OnRowCancelingEdit="grvSueldo_RowCancelingEdit"
            OnRowEditing="grvSueldo_RowEditing" OnRowUpdating="grvSueldo_RowUpdating" OnRowDataBound="grvSueldo_RowDataBound">
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
                <asp:TemplateField HeaderText="ID">
                    <ItemTemplate>
                        <asp:Label ID="lbl_codigoSueldo" runat="server" Text='<%#Eval("codigoSueldo") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Categoria" HeaderStyle-CssClass="th">
                    <ItemTemplate>
                        <asp:Label ID="lbl_Categoria" runat="server" Text='<%#Eval("Categoria") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:DropDownList ID="ddl_Categoria" runat="server"></asp:DropDownList>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText=" Puesto " HeaderStyle-CssClass="th" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lbl_Puesto" runat="server" Text='<%#Eval("Puesto") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txt_Puesto" runat="server" Text='<%#Eval("Puesto") %>'></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Sueldo Base" HeaderStyle-CssClass="th" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lbl_SueldoBase" runat="server" Text='<%#"$" + Eval("SueldoBase") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txt_SueldoBase" runat="server" Text='<%#Eval("SueldoBase") %>'></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>

    <div class="form-group col-md-12">
        <br />
        <asp:Button ID="btnCrearNuevoSueldo" CssClass="btn btn-primary" runat="server" Text="Crear Nuevo Sueldo" OnClick="btnCrearNuevoSueldo_Click" />
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