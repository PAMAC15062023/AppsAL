<%@ Page Language="C#" MasterPageFile="IDOC_MasterPage.master" AutoEventWireup="true" Theme="SkinFile" CodeFile="IDOC_CaseView.aspx.cs" Inherits="CPV_IDOC_IDOC_CaseView" %>
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
<table border="0" cellpadding="0" cellspacing="0" width="99%" align="center">
<tr><td>
<fieldset ><legend class="FormHeading">View Cases</legend>
  <table style="width: 99%" cellpadding="0" cellspacing="0" border="0">
       
      <tr>
          <td>
          </td>
          <td>
          <table id="tblCreditCard" width="100%" cellpadding="0" cellspacing="0">
          <tr>
              <td>
                <table id="tblCCSearch" width="100%" cellpadding="0" cellspacing="0" border="0">
                <tr>
                <td>Ref No</td>
                    <td><asp:TextBox ID="txtRefNo" runat="server" MaxLength="50" SkinID="txtSkin"></asp:TextBox></td><td>Name</td><td>
                    <asp:TextBox ID="txtName" runat="server" MaxLength="200" SkinID="txtSkin"></asp:TextBox>
                        <asp:CheckBox ID="chkName" runat="server"  Text="Absolute" SkinID="chkSkin"/></td>
                    <td>
                        &nbsp;Case ID</td>
                    <td>
                        <asp:TextBox ID="txtCaseID" runat="server" MaxLength="15" SkinID="txtSkin"></asp:TextBox></td>
                </tr>
                <tr>
                <td>From Date</td>
                <td>
                <asp:TextBox ID="txtFromDate" runat="server" MaxLength="10" SkinID="txtSkin"></asp:TextBox>
                <img id="imgRecDate"  alt="Calendar" src="../../Images/SmallCalendar.gif" onclick="popUpCalendar(this, document.all.<%=txtFromDate.ClientID%>, 'dd/mm/yyyy', 0, 0);" />
                </td>
                <td>To Date</td><td>
                    <asp:TextBox ID="txtToDate" runat="server" MaxLength="10" SkinID="txtSkin"></asp:TextBox>
                    <img id="Img1"  alt="Calendar" src="../../Images/SmallCalendar.gif" onclick="popUpCalendar(this, document.all.<%=txtToDate.ClientID%>, 'dd/mm/yyyy', 0, 0);" /></td>
                    <td><asp:Button ID="btnSearch" runat="server" Text="Search" SkinID="btnSearchSkin" OnClick="btnSearch_Click" ValidationGroup="grpValidate" OnClientClick="return datevalidation();" />
                    </td>
                    <td><asp:Button ID="btnNewCase" runat="server" Text="New Case"  SkinID="btnNewCaseSkin" OnClick="btnNewCase_Click"   />
                        </td>
                </tr>
                </table>
                </td>
          </tr> 
          <tr><td><br /></td></tr>            
          <tr>
          
          <td>          
          <table id="tblCreditCardView" width="100%">
          <tr><td>
              <asp:Label ID="lblMsg" runat="server" CssClass="LabelError" Visible="False" SkinID="lblError"></asp:Label></td></tr>
          <tr><td>
              
              <asp:GridView ID="gvIDOC" runat="server" AllowPaging="true" AllowSorting="true"
                AutoGenerateColumns="False" BackColor="White" BorderColor="Transparent" BorderStyle="Solid" OnRowCommand="gvIDOC_RowCommand" OnRowDataBound="gvIDOC_RowDataBound" 
                BorderWidth="1px" CellPadding="1" CellSpacing="1" DataSourceID="sdsCreditCard" Font-Bold="False"
                Font-Names="Arial" Font-Size="8pt" ForeColor="Black" GridLines="None" meta:resourcekey="gvCCResource1"
                PageSize="15" Width="100%">
                <FooterStyle BackColor="#D0D5D8" ForeColor="White" Height="20px" />
                <RowStyle BackColor="#E5E5E5" />
                <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#D0D5D8" ForeColor="Black" HorizontalAlign="Center" />
                <HeaderStyle BackColor="#D0D5D8" Font-Bold="True" Font-Names="Arial" Font-Size="8pt"
                    ForeColor="Black" Height="20px" />
                <AlternatingRowStyle BackColor="White" />
                  <Columns>
                      <asp:BoundField ReadOnly="True" DataField="Case_ID" HeaderText="Case_ID" Visible="true" SortExpression="Case_ID" />
                      <asp:BoundField ReadOnly="True" DataField="Ref_No" HeaderText="Ref No" SortExpression="Ref_No" />                      
                      <asp:BoundField ReadOnly="True" DataField="Name" HeaderText="Name" SortExpression="Name"  />
                      <asp:BoundField ReadOnly="True" DataField="VERIFICATION_CODE" HeaderText="VERIFICATION_CODE TYPE" SortExpression="VERIFICATION_CODE"  />
                      <asp:BoundField ReadOnly="True" DataField="Case_Rec_DateTime" SortExpression="Case_Rec_DateTime" HeaderText="Received DateTime" HtmlEncode="false" DataFormatString="{0:dd/MM/yyyy hh:mm tt}" />
                      <asp:BoundField ReadOnly="True" DataField="Department" SortExpression="Department" HeaderText="Department"  />
                      <asp:BoundField ReadOnly="True" DataField="Designation" SortExpression="Designation" HeaderText="Designation"  />
                     <asp:TemplateField meta:resourcekey="TemplateFieldResource1"> 
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkEditIDOC" runat="server" CommandArgument='<%# Eval("Case_ID") %>'
                            CommandName="Edit" ><img src="../../Images/icon_edit.gif" alt="Edit" style="border:0" />
                            </asp:LinkButton>
                        </ItemTemplate>
                        <ItemStyle Width="20px" />
                    </asp:TemplateField>
                    <asp:TemplateField meta:resourcekey="TemplateFieldResource2"> 
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkDeleteIDOC" runat="server" CommandArgument='<%# Eval("Case_ID") %>'
                            CommandName="DeleteIDOC" ><img src="../../Images/icon_delete.gif" alt="Delete" style="border:0" />
                            </asp:LinkButton>
                        </ItemTemplate>
                        <ItemStyle Width="20px" />
                    </asp:TemplateField>
                  </Columns>                 
              </asp:GridView>
              </td></tr>
              
              </table>
              </td>
              </tr>
              
              </table>
              
          </td>
          <td>
          </td>
      </tr>
                <tr>
                    <td >
                    </td>
                    <td >
                        <asp:SqlDataSource ID="sdsCreditCard" runat="server" ProviderName="System.Data.OleDb"
                     SelectCommand="SELECT Case_ID,REF_NO,VERIFICATION_CODE,CASE_REC_DATETIME, (ISNULL(TITLE,'')+ ' ' +ISNULL(FIRST_NAME,'')+' '+ISNULL(MIDDLE_NAME,'')+' '+ISNULL(LAST_NAME,'')) as NAME, DOB, 
                     RES_ADD_LINE_1, RES_ADD_LINE_2, RES_ADD_LINE_3, RES_CITY, RES_PIN_CODE, RES_LAND_MARK, RES_PHONE, 
                     OFF_ADD_LINE_1, OFF_ADD_LINE_2, OFF_ADD_LINE_3, OFF_CITY, OFF_PIN_CODE, OFF_PHONE, OFF_EXTN, DESIGNATION, 
                     DEPARTMENT FROM CPV_IDOC_CASE_DETAILS                      
                     WHERE SEND_DATETIME IS NULL AND ([Client_Id] = ?) AND ([Centre_Id] = ?) ORDER BY CASE_ID DESC"
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
                    <asp:ValidationSummary ID="vsValidate" runat="server" CssClass="compulsary" ShowMessageBox="True"
                            ShowSummary="False" ValidationGroup="grpValidate" />
                            </td>
                    <td style="height: 43px">
                    </td>
                </tr>
            </table>
            </fieldset>
            </td></tr></table>
</asp:Content>



