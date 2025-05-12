<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MasterPage.master" AutoEventWireup="true" CodeFile="Quality_control.aspx.cs" Inherits="Pages_JFS_Quality_control" %>

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
            alert("Invalid. Please select any Case to save.");
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
    <asp:Label ID="Label1" runat="server" ForeColor="black" Text="Quality Ckeck" Font-Size="Medium"></asp:Label>
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
    <asp:DropDownList ID="ddlbranch_qc" runat="server" 
          Width="100px" onselectedindexchanged="ddlbranch_qc_SelectedIndexChanged1">
        <asp:ListItem Value="0">----All------</asp:ListItem>
    </asp:DropDownList>
                </td>
                <td class="TableTitle" style="width: 30px">
    <asp:Label ID="lblappno" runat="server" Text="Applicant No."></asp:Label>
                </td>
                <td class="TableGrid" style="width: 509px">
    <asp:TextBox ID="txtAppNo" runat="server" Width="136px"></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan="4">
    <asp:Button ID="btnsearch" runat="server" Text="Search" 
                        BorderColor="#400000" BorderWidth="1px" 
                        Font-Bold="False" Width="105px" style="height: 24px" 
                        onclick="btnsearch_Click" /> &nbsp; &nbsp; &nbsp;&nbsp;

     <asp:Button ID="btnsave" runat="server" Text="Save" BorderColor="#400000" BorderWidth="1px" 
                        Font-Bold="False" Width="105px" onclick="btnsave_Click" OnClientClick="javascript:ClientCheckmm()"/> &nbsp; &nbsp; &nbsp;&nbsp; 
    <asp:Button ID="btnCancel" runat="server" Text="Cancel" 
        onclick="btnCancel_Click" BorderColor="#400000" BorderWidth="1px" 
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
   <asp:BoundField DataField="branch_name" HeaderText="Branch Name" />
   <asp:BoundField DataField="Meeting_Center_Code" HeaderText="Meeting Center Code" />
   <asp:BoundField DataField="No_of_Customer" HeaderText="NO.Of Customers" />
   <asp:BoundField DataField="Total_Loan_Amount" HeaderText="Total Loan Amount" />
   <asp:BoundField DataField="Product_Code" HeaderText="Product Code" />
    <asp:BoundField DataField="dde_comp_date" HeaderText="DE Compele Date" />
   <asp:TemplateField HeaderText="QC Status">
   <ItemTemplate>
   <asp:DropDownList ID="ddlstatus" runat="server" AutoPostBack="True" 
           onselectedindexchanged="ddlstatus_SelectedIndexChanged">
   <asp:ListItem>Completed</asp:ListItem>
   <asp:ListItem>Incompleted</asp:ListItem>
   <asp:ListItem></asp:ListItem>
   </asp:DropDownList>
   </ItemTemplate>
    </asp:TemplateField>


    <asp:TemplateField HeaderText="Error">
   <ItemTemplate>
   <asp:DropDownList ID="ddlerror" runat="server" AutoPostBack="True" 
           onselectedindexchanged="ddlerror_SelectedIndexChanged">
   <asp:ListItem>No</asp:ListItem>
   <asp:ListItem>Yes</asp:ListItem>
   <asp:ListItem></asp:ListItem>
   </asp:DropDownList>
   </ItemTemplate>
    </asp:TemplateField>
    
    <asp:TemplateField HeaderText="Remark">
    <ItemTemplate>
    <asp:TextBox ID="txtremark" runat="server" Visible="false" TextMode="MultiLine"></asp:TextBox>
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
                   <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        Display="Dynamic" ErrorMessage=" Please Enter the Remark" 
                        ValidationGroup="validremark"></asp:RequiredFieldValidator>--%>
                </td>
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
                    <asp:ValidationSummary ID="validremark" runat="server" 
                        ValidationGroup="validremark" />
                </td>
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

