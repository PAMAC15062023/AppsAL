<%@ Page Language="C#" MasterPageFile="~/CM.master" AutoEventWireup="true" CodeBehind="CM_CR-Initiation.aspx.cs" Inherits="ChangeManagement.CM_CR_Initiation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="App_Assets/css/example.css" rel="stylesheet" />
    <link href="App_Assets/css/jquery-ui.css" rel="stylesheet" />
    <script src="App_Assets/js/jquery-3.5.1.js"></script>
    <script src="App_Assets/js/bootstrap-datepicker.min.js"></script>

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

    </style> <%--add on 27/11/2024 end here<< --%>

 
    <asp:ScriptManager ID="ScriptManager1" runat="server" ScriptMode="Release"></asp:ScriptManager>
    <table style="width: 688px;">
        <tr>
            <td class="TableTitle" style="height: 27px" colspan="4">
                <span style="font-size: 13pt; font-weight: bold;">CR&nbsp;Initiation</span>
            </td>
        </tr>
    </table>
    <table style="width: 688px;">
        <tr>
            <td colspan="4">
                <asp:Label ID="lblMsgXls" runat="server" ForeColor="Red" Font-Size="10pt" Width="180px"></asp:Label>
            </td>
        </tr>
    </table>
   
    <asp:Panel runat="server" ID="panel1" Visible="true">
        <%--<table style="width: 688px;"> <%--add on 09/09/2024--
            <tr>
                <td class="TableTitle" style="height: 27px" colspan="8">
                    <asp:Label runat="server" Width="150px" Font-Size="10" Height="20" Style="text-align: center;">CR No</asp:Label>
                </td>
                <td class="TableTitle" style="height: 27px" colspan="8">
                    <asp:TextBox ID="txtCRNo" runat="server" Enabled="false" Width="150px"></asp:TextBox>
                </td>
                <td class="TableTitle" style="height: 27px" colspan="8">
                    <asp:Label runat="server" Width="150px" Font-Size="10" Height="20" Style="text-align: center;">CR Date</asp:Label>
                </td>
                <td class="TableTitle" style="height: 27px" colspan="8">
                    <asp:TextBox ID="txtCRDate" runat="server" Enabled="false" Width="150px" TextMode="Date" autoClose="true"  
                    onchange="TDate()" BorderWidth="1px" SkinID="txtSkin"></asp:TextBox>
                </td>
            </tr>
        </table>--%>
        <table style="width: 688px;">
            <tr>
                
                 <td class="TableTitle" style="height: 27px" colspan="8">
                    <asp:Label runat="server" Width="150px" Font-Size="10" Height="20" Style="text-align: center;">CR Priority</asp:Label>
                </td>
                <td class="TableTitle" style="height: 27px" colspan="8">
                    <asp:RadioButtonList ID="rblCRPriority" runat="server" RepeatDirection="Horizontal" Width="160px">
                        <%--<asp:ListItem Text= "Urgent" Value="1"/>--%>
                         <asp:ListItem Text= "High" Value="1"/>
                        <asp:ListItem Text= "Medium" Value="2"/>
                        <asp:ListItem Text= "Low" Value="3"/> 
                    </asp:RadioButtonList>
                </td>
                 <td class="TableTitle" style="height: 27px" colspan="8">
                    <asp:Label runat="server" Width="150px" Font-Size="10" Height="20" Style="text-align: center;">CR Type</asp:Label>
                </td>
                <td class="TableTitle" style="height: 27px" colspan="8">
                    <asp:RadioButtonList ID="rblCRType" runat="server" RepeatDirection="Horizontal" Width="160px">
                        <asp:ListItem Text= "New" Value="1"/>
                         <asp:ListItem Text= "Normal" Value="2"/>
                        <asp:ListItem Text= "Emergency" Value="3"/>
                    </asp:RadioButtonList>
                </td>
                
            </tr>
        </table>
        <table style="width: 688px;"> <%--new add on 15/11/2024--%>
            <tr>
                <td class="TableTitle" style="height: 27px" colspan="8">
                    <asp:Label runat="server" Width="150px" Font-Size="10" Height="20" Style="text-align: center;">	Vertical </asp:Label>
                </td>
                <td class="TableTitle" style="height: 27px" colspan="8">
                    <asp:DropDownList ID="ddlVertical" runat="server" Width="150px"></asp:DropDownList>
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
                    <asp:Label runat="server" Width="150px" Font-Size="10" Height="20" Style="text-align: center;">	Department</asp:Label>
                </td>
                <td class="TableTitle" style="height: 27px" colspan="8">
                    <asp:DropDownList ID="ddlDepartmet" runat="server" Width="150px" OnSelectedIndexChanged="ddlDepartmet_SelectedIndexChanged" AutoPostBack="true">
                        <asp:ListItem Text= "--Select--" Value="0"/>
                        <asp:ListItem Text= "Software" Value="1"/>
                        <asp:ListItem Text= "IT" Value="2"/>
                    </asp:DropDownList>
                </td>
                <td class="TableTitle" style="height: 27px" colspan="8">
                    <asp:Label runat="server" Visible="false" Width="150px" Font-Size="10" Height="20" Style="text-align: center;"></asp:Label>
                </td>
                <td class="TableTitle" style="height: 27px" colspan="8">
                    <asp:TextBox ID="TextBox3" runat="server" Width="150px" Visible="false"></asp:TextBox>
                </td>
            </tr>
        </table>
        <table runat="server" style="width: 688px;" id="tbldept" visible="false">
            <tr runat="server" id="department" visible="false">
                <td class="TableTitle" style="height: 27px" colspan="8">
                    <asp:Label ID="lblCRApplicationName" runat="server"  Visible="false" Width="150px" Font-Size="10" Height="20" Style="text-align: center;">	CR Application Name</asp:Label>
                </td>
                <td class="TableTitle" style="height: 27px" colspan="8">
                    <asp:TextBox ID="txtCRApplicationName" runat="server" Visible="false" Width="150px"></asp:TextBox>
                </td>
                <td class="TableTitle" style="height: 27px" colspan="8"> <%--new add on 15/11/2024--%>
                    <asp:Label ID="lblCRHardwareName" runat="server"  Visible="false" Width="150px" Font-Size="10" Height="20" Style="text-align: center;"> CR Hardware Name</asp:Label>
                </td>
                <td class="TableTitle" style="height: 27px" colspan="8">
                    <asp:TextBox ID="txtCRHardwareName" runat="server" Visible="false" Width="150px"></asp:TextBox>
                </td>
            </tr>
        </table>
        <table style="width: 688px;">
            <tr>
                <td class="TableTitle" style="height: 27px" colspan="8">
                    <asp:Label runat="server" Width="150px" Font-Size="10" Height="20" Style="text-align: center;">CR Change Requirement</asp:Label>
                </td>
                <td class="TableTitle" style="height: 27px" colspan="8">
                    <asp:TextBox ID="txtCRChangeRequirement" runat="server" Width="150px"></asp:TextBox>
                </td>
                <td class="TableTitle" style="height: 27px" colspan="8">
                    <asp:Label runat="server" Width="150px" Font-Size="10" Height="20" Style="text-align: center;">CR File</asp:Label>
                </td>
                <td class="TableTitle" style="height: 27px" colspan="8">
                    <asp:FileUpload ID="xslCRFile" runat="server"  Width="160px" />
                </td>
            </tr>
        </table>
       
        <table style="width: 688px;">
            <tr>
                
                <td class="TableTitle" style="height: 27px" colspan="8">
                    <asp:Label runat="server" Width="150px" Font-Size="10" Height="20" Style="text-align: center;">CR Reason</asp:Label>
                </td>
                <td class="TableTitle" style="height: 27px" colspan="8">
                    <asp:TextBox ID="txtCRReason" runat="server" Width="150px"></asp:TextBox>
                </td>
                <td class="TableTitle" style="height: 27px" colspan="8">
                    <asp:Label runat="server" Width="150px" Font-Size="10" Height="20" Style="text-align: center;">CR Impact Analysis</asp:Label>
                </td>
                <td class="TableTitle" style="height: 27px" colspan="8">
                    <asp:TextBox ID="txtCRImpactAnalysis" runat="server" Width="150px"></asp:TextBox> 
                </td>
            </tr>
        </table>
        <table style="width: 688px;">
            <tr>
                <td class="TableTitle" style="height: 27px" colspan="8">
                    <asp:Label runat="server" Width="150px" Font-Size="10" Height="20" Style="text-align: center;">CR Affected Module</asp:Label>
                </td>
                <td class="TableTitle" style="height: 27px" colspan="8">
                    <asp:TextBox ID="txtCRAffectedModule" runat="server" Width="150px"></asp:TextBox>
                </td>
                <td class="TableTitle" style="height: 27px" colspan="8">
                    <asp:Label runat="server"  Width="150px" Font-Size="10" Height="20" Style="text-align: center;">CR Remark</asp:Label> <%--new add on 15/11/2024--%>
                </td>
                <td class="TableTitle" style="height: 27px" colspan="8">
                    <asp:TextBox ID="txtCRRemark" runat="server" Width="150px" ></asp:TextBox>
                </td>
            </tr>
        </table>
        
        <table style="width: 688px;">
          <tr>
            <td class="TableTitle" style="height: 27px" colspan="4">
                <br />
                <asp:Button ID="btnSave" runat="server" Text="Save"
                    BorderColor="#400000" BorderWidth="1px" Font-Bold="False" Width="105px" OnClick="btnSave_Click" ValidationGroup="valid" CausesValidation="true" />
                &nbsp;
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" BorderColor="#400000"
                        BorderWidth="1px" Font-Bold="False" Width="105px" OnClick="btnCancel_Click" ValidationGroup="valid" CausesValidation="true" />
                &nbsp;
                
            </td>
        </tr>
    </table>

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

    </asp:Panel>

    <asp:HiddenField ID="HdnPLtimer" runat="server" value="1"/> 
    <asp:HiddenField ID="hdgvIDs" runat="server" />

    

</asp:Content>

