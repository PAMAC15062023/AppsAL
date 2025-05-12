<%@ Page Language="C#" MasterPageFile="~/BD/BD/BDMasterPage.master" AutoEventWireup="true" CodeFile="MeetingDetails.aspx.cs" Inherits="MeetingDetails" Theme="SkinFile" %>
<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
    <fieldset><legend class="legend">Meeting Details</legend>
    <table width="100%" border="1" cellpadding="0" cellspacing="0">
    <tr><td>&nbsp;<asp:Label ID="lblMsg" runat="server" SkinID="lblErrorMsg"></asp:Label></td></tr>
    <tr><td>    
   <table width="100%" border="0" cellpadding="1" cellspacing="1">
   <tr>
       <td class="tr1">Presale Contract Details View</td></tr>      
       <tr>
           <td>
               <asp:GridView ID="gvPresaleCase" runat="server" AutoGenerateColumns="False" DataSourceID="sdsPresaleCase"
                    SkinID="gridviewNoSort" Width="100%">
                   <RowStyle Font-Bold="False" ForeColor="Black" />
                   <Columns>
                       <asp:BoundField DataField="CONT_PRESALE_REF_NO" HeaderText="Contract Ref No" SortExpression="CONT_PRESALE_REF_NO" />
                       <asp:BoundField DataField="CLIENT_NAME" HeaderText="Client Name" SortExpression="CLIENT_NAME" />
                       <asp:BoundField DataField="PRESALE_STATUS" HeaderText="Status" SortExpression="PRESALE_STATUS" />
                       <asp:BoundField DataField="REMARK" HeaderText="Remark" SortExpression="REMARK" />                      
                   </Columns>
                   <HeaderStyle CssClass="tr3" />
               </asp:GridView>
           </td>
       </tr>
        <tr>
       <td class="tr1">Meeting Details View</td></tr>
        <tr><td>
        <asp:GridView ID="gvMeetingDetails" runat="server" Width="100%" CellPadding="1" DataSourceID="sdsMeetingView" AutoGenerateColumns="False" OnRowDataBound="gvMeetingDetails_RowDataBound" OnRowCommand="gvMeetingDetails_RowCommand" SkinID="gridviewNoSort">
        <RowStyle Font-Bold="False" ForeColor="Black" />
            <Columns>
                <asp:TemplateField HeaderText="Nbr">
                    <ItemTemplate>
                    <asp:Label ID="lblNo" runat="server" ></asp:Label>
                    </ItemTemplate>                    
                </asp:TemplateField>
                <asp:BoundField DataField="FULLNAME" HeaderText="Contacted By" SortExpression="FULLNAME" />
                <asp:BoundField DataField="MEETING_STATUS" HeaderText="Meeting For" SortExpression="MEETING_STATUS" />
                <asp:BoundField DataField="Meet_status" HeaderText="Lead Is" SortExpression="Meet_status" />
                <asp:BoundField DataField="MEETING_DATE" HeaderText="Meeting Date" SortExpression="MEETING_DATE" DataFormatString="{0:dd/MM/yyyy}" HtmlEncode="False" />
                <asp:BoundField DataField="MEETING_PLACE" HeaderText="Meeting Place" SortExpression="MEETING_PLACE" />
                <asp:BoundField DataField="OFFICER_NAME" HeaderText="Officer Name" SortExpression="OFFICER_NAME" />
                <asp:BoundField DataField="MINUTES_MEETING" HeaderText="Minutes of Meeting" SortExpression="MINUTES_MEETING" />
                <asp:BoundField DataField="REMARK" HeaderText="Remark" SortExpression="REMARK" />
                <asp:TemplateField> 
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkEditMeeting" runat="server" CommandArgument='<%# Eval("MEETING_DET_ID") %>'
                            CommandName="EditMeeting" ><img src="../../Images/icon_edit.gif" alt="Edit Meeting Details" style="border:0" /></asp:LinkButton>
                        </ItemTemplate>
                        <ItemStyle Width="20px" />
                    </asp:TemplateField>
            </Columns>
        </asp:GridView>
        </td></tr>
    </table>
    </td></tr>
    <tr><td class="tr1">Meeting Details</td></tr>
    <tr><td>
        <table width="100%" border="0" cellpadding="2" cellspacing="2">
        <tr>
            <td valign="top">Contacted By<span style="color:Red;">*</span></td><td>:</td>
            <td valign="top"><asp:DropDownList ID="ddlContactBy" runat="server" CssClass="textbox" DataSourceID="sdsContactedBy" DataTextField="FULLNAME" DataValueField="EMP_ID" SkinID="ddlSkin">                       
                    </asp:DropDownList></td>
                    <td valign="top">Officer Name<span style="color:Red;">*</span></td><td>:</td>
           <td valign="top">
                <asp:TextBox ID="txtOfficer" runat="server" CssClass="textbox" MaxLength="100" SkinID="txtSkin"></asp:TextBox></td>            
               <td valign="top">Lead Is<span style="color:Red;">*</span></td><td>:</td>
            <td valign="top"><asp:DropDownList ID="ddlMeetinglead" runat="server" CssClass="textbox" DataSourceID="sdsStatus1" OnDataBound="ddlMeetinglead_DataBound" SkinID="ddlSkin" DataTextField="Meet_status" DataValueField="Meet_id">                        
                    </asp:DropDownList></td>
        </tr>
        <tr><td valign="top">Meeting For<span style="color:Red;">*</span></td><td>:</td>
            <td valign="top"><asp:DropDownList ID="ddlMeetingFor" runat="server" CssClass="textbox" DataSourceID="sdsStatus" DataTextField="MEETING_STATUS" DataValueField="MEETING_ID" OnDataBound="ddlMeetingFor_DataBound" SkinID="ddlSkin">                        
                    </asp:DropDownList></td>
            <td valign="top">Meeting Date<span style="color:Red;">*</span></td><td>:</td>
            <td valign="top">
                <asp:TextBox ID="txtMeetingDate" runat="server" CssClass="textbox" MaxLength="10" SkinID="txtSkin"></asp:TextBox>&nbsp;
                <img alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtMeetingDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                    src="../../Images/SmallCalendar.gif" /></td>
            <td valign="top">Meeting Place<span style="color:Red;">*</span></td><td>:</td>
            <td valign="top">
                <asp:TextBox ID="txtPlace" runat="server" CssClass="textbox" MaxLength="100" SkinID="txtSkin"></asp:TextBox></td></tr>
         <tr>
            
            <td valign="top">Minutes of Meeting</td><td>:</td>
            <td valign="top">
                <asp:TextBox ID="txtMoM" runat="server" TextMode="MultiLine" CssClass="textbox" MaxLength="500" SkinID="txtSkin" Columns="50" Rows="5"></asp:TextBox></td>
            <td valign="top">Remark</td><td>:</td>
            <td valign="top" colspan="4">
                <asp:TextBox ID="txtRemark" runat="server" TextMode="MultiLine" CssClass="textbox" MaxLength="1000" SkinID="txtSkin" Columns="60" Rows="5"></asp:TextBox></td>            
        </tr>
         <tr>
            <td valign="top">Confirmed</td><td>:</td>
            <td valign="top">
                <asp:CheckBox ID="chkConfirm" runat="server" Text="Yes" SkinID="chkSkin"  />
            </td>
                <td valign="top">Source of Confirmation</td><td>:</td>
            <td valign="top">
                <asp:TextBox ID="txtConfirmSource" runat="server" CssClass="textbox" MaxLength="200" SkinID="txtSkin"></asp:TextBox></td>           
            <td valign="top">Confirm Date</td><td>:</td>
            <td valign="top">
                <asp:TextBox ID="txtConfirmDate" runat="server" CssClass="textbox" MaxLength="10" SkinID="txtSkin"></asp:TextBox>&nbsp;
                <img alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtConfirmDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                    src="../../Images/SmallCalendar.gif" /></td>        
        </tr>
         <tr>
        <td valign="top">Order No</td><td>:</td>
            <td valign="top">
                <asp:TextBox ID="txtOrderNo" runat="server" CssClass="textbox" MaxLength="100" SkinID="txtSkin"></asp:TextBox></td>           
            <td valign="top">Order Date</td><td>:</td>
            <td valign="top" colspan="4">
                <asp:TextBox ID="txtOrderDate" runat="server" CssClass="textbox" MaxLength="10" SkinID="txtSkin"></asp:TextBox>&nbsp;
                <img alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtOrderDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                    src="../../Images/SmallCalendar.gif" /></td>                         
        </tr>
        <tr>
            <td align="center" colspan="9">
                <asp:Button ID="btnSubmit" runat="server" Text="Submit" ValidationGroup="vgrpMeetingDetails" OnClick="btnSubmit_Click" SkinID="btnSubmitSkin" />
                <asp:Button ID="btnReset" runat="server" OnClick="btnReset_Click" Text="Reset" SkinID="btnResetSkin" />
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" SkinID="btnCancelSkin" /></td>
        </tr>
        </table>
    </td></tr>
    </table>
    </fieldset>
    </div>
        <asp:RequiredFieldValidator ID="rfvConBy" runat="server" Display="None"
            ErrorMessage="Please select Contacted By" SetFocusOnError="True" ControlToValidate="ddlContactBy" ValidationGroup="vgrpMeetingDetails"></asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="rfvMeetingFor" runat="server" Display="None"
            ErrorMessage="Please select Meeting For" SetFocusOnError="True" ControlToValidate="ddlMeetingFor" ValidationGroup="vgrpMeetingDetails"></asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="rfvDate" runat="server" Display="None"
            ErrorMessage="Please enter Meeting Date" SetFocusOnError="True" ControlToValidate="txtPlace" ValidationGroup="vgrpMeetingDetails"></asp:RequiredFieldValidator>
          <asp:RequiredFieldValidator ID="rfvlead" runat="server" ControlToValidate="ddlMeetinglead"
        ErrorMessage="pls select lead type" Display="None" SetFocusOnError="True" ValidationGroup="vgrpMeetingDetails"></asp:RequiredFieldValidator>  
        <asp:RequiredFieldValidator ID="rfvPlace" runat="server" Display="None"
            ErrorMessage="Please enter Meeting Place" SetFocusOnError="True" ControlToValidate="txtPlace" ValidationGroup="vgrpMeetingDetails"></asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="rfvOName" runat="server" Display="None"
            ErrorMessage="Please enter Officer Name" SetFocusOnError="True" ControlToValidate="txtOfficer" ValidationGroup="vgrpMeetingDetails"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="revMeetingDate" runat="server" ControlToValidate="txtMeetingDate"
            Display="None" ErrorMessage="Please enter valid date format for Meeting Date"
            SetFocusOnError="True" ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d"
            ValidationGroup="vgrpMeetingDetails"></asp:RegularExpressionValidator>
        <asp:RegularExpressionValidator ID="revConfirmDate" runat="server" ControlToValidate="txtConfirmDate"
            Display="None" ErrorMessage="Please enter valid date format for Confirm Date"
            SetFocusOnError="True" ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d"
            ValidationGroup="vgrpMeetingDetails"></asp:RegularExpressionValidator>
        <asp:RegularExpressionValidator ID="revOrderDate" runat="server" ControlToValidate="txtOrderDate"
            Display="None" ErrorMessage="Please enter valid date format for Order Date"
            SetFocusOnError="True" ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d"
            ValidationGroup="vgrpMeetingDetails"></asp:RegularExpressionValidator>
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
            ShowSummary="False" ValidationGroup="vgrpMeetingDetails" />
        <asp:SqlDataSource ID="sdsContactedBy" runat="server" ConnectionString="<%$ ConnectionStrings:CMConnectionString %>"
            ProviderName="<%$ ConnectionStrings:CMConnectionString.ProviderName %>" SelectCommand="SELECT EMPLOYEE_MASTER.FULLNAME, EMPLOYEE_MASTER.EMP_ID FROM PRESALE_CONTRACT_DETAIL INNER JOIN EMPLOYEE_MASTER ON PRESALE_CONTRACT_DETAIL.BD_MANAGER_ID = EMPLOYEE_MASTER.EMP_ID WHERE (PRESALE_CONTRACT_DETAIL.CONT_PRESALE_ID = ?)">
            <SelectParameters>
                <asp:ControlParameter ControlID="hdnContID" Name="CONT_PRESALE_ID" PropertyName="Value"
                    Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
          &nbsp;
        <asp:SqlDataSource ID="sdsMeetingView" runat="server" ConnectionString="<%$ ConnectionStrings:CMConnectionString %>" ProviderName="<%$ ConnectionStrings:CMConnectionString.ProviderName %>" SelectCommand="SELECT PRESALE_CONTRACT_MEETING_DETAIL.CONT_PRESALE_ID, PRESALE_CONTRACT_MEETING_DETAIL.CONTACT_EMP_ID, PRESALE_MEETING_STATUS.MEETING_STATUS,PRESALE_LEAD.Meet_status,&#13;&#10;PRESALE_CONTRACT_MEETING_DETAIL.MEETING_DATE, PRESALE_CONTRACT_MEETING_DETAIL.MEETING_PLACE, PRESALE_CONTRACT_MEETING_DETAIL.OFFICER_NAME, PRESALE_CONTRACT_MEETING_DETAIL.MINUTES_MEETING, PRESALE_CONTRACT_MEETING_DETAIL.REMARK, EMPLOYEE_MASTER.FULLNAME, PRESALE_CONTRACT_MEETING_DETAIL.MEETING_DET_ID FROM PRESALE_CONTRACT_MEETING_DETAIL LEFT OUTER JOIN PRESALE_MEETING_STATUS ON PRESALE_CONTRACT_MEETING_DETAIL.MEETING_FOR = PRESALE_MEETING_STATUS.MEETING_ID LEFT OUTER JOIN PRESALE_LEAD &#13;&#10;ON PRESALE_CONTRACT_MEETING_DETAIL.Meeting_Lead = PRESALE_LEAD.Meet_id&#13;&#10;LEFT OUTER JOIN EMPLOYEE_MASTER ON PRESALE_CONTRACT_MEETING_DETAIL.CONTACT_EMP_ID = EMPLOYEE_MASTER.EMP_ID WHERE (PRESALE_CONTRACT_MEETING_DETAIL.CONT_PRESALE_ID = ?) ORDER BY PRESALE_CONTRACT_MEETING_DETAIL.MEETING_DATE DESC">
            <SelectParameters>
                <asp:ControlParameter ControlID="hdnContID" Name="CONT_PRESALE_ID" PropertyName="Value"
                    Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="sdsStatus" runat="server" ConnectionString="<%$ ConnectionStrings:CMConnectionString %>" ProviderName="<%$ ConnectionStrings:CMConnectionString.ProviderName %>" SelectCommand="SELECT [MEETING_ID], [MEETING_STATUS] FROM [PRESALE_MEETING_STATUS]"></asp:SqlDataSource>
       &nbsp;
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:CMConnectionString %>" ProviderName="<%$ ConnectionStrings:CMConnectionString.ProviderName %>" SelectCommand="SELECT [MEETING_ID], [MEETING_STATUS] FROM [PRESALE_MEETING_STATUS]"></asp:SqlDataSource><asp:SqlDataSource ID="sdsStatus1" runat="server" ConnectionString="<%$ ConnectionStrings:CMConnectionString %>" ProviderName="<%$ ConnectionStrings:CMConnectionString.ProviderName %>" SelectCommand="SELECT [Meet_id], [Meet_status] FROM [PRESALE_LEAD]">
        </asp:SqlDataSource>
         <asp:HiddenField ID="hdnContID" runat="server" />
         <asp:HiddenField ID="hdnMeetingID" runat="server" />
         <asp:HiddenField ID="hdnMode" runat="server" />
         <asp:SqlDataSource ID="sdsPresaleCase" runat="server" ConnectionString="<%$ ConnectionStrings:CMConnectionString %>" ProviderName="<%$ ConnectionStrings:CMConnectionString.ProviderName %>" SelectCommand="SELECT A.CONT_PRESALE_ID, A.CONT_PRESALE_REF_NO, A.PRESALE_STATUS, A.REMARK, B.CLIENT_NAME FROM PRESALE_CONTRACT_DETAIL AS A LEFT OUTER JOIN CLIENT_MASTER AS B ON A.CLIENT_ID = B.CLIENT_ID WHERE  A.CONT_PRESALE_ID=?&#13;&#10;ORDER BY A.CONT_PRESALE_REF_NO DESC">
             <SelectParameters>
                 <asp:ControlParameter ControlID="hdnContID" Name="?" PropertyName="Value" />
             </SelectParameters>
         </asp:SqlDataSource>
  </asp:Content>
