<%@ Page Language="C#" MasterPageFile="~/FETracking/FETracking.master" AutoEventWireup="true" Theme="SkinFile" CodeFile="FECheckOut.aspx.cs" Inherits="FETracking_FECheckOut"%>
<asp:Content ID="Content1" ContentPlaceHolderID="C1" Runat="Server">
<table border="0" cellpadding="0" cellspacing="0" width="99%">
<tr><td style="padding-left:10px">
<fieldset><legend class="FormHeading">Check-Out</legend>
<table border="0" cellpadding="0" cellspacing="0" width="100%">

<tr>
    <td align="left" style="height: 24px" width="3%">
    </td>
<td align="left" style="height: 24px; width: 13%;">
   FE Code <span style="color: #ff0033">*</span></td>
<td style="width: 1%" >:</td>
<td width="20%">    <asp:TextBox ID="txtFE_Code" runat="server" MaxLength="10" SkinID="txtSkin"></asp:TextBox>    
</td>
<td valign ="top" >
    <asp:Button ID="btnGet" runat="server"  Text="Get Name" ValidationGroup="vFE" SkinID="btn" OnClick="btnGet_Click" />&nbsp;
</td>
<td ></td>
</tr>
<tr>
    <td align="left" width="3%" style="height: 23px">
    </td>
<td align="left" style="width: 13%; height: 23px">
    FE Name
</td>
<td style="width: 1%; height: 23px;">
    :</td>
<td colspan="2" style="height: 23px" >
    <asp:TextBox ID="txtFE_Name" runat="server" MaxLength="10" SkinID="txtSkin" ReadOnly="True"></asp:TextBox>
    &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;&nbsp;
    <asp:Label ID="lbPending" runat="server" CssClass="lblSkin" Font-Bold="True" Text="Cases Issued:"
        Visible="False"></asp:Label>&nbsp;<asp:Label ID="lbCount" runat="server" CssClass="lblSkin"
            Font-Bold="True" Font-Size="12pt" Visible="False"></asp:Label></td>
