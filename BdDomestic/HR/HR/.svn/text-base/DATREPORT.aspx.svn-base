<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DATREPORT.aspx.cs"  Theme="SkinFile"  MasterPageFile="HRMasterPage.master" Inherits="HR_HR_DATREPORT" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server" >        
<script language="javascript" type="text/javascript" src="DependentDropdownlist.js" ></script>
<script type="text/javascript" language="javascript">
function ddlfill()
			{		
			debugger;
//			    DependentDropDownlist('ddlparent','ddlchild','capital','country','capital','capitalname','country','txtfname');
			    DependentDropDownlist('ctl00_ContentPlaceHolder1_ddlCentre','ctl00_ContentPlaceHolder1_ddlSubCentre','subcentremaster','centre_master','SubCentreId','SubCentreName','CentreId','CentreId');
			}    
</script>
  <fieldset ><legend class="FormHeading">Attendance Count Report</legend>   
      <table width="100%">
          <tr>
              <td colspan="4">
                  <asp:Label ID="lblMsg" runat="server" SkinID="lblErrorMsg" Visible="False"></asp:Label></td>
          </tr>
          <tr>
              <td align="center" colspan="4" >
                  &nbsp;<asp:Label ID="lblHierChichy" runat="server" Font-Bold="True" Font-Size="Medium"
                      ForeColor="#404040" SkinID="lblSkin"></asp:Label></td>
          </tr>
          <tr>
              <td style="width: 60px">
                    Center:                
              </td>
              <td style="width: 220px">
                  <asp:DropDownList ID="ddlCentre" OnSelectedIndexChanged="FillSubCentre" runat="server" SkinID="ddlSkin" AutoPostBack="true" Width="125px">
                  </asp:DropDownList>
              </td>
              <td style="width: 60px">
                  &nbsp;Sub Center:</td>
              <td>
                 <asp:DropDownList ID="ddlSubCentre" runat="server"  SkinID="ddlSkin" AutoPostBack="false" OnDataBound="ddlSubCentre_DataBound" Width="125px">
                  </asp:DropDownList>
              </td>
          </tr>
          <tr>
              <td style="width: 60px">
                    From Date:                
              </td>
            <td valign="top" style="width: 220px">
                    <asp:TextBox  ID="txtFromDate" runat="server" SkinID="txtSkin" MaxLength="10" Width="120px"></asp:TextBox>
                    <img id="Img1" onclick="popUpCalendar(this, document.all.<%=txtFromDate.ClientID%>,'dd/mm/yyyy', 0, 0);"  alt="Calendar" src="../../Images/SmallCalendar.gif" />[dd/mm/yyyy]</td>                                          
              <td style="width: 60px">
                    To Date:</td>              
            <td valign="top">
                    <asp:TextBox  ID="txtToDate" runat="server" SkinID="txtSkin" MaxLength="10" Width="120px"></asp:TextBox>
                    <img id="Img2" onclick="popUpCalendar(this, document.all.<%=txtToDate.ClientID%>,'dd/mm/yyyy', 0, 0);"  alt="Calendar" src="../../Images/SmallCalendar.gif" />[dd/mm/yyyy]</td>                                          
          </tr>                    
          
          <tr>
              <td style="width: 60px" >
              </td>
              <td style="width: 220px"></td>
              <td align="right" style="width: 60px">
                  <asp:Button ID="btnShow" runat="server" OnClick="btnShow_Click" SkinID="btn"
                      Text="SHOW" ValidationGroup="ValGrp" /></td>
              
              <td align="left">
                  <asp:Button ID="btnExportToExcel" runat="server" Enabled="false" OnClick="btnExportToExcel_Click"  SkinID="btnExpToExlSkin"
                      Text="EXPORT TO EXCEL" /></td>              
          </tr>
      </table>
      <table width="100%">
      <tr>
      <td colspan="4">            
           <asp:Label ID="lblReportTitle" runat="server" Font-Bold="True" Font-Size="Medium"
            ForeColor="#404040" SkinID="lblSkin"></asp:Label>           
      </td>
      </tr>
      <tr>
      <td align="center" colspan="4">      
                        <asp:GridView ID="GVDE" runat="server"  SkinID="gridviewNoSort" AutoGenerateColumns="true" >
                     
                  
                  </asp:GridView>
      
      </td>
      </tr>     
      </table>
      <asp:RegularExpressionValidator ID="revFromDate" runat="server" ControlToValidate="txtFromDate"
        Display="None" ErrorMessage="Please enter valid Date Format for From date." SetFocusOnError="True"
        ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d"    
        ValidationGroup="ValGrp"></asp:RegularExpressionValidator>
    <asp:RegularExpressionValidator ID="revToDate" runat="server" ControlToValidate="txtToDate"
        Display="None" ErrorMessage="Please enter valid Date Format for To date." SetFocusOnError="True"
        ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d"    
        ValidationGroup="ValGrp"></asp:RegularExpressionValidator>
        <asp:RequiredFieldValidator Display="None" ID="RtxtFromDate" ControlToValidate="txtFromDate" runat="server" ErrorMessage="Please Enter From Date" ValidationGroup="ValGrp"></asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator Display="None"  ID="RtxtToDate" ControlToValidate="txtToDate" runat="server" ErrorMessage="Please Enter To Date" ValidationGroup="ValGrp"></asp:RequiredFieldValidator>
      <asp:ValidationSummary ID="validateclientdata" runat="server" ShowMessageBox="True" ShowSummary="false" ValidationGroup="ValGrp" />            
  </fieldset>
 </asp:Content>