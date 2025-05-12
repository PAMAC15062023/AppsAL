<%@ Page Language="C#" MasterPageFile="~/FETracking/FETracking.master" AutoEventWireup="true" Theme="SkinFile" CodeFile="FECheckIn.aspx.cs" Inherits="FETracking_FECheckIn"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="C1" Runat="Server">
<table border="0" cellpadding="0" cellspacing="0" width="99%">
<tr><td>
    <fieldset>
        <legend class="FormHeading">Check-In</legend>
        <table border="0" cellpadding="0" cellspacing="0" width="100%">            
            <tr>               
                <td style="width: 3%">
                </td>
                <td  valign="top" style="width: 13%">
                    FE Code <span style="color: #ff0033">* </span></td>
                <td style="width: 1%">
                    :</td>
                <td  valign="top" >
                    <asp:TextBox ID="txtFECode" runat="server" MaxLength="10" OnTextChanged="txtFECode_TextChanged"
                        SkinID="txtSkin"></asp:TextBox>
                    &nbsp; &nbsp; &nbsp;
                    &nbsp; &nbsp;&nbsp;&nbsp;<asp:Button ID="btnGet" runat="server" OnClick="btnGet_Click" SkinID="btn" Text="Get Name"
                        ValidationGroup="vFE" /></td>
            </tr>
            <tr>
                <td style="width: 3%">
                </td>
               
                <td  valign="top" style="width: 13%" >
                   FE Name  
                   
                </td>
                <td style="width: 1%" valign="top">
                    :</td>
                <td  valign="top" >
                    <asp:TextBox ID="txtFE_Name" runat="server" MaxLength="10" SkinID="txtSkin" ReadOnly="True"></asp:TextBox>
                    &nbsp; &nbsp; &nbsp;
                   &nbsp; &nbsp;&nbsp; &nbsp;<asp:Label ID="lbPending" runat="server" CssClass="lblSkin" Font-Bold="True"
                       Text="Pending Cases:" Visible="False"></asp:Label>
                   <asp:Label ID="lbCount" runat="server" CssClass="lblSkin" Font-Bold="True" Font-Size="12pt"
                       Visible="False"></asp:Label></td>
               
            </tr>
            <tr>
                <td style="width: 3%; height: 22px;">
                </td>
                <td   valign="top" style="width:13%">
                    Case Status 
                </td>
                <td style="width: 1%; height: 22px;" valign="top">
                    :</td>
                <td colspan="1" valign="top"  >
                    <asp:DropDownList ID="ddlCaseStatus" runat="server" SkinID="ddlSkin" Width="130px" >
                        <asp:ListItem>Completed</asp:ListItem>
                        <asp:ListItem>Pending</asp:ListItem>
                    </asp:DropDownList></td>
               
            </tr>
            <tr>
                <td style="width: 3%; height: 24px;" >
                </td>
               
                <td valign="top" style="width: 13%">
                    Scan Barcode <span style="color: #ff0033">* </span></td>
                <td style="width: 1%; height: 24px" valign="top">
                    :</td>
                <td colspan="1"  valign="top" >
                    <asp:TextBox ID="txtbarcode" runat="server" MaxLength="200" onkeyup="txtbarcode.focus();"
                        OnTextChanged="txtbarcode_TextChanged" SkinID="txtSkin"   AutoPostBack="True"></asp:TextBox></td>
               
            </tr>
            <tr>
                <td style="width: 3%; height: 14px;">
                </td>
                <td style="width: 12px" >
                </td>
                <td style="width: 1%; height: 14px">
                </td>
                <td colspan="1" style="height: 14px">
                    <asp:Label ID="lblMsg" runat="server" SkinID="lblErrormsg" Text="" Visible="false"></asp:Label></td>
            </tr>
            <tr>
            <td ></td>
                <td  colspan="3">                          
                   <asp:Panel ID="pnlAssign" runat="server" Visible="false"  BorderStyle="Solid" BorderWidth="2px" BorderColor="black" width="700px">
                        <table width="100%">
                            <tr>
                                <td colspan="1" style="height: 16px">
                                    <asp:Label ID="lblAssign" runat="server" Font-Bold="True" SkinID="lblErrormsg"></asp:Label>
                                   </td>
                            </tr>
                            <tr>
                                <td colspan="1" style="height: 26px">
                                    <asp:Button ID="btnOk" runat="server" OnClick="btnOk_Click" SkinID="btn" Text="Ok" Width="57px" />
                                    <asp:Button ID="btnCancel" runat="server"
                                        OnClick="btnCancel_Click" SkinID="btn" Text="Cancel" /></td>
                            </tr>
                        </table>
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td colspan="3">
                    <asp:GridView ID="gvIssued" runat="server" SkinID="gridviewNoSort">
                    </asp:GridView>
                    <asp:SqlDataSource ID="SqlDataSourceCheckOut" runat="server" ConnectionString="<%$ ConnectionStrings:CMConnectionString %>"
                        ProviderName="<%$ ConnectionStrings:CMConnectionString.ProviderName %>" SelectCommand="">
                    </asp:SqlDataSource>
                </td>
            </tr>
             <asp:RequiredFieldValidator ID="rfvtxtFECODE" runat="server" ControlToValidate="txtFECode" ValidationGroup="vFE"
                                      ErrorMessage="Please enter FE Code."  Display="none" SetFocusOnError="true" ></asp:RequiredFieldValidator><asp:ValidationSummary ID="vsValidateuser" runat="server" ValidationGroup="vFE"
                      ShowMessageBox="True" ShowSummary="False" />
                        <asp:RequiredFieldValidator ID="rfvtxtFECODE1" runat="server" ControlToValidate="txtFECode" ValidationGroup="vFECheckout"
                                      ErrorMessage="Please enter FE Code."  Display="none" SetFocusOnError="true" ></asp:RequiredFieldValidator><asp:RequiredFieldValidator ID="rfvtxtbarcode" runat="server" ControlToValidate="txtbarcode" ValidationGroup="vFECheckout"
                                      ErrorMessage="Please scan barcode."  Display="none" SetFocusOnError="true" ></asp:RequiredFieldValidator><asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="vFECheckout"
                      ShowMessageBox="True" ShowSummary="False" />  
        </table>
    </fieldset>
    </td></tr></table>
</asp:Content>

