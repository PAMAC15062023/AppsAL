<%@ Page Language="C#" AutoEventWireup="true" CodeFile="~/Pages/ChequeProcessing/ChequeEntryReport_SBI_II_Pass.aspx.cs"
    Inherits="ChequeEntryReport_SBI_II_Pass" MasterPageFile="~/Pages/MasterPage.master" StylesheetTheme="SkinFile" %>
 <asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   <script language="javascript" type="text/javascript" src="popcalendar.js">
    
    </script>    
    <script language="javascript" type="text/javascript">
    
    function Validate_Upload()
    {
       var returnValue=true;
       var ErrorMessage="";      
       var FileUpload1=document.getElementById("<%=FileUpload1.ClientID %>");       
       var lblMessage=document.getElementById("<%=lblMessage.ClientID %>");
       
        if (FileUpload1.value=='')
            {
                ErrorMessage="Please select File for Upload!";
                returnValue=false;
            }
                     
       lblMessage.cssClass="ErrorMessage";
       lblMessage.innerText=ErrorMessage;
       
       return returnValue;
    
    }
    
    function Validate_Export()
    {
      var returnValue=true;
      var ErrorMessage="";      
      var gvUploadedDATA=document.getElementById("<%=gvUploadedDATA.ClientID %>");       
      var lblMessage=document.getElementById("<%=lblMessage.ClientID %>");
      var txtDepositDate=document.getElementById("<%=txtDepositDate.ClientID %>");
       
       
       if (gvUploadedDATA==null)
       {
            ErrorMessage="No Record for Generating Export!";
            returnValue=false;
        
       }
       else
       {
        if (gvUploadedDATA.rows.length<=1)
        {
            ErrorMessage="No Record for Generating Export!";
            returnValue=false;
        }
        }         

        if (txtDepositDate.value=="")
        {
            ErrorMessage="Please Enter Deposit Date!";
            returnValue=false;
            txtDepositDate.focus();       
        }
        
        lblMessage.cssClass="ErrorMessage";
        lblMessage.innerText=ErrorMessage;
        
        
        return returnValue; 
    
    }
    
    
    </script>

    <table border="0" cellspacing="1" cellpadding="1">
        <tr>
            <td colspan="6" style="height: 13px">
                <asp:Label ID="lblMessage" runat="server" CssClass="ErrorMessage" Width="100%" ForeColor="Red" Font-Bold="True" BackColor="Transparent"></asp:Label></td>
        </tr>
        <tr>
            <td colspan="6" style="height: 13px">
                </td>
        </tr>
        <tr>
            <td colspan="6" headers="Y" style="height: 20px" class="TableHeader">
                &nbsp;Cheque Entry Report II Pass</td>
        </tr>
        <tr>
            <td class="TableTitle">
                &nbsp;&nbsp; Upload File</td>
            <td colspan="5" style="height: 29px">
                &nbsp;<asp:FileUpload ID="FileUpload1" runat="server" Height="25px" Width="485px"
                    BorderWidth="1px" /></td>
        </tr>
        <tr>
            <td style="width: 102px" class="TableTitle">
                &nbsp;
                Deposit Date</td>
            <td colspan="5" style="height: 29px">
                <table cellpadding="0" cellspacing="0" style="width: 147px">
                    <tr>
                        <td style="width: 100px">
                            <asp:TextBox ID="txtDepositDate" runat="server" BorderWidth="1px"
                    Width="106px" SkinID="txtSkin"></asp:TextBox></td>
                        <td style="width: 100px">
                            &nbsp;<img id="ImgDate3rdCall" alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtDepositDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                    src="SmallCalendar.png" style="width: 17px; height: 16px;" /></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="width: 102px">
            </td>
            <td colspan="5">
            </td>
        </tr>
        <tr>
            <td colspan="6" class="TableTitle" style="height: 35px">
                &nbsp;&nbsp;
                <asp:Button ID="btnUpload" runat="server" Height="23px" OnClick="btnUpload_Click"
                    Text="Upload" Width="81px" BorderWidth="1px" /></td>
        </tr>
        <tr>
            <td colspan="6">
                <asp:Panel ID="Panel1" runat="server" Height="200px" ScrollBars="Auto" Width="800px">
                    <asp:GridView ID="gvUploadedDATA" CssClass="GridViewStyle" runat="server" Width="98%" OnDataBound="gvUploadedDATA_DataBound" Height="100px">
                        <footerstyle cssclass="GridViewFooterStyle" />
                        <rowstyle cssclass="GridViewRowStyle" />
                        <selectedrowstyle cssclass="GridViewSelectedRowStyle" />
                        <pagerstyle cssclass="GridViewPagerStyle" />
                        <alternatingrowstyle cssclass="GridViewAlternatingRowStyle" />
                        <headerstyle cssclass="GridViewHeaderStyle" />
                    </asp:GridView>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td colspan="6" style="height: 33px" class="TableTitle">
                &nbsp; &nbsp;
                <asp:Button ID="btnExport" runat="server" OnClick="btnExport_Click" Text="Generate Report"
        Width="122px" BorderWidth="1px" />
                <asp:Button ID="btnClose" runat="server"   Text="Close"
        Width="90px" BorderWidth="1px" OnClick="btnClose_Click" ToolTip="Back to Menu" /></td>
        </tr>
    </table>
   </asp:Content>
 
