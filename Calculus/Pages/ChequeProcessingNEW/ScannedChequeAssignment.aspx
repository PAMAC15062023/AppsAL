<%@ Page Language="C#" MasterPageFile="~/Pages/MasterPage.master" AutoEventWireup="true"
    CodeFile="ScannedChequeAssignment.aspx.cs" Inherits="Pages_ChequeProcessingNEW_ScannedChequeAssignment"
    Title="CheuqeImgaeAssignment" StylesheetTheme="SkinFile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript">
    
            function Validate_ChequeCount()
            {
           
               var chkUserList=document.getElementById("<%=chkUserList.ClientID%>");
               var lblChequeImageCounts=document.getElementById("<%=lblChequeImageCounts.ClientID%>");
               var hdnUserCount=document.getElementById("<%=hdnUserCount.ClientID%>");
               var hdnChequeCounts=document.getElementById("<%=hdnChequeCounts.ClientID%>");
               var ddlBatchNoList=document.getElementById("<%=ddlBatchNoList.ClientID%>");
               var hdnCount=document.getElementById("<%=hdnCount.ClientID%>");
              
               
               var i=0;
               var TotalChequesCounts=parseInt(lblChequeImageCounts.innerText);
               var TotalNoOfUsers=0;
               var CaseAssignedPerPerson=0;
              
               
               for (i=0;i<=chkUserList.rows.length-1;i++)
               {    
                     var checkControl='ctl00_ContentPlaceHolder1_chkUserList_'+i;
                     var chkUserList1=document.getElementById(checkControl);
                     if (chkUserList1!=null)
                     {
                        if (chkUserList1.checked==true)
                        {
                            TotalNoOfUsers=TotalNoOfUsers+1;
                        }
                     
                     }               
               }
               CaseAssignedPerPerson=(parseInt(TotalChequesCounts)/parseInt(TotalNoOfUsers))
               
               hdnChequeCounts.value=TotalChequesCounts;
               hdnUserCount.value=TotalNoOfUsers;
               hdnCount.value=Math.round(CaseAssignedPerPerson);
               
                return true;
                 
            }
            
            function Get_DropBoxDetails()
            { 
                var ddlDropboxList=document.getElementById("<%=ddlDropboxList.ClientID%>");       

                var lblDropBoxName=document.getElementById("<%=lblDropBoxName.ClientID%>");       
                var lblTotalChequesCount=document.getElementById("<%=lblChequeImageCounts.ClientID%>");       

                var SelectIndex=parseInt(ddlDropboxList.selectedIndex);                        

                var strDropBoxDetails='';         
                var strRowDetails="";    
                strDropBoxDetails=ddlDropboxList.value; 
                strRowDetails=strDropBoxDetails.split('|', strDropBoxDetails.length); 

                lblDropBoxName.innerText=strRowDetails[1];
                lblTotalChequesCount.innerText=strRowDetails[2];             
            } 
    </script>

    <table>
        <tr>
            <td colspan="7">
                <asp:Label ID="lblMessage" runat="server" CssClass="ErrorMessage" Text=""></asp:Label></td>
        </tr>
        <tr>
            <td colspan="7" style="height: 21px" class="TableHeader">
                &nbsp; Cheque Image Assignment</td>
           
        </tr>
        <tr>
            <td style="width: 13px">
            </td>
            <td style="width: 100px" class="TableTitle">
                &nbsp;<strong>Batch No <span style="color: #ff0000"></span></strong>
            </td>
            <td class="TableGrid" colspan="4">
                <table border="0" cellspacing="0" style="width: 376px">
                    <tr>
                        <td style="width: 103px; height: 22px">
                            <asp:TextBox ID="txtBatchNoSearch" runat="server" SkinID="txtSkin"></asp:TextBox></td>
                        <td style="width: 15px; height: 22px">
                            <asp:Button ID="btnSearch" runat="server" CssClass="BUTTON" Font-Bold="False" Text=">>"
                                Width="30px" OnClick="btnSearch_Click" />&nbsp;</td>
                        <td style="height: 22px">
                            <asp:DropDownList ID="ddlBatchNoList" runat="server" SkinID="ddlSkin" AutoPostBack="True"
                                OnSelectedIndexChanged="ddlBatchNoList_SelectedIndexChanged">
                                <asp:ListItem>--Select--</asp:ListItem>
                            </asp:DropDownList></td>
                        <td style="width: 100px; height: 22px">
                        </td>
                    </tr>
                </table>
            </td>
            <td style="width: 100px">
                <asp:HiddenField ID="hdnUserCount" runat="server" /><asp:HiddenField ID="hdnChequeCounts" runat="server" /><asp:HiddenField ID="hdnCount" runat="server" />
            </td>
        </tr>
        <tr>
            <td style="width: 13px;">
            </td>
            <td class="TableTitle" style="width: 100px;">
                &nbsp;<strong>Dropbox </strong>
            </td>
            <td class="TableGrid" style="width: 26px;">
                &nbsp;<asp:DropDownList ID="ddlDropboxList" runat="server" SkinID="ddlSkin">
                    <asp:ListItem>--All-</asp:ListItem>
                </asp:DropDownList></td>
            <td class="TableTitle" style="width: 115px">
                &nbsp;DropBox Name</td>
            <td class="TableGrid" style="width: 100px;">
                &nbsp;<asp:Label ID="lblDropBoxName" runat="server"></asp:Label></td>
            <td style="width: 100px;" class="TableTitle">
                Chq Image Counts</td>
            <td style="width: 100px;" class="TableGrid">
                <asp:Label ID="lblChequeImageCounts" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td colspan="7" class="TableHeader">
                &nbsp; User Assignement List</td>
        </tr>
        <tr>
            <td colspan="7">
                <asp:CheckBoxList ID="chkUserList" runat="server" BorderWidth="1px" CssClass="TableGrid" Width="356px">
                </asp:CheckBoxList></td>
        </tr>
        <tr>
            <td style="height: 29px;" class="TableTitle" colspan="7">
                &nbsp;
                <asp:Button ID="btnSave" runat="server" BorderWidth="1px" Text="Assign" Width="66px" OnClick="btnSave_Click" />&nbsp;<asp:Button
                    ID="btnCancel" runat="server" BorderWidth="1px" Text="Cancel" Width="66px" OnClick="btnCancel_Click" /></td>
        </tr>
        <tr>
            <td style="width: 13px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 26px">
            </td>
            <td style="width: 115px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td style="width: 13px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 26px">
            </td>
            <td style="width: 115px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td style="width: 13px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 26px">
            </td>
            <td style="width: 115px">
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
