<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/BD/BD/BDMasterPage.master" CodeFile="ContractDetail.aspx.cs" Inherits="BD_ContractDetail" Theme="SkinFile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<script language="javascript" type="text/javascript">
function funDateDiff(source, arguments)
    {
    
	    //This function is created by Manoj to find the days
    var strFromDate = document.getElementById("<%=txtContractDate.ClientID %>").value;
    var strToDate = document.getElementById("<%=txtImplementDate.ClientID %>").value;
	    //===Replaceing the string format "dd-MMM-yyyy" to dd MMM yyyy
//	    var strNewFromDate = strFromDate
//	    var strNewToDate = strToDate
        dateNull = new Date();
        dateNull = null;
    //      ===split and fill into array

        var arFromDate = strFromDate.split('/');

        var arToDate = strToDate.split('/');

//         ===Replaceing the string format "dd/mm/yyyy" to mm/dd/yyyy

        var strNewFromDate = arFromDate[1]+"/"+arFromDate[0]+"/"+arFromDate[2];

        var strNewToDate=arToDate[1]+"/"+arToDate[0]+"/"+arToDate[2];

	    //==Converting the string to date format
	    dtFromDate = new Date(strNewFromDate);
	    dtToDate = new Date(strNewToDate);

	    //declareing the date variable
	    date1 = new Date();
	    date2 = new Date();
	    diff  = new Date();
    	    
	    //setTime 
	    date1.setTime(dtFromDate.getTime());
	    date2.setTime(dtToDate.getTime());

	    //Difference in MilliSeconds
	    diff.setTime(Math.floor(date2.getTime()-date1.getTime()));
	    timediff = diff.getTime();
	    //No of Days
	    days = Math.floor(timediff / (1000 * 60 * 60 * 24));
	    
	    if(days>10)
	     arguments.IsValid=true;
	    else
	     arguments.IsValid=false;
   }  
