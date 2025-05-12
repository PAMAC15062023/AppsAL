<%@ Page Language="C#" MasterPageFile="~/BD/BD/BDMasterPage.master" AutoEventWireup="true" EnableEventValidation ="false" CodeFile="Export.aspx.cs" Inherits="BD_Export" Theme="SkinFile" StylesheetTheme="SkinFile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<script  language="javascript" type="text/javascript">
function Validate_Search()
    {    
         var txtFromDate=document.getElementById("<%=txtFromDate.ClientID%>");
         var txtToDate=document.getElementById("<%=txtToDate.ClientID%>");
                  
         var lblMessage=document.getElementById("<%=lblMessage.ClientID%>");
    
         var ReturnValue=true;
         var ErrorMessage='';
         
         if (txtToDate.value=='')
         {
            ErrorMessage='Please enter to To Date to continue!';
            ReturnValue=false;
            txtToDate.focus();
         }
         if (txtFromDate.value=='')
         {
            ErrorMessage='Please enter to From Date to continue!';
            ReturnValue=false;
            txtFromDate.focus();
         }
                 
            window.scrollTo(0,0);    
            lblMessage.innerText=ErrorMessage;
           
           
           return ReturnValue;
            
    }
 </script>
  <table>
        <tr>
            <td colspan="8" style="height: 16px">
                <asp:Label ID="lblMessage" runat="server" CssClass="ErrorMessage"></asp:Label></td>
        </tr>
        <tr>
            <td class="topbar" colspan="8" style="height: 28px">
                BD Tracker MIS</td>
        </tr>
        <tr>
            <td style="width: 10px; height: 21px;">
            </td>
            <td class="reportTitleIncome" style="width: 100px; height: 21px;">
                <asp:Label ID="lblbd" runat="server" Text="BDManager" Width="88px" Visible="False" Height="17px"></asp:Label></td>
            <td class="Info" colspan="2" style="height: 21px; width: 255px;">
                <asp:DropDownList ID="ddlBDManager" runat="server" CssClass="textbox" DataSourceID="sdsBDManager"
                    DataTextField="FULLNAME" DataValueField="EMP_ID" OnDataBound="ddlBDManager_DataBound"
                    SkinID="ddlSkin" Visible="false">
                </asp:DropDownList></td>
            <td class="reportTitleIncome" style="width: 100px; height: 21px;">
                <asp:Label ID="lblleadby" runat="server" Text="LeadGeneratedBy" Visible="False" Height="17px"></asp:Label></td>
            <td class="Info" style="width: 192px; height: 21px;">
                <asp:DropDownList ID="ddlLeadBy" runat="server" CssClass="textbox" DataSourceID="sdsLeadBy"
                    DataTextField="FULLNAME" DataValueField="EMP_ID" OnDataBound="ddlLeadBy_DataBound"
                    SkinID="ddlSkin" Visible="false">
                </asp:DropDownList></td>
            <td style="width: 100px; height: 21px;">
            </td>
            <td style="width: 100px; height: 21px;">
            </td>
        </tr>
      <tr>
          <td style="width: 10px">
          </td>
          <td class="reportTitleIncome" style="width: 100px">
              LeadStatus</td>
          <td class="Info" colspan="2" style="width: 255px">
              <asp:DropDownList ID="ddlMeetinglead" runat="server" CssClass="textbox" DataSourceID="sdsStatus1"
                  DataTextField="Meet_status" DataValueField="Meet_id" OnDataBound="ddlMeetinglead_DataBound"
                  SkinID="ddlSkin">
              </asp:DropDownList></td>
          <td class="reportTitleIncome" style="width: 100px">
          </td>
          <td class="Info" style="width: 192px">
          </td>
          <td style="width: 100px">
          </td>
          <td style="width: 100px">
          </td>
      </tr>
      <tr>
          <td style="width: 10px">
          </td>
          <td class="reportTitleIncome" style="width: 100px">
              From Date
          </td>
          <td class="Info" colspan="2" style="width: 255px">
              <asp:TextBox ID="txtFromDate" runat="server" SkinID="txtSkin" Width="109px"></asp:TextBox>
              <img alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtFromDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                  src="../../Images/SmallCalendar.png" /></td>
          <td class="reportTitleIncome" style="width: 100px">
              To Date</td>
          <td class="Info" style="width: 192px">
              <asp:TextBox ID="txtToDate" runat="server" SkinID="txtSkin"></asp:TextBox>
              <img alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtToDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                  src="../../Images/SmallCalendar.png" /></td>
          <td style="width: 100px">
          </td>
          <td style="width: 100px">
          </td>
      </tr>
        <tr>
            <td class="tta" colspan="8">
                &nbsp;<asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" Text="Search" Font-Bold="True" />&nbsp;
                <asp:Button ID="btnExport" runat="server"  Text="Export" Font-Bold="True" OnClick="btnExport_Click" Visible="False" /></td>
        </tr>
    </table>
      
    
