<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeBehind="Tedarikciler.aspx.cs" Inherits="E_TicaretSitesiBem.View.Tedarikciler" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    
    <div class="container">
        <div class="row my-3">
            <div class="col">
                <table class="table d-sm-table-cell d-sm-table-row table-borderless " style="padding-left: 100px;">
                    <tr>
                        <th>
                            <asp:Label Visible="false" Text="AdminID" runat="server" />
                        </th>
                        <th>
                            <asp:TextBox Visible="false" Enabled="false" runat="server" ID="txtAdminID" />
                        </th>
                    </tr>
                    <tr>
                        <th>
                            <asp:Label Visible="false" Text="Tedarikci ID" runat="server" />
                        </th>
                        <th>
                            <asp:TextBox  Enabled="false" runat="server" ID="txtTedarikciID" />
                        </th>
                    </tr>
                    <tr>
                        <th>
                            <asp:Label Text="Tedarikci Adı" runat="server" />
                        </th>
                        <th>
                            <asp:TextBox runat="server" MaxLength="50" ID="txtTedarikciAd" />
                        </th>
                    </tr>
                    <tr>
                        <th>
                            <asp:Label Text="Tedarikci Telefon" runat="server" />
                        </th>
                        <th>
                           
                            <asp:TextBox  runat="server" TextMode="Number" MaxLength="11" ID="txtTedarikciTelefon" OnTextChanged="txtTedarikciTelefon_TextChanged"/>
                        </th>
                    </tr>
                    <tr>
                        <th>
                            <asp:Label Text="Tedarikci Şehir" runat="server" />
                        </th>
                        <th>
                            <asp:DropDownList runat="server" ID="drpSehir" AutoPostBack="true" OnSelectedIndexChanged="drpSehir_SelectedIndexChanged"></asp:DropDownList>
                        </th>
                    </tr>

                    <tr>
                        <th>
                            <asp:Label Text="Tedarikci İlçe" runat="server" />
                        </th>
                        <th>
                            <asp:DropDownList runat="server" ID="drpIlce" AutoPostBack="true" OnSelectedIndexChanged="drpIlce_SelectedIndexChanged"></asp:DropDownList>
                        </th>
                    </tr>
                    <tr>
                        <th>
                            <asp:Label Text="Tedarikci Mah" runat="server" />
                        </th>
                        <th>
                            <asp:DropDownList runat="server" ID="drpMah"  AutoPostBack="true"></asp:DropDownList>
                        </th>
                    </tr>
                    <tr>
                        <th>
                            <asp:Label Text="Tedarikci Adres" runat="server" />
                        </th>
                        <th>
                            <asp:TextBox runat="server" ID="txtAdres" MaxLength="200" />
                        </th>
                    </tr>

                    <tr>
                        <th></th>
                        <th>
                            <asp:Button Text="Kaydet" runat="server" class="btn btn-outline-dark" ID="btnKaydet" Style="width: 100px;" OnClick="btnKaydet_Click" />
                        </th>

                    </tr>
                </table>
            </div>
        </div>
        <div class="row my-2">
            <div class="col">
                <table class="table-bordered">
                    <tr>
                        <td>Tedarikci ID</td>
                        <td>Tedarikci Adı</td>
                        <td>Tedarikci İletişim</td>
                        <td>Tedarikci Şehir</td>
                        <td>Tedarikci İlçe</td>
                        <td>Tedarikci Mah</td>
                        <td>Tedarikci Tedarikci Adres</td>
                        <td>Güncelle</td>
                        <td>Sil</td>
                    </tr>
                    <asp:Repeater runat="server" ID="rptTedarikciler">
                        <ItemTemplate>
                            <tr>
                                <td><asp:Label ID="tedarikciid" Text='<%#Eval("TedarikciID") %>' runat="server" /></td>
                                <td><asp:Label ID="tedarikciAd" Text='<%#Eval("TedarikciAd") %>' runat="server" /></td>
                                <td><asp:Label ID="tiletisim" Text='<%#Eval("Tiletisim") %>' runat="server" /></td>
                                <td><asp:Label ID="sehirId" Text='<%#Eval("SehirAdi") %>' runat="server" /></td>
                                <td><asp:Label ID="ilceid" Text='<%#Eval("IlceAdi") %>' runat="server" /></td>
                                <td><asp:Label ID="semtMahId" Text='<%#Eval("MahalleAdi") %>' runat="server" /></td>
                                <td><asp:Label ID="tedarikciAdres" Text='<%#Eval("TedarikciAdresDetay") %>' runat="server" /></td>
                                <td><asp:LinkButton Text="Güncelle" runat="server" ID="TedarikciSec" CssClass="btn btn-info" OnClick="TedarikciSec_Click1" /></td>
                                <td><asp:LinkButton runat="server" ID="btnSil" Text="Sil" CssClass="btn btn-danger" OnClientClick="return confirm('Bu Kaydı Silmek İstediğinize Emin misiniz?');" OnClick="btnSil_Click" /></td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
            </div>
        </div>
    </div>

</asp:Content>
