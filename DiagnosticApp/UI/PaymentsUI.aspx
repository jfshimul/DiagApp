<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PaymentsUI.aspx.cs" Inherits="DiagnosticApp.UI.PaymentsUI" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    
    <style type="text/css">
        .auto-style4 {
            text-align: left;
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
            height: 50px;
        }
        .auto-style6 {
            text-align: right;
            padding-right: 20px;
            height: 50px;
        }
        .auto-style7 {
            text-align: right;
            height: 50px;
        }
    </style>
    
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="TitleHead" runat="server">
    Payment Information
</asp:Content >


<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    
    <div style="padding:5px;float:left;margin:auto;margin-left:70px;">
      <h2 style="padding:4px;">Payment</h2>
    </div>
    
    <table style="padding-left:-200px; width:100%;">
        <tr>
            <td class="auto-style2">
                <asp:Label ID="testRequestIdLabel" runat="server" Text="Test Request Id :" Visible="false" style="text-align: right"></asp:Label></td>
            <td class="auto-style4">
                <asp:TextBox ID="testRequestIdTextBox"  runat="server" Visible="false" style="margin-left: 0px" Width="280px"></asp:TextBox>
            </td>
        </tr>

        <tr>
            <td class="numberValue">
                <asp:Label ID="billNoLabel" runat="server" Text="Bill No. :" style="font-weight: 700"></asp:Label></td>
            <td class="auto-style4">
                <asp:TextBox ID="billNoTextBox"  required="true" runat="server" Width="282px" style="margin-left: 0px" Height="18px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                             ControlToValidate="billNoTextBox" 
                                             ValidationGroup="searchEntry" 
                                             ForeColor="red" 
                                             ErrorMessage="Bill No. Is Empty!"> </asp:RequiredFieldValidator>
            </td>
        </tr>
        
        <tr>
            <td class="auto-style4">&nbsp;</td>
            <td class="auto-style3"><asp:Label ID="msgBillNoLabel" runat="server" Text=""></asp:Label></td>
        </tr>

        <tr>
            <td class="auto-style3"> </td>
            <td class="auto-style4">
                <asp:Button ID="searchButton" runat="server" Text="Search" ValidationGroup="searchEntry" OnClick="searchButton_Click" />                
            </td>
        </tr>
            
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>

        <tr>
            <td>&nbsp;</td>

            <td>
                <h3 style="background:url(../images/outright_logo.gif) no-repeat; margin-left:-100px;padding-left:50px">Test Request List :) </h3>
                <br/>
                <asp:GridView ID="testsGridView" CssClass="mydatagrid" PagerStyle-CssClass="pager"
                                HeaderStyle-CssClass="header" RowStyle-CssClass="rows" runat="server"
                                AutoGenerateColumns="False"
                                Width="570px" ShowFooter="True"
                                EmptyDataText="No records has been added." CaptionAlign="Right" OnRowDataBound="testsGridView_RowDataBound" OnSelectedIndexChanged="testsGridView_SelectedIndexChanged">
            
                    <Columns>
                            
                        <asp:TemplateField HeaderText="SL">
                            <ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate>
                            <HeaderStyle CssClass="GridHeaderCol1"></HeaderStyle>
                        </asp:TemplateField>

                        <%--<asp:BoundField HeaderText="Test" DataField="Test" />
                        <asp:BoundField HeaderText="Fee" DataField="Fee" />--%>
                            
                        <asp:TemplateField Visible="False">
                            <ItemTemplate>
                                <asp:Label ID="testTypeIdLabel" runat="server" Visible="False" Text='<%# Eval("TestId") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle CssClass="GridHeaderCol2" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Test">
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Eval("TestName") %>'></asp:Label>
                            </ItemTemplate>
                            
                            <%--<FooterTemplate>
                                    <asp:Label ID="Label404" runat="server" Font-Bold="True" Text="Total Amount" />
                            </FooterTemplate>--%>

                            <HeaderStyle CssClass="GridHeaderCol2" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Fee">                                
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%# Eval("Fee") %>'></asp:Label>
                            </ItemTemplate>                        
                           <%-- <FooterTemplate>
                                <asp:Label ID="totalAmountLabel" runat="server" Text='<%# Eval("TotalAmount") %>' />
                            </FooterTemplate>--%>

                        </asp:TemplateField>
                            
                    </Columns>


                    <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
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
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        
            <tr>
                <td class="numberValue">
                    <asp:Label ID="billDateLabel" runat="server" Text="Bill Date :" style="font-weight: 700"></asp:Label>
                </td>
                 <td class="auto-style4">
                    <asp:TextBox ID="billDateTextBox" runat="server"  Width="100px" style="margin-left: 0px" Height="18px" ReadOnly="True"></asp:TextBox>
                  <%--  <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                                 ControlToValidate="billDateTextBox" 
                                                 ValidationGroup="paymentEntry" 
                                                 ForeColor="red" 
                                                 ErrorMessage="Bill Date Is Empty!">

                     </asp:RequiredFieldValidator>--%>
                </td>
            </tr>

            <tr>
                <td class="numberValue">
                    <asp:Label ID="totalFeeLabel"  runat="server" Text="Total Fee :" style="font-weight: 700"></asp:Label></td>
                <td class="auto-style4">
                    <asp:TextBox ID="totalFeeTextBox"  runat="server" Width="100px" style="margin-left: 0px" Height="18px" ReadOnly="True"></asp:TextBox>
                   <%-- <asp:RequiredFieldValidator  ID="RequiredFieldValidator3" runat="server" 
                                                 ControlToValidate="totalFeeTextBox" 
                                                 ValidationGroup="paymentEntry" 
                                                 ForeColor="red" 
                                                 ErrorMessage="Total Fee Must Be Greater Than Zero!">

                 </asp:RequiredFieldValidator>--%>
                </td>
            </tr>
        
            <tr>
                <td class="numberValue">
                    <asp:Label ID="paidAmountLabel" runat="server" Text="Paid Amount :" style="font-weight: 700"></asp:Label></td>
                <td class="auto-style4">
                    <asp:TextBox ID="paidAmountTextBox"  runat="server" Width="100px" style="margin-left: 0px" Height="18px" ReadOnly="True"></asp:TextBox>
                </td>
            </tr>


            <tr>
                <td class="numberValue">
                    <asp:Label ID="dueAmountabel" runat="server" Text="Due Amount :" style="font-weight: 700"></asp:Label></td>               
            
                <td class="auto-style4">
                    <asp:TextBox ID="dueAmountTextBox" runat="server" Width="100px" style="margin-left: 0px" Height="18px" ReadOnly="True"></asp:TextBox>
                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                                             ControlToValidate="dueAmountTextBox" 
                                             ValidationGroup="paymentEntry" 
                                             ForeColor="red" 
                                             ErrorMessage="Due Amount Fee Must Be Greater Than Zero!">

                    </asp:RequiredFieldValidator>--%>
            </tr>
         
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            
            <tr>
                <td class="numberValue">
                    <asp:Label ID="amountLabel" runat="server" Text="Amount :" style="font-weight: 700"></asp:Label></td>               
            
                <td class="auto-style4">
                    <asp:TextBox ID="amountTextBox"  runat="server" Width="100px" style="margin-left: 0px" Height="18px"></asp:TextBox>
                  <%--  <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                                             ControlToValidate="AmountTextBox" 
                                             ValidationGroup="paymentEntry" 
                                             ForeColor="red" 
                                             ErrorMessage="Amount Must Be Greater Than Zero!">

                    </asp:RequiredFieldValidator>--%>
            </tr>
            
            <tr>
                <td class="auto-style4">&nbsp;</td>
                <td class="auto-style3"><asp:Label ID="msgPaymentErrorLabel" runat="server" Text=""></asp:Label></td>
            </tr>
 
            <tr>
                <td class="auto-style3"> </td>
                <td class="auto-style4">
                    <asp:Button ID="payButton" runat="server" Text="Pay"  OnClick="payButton_Click" />                
                </td>
            </tr>
          </table>
   


</asp:Content>


