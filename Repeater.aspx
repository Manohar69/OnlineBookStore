<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Repeater.aspx.cs" Inherits="Repeater" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Repeater ID="Myrepeater" runat="server" DataSourceID="SqlDataSource2">
                <HeaderTemplate>
                    <table style="font: 8pt verdana; width:510px;">
                </HeaderTemplate>

                <ItemTemplate>
                    <tr>
                        <td rowspan="7" style="width:160px;">
                            <asp:Image ImageUrl='<%# DataBinder.Eval(Container.DataItem,"bk_img") %>' runat="server" />
                            
                        </td>
                        <td style="width:100px;">Book Name</td>
                        <td style="width:250px;">
                             <%# DataBinder.Eval(Container.DataItem,"bk_name") %>
                        </td>
                    </tr>

                    <tr>
                        <td>AUTHOR NAME</td>
                        <td>
                            <%# DataBinder.Eval(Container.DataItem,"au_id") %>
                        </td>
                    </tr>
                    
                    <tr>
                        <td>PUBLISHER NAME</td>
                        <td>
                           <%# DataBinder.Eval(Container.DataItem,"pub_id") %>
                        </td>
                    </tr>
                    <tr>
                        <td>EDITION</td>
                        <td>
                        <%# DataBinder.Eval(Container.DataItem,"edition") %>
                        </td>
                    </tr>
                    
                    <tr>
                        <td>PRICE</td>
                        <td>
                        <%# DataBinder.Eval(Container.DataItem,"price") %>
                        </td>
                    </tr>
                    
                    <tr>
                          <td>ISBN NO</td>
                        <td>
                        <%# DataBinder.Eval(Container.DataItem,"isbnno") %>
                        </td>
                    </tr>

                    <tr>
                        
                          <td>YEAR OF PUBLISHING</td>
                        <td>
                        <%# DataBinder.Eval(Container.DataItem,"year of publishing") %>
                        </td>
                    </tr>
                    </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>

            </asp:Repeater>

            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:catalogConnectionString2 %>" 
                SelectCommand="SELECT * FROM [bookstable]" />

        </div>
    </form>
</body>
</html>
