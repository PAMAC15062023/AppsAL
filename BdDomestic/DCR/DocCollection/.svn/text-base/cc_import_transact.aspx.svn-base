<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/CPV/CC/CC_MasterPage.master" CodeFile="cc_import_transact.aspx.cs" Inherits="CPV_CC_cc_import_transact" Theme="SkinFile" %>
<asp:Content id="Content1" runat="server" ContentPlaceholderID="C1">&nbsp;
    <fieldset><legend class="FormHeading">Import CSV File</legend>
        <asp:Label ID="Label1" runat="server" Text="Folder Path"></asp:Label>
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
        <asp:TextBox ID="txtCSVFolderPath" runat="server"></asp:TextBox>
        <asp:Button ID="btnOpenFldrBwsr" runat="server" Width="32px" /><br />
        &nbsp;<asp:Label ID="Label2" runat="server" Text="File Path"></asp:Label>
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
        &nbsp;&nbsp;&nbsp;<asp:FileUpload ID="FileUpload" runat="server" Width="242px" /><br />
        <br />
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp;&nbsp;
        <asp:CheckBox ID="cbColNameHeader" runat="server" Checked="True" SkinID="chkSkin" Text="Column Name Header"
            Width="192px" />
        <asp:TextBox ID="txtFileName" runat="server"></asp:TextBox><br />
        <br />
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; Format :
        <asp:DropDownList ID="DropDownList1" runat="server">
            <asp:ListItem>Tab Delimited</asp:ListItem>
        </asp:DropDownList>
        &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp;&nbsp;<br />
        <br />
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp;&nbsp;
        <asp:Button ID="btnImport" runat="server" OnClick="btnImport_Click" Text="Import CSV Data"
            Width="274px" /><br />
        &nbsp;<br />
        <asp:GridView ID="dGridCSVdata" runat="server" Caption="Imported CSV Data" Width="664px">
        </asp:GridView>
        <br />
    </fieldset></asp:Content>