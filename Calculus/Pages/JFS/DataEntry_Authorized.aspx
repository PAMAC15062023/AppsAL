<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MasterPage.master" AutoEventWireup="true" CodeFile="DataEntry_Authorized.aspx.cs" Inherits="Pages_JFS_DataEntry_Authorized" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

 <script type="text/javascript">

     function ClientCheckmm() {
        // debugger
         //alert("kkkk");
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
        <td colspan="6" class="TableHeader">
    <asp:Label ID="Label1" runat="server" ForeColor="Black" Text="Data Authorization Stage" Font-Size="Medium" ></asp:Label>
    <br />
    </td>
    </tr>
        <tr>
        <td colspan="6">
    <asp:Label ID="lblMsgXls" runat="server" ForeColor="Red"></asp:Label>
    <br />
    </td>
    </tr>
            <tr>
                 <td class="TableTitle" style="width: 106px">
    <asp:Label ID="lblbranch" runat="server" Text="Branch"></asp:Label>&nbsp;&nbsp;</td>
                <td class="TableGrid">
    <asp:DropDownList ID="ddlbranch" runat="server" 
            onselectedindexchanged="ddlbranch_SelectedIndexChanged" Width="100px">
        <asp:ListItem Value="0">----All------</asp:ListItem>
    </asp:DropDownList>
                </td>
                <td class="TableTitle" style="width: 30px">
    <asp:Label ID="lblappno" runat="server" Text="Applicant No."></asp:Label>
                </td>
                <td class="TableGrid" style="width: 791px">
    <asp:TextBox ID="txtAppNo" runat="server" Width="136px"></asp:TextBox>
                </td>
                <%--<td class="TableTitle" style="width: 30px">
    <asp:Label ID="lblname" runat="server" Text="User Name"></asp:Label>
                </td>
                <td class="TableGrid" style="width: 500px">
    <asp:DropDownList ID="ddlusername" runat="server" Width="100px" style="margin-left: 12px" >
   
   <asp:ListItem>---All---</asp:ListItem>
  
   </asp:DropDownList>
                </td>--%>
            </tr>
            <tr>
                <td colspan="6">
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
                <td style="width: 83px">
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan="7">
                <asp:Panel ID="pnlPayeeList" runat="server"  ScrollBars="Both">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" Width="100%" 
                        Height="136px" CssClass="mGrid">
   <Columns>
   <asp:TemplateField>
   <ItemTemplate>
   <asp:CheckBox ID="chkid" runat="server" />
   </ItemTemplate>
   </asp:TemplateField>
   <asp:BoundField DataField="Auto_Application_No" HeaderText="Application NO." />
   <asp:BoundField DataField="agency_date" HeaderText="Dispatch To agency Date" />
   <asp:BoundField DataField="branch_name" HeaderText="Branch Name" />
   <%--<asp:BoundField DataField="Meeting_Center_Code" HeaderText="Meeting Center Code" />--%>
   <asp:BoundField DataField="No_of_Customer" HeaderText="NO.Of Customers" />
   <asp:BoundField DataField="Total_Loan_Amount" HeaderText="Total Loan Amount" />
   <asp:BoundField DataField="file_at_agency" HeaderText="Agency Date" />
   <asp:BoundField DataField="Product_Code" HeaderText="Product Code" />
   <asp:TemplateField HeaderText="DA Status">
   <ItemTemplate>
   <asp:DropDownList ID="ddlDAstatus" runat="server" AutoPostBack="True" 
           onselectedindexchanged="ddlDAstatus_SelectedIndexChanged">
   <asp:ListItem>Completed</asp:ListItem>
   <asp:ListItem>InCompleted</asp:ListItem>
   </asp:DropDownList>
   </ItemTemplate>
    </asp:TemplateField>

    <asp:BoundField DataField="dde_comp_date" HeaderText="DE compele Date" />

    <%--<asp:TemplateField HeaderText="Remark">
    <ItemTemplate>
    <asp:TextBox ID="txtremark" runat="server" Visible="false" TextMode="MultiLine"></asp:TextBox>
    </ItemTemplate>
    </asp:TemplateField>
   --%>
   </Columns>
   <HeaderStyle CssClass="TableTitle" />
    
    </asp:GridView>
    </asp:Panel>



                </td>
            </tr>
            <tr>
                <td style="width: 106px">
    
                        </td>
   
               
                <td>
                    &nbsp;</td>
                <td style="width: 91px">
                   <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        Display="Dynamic" ErrorMessage=" Please Enter the Remark" 
                        ValidationGroup="validremark"></asp:RequiredFieldValidator>--%>
                </td>
                <td style="width: 791px">
                    &nbsp;</td>
                <td style="width: 434px">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td style="width: 83px">
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="width: 106px">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td style="width: 91px">
                    &nbsp;</td>
                <td style="width: 791px">
                    &nbsp;</td>
                <td style="width: 434px">
                    &nbsp;</td>
                <td>
                    <asp:ValidationSummary ID="validremark" runat="server" 
                        ValidationGroup="validremark" />
                </td>
                <td style="width: 83px">
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="width: 106px">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td style="width: 91px">
                    &nbsp;</td>
                <td style="width: 791px">
                    &nbsp;</td>
                <td style="width: 434px">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td style="width: 83px">
                    &nbsp;</td>
            </tr>
        </table>
</asp:Content>

