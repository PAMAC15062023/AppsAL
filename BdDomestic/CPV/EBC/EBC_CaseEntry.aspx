<%@ Page Language="C#" MasterPageFile="~/CPV/EBC/EBC_MasterPage.master" Theme="SkinFile" AutoEventWireup="true" CodeFile="EBC_CaseEntry.aspx.cs" Inherits="EBC_EBC_CaseEntry"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="C1" Runat="Server">
<script language="javascript" type="text/javascript">
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
     if(getControlsId.value.length > 99)
     {
       getControlsId.value = getControlsId.value.substring( 0, 99 );            
       return false;
     }          
   }
   function PreventCharacterToAdd1(controlId)
   {        
     getControlsId = document.getElementById(controlId);
     if(getControlsId.value.length > 254)
     {
       getControlsId.value = getControlsId.value.substring( 0, 254);            
       return false;
     }          
   }
   //function  AddReord()
  // {
  // getTextBoxID=document.getElementById('ctl00_C1_txtQualification')
   //if(getTextBoxID.value!="")
  // {
   //alert('Please Add the record in table');
   //return false; 
   //}
   //}
   
    function  AddReord1()
   {
   getTextBoxID=document.getElementById('ctl00_C1_txtQualification')
   
   if(getTextBoxID.value=="")
   {
   alert('Please put the value in Qualification ');
   return false; 
   }
   
   }
