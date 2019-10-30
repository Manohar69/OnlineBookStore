<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Branch.aspx.cs" Inherits="Branch" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


    <table>
        <tr>
<td>BRANCH_ID</td>
<td>
    <asp:TextBox ID="txtBrid" runat="server"></asp:TextBox>
    </td>
            </tr>
         <tr>
<td>BRANCH NAME</td>
<td>
    <asp:TextBox ID="txtBrname" runat="server"></asp:TextBox>
    </td>
             </tr>
        <tr>
            <td>
                <asp:Button ID="Brdetails" runat="server" Text="details" OnClick="Button1_Click" /> </td>
        </tr>
        </table>
</asp:Content>

