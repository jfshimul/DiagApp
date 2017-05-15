<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TestSetupUI.aspx.cs" Inherits="DiagnosticApp.UI.TestSetupUI" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="TitleHead" runat="server">
Test Setup Information
</asp:Content >


<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    
    <div style="padding:5px;float:left;margin:auto;margin-left:70px;">
      <h2 style="padding:4px;">Test Setup</h2>
    </div>
    
    <table style="padding-left:-200px; width:100%;">
        <tr>
            <td class="auto-style2">
                <asp:Label ID="TestSetupIdLabel" runat="server" Text="Type Id :" Visible="false" style="text-align: right"></asp:Label></td>
            <td class="auto-style4">
                <asp:TextBox ID="TestSetupIdTextBox" runat="server" Visible="false" style="margin-left: 0px" Width="280px"></asp:TextBox>
            </td>
        </tr>

        <tr>
            <td class="numberValue">
                <asp:Label ID="TestNameLabel" runat="server" Text="Test Name :" style="font-weight: 700"></asp:Label></td>
            <td class="auto-style4">
                <asp:TextBox ID="TestNameTextBox"  runat="server" Width="282px" style="margin-left: 0px" Height="18px" required="true"></asp:TextBox>
                <!--
                <asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server"
                  ControlToValidate="TestNameTextBox"
                  ErrorMessage="Test Name Is Empty!"
                  ForeColor="Red">
                </asp:RequiredFieldValidator>
                -->
            </td>
        </tr>
        
        <tr>
            <td class="numberValue">
                <asp:Label ID="TestFeeLabel" runat="server" Text="Fee :" style="font-weight: 700"></asp:Label></td>
            <td class="auto-style4">
                <asp:TextBox ID="TestFeeTextBox"  runat="server" Width="282px" style="margin-left: 0px" Height="18px" ></asp:TextBox>
                <asp:Label ID="bdtLabel" runat="server" Text="BDT" style="font-weight: 700"></asp:Label></td>
            
        </tr>
        
        <tr>
            <td class="numberValue">
                <asp:Label ID="TestTypeLabel" runat="server" Text="Test Type :" style="font-weight: 700"></asp:Label></td>
            <td class="auto-style4">
                <asp:DropDownList ID="TestTypeDropDownList" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
            
        <tr>
            <td class="auto-style4">&nbsp;</td>
            <td class="auto-style3"><asp:Label ID="MsgTestSetupLabel" runat="server" Text=""></asp:Label></td>
        </tr>

        <tr>
            <td class="auto-style3"> </td>
            <td class="auto-style4">
                <asp:Button ID="TestSetupSaveButton" runat="server" Text="Save" Width="59px" OnClick="TestSetupSaveButton_Click" />                         
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
                        <h3 style="background:url(../images/outright_logo.gif) no-repeat; margin-left:-100px;padding-left:50px">Test Setup List :) </h3>
                        <br/>
                        <asp:GridView ID="GridView2" runat="server" Width="719px" AutoGenerateColumns="False" style="text-align: center">
            
                            <COLUMNS>
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


