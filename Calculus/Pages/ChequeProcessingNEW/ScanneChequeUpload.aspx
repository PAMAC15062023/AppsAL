<%@ Page Language="C#" MasterPageFile="~/Pages/MasterPage.master" AutoEventWireup="true"
    CodeFile="ScanneChequeUpload.aspx.cs" Inherits="Pages_ChequeProcessingNEW_ScanneChequeUpload"
    Title="Untitled Page" StylesheetTheme="SkinFile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="javascript" type="text/javascript">
    
        function Get_BatchDetails()
        {
            var ddlBatchNoList=document.getElementById("<%=ddlBatchNoList.ClientID%>");       

            var lblClientName=document.getElementById("<%=lblClientName.ClientID%>");       
            var lblBranchName=document.getElementById("<%=lblBranchName.ClientID%>");  

            var SelectIndex=parseInt(ddlBatchNoList.selectedIndex);                        

            var strBatchDetails=''
            var strClientName='';
            var strBranchName='';
            var strRowDetails="";   
                       

            if (ddlBatchNoList.selectedIndex!=0)   
            {

                strBatchDetails=ddlBatchNoList.value; 
                strRowDetails=strBatchDetails.split('|', strBatchDetails.length); 

                lblBranchName.innerText=strRowDetails[0];
                lblClientName.innerText=strRowDetails[1];
            } 
            
        }   
        function Get_DropBoxDetails()
        {
            
            var ddlDropBoxList=document.getElementById("<%=ddlDropBoxList.ClientID%>");       

            var lblDropBoxName=document.getElementById("<%=lblDropBoxName.ClientID%>");       
            var lblTotalChequesCount=document.getElementById("<%=lblTotalChequesCount.ClientID%>");       
             
            var SelectIndex=parseInt(ddlDropBoxList.selectedIndex);                        

            var strDropBoxDetails=''         
            var strRowDetails="";   
                       

            if (ddlDropBoxList.selectedIndex!=0)   
            { 
                strDropBoxDetails=ddlDropBoxList.value; 
                strRowDetails=strDropBoxDetails.split('|', strDropBoxDetails.length); 
                
                lblDropBoxName.innerText=strRowDetails[1];
                lblTotalChequesCount.innerText=strRowDetails[2];
                
            } 
            else            
            {
                lblDropBoxName.innerText='';
                lblTotalChequesCount.innerText='';
                 
            }
            //addFileUploadBox(true);
            
        }
       
        function Page_load_validation()
        {
            
        }
        function addFileUploadBox(value)
        {
        
           var lblTotalChequesCount=document.getElementById("<%=lblTotalChequesCount.ClientID%>");       
           var lblTotalFileUploaded=document.getElementById("<%=lblTotalFileUploaded.ClientID%>");       
      
           var uploadArea = document.getElementById ("upload-area");
           var ControlsCount=parseInt(lblTotalChequesCount.innerText);           
           //debugger;
            
//           
//        for (j=0;j<=uploadArea.children.length-1;j++)
//        {    
//            if (uploadArea.children[j].tagName=='INPUT')
//            {
//                var El=document.getElementById(uploadArea.children[j].id);
//                uploadArea.removeChild(El);
//            }
//            else
//            {
//               var El=document.getElementById(uploadArea.children[j].id);
//               uploadArea.removeChild(El);   
//            }
//        }
             
           for(i =0; i <=ControlsCount-2; i++)
            { 
             
                    
            if (!document.getElementById || !document.createElement)            
            return false;

           
            if (!uploadArea)
            return;
            
            if (!addFileUploadBox.lastAssignedId_New)
            addFileUploadBox.lastAssignedId_New = 1;

            var newLine = document.createElement ("br");
            newLine.setAttribute ("id", "new" + addFileUploadBox.lastAssignedId_New);
            uploadArea.appendChild (newLine);
            

            var newUploadBox = document.createElement ("input");

            // Set up the new input for file uploads
            newUploadBox.type = "file";
            newUploadBox.size = "60";
            //newUploadBox.value="c:\\avinash.txt";//row.cells[2].innerText;

            // The new box needs a name and an ID
            if (!addFileUploadBox.lastAssignedId)
            addFileUploadBox.lastAssignedId = 1;

            newUploadBox.setAttribute ("id", "dynamic" + addFileUploadBox.lastAssignedId);
            newUploadBox.setAttribute ("name", "dynamic:" + addFileUploadBox.lastAssignedId);
            //newUploadBox.setAttribute ("value", "c:\\avinash.txt");
             
            uploadArea.appendChild (newUploadBox);  
            addFileUploadBox.lastAssignedId++;
            
            addFileUploadBox.lastAssignedId_New++;
            
            }                      
            lblTotalFileUploaded.innerText=addFileUploadBox.lastAssignedId;
            return false;
            
        
        }
        
        

    </script>

     <form id="form2" enctype="multipart/form-data">
        <table>
            <tr>
                <td colspan="8" style="height: 19px">
                    <asp:Label ID="lblMessage" runat="server" CssClass="ErrorMessage"></asp:Label></td>
            </tr>
            <tr>
                <td class="TableHeader" colspan="8" style="height: 17px">
                    &nbsp; Scanned Cheque Upload
                </td>
            </tr>
            <tr>
                <td style="width: 16px;">
                </td>
                <td class="TableTitle" style="width: 256px;">
                    &nbsp;<strong>Batch No</strong></td>
                <td class="TableGrid" colspan="3">
                    <table cellspacing="0" style="width: 45px">
                        <tr>
                            <td style="width: 3px; height: 32px">
                                <asp:TextBox ID="txtBatchNo" runat="server" MaxLength="100" SkinID="txtSkin" Width="138px"></asp:TextBox>
                            </td>
                            <td style="width: 10px; height: 32px">
                                <asp:Button ID="btnGo" runat="server" BorderWidth="1px" Text=">>" Width="27px" OnClick="btnGo_Click"
                                    BackColor="DarkGray" Font-Bold="True" /></td>
                            <td style="width: 100px; height: 32px">
                                <asp:DropDownList ID="ddlBatchNoList" runat="server" SkinID="ddlSkin" AutoPostBack="True"
                                    OnSelectedIndexChanged="ddlBatchNoList_SelectedIndexChanged">
                                    <asp:ListItem>--Select--</asp:ListItem>
                                </asp:DropDownList></td>
                        </tr>
                    </table>
                </td>
                <td style="width: 134px;" class="TableTitle">
                    &nbsp;Branch Name</td>
                <td style="width: 100px;" class="TableGrid">
                    <asp:Label ID="lblBranchName" runat="server"></asp:Label></td>
                <td style="width: 100px;">
                </td>
            </tr>
            <tr>
                <td style="width: 16px;">
                </td>
                <td class="TableTitle" style="width: 256px;">
                    &nbsp;Drop Box Code</td>
                <td class="TableGrid" style="width: 100px;">
                    <asp:DropDownList ID="ddlDropBoxList" runat="server" SkinID="ddlSkin" AutoPostBack="True"
                        OnSelectedIndexChanged="ddlDropBoxList_SelectedIndexChanged">
                    </asp:DropDownList></td>
                <td class="TableTitle" style="width: 182px;">
                    &nbsp;Drop Box Name</td>
                <td class="TableGrid" style="width: 100px;">
                    <asp:Label ID="lblDropBoxName" runat="server"></asp:Label></td>
                <td style="width: 100px" class="TableTitle">
                    Client Name</td>
                <td style="width: 39px" class="TableGrid">
                    <asp:Label ID="lblClientName" runat="server"></asp:Label></td>
                <td style="width: 100px;">
                </td>
            </tr>
            <tr>
                <td style="width: 16px;">
                </td>
                <td style="width: 256px;" class="TableTitle">
                    &nbsp;<strong>Total Cheques Collected</strong></td>
                <td style="width: 100px;" class="TableGrid">
                    <asp:Label ID="lblTotalChequesCount" runat="server"></asp:Label></td>
                <td style="width: 182px;" class="TableTitle">
                    &nbsp;Uploaded On server</td>
                <td style="width: 100px;" class="TableGrid">
                    <asp:Label ID="lblUploadedOnServer" runat="server"></asp:Label></td>
                <td colspan="3">
                    <asp:HiddenField ID="hdnUploadFileDetails" runat="server" /><asp:HiddenField ID="hdnBatchNo" runat="server" />
                </td>
            </tr>
            <tr>
                <td class="TableHeader" colspan="8">
                    &nbsp;Multiple Cheque Image Upload</td>
            </tr>
            <tr>
                <td style="width: 16px">
                </td>
                <td colspan="7">
                    <p id="upload-area">
                        <input id="File1" runat="server" type="file" style="height: 24px;" size="60" visible="true" />
                    </p>
                    &nbsp;File Uploaded :
                    <asp:Label ID="lblTotalFileUploaded" runat="server" Width="17px" CssClass="TableGrid">1</asp:Label><br />
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="height: 32px;" colspan="8" class="TableTitle">
                    &nbsp;
                    <asp:Button ID="btnSave" runat="server" BorderWidth="1px" Text="Upload to Server"
                        Width="128px" OnClick="btnSave_Click" Height="25px" />
                    <asp:Button ID="btnClose" runat="server" BorderWidth="1px" Text="Close" Width="67px"
                        OnClick="btnClose_Click" Height="25px" />
                </td>
            </tr>
            <tr>
                <td style="width: 16px">
                </td>
                <td style="width: 256px">
                </td>
                <td style="width: 100px">
                </td>
                <td style="width: 182px">
                </td>
                <td style="width: 100px">
                </td>
                <td style="width: 100px">
                </td>
                <td style="width: 39px">
                </td>
                <td style="width: 100px">
                </td>
            </tr>
            <tr>
                <td style="width: 16px">
                </td>
                <td style="width: 256px">
                </td>
                <td style="width: 100px">
                </td>
                <td style="width: 182px">
                </td>
                <td style="width: 100px">
                </td>
                <td style="width: 100px">
                </td>
                <td style="width: 39px">
                </td>
                <td style="width: 100px">
                </td>
            </tr>
        </table>
    </form>
  
   
</asp:Content>
