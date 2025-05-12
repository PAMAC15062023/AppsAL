<%@ Page Language="C#" MasterPageFile="CC_MasterPage.master" AutoEventWireup="true" CodeFile="CC_BatchDedup.aspx.cs" Inherits="Import" Theme="SkinFile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="C1" Runat="Server">
<table width="99%" border="0" cellspacing="0" cellpadding="0"  align="center">

<tr> 
    <td align="center" width="100%">
    <fieldset><legend class="FormHeading">Dedup Search</legend>
<table width="100%">
         <tr>
            <td>
                <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
                <asp:Panel ID="pnlDedup" runat="server" Visible="true" Width="100%">
                              <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0" class="shadow">
                
            <tr > 
                <td >     
                <!--Dedupe Start-->           
                    <table width="100%" border="0" cellpadding="0" cellspacing="1">
                        <tr>
                            <td valign="top" class="label">
                                <table width="100%">
                                    <tr>
                                        <td align="left">From Date:</td>
                                        <td align="left"><asp:TextBox ID="txtFromDate" runat="server" SkinID="txtSkin" MaxLength="11"></asp:TextBox>
                                            <img src="../../Images/SmallCalendar.gif" alt="" onclick="popUpCalendar(this, document.all.<%=txtFromDate.ClientID%>, 'dd-mmm-yyyy', 0, 0);" /><asp:RequiredFieldValidator
                                                ID="RFVALC_Date" runat="server" ControlToValidate="txtFromDate" CssClass="txtError"
                                                Display="None" ErrorMessage="From Date should not be blank" SetFocusOnError="True"
                                                ValidationGroup="grpImport"></asp:RequiredFieldValidator><asp:RegularExpressionValidator
                                                    ID="REVALC_Date" runat="server" ControlToValidate="txtFromDate" CssClass="txtError"
                                                    Display="None" ErrorMessage="Enter valid date format for From Date" SetFocusOnError="True"
                                                    ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.]([A-Za-z]{3})[- /.](19|20|21)\d\d"
                                                    ValidationGroup="grpImport"></asp:RegularExpressionValidator></td>
                                        <td align="left">To Date:</td>
                                        <td align="left"><asp:TextBox ID="txtToDate" runat="server" SkinID="txtSkin" MaxLength="11"></asp:TextBox>
                                            <img src="../../Images/SmallCalendar.gif" alt="" onclick="popUpCalendar(this, document.all.<%=txtToDate.ClientID%>, 'dd-mmm-yyyy', 0, 0);" />
                                            &nbsp;&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                                ControlToValidate="txtToDate" CssClass="txtError" Display="None" ErrorMessage="To Date should not be blank"
                                                SetFocusOnError="True" ValidationGroup="grpImport"></asp:RequiredFieldValidator><asp:RegularExpressionValidator
                                                    ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtToDate"
                                                    CssClass="txtError" Display="None" ErrorMessage="Enter valid date format for To Date"
                                                    SetFocusOnError="True" ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.]([A-Za-z]{3})[- /.](19|20|21)\d\d"
                                                    ValidationGroup="grpImport"></asp:RegularExpressionValidator>
                                            <asp:CheckBox ID="ckhSoundex" runat="server" Text="SoundX" Visible="False" /></td>
                                    </tr>

                                     <tr>
                                        <td align="left">Dedup search with</td>
                                        <td align="left"><asp:RadioButton ID="rdbNegative" GroupName="IsNegative" Checked="true" Text="Negative" runat="server" SkinID="rdbSkin" />
                                            &nbsp;
                                            <asp:RadioButton ID="rdbPositive" GroupName="IsNegative" Text="All" runat="server" SkinID="rdbSkin" /></td>
                                        <td align="left"></td>
                                        <td align="left" valign="top" class="label">                                 
                                            <asp:Button ID="btnDedupeSearch" CssClass="label" runat="server" OnClick="btnDedupeSearch_Click" SkinID="btnDedupSkin" ValidationGroup="grpImport" />&nbsp;
                                            <asp:Button ID="btnExportToExcel" CssClass="label" runat="server" OnClick="btnExportToExcel_Click" SkinID="btnExpToExlSkin" Visible="False" />
                                        </td>
                                    </tr>
                                </table>
                                <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="txtError"
                                    DisplayMode="List" ShowMessageBox="True" ShowSummary="False" ValidationGroup="grpImport" />
                            </td>
                        </tr>
                        <tr>
                            <td align="left" valign="top">
                                <asp:PlaceHolder ID="plhDedupe" runat="server">
                                    
                                </asp:PlaceHolder>
                            </td>
                        </tr>
                    </table>
                    <!--Dedupe End-->    
                </td>
              </tr>                          

           </table>
                </asp:Panel>
            </td>
         </tr>
</table>
</fieldset></td></tr></table>
<asp:SqlDataSource id="SDSCases" runat="server" SelectCommand="SELECT [CASE_TYPE_CODE], [CASE_TYPE], [CASE_TYPE_ID] FROM [CASE_TYPE_MASTER]" ConnectionString="<%$ ConnectionStrings:CMConnectionString %>"></asp:SqlDataSource>
<asp:SqlDataSource ID="SDSViewCases" runat="server" ConnectionString="<%$ ConnectionStrings:CMConnectionString %>">
</asp:SqlDataSource> 
    <asp:HiddenField ID="hdnBatchID" runat="server" />
</asp:Content>

