<%@ page language="C#" masterpagefile="~/HDFCBANK/HDFCBANK/MasterPage.master" theme="SkinFile" autoeventwireup="true" inherits="KYC_KYC_CaseEntry, App_Web_kyc_caseentry.aspx.513d3bc3" viewStateEncryptionMode="Always" %>
<%@ Register TagPrefix="uc" Namespace="ASPNET_Captcha" Assembly="ASPNET_Captcha" %>


<asp:Content ID="Content1" ContentPlaceHolderID="C1" Runat="Server">
<script type="text/javascript" language="javascript">

function ClientValidate(source, arguments)
   {
      //alert(arguments.Value);
      if ((arguments.Value) == 0)
         arguments.IsValid=false;
      else
         arguments.IsValid=true;
   }
 function PreventCharacterToAdd(controlId)
   {        
     getControlsId = document.getElementById(controlId);
     if(getControlsId.value.length > 49)
     {
       getControlsId.value = getControlsId.value.substring( 0, 49 );            
       return false;
     }          
   }
   
   
function checkNumeric(textBox) 
{
    var textBox = document.getElementById(textBox); 
    if(isNaN(textBox.value)) 
    {
        alert("-Please provide a numeric value."); 
        textBox.value=""; 
        return false; 
    }
}
</script>

