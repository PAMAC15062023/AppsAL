<%@ Page Language="C#" MasterPageFile="~/CPV/CC/CC_MasterPage.master" AutoEventWireup="true" Theme="SkinFile" CodeFile="CC_SMSGeneration.aspx.cs" Inherits="CC_CC_SMSGeneration"%>
<asp:Content ID="Content1" ContentPlaceHolderID="C1" Runat="Server">
<fieldset ><legend class="FormHeading" >SMS Generation</legend>

<table border="0" cellpadding="1" cellspacing="0" width="100%" id="TABLE1">
   
   
    <tr>
         <td >Ref No</td>
         <td>:</td>
        <td><asp:TextBox ID="txtRefNo" runat="server" MaxLength="50" SkinID="txtSkin" ></asp:TextBox></td>
        <td>Name</td>
        <td>:</td>
        <td><asp:TextBox ID="txtName" runat="server" MaxLength="50" SkinID="txtSkin" ></asp:TextBox></td> 
       <td><asp:CheckBox ID="chkName" runat="server" SkinID="chkSkin" Text="Absolute" /> </td>
   </tr>   
 
 
  
  <tr>
        <td>From Date</td>
         <td>:</td>
         <td><asp:TextBox ID="txtFromDate" runat="server" MaxLength="12" SkinID="txtSkin" ></asp:TextBox> <img id="imgRecDate"  alt="Calendar" src="../../Images/SmallCalendar.gif" onclick="popUpCalendar(this, document.all.<%=txtFromDate.ClientID%>, 'dd-mmm-yyyy', 0, 0);" /></td>
         <td>ToDate</td>
         <td>:</td>
         <td><asp:TextBox ID="txtToDate" runat="server" MaxLength="12" SkinID="txtSkin"></asp:TextBox><img id="Img1"  alt="Calendar" src="../../Images/SmallCalendar.gif" onclick="popUpCalendar(this, document.all.<%=txtToDate.ClientID%>, 'dd-mmm-yyyy', 0, 0);" /></td>
         
         <td><asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" ValidationGroup="grpValidate" SkinID="btn" /></td>
  
  
  </tr>                           

 
  
 <tr>
      <td colspan="7"><asp:Label ID="lblMsg" SkinID="lblSkin" runat="server" meta:resourcekey="lblMsgResource1"></asp:Label></td>
 </tr>


<tr  >
      <td colspan="7">
                 <asp:GridView ID="gvCreditCard" SkinId="gridviewSkin"  AllowSorting="True" AllowPaging="True" PageSize="15" DataSourceID="sdsCreditCard" runat="server" AutoGenerateColumns="False" Height="10px" >
                  <Columns>
                      <asp:BoundField ReadOnly="True" DataField="Case_ID" HeaderText="Case_ID" Visible="False"  />
                      <asp:BoundField ReadOnly="True" DataField="Ref_No" HeaderText="Ref No" SortExpression="Ref_No" />
                      <asp:BoundField ReadOnly="True" DataField="Name" HeaderText="Applicant Name" SortExpression="Name"  />
                      <asp:BoundField ReadOnly="True" DataField="Address" HeaderText="Address" SortExpression="Address"  />
                      <asp:BoundField ReadOnly="True" DataField="Case_Rec_DateTime" SortExpression="Case_Rec_DateTime" HeaderText="Received DateTime" HtmlEncode="False" DataFormatString="{0:dd-MMM-yyyy hh:mm tt}" />
                      <asp:BoundField ReadOnly="True" DataField="Mobile" HeaderText="Mobile No." SortExpression="Mobile"  />
                      <asp:TemplateField HeaderText="SMS Content" SortExpression="SMSContent">
                      <ItemTemplate>
                      <asp:TextBox ID="txtSMSContent" runat="server" TextMode="MultiLine"  MaxLength="300" SkinID="txtSkin" Text='<%# Eval("SMSContent") %>'>
                      </asp:TextBox>
                      </ItemTemplate>
                      </asp:TemplateField>
                      <asp:TemplateField HeaderText="Select"> 
                        <ItemTemplate>
                            <asp:CheckBox ID="chkSelect" runat="server" />
                        </ItemTemplate>
                        <ItemStyle Width="20px" />
                    </asp:TemplateField>
                    </Columns>   
                  </asp:GridView>
        </td>
       
  </tr>
  
  
   <tr>
      <td colspan="6" align="center"><asp:Button ID="btnSend" runat="server" Text="Send"  ValidationGroup="grpValidate" OnClick="btnSend_Click" SkinID="btn" /></td>
   </tr>

   <tr>
            
       <td colspan="7">
                <asp:SqlDataSource ID="sdsCreditCard" runat="server" ProviderName="<%$ ConnectionStrings:CMConnectionString.ProviderName %>" SelectCommand="SELECT CASE_ID, REF_NO, CASE_REC_DATETIME, TITLE, MOBILE, FIRST_NAME + ' ' + MIDDLE_NAME + ' ' + LAST_NAME AS NAME, FULL_NAME + ' ' + RES_ADD_LINE_1 + ' ' + RES_ADD_LINE_2 + ' ' + RES_ADD_LINE_3 + ' ' + RES_LAND_MARK + ' ' + RES_CITY + ' ' + RES_PIN_CODE AS SMSContent, DOB, RES_ADD_LINE_1 + ' ' + RES_ADD_LINE_2 + ' ' + RES_ADD_LINE_3 + ' ' + RES_LAND_MARK + ' ' + RES_CITY + ' ' + RES_PIN_CODE AS Address, RES_PHONE, OFF_ADD_LINE_1, OFF_ADD_LINE_2, OFF_ADD_LINE_3, OFF_CITY, OFF_PIN_CODE, OFF_PHONE, OFF_EXTN, DESIGNATION, DEPARTMENT FROM CPV_CC_CASE_DETAILS" ConnectionString="<%$ ConnectionStrings:CMConnectionString %>"> </asp:SqlDataSource>
                <asp:RegularExpressionValidator ID="revFromDate" runat="server" ControlToValidate="txtFromDate" Display="None" ErrorMessage="Please enter valid Date Format for From Date." SetFocusOnError="True" ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.]([A-Za-z]{3})[- /.](19|20|21)\d\d" ValidationGroup="grpValidate" > </asp:RegularExpressionValidator>
                <asp:RegularExpressionValidator ID="revToDate" runat="server" ControlToValidate="txtToDate" Display="None" ErrorMessage="Please enter valid Date Format for To Date." SetFocusOnError="True" ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.]([A-Za-z]{3})[- /.](19|20|21)\d\d" ValidationGroup="grpValidate" ></asp:RegularExpressionValidator>
           
            </td>
       
            
   </tr>



</table>
   
</fieldset>    
</asp:Content>


