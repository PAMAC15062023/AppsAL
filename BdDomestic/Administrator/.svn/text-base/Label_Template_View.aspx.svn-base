<%@ Page Language="C#" MasterPageFile="~/Administrator/Admin_MasterPage.master" Theme="SkinFile" AutoEventWireup="true" CodeFile="Label_Template_View.aspx.cs" Inherits="Administrator_Label_Template_View" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script type="text/javascript" language="javascript">
//function show()
//{
//    var ddlId=document.getElementById('<%=ddlProduct.ClientID %>');   

//    if(ddlId.value=="1014")
//    { 
//      alert("ashish");
//      return true;
////     var tableId= document.getElementById('Tbl_other');
////     tableId.style.display='none'; 
////     alert("ashish");
////     return true; 
//     } 
//}
//function Test()
//{
//    alert("OK");
//    return false;
//}
</script>
<table id="tblMain" width="99%">
        <tr><td style="padding-left:8px">
 <fieldset><legend class="FormHeading">Create Template</legend>
<table border="0" cellpadding="0" cellspacing="0">
<tr>
<td >
<table>
            <tr>
            
            
            <td  >
               <asp:RadioButtonList ID="rbtnlst" runat="server" AppendDataBoundItems="True"
                    Width="373px" RepeatLayout="Flow" AutoPostBack="True" OnSelectedIndexChanged="rbtnlst_SelectedIndexChanged">
                    <asp:ListItem Value="L">Template For Label</asp:ListItem>
                    <asp:ListItem Value="S">Template For Sms</asp:ListItem>
                </asp:RadioButtonList></td>
                <td></td>
                
                
            
            </tr>
            </table>
          
        <table border="0" cellpadding="0" cellspacing="0"> 
            <tr>
                <td >
                    Activity<span style="color: #ff3366">*</span>:</td>
                  <td ><asp:DropDownList ID="ddl_activity" SkinID="ddlSkin"  runat="server" OnSelectedIndexChanged="ddl_activity_SelectedIndexChanged1" AutoPostBack="True" Width="138px">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td >
                    Product<span style="color: #ff3366">*</span>:</td> 
                   <td><asp:DropDownList ID="ddlProduct" SkinID="ddlSkin" runat="server" AutoPostBack="True"
                       AppendDataBoundItems="True"  OnSelectedIndexChanged="ddlProduct_SelectedIndexChanged1" Width="138px" OnPreRender="ddlProduct_PreRender">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td style="height: 22px" >
                    Client<span style="color: #ff3366">*</span>:</td> 
                  <td style="height: 22px" ><asp:DropDownList ID="ddlclient" SkinID="ddlSkin" runat="server" Width="138px" >
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td >Verification Type<span style="color: #ff3366">*</span>:
                </td> 
                    <td > <asp:DropDownList ID="ddlVerify" SkinID="ddlSkin" runat="server" Width="138px" >
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td >Template Name<span style="color: #ff3366">* </span>:</td> 
                <td> <asp:TextBox ID="txtTempName"  SkinID="txtSkin" runat="server" Width="134px" MaxLength="20" ></asp:TextBox></td>
                </tr>
            <tr>
                <td>Line* :</td> 
                <td> <asp:DropDownList ID="ddlLine" SkinID="ddlSkin" runat="server" OnSelectedIndexChanged="ddlLine_SelectedIndexChanged"
                        AutoPostBack="True" OnDataBound="ddlLine_DataBound">
                        <asp:ListItem>1</asp:ListItem>
                        <asp:ListItem>2</asp:ListItem>
                        <asp:ListItem>3</asp:ListItem>
                        <asp:ListItem>4</asp:ListItem>
                        <asp:ListItem>5</asp:ListItem>
                        <asp:ListItem>6</asp:ListItem>
                        <asp:ListItem>7</asp:ListItem>
                        <asp:ListItem>8</asp:ListItem>
                        <asp:ListItem>9</asp:ListItem>
                        <asp:ListItem>10</asp:ListItem>
                        <asp:ListItem>11</asp:ListItem>
                        <asp:ListItem>12</asp:ListItem>
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td >
                    Character:</td> 
                   <td>  <asp:TextBox ID="txtchar" SkinID="txtSkin" runat="server"  Width="109px" ></asp:TextBox></td>
            </tr>
            <tr>
                <td >Additional Field 1 :</td>
                 <td> <asp:TextBox ID="txtADD1" SkinID="txtSkin" runat="server" Width="134px"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Additional Field 2:</td> 
                    <td> <asp:TextBox ID="txtADD2" SkinID="txtSkin" runat="server" Width="134px"></asp:TextBox></td>
            </tr>
          
          </table>
           
    <%--<tr>
        <td colspan="2">--%>
            <table id="Tbl_other" runat="server" >
                <tr>
                    <td style="width: 81px" >
                        Sr No: </td> 
                        <td>                       
                    <asp:CheckBox ID="chkSrNo"  SkinID="chkSkin" runat="server" /></td>
                </tr>
                <tr>
                    <td style="width: 81px" >Lable Printing Date:</td> 
                       <td>  <asp:CheckBox ID="chkDate" SkinID="chkSkin" runat="server" /></td>
                </tr>
                <tr>
                    <td style="width: 81px" >
                        All Verification Type:</td> 
                        <td> <asp:CheckBox ID="ChkVerify"  SkinID="chkSkin" runat="server" /> </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td colspan="2" >
            <table border="0" cellpadding="0" cellspacing="0" width="80%">
                <tr>
                    <td colspan="2" style="height: 14px" >
                        &nbsp;&nbsp;<asp:Label ID="lblmessage" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label></td>
                    <td style="height: 14px" >
                        &nbsp;<asp:Label ID="lblError" runat="server" SkinID="lblSkin" Font-Bold="True" ForeColor="Red"></asp:Label></td>
                </tr>
            </table>
            <strong><span style="font-size: 9pt; color: red">
            * Please do not Select Date Field<br />
            * Please do not Select Case Id while Creating Template for SMS<br />
              <asp:Label ID="lbltemplatetype" runat="server" Width="502px" Font-Bold="True" ForeColor="Red"></asp:Label><br />
              <asp:Label ID="lblMsg" runat="server" Width="61px" Font-Bold="True" ForeColor="Red"></asp:Label><br />
                <asp:Button ID="Button1" SkinID="btnSaveSkin"    runat="server" OnClick="BTNSUBMIT_Click" Text="Submit" Width="103px" ValidationGroup="grpTemplate" /><asp:Button ID="Button2" SkinID="btnBackSkin" runat="server" OnClick="Button1_Click"  /></span></strong></td>
    </tr>
            
            <tr>
                <td colspan="3">
                    <asp:GridView ID="gvMap" runat="server" SkinID="gridviewSkin"  AutoGenerateColumns="False" OnRowDataBound="gvMap_RowDataBound" Width="505px">
                        <Columns>
                            <asp:BoundField DataField="name" HeaderText="Field" />
                            <asp:TemplateField HeaderText="SerialNo.">
                                <ItemTemplate>
                                    <asp:DropDownList ID="ddlserial" SkinID="ddlSkin"  runat="server">
                                     
                                    </asp:DropDownList>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Line">
                                <ItemTemplate>
                                    <asp:DropDownList ID="ddlline" SkinID="ddlSkin" runat="server" >
                                    </asp:DropDownList>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Select Field">
                                <EditItemTemplate>
                                    <asp:CheckBox ID="CheckBox1" SkinID="chkSkin" runat="server" />
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:CheckBox ID="CheckBox1" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="table_name" HeaderText="Table" />
                        </Columns>
                    </asp:GridView>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td >
                    <asp:Button ID="BTNSUBMIT" SkinID="btnSaveSkin"    runat="server" OnClick="BTNSUBMIT_Click" Text="Submit" Width="103px" ValidationGroup="grpTemplate" />
                    <asp:Button ID="BtnCancel" SkinID="btnBackSkin" runat="server" OnClick="Button1_Click"  /></td>
                <td >
                    &nbsp;<asp:ValidationSummary ID="vsTemplate" runat="server" ShowMessageBox="True" ShowSummary="False"
                        ValidationGroup="grpTemplate" />
                </td>
            </tr>
    <tr>
        <td colspan="2">
                    <asp:RequiredFieldValidator ID="rfvActivity" runat="server" ControlToValidate="ddl_activity"
                        Display="None" ErrorMessage="Select Activity" SetFocusOnError="True" ValidationGroup="grpTemplate"></asp:RequiredFieldValidator>
                    <asp:RequiredFieldValidator ID="rfvProduct" runat="server" ControlToValidate="ddlProduct"
                        Display="None" ErrorMessage="Select Product" SetFocusOnError="True" ValidationGroup="grpTemplate"></asp:RequiredFieldValidator>
                    <asp:RequiredFieldValidator ID="rfvClient" runat="server" ControlToValidate="ddlclient"
                        Display="None" ErrorMessage="Select Client" SetFocusOnError="True" ValidationGroup="grpTemplate"></asp:RequiredFieldValidator>
                    <asp:RequiredFieldValidator ID="rfvVerification" runat="server" ControlToValidate="ddlVerify"
                        Display="None" ErrorMessage="Select Verification Type" SetFocusOnError="True"
                        ValidationGroup="grpTemplate"></asp:RequiredFieldValidator>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtTempName"
                        Display="None" ErrorMessage="Enter Template Name" ValidationGroup="grpTemplate"></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="cvTxtCharacter" runat="server" ControlToValidate="txtchar"
                        ErrorMessage="Please enter numeric values" Operator="DataTypeCheck" SetFocusOnError="True"
                        Type="Integer" ValidationGroup="grpTemplate"></asp:CompareValidator></td>
    </tr>
        </table>
    <asp:HiddenField ID="hidTemplateID" runat="server" />
     </fieldset>
 </td></tr></table>
</asp:Content>

