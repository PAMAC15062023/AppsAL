<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/CPV/RL/RL_MasterPage.master" Theme="SkinFile" CodeFile="RL_CaseEntry.aspx.cs" Inherits="CPV_RL_RL_CaseEntry" %>

<asp:Content ID="Content1" ContentPlaceHolderID="C1" Runat="Server">
<script language="javascript" type="text/jscript">
function ValidateTextLength(DisplayName, ControlName, xLength)
{
    if (ControlName.value.length > parseInt(xLength))
    {
         alert(DisplayName + " Should Not be Greater Then " + xLength + " Characters.");
         ControlName.focus();   
    }      
}
 function funCheckOneVerificationType(source, arguments)
{
   
      var chkList1 = document.getElementById("<%=chkCaseVerification.ClientID%>");
      var arrayOfCheckBoxes= chkList1.getElementsByTagName("input");
      
      var nCount="N";
      for(var i=0;i<arrayOfCheckBoxes.length;i++)
      {
        if(document.getElementById(arrayOfCheckBoxes[i].id).checked)
        {
        nCount="Y";
        break;
        }
       
      }
      if(nCount!="Y")
      {
      arguments.IsValid=false;
      }
      else
      {
      arguments.IsValid=true;
      }
}

/* function IntegerOnly()
{
   var KeyID = event.keyCode;
   if(KeyID>=48 && KeyID<=57)
   {
    return true;
   }
   
   else
   {
   
	alert('pls enter numeric value');
    	return false;
   }
}*/

</script>
  <fieldset ><legend class="FormHeading">Retail Loan Case Entry</legend>
<table border="0" cellpadding="1" cellspacing="0" width="100%" id="TABLE1">
    <tr>
        <td colspan="9" ><asp:Label ID="lblMsg" runat="server" SkinID="lblErrorMsg" Visible="false"></asp:Label>
        </td>
        
    </tr>
    <tr>
        <td>
            Case Type</td>
        <td style="width: 6px" >
        :</td>
        <td>
        <asp:DropDownList SkinID="ddlSkin" ID="ddCaseType" runat="server">
        <asp:ListItem>Fresh cases</asp:ListItem>
        <asp:ListItem>Redu cases</asp:ListItem>
        <asp:ListItem>RCC cases</asp:ListItem>
        </asp:DropDownList></td>
        <td>
        </td>
        <td style="width: 7px">
        </td>
        <td>
        </td>
        <td>
        </td>
        <td style="width: 7px">
        </td>
        <td>
        </td>
    </tr>
<tr>
    <td>REF No</td>
    <td style="width: 6px" >:</td>
    <td><asp:TextBox id="txtRefNo" runat="server" SkinID="txtSkin" MaxLength="50" Columns="30"></asp:TextBox></td>
    <td>Recv Date<asp:Label ID="Label2" runat="server" ForeColor="Red" Text="*"></asp:Label></td>
    <td style="width: 7px">:</td>
    <td><asp:TextBox id="txtRecDate" runat="server" SkinID="txtSkin" MaxLength="10" Columns="8"></asp:TextBox>
    <IMG id="imgRecDate" 
onclick="popUpCalendar(this, document.all.<%=txtRecDate.ClientID%>, 'dd/mm/yyyy', 0, 0);" 
alt="Calendar" src="../../Images/SmallCalendar.gif" /></td>
    <td>Recv Time<asp:Label ID="Label3" runat="server" ForeColor="Red" Text="*"></asp:Label></td>
    <td style="width: 7px">:</td>
    <td><asp:TextBox id="txtRecTime" runat="server" SkinID="txtSkin" MaxLength="5" Columns="8"></asp:TextBox>
    <asp:DropDownList id="ddlTimeType" runat="server" SkinID="ddlSkin">
        <asp:ListItem>AM</asp:ListItem>
        <asp:ListItem>PM</asp:ListItem>
    </asp:DropDownList>
    </td>
