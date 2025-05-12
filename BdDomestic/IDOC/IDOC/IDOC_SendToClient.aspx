<%@ Page Language="C#" MasterPageFile="IDOC_MasterPage.master" AutoEventWireup="true" Theme="SkinFile" CodeFile="IDOC_SendToClient.aspx.cs" Inherits="IDOC_IDOC_IDOC_SendToClient" %>
<asp:Content ID="Content1" ContentPlaceHolderID="C1" Runat="Server">
 <fieldset><legend class="FormHeading" >Tat Calculation</legend>
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
     
          
            <tr>
            
          
        
          </tr>
             
             
              <tr>
                <td class="label" style="height: 39px">From Date:<span class="txtRed">* </span></td>
                     
                   <%-- <asp:Label ID="lblfromdate" SkinID="lblSkin" runat="server"  Text=" From Date:"></asp:Label></td>--%>
                  
                   <td style="height: 39px" ><asp:TextBox ID="txtfromdate" SkinID="txtSkin" runat="server" MaxLength="10" ValidationGroup="grpsearch" ></asp:TextBox>
                      </td>
               
                   <td style="height: 39px"><table id="fromdatetable" runat="server">
                   <tr>
                   <td> <img alt="Calendar" id="Img1" onclick="popUpCalendar(this, document.all.<%=txtfromdate.ClientID%>, 'dd/mm/yyyy', 0, 0);" src="../../Images/SmallCalendar.gif"/>
                    
                     <asp:Label ID="lblfromdateformate" runat="server" SkinID="lblSkin" Text="[dd/mm/yyyy]" ></asp:Label>
                    </td>
                    </tr></table>
                   </td>
                <%--<td><asp:Label ID="lbltodate" SkinID="lblSkin" runat="server" Text="To Date"></asp:Label></td>--%>
                <td class="label" style="height: 39px">To Date:<span class="txtRed">* </span></td>
                
                <td style="height: 39px" ><asp:TextBox ID="Txttodate1" SkinID="txtSkin"   runat="server" MaxLength="10" ValidationGroup="grpsearch" ></asp:TextBox> </td>
                
               <td style="height: 39px">
                <table id="Table1" runat="server">
                <tr>
                <td>
                    <img alt="Calendar" id="Img4" onclick="popUpCalendar(this, document.all.<%=Txttodate1.ClientID%>, 'dd/mm/yyyy', 0, 0);" src="../../Images/SmallCalendar.gif"/>
                    <asp:Label ID="Label1" runat="server" SkinID="lblSkin" Text="[dd/mm/yyyy]"></asp:Label>
                    </td>
               </tr>
               </table>
               </td>
            
           
                <td style="height: 39px"><asp:Button ID="BtnSearch" runat="server"  SkinID="btnSearchSkin"  OnClick="BtnSearch_Click" Text="Search" ValidationGroup="grpsearch" /></td>
          
           </tr>
            <tr>
                <td colspan="9">
                    <span style="color: #ff0033">* </span>Indicate mandatory fields.</td>
            </tr>
          
         
           <tr>
                <td colspan="9" > <asp:Label ID="lblmessage" runat="server" Width="437px" ForeColor="Red"></asp:Label></td>
           
           </tr>
              
              <tr>
                    <td colspan="9" > <asp:Label ID="lbldatavalidation" runat="server" ForeColor="Red" Width="441px"></asp:Label></td>
              </tr>

          
          <tr>
                <td colspan="9"  > 
                    <asp:GridView ID="gvSearch" runat="server"  SkinID="gridviewSkin" AutoGenerateColumns="False" >
                        <Columns>
                            <asp:BoundField DataField="Ref_no" HeaderText="Ref_no" />
                            <asp:BoundField DataField="Applicant_name" HeaderText="Applicant Name" />
                            <asp:BoundField DataField="Rec_date" HeaderText="Rec Date" />
                        </Columns>
                    </asp:GridView>
                    <asp:GridView ID="gvSendTat" runat="server" SkinID="gridviewSkin"  OnRowDataBound="gvSendTat_RowDataBound" OnSorting="gvSendTat_Sorting" AutoGenerateColumns="False">
                        <Columns>
                            <asp:BoundField DataField="CaseId" HeaderText="CaseId" />
                            <asp:BoundField DataField="REF_NO" HeaderText="REF_NO" />
                            <asp:BoundField DataField="APPLICANT_NAME" HeaderText="APPLICANT_NAME" />
                            <asp:BoundField DataField="REC_DATE" HeaderText="REC_DATE" />
                            <asp:BoundField DataField="TAT_HRS" HeaderText="TAT_HRS" />
                            <asp:TemplateField HeaderText="WITHIN_TAT ">
                                <ItemTemplate>
                                    <asp:CheckBox ID="ChkTAT" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </td>
           </tr>
           
           
           <tr>
                 <td class="label" > <asp:Label ID="lblsenddate" SkinID="lblSkin" runat="server" Text="Send Date" Visible="False"></asp:Label>
                 <label id="dd" visible="false" runat="server"><span class="txtRed" >* </span></label>
                </td>
                
                <td><asp:TextBox ID="txtSendDt" SkinID="txtSkin" runat="server" CssClass="textbox" MaxLength="10"  Visible="False" ValidationGroup="grpSend"></asp:TextBox>
                   </td>
                    
                <td>
                <table id="tblImg" runat="server">
                <tr>
                <td><img id="Img2"  alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtSendDt.ClientID%>, 'dd/mm/yyyy', 0, 0);"src="../../Images/SmallCalendar.gif" />
                    <asp:Label ID="lblsenddatefotmate" runat="server" SkinID="lblSkin" Text="[dd/mm/yyyy]" Visible="False"></asp:Label>
                </td>
                </tr>
                </table>
                </td> 
               
               
                 <td class="label" ><asp:Label ID="lblsendtime" SkinID="lblSkin" runat="server" Text="Send Time " Visible="False"></asp:Label>
                <%--<span class="txtRed"  visible ="false">* </span>--%>
                <label id="ddd" visible="false" runat="server"><span class="txtRed" >* </span></label>
                </td>
               
               
                <td><asp:TextBox ID="txtSendTm" SkinID="txtSkin" runat="server" CssClass="textbox"  Visible="False" ValidationGroup="grpSend" MaxLength="5"></asp:TextBox>
                      <asp:Label ID="lblhourandminformate" runat="server" SkinID="lblSkin" Text="[hh:mm]" Visible="False"></asp:Label>
                </td>
                <td ><asp:DropDownList ID="ddlSendTimeType" SkinID="ddlSkin" runat="server" CssClass="combo" Visible="False">
                    <asp:ListItem>AM</asp:ListItem>
                    <asp:ListItem>PM</asp:ListItem>
                    </asp:DropDownList>
                </td>
               
               
       </tr>
       <tr>
            <td></td>
            <td ></td>
            <td></td>
            <td></td>
            <td ></td>
        <td><asp:Button ID="btnCalcTat"  SkinID="btntatcalskin" runat="server" CssClass="button" Width="100%" OnClick="btnCalcTat_Click" ValidationGroup="grpSend" Visible="False" /></td>
        <td><asp:Button ID="btnSentToClient"  SkinID="btnSendSkin"  runat="server" OnClick="btnSentToClient_Click"  Visible="False" ValidationGroup="grpSend" /></td>
        </tr>
       
       <tr>
                <td><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtSendDt" Display="None" ErrorMessage="Please enter Send Date" SetFocusOnError="True" ValidationGroup="grpSend"></asp:RequiredFieldValidator></td>
               
                <td ><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtSendTm" Display="None" ErrorMessage="Please enter Send Time" SetFocusOnError="True" ValidationGroup="grpSend"></asp:RequiredFieldValidator></td>
               
          
           
                <td><asp:RegularExpressionValidator ID="revDate1" runat="server" ControlToValidate="txtSendDt" Display="None" ErrorMessage="Please enter valid date format for Send Date" SetFocusOnError="True" ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d" ValidationGroup="grpSend"></asp:RegularExpressionValidator></td>
                
                <td><asp:RegularExpressionValidator ID="revTime1" runat="server" ControlToValidate="txtSendTm" Display="None" ErrorMessage="Please enter valid Time Format for Send Time" SetFocusOnError="True" ValidationExpression="(0[1-9]|1[0-2])[:]([0-5][0-9])" ValidationGroup="grpSend"></asp:RegularExpressionValidator></td>
               
                <td  ><asp:ValidationSummary ID="ValidationSummary1" runat="server" DisplayMode="List" ShowMessageBox="True" ShowSummary="False" ValidationGroup="grpSend" /> 
                    <asp:ValidationSummary ID="ValidationSummary2" runat="server" DisplayMode="List"
                        ShowMessageBox="True" ShowSummary="False" ValidationGroup="grpsearch" />
                </td>
                
          </tr>
        </table>
        <asp:RequiredFieldValidator ID="rvvforfromdate" runat="server" ControlToValidate="txtfromdate"
            Display="None" ErrorMessage="Please Enter from date" SetFocusOnError="True" ValidationGroup="grpsearch"></asp:RequiredFieldValidator>
       
       
        <asp:RequiredFieldValidator ID="rfvfortodate" runat="server" ControlToValidate="Txttodate1"
            Display="None" ErrorMessage="Please Enter todate" SetFocusOnError="True" ValidationGroup="grpsearch"></asp:RequiredFieldValidator></fieldset>
   
   
   
   
   <asp:RegularExpressionValidator ID="revFromDate" runat="server" ControlToValidate="txtfromdate"
    Display="None" ErrorMessage="Please enter valid Date Format for From date." SetFocusOnError="True"
    ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d"    
    ValidationGroup="grpsearch"></asp:RegularExpressionValidator>
    
    <asp:RegularExpressionValidator ID="revToDate" runat="server" ControlToValidate="Txttodate1"
    Display="None" ErrorMessage="Please enter valid Date Format for To date." SetFocusOnError="True"
    ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d"    
    ValidationGroup="grpsearch"></asp:RegularExpressionValidator>
    
    
    <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtSendDt"
    Display="None" ErrorMessage="Please enter valid Date Format for To date." SetFocusOnError="True"
    ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[0-2])[- /.](19|20|21)\d\d"    
    ValidationGroup="grpSend"></asp:RegularExpressionValidator>
   --%>
   
   
   
   
   
   
   
</asp:Content>



