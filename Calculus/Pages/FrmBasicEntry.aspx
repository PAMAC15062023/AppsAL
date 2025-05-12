<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Pages/MasterPage.master"
    CodeFile="FrmBasicEntry.aspx.cs" Inherits="_Default" Title="Application Entry" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="javascript" src="popcalendar.js">
    </script>

    <script language="javascript" type="text/javascript">

    function Enabled_ImagePosition_Refresh(HeightPos) 
    {
    
        //debugger;
            var pnlHeader=document.getElementById("<%=pnlHeader.ClientID%>");
            var pnlDetails=document.getElementById("<%=pnlDetails.ClientID%>");
            pnlHeader.scrollTop= (pnlHeader.scrollHeight*HeightPos)/100; 
            pnlDetails.scrollTop= (pnlDetails.scrollHeight*(HeightPos-12))/100; 
        
           
        }




    var zoomfactor=0.10 //Enter factor (0.05=5%)
   
    function zoomhelper()
    {
        
        if (parseInt(whatcache.style.width)>10&&parseInt(whatcache.style.height)>10)
        {
        whatcache.style.width=parseInt(whatcache.style.width)+parseInt(whatcache.style.width)*zoomfactor*prefix
        whatcache.style.height=parseInt(whatcache.style.height)+parseInt(whatcache.style.height)*zoomfactor*prefix
        }
}

function zoom(originalW, originalH, what, state)
{
    //debugger;
    if (!document.all&&!document.getElementById)
    return
    whatcache=eval("document.images."+what)
    prefix=(state=="in")? 1 : -1
    
    if (whatcache.style.width==""||state=="restore")
    {
        whatcache.style.width=originalW+"px"
        whatcache.style.height=originalH+"px"
      if (state=="restore")
      return
     }
else
    {
        zoomhelper()
    }
    beginzoom=setInterval("zoomhelper()",100)
}

