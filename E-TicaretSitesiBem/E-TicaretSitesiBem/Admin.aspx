<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="E_TicaretSitesiBem.View.Admin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>..:: Giriş Yap ::..</title>
    <!-- Google Font: Source Sans Pro -->
    <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Source+Sans+Pro:300,400,400i,700&display=fallback">
    <!-- Font Awesome -->
    <link rel="stylesheet" href="Tasarım/plugins/fontawesome-free/css/all.min.css">
    <!-- icheck bootstrap -->
    <link rel="stylesheet" href="Tasarım/plugins/icheck-bootstrap/icheck-bootstrap.min.css">
    <!-- Theme style -->
    <link rel="stylesheet" href="Tasarım/dist/css/adminlte.min.css">
</head>
<body>
    <form id="form1" runat="server">
        <center>
            <div class="login-box">
                <!--LOGO-->
                <div class="login-logo">
                    <a href="#"><b>E-Ticaret</b></a>
                </div>
                <!--LOGO END-->

                <div class="card">
                    <div class="card-body login-card-body">
                        <p class="login-box-msg">Kullanmak için giriş yap !</p>

                        <!--Kullanici ad-->
                        <div class="input-group mb-3">
                            <asp:TextBox ID="txtKulAd" placeholder="Kullanıcı Adı Giriniz..." CssClass="form-control" runat="server" type="text" MaxLength="50" Visible="true"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" ControlToValidate="txtKulAd" runat="server" Display="Static"
                                ErrorMessage="Sadece Harf Giriniz." EnableClientScript="False" ForeColor="red" ValidationExpression="^\p{L}+$" ValidationGroup="ButtonClck">
                            </asp:RegularExpressionValidator>
                            <div class="input-group-append">
                                <div class="input-group-text">
                                    <span class="fa fa-user"></span>
                                </div>
                            </div>
                        </div>
                        <!--Kullanici ad END-->

                        <!--Kullanici Mail -->
                        <div class="input-group mb-3">
                            <asp:TextBox ID="txtKmail" placeholder="Kullanıcı Mail Giriniz..." CssClass="form-control" runat="server" type="text" MaxLength="50"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator9" ControlToValidate="txtKmail" runat="server" Display="Static"
                                ErrorMessage="Sadece Harf Giriniz." EnableClientScript="False" ForeColor="red" ValidationExpression="^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$" ValidationGroup="ButtonClck">
                            </asp:RegularExpressionValidator>
                            <div class="input-group-append">
                                <div class="input-group-text">
                                    <span class="fas fa-envelope"></span>
                                </div>
                            </div>
                        </div>
                        <!--Kullanici Mail END-->

                        <!--Kullanici Pass-->
                        <div class="input-group mb-3">
                            <asp:TextBox ID="txtKsifre" placeholder="Kullanıcı Şifre Giriniz..." CssClass="form-control" runat="server" type="text" MaxLength="50" Visible="true" TextMode="Password"></asp:TextBox>
                            <div class="input-group-append">
                                <div class="input-group-text">
                                    <span class="fas fa-lock"></span>
                                </div>
                            </div>
                        </div>
                        <!--Kullanici Pass END-->

                        <!--KOD ONAY-->
                        <div class="input-group mb-3">
                            <asp:TextBox ID="txtkod" CssClass="form-control" placeholder="Onay Kodunu Giriniz..." runat="server" type="text" MaxLength="50" Visible="false" ValidationGroup="OnayClck"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="txtkod" runat="server" Display="Static"
                                ErrorMessage="Sadece Rakam Giriniz." EnableClientScript="False" ForeColor="red" ValidationExpression="^\d+$" ValidationGroup="OnayClck">
                            </asp:RegularExpressionValidator>
                        </div>
                        <!--KOD ONAY END-->


                        <center>
                            <asp:Button Text="Giriş" CssClass="btn btn-primary btn-danger" runat="server" ID="btnGiris" OnClick="btnGiris_Click1" />
                        </center>

                        <center>
                            <asp:Button Text="Giriş" CssClass="btn btn-primary btn-danger" runat="server" ID="btnGirisKod" Visible="false" OnClick="btnGirisKod_Click" />
                        </center>

                        <br />
                        <br />
                        <br />


                        <p class="mb-1">
                            <a href="#">Şifremi Unuttum</a>
                        </p>

                    </div>
                </div>
            </div>
        </center>
        <div class="container">
        <div class="row">  
                    
                     
                   <%-- <div class="col-md-12">  
                        <div class="col-md-4">  
                            <asp:Image ID="imgQrCode" runat="server" />  
                        </div>  
                        <div class="col-md-6">  
                            <div>  
                                <span style="font-weight: bold; font-size: 14px;">Account Name:</span>  
                            </div>  
                            <div>  
                                <asp:Label runat="server" ID="lblAccountName"></asp:Label>  
                            </div>  
                               
                        <div>  
                            <span style="font-weight: bold; font-size: 14px;">Secret Key:</span>  
                        </div>  
                            <div>  
                                <asp:Label runat="server" ID="lblManualSetupCode"></asp:Label>  
                            </div>  
                        </div>  
                    </div>  
                    <div class="clearfix"></div>  
                    <div class="col-md-12" style="margin-top: 2%">  
                        <div class="form-group col-md-4">  
                            
                            </asp:TextBox>  
                        </div>  
                        <asp:Button ID="btnValidate" OnClick="btnValidate_Click" CssClass="btn btn-primary" runat="server" Text="Validate" /> 
                    </div>  
                    <h3>Result:</h3>  
                    <div class="alert alert-success col-md-12" runat="server" role="alert">  
                        <asp:Label ID="lblResult" runat="server" Text=""></asp:Label>  
                    </div>  
                </div>  
            </div>--%>

        <script src="Tasarım/plugins/jquery/jquery.min.js"></script>
        <!-- Bootstrap 4 -->
        <script src="Tasarım/plugins/bootstrap/js/bootstrap.bundle.min.js"></script>
        <!-- AdminLTE App -->
        <script src="Tasarım/dist/js/adminlte.min.js"></script>

    </form>
</body>
</html>

