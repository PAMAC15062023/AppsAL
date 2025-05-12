<%@ Page Language="C#" MasterPageFile="~/CM.master" AutoEventWireup="true" CodeBehind="CM_VH_Approval.aspx.cs" Inherits="ChangeManagement.CM_VH_Approval" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="App_Assets/css/example.css" rel="stylesheet" />
    <link href="App_Assets/css/jquery-ui.css" rel="stylesheet" />
    <script src="App_Assets/js/jquery-3.5.1.js"></script>
    <script src="App_Assets/js/bootstrap-datepicker.min.js"></script>

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

        function CheckSingleCheckbox(ob) {   /*add on 17/01/24*/
            var grid = ob.parentNode.parentNode.parentNode;
            var inputs = grid.getElementsByTagName("input");
            for (var i = 0; i < inputs.length; i++) {
                if (inputs[i].type == "checkbox") {
                    if (ob.checked && inputs[i] != ob && inputs[i].checked) {
                        inputs[i].checked = false;
                    }
                }
            }
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

    <asp:ScriptManager ID="sm" runat="server"></asp:ScriptManager>
    <table style="width: 688px;">
        <tr>
            <td class="TableTitle" style="height: 27px" colspan="4">
                <span style="font-size: 13pt; font-weight: bold;">VH Approval</span>
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

    <asp:Panel runat="server" ID="panel2" Visible="true">
        <table style="width: 688px;"><%--add on 19/11/2024--%>
            <tr>
                 <td class="TableTitle" style="height: 27px" colspan="8">
                    <asp:Label runat="server" Width="150px" Font-Size="10" Height="20" Style="text-align: center;">CR No</asp:Label>
                </td>
                <td class="TableTitle" style="height: 27px" colspan="8">
                    <asp:TextBox ID="txtsearch_crno" runat="server"  Width="150px" MaxLength="15" 
                                    autocomplete="off" OnTextChanged="txtsearch_crno_TextChanged" AutoPostBack="true"></asp:TextBox>
                </td>
                <td class="TableTitle" style="height: 27px" colspan="8">
                        <asp:Label runat="server"  Width="150px" Visible="false" Font-Size="10" Height="20" Style="text-align: center;"></asp:Label> <%--new add on 15/11/2024--%>
                    </td>
                    <td class="TableTitle" style="height: 27px" colspan="8">
                        <asp:TextBox ID="TextBox2" Visible="false" runat="server" Width="150px" ></asp:TextBox>
                    </td>
            </tr>
        </table>
        <table style="width: 688px;"> <%--add on 19/11/2024--%>
             <tr>
                <td class="TableTitle" style="height: 27px" colspan="8">
                    <asp:Label runat="server" Width="150px" Font-Size="10" Height="20" Style="text-align: center;">Request From Date</asp:Label>
                </td>
                <td class="TableTitle" style="height: 27px" colspan="8">
                    <asp:TextBox ID="txtFromDate" runat="server" BorderWidth="1px" SkinID="txtSkin" Width="150px"></asp:TextBox>
                </td>
                 <td style="width: 100px; height: 20px" class="TableTitle">
                    <img id="ImgDate3rdCall" alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtFromDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                        src="SmallCalendar.gif" style="width: 17px; height: 16px" /></td>
                <td style="width: 100px; height: 20px"></td>


                <td class="TableTitle" style="height: 27px" colspan="8">
                    <asp:Label runat="server" Width="150px" Font-Size="10" Height="20" Style="text-align: center;">Request To date</asp:Label>
                </td>
                <td class="TableTitle" style="height: 27px" colspan="8">
                    <asp:TextBox ID="txtToDate" runat="server" BorderWidth="1px" SkinID="txtSkin" Width="150px"></asp:TextBox></td>
                <td style="width: 100px" class="TableTitle">
                    <img id="Img1" alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtToDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                        src="SmallCalendar.gif" style="width: 17px; height: 16px" />
                </td>
            </tr>
        </table>
        <table style="width: 688px;"><%--add on 21/11/2024--%>
            <tr>
                <td class="TableTitle" style="height: 27px" colspan="8">
                    <asp:Button ID="btnSearch" runat="server"  Width="150px" autocomplete="off" OnClick="btnSearch_Click" AutoPostBack="true" Text="Search" ></asp:Button>
                </td>
                <td class="TableTitle" style="height: 27px" colspan="8">
                    <asp:Button ID="btnBack" runat="server" Text="Back" BorderColor="#400000" BorderWidth="1px"
                    Font-Bold="False" Width="105px" OnClick="btnBack_Click" />
                </td>
                <td class="TableTitle" style="height: 27px" colspan="8">
                        <asp:Label runat="server"  Width="150px" Visible="false" Font-Size="10" Height="20" Style="text-align: center;"></asp:Label> <%--new add on 15/11/2024--%>
                    </td>
                    <td class="TableTitle" style="height: 27px" colspan="8">
                        <asp:TextBox ID="TextBox4" Visible="false" runat="server" Width="150px" ></asp:TextBox>
                    </td>
            </tr>
        </table>
    
        <table style="width: 688px;">
            <tr>
                <td class="TableTitle" style="height: 27px" colspan="4">
                    <asp:GridView ID="gvData" runat="server" AutoGenerateColumns="false" Height="16px" Width="1200px" CssClass="mGrid">
                        <Columns>
                            <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="150px">
                                <%--<HeaderTemplate>
                                    <input id="chkSelectAll" type="checkbox" />
                                </HeaderTemplate>--%>
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkSelect" runat="server" onclick="CheckSingleCheckbox(this)" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="150px">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkEdit" runat="server" Font-Bold="True" OnClick="lnkEdit_Click">Edit</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="CR_No" HeaderText="CR_No" ItemStyle-Width="400px" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="CR_Date" HeaderText="CR_Date" ItemStyle-Width="200px" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="CR_Priority" HeaderText="CR_Priority" ItemStyle-Width="200px" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="CR_Type" HeaderText="CR_Type" ItemStyle-Width="300px" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="CR_Vertical" HeaderText="CR_Vertical" ItemStyle-Width="300px" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="BranchName" HeaderText="BranchName" ItemStyle-Width="300px" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="CR_Department" HeaderText="CR_Department" ItemStyle-Width="300px" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="CR_ApplicationName" HeaderText="CR_ApplicationName" ItemStyle-Width="400px" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="CR_HardwareName" HeaderText="CR_HardwareName" ItemStyle-Width="400px" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="CR_Status" HeaderText="CR_Status" ItemStyle-Width="600px" ItemStyle-HorizontalAlign="Center" />
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </asp:Panel>

    <asp:Panel runat="server" ID="panel1" Visible="true">
        <table style="width: 688px;"> <%--add on 09/09/2024--%>
            <tr>
                <td class="TableTitle" style="height: 27px" colspan="8">
                    <asp:Label runat="server" Width="150px" Font-Size="10" Height="20" Style="text-align: center;">CR No</asp:Label>
                </td>
                <td class="TableTitle" style="height: 27px" colspan="8">
                    <asp:TextBox ID="txtCRNo" runat="server" Enabled="false" Width="150px"></asp:TextBox>
                </td>
                <td class="TableTitle" style="height: 27px" colspan="8">
                    <asp:Label runat="server" Width="150px"  Font-Size="10" Height="20" Style="text-align: center;">CR Date</asp:Label>
                </td>
                <td class="TableTitle" style="height: 27px" colspan="8">
                    <asp:TextBox ID="txtCRDate" runat="server" Enabled="false" Width="150px" autoClose="true"></asp:TextBox>
                </td>
            </tr>
        </table>
        <table style="width: 688px;">
            <tr>
                
                 <td class="TableTitle" style="height: 27px" colspan="8">
                    <asp:Label runat="server" Width="150px" Font-Size="10" Height="20" Style="text-align: center;">CR Priority</asp:Label>
                </td>
               <td class="TableTitle" style="height: 27px" colspan="8">
                    <asp:TextBox ID="txtCRPriority" runat="server" Enabled="false" Width="150px"></asp:TextBox>
                </td>
                 <td class="TableTitle" style="height: 27px" colspan="8">
                    <asp:Label runat="server" Width="150px" Font-Size="10" Height="20" Style="text-align: center;">CR Type</asp:Label>
                </td>
                <td class="TableTitle" style="height: 27px" colspan="8">
                    <asp:TextBox ID="txtCRType" runat="server" Enabled="false"  Width="150px"></asp:TextBox>
                </td>
                
            </tr>
        </table>
      
        <table style="width: 688px;"> <%--new add on 15/11/2024--%>
            <tr>
                <td class="TableTitle" style="height: 27px" colspan="8">
                    <asp:Label runat="server" Width="150px" Font-Size="10" Height="20" Style="text-align: center;">	Vertical </asp:Label>
                </td>
                <td class="TableTitle" style="height: 27px" colspan="8">
                    <asp:TextBox ID="txtVertical" Enabled="false" runat="server" Width="150px"></asp:TextBox>
                </td>
                <td class="TableTitle" style="height: 27px" colspan="8">
                    <asp:Label runat="server" Width="150px" Font-Size="10" Height="20" Style="text-align: center;"> Branch </asp:Label>
                </td>
                <td class="TableTitle" style="height: 27px" colspan="8">
                    <asp:TextBox ID="txtBranch" Enabled="false" runat="server" Width="150px"></asp:TextBox>
                </td>
            </tr>
        </table>
        <table style="width: 688px;">
            <tr>
                <td class="TableTitle" style="height: 27px" colspan="8">
                    <asp:Label runat="server" Width="150px" Font-Size="10" Height="20" Style="text-align: center;">	Department</asp:Label>
                </td>
                <td class="TableTitle" style="height: 27px" colspan="8">
                    <asp:TextBox ID="txtDepartment" Enabled="false" runat="server" Width="150px"></asp:TextBox>
                </td>
                <td class="TableTitle" style="height: 27px" colspan="8">
                    <asp:Label runat="server" Width="150px" Font-Size="10" Height="20" Style="text-align: center;">CR Raised By</asp:Label>
                </td>
                <td class="TableTitle" style="height: 27px" colspan="8">
                    <asp:TextBox ID="txtCRRaisedBy" runat="server" Enabled="false" Width="150px"></asp:TextBox>
                </td>
            </tr>
        </table>
        <table runat="server" style="width: 688px;" id="tbldept" > <%--visible="false"--%>
            <tr runat="server" id="department" > <%--visible="false"--%>
                <td class="TableTitle" style="height: 27px" colspan="8">
                    <asp:Label ID="lblCRApplicationName" runat="server" Width="150px" Font-Size="10" Height="20" Style="text-align: center;">	CR Application Name</asp:Label>
                </td>
                <td class="TableTitle" style="height: 27px" colspan="8">
                    <asp:TextBox ID="txtCRApplicationName" runat="server" Enabled="false" Width="150px"></asp:TextBox>
                </td>
                <td class="TableTitle" style="height: 27px" colspan="8"> <%--new add on 15/11/2024--%>
                    <asp:Label ID="lblCRHardwareName" runat="server" Width="150px" Font-Size="10" Height="20" Style="text-align: center;"> CR Hardware Name</asp:Label>
                </td>
                <td class="TableTitle" style="height: 27px" colspan="8">
                    <asp:TextBox ID="txtCRHardwareName" runat="server" Enabled="false" Width="150px"></asp:TextBox>
                </td>
            </tr>
        </table>
        <table style="width: 688px;">
            <tr>
                <td class="TableTitle" style="height: 27px" colspan="8">
                    <asp:Label runat="server" Width="150px" Font-Size="10" Height="20" Style="text-align: center;">CR Change Requirement</asp:Label>
                </td>
                <td class="TableTitle" style="height: 27px" colspan="8">
                    <asp:TextBox ID="txtCRChangeRequirement" runat="server" Enabled="false" Width="150px"></asp:TextBox>
                </td>
                <td class="TableTitle" style="height: 27px" colspan="8">
                    <asp:Label runat="server" Width="150px" Font-Size="10" Height="20" Style="text-align: center;">CR File</asp:Label>
                </td>
                <td class="TableTitle" style="height: 27px" colspan="8">
                    <asp:LinkButton ID="lkbtnxslCRFile" runat="server" Font-Bold="True" Width="160px" OnClick="lkbtnxslCRFile_Click"></asp:LinkButton> <%--//add on 13/11/2024--%>
                </td>
            </tr>
        </table>
        <table style="width: 688px;">
            <tr>
                
                <td class="TableTitle" style="height: 27px" colspan="8">
                    <asp:Label runat="server" Width="150px" Font-Size="10" Height="20" Style="text-align: center;">CR Reason</asp:Label>
                </td>
                <td class="TableTitle" style="height: 27px" colspan="8">
                    <asp:TextBox ID="txtCRReason" runat="server" Enabled="false" Width="150px"></asp:TextBox>
                </td>
                <td class="TableTitle" style="height: 27px" colspan="8">
                    <asp:Label runat="server" Width="150px" Font-Size="10" Height="20" Style="text-align: center;">CR Impact Analysis</asp:Label>
                </td>
                <td class="TableTitle" style="height: 27px" colspan="8">
                    <asp:TextBox ID="txtCRImpactAnalysis" runat="server" Enabled="false" Width="150px"></asp:TextBox> 
                </td>
            </tr>
        </table>
        <table style="width: 688px;">
            <tr>
                <td class="TableTitle" style="height: 27px" colspan="8">
                    <asp:Label runat="server" Width="150px" Font-Size="10" Height="20" Style="text-align: center;">CR Affected Module</asp:Label>
                </td>
                <td class="TableTitle" style="height: 27px" colspan="8">
                    <asp:TextBox ID="txtCRAffectedModule" runat="server" Enabled="false" Width="150px"></asp:TextBox>
                </td>
                <td class="TableTitle" style="height: 27px" colspan="8">
                    <asp:Label runat="server"  Width="150px" Font-Size="10" Height="20" Style="text-align: center;">CR Remark</asp:Label> <%--new add on 15/11/2024--%>
                </td>
                <td class="TableTitle" style="height: 27px" colspan="8">
                    <asp:TextBox ID="txtCRRemark" runat="server" Enabled="false" Width="150px" ></asp:TextBox>
                </td>
            </tr>
        </table>
        <table style="width: 688px;">
            <tr>
               <td class="TableTitle" style="height: 27px" colspan="8">
                    <asp:Label runat="server"  Width="150px" Font-Size="10" Height="20" Style="text-align: center;">VH Remark</asp:Label>
                </td>
                <td class="TableTitle" style="height: 27px" colspan="8">
                    <asp:TextBox ID="txtVHRemark" runat="server" Width="150px" ></asp:TextBox>
                </td>
                <td class="TableTitle" style="height: 27px" colspan="8">
                    <asp:Label runat="server"  Width="150px" Visible="false" Font-Size="10" Height="20" Style="text-align: center;"></asp:Label> <%--new add on 15/11/2024--%>
                </td>
                <td class="TableTitle" style="height: 27px" colspan="8">
                    <asp:TextBox ID="TextBox1" Visible="false" runat="server" Width="150px" ></asp:TextBox>
                </td>
            </tr>
        </table>
        
        <table style="width: 688px;">
          <tr>
            <td class="TableTitle" style="height: 27px" colspan="4">
                <br />
                <asp:Button ID="btnAccepted" runat="server" Text="Accepted"
                    BorderColor="#400000" BorderWidth="1px" Font-Bold="False" Width="105px" OnClick="btnAccepted_Click" ValidationGroup="valid" CausesValidation="true" />
                &nbsp;
                <asp:Button ID="btnRejected" runat="server" Text="Rejected"
                    BorderColor="#400000" BorderWidth="1px" Font-Bold="False" Width="105px" OnClick="btnRejected_Click" ValidationGroup="valid" CausesValidation="true" />
                &nbsp;
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" BorderColor="#400000"
                        BorderWidth="1px" Font-Bold="False" Width="105px" OnClick="btnCancel_Click" ValidationGroup="valid" CausesValidation="true" />
                &nbsp;
                
            </td>
        </tr>
    </table>
    </asp:Panel>

    <asp:Panel runat="server" ID="panel3" Visible="true">
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
