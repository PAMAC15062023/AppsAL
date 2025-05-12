<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MasterPage.master" AutoEventWireup="true" CodeFile="re_assign.aspx.cs" Inherits="Pages_JFS_re_assign" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table style="width: 100%">

<tr>
        <td colspan="2" class="TableHeader">
    <asp:Label ID="Label1" runat="server" ForeColor="black" Font-Size="Medium" Text ="Re-Assign Stage"></asp:Label>
    <br />
    </td>
    </tr>

    <tr>
    <td class="TableTitle" style="width: 154px">
    <asp:Label ID="lblname" runat="server" Text ="Select Type:"></asp:Label>
    </td>
    <td class="TableGrid">
    <asp:DropDownList ID="ddltype" runat="server" AutoPostBack="True" onselectedindexchanged="ddltype_SelectedIndexChanged">
    <asp:ListItem>DE</asp:ListItem>
    <asp:ListItem>DA</asp:ListItem>    
    </asp:DropDownList>
    </td></tr>
  </table>
    
    <asp:Panel ID="pnlDA" runat="server" Visible="false">
 
   <table style="width: 100%">                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                       
        <tr>
        <td colspan="4" class="TableHeader">
    <asp:Label ID="Label9" runat="server" ForeColor="Black" Text=" DA User Assignment Stage" Font-Size="Medium"></asp:Label>
    <br />
    </td>
    </tr>
        <tr>
        <td colspan="4">
    <asp:Label ID="Label10" runat="server" ForeColor="Red"></asp:Label>
    <br />
    </td>
    </tr>
            <tr>
                <td class="TableTitle" style="width: 82px">
    <asp:Label ID="Label11" runat="server" Text="Branch"></asp:Label>&nbsp;&nbsp;</td>
                <td class="TableGrid">
    <asp:DropDownList ID="ddlbranch_da" runat="server" 
            Width="100px">
        <asp:ListItem Value="0">----All------</asp:ListItem>
    </asp:DropDownList>
                </td>
                <td class="TableTitle" style="width: 30px">
    <asp:Label ID="Label12" runat="server" Text="Applicant No."></asp:Label>
                </td>
                <td class="TableGrid" style="width: 93px">
    <asp:TextBox ID="txtappno_da" runat="server" Width="100px"></asp:TextBox>
                </td>
                <td class="TableTitle">
    <asp:Label ID="Label13" runat="server" Text="User Name"></asp:Label>
                </td>
                <td class="TableGrid" style="width: 509px">
    <asp:DropDownList ID="ddluser_da" runat="server" Width="100px" style="margin-left: 12px">
   
   <asp:ListItem>---All---</asp:ListItem>
  
   </asp:DropDownList>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan="4" style="height: 27px">
    <asp:Button ID="btnserach_DA" runat="server" Text="Search" 
                        BorderColor="#400000" BorderWidth="1px" 
                        Font-Bold="False" Width="105px" style="height: 24px" 
                         /> 
                         &nbsp; &nbsp; &nbsp;
      <asp:Button ID="btnreassign_da" runat="server" Text="Reassign" BorderColor="#400000" BorderWidth="1px" 
                        Font-Bold="False" Width="105px" style="height: 24px"   
                        OnClientClick="javascript:ClientCheckmm()" 
                        onclick="btnreassign_da_Click" /> 
                     &nbsp; &nbsp; &nbsp;
                        
                        
    <asp:Button ID="btncancel_da" runat="server" Text="Cancel" 
         BorderColor="#400000" BorderWidth="1px" 
                        Font-Bold="False" Width="132px" style="height: 24px" 
                        onclick="btncancel_da_Click" /> &nbsp; 
   
                </td>
                <td style="width: 117px; height: 27px;">
                    </td>
            </tr>
            <tr>
                   <td colspan="5">
                <asp:Panel ID="Panel1" runat="server"  ScrollBars="Both" Width="794px">
    <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="false" Width="71%" 
                        Height="136px" CssClass="mGrid">
   <Columns>
   <asp:TemplateField>
   <ItemTemplate>
   <asp:CheckBox ID="chkid" runat="server" />
   </ItemTemplate>
   </asp:TemplateField>
   <asp:BoundField DataField="Auto_Application_No" HeaderText="Application NO." />
   <asp:BoundField DataField="dispatch_date" HeaderText="Dispatch To agency Date" />
   <asp:BoundField DataField="branch_name" HeaderText="Branch Name" />
   <asp:BoundField DataField="Meeting_Center_Code" HeaderText="Meeting Center Code" />
   <asp:BoundField DataField="No_of_Customer" HeaderText="NO.Of Customers" />
   <asp:BoundField DataField="Total_Loan_Amount" HeaderText="Total Loan Amount" />
   <asp:BoundField DataField="agency_date" HeaderText="File Received at Agency" />
   <asp:BoundField DataField="Product_Code" HeaderText="Product Code" />
   </Columns>
   <HeaderStyle CssClass="TableTitle" />
    
    </asp:GridView>
   
   
    </asp:Panel>
    </table>
    </asp:Panel>

 
  <asp:Panel ID="pnlDE" runat="server" Visible="false">
 <table style="width: 100%">
 
 <tr>
 <td>
 <asp:Label ID="lblMsgXls" runat="server" Text=""></asp:Label>
 </td>
 </tr>
        <tr>
        <td colspan="4" class="TableHeader">
    <asp:Label ID="Label4" runat="server" ForeColor="Black" Text="DE User Assignment Stage" Font-Size="Medium"></asp:Label>
    <br />
    </td>
    </tr>
        <tr>
        <td colspan="4">
    <asp:Label ID="Label5" runat="server" ForeColor="Red"></asp:Label>
    <br />
    </td>
            <td>
            </td>
    </tr>
            <tr>
                <td class="TableTitle" style="width: 82px">
    <asp:Label ID="Label6" runat="server" Text="Branch"></asp:Label>&nbsp;&nbsp;</td>
                <td class="TableGrid">
    <asp:DropDownList ID="ddlbranch_DE" runat="server" 
            Width="100px" >
        <asp:ListItem Value="0">----All------</asp:ListItem>
    </asp:DropDownList>
                </td>
                <td class="TableTitle" style="width: 111px">
    <asp:Label ID="Label7" runat="server" Text="Applicant No."></asp:Label>
                </td>
                <td class="TableGrid" style="width: 157px">
    <asp:TextBox ID="txtappno_de" runat="server" Width="100px"></asp:TextBox>
                </td>

                <td class="TableTitle" style="width: 117px">
    <asp:Label ID="Label8" runat="server" Text="User Name"></asp:Label>
                </td>
                <td class="TableGrid" style="width: 509px">
    <asp:DropDownList ID="ddluser_DE" runat="server" Width="100px" style="margin-left: 12px" >
   
   <asp:ListItem>---All---</asp:ListItem>
  
   </asp:DropDownList>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan="4" style="height: 27px">
    <asp:Button ID="btnsearch_de" runat="server" Text="Search"  
                        BorderColor="#400000" BorderWidth="1px" 
                        Font-Bold="False" Width="105px" style="height: 24px" 
                        onclick="btnsearch_de_Click" /> 
                         &nbsp; &nbsp; &nbsp;
      <asp:Button ID="btnreassign_de" runat="server" Text="Reassign" BorderColor="#400000" BorderWidth="1px" 
                        Font-Bold="False" Width="105px" style="height: 24px"  OnClientClick="javascript:ClientCheckmm()" OnClick="btnreassign_de_Click"/> 
                     &nbsp; &nbsp; &nbsp;
                        
                        
    <asp:Button ID="btncancel_de" runat="server" Text="Cancel" 
  BorderColor="#400000" BorderWidth="1px" 
                        Font-Bold="False" Width="132px" style="height: 24px" 
                        onclick="btncancel_de_Click" /> &nbsp; 
   
                </td>
                <td style="width: 117px; height: 27px;">
                    &nbsp;</td>
            </tr>
            <tr>
                   <td colspan="5">

    <asp:GridView ID="grd_dedata" runat="server" AutoGenerateColumns="false" Width="71%" 
                        Height="136px" CssClass="mGrid">
   <Columns>
   <asp:TemplateField>
   <ItemTemplate>
   <asp:CheckBox ID="chkid" runat="server" />
   </ItemTemplate>
   </asp:TemplateField>
   <asp:BoundField DataField="Auto_Application_No" HeaderText="Application NO." />
   <asp:BoundField DataField="dispatch_date" HeaderText="Dispatch To agency Date" />
   <asp:BoundField DataField="branch_name" HeaderText="Branch Name" />
   <asp:BoundField DataField="Meeting_Center_Code" HeaderText="Meeting Center Code" />
   <asp:BoundField DataField="No_of_Customer" HeaderText="NO.Of Customers" />
   <asp:BoundField DataField="Total_Loan_Amount" HeaderText="Total Loan Amount" />
   <asp:BoundField DataField="agency_date" HeaderText="File Received at Agency" />
   <asp:BoundField DataField="Product_Code" HeaderText="Product Code" />
   </Columns>
   <HeaderStyle CssClass="TableTitle" />
    
    </asp:GridView>
   <%-- <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="Please select at least one record."
    ClientValidationFunction="Validate" ForeColor="Red"></asp:CustomValidator>--%>




                </td>
            </tr>
            <tr>
                <td style="width: 82px">
    <%--<asp:Button ID="btnsave" runat="server" Text="Save" BorderColor="#400000" BorderWidth="1px" 
                        Font-Bold="False" Width="105px"/> --%>
                        </td>
   
               
                <td>
                    &nbsp;</td>
                <td style="width: 111px">
                   <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        Display="Dynamic" ErrorMessage=" Please Enter the Remark" 
                        ValidationGroup="validremark"></asp:RequiredFieldValidator>--%>
                </td>
                <td style="width: 157px">
                    &nbsp;</td>
                <td style="width: 117px">
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="width: 82px">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td style="width: 111px">
                    &nbsp;</td>
                <td style="width: 157px">
                    <asp:ValidationSummary ID="validremark" runat="server" 
                        ValidationGroup="validremark" />
                </td>
                <td style="width: 117px">
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="width: 82px">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td style="width: 111px">
                    &nbsp;</td>
                <td style="width: 157px">
                    &nbsp;</td>
                <td style="width: 117px">
                    &nbsp;</td>
            </tr>
        </table>
 </asp:Panel>
 





    
  

        

</asp:Content>

