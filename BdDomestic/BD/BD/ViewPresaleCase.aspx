<%@ Page Language="C#" MasterPageFile="~/BD/BD/BDMasterPage.master" AutoEventWireup="true" CodeFile="ViewPresaleCase.aspx.cs" Inherits="ViewPresaleCase" Theme="SkinFile" StylesheetTheme="SkinFile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<script  language="javascript" type="text/javascript">
function Validate_Search()
    {    
         var fdate=document.getElementById("<%=fdate.ClientID%>");
         var tdate=document.getElementById("<%=tdate.ClientID%>");
                  
         var lblMsg=document.getElementById("<%=lblMsg.ClientID%>");
    
         var ReturnValue=true;
         var ErrorMessage='';
         
         if (tdate.value=='')
         {
            ErrorMessage='Please enter to To Date to continue!';
            ReturnValue=false;
            tdate.focus();
         }
         if (fdate.value=='')
         {
            ErrorMessage='Please enter to From Date to continue!';
            ReturnValue=false;
            fdate.focus();
         }
                 
            window.scrollTo(0,0);    
            lblMsg.innerText=ErrorMessage;
           
           
           return ReturnValue;
            
    }

</script>

       <table width="100%" border="0">
           <tr>
               <td colspan="7" style="width: 40px">
                  <asp:Label ID="lblMsg" runat="server" EnableViewState="False" Width="682px" CssClass="ErrorMessage"></asp:Label></td>
           </tr>
           <tr>
               <td class="topbar" colspan="7">
                   View Presale Case</td>
           </tr>
           <tr>
               <td colspan="1" style="width: 70px" class="reportTitleIncome">
                    <asp:Label ID="lblbd" runat="server" Text="BDManager" Visible="False" Width="89px"></asp:Label></td>
               <td colspan="1" style="width: 135px" class="Info">
                  <asp:DropDownList ID="ddlBDManager" runat="server" CssClass="textbox" DataSourceID="sdsBDManager" Visible="false" DataTextField="FULLNAME" DataValueField="EMP_ID" OnDataBound="ddlBDManager_DataBound" SkinID="ddlSkin">                       
                    </asp:DropDownList></td>
               <td colspan="1" class="reportTitleIncome">
                     <asp:Label ID="lblleadby" runat="server" Text="LeadGeneratedBy" Visible="False" Width="115px" Height="19px"></asp:Label></td>
               <td colspan="1" style="width: 40px" class="Info">
                  <asp:DropDownList ID="ddlLeadBy" runat="server" CssClass="textbox" Visible="false" DataSourceID="sdsLeadBy" DataTextField="FULLNAME" DataValueField="EMP_ID" OnDataBound="ddlLeadBy_DataBound" SkinID="ddlSkin">
                    </asp:DropDownList></td>
               <td colspan="1">
               </td>
               <td colspan="1">
               </td>
               <td colspan="1">
               </td>
           </tr>
      <tr>
              <td style="width: 70px" class="reportTitleIncome">
              LeadStatus</td>
              <td style="width: 135px" class="Info">
                  <asp:DropDownList ID="ddlMeetinglead" runat="server" CssClass="textbox" DataSourceID="sdsStatus1"
                DataTextField="Meet_status" DataValueField="Meet_id" OnDataBound="ddlMeetinglead_DataBound"
                SkinID="ddlSkin">
            </asp:DropDownList></td>
              <td align="right" class="reportTitleIncome">
                  </td>
          <td align="right">
                  <asp:Label ID="Label2" runat="server" Font-Bold="True" SkinID="lblSkin"  Visible="false" Text="[View]"></asp:Label></td>
          <td align="right">
          </td>
          <td align="right">
          </td>
          <td align="right">
          </td>
          </tr>
           <tr>
               <td class="reportTitleIncome" style="width: 70px">
               </td>
               <td class="Info" style="width: 135px">
                   </td>
               <td align="right" class="reportTitleIncome">
               </td>
               <td align="right">
                   </td>
               <td align="right">
               </td>
               <td align="right">
               </td>
               <td align="right">
               </td>
           </tr>
           <tr>
               <td class="reportTitleIncome" style="width: 70px; height: 23px">
                   From Date</td>
               <td class="Info" style="width: 135px; height: 23px">
                   &nbsp;
                   <asp:TextBox ID="fdate" runat="server"></asp:TextBox><img alt="Calendar" onclick="popUpCalendar(this, document.all.<%=fdate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                       src="../../Images/SmallCalendar.png" /></td>
               <td align="right" class="reportTitleIncome" style="height: 23px">
                   To Date</td>
               <td align="right" class="Info" style="height: 23px">
                   &nbsp;<asp:TextBox ID="tdate" runat="server"></asp:TextBox><img alt="Calendar" onclick="popUpCalendar(this, document.all.<%=tdate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                       src="../../Images/SmallCalendar.png" /></td>
               <td align="right" style="height: 23px">
               </td>
               <td align="right" style="height: 23px">
               </td>
               <td align="right" style="height: 23px">
               </td>
           </tr>
           <tr >
              <td align="left" colspan="7" class="tta" style="height: 39px">
                  &nbsp; &nbsp;
                  <asp:Button ID="btnshow" runat="server" Font-Bold="True" Text="Search" OnClick="btnshow_Click1" />
                  <asp:Button ID="btnNew" runat="server" Font-Bold="True" Text="New Contract" OnClick="btnNew_Click1" /></td>
             </tr>
          <tr><td colspan="7" style="height: 458px">
             <asp:GridView ID="gvPresaleCase" runat="server" Width="100%" AutoGenerateColumns="False" OnRowCommand="gvPresaleCase_RowCommand"  SkinID="gridviewExportSkin" PageSize="20" AllowPaging="True" OnPageIndexChanging="gvPresaleCase_PageIndexChanging" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4">
            <RowStyle ForeColor="#003399" BackColor="White" />
             <Columns>
                    <asp:BoundField DataField="CONT_PRESALE_REF_NO" HeaderText="Contract Ref No"
                        SortExpression="CONT_PRESALE_REF_NO" />
                    <asp:BoundField DataField="LeadGen_DATE" HeaderText="LeadGen_DATE" SortExpression="LEAD_DATE" />
                    <asp:BoundField DataField="BDManager" HeaderText="Bd Manager" SortExpression="FULLNAME" />
                    <asp:BoundField DataField="LeadBy" HeaderText="lead by" SortExpression="FULLNAME" />
                    <asp:BoundField DataField="CLIENT_NAME" HeaderText="Client Name" SortExpression="CLIENT_NAME" />
                    <asp:BoundField DataField="ClientOfficerName" HeaderText="Client officer Name" SortExpression="CONTACT_PERSON" />
                    <asp:BoundField DataField="Meeting_dt" HeaderText="Meeting_dt" SortExpression="MEETING_DATE" />
                    <asp:BoundField DataField="ACTIVITY_NAME" HeaderText="Act_Name" SortExpression="ACTIVITY_NAME" />
                    <asp:BoundField DataField="PRODUCT_NAME" HeaderText="Pro_Name" SortExpression="PRESALE_STATUS" />
                    <asp:BoundField DataField="remark1" HeaderText="remark1" SortExpression="REMARK" />
                     <asp:TemplateField HeaderText="Update Meeting Details"> 
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkEditMeeting" runat="server" CommandArgument='<%# Eval("CONT_PRESALE_ID") %>'
                            CommandName="EditMeeting" ><img src="../../Images/icon_edit.gif" alt="Edit Meeting Details" style="border:0" /></asp:LinkButton>
                        </ItemTemplate>
                        <ItemStyle Width="20px" />
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="Edit Contract Details"> 
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkEditContract" runat="server" CommandArgument='<%# Eval("CONT_PRESALE_ID") %>'
                            CommandName="EditContract" ><img src="../../Images/icon_edit.gif" alt="Edit Contract Details" style="border:0" /></asp:LinkButton>
                        </ItemTemplate>
                        <ItemStyle Width="20px" />
                    </asp:TemplateField>
                </Columns>
            <HeaderStyle CssClass="tr3" BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                 <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                 <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                 <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
            </asp:GridView>
             <asp:SqlDataSource ID="sdsStatus1" runat="server" ConnectionString="<%$ ConnectionStrings:CMConnectionString %>"
                ProviderName="<%$ ConnectionStrings:CMConnectionString.ProviderName %>" SelectCommand="SELECT [Meet_id], [Meet_status] FROM [PRESALE_LEAD]">
            </asp:SqlDataSource>
        </td></tr>    
    </table>
        <asp:SqlDataSource ID="sdsPresaleCase" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="SELECT DISTINCT A.CONT_PRESALE_ID, A.CONT_PRESALE_REF_NO,convert(varchar,A.LEAD_DATE,103) AS DATE,C.FULLNAME AS 'BD Manager',g.FullName as 'Lead By',B.CLIENT_NAME, 
