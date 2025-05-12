
<%@ Page Language="C#" MasterPageFile="CC_MasterPage.master" AutoEventWireup="true" Theme="SkinFile" CodeFile="CC_CaseView.aspx.cs" Inherits="CC_CC_CaseView" %>
<asp:Content ID="Content1" ContentPlaceHolderID="C1" Runat="Server">
<script language="javascript" type="text/jscript">
function datevalidation()
{

var text1=(document.getElementById("<%=txtFromDate.ClientID%>")).value;
var text2=(document.getElementById("<%=txtToDate.ClientID%>")).value;

if(text1!="" && text2=="")
{
    alert("Please enter To date");
    return false;
}
if(text2!="" && text1=="")
{
    alert("Please enter From date");
    return false;
}
}
</script>
<table border="0" cellpadding="0" cellspacing="0" width="99%">
<tr><td style="padding-left:10px">
  <fieldset><legend class="FormHeading">View Cases</legend>
<table border="0" cellpadding="1" cellspacing="0" width="99%" id="TABLE2"> 
 <tr>
 <td>Ref No</td>
 <td>:</td>
 <td><asp:TextBox ID="txtRefNo" runat="server" MaxLength="50"  Columns="30" SkinID="txtSkin" ></asp:TextBox></td>
 <td>Name</td>
 <td>:</td>
 <td><asp:TextBox ID="txtName" runat="server" MaxLength="50" Columns="30" SkinID="txtSkin"></asp:TextBox></td>
 <td></td>
 <td></td>
 <td><asp:CheckBox ID="chkName" runat="server"  Text="Absolute"  SkinID="chkSkin"/></td>
 </tr>
 <tr>
 <td>From Date</td>
 <td>:</td>
 <td><asp:TextBox ID="txtFromDate" runat="server" MaxLength="10" SkinID="txtSkin" Columns="12" ></asp:TextBox>
                <img id="imgRecDate"  alt="Calendar" src="../../Images/SmallCalendar.gif" onclick="popUpCalendar(this, document.all.<%=txtFromDate.ClientID%>, 'dd/mm/yyyy', 0, 0);" /></td>
 <td>To Date</td>
 <td>:</td>
 <td><asp:TextBox ID="txtToDate" runat="server" MaxLength="10" SkinID="txtSkin" Columns="12" ></asp:TextBox>
                    <img id="Img1"  alt="Calendar" src="../../Images/SmallCalendar.gif" onclick="popUpCalendar(this, document.all.<%=txtToDate.ClientID%>, 'dd/mm/yyyy', 0, 0);" /></td>
 <td></td>
 <td></td>
 <td><asp:Button ID="btnSearch" runat="server" Text="Search"  SkinID="btnSearchSkin" ValidationGroup="grpValidate" OnClick="btnSearch_Click" OnClientClick="return datevalidation();"/>
     <asp:Button ID="btnNewCase" runat="server" Text="New Case"  SkinID="btnNewCaseSkin" OnClick="btnNewCase_Click"  /></td>
 </tr>
 <tr>
 <td colspan="9"><asp:Label ID="lblMsg" runat="server" meta:resourcekey="lblMsgResource1" SkinID="lblSkin"></asp:Label></td>
 </tr>
 <tr>
 <td colspan="9" >
 <asp:GridView ID="gvCreditCard" AllowSorting="True" AllowPaging="True"  OnRowCommand="gvCreditCard_RowCommand"  OnRowDataBound="gvCreditCard_RowDataBound" DataSourceID="sdsCreditCard" runat="server" AutoGenerateColumns="False"  
 meta:resourcekey="gvCreditCardResource1" BackColor="White" BorderColor="Transparent" BorderWidth="1px" CellPadding="1" CellSpacing="1" ForeColor="Black" GridLines="None" BorderStyle="Solid" Font-Bold="False" Font-Names="Arial" Font-Size="8pt" Width="100%" >
                  <FooterStyle BackColor="#D0D5D8" Height="20px"  ForeColor="White" />
    <RowStyle BackColor="#E5E5E5"  />
    <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
    <PagerStyle BackColor="#D0D5D8" ForeColor="Black" HorizontalAlign="Center" />
    <HeaderStyle BackColor="#D0D5D8" Font-Bold="True" ForeColor="Black" Height="20px" Font-Names="Arial" Font-Size="8pt" />
    <AlternatingRowStyle BackColor="White" />
                  <Columns>
                      <asp:BoundField ReadOnly="True" DataField="Case_ID" HeaderText="Case_ID" Visible="true"  />
                      <asp:BoundField ReadOnly="True" DataField="Ref_No" HeaderText="Ref No" SortExpression="Ref_No" />
                      <asp:BoundField ReadOnly="True" DataField="Name" HeaderText="Name" SortExpression="Name"  />
                      <asp:BoundField ReadOnly="True" DataField="Case_Rec_DateTime" SortExpression="Case_Rec_DateTime" HeaderText="Received DateTime" HtmlEncode="False" DataFormatString="{0:dd/MM/yyyy hh:mm tt}" />
                      <asp:BoundField ReadOnly="True" DataField="Department" SortExpression="Department" HeaderText="Department"  />
                      <asp:BoundField ReadOnly="True" DataField="Designation" SortExpression="Designation" HeaderText="Designation"  />
                     <asp:TemplateField meta:resourcekey="TemplateFieldResource1"> 
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkEditCreditCard" runat="server" CommandArgument='<%# Eval("Case_ID") %>'
                            CommandName="Edit" meta:resourcekey="lnkEditCreditCardResource1" ><img src="../../Images/icon_edit.gif" alt="Edit" style="border:0" />
                            </asp:LinkButton>
                        </ItemTemplate>
                        <ItemStyle Width="20px" />
                    </asp:TemplateField>
                    <asp:TemplateField meta:resourcekey="TemplateFieldResource2"> 
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkDeleteCreditCard" runat="server" CommandArgument='<%# Eval("Case_ID") %>'
                            CommandName="DeleteCC" meta:resourcekey="lnkDeleteCreditCardResource1" ><img src="../../Images/icon_delete.gif" alt="Delete" style="border:0" />
                            </asp:LinkButton>
                        </ItemTemplate>
                        <ItemStyle Width="20px" />
                    </asp:TemplateField>
                  </Columns>                 
              </asp:GridView>
 </td>
 </tr>
 <tr>
 <td colspan="9"></td>
 </tr>
 <tr>
 <td colspan="9">
 <asp:SqlDataSource ID="sdsCreditCard" runat="server" ProviderName="<%$ ConnectionStrings:CMConnectionString.ProviderName %>"
     SelectCommand="SELECT CASE_ID, REF_NO, CASE_REC_DATETIME, TITLE, ISNULL(FIRST_NAME,'') + ' ' + ISNULL(MIDDLE_NAME,'') + ' ' + ISNULL(LAST_NAME,'') AS NAME, DOB, RES_ADD_LINE_1, RES_ADD_LINE_2, RES_ADD_LINE_3, RES_CITY, RES_PIN_CODE, RES_LAND_MARK, RES_PHONE, OFF_ADD_LINE_1, OFF_ADD_LINE_2, OFF_ADD_LINE_3, OFF_CITY, OFF_PIN_CODE, OFF_PHONE, OFF_EXTN, DESIGNATION, DEPARTMENT 
     FROM CPV_CC_CASE_DETAILS WHERE SEND_DATETIME IS  NULL AND ([Client_Id] = ?) AND ([Centre_Id] = ?) ORDER BY CASE_ID DESC"
     ConnectionString="<%$ ConnectionStrings:CMConnectionString %>">
      <SelectParameters>
        <asp:SessionParameter Name="ClientId" SessionField="ClientId" Type="String" />                            
        <asp:SessionParameter Name="CentreId" SessionField="CentreId" Type="String" />                             
      </SelectParameters>
     </asp:SqlDataSource>
     
        <asp:RegularExpressionValidator ID="revFromDate" runat="server" ControlToValidate="txtFromDate"
            Display="None" ErrorMessage="Please enter valid Date Format for From Date."
            SetFocusOnError="True" ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d"
            ValidationGroup="grpValidate" ></asp:RegularExpressionValidator>
        <asp:RegularExpressionValidator ID="revTpDate" runat="server" ControlToValidate="txtToDate"
            Display="None" ErrorMessage="Please enter valid Date Format for To Date." SetFocusOnError="True"
            ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d"
            ValidationGroup="grpValidate" ></asp:RegularExpressionValidator>
        <asp:ValidationSummary ID="vsValidateDate" runat="server"  
        ValidationGroup="grpValidate" ShowMessageBox="True" ShowSummary="False" /> 
       </td>
 </tr>
</table>
</fieldset>
   </td></tr>
</table>
</asp:Content>
