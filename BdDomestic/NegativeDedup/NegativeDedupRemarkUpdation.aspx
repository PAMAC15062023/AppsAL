<%@ Page Language="C#" MasterPageFile="~/NegativeDedup/NegativeDedup.master" AutoEventWireup="true" CodeFile="NegativeDedupRemarkUpdation.aspx.cs" Inherits="NegativeDedup_NegativeDedupRemarkUpdation" Theme="SkinFile"%>
<asp:Content ID="Content1" ContentPlaceHolderID="C1" Runat="Server">
<script>
function ValidateTextLength(DisplayName, ControlName, xLength)
{   
        
        if (ControlName.value.length > parseInt(xLength)-2)
        {                      
             ControlName.value = ControlName.value.substring( 0, parseInt(xLength)-1 ); 
             alert(DisplayName + " Should Not be Greater Then " + xLength + " Characters.");
             return false;         
        }      
}
function ClientValidate(source, arguments)
{
          //alert(arguments.Value);
          if ((arguments.Value) == 0)
             arguments.IsValid=false;
          else
             arguments.IsValid=true;
}
</script>
<table id="tblMain" runat="server" cellpadding="0" cellspacing="0" border="0" width="100%">
<tr><td></td><td></td><td></td></tr>
<tr><td></td><td align="center">
<table border="0" cellpadding="0" cellspacing="0" width="99%">
<tr><td style="padding-left:10px">

