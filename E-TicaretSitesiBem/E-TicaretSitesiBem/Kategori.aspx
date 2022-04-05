<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.Master" AutoEventWireup="true" CodeBehind="Kategori.aspx.cs" Inherits="E_TicaretSitesiBem.View.Kategori" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="~/Content/bootstrap.min.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <div class="container">
        <div class="row my-3">
            <div class="col">
                <table class="table d-sm-table-cell d-sm-table-row table-borderless " style="padding-left: 100px;">
                    
                    <tr>
                            <th><asp:Label Visible="false" Text="KategoriID" runat="server" /></th>
                            <th><asp:TextBox Visible="false" runat="server" ID="txtkullanici" /></th>
                        </tr>
                        <tr>
                            <th><asp:Label Visible="false" Text="KategoriID" runat="server" /></th>
                            <th><asp:TextBox Visible="false" runat="server" ID="txtKategoriID" /></th>
                        </tr>
                        <tr>
                            <th><asp:Label Text="Kategori Adı" runat="server" /><th>
                            <th>
                                <asp:TextBox placeholder="Kategori Adı Giriniz..." ID="KategoriAd" runat="server" type="text" MaxLength="50"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator9" ControlToValidate="KategoriAd" runat="server" Display="Static"
                                    ErrorMessage="Sadece Harf Giriniz." EnableClientScript="False" ForeColor="red" ValidationExpression="^\p{L}+$" ValidationGroup="ButtonClick">
                                </asp:RegularExpressionValidator>
                            </th>
                        </tr>
                        <tr>
                            <th></th>
                            <th><asp:Button ID="KategoriEkle" ValidationGroup="ButtonClick" runat="server" Text="Ekle" class="btn btn-outline-dark" Style="width: 100px;" OnClick="KategoriEkle_Click" /></th>
                        </tr>
                </table>
            </div>
        </div>
        <div class="row my-3">
            <div class="col">
                <table class="table-bordered">
                    <tr>
                        <td>KATEGORİ ID</td>
                        <td>KATEGORİ ADI</td>
                    </tr>
                    <asp:Repeater ID="rptKategori" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td><asp:Label ID="txtkategoriid" Text='<%#Eval("KategoriID") %>' runat="server" /></td>
                                <td><asp:Label ID="txtkategoriad" Text='<%#Eval("KategoriAd") %>' runat="server" /></td>
                                <td><asp:LinkButton Text="Güncelle" CssClass="btn btn-info" ID="btnGuncelle" OnClick="btnGuncelle_Click" runat="server" /></td>
                                <td><asp:LinkButton CssClass="btn btn-danger" Text="SİL" ID="btnKategoriSil" OnClick="btnKategoriSil_Click" OnClientClick="return confirim('Bu veriyi silmek istediğinize emin misiniz?')" runat="server" /></td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
            </div>
        </div>
    </div>
</asp:Content>
