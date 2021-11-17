<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Categorias.aspx.cs" Inherits="GUI.Datos.Categorias" MasterPageFile="~/Site.Master"%>

<%@ Register Src="~/User_Controls/UC_MensajeModal.ascx" TagPrefix="uc1" TagName="UC_MensajeModal" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <br />
    <div class="form-group col-md-12">
        <asp:GridView ID="grvCategoria" runat="server" AllowSorting="True" Caption="Categorías"
            AutoGenerateColumns="False" AllowPaging="True" DataKeyNames="codigoCategoria" PageSize="15" EnableTheming="True"
            OnPageIndexChanging="grvCategoria_PageIndexChanging" OnRowCancelingEdit="grvCategoria_RowCancelingEdit"
            OnRowEditing="grvCategoria_RowEditing" OnRowUpdating="grvCategoria_RowUpdating" OnRowDataBound="grvCategoria_RowDataBound">
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
                        <asp:Label ID="lbl_codigoCategoria" runat="server" Text='<%#Eval("codigoCategoria") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText=" Categoria ">
                    <ItemTemplate>
                        <asp:Label ID="lbl_DescripcionCategoria" runat="server" Text='<%#Eval("DescripcionCategoria") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txt_DescripcionCategoria" runat="server" Text='<%#Eval("DescripcionCategoria") %>'></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>

    <div class="form-group col-md-12">
        <br />
        <asp:Button ID="btnCrearNuevaCategoria" CssClass="btn btn-primary" runat="server" Text="Crear Nueva Categoría" OnClick="btnCrearNuevaCategoria_Click" />
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