function clearzoom()
{
    
    if (window.beginzoom)
    clearInterval(beginzoom)
}

 
        
        function Validate_PanNo_Form60601()
        {
       // debugger;
       var message="";
       var returnValue=true;
        
        var ContentHolder='';//"Ctl00_ContentPlaceHolder1_";
        var txtPanNo=document.getElementById("<%=txtPanNo.ClientID%>");
        var valSummery=document.getElementById("<%=valSummery.ClientID%>");
        var ddlForm60601=document.getElementById("<%=ddlForm60601.ClientID%>") ;
        
        if (txtPanNo.value=="")
            {
            if (ddlForm60601.value=="(Select)")
            {
             alert("If you do not have a PAN number please select any of one Form60 or Form61!");
            message="If you do not have a PAN number please select any of one Form60 or Form61!";
            returnValue=false;
            }       
         }
         if (message!="")
            {
            valSummery.innerHTML=message;
            valSummery.ValidationGroup="ApplicationBasic";
            valSummery.style.visibility="visible";
            }
         return returnValue;
         
      
      }
      
        function HideControl(dropdownName,txtboxName,dropdownvalue)
        {
        
       // debugger; 
         
        //var ContentHolder="Ctl00_ContentPlaceHolder1_";
        var ContentHolder="";      
        var dropdown=document.getElementById(ContentHolder+dropdownName);
        var txtbox=document.getElementById(ContentHolder+txtboxName);                     
          if (dropdown.value==dropdownvalue)
          {
               txtbox.style.visibility="visible"; //VISIBILITY: hidden        
          }
          else
          {
           txtbox.style.visibility="hidden";
           txtbox.value=""; //VISIBILITY: hidden                
          }  
          

        }

    </script>

    <a href="#" onmouseover="zoom(99,100,'ctl00_ContentPlaceHolder1_imgScan','in')" onmouseout="clearzoom()">
        Zoom In</a> | <a href="#" onmouseover="zoom(970,1083,'ctl00_ContentPlaceHolder1_imgScan','restore')">
            Normal</a> | <a href="#" onmouseover="zoom(120,60,'ctl00_ContentPlaceHolder1_imgScan','out')"
                onmouseout="clearzoom()">Zoom Out</a>
    <div style="position: relative; width: 99; height: 100; left: 0px; top: 0px;">
    </div>
    &nbsp<asp:FileUpload ID="FileUpload1" runat="server" />
    <asp:Button ID="btnUpload" runat="server" Text="Upload" Width="77px" OnClick="btnUpload_Click"
        Height="21px" />
    <asp:Panel ID="pnlHeader" runat="server" Height="200px" ScrollBars="Auto" Width="100%">
        <table style="width: 100%; height: 100%">
            <tr>
                <td style="width: 21px; height: 15px;">
                </td>
                <td style="width: 100px; height: 15px;">
                </td>
                <td style="width: 63px; height: 15px;">
                </td>
            </tr>
            <tr>
                <td style="width: 21px">
                </td>
                <td style="width: 100px">
                    <asp:Image ID="imgScan" runat="server" Width="920px" /></td>
                <td style="width: 63px">
                </td>
            </tr>
            <tr>
                <td style="width: 21px">
                </td>
                <td style="width: 100px">
                </td>
                <td style="width: 63px">
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="pnlDetails" runat="server" Height="400px" ScrollBars="Vertical">
        <table cellpadding="2" cellspacing="2" border="0" class="Table" id="TABLE1">
            <tr>
                <td colspan="6" style="height: 22px">
                    <asp:Label ID="lblMessage" runat="server" Visible="False" Width="100%"></asp:Label><br />
                    <asp:ValidationSummary ID="valSummery" runat="server" ValidationGroup="ApplicationBasic" />
                </td>
            </tr>
            <tr>
                <td class="TableHeader" colspan="6">
                    <strong>Personal Deatails(Refer section 1 of T&amp;C)</strong></td>
            </tr>
            <tr>
                <td style="width: 128px" class="TableTitle">
                    Application No</td>
                <td>
                    <asp:TextBox ID="txtNanoApplicationNo" runat="server" Font-Size="Small" Width="185px"
                        ValidationGroup="ApplicationChecK" CssClass="TEXTBOX"></asp:TextBox>&nbsp;<br />
                    <asp:LinkButton ID="lnkApplicationExists" runat="server" OnClick="lnkApplicationExists_Click"
                        ToolTip="Check for Aleady Exist" ValidationGroup="ApplicationChecK">Duplication Check</asp:LinkButton></td>
                <td style="width: 229px; color: #000000;">
                    <asp:RequiredFieldValidator ID="rq_ApplicationNo" runat="server" ControlToValidate="txtNanoApplicationNo"
                        ErrorMessage="ApplicationNot No enterd" Font-Bold="True" SetFocusOnError="True"
                        ValidationGroup="ApplicationChecK" Width="227px">?</asp:RequiredFieldValidator></td>
                <td style="width: 100px">
                    <asp:HiddenField ID="Hdn_puid" runat="server" />
                </td>
                <td style="width: 100px">
                </td>
                <td style="width: 100px">
                </td>
            </tr>
            <tr>
                <td class="TableTitle" style="width: 128px; height: 28px;">
                    Application Date</td>
                <td style="height: 28px">
                    <asp:TextBox ID="txtApplicationDate" runat="server" Font-Size="Small" ValidationGroup="ApplicationChecK"
                        Width="119px"></asp:TextBox>
                    <img id="ImgApplicationDate" alt="Calendar" src="SmallCalendar.gif" onclick="popUpCalendar(this, document.all.<%=txtApplicationDate.ClientID%>, 'dd/mm/yyyy', 0, 0);" /></td>
                <td style="width: 229px; height: 28px;">
                    <asp:RequiredFieldValidator ID="rq_ApplicationDate" runat="server" ControlToValidate="txtApplicationDate"
                        ErrorMessage="Application Date not Entered!" Font-Bold="True" SetFocusOnError="True"
                        ValidationGroup="ApplicationBasic" Width="13px">?</asp:RequiredFieldValidator></td>
                <td style="width: 100px; height: 28px;">
                </td>
                <td style="width: 100px; height: 28px;">
                </td>
                <td style="width: 100px; height: 28px;">
                </td>
            </tr>
            <tr>
                <td colspan="6">
                </td>
            </tr>
            <tr>
                <td colspan="6" class="TableTitle">
                    <strong><span style="background-color: #faebd7">Name of the Applicant in whose name
                        booking is being done </span></strong>:</td>
            </tr>
            <tr>
                <td style="width: 128px; height: 41px;">
                    <asp:DropDownList ID="ddlSalutation" runat="server" Width="58px" Font-Size="Small">
                        <asp:ListItem>Mr.</asp:ListItem>
                        <asp:ListItem>Mrs.</asp:ListItem>
                        <asp:ListItem>Ms.</asp:ListItem>
                        <asp:ListItem>Messrs.</asp:ListItem>
                    </asp:DropDownList></td>
                <td style="height: 41px">
                    <asp:TextBox ID="txtLastName" runat="server" Width="190px" Font-Size="Small" CssClass="TEXTBOX"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rq_LastName" runat="server" ControlToValidate="txtLastName"
                        ErrorMessage="LastName not Entered" SetFocusOnError="True" ValidationGroup="ApplicationBasic">?</asp:RequiredFieldValidator></td>
                <td style="width: 229px; height: 41px;">
                    <asp:TextBox ID="txtMiddleName" runat="server" Width="199px" Font-Size="Small" CssClass="TEXTBOX"></asp:TextBox>
                </td>
                <td style="width: 100px; height: 41px;">
                    <asp:TextBox ID="txtFirstName" runat="server" Width="200px" Font-Size="Small" CssClass="TEXTBOX"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RetxtFirstName" runat="server" ControlToValidate="txtFirstName"
                        ErrorMessage="FirstName not Ented" SetFocusOnError="True" ValidationGroup="ApplicationBasic">?</asp:RequiredFieldValidator></td>
                <td style="width: 100px; height: 41px;">
                </td>
                <td style="width: 100px; height: 41px;">
                </td>
            </tr>
            <tr>
                <td style="width: 128px; height: 13px;" class="TableTitle">
                    &nbsp;Salutation</td>
                <td class="TableTitle" style="height: 13px">
                    Last Name</td>
                <td style="height: 13px; width: 229px;" class="TableTitle">
                    Middle Name</td>
                <td style="width: 100px; height: 13px;" class="TableTitle">
                    &nbsp; First Name</td>
                <td style="width: 100px; height: 13px;" class="TableTitle">
                </td>
                <td style="width: 100px; height: 13px;" class="TableTitle">
                </td>
            </tr>
            <tr>
                <td style="height: 15px;" colspan="6">
                </td>
            </tr>
            <tr>
                <td class="TableTitle" style="width: 128px">
                    Applicant Category</td>
                <td style="height: 15px">
                    <asp:DropDownList ID="ddlApplicant_CategoryList" runat="server" Font-Size="Small">
                        <asp:ListItem>(Select)</asp:ListItem>
                        <asp:ListItem>Individual</asp:ListItem>
                        <asp:ListItem>Public Ltd Co.</asp:ListItem>
                        <asp:ListItem>Partnership Co.</asp:ListItem>
                        <asp:ListItem>Govt Dept.</asp:ListItem>
                        <asp:ListItem>Private Ltd Co.</asp:ListItem>
                        <asp:ListItem>Prop Business</asp:ListItem>
                        <asp:ListItem>Other</asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RqddlApplicant_CategoryList" runat="server" ControlToValidate="ddlApplicant_CategoryList"
                        ErrorMessage="Applicant Ctegory No Selected" InitialValue="(Select)" SetFocusOnError="True"
                        ValidationGroup="ApplicationBasic">?</asp:RequiredFieldValidator></td>
                <td style="height: 15px; width: 229px; color: #000000;" class="TableTitle">
                    If Other(Plz specify) :</td>
                <td style="width: 100px; height: 15px">
                    <asp:TextBox ID="txtApplicantCategory" runat="server" Font-Size="Small" Width="187px"
                        CssClass="TEXTBOX"></asp:TextBox></td>
                <td style="width: 100px; height: 15px">
                </td>
                <td style="width: 100px; height: 15px">
                </td>
            </tr>
            <tr>
                <td style="width: 128px; height: 15px" class="TableTitle">
                    Gender</td>
                <td style="height: 15px">
                    <asp:DropDownList ID="ddlGender" runat="server" Font-Size="Small">
                        <asp:ListItem>(Select)</asp:ListItem>
                        <asp:ListItem>Male</asp:ListItem>
                        <asp:ListItem>Female</asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rqGender" runat="server" ControlToValidate="ddlGender"
                        ErrorMessage="Gender Not Selected" InitialValue="(Select)" SetFocusOnError="True"
                        ValidationGroup="ApplicationBasic">?</asp:RequiredFieldValidator></td>
                <td style="height: 15px; width: 229px;" class="TableTitle">
                    Date of Birth(DD/MM/YYYY)</td>
                <td style="width: 100px; height: 15px">
                    <asp:TextBox ID="txtDateOfBirth" runat="server" Font-Size="Small" MaxLength="10"
                        CssClass="TEXTBOX"></asp:TextBox>
                    <img id="ImgDOB1" alt="Calendar" src="SmallCalendar.gif" onclick="popUpCalendar(this, document.all.<%=txtDateOfBirth.ClientID%>, 'dd/mm/yyyy', 0, 0);" />
                </td>
                <td style="width: 100px; height: 15px">
                </td>
                <td style="width: 100px; height: 15px">
                </td>
            </tr>
            <tr>
                <td style="height: 17px; width: 128px;" class="TableTitle">
                    Pan Number
                </td>
                <td style="height: 17px">
                    &nbsp;<asp:TextBox ID="txtPanNo" runat="server" Font-Size="Small" CssClass="TEXTBOX"></asp:TextBox></td>
                <td style="height: 17px; width: 229px;">
                </td>
                <td style="width: 100px; height: 17px">
                </td>
                <td style="width: 100px; height: 17px">
                </td>
                <td style="width: 100px; height: 17px">
                </td>
            </tr>
            <tr>
                <td colspan="3" class="TableTitle">
                    If you do not have a PAN number please attach one of these and click here :</td>
                <td style="width: 100px;">
                    <asp:DropDownList ID="ddlForm60601" runat="server" Font-Size="Small">
                        <asp:ListItem>(Select)</asp:ListItem>
                        <asp:ListItem>Form 60</asp:ListItem>
                        <asp:ListItem>Form 61</asp:ListItem>
                    </asp:DropDownList></td>
                <td style="width: 100px;">
                </td>
                <td style="width: 100px;">
                </td>
            </tr>
            <tr>
                <td style="height: 17px; width: 128px;" class="TableTitle">
                    Address Line 1
                </td>
                <td colspan="3" style="height: 17px">
                    <asp:TextBox ID="txtAdd1" runat="server" Width="458px" Font-Size="Small" CssClass="TEXTBOX"></asp:TextBox></td>
                <td style="width: 100px; height: 17px">
                </td>
                <td style="width: 100px; height: 17px">
                </td>
            </tr>
            <tr>
                <td style="height: 17px; width: 128px;" class="TableTitle">
                    Address Line 2</td>
                <td colspan="3" style="height: 17px">
                    <asp:TextBox ID="txtAdd2" runat="server" Width="458px" Font-Size="Small" CssClass="TEXTBOX"></asp:TextBox></td>
                <td style="width: 100px; height: 17px">
                </td>
                <td style="width: 100px; height: 17px">
                </td>
            </tr>
            <tr>
                <td class="TableTitle" style="width: 128px">
                    City</td>
                <td>
                    <asp:TextBox ID="txtApplicantCity" runat="server" Font-Size="Small" CssClass="TEXTBOX"></asp:TextBox></td>
                <td style="width: 229px;" class="TableTitle">
                    District</td>
                <td style="width: 100px;">
                    <asp:TextBox ID="txtApplicantDistrict" runat="server" Font-Size="Small" CssClass="TEXTBOX"></asp:TextBox></td>
                <td style="width: 100px;">
                </td>
                <td style="width: 100px;">
                </td>
            </tr>
            <tr>
                <td style="height: 17px; width: 128px;" class="TableTitle">
                    State</td>
                <td style="height: 17px">
                    <asp:TextBox ID="txtApplicantState" runat="server" Font-Size="Small" CssClass="TEXTBOX"></asp:TextBox></td>
                <td style="height: 17px; width: 229px;" class="TableTitle">
                    PinCode</td>
                <td style="width: 100px; height: 17px">
                    <asp:TextBox ID="txtApplicantPincode" runat="server" Font-Size="Small" MaxLength="6"
                        Width="160px" CssClass="TEXTBOX"></asp:TextBox></td>
                <td style="width: 100px; height: 17px">
                </td>
                <td style="width: 100px; height: 17px">
                </td>
            </tr>
            <tr>
                <td class="TableTitle" style="height: 17px; width: 128px;">
                    MobileNo
                </td>
                <td style="height: 17px">
                    <asp:TextBox ID="txtApplicantLandLineNo" runat="server" Font-Size="Small" Width="159px"
                        MaxLength="15" CssClass="TEXTBOX"></asp:TextBox>
                    <asp:RangeValidator ID="rnResiNo" runat="server" ControlToValidate="txtApplicantLandLineNo"
                        ErrorMessage="Resi No Wrong Entered" MaximumValue="999999999999999" MinimumValue="000000000000000"
                        Type="Double" ValidationGroup="ApplicationBasic">?</asp:RangeValidator></td>
                <td class="TableTitle" style="width: 229px; height: 17px">
                    LandLine (STD Code - Telephone Number)</td>
                <td>
                    <asp:TextBox ID="txtApplicantMobNo" runat="server" Font-Size="Small" MaxLength="12"
                        CssClass="TEXTBOX"></asp:TextBox>
                    <asp:RangeValidator ID="rnMobNo" runat="server" ControlToValidate="txtApplicantMobNo"
                        ErrorMessage="Mob No Wrong Entered" MaximumValue="999999999999" MinimumValue="000000000000"
                        Type="Double" ValidationGroup="ApplicationBasic">?</asp:RangeValidator></td>
                <td style="width: 100px; height: 17px">
                </td>
                <td style="width: 100px; height: 17px">
                </td>
            </tr>
            <tr>
                <td style="height: 17px; width: 128px;" class="TableTitle">
                    Email Id(Optional)</td>
                <td colspan="3" style="height: 17px">
                    <asp:TextBox ID="txtEmailId" runat="server" Font-Size="Small" Width="461px"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RExEmailId" runat="server" ControlToValidate="txtEmailId"
                        ErrorMessage="Wrong EmaiId Entered" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                        ValidationGroup="ApplicationBasic">?</asp:RegularExpressionValidator></td>
                <td style="width: 100px; height: 17px">
                </td>
                <td style="width: 100px; height: 17px">
                </td>
            </tr>
            <tr>
                <td colspan="6" style="height: 20px">
                </td>
            </tr>
            <tr>
                <td class="TableHeader" colspan="6" style="height: 20px">
                    Branch Source Details</td>
            </tr>
            <tr>
                <td class="TableTitle" style="width: 128px">
                    &nbsp;Source Branch</td>
                <td>
                    <asp:DropDownList ID="ddlSourceBranch" runat="server" Font-Size="Small">
                        <asp:ListItem>(Select)</asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RqSourchBranch" runat="server" ControlToValidate="ddlSourceBranch"
                        ErrorMessage="Applicant Ctegory No Selected" InitialValue="(Select)" SetFocusOnError="True"
                        ValidationGroup="ApplicationBasic">?</asp:RequiredFieldValidator></td>
                <td class="TableTitle">
                    Sales Manager</td>
                <td>
                    <asp:TextBox ID="txtEmpCode" runat="server" CssClass="TEXTBOX"></asp:TextBox></td>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td colspan="6" style="height: 20px">
                </td>
            </tr>
            <tr>
                <td class="TableHeader" colspan="6">
                    <strong>Account Details for Refund (Refer Section 5 of T &amp; C)</strong></td>
            </tr>
            <tr>
                <td colspan="6" style="height: 17px" class="TableTitle">
                    (Refund account details of the preferred financier to be mentioned in case of financed
                    booking)</td>
            </tr>
            <tr>
                <td style="height: 17px; width: 128px;" class="TableTitle">
                    Name of the Account Holder/Financier :</td>
                <td colspan="2" style="height: 17px">
                    <asp:TextBox ID="txtAccountHolder" runat="server" Font-Size="Small" Width="305px"
                        CssClass="TEXTBOX"></asp:TextBox></td>
                <td style="width: 100px; height: 17px">
                </td>
                <td style="width: 100px; height: 17px">
                </td>
                <td style="width: 100px; height: 17px">
                </td>
            </tr>
            <tr>
                <td class="TableTitle" style="width: 128px">
                    Bank Account Number</td>
                <td colspan="2">
                    <asp:TextBox ID="txtBankAccount" runat="server" Font-Size="Small" Width="194px" CssClass="TEXTBOX"></asp:TextBox></td>
                <td style="width: 100px;">
                </td>
                <td style="width: 100px;">
                </td>
                <td style="width: 100px;">
                </td>
            </tr>
            <tr>
                <td class="TableTitle" style="width: 128px">
                    Bank Name</td>
                <td colspan="2">
                    <asp:TextBox ID="txtBankName" runat="server" Font-Size="Small" Width="306px" CssClass="TEXTBOX"></asp:TextBox></td>
                <td style="width: 100px;">
                </td>
                <td style="width: 100px;">
                </td>
                <td style="width: 100px;">
                </td>
            </tr>
            <tr>
                <td style="height: 17px; width: 128px;" class="TableTitle">
                    BranchName</td>
                <td colspan="2" style="height: 17px">
                    <asp:TextBox ID="txtBranchName" runat="server" Font-Size="Small" Width="305px" CssClass="TEXTBOX"></asp:TextBox></td>
                <td style="width: 100px; height: 17px">
                </td>
                <td style="width: 100px; height: 17px">
                </td>
                <td style="width: 100px; height: 17px">
                </td>
            </tr>
            <tr>
                <td style="height: 17px; width: 128px;" class="TableTitle">
                    Branch MICR Code</td>
                <td style="height: 17px">
                    <asp:TextBox ID="txtBranchMICRCode" runat="server" Font-Size="Small" MaxLength="9"
                        Width="218px" CssClass="TEXTBOX"></asp:TextBox></td>
                <td style="height: 17px; width: 229px;" class="TableTitle">
                    &nbsp;PinCode</td>
                <td style="width: 100px; height: 17px">
                    <asp:TextBox ID="txtBranchPincode" runat="server" Font-Size="Small" MaxLength="6"
                        Width="121px" CssClass="TEXTBOX"></asp:TextBox></td>
                <td style="width: 100px; height: 17px">
                </td>
                <td style="width: 100px; height: 17px">
                </td>
            </tr>
            <tr>
                <td colspan="2" class="TableTitle">
                    &nbsp;(MICR code is a 9 digit number printed on your cheque lead)</td>
                <td style="height: 17px; width: 229px;">
                </td>
                <td style="width: 100px; height: 17px">
                </td>
                <td style="width: 100px; height: 17px">
                </td>
                <td style="width: 100px; height: 17px">
                </td>
            </tr>
            <tr>
                <td colspan="6" style="height: 17px">
                </td>
            </tr>
            <tr>
                <td class="TableHeader" colspan="6" style="height: 17px">
                    <strong>Car Selection Section</strong></td>
            </tr>
            <tr>
                <td colspan="6" style="height: 17px" class="TableTitle">
                    Kindly select one cell only. Selection of more than one cell or any overwritting
                    would result in rejection of form.
                </td>
            </tr>
            <tr>
                <td style="height: 10px; width: 128px;" class="TableTitle">
                    &nbsp;Model No</td>
                <td style="height: 10px">
                    <asp:DropDownList ID="ddlNanoModelNo" runat="server" Font-Size="Small" OnSelectedIndexChanged="ddlNanoModelNo_SelectedIndexChanged">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RqddlNanoModelNo" runat="server" ControlToValidate="ddlNanoModelNo"
                        InitialValue="(Select)" SetFocusOnError="True" ValidationGroup="ApplicationBasic">?</asp:RequiredFieldValidator></td>
                <td style="height: 10px; width: 229px;" class="TableTitle">
                    &nbsp; Color
                </td>
                <td style="width: 100px; height: 10px">
                    <asp:DropDownList ID="ddlNanoColor" runat="server" Font-Size="Small">
                        <asp:ListItem Selected="True" Value="0">(Select)</asp:ListItem>
                        <asp:ListItem>RacingRed</asp:ListItem>
                        <asp:ListItem>IvoryWhite</asp:ListItem>
                        <asp:ListItem>SummerBlue</asp:ListItem>
                        <asp:ListItem>ChampangeGold</asp:ListItem>
                        <asp:ListItem>LunarSilver</asp:ListItem>
                        <asp:ListItem>SunShineYellow</asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rqDDNanoColor" runat="server" ControlToValidate="ddlNanoColor"
                        ErrorMessage="Please Select Nano Color" InitialValue="(Select)" SetFocusOnError="True"
                        ValidationGroup="ApplicationBasic">?</asp:RequiredFieldValidator></td>
                <td style="width: 100px; height: 10px">
                </td>
                <td style="width: 100px; height: 10px">
                </td>
            </tr>
            <tr>
                <td colspan="6" style="height: 17px" class="TableTitle">
                    BS. Bharat stage. Color &amp; Model Choice are Indicative preferences. Tata Motor
                    will try to match the applicant's preference on a best effort basis.
                </td>
            </tr>
            <tr>
                <td style="width: 128px">
                </td>
                <td>
                </td>
                <td style="width: 229px;">
                </td>
                <td style="width: 100px;">
                </td>
                <td style="width: 100px;">
                </td>
                <td style="width: 100px;">
                </td>
            </tr>
            <tr>
                <td class="TableHeader" colspan="6" style="height: 17px">
                    <strong>Delivering TML Dealership / Westside Store / Croma Store Details</strong></td>
            </tr>
            <tr>
                <td style="height: 17px; width: 128px;" class="TableTitle">
                    Will take delivery from (Click only one option)</td>
                <td style="height: 17px">
                    <asp:DropDownList ID="ddlDeliveryList" runat="server" Width="171px">
                        <asp:ListItem>(Select)</asp:ListItem>
                        <asp:ListItem>TML Dealership</asp:ListItem>
                        <asp:ListItem>Westside Store</asp:ListItem>
                        <asp:ListItem>Croma store</asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RqddlDeliveryList" runat="server" ControlToValidate="ddlDeliveryList"
                        ErrorMessage="Please Select Nano ModelNo" InitialValue="(Select)" SetFocusOnError="True"
                        ValidationGroup="ApplicationBasic">?</asp:RequiredFieldValidator></td>
                <td colspan="2" style="height: 17px" class="TableTitle">
                    * Only if booking is done from Westside Store / Croma Store</td>
                <td style="width: 100px; height: 17px">
                </td>
                <td style="width: 100px; height: 17px">
                </td>
            </tr>
            <tr>
                <td style="height: 17px; width: 128px;" class="TableTitle">
                    State</td>
                <td style="height: 17px">
                    <asp:TextBox ID="txtDeliveryState" runat="server" Font-Size="Small" Width="200px"
                        CssClass="TEXTBOX"></asp:TextBox></td>
                <td style="height: 17px; width: 229px;" class="TableTitle">
                    City</td>
                <td style="width: 100px; height: 17px">
                    <asp:TextBox ID="txtDeliveryCity" runat="server" Font-Size="Small" Width="200px"
                        CssClass="TEXTBOX"></asp:TextBox></td>
                <td style="width: 100px; height: 17px">
                </td>
                <td style="width: 100px; height: 17px">
                </td>
            </tr>
            <tr>
                <td style="height: 17px; width: 128px;" class="TableTitle">
                    DelearshipName</td>
                <td colspan="3" style="height: 17px">
                    <asp:TextBox ID="txtDeliveryDelearship" runat="server" Font-Size="Small" Width="449px"
                        CssClass="TEXTBOX"></asp:TextBox></td>
                <td style="width: 100px; height: 17px">
                </td>
                <td style="width: 100px; height: 17px">
                </td>
            </tr>
            <tr>
                <td colspan="6" style="height: 17px">
                </td>
            </tr>
            <tr>
                <td colspan="6" style="height: 17px" class="TableHeader">
                    &nbsp;Payment Details</td>
            </tr>
            <tr>
                <td class="TableTitle" colspan="4" style="height: 17px">
                    <strong>Cheque / DD number (Drawn in favour of "Tata Motors Limited - A/c Tata Nano")
                    </strong>
                </td>
                <td style="width: 100px; height: 17px">
                </td>
                <td style="width: 100px; height: 17px">
                </td>
            </tr>
            <tr>
                <td class="TableTitle" style="height: 17px; width: 128px;">
                    Cheque / DD number
                </td>
                <td colspan="2" style="height: 17px">
                    <asp:TextBox ID="txtCheque_ddNo" runat="server" Font-Size="Small" Width="420px" CssClass="TEXTBOX"></asp:TextBox></td>
                <td style="width: 100px; height: 17px">
                </td>
                <td style="width: 100px; height: 17px">
                </td>
                <td style="width: 100px; height: 17px">
                </td>
            </tr>
            <tr>
                <td style="height: 17px; width: 128px;" class="TableTitle">
                    &nbsp;DraweeBank</td>
                <td style="height: 17px">
                    <asp:TextBox ID="txtDraweeBank" runat="server" Font-Size="Small" Width="200px" CssClass="TEXTBOX"></asp:TextBox></td>
                <td style="height: 17px; width: 229px;" class="TableTitle">
                    Dated (DD/MM/YYYY)</td>
                <td style="width: 100px; height: 17px">
                    <asp:TextBox ID="txtCheque_DD_date" runat="server" Font-Size="Small" MaxLength="10"
                        CssClass="TEXTBOX"></asp:TextBox>
                    <img id="Img1" alt="Calendar" src="SmallCalendar.gif" onclick="popUpCalendar(this, document.all.<%=txtCheque_DD_date.ClientID%>, 'dd/mm/yyyy', 0, 0);" /></td>
                <td style="width: 100px; height: 17px">
                </td>
                <td style="width: 100px; height: 17px">
                </td>
            </tr>
            <tr>
                <td style="height: 17px; width: 128px;" class="TableTitle">
                    &nbsp;Issuing Branch</td>
                <td colspan="2" style="height: 17px">
                    <asp:TextBox ID="txtSellingBank" runat="server" Font-Size="Small" Width="333px" CssClass="TEXTBOX"></asp:TextBox></td>
                <td style="width: 100px; height: 17px">
                </td>
                <td style="width: 100px; height: 17px">
                </td>
                <td style="width: 100px; height: 17px">
                </td>
            </tr>
            <tr>
                <td colspan="6" style="height: 17px">
                </td>
            </tr>
            <tr>
                <td class="TableHeader" colspan="6" style="height: 17px">
                    <strong>Retention of Booking (Refer Section 4 of T &amp; C)</strong></td>
            </tr>
            <tr>
                <td colspan="3" style="height: 21px" class="TableTitle">
                    Case I do not get allotment in the first 100000 allottees (tick ONLY one)</td>
                <td style="width: 100px; height: 21px">
                </td>
                <td style="width: 100px; height: 21px">
                </td>
                <td style="width: 100px; height: 21px">
                </td>
            </tr>
            <tr>
                <td colspan="4" style="height: 17px">
                    <asp:CheckBox ID="chkRentention1" runat="server" Font-Size="Small" Text="Please retain my booking amount with Tata Motors per Section 4 of Terms & Conditions." /></td>
                <td style="width: 100px; height: 17px">
                </td>
                <td style="width: 100px; height: 17px">
                </td>
            </tr>
            <tr>
                <td colspan="3" style="height: 17px">
                    <asp:CheckBox ID="chkRentention2" runat="server" Text="Please refund my booking amount"
                        Checked="True" /></td>
                <td style="width: 100px; height: 17px">
                </td>
                <td style="width: 100px; height: 17px">
                </td>
                <td style="width: 100px; height: 17px">
                </td>
            </tr>
            <tr>
                <td colspan="6" style="height: 17px">
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan="6" style="height: 17px" class="TableHeader">
                    &nbsp;Declaration</td>
            </tr>
            <tr>
                <td style="height: 17px; width: 128px;" class="TableTitle">
                    Photo ID Proof type</td>
                <td style="height: 17px">
                    <asp:DropDownList ID="ddlPhotoIdProff" runat="server" Width="149px">
                        <asp:ListItem>(Select)</asp:ListItem>
                        <asp:ListItem>PAN card</asp:ListItem>
                        <asp:ListItem>Passport</asp:ListItem>
                        <asp:ListItem>Voter I-card</asp:ListItem>
                        <asp:ListItem>Driving Licence</asp:ListItem>
                        <asp:ListItem>Any Other</asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rqddlPhotoIdProff" runat="server" ControlToValidate="ddlPhotoIdProff"
                        ErrorMessage="PhotoId Proof Not Selected" InitialValue="(Select)" SetFocusOnError="True"
                        ValidationGroup="ApplicationBasic">?</asp:RequiredFieldValidator></td>
                <td style="height: 17px; width: 229px;" class="TableTitle">
                    If other plz specify
                </td>
                <td style="width: 100px; height: 17px">
                    <asp:TextBox ID="txtPhotoIdProff" runat="server" Font-Size="Small" Width="338px"
                        CssClass="TEXTBOX"></asp:TextBox></td>
                <td style="width: 100px; height: 17px">
                </td>
                <td style="width: 100px; height: 17px">
                </td>
            </tr>
            <tr>
                <td style="height: 17px; width: 128px;" class="TableTitle">
                    Enclosures</td>
                <td style="height: 17px">
                    <asp:DropDownList ID="ddlEncloser" runat="server" Width="148px">
                        <asp:ListItem>(Select)</asp:ListItem>
                        <asp:ListItem>Form 60</asp:ListItem>
                        <asp:ListItem>Form 61</asp:ListItem>
                        <asp:ListItem>ID Proof</asp:ListItem>
                        <asp:ListItem>Cancelled Cheque</asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RqddlEncloser" runat="server" ControlToValidate="ddlEncloser"
                        ErrorMessage="Encloser Not Selected" InitialValue="(Select)" SetFocusOnError="True"
                        ValidationGroup="ApplicationBasic">?</asp:RequiredFieldValidator></td>
                <td style="height: 17px; width: 229px;" class="TableTitle">
                    Photo ID Proof number
                </td>
                <td style="width: 100px; height: 17px">
                    <asp:TextBox ID="txtPhotoIdProffNo" runat="server" Font-Size="Small" Width="339px"
                        CssClass="TEXTBOX"></asp:TextBox></td>
                <td style="width: 100px; height: 17px">
                </td>
                <td style="width: 100px; height: 17px">
                </td>
            </tr>
            <tr>
                <td class="TableTitle" style="height: 17px; width: 128px;">
                    Location</td>
                <td style="height: 17px">
                    <asp:TextBox ID="txtLocation" runat="server" Font-Size="Small" Width="197px" CssClass="TEXTBOX"></asp:TextBox></td>
                <td style="width: 229px; height: 17px">
                </td>
                <td style="width: 100px; height: 17px">
                </td>
                <td style="width: 100px; height: 17px">
                </td>
                <td style="width: 100px; height: 17px">
                </td>
            </tr>
            <tr>
                <td colspan="6" style="height: 17px">
                </td>
            </tr>
            <tr>
                <td class="TableHeader" colspan="6" style="height: 17px">
                    &nbsp;<strong>For Office Use</strong></td>
            </tr>
            <tr>
                <td style="height: 17px; width: 128px;" class="TableTitle">
                    Form Received at</td>
                <td style="height: 17px">
                    <asp:DropDownList ID="ddlReceivedAt" runat="server" Width="147px">
                        <asp:ListItem>(Select)</asp:ListItem>
                        <asp:ListItem>SBI Branch</asp:ListItem>
                        <asp:ListItem>TML Dealership</asp:ListItem>
                        <asp:ListItem>Westside Store</asp:ListItem>
                        <asp:ListItem>Croma Store</asp:ListItem>
                    </asp:DropDownList></td>
                <td style="height: 17px; width: 229px;" class="TableTitle">
                    Date of Form Receipt (DD/MM/YYYY)</td>
                <td style="width: 100px; height: 17px">
                    <asp:TextBox ID="txtReceiptDate" runat="server" Font-Size="Small" MaxLength="10"
                        CssClass="TEXTBOX"></asp:TextBox>
                    <img id="Img2" alt="Calendar" src="SmallCalendar.gif" onclick="popUpCalendar(this, document.all.<%=txtReceiptDate.ClientID%>, 'dd/mm/yyyy', 0, 0);" /></td>
                <td style="width: 100px; height: 17px">
                </td>
                <td style="width: 100px; height: 17px">
                </td>
            </tr>
            <tr>
                <td style="height: 17px; width: 128px;" class="TableTitle">
                    SBI Branch Code</td>
                <td style="height: 17px">
                    <asp:TextBox ID="txtSBIBranchCode" runat="server" Font-Size="Small" Width="197px"
                        CssClass="TEXTBOX"></asp:TextBox></td>
                <td style="height: 17px; width: 229px;">
                </td>
                <td style="width: 100px; height: 17px">
                </td>
                <td style="width: 100px; height: 17px">
                </td>
                <td style="width: 100px; height: 17px">
                </td>
            </tr>
        </table>
    </asp:Panel>
    &nbsp;<table style="width: 963px">
        <tr>
            <td class="TableHeader" colspan="4" style="height: 15px">
                &nbsp;
                <asp:Button ID="btnSave" runat="server" Text="Save" Width="78px" OnClick="btnSave_Click"
                    ValidationGroup="ApplicationBasic" CssClass="TableTitle" Height="23px" />
                <asp:Button ID="btnClear" runat="server" Text="Clear" Width="71px" CssClass="TableTitle"
                    OnClick="btnClear_Click" Height="23px" />&nbsp;<asp:Button ID="btnCancel" runat="server"
                        CssClass="TableTitle" OnClick="btnCancel_Click" Text="Close" Width="76px" Height="23px" /></td>
        </tr>
        <tr>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
        </tr>
    </table>
    <br />
    &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp;&nbsp;
</asp:Content>
