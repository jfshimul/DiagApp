<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TypeWiseReportUI.aspx.cs" Inherits="DiagnosticApp.UI.TypeWiseReportUI" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    
    <style type="text/css">
        .auto-style4 {
            text-align: left;
            width: 752px;
        }

        .save-style5 {
            text-align: right;
            padding-right:100px;
        }
        .total-label {
            text-align: right;
            padding-right:70px;
        }
        .auto-style5 {
            text-align: right;
            width: 107px;
        }
        .auto-style6 {
            text-align: left;
            width: 107px;
        }
        .auto-style7 {
            width: 107px;
            text-align: right;
        }
        .auto-style8 {
            width: 752px;
            font-weight: 700;
        }
        .mydatagrid {}
    </style>
    
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="TitleHead" runat="server">
    Test Type wise Information
</asp:Content >


<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    
    <div style="padding:5px;float:left;margin:auto;margin-left:70px;">
        <h2 style="padding:4px;">Type Wise Report</h2>
    </div>
    
    <table style="padding-left:-200px; width:100%;">
        
        <tr>
            <td class="auto-style5">
                <asp:Label ID="fromDateLabel" runat="server" Text="From Date :" style="font-weight: 700"></asp:Label></td>
            <td class="auto-style4">
                <asp:TextBox ID="fromDateTextBox" required="true" runat="server" TextMode="Date" Width="282px" style="margin-left: 0px" Height="18px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                            ControlToValidate="fromDateTextBox" 
                                            ValidationGroup="reportParam" 
                                            ForeColor="red" 
                                            ErrorMessage="From Date Is Empty!">

                </asp:RequiredFieldValidator>
            </td>
        </tr>


        <tr>
            <td class="auto-style5">
                <asp:Label ID="toDateLabel" runat="server" Text="To Date :" style="font-weight: 700"></asp:Label></td>
            <td class="auto-style4">
                <asp:TextBox ID="toDateTextBox" required="true" runat="server" TextMode="Date" Width="282px" style="margin-left: 0px" Height="18px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                            ControlToValidate="toDateTextBox" 
                                            ValidationGroup="reportParam" 
                                            ForeColor="red" 
                                            ErrorMessage="To Date Is Empty!">

                </asp:RequiredFieldValidator>
            </td>
        </tr>
                
        <tr>
            <td class="auto-style6">&nbsp;</td>
            <td class="auto-style8"><asp:Label ID="msgReportParameterLabel" runat="server" Text=""></asp:Label></td>
        </tr>

        <tr>
            <td class="auto-style7"> </td>
            <td class="auto-style4">
                <asp:Button ID="showButton" runat="server" Text="Show" OnClick="showButton_Click" />
            </td>
        </tr>
            
        <tr>
            <td class="auto-style7">&nbsp;</td>
            <td class="auto-style8">&nbsp;</td>
        </tr>

        <tr>
            <td class="auto-style7">&nbsp;</td>

            <td class="auto-style8">
                <h3 style="background:url(../images/outright_logo.gif) no-repeat; margin-left:-100px;padding-left:50px">Type Wise Report :) </h3>
                <br/>
                <asp:GridView ID="typeWiseReportGridView" CssClass="mydatagrid" PagerStyle-CssClass="pager"
                              HeaderStyle-CssClass="header" RowStyle-CssClass="rows" runat="server"
                              AutoGenerateColumns="False"
                              Width="686px"
                              EmptyDataText="No records has been shown." CaptionAlign="Right">
                    <Columns>
                            
                        <asp:TemplateField HeaderText="SL">
                            <ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate>
                            <HeaderStyle CssClass="GridHeaderCol1"></HeaderStyle>
                        </asp:TemplateField>

                        <asp:TemplateField Visible="False">
                            <ItemTemplate>
                                <asp:Label ID="testTypeIdLabel" runat="server" Visible="False" Text='<%# Eval("TestTypeId") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle CssClass="GridHeaderCol2" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Test Type Name">
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Eval("TestTypeName") %>'></asp:Label>
                            </ItemTemplate>

                            <HeaderStyle CssClass="GridHeaderCol2" />
                        </asp:TemplateField>
                
                        <asp:TemplateField HeaderText="Total no of Test">
                            <ItemTemplate>
                                <asp:Label ID="totalTestLabel" runat="server" Text='<%# Eval("TotalTests") %>'></asp:Label>
                            </ItemTemplate>
                    
                            <%-- <FooterTemplate>
                        <asp:Label ID="Label404" runat="server" Font-Size="Medium" Font-Bold="True" Text="Total" />
                    </FooterTemplate>--%>

                            <HeaderStyle CssClass="GridHeaderCol2" />
                        </asp:TemplateField>
                

                        <asp:TemplateField HeaderText="Total Amount">
                                
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%# Eval("TotalAmount") %>'></asp:Label>
                            </ItemTemplate>
                                
                            <%--<FooterTemplate>
                        <asp:Label ID="totalAmountLabel" runat="server" Text='<%# Eval("TotalAmount") %>' />
                    </FooterTemplate>--%>
                                
                            <ItemStyle Width="120px" />
                                                                   
                        </asp:TemplateField>
                            
                    </Columns>

                    <%--<FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />--%>
                    <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
                    <PagerStyle  BackColor="#4A3C8C" ForeColor="#F7F7F7" HorizontalAlign="Right" />
                    <RowStyle    BackColor="#E7E7FF" Height="30px" ForeColor="#4A3C8C" />
                    <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
                    <SortedAscendingCellStyle BackColor="#F4F4FD" />
                    <SortedAscendingHeaderStyle BackColor="#5A4C9D" />
                    <SortedDescendingCellStyle BackColor="#D8D8F0" />
                    <SortedDescendingHeaderStyle BackColor="#3E3277" />

                </asp:GridView>    
            </td>
        </tr>
        <tr>
            <td class="auto-style7"> &nbsp;</td>
            <td class="auto-style8"> &nbsp;</td>
        </tr>
    
        <tr>
            <td class="auto-style7"> <asp:Label ID="totalAmLabel" runat="server" Text="Total :" style="font-weight: 700"></asp:Label> </td>
            <td class="auto-style8"> <asp:Label ID="totalAmountLabel" runat="server"></asp:Label></td>
        </tr>
    
        <tr>
            <td class="auto-style7"> &nbsp;</td>
            <td class="auto-style8"> &nbsp;</td>
        </tr>

        <tr>
            <td class="auto-style7"> </td>
            <td class="auto-style4">
                <asp:Button ID="pdfButton" runat="server" Text="PDF" OnClick="pdfButton_Click" />
            </td>
        </tr>    
    </table>
   


</asp:Content>


