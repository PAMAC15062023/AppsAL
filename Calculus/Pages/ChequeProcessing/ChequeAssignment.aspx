<%@ Page Language="C#" MasterPageFile="~/Pages/MasterPage.master" AutoEventWireup="true" CodeFile="ChequeAssignment.aspx.cs" Inherits="Pages_ChequeProcessing_ChequeAssignment" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script language="javascript" type="text/javascript" src="../popcalendar.js"></script>
<script language="javascript" type="text/javascript" >
 

</script>


    <table cellpadding="0" cellspacing="1">
        <tr>
            <td colspan="7" style="height: 17px">
                <asp:Label ID="lblMessage" runat="server" CssClass="ErrorMessage"></asp:Label></td>
        </tr>
        <tr>
            <td class="TableHeader" colspan="7" style="height: 17px">
                &nbsp;Cheque Assignment
            </td>
        </tr>
        <tr>
            <td style="width: 6px;">
            </td>
            <td style="width: 134px;" class="TableTitle">
                &nbsp;Assign Date</td>
            <td style="width: 100px;">
                <asp:TextBox ID="txtAssignDate" runat="server" Font-Size="Small" MaxLength="10" Width="113px" BorderWidth="1px"></asp:TextBox></td>
            <td style="width: 100px;">
                <img id="ImgDOB1" alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtAssignDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                    src="SmallCalendar.png" style="width: 19px; height: 18px;" /></td>
            <td style="width: 100px;">
            </td>
            <td style="width: 100px;">
            </td>
            <td style="width: 100px;">
            </td>
        </tr>
        <tr>
            <td style="width: 6px">
            </td>
            <td style="width: 134px" class="TableTitle">
                &nbsp;Assign To</td>
            <td style="width: 100px">
                <asp:DropDownList ID="ddlAssignTo" runat="server" Width="118px">
                </asp:DropDownList></td>
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
            <td style="width: 6px">
            </td>
            <td style="width: 134px" class="TableTitle">
                &nbsp;Upload Scan Image</td>
            <td colspan="4">
                <asp:FileUpload ID="FileUpload1" runat="server" BorderWidth="1px" Width="413px" /></td>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td colspan="7" style="height: 30px">
                &nbsp;
                <asp:Button ID="btnAddImages" runat="server" BorderWidth="1px" Text="Add Image" OnClick="btnAddImages_Click" />
                <asp:Button ID="Button1" runat="server" BorderWidth="1px" Text="Clear Data" OnClick="btnAddImages_Click" /></td>
        </tr>
        <tr>
            <td colspan="7">
                <asp:GridView ID="GridView1" runat="server">
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td style="width: 6px">
            </td>
            <td style="width: 134px"><asp:Button ID="btnUploadAll" runat="server" BorderWidth="1px" Text="Upload All" OnClick="btnUploadAll_Click" /></td>
            <td style="width: 100px"><asp:Button ID="btnClose" runat="server" BorderWidth="1px" Text="Close" OnClick="btnClose_Click" /></td>
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

