<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ResimGoster.aspx.cs" Inherits="E_TicaretSitesiBem.ResimGoster" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3>Ürün Fotoğraf Galerisi</h3>
            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                <tr>
                    <td width="150px" valign="top" align="center" style="border-right:3px solid #EEEEEE">
                        <div id="ImageGallery" style="overflow:auto; height:350px; width:400px; display:inline-block;">
                            <asp:Repeater ID="Repeater1" runat="server">

                                <%--  --%>
                                <ItemTemplate>

                                    <img src='/Upload/<%#Eval("FileName") %>' alt='<%#Eval("FileName") %>' width="300px" style="cursor:pointer" />
                                 </ItemTemplate>
                            </asp:Repeater>
                        </div>
                    </td>

                </tr>
            </table>
</asp:Content>
