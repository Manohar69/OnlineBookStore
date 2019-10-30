<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="Publisher.aspx.cs" Inherits="Admin_Publisher" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">



    <table align="center">
        <span id="msg" runat="server">

        </span>
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
                 <asp:Button ID="Pubdetails" runat="server" Text="details" OnClick="Button1_Click1" style="height: 26px" /></td>
         </tr>
        <tr>
            <td>
                <asp:Button ID="cleardetails" runat="server" Text="btnclear" OnClick="cleardetails_Click" />
            </td>
        </tr>
    </table>
    <asp:Button ID="pubBtn" runat="server" Text="modify" OnClick="pubBtn_Click" />
        <asp:GridView ID="gvPublishers" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" 
        DataKeyNames="pub_id"
        OnRowCancelingEdit="gvPublishers_RowCancelingEdit"
        OnRowDeleting="gvPublishers_RowDeleting" OnRowEditing="gvPublishers_RowEditing" OnRowUpdating="gvPublishers_RowUpdating">
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
                <asp:BoundField DataField="pub_id" HeaderText="Publisher ID" ReadOnly="True" />
                <asp:BoundField DataField="pub_name" HeaderText="Publisher Name" />
                <asp:CommandField HeaderText="Delete" ShowDeleteButton="True" />
            </Columns>
    </asp:GridView>
</asp:Content>

