<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Author.aspx.cs" Inherits="Author" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table>
        <tr>
<td> AUTHOR-ID</td>
<td>
    <asp:TextBox ID="txtAuid" runat="server"></asp:TextBox>
    </td>
            </tr>
         <tr>
<td> NAME</td>
<td>
    <asp:TextBox ID="txtAuname" runat="server"></asp:TextBox>
    </td>
             </tr>
              <tr>
<td>EMAIL</td>
<td>
    <asp:TextBox ID="txtAuemail" runat="server"></asp:TextBox>
    </td>
                  </tr>
         <tr>
<td>ADDRESS</td>
<td>
    <asp:TextBox ID="txtAuaddress" runat="server" TextMode="MultiLine"></asp:TextBox>
    </td>
             </tr>
        <tr>
            <td>
                <asp:Button ID="Audetails" runat="server" Text="details" OnClick="Audetails_Click" />
            </td>
        </tr>

    </table>
</asp:Content>