<fieldset><legend class="FormHeading">Negative Dedup Remark Updation</legend>
    <table border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td align="left" style="height: 22px" colspan="3">&nbsp;            
            </td>
        </tr>
        <tr >
            <td align="left" colspan="3" style="width:50%">
            <fieldset><legend class="FormHeading">Add New</legend>
                <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                   
                    <tr>
                        <td align="right" >Product <span style="color: #ff0033">* </span></td>
                        <td style="width: 2%; height: 14px" align="center">:</td>
                        <td >
                            <asp:DropDownList ID="ddlProduct" runat="server" AutoPostBack="false" 
                                SkinID="ddlSkin">
                                </asp:DropDownList>
                       </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 24px" align="right" >Case Id <span style="color: #ff0033">*</span></td>                        
                        <td style="width: 2%; height: 24px" align="center">:</td>
                        <td style="height: 24px"><asp:TextBox ID="txtCaseId" runat="server" MaxLength="15" SkinID="txtSkin">
                            </asp:TextBox>
                        </td>
                        <td style="height: 24px">
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="height: 14px">
                            Remark <span style="color: #ff0033">* </span></td>
                        <td align="center" style="width: 2%; height: 14px">
                            :</td>
                        <td style="height: 14px">
                            <asp:TextBox ID="txtDedupRemark" SkinID="txtSkin" runat="server" MaxLength="2000" Width="80%" TextMode="MultiLine" onkeyPress="ValidateTextLength('Dedup Remark', this, 2000);"></asp:TextBox></td>
                        <td style="height: 14px">
                            <asp:Button ID="btnInsert" runat="server" Text="Insert" SkinID="btn" Visible="true" OnClick="btnInsert_Click" ValidationGroup="grpInsert" />
                            <asp:CustomValidator ID="cvProduct" runat="server" 
                               SetFocusOnError="true" ErrorMessage="Please select Product." ValidationGroup="grpInsert" Display="None" ClientValidationFunction="ClientValidate"
                               ControlToValidate="ddlProduct" OnServerValidate="cvProduct_ServerValidate"></asp:CustomValidator>
                           <asp:RequiredFieldValidator ID="reqCaseId" runat="server" ControlToValidate="txtCaseId"
                                ErrorMessage="Please Enter Case Id." Display="none" SetFocusOnError="true" ValidationGroup="grpInsert">
                           </asp:RequiredFieldValidator>
                
                           <asp:RequiredFieldValidator ID="reqDedupRemark" runat="server" ControlToValidate="txtDedupRemark"
                                ErrorMessage="Please Enter Dedup Remark." Display="none" SetFocusOnError="true" ValidationGroup="grpInsert">
                           </asp:RequiredFieldValidator>
                           
                           <asp:ValidationSummary ID="vsInsert" runat="server" CssClass="compulsary" ValidationGroup="grpInsert" 
                                ShowMessageBox="True" ShowSummary="False" />
                        </td>
                    </tr>
                    <tr><td colspan="4">&nbsp;</td></tr>
                     <tr>
                        <td colspan="4">
                            <asp:Label ID="lblMSg" runat="server" SkinID="lblErrorMsg"  Visible="False"></asp:Label>
                        </td>
                    </tr>
                </table>
                </fieldset>
            </td>
        </tr>
        
        <tr>
            <td align="left" colspan="3" height="15px">&nbsp;
            <span style="color: #ff0033">* </span>Indicate mandatory fields.
            </td>
            
        </tr>
        <tr >
            <td align="left" colspan="3" style="width:50%">
            <fieldset><legend class="FormHeading">Searching</legend>
                <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                    <tr>
                        <td align="right" >Product <span style="color: #ff0033">* </span></td>
                        <td style="width: 2%; height: 14px" align="center">:</td>
                        <td >
                            <asp:DropDownList ID="ddlSearchProduct" runat="server" AutoPostBack="true" 
                                SkinID="ddlSkin" OnSelectedIndexChanged="ddlSearchProduct_SelectedIndexChanged">
                                </asp:DropDownList>
                       </td>
                        <td align="right" >Centre </td>
                        <td style="width: 2%; height: 14px" align="center">:</td>
                        <td >
                            <asp:DropDownList ID="ddlSearchCentre" runat="server" AutoPostBack="false" 
                                SkinID="ddlSkin">
                                </asp:DropDownList>
                       </td>
                        <td>
                        </td>
                        
                    </tr>
                    <tr>
                        <td style="height: 24px" align="right" >Dedup Entry Date</td>                        
                        <td style="width: 2%; height: 24px" align="center">:</td>
                        <td style="height: 24px">
                            &nbsp;<asp:TextBox ID="txtDedupEntryDate" runat="server" MaxLength="10" SkinID="txtSkin"></asp:TextBox>                
                            <img id="imgFromDate" alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtDedupEntryDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                                src="../Images/SmallCalendar.gif" />&nbsp;[dd//MM/yyyy]&nbsp;
                        </td>
                        
                    
                        <td style="height: 24px" align="right" >Case Id</td>                        
                        <td style="width: 2%; height: 24px" align="center">:</td>
                        <td style="height: 24px">
                            &nbsp;<asp:TextBox ID="txtSearchCaseId" runat="server" MaxLength="15" SkinID="txtSkin">
                            </asp:TextBox>
                            &nbsp;</td>
                        <td style="height: 24px">
                            <asp:Button ID="btnGet" runat="server" Text="Get" SkinID="btn" Visible="true" OnClick="btnGet_Click" ValidationGroup="grpSearchDedup" />
                            <asp:CustomValidator ID="cvSearchProduct" runat="server" 
                               SetFocusOnError="true" ErrorMessage="Please select Product." ValidationGroup="grpSearchDedup" Display="None" ClientValidationFunction="ClientValidate"
                               ControlToValidate="ddlSearchProduct" OnServerValidate="cvProduct_ServerValidate"></asp:CustomValidator>
                           <asp:RegularExpressionValidator ID="revDedupEntryDate" runat="server" ControlToValidate="txtDedupEntryDate"
                                Display="None" ErrorMessage="Please enter valid date format for Dedup Entry."
                                SetFocusOnError="True"  ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d"
                                ValidationGroup="grpSearchDedup"></asp:RegularExpressionValidator>
       
                           <asp:ValidationSummary ID="vsSearchDedup" runat="server" CssClass="compulsary" ValidationGroup="grpSearchDedup" 
                                ShowMessageBox="True" ShowSummary="False" />
                            </td>
                        <td style="height: 24px">
                        </td>
                    </tr>                   
                    
                    <tr><td colspan="8">&nbsp;</td></tr>
                     <tr><td colspan="8">
                     <asp:Label ID="lblSearchMsg" runat="server" SkinID="lblErrorMsg"  Visible="False"></asp:Label>
                     </td></tr>
                    <tr><td colspan="8">
                    <asp:GridView ID="gvDeupRecords" runat="server" SkinID="gridviewSkin" AutoGenerateColumns="False" 
                        PageSize="15" AllowPaging="true" AllowSorting="true" OnRowCancelingEdit="gvDeupRecords_RowCancelingEdit" 
                        OnRowEditing="gvDeupRecords_RowEditing" OnRowUpdating="gvDeupRecords_RowUpdating"
                        OnPageIndexChanging="gvDeupRecords_PageIndexChanging" OnSorting="gvDeupRecords_Sorting" >
                        <Columns>    
                                                 
                           <asp:BoundField ReadOnly="True" DataField="Centre" HeaderText="Centre" SortExpression="Centre"  />
                           <asp:BoundField ReadOnly="True" DataField="Client" HeaderText="Client" SortExpression="Client" />                           
                            <asp:TemplateField HeaderText="CaseId" SortExpression="CaseId">
                            <ItemTemplate>
                                <asp:Label ID="lblCaseId" runat="server" Text='<%# Bind("CaseId") %>' ></asp:Label>
                            </ItemTemplate>
                            </asp:TemplateField>  
                           <asp:BoundField ReadOnly="True" DataField="DedupEntryDate" SortExpression="DedupEntryDate" HeaderText="Dedup Entry Date" HtmlEncode="False" DataFormatString="{0:dd/MM/yyyy hh:mm tt}" />
                                                      
                           
                           
                           
              <asp:TemplateField HeaderText="Dedup Remarks" ItemStyle-HorizontalAlign="left" SortExpression="DedupRemarks"> 
                <ItemTemplate>  
                    <asp:Panel ID="pnlDedupRemark" Runat="Server" Width="500px" Height="30px" ScrollBars="Vertical">              
                    <asp:Label ID="lblDedupRemark" Text='<%# Eval("DedupRemark") %>' runat="server">
                    </asp:Label>                
                    </asp:Panel>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox id="txtDedupRemark" CssClass="textbox" Text='<%# Eval("DedupRemark") %>' Rows="2" Width="500px" 
                        runat="server" TextMode="MultiLine" MaxLength="500" SkinID="txtSkin" onkeyPress="ValidateTextLength('Dedup Remark', this, 2000);">
                    </asp:TextBox>                    
                </EditItemTemplate>
               </asp:TemplateField> 
              
              <asp:TemplateField HeaderText="Edit">	
                  <ItemTemplate>                    
                    <asp:LinkButton ID="lnkAddDedupRemark" CommandName="Edit"  runat="server">
                    <img src="../Images/icon_edit.gif" alt="Edit" style="border:0" />
                    </asp:LinkButton>
                  </ItemTemplate>
                  <EditItemTemplate>
                    <asp:LinkButton ID="lnkUpdateDedupRemark" CommandName="Update" Text="Add" runat="server"></asp:LinkButton>
                    <asp:LinkButton ID="lnkCancelDedupRemark" CommandName="Cancel" Text="Cancel" runat="server"></asp:LinkButton>                                    
                  </EditItemTemplate>
                  <ItemStyle VerticalAlign="Top" />
                </asp:TemplateField>  
               </Columns>
              </asp:GridView>
                    </td></tr>
                </table>
                </fieldset>
            </td>
        </tr>
        <tr>
            <td align="right" colspan="3" height="15px">&nbsp;
            </td>
            
        </tr>
    </table>
    </fieldset>
    </td></tr></table>
    &nbsp;</td><td></td></tr>
<tr><td></td><td></td><td></td></tr>
</table>

</asp:Content>

