<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.Master" AutoEventWireup="true" CodeBehind="Urunler.aspx.cs" Inherits="E_TicaretSitesiBem.View.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />


    <div class="container">
        <div class="row my-3">
            <div class="col">

                <table class="table d-sm-table-cell d-sm-table-row table-borderless " style="padding-left: 100px;">
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
                            <asp:Label Visible="false" Text="Ürün İD" runat="server" />
                        </th>
                        <th>
                            <asp:TextBox Visible="false" runat="server" ID="txtUrunID"/>
                        </th>
                    </tr>
                    <tr>
                        <th>
                            <asp:Label Text="Ürün İsmi" runat="server" />
                        </th>
                        <th>
                            <asp:TextBox runat="server" ID="txtUrunismi" MaxLength="50"/>
                           
                        </th>
                    </tr>

                    <tr>
                        <th>
                            <asp:Label Text="Tedarikci" runat="server" />
                        </th>
                        <th>
                            <asp:DropDownList runat="server" AutoPostBack="true" ID="drpTedarikci">
                            </asp:DropDownList>
                        </th>
                    </tr>

                    <tr>
                        <th>
                            <asp:Label Text="Kategori" runat="server" />
                        </th>
                        <th>
                            <asp:DropDownList runat="server" AutoPostBack="true" ID="drpKategori">
                            </asp:DropDownList>
                        </th>
                    </tr>

                    <tr>
                        <th>
                            <asp:Label Text="Ürün Stok" runat="server"  />
                        </th>
                        <th>
                            <asp:TextBox runat="server" ID="txtUrunStok" TextMode="Number" MaxLength="50"/>
                        </th>
                    </tr>

                    <tr>
                        <th>
                            <asp:Label Text="Ürün Fiyat" runat="server" />
                        </th>
                        <th>
                            <asp:TextBox runat="server" ID="txtUrunFiyat"  MaxLength="50" />
                        </th>
                    </tr>

                    <tr>
                        <th>
                            <asp:Label Text="Urun Detay" runat="server" />
                        </th>
                        <th>
                            <asp:TextBox runat="server" ID="txtUrunDetay"  MaxLength="50" />
                        </th>
                    </tr>

                    <tr>
                        <th>
                            <asp:Label Text="Ürün Fotoğraf" runat="server" />
                            <asp:HiddenField ID="fpath" runat="server" />
                        </th>
                        <th>
                            <asp:FileUpload runat="server" ID="FotoSec" />
                        </th>
                    </tr>

                    <tr>
                        <th></th>
                        <th>
                            <asp:Button class="btn btn-outline-dark" Text="Kaydet" OnClick="btnKaydet_Click" runat="server" ID="btnKaydet" style="width: 100px;"/> 
                        </th>

                    </tr>
                </table>

            </div>
        </div>
        <div class="row">
    <table class="table-bordered">
        <tr>
            <td>ÜRÜN ID</td>
            <td>ÜRÜN AD</td>
            <td>KATEGORİ AD</td>
            <td>ÜRÜN FİYAT</td>
            <td>ÜRÜN DETAY</td>
            <td>TEDARİKCİ AD</td>
            <td>STOK SAYISI</td>
        </tr>
        <asp:Repeater ID="rptUrunler" runat="server">
            <ItemTemplate>
                <tr>
                    <td><asp:Label Text='<%#Eval("UrunID") %>' ID="txturunid" runat="server" /></td>
                    <td><asp:Label Text='<%#Eval("UrunAd") %>' ID="txturunad" runat="server" /></td>
                    <td><asp:Label Text='<%#Eval("KategoriAd") %>' ID="txtkategoriid" runat="server" /></td>
                    <td><asp:Label Text='<%#Eval("UrunFiyat") %>' ID="txturunfiyat" runat="server" /></td>
                    <td><asp:Label Text='<%#Eval("UrunDetay") %>' ID="txturundetay" runat="server" /></td>
                    <td><asp:Label Text='<%#Eval("TedarikciAd") %>' ID="txttedarikciid" runat="server" /></td>
                    <td><asp:Label Text='<%#Eval("StokID") %>' ID="txtstokid" runat="server" /></td>
                    <td><asp:LinkButton CssClass="btn btn-info" Text="Güncelle" ID="UrunSec" OnClick="UrunSec_Click" runat="server" /></td>
                    <td><asp:LinkButton CssClass="btn btn-danger" Text="Sil" OnClientClick="return confirm('Bu Kaydı Silmek İstediğinize Emin misiniz?');" ID="UrunSil" OnClick="UrunSil_Click" runat="server" /></td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </table>
        </div>
    </div>


</asp:Content>
