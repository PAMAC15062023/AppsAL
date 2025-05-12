<%@ Page Language="C#" MasterPageFile="~/HR/HR/HRMasterPage.master" Theme="SkinFile" AutoEventWireup="true" CodeFile="ResetPassword.aspx.cs" Inherits="HR_HR_ResetPassword"%>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script language="javascript" type="text/javascript">
    function checkSelectedRecords()
    {
        //debugger; 
        var count='<%=Cache["RecCount"]%>';
        chk='';   
        var cnt;     
        chkRecord=false;
        cnt=2;  
        for(i=0; i<count; i++)
            {
              //for selectde checkbox
            
                 chk="ctl00_ContentPlaceHolder1_gvExport_ctl0"+cnt+"_chkSelect";         
                 if(cnt > 9)
                 {
                  chk="ctl00_ContentPlaceHolder1_gvExport_ctl"+cnt+"_chkSelect";
                 }
                 getCheckBoxId='';
                 getCheckBoxId=document.getElementById(chk);             
                 if(getCheckBoxId.checked == true)
                 {
                      chkRecord = true;             
                 }       
                  cnt = cnt + 1;      
        
              }
         if( chkRecord==false)
         {
               alert('- Please select at least one records for Export...');
               return false;  
         }
         return true;
    }


    function SelectAllCheckboxes(spanChk)
    {
       // Added as ASPX uses SPAN for checkbox
       var oItem = spanChk.children;
       var theBox= (spanChk.type=="checkbox") ? spanChk : spanChk.children.item[0];
           xState=theBox.checked;
           elm=theBox.form.elements;
           
       for(i=0;i<elm.length;i++)
         if(elm[i].type=="checkbox" && elm[i].id!=theBox.id)
         {       
           if(elm[i].checked!=xState)
             elm[i].click();       
         }
     }
    </script>
    
    <table  width="99%" border="0" align="center" cellspacing="0" cellpadding="0" >
        <tr> 
            <td align="left" ><asp:Label ID="lblMsg" runat="server" CssClass="txtError" Font-Bold="True" ForeColor="Red"></asp:Label></td>
        </tr>
        <tr> 
            <td align="center">
                <fieldset><legend class="FormHeading"><b>Reset Password</b></legend>
                    <table width="100%" border="0" align="center" cellspacing="0" cellpadding="0">
                        <tr> 
                            <td>
                                <table width="100%" border="0" cellpadding="0" cellspacing="0"  class="shadow">
                                    <tr> 
                                        <td class="shadow-center" align="left">
                                            <table width="100%" border="0" cellpadding="0" cellspacing="0" >
                                           <tr>
                                                <td>
                                                    <table>
                                                        <tr>
                                                            <td align="right">
                                                                <asp:Button ID="BtnSave" SkinID="btnSaveSkin" runat="Server" OnClick="BtnSave_Click" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:GridView ID="GvResetPassword" runat="Server" AutoGenerateColumns="false" 
                                                                HorizontalAlign="Center" Width="980px" PageSize="10" AllowPaging="True" 
                                                                AllowSorting="True" BackColor="White" BorderColor="Transparent" BorderWidth="1px" 
                                                                CellPadding="1" CellSpacing="1" ForeColor="Black" GridLines="None" BorderStyle="Solid"
                                                                Font-Bold="False" Font-Names="Arial" Font-Size="8pt" OnPageIndexChanging="GvResetPassword_PageIndexChanging" OnSorting="GvResetPassword_Sorting" OnRowDataBound="GvResetPassword_RowDataBound">
                                                                    <FooterStyle BackColor="#D0D5D8" Height="20px"  ForeColor="White" />
                                                                    <RowStyle BackColor="#E5E5E5"  />
                                                                    <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                                                                    <PagerStyle BackColor="#D0D5D8" ForeColor="Black" HorizontalAlign="Center" />
                                                                    <HeaderStyle BackColor="#D0D5D8" Font-Bold="True" ForeColor="Black" Height="20px" Font-Names="Arial" Font-Size="8pt" />
                                                                    <AlternatingRowStyle BackColor="White" />
                                                                    <Columns>
                                                                        <asp:BoundField DataField="Emp_code" HeaderText="Emp Code" SortExpression="Emp_code" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Center" />
                                                                        <asp:BoundField DataField="FullName" HeaderText="PAMACian" SortExpression="FullName" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Center" />
                                                                        <asp:BoundField DataField="DOL" HeaderText="Date of Leaving" SortExpression="DOL" ItemStyle-HorizontalAlign="Left" HtmlEncode="false" DataFormatString="{0:dd/MM/yyyy}" HeaderStyle-HorizontalAlign="Center" />
                                                                        <asp:BoundField DataField="Designation" HeaderText="Designation" SortExpression="Designation" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Center" />
                                                                        <asp:BoundField DataField="Department" HeaderText="Department" SortExpression="Department" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Center" />
                                                                        <asp:BoundField DataField="Activity_Name" HeaderText="Unit" SortExpression="Activity_Name" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Center" />
                                                                        <asp:BoundField DataField="Cluster_Name" HeaderText="Cluster Name" SortExpression="Cluster_Name" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Center" />
                                                                        <asp:BoundField DataField="Centre_Name" HeaderText="Centre Name" SortExpression="Centre_Name" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Center" />
                                                                        <asp:BoundField DataField="SubCentreName" HeaderText="Sub Centre Name" SortExpression="SubCentreName" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Center" />
                                                                        <asp:TemplateField HeaderText="Select" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="center">
                                                                            <HeaderTemplate>
                                                                                <asp:CheckBox ID="chkHeaderSelect" runat="server" OnClick="javascript:SelectAllCheckboxes(this);" />
                                                                            </HeaderTemplate>
                                                                            <ItemTemplate>
                                                                                <asp:CheckBox ID="chkSelect" runat="server" />
                                                                                <asp:HiddenField ID="HdnDOL" runat="Server" Value='<%# Bind("DOL") %>' />
                                                                                <asp:HiddenField ID="HdnEmpId" runat="Server" Value='<%# Bind("Emp_Id") %>' />
                                                                                <asp:HiddenField ID="HdnEmpcode" runat="Server" Value='<%# Bind("Emp_code") %>' />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>                                                                    
                                                                    </Columns>
                                                                </asp:GridView>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="right">
                                                                <asp:Button ID="BtnSave1" SkinID="btnSaveSkin" runat="Server" OnClick="BtnSave_Click" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                           </tr>
                                    </table>
                                        </td>
                                    </tr>
                              </table>
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </td>
          </tr>
        </table>
</asp:Content>

