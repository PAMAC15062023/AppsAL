<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MasterPage3.master" AutoEventWireup="true" CodeFile="DA_user_assign.aspx.cs" Inherits="Pages_JFS_DA_user_assign" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<script>

    function ClientCheckmm() {
        //        debugger
        //        alert("kkkk")
        var valid = false;
        var gv = document.getElementById("<%=GridView1.ClientID %>");
        for (var i = 0; i < gv.getElementsByTagName("input").length; i++) {
            var node = gv.getElementsByTagName("input")[i];
            if (node != null && node.type == "checkbox" && node.checked) {
                valid = true;
                break;

            }
        }
        if (!valid) {
            alert("Invalid. Please select any Case to change.");
        }
        return valid;
    }
</script>
    &nbsp;&nbsp;&nbsp;
    &nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
    &nbsp;&nbsp;&nbsp;
        <table style="width: 100%">
        <tr>
        <td colspan="4" class="TableHeader">
    <asp:Label ID="Label1" runat="server" ForeColor="Black" Text=" DA User Assignment Stage" Font-Size="Medium"></asp:Label>
    <br />
    </td>
    </tr>
        <tr>
        <td colspan="4">
    <asp:Label ID="lblMsgXls" runat="server" ForeColor="Red"></asp:Label>
    <br />
    </td>
    </tr>
            <tr>
                <td class="TableTitle" style="width: 82px">
    <asp:Label ID="lblbranch" runat="server" Text="Branch"></asp:Label>&nbsp;&nbsp;</td>
                <td class="TableGrid">
    <asp:DropDownList ID="ddlbranch" runat="server" 
            Width="100px" onselectedindexchanged="ddlbranch_SelectedIndexChanged" >
        <asp:ListItem Value="0">----All------</asp:ListItem>
    </asp:DropDownList>
                </td>
                <td class="TableTitle" style="width: 30px">
    <asp:Label ID="lblappno" runat="server" Text="Applicant No."></asp:Label>
                </td>
                <td class="TableGrid" style="width: 93px">
    <asp:TextBox ID="txtAppNo" runat="server" Width="100px"></asp:TextBox>
                </td>
                <td class="TableTitle">
    <asp:Label ID="lblname" runat="server" Text="User Name"></asp:Label>
                </td>
                <td class="TableGrid" style="width: 509px">
    <asp:DropDownList ID="ddlusername" runat="server" Width="100px" style="margin-left: 12px" 
                        onselectedindexchanged="ddlusername_SelectedIndexChanged" >
   
   <asp:ListItem>---All---</asp:ListItem>
  
   </asp:DropDownList>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan="4" style="height: 27px">
    <asp:Button ID="btnsearch" runat="server" Text="Search" 
                        BorderColor="#400000" BorderWidth="1px" 
                        Font-Bold="False" Width="105px" style="height: 24px" 
                        onclick="btnsearch_Click" /> 
                         &nbsp; &nbsp; &nbsp;
      <asp:Button ID="btnassign" runat="server" Text="Assign/Reassign" BorderColor="#400000" BorderWidth="1px" 
                        Font-Bold="False" Width="105px" style="height: 24px"   
                        OnClientClick="javascript:ClientCheckmm()" onclick="btnassign_Click"/> 
                     &nbsp; &nbsp; &nbsp;
                        
                        
    <asp:Button ID="btnCancel" runat="server" Text="Cancel" 
        onclick="btnCancel_Click" BorderColor="#400000" BorderWidth="1px" 
                        Font-Bold="False" Width="132px" style="height: 24px" /> &nbsp; 
   
                </td>
                <td style="width: 117px; height: 27px;">
                    </td>
            </tr>
            <tr>
                   <td colspan="5">
                <asp:Panel ID="pnlPayeeList" runat="server"  ScrollBars="Both" Width="794px">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" Width="71%" 
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

    </asp:Panel>



                </td>
            </tr>
            <tr>
                <td style="width: 82px">
    <%--<asp:Button ID="btnsave" runat="server" Text="Save" BorderColor="#400000" BorderWidth="1px" 
                        Font-Bold="False" Width="105px"/> --%>
                        </td>
   
               
                <td>
                    &nbsp;</td>
                <td style="width: 108px">
                   <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        Display="Dynamic" ErrorMessage=" Please Enter the Remark" 
                        ValidationGroup="validremark"></asp:RequiredFieldValidator>--%>
                </td>
                <td style="width: 93px">
                    &nbsp;</td>
                <td style="width: 117px">
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="width: 82px">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td style="width: 108px">
                    &nbsp;</td>
                <td style="width: 93px">
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
                <td style="width: 108px">
                    &nbsp;</td>
                <td style="width: 93px">
                    &nbsp;</td>
                <td style="width: 117px">
                    &nbsp;</td>
            </tr>
        </table>


</asp:Content>

