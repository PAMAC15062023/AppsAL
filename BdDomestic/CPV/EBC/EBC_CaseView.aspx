<%@ Page Language="C#" MasterPageFile="~/CPV/EBC/EBC_MasterPage.master" Theme="SkinFile" AutoEventWireup="true" CodeFile="EBC_CaseView.aspx.cs" Inherits="EBC_EBC_CaseView" %>
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
<fieldset ><legend class="FormHeading">EBC Case View</legend>
<table style="width: 100%" cellpadding="0" cellspacing="0" >
               
      <tr>
          <td>
          </td>
          <td>
          <table id="tblCreditCard" width="100%" cellpadding="0" cellspacing="0">
          <tr>
              <td>
                <table id="tblCCSearch" width="100%" cellpadding="0" cellspacing="0" >
                    <tr>
                        <td>
              <asp:Label ID="lblMsg" runat="server" meta:resourcekey="lblMsgResource1" SkinID="lblError"></asp:Label></td>
                        <td>
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                    </tr>
                <tr>
                <td>Ref No</td>
                    <td><asp:TextBox ID="txtRefNo" runat="server" MaxLength="50" SkinID="txtSkin" ></asp:TextBox></td><td>Name</td><td>
                    <asp:TextBox ID="txtName" runat="server" MaxLength="200" SkinID="txtSkin" ></asp:TextBox></td>
                    <td>
                        <asp:CheckBox ID="chkName" runat="server"  Text="Absolute" SkinID="chkSkin" />
                    </td>
                    <td></td>
                </tr>
                <tr>
                <td>From Date</td>
                <td>
                <asp:TextBox ID="txtFromDate" runat="server" MaxLength="10" SkinID="txtSkin" ></asp:TextBox>
                <img id="imgRecDate"  alt="Calendar" src="../../Images/SmallCalendar.gif" onclick="popUpCalendar(this, document.all.<%=txtFromDate.ClientID%>, 'dd/mm/yyyy', 0, 0);" />
                </td>
                <td>To Date</td><td>
                    <asp:TextBox ID="txtToDate" runat="server" MaxLength="10" SkinID="txtSkin" ></asp:TextBox>
                    <img id="Img1"  alt="Calendar" src="../../Images/SmallCalendar.gif" onclick="popUpCalendar(this, document.all.<%=txtToDate.ClientID%>, 'dd/mm/yyyy', 0, 0);" /></td>
                    <td><asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" ValidationGroup="grpValidate" SkinID="btnSearchSkin"  OnClientClick="return datevalidation();"/>
                    </td>
                    <td><asp:Button ID="btnNewCase" runat="server" Text="New Case" OnClick="btnNewCase_Click" SkinID="btnAddNewSkin"   />
                        </td>
                
                </table>
                </td>
          </tr> 
          <tr>
          
          <td>          
          <table id="tblCreditCardView" width="100%">
          <tr><td>
              <asp:GridView ID="gvEBC" AllowSorting="true" AllowPaging="true" PageSize="15" DataSourceID="sdsEBC" runat="server" AutoGenerateColumns="False" OnRowCommand="gvEBC_RowCommand" OnRowDataBound="gvEBC_RowDataBound" meta:resourcekey="gvCreditCardResource1" SkinID="gridviewNoSort" Width="100%" >
                  <Columns>
                      <asp:BoundField ReadOnly="True" DataField="Case_ID" HeaderText="Case_ID" SortExpression="Case_ID"  />
                      <asp:BoundField ReadOnly="True" DataField="Ref_No" HeaderText="Ref No" SortExpression="Ref_No" />
                      <asp:BoundField ReadOnly="True" DataField="Name" HeaderText="Name" SortExpression="Name"  />
                      <asp:BoundField ReadOnly="True" DataField="Case_Rec_DateTime" SortExpression="Case_Rec_DateTime" HeaderText="Received DateTime" HtmlEncode="False" DataFormatString="{0:dd/MM/yyyy hh:mm tt}" />
                      <asp:TemplateField meta:resourcekey="TemplateFieldResource1"> 
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkEditEBC" runat="server" CommandArgument='<%# Eval("Case_ID") %>'
                            CommandName="Edit" ><img src="../../Images/icon_edit.gif" alt="Edit" style="border:0" />
                            </asp:LinkButton>
                        </ItemTemplate>
                        <ItemStyle Width="20px" />
                    </asp:TemplateField>
                    <asp:TemplateField meta:resourcekey="TemplateFieldResource2"> 
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkDeleteEBC" runat="server" CommandArgument='<%# Eval("Case_ID") %>'
                            CommandName="DeleteEBC" ><img src="../../Images/icon_delete.gif" alt="Delete" style="border:0" />
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
                    <td style="height: 43px">
                    </td>
                    <td style="height: 43px">
                        <asp:SqlDataSource ID="sdsEBC" runat="server" ProviderName="System.Data.OleDb"
                     SelectCommand="SELECT Case_ID,REF_NO, CASE_REC_DATETIME, (FIRST_NAME+' '+MIDDLE_NAME+' '+LAST_NAME) as NAME, ADD_LINE_1, ADD_LINE_2, ADD_LINE_3, CITY, PIN_CODE, PHONE1, PHONE2 FROM CPV_EBC_CASE_DETAILS where  ([Centre_ID]=? and [Client_ID]=? and send_datetime is null)"
                     ConnectionString="<%$ ConnectionStrings:CMConnectionString %>">
                       <SelectParameters>
                       <asp:SessionParameter Name="CentreId" SessionField="CentreId" Type="String" />  
                         <asp:SessionParameter Name="ClientId" SessionField="ClientId" Type="String" />                          
                       </SelectParameters> 
                    </asp:SqlDataSource>
                        <asp:RegularExpressionValidator ID="revFromDate" runat="server" ControlToValidate="txtFromDate"
                            Display="None" ErrorMessage="Please enter valid Date Format for From Date."
                            SetFocusOnError="True" ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d"
                            ValidationGroup="grpValidate" meta:resourcekey="revFromDateResource1"></asp:RegularExpressionValidator>
                        <asp:RegularExpressionValidator ID="revTpDate" runat="server" ControlToValidate="txtToDate"
                            Display="None" ErrorMessage="Please enter valid Date Format for To Date." SetFocusOnError="True"
                            ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d"
                            ValidationGroup="grpValidate" meta:resourcekey="revTpDateResource1"></asp:RegularExpressionValidator></td>
                    <td style="height: 43px">
                    </td>
                </tr>
            </table>
            </fieldset>
</asp:Content>



