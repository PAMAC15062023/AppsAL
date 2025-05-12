<%@ Page Language="C#" MasterPageFile="~/Pages/MasterPage.master" AutoEventWireup="true" CodeFile="DiscrepancyUpdate.aspx.cs" Inherits="Pages_DiscrepancyUpdate" Title="Discrepancy Update" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script language="javascript" type="text/javascript" for="window" event="onload">
// <!CDATA[
return window_onload()
// ]]>
</script>


 <script language="javascript" type="text/javascript">
  
 function CheckValicationOn_AddDiscrepancy()
 {
          //debugger;
          var lblMsg=document.getElementById("Ctl00_ContentPlaceHolder1_lblMsg");
          var hdnNanoApplicationNO=document.getElementById("Ctl00_ContentPlaceHolder1_hdnNanoApplicationNO");
          var ddlDiscrepancy=document.getElementById("Ctl00_ContentPlaceHolder1_ddlDiscrepancy");
          var Message="";
          var returnValue=true;

          if (hdnNanoApplicationNO.value=="")
          {
            Message="ApplicationNo not Maintained,Please enter again!!";
            returnValue=false;
          }
         
          if (ddlDiscrepancy.value=="--Select--")
          {
          Message+="Please select Discrepancy to add!";
          returnValue=false;
          }
           if (Message!="")
          {
           lblMsg.innerText=Message;
          }
          
          return returnValue; 
 }
    function Check_Discrepancy()
    {
   // debugger;
    var ddlDiscrepancy=document.getElementById("Ctl00_ContentPlaceHolder1_ddlDiscrepancy");
    var txtDiscrepancyRemark=document.getElementById("Ctl00_ContentPlaceHolder1_txtDiscrepancyRemark");
       
               
              
          if (ddlDiscrepancy.value==20)
          {
               txtDiscrepancyRemark.style.visibility="visible"; //VISIBILITY: hidden        
          }
          else
          {
           txtDiscrepancyRemark.style.visibility="hidden";
           txtDiscrepancyRemark.value=""; //VISIBILITY: hidden        
        
          }
          
    
    }
 
 


function window_onload() 
{
var txtDiscrepancyRemark=document.getElementById("Ctl00_ContentPlaceHolder1_txtDiscrepancyRemark");
var ddlDiscrepancy=document.getElementById("Ctl00_ContentPlaceHolder1_ddlDiscrepancy");
    
    if (ddlDiscrepancy!=null)
    {
          if (ddlDiscrepancy.value!=20)
          {
               txtDiscrepancyRemark.style.visibility="hidden"; //VISIBILITY: hidden        
                txtDiscrepancyRemark.value="";
            }
        }
}

 </script>
     &nbsp;<asp:Label ID="lblMessage" runat="server" Visible="False"></asp:Label>
    <asp:Label ID="lblMsg" runat="server"></asp:Label>
    <table border="0" cellspacing="0" style="width: 100%; height: 45%">
        <tr>
            <td colspan="2" style="height: 28px">
                <table style="width: 100%; height: 100%">
                    <tr>
                        <td class="TableHeader" colspan="5" style="height: 15px">
                            &nbsp;Enter Nano Application No Here</td>
                    </tr>
                    <tr>
                        <td class="TableTitle">
                            Nano Application No</td>
                        <td>
                            <asp:TextBox ID="txtNanoApplicationNo" runat="server" MaxLength="100"></asp:TextBox>
                <asp:RequiredFieldValidator ID="Rq_NanoApplicationNo" runat="server" BorderColor="Red"
                    BorderWidth="0px" ControlToValidate="txtNanoApplicationNo" ToolTip="Please enter Application No to Continue"
                    ValidationGroup="RetrieveRecord">?</asp:RequiredFieldValidator></td>
                        <td style="width: 100px">
                        </td>
                        <td style="width: 100px">
                        </td>
                        <td style="width: 100px">
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 15px">
                        </td>
                        <td style="height: 15px">
                        </td>
                        <td style="width: 100px; height: 15px">
                        </td>
                        <td style="width: 100px; height: 15px">
                        </td>
                        <td style="width: 100px; height: 15px">
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Button ID="btnRetreive" runat="server" OnClick="btnRetreive_Click" Text="Retreive"
                    Width="100px" ValidationGroup="RetrieveRecord" />
                            <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click"
                        Text="Close" /></td>
                        <td style="width: 100px">
                        </td>
                        <td style="width: 100px">
                        </td>
                        <td style="width: 100px">
                        </td>
                    </tr>
                    <tr>
                        <td colspan="5">
                        </td>
                    </tr>
                    <tr>
                        <td class="TableHeader" colspan="5">
                            &nbsp;Application Info</td>
                    </tr>
                    <tr>
                        <td colspan="5" style="height: 15px">
                            <asp:GridView ID="grv_ApplicationInfo" runat="server" Width="100%">
                            </asp:GridView>
                        </td>
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
                        <td style="width: 100px">
                        </td>
                    </tr>
                </table>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td colspan="2" style="height: 28px">
                &nbsp;&nbsp;</td>
            <td>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:HiddenField ID="hdnNanoApplicationNO" runat="server" />
                <asp:Panel ID="pnlAddDiscrepancy" runat="server" Width="100%" Visible="False">
                    <table border="0" cellspacing="0" style="width: 100%; height: 100%">
                        <tr>
                            <td colspan="3" style="height: 16px" class="TableHeader">
                                &nbsp;Application Discrepancy Add</td>
                        </tr>
                        <tr>
                            <td style="width: 97px; height: 16px" class="TableTitle">
                                &nbsp;Discrepancy</td>
                            <td style="width: 100px; height: 16px" class="TableTitle">
                &nbsp;Remark</td>
                            <td style="width: 100px; height: 16px">
                            </td>
                        </tr>
                        <tr>
                            <td>
                <asp:DropDownList ID="ddlDiscrepancy" runat="server" ValidationGroup="AddRecord">
                </asp:DropDownList>
                                </td>
                            <td>
                <asp:TextBox ID="txtDiscrepancyRemark" runat="server" Width="242px" MaxLength="100"></asp:TextBox>
                                </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 97px">
                            </td>
                            <td style="width: 100px">
                            </td>
                            <td style="width: 100px">
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" class="TableHeader">
                <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" Text="Add New Discrepancy" Width="159px" ValidationGroup="AddRecord" OnClientClick="javascript:return CheckValicationOn_AddDiscrepancy()" /></td>
                            <td style="width: 100px">
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 97px">
                            </td>
                            <td style="width: 100px">
                            </td>
                            <td style="width: 100px">
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3" style="height: 14px">
                <asp:GridView ID="gridDiscrepancyList" runat="server" Width="100%">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="lnk_ChangeStatus" runat="server" OnClick="lnk_ChangeStatus_Click" CommandArgument='<%# Eval("AutoId") %>' ToolTip="Update Status to Close">Update Status</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                            </td>
                        </tr>
                    </table>
                    &nbsp;
                    </asp:Panel>
                &nbsp;&nbsp;
            </td>
            <td style="height: 125px">
            </td>
        </tr>
    </table>
</asp:Content>

