<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Resim.aspx.cs" Inherits="E_TicaretSitesiBem.Resim" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
    <table class="table-bordered">
        <tr>
            <td>ÜRÜN ID</td>
            <td>ÜRÜN AD</td>
            
        </tr>
        <asp:Repeater ID="repurun" runat="server">
            <ItemTemplate>
                <tr>
                    <td><asp:Label Text='<%#Eval("UrunID") %>' ID="labelurunid" runat="server" /></td>
                    <td><asp:Label Text='<%#Eval("UrunAd") %>' ID="labelurunad" runat="server" /></td>
                 <td><asp:LinkButton Text="Seç" ID="Usec" OnClick="Usec_Click" runat="server" /></td>
                   
                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </table>
        </div>
    <div>
        <table>
            <tr>
                        <th>
                            <asp:Label Visible="false" Text="Admin ID" runat="server" />
                        </th>
                        <th>
                            <asp:TextBox Visible="false" runat="server" ID="txtkullanici"/>
                        </th>
                    </tr>
            <tr>
                <th>
                    <asp:TextBox ID="txtuid" Enabled="false" runat="server" />
                </th>
               
               </tr>
               <tr>
                        <th>
                            <asp:Label Text="Ürün Fotoğraf" runat="server" />
                            <asp:Label Text="deneme" ID="deneme2" runat="server" />
                            <asp:HiddenField ID="fpath" runat="server" />
                        </th>
                        <th>
                            <asp:FileUpload runat="server" ID="FotoSec" />
                        </th>
                        <th>
                           <asp:Button ID="fotyukle" Text="Yükle" OnClick="fotyukle_Click" runat="server" />
                        </th>
                    </tr>
        </table>
    </div>
</asp:Content>
