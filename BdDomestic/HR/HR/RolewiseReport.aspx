<%@ Page Language="C#" AutoEventWireup="true" Theme="SkinFile"  MasterPageFile="HRMasterPage.master" CodeFile="RolewiseReport.aspx.cs" Inherits="HR_HR_RolewiseReport" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server" >
<script language="javascript" type="text/javascript" src="DependentDropdownlist.js" ></script>
<script language="javascript" type="text/javascript" src="CommonJs.js" ></script>
<script type="text/javascript" language="javascript">

function ddlfill()
			{		
			debugger;
//			    DependentDropDownlist('ddlparent','ddlchild','capital','country','capital','capitalname','country','txtfname');
			    DependentDropDownlist('ctl00_ContentPlaceHolder1_ddlCentre','ctl00_ContentPlaceHolder1_ddlSubCentre','subcentremaster','centre_master','SubCentreId','SubCentreName','CentreId','CentreId');
			}    
</script>
  <fieldset ><legend class="FormHeading">DAT Daily Report</legend>
      <table width="100%">
          <tr>
              <td colspan="4">
                  <asp:Label ID="lblMsg" runat="server" SkinID="lblErrorMsg" Visible="False"></asp:Label></td>
          </tr>
          <tr>
              <td colspan="4">
                  <asp:Label ID="lblHierChichy" runat="server" Font-Bold="True" Font-Size="Medium"
                      ForeColor="#404040" SkinID="lblSkin"></asp:Label></td>
          </tr>
          <tr><td style="width: 65px">
                  </td>
              <td style="width: 217px">
                  </td>
              <td align="right" style="width: 60px">
                  &nbsp;</td>
              <td>
              </td>
          </tr>
          <tr><td style="width: 65px">
            <asp:Label Text=" Cluster" ID="lblChooseCluster" SkinID="lblSkin" runat="server" Visible="False"></asp:Label>
          </td><td style="width: 217px">
          <asp:DropDownList ID="ddlCluster" Visible="false" Enabled="false" OnSelectedIndexChanged="FillCentre" runat="server" SkinID="ddlSkin" AutoPostBack="true" Width="125px">
                  </asp:DropDownList>
          </td>
              <td style="width: 60px" >
              <asp:Label Text="Center" ID="lblChooseCentre" SkinID="lblSkin" runat="server" Visible="False"></asp:Label>
                    </td>
              <td>
                  <asp:DropDownList ID="ddlCentre"  Visible="false" Enabled="false" OnSelectedIndexChanged="FillSubCentre" runat="server" SkinID="ddlSkin" AutoPostBack="true" Width="125px">
                  </asp:DropDownList>
              </td>
              
          </tr>
          <tr>
              <td style="width: 65px">
           Report Type:
              </td>
              <td style="width: 217px">
              <asp:DropDownList ID="ddlReportType" runat="server"  SkinID="ddlSkin" AutoPostBack="false" Width="125px">
                  <asp:ListItem>With Data</asp:ListItem>
                  <asp:ListItem>Without Data</asp:ListItem>
                  </asp:DropDownList></td>
              <td style="width: 60px" >
                <asp:Label Text=" Sub Center" ID="lblChooseSubCenter" SkinID="lblSkin" runat="server"></asp:Label></td>
              <td>
                 <asp:DropDownList ID="ddlSubCentre" Visible="false" runat="server"  Enabled="false" SkinID="ddlSkin" AutoPostBack="false" Width="125px">
                  </asp:DropDownList></td>
          </tr>
          <tr><td style="width: 65px">
              From Date:</td>
              <td  align="left" style="width: 217px">
                 <asp:TextBox  ID="txtFromDate" runat="server" SkinID="txtSkin" MaxLength="10" Width="120px"></asp:TextBox>
                    <img id="Img1" onclick="popUpCalendar(this, document.all.<%=txtFromDate.ClientID%>,'dd/mm/yyyy', 0, 0);"  alt="Calendar" src="../../Images/SmallCalendar.gif" />[dd/mm/yyyy]</td>
              
            
            <td valign="top" style="width: 60px" >
                    To Date</td>                                          
              <td>
                  <asp:TextBox  ID="txtToDate" runat="server" SkinID="txtSkin" MaxLength="10" Width="120px"></asp:TextBox>
                    <img id="Img3" onclick="popUpCalendar(this, document.all.<%=txtToDate.ClientID%>,'dd/mm/yyyy', 0, 0);"  alt="Calendar" src="../../Images/SmallCalendar.gif" />[dd/mm/yyyy]</td>              
          </tr>                    
          <tr>
              <td style="width: 65px">
              </td>
              <td align="left" style="width: 217px">
              </td>
              <td  valign="top" style="width: 60px">
              </td>
              <td>
              </td>
          </tr>
          <tr><td colspan="3" align="right">
                  <asp:Button OnClientClick="javascript:return Validate2Dates('ctl00_ContentPlaceHolder1_txtFromDate','ctl00_ContentPlaceHolder1_txtToDate');" ID="btnShow" runat="server" OnClick="btnShow_Click" SkinID="btn"
                      Text="SHOW" ValidationGroup="validateclientdata" /></td>
              
              <td>
                  <asp:Button ID="btnExportToExcel" runat="server" Enabled="false" OnClick="btnExportToExcel_Click"  SkinID="btnExpToExlSkin"
                      Text="EXPORT TO EXCEL" /></td>
          </tr>
      </table>
      <table width="100%">
      <tr>
      <td>            
           <asp:Label ID="lblReportTitle" runat="server" Font-Bold="True" Font-Size="Medium"
            ForeColor="#404040" SkinID="lblSkin"></asp:Label>           
      </td>
      </tr>
      <tr>
      <td align="center">
                      <asp:GridView ID="GVDE" runat="server"  AllowSorting="false" AllowPaging="false" AutoGenerateColumns="true" SkinID="gridviewNoSort" OnRowDataBound="ChangeColorForSunday" OnSelectedIndexChanged="GVDE_SelectedIndexChanged">
                  </asp:GridView>      
      </td>
      </tr>     
      </table>
        <asp:RequiredFieldValidator Display="None" ID="RtxtFromDate" ControlToValidate="txtFromDate" runat="server" ErrorMessage="Please Enter From Date" ValidationGroup="validateclientdata" SetFocusOnError="True"></asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator Display="None"  ID="RtxtToDate" ControlToValidate="txtToDate" runat="server" ErrorMessage="Please Enter To Date" ValidationGroup="validateclientdata"></asp:RequiredFieldValidator>
      <asp:ValidationSummary ID="validateclientdata" runat="server" ShowMessageBox="True" ShowSummary="false" />            
  </fieldset>
 </asp:Content>