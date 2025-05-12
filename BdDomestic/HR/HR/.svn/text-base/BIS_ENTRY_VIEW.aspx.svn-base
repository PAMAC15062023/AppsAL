<%@ Page Language="C#" AutoEventWireup="true" Theme="SkinFile"  MasterPageFile="HRMasterPage.master"  CodeFile="BIS_ENTRY_VIEW.aspx.cs" Inherits="HR_BIS_ENTRY_VIEW" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server" >
<script language="javascript" type="text/javascript"src="popcalendar.js"></script>
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
        
  <fieldset ><legend class="FormHeading">BIS-ENTRY-VIEW</legend>  
      <table width="100%" >
          <tr>
              <td style="width: 92px">
              </td>
              <td style="width: 6px">
              </td>
              <td style="width: 228px">
              </td>
              <td>
              </td>
              <td style="width: 4px">
              </td>
              <td style="width: 227px">
                  <asp:Label ID="lblmsg" runat="server" EnableViewState="False" SkinID="lblErrorMsg"></asp:Label></td>
              <td style="width: 103px">
              </td>
              <td align="right" style="width: 9px">
              </td>
              <td align="right">
                  <asp:Label ID="Label1" runat="server" Font-Bold="True" SkinID="lblSkin" Text="[View]"></asp:Label></td>
          </tr>
          <tr>
              <td style="width: 92px"  >
                  
                  <asp:Label ID="lblCluster" runat="server" Text="Cluster Name" Visible="False" Width="89px"></asp:Label>
                  </td>
              <td style="width: 6px">
                  <asp:Label ID="lblClusterCo" runat="server" Text=":" Width="2px" Visible="False"></asp:Label></td>
                  <td style="width: 228px" >
                  <asp:DropDownList ID="ddlCluter" runat="server" AutoPostBack="True" DataSourceID="sdsCluster" DataTextField="CLUSTER_NAME" DataValueField="CLUSTER_ID" SkinID="ddlSkin" Visible="False" OnSelectedIndexChanged="ddlCluter_SelectedIndexChanged" OnDataBound="ddlCluter_DataBound" Width="164px">
                  </asp:DropDownList></td>
              <td >
                
                  <asp:Label ID="lblCentre" runat="server" Text="Centre  Name" Visible="False" Width="78px"></asp:Label>
                  </td>
              <td style="width: 4px">
                  <asp:Label ID="lblCentreCo" runat="server" Text=":" Width="2px" Visible="False"></asp:Label></td>
                  <td style="width: 227px" >
                  <asp:DropDownList ID="ddlCentre" runat="server" AutoPostBack="True" DataSourceID="sdsCentre" DataTextField="CENTRE_NAME" DataValueField="CENTRE_ID" SkinID="ddlSkin" Visible="False" OnDataBound="ddlCentre_DataBound" OnSelectedIndexChanged="ddlCentre_SelectedIndexChanged" Width="164px">
                  </asp:DropDownList></td>
              <td style="width: 103px" >
                  
                  <asp:Label ID="lblSubcentre" runat="server" Text="Sub Centre  Name" Width="100px" Visible="False"></asp:Label></td>
              <td align="right" style="width: 9px">
                  <asp:Label ID="lblSubcentreCo" runat="server" Text=":" Width="2px" Visible="False"></asp:Label></td>
                  <td align="right">
                  <asp:DropDownList ID="ddlSubcentre" runat="server" SkinID="ddlSkin" DataSourceID="sdsSubcetre" DataTextField="SubCentreName" DataValueField="SubCentreId" Visible="False" OnDataBound="ddlSubcentre_DataBound" Width="164px">
                  </asp:DropDownList>
                  </td>
          </tr>
          <tr>
              <td  >
                  From Date 
                  </td>
              <td style="width: 6px">
                  :</td>
                  <td  >
                  <asp:TextBox ID="txtFromDate" runat="server" SkinID="txtSkin" MaxLength="10" Width="128px"></asp:TextBox>
                  <img alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtFromDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                      src="../../Images/SmallCalendar.gif" />[dd/mm/yyyy]</td>
              
              <td >
              
                  To Date 
                  </td>
              <td style="width: 2px">
                  :</td>
                  <td >
                  <asp:TextBox ID="txtToDate" runat="server" SkinID="txtSkin" MaxLength="10" Width="128px"></asp:TextBox>
                  <img alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtToDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                      src="../../Images/SmallCalendar.gif" />[dd/mm/yyyy]</td>
              <td align="right"   >
                  &nbsp;
                  </td>
              <td align="left" >
              </td>
                  
                  <td align="right" >
                      &nbsp;
                      </td>
          </tr>
          <tr >
              <td >
                  PAMACian Code</td>
              <td style="width: 6px">
                  :</td>
              <td >
                  <asp:TextBox ID="txtEmpCode" runat="server" MaxLength="15" SkinID="txtSkin"></asp:TextBox></td>
              <td>
                  PAMACian Name</td>
              <td style="width: 2px">
                  :</td>
              <td >
                  <asp:TextBox ID="txtEmpName" runat="server" SkinID="txtSkin"></asp:TextBox></td>
              <td align="right" >
              </td>
              <td align="left" >
              </td>
              <td align="right">
                  <asp:Button ID="btnshow" runat="server" OnClick="btnshow_Click" SkinID="btn" Text="Show" ValidationGroup="ValDate" Width="60px" />
                  <asp:Button ID="btAddNew" runat="server" SkinID="btnAddNewSkin" Text="Add New" OnClick="btAddNew_Click" ValidationGroup="ValAddNew" Width="60px" />
                  &nbsp;
              </td>
          </tr>
          <tr>
          </tr>
          <tr>
              <td colspan="10" >
      <asp:GridView ID="GV_EMP_VEIW" Width="100%" runat="server" SkinID="gridviewNoSort" AutoGenerateColumns="False" OnPageIndexChanging="GV_EMP_VEIW_PageIndexChanging" AllowPaging="True" PageSize="20" OnRowCommand="GV_EMP_VEIW_RowCommand" >
          <Columns>
              <asp:BoundField DataField="EMP CODE" HeaderText="PAMACian Code" ItemStyle-HorizontalAlign="left"/>
              <asp:BoundField DataField="PAMACIAN" HeaderText="PAMACian" ItemStyle-HorizontalAlign="left"/>
          <asp:BoundField DataField="DOJ" HeaderText="DOJ" HtmlEncode="false" DataFormatString="{0:dd/MM/yyyy}" ItemStyle-HorizontalAlign="left"/>
          <asp:BoundField DataField="DOL" HeaderText="DOL" HtmlEncode="false" DataFormatString="{0:dd/MM/yyyy}" ItemStyle-HorizontalAlign="left"/>
              <asp:BoundField DataField="DEPARTMENT" HeaderText="Department" ItemStyle-HorizontalAlign="left"/>
              <asp:BoundField DataField="DESIGNATION" HeaderText="Designation" ItemStyle-HorizontalAlign="left"/>
              <asp:BoundField DataField="UNIT" HeaderText="Unit" ItemStyle-HorizontalAlign="left"/>
               <asp:BoundField DataField="CLUSTER_NAME" HeaderText="Cluster Name" ItemStyle-HorizontalAlign="left"/>
               <asp:BoundField DataField="CENTRE_NAME" HeaderText="Centre Name" ItemStyle-HorizontalAlign="left"/>
               <asp:BoundField DataField="SubCentreName" HeaderText="Sub Centre Name" ItemStyle-HorizontalAlign="left"/>
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
      </table>
     
  
  
  </fieldset>
    
      <asp:SqlDataSource ID="sdsSubcetre" runat="server" ConnectionString="<%$ ConnectionStrings:CMConnectionString %>" ProviderName="<%$ ConnectionStrings:CMConnectionString.ProviderName %>" >
      
      </asp:SqlDataSource>
      <asp:SqlDataSource ID="sdsCentre" runat="server" ConnectionString="<%$ ConnectionStrings:CMConnectionString %>" ProviderName="<%$ ConnectionStrings:CMConnectionString.ProviderName %>" >
          
      </asp:SqlDataSource>
    
    <asp:CustomValidator ID="ValCluster" runat="server" ControlToValidate="ddlCluter"
        Display="None" ErrorMessage="Please select the Cluster" SetFocusOnError="True"
        ValidationGroup="ValAddNew" ClientValidationFunction="ClientValidate"></asp:CustomValidator>
    <asp:CustomValidator ID="ValCentre" runat="server" ControlToValidate="ddlCentre"
        Display="None" ErrorMessage="Please select the centre" SetFocusOnError="True"
        ValidationGroup="ValAddNew" ClientValidationFunction="ClientValidate"></asp:CustomValidator>
    <asp:CustomValidator ID="ValSubcentre" runat="server" ControlToValidate="ddlSubcentre"
        Display="None" ErrorMessage="Please select the SubCentre" SetFocusOnError="True"
        ValidationGroup="ValAddNew" ClientValidationFunction="ClientValidate"></asp:CustomValidator>
    <asp:ValidationSummary ID="ValSummarry" runat="server" ShowMessageBox="True" ShowSummary="False"
        ValidationGroup="ValAddNew" DisplayMode="List" />
    &nbsp;&nbsp;&nbsp;
    
      <asp:SqlDataSource ID="sdsCluster" runat="server" ConnectionString="<%$ ConnectionStrings:CMConnectionString %>" ProviderName="<%$ ConnectionStrings:CMConnectionString.ProviderName %>" SelectCommand="SELECT [CLUSTER_ID], [CLUSTER_NAME] FROM [CLUSTER_MASTER] ORDER BY CLUSTER_NAME"></asp:SqlDataSource>
    &nbsp;
    <asp:RegularExpressionValidator ID="RegFromDate" runat="server" ControlToValidate="txtFromDate"
        Display="None" ErrorMessage="Please enter valid date format for DOB." SetFocusOnError="True"
        ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d"
        ValidationGroup="ValDate"></asp:RegularExpressionValidator>
    <asp:RegularExpressionValidator ID="RegToDate" runat="server" ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d"
    ErrorMessage="Please enter valid date format for DOB."  ValidationGroup="ValDate" ControlToValidate="txtToDate" Display="None" SetFocusOnError="True"></asp:RegularExpressionValidator>
    <asp:ValidationSummary ID="ValDate" runat="server" ShowMessageBox="True" ShowSummary="False"  
        ValidationGroup="ValDate" />
    <asp:CustomValidator ID="ValDate1" runat="server" ErrorMessage="Please put the both From Date  and To Date" ClientValidationFunction="ValDate" Display="None" SetFocusOnError="True" ValidationGroup="ValDate"></asp:CustomValidator>
    <asp:CustomValidator ID="ValFromToDate" runat="server" Display="None" ErrorMessage="From Date should not be greater then To Date"
        SetFocusOnError="True" ValidationGroup="ValDate" ClientValidationFunction="DateCompare"></asp:CustomValidator>
  </asp:Content>
  
