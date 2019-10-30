<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="Author.aspx.cs" Inherits="Admin_Author" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <table align="center">
        <span id="msg" runat="server">
        </span>
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
                <asp:Button ID="Audetails" runat="server" Text="details" OnClick="Audetails_Click" style="height: 26px" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="Cleardetails" runat="server" Text="clear" OnClick="Cleardetails_Click" />
            </td>
        </tr>
    </table>
    <asp:Button ID="aubtn" runat="server" Text="display" OnClick="aubtn_Click" />

    <asp:GridView ID="gvAuthors" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None"
        DataKeyNames="au_id"
        OnRowCancelingEdit="gvAuthors_RowCancelingEdit"
        OnRowDeleting="gvAuthors_RowDeleting" OnRowEditing="gvAuthors_RowEditing" OnRowUpdating="gvAuthors_RowUpdating">
        <AlternatingRowStyle BackColor="White" />
        <EditRowStyle BackColor="#2461BF" />
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#EFF3FB" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#F5F7FB" />
        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
        <SortedDescendingCellStyle BackColor="#E9EBEF" />
        <SortedDescendingHeaderStyle BackColor="#4870BE" />
        <Columns>
                <asp:CommandField HeaderText="Update" ShowEditButton="True" />
                <asp:BoundField DataField="au_id" HeaderText="Author ID" ReadOnly="True" />
                <asp:BoundField DataField="au_name" HeaderText="Author Name" />
                <asp:CommandField HeaderText="Delete" ShowDeleteButton="True" />
            </Columns>
    </asp:GridView>
</asp:Content>

