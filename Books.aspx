<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Books.aspx.cs" Inherits="Books" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table>
        <tr>
<td>BOOK_ID</td>
<td>
    <asp:TextBox ID="txtBkid" runat="server"></asp:TextBox>
    </td>
            </tr>
         <tr>
<td>BOOK NAME</td>
<td>
    <asp:TextBox ID="txtBkname" runat="server"></asp:TextBox>
    </td>
             </tr>
              <tr>
<td>AUTHOR_ID</td>
<td>
    <asp:TextBox ID="txtBkaudId" runat="server"></asp:TextBox>
    </td>
                  </tr>
         <tr>
<td>PUBLISHER_ID</td>
<td>
    <asp:TextBox ID="txtbkpubid" runat="server"></asp:TextBox>
    </td>
             </tr>
        <tr>
            <td>EDITION</td>
            <td>
                
                <asp:TextBox ID="txtbkedit" runat="server"></asp:TextBox>
            </td>
        </tr>
 <tr>
            <td>PRICE</td>
            <td>
                
                <asp:TextBox ID="txtbkprice" runat="server"></asp:TextBox>
            </td>
        </tr>


         <tr>
             <td>
                 <asp:Button ID="details" runat="server" Text="Button" OnClick="details_Click" />     </td>
         </tr>

    </table>
</asp:Content>

