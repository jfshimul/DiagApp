<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TestRequestEntryUI.aspx.cs" Inherits="DiagnosticApp.UI.TestRequestEntryUI" %>

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
    Test Request Information
</asp:Content >


<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    
    <div style="padding:5px;float:left;margin:auto;margin-left:70px;">
      <h2 style="padding:4px;">Test Request Entry</h2>
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
                <asp:Label ID="patientNameLabel" runat="server" Text="Name Of The Patient :" style="font-weight: 700"></asp:Label></td>
            <td class="auto-style4">
                <asp:TextBox ID="patientNameTextBox"  required="true" runat="server" Width="282px" style="margin-left: 0px" Height="18px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                             ControlToValidate="patientNameTextBox" 
                                             ValidationGroup="requestEntry" 
                                             ForeColor="red" 
                                             ErrorMessage="Patient Name Is Empty!">

                 </asp:RequiredFieldValidator>
            </td>
        </tr>
        
        
        <tr>
            <td class="numberValue">
                <asp:Label ID="dateOfBirth" runat="server" Text="Date Of Birth :" style="font-weight: 700"></asp:Label></td>
             <td class="auto-style4">
                <asp:TextBox ID="dateOfBirthTextBox" required="true" runat="server" TextMode="Date" Width="282px" style="margin-left: 0px" Height="18px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                             ControlToValidate="dateOfBirthTextBox" 
                                             ValidationGroup="requestEntry" 
                                             ForeColor="red" 
                                             ErrorMessage="Patient Date of birth Is Empty!">

                 </asp:RequiredFieldValidator>
            </td>
        </tr>

        <tr>
            <td class="numberValue">
                <asp:Label ID="mobileNoLabel"  required="true" runat="server" Text="Mobile No :" style="font-weight: 700"></asp:Label></td>
            <td class="auto-style4">
                <asp:TextBox ID="mobileNoTextBox"  required="true" runat="server" Width="282px" style="margin-left: 0px" Height="18px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                             ControlToValidate="mobileNoTextBox" 
                                             ValidationGroup="requestEntry" 
                                             ForeColor="red" 
                                             ErrorMessage="Mobile No. Is Empty!">

                 </asp:RequiredFieldValidator>
            </td>
        </tr>
        
        <tr>
            <td class="numberValue">
                <asp:Label ID="testNameLabel" runat="server" Text="Select Test :" style="font-weight: 700"></asp:Label></td>
            <td class="auto-style4">
                <asp:DropDownList ID="testNameDropDownList" required="true" AutoPostBack="True" runat="server" Width="282px" style="margin-left: 0px" OnSelectedIndexChanged="testNameDropDownList_SelectedIndexChanged" ></asp:DropDownList>
            </td>
        </tr>

        <tr>
            <td class="numberValue">
                <asp:Label ID="testFeeLabel" runat="server" Text="Fee :" style="font-weight: 700"></asp:Label></td>               
            
            <td class="auto-style4">
                <asp:TextBox ID="testFeeTextBox" required="true"  runat="server" Width="82px" style="margin-left: 0px" Height="18px"></asp:TextBox>
                <asp:HiddenField ID="testIdTextBox" runat="server" />
                <asp:Label ID="bdtLabel" runat="server" Text="BDT" style="font-weight: 700; text-align: right;"></asp:Label></td>            
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                                             ControlToValidate="testFeeTextBox" 
                                             ValidationGroup="requestEntry" 
                                             ForeColor="red" 
                                             ErrorMessage="Test Fee Is Empty!">

                </asp:RequiredFieldValidator>
        </tr>
            
        <tr>
            <td class="auto-style4">&nbsp;</td>
            <td class="auto-style3"><asp:Label ID="msgTestRequestLabel" runat="server" Text=""></asp:Label></td>
        </tr>

        <tr>
            <td class="auto-style3"> </td>
            <td class="auto-style4">
                
                <asp:Button ID="addButton" runat="server" Text="Add" OnClick="addButton_Click" />
                <asp:Button ID="saveButton" runat="server" CssClass="button" ValidationGroup="requestEntry" Text="Save" OnClick="saveButton_Click" />
            </td>
            

            <td></td>
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
                    <asp:GridView ID="GridView2" CssClass="mydatagrid" PagerStyle-CssClass="pager"
                                  HeaderStyle-CssClass="header" RowStyle-CssClass="rows" runat="server"
                                  AutoGenerateColumns="False"
                                  Width="570px" ShowFooter="True"
                                  EmptyDataText="No records has been added." CaptionAlign="Right" OnRowDataBound="GridView2_RowDataBound" OnSelectedIndexChanged="GridView2_SelectedIndexChanged">
            
                        <%--<COLUMNS>
                            <asp:BoundField DataField="TestId" HeaderText="SL" >
                                <ControlStyle Width="150px" />
                                <FooterStyle Width="15px" />
                                <HeaderStyle Width="150px" />
                                <ItemStyle Width="150px" />
                            </asp:BoundField>

                            <asp:BoundField DataField="TestName" HeaderText="Test Name" >
                                <ControlStyle Width="500px" />
                                <FooterStyle Width="500px" />
                                <HeaderStyle Width="500px" />
                                <ItemStyle Width="500px" />
                            </asp:BoundField>
                                
                            <asp:BoundField DataField="Fee" DataFormatString="{0:0.00}" HeaderText="Fee" >
                                <ControlStyle Width="200px" />
                                <FooterStyle Width="200px" />
                                <HeaderStyle Width="200px" />
                                <ItemStyle Width="200px" />
                            </asp:BoundField>
                                
                            <asp:BoundField DataField="TestTypeName" HeaderText="Type" >
                                <ControlStyle Width="500px" />
                                <FooterStyle Width="500px" />
                                <HeaderStyle Width="500px" />
                                <ItemStyle Width="500px" />
                            </asp:BoundField>


                        </COLUMNS>--%>
                        
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

                                <FooterTemplate>
                                    <asp:Label ID="Label404" runat="server" Font-Size="Medium" Font-Bold="True" Text="Total Amount" />
                                </FooterTemplate>

                                <HeaderStyle CssClass="GridHeaderCol2" />

                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Fee">
                                
                                <ItemTemplate>
                                    <asp:Label ID="Label2" runat="server" Text='<%# Eval("Fee") %>'></asp:Label>
                                </ItemTemplate>
                                
                                <FooterTemplate>
                                    <asp:Label ID="totalAmountLabel" runat="server" Text='<%# Eval("TotalAmount") %>' />
                                </FooterTemplate>
                                
                                <ItemStyle Width="120px" />
                                                                   
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
             
        </table>
   


</asp:Content>


