<%@ page language="C#" autoeventwireup="true" theme="SkinFile" masterpagefile="~/HDFCBANK/HDFCBANK/MasterPage.master" inherits="CPV_KYC_KYC_PendingList, App_Web_kyc_pendinglist.aspx.513d3bc3" viewStateEncryptionMode="Always" %>

<asp:Content ID="Content1" ContentPlaceHolderID="C1" Runat="Server">
<table border="0" cellpadding="0" cellspacing="0" width="99%" align="center">
<tr><td>
<fieldset><legend class="FormHeading">Pending List</legend>
  <script language="javascript" src="../../popcalendar.js" type="text/javascript"></script>

        <table align="center" width="100%">
            <tr>
                <td colspan="7">
                    <asp:Label ID="lblMsg" runat="server" Font-Bold="True" ForeColor="#C00000"></asp:Label></td>
            </tr>
            <tr>
                <td style="height: 34px">
                    <table id="tblPerDtl" border="0" cellpadding="0" cellspacing="0" width="100%">
                        <tr>
                            <td style="width: 111px; height: 38px">
                                Client Name</td>
                        </tr>
                    </table>
                </td>
                <td style="height: 34px">
                </td>
                <td style="height: 34px">
                    <asp:DropDownList ID="ddlclientname" runat="server" SkinID="ddlSkin">
                    </asp:DropDownList></td>
                <td style="height: 34px">
                </td>
                <td style="height: 34px">
                </td>
                <td style="height: 34px">
                </td>
                <td style="height: 34px">
                </td>
            </tr>
            <tr>
                <td >
                    From Date <font color="red"> * </font></td>
                <td >
                    :</td>
                <td >
                  <asp:TextBox ID="txtFromDate" SkinID="txtSkin" runat="server" MaxLength="10" ></asp:TextBox>
                  <img id="imgFromDate"alt="Calendar"  src="../../Images/SmallCalendar.gif" onclick="popUpCalendar(this, document.all.<%=txtFromDate.ClientID%>, 'dd/mm/yyyy', 0, 0);" />[dd/MM/yyyy]
            
                </td>
                <td >
                    To Date <font color="red"> *</font></td>
                <td >
                    :</td>
                <td>
                  <asp:TextBox ID="txtToDate" SkinID="txtSkin" runat="server" CssClass="textbox" MaxLength="10"
                        Text=""></asp:TextBox>
                        <img alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtToDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                                src="../../Images/SmallCalendar.gif"style="width: 19px;" height="16" />[dd/MM/yyyy]
                </td>
                <td>&nbsp;<asp:Button
                        ID="Button1" runat="server" OnClick="Button1_Click" SkinID="btn" Text=" Excel Report" ValidationGroup="grpValidate" /></td>
            </tr>
            <tr>
                <td colspan="7">
                    <span style="color: #ff0033">* </span>Indicate mandatory fields.</td>
            </tr>
            <tr>
                <td colspan="7" style="height: 166px">
                    <asp:GridView ID="grdvpdrp" runat="server">
                    </asp:GridView>
                    <br />
                    &nbsp;<asp:RequiredFieldValidator ID="Rfvddlclient" runat="server" ControlToValidate="ddlclientname"
                        Display="None" ErrorMessage="Please Select Client Name" InitialValue="0" ValidationGroup="grpValidate"></asp:RequiredFieldValidator>
                    <asp:ValidationSummary ID="vsValidate" runat="server" CssClass="compulsary" ShowMessageBox="True"
                        ShowSummary="False" ValidationGroup="grpValidate" />
                    <asp:RequiredFieldValidator ID="rfvFromDate" runat="server" ControlToValidate="txtFromDate"
                        Display="None" ErrorMessage="Please enter From  date." ValidationGroup="grpValidate"></asp:RequiredFieldValidator>
                    <asp:RequiredFieldValidator ID="rfvToDate" runat="server" ControlToValidate="txtToDate"
                        Display="None" ErrorMessage="Please enter To date." ValidationGroup="grpValidate"></asp:RequiredFieldValidator></td>
            </tr>
        </table>

                   
        </fieldset>
        </td></tr></table>
        </asp:Content>