<asp:Panel ID="Panel1" runat="server" Height="300px" Width="930px" ScrollBars="Auto">
        <table border="0" id="tblExport" cellpadding="0" cellspacing="0" runat="server"  visible="false" width="100%">
            <tr><td>
                &nbsp;&nbsp;&nbsp;
                <asp:GridView ID="gvImportedData" runat="server" BackColor="White" BorderColor="#3366CC"
                        BorderStyle="None" BorderWidth="1px" CellPadding="8" Font-Size="8pt" Height="83px" Width="885px">
                        <RowStyle BackColor="White" ForeColor="#003399" />
                        <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                        <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                        <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                        <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
             </asp:GridView>
            </td>
            </tr>
        </table>
    <asp:SqlDataSource ID="sdsPresaleCase" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
        ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="SELECT DISTINCT A.CONT_PRESALE_ID, A.CONT_PRESALE_REF_NO,convert(varchar,A.LEAD_DATE,103) AS DATE,C.FULLNAME AS 'BD Manager',g.FullName as 'Lead By',B.CLIENT_NAME, &#13;&#10;A.CONTACT_PERSON AS 'Client officer Name',A.CONTACT_DESIGNATION AS 'Designation',D.ACTIVITY_NAME, A.PRESALE_STATUS, A.REMARK FROM &#13;&#10;PRESALE_CONTRACT_DETAIL AS A LEFT OUTER JOIN CLIENT_MASTER AS B ON A.CLIENT_ID = B.CLIENT_ID LEFT OUTER JOIN EMPLOYEE_MASTER C ON A.BD_MANAGER_ID=C.EMP_ID Left Outer Join Employee_master g on a.lead_by=g.emp_id LEFT OUTER JOIN&#13;&#10;PRESALE_CONTRACT_ACTIVITY_PRODUCT E ON A.CONT_PRESALE_ID=E.CONT_PRESALE_ID LEFT OUTER JOIN ACTIVITY_MASTER D ON E.ACTIVITY_ID=D.ACTIVITY_ID&#13;&#10;ORDER BY Date DESC&#13;&#10;">
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="sdsBDManager" runat="server" ConnectionString="<%$ ConnectionStrings:CMConnectionString %>"
        ProviderName="<%$ ConnectionStrings:CMConnectionString.ProviderName %>" SelectCommand="SELECT EMP_ID,FULLNAME FROM EMPLOYEE_MASTER A, USER_ROLE B WHERE A.EMP_ID=B.USER_ID AND B.ROLE_ID=19 AND (DOL is null or DOL = '') ORDER BY A.FULLNAME">
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="sdsStatus1" runat="server" ConnectionString="<%$ ConnectionStrings:CMConnectionString %>"
        ProviderName="<%$ ConnectionStrings:CMConnectionString.ProviderName %>" SelectCommand="SELECT [Meet_id], [Meet_status] FROM [PRESALE_LEAD]">
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="sdsLeadBy" runat="server" ConnectionString="<%$ ConnectionStrings:CMConnectionString %>"
        ProviderName="<%$ ConnectionStrings:CMConnectionString.ProviderName %>" SelectCommand="SELECT EMP_ID,FULLNAME FROM EMPLOYEE_MASTER A, USER_ROLE B WHERE A.EMP_ID=B.USER_ID AND B.ROLE_ID=19 AND (DOL is null or DOL = '') ORDER BY A.FULLNAME">
    </asp:SqlDataSource>
      </asp:Panel>
      </asp:Content>
    
   