</tr>
    <tr>
        <td>
            Title</td>
        <td style="width: 6px" >
            :</td>
        <td>
            <asp:TextBox ID="txtTitle" runat="server" MaxLength="20" SkinID="txtSkin" Columns="10"></asp:TextBox>
        </td>
        <td >
            First Name</td>
        <td style="width: 7px">
            :</td>
        <td >
            <asp:TextBox ID="txtFirstNm" runat="server" MaxLength="100" SkinID="txtSkin" Columns="30"></asp:TextBox></td>
        <td>
            Middle Name</td>
        <td style="width: 7px">
           :</td>
        <td>
            <asp:TextBox ID="txtMiddleNm" runat="server" MaxLength="100" SkinID="txtSkin" Columns="30"></asp:TextBox></td>
    </tr>
    <tr>
    <td> Last Name</td>
    <td style="width: 6px">:</td>
    <td><asp:TextBox ID="txtLastNm" runat="server" MaxLength="350" SkinID="txtSkin" Columns="30"></asp:TextBox>
            </td>
    <td>DOB</td>
    <td style="width: 7px">:</td>
    <td> <asp:TextBox ID="txtDOB" runat="server" MaxLength="50" SkinID="txtSkin" Columns="12"></asp:TextBox>
            <img alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtDOB.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                src="../../Images/SmallCalendar.gif" /></td>
    <td>
        Channel Name</td>
    <td style="width: 7px">
        :</td>
    <td>
        <asp:TextBox ID="txtChannelName" runat="server" SkinID="txtSkin" MaxLength="100"></asp:TextBox></td>
    </tr>
    <tr>
        <td>
            Product Type</td>
        <td style="width: 6px">
            :</td>
        <td>
            <asp:TextBox ID="txtProductTyoe" runat="server" SkinID="txtSkin" MaxLength="100"></asp:TextBox></td>
        <td>
            Product Name</td>
        <td style="width: 7px">
        </td>
        <td>
            <asp:TextBox ID="txtProductName" runat="server" SkinID="txtSkin" MaxLength="100"></asp:TextBox></td>
        <td>
            Product price</td>
        <td style="width: 7px">
            :</td>
        <td>
            <asp:TextBox ID="txtProducPrice" runat="server" SkinID="txtSkin" MaxLength="100"></asp:TextBox></td>
    </tr>
    <tr>
        <td>
            Verification Type<asp:Label ID="Label1" runat="server" ForeColor="Red" Text="*"></asp:Label></td>
        <td style="width: 6px">
            :</td>
        <td colspan="7">
            <asp:CheckBoxList ID="chkCaseVerification" SkinID="chkListSkin" runat="server" RepeatDirection="Horizontal" ></asp:CheckBoxList></td>
    </tr>
    <tr>
        <td style="height: 16px">
            <asp:Label ID="Label4" runat="server" ForeColor="Red" Text="*Mandatory Field"></asp:Label></td>
        <td style="width: 6px"   >
        </td>
        <td >
        </td>
        <td  >
        </td>
        <td style="width: 7px"  >
        </td>
        <td  >
        </td>
        <td >
        </td>
        <td style="width: 7px" >
        </td>
        <td >
        </td>
    </tr>
    <tr>
        <td colspan="9" class="txtBold" style="background-color:#D0D5D8; height: 16px;">
            Residence Detail</td>
    </tr>
    <tr>
        <td>
            Address1</td>
        <td style="width: 6px">
            :</td>
        <td colspan="7" >
            <asp:TextBox ID="txtResAdd1" runat="server" MaxLength="100" SkinID="txtSkin" Columns="100"></asp:TextBox></td>
    </tr>
    <tr>
        <td style="height: 25px" >
            Address2</td>
        <td style="width: 6px; height: 25px;">
            :</td>
        <td colspan="7" style="height: 25px">
        <asp:TextBox SkinID="txtSkin" ID="txtResAdd2" runat="server" Columns="100" MaxLength="50"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            Address3</td>
        <td style="width: 6px">
            :</td>
        <td colspan="7">
        <asp:TextBox SkinID="txtSkin" ID="txtResAdd3" runat="server" Columns="100" MaxLength="50"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            City</td>
        <td style="width: 6px" >
            :</td>
        <td>
            <asp:TextBox ID="txtResCity" runat="server" MaxLength="100" SkinID="txtSkin"></asp:TextBox></td>
        <td  >
            </td>
        <td style="width: 7px" >
            </td>
        <td>
            </td>
        <td>
        Pin</td>
        <td style="width: 7px">
        :</td>
        <td>
        <asp:TextBox ID="txtResPin" runat="server"  MaxLength="10" SkinID="txtSkin"></asp:TextBox></td>
    </tr>
    <tr>        <td>
            Res Land Mark</td>
        <td style="width: 6px" >
            :</td>
        <td>
            <asp:TextBox ID="txtLandMark" runat="server" MaxLength="100" SkinID="txtSkin"></asp:TextBox>
            </td>
        <td >
            Res. Phone</td>
        <td style="width: 7px" >
            :</td>
        <td>
            <asp:TextBox ID="txtResPhone" runat="server"  MaxLength="100"  SkinID="txtSkin"></asp:TextBox></td>
        <td>
            Mobile</td>
        <td style="width: 7px">
            :</td>
        <td>
        <asp:TextBox ID="txtResMob" SkinID="txtSkin" MaxLength="100"  runat="server"></asp:TextBox></td>
    </tr>
    <tr>
        <td>
        </td>
        <td style="width: 6px" >
        </td>
        <td>
        </td>
        <td>
        </td>
        <td style="width: 7px">
        </td>
        <td>
        </td>
        <td>
        </td>
        <td style="width: 7px">
        </td>
        <td>
        </td>
    </tr>
    <tr>
        <td colspan="9" class="txtBold" style="background-color:#D0D5D8; height: 16px;">
            Office Detail</td>
    </tr>
    <tr>
    <td>Office Name</td>
    <td style="width: 6px">:</td>
    <td colspan="7"><asp:TextBox ID="txtOffName" SkinID="txtSkin" runat="server" MaxLength="100"></asp:TextBox></td>
    </tr>
    <tr>
        <td>
            Address1</td>
        <td style="width: 6px">
            :</td>
        <td colspan="7" >
            <asp:TextBox ID="txtOffAdd1" runat="server"  MaxLength="100" Columns="100"  SkinID="txtSkin"></asp:TextBox></td>
    </tr>
    <tr>
        <td>
            Address2</td>
        <td style="width: 6px">
            :</td>
        <td colspan="7">
            <asp:TextBox ID="txtOffAdd2" runat="server" Columns="100" MaxLength="100" SkinID="txtSkin"></asp:TextBox></td>
    </tr>
    <tr>
        <td style="height: 26px" >
            Address3</td>
        <td style="width: 6px; height: 26px;">
            :</td>
        <td  colspan="7" style="height: 26px">
            <asp:TextBox ID="txtOffAdd3" runat="server" Columns="100" MaxLength="100" SkinID="txtSkin"></asp:TextBox></td>
          
            
    </tr>
    <tr>
        <td >
            City</td>
        <td style="width: 6px" >
            :</td>
        <td >
            <asp:TextBox ID="txtOffCity" runat="server" MaxLength="100" SkinID="txtSkin"></asp:TextBox></td>
        <td>
            </td>
        <td style="width: 7px">
            </td>
        <td >
           </td>
        <td>
        Pin</td>
        <td style="width: 7px" >
        :</td>
        <td>
        <asp:TextBox ID="txtOffPin" runat="server"  MaxLength="50" SkinID="txtSkin"></asp:TextBox></td>
    </tr>
    <tr>
        <td  >
            Off. Phone</td>
        <td style="width: 6px"  >
            :</td>
        <td  >
            <asp:TextBox ID="txtOffPhone" runat="server"  MaxLength="50" SkinID="txtSkin"></asp:TextBox></td>
        <td  >
            Off. Extn</td>
        <td style="width: 7px"  >
            :</td>
        <td >
            <asp:TextBox ID="txtOffExtn" runat="server"  MaxLength="10" SkinID="txtSkin"></asp:TextBox></td>
        <td  >
            Occupation</td>
        <td style="width: 7px"  >
            :</td>
        <td><asp:TextBox ID="txtOccupation" SkinID="txtSkin" runat="server" MaxLength="100"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="height: 43px">
            Designation</td>
        <td style="width: 6px; height: 43px;">
            :</td>
        <td style="height: 43px">
            <asp:TextBox ID="txtDesgn" runat="server" MaxLength="100" SkinID="txtSkin"></asp:TextBox></td>
        <td style="height: 43px">
            Department
        </td>
        <td style="width: 7px; height: 43px;">
            :</td>
        <td style="height: 43px">
            <asp:TextBox ID="txtDept" runat="server" MaxLength="100" SkinID="txtSkin"></asp:TextBox></td>
        <td style="height: 43px">
            Priority</td>
        <td style="width: 7px; height: 43px;" >
            :</td>
        <td style="height: 43px"><asp:TextBox ID="txtOffPriority" runat="server" MaxLength="10" SkinID="txtSkin"></asp:TextBox>
        </td>
    </tr>
    
    
    <tr>
        <td >
           Region</td>
        <td style="width: 6px" >
            :</td>
        <td >
        <asp:TextBox ID="txtregion" runat="server" MaxLength="50" SkinID="txtSkin"></asp:TextBox></td>
        <td >
            Employee Type</td>
        <td style="width: 7px" >
            :</td>
        <td >
            <asp:DropDownList ID="ddlEmpType" runat="server" SkinID="ddlSkin">
            
            <asp:ListItem>Salaried</asp:ListItem>
            <asp:ListItem>Self Emplyed</asp:ListItem>
            
            </asp:DropDownList></td>
        <td >
        </td>
        <td style="width: 7px" >
        </td>
        <td  >
        </td>
    </tr>
    <tr>
    <td>SPL Instruction</td>
    <td style="width: 6px">:</td>
    <td colspan="7"><asp:TextBox ID="txtSplInst" runat="server" Columns="50" MaxLength="255" SkinID="txtSkin" onkeyPress="ValidateTextLength('Remark', this, 255);" TextMode="MultiLine" ></asp:TextBox></td>
    </tr>
    <tr>
        <td  colspan="9" class="txtBold" style="background-color:#D0D5D8; height: 16px;" >
            References</td>
         </tr>
    <tr>
    <td>
        Reference1</td>
    <td style="width: 6px">:</td>
    <td><asp:TextBox  SkinID="txtSkin" ID="txtRef1" runat="server" MaxLength="50"></asp:TextBox></td>
    <td>
        Telephone1</td>
    <td style="width: 7px">
        :</td>
    <td><asp:TextBox  SkinID="txtSkin" ID="txtTel1"  runat="server" MaxLength="50"></asp:TextBox></td>
    <td> </td>
    <td style="width: 7px"></td>
    <td></td>
    </tr>
    <tr>
    <td >
        Reference2</td>
    <td style="width: 6px" >
        :</td>
    <td ><asp:TextBox  SkinID="txtSkin" ID="txtRef2" runat="server" MaxLength="50"></asp:TextBox></td>
    <td >
        Telephonie2</td>
    <td style="width: 7px">
        :</td>
    <td ><asp:TextBox SkinID="txtSkin" ID="txtTel2"  runat="server" MaxLength="50"></asp:TextBox></td>
    <td></td>
    <td style="width: 7px"></td>
    <td></td>
    </tr>
    <tr>
    
    <td ></td>
    <td style="width: 6px"></td>
    <td></td>
    <td></td>
    <td style="width: 7px"></td>
    <td></td>
    <td></td>
    <td style="width: 7px"></td>
    <td></td>
    </tr>
    <tr>
        <td colspan="9" align="center">
            <asp:Button ID="btnSubmit" runat="server"  SkinID="btnSubmitSkin" Text="Submit" ValidationGroup="grpValidate" OnClick="btnSubmit_Click" />
            <asp:Button ID="btnCancel" runat="server"  SkinID="btnCancelSkin"
                Text="Cancel" OnClick="btnCancel_Click" /></td>
    </tr>
    <tr>
    <td colspan="9"></td>
    
    </tr>
    <tr>
        <td colspan="9" style="height: 16px">
        <asp:SqlDataSource ID="sdsRL" runat="server" ProviderName="System.Data.OleDb"
                     SelectCommand="SELECT REF_NO, CASE_REC_DATETIME, TITLE, (isnull(FIRST_NAME,'')+' '+isnull(MIDDLE_NAME,'')+' '+isnull(LAST_NAME,'')) as NAME, DOB, RES_ADD_LINE_1, RES_ADD_LINE_2, RES_ADD_LINE_3, RES_CITY, RES_PIN_CODE, RES_LAND_MARK, RES_PHONE,MOBILE, OFF_ADD_LINE_1, OFF_ADD_LINE_2, OFF_ADD_LINE_3, OFF_CITY, OFF_PIN_CODE, OFF_PHONE, OFF_EXTN, DESIGNATION, DEPARTMENT,OCCUPATION,PRIORITY,REGION,SPL_INSTRUCTION,REFERENCE1,REFERENCE2,REFERENCE1_TEL,REFERENCE2_TEL FROM CPV_RL_CASE_DETAILS"
                     ConnectionString="<%$ ConnectionStrings:CMConnectionString %>">
                       
                    </asp:SqlDataSource>
                    <asp:RegularExpressionValidator ID="revReceived" runat="server" ControlToValidate="txtRecDate"
                            Display="None" ErrorMessage="Please enter valid date format for Received date."
                            SetFocusOnError="True"  ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d"
                            ValidationGroup="grpValidate"></asp:RegularExpressionValidator>&nbsp;
                        <asp:RegularExpressionValidator ID="revRecTime" runat="server" ControlToValidate="txtRecTime"
                            Display="None" ErrorMessage="Please enter valid time format for Received date."
                            SetFocusOnError="True" ValidationExpression="(0[1-9]|1[0-2])[:]([0-5][0-9])"
                            ValidationGroup="grpValidate"></asp:RegularExpressionValidator>
                        <asp:RequiredFieldValidator ID="rfvRecDate" runat="server" ErrorMessage="Please enter Received date." ControlToValidate="txtRecDate" Display="None" ValidationGroup="grpValidate"></asp:RequiredFieldValidator>
                        <%--<asp:RequiredFieldValidator ID="rfvDOB" runat="server" ControlToValidate="txtDOB"
                            Display="None" ErrorMessage="Please enter Date of birth." ValidationGroup="grpValidate"></asp:RequiredFieldValidator>--%>
                        <asp:RequiredFieldValidator ID="rfvRecTime" runat="server" ControlToValidate="txtRecTime"
                            Display="None" ErrorMessage="Please enter Received time." ValidationGroup="grpValidate"></asp:RequiredFieldValidator>&nbsp;
                        <asp:ValidationSummary ID="vsValidate" runat="server" CssClass="compulsary" ShowMessageBox="True"
                            ShowSummary="False" ValidationGroup="grpValidate" />
            &nbsp;
            <asp:CompareValidator ID="valresPhone" runat="server" ControlToValidate="txtResPhone"
                Display="None" ErrorMessage="Please put integer value in Res phone " Operator="DataTypeCheck"
                SetFocusOnError="True" Type="Integer" ValidationGroup="grpValidate"></asp:CompareValidator>
            &nbsp;<asp:CompareValidator ID="resPin" runat="server" ControlToValidate="txtResPin"
                Display="None" ErrorMessage="Please put integer value in res pin" Operator="DataTypeCheck"
                SetFocusOnError="True" Type="Integer" ValidationGroup="grpValidate"></asp:CompareValidator>
            <asp:CompareValidator ID="valresimob" runat="server" ControlToValidate="txtResMob"
                Display="None" ErrorMessage="Please put integer value in res mobile" Operator="DataTypeCheck"
                SetFocusOnError="True" Type="Integer" ValidationGroup="grpValidate"></asp:CompareValidator>
            <asp:CompareValidator ID="valoffphone" runat="server" ControlToValidate="txtOffPhone"
                Display="None" ErrorMessage="Please put the integer  value in off phne" Operator="DataTypeCheck"
                SetFocusOnError="True" Type="Integer" ValidationGroup="grpValidate"></asp:CompareValidator>
            &nbsp;
            <asp:CompareValidator ID="valoffExt" runat="server" ControlToValidate="txtOffExtn"
                Display="None" ErrorMessage="Please put the integer value in off.E xt." Operator="DataTypeCheck"
                SetFocusOnError="True" Type="Integer" ValidationGroup="grpValidate"></asp:CompareValidator>
            <asp:CompareValidator ID="valoffPin" runat="server" ControlToValidate="txtOffPin"
                Display="None" ErrorMessage="Please put the integer value in off pin" Operator="DataTypeCheck"
                SetFocusOnError="True" Type="Integer" ValidationGroup="grpValidate"></asp:CompareValidator>
            <asp:CompareValidator ID="tell2" runat="server" ControlToValidate="txtTel2" Display="None"
                ErrorMessage="Please put the integer value in Telephone2" Operator="DataTypeCheck"
                SetFocusOnError="True" Type="Integer" ValidationGroup="grpValidate"></asp:CompareValidator>
            <asp:CompareValidator ID="valtell1" runat="server" ControlToValidate="txtTel1" Display="None"
                ErrorMessage="Please put the integer value Telephone1" Operator="DataTypeCheck"
                SetFocusOnError="True" Type="Integer" ValidationGroup="grpValidate"></asp:CompareValidator>
            <asp:CustomValidator ID="cvVeriType" runat="server" 
                Display="None" ErrorMessage="Please select one Verification Type" ClientValidationFunction="funCheckOneVerificationType" ValidationGroup="grpValidate"></asp:CustomValidator></td>
    </tr>
    <tr>
        <td colspan="9" >
        </td>
    </tr>
   </table>
</fieldset>
</asp:Content>