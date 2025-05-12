<%@ page language="C#" masterpagefile="~/HDFCBANK/HDFCBANK/MasterPage.master" theme="SkinFile" autoeventwireup="true" inherits="KYC_KYC_CaseView, App_Web_kyc_caseview.aspx.513d3bc3" viewStateEncryptionMode="Always" %>
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
<fieldset ><legend class="FormHeading">View Cases</legend>
  <table style="width: 100%" cellpadding="0" cellspacing="0" border="0">
         
      <tr>
          <td>
          </td>
          <td>
          <table id="tblKYC" width="100%" cellpadding="0" cellspacing="0" border="0">
          <tr>
              <td style="height: 14px">
                </td>
          </tr> 
              <tr>
                  <td style="height: 14px">
                      Client Name &nbsp; :
                      <asp:DropDownList ID="ddlclientname" runat="server" SkinID="ddlSkin" AutoPostBack="True" OnSelectedIndexChanged="ddlclientname_SelectedIndexChanged" ValidationGroup="grpValidate">
                      </asp:DropDownList>&nbsp;</td>
              </tr>
          <tr><td><br /><table border="0" cellpadding="0" cellspacing="0" id="tblCCSearch" width="100%">
              <tr>
                  <td>
                      From Date</td>
                  <td  >
                      <asp:TextBox ID="txtFromDate" runat="server" MaxLength="11" SkinID="txtSkin" ValidationGroup="grpvalidate"></asp:TextBox>
                      <img id="imgRecDate" alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtFromDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                          src="../../Images/SmallCalendar.gif" />
                  </td>
                  <td>
                      To Date</td>
                  <td  >
                      <asp:TextBox ID="txtToDate" runat="server" MaxLength="11" SkinID="txtSkin" ValidationGroup="grpvalidate"></asp:TextBox>
                      <img id="Img1" alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtToDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                          src="../../Images/SmallCalendar.gif" /></td>
                  <td>
                      <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" SkinID="btnSearchSkin"
                          Text="Search" ValidationGroup="grpValidate"/></td>
                  <td >
                      &nbsp;</td>
              </tr>
          </table>
          </td>
          </tr>
              <tr>
                  <td>
                      <table id="tblKYCView" width="100%">
          <tr><td>
              <asp:Label ID="lblMsg" runat="server" meta:resourcekey="lblMsgResource1"></asp:Label></td></tr>
          <tr><td>
              <asp:GridView ID="gvKYC" AllowPaging="True" PageSize="15" DataSourceID="sdsKYC" runat="server" AutoGenerateColumns="False" OnRowCommand="gvKYC_RowCommand" OnRowDataBound="gvKYC_RowDataBound" SkinID="gridviewSkin">
                  <Columns>
                      <asp:BoundField ReadOnly="True" DataField="Case_ID" HeaderText="Case_ID"  />
                      <asp:BoundField ReadOnly="True" DataField="Ref_No" HeaderText="Ref No" />
                      <asp:BoundField ReadOnly="True" DataField="Name" HeaderText="Name"  />
                      <asp:BoundField ReadOnly="True" DataField="Case_Rec_DateTime" HeaderText="Received DateTime" HtmlEncode="False" DataFormatString="{0:dd/MM/yyyy hh:mm tt}"/>
                      <asp:BoundField ReadOnly="True" DataField="Department" HeaderText="Department"  />
                      <asp:BoundField ReadOnly="True" DataField="Designation" HeaderText="Designation"  />
                     <asp:TemplateField meta:resourcekey="TemplateFieldResource1"> 
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkEditKYC" runat="server" CommandArgument='<%# Eval("Case_ID") %>'
                            CommandName="Edit" meta:resourcekey="lnkEditKYCResource1" ><img src="../../Images/icon_edit.gif" alt="Edit" style="border:0" />
                            </asp:LinkButton>
                        </ItemTemplate>
                        <ItemStyle Width="20px" />
                    </asp:TemplateField>
                    <asp:TemplateField meta:resourcekey="TemplateFieldResource2"> 
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkDeleteKYC" runat="server" CommandArgument='<%# Eval("Case_ID") %>'
                            CommandName="DeleteKYC" meta:resourcekey="lnkDeleteKYCResource1" Enabled="False" Visible="False" ><img src="../../Images/icon_delete.gif" alt="Delete" style="border:0" />
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
                    <td style="height: 62px" >
                    </td>
                    <td style="height: 62px" >
                        <asp:SqlDataSource ID="sdsKYC" runat="server" ProviderName="System.Data.OleDb"
                     SelectCommand="Sp_getRecordView" SelectCommandType="StoredProcedure"
                     >
                        <SelectParameters>
                            <asp:SessionParameter Name="@CentreId" SessionField="Centreid" />
                            <asp:ControlParameter ControlID="ddlclientname" Name="@ClientId" PropertyName="SelectedValue" />
                            <asp:SessionParameter Name="@Ref_no" SessionField="Branch_Code" />
                            <asp:SessionParameter DefaultValue="" Name="@Add_By" SessionField="Userid" />
        </SelectParameters> 
                    </asp:SqlDataSource>
                        <asp:HiddenField ID="hdnclientname" runat="server" />
                        &nbsp; &nbsp; &nbsp; &nbsp;
                        <asp:RequiredFieldValidator ID="Rfvddlclient" runat="server" ControlToValidate="ddlclientname"
                            Display="None" ErrorMessage="Please Select Client Name" InitialValue="0" ValidationGroup="grpValidate"></asp:RequiredFieldValidator><asp:ValidationSummary
                                ID="ValidationSummary1" runat="server" CssClass="compulsary" ShowMessageBox="True"
                                ShowSummary="False" ValidationGroup="grpValidate" />
                    </td>
                            <asp:ValidationSummary ID="vsValidate" runat="server" CssClass="compulsary" ShowMessageBox="True"
                            ShowSummary="False" ValidationGroup="grpValidate" />
                    <td style="height: 62px" >
                    </td>
                </tr>
            </table>
            </fieldset >
</asp:Content>


