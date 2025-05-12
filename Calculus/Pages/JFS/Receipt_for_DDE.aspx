<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MasterPage.master" AutoEventWireup="true" CodeFile="Receipt_for_DDE.aspx.cs" Inherits="Pages_JFS_Receipt_for_DDE" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<%--<script>

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

</script>--%>

&nbsp;&nbsp;&nbsp;
    &nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
    &nbsp;&nbsp;&nbsp;
        <table style="width: 100%">
        <tr>
        <td colspan="4" class ="TableHeader">
    <asp:Label ID="Label1" runat="server" ForeColor="Black" Text="Receipt To DDE Stage" Font-Size="Medium"></asp:Label>
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
    <asp:DropDownList ID="ddlbranchrd" runat="server" 
            onselectedindexchanged="ddlbranch_SelectedIndexChanged" Width="100px">
        <asp:ListItem Value="0">----All------</asp:ListItem>
    </asp:DropDownList>
                </td>
                <td class="TableTitle" style="width: 30px">
    <asp:Label ID="lblappno" runat="server" Text="Applicant No."></asp:Label>
                </td>
                <td class="TableGrid" style="width: 509px">
    <asp:TextBox ID="txtAppNord" runat="server" Width="136px" ></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan="4">
    <asp:Button ID="btnsearch" runat="server" Text="Search" onclick="btnsearch_Click" BorderColor="#400000" BorderWidth="1px" 
                        Font-Bold="False" Width="105px" /> &nbsp; &nbsp; &nbsp;&nbsp;

  <asp:Button ID="Button1" runat="server" Text="Save" BorderColor="#400000" BorderWidth="1px" 
                        Font-Bold="False" Width="105px" onclick="btnsave_Click" OnClientClick="javascript:ClientCheckmm()"/> &nbsp; &nbsp; &nbsp;&nbsp;
    <asp:Button ID="btnCancel" runat="server" Text="Cancel" 
        onclick="btnCancelRD_Click" BorderColor="#400000" BorderWidth="1px" 
                        Font-Bold="False" Width="105px" />
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan="5">
                <asp:Panel ID="pnlPayeeList" runat="server"  ScrollBars="Both">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" Width="100%" 
                        Height="136px" CssClass="mGrid"  
                        >
   <Columns>
   <asp:TemplateField>
   <ItemTemplate>
   <asp:CheckBox ID="chkid" runat="server" />
   </ItemTemplate>
   </asp:TemplateField>
   <asp:BoundField DataField="Auto_Application_No" HeaderText="Application NO." />
    <asp:BoundField DataField="agency_date" HeaderText="Dispatch To agency Date" />
   <asp:BoundField DataField="branch_name" HeaderText="Branch Name" />
   <asp:BoundField DataField="Meeting_Center_Code" HeaderText="Meeting Center Code" />
   <asp:BoundField DataField="No_of_Customer" HeaderText="NO.Of Customers" />
   <asp:BoundField DataField="Total_Loan_Amount" HeaderText="Total Loan Amount" />
   <asp:BoundField DataField="Product_Code" HeaderText="Product Code" />
    <asp:BoundField DataField="RRE_Date" HeaderText="File Received at Agency" />
   <asp:TemplateField HeaderText="Receipt Status">
   <ItemTemplate>
   <asp:DropDownList ID="ddlstatus" runat="server" AutoPostBack="True" onselectedindexchanged="ddlstatus_SelectedIndexChanged" 
            >
   <asp:ListItem>Received</asp:ListItem>
   <asp:ListItem>Not Received</asp:ListItem>
   </asp:DropDownList>
   </ItemTemplate>
    </asp:TemplateField>
   
   </Columns>
   <HeaderStyle CssClass="TableTitle" />
    
    </asp:GridView>
    </asp:Panel>



                </td>
            </tr>
            <tr>
                <td style="width: 82px">
    </td>
                <td>
                    &nbsp;</td>
                <td style="width: 91px">
                    &nbsp;</td>
                <td style="width: 509px">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="width: 82px">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td style="width: 91px">
                    &nbsp;</td>
                <td style="width: 509px">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="width: 82px">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td style="width: 91px">
                    &nbsp;</td>
                <td style="width: 509px">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>

</asp:Content>

