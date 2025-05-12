<%@ Page Language="C#" MasterPageFile="~/CM.master" AutoEventWireup="true" CodeBehind="CM_MIS_Report.aspx.cs" Inherits="ChangeManagement.CM_MIS_Report" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script language="javascript" type="text/javascript" src="App_Assets/js/popcalendar.js"></script>

    <script language="javascript" type="text/javascript">
        function DisableDelete(e) {
            var code;
            if (!e) var e = window.event; // some browsers don't pass e, so get it from the window
            if (e.keyCode) code = e.keyCode; // some browsers use e.keyCode
            else if (e.which) code = e.which;  // others use e.which

            if (code == 8 || code == 46)
                return false;
        }
        function disallowDelete(evt) {
            evt = (evt) ? evt : window.event;
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            alert(charCode);
            // return true;

        };

        function isNumber(evt) {
            evt = (evt) ? evt : window.event;
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            if (charCode > 31 && (charCode < 48 || charCode > 57)) {
                return false;
            }
            return true;
        }
    </script>

     <%--add on 27/11/2024 start from here>>--%>
    <style> 

    /* Workflow container that holds all the steps */
    .workflow-container {
        display: flex;
        align-items: center;
    }

    /* Each workflow step with a box and an arrow */
    .workflow-step {
        display: flex;
        align-items: center;
        margin: 0 15px;
    }

    /* Style for the square boxes */
    .workflow-box {
        background-color: #0a263d; /*#4CAF50;*/
        color: white;
        padding: 30px;
        width: 120px;
        height: 10px;
        text-align: center;
        border-radius: 10px;
        font-size: 11.5px;
        font-weight: bold;
        box-shadow: 0 4px 6px rgba(0, 0, 0, 0.1);
         display: flex;
        align-items: center;
        justify-content: center;
    }

    /* Insert arrows between steps using the ::after pseudo-element */
    .workflow-step::after {
    content: "→"; /* Arrow character */
    font-size: 50px; /* Large arrows */
    font-weight: bold;
    color: #333;
    margin: 0 05px;
    display: inline-block;
    }

    /* Hide the last arrow */
        .workflow-step:last-child::after {
            content: ""; /* Remove the arrow from the last step */
        }

    </style> <%--add on 27/11/2024 end here<< --%>

    <table style="width: 688px;">
        <tr>
            <td class="TableTitle" style="height: 27px" colspan="4">
                <span style="font-size: 13pt; font-weight: bold;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    Reports &nbsp;</span>
            </td>
        </tr>
    </table>
    <table style="width: 688px;">
        <tr>
            <td colspan="4">
                <asp:Label ID="lblMsgXls" runat="server" ForeColor="Red"></asp:Label>
            </td>
        </tr>
    </table>
    <table style="width: 688px;">
        <tr>
                <td class="TableTitle" style="height: 27px" colspan="8">
                    <asp:Label runat="server" Width="150px" Font-Size="10" Height="20" Style="text-align: center;">	Vertical </asp:Label>
                </td>
                <td class="TableTitle" style="height: 27px" colspan="8">
                    <asp:DropDownList ID="ddlVertical" runat="server" Width="150px" ></asp:DropDownList>
                </td>
                <td class="TableTitle" style="height: 27px" colspan="8">
                    <asp:Label runat="server" Width="150px" Font-Size="10" Height="20" Style="text-align: center;"> Branch </asp:Label>
                </td>
                <td class="TableTitle" style="height: 27px" colspan="8">
                    <asp:DropDownList ID="ddlBranch" runat="server" Width="150px"></asp:DropDownList>
                </td>
            </tr>
       </table>
    <table style="width: 688px;">
        <tr>
            <td class="TableTitle" style="height: 27px" colspan="8">
                <asp:Label runat="server" Width="150px" Font-Size="10" Height="20" Style="text-align: center;">Request From Date</asp:Label>
            </td>
            <td class="TableTitle" style="height: 27px" colspan="8">
                <asp:TextBox ID="txtFromDate" runat="server" BorderWidth="1px" SkinID="txtSkin" Width="150px"></asp:TextBox>
            </td>
            <td style="width: 100px; height: 20px" class="TableTitle">
                <img id="ImgDate3rdCall" alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtFromDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                    src="SmallCalendar.gif" style="width: 17px; height: 16px" />
            </td>
            <td class="TableTitle" style="height: 27px" colspan="8">
                <asp:Label runat="server" Width="150px" Font-Size="10" Height="20" Style="text-align: center;">Request To date</asp:Label>
            </td>
            <td class="TableTitle" style="height: 27px" colspan="8">
                <asp:TextBox ID="txtToDate" runat="server" BorderWidth="1px" SkinID="txtSkin" Width="150px"></asp:TextBox></td>
            <td style="width: 100px" class="TableTitle">
                <img id="Img1" alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtToDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                    src="SmallCalendar.gif" style="width: 17px; height: 16px" /></td>
        </tr>
    </table>
    <table style="width: 688px;">
        <tr>
            <td class="TableTitle" style="height: 27px" colspan="4">
                <br />
                <br />
                <br />
                <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                      &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                      &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
             <%--<asp:Button ID="btnSearch" runat="server" Text="Search" BorderColor="#400000"
                     BorderWidth="1px" Font-Bold="False" Width="105px" OnClick="btnSearch_Click1" />--%>&nbsp;&nbsp;
                <asp:Button ID="btnExport" runat="server" Text="Export" BorderColor="#400000" Visible="false"
                    BorderWidth="1px" Font-Bold="False" Width="105px" OnClick="btnExport_Click" />&nbsp;&nbsp;
                <asp:Button ID="btnBack" runat="server" Text="Back" BorderColor="#400000" BorderWidth="1px"
                    Font-Bold="False" Width="105px" OnClick="btnBack_Click" />&nbsp;&nbsp;
                    
            </td>
        </tr>
    </table>
    <br />
    <table style="width: 688px;">
        <tr>
            <%--  <td class="TableHeader" colspan="9">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Data
            </td>--%>
        </tr>
        <tr>
            <td class="TableTitle" style="height: 27px" colspan="4">
                <asp:GridView ID="gvData" runat="server" Height="16px" Width="1200px" CssClass="mGrid">
                </asp:GridView>
            </td>
        </tr>
    </table>
    <br />
    <br />

        <%--add on 27/11/2024 start from here>>--%>
          <!-- Add the workflow section here -->  
        <br>
     <div><p style="font-size:15px; color:navy"><i>Change Management workflow as follows:-</i></p></div>  
    <div class="workflow-container" >
        <div class="workflow-step">
            <div class="workflow-box">Change Request Initiation</div>
            
        </div>
        <div class="workflow-step">
            <div class="workflow-box">Vertical Head Approval</div>
           
        </div>
        <div class="workflow-step">
            <div class="workflow-box">Reviewer Approval</div>
           
        </div>
        <div class="workflow-step">
            <div class="workflow-box">Development/IT Activities</div>
            
        </div>
        <div class="workflow-step">
            <div class="workflow-box">Project Manager Approval</div>
        </div>
    </div> 
        <br> 
        <%--add on 27/11/2024 end here<< --%>

</asp:Content>


