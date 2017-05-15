
<%@ Page Title="Test Type Setup" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TestTypeSetupUI.aspx.cs" Inherits="DiagnosticApp.UI.TestTypeSetup" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="TitleHead" runat="server">
Test Type Setup
</asp:Content >

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    
    <div style="padding:5px;float:left;margin:auto;margin-left:70px;">
      <h2 style="padding:4px;">Test Type Setup</h2>
    </div>
    
    <table style="padding-left:-200px; width:100%;">
        <tr>
            <td class="auto-style2">
                <asp:Label ID="TestTypeIdLabel" runat="server" Text="Type Id :" Visible="false"></asp:Label></td>
            <td class="auto-style4">
                <asp:TextBox ID="TestTypeIdTextBox" runat="server" Visible="false" style="margin-left: 0px" Width="280px"></asp:TextBox>
            </td>
        </tr>

        <tr>
            <td class=" auto-style2">
                <asp:Label ID="TestTypeNameLabel" runat="server" Text="Type Name :" style="font-weight: 700"></asp:Label></td>
            <td class="auto-style4">
                <asp:TextBox ID="TestTypeNameTextBox"  runat="server" Width="282px" style="margin-left: 0px" Height="18px" required="true"></asp:TextBox>
                <!--
                <asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server"
                  ControlToValidate="TestTypeNameTextBox"
                  ErrorMessage="Test Type Name Is Empty!"
                  ForeColor="Red">
                </asp:RequiredFieldValidator>
                -->
            </td>
        </tr>
            
        <tr>
            <td class="auto-style4">&nbsp;</td>
            <td class="auto-style3"><asp:Label ID="MsgLabel" runat="server" Text=""></asp:Label></td>
        </tr>

        <tr>
            <td class="auto-style3"> </td>
            <td class="auto-style4">
                <asp:Button ID="saveButton" runat="server" Text="Save" Width="59px" OnClick="SaveButton_Click" />                         
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
                        <h3 style="background:url(../images/outright_logo.gif) no-repeat; margin-left:-100px;padding-left:50px">Test Type List :) </h3>
                        <br/>
                        <asp:GridView ID="GridView1" runat="server" Width="719px" AutoGenerateColumns="False" style="text-align: center">
            
                            <COLUMNS>
                                <asp:BoundField DataField="TestTypeId" HeaderText="SL" >
                                    <ControlStyle Width="150px" />
                                    <FooterStyle Width="15px" />
                                    <HeaderStyle Width="150px" />
                                    <ItemStyle Width="150px" />
                                </asp:BoundField>

                                <asp:BoundField DataField="TestTypeName" HeaderText="Type Name" >
                                    <ControlStyle Width="500px" />
                                    <FooterStyle Width="500px" />
                                    <HeaderStyle Width="500px" />
                                    <ItemStyle Width="500px" />
                                </asp:BoundField>
                
                            </COLUMNS>
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

