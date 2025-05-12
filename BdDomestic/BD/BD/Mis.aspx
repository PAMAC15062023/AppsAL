<%@ Page Language="C#" MasterPageFile="~/BD/BD/BDMasterPage.master" AutoEventWireup="true" Theme="SkinFile" CodeFile="Mis.aspx.cs" Inherits="BD_Mis" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
     <div>
     <fieldset><legend class="legend"><asp:Label ID="Label5" runat="server" Text="MIS Report" ></asp:Label></legend>
    <table border="0" cellpadding="1" cellspacing="1" width="100%">   
    <tr><td><table border="0" cellpadding="2" cellspacing="2" width="100%">   
        <tr>
            <td colspan="8">
                <asp:RadioButton ID="RBTN_BD" SkinID="rdbSkin" runat="server" GroupName="GRP" Text="BD Wise" Checked="True"  />
                &nbsp; &nbsp;
                <asp:RadioButton ID="RBTN_CLIENT" SkinID="rdbSkin" runat="server" GroupName="GRP" Text="Client Wise"  /></td>
        </tr>
        <tr>
            <td>
                BD Manager</td>
            <td>
                &nbsp;:
            </td>
            <td >
                <asp:DropDownList ID="DDL_BD" SkinID="ddlSkin" runat="server" DataTextField="FULLNAME" DataValueField="EMP_ID" DataSourceID="SqlDataSourceBD" OnDataBinding="Page_Load" OnDataBound="DDL_BD_DataBound">
                    <asp:ListItem Selected="True"></asp:ListItem>
                    <asp:ListItem></asp:ListItem>
               
                </asp:DropDownList><asp:SqlDataSource ID="SqlDataSourceBD" runat="server" ConnectionString="<%$ ConnectionStrings:CMConnectionString %>"
                    ProviderName="<%$ ConnectionStrings:CMConnectionString.ProviderName %>" SelectCommand="SELECT EMP_ID,FULLNAME FROM EMPLOYEE_MASTER A, USER_ROLE B WHERE A.EMP_ID=B.USER_ID AND B.ROLE_ID=19 AND (DOL is null or DOL = '') ORDER BY A.FULLNAME">
                </asp:SqlDataSource>
            </td>
            <td>
            </td>
            <td>
                Activity</td>
            <td>
                &nbsp;:
            </td>
            <td>
                <asp:DropDownList ID="DDL_ACTIVITY"  SkinID="ddlSkin" runat="server" DataSourceID="SqlDataSourceActivity" DataTextField="ACTIVITY_NAME" DataValueField="ACTIVITY_ID" OnDataBinding="Page_Load" OnDataBound="DDL_ACTIVITY_DataBound" AutoPostBack="True"  >
                </asp:DropDownList><asp:SqlDataSource ID="SqlDataSourceActivity" runat="server" ConnectionString="<%$ ConnectionStrings:CMConnectionString %>"
                    ProviderName="<%$ ConnectionStrings:CMConnectionString.ProviderName %>" SelectCommand="SELECT [ACTIVITY_NAME], [ACTIVITY_ID] FROM [ACTIVITY_MASTER]">
                </asp:SqlDataSource>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td>
                Client</td>
            <td>
                &nbsp;:
            </td>
            <td>
                <asp:DropDownList ID="DDL_CLIENT" SkinID="ddlSkin" runat="server" DataSourceID="SqlDataSourceCient" DataTextField="CLIENT_NAME" DataValueField="CLIENT_ID" OnDataBinding="Page_Load" OnDataBound="DDL_Client_DataBound">
                </asp:DropDownList><asp:SqlDataSource ID="SqlDataSourceCient" runat="server" ConnectionString="<%$ ConnectionStrings:CMConnectionString %>"
                    ProviderName="<%$ ConnectionStrings:CMConnectionString.ProviderName %>" SelectCommand="SELECT CLIENT_NAME, CLIENT_ID FROM CLIENT_MASTER ORDER BY CLIENT_NAME">
                </asp:SqlDataSource>
            </td>
            <td>
            </td>
            <td>
                Product</td>
            <td>
                &nbsp;:
            </td>
            <td>
                <asp:DropDownList ID="DDL_PRODUCT"  SkinID="ddlSkin" runat="server" DataSourceID="SqlDataSource1" DataTextField="PRODUCT_NAME" DataValueField="PRODUCT_ID" OnDataBinding="Page_Load" OnDataBound="DDL_PRODUCT_DataBound" AutoPostBack="True" >
            </asp:DropDownList><asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:CMConnectionString %>"
                    ProviderName="<%$ ConnectionStrings:CMConnectionString.ProviderName %>" SelectCommand="SELECT DISTINCT PRODUCT_ID, PRODUCT_NAME FROM CE_AC_PR_CT_VW WHERE ([ACTIVITY_ID] = ?) AND PRODUCT_NAME IS NOT NULL">
                <SelectParameters>
                    <asp:ControlParameter ControlID="DDL_ACTIVITY" Name="ACTIVITY_ID" PropertyName="SelectedValue"
                        Type="String" />
                </SelectParameters>
                </asp:SqlDataSource>
            </td>
            <td>
    <asp:Button ID="BTN_VIEW" runat="server"  SkinID="btnGenerateReportSkin"  OnClick="BTN_VIEW_Click" Text="VIEW" ValidationGroup="vgrpMIS"/>
                <asp:Button ID="BTN_EXPORT"  SkinID= "btnExpToExlSkin"  runat="server" OnClick="BTN_EXPORT_Click"
                    Text="EXPORT"  /></td>
        </tr>
        <tr>
            <td colspan="8">
                <asp:RadioButtonList ID="rbtnDate" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem Selected="True" Value="0">All</asp:ListItem>
                    <asp:ListItem Value="1">Lead Generate Date</asp:ListItem>
                    <asp:ListItem Value="2">Meeting Date</asp:ListItem>
                    <asp:ListItem Value="3">Close Date</asp:ListItem>
                </asp:RadioButtonList></td>
        </tr>
        <tr>
            <td>
                From Date</td>
            <td>
                :</td>
            <td>
                <asp:TextBox ID="txtFromDt" runat="server" MaxLength="10" SkinID="txtSkin"></asp:TextBox>
                <img alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtFromDt.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                    src="../../Images/SmallCalendar.gif" /></td>
            <td>
            </td>
            <td>
                To Date</td>
            <td>
                :</td>
            <td>
                <asp:TextBox ID="txtToDt" runat="server" MaxLength="10" SkinID="txtSkin"></asp:TextBox>
                <img alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtToDt.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                    src="../../Images/SmallCalendar.gif" /></td>
            <td>
            </td>
        </tr>
        </table> 
        </td></tr>
        <tr>
            <td align="left">
                &nbsp;<asp:Label ID="lblMsg" runat="server" SkinID="lblErrorMsg"></asp:Label></td>
        </tr>
        <tr>
            <td>
           <asp:GridView ID="GridView1" runat="server" Width="100%" SkinID="gridviewNoSort">               
           </asp:GridView>
            </td>            
        </tr>
    </table>
         <asp:RegularExpressionValidator ID="revFromDt" runat="server" ErrorMessage="Please enter valid date format for From Date"
             ValidationGroup="vgrpMIS" ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d" SetFocusOnError="true" ControlToValidate="txtFromDt" Display="None"></asp:RegularExpressionValidator>
         <asp:RegularExpressionValidator ID="revToDt" runat="server" ControlToValidate="txtToDt"
             Display="None" ErrorMessage="Please enter valid date format for From Date" SetFocusOnError="true"
             ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d"
             ValidationGroup="vgrpMIS"></asp:RegularExpressionValidator>
         <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
             ShowSummary="False" ValidationGroup="vgrpMIS" />
     </fieldset></div> 
   </asp:Content>