<table border="0" cellpadding="0" cellspacing="0" width="99%" align="center">
<tr>
<td>
<fieldset >
<legend class="FormHeading">KYC Case Entry</legend>
<table style="width: 100%" cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                    </td>
                    <td>
                        <table id="tblCreditCardCaseEntry" width="100%" cellpadding="0" cellspacing="0" style="background-color:#E7F6FF">
                        <tr><td align="right" style="height: 16px">
                            </td></tr>
                            <tr>
                                <td>
                                    <table id="tblPerDtl" width="100%" cellpadding="0" cellspacing="0" border="0">
                                        <tr>
                                            <td colspan="8">
                                                <asp:Label ID="lblMsg" runat="server" CssClass="LabelError" Visible="False" SkinID="lblError"></asp:Label></td>
                                            <td colspan="1" style="width: 11px">
                                            </td>
                                            <td colspan="1">
                                            </td>
                                            
                                        </tr>
                                        <tr>
                                            <td style="width: 111px; height: 38px">
                                                Client Name</td>
                                            <td colspan="2" style="width: 40px; height: 38px">
                                                <asp:DropDownList ID="ddlclientname" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlclientname_SelectedIndexChanged"
                                                    SkinID="ddlSkin">
                                                </asp:DropDownList></td>
                                            <td style="height: 38px">
                                            </td>
                                            <td style="width: 77px; height: 38px">
                                            </td>
                                            <td align="left" colspan="3" style="height: 38px">
                                            </td>
                                            <td align="left" colspan="1" style="width: 11px; height: 38px">
                                            </td>
                                            <td colspan="1" style="height: 38px">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 111px; height: 38px;" >
                                                REF No :-</td>
                                            <td colspan="2" style="height: 38px; width: 40px;">
                                                <asp:TextBox ID="txtRefNo" runat="server" MaxLength="50" SkinID="txtSkin" Enabled="False" Font-Bold="True"></asp:TextBox></td>
                                            <td style="height: 38px"  >
                                                </td>
                                            <td style="height: 38px; width: 77px;" >
                                                Title :-</td>
                                            <td colspan="3" style="height: 38px" align="left" >
                                                <asp:TextBox ID="txtTitle" runat="server" MaxLength="10" SkinID="txtSkin"></asp:TextBox></td>
                                            <td align="left" colspan="1" style="width: 11px; height: 38px">
                                            </td>
                                            <td colspan="1" style="height: 38px">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 111px">
                                                Recv Date :-</td>
                                            <td colspan="2" style="width: 40px">
                                                <asp:TextBox ID="txtRecDate" runat="server" MaxLength="11" SkinID="txtSkin" Enabled="False" Font-Bold="True"></asp:TextBox>
                                                [dd/MM/yyyy]</td>
                                            <td>
                                            </td>
                                            <td style="width: 77px">
                                                Recv Time :-
                                            </td>
                                            <td align="left" colspan="3">
                                                <asp:TextBox ID="txtRecTime" runat="server" MaxLength="5" SkinID="txtSkin" Enabled="False" Font-Bold="True"></asp:TextBox><asp:DropDownList ID="ddlTimeType" runat="server" SkinID="ddlSkin" Enabled="False" Font-Bold="True">
                                                    <asp:ListItem>AM</asp:ListItem>
                                                    <asp:ListItem>PM</asp:ListItem>
                                                </asp:DropDownList>[hh:mm]
                                            </td>
                                            <td align="left" colspan="1" style="width: 11px">
                                            </td>
                                            <td colspan="1">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 111px; height: 24px;" >
                                                First Name :-</td>
                                            <td colspan="2" style="height: 24px; width: 40px;">
                                                <asp:TextBox ID="txtFirstNm" runat="server" MaxLength="50" SkinID="txtSkin" ValidationGroup="grpValidate"></asp:TextBox></td>
                                            <td style="height: 24px" >
                                                </td>
                                            <td style="height: 24px; width: 77px;" >
                                                Middle Name :-</td>
                                            <td style="height: 24px; width: 170px;">
                                                <asp:TextBox ID="txtMiddleNm" runat="server" MaxLength="50" SkinID="txtSkin" ValidationGroup="grpValidate"></asp:TextBox></td>
                                            <td style="height: 24px; width: 78px;" >
                                                Last Name :-</td>
                                            <td style="height: 24px; width: 309px;" >
                                                <asp:TextBox ID="txtLastNm" runat="server" MaxLength="50" SkinID="txtSkin" ValidationGroup="grpValidate"></asp:TextBox></td>
                                            <td style="width: 11px; height: 24px">
                                            </td>
                                            <td style="height: 24px">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 111px; height: 24px">
                                                Verification Type :-</td>
                                            <td colspan="2" style="height: 24px; width: 40px;">
                                                <asp:DropDownList ID="ddlVeriType" runat="server" OnDataBound="ddlVeriType_DataBound" SkinID="ddlSkin" OnSelectedIndexChanged="ddlVeriType_SelectedIndexChanged" AutoPostBack="True">
                                                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                    <asp:ListItem Value="1">Residence Address</asp:ListItem>
                                                    <asp:ListItem Value="2">Office address</asp:ListItem>
                                                     <asp:ListItem Value="2">Current account CPV</asp:ListItem>
                                                </asp:DropDownList></td>
                                            <td style="height: 24px">
                                            </td>
                                            <td style="height: 24px; color: #ffffff; width: 77px;">
                                                </td>
                                            <td colspan="2" style="height: 24px; color: #ffffff;">
                                                &nbsp;
                                                &nbsp;&nbsp; 
                                            </td>
                                            <td style="height: 24px; color: #ffffff; width: 309px;">
                                                   </td>
                                            <td style="width: 11px; color: #ffffff; height: 24px">
                                            </td>
                                            <td style="height: 24px">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="8">
                                                <asp:Panel ID="PnlRes" runat="server" Width="99px">
                                    <table id="tblResDtl" cellpadding="0" cellspacing="0" border="0" style="width: 767%; height: 68px">
                                    <tr><td colspan="4" class="txtBold" style="background-color:#D0D5D8; height: 15px;" align="center">Residence Detail</td></tr>
                                        <tr>
                                            <td style="height: 38px; width: 111px;">
                                                &nbsp;Flat No. Bldg Name</td>
                                            <td colspan="3" style="height: 38px">
                                                <asp:TextBox ID="txtResAdd1" runat="server" TextMode="MultiLine" MaxLength="50" SkinID="txtSkin" Width="277px"  onkeypress="return PreventCharacterToAdd('ctl00_C1_txtResAdd1')" onkeyup="return PreventCharacterToAdd('ctl00_C1_txtResAdd1');"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td style="height: 40px; width: 111px;">
                                                &nbsp;Road No. / Name</td>
                                            <td colspan="3" style="height: 40px">
                                                <asp:TextBox ID="txtResAdd2" runat="server" TextMode="MultiLine" MaxLength="50" SkinID="txtSkin" Width="276px"  onkeypress="return PreventCharacterToAdd('ctl00_C1_txtResAdd2')" onkeyup="return PreventCharacterToAdd('ctl00_C1_txtResAdd2');"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 111px">
                                                &nbsp;Area</td>
                                            <td colspan="3">
                                                <asp:TextBox ID="txtResAdd3" runat="server" TextMode="MultiLine" MaxLength="50" SkinID="txtSkin" Width="276px"  onkeypress="return PreventCharacterToAdd('ctl00_C1_txtResAdd3')" onkeyup="return PreventCharacterToAdd('ctl00_C1_txtResAdd3');"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 111px; height: 24px">
                                                &nbsp;City</td>
                                            <td style="height: 24px">
                                                <asp:TextBox ID="txtResCity" runat="server" MaxLength="50" SkinID="txtSkin"></asp:TextBox></td>
                                            <td style="height: 24px">
                                                </td>
                                            <td style="height: 24px">
                                                </td>
                                        </tr>
                                        <tr>
                                            <td style="height: 24px; width: 111px;">
                                                &nbsp;Pin</td>
                                            <td style="height: 24px">
                                                <asp:TextBox ID="txtResPin" runat="server" MaxLength="10" SkinID="txtSkin" Onchange ="return checkNumeric('ctl00_C1_txtResPin');"></asp:TextBox></td>
                                            <td style="height: 24px">
                                                Resi Phone</td>
                                            <td style="height: 24px">
                                                <asp:TextBox ID="txtResPhone" runat="server" MaxLength="50" SkinID="txtSkin" Onchange ="return checkNumeric('ctl00_C1_txtResPhone');"></asp:TextBox></td>
                                        </tr>
                                    </table>
                                                </asp:Panel>
                                                <asp:Panel ID="Panel1" runat="server">
                                    <table id="tblOfficeDtl" cellpadding="0" cellspacing="0" border="0" style="width: 635px; height: 68px">
                                    <tr><td colspan="4" class="txtBold" style="background-color:#D0D5D8; height: 16px;" align="center">Office Detail</td></tr>
                                        <tr>
                                            <td style="height: 24px; width: 113px;">
                                                &nbsp;Company Name</td>
                                            <td colspan="3" style="height: 24px">
                                                <asp:TextBox ID="txtOffName" runat="server" MaxLength="500" SkinID="txtSkin" Width="276px"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td style="height: 38px; width: 113px;" >
                                                &nbsp;Office No.&nbsp; Bldg Name</td>
                                            <td colspan="3" style="height: 38px">
                                                <asp:TextBox ID="txtOffAdd1" runat="server" TextMode="MultiLine" MaxLength="50" SkinID="txtSkin" Width="275px"  onkeypress="return PreventCharacterToAdd('ctl00_C1_txtOffAdd1')" onkeyup="return PreventCharacterToAdd('ctl00_C1_txtOffAdd1');"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td style="height: 40px; width: 113px;" >
                                                &nbsp;Road No. / Name</td>
                                            <td colspan="3" style="height: 40px">
                                                <asp:TextBox ID="txtOffAdd2" runat="server" TextMode="MultiLine" MaxLength="50" SkinID="txtSkin" Width="275px"  onkeypress="return PreventCharacterToAdd('ctl00_C1_txtOffAdd2')" onkeyup="return PreventCharacterToAdd('ctl00_C1_txtOffAdd2');"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 113px" >
                                                &nbsp;Area</td>
                                            <td colspan="3">
                                                <asp:TextBox ID="txtOffAdd3" runat="server" TextMode="MultiLine" MaxLength="50" SkinID="txtSkin" Width="274px"  onkeypress="return PreventCharacterToAdd('ctl00_C1_txtOffAdd3')" onkeyup="return PreventCharacterToAdd('ctl00_C1_txtOffAdd3');"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 113px" >
                                                &nbsp;City</td>
                                            <td>
                                                <asp:TextBox ID="txtOffCity" runat="server" MaxLength="50" SkinID="txtSkin"></asp:TextBox></td>
                                            <td>
                                                Pin</td>
                                            <td>
                                                <asp:TextBox ID="txtOffPin" runat="server" MaxLength="10" SkinID="txtSkin" Onchange ="return checkNumeric('ctl00_C1_txtOffPin');"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 113px">
                                                &nbsp;Off. Phone</td>
                                            <td>
                                                <asp:TextBox ID="txtOffPhone" runat="server" MaxLength="50" SkinID="txtSkin" Onchange ="return checkNumeric('ctl00_C1_txtOffPhone');"></asp:TextBox></td>
                                            <td>
                                                Off. Extn</td>
                                            <td>
                                                <asp:TextBox ID="txtOffExtn" runat="server" MaxLength="10" SkinID="txtSkin" Onchange ="return checkNumeric('ctl00_C1_txtOffExtn');"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 113px">
                                                &nbsp;Designation</td>
                                            <td>
                                                <asp:TextBox ID="txtDesgn" runat="server" MaxLength="50" SkinID="txtSkin"></asp:TextBox></td>
                                            <td>
                                                Department</td>
                                            <td>
                                                <asp:TextBox ID="txtDept" runat="server" MaxLength="50" SkinID="txtSkin"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 113px">
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtOccupation" runat="server" MaxLength="50" SkinID="txtSkin" Visible="False"></asp:TextBox></td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                    </table>
                                                </asp:Panel>
                                                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                                                <table id="Table1" cellpadding="0" cellspacing="0" border="0" style="width: 635px; height: 68px">
                                                    <tr>
                                                        <td style="width: 113px">
                                                            <asp:Label ID="lbllandmark" runat="server" Text="Land Mark" Visible="False"></asp:Label></td>
                                                        <td style="font-size: 10pt; color: #ff3300">
                                                <asp:TextBox ID="txtLandMark" runat="server" MaxLength="50" SkinID="txtSkin" Visible="False"></asp:TextBox></td>
                                                        <td>
                                                            <asp:Label ID="lblreason" runat="server" Text="Reason For CPV" Visible="False"></asp:Label></td>
                                                        <td>
                                                            <asp:TextBox ID="txtReasonForCpv" runat="server" SkinID="txtSkin" Visible="False" ValidationGroup="grpValidate"></asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 113px">
                                                            <asp:Label ID="lblstate" runat="server" Text="State" Visible="False"></asp:Label></td>
                                                        <td>
                                                            <asp:TextBox ID="txtstate" runat="server" SkinID="txtSkin" Visible="False"></asp:TextBox></td>
                                                        <td>
                                                            <asp:Label ID="lblcountry" runat="server" Text="Country" Visible="False"></asp:Label></td>
                                                        <td>
                                                            <asp:TextBox ID="txtcountry" runat="server" SkinID="txtSkin" Visible="False"></asp:TextBox></td>
                                                    </tr>
                                                </table>
                                              
                                                <table id="Table3" cellpadding="0" cellspacing="0" border="0" style="width: 635px; height: 32px;">
                                                    <tr>
                                                        <td style="width: 113px; height: 52px;">
                                                            <uc:aspnet_captcha id="ucCaptcha" runat="server" align="Middle" color="#FF0000"></uc:aspnet_captcha>
                                                        </td>
                                                        <td style="height: 52px">
                                                            &nbsp;<asp:TextBox ID="txtCaptcha" runat="server"></asp:TextBox><asp:Label ID="lblMessage"
                                                                runat="server" Text=""></asp:Label></td>
                                                        <td style="height: 52px">
                                                        </td>
                                                        <td style="height: 52px">
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td colspan="1" style="width: 11px">
                                            </td>
                                            <td colspan="1">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" colspan="8" style="height: 14px">
                                                &nbsp;<asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" ValidationGroup="grpValidate" SkinID="btnSubmitSkin" Font-Bold="True" Width="114px" Height="25px" />
                                                &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" Text="Cancel" SkinID="btncancelskin" Font-Bold="True" Width="113px" Height="25px" /></td>
                                            <td align="center" colspan="1" style="width: 11px; height: 14px">
                                            </td>
                                            <td colspan="1" style="height: 14px">
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                            <td align="center">
                                &nbsp;</td>
                            </tr>
                             
                        </table>
                    </td>
                    <td>
                    </td>
                </tr>
      <tr>
          <td>
          </td>
          <td>
             </td>
          <td>
          </td>
      </tr>
                <tr>
                    <td style="height: 91px">
                    </td>
                    <td style="height: 91px">
                        &nbsp; &nbsp;&nbsp;
                        <asp:RequiredFieldValidator ID="Rfvddlclient" runat="server" ControlToValidate="ddlclientname"
                            ErrorMessage="Please Select Client Name" InitialValue="0" ValidationGroup="grpValidate" Display="None"></asp:RequiredFieldValidator>&nbsp;
                        <asp:RequiredFieldValidator ID="reqfrstname" runat="server" ControlToValidate="txtFirstNm"
                            Display="None" ErrorMessage="Please Enter First Name" ValidationGroup="grpValidate"></asp:RequiredFieldValidator>
                        <asp:RequiredFieldValidator ID="rqfmdlname" runat="server" ControlToValidate="txtMiddleNm"
                            Display="None" ErrorMessage="Please Enter Middle Name" ValidationGroup="grpValidate"></asp:RequiredFieldValidator>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtLastNm"
                            Display="None" ErrorMessage="Please Enter Last Name" ValidationGroup="grpValidate"></asp:RequiredFieldValidator>
               <asp:CustomValidator ID="valVeriType" runat="server" ControlToValidate="ddlVeriType"
                                                    Display="None" ErrorMessage="Please select Verification Type" SetFocusOnError="True" ClientValidationFunction="ClientValidate" ValidationGroup="grpValidate"></asp:CustomValidator>
                        &nbsp;
                        <asp:RegularExpressionValidator ID="revReceived" runat="server" ControlToValidate="txtRecDate"
                            Display="None" ErrorMessage="Please enter valid date format for Received date."
                            SetFocusOnError="True" ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d"
                            ValidationGroup="grpValidate"></asp:RegularExpressionValidator>
                        <asp:RegularExpressionValidator ID="revRecTime" runat="server" ControlToValidate="txtRecTime"
                            Display="None" ErrorMessage="Please enter valid time format for Received date."
                            SetFocusOnError="True" ValidationExpression="(0[1-9]|1[0-2])[:]([0-5][0-9])"
                            ValidationGroup="grpValidate"></asp:RegularExpressionValidator>
                        <asp:RequiredFieldValidator ID="rfvRecDate" runat="server" ErrorMessage="Please enter Received date." ControlToValidate="txtRecDate" Display="None" ValidationGroup="grpValidate"></asp:RequiredFieldValidator>&nbsp;
                        <asp:RequiredFieldValidator ID="rfvRecTime" runat="server" ControlToValidate="txtRecTime"
                            Display="None" ErrorMessage="Please enter Received time." ValidationGroup="grpValidate"></asp:RequiredFieldValidator>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtRefNo"
        Display="None" ErrorMessage="Please Enter Ref. No." ValidationGroup="grpValidate"></asp:RequiredFieldValidator>

                        <asp:ValidationSummary ID="vsValidate" runat="server" CssClass="compulsary" ShowMessageBox="True"
                            ShowSummary="False" ValidationGroup="grpValidate" />
                    </td>
                    <td style="height: 91px" >
                    </td>
                </tr>
               
               
            </table>
    <asp:RequiredFieldValidator ID="Add1" runat="server" ControlToValidate="txtResAdd1"
        Display="None" ErrorMessage="Enter Flat No. Bldg Name" ValidationGroup="grpValidate">Enter Flat No. Bldg Name</asp:RequiredFieldValidator>
    <asp:RequiredFieldValidator ID="Add2" runat="server" ControlToValidate="txtResAdd2"
        Display="None" ErrorMessage="Enter Road No. / Name" ValidationGroup="grpValidate">Enter Road No. / Name</asp:RequiredFieldValidator>
    <asp:RequiredFieldValidator ID="Add3" runat="server" ControlToValidate="txtResAdd3"
        Display="None" ErrorMessage="Enter Area" ValidationGroup="grpValidate">Enter Area</asp:RequiredFieldValidator>
    <asp:RequiredFieldValidator ID="Resipin" runat="server" ControlToValidate="txtResPin"
        Display="None" ErrorMessage="Enter Residence Pincode" ValidationGroup="grpValidate"></asp:RequiredFieldValidator>
    <asp:RequiredFieldValidator ID="landmark" runat="server" ControlToValidate="txtLandMark"
        Display="None" ErrorMessage="Enter Landmark" ValidationGroup="grpValidate">Enter Landmark</asp:RequiredFieldValidator>
    <asp:RequiredFieldValidator ID="Offadd1" runat="server" ControlToValidate="txtOffAdd1"
        Display="None" ErrorMessage="Enter Office No.  Bldg Name" ValidationGroup="grpValidate">Enter Office No.  Bldg Name</asp:RequiredFieldValidator>
    <asp:RequiredFieldValidator ID="Offadd2" runat="server" ControlToValidate="txtOffAdd2"
        Display="None" ErrorMessage="Enter Road No. / Name" ValidationGroup="grpValidate">Enter Road No. / Name</asp:RequiredFieldValidator>
    <asp:RequiredFieldValidator ID="OffPin" runat="server" ControlToValidate="txtOffPin"
        Display="None" ErrorMessage="Enter Office Pincode" ValidationGroup="grpValidate">Enter Office Pincode</asp:RequiredFieldValidator>
    <asp:RequiredFieldValidator ID="OffAdd3" runat="server" ControlToValidate="txtOffAdd3"
        Display="None" ErrorMessage="Enter Area" ValidationGroup="grpValidate">Enter Area</asp:RequiredFieldValidator>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtReasonForCpv"
        Display="None" ErrorMessage="Please Enter Reason For CPV" ValidationGroup="grpValidate"></asp:RequiredFieldValidator></fieldset>
</td></tr></table>
            

</asp:Content>



