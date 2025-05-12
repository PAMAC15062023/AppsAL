<%@ Page Language="C#" MasterPageFile="~/Pages/Hero_Housing/sample.master" AutoEventWireup="true"
    CodeFile="Superadmin.aspx.cs" Inherits="Pages_Hero_Housing_Superadmin" %>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="Server">
    <link href="css/bootstrap.css" rel="stylesheet" type="text/css" />
<%--    <link href="css/bootstrap-material-design.min.css" rel="stylesheet" type="text/css" />
    <link href="css/bootstrap-material-design.min.css" rel="stylesheet" type="text/css" />--%>
 
 <meta http-equiv="refresh" content="120">

 <meta http-equiv="refresh" content="15;url=https://www.pamaconline.com/calculus/Pages/Hero_Housing/Superadmin.aspx">
    <style type="text/css">
        .form-group label
        {
            color: black;
        }
        .table > tbody > tr > th
        {
            background: #80deea;
        }
    </style>

    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <script type="text/javascript">
        $.material.init();
    </script>
    <asp:HiddenField ID="hiddenResult" runat="server" />
    <div class="container">
        <div class="row">
            <div class="col-md-12">
                <fieldset>
                    <%--<legend>Superadmin&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                        <ContentTemplate>
                        <table border="1px solid"class="table table-striped table-bordered table-hover table-responsive" Width="910px">
                        <tr>
                        <td colspan="7" style="text-align:center;font-weight:bold;">Out of TAT Pendency Counter </td>
                        </tr>
                        <tr>
                        <td style="text-align:center;">QC</td>
                        <td style="text-align:center;">QC Hold</td>
                        <td style="text-align:center;">QC Pending For FinnOne</td>
                        <td style="text-align:center;">Maker</td>
                        <td style="text-align:center;">Maker Hold</td>
                        <td style="text-align:center;">Author</td>
                        <td style="text-align:center;">Author Hold</td>
                        </tr>
                        <tr>
                        <td style="text-align:center;font-weight:bold;color:Red;font-size:large;"><asp:Label ID="lblQCCount" runat="server" Text=""></asp:Label></td>
                        <td style="text-align:center;font-weight:bold;color:Red;font-size:large;"><asp:Label ID="lblQCHoldCount" runat="server" Text=""></asp:Label></td>
                        <td style="text-align:center;font-weight:bold;color:Red;font-size:large;"><asp:Label ID="lblQCPendingFinnOneCount" runat="server" Text=""></asp:Label></td>
                        <td style="text-align:center;font-weight:bold;color:Red;font-size:large;"><asp:Label ID="lblMakerCount" runat="server" Text=""></asp:Label></td>
                        <td style="text-align:center;font-weight:bold;color:Red;font-size:large;"><asp:Label ID="lblMakerHoldCount" runat="server" Text=""></asp:Label></td>
                        <td style="text-align:center;font-weight:bold;color:Red;font-size:large;"><asp:Label ID="lblAuthorCount" runat="server" Text=""></asp:Label></td>
                        <td style="text-align:center;font-weight:bold;color:Red;font-size:large;"><asp:Label ID="lblAuthorHoldCount" runat="server" Text=""></asp:Label></td>
                        </tr>
                        </table>
                        
                            <asp:Timer ID="pendencyTimer" runat="server" ontick="pendencyTimer_Tick" 
                                Interval="5000">
                            </asp:Timer>
                        </ContentTemplate>
                        </asp:UpdatePanel>
                    </legend>--%>
                    <div class="row">
                       <%-- <div class="form-group">
                            <div class="col-md-3">
                                <label for="CaseNo">
                                    Location</label>
                            </div>
                            <div class="col-md-3">
                                <asp:DropDownList ID="ddllocation" class="form-control" runat="server" SkinID="ddlSkin">
                                    <asp:ListItem Value="1">Mumbai</asp:ListItem>
                                    <asp:ListItem Value="2">Pune</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>--%>
                        <div class="form-group">
                            <div class="col-md-3">
                                <asp:HiddenField ID="HdnCase" runat="server" />
                                <asp:HiddenField ID="HdnWeb" runat="server" />
                                <asp:HiddenField ID="HdnAppno" runat="server" />
                            </div>
                            <div class="col-md-3">
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-md-3">
                                <label for="CaseNo">
                                </label>
                            </div>
                            <div class="col-md-3">
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="form-group">
                            <div class="col-md-3">
                                <label for="CaseNo">
                                    Stage</label>
                            </div>
                            <div class="col-md-3">
                                        <asp:DropDownList ID="ddlapptyp" class="form-control" runat="server" SkinID="ddlSkin"
                                            AutoPostBack="True" 
                                            onselectedindexchanged="ddlapptyp_SelectedIndexChanged">
                                            <asp:ListItem Value="0">--Select--</asp:ListItem>
                                            <%--<asp:ListItem Value="1">SFDC Screening</asp:ListItem>--%>
                                            <asp:ListItem Value="DATAENTRY">DATAENTRY</asp:ListItem>
                                            <asp:ListItem Value="CAM">CAM</asp:ListItem>
                                         
                                        </asp:DropDownList>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-md-3">
                              
                                <label for="CaseNo">
                                   Reinitiate Queue</label>
                     
  
                               </div>
                            <div class="col-md-3">
                                
                                        <asp:DropDownList ID="ddlQueue" class="form-control" runat="server" SkinID="ddlSkin"
                                            OnSelectedIndexChanged="ddlQueue_SelectedIndexChanged" AutoPostBack="True">
                                            <asp:ListItem>---SELECT---</asp:ListItem>
                                            <asp:ListItem>FTNR</asp:ListItem>
                                            <asp:ListItem>COMPLETED</asp:ListItem>
                                            <asp:ListItem>HOLD</asp:ListItem>
                                             <asp:ListItem>Reinitiate Cases</asp:ListItem>
                                        </asp:DropDownList>
                                    
                            </div>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="form-group">
                            <div class="col-md-3">
                                <label for="CaseNo">
                                   
                                    User Name</label>
                            </div>
                            <div class="col-md-3">
                              
                                       
                                        <asp:DropDownList ID="ddlUserlist" class="form-control" runat="server" SkinID="ddlSkin"
                                            Style="height: 30px">
                                        </asp:DropDownList>
                                    
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-md-2">
                                <asp:Button ID="btnsumbit" class="form-control btn-primary" runat="server" Text="Assign"
                                    ValidationGroup="ValidateALL" Width="80px" OnClick="btnsumbit_Click" AutoPostBack="True" />
                            </div>
                            <div class="col-md-2">
                                <asp:Button ID="btncancel" class="form-control btn-primary" runat="server" Text="Cancel"
                                    Width="80px" OnClick="btncancel_Click" AutoPostBack="True" />
                            </div>
                            <div class="col-md-2">
                                <asp:Button ID="btnExport" class="form-control btn-primary" runat="server" Text="Export"
                                    Width="80px" OnClick="btnExport_Click" AutoPostBack="True" />
                            </div>
                        </div>
                    </div>
                    <br />
                    <br />
                    <div class="row">
                        <div class="form-group">
                            <div class="col-md-3">
                            </div>
                        </div>
                        <div class="col-md-3">
                        </div>
                    </div>
                    <div class="row">
                        <div class="form-group">
                            <div class="col-md-3">
                            </div>
                            <div class="col-md-2">
                            </div>
                            <div class="col-md-2">
                            </div>
                        </div>
                    </div>
                    </label>
                </fieldset>
            </div>
        </div>
    </div>
    <br />
    <div class="container">
        <div class="row">
            <div class="col-md-12">
                <fieldset>
                    <div class="row">
                        <div class="form-group">
                            <div class="col-md-3">
                                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                    <ContentTemplate>
                                        <asp:Label ID="lblCount" runat="server" Visible="false" BackColor="#FFCC00" Font-Bold="true" Text="Label"></asp:Label>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <div class="col-md-3">
                            </div>
                        </div>
                    </div>
                </fieldset>
            </div>
        </div>
    </div>
    <div class="container">
        <div class="row">
            <div class="col-md-12">
                <fieldset>
                    <div class="row">
                        <div class="form-group">
                            <div class="col-md-3">
                                <asp:Panel ID="Panel1" runat="server" Height="313px" ScrollBars="Both" Width="900px">
                                            <asp:GridView ID="grdlos" runat="server" Style="background"
                                                class="table table-striped table-bordered table-hover table-responsive" 
                                                Width="910px" AutoGenerateColumns="False"
                                              >
                                                <Columns>
                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            <%--<input id="chkSelectAll" type="checkbox" />--%>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="chk" type="CheckBox" runat="server"/>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="Loan_App_No" HeaderText="Application No" />
                                                    <asp:BoundField DataField="LMS_Application_ID" HeaderText="LMS App ID" />
                                                    <asp:BoundField DataField="Application_Form_Number" HeaderText="APP Form No" />
                                                    <asp:BoundField DataField="LOB" HeaderText="LOB" />
                                                    <asp:BoundField DataField="Branch" HeaderText="Branch" />
                                                    <asp:BoundField DataField="Product_Scheme" HeaderText="Product_Scheme" />
                                                    <asp:BoundField DataField="Transaction_Type" HeaderText="Transaction_Type" />
                                                    <asp:BoundField DataField="Sub_Stage" HeaderText="Sub_Stage" />
                                                    <asp:BoundField DataField="Sub_Stage_Start_Time" 
                                                        HeaderText="Sub_Stage_Start_Time" />
                                                    <asp:BoundField DataField="Data_Entry_CompletedTime" 
                                                        HeaderText="Data_Entry_CompletedTime" />
                                                    <asp:BoundField DataField="Cam_Completed_Time" 
                                                        HeaderText="Cam_Completed_Time" />
                                                    <asp:BoundField DataField="Assign_Entry" HeaderText="Assign_Entry" />
                                                    <asp:BoundField DataField="AssignUserid" HeaderText="Assign Userid" />
                                                    <asp:BoundField DataField="CasesReinitiate" 
                                                        HeaderText="Cases Reinitiate Status " />
                                                </Columns>
                                            </asp:GridView>
                                </asp:Panel>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="form-group">
                            <div class="col-md-3">
                                <asp:ValidationSummary ID="ValidationSummary1" class="form-control" runat="server"
                                    ShowMessageBox="True" ShowSummary="False" ValidationGroup="validenrty" />
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="hidWrapper">
                            <div class="col-md-4">
                                <asp:HiddenField ID="HiddenField2" runat="server" />
                                <asp:HiddenField ID="HiddenField1" runat="server" />
                            </div>
                        </div>
                    </div>
                </fieldset>
            </div>
        </div>
    </div>
    <!-- Dialog start -->
    <div id="dialog-message">
    </div>
    <%--<meta http-equiv="refresh" content="180" />--%>
</asp:Content>
