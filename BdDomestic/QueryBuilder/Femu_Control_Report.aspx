<%@ Page Language="C#" MasterPageFile="~/QueryBuilder/QueryBuilder.master" AutoEventWireup="true"
    CodeFile="Femu_Control_Report.aspx.cs" Inherits="QueryBuilder_Femu_Control_Report"
    Theme="SkinFile" Title="Femu Control Report" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<script language="javascript" type="text/javascript">
        function Resassign_to_Case(SelectedValue,SelectedTEXT)
        {
        //debugger;
            var ddlFEList=document.getElementById("<%=ddlFEList.ClientID%>");
            var grdvw=document.getElementById("<%=grdvw.ClientID%>");
            var lblTotalCount=document.getElementById("<%=lblTotalCount.ClientID%>");
            var SelectedInt=0;
           
            var i=0;
        
         if ((SelectedValue!="")&&(SelectedTEXT!=""))
                {
                  
                 if (grdvw!=null)
                 { 
                  
                    for (i=0;i<=grdvw.rows.length-1;i++)
                       {
                                var Value=i+1;
                                if (Value<9)
                                {
                                    var chkSelect=document.getElementById(grdvw.id +'_'+'ctl0'+ Value +'_chkSelect');
                                    var hdnSelectedValue=document.getElementById(grdvw.id +'_'+'ctl0'+ Value +'_hdnSelectedValue');
                                    var lblFEName=document.getElementById(grdvw.id +'_'+'ctl0'+ Value +'_lblFEName');
                                }
                                else
                                {
                                    var chkSelect=document.getElementById(grdvw.id +'_'+'ctl'+ Value +'_chkSelect');
                                    var hdnSelectedValue=document.getElementById(grdvw.id +'_'+'ctl'+ Value +'_hdnSelectedValue');
                                    var lblFEName=document.getElementById(grdvw.id +'_'+'ctl'+ Value +'_lblFEName');
                              
                                }
                        
                               if (chkSelect!=null)             
                               {
                                   // debugger;
                                    if ((chkSelect.checked==true) && (grdvw.rows[i].cells[12].innerText!="Accept"))
                                    {
                                            hdnSelectedValue.value=SelectedValue;
                                            lblFEName.innerText=SelectedTEXT;
                                            
                                    }
                                    else if ((chkSelect.checked==true) && (grdvw.rows[i].cells[12].innerText=="Accept"))
                                    {      
                                           grdvw.rows[i].cells[12].style.cssText="COLOR: red";
                                    }
                                    
                                     chkSelect.checked=false;
                                     ddlFEList.selectedIndex=0;                                  
                                                               
                               }                          
                        
                             if (lblFEName!=null)
                             {
                                 if (lblFEName.innerText!= "")
                                {
                                    SelectedInt = SelectedInt + 1;
                                }
                             }   
                                         
                       }  
                    }           
                
                }
                lblTotalCount.innerText="Total Records Found: " + grdvw.rows.length+" And "+SelectedInt +" were Reassigned to FE" ;
                
        }       

        function Validate_FEAssignment()
           {
           
                var ErrorMessage="";
                var ValueSelect=0;
                var ReturnValue=true;
                var lblMessage=document.getElementById("<%=lblMessage.ClientID%>");
                 
                var statusIndex_Info=document.getElementById("<%=ddlFEList.ClientID%>").selectedIndex;
                var status_Info=document.getElementById("<%=ddlFEList.ClientID%>").options[statusIndex_Info].text;
                var status_Value=document.getElementById("<%=ddlFEList.ClientID%>").options[statusIndex_Info].value;

                
                if (status_Info=="--Select--")
                {
                    ErrorMessage="Please select FE To Continue!"
                    ReturnValue=false;
                }
                else
                {
                   // debugger;
                    Resassign_to_Case(status_Value,status_Info);
                
                }               
                lblMessage.innerText=ErrorMessage;             
                 
                window.scrollTo(0,0);
                //return ReturnValue;     
                return false;
           }        


        function Validate_ReassignedCasesToFE()
        {
            //debugger;
            var ErrorMessage="";
            var ValueSelect=0;
            var ReturnValue=true;
            var lblMessage=document.getElementById("<%=lblMessage.ClientID%>");
        
            var grdvw=document.getElementById("<%=grdvw.ClientID%>");
            var i=0;
            if (grdvw!=null)
            { 
                //debugger;
                     if (grdvw.rows.length>0)
                     {
                                 for (i=0;i<=grdvw.rows.length-1;i++)
                                 {
                                         if (i==0)
                                         {
                                         
                                         }
                                         else if (grdvw.rows[i].cells[1].innerText!="")
                                         {  
                                            ValueSelect=1;
                                            break;
                                         }  
                                 }  
                     
                    }  
                 else 
                 {
                    ErrorMessage=" No Records selected for Save!";
                    ReturnValue=false;
                 }                        
            
                
           } 
           else 
                 {
                    ErrorMessage=" No Records selected for Save!";
                    ReturnValue=false;
                 }
           
        if (ValueSelect==0)    
        {
             ErrorMessage=" No Records Reassigned for Save!";
             ReturnValue=false;
        }                      
         
        lblMessage.innerText=ErrorMessage;             
             
        window.scrollTo(0,0);
        return ReturnValue;           
        
        }
        