</script>
<fieldset ><legend class="FormHeading">EBC Case Entry</legend>
<table style="width: 100%" cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                    </td>
                    <td>
                        <table id="tblCreditCardCaseEntry" width="100%" cellpadding="0" cellspacing="0">
                            <tr>
                                <td style="height: 400px">
                                    <table id="tblPerDtl" width="100%" cellpadding="0" cellspacing="0" >
                                        <tr>
                                            <td colspan="12">
                                                <asp:Label ID="lblMsg" runat="server" Visible="False" SkinID="lblError"></asp:Label></td>
                                            
                                        </tr>
                                        <tr>
                                            <td style="width: 73px"  >
                                                REF No</td>
                                            <td style="width: 3px" >
                                                :</td>
                                            <td >
                                                <asp:TextBox ID="txtRefNo" runat="server" MaxLength="50" SkinID="txtSkin"></asp:TextBox></td>
                                            <td style="width: 70px"  >
                                                Recv Date</td>
                                            <td style="width: 6px" >
                                                :</td>
                                            <td >
                                                <asp:TextBox ID="txtRecDate" runat="server" MaxLength="10" SkinID="txtSkin"></asp:TextBox>
                                                <img id="imgRecDate"  alt="Calendar" src="../../Images/SmallCalendar.gif" onclick="popUpCalendar(this, document.all.<%=txtRecDate.ClientID%>, 'dd/mm/yyyy', 0, 0);" /></td>
                                            <td >
                                                Recv Time &nbsp;&nbsp;&nbsp;</td>
                                            <td style="width: 1px">
                                                : &nbsp;&nbsp;
                                            </td>
                                            <td colspan="4">
                                                <asp:TextBox ID="txtRecTime" runat="server" MaxLength="5" SkinID="txtSkin"></asp:TextBox>
                                                <asp:DropDownList ID="ddlTimeType" runat="server" SkinID="ddlSkin">
                                                    <asp:ListItem>AM</asp:ListItem>
                                                    <asp:ListItem>PM</asp:ListItem>
                                                </asp:DropDownList></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 73px" >
                                                Title</td>
                                            <td style="width: 3px" >
                                                :</td>
                                            <td>
                                                <asp:TextBox ID="txtTitle" runat="server" SkinID="txtSkin" MaxLength="50"></asp:TextBox></td>
                                            <td style="width: 70px">
                                                First Name</td>
                                            <td style="width: 6px">
                                                :</td>
                                            <td>
                                                <asp:TextBox ID="txtFirstNm" runat="server" MaxLength="50" SkinID="txtSkin"></asp:TextBox></td>
                                            <td>
                                                Middle Name &nbsp;&nbsp;</td>
                                            <td style="width: 1px">
                                                :</td>
                                            <td>
                                                <asp:TextBox ID="txtMiddleNm" runat="server" MaxLength="50" SkinID="txtSkin"></asp:TextBox></td>
                                            <td style="width: 57px" >
                                                Last Name&nbsp;</td>
                                            <td style="width: 1px">
                                                &nbsp;:&nbsp;
                                            </td>
                                            <td >
                                                <asp:TextBox ID="txtLastNm" runat="server" MaxLength="50" SkinID="txtSkin"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 73px">
                                                Date of joining</td>
                                            <td style="width: 3px">
                                                :</td>
                                            <td>
                                                <asp:TextBox ID="txtDOJ" runat="server" SkinID="txtSkin" MaxLength="10"></asp:TextBox>
                                                <img alt="Calendar" src="../../Images/SmallCalendar.gif" onclick="popUpCalendar(this, document.all.<%=txtDOJ.ClientID%>, 'dd/mm/yyyy', 0, 0);" /></td>
                                            <td style="width: 70px">
                                                Location</td>
                                            <td style="width: 6px">
                                                :</td>
                                            <td>
                                                <asp:TextBox ID="txtLocation" runat="server" SkinID="txtSkin" MaxLength="50"></asp:TextBox></td>
                                            <td>
                                                Designation</td>
                                            <td style="width: 1px">
                                                :</td>
                                            <td>
                                                <asp:TextBox ID="txtDesignation" runat="server" SkinID="txtSkin" MaxLength="100"></asp:TextBox></td>
                                            <td style="width: 57px">
                                            </td>
                                            <td style="width: 1px">
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 73px">
                                                Staff name</td>
                                            <td style="width: 3px">
                                                :</td>
                                            <td>
                                                <asp:TextBox ID="txtStaffname" runat="server" SkinID="txtSkin" MaxLength="100"></asp:TextBox></td>
                                            <td style="width: 70px">
                                                Father's name
                                            </td>
                                            <td style="width: 6px">
                                                :</td>
                                            <td colspan="7">
                                                <asp:TextBox ID="txtFathername" runat="server" SkinID="txtSkin" MaxLength="100"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 73px" >
                                                DOB</td>
                                            <td style="width: 3px" >
                                                :</td>
                                            <td>
                                                <asp:TextBox ID="txtDOB" runat="server" MaxLength="50" SkinID="txtSkin"></asp:TextBox>
                                                <img alt="Calendar" src="../../Images/SmallCalendar.gif" onclick="popUpCalendar(this, document.all.<%=txtDOB.ClientID%>, 'dd/mm/yyyy', 0, 0);" />
                                                </td>
                                                <td style="width: 70px">
                                                    EMP Code</td>
                                            <td style="width: 6px" >
                                                :</td>
                                               <td colspan="7">
                                                   <asp:TextBox ID="txtEmpCode" runat="server" MaxLength="10" SkinID="txtSkin"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 73px; height: 38px;">
                                                Verfication Type</td>
                                            <td style="width: 3px; height: 38px;">
                                                :</td>
                                            <td style="height: 38px">
                                                <asp:DropDownList ID="ddlVeriType" runat="server" DataSourceID="sdsVeriType" DataTextField="VERIFICATION_TYPE" DataValueField="VERIFICATION_TYPE_ID" OnDataBound="ddlVeriType_DataBound" SkinID="ddlSkin">
                                                </asp:DropDownList></td>
                                            <td style="width: 70px; height: 38px;">
                                            </td>
                                            <td style="width: 6px; height: 38px;">
                                            </td>
                                            <td colspan="7" style="height: 38px">
                                                <asp:SqlDataSource ID="sdsVeriType" runat="server" SelectCommand ="Select [VERIFICATION_TYPE_ID], [VERIFICATION_TYPE] from VERIFICATION_TYPE_MASTER 
               WHERE VERIFICATION_TYPE_ID IN(1,15,16,17,18) AND (PARENT_TYPE_CODE = 'VV')" ConnectionString="<%$ ConnectionStrings:CMConnectionString %>" ProviderName="<%$ ConnectionStrings:CMConnectionString.ProviderName %>"></asp:SqlDataSource>
                                                <asp:CustomValidator ID="valVeriType" runat="server" ControlToValidate="ddlVeriType"
                                                    Display="None" ErrorMessage="Please select Verification Type" SetFocusOnError="True" ClientValidationFunction="ClientValidate" ValidationGroup="grpValidate"></asp:CustomValidator>
                                            </td>
                                        </tr>
                                    </table>
                                    <table id="tblResDtl" width="100%" cellpadding="0" cellspacing="0" >
                                     <tr>
                                      <td style="height: 16px; width: 70px;">
                                          </td>
                                         <td style="width: 5px"   >
                                           </td>
                                           <td style="width: 329px" >
                                           </td>
                                          <td style="width: 182px"  >
                                           </td>
                                             <td style="width: 5px"  >
                                             </td>
                                            <td >
                                              </td>
                                             <td style="width: 2px" >
                                             </td>
                                             <td style="width: 2px" >
                                             </td>
                                             <td >
                                            </td>
                                           </tr>
                                    <tr><td colspan="6" class="txtBold" style="background-color:#D0D5D8; height: 14px;">
                                        Address &amp; Phone Detail</td></tr>
                                        <tr>
                                            <td style="width: 70px" >
                                                Add1</td>
                                            <td style="width: 5px" >
                                                :</td>
                                            <td colspan="4">
                                                
                                                <asp:TextBox ID="txtResAdd1" runat="server" TextMode="MultiLine" MaxLength="100" onkeypress="return PreventCharacterToAdd('ctl00_C1_txtResAdd1');" onkeyup="return PreventCharacterToAdd('ctl00_C1_txtResAdd1');" SkinID="txtSkin" Width="244px"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 70px">
                                                Add2</td>
                                            <td style="width: 5px" >
                                                :</td>
                                            <td colspan="4">
                                                <asp:TextBox ID="txtResAdd2" runat="server" TextMode="MultiLine" MaxLength="100" SkinID="txtSkin" Width="244px" onkeypress="return PreventCharacterToAdd('ctl00_C1_txtResAdd2');" onkeyup="return PreventCharacterToAdd('ctl00_C1_txtResAdd2');"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 70px; height: 38px;">
                                                Add3</td>
                                            <td style="width: 5px; height: 38px;" >
                                                :</td>
                                            <td colspan="4" style="height: 38px">
                                                <asp:TextBox ID="txtResAdd3" runat="server" TextMode="MultiLine" MaxLength="100" SkinID="txtSkin" Width="244px" onkeypress="return PreventCharacterToAdd('ctl00_C1_txtResAdd3');" onkeyup="return PreventCharacterToAdd('ctl00_C1_txtResAdd3');"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 70px">
                                                City</td>
                                            <td style="width: 5px" >
                                                :</td>
                                            <td style="width: 329px">
                                                <asp:TextBox ID="txtResCity" runat="server" MaxLength="50" SkinID="txtSkin"></asp:TextBox></td>
                                            <td style="width: 182px">
                                                Pin Code</td>
                                            <td style="width: 5px" >
                                                :&nbsp;</td>
                                            <td>
                                                <asp:TextBox ID="txtResPin" runat="server" MaxLength="10" SkinID="txtSkin"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 70px" >
                                                Phone1</td>
                                            <td style="width: 5px" >
                                                :</td>
                                            <td style="width: 329px" >
                                                <asp:TextBox ID="txtPhone1" runat="server" MaxLength="50" SkinID="txtSkin"></asp:TextBox></td>
                                            <td style="width: 182px" >
                                                Phone2</td>
                                            <td style="width: 5px" >
                                                :</td>
                                            <td >
                                                <asp:TextBox ID="txtPhone2" runat="server" MaxLength="50" SkinID="txtSkin"></asp:TextBox></td>
                                        </tr>
                                    </table>
                                    <table id="Table1" width="100%" cellpadding="0" cellspacing="0"  >
                                        <tr>
                                            <td colspan="12" class="txtBold" style="background-color:#D0D5D8; height: 14px;">
                                                Previous Employer Record</td>
                                            
                                        </tr>
                                        <tr>
                                            <td style="width: 186px"  >
                                                Previous Employer Name</td>
                                            <td  >
                                                :</td>
                                            <td  >
                                                <asp:TextBox ID="txtPreEmpName" runat="server" MaxLength="100" SkinID="txtSkin"></asp:TextBox></td>
                                            <td  >
                                                Previous Employer Address</td>
                                            <td style="width: 8px"  >
                                                :</td>
                                            <td  colspan="7" >
                                                <asp:TextBox ID="txtPreEmpAdd" runat="server" SkinID="txtSkin" TextMode="MultiLine" Width="244px" onkeypress="return PreventCharacterToAdd('ctl00_C1_txtPreEmpAdd');" onkeyup="return PreventCharacterToAdd1('ctl00_C1_txtPreEmpAdd');"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 186px"  >
                                                Previous Designation</td>
                                            <td  >
                                                :</td>
                                            <td >
                                                <asp:TextBox ID="txtPreDsig" runat="server" SkinID="txtSkin" MaxLength="100"></asp:TextBox></td>
                                                <td >
                                                    Reference Name number</td>
                                            <td >
                                                :</td>
                                               <td colspan="7">
                                                   <asp:TextBox ID="txtRefID" runat="server" SkinID="txtSkin" MaxLength="100"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td style="height: 23px; width: 186px;" >
                                                Projects</td>
                                            <td style="height: 23px" >
                                                :</td>
                                            <td style="height: 23px" >
                                                <asp:TextBox ID="txtProject" runat="server" SkinID="txtSkin" MaxLength="100"></asp:TextBox></td>
                                            <td colspan="9" style="height: 23px" >
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="12" class="txtBold" style="background-color:#D0D5D8; height: 14px;">
                                                Qulification Record</td>
                                        </tr>
                                        <tr>
                                            <td style="width: 186px" >
                                                Qualification</td>
                                            <td>
                                                :</td>
                                            <td >
                                                <asp:TextBox ID="txtQualification" runat="server" SkinID="txtSkin" MaxLength="50"></asp:TextBox></td>
                                            <td >
                                                Specilization</td>
                                            <td >
                                                :</td>
                                                <td>
                                                    <asp:TextBox ID="txtSpecilization" runat="server" SkinID="txtSkin" MaxLength="100"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 186px">
                                                university</td>
                                            <td>
                                                :</td>
                                            <td>
                                                <asp:TextBox ID="txtUniversity" runat="server" SkinID="txtSkin" MaxLength="100"></asp:TextBox></td>
                                            <td>
                                                Roll No.</td>
                                            <td>
                                                :</td>
                                            <td>
                                                <asp:TextBox ID="txtRollNo" runat="server" SkinID="txtSkin" MaxLength="50"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 186px; height: 25px;">
                                                Year of Passing</td>
                                            <td style="height: 25px">
                                                :</td>
                                            <td colspan="4" style="height: 25px">
                                                <asp:TextBox ID="txtYearOfPassing" runat="server" SkinID="txtSkin" MaxLength="50"></asp:TextBox>
                                                </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 186px; height: 25px">
                                            </td>
                                            <td style="height: 25px">
                                            </td>
                                            <td colspan="4" style="height: 25px">
                                                <asp:Button ID="btnAddNew" runat="server" SkinID="btnAddNewSkin" Text="Button" OnClick="btnAddNew_Click" OnClientClick="return AddReord1();"/></td>
                                        </tr>
                                        <tr>
                                            <td colspan="6" style="height: 14px">
                                                <asp:GridView ID="gvQualifivation" runat="server" SkinID="gridviewNoSort" Width="100%" OnRowDeleting="gvQualifivation_RowDeleting" OnRowEditing="gvQualifivation_RowEditing">
                                               <Columns>
                                                <asp:TemplateField>
                                                    <ItemStyle VerticalAlign="Top" />
                                                     <ItemTemplate>
                                                  <asp:LinkButton ID="lnkTemplate" runat="server" CausesValidation="False" 
                                                    CommandName="Delete"><img src="../../images/icon_delete.gif" alt="Delete" style="border:0" /></asp:LinkButton>
                                                
                                                   </ItemTemplate>
                                                   </asp:TemplateField>
                                                   
                                               <asp:TemplateField>
                                               <ItemTemplate>
                                              <asp:LinkButton ID="lnkTemplate1" runat="server" CausesValidation="False"
                                                   CommandName="Edit" ><img src="../../images/icon_Edit.gif" alt="Edit" style="border:0" /></asp:LinkButton>
                                        
                                                </ItemTemplate>
                                              </asp:TemplateField>
                                                  </Columns>
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                    </table>
                                    <asp:HiddenField ID="hidIndex" runat="server" />
                                </td>
                            </tr>
                            
                            <tr>
                           
                            <td align="center">
                                <asp:Button ID="btnSubmit" runat="server" Text="Submit" ValidationGroup="grpValidate" OnClick="btnSubmit_Click"  SkinID="btnSubmitSkin" />
                                <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" SkinID="btnCancelSkin" /></td>
                            </tr>
                             
                        </table>
                    </td>
                </tr>
                  
      <tr>
          <td>
          </td>
          <td>
              &nbsp;</td>
          <td>
          </td>
      </tr>
                <tr>
                    <td style="height: 81px">
                    </td>
                    <td style="height: 81px">
                        <asp:SqlDataSource ID="sdsEBC" runat="server" ProviderName="System.Data.OleDb"
                     SelectCommand="SELECT REF_NO, CASE_REC_DATETIME, TITLE, DOB,Title,(FIRST_NAME+' '+MIDDLE_NAME+' '+LAST_NAME) as NAME, DOB, RES_ADD_LINE_1, RES_ADD_LINE_2, RES_ADD_LINE_3, RES_CITY, RES_PIN_CODE, RES_LAND_MARK, RES_PHONE, OFF_ADD_LINE_1, OFF_ADD_LINE_2, OFF_ADD_LINE_3, OFF_CITY, OFF_PIN_CODE, OFF_PHONE, OFF_EXTN, DESIGNATION, DEPARTMENT FROM CPV_CC_CASE_DETAILS"
                     ConnectionString="<%$ ConnectionStrings:CMConnectionString %>">
                       
                    </asp:SqlDataSource>
                        &nbsp;
                        <asp:RegularExpressionValidator ID="revReceived" runat="server" ControlToValidate="txtRecDate"
                            Display="None" ErrorMessage="Please enter valid date format for Received date."
                            SetFocusOnError="True" ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d"
                            ValidationGroup="grpValidate"></asp:RegularExpressionValidator>
                        <asp:RegularExpressionValidator ID="revRecTime" runat="server" ControlToValidate="txtRecTime"
                            Display="None" ErrorMessage="Please enter valid time format for Received date."
                            SetFocusOnError="True" ValidationExpression="(0[1-9]|1[0-2])[:]([0-5][0-9])"
                            ValidationGroup="grpValidate"></asp:RegularExpressionValidator>
                        <asp:RequiredFieldValidator ID="rfvRecDate" runat="server" ErrorMessage="Please enter Received date." ControlToValidate="txtRecDate" Display="None" ValidationGroup="grpValidate"></asp:RequiredFieldValidator>
                        <asp:RequiredFieldValidator ID="rfvDOB" runat="server" ControlToValidate="txtDOB"
                            Display="None" ErrorMessage="Please enter Date of birth." ValidationGroup="grpValidate"></asp:RequiredFieldValidator>
                        <asp:RequiredFieldValidator ID="rfvRecTime" runat="server" ControlToValidate="txtRecTime"
                            Display="None" ErrorMessage="Please enter Received time." ValidationGroup="grpValidate"></asp:RequiredFieldValidator>
                        <asp:ValidationSummary ID="vsValidate" runat="server" CssClass="compulsary" ShowMessageBox="True"
                            ShowSummary="False" ValidationGroup="grpValidate" />
                    </td>
                    <td style="height: 81px">
                    </td>
                </tr>
            </table>
            </fieldset>
</asp:Content>



