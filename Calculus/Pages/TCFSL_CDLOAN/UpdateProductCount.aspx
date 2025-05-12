<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/TCFSL_CDLOAN/sample.master"
    AutoEventWireup="true" CodeFile="UpdateProductCount.aspx.cs" Inherits="Pages_TCFSL_CDLOAN_UpdateProductCount" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <table style="width: 517px">
        <tr>
            <td colspan="5" style="height: 18px">&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lblMessage" runat="server" CssClass="ErrorMessage" Visible="False"
                    ForeColor="Red"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="TableHeader" colspan="4"></td>
        </tr>
        <tr>
            <td colspan="4"></td>
        </tr>
        <tr>
            <td style="width: 319px; height: 30px;" class="TableTitle">&nbsp;<b>&nbsp; Case Number</b>
            </td>
            <td style="width: 100px; height: 30px;" class="TableGrid">
                <asp:TextBox ID="txtCaseNumber" runat="server" autocomplete="off" MaxLength="200"
                    SkinID="txtSkin" Width="115px" Style="margin-left: -197px;"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 319px; height: 30px;" class="TableTitle">&nbsp;<b>&nbsp; Product Count</b>
            </td>
            <td style="width: 100px; height: 30px;" class="TableGrid">
                <asp:TextBox ID="txtProductCount" runat="server" autocomplete="off" MaxLength="200"
                    SkinID="txtSkin" Width="115px" Style="margin-left: -197px;"></asp:TextBox>
                <asp:RegularExpressionValidator ID="REVProduct" runat="server" ControlToValidate="txtProductCount"
                    ErrorMessage="Only Numeric values allow!" ValidationExpression="\d+"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td style="height: 30px;" class="TableTitle">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="txtSearch" runat="server" Text="Search" Style="font-weight: 700; background-color: #009999; color: #FFFFFF;"
                    Height="30px" Width="72px"
                    OnClick="txtSearch_Click" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnUpdate" runat="server" Text="Update" Style="font-weight: 700; background-color: #009999; color: #FFFFFF;"
                    Height="30px" Width="72px" OnClick="btnUpdate_Click" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" Style="font-weight: 700; background-color: #009999; color: #FFFFFF;"
                    Height="30px" Width="72px" OnClick="btnCancel_Click" />
            </td>
        </tr>
        <tr>
            <td colspan="4" style="height: 23px"></td>
        </tr>
    </table>
    &nbsp;&nbsp;&nbsp;&nbsp;
    Existing Product Count&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 

    <table border="1px solid" style="margin-left: 17px;">
        <tr>
            <th>1<sup>st</sup> Iteration
            </th>
            <th>2<sup>nd</sup> Iteration
            </th>
            <th>3<sup>rd</sup> Iteration
            </th>
            <th>4<sup>th</sup> Iteration
            </th>
            <th>5<sup>th</sup> Iteration
            </th>
            <th>6<sup>th</sup> Iteration
            </th>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lbl1st" runat="server"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lbl2nd" runat="server"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lbl3rd" runat="server"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lbl4th" runat="server"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lbl5th" runat="server"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lbl6th" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>
