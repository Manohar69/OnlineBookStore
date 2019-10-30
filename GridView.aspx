<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="GridView.aspx.cs" Inherits="GridView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    
    <asp:GridView ID="GridView1" runat="server" ></asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server"></asp:SqlDataSource>
        <%--<asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="display" />--%>
</asp:Content>