A.CONTACT_PERSON AS 'Client officer Name',A.CONTACT_DESIGNATION AS 'Designation',D.ACTIVITY_NAME, A.PRESALE_STATUS, A.REMARK FROM 
PRESALE_CONTRACT_DETAIL AS A LEFT OUTER JOIN CLIENT_MASTER AS B ON A.CLIENT_ID = B.CLIENT_ID LEFT OUTER JOIN EMPLOYEE_MASTER C ON A.BD_MANAGER_ID=C.EMP_ID Left Outer Join Employee_master g on a.lead_by=g.emp_id 
LEFT OUTER JOIN
PRESALE_CONTRACT_ACTIVITY_PRODUCT E ON A.CONT_PRESALE_ID=E.CONT_PRESALE_ID LEFT OUTER JOIN ACTIVITY_MASTER D ON E.ACTIVITY_ID=D.ACTIVITY_ID
ORDER BY Date DESC
"></asp:SqlDataSource>
    <asp:SqlDataSource ID="sdsBDManager" runat="server" ConnectionString="<%$ ConnectionStrings:CMConnectionString %>"
        ProviderName="<%$ ConnectionStrings:CMConnectionString.ProviderName %>" SelectCommand="SELECT EMP_ID,FULLNAME FROM EMPLOYEE_MASTER A, USER_ROLE B WHERE A.EMP_ID=B.USER_ID AND B.ROLE_ID=19 AND (DOL is null or DOL = '') ORDER BY A.FULLNAME">
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="sdsLeadBy" runat="server" ConnectionString="<%$ ConnectionStrings:CMConnectionString %>"
        ProviderName="<%$ ConnectionStrings:CMConnectionString.ProviderName %>" SelectCommand="SELECT EMP_ID,FULLNAME FROM EMPLOYEE_MASTER A, USER_ROLE B WHERE A.EMP_ID=B.USER_ID AND B.ROLE_ID=19 AND (DOL is null or DOL = '') ORDER BY A.FULLNAME">
    </asp:SqlDataSource>
    <br />
</asp:Content>