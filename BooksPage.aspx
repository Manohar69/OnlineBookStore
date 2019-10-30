<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="BooksPage.aspx.cs" Inherits="BooksPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">


    <div class="col-md-2">
        <h3>MOST-SELLING SEARCH BOOKS</h3>
        <br />
        <asp:TextBox ID="txtSearch" runat="server" placeholder="Enter text here..."></asp:TextBox>
        <asp:Button ID="btnSearch" runat="server" Text="Search" Height="25px" OnClick="btnSearch_Click" />
        <asp:Button ID="btnShowAll" runat="server" Text="Show All" Height="25px" OnClick="btnShowAll_Click" />
    </div>
    <div class="col-md-10">
        <asp:DataList runat="server" ID="dlBooks" CellPadding="4" RepeatColumns="2"
            DataSourceID="SqlDataSource2" ForeColor="#333333">
            <AlternatingItemStyle BackColor="White" />
            <FooterStyle BackColor="#1C5E55" ForeColor="White" Font-Bold="True" />
            
            <FooterTemplate>
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
            </FooterTemplate>
            
            <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <ItemStyle BackColor="#E3EAEB" />
            <SelectedItemStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
            <ItemTemplate>
                <br />
                <table style="text-align:left; font-size:80%;">
                    <tr>
                        <td rowspan="7" style="width: 160px;">
                            <asp:Image ImageUrl='<%# DataBinder.Eval(Container.DataItem,"bk_img") %>' runat="server" />
                        </td>
                        <td style="width: 100px;">Book Name</td>
                        <td style="width: 250px; font-weight:bold; font-size:100%;">
                            <%# DataBinder.Eval(Container.DataItem,"bk_name") %>
                        </td>
                    </tr>

                    <tr>
                        <td>AUTHOR NAME</td>
                        <td>
                            <%# DataBinder.Eval(Container.DataItem,"au_name") %>
                        </td>
                    </tr>

                    <tr>
                        <td>PUBLISHER NAME</td>
                        <td>
                            <%# DataBinder.Eval(Container.DataItem,"pub_name") %>
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
                </table>
                <asp:Button ID="btnBuy" CssClass="btn bg-primary" Text="Buy Book Now" runat="server" OnClick="btnBuy_Click" />
                <br />
            </ItemTemplate>
        </asp:DataList>


        <%-- <asp:Repeater ID="Myrepeater" runat="server" DataSourceID="SqlDataSource2">
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

            </asp:Repeater>--%>

        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:catalogConnectionString2 %>"
            SelectCommand="Select b.bk_id, b.bk_name, a.au_name,p.pub_name,b.edition,b.price,b.bk_img,b.isbnno,b.[year of publishing]from bookstable b, authortable a, publishertable p where b.au_id = a.au_id and b.pub_id = p.pub_id; " />


    </div>

</asp:Content>

