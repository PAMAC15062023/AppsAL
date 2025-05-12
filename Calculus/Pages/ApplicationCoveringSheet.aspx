<%@ Page Language="C#" MasterPageFile="~/Pages/MasterPage.master" AutoEventWireup="true" CodeFile="ApplicationCoveringSheet.aspx.cs" Inherits="Pages_ApplicationCoveringSheet" Title="Covering Sheet" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script language="javascript" type="text/javascript" src="popcalendar.js"></script>
<script language="javascript" type="text/javascript" >
    function SelectAll()
    {
    //
         //var ContentHolder="Ctl00_ContentPlaceHolder1_";
          
         chequeBoxSelectedCount=0;
     var grvTransactionInfo=document.getElementById("<%=GrvApplicationList.ClientID%>");
     var chkSelectAll=document.getElementById('chkSelectAll');    
     var cell;
           for (i=0;i<=grvTransactionInfo.rows.length - 1; i++)
            {
                cell = grvTransactionInfo.rows[i].cells[0];
                if (cell!=null)
                {
                for (j=0; j<cell.childNodes.length; j++)
                    {          
                        
                        if (cell.childNodes[j].type =="checkbox")
                        {                            
                             cell.childNodes[j].checked =chkSelectAll.checked;  
                             chequeBoxSelectedCount=chequeBoxSelectedCount+1;                           
                        }
                    }
                }

             }
            
       
         
         
       
    
    }

</script>

    <table style="width: 100%">
    
    
        <tr>
            <td colspan="6">
                <asp:Label ID="lblMessage" runat="server" Visible="False"></asp:Label></td>
        </tr>
        <tr>
            <td class="TableHeader" colspan="6">
                &nbsp;Covering Letter</td>
        </tr>
        <tr>
            <td style="width: 100px">
                &nbsp;</td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td class="TableTitle">
                &nbsp; NanoApplication No</td>
            <td class="TableTitle">
                Application From Date</td>
            <td class="TableTitle">
                &nbsp;Application To Date</td>
            <td>
            </td>
            <td>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td>
                <asp:TextBox ID="txtNanoApplicationNo" runat="server"></asp:TextBox></td>
            <td>
                <asp:TextBox ID="txtFromDate" runat="server" Font-Size="Small" MaxLength="10" Width="113px"></asp:TextBox><img
                    id="Img1" alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtFromDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                    src="SmallCalendar.gif" />(DD/MM/YYYY)</td>
            <td>
                <asp:TextBox ID="txtToDate" runat="server" Font-Size="Small" MaxLength="10" Width="113px"></asp:TextBox><img
                    id="ImgDOB1" alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtToDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                    src="SmallCalendar.gif" />(DD/MM/YYYY)</td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
            </td>
            <td>
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td colspan="6"><asp:Button ID="btnRetrieve" runat="server" Text="Retrive" Width="97px" OnClick="btnRetrieve_Click" CssClass="button" />
                <asp:Button ID="btnClear" runat="server" Text="Clear" Width="105px" CssClass="button" /></td>
        </tr>
        <tr>
            <td colspan="6">
            </td>
        </tr>
        <tr>
            <td colspan="6">
                <asp:GridView ID="GrvApplicationList" runat="server" Width="100%">
                    <Columns>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                <input id="chkSelectAll" type="checkbox" onclick="javascript:SelectAll();" />
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:CheckBox ID="Chkbox" runat="server" />&nbsp;
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                &nbsp; &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="6" style="height: 15px">
                &nbsp;<table id="tbExport" runat="server" border="0" cellpadding="0" cellspacing="0"
                    visible="true" width="100%">
                    <tr>
                        <td style="height: 13px">
                            <asp:GridView ID="GridView1" runat="server">
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="6" style="height: 26px">
                &nbsp;<asp:Button ID="btnGenrateReport" runat="server"   Text="Generate Report" OnClick="btnGenrateReport_Click" />&nbsp;
                <asp:Button ID="btnCancel" runat="server"   Text="Cancel" OnClick="btnCancel_Click" />
                <asp:Button ID="btnUpdateStatus" runat="server"   Text="Update Status of Application" OnClick="btnUpdateStatus_Click" Width="295px" /></td>
        </tr>
        <tr>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
        </tr>
    </table>
</asp:Content>

