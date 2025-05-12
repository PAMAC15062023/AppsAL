<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MasterPage.master" AutoEventWireup="true" CodeFile="Scanning.aspx.cs" Inherits="Pages_JFS_Scanning" Theme="SkinFile"%>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script type="text/javascript">

    function ClientCheckmm() {
//        debugger
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

    function switchViews(obj, row) {
        ////debugger;
        var div = document.getElementById(obj);
        var img = document.getElementById('img' + obj);

        if (div.style.display == "none") {
            div.style.display = "inline";
            if (row == 'alt') {
                img.src = "Images/close.png";
                mce_src = "Images/close.png";
            }
            else {
                img.src = "Images/close.png";
                mce_src = "Images/close.png";
            }
            img.alt = "Close to view other customers";
        }
        else {
            div.style.display = "none";
            if (row == 'alt') {

                img.src = "Images/open.png";
                mce_src = "Images/open.png";
            }
            else {
                img.src = "Images/open.png";
                mce_src = "Images/open.png";

            }
            img.alt = "Expand to show Transactions";
        }
    }

</script>
     &nbsp;&nbsp;&nbsp;
    &nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
    &nbsp;&nbsp;&nbsp;
        <table style="width: 100%">
        <tr>
        <td colspan="4" class="TableHeader">
    <asp:Label ID="Label1" runat="server" ForeColor="Black" Font-Size="Medium" Text="Scanning Stage"></asp:Label>
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
            onselectedindexchanged="ddlbranch_SelectedIndexChanged" Width="100px">
        <asp:ListItem Value="0">----All------</asp:ListItem>
    </asp:DropDownList>
                </td>
                <td class="TableTitle" style="width: 30px">
    <asp:Label ID="lblappno" runat="server" Text="Applicant No."></asp:Label>
                </td>
                <td class="TableGrid" style="width: 509px">
    <asp:TextBox ID="txtAppNo" runat="server" Width="136px" AutoPostBack="True"></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan="4">
    <asp:Button ID="btnsearch" runat="server" Text="Search" onclick="btnsearch_Click" 
                        BorderColor="#400000" BorderWidth="1px" 
                        Font-Bold="False" Width="105px" style="height: 24px" /> 
                         &nbsp; &nbsp; &nbsp;&nbsp
     <%--<asp:Button ID="Button1" runat="server" Text="Save" BorderColor="#400000" BorderWidth="1px" 
                        Font-Bold="False" Width="105px" onclick="btnsave_Click" OnClientClick="javascript:ClientCheckmm()" 
                      ValidationGroup="validchk"/>--%>                  
                         &nbsp; &nbsp; &nbsp;&nbsp;
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
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" Width="96%" 
                        Height="136px" CssClass="mGrid"   
                        onrowcommand="GridView1_RowCommand" 
                        >
   <Columns>

   <asp:TemplateField>
<ItemTemplate>
<asp:LinkButton ID="lnkEditEmp" runat="server" CommandArgument='<%# Eval("app_id") %>' CommandName="Edit1" >
      <img src="../Images/icon_edit.gif" alt="Edit" style="border:0" /></asp:LinkButton>
      </ItemTemplate>
   </asp:TemplateField>

   <%--<asp:TemplateField>
   <ItemTemplate>
   <asp:CheckBox ID="chkid" runat="server"/>
   </ItemTemplate>
   </asp:TemplateField>--%>
   <asp:BoundField DataField="app_id" HeaderText="App ID." />
   <asp:BoundField DataField="Auto_Application_No" HeaderText="Application NO." />
    <asp:BoundField DataField="agency_date" HeaderText="Dispatch To agency Date" />
   <asp:BoundField DataField="branch_name" HeaderText="Branch Name" />
   <asp:BoundField DataField="Meeting_Center_Code" HeaderText="Meeting Center Code" />
   <asp:BoundField DataField="No_of_Customer" HeaderText="NO.Of Customers" />
   <asp:BoundField DataField="Total_Loan_Amount" HeaderText="Total Loan Amount" />
   <asp:BoundField DataField="Product_Code" HeaderText="Product Code" />
   <%--<asp:TemplateField HeaderText="Scanning Status">
   <ItemTemplate>
   <asp:DropDownList ID="ddlstatus" runat="server" AutoPostBack="True" 
           onselectedindexchanged="ddlstatus_SelectedIndexChanged" >
   <asp:ListItem>Received</asp:ListItem>
   <asp:ListItem>Received with Query</asp:ListItem>
   </asp:DropDownList>
   </ItemTemplate>
    </asp:TemplateField>--%>

   <%-- <asp:TemplateField HeaderText="Remark">
    <ItemTemplate>
    <asp:TextBox ID="txtremark" runat="server" Visible="false" TextMode="MultiLine"></asp:TextBox>
    </ItemTemplate>
    </asp:TemplateField>--%>
       
        
     <asp:TemplateField>

      <ItemTemplate>
  </td></tr>

</ItemTemplate>
</asp:TemplateField>
</Columns>
</asp:GridView>
</asp:Panel>
</td>
</tr>
<tr>
<td style="width: 82px">
</td>
<td>
    <asp:HiddenField ID="HiddenField2" runat="server" />
    </td>
<td style="width: 91px">
    <asp:HiddenField ID="HiddenField1" runat="server" />
</td>
<td style="width: 509px">
<asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="validchk" />
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

