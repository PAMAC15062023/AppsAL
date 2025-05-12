<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BIS_APPROVAL_VIEW.aspx.cs" Theme="SkinFile"  MasterPageFile="HRMasterPage.master" Inherits="HR_HR_BIS_APPROVAL_VIEW" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server" >
<script language="JAVASCRIPT" type="text/javascript"> 

 function compareDate(date1, date2)
            {
                k = date1.split('/');

                dayTo = k[0]; 
                yearTo = k[2];
                monthTo  = k[1];
                    var tempStartDate = new Date(yearTo,monthTo,dayTo);
                k = date2.split('/');
                dayFrom= k[0]; // javascript month range : 0- 11
                yearFrom = k[2];
                monthFrom = k[1];   
            
                var tempEndDate = new Date(yearFrom,monthFrom,dayFrom);

                if(tempStartDate > tempEndDate)
                {
                    //alert(msg);
                    if(tempStartDate != tempEndDate)
                    {
                     return false;
                    }
                }
                else
                {
                   return true;
                }
            }
function DateCompare(source, arguments)
{

var Fdate=document.getElementById("<%=txtFromDate.ClientID %>").value;
var Tdate= document.getElementById("<%=txtToDate.ClientID %>").value;
var Fdate1= Fdate.substring(0,10);
var Tdate1= Tdate.substring(0,10);
if(compareDate(Fdate1,Tdate1) == false)                      
arguments.IsValid=false;
else
arguments.IsValid=true;  
  	  
}


