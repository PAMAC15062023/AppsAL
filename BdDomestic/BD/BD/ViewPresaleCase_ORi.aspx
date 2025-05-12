<%@ Page Language="C#" MasterPageFile="~/BD/BD/BDMasterPage.master" AutoEventWireup="true" CodeFile="ViewPresaleCase.aspx.cs" Inherits="ViewPresaleCase" Theme="SkinFile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
     <fieldset><legend class="legend">View Presale Case</legend>
     <table width="100%" border="0">
      <tr>
              <td style="width: 40px">
              </td>
              <td style="width: 72px">
                  <asp:Label ID="lblMsg" runat="server" EnableViewState="False" SkinID="lblErrorMsg"></asp:Label></td>
              <td align="right">
                  <asp:Label ID="Label2" runat="server" Font-Bold="True" SkinID="lblSkin"  Visible="false" Text="[View]"></asp:Label></td>
          </tr>
               <tr>
                  <td style="width: 72px" >
                    <asp:Label ID="lblbd" runat="server" Text="BDManager" Visible="False" Width="89px"></asp:Label>
                  <asp:DropDownList ID="ddlBDManager" runat="server" CssClass="textbox" DataSourceID="sdsBDManager" Visible="false" DataTextField="FULLNAME" DataValueField="EMP_ID" OnDataBound="ddlBDManager_DataBound" SkinID="ddlSkin">                       
                    </asp:DropDownList></td>
                     <td style="height: 34px; width: 40px;">
                     <asp:Label ID="lblleadby" runat="server" Text="LeadGeneratedBy" Visible="False" Width="137px"></asp:Label>
                  <asp:DropDownList ID="ddlLeadBy" runat="server" CssClass="textbox" Visible="false" DataSourceID="sdsLeadBy" DataTextField="FULLNAME" DataValueField="EMP_ID" OnDataBound="ddlLeadBy_DataBound" SkinID="ddlSkin">
                    </asp:DropDownList></td>
                  <td align="left">
                      &nbsp;LeadStatus<br />
                  <asp:DropDownList ID="ddlMeetinglead" runat="server" CssClass="textbox" DataSourceID="sdsStatus1"
                DataTextField="Meet_status" DataValueField="Meet_id" OnDataBound="ddlMeetinglead_DataBound"
                SkinID="ddlSkin">
            </asp:DropDownList>
                  </td>
          </tr>
           <tr >
              <td align="right" colspan="2">
              <asp:Button ID="btnshow" runat="server" Text="Show" OnClick="btnshow_Click" SkinID="btn" /></td>
               <td align="left" colspan="1">
                 <asp:Button ID="btnNew" runat="server" Text="New Contract" OnClick="btnNew_Click" SkinID="btnAddNewSkin" />
                  &nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
              </td>
             </tr>
          <tr><td colspan="4" style="height: 458px">
             <asp:GridView ID="gvPresaleCase" runat="server" Width="100%" AutoGenerateColumns="False" OnRowCommand="gvPresaleCase_RowCommand"  SkinID="gridviewNoSort" PageSize="20" AllowPaging="True" OnPageIndexChanging="gvPresaleCase_PageIndexChanging">
            <RowStyle ForeColor="Black" Font-Bold="False" />
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
            <HeaderStyle CssClass="tr3" />
            </asp:GridView>
             <asp:SqlDataSource ID="sdsStatus1" runat="server" ConnectionString="<%$ ConnectionStrings:CMConnectionString %>"
                ProviderName="<%$ ConnectionStrings:CMConnectionString.ProviderName %>" SelectCommand="SELECT [Meet_id], [Meet_status] FROM [PRESALE_LEAD]">
            </asp:SqlDataSource>
        </td></tr>    
    </table>
    </fieldset>
    </div>
        <asp:SqlDataSource ID="sdsPresaleCase" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="SELECT DISTINCT A.CONT_PRESALE_ID, A.CONT_PRESALE_REF_NO,convert(varchar,A.LEAD_DATE,103) AS DATE,C.FULLNAME AS 'BD Manager',g.FullName as 'Lead By',B.CLIENT_NAME, &#13;&#10;A.CONTACT_PERSON AS 'Client officer Name',A.CONTACT_DESIGNATION AS 'Designation',D.ACTIVITY_NAME, A.PRESALE_STATUS, A.REMARK FROM &#13;&#10;PRESALE_CONTRACT_DETAIL AS A LEFT OUTER JOIN CLIENT_MASTER AS B ON A.CLIENT_ID = B.CLIENT_ID LEFT OUTER JOIN EMPLOYEE_MASTER C ON A.BD_MANAGER_ID=C.EMP_ID Left Outer Join Employee_master g on a.lead_by=g.emp_id LEFT OUTER JOIN&#13;&#10;PRESALE_CONTRACT_ACTIVITY_PRODUCT E ON A.CONT_PRESALE_ID=E.CONT_PRESALE_ID LEFT OUTER JOIN ACTIVITY_MASTER D ON E.ACTIVITY_ID=D.ACTIVITY_ID&#13;&#10;ORDER BY Date DESC&#13;&#10;"></asp:SqlDataSource>
    <asp:SqlDataSource ID="sdsBDManager" runat="server" ConnectionString="<%$ ConnectionStrings:CMConnectionString %>"
        ProviderName="<%$ ConnectionStrings:CMConnectionString.ProviderName %>" SelectCommand="SELECT EMP_ID,FULLNAME FROM EMPLOYEE_MASTER A, USER_ROLE B WHERE A.EMP_ID=B.USER_ID AND B.ROLE_ID=19 AND (DOL is null or DOL = '') ORDER BY A.FULLNAME">
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="sdsLeadBy" runat="server" ConnectionString="<%$ ConnectionStrings:CMConnectionString %>"
        ProviderName="<%$ ConnectionStrings:CMConnectionString.ProviderName %>" SelectCommand="SELECT EMP_ID,FULLNAME FROM EMPLOYEE_MASTER A, USER_ROLE B WHERE A.EMP_ID=B.USER_ID AND B.ROLE_ID=19 AND (DOL is null or DOL = '') ORDER BY A.FULLNAME">
    </asp:SqlDataSource>
    <br />
</asp:Content>