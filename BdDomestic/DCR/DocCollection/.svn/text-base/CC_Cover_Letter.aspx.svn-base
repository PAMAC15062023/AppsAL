<%@ Page Language="C#" MasterPageFile="~/DCR/DocCollection/CC_MasterPage.master" AutoEventWireup="true" CodeFile="~/DCR/DocCollection/CC_Cover_Letter.aspx.cs" Inherits="CPV_CC_CC_Cover_Letter" Theme="SkinFile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="C1" Runat="Server">
<script type="text/javascript" language="javascript">
<!--
 function ValidateDateTime(source,arguments)
 {      
       if(document.getElementById("<%=rdoDateTime.ClientID%>").checked==true)
       {
            if(document.getElementById("<%=txtDate.ClientID%>").value=="" || document.getElementById("<%=txtTime.ClientID%>").value=="")
            {                  
                  arguments.IsValid=false;
            }
       }      
 }
 
 function ValidateFromToDateTime(source,arguments)
 {      
       if(document.getElementById("<%=rdoFromToDate.ClientID%>").checked==true)
       {
            if(document.getElementById("<%=txtDateFrom.ClientID%>").value=="" || document.getElementById("<%=txtDateTo.ClientID%>").value=="")
            {                  
                  arguments.IsValid=false;
            }
       }      
 }
 -->
</script>
<div>
<table border="0" cellpadding="0" cellspacing="0" width="99%">
<tr><td style="padding-left:10px">
<fieldset><legend class="FormHeading">Covering Letter</legend>
        <table align="center" width="100%">
            <tr>
                <td colspan="1">
                </td>
                <td colspan="1">
                </td>
                <td colspan="8">
                </td>
            </tr>
            <tr>
                <td>
                    <asp:RadioButton ID="rdoFromToDate" runat="server" GroupName="SelectDateCriteria" Checked="true" /></td>
                
                <td >
                     From Date<font color="red"> *</font></td>
                <td >
                    :</td>
                <td >
                    <asp:TextBox ID="txtDateFrom" runat="server" Width="155px" SkinID="txtSkin" MaxLength="10"></asp:TextBox>
                    <img alt="" src="../../Images/SmallCalendar.gif" onclick="popUpCalendar(this,document.all.<%=txtDateFrom.ClientID %>,'dd/mm/yyyy',0,0);" />
                    [dd/MM/yyyy]</td>
                
                <td >
                    To Date<font color="red"> *</font><font color="red"></font></td>
                <td >
                    :</td>
                <td >
                    <asp:TextBox ID="txtDateTo" runat="server" Width="155px" SkinID="txtSkin" MaxLength="10"></asp:TextBox>
                    <img alt="" src="../../Images/SmallCalendar.gif" onclick="popUpCalendar(this,document.all.<%=txtDateTo.ClientID %>,'dd/mm/yyyy',0,0)";/>
                    [dd/MM/yyyy]</td>
                <td>
                </td>
                <td >
                </td>
                
            </tr>
            <tr><td colspan="9"><hr /></td></tr>
            <tr>
                <td>
                    <asp:RadioButton ID="rdoDateTime" runat="server" GroupName="SelectDateCriteria"  /></td>
                <td>
                    <table align="center" width="100%">
                        <tr>
                           
                <td>
                    Date <span style="color: #ff0000">*</span></td>
                        </tr>
                    </table>
                </td>
                <td>
                    :</td>
                <td>
                    <asp:TextBox ID="txtDate" runat="server" MaxLength="10" SkinID="txtSkin" Width="155px"></asp:TextBox>
                    <img alt="" src="../../Images/SmallCalendar.gif" onclick="popUpCalendar(this,document.all.<%=txtDate.ClientID %>,'dd/mm/yyyy',0,0);" />
                    [dd/MM/yyyy]</td>
                <td>
                    Time <span style="color: #ff0000">*<font color="red"></font></span></td>
                <td>
                    :</td>
                <td>
                    <asp:TextBox ID="txtTime" runat="server" MaxLength="5" SkinID="txtSkin" Width="44px"></asp:TextBox>
                    <asp:DropDownList ID="ddlTimeType" runat="server" SkinID="ddlSkin">
                        <asp:ListItem Text="AM" Value="AM"></asp:ListItem>
                        <asp:ListItem Text="PM" Value="PM"></asp:ListItem>
                    </asp:DropDownList></td>
                <td>
                <asp:Button ID="btnSubmit" runat="server" SkinID="btnReportSkin"
                        OnClick="btnSubmit_Click" ValidationGroup="valGrp" />
                </td>
            </tr>
            <tr>
                <td colspan="10" style="height: 18px">
                    <asp:Label ID="lblMessage" runat="server" SkinID="lblErrorMsg"></asp:Label></td>
            </tr>
        </table>
   </fieldset> 
   </td></tr>
