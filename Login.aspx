<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h3 align="center">LOGIN</h3>
    <table style="text-align:left; width:300px; margin:auto;">
        <tr style="height:40px;">
            <td>USER NAME</td>
            <td>
                <asp:TextBox ID="txtUserName" runat="server" CssClass="form-control"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>PASSWORD</td>
            <td>
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
            </td>
        </tr>
        <tr style="height:50px;">
            <td colspan="2" style="text-align:center">
                <asp:Button ID="btlogin" runat="server" Text="LOGIN" OnClick="Button1_Click" CssClass="btn btn-primary btn" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <span id="msg" runat="server"></span>
            </td>
        </tr>
    </table>
</asp:Content>

