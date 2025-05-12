<%@ Page Language="C#" MasterPageFile="~/CPV/CC/CC_MasterPage.master" AutoEventWireup="true" Theme="SkinFile" CodeFile="CC_QC_LabelPrinting.aspx.cs" Inherits="CPV_CC_CC_QC_LabelPrinting" Title="Untitled Page" %>
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
            if(document.getElementById("<%=txtfrom.ClientID%>").value=="" || document.getElementById("<%=txtto.ClientID%>").value=="")
            {                  
                  arguments.IsValid=false;
            }
       }      
 }
 -->
</script>
<table border="0" cellpadding="0" cellspacing="0" width="99%">
<tr><td style="padding-left:10px">
    <fieldset>
        
        <legend class="FormHeading">QC - Label Printing</legend>
        <table id="tblLabelPrinting" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td align="left" style="width: 14px; height: 7px" valign="top">
            </td>
            <td align="left" style="width: 99px; height: 7px;" valign="top">
            </td>
            <td align="left" valign="top" style="height: 7px">
            </td>
            <td align="left" colspan="3" valign="top" style="height: 7px">
            </td>
            <td align="left" valign="top" style="height: 7px">
            </td>
            <td align="left" style="width: 109px; height: 7px;" valign="top">
            </td>
            <td align="left" style="width: 119px; height: 7px;" valign="top">
            </td>
            <td align="left" style="width: 119px; height: 7px" valign="top">
            </td>
            <td align="left" style="width: 100px; height: 7px;" valign="top">
            </td>
        </tr>
        <tr>
            <td align="left" style="width: 14px; " valign="top">
                <asp:RadioButton ID="rdoFromToDate" runat="server" Checked="true" GroupName="SelectDateCriteria"
                   /></td>
            <td align="left" style="width: 99px; ;" valign="top">
                From Date<span style="color: red">*</span></td>
            <td align="left" valign="top" style="">
                :</td>
            <td align="left" style="width: 11px; ;" valign="top">
                <asp:TextBox ID="txtfrom" runat="server" Width="100px" SkinID="txtSkin" MaxLength="10"></asp:TextBox>&nbsp;</td>
            <td align="left" style="width: 100px; ;" valign="top">
            <img id="imgfrom" alt="Calendar"  src="../../Images/SmallCalendar.gif" onclick="popUpCalendar(this, document.all.<%=txtfrom.ClientID%>, 'dd/mm/yyyy', 0, 0);" />&nbsp;[dd/mm/yyyy]</td>
            <td align="left" style="width: 44px; ;" valign="top">
                To Date<span style="color: #ff0000">*</span></td>
            <td align="left" valign="top" style="">
                :</td>
            <td align="left" style="width: 109px; ;" valign="top">
                <asp:TextBox ID="txtto" runat="server" Width="100px" SkinID="txtSkin" MaxLength="10"></asp:TextBox></td>
            <td align="left" style="width: 119px; ;" valign="top">
                <img id="imgto" alt="Calendar" src="../../Images/SmallCalendar.gif" onclick="popUpCalendar(this, document.all.<%=txtto.ClientID%>, 'dd/mm/yyyy', 0, 0);" />&nbsp;[dd/mm/yyyy]</td>
            <td align="left" style="width: 119px; " valign="top">
            </td>
            <td align="left" style="width: 100px;">
                    </td>
        </tr>
        <tr><td colspan="19"><hr /></td></tr>        
            <tr>
                <td align="left" style="width: 14px; " valign="top">
                    <asp:RadioButton ID="rdoDateTime" runat="server" GroupName="SelectDateCriteria" /></td>
                <td align="left" style="width: 99px; " valign="top">
                    Date<span style="color: red">*</span></td>
                <td align="left" style="" valign="top">
                    :</td>
                <td align="left" style="width: 11px; " valign="top">
                    <asp:TextBox ID="txtDate" runat="server" MaxLength="10" SkinID="txtSkin" Width="100px"></asp:TextBox></td>
                <td align="left" style="width: 100px; " valign="top"> 
                    <img id="Img1" alt="Calendar"  src="../../Images/SmallCalendar.gif" onclick="popUpCalendar(this, document.all.<%=txtDate.ClientID%>, 'dd/mm/yyyy', 0, 0);" />
                    [dd/mm/yyyy]</td>
                <td align="left" style="width: 44px; " valign="top">
                    Time <span style="color: #ff0000">*</span></td>
                <td align="left" style="" valign="top">
                    :</td>
                <td align="left" style="width: 109px; " valign="top">
                    <asp:TextBox ID="txtTime" runat="server" MaxLength="5" SkinID="txtSkin" Width="44px"></asp:TextBox></td>
                <td align="left" style="width: 119px; " valign="top">
                    <asp:DropDownList ID="ddlTimeType" runat="server" SkinID="ddlSkin">
                        <asp:ListItem Text="AM" Value="AM"></asp:ListItem>
                        <asp:ListItem Text="PM" Value="PM"></asp:ListItem>
                    </asp:DropDownList></td>
                <td align="left" style="width: 119px; " valign="top">
                    <asp:Button ID="btnsearch" runat="server" Text="Search" Width="85px" OnClick="btnsearch_Click" SkinID="btnSearchSkin" ValidationGroup="Search_Validation" /></td>
            </tr>
            <tr><td>&nbsp;</td></tr>
        <tr>
            <td align="left" style="width: 14px; height: 24px;" valign="top">
            </td>
            <td align="left" style="width: 99px; height: 24px;" valign="top">
                Verification Type<span style="color: #ff0000">*</span></td>
            <td align="left" valign="top" style="height: 24px">
                :</td>
            <td align="left" colspan="2" valign="top" style="height: 24px">
                    <asp:DropDownList ID="ddlverify" runat="server" OnDataBound="ddlverify_DataBound" Width="170px" ValidationGroup="dateValidation" SkinID="ddlSkin">
                    </asp:DropDownList></td>
            <td align="left" colspan="3" valign="top" style="height: 24px">
                    <asp:Button ID="Button1" runat="server" Text="Generate Label" Width="120px" OnClick="Button1_Click" SkinID="btnGenrateLabel" ValidationGroup="dateValidation" /></td>
            <td align="left" style="width: 119px; height: 24px;" valign="top">
            </td>
            <td align="left" style="width: 119px; height: 24px;" valign="top">
            </td>
            <td align="left" style="width: 100px; height: 24px;" valign="top">
            </td>
        </tr>
            <tr>
                <td align="left" style="width: 14px" valign="top">
                </td>
                <td align="left" colspan="10" valign="top">
                    <span style="color: #ff0033">* </span>Indicate mandatory fields.</td>
            </tr>
        <tr>
            <td align="left" style="width: 14px" valign="top">
            </td>
            <td align="left" colspan="10" valign="top">
            <asp:Label ID="lblMsg" runat="server" Width="237px" Font-Bold="True" ForeColor="Red"></asp:Label></td>
        </tr>
        <tr>
            <td align="center" colspan="1" style="width: 14px">
            </td>
            <td align="center" colspan="10">
                    <asp:GridView ID="GV" runat="server" Width="100%" SkinID="gridviewSkin" AllowSorting="false" OnSorting="GV_Sorting">
                    </asp:GridView>
                &nbsp;
            </td>
        </tr>
    </table>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator_FromDate" runat="server"
            ErrorMessage="Please enter valid date format for From date." ControlToValidate="txtfrom" SetFocusOnError="true"  Display="None" ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d" ValidationGroup="dateValidation"></asp:RegularExpressionValidator>
        <asp:RegularExpressionValidator ID="RegularExpressionValidatorToDate" runat="server"
            SetFocusOnError="true" ControlToValidate="txtto" Display="None" ErrorMessage="Please enter valid Date format for To date."
            ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d"
            ValidationGroup="dateValidation"></asp:RegularExpressionValidator>
        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidatorFrom_Date" runat="server" ControlToValidate="txtfrom"
            SetFocusOnError="true" ErrorMessage="Please enter From date." ValidationGroup="dateValidation" Display="None"></asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="RequiredFieldValidatorTo_date" runat="server" ControlToValidate="txtfrom"
            SetFocusOnError="true" ErrorMessage="Please enter To date."  ValidationGroup="dateValidation" Display="None"></asp:RequiredFieldValidator>
        --%><asp:ValidationSummary ID="ValidationSummaryDateValidation" runat="server" ShowMessageBox="True"
            ShowSummary="False" ValidationGroup="dateValidation" />
        &nbsp;<asp:CompareValidator ID="CompareValidator_ddl" runat="server" ControlToValidate="ddlverify"
            Display="None" ErrorMessage="Please Select Verification Type." Operator="GreaterThan"
            ValidationGroup="dateValidation" ValueToCompare="0"></asp:CompareValidator>
        &nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtfrom"
            SetFocusOnError="true" Display="None" ErrorMessage="Please Select From Date." ValidationGroup="Search_Validation"></asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtto"
            SetFocusOnError="true" Display="None" ErrorMessage="Please Select To Date." ValidationGroup="Search_Validation"></asp:RequiredFieldValidator>
        --%><asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
            ShowSummary="False" ValidationGroup="Search_Validation" />
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtfrom"
            SetFocusOnError="true" Display="None" ErrorMessage="Please Enter Valid From Date." ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d"
            ValidationGroup="Search_Validation"></asp:RegularExpressionValidator>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtto"
            SetFocusOnError="true" Display="None" ErrorMessage="Please enter Valid To Date." ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d"
            ValidationGroup="Search_Validation"></asp:RegularExpressionValidator><asp:RegularExpressionValidator
                ID="revDate" runat="server" ControlToValidate="txtDate" Display="None" ErrorMessage="Please enter valid date format for Date"
                SetFocusOnError="True" ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d"
                ValidationGroup="Search_Validation"></asp:RegularExpressionValidator><asp:RegularExpressionValidator
                    ID="revTime" runat="server" ControlToValidate="txtTime" Display="None" ErrorMessage="Please enter valid time format."
                    SetFocusOnError="True" ValidationExpression="(0[1-9]|1[0-2])[:]([0-5][0-9])"
                    ValidationGroup="Search_Validation"></asp:RegularExpressionValidator>
        
        <asp:CustomValidator ID="cvDateTime1" runat="server" Display="None" ErrorMessage="Please select both date and time."
            ValidationGroup="dateValidation" ClientValidationFunction="ValidateDateTime"></asp:CustomValidator>
        
        <asp:CustomValidator ID="cvFromToDateTime1" runat="server" Display="None" ErrorMessage="Please select both From date and To Date."
            ValidationGroup="dateValidation" ClientValidationFunction="ValidateFromToDateTime"></asp:CustomValidator>
               
        <asp:CustomValidator ID="cvDateTime" runat="server" Display="None" ErrorMessage="Please select both date and time."
            ValidationGroup="Search_Validation" ClientValidationFunction="ValidateDateTime"></asp:CustomValidator>
        
        <asp:CustomValidator ID="cvFromToDateTime" runat="server" Display="None" ErrorMessage="Please select both From date and To Date."
            ValidationGroup="Search_Validation" ClientValidationFunction="ValidateFromToDateTime"></asp:CustomValidator>
        
                    
                    
                    </fieldset>
                    
    </td></tr>
</table>                
</asp:Content>

