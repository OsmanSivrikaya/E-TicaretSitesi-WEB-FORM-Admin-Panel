<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.Master" AutoEventWireup="true" CodeBehind="Musteriler.aspx.cs" Inherits="E_TicaretSitesiBem.View.Musteriler" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="~/Content/bootstrap.min.css" rel="stylesheet" />
</asp:Content>



<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />

    <div class="container">
        <div class="row my-2">
            <div class="col">
                <table class="table d-sm-table-cell d-sm-table-row table-borderless " style="padding-left: 100px;">
                    <tr>
                        <td>
                            <asp:Label Text="AdminID" runat="server" Visible="false" Enabled="false" /></td>
                        <td>
                            <asp:TextBox runat="server" ID="txtAdminID" Visible="false" Enabled="false" /></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label Text="Müşteri ID" runat="server" Visible="false" Enabled="false" /></td>
                        <td>
                            <asp:TextBox runat="server" ID="txtmusteriid" Visible="false" Enabled="false" /></td>
                    </tr>
                    <tr>
                        <th><span>Ad: </span></th>
                        <th>
                            <asp:TextBox ID="TextBox1" runat="server" type="text" MaxLength="50" Visible="false"></asp:TextBox>
                            <asp:TextBox ID="MusAd" runat="server" type="text" MaxLength="50"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" ControlToValidate="MusAd" runat="server" Display="Static"
                                ErrorMessage="Sadece Harf Giriniz." EnableClientScript="False" ForeColor="red" ValidationExpression="^\p{L}+$" ValidationGroup="ClickEvent">
                            </asp:RegularExpressionValidator>
                        </th>
                    </tr>
                    <tr>
                        <th><span>Soyad:</span></th>
                        <th>
                            <asp:TextBox ID="MusSoyad" runat="server" type="text" MaxLength="50"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator4" ControlToValidate="MusSoyad" runat="server" Display="Static"
                                ErrorMessage="Sadece Harf Giriniz." EnableClientScript="False" ForeColor="red" ValidationExpression="^\p{L}+$" ValidationGroup="ClickEvent">
                            </asp:RegularExpressionValidator>
                        </th>
                    </tr>
                    <tr>
                        <th><span>E-mail: </span></th>
                        <th>
                            <asp:TextBox ID="MusEmail" TextMode="Email" runat="server" type="text" MaxLength="50"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator5" ControlToValidate="MusEmail" runat="server" Display="Static"
                                ErrorMessage="Geçerli Mail Adresi Giriniz." EnableClientScript="False" ForeColor="red" ValidationExpression="^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$" ValidationGroup="ClickEvent">
                            </asp:RegularExpressionValidator>
                        </th>
                    </tr>
                    <tr>
                        <th><span>Telefon:</span></th>
                        <th>
                            <asp:TextBox ID="MusTelefon" runat="server" type="text" MaxLength="11"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ControlToValidate="MusTelefon" runat="server" Display="Static"
                                ErrorMessage="Sadece Rakam Giriniz." EnableClientScript="False" ForeColor="red" ValidationExpression="^\d+$" ValidationGroup="ClickEvent">
                            </asp:RegularExpressionValidator>
                        </th>
                    </tr>
                    <tr>
                        <th><span>TC Kimlik No:</span></th>
                        <th>
                            <asp:TextBox ID="MusTc" runat="server" type="text" MaxLength="11" OnTextChanged="MusTc_TextChanged" ></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="MusTc" runat="server" Display="Static"
                                ErrorMessage="Sadece Rakam Giriniz." EnableClientScript="False" ForeColor="red" ValidationExpression="^\d+$" ValidationGroup="ClickEvent">
                            </asp:RegularExpressionValidator>
                        </th>
                    </tr>
                    <tr>
                        <th><span>Kargolanacak Sehir:</span></th>
                        <th>
                            <asp:DropDownList ID="DropDKSehir" runat="server" OnSelectedIndexChanged="DropDKSehir_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList></th>
                    </tr>
                    <tr>
                        <th><span>Kargolanacak İlçe:</span></th>
                        <th>
                            <asp:DropDownList ID="DropDKİlce" runat="server" OnSelectedIndexChanged="DropDKİlce_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                        </th>
                    </tr>
                    <tr>
                        <th><span>Kargolanacak Mahalle:</span></th>
                        <th>
                            <asp:DropDownList ID="DropDKMahalle" runat="server" AutoPostBack="true"></asp:DropDownList>
                        </th>
                    </tr>
                    <tr>

                        <th>
                            <span>Kargolanacak Adres:</span>
                        </th>
                        <th>
                            <asp:TextBox ID="KAdres" runat="server" type="text" MaxLength="100"></asp:TextBox>

                        </th>
                    </tr>
                    <tr>

                        <th>
                            <span>Fatura Adresi için Sehir:</span>
                        </th>
                        <th>
                            <asp:DropDownList ID="DropDFSehir" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DropDFSehir_SelectedIndexChanged"></asp:DropDownList>
                        </th>
                    </tr>
                    <tr>

                        <th>
                            <span>Fatura Adresi için İlçe:</span>
                        </th>
                        <th>
                            <asp:DropDownList ID="DropDFİlce" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DropDFİlce_SelectedIndexChanged"></asp:DropDownList>
                        </th>
                    </tr>
                    <tr>

                        <th>
                            <span>Fatura Adresi için Mahalle:</span>
                        </th>
                        <th>
                            <asp:DropDownList ID="DropDFMahalle" runat="server" AutoPostBack="true"></asp:DropDownList>
                        </th>
                    </tr>
                    <tr>

                        <th>
                            <span>Fatura Adres:</span>
                        </th>
                        <th>
                            <asp:TextBox ID="FAdres" runat="server" type="text" MaxLength="100"></asp:TextBox>



                        </th>
                    </tr>
                    <tr>
                        <th></th>
                        <th>
                            <asp:Button ID="MusEkle" runat="server" Text="KAYDET" class="btn btn-outline-dark" Style="width: 100px;" OnClick="MusEkle_Click" ValidationGroup="ClickEvent" />


                        </th>

                    </tr>
                </table>
            </div>
        </div>
        <div class="row">
            <div class="col">
                <table class="table-bordered">
                    <tr>
                        <td>MÜSTERİ ID</td>
                        <td>MÜŞTERİ ADI</td>
                        <td>MÜŞTERİ SOYADI</td>
                        <td>MÜŞTERİ TELEFON</td>
                        <td>MÜŞTERİ MAİL</td>
                        <td>MÜŞTERİ TC</td>
                        <td>KARGO ŞEHİR</td>
                        <td>KARGO İLÇE</td>
                        <td>KARGO MAH</td>
                        <td>KARGO DETAY</td>
                        <td>FATURA ŞEHİR</td>
                        <td>FATURA İLÇE</td>
                        <td>FATURA MAH</td>
                        <td>FATURA DETAY</td>
                    </tr>
                    <asp:Repeater ID="rptMusteri" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <asp:Label ID="txtmusteriid" Text='<%#Eval("MusteriID") %>' runat="server" /></td>
                                <td>
                                    <asp:Label ID="txtmad" Text='<%#Eval("MAd") %>' runat="server" /></td>
                                <td>
                                    <asp:Label ID="txtmsoyad" Text='<%#Eval("MSoyad") %>' runat="server" /></td>
                                <td>
                                    <asp:Label ID="txtmtel" Text='<%#Eval("MTelefon") %>' runat="server" /></td>
                                <td>
                                    <asp:Label ID="txtmmail" Text='<%#Eval("Mail") %>' runat="server" /></td>
                                <td>
                                    <asp:Label ID="txtmtc" Text='<%#Eval("MTC") %>' runat="server" /></td>
                                <td>
                                    <asp:Label ID="txtsehir" Text='<%#Eval("SehirAdi") %>' runat="server" /></td>
                                <td>
                                    <asp:Label ID="txtilce" Text='<%#Eval("IlceAdi") %>' runat="server" /></td>
                                <td>
                                    <asp:Label ID="txtmah" Text='<%#Eval("MahalleAdi") %>' runat="server" /></td>
                                <td>
                                    <asp:Label ID="txtdetay" Text='<%#Eval("KargoAdresD") %>' runat="server" /></td>
                                <td>
                                    <asp:Label ID="txtfsehir" Text='<%#Eval("sehirad") %>' runat="server" /></td>
                                <td>
                                    <asp:Label ID="txtfilce" Text='<%#Eval("ilcead") %>' runat="server" /></td>
                                <td>
                                    <asp:Label ID="txtfmah" Text='<%#Eval("mahad") %>' runat="server" /></td>
                                <td>
                                    <asp:Label ID="txtfdetay" Text='<%#Eval("FaturaAdresD") %>' runat="server" /></td>
                                <td>
                                    <asp:LinkButton CssClass="btn btn-info" Text="Güncelle" ID="bntGuncelle" OnClick="bntGuncelle_Click" runat="server" /></td>
                                <td>
                                    <asp:LinkButton CssClass="btn btn-danger" ID="btnSil" OnClick="btnSil_Click" OnClientClick="return confirm('Bu Kaydı Silmek İstediğinize Emin misiniz?');"  Text="Sil" runat="server" /></td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
            </div>
        </div>
    </div>


</asp:Content>