<td style="height: 23px"></td>
</tr>
    <tr>
        <td align="left" width="3%">
        </td>
        <td align="left" style="width: 13%" >
            Case Staus &nbsp;</td>
        <td style="width: 1%" >
            :</td>
        <td colspan="2" >
            
            <asp:DropDownList ID="ddlCaseStatus" runat="server" SkinID="ddlSkin" Width="130px">
                <asp:ListItem>Fresh</asp:ListItem>
                <asp:ListItem>ReVisit</asp:ListItem>
            </asp:DropDownList></td>
        <td >
        </td>
    </tr>
    
    
    <tr>
        <td align="left" width="3%">
        </td>
        <td align="left" style="width: 13%">
            Date of CheckOut 
        </td>
        <td  style="width: 1%">
            :</td>
        <td >
            <asp:TextBox ID="txtDate" runat="server" MaxLength="10" SkinID="txtSkin"></asp:TextBox>
            <img id="imgDate" alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                src="../Images/SmallCalendar.gif" /></td>
        <td style="height: 14px" valign ="top">
            <asp:TextBox ID="txtTime" runat="server" CssClass="textbox" MaxLength="5" SkinID="txtSkin" Width="40px"></asp:TextBox>&nbsp;<asp:DropDownList
                    ID="ddlTimeType" runat="server" CssClass="combo" SkinID="ddlSkin">
                    <asp:ListItem Selected="True">AM</asp:ListItem>
                    <asp:ListItem>PM</asp:ListItem>
                     
                </asp:DropDownList>
                [hh:mm] &nbsp;&nbsp;
                <asp:RequiredFieldValidator  ID="Rvdate" runat="server" ControlToValidate="txtDate" CssClass="txtError"
                        Display="None" ErrorMessage="Enter the date !" SetFocusOnError="True"
                        ValidationGroup="vFECheckout"></asp:RequiredFieldValidator>
                
                <asp:RegularExpressionValidator ID="REVALC_Date" runat="server"
                    ControlToValidate="txtDate" CssClass="txtError" Display="None" ErrorMessage="Enter valid date format "
                    SetFocusOnError="True" ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d"
                    ValidationGroup="vFECheckout"></asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ID="RFVACT_Time" runat="server" ControlToValidate="txtTime" CssClass="txtError"
                        Display="None" ErrorMessage="Enter the Time !" SetFocusOnError="True"
                        ValidationGroup="vFECheckout"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator
                            ID="REVACT_Time" runat="server" ControlToValidate="txtTime" CssClass="txtError"
                            Display="None" ErrorMessage="Enter valid  Time!" SetFocusOnError="True"
                            ValidationExpression="(0[1-9]|1[0-2])[:]([0-5][0-9])" ValidationGroup="vFECheckout"></asp:RegularExpressionValidator></td>
        <td>
        </td>
    </tr>
    <tr>
        <td align="left" style="height: 24px" width="3%">
        </td>
        <td align="left" style="height: 24px; width: 13%;">
            Scan Barcode <span style="color: #ff0033">*</span>
        </td>
        <td  style="width: 1%; height: 24px;">
            :</td>
        <td colspan="2" style="height: 24px">
            <asp:TextBox ID="txtbarcode" runat="server" MaxLength="200" 
                SkinID="txtSkin" OnTextChanged="txtbarcode_TextChanged"  AutoPostBack="True" ></asp:TextBox></td>
        <td style="height: 24px">
        </td>
    </tr>
    <tr>
        <td align="left" width="3%" style="height: 14px">
        </td>
        <td align="left" style="height: 14px; width: 13%;">
        </td>
        <td  style="height: 14px">
        </td>
        <td colspan="3" style="height: 14px">
        <asp:Label ID="lblMsg" runat="server" SkinID="lblErrormsg"  Visible="False"></asp:Label></td>
        
    </tr>
    <tr>
        <td align="left" colspan="1" width="3%">
        </td>
        <td align="left" colspan="4">
        </td>
        <td>
        </td>
    </tr>
    <tr>
        <td align="left" style="height: 70px" >
        </td>
        <td colspan="5" style="height: 70px"> 
        <asp:Panel ID="pnlReassign" runat="server"  Visible="false" BorderStyle="Solid" BorderWidth="2px" BorderColor="black"  Height="50px" Width="700px">                   
             <table  width="100%" cellpadding="0" cellspacing="0">
                <tr>
                <td>
                    &nbsp;
            <asp:Label ID="lblReassign" runat="server" Font-Bold="True" SkinID="lblErrormsg"></asp:Label></td>
                </tr>             
                 <tr>
                     <td>
                   <asp:Button ID="btnOk" runat="server" Text="Ok" OnClick="btnOk_Click" Width="59px" />
                      
                   <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" /></td>
                 </tr>
            </table>
         </asp:Panel>
         </td>                                     
    </tr>
    <tr>
        <td align="left" style="height: 70px">
        </td>
        <td colspan="5" style="height: 70px">
            <asp:GridView ID="gvIssued" runat="server" SkinID="gridviewNoSort">
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSourceCheckOut" runat="server" ConnectionString="<%$ ConnectionStrings:CMConnectionString %>"
            ProviderName="<%$ ConnectionStrings:CMConnectionString.ProviderName %>" 
            SelectCommand=""></asp:SqlDataSource>
        </td>
    </tr>
 <%--<asp:RequiredFieldValidator ID="rfvtxtHolidayDate" runat="server" ControlToValidate="txtHDate" ValidationGroup="vHoliday"
                        ErrorMessage="Please Select Holiday Date!"  Display="none"   SetFocusOnError="true"   ></asp:RequiredFieldValidator>--%>
      
	 <asp:RequiredFieldValidator ID="rfvtxtFECODE" runat="server" ControlToValidate="txtFE_Code" ValidationGroup="vFE"
                                      ErrorMessage="Please Enter FE_CODE !"  Display="none" SetFocusOnError="true" ></asp:RequiredFieldValidator><asp:ValidationSummary ID="vsValidateuser" runat="server" ValidationGroup="vFE"
                      ShowMessageBox="True" ShowSummary="False" /> 
                      
                       <asp:RequiredFieldValidator ID="rfvtxtFECODE1" runat="server" ControlToValidate="txtFE_Code" ValidationGroup="vFECheckout"
                                      ErrorMessage="Please Enter FE_CODE !"  Display="none" SetFocusOnError="true" ></asp:RequiredFieldValidator><asp:RequiredFieldValidator ID="rfvtxtbarcode" runat="server" ControlToValidate="txtbarcode" ValidationGroup="vFECheckout"
                                      ErrorMessage="Please scan barcode !"  Display="none" SetFocusOnError="true" ></asp:RequiredFieldValidator><asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="vFECheckout"
                      ShowMessageBox="True" ShowSummary="False" /> 
</table>    
</fieldset>  
 </td></tr></table>
</asp:Content>

