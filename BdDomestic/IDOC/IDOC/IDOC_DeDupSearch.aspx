<%@ Page Language="C#" MasterPageFile="IDOC_MasterPage.master" AutoEventWireup="true" CodeFile="IDOC_DeDupSearch.aspx.cs" Inherits="IDOC_IDOC_IDOC_DeDupSearch"  Theme="SkinFile"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="C1" Runat="Server">
<table width="99%" border="0" cellspacing="0" cellpadding="0"  align="center">

<tr> 
    <td align="center" width="100%" >
    <fieldset><legend class="FormHeading">Dedup Search</legend>
<table width="100%">

         <tr>
            <td>
                
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
                                        <td align="left">
                                            Case Id :</td>
                                        <td align="left">
                                            <asp:TextBox ID="txtCaseId" runat="server" MaxLength="15" SkinID="txtSkin"></asp:TextBox></td>
                                        <td align="left">
                                            Name :</td>
                                        <td align="left">
                                        <asp:TextBox ID="txtName" runat="server" SkinID="txtSkin" MaxLength="200"></asp:TextBox></td>
                                        <td align="left">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left">
                                            Date of Birth :</td>
                                        <td align="left">
                                            <asp:TextBox ID="txtDOB" runat="server" SkinID="txtSkin" MaxLength="10"></asp:TextBox>
                                            <img src="../../Images/SmallCalendar.gif" alt="" onclick="popUpCalendar(this, document.all.<%=txtDOB.ClientID%>, 'dd/mm/yyyy', 0, 0);" /> [dd/MM/yyyy]</td>
                                        <td align="left">
                                            Verification Type :</td>
                                        <td align="left">
                                        <asp:DropDownList SkinID="ddlSkin" ID="ddlVerifyType" runat="server" DataSourceID="sdsVerifyType"
                 DataTextField="VERIFICATION_TYPE"  DataValueField="VERIFICATION_TYPE_ID" OnDataBound="ddlVerifyType_DataBound" >
            </asp:DropDownList></td>
                                        <td align="left">
                                            <asp:Button ID="btnDedupeSearch" CssClass="label" runat="server" OnClick="btnDedupeSearch_Click" SkinID="btnDedupSkin" ValidationGroup="grValidateDate" />
                                            <asp:SqlDataSource ID="sdsVerifyType" runat="server" ConnectionString="<%$ ConnectionStrings:CMConnectionString %>"
              ProviderName="<%$ ConnectionStrings:CMConnectionString.ProviderName %>"  
              SelectCommand="Select [VERIFICATION_TYPE_ID],[VERIFICATION_TYPE], [VERIFICATION_TYPE_CODE] from VERIFICATION_TYPE_MASTER 
               WHERE VERIFICATION_TYPE_ID IN(5,6,7,8,9,11)">
            </asp:SqlDataSource>
                                        </td>
                                    </tr>
                                </table>
<asp:RegularExpressionValidator ID="revDOB" runat="server" ControlToValidate="txtDOB"
            Display="None" ErrorMessage="Please enter valid date format for date of birth"
            SetFocusOnError="True" ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d"
            ValidationGroup="grValidateDate"></asp:RegularExpressionValidator>
            <asp:ValidationSummary ID="vsValidateDate" runat="server"  
                    ValidationGroup="grValidateDate" ShowMessageBox="True" ShowSummary="False" />
                            </td>
                        </tr>
                          <tr><td align="left"><asp:Label ID="lblMsg" runat="server" CssClass="LabelError" Visible="False" SkinID="lblError"></asp:Label></td></tr>
                        <tr>
                            <td align="left" valign="top">
                                <asp:GridView ID="gvIDOCDedup" runat="server" AllowPaging="True" AllowSorting="True"
                                    AutoGenerateColumns="False" BackColor="White" BorderColor="Transparent" BorderStyle="Solid"
                                    BorderWidth="1px" CellPadding="1" CellSpacing="1" Font-Bold="False"
                                    Font-Names="Arial" Font-Size="8pt" ForeColor="Black" GridLines="None" meta:resourcekey="gvCCResource1"
                                    
                                    PageSize="15" Width="100%" OnSorting="gvIDOCDedup_Sorting" OnPageIndexChanging="gvIDOCDedup_PageIndexChanging" OnRowCommand="gvIDOCDedup_RowCommand">
                                    <FooterStyle BackColor="#D0D5D8" ForeColor="White" Height="20px" />
                                    <RowStyle BackColor="#E5E5E5" />
                                    <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="#D0D5D8" ForeColor="Black" HorizontalAlign="Center" />
                                    <HeaderStyle BackColor="#D0D5D8" Font-Bold="True" Font-Names="Arial" Font-Size="8pt"
                                        ForeColor="Black" Height="20px" />
                                    <AlternatingRowStyle BackColor="White" />
                                    <Columns>
                                        <asp:BoundField DataField="Case_ID" HeaderText="Case ID" ReadOnly="True" SortExpression="Case_ID" />                                        
                                        <asp:BoundField DataField="Ref_No" HeaderText="Bank RefNo" ReadOnly="True" SortExpression="Ref_No" />
                                        <asp:BoundField DataField="VERIFICATION_TYPE" HeaderText="VERIFICATION TYPE" ReadOnly="True" SortExpression="VERIFICATION_TYPE" />
                                        <asp:BoundField DataField="APPLICANT_NAME" HeaderText="Applicant Name" ReadOnly="True" SortExpression="APPLICANT_NAME" />
                                        <asp:BoundField DataField="Client_Name" HeaderText="Client Name" ReadOnly="True" SortExpression="Client_Name" />
                                        <asp:BoundField DataField="RECD DATE" DataFormatString="{0:dd/MM/yyyy}"
                                            HeaderText="Received DateTime" HtmlEncode="False" ReadOnly="True" SortExpression="RECD DATE" />                      
                                        <asp:BoundField DataField="DOB" DataFormatString="{0:dd/MM/yyyy}"
                                            HeaderText="Date of Birth" HtmlEncode="False" ReadOnly="True" SortExpression="DOB" />                                        
                                        
                                        <asp:BoundField DataField="STATUS_NAME" HeaderText="STATUS NAME" ReadOnly="True" SortExpression="STATUS_NAME" />
                                        
                                        <asp:TemplateField > 
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lblCaseId" runat="server" CommandArgument='<%# Eval("VERIFICATION_TYPE_ID") %>'
                                                CommandName="ShowDetail" Text="MoreDetails">
                                                </asp:LinkButton>
                                            </ItemTemplate>
                                            <ItemStyle Width="20px" />
                                        </asp:TemplateField>
                                       
                                    </Columns>
                                </asp:GridView>
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
</fieldset> 
   </td></tr></table>
</asp:Content>