</script>
    <div><fieldset><legend class="legend">Confirm Contract Detail</legend>
    <table  width="100%" border="0" cellpadding="0" cellspacing="0">    
        <tr>
            <td>
                <asp:Label ID="lblMgs" runat="server" CssClass="msg"></asp:Label></td>
        </tr>
    <tr><td><table>
    <tr>
        <td class="label">Presale Contract Ref No</td><td>:</td><td>
        <asp:Label ID="lblContRefNo" runat="server"></asp:Label></td>
        <td class="label">Client Name</td><td>:</td><td>
        <asp:Label ID="lblClientName" runat="server"></asp:Label></td>
        <td class="label">Order No</td><td>:</td><td>
        <asp:Label ID="lblOrderNo" runat="server"></asp:Label></td>
        <td class="label">Order Date</td><td>:</td><td>
        <asp:Label ID="lblOrderDate" runat="server"></asp:Label></td>        
    </tr>
     </table></td></tr>
    <tr><td class="tr1">Contract Detail</td></tr>
    <tr>
    <td><table>
            <tr>
                <td>Contract No<span style="color: red">*</span></td><td>:</td><td>
                    <asp:TextBox ID="txtContractNo" runat="server" MaxLength="50" SkinID="txtSkin" ReadOnly="False"></asp:TextBox>
                    <%--<asp:ImageButton ID="imgGet" runat="server" ImageUrl="~/Images/find.gif" AlternateText="Get Unique ID" OnClick="imgGet_Click" ToolTip="Get Unique ID" Visible="False" />--%></td>
                <td>Contract Date</td><td>:</td><td><asp:TextBox ID="txtContractDate" runat="server" MaxLength="10" SkinID="txtSkin"></asp:TextBox>
                    <img alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtContractDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                        src="../../Images/SmallCalendar.gif" /></td>                
            </tr>
            <tr>
                <td>Contract Expiry Date</td><td>:</td><td><asp:TextBox ID="txtExpiryDate" runat="server" MaxLength="10" SkinID="txtSkin"></asp:TextBox>
                    <img alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtExpiryDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                        src="../../Images/SmallCalendar.gif" /></td>
                <td>Project Implement Date</td><td>:</td><td><asp:TextBox ID="txtImplementDate" runat="server" MaxLength="10" SkinID="txtSkin"></asp:TextBox>
                    <img alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtImplementDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                        src="../../Images/SmallCalendar.gif" /></td>                
            </tr>
            <tr>
                <td>Project Start Date<span style="color:Red">*</span></td><td>:</td><td><asp:TextBox ID="txtStartDate" runat="server" MaxLength="10" SkinID="txtSkin"></asp:TextBox>
                    <img alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtStartDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                        src="../../Images/SmallCalendar.gif" /></td>
                <td>Project Implemented By</td><td>:</td><td>
                    <asp:DropDownList ID="ddlImplementedBy" runat="server" DataSourceID="sdsImplementedBy" DataTextField="FULLNAME" DataValueField="EMP_ID" OnDataBound="ddlImplementedBy_DataBound" SkinID="ddlSkin">
                    </asp:DropDownList></td>                
            </tr>
            <tr>
                <td>Expected To</td><td>:</td><td><asp:TextBox ID="txtExpectedTo" runat="server" MaxLength="50" SkinID="txtSkin"></asp:TextBox></td>
                <td>Status After 3 months</td><td>:</td><td><asp:TextBox ID="txtStatusAfterMonths" runat="server" MaxLength="50" SkinID="txtSkin"></asp:TextBox></td>                
            </tr>
        <tr>
            <td>
                    Minimum Volume/month</td>
            <td>
                :</td>
            <td>
                <asp:TextBox ID="txtMinVolMonth" runat="server" MaxLength="10" SkinID="txtSkin"></asp:TextBox></td>
            <td>
                Minimum Guarantee/month</td>
            <td>
                :</td>
            <td>
                <asp:TextBox ID="txtMinGrtMonth" runat="server" MaxLength="10" SkinID="txtSkin"></asp:TextBox></td>
        </tr>
            <tr>
                <td valign="top">
                    Tax Inclusive/ Exclusive</td><td valign="top">:</td><td valign="top">
                    <asp:DropDownList ID="ddlTaxing" runat="server" SkinID="ddlSkin">
                        <asp:ListItem>--Select--</asp:ListItem>
                        <asp:ListItem Value="I">Inclusive</asp:ListItem>
                        <asp:ListItem Value="E">Exclusive</asp:ListItem>
                    </asp:DropDownList></td>
                <td colspan="3">
                    &nbsp;</td>                
            </tr>
    </table>
    </td>
    </tr>       
        <tr>
            <td>
                &nbsp;</td>
        </tr>
    <tr><td class="tr1">Rate Chart</td></tr>
    <tr><td style="height: 143px"><table border="0" cellpadding="1" cellspacing="1" width="100%">
       <%-- <tr><td>
           <asp:LinkButton ID="lnkInsertRateChart" runat="server" OnClick="lnkInsertRateChart_Click">Insert Rate Chart</asp:LinkButton>
            <asp:LinkButton ID="lnkRemoveRateChart" runat="server" OnClick="lnkRemoveRateChart_Click">Remove Rate Chart</asp:LinkButton>
            </td></tr>--%>
            <tr>
            <td>
            <table border="0" cellpadding="1" cellspacing="1" width="100%">
            <tr class="tr1">
            <td>
                Centre</td>
            <td>Activity</td>
            <td>Product</td>
            <td>Verification Type</td>
            <td>Rate</td>
                <td>
                </td>
            </tr>
            <tr>
            <td> <asp:DropDownList ID="ddlCentre" runat="server" DataSourceID="sdsCentre" DataTextField="CENTRE_NAME" DataValueField="CENTRE_ID" AutoPostBack="true" SkinID="ddlSkin" OnSelectedIndexChanged="ddlCentre_SelectedIndexChanged">
                 </asp:DropDownList>
                 <asp:SqlDataSource ID="sdsCentre" runat="server" ConnectionString="<%$ ConnectionStrings:CMConnectionString %>" ProviderName="<%$ ConnectionStrings:CMConnectionString.ProviderName %>" SelectCommand="SELECT '' AS CENTRE_ID, '--Select--' AS CENTRE_NAME UNION SELECT DISTINCT CENTRE_ID, CENTRE_NAME FROM CE_AC_PR_CT_VW WHERE CENTRE_NAME IS NOT NULL"></asp:SqlDataSource>
                <asp:RequiredFieldValidator ID="rfvCentre" runat="server" ErrorMessage="Please select Centre" ValidationGroup="grpRateChart1" ControlToValidate="ddlCentre" Display="None" SetFocusOnError="True"></asp:RequiredFieldValidator>
            </td>
            <td>
            <asp:DropDownList ID="ddlActivity" runat="server" DataSourceID="" DataTextField="ACTIVITY_NAME" DataValueField="ACTIVITY_ID" AutoPostBack="true" SkinID="ddlSkin" OnSelectedIndexChanged="ddlActivity_SelectedIndexChanged">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="sdsActivity" runat="server" ConnectionString="<%$ ConnectionStrings:CMConnectionString %>" ProviderName="<%$ ConnectionStrings:CMConnectionString.ProviderName %>" SelectCommand="SELECT DISTINCT activity_id, ACTIVITY_NAME FROM ce_ac_pr_ct_vw WHERE (CENTRE_ID = ?) AND (ACTIVITY_NAME IS NOT NULL)">
                        <SelectParameters>
                           <asp:ControlParameter ControlID="ddlCentre" Name="CENTRE_ID" PropertyName="SelectedValue" Type="String" />
                        </SelectParameters>
                    </asp:SqlDataSource>        
                <asp:RequiredFieldValidator ID="rfvActivity" runat="server" ControlToValidate="ddlActivity"
                    Display="None" ErrorMessage="Please select Activity" SetFocusOnError="True" ValidationGroup="grpRateChart1"></asp:RequiredFieldValidator></td>
            <td><asp:DropDownList ID="ddlProduct" runat="server" DataSourceID="" DataTextField="PRODUCT_NAME" DataValueField="product_id" SkinID="ddlSkin" >
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="sdsProduct" runat="server" ConnectionString="<%$ ConnectionStrings:CMConnectionString %>" ProviderName="<%$ ConnectionStrings:CMConnectionString.ProviderName %>" SelectCommand="SELECT DISTINCT PRODUCT_ID, PRODUCT_NAME FROM CE_AC_PR_CT_VW WHERE ([ACTIVITY_ID] = ?) AND PRODUCT_NAME IS NOT NULL">
                         <SelectParameters>
                             <asp:ControlParameter ControlID="ddlActivity" Name="activity_id" PropertyName="SelectedValue"
                                 Type="String" />
                         </SelectParameters>
                    </asp:SqlDataSource>
                <asp:RequiredFieldValidator ID="rfvProduct" runat="server" ControlToValidate="ddlProduct"
                    Display="None" ErrorMessage="Please select Product" SetFocusOnError="True" ValidationGroup="grpRateChart1"></asp:RequiredFieldValidator></td>
            <td>                    <asp:TextBox ID="txtType" runat="server" SkinID="txtSkin" MaxLength = "15" Text='<%# Bind("VERIFICATION_TYPE") %>'></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvType" runat="server" ControlToValidate="txtType"
                    Display="None" ErrorMessage="Please enter Type" SetFocusOnError="True" ValidationGroup="grpRateChart1"></asp:RequiredFieldValidator>
