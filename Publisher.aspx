<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Publisher.aspx.cs" Inherits="Publisher" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table>
        <tr>
<td>PUBLISHER-ID</td>
<td>
    <asp:TextBox ID="txtPubid" runat="server"></asp:TextBox>
    </td>
            </tr>
         <tr>
<td>PUBLISHER NAME</td>
<td>
    <asp:TextBox ID="txtPubname" runat="server"></asp:TextBox>
    </td>
             </tr>
              <tr>
<td>EMAIL-ID</td>
<td>
    <asp:TextBox ID="txtMailId" runat="server" ></asp:TextBox>
    </td>
                  </tr>
         <tr>
<td>PHONENUMBER</td>
<td>
    <asp:TextBox ID="txtPhno" runat="server"></asp:TextBox>
    </td>
             </tr>
        <tr>
            <td>ADDRESS</td>
            <td>
                <asp:TextBox ID="txtPubAddress" runat="server" TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
         <tr>
             <td>
                 <asp:Button ID="Pubdetails" runat="server" Text="details" OnClick="Button1_Click1" /></td>
         </tr>

    </table>
</asp:Content>

