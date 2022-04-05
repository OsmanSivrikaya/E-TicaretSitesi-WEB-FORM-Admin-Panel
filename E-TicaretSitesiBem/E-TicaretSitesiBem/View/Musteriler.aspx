<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Musteriler.aspx.cs" Inherits="E_TicaretSitesiBem.View.Musteriler" %>

    
    
    
    
    
    
    <asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  
    <link href="~/Content/bootstrap.min.css" rel="stylesheet" />
   
    <br />

    <table class="table d-sm-table-cell d-sm-table-row table-borderless " style="padding-left:100px;">
        <form method="post">
        <tr>
            <th>
                <span>Name: </span>
            </th>
            <th>
                <input Name="Name" id="n" type="text" />
            </th>
        </tr>
        <tr>
            <th>
                <span>Surname:</span>
            </th>
            <th>
                <input Name="Surname" id="s" type="text" />
            </th>
        </tr>
        <tr>
            <th>
                <span>E-mail: </span>
            </th>
            <th>
                <input Name="Email" id="e" type="text" />
            </th>
        </tr>
        <tr>
            <th>
                <span>UserName:</span>
            </th>
            <th>
                <input Name="Username" id="u" type="text" />
            </th>
        </tr>
        <tr>
            <th>
                <span>Password:</span>
            </th>
            <th>
                <input Name="Password" id="p" type="password" />
            </th>
        </tr>
        <tr>
            <th>

            </th>
            <th>
                <input class="btn btn-outline-dark" id="Signup" type="button" value="Sign Up" style="width:100px;" />
            </th>

        </tr>
        </form>
    </table>
</asp:Content>
  




