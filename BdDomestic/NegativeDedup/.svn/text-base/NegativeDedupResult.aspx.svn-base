<%@ Page Language="C#" MasterPageFile="~/NegativeDedup/NegativeDedup.master" AutoEventWireup="true" CodeFile="NegativeDedupResult.aspx.cs" Inherits="NegativeDedup_NegativeDedupResult" Theme="skinFile"%>
<asp:Content ID="Content1" ContentPlaceHolderID="C1" Runat="Server">
<table id="tblMain" runat="server" cellpadding="0" cellspacing="0" border="0" width="100%">
<tr><td></td><td></td><td></td></tr>
<tr><td></td><td align="center">
<table border="0" cellpadding="0" cellspacing="0" width="99%">
<tr><td style="padding-left:10px">
<%string FtpPath = ConfigurationManager.AppSettings["FtpPathNegMatch"]; %>
<script>
 function funPopUp(nCentre,nProduct,nClient)
 {
        var sURL="";   
        sURL ="<%=FtpPath%>" + nCentre + "/" + nProduct + "/" + nClient; 
        window.open(sURL);    
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
<fieldset><legend class="FormHeading">Negative Dedup Results</legend>
    <table border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td align="right" style="height: 22px" colspan="6">
            </td>
        </tr>
        <tr style="color: #000000">
            <td align="right">
                Activity <span style="color: #ff0033">* </span></td>
            <td style="width: 2%; height: 14px">
                :</td>
            <td align="left" style="width: 142px">
            <asp:DropDownList ID="ddlActivity" runat="server" AutoPostBack="True" 
                    OnSelectedIndexChanged="ddlActivity_SelectedIndexChanged"
                    SkinID="ddlSkin">
                </asp:DropDownList>
                </td>
            <td align="left" style="width: 92px">
                Product <span style="color: #ff0033">* </span></td>
           <td style="width: 2%; height: 14px">
                :</td>
            <td align="left">
            <asp:DropDownList ID="ddlProduct" runat="server" AutoPostBack="True" 
                    OnSelectedIndexChanged="ddlProduct_SelectedIndexChanged" SkinID="ddlSkin">
                </asp:DropDownList>
                </td>
        </tr>
        <tr style="color: #000000">
            <td align="right" style="height: 14px">
                Centre <span style="color: #ff0033">* </span></td>
            <td style="width: 2%; height: 14px">
                :</td>
            <td align="left" style="height: 14px; width: 142px;">
                <asp:DropDownList ID="ddlCentre" runat="server" AutoPostBack="True" 
                     SkinID="ddlSkin" OnSelectedIndexChanged="ddlCentre_SelectedIndexChanged">
                </asp:DropDownList></td>
            <td align="left" style="height: 14px; width: 92px;">
                Case Recd.Date <span style="color: #ff0033">*</span></td>
           <td style="width: 2%; height: 14px">
                :</td>
            <td align="left" style="height: 14px">
                <asp:TextBox ID="txtRecdDate" runat="server" MaxLength="10" SkinID="txtSkin"></asp:TextBox>
                
                <img id="imgFromDate" alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtRecdDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                    src="../Images/SmallCalendar.gif" />&nbsp;[dd//MM/yyyy]&nbsp;
            </td>
        </tr>
        <tr>
            <td align="left" colspan="6">
                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                <asp:Label ID="lblMsg" runat="server" SkinID="lblErrorMsg" Visible="false"></asp:Label>&nbsp;
            </td>
            
        </tr>
        <tr>
            <td align="left" colspan="6">&nbsp;<span style="color: #ff0033">* </span>Indicate mandatory fields.
            </td>
            
        </tr>
        
        <tr>
            <td align="right" colspan="6">
                <asp:Button ID="btnShowCompletedCases" ValidationGroup="grpShowImportCases" 
                    runat="server" Text="Show Completed Cases" SkinID="btn" Visible="false" OnClick="btnShowCompletedCases_Click" />
               
            </td>
        </tr>
        <tr >
            <td align="left" colspan="6">
              <asp:GridView ID="gvImportCases" runat="server" SkinID="gridviewSkin" AutoGenerateColumns="False" OnPageIndexChanging="gvImportCases_PageIndexChanging" OnSorting="gvImportCases_Sorting" >
                <Columns>                    
                   <asp:BoundField ReadOnly="True" DataField="Centre" HeaderText="Centre" SortExpression="Centre"  />
                   <asp:BoundField ReadOnly="True" DataField="Client" HeaderText="Client" SortExpression="Client" />
                   <asp:BoundField ReadOnly="True" DataField="Cases" HeaderText="Cases" SortExpression="Cases"  />                   
                   
                    <asp:TemplateField HeaderText="View Negative Dedup Result">
                        <ItemTemplate>                            
                            <a href="#" onclick="funPopUp('<%# Eval("Centre") %>','<%# Eval("Product") %>','<%# Eval("Client") %>')">View</a>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
              </asp:GridView>                
            </td>
        </tr>
        <tr>
            <td align="left" style="height: 22px" colspan="6">
                <asp:RequiredFieldValidator ID="reqCaseRecdDate" runat="server" ControlToValidate="txtRecdDate"
                    ErrorMessage="Please Enter Case Received date." Display="none" SetFocusOnError="true" ValidationGroup="grpShowImportCases">
                </asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="revFromDate" runat="server" ControlToValidate="txtRecdDate"
                    Display="None" ErrorMessage="Please Enter valid date format for case received date." SetFocusOnError="True"
                    ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d"    
                    ValidationGroup="grpShowImportCases"></asp:RegularExpressionValidator>
                
                <asp:CustomValidator ID="cvActivity" runat="server" 
                   SetFocusOnError="true" ErrorMessage="Please select Activity." ValidationGroup="grpShowImportCases" Display="None" 
                   ClientValidationFunction="ClientValidate" ControlToValidate="ddlActivity" OnServerValidate="cv_ServerValidate"></asp:CustomValidator>
               
                <asp:CustomValidator ID="cvProduct" runat="server" 
                   SetFocusOnError="true" ErrorMessage="Please select Product." ValidationGroup="grpShowImportCases" Display="None" 
                   ClientValidationFunction="ClientValidate" ControlToValidate="ddlProduct" OnServerValidate="cv_ServerValidate"></asp:CustomValidator>
               
               <asp:CustomValidator ID="cvCentre" runat="server" 
                   SetFocusOnError="true" ErrorMessage="Please select Centre or select all." ValidationGroup="grpShowImportCases" Display="None" 
                   ClientValidationFunction="ClientValidate" ControlToValidate="ddlCentre" OnServerValidate="cv_ServerValidate"></asp:CustomValidator>
               
                <asp:ValidationSummary ID="vsValidate" runat="server" CssClass="compulsary" ShowMessageBox="True"
                            ShowSummary="False" ValidationGroup="grpShowImportCases" />
            </td>
        </tr>
    </table>
    </fieldset>
    </td></tr></table>
    &nbsp;</td><td></td></tr>
<tr><td></td><td></td><td></td></tr>
</table>
</asp:Content>

