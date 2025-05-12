<%@ Page Language="C#" MasterPageFile="CC_MasterPage.master" AutoEventWireup="true" CodeFile="CC_DeDupSearch.aspx.cs" Inherits="DeDupeSearch" Theme="SkinFile"%>
<asp:Content ID="Content1" ContentPlaceHolderID="C1" Runat="Server">
<asp:Panel ID="pnlMainFeAssign" runat="server" Visible="true" Width="100%" HorizontalAlign ="Center">
<table border="0" cellspacing="0" cellpadding="0" width="99%" >
          <tr> 
            <td align="center">
                <fieldset><legend  class="FormHeading">Dedup
                              Cases</legend>
                              <table width="100%" border="0" cellspacing="0" cellpadding="1">
                                <tr> 
                                  <td><table width="100%" border="0" align="center" cellpadding="0" cellspacing="1" >
                                            <tr align="left"> 
                                              <td>
                                                  Applicant Name&nbsp;</td>
                                              <td ><font color="#990000"><strong>
                                                  <asp:TextBox ID="txtSearchCust" runat="server" CssClass="textbox" SkinID="txtSkin"></asp:TextBox>&nbsp;
                                                  <asp:DropDownList ID="ddlSearchCust"
                                                  runat="server" CssClass="textbox" SkinID="ddlSkin" >
                                                      <asp:ListItem Value="1">Like</asp:ListItem>
                                                      <asp:ListItem Value="2">Start with</asp:ListItem>
                                                      <asp:ListItem Value="3">Equal</asp:ListItem>
                                                  </asp:DropDownList></strong></font></td>
                                              <td height="23">
                                                  City</td>
                                              <td > <strong><font color="#990000"> 
                                                  <asp:TextBox ID="txtSearchCity" runat="server" CssClass="textbox" SkinID="txtSkin"></asp:TextBox>&nbsp;
                                                  <asp:DropDownList ID="ddlSearchCity"
                                                  runat="server" CssClass="textbox" SkinID="ddlSkin" >
                                                      <asp:ListItem Value="1">Like</asp:ListItem>
                                                      <asp:ListItem Value="2">Start with</asp:ListItem>
                                                      <asp:ListItem Value="3">Equal</asp:ListItem>
                                                  </asp:DropDownList></font></strong></td>
                                            </tr>
                                            <tr align="left">
                                                <td  class="label">
                                                    PIN</td>
                                                <td >
                                                    <asp:TextBox ID="txtSearchPin" runat="server" CssClass="textbox" SkinID="txtSkin"></asp:TextBox>
                                                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                                </td>
                                                <td  class="label" height="23">
                                                    Address</td>
                                                <td >
                                                    <asp:TextBox ID="txtSearchAdd" runat="server" CssClass="textbox" SkinID="txtSkin"></asp:TextBox>&nbsp;
                                                    <asp:DropDownList ID="ddlSearchAdd"
                                                  runat="server" CssClass="textbox" SkinID="ddlSkin">
                                                        <asp:ListItem Value="1">Like</asp:ListItem>
                                                        <asp:ListItem Value="2">Start with</asp:ListItem>
                                                    </asp:DropDownList></td>
                                            </tr>
                                            <tr align="left">
                                                <td  class="label">
                                                </td>
                                                <td >
                                                </td>
                                                <td  class="label" height="23">
                                                </td>
                                                <td >
                                                    <asp:Button
                                                      ID="btnSearch" runat="server" CssClass="button" OnClick="btnSearch_Click" SkinID="btnSearchSkin" /></td>
                                            </tr>
                                          </table></td>
                                </tr>
                                  <tr>
                                      <td align="left" style="height: 15px; width: 940px;">
                                          &nbsp; &nbsp;
                                            <asp:Label CssClass="txtError" ID="lblInitialMsg" runat="server" Text=""></asp:Label>&nbsp;</td>
                                  </tr>
                                <tr> 
                                  <td align="right" >
                                      <asp:Button ID="btnExport" runat="server" CssClass="button" OnClick="btnExport_Click" SkinID="btnExpToExlSkin" /></td>
                                </tr>
                                <tr> 
                                  <td align="left" > <table width="100%" border="0"   cellpadding="0" cellspacing="0"  class="shadow">
                                      <tr> 
                                        <td>
                                            <asp:GridView ID="gvDeDupe" runat="server" AllowSorting="true" AllowPaging="true" AutoGenerateColumns="False"
                                                 DataSourceID="sdsDeDupe" PagerStyle-CssClass="txtLink" PageSize="15" SkinID="gridviewSkin"
                                                Width="100%" CellPadding="2" CellSpacing="1" GridLines="None" OnSorting="gvDeDupe_Sorting">
                                                <Columns>
                                                    <asp:BoundField DataField="FullName" HeaderText="Applicant Name" SortExpression="FIRST_NAME"  >
                                                        <ItemStyle />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="CLIENT_NAME" HeaderText="Client" SortExpression="CLIENT_NAME"  >
                                                        <ItemStyle  />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="RecAddress" HeaderText="Address" SortExpression="RecAddress" >
                                                        <ItemStyle />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="RES_CITY" HeaderText="City" SortExpression="RES_CITY"  >
                                                        <ItemStyle />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="RES_PIN_CODE"  HeaderText="Pin" HtmlEncode="False" SortExpression="RES_PIN_CODE"  >
                                                        <ItemStyle  />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="OffAddress" HeaderText="Office Address" SortExpression="OffAddress" >
                                                        <ItemStyle  />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="OFF_CITY" HeaderText=" Office City" SortExpression="OFF_CITY"  >
                                                        <ItemStyle  />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="OFF_PIN_CODE"  HeaderText="Office Pin" SortExpression="OFF_PIN_CODE"  >
                                                        <ItemStyle  />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="REASON" HeaderText="FE Remark" SortExpression="REASON" >
                                                        <ItemStyle  />
                                                    </asp:BoundField>
<%--                                                <asp:BoundField DataField="SendDate" HeaderText="Send Date" HtmlEncode="False"  DataFormatString="{0:dd-MMM-yyyy}" SortExpression="SendDate" >
                                                        <ItemStyle Width="20%" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="SendTime" HeaderText="Send Time" >
                                                        <ItemStyle Width="20%" />
                                                    </asp:BoundField>--%>
                                                    <asp:BoundField DataField="STATUS_CODE" HeaderText="Status" SortExpression="STATUS_CODE" >
                                                        <ItemStyle  />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="DECLINED_CODE" HeaderText="Decline Code" SortExpression="DECLINED_CODE" >
                                                        <ItemStyle  />
                                                    </asp:BoundField>
                                                </Columns>
                                            </asp:GridView>
                                            <asp:SqlDataSource ID="sdsDeDupe" runat="server" ConnectionString="<%$ ConnectionStrings:CMConnectionString %>" ProviderName="<%$ ConnectionStrings:CMConnectionString.ProviderName %>">
                                            </asp:SqlDataSource>
                                        </td>
                                      </tr>

                                    </table></td>
                                </tr>
                                <tr> 
                                  <td align="right" ><asp:Button id="btnExport1" runat="server" CssClass="button" OnClick="btnExport_Click" SkinID="btnExpToExlSkin"></asp:Button></td>
                                </tr>
                                <tr>
                                  <td align="center" >
                                      &nbsp; &nbsp; &nbsp;
                                  </td>
                                </tr>
                              </table>
                              </fieldset>
            </td>
          </tr>
        </table>
</asp:Panel>
</asp:Content>