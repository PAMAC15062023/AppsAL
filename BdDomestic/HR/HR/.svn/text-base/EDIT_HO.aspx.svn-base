<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EDIT_HO.aspx.cs" Theme="SkinFile"  MasterPageFile="HRMasterPage.master" Inherits="HR_HR_EDIT_HO" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server" >
<script type="text/javascript" language="javascript">
       <!--
       function ClientValidate(source, arguments)
       {
//            alert(arguments.Value);
          if ((arguments.Value) == 0)
             arguments.IsValid=false;
          else
             arguments.IsValid=true;
       }
       // -->
    </script>
        
  <fieldset><legend class="FormHeading">HO Edit Attendance </legend>   
      <table width="100%">
            <tr>
                <td colspan="8">
                    <asp:Label ID="lblMsg" runat="server" SkinID="lblErrorMsg" Visible="False" Font-Bold="True" ForeColor="Red"></asp:Label>
                </td>
            </tr>
          <tr>
              <td align="center" colspan="7">
                  <asp:Label ID="lblHierChichy" runat="server" Font-Bold="True" Font-Size="Medium"
                      ForeColor="#404040" SkinID="lblSkin"></asp:Label></td>
          </tr>
          <tr>
              <td style="width: 91px">
                  Centre:</td>
              <td style="width: 127px"><asp:DropDownList ID="ddlCentre" runat="server" DataSourceID="sdsCentre" DataTextField="centre_name" DataValueField="centre_id" OnDataBound="ddlCentre_DataBound" OnSelectedIndexChanged="ddlCentre_SelectedIndexChanged" SkinID="ddlSkin" AutoPostBack="True" Width="125px">
                  </asp:DropDownList></td>
              <td style="width: 87px">
                  SubCentre:</td>
              <td style="width: 124px"><asp:DropDownList ID="ddlSubCentre" runat="server" DataSourceID="sdsSubCentre" DataTextField="SubCentreName" DataValueField="SubCentreId" SkinID="ddlSkin" OnDataBound="ddlSubCentre_DataBound" ValidationGroup="Valgrp1" Width="125px">
                  </asp:DropDownList></td>
                <td style="width: 25px">
                  Date:</td>
              <td style="width: 211px"><asp:TextBox ID="txtDate" runat="server" SkinID="txtSkin" MaxLength="10" Width="120px"></asp:TextBox><img id="Img2" alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtDate.ClientID%>, 'dd/mm/yyyy', 0, 0);" 
                        src="../../Images/SmallCalendar.gif" />[dd/mm/yyyy]
                  </td>
                  <td>
                      &nbsp;</td>
             </tr>
          <tr>
              <td style="width: 91px">
                  Pamacian Code&nbsp; :</td>
              <td style="width: 127px">
                  <asp:TextBox ID="txtEmpCode" runat="server" MaxLength="15" SkinID="txtSkin"></asp:TextBox></td>
              <td style="width: 87px">
                  Pamacian Name :</td>
              <td style="width: 124px">
                  <asp:TextBox ID="txtEmpName" runat="server" SkinID="txtSkin"></asp:TextBox></td>
              <td style="width: 25px">
              </td>
              <td style="width: 211px">
                  <asp:Button ID="btnShow" runat="server" OnClick="btnShow_Click" SkinID="btn" Text="Show" ValidationGroup="Valgrp" /></td>
              <td>
              </td>
          </tr>
          <tr>
              <td colspan="8" align="left">
                  <asp:Label ID="lblDate" runat="server" Font-Bold="True" Text=""></asp:Label></td>
          </tr>
          <tr>
              <td colspan="8" align="center">
                 <asp:GridView ID="GVDE" runat="server"  SkinID="gridviewSkin" AutoGenerateColumns="False" OnRowDataBound="GVDE_RowDataBound" AllowPaging="True" OnPageIndexChanging="GVDE_PageIndexChanging" PageSize="50">
                      <Columns>
                      <asp:BoundField DataField="Emp Code" HeaderText="Emp Code"  />
                        <asp:BoundField DataField="Centre_Name" HeaderText="Centre Name"  />
                        <asp:BoundField DataField="SubcentreName" HeaderText="Subcentre Name"  />
                      <asp:BoundField DataField="Pamecian" HeaderText="Pamacian"  />
                       <asp:BoundField DataField="DEPARTMENT" HeaderText="Department"  />
                        <asp:BoundField DataField="Designation" HeaderText="Designation"  />
                         <asp:BoundField DataField="Unit" HeaderText="Unit"  />
                          <asp:TemplateField HeaderText="Attendance">
                              <ItemTemplate>
                                  <asp:DropDownList ID="ddl" runat="server" SkinID="ddlSkin">
                                  <asp:ListItem Text="U" Value="U"></asp:ListItem>
                                  <asp:ListItem Text="P" Value="P"></asp:ListItem>
                                  <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                  </asp:DropDownList>
                                  <asp:HiddenField ID="hidEmpID" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "emp_id") %>' />
                              </ItemTemplate>
                          </asp:TemplateField>
                          
                      </Columns>
                  
                  </asp:GridView>
              </td>
          </tr>
          <tr>
              <td align="center" colspan="7">
                  &nbsp;&nbsp;
                  <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" SkinID="btnSaveSkin" ValidationGroup="Valgrp" />
                  &nbsp; &nbsp;
              </td>
          </tr>
      </table>
                <asp:SqlDataSource ID="sdsSubCentre" runat="server" ConnectionString="<%$ ConnectionStrings:CMConnectionString %>"
          ProviderName="<%$ ConnectionStrings:CMConnectionString.ProviderName %>">
          
      </asp:SqlDataSource>
                  <asp:SqlDataSource ID="sdsCentre" runat="server" ConnectionString="<%$ ConnectionStrings:CMConnectionString %>"
                      ProviderName="<%$ ConnectionStrings:CMConnectionString.ProviderName %>" SelectCommand="select  centre_id,centre_name from centre_master ">
                      
                      
                  </asp:SqlDataSource>
                  <asp:RequiredFieldValidator ID="valDate" runat="server" ControlToValidate="txtDate"
                      Display="None" ErrorMessage="Date should not be blank" SetFocusOnError="True"
                      ValidationGroup="Valgrp"></asp:RequiredFieldValidator>
                  <asp:CustomValidator ID="ValSubCentre" runat="server" ControlToValidate="ddlSubCentre"
                      Display="None" ErrorMessage="Please select Centre" SetFocusOnError="True" ValidationGroup="Valgrp" ClientValidationFunction="ClientValidate"></asp:CustomValidator>
                  <asp:ValidationSummary ID="val" runat="server" ShowMessageBox="True" ShowSummary="False"
                      ValidationGroup="Valgrp" />
      &nbsp;&nbsp;
      <asp:RegularExpressionValidator ID="revDate" runat="server" ControlToValidate="txtDate"
        Display="None" ErrorMessage="Please enter valid date format for From Date" SetFocusOnError="True"
        ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d"
        ValidationGroup="Valgrp"></asp:RegularExpressionValidator></asp:Content>
