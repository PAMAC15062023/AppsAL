<%@ Page Language="C#" AutoEventWireup="true" Theme="SkinFile" CodeFile="SalaryStatusReport.aspx.cs" MasterPageFile="HRMasterPage.master" Inherits="HR_HR_SalaryStatusReport" %>
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
  <fieldset ><legend class="FormHeading">Attendance Dump Report</legend>
      <table>
          <tr>
              <td align="center" colspan="6">
                  <asp:Label ID="lblHierChichy" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="#404040" SkinID="lblSkin"></asp:Label></td>
          </tr>
          <tr>
              <td colspan="6" >
                  <asp:Label ID="lblMsg" runat="server" SkinID="lblErrorMsg" Visible="False"></asp:Label></td>
          </tr>
          <tr>
              <td>
                    Center:</td>
              <td>
                  <asp:DropDownList ID="ddlCentre" OnSelectedIndexChanged="FillSubCentre" runat="server" SkinID="ddlSkin" AutoPostBack="true" Width="125px">
                  </asp:DropDownList>
              </td>
              <td>
                    Sub Center:</td>
              <td>
                 <asp:DropDownList ID="ddlSubCentre" runat="server"  SkinID="ddlSkin" AutoPostBack="false" Width="125px">
                  </asp:DropDownList>
              </td>
          </tr>
          <tr>
              <td>
              </td>
              <td>
              <asp:DropDownList ID="ddlReportType" runat="server"  SkinID="ddlSkin" AutoPostBack="false" Visible="False" Width="125px">
                  <asp:ListItem>With Data</asp:ListItem>
                  <asp:ListItem>Without Data</asp:ListItem>
                  </asp:DropDownList>
              </td>
              <td>
              </td><td></td>
          </tr>                    
          <tr>
              <td>
                    From Date:                
              </td>
            <td valign="top">
                    <asp:TextBox  ID="txtFromDate" runat="server" SkinID="txtSkin" MaxLength="11" Width="120px"></asp:TextBox>
                    <img id="Img1" onclick="popUpCalendar(this, document.all.<%=txtFromDate.ClientID%>,'dd/mm/yyyy', 0, 0);"  alt="Calendar" src="../../Images/SmallCalendar.gif" />[dd/mm/yyyy]</td>                                          
              <td>
                    To Date :</td>              
            <td valign="top">
                    <asp:TextBox  ID="txtToDate" runat="server" SkinID="txtSkin" MaxLength="11" Width="120px"></asp:TextBox>
                    <img id="Img2" onclick="popUpCalendar(this, document.all.<%=txtToDate.ClientID%>,'dd/mm/yyyy', 0, 0);"  alt="Calendar" src="../../Images/SmallCalendar.gif" />[dd/mm/yyyy]</td>                                          
          </tr>
          <tr>
              <td colspan="3" align="right">
                  <asp:Button ID="btnShow" runat="server" SkinID="btn"
                      Text="SHOW" ValidationGroup="ValGrp" OnClick="btnShow_Click" /></td>
              
              <td align="left">
                  <asp:Button ID="btnExportToExcel" runat="server" Enabled="false" OnClick="btnExportToExcel_Click"  SkinID="btnExpToExlSkin"
                      Text="EXPORT TO EXCEL" /></td>              
          </tr>
      </table>
      <table width="100%">
      <tr>
      <td colspan="5">            
           <asp:Label ID="lblReportTitle" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="#404040" SkinID="lblSkin"></asp:Label>           
      </td>
      </tr>
      <tr>
      <td align="center" colspan="5">
                      <asp:GridView ID="GVDE" runat="server"  SkinID="gridviewNoSort" AutoGenerateColumns="true">
                     <%-- <Columns>
                      <asp:TemplateField HeaderText="Sr. No.">
                        <ItemTemplate>
                            <asp:Label ID="lblSrno" runat="server"></asp:Label>                        
                        </ItemTemplate>
                      </asp:TemplateField>
                          <asp:BoundField DataField="centre_name" HeaderText="Centre"  />
                          <asp:BoundField DataField="subcentrename" HeaderText="Sub Centre"  />                    
                          <asp:BoundField DataField="Emp_Code" HeaderText="Emp Code"  />
                          <asp:BoundField DataField="fullname" HeaderText="Pamacian"  />
                          <asp:BoundField DataField="suvidha_ac" HeaderText="Suvidha Ac#"  />
                          <asp:BoundField DataField="category" HeaderText="Category"  />
                          <asp:BoundField DataField="department" HeaderText="Department"  />
                          <asp:BoundField DataField="unit" HeaderText="Unit"  />
                          <asp:BoundField DataField="company_id" HeaderText="Company Code"  />
                          <asp:BoundField DataField="Absent" HeaderText="Absent"  /> 
                          <%--<asp:BoundField DataField="Present" HeaderText="Present"  />--%>
                          <%--<asp:BoundField DataField="ARemark" HeaderText="Allowance Remark"  />  
                          <asp:BoundField DataField="SPAllowance" HeaderText="Special Allowance"  /> 
                          <asp:BoundField DataField="OTDays" HeaderText="Over Time(In Days)" />
                          <asp:BoundField DataField="Deduction" HeaderText="Deduction" /> 
                          <asp:BoundField DataField="Dremarks" HeaderText="Deduction Remarks" />
                      </Columns> --%>               
                  </asp:GridView>      
      </td>
      </tr>     
      </table>
        <asp:RequiredFieldValidator Display="None" ID="RtxtFromDate" ControlToValidate="txtFromDate" runat="server" ErrorMessage="Please Enter From Date" ValidationGroup="ValGrp"></asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator Display="None"  ID="RtxtToDate" ControlToValidate="txtToDate" runat="server" ErrorMessage="Please Enter To Date" ValidationGroup="ValGrp"></asp:RequiredFieldValidator>
        
         <asp:RegularExpressionValidator ID="revFromDate" runat="server" ControlToValidate="txtFromDate"
        Display="None" ErrorMessage="Please enter valid Date Format for From date." SetFocusOnError="True"
        ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d"    
        ValidationGroup="ValGrp"></asp:RegularExpressionValidator>
    <asp:RegularExpressionValidator ID="revToDate" runat="server" ControlToValidate="txtToDate"
        Display="None" ErrorMessage="Please enter valid Date Format for To date." SetFocusOnError="True"
        ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d"    
        ValidationGroup="ValGrp"></asp:RegularExpressionValidator>
      <asp:ValidationSummary ID="validateclientdata" runat="server" ShowMessageBox="True" ShowSummary="false" ValidationGroup="ValGrp"/>            
  </fieldset>
 </asp:Content>