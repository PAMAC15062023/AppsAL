<%@ Page Language="C#" MasterPageFile="~/Pages/MasterPage.master" AutoEventWireup="true" CodeFile="CPRT_ChequePrinting.aspx.cs" Inherits="CPRT_ChequePrinting" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%-- <script language="javascript" type="text/javascript" >
 function ValidateAddNew()
 {
        hdnGroupID = document.getElementById("<%=hdnGroupID.ClientID%>");
        txtGroupDescription = document.getElementById("<%=txtGroupDescription.ClientID%>");
        txtGroupName = document.getElementById("<%=txtGroupName.ClientID%>");
        ddlBranchList = document.getElementById("<%=ddlBranchList.ClientID%>");
        ddlIsActivate = document.getElementById("<%=ddlIsActivate.ClientID%>");
        grv_GroupInfo = document.getElementById("<%=grv_GroupInfo.ClientID%>");
       
        hdnGroupID.value = "0";
        txtGroupName.value = ""; ;
        txtGroupDescription.value = "" ;
        ddlIsActivate.selectedIndex=0;     
        ddlBranchList.selectedIndex=0;                       
          
        return false;
       
 
 }
 
 function ValidateSave()
 {
    var ReturnValue=true;
    var ErrorMessage="";
    
        hdnGroupID = document.getElementById("<%=hdnGroupID.ClientID%>");
        txtGroupDescription = document.getElementById("<%=txtGroupDescription.ClientID%>");
        txtGroupName = document.getElementById("<%=txtGroupName.ClientID%>");
        ddlBranchList = document.getElementById("<%=ddlBranchList.ClientID%>");
        ddlIsActivate = document.getElementById("<%=ddlIsActivate.ClientID%>");
         
        lblMessage= document.getElementById("<%=lblMessage.ClientID%>");
 
        if (txtGroupDescription.value=='')
        {
            ErrorMessage="Please enter Group Description to continue....";
            ReturnValue=false;
        }
        if (txtGroupName.value=='')
        {
            ErrorMessage="Please enter Group Name to continue....";
            ReturnValue=false;
        }
        if (ddlBranchList.value=='--Select--')
        {
            ErrorMessage="Please select Branch to continue....";
            ReturnValue=false;
        }
        if (ddlIsActivate.selectedIndex==0)
        {
            ErrorMessage="Please select Activate  Status to continue....";
            ReturnValue=false;
        }
         
    if (ReturnValue)
    {
        lblWait = document.getElementById("<%=lblWait.ClientID%>");   
        lblWait.innerText="Please wait.....";
    }    
    
        lblMessage.innerText=ErrorMessage;         
    
        return ReturnValue;
 }
 
 function hover(value,rowno)
 {
    //debugger;
    grv_GroupInfo = document.getElementById("<%=grv_GroupInfo.ClientID%>");
    hdnGroupID = document.getElementById("<%=hdnGroupID.ClientID%>");
        
    rowno=(parseInt(rowno)+1);
        
    if (value=='in')
    {
     if (hdnGroupID.value!=grv_GroupInfo.rows[rowno].cells[0].innerText)
        {
            grv_GroupInfo.rows[rowno].style.backgroundColor = "#ffff33";
        }
    }
    else
    {
        if (hdnGroupID.value!=grv_GroupInfo.rows[rowno].cells[0].innerText)
        {
            grv_GroupInfo.rows[rowno].style.backgroundColor = "white";
        }
    }
 
 }
 
 
 function Pro_SelectRow(rowno,id)
{
        //debugger;
        //alert(rowno);
        rowno=(parseInt(rowno)+1);
        hdnGroupID = document.getElementById("<%=hdnGroupID.ClientID%>");
        txtGroupDescription = document.getElementById("<%=txtGroupDescription.ClientID%>");
        txtGroupName = document.getElementById("<%=txtGroupName.ClientID%>");
        ddlBranchList = document.getElementById("<%=ddlBranchList.ClientID%>");
        ddlIsActivate = document.getElementById("<%=ddlIsActivate.ClientID%>");
        grv_GroupInfo = document.getElementById("<%=grv_GroupInfo.ClientID%>");
        
              
        //-/-if(rowno != null)
        //{
            
                hdnGroupID.value = grv_GroupInfo.rows[rowno].cells[0].innerText;
                txtGroupName.value = grv_GroupInfo.rows[rowno].cells[1].innerText; ;
                txtGroupDescription.value = grv_GroupInfo.rows[rowno].cells[2].innerText ;
                ddlIsActivate.value=grv_GroupInfo.rows[rowno].cells[3].innerText;     
                ddlBranchList.value=grv_GroupInfo.rows[rowno].cells[4].innerText;                       
                grv_GroupInfo.rows[rowno].style.backgroundColor = "DarkGray";//"#E0E0E0";
            
            
        //}

         
        
}
 
 </script>--%>

    <table border="0" cellpadding="2" cellspacing="2">
        <tr>
            <td colspan="5">
                <asp:Label ID="lblMessage" runat="server" CssClass="ErrorMessage"></asp:Label>&nbsp;
            
            </td>
        </tr>

        <tr>
            <td class="TableHeader" colspan="5">&nbsp;Cheque Printing Screen</td>
        </tr>
        <tr>
            <td class="TableTitle" style="width: 162px">&nbsp;Company_directorName</td>
            <td style="width: 100px">
                <asp:DropDownList ID="ddlCodirList" runat="server" CssClass="dropdown">
                </asp:DropDownList></td>
            <td style="width: 100px"></td>
            <td style="width: 100px"></td>
            <td style="width: 100px"></td>
        </tr>
        <tr>
            <td class="TableTitle" style="width: 162px">&nbsp;BankName</td>
            <td style="width: 100px">
                <asp:DropDownList ID="ddlBankName" runat="server" CssClass="dropdown" AutoPostBack="True"
                    OnSelectedIndexChanged="ddlBankName_SelectedIndexChanged">
                </asp:DropDownList></td>
            <td style="width: 100px"></td>
            <td style="width: 100px"></td>
            <td style="width: 100px"></td>
        </tr>
        <tr>
            <tr>
                <td class="TableTitle" style="width: 162px">&nbsp;BranchName</td>
                <td style="width: 100px">
                    <asp:DropDownList ID="ddlBranchName" runat="server" CssClass="dropdown">
                    </asp:DropDownList></td>
                <td style="width: 100px"></td>
                <td style="width: 100px"></td>
                <td style="width: 100px"></td>
            </tr>
            <%--   <tr>

            <td class="TableTitle" style="width: 162px">
                &nbsp;ChequeStartNumber</td>
            <td style="width: 100px">
                <asp:TextBox ID="txtChqStartNo" runat="server"  BorderWidth="1px"></asp:TextBox></td>
            <td style="width: 100px">
                </td>
            <td style="width: 100px">
                &nbsp;</td>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td class="TableTitle" style="width: 162px">
                &nbsp;ChequeEndNumber</td>
            <td style="width: 100px">
                <asp:TextBox ID="txtChqEndNo" runat="server" BorderWidth="1px" ></asp:TextBox></td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
        </tr>--%>
            <%--      <tr>
            <td class="TableTitle" style="width: 162px">
                &nbsp;Is Active</td>
            <td style="width: 100px">
                <asp:DropDownList ID="ddlIsActivate" runat="server" CssClass="dropdown" ValidationGroup="BranchENtry">
                    <asp:ListItem>--Select--</asp:ListItem>
                    <asp:ListItem Value="True">Yes</asp:ListItem>
                    <asp:ListItem Value="False">No</asp:ListItem>
                </asp:DropDownList></td>
            <td style="width: 100px">
                </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
        </tr>--%>
            <%--   <tr>
            <td class="TableTitle" style="width: 162px">
                &nbsp;Branch Mapping</td>
            <td style="width: 100px">
                <asp:DropDownList ID="ddlBranchList" runat="server" CssClass="dropdown" ValidationGroup="BranchENtry">
                </asp:DropDownList></td>
            <td style="width: 100px">
                </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
        </tr>--%>
            <%--   <tr>
            <td colspan="5">
                <asp:HiddenField ID="hdnGroupID" runat="server" Value="0" />
            </td>
        </tr>--%>
            <tr>
                <td class="TableHeader" colspan="5">&nbsp;<asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Search"
                    ValidationGroup="BranchENtry" Width="67px" />
                    <%--  <asp:Button ID="btnAddNew" runat="server" OnClick="btnAddNew_Click" Text="Add New"
                    ValidationGroup="BranchENtry" Width="67px" />--%>
                    <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" Text="Cancel" />&nbsp;
                <asp:Label ID="lblWait" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td colspan="7">
                    <div style="overflow: scroll; width: 840px; height: 199px">
                        <asp:GridView ID="grvTransactionInfo" runat="server" AutoGenerateColumns="False"
                            BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px"
                            CellPadding="4" Font-Size="8pt"
                            PageSize="20">
                            <Columns>

                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkSelect" runat="server" AutoPostBack="true" OnCheckedChanged="chkApprove_CheckedChanged" />


                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID" />
                                <asp:BoundField DataField="UploadDate" HeaderText="UploadDate" SortExpression="UploadDate" />
                                <asp:BoundField DataField="Company_DirectorName" HeaderText="Company_DirectorName" SortExpression="Company_DirectorName" />
                                <asp:BoundField DataField="BankName" HeaderText="BankName" SortExpression="BankName" />
                                <asp:BoundField DataField="BranchName" HeaderText="BranchName" SortExpression="BranchName" />
                                <asp:BoundField DataField="PayeeName" HeaderText="PayeeName" />
                                <asp:BoundField DataField="Amount" HeaderText="Amount" SortExpression="Amount" />
                                <asp:BoundField DataField="PaymentDetails" HeaderText="PaymentDetails" />
                                <asp:BoundField DataField="Narration" HeaderText="Narration" />
                                <asp:BoundField DataField="CalculusTransactionID" HeaderText="CalculusTransactionID" />
                                <asp:BoundField DataField="AccountHead" HeaderText="Account Head" />
                                <asp:BoundField DataField="CurrentStatus" HeaderText="CurrentStatus" />
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        </td></tr>
              
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <RowStyle BackColor="White" Font-Names="Tahoma" Font-Size="8pt" ForeColor="#330099" />
                            <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
                            <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
                            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
                            <HeaderStyle BackColor="#990000" Font-Bold="True" Font-Names="Tahoma" Font-Size="8pt"
                                ForeColor="#FFFFCC" />
                        </asp:GridView>
                    </div>
                </td>
            </tr>
            <%-- <tr>
            <td style="height: 31px;" class="TableTitle" colspan="7">&nbsp;
                <asp:Button ID="btnView" runat="server" BorderWidth="1px" Text="Print" Width="152px" OnClick="btnView_Click" />
                 </tr>--%>
            <%--   </asp:GridView>
            </td>--%>
            <%--</tr>--%>
    </table>
</asp:Content>

