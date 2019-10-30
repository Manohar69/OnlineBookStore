<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Registration.aspx.cs" Inherits="Registration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h3>Registration Form</h3>

<table style="text-align:left; width:300px; margin:auto";>
 <tr style="height:40px;">
<td> NAME</td>
<td>
    <asp:TextBox ID="txtRegusername" runat="server" Width="176px"></asp:TextBox>
</td>
</tr>
 <tr style="height:40px";>
<td>EMAIL_ID</td>
<td>
    <asp:TextBox ID="txtregemail" runat="server" Width="176px" TextMode="Email"></asp:TextBox></td>
     
</tr>
  <tr  style="height:40px";>
<td>PASSWORD</td>
<td>
    <asp:TextBox ID="txtregpassword" runat="server" TextMode="Password" Width="176px"></asp:TextBox></td>
</tr>
<tr style="height:40px"; >
<td>MOBILE NUMBER</td>
<td>
    <asp:TextBox ID="txtregmobileno" runat="server" Width="176px"></asp:TextBox>


</td>
</tr>
 
<tr style="height:40px";>
<td id="gender">GENDER</td>
<td id="txtRadBtn">
<asp:RadioButton ID="radmale" runat="server" Text="Male" GroupName="GENDER" />
    <asp:RadioButton ID="radfemale" runat="server" GroupName="GENDER" Text="Female" />
</td>
</tr>
<tr style="height:40px";>
<td>ADDRESS</td>
<td>
    <asp:TextBox ID="txtRegAddress" runat="server" TextMode="MultiLine"></asp:TextBox> </td>
</tr>
 <tr style="height:50px;">
<td colspan="6" style="text-align:center">
    <asp:Button ID="Regdetails" runat="server" Text="submit" OnClick="Button1_Click" />
    <asp:Button ID="Regreset" runat="server" Text="reset" OnClick="Button2_Click" />



</td>
</tr>
</table>
</asp:Content>

