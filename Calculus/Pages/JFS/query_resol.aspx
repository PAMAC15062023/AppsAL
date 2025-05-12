<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MasterPage.master" AutoEventWireup="true" CodeFile="query_resol.aspx.cs" Inherits="Pages_JFS_query_resol" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script type="text/javascript" language="javascript">

    function ClientCheckmm() {
        //          debugger
        //          alert("kkkk")
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
<table>
<tr>
<td colspan="4" class="TableHeader">
<asp:Label ID="Label1" runat="server" ForeColor="black" Font-Size="Medium" Text ="Query Resolution Stage"></asp:Label>
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
    <asp:DropDownList ID="ddlbranch" runat="server" Width="100px" 
                        onselectedindexchanged="ddlbranch_SelectedIndexChanged">
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
                         /> &nbsp; &nbsp; &nbsp;&nbsp;

     <asp:Button ID="Button1" runat="server" Text="Save" BorderColor="#400000" BorderWidth="1px" 
                        Font-Bold="False" Width="105px" OnClientClick="javascript:ClientCheckmm()" 
                        onclick="Button1_Click"/> &nbsp; &nbsp; &nbsp;&nbsp;
    <asp:Button ID="btnCancel" runat="server" Text="Cancel" 
       BorderColor="#400000" BorderWidth="1px" 
                        Font-Bold="False" Width="105px" onclick="btnCancel_Click"/>
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
   <asp:BoundField DataField="dispatch_date" HeaderText="Dispatch To agency Date" />
   <asp:BoundField DataField="branch_name" HeaderText="Branch Name" />
   <%--<asp:BoundField DataField="Meeting_Center_Code" HeaderText="Meeting Center Code" />--%>
   <asp:BoundField DataField="No_of_Customer" HeaderText="NO.Of Customers" />
   <asp:BoundField DataField="Total_Loan_Amount" HeaderText="Total Loan Amount" />
   <asp:BoundField DataField="agency_date" HeaderText="Received Date Frmo Sales" />
   <asp:BoundField DataField="Product_Code" HeaderText="Product Code" />
   <asp:TemplateField HeaderText="DataEntry Status">
   <ItemTemplate>
   <asp:DropDownList ID="ddlstatus" runat="server" AutoPostBack="True" 
           onselectedindexchanged="ddlstatus_SelectedIndexChanged">
   <asp:ListItem>Completed</asp:ListItem>
   <asp:ListItem>Incompleted</asp:ListItem>
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
</table>
</asp:Content>