</td>
            <td>                    <asp:TextBox ID="txtRate" runat="server" SkinID="txtSkin" Text='<%# Bind("RATE") %>'></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvRate" runat="server" ControlToValidate="txtRate"
                    Display="None" ErrorMessage="Please enter Rate" SetFocusOnError="True" ValidationGroup="grpRateChart1"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="revRate" runat="server" ControlToValidate="txtRate" Display="None" ErrorMessage="Please enter only numbers for Rate" SetFocusOnError="True" ValidationGroup="grpRateChart1" ValidationExpression="^[0-9]*$"></asp:RegularExpressionValidator></td>
                <td>
            <asp:Button ID="btnAdd" runat="server" Text="Add" SkinID="btnSaveSkin" OnClick="btnAdd_Click" ValidationGroup="grpRateChart1" />&nbsp;<asp:Button
                        ID="btnCancelRC" runat="server" OnClick="btnCancelRC_Click" SkinID="btnCancelSkin" Text="Cancel" />
                    <asp:HiddenField ID="hdnIndex" runat="server" />
                    <asp:HiddenField ID="hdnRateChart" runat="server" />
                </td>
            </tr>
            </table>
            </td>
        </tr>
            </table>
    </td></tr>
    <tr><td>
        <asp:GridView ID="gvRateChart" runat="server" AutoGenerateColumns="False" SkinID="gridviewNoSort" Width="100%" OnRowCommand="gvRateChart_RowCommand">
            <Columns>               
                <asp:TemplateField HeaderText="Centre">
                <ItemTemplate>
                    <asp:Label ID="lblCentre" runat="server" Text='<%# Bind("CENTRE_NAME") %>'></asp:Label>
                    <asp:HiddenField ID="hdnCentre" runat="server" Value='<%# Bind("CENTRE_ID") %>' />
                </ItemTemplate>
                    <EditItemTemplate>
                        <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="sdsCentre" DataTextField="CENTRE_NAME"
                            DataValueField="CENTRE_ID">
                        </asp:DropDownList>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Activity">
                <ItemTemplate>
                    <asp:Label ID="lblAcitity" runat="server" Text='<%# Bind("ACTIVITY_NAME") %>'></asp:Label>
                    <asp:HiddenField ID="hdnActivity" runat="server" Value='<%# Bind("ACTIVITY_ID") %>' />
                </ItemTemplate>
                    <EditItemTemplate>
                        <asp:DropDownList ID="DropDownList2" runat="server" DataSourceID="sdsActivity" DataTextField="ACTIVITY_NAME"
                            DataValueField="activity_id">
                        </asp:DropDownList>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Product">
                <ItemTemplate>
                        <asp:Label ID="lblProduct" runat="server" Text='<%# Bind("PRODUCT_NAME") %>'></asp:Label>
                        <asp:HiddenField ID="hdnProduct" runat="server" Value='<%# Bind("PRODUCT_ID") %>' />
                </ItemTemplate>
                    <EditItemTemplate>
                        <asp:DropDownList ID="DropDownList3" runat="server" DataSourceID="sdsProduct" DataTextField="PRODUCT_NAME"
                            DataValueField="PRODUCT_ID">
                        </asp:DropDownList>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Type">
                <ItemTemplate>
                        <asp:Label ID="lblType" runat="server" Text='<%# Bind("VERIFICATION_TYPE") %>'></asp:Label>                        
                </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>    
                <asp:TemplateField HeaderText="Rate">
                <ItemTemplate>
                        <asp:Label ID="lblRate" runat="server"  Text='<%# Bind("RATE") %>'></asp:Label>
                </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                <ItemTemplate>                
                    <asp:ImageButton ID="imgEdit" runat="server" ImageUrl="~/Images/icon_edit.gif" CommandName="EditRateChart" CommandArgument='<%# Container.DataItemIndex %>' />
                    <asp:HiddenField ID="hdnRateChart" runat="server" Value='<%# Bind("RATE_CHART_ID") %>' />
                </ItemTemplate>
                </asp:TemplateField>       
                <asp:TemplateField>
                <ItemTemplate>                
                    <asp:ImageButton ID="imgDelete" runat="server" ImageUrl="~/Images/icon_delete.gif" CommandName="DeleteRateChart" CommandArgument='<%# Container.DataItemIndex %>' />
                </ItemTemplate>
                </asp:TemplateField>           
            </Columns>
        </asp:GridView>
    </td></tr>
    <%--<tr><td>
       <table><tr align="left">
       <td style="width:50px">#</td>
       <td style="width:150px">Centre</td>
       <td style="width:150px">Activty</td>
       <td style="width:150px">Product</td>
       <td style="width:125px">Type</td>
       <td style="width:100px">Rate</td></tr>
        </table></td></tr>--%><tr><td>
            &nbsp;<%--<asp:Table ID="tblRateChart" runat="server">               
        </asp:Table>--%></td></tr>
     <tr><td class="tr1">Volume Slab</td></tr>    
    <tr><td><table>
        <tr><td>
            <asp:LinkButton ID="lnkInsertVolSlab" runat="server" OnClick="lnkInsertVolSlab_Click">Insert Volume Slab</asp:LinkButton>
            <asp:LinkButton ID="lnkRemoveVolSlab" runat="server" OnClick="lnkRemoveVolSlab_Click">Remove Volume Slab</asp:LinkButton>
            </td></tr></table>
    </td></tr>
     <tr><td class="tr1">
       <table><tr align="left">
       <td style="width:50px">#</td>
       <td style="width:150px">From No of Cases</td>
       <td style="width:150px">To No of Cases</td>
       <td style="width:150px">Type</td>
       <td style="width:150px">Rate/ Case</td>
       </tr>
        </table></td></tr>
    <tr><td>
        <asp:Table ID="tblVolumeSlab" runat="server">
        <%--<asp:TableHeaderRow>
        <asp:TableHeaderCell>#</asp:TableHeaderCell>
        <asp:TableHeaderCell>From No of Cases</asp:TableHeaderCell>
        <asp:TableHeaderCell>To No of Cases</asp:TableHeaderCell>
        <asp:TableHeaderCell>Type</asp:TableHeaderCell>
        <asp:TableHeaderCell>Rate</asp:TableHeaderCell>
        </asp:TableHeaderRow>--%>
        </asp:Table>
    </td></tr>
        <tr>
            <td>
                &nbsp;</td>
        </tr>
    <tr><td class="tr1">Penalty</td></tr>
    <tr><td><table>
        <tr><td>
            <asp:LinkButton ID="lnkInsertPenalty" runat="server" OnClick="lnkInsertPenalty_Click">Insert Penalty</asp:LinkButton>
            <asp:LinkButton ID="lnkRemovePenalty" runat="server" OnClick="lnkRemovePenalty_Click">Remove Penalty</asp:LinkButton>
            </td></tr></table>
    </td></tr>
        <tr><td class="tr1">
       <table><tr align="left">
       <td style="width:50px">#</td>
       <td style="width:150px">From (%) Beyond TAT</td>
       <td style="width:150px">To (%) Beyond TAT</td>
       <td style="width:150px">Penalty on</td>
       <td style="width:150px">Value Type</td>
       <td style="width:100px">Value</td></tr>
        </table></td></tr>
    <tr><td>
        <asp:Table ID="tblPenalty" runat="server">
        <%--<asp:TableHeaderRow>
        <asp:TableHeaderCell>#</asp:TableHeaderCell>
        <asp:TableHeaderCell>From (%) Beyond TAT</asp:TableHeaderCell>
        <asp:TableHeaderCell>To (%) Beyond TAT</asp:TableHeaderCell>
        <asp:TableHeaderCell>Penalty on</asp:TableHeaderCell>
        <asp:TableHeaderCell>Value Type</asp:TableHeaderCell>
        <asp:TableHeaderCell>Value</asp:TableHeaderCell>
        </asp:TableHeaderRow>--%>
        </asp:Table>
    </td></tr>
        <tr>
            <td>
                &nbsp;</td>
        </tr>
    <tr><td class="tr1">Bonus</td></tr>    
    <tr><td><table>
        <tr><td>
            <asp:LinkButton ID="lnkInsertBonus" runat="server" OnClick="lnkInsertBonus_Click">Insert Bonus</asp:LinkButton>
            <asp:LinkButton ID="lnkRemoveBonus" runat="server" OnClick="lnkRemoveBonus_Click">Remove Bonus</asp:LinkButton>
            </td></tr></table>
    </td></tr>
    <tr><td class="tr1">
       <table><tr align="left">
       <td style="width:50px">#</td>
       <td style="width:150px">From (%) Within TAT</td>
       <td style="width:150px">To (%) Within TAT</td>
       <td style="width:150px">Bonus on</td>
       <td style="width:150px">Value Type</td>
       <td style="width:100px">Value</td></tr>
        </table></td></tr>
    <tr><td>
        <asp:Table ID="tblBonus" runat="server">
        <%--<asp:TableHeaderRow>
        <asp:TableHeaderCell>#</asp:TableHeaderCell>
        <asp:TableHeaderCell>From (%) Within TAT</asp:TableHeaderCell>
        <asp:TableHeaderCell>To (%) Within TAT</asp:TableHeaderCell>
        <asp:TableHeaderCell>Bonus on</asp:TableHeaderCell>
        <asp:TableHeaderCell>Value Type</asp:TableHeaderCell>
        <asp:TableHeaderCell>Value</asp:TableHeaderCell>
        </asp:TableHeaderRow>--%>
        </asp:Table>
    </td></tr>
    <tr><td>
        &nbsp;</td></tr>
    <tr><td align="center">
        <asp:Button ID="btnSubmit" runat="server" Text="Submit" ValidationGroup="grpRateChart" OnClick="btnSubmit_Click" SkinID="btnSubmitSkin" />&nbsp;
        <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" SkinID="btnCancelSkin" /></td></tr>
    </table>
    </fieldset>
    </div>
        <asp:SqlDataSource ID="sdsImplementedBy" runat="server" ConnectionString="<%$ ConnectionStrings:CMConnectionString %>"
            ProviderName="<%$ ConnectionStrings:CMConnectionString.ProviderName %>" SelectCommand="SELECT [EMP_ID], [FULLNAME] FROM [EMPLOYEE_MASTER] ORDER BY [FULLNAME]">
        </asp:SqlDataSource>
        &nbsp; &nbsp;&nbsp; &nbsp;<asp:RequiredFieldValidator ID="rfvID"
        runat="server" ControlToValidate="txtContractNo" Display="None" ErrorMessage="Please get Unique Contract No"
        SetFocusOnError="True" ValidationGroup="grpRateChart"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="revContractDate" runat="server" ControlToValidate="txtContractDate"
            Display="None" ErrorMessage="Please enter valid date format for Contract Date"
            SetFocusOnError="True" ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d"
            ValidationGroup="grpRateChart"></asp:RegularExpressionValidator>
        <asp:RegularExpressionValidator ID="revContractExpiryDate" runat="server" ControlToValidate="txtExpiryDate"
            Display="None" ErrorMessage="Please enter valid date format for Contract Expiry Date"
            SetFocusOnError="True" ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d"
            ValidationGroup="grpRateChart"></asp:RegularExpressionValidator>
        <asp:RegularExpressionValidator ID="rfvProjectImplementDate" runat="server" ControlToValidate="txtImplementDate"
            Display="None" ErrorMessage="Please enter valid date format for Project Implement Date"
            SetFocusOnError="True" ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d"
            ValidationGroup="grpRateChart"></asp:RegularExpressionValidator>
        <asp:RegularExpressionValidator ID="revProjectStartDate" runat="server" ControlToValidate="txtStartDate"
            Display="None" ErrorMessage="Please enter valid date format for Project Start Date"
            SetFocusOnError="True" ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d"
            ValidationGroup="grpRateChart"></asp:RegularExpressionValidator>
        <asp:RequiredFieldValidator ID="rfvProjectStartDate" runat="server" ErrorMessage="Please enter Project Start Date" ControlToValidate="txtStartDate" Display="None" SetFocusOnError="True" ValidationGroup="grpRateChart"></asp:RequiredFieldValidator>
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
            ShowSummary="False" ValidationGroup="grpRateChart" />
            <asp:ValidationSummary ID="ValidationSummary2" runat="server" ShowMessageBox="True"
            ShowSummary="False" ValidationGroup="grpRateChart1" />
        <asp:HiddenField ID="hdnContID" runat="server" /><asp:HiddenField ID="hdnPresaleContID" runat="server" />
        <asp:HiddenField ID="hdnMode" runat="server" />
        <asp:CustomValidator ID="cvConDate" runat="server" ControlToValidate="txtImplementDate"
        Display="None" ErrorMessage="Project Implementation should be at least 10 days greater than Contract Date" SetFocusOnError="True" ValidationGroup="grpRateChart" ClientValidationFunction="funDateDiff"></asp:CustomValidator>
   
 </asp:Content>   