</table>
    </div>
    
    <asp:GridView ID="gvCoverLetter" runat="server" AutoGenerateColumns="False" SkinID="gridviewSkin">
        <Columns>
            <asp:BoundField HeaderText="Sr. No"  />
            <asp:BoundField DataField="Ref_no" HeaderText="Reference Nos" />
            <asp:BoundField DataField="Case_rec_dateTime" HeaderText="Received Date" DataFormatString="{0:dd-MM-yyyy}" HtmlEncode="False" />
            <asp:BoundField HeaderText="Types of Verification" DataField="Verification_code" />
            <asp:BoundField DataField="Name" HeaderText="Full Name" />
            <asp:BoundField DataField="send_Datetime" HeaderText="Send Date" DataFormatString="{0:dd-MM-yyyy}" HtmlEncode="False"  />
        </Columns>
    </asp:GridView>
    &nbsp;
    <asp:SqlDataSource ID="sdsgvCoverLetter" runat="server" ConnectionString="<%$ ConnectionStrings:CMConnectionString %>"
        ProviderName="<%$ ConnectionStrings:CMConnectionString.ProviderName %>">
    </asp:SqlDataSource>
    
    <asp:ValidationSummary ID="vsDate" runat="server" ShowMessageBox="True" ShowSummary="False" Width="152px" ValidationGroup="valGrp" />
    
    <%--<asp:RequiredFieldValidator ID="rfvDateFrom" runat="server" ControlToValidate="txtDateFrom"
        ErrorMessage="Please Select a Start Date." Display="None" ValidationGroup="valGrp"></asp:RequiredFieldValidator><asp:RequiredFieldValidator ID="rfvDateTo" runat="server" ControlToValidate="txtDateTo"
        ErrorMessage="Please Select a  End Date " Display="None" ValidationGroup="valGrp"></asp:RequiredFieldValidator>&nbsp;
    --%>
    <asp:RegularExpressionValidator ID="revFromDate" runat="server" ControlToValidate="txtDateFrom"
        Display="None" ErrorMessage="Please enter valid date format for From Date" SetFocusOnError="True"
        ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d" ValidationGroup="valGrp"></asp:RegularExpressionValidator>
    <asp:RegularExpressionValidator ID="revToDate" runat="server" ControlToValidate="txtDateTo"
        Display="None" ErrorMessage="Please enter valid date format for To Date" SetFocusOnError="True"
        ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d" ValidationGroup="valGrp"></asp:RegularExpressionValidator>
        
    <asp:RegularExpressionValidator ID="revDate" runat="server" ControlToValidate="txtDate"
        Display="None" ErrorMessage="Please enter valid date format for Date" SetFocusOnError="True"
        ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d" ValidationGroup="valGrp"></asp:RegularExpressionValidator>
        
    <asp:RegularExpressionValidator ID="revTime" runat="server" ControlToValidate="txtTime"
        Display="None" ErrorMessage="Please enter valid time format."
        SetFocusOnError="True" ValidationExpression="(0[1-9]|1[0-2])[:]([0-5][0-9])"
        ValidationGroup="valGrp"></asp:RegularExpressionValidator>
                    
    <asp:CustomValidator ID="cvDateTime" runat="server" Display="None" ErrorMessage="Please select both date and time."
        ValidationGroup="valGrp" ClientValidationFunction="ValidateDateTime"></asp:CustomValidator>
        
    <asp:CustomValidator ID="cvFromToDateTime" runat="server" Display="None" ErrorMessage="Please select both From date and To Date."
        ValidationGroup="valGrp" ClientValidationFunction="ValidateFromToDateTime"></asp:CustomValidator>
        
</asp:Content>

