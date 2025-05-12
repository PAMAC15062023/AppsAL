<%@ Page Language="C#" MasterPageFile="~/CPV/KYC/KYC_MasterPage.master" AutoEventWireup="true" CodeFile="KYC_CaseVerificationEntry.aspx.cs" Inherits="KYC_KYC_CaseVerificationEntry"%>
<asp:Content ID="Content1" ContentPlaceHolderID="C1" Runat="Server">
<script language="javascript" type="text/javascript">
<!--
       function ValidateTime1(source, arguments)
       { 
          //alert(document.aspnetForm.ctl00$C1$txtTime1.value);          
          if(document.aspnetForm.ctl00$C1$txtAttemptTime1.value.length >0)
          {            
            if(document.aspnetForm.ctl00$C1$txtAttemptRemark1.value.length ==0)
            {
                document.aspnetForm.ctl00$C1$txtAttemptRemark1.focus();
                arguments.IsValid=false;
            }              
          }
       }
       function ValidateRemark1(source, arguments)
       {
           if(document.aspnetForm.ctl00$C1$txtAttemptRemark1.value.length >0)
           {                
                if(document.aspnetForm.ctl00$C1$txtAttemptTime1.value.length ==0)
                {
                    document.aspnetForm.ctl00$C1$txtAttemptTime1.focus();
                    arguments.IsValid=false;
                }
           }
       }
       function ValidateTime2(source, arguments)
       { 
          //alert(document.aspnetForm.ctl00$C1$txtTime1.value);          
          if(document.aspnetForm.ctl00$C1$txtAttemptTime2.value.length >0)
          {            
            if(document.aspnetForm.ctl00$C1$txtAttemptRemark2.value.length ==0)
            {
                document.aspnetForm.ctl00$C1$txtAttemptRemark2.focus();
                arguments.IsValid=false;
            }   
          }
       }
       function ValidateRemark2(source, arguments)
       {
           if(document.aspnetForm.ctl00$C1$txtAttemptRemark2.value.length >0)
           {                
                if(document.aspnetForm.ctl00$C1$txtAttemptTime2.value.length ==0)
                {
                    document.aspnetForm.ctl00$C1$txtAttemptTime2.focus();
                    arguments.IsValid=false;
                }
           }
       }
       function ValidateTime3(source, arguments)
       { 
          //alert(document.aspnetForm.ctl00$C1$txtTime1.value);          
          if(document.aspnetForm.ctl00$C1$txtAttemptTime3.value.length >0)
          {            
            if(document.aspnetForm.ctl00$C1$txtAttemptRemark3.value.length ==0)
            {
                document.aspnetForm.ctl00$C1$txtAttemptRemark3.focus();
                arguments.IsValid=false;
            }   
          }
       }
       function ValidateRemark3(source, arguments)
       {
           if(document.aspnetForm.ctl00$C1$txtAttemptRemark2.value.length >0)
           {                
                if(document.aspnetForm.ctl00$C1$txtAttemptTime3.value.length ==0)
                {
                    document.aspnetForm.ctl00$C1$txtAttemptTime3.focus();
                    arguments.IsValid=false;
                }
           }
       }
// -->

</script>