function ClientValidate(source, arguments)
       {
//            alert(arguments.Value);
          if ((arguments.Value) == 0)
             arguments.IsValid=false;
          else
             arguments.IsValid=true;
       }
       function ValDate(source, arguments)
       {
      
       var strFromDt=document.getElementById("<%=txtFromDate.ClientID %>").value;
       var strTidt= document.getElementById("<%=txtToDate.ClientID %>").value;
       if(strFromDt=="" && strTidt!="")
       {
       arguments.IsValid=false;
       }
       else if(strFromDt!="" && strTidt=="")
       {
        arguments.IsValid=false;
       }
       else
       {
       arguments.IsValid=true;
       }
       }
       </script>
        
  <fieldset><legend class="FormHeading">BIS-APPROVAL-VIEW</legend>  
  <table width="100%" >
      <tr>
          <td>
          </td>
          <td style="width: 1px">
          </td>
          <td>
          </td>
          <td>
          </td>
          <td >
          </td>
          <td>
              <asp:Label ID="lblmsg" runat="server" EnableViewState="False" SkinID="lblErrorMsg"></asp:Label></td>
          <td>
          </td>
          <td>
          </td>
          <td align="right">
              <asp:Label ID="Label1" runat="server" Font-Bold="True" SkinID="lblSkin" Text="[View]"></asp:Label></td>
      </tr>
          <tr>
              <td align="right" >
                 
                  <asp:Label ID="lblCluster" runat="server" Text="Cluster Name" Visible="False"></asp:Label>
                  </td>
              <td style="width: 1px">
                  <asp:Label ID="lblClusterCo" runat="server" Text=":" Visible="False" Width="2px"></asp:Label>&nbsp;</td>
                  <td>
                  <asp:DropDownList ID="ddlCluter" runat="server" AutoPostBack="True" DataSourceID="sdsCluster" DataTextField="CLUSTER_NAME" DataValueField="CLUSTER_ID" SkinID="ddlSkin" Visible="False" OnSelectedIndexChanged="ddlCluter_SelectedIndexChanged" OnDataBound="ddlCluter_DataBound" Width="164px">
                  </asp:DropDownList></td>
                <td align="right">
              
                  <asp:Label ID="lblCentre" runat="server" Text="Centre Name" Visible="False"></asp:Label>
                  </td>
              <td style="width: 11px">
                  <asp:Label ID="lblCentreCo" runat="server" Text=":" Width="2px" Visible="False"></asp:Label></td>
                  <td>
                  <asp:DropDownList ID="ddlCentre" runat="server" AutoPostBack="True" DataSourceID="sdsCentre" DataTextField="CENTRE_NAME" DataValueField="CENTRE_ID" SkinID="ddlSkin" Visible="False" OnDataBound="ddlCentre_DataBound" OnSelectedIndexChanged="ddlCentre_SelectedIndexChanged" Width="164px">
                  </asp:DropDownList></td>
                <td align="right">
                  
                  <asp:Label ID="lblSubcentre" runat="server" Text="Sub Centre Name" Width="84px" Visible="False"></asp:Label>
                  </td>
              <td align="right">
                  <asp:Label ID="lblSubcentreCo" runat="server" Text=":" Visible="False" Width="2px"></asp:Label></td>
                  <td align="right">
                  <asp:DropDownList ID="ddlSubcentre" runat="server" SkinID="ddlSkin" DataSourceID="sdsSubcetre" DataTextField="SubCentreName" DataValueField="SubCentreId" Visible="False" OnDataBound="ddlSubcentre_DataBound" Width="164px">
                  </asp:DropDownList>
                  </td>
          </tr>
      <tr>
          <td align="right">
              From Date</td>
          <td style="width: 1px">
              :</td>
          <td>
              <asp:TextBox ID="txtFromDate" runat="server" SkinID="txtSkin" MaxLength="10"></asp:TextBox>
              <img alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtFromDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                  src="../../Images/SmallCalendar.gif" />[dd/mm/yyyy]</td>
          <td align="right">
              To Date</td>
          <td style="width: 11px">
              :</td>
          <td>
              <asp:TextBox ID="txtToDate" runat="server" MaxLength="10" SkinID="txtSkin"></asp:TextBox>
              <img alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtToDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                  src="../../Images/SmallCalendar.gif" />[dd/mm/yyyy]</td>
          <td>
          </td>
          <td align="right">
              </td>
          <td align="right">
              &nbsp;</td>
      </tr>
      <tr >
          <td align="right">
              PAMACian Code</td>
          <td style="width: 1px">
              :</td>
          <td>
              <asp:TextBox ID="txtEmpCode" runat="server" MaxLength="15" SkinID="txtSkin"></asp:TextBox></td>
          <td align="right">
              PAMACian Name</td>
          <td style="width: 11px">
              :</td>
          <td>
              <asp:TextBox ID="txtEmpName" runat="server" MaxLength="100" SkinID="txtSkin"></asp:TextBox></td>
          <td>
          </td>
          <td align="right">
          </td>
          <td align="right">
                  <asp:Button ID="btnShow" runat="server" OnClick="btnShow_Click" SkinID="btn" Text="Show" ValidationGroup="ValDate" Width="60px" />
                 
                  <asp:Button ID="btAddNew" runat="server" SkinID="btnAddNewSkin" Text="Add New" OnClick="btAddNew_Click" ValidationGroup="ValAddNew" Width="60px" />
          </td>
      </tr>
          <tr>
          </tr>
          <tr>
              <td colspan="9" align="center" >
      <asp:GridView ID="GV_EMP_VEIW" Width="100%" runat="server" SkinID="gridviewNoSort" PageSize="20" AutoGenerateColumns="False" OnRowDataBound="GV_EMP_VEIW_RowDataBound" OnPageIndexChanging="GV_EMP_VEIW_PageIndexChanging" AllowPaging="True" OnRowCommand="GV_EMP_VEIW_RowCommand">
          <Columns>
              <asp:BoundField DataField="EMP CODE" HeaderText="PAMACian Code" ItemStyle-HorizontalAlign="left"/>
              <asp:BoundField DataField="PAMACIAN" HeaderText="PAMACian" ItemStyle-HorizontalAlign="left"/>
              <asp:BoundField DataField="DOJ" HeaderText="DOJ" HtmlEncode="false" DataFormatString="{0:dd/MM/yyyy}" ItemStyle-HorizontalAlign="left"/>
              <asp:BoundField DataField="DEPARTMENT" HeaderText="Department" ItemStyle-HorizontalAlign="left"/>
              <asp:BoundField DataField="DESIGNATION" HeaderText="Designation" ItemStyle-HorizontalAlign="left"/>
              <asp:BoundField DataField="UNIT" HeaderText="Unit" ItemStyle-HorizontalAlign="left"/>
               <asp:BoundField DataField="CLUSTER_NAME" HeaderText="Cluster Name" ItemStyle-HorizontalAlign="left"/>
               <asp:BoundField DataField="CENTRE_NAME" HeaderText="Centre Name" ItemStyle-HorizontalAlign="left"/>
               <asp:BoundField DataField="SubCentreName" HeaderText="Sub Centre Name" ItemStyle-HorizontalAlign="left"/>
              <asp:TemplateField HeaderText="Cluster-HR"> 
                            <ItemTemplate>
                                <asp:DropDownList ID="ddlAppCL" runat="server" SkinID="ddlSkin" >
                                  <asp:ListItem Text="NS" Value="NS"></asp:ListItem>
                                  <asp:ListItem Text="Y" Value="Y"></asp:ListItem>
                                  <asp:ListItem Text="N" Value="N"></asp:ListItem>
                                    
                                </asp:DropDownList>
                                 <asp:HiddenField ID="hidEmpIDCL" runat="server"
                                  Value='<%# DataBinder.Eval(Container.DataItem, "emp_id") %>' />
                                </ItemTemplate>
                               
            </asp:TemplateField>
                 <asp:TemplateField HeaderText="HO-HR"> 
                            <ItemTemplate>
                                <asp:DropDownList ID="ddlAppHO" runat="server" SkinID="ddlSkin" >
                                   <asp:ListItem Text="NS" Value="NS"></asp:ListItem>
                                  <asp:ListItem Text="Y" Value="Y"></asp:ListItem>
                                  <asp:ListItem Text="N" Value="N"></asp:ListItem>
                                    
                                </asp:DropDownList>
                               <asp:HiddenField ID="hidEmpIDHO" runat="server"
                                  Value='<%# DataBinder.Eval(Container.DataItem, "emp_id") %>' />
                                </ItemTemplate>
                                
            </asp:TemplateField>
              
             
              
              <asp:TemplateField HeaderText="Edit" HeaderStyle-HorizontalAlign="Center"> 
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkEditEmp" runat="server" CommandArgument='<%# Eval("EMP_ID") %>'
                                CommandName="Ed" ><img src="../../Images/icon_edit.gif" alt="Edit" style="border:0" /></asp:LinkButton>
                            </ItemTemplate>
                                <ItemStyle Width="20px" />
            </asp:TemplateField>
            
          </Columns>
      </asp:GridView>
                  </td>
          </tr>
      <tr>
          <td align="right" colspan="9">
              &nbsp;<asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" SkinID="btnSaveSkin"
                      Text="Button" Width="60px" /></td>
      </tr>
      </table>
    

  </fieldset>
        <asp:SqlDataSource ID="sdsSubcetre" runat="server" ConnectionString="<%$ ConnectionStrings:CMConnectionString %>" ProviderName="<%$ ConnectionStrings:CMConnectionString.ProviderName %>" >
      
      </asp:SqlDataSource>
      <asp:SqlDataSource ID="sdsCentre" runat="server" ConnectionString="<%$ ConnectionStrings:CMConnectionString %>" ProviderName="<%$ ConnectionStrings:CMConnectionString.ProviderName %>" >
          
      </asp:SqlDataSource>
      <asp:SqlDataSource ID="sdsCluster" runat="server" ConnectionString="<%$ ConnectionStrings:CMConnectionString %>" ProviderName="<%$ ConnectionStrings:CMConnectionString.ProviderName %>" SelectCommand="SELECT [CLUSTER_ID], [CLUSTER_NAME] FROM [CLUSTER_MASTER]"></asp:SqlDataSource>
      <asp:HiddenField ID="hdnField" runat="server" />
    <asp:CustomValidator ID="ValCluster" runat="server" ClientValidationFunction="ClientValidate"
        ControlToValidate="ddlCluter" Display="None" ErrorMessage="Please select the Cluster"
        SetFocusOnError="True" ValidationGroup="ValAddNew"></asp:CustomValidator><asp:CustomValidator
            ID="ValCentre" runat="server" ClientValidationFunction="ClientValidate" ControlToValidate="ddlCentre"
            Display="None" ErrorMessage="Please select the centre" SetFocusOnError="True"
            ValidationGroup="ValAddNew"></asp:CustomValidator><asp:CustomValidator ID="ValSubcentre"
                runat="server" ClientValidationFunction="ClientValidate" ControlToValidate="ddlSubcentre"
                Display="None" ErrorMessage="Please select the SubCentre" SetFocusOnError="True"
                ValidationGroup="ValAddNew"></asp:CustomValidator><asp:ValidationSummary ID="ValSummarry"
                    runat="server" DisplayMode="List" ShowMessageBox="True" ShowSummary="False" ValidationGroup="ValAddNew" />
    <asp:RegularExpressionValidator ID="RegFromDate" runat="server" ControlToValidate="txtFromDate"
        Display="None" ErrorMessage="Please enter valid date format for DOB." SetFocusOnError="True"
        ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d"
        ValidationGroup="ValDate"></asp:RegularExpressionValidator><asp:RegularExpressionValidator
            ID="RegToDate" runat="server" ControlToValidate="txtToDate" Display="None" ErrorMessage="Please enter valid date format for DOB."
            SetFocusOnError="True" ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d"
            ValidationGroup="ValDate"></asp:RegularExpressionValidator><asp:ValidationSummary
                ID="ValDate" runat="server" ShowMessageBox="True" ShowSummary="False" ValidationGroup="ValDate" />
    <asp:CustomValidator ID="ValDate1" runat="server" ClientValidationFunction="ValDate"
        Display="None" ErrorMessage="Please put the both From Date  and To Date" SetFocusOnError="True"
        ValidationGroup="ValDate"></asp:CustomValidator><asp:CustomValidator ID="ValFromToDate"
            runat="server" ClientValidationFunction="DateCompare" Display="None" ErrorMessage="From Date should not be greater then To Date"
            SetFocusOnError="True" ValidationGroup="ValDate"></asp:CustomValidator>
  
  </asp:Content>
  
  
