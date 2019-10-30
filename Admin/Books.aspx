<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="Books.aspx.cs" Inherits="Admin_Books" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script type="text/javascript">
        function checkFileExtension(elem) {
            var filepath = elem.Value;
            if (filepath.indexOf('.') == -1)
                return false;
            var ValidExtensions = new Array();
            var ext = filepath.substring(filepath.lastIndexOf('.') + 1).toLowercase();
            ValidExtensions[0] = 'png';
            ValidExtensions[1] = 'jpg';
            ValidExtensions[2] = 'gif';
            ValidExtensions[3] = 'jpeg';
            for(var i=0;i<ValidExtensions.length;i++)
            {
                if (ext == ValidExtensions[i])
                    return true;
            }
            elem.Value = "";
            alert("the fileextension" + ext.toUpperCase() + "is not allowed!");
            return false;
        }
    </script>

    <table align="center">
        <span id="msg" runat="server">

        </span>
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
<td>AUTHOR</td>
<td>
    <asp:DropDownList ID="ddlAuthor" runat="server">
   </asp:DropDownList>
    </td>
                  </tr>
         <tr>
<td>PUBLISHER</td>
<td>
    <asp:DropDownList ID="ddlPublisher" runat="server">
    </asp:DropDownList>
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
            <td>Book Image</td>
            <td>
                
                <asp:FileUpload ID="imgUplaod" runat="server" />
            </td>
        </tr>
        
            <tr>
           <td>ISBN NO</td>
            <td>
                <asp:TextBox ID="txtisbnno" runat="server"></asp:TextBox>
               
            </td>
        </tr>
        <tr>
        <td>YEAR OF PUBLISHING</td>
            <td>
                
                <asp:TextBox ID="txtyearpub" runat="server"></asp:TextBox>
            </td>
        </tr>

         <tr>
             <td>
                 <asp:Button ID="details" runat="server" Text="Button" OnClick="details_Click" /></td>
         </tr>
        <tr>
             <td>
                 <asp:Button ID="bksclear" runat="server" Text="clear" OnClick="bksclea_Click" />

                 </td>
            </tr>
    </table>
</asp:Content>

