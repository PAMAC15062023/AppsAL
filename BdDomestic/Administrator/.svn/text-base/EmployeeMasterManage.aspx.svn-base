<%@ Page Language="C#" MasterPageFile="~/Administrator/Admin_MasterPage.master" AutoEventWireup="true" CodeFile="EmployeeMasterManage.aspx.cs" Inherits="EmployeeMasterManage" Theme="SkinFile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script language="javascript" type="text/javascript">

function validation(source, arguments)
{
 
 var chkLeftOrganisation = document.getElementById("<%=chkLeftOrganisation.ClientID%>");
 var txtDOL = document.getElementById("<%=txtDOL.ClientID%>").value;
 if(chkLeftOrganisation.checked == true)
    {   
      if(txtDOL == "")
      {             
       arguments.IsValid=false;
       return; 
      }
      else
      {
      arguments.IsValid=true;
       return;
      }
   }      
}
</script>
<table id="tblMain" width="99%">
<tr><td style="padding-left:8px">
     <fieldset><legend class="FormHeading">Employee Entry</legend>
    <table width="100%" border="0" cellpadding="0" cellspacing="0">
        <tr><td><asp:Label ID="lblMsg" runat="server" Text=""></asp:Label></td></tr>
        <tr>
            <td> 
                <table width="100%" border="0" cellpadding="2" cellspacing="1">                    
                    <tr>
                        <td>[<asp:Label ID="lblMode" runat="server"></asp:Label>]</td>
                    </tr>                   
                    <tr>
                        <td colspan="2">
                            Emp Code<span class="txtRed"> * </span></td>
                        <td>:</td>
                        <td><asp:TextBox ID="txtEmpCode" runat="server" MaxLength="15" SkinID="txtSkin"></asp:TextBox></td>
                        <td  colspan="2">
                            First Name<span class="txtRed"> * </span></td>
                        <td>:</td>
                        <td><asp:TextBox ID="txtFName" runat="server" MaxLength="100" SkinID="txtSkin"></asp:TextBox></td>
                        <td>Middle Name</td>
                        <td>:</td>
                        <td><asp:TextBox ID="txtMName" runat="server" MaxLength="100" SkinID="txtSkin"></asp:TextBox></td>
                        <td >Last Name</td>
                        <td>:</td>
                        <td><asp:TextBox ID="txtLName" runat="server" MaxLength="100" SkinID="txtSkin"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td  colspan="2">
                            Date of Birth<span class="txtRed"> * </span></td>
                        <td>:</td>
                        <td><asp:TextBox ID="txtDoB" runat="server" MaxLength="11" SkinID="txtSkin"></asp:TextBox>
                            <img src="../Images/SmallCalendar.gif" alt="" onclick="popUpCalendar(this, document.all.<%=txtDoB.ClientID%>, 'dd/mm/yyyy', 0, 0);" /></td>
                        <td  colspan="2">
                            Gender<span class="txtRed"> * </span></td>
                        <td>:</td>
                        <td valign="top">
                            <asp:RadioButtonList ID="rblGender" runat="server" SkinID="rdblSkin" RepeatDirection="Horizontal" CellPadding="0" CellSpacing="0">
                                <asp:ListItem Selected="True" Value="M">Male</asp:ListItem>
                                <asp:ListItem Value="F">Female</asp:ListItem>
                            </asp:RadioButtonList></td>
                             <td >Date of Joining</td>
                        <td>:</td>
                        <td colspan="4"><asp:TextBox ID="txtDoJ" runat="server" MaxLength="11" SkinID="txtSkin"></asp:TextBox>
                            <img src="../Images/SmallCalendar.gif" alt="" onclick="popUpCalendar(this, document.all.<%=txtDoJ.ClientID%>, 'dd/mm/yyyy', 0, 0);" /></td>                    
                    </tr>
                    <tr>
                        <td  colspan="2">
                            Address1</td>
                        <td>:</td>
                        <td colspan="11"><asp:TextBox ID="txtAdd1" runat="server" Width="550px" MaxLength="200" SkinID="txtSkin"></asp:TextBox></td>                        
                    </tr>
                    <tr>
                        <td  colspan="2">
                            Address2</td>
                        <td>:</td>
                        <td colspan="11"><asp:TextBox ID="txtAdd2" runat="server" Width="550px" MaxLength="200" SkinID="txtSkin"></asp:TextBox></td>                        
                    </tr>
                    <tr>
                        <td  colspan="2">
                            Address3</td>
                        <td>:</td>
                        <td colspan="11"><asp:TextBox ID="txtAdd3" runat="server" Width="550px" MaxLength="200" SkinID="txtSkin"></asp:TextBox></td>                        
                    </tr>
                    <tr>
                        <td  colspan="2">
                            City</td>
                        <td>:</td>
                        <td><asp:TextBox ID="txtCity" runat="server" MaxLength="100" SkinID="txtSkin"></asp:TextBox></td>
                        <td  colspan="2">
                            Pin</td>
                        <td>:</td>
                        <td colspan="7">
                            <asp:TextBox ID="txtPin" runat="server" MaxLength="6" SkinID="txtSkin"></asp:TextBox></td>
                    </tr>
                     <tr>
                         <td  colspan="2">
                             Mobile</td>
                        <td>:</td>
                        <td><asp:TextBox ID="txtMobile" runat="server" MaxLength="30" SkinID="txtSkin"></asp:TextBox></td>
                         <td  colspan="2">
                             Phone</td>
                        <td>:</td>
                         <td colspan="7">
                             <asp:TextBox ID="txtPhone" runat="server" MaxLength="30" SkinID="txtSkin"></asp:TextBox></td>
                    </tr>
                     <tr>
                         <td  colspan="2">
                             Emp Type<span class="txtRed"> * </span></td>
                        <td>:</td>
                        <td>
                            <asp:DropDownList ID="ddlEmpType" runat="server" SkinID="ddlSkin">
                            <asp:ListItem Selected="True" Value="">--Select--</asp:ListItem>
                            <asp:ListItem Value="S">Salaried</asp:ListItem>
                            <asp:ListItem Value="P">Professional</asp:ListItem>
                            </asp:DropDownList></td>
                         <td  colspan="2">
                             Designation<span class="txtRed"> * </span></td>
                        <td>:</td>
                         <td colspan="7">
                             <asp:DropDownList ID="ddlDsgn" runat="server" SkinID="ddlSkin" DataSourceID="sdsDesignation" DataTextField="DESIGNATION" DataValueField="DESIGNATION_ID" OnDataBound="ddlDsgn_DataBound">
                            </asp:DropDownList></td>
                    </tr>
                     <tr>
                         <td  colspan="2">
                             Department<span class="txtRed"> * </span></td>
                        <td>:</td>
                        <td><asp:DropDownList ID="ddlDept" runat="server" SkinID="ddlSkin" DataSourceID="sdsDepartment" DataTextField="DEPARTMENT" DataValueField="DEPT_ID" OnDataBound="ddlDept_DataBound">
                            </asp:DropDownList></td>
                         <td  colspan="2">
                             Login Name<span class="txtRed"> * </span></td>
                        <td>:</td>
                        <td><asp:TextBox ID="txtLogin" runat="server" MaxLength="20" SkinID="txtSkin"></asp:TextBox></td>
                         <td colspan="6">
                            <asp:Button ID="btnCheck" runat="server" SkinID="btnCheckAvailabilitySkin" Text="Check Availability" OnClick="btnCheck_Click" ValidationGroup="grpchkLogin" />&nbsp;
                             <asp:Label ID="lblLoginMsg" runat="server" Text=""></asp:Label>
                             <asp:RequiredFieldValidator ID="RFVchkLogin" runat="server" ControlToValidate="txtLogin" ErrorMessage="Enter Login Name to check availibality" SetFocusOnError="True" ValidationGroup="grpchkLogin" Display="None"></asp:RequiredFieldValidator></td>
                    </tr>
                      <tr>
                        <td colspan="2">
                            SubCentre</td>
                        <td style="width: 8px">
                            :</td>
                        <td style="width: 186px">
                            <asp:DropDownList ID="ddlSubCentre" runat="server" DataSourceID="sdsSunCentre" SkinID="ddlSkin" DataTextField="SubCentreName" DataValueField="SubCentreId" OnDataBound="ddlSubCentre_DataBound">
                            </asp:DropDownList></td>
                        <td colspan="2">
                            Unit</td>
                        <td style="width: 8px">
                            :</td>
                        <td>
                            <asp:TextBox ID="txtUnit" runat="server" SkinID="txtSkin"></asp:TextBox></td>
                        <td colspan="6">
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            Suvidha A/C</td>
                        <td style="width: 8px">
                        </td>
                        <td style="width: 186px">
                            <asp:TextBox ID="txtSuvidhaAC" runat="server" SkinID="txtSkin"></asp:TextBox></td>
                        <td colspan="2">
                        </td>
                        <td style="width: 8px">
                        </td>
                        <td>
                        </td>
                        <td colspan="6">
                        </td>
                    </tr>
                    <tr>
                        <td colspan="14">
                            <strong>
                            Resignation Detail:</strong></td>
                    </tr>
                    <tr>
                        <td colspan="2">
                        </td>
                        <td style="width: 8px">
                        </td>
                        <td colspan="3">
                            <asp:CheckBox ID="chkResignation" runat="server" Text="Resignation" />
                            &nbsp; &nbsp;
                            <asp:CheckBox ID="chkLeftOrganisation" runat="server" Text="Left Organisation" />&nbsp;
                        </td>
                        <td style="width: 8px">
                        </td>
                        <td>
                        </td>
                        <td colspan="6">
                        </td>
                    </tr>
                    <tr>
                         <td style="height: 28px" >DOL</td>
                        <td style="height: 28px">:</td>
                        <td colspan="12" style="height: 28px"><asp:TextBox ID="txtDOL" runat="server" MaxLength="11" SkinID="txtSkin"></asp:TextBox>
                            <img src="../Images/SmallCalendar.gif" alt="" onclick="popUpCalendar(this, document.all.<%=txtDOL.ClientID%>, 'dd/mm/yyyy', 0, 0);" /></td>         
                       
                    </tr>   
                    <tr>
                        <td align="center" colspan="14" style="text-align: left">
                            <asp:Label ID="lblChangePassword" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label></td>
                    </tr>
                    <tr>
                        <td align="center" colspan="14">
                            &nbsp;<asp:Button ID="btnConfirm" runat="server" SkinID="btnSaveSkin" ValidationGroup="grpEmpManage" OnClick="btnConfirm_Click" />
                            <asp:Button ID="btnCancel" runat="server"  SkinID="btnCancelSkin" OnClick="btnCancel_Click" /></td>
                    </tr>
                    <tr>
                        <td colspan="14" align="left">
                               &nbsp;<span class="txtRed"> * </span><span >&nbsp;<b>Indicate mandatory fields.</b></span>
                               <br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>All date format should be in [dd-mmm-yyyy]</b>
                         </td>
                    </tr>                       
                </table>                         
            </td>                             
        </tr>
        <tr>
          
    <td align="left" colspan="13" style="height: 20px">
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="txtError"
            DisplayMode="List" ValidationGroup="grpEmpManage" ShowMessageBox="True" ShowSummary="False" />
        <asp:RequiredFieldValidator ID="RFVEmpCode" runat="server" ControlToValidate="txtEmpCode"
            CssClass="txtError" Display="None" ErrorMessage="Emp Code should not be blank" SetFocusOnError="True"
            ValidationGroup="grpEmpManage"></asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="RFVFName" runat="server" ControlToValidate="txtFName"
            CssClass="txtError" Display="None" ErrorMessage="First Name should not be blank" SetFocusOnError="True"
            ValidationGroup="grpEmpManage"></asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="RFVDoB" runat="server" ControlToValidate="txtDoB"
            CssClass="txtError" Display="None" ErrorMessage="Date of Birth should not be blank" SetFocusOnError="True"
            ValidationGroup="grpEmpManage"></asp:RequiredFieldValidator>                            
        <asp:RegularExpressionValidator ID="REVDoB" runat="server" ControlToValidate="txtDoB"
            Display="None" ErrorMessage="Enter valid date format for Date of Birth"
            SetFocusOnError="True" ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d"
            ValidationGroup="grpEmpManage" CssClass="txtError"></asp:RegularExpressionValidator>&nbsp;
        <asp:RegularExpressionValidator ID="REVDoJ" runat="server" ControlToValidate="txtDoJ"
            CssClass="txtError" Display="None" ErrorMessage="Enter valid date format for Date of Joining"
            SetFocusOnError="True" ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d"
            ValidationGroup="grpEmpManage"></asp:RegularExpressionValidator>
               <asp:RegularExpressionValidator ID="REVDoL" runat="server" ControlToValidate="txtDOL"
            CssClass="txtError" Display="None" ErrorMessage="Enter valid date format for Date of Leaving"
            SetFocusOnError="True" ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d"
            ValidationGroup="grpEmpManage"></asp:RegularExpressionValidator>
        <asp:RequiredFieldValidator ID="RFVLoginName" runat="server" ControlToValidate="txtLogin"
            CssClass="txtError" Display="None" ErrorMessage="Login Name should not be blank" SetFocusOnError="True"
            ValidationGroup="grpEmpManage"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="REVPin" runat="server" ControlToValidate="txtPin"
            CssClass="txtError" Display="None" ErrorMessage="Only numbers are allowed in Pin"
            SetFocusOnError="True" ValidationExpression="\d{6}" ValidationGroup="grpEmpManage"></asp:RegularExpressionValidator>
        &nbsp;<asp:RequiredFieldValidator ID="RFVEmpType" runat="server" ControlToValidate="ddlEmpType"
            CssClass="txtError" Display="None" ErrorMessage="Select the Emp Type" SetFocusOnError="True"
            ValidationGroup="grpEmpManage"></asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="RFVDesg" runat="server" ControlToValidate="ddlDsgn"
            CssClass="txtError" Display="None" ErrorMessage="Select the Designation" SetFocusOnError="True"
            ValidationGroup="grpEmpManage"></asp:RequiredFieldValidator>
            <asp:CompareValidator ID="CompareValidator_SubCentre" CssClass="txtError" SetFocusOnError="true" runat="server" ControlToValidate="ddlSubCentre"
         Display="None"  ErrorMessage="Select the Sub Centre !!" Operator="GreaterThan"
         ValidationGroup="grpEmpManage" ValueToCompare="0"></asp:CompareValidator>
         <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlSubCentre"
            CssClass="txtError" Display="None" ErrorMessage="Select the Sub Centre" SetFocusOnError="True"
            ValidationGroup="grpEmpManage"></asp:RequiredFieldValidator>--%>
        &nbsp;<asp:RequiredFieldValidator ID="RFVDept" runat="server" ControlToValidate="ddlDept"
            CssClass="txtError" Display="None" ErrorMessage="Select the Department" SetFocusOnError="True"
            ValidationGroup="grpEmpManage"></asp:RequiredFieldValidator>
        &nbsp;
        <asp:ValidationSummary ID="ValidationSummary2" runat="server" CssClass="txtError"
            DisplayMode="List" ShowMessageBox="True" ShowSummary="False" ValidationGroup="grpchkLogin" />
        <asp:HiddenField ID="hdnEmpID" runat="server" Value="" />
        <asp:CustomValidator ID="cvDOL" runat="server"  ValidationGroup="grpEmpManage" Display="none" ClientValidationFunction="validation" ErrorMessage="Please Enter DOL" ></asp:CustomValidator>
       </td></tr> 
    </table>    </fieldset>  
    </td></tr>
</table>
<asp:SqlDataSource ID="sdsSunCentre" runat="server" ConnectionString="<%$ ConnectionStrings:CMConnectionString %>"
            ProviderName="<%$ ConnectionStrings:CMConnectionString.ProviderName %>" SelectCommand="select SubCentreName,SubCentreId from SubCentreMaster where CentreId=?">
            <SelectParameters>
                <asp:SessionParameter Name="?" SessionField="CentreID" />
            </SelectParameters>
        </asp:SqlDataSource>
    <asp:SqlDataSource ID="sdsDepartment" runat="server" ConnectionString="<%$ ConnectionStrings:CMConnectionString %>" ProviderName="<%$ ConnectionStrings:CMConnectionString.ProviderName %>" SelectCommand="SELECT * FROM [DEPARTMENT_MASTER]"></asp:SqlDataSource>
    <asp:SqlDataSource ID="sdsDesignation" runat="server" ConnectionString="<%$ ConnectionStrings:CMConnectionString %>" ProviderName="<%$ ConnectionStrings:CMConnectionString.ProviderName %>" SelectCommand="SELECT [DESIGNATION_ID], [DESIG_CODE], [DESIGNATION] FROM [DESIGNATION_MASTER]"></asp:SqlDataSource>
</asp:Content>