</script> 
    <table border="0" cellpadding="0" cellspacing="0" visible="false" width="100%">
        <tr>
        </tr>
        <tr>
        </tr>
    </table>
    <table cellpadding="0" cellspacing="0" style="width: 918px">
        <tr>
            <td colspan="5">
                <asp:Label ID="lblMessage" runat="server" ForeColor="Red"
                    Font-Bold="True" CssClass="ErrorMessage" Width="100%"></asp:Label><br />
                <asp:ValidationSummary ID="vsValidate" runat="server" CssClass="ErrorMessage" ValidationGroup="ValGen"
                    Width="100%" />
            </td>
            <td colspan="1" style="height: 61px;">
            </td>
            <td colspan="1" style="height: 61px; width: 72px;">
                <asp:TextBox ID="txtFromDate" runat="server" SkinID="txtSkin" Width="43px" Visible="False">01/01/2005</asp:TextBox></td>
            <td colspan="1" style="width: 103px; height: 61px;">
            </td>
        </tr>
        <tr>
            <td class="TableHeader" colspan="8" style="height: 55px">
                &nbsp;<strong><span>Femu Control Report</span></strong></td>
        </tr>
        <tr>
            <td colspan="2">
                <table border="0" cellpadding="0" cellspacing="0" style="width: 227px">
                    <tr>
                        <td>
                            <strong>&nbsp;CaseAssignDate </strong>
                        </td>
                        <td style="width: 100px; height: 42px">
                            <asp:TextBox ID="txtToDate" runat="server" SkinID="txtSkin" Width="111px" ValidationGroup="ValGen"></asp:TextBox></td>
                        <td style="width: 100px; height: 42px;">
                            &nbsp;<img id="Img1" alt="Calendar" onclick="popUpCalendar(this, document.all.<%=txtToDate.ClientID%>, 'dd/mm/yyyy', 0, 0);"
                                src="../Images/SmallCalendar.png" /></td>
                        <td style="width: 100px; height: 42px; text-align: center">
                            <asp:RequiredFieldValidator ID="rq_txtAssignDate" runat="server" ControlToValidate="txtToDate"
                                ErrorMessage="Please enter Assign date!" ValidationGroup="ValGen" Width="17px">?</asp:RequiredFieldValidator></td>
                    </tr>
                </table>
            </td>
            <td colspan="2">
                <strong>
                    <table style="width: 174px" cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                                ProductType&nbsp;<strong></strong></td>
                            <td>
                                <asp:DropDownList ID="ddlprduct1" runat="server" SkinID="ddlSkin" Width="102px" ValidationGroup="ValGen">
                                    <asp:ListItem>(Select)</asp:ListItem>
                                    <asp:ListItem>CC</asp:ListItem>
                                    <asp:ListItem>KYC</asp:ListItem>
                                    <asp:ListItem>RL</asp:ListItem>
                                    <asp:ListItem Value="CEL">CELLULAR</asp:ListItem>
                                </asp:DropDownList></td>
                            <td style="text-align: center">
                                <asp:RequiredFieldValidator ID="rq_ddlprduct1" runat="server" ControlToValidate="ddlprduct1"
                                    ErrorMessage="Please Select Product to continue...." InitialValue="(Select)"
                                    ValidationGroup="ValGen" Width="18px">?</asp:RequiredFieldValidator></td>
                        </tr>
                    </table>
                </strong>
            </td>
            <td style="width: 16px">
            </td>
            <td>
            </td>
            <td colspan="2">
                <table cellpadding="0" cellspacing="0">
                    <tr>
                        <td>
                            <strong>Case Status</strong>
                        </td>
                        <td style="width: 100px; height: 22px;">
                            <asp:DropDownList ID="DDLCaseSta" runat="server" SkinID="ddlSkin" Width="102px" ValidationGroup="ValGen">
                                <asp:ListItem>(Select)</asp:ListItem>
                                <asp:ListItem>All</asp:ListItem>
                                <asp:ListItem>Accept</asp:ListItem>
                                <asp:ListItem>Reject</asp:ListItem>
                                <asp:ListItem Value=" ">Pending</asp:ListItem>
                            </asp:DropDownList>
                            &nbsp;
                        </td>
                        <td style="width: 39px; height: 22px; text-align: center">
                            <asp:RequiredFieldValidator ID="rq_DDLCaseSt" runat="server" ControlToValidate="DDLCaseSta"
                                ErrorMessage="Please Select Case Status to continue...." InitialValue="(Select)"
                                ValidationGroup="ValGen" Width="17px">?</asp:RequiredFieldValidator></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="8">
                &nbsp;
                <asp:Panel ID="Panel1" runat="server" Height="200px" Width="900px" ScrollBars="Vertical"
                    BorderColor="Gray" BorderStyle="Solid" BorderWidth="1px">
                    <asp:GridView ID="grdvw" runat="server" SkinID="gridviewNoSort" Width="775px" AutoGenerateColumns="False">
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <table cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td style="height: 38px">
                                                &nbsp
                                                <asp:CheckBox ID="chkSelect" runat="server" SkinID="chkSkin" /></td>
                                            <td style="width: 100px; text-align: left; height: 38px;">
                                                <asp:HiddenField ID="hdnSelectedValue" runat="server" />
                                            </td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Re Assigned FE Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblFEName" runat="server"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="FullName" HeaderText="FE Name" />
                            <asp:BoundField DataField="Product" HeaderText="Product Type" />
                            <asp:BoundField DataField="Client_Name" HeaderText="Client" />
                            <asp:BoundField DataField="Centre_Name" HeaderText="Centre" />
                            <asp:BoundField DataField="CASE_REC_DATETIME" HeaderText="Case Received" />
                            <asp:BoundField DataField="Case_Id" HeaderText="Case Id" />
                            <asp:BoundField DataField="Ref_no" HeaderText="Ref no" />
                            <asp:BoundField DataField="ApplicantName" HeaderText="Applicant Name" />
                            <asp:BoundField DataField="Verification_Type" HeaderText="Verification Type" />
                            <asp:BoundField DataField="Address" HeaderText="Address" />
                            <asp:BoundField DataField="Case_Status" HeaderText="Case Status" />
                            <asp:BoundField DataField="RejectType" HeaderText="Reject Type" />
                            <asp:BoundField DataField="Reject_Reason" HeaderText="Reject Reason" />
                        </Columns>
                    </asp:GridView>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td colspan="8" style="height: 48px">
                <table width="100%">
                    <tr>
                        <td style="width: 1px">
                            <asp:DropDownList ID="ddlFEList" runat="server" ValidationGroup="ValGen" SkinID="ddlSkin">
                            </asp:DropDownList></td>
                        <td style="width: 100px">
                            <asp:Button ID="btnSetValue" runat="server" OnClick="btnSetValue_Click" SkinID="btn"
                                Text="Assign to FE" ValidationGroup="ValGen" /></td>
                        <td style="width: 100px; text-align: center;">
                            <asp:Button ID="ClearAssignment" runat="server" SkinID="btn" Text="Clear Assignment" Visible="False" /></td>
                        <td colspan="2" style="text-align: right">
                            <asp:Label ID="lblTotalCount" runat="server" SkinID="lblError"></asp:Label></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="3" style="height: 38px">
                <table>
                    <tr>
                        <td style="width: 26px; height: 26px;">
                        </td>
                        <td style="width: 100px; height: 26px;">
                            <asp:Button ID="btnsearch" Text="Generate" runat="server" OnClick="btnsearch_Click"
                                SkinID="btn" ValidationGroup="ValGen" /></td>
                        <td style="width: 100px; height: 26px;">
                            <asp:Button ID="btnExport" runat="server" Text="Export To Excel" Width="110px" OnClick="btnExport_Click"
                                SkinID="btn" /></td>
                        <td style="width: 100px; height: 26px;">
                            <asp:Button ID="btnResignedCases" runat="server" OnClick="btnResignedCases_Click"
                                SkinID="btn" Text="Save Resign Cases" ToolTip="Resign Selected Case to selected FE" /></td>
                        <td style="width: 100px; height: 26px;">
                            <asp:Button ID="btnClose" runat="server" SkinID="btn" Text="Close" /></td>
                    </tr>
                </table>
                &nbsp;</td>
            <td style="width: 100px; height: 38px;">
            </td>
            <td style="width: 16px; height: 38px;">
            </td>
            <td style="height: 38px">
            </td>
            <td style="width: 72px; height: 38px;">
            </td>
            <td style="width: 103px; height: 38px;">
            </td>
        </tr>
        <tr>
            <td colspan="8" style="visibility: hidden">
            </td>
        </tr>
    </table>
                <table border="0" id="tblExport" cellpadding="0" cellspacing="0" visible="true" runat="server"
                    width="100%">
                    <tr>
                        <td style="visibility: hidden;">
                            <asp:GridView ID="grvReport" runat="server" SkinID="gridviewNoSort" Width="0%" Height="0%">
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
</asp:Content>
