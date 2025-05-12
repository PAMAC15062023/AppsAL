<%@ Page Language="C#" AutoEventWireup="true" Theme="SkinFile" MasterPageFile="Admin_MasterPage.master" CodeFile="CompanyMaster.aspx.cs" Inherits="Administrator_CompanyMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server" >
    <asp:Panel ID="pnlCompanyMaster" runat="server" Visible="true">
    <table id="tblMain" width="99%">
    <tr>
    <td style="padding-left:10px">
    
            <fieldset><legend class="FormHeading">Company Master</legend>
            <table width="100%" cellpadding="1" class="tblBorder" style="border:0" cellspacing="0">
            <tr  class="rowSeparator">
                <td align="center" class="txtError" colspan="12"  valign="top">
                    <asp:Label ID="lblMsg" runat="server" ForeColor="Red" Text="Label" Visible="False"></asp:Label></td>
            </tr>
            <tr  >
                <td  colspan="2">
                    Company Code<asp:Label SkinID="lblSkin" ID="Label4" runat="server"  Height="12px" Text="*" Width="8px" ForeColor="Red"></asp:Label></td>
                <td class="separator">:</td>
                <td ><asp:TextBox SkinID="txtSkin" ID="txtCoCode" runat="server" CssClass="textbox" MaxLength="10"></asp:TextBox></td>
                <td colspan="2">
                    <span class="txtError">
                        Company Name<asp:Label SkinID="lblSkin" ID="Label1" runat="server" ForeColor="Red"  Text="*" ></asp:Label></span></td>
                <td class="separator">:</td>
                <td><asp:TextBox SkinID="txtSkin" ID="txtCoName" runat="server" CssClass="textbox" MaxLength="100"></asp:TextBox>
                    </td>
                <td  colspan="2" >
                    </td>
                <td class="separator"></td>
                <td>
                    </td>
            </tr>                      
             <tr >
                    <td colspan="3" ><b>
                        Correspondence Address</b></td>
                    
                </tr>
            <tr  >
                <td  valign="top" colspan="2">
                    Address1</td>
                <td class="separator">:</td>
                <td ><asp:TextBox SkinID="txtSkin" ID="txtCorAdd1" runat="server" CssClass="textbox" MaxLength="100" ></asp:TextBox></td>
                <td  colspan="2">
                    Address2</td>
                <td class="separator">:</td>
                <td><asp:TextBox SkinID="txtSkin" ID="txtCorAdd2" runat="server" CssClass="textbox" MaxLength="100" ></asp:TextBox></td>
                <td  colspan="2" style="width: 75px">
                    Address3</td>
                <td class="separator" style="width: 10px">
                    :</td>
                <td><asp:TextBox SkinID="txtSkin" ID="txtCorAdd3" runat="server" CssClass="textbox" MaxLength="100" ></asp:TextBox></td>
            </tr>
               
            <tr  >
                <td  valign="top" colspan="2">
                    City</td>
                <td class="separator">:</td>
                <td ><asp:TextBox SkinID="txtSkin" ID="txtCorCity" runat="server" CssClass="textbox" MaxLength="50"></asp:TextBox></td>
                <td colspan="2">
                    Pin Code</td>
                <td class="separator">:</td>
                <td><asp:TextBox SkinID="txtSkin" ID="txtCorPin" runat="server" CssClass="textbox" MaxLength="10"></asp:TextBox></td>    
                <td class="label" colspan="2">
                    </td>
                <td class="separator" ></td>
                <td></td>
            </tr>
            <tr >
                    <td  colspan="2" valign="top"><b>
                        Registered Address</b></td>
                    
                </tr>
            <tr  >
                <td class="label" valign="top" colspan="2">
                    Address1</td>
                <td class="separator">:</td>
                <td ><asp:TextBox SkinID="txtSkin" ID="txtRegAdd1" runat="server" CssClass="textbox" MaxLength="100"></asp:TextBox></td>
                <td  colspan="2">
                    Address2</td>
                <td class="separator">:</td>
                <td><asp:TextBox SkinID="txtSkin" ID="txtRegAdd2" runat="server" CssClass="textbox" MaxLength="100"></asp:TextBox>&nbsp;
                  
                </td>
                <td colspan="2" >
                    Address3</td>
                <td class="separator" >
                    :</td>
                <td><asp:TextBox SkinID="txtSkin" ID="txtRegAdd3" runat="server" CssClass="textbox" MaxLength="100"></asp:TextBox></td>
            </tr>
            <tr  >
                <td  colspan="2">
                    City</td>
                <td class="separator">:</td>
                <td><asp:TextBox SkinID="txtSkin" ID="txtRegCity" runat="server" CssClass="textbox" MaxLength="50"></asp:TextBox></td>
                <td class="label" colspan="2">
                    Pin Code</td>
                <td class="separator">:</td>
                <td><asp:TextBox SkinID="txtSkin" ID="txtRegPin" runat="server" CssClass="textbox" MaxLength="50"></asp:TextBox></td>
                <td colspan="2" >
                    </td>
                <td class="separator" ></td>
                <td></td>
            </tr>
            <tr>
                <td colspan="12" >
                </td>
            </tr>
            <tr>
                <td colspan="14" align="left">
                       &nbsp;<span class="txtRed"> * </span><span >&nbsp;<b>Indicate mandatory fields.</b></span>
                 </td>
            </tr>
                
            <tr>
                <td colspan="12" >
                </td>
            </tr>
             <tr>
                <%--<td class="label" colspan="2">
                </td>
                <td class="separator">
                </td>
                <td style="width: 175px">
                </td>--%>
                <td  colspan="12" align="center">
            <asp:Button SkinID="btnSaveSkin" ID="btnSave" runat="server" Text="Save" Width="62px" OnClick="btnSave_Click" ValidationGroup="valGrpCom" />
            <asp:Button SkinID="btnCancelSkin" ID="btnCancel" runat="server" Text="Cancel" Width="67px" OnClick="btnCancel_Click" /></td>
                <%--<td class="label" colspan="2" style="width: 75px">
                </td>
                <td class="separator" style="width: 10px">
                </td>
                <td>--%>
                <%--</td>--%>
            </tr>
                 
                <tr>
                <td colspan="12"></td>
                </tr>
            <tr >
                <td align="center" class="txtError" colspan="12" valign="top">
                    &nbsp; &nbsp;&nbsp;
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" DisplayMode="List"
                    ShowMessageBox="True" ShowSummary="False" ValidationGroup="valGrpCom" />
                <asp:RequiredFieldValidator ID="valComCode" runat="server" ControlToValidate="txtCoCode"
                    Display="None" ErrorMessage="Please enter Company Code." SetFocusOnError="True"
                    ValidationGroup="valGrpCom"></asp:RequiredFieldValidator>
                <asp:RequiredFieldValidator ID="valCoName" runat="server" ControlToValidate="txtCoName"
                    Display="None" ErrorMessage="Please enter Company Name." SetFocusOnError="True"
                    ValidationGroup="valGrpCom"></asp:RequiredFieldValidator></td>
                </tr>

            </table>
               
            </fieldset></td>
    </tr>
    </table>
            </asp:Panel>
       
       </asp:Content>