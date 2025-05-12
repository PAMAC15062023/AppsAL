<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Pages/MasterPage.master"  CodeFile="application.aspx.cs" Inherits="application" Title="Schedule Entry" %>

 
    <asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script language="javascript" type="text/javascript" src="popcalendar.js">
    </script>
 <script language="javascript" type="text/javascript">
 
 function Compute_Columns()
 {
    var ContentHolder="Ctl00_ContentPlaceHolder1_";      
    var txtTowardAd=document.getElementById(ContentHolder+"txtTowardAd");
    var txtTowStamp=document.getElementById(ContentHolder+"txtTowStamp");
    var txtTowardAdInt=document.getElementById(ContentHolder+"txtTowardAdInt");
    var txtTowardAppli=document.getElementById(ContentHolder+"txtTowardAppli");
    var txtPaidRs=document.getElementById(ContentHolder+"txtPaidRs");        
    
    var SumOf =parseFloat(txtTowardAd.value,10)+parseFloat(txtTowStamp.value,10)+ parseFloat(txtTowardAdInt.value,10)+parseFloat(txtTowardAppli.value,10);
    txtPaidRs.value=SumOf; 
 }
 
 
 </script>
    
     
 <div> 
     <asp:Label ID="lblMess" runat="server" Width="244px" ForeColor="Red" Visible="False"></asp:Label><br />
     <asp:ValidationSummary ID="Valsummery" runat="server" ValidationGroup="BasicEntry" />
     <br />
     <table style="width: 100%">
         <tr>
             
             <td class="TableHeader" colspan="6">
                 &nbsp;Schedule New Entry
                 </td>
         </tr>
         <tr>
             <td class="TableTitle">
                 Application No</td>
             <td style="width: 269px">
         <asp:TextBox ID="txtAppNo" runat="server" Width="161px"></asp:TextBox></td>
             <td class="TableTitle">
         <asp:Button ID="btnRet" runat="server" Text="Retrive" OnClick="btnRet_Click" /></td>
             <td style="width: 100px">
             </td>
             <td style="width: 100px">
             </td>
             <td style="width: 100px">
             </td>
         </tr>
         <tr>
             <td class="TableTitle">
                 Pamac UID &nbsp; &nbsp;&nbsp;</td>
             <td style="width: 269px">
         <asp:TextBox ID="txtPUId" runat="server" Width="161px" ReadOnly="True" ValidationGroup="BasicEntry"></asp:TextBox>
             </td>
             <td style="width: 100px">
                 <asp:RequiredFieldValidator ID="rqPUID" runat="server" ControlToValidate="txtPUId"
                     ErrorMessage="PUID is not entered" ValidationGroup="BasicEntry">?</asp:RequiredFieldValidator></td>
             <td style="width: 100px">
             </td>
             <td style="width: 100px">
             </td>
             <td style="width: 100px">
             </td>
         </tr>
         <tr>
             <td colspan="6">
             </td>
         </tr>
         <tr>
             <td class="TableTitle">
                 Place of execution of Agreement</td>
             <td colspan="2">
         <asp:TextBox ID="txtPlace" runat="server" Width="259px" Font-Size="Small"></asp:TextBox></td>
             <td style="width: 100px">
             </td>
             <td style="width: 100px">
             </td>
             <td style="width: 100px">
             </td>
         </tr>
         <tr>
             <td class="TableTitle">
                 Date of Agreement</td>
             <td style="width: 269px">
                 <asp:TextBox ID="txtAgriDate" runat="server" Width="83px" Font-Size="Small" MaxLength="10"></asp:TextBox>
                 <img id="ImgApplicationDate" alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtAgriDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                     src="SmallCalendar.gif" /></td>
             <td class="TableTitle">
                 &nbsp;(DD/MM/YYYY)</td>
             <td style="width: 100px">
             </td>
             <td style="width: 100px">
             </td>
             <td style="width: 100px">
             </td>
         </tr>
         <tr>
             <td class="TableTitle">
                 Name Of the Borrower</td>
             <td colspan="2">
                 <asp:TextBox ID="txtBorroName" runat="server" Width="258px" Font-Size="Small"></asp:TextBox></td>
             <td style="width: 100px">
             </td>
             <td style="width: 100px">
             </td>
             <td style="width: 100px">
             </td>
         </tr>
         <tr>
             <td class="TableTitle">
                 Date of Birth</td>
             <td style="width: 269px">
                    <asp:TextBox ID="txtBirthDate" runat="server"  
                        Width="107px" Font-Size="Small" MaxLength="10"></asp:TextBox>
                 <img id="Img1" alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtBirthDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                     src="SmallCalendar.gif" /></td>
             <td class="TableTitle">
                 (DD/MM/YYYY)</td>
             <td style="width: 100px">
             </td>
             <td style="width: 100px">
             </td>
             <td style="width: 100px">
             </td>
         </tr>
         <tr>
             <td colspan="6">
             </td>
         </tr>
         <tr>
             <td class="TableHeader" colspan="6" style="height: 18px">
                 Residence Details</td>
         </tr>
         <tr>
             <td class="TableTitle">
                 Residance Address</td>
             <td colspan="3">
            <asp:TextBox ID="txtResiAdd" runat="server" Width="537px" Font-Size="Small"></asp:TextBox></td>
             <td style="width: 100px">
             </td>
             <td style="width: 100px">
             </td>
         </tr>
         <tr>
             <td class="TableTitle">
                 Pincode</td>
             <td style="width: 269px">
            <asp:TextBox ID="txtResiPin" runat="server" Width="142px" Font-Size="Small"></asp:TextBox></td>
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
             <td class="TableTitle">
                 Land Line No</td>
             <td style="width: 269px">
                 <asp:TextBox ID="txtResiTel" runat="server" Width="143px" Font-Size="Small"></asp:TextBox></td>
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
             <td class="TableTitle">
                 Mobile No</td>
             <td style="width: 269px">
                 <asp:TextBox ID="txtMob" runat="server" Width="142px" Font-Size="Small"></asp:TextBox></td>
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
             <td colspan="6">
             </td>
         </tr>
         <tr>
             <td class="TableHeader" colspan="6">
                 Office Details</td>
         </tr>
         <tr>
             <td class="TableTitle">
                 Office Address</td>
             <td colspan="2">
            <asp:TextBox ID="txtOffAdd" runat="server" Width="261px" Font-Size="Small"></asp:TextBox></td>
             <td style="width: 100px">
             </td>
             <td style="width: 100px">
             </td>
             <td style="width: 100px">
             </td>
         </tr>
         <tr>
             <td class="TableTitle" style="height: 26px">
                 Pincode</td>
             <td colspan="2" style="height: 26px">
            <asp:TextBox ID="txtOffPin" runat="server" Width="260px" Font-Size="Small"></asp:TextBox></td>
             <td style="width: 100px; height: 26px">
             </td>
             <td style="width: 100px; height: 26px">
             </td>
             <td style="width: 100px; height: 26px">
             </td>
         </tr>
         <tr>
             <td class="TableTitle">
                 Tel No</td>
             <td colspan="2">
                                <asp:TextBox ID="txtOffTel" runat="server" Width="112px" Font-Size="Small"></asp:TextBox></td>
             <td style="width: 100px">
             </td>
             <td style="width: 100px">
             </td>
             <td style="width: 100px">
             </td>
         </tr>
         <tr>
             <td class="TableTitle">
                 Mobile No</td>
             <td style="width: 269px">
                                <asp:TextBox ID="txtOffMob" runat="server" Width="110px" Font-Size="Small"></asp:TextBox></td>
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
             <td class="TableTitle">
             </td>
             <td style="width: 269px">
             </td>
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
             <td class="TableTitle">
                 Residence Address</td>
             <td style="width: 269px">
                 <asp:DropDownList
             ID="ddlresiAdd" runat="server">
             <asp:ListItem>(Select)</asp:ListItem>
             <asp:ListItem>Owned</asp:ListItem>
             <asp:ListItem>Rented</asp:ListItem>
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
             <td class="TableTitle">
                 Applicant</td>
             <td style="width: 269px">
         <asp:DropDownList ID="ddlAppli" runat="server">
             <asp:ListItem>(Select)</asp:ListItem>
             <asp:ListItem>Borrower</asp:ListItem>
             <asp:ListItem>Individual</asp:ListItem>
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
             <td class="TableTitle">
                 Occupation
             </td>
             <td style="width: 269px">
         <asp:DropDownList ID="ddlOccu" runat="server">
             <asp:ListItem>(Select)</asp:ListItem>
             <asp:ListItem>Salaried</asp:ListItem>
             <asp:ListItem>Self Employed</asp:ListItem>
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
             <td class="TableTitle">
                 Annual Income</td>
             <td style="width: 269px">
                    <asp:TextBox ID="txtAnnInco" runat="server" Width="105px"></asp:TextBox></td>
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
             <td class="TableTitle">
                 No Of Dependants</td>
             <td style="width: 269px">
                 <asp:TextBox ID="txtNoDept" runat="server" Width="106px"></asp:TextBox></td>
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
             <td class="TableTitle">
                 Booking Deposit/Loan Amount Rs</td>
             <td style="width: 269px">
                    <asp:TextBox ID="txtBookDep" runat="server" Width="105px"></asp:TextBox></td>
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
             <td class="TableTitle" style="height: 17px">
                 Vehicle Booking Form No</td>
             <td style="width: 269px; height: 17px">
                    <asp:TextBox ID="txtVehBook" runat="server" Width="106px"></asp:TextBox></td>
             <td style="width: 100px; height: 17px">
             </td>
             <td style="width: 100px; height: 17px">
             </td>
             <td style="width: 100px; height: 17px">
             </td>
             <td style="width: 100px; height: 17px">
             </td>
         </tr>
         <tr>
             <td class="TableHeader" colspan="6">
             </td>
         </tr>
         <tr>
             <td class="TableTitle" colspan="2">
                 Initial payment by the Borrower
             </td>
             <td style="width: 100px">
         <asp:TextBox ID="txtInPay" runat="server" Width="100px">0</asp:TextBox></td>
             <td style="width: 100px">
             </td>
             <td style="width: 100px">
             </td>
             <td style="width: 100px">
             </td>
         </tr>
         <tr>
             <td class="TableTitle" colspan="2">
                 &nbsp;(a) Towards Non-refundable service charges Rs
             </td>
             <td style="width: 100px">
         <asp:TextBox ID="txtTowardAd" runat="server" Width="100px">1000.00</asp:TextBox></td>
             <td style="width: 100px">
             </td>
             <td style="width: 100px">
             </td>
             <td style="width: 100px">
             </td>
         </tr>
         <tr>
             <td class="TableTitle" colspan="2" style="height: 26px">
                 &nbsp;(b) Towards Stamping Expenses Rs.</td>
             <td style="width: 100px; height: 26px">
         <asp:TextBox ID="txtTowStamp" runat="server" Width="100px">0</asp:TextBox></td>
             <td style="width: 100px; height: 26px">
             </td>
             <td style="width: 100px; height: 26px">
             </td>
             <td style="width: 100px; height: 26px">
             </td>
         </tr>
         <tr>
             <td class="TableTitle" colspan="2">
                 &nbsp;(c) Towards Advance interest Rs</td>
             <td style="width: 100px">
         <asp:TextBox ID="txtTowardAdInt" runat="server" Width="100px">0</asp:TextBox></td>
             <td style="width: 100px">
             </td>
             <td style="width: 100px">
             </td>
             <td style="width: 100px">
             </td>
         </tr>
         <tr>
             <td class="TableTitle" colspan="2">
                 &nbsp;(d) Towards Application form charges Rs</td>
             <td style="width: 100px">
                 <asp:TextBox ID="txtTowardAppli" runat="server" Width="100px">300.00</asp:TextBox></td>
             <td style="width: 100px">
             </td>
             <td style="width: 100px">
             </td>
             <td style="width: 100px">
             </td>
         </tr>
         <tr>
             <td class="TableHeader" colspan="6" style="height: 17px">
             </td>
         </tr>
         <tr>
             <td class="TableTitle">
                 Paid vide DD/PO No.</td>
             <td>
         <asp:TextBox ID="txtPaidVaid" runat="server" Width="161px"></asp:TextBox></td>
             <td class="TableTitle">
                 Dated</td>
             <td style="width: 100px; height: 17px">
         <asp:TextBox ID="txtPaiddate" runat="server" Width="102px"></asp:TextBox>
                 <img id="Img2" alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtPaiddate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                     src="SmallCalendar.gif" />
                 <br />
                 dd-mm-yyyy</td>
             <td class="TableTitle">
                 For Rs.</td>
             <td style="width: 100px; height: 17px">
         <asp:TextBox ID="txtPaidRs" runat="server" Width="161px">0</asp:TextBox></td>
         </tr>
         <tr>
             <td class="TableTitle" colspan="3">
                 Last date of booking and payment of the dues mentioned in the Item No.14</td>
             <td style="width: 100px; height: 17px">
         <asp:TextBox ID="txtLastBook" runat="server" Width="105px"></asp:TextBox>
                 <img id="Img3" alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtLastBook.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                     src="SmallCalendar.gif" />&nbsp;<br />
                 DD-MM-YYYY</td>
             <td style="width: 100px; height: 17px">
             </td>
             <td style="width: 100px; height: 17px">
             </td>
         </tr>
         <tr>
             <td class="TableTitle" colspan="3">
                 Period of the Loan 90Days commencing fro the date specified in the Item No.15</td>
             <td style="width: 100px; height: 17px">
         <asp:TextBox ID="txtPeriodLoan" runat="server" Width="142px"></asp:TextBox></td>
             <td style="width: 100px; height: 17px">
             </td>
             <td style="width: 100px; height: 17px">
             </td>
         </tr>
         <tr>
             <td class="TableTitle" colspan="3">
                 Rate of Interest Payable 11% per annum</td>
             <td style="width: 100px; height: 17px">
         <asp:TextBox ID="txtRateInt" runat="server" Width="24px" Visible="False"></asp:TextBox></td>
             <td style="width: 100px; height: 17px">
             </td>
             <td style="width: 100px; height: 17px">
             </td>
         </tr>
         <tr>
             <td class="TableTitle" style="height: 17px">
                 Vehicle Model</td>
             <td style="width: 269px; height: 17px">
         <asp:DropDownList ID="ddlVehMod" runat="server" Width="167px">
             <asp:ListItem>(Select)</asp:ListItem>
             <asp:ListItem>NANO BS 2</asp:ListItem>
             <asp:ListItem>NANO BS 3</asp:ListItem>
             <asp:ListItem>NANO CX BS 2</asp:ListItem>
             <asp:ListItem>NANO CX BS 3</asp:ListItem>
             <asp:ListItem>NANO LX BS 3</asp:ListItem>
         </asp:DropDownList></td>
             <td style="width: 100px; height: 17px">
                 <asp:RequiredFieldValidator ID="RqVehicleModel" runat="server" ControlToValidate="ddlVehMod"
                     ErrorMessage="Vehicle Model Not Selected!" InitialValue="(Select)" ValidationGroup="BasicEntry">?</asp:RequiredFieldValidator></td>
             <td style="width: 100px; height: 17px">
             </td>
             <td style="width: 100px; height: 17px">
             </td>
             <td style="width: 100px; height: 17px">
             </td>
         </tr>
         <tr>
             <td class="TableTitle" style="height: 17px">
                 &nbsp;Present Vehicle</td>
             <td style="width: 269px; height: 17px">
         <asp:DropDownList ID="ddlPreVeh" runat="server" Width="167px">
             <asp:ListItem>(Select)</asp:ListItem>
             <asp:ListItem>Two Wheeler</asp:ListItem>
             <asp:ListItem>Four Wheeler</asp:ListItem>
         </asp:DropDownList></td>
             <td style="width: 100px; height: 17px">
             </td>
             <td style="width: 100px; height: 17px">
             </td>
             <td style="width: 100px; height: 17px">
             </td>
             <td style="width: 100px; height: 17px">
             </td>
         </tr>
         <tr>
             <td class="TableTitle">
                 LanLine Phone</td>
             <td style="width: 269px; height: 17px">
                 <asp:DropDownList ID="ddlLandTele" runat="server" Width="167px">
             <asp:ListItem>(Select)</asp:ListItem>
             <asp:ListItem>Yes</asp:ListItem>
             <asp:ListItem>No</asp:ListItem>
         </asp:DropDownList></td>
             <td style="width: 100px; height: 17px">
                 <asp:RequiredFieldValidator ID="RqLandLinePhoneYESNO" runat="server" ControlToValidate="ddlLandTele"
                     ErrorMessage="LandLine Phone!" InitialValue="(Select)" ValidationGroup="BasicEntry">?</asp:RequiredFieldValidator></td>
             <td style="width: 100px; height: 17px">
             </td>
             <td style="width: 100px; height: 17px">
             </td>
             <td style="width: 100px; height: 17px">
             </td>
         </tr>
         <tr>
             <td style="height: 17px">
             </td>
             <td style="width: 269px; height: 17px">
             </td>
             <td style="width: 100px; height: 17px">
             </td>
             <td style="width: 100px; height: 17px">
             </td>
             <td style="width: 100px; height: 17px">
             </td>
             <td style="width: 100px; height: 17px">
             </td>
         </tr>
         <tr>
             <td class="TableHeader" colspan="6" style="height: 17px">
                 &nbsp;<asp:Button ID="BtnSave1" runat="server" Text="Save" Width="56px" OnClick="BtnSave1_Click" ValidationGroup="BasicEntry" />
     <asp:Button ID="btnClear1" runat="server" Text="Clear" Width="50px" />
                 <asp:Button ID="btnClose" runat="server" OnClick="btnClose_Click" Text="Close" /></td>
         </tr>
         <tr>
             <td colspan="2" style="height: 17px">
                 &nbsp;</td>
             <td style="width: 100px; height: 17px">
             </td>
             <td style="width: 100px; height: 17px">
             </td>
             <td style="width: 100px; height: 17px">
             </td>
             <td style="width: 100px; height: 17px">
             </td>
         </tr>
     </table>
     <br />
     &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
     &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
     &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
     &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
 </div>
    </asp:Content>