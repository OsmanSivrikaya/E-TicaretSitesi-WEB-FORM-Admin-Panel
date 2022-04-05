<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="RaporGetir.aspx.cs" Inherits="E_TicaretSitesiBem.RaporGetir" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="table-bordered">
        <tr>
            <td>RAPOR ID</td>
            <td>ADMİN ID</td>
            <td>GÜNCELLEYEN ADMIN ADI</td>
            <td>GÜNCELLEYEN ADMIN SOYADI</td>
            <td>GUNCELLENEN VERİ ADI</td>
            <td>EKLENME TARİHİ</td>
            <td>GÜNCELLENME TARİHİ</td>
            <td>SİLİNME TARİHİ</td>
            <td>GÜNCELLENEN VERİ NEREYE BAĞLI</td>
        </tr>
        <asp:Repeater ID="rptRapor" runat="server">
            <ItemTemplate>
                <tr>
                    <td><asp:Label ID="txtRaporID" Text='<%#Eval("RaporID") %>' runat="server" /></td>
                    <td><asp:Label ID="txtAdminID" Text='<%#Eval("AdminID") %>' runat="server" /></td>
                    <td><asp:Label ID="txtAdminAD" Text='<%#Eval("AdminAD") %>' runat="server" /></td>
                    <td><asp:Label ID="txtAdminSoyad" Text='<%#Eval("AdminSoyad") %>' runat="server" /></td>
                    <td><asp:Label ID="txtID" Text='<%#Eval("ID") %>' runat="server" /></td>
                    <td><asp:Label ID="txtEklenmeTarihi" Text='<%#Eval("EklenmeTarihi") %>' runat="server" /></td>
                    <td><asp:Label ID="txtGuncellenmeTarihi" Text='<%#Eval("GuncellenmeTarihi") %>' runat="server" /></td>
                    <td><asp:Label ID="txtSilinmeTarihi" Text='<%#Eval("SilinmeTarihi") %>' runat="server" /></td>
                    <td><asp:Label ID="txtTabloID" Text='<%#Eval("TabloAdi") %>' runat="server" /></td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </table>
</asp:Content>