<table style="width: 100%" cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td>                    
                    </td>
                    <td>
                        <table id="tblCreditCardCaseEntry" width="100%" cellpadding="0" cellspacing="0" border="1">
                        <tr><td align="center"><b>KYC Case Verification Detail</b></td></tr>
                            <tr>
                                <td>
                                    <table id="tblPerDtl" width="100%" cellpadding="0" cellspacing="0" border="1">
                                        <tr>
                                            <td colspan="4">
                                                <asp:Label ID="lblMsg" runat="server" Visible="False"></asp:Label></td>
                                            
                                        </tr>
                                        <tr>
                                            <td style="width:12%">
                                                REF No</td>
                                            <td style="width:18%" >
                                                <asp:Label ID="lblRefNo" runat="server" ></asp:Label></td>
                                            <td rowspan="2" valign="top" style="width:15%" >
                                                Address</td>
                                            <td rowspan="2" valign="top"  >
                                            <asp:Label ID="lblAddress" runat="server" ></asp:Label>
                                                </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Applicaant Name</td>
                                            <td >
                                                <asp:Label ID="lblName" runat="server"></asp:Label></td>
                                            
                                        </tr>
                                    </table>
                                    <table id="tblResDtl" width="100%" cellpadding="0" cellspacing="0" border="1">
                                    <tr><td colspan="4" style="height: 21px">
                                        </td></tr>
                                        <tr>
                                            <td style="width:12%">
                                                Verifier</td>
                                            <td colspan="3">
                                                <asp:DropDownList ID="ddlVerifier" DataSourceID="sdsVerifier" DataTextField="Name"
                                            DataValueField="EMP_ID" runat="server" OnDataBound="ddlVerifier_DataBound">
                                                </asp:DropDownList></td>
                                        </tr>
                                    </table>
                                    
                                </td>
                            </tr>
                            <tr><td>&nbsp;</td></tr>
                            <tr>
                            <td>
                            <table id="tblAttemptDtl" cellpadding="0" cellspacing="0" width="100%" border="1">
                            <tr>
                            <td style="width: 10%">Attempt</td>
                            <td style="width: 15%" >Date</td>
                            <td style="width: 13%">Time</td>
                            <td style="width: 25%">Remark</td>
                            </tr>
                            <tr>
                            <td >Attempt1</td>
                            <td  ><asp:TextBox ID="txtAttemptDate1" runat="server" Width="70%" MaxLength="11"></asp:TextBox>
                                <img alt="Calendar" src="../../Images/SmallCalendar.gif" onclick="popUpCalendar(this,document.all.<%=txtAttemptDate1.ClientID%>, 'dd-mmm-yyyy', 0, 0);" /></td>
                            <td  ><asp:TextBox ID="txtAttemptTime1" runat="server" Width="33%" MaxLength="5"></asp:TextBox>
                                <asp:DropDownList ID="ddlAttemptTimeType1" runat="server">
                                <asp:ListItem Text="AM" Value="AM"></asp:ListItem>
                                <asp:ListItem Text="PM" Value="PM"></asp:ListItem>
                                </asp:DropDownList></td>
                            <td><asp:TextBox ID="txtAttemptRemark1" runat="server" MaxLength="255" TextMode="MultiLine" Width="206px"></asp:TextBox>
                            <asp:CustomValidator ID="cvAttemptTime1" runat="server" ControlToValidate="txtAttemptTime1"
                                 Display="None" ErrorMessage="Enter remark in first attempt." 
                                 ValidationGroup="grpValidate" ClientValidationFunction="ValidateTime1"></asp:CustomValidator>
                           <asp:CustomValidator ID="cvAttemptRemark1" runat="server" ClientValidationFunction="ValidateRemark1"
                                    ControlToValidate="txtAttemptRemark1" Display="None" ErrorMessage="Enter time in first attempt."
                                    ValidationGroup="grpValidate"></asp:CustomValidator>
                            </td>
                            </tr>
                            <tr>
                            <td>Attempt2</td>
                             <td ><asp:TextBox ID="txtAttemptDate2" runat="server" Width="70%" MaxLength="11"></asp:TextBox>
                                <img alt="Calendar" src="../../Images/SmallCalendar.gif" onclick="popUpCalendar(this, document.all.<%=txtAttemptDate2.ClientID%>, 'dd-mmm-yyyy', 0, 0);" /></td>
                            <td  ><asp:TextBox ID="txtAttemptTime2" runat="server" Width="33%" MaxLength="5"></asp:TextBox>
                                <asp:DropDownList ID="ddlAttemptTimeType2" runat="server">
                                <asp:ListItem Text="AM" Value="AM"></asp:ListItem>
                                <asp:ListItem Text="PM" Value="PM"></asp:ListItem>
                                </asp:DropDownList></td>
                            <td><asp:TextBox ID="txtAttemptRemark2" runat="server" MaxLength="255" TextMode="MultiLine" Width="206px"></asp:TextBox><asp:CustomValidator
                                    ID="cvAttemptTime2" runat="server" ClientValidationFunction="ValidateTime2" ControlToValidate="txtAttemptTime2"
                                    Display="None" ErrorMessage="Enter remark in second attempt." ValidationGroup="grpValidate"></asp:CustomValidator>
                                <asp:CustomValidator ID="cvAttemptRemark2" runat="server" ClientValidationFunction="ValidateRemark2"
                                    ControlToValidate="txtAttemptRemark2" Display="None" ErrorMessage="Enter time in second attempt."
                                    ValidationGroup="grpValidate"></asp:CustomValidator></td>
                            </tr>
                            <tr>
                            <td>Attempt3</td>
                            <td  ><asp:TextBox ID="txtAttemptDate3" runat="server" Width="70%" MaxLength="11"></asp:TextBox>
                                <img alt="Calendar" src="../../Images/SmallCalendar.gif" onclick="popUpCalendar(this, document.all.<%=txtAttemptDate3.ClientID%>, 'dd-mmm-yyyy', 0, 0);" /></td>
                            <td ><asp:TextBox ID="txtAttemptTime3" runat="server" Width="33%" MaxLength="5"></asp:TextBox>
                                <asp:DropDownList ID="ddlAttemptTimeType3" runat="server">
                                <asp:ListItem Text="AM" Value="AM"></asp:ListItem>
                                <asp:ListItem Text="PM" Value="PM"></asp:ListItem>
                                </asp:DropDownList></td>
                            <td><asp:TextBox ID="txtAttemptRemark3" runat="server" MaxLength="255" TextMode="MultiLine" Width="206px"></asp:TextBox><asp:CustomValidator
                                    ID="cvAttemptTime3" runat="server" ClientValidationFunction="ValidateTime3" ControlToValidate="txtAttemptTime3"
                                    Display="None" ErrorMessage="Enter remark in third attempt." ValidationGroup="grpValidate"></asp:CustomValidator>
                                <asp:CustomValidator ID="cvAttemptRemark3" runat="server" ClientValidationFunction="ValidateRemark3"
                                    ControlToValidate="txtAttemptRemark3" Display="None" ErrorMessage="Enter time in third attempt."
                                    ValidationGroup="grpValidate"></asp:CustomValidator></td>
                            </tr>
                            </table>
                            </td>
                            </tr>
                            <tr><td>&nbsp;</td></tr>
                            
                            <tr>
                            
                                <td>
                                <table id="tblverifyStatus" width="100%" cellpadding="0" cellspacing="0" border="1">
                                    
                                        <tr>
                                            <td style="width:12%">
                                                Verification Status</td>
                                            <td colspan="3">
                                                <asp:DropDownList ID="ddlCaseStatus" DataSourceID="sdsVerification" DataTextField="Status_Name"
                                            DataValueField="Case_Status_ID" runat="server"></asp:DropDownList></td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                            <td >&nbsp;</td>
                            </tr>
                            <tr>
                            <td align="center">
                                <asp:Button ID="btnSubmit" runat="server" Text="Submit" ValidationGroup="grpValidate" OnClick="btnSubmit_Click" />
                                <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" /></td>
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
              &nbsp;</td>
          <td>
          </td>
      </tr>
                <tr>
                    <td style="height: 129px">
                    </td>
                    <td style="height: 129px">
                        <asp:SqlDataSource ID="sdsVerifier" runat="server" ProviderName="System.Data.OleDb"
                     SelectCommand="SELECT E.EMP_ID, E.FirstName + ' ' + E.LastName AS Name
                     FROM EMPLOYEE_MASTER E INNER JOIN USER_MASTER U ON E.EMP_ID = U.userid Inner JOIN
                     USER_ROLE UR ON E.EMP_ID = UR.USER_ID where UR.Role_ID IN(3) order by E.FirstName "                     
                     ConnectionString="<%$ ConnectionStrings:CMConnectionString %>">
                       
                    </asp:SqlDataSource>
                    <asp:SqlDataSource ID="sdsVerification" runat="server" ProviderName="System.Data.OleDb"
                     SelectCommand="SELECT Case_status_ID,Status_Code,Status_Name from Case_status_Master"                     
                     ConnectionString="<%$ ConnectionStrings:CMConnectionString %>"></asp:SqlDataSource>
                     <asp:SqlDataSource ID="sdsVeriType" runat="server" ProviderName="System.Data.OleDb"
                     SelectCommand="select verification_type_Id,verification_type from verification_type_master where verification_type_code in('RV','BV')"                     
                     ConnectionString="<%$ ConnectionStrings:CMConnectionString %>"></asp:SqlDataSource>
                        <asp:ValidationSummary ID="vsValidate" runat="server" ShowMessageBox="True"
                            ShowSummary="False" ValidationGroup="grpValidate" /><asp:CustomValidator ID="cvVerifier" runat="server" 
                   ErrorMessage="Please select verifier." ValidationGroup="grpValidate" Display="None" ClientValidationFunction="ClientValidate"
                   ControlToValidate="ddlVerifier" OnServerValidate="cvSelectverifier_ServerValidate"></asp:CustomValidator> 
                        <asp:RegularExpressionValidator ID="revAttemptDate1" runat="server" ControlToValidate="txtAttemptDate1"
                            Display="None" ErrorMessage="Please enter valid date format for first attempt."
                            SetFocusOnError="True" ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.]([A-Za-z]{3})[- /.](19|20|21)\d\d"
                            ValidationGroup="grpValidate"></asp:RegularExpressionValidator><asp:RegularExpressionValidator ID="revAttemptDate2" runat="server" ControlToValidate="txtAttemptDate2"
                            Display="None" ErrorMessage="Please enter valid date format for second attempt."
                            SetFocusOnError="True" ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.]([A-Za-z]{3})[- /.](19|20|21)\d\d"
                            ValidationGroup="grpValidate"></asp:RegularExpressionValidator><asp:RegularExpressionValidator ID="revAttemptDate3" runat="server" ControlToValidate="txtAttemptDate3"
                            Display="None" ErrorMessage="Please enter valid date format for third attempt."
                            SetFocusOnError="True" ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.]([A-Za-z]{3})[- /.](19|20|21)\d\d"
                            ValidationGroup="grpValidate"></asp:RegularExpressionValidator><asp:RegularExpressionValidator ID="revAttemptTime1" runat="server" ControlToValidate="txtAttemptTime1"
                            Display="None" ErrorMessage="Please enter valid time format for first attempt."
                            SetFocusOnError="True" ValidationExpression="(0[1-9]|1[0-2])[:]([0-5][0-9])"
                            ValidationGroup="grpValidate"></asp:RegularExpressionValidator><asp:RegularExpressionValidator ID="revAttemptTime2" runat="server" ControlToValidate="txtAttemptTime2"
                            Display="None" ErrorMessage="Please enter valid time format for second attempt."
                            SetFocusOnError="True" ValidationExpression="(0[1-9]|1[0-2])[:]([0-5][0-9])"
                            ValidationGroup="grpValidate"></asp:RegularExpressionValidator><asp:RegularExpressionValidator ID="revAttemptTime3" runat="server" ControlToValidate="txtAttemptTime3"
                            Display="None" ErrorMessage="Please enter valid time format for third attempt."
                            SetFocusOnError="True" ValidationExpression="(0[1-9]|1[0-2])[:]([0-5][0-9])"
                            ValidationGroup="grpValidate"></asp:RegularExpressionValidator></td>
                    <td style="height: 129px" >
                    </td>
                </tr>
            </table>
</asp:Content>