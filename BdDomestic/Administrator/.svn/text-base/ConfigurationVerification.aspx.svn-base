<%@ Page Language="C#" MasterPageFile="~/Administrator/Admin_MasterPage.master"  AutoEventWireup="true" CodeFile="ConfigurationVerification.aspx.cs" Theme="SkinFile"  Inherits="ConfigurationVerification" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1"  Runat="Server">

  
     <script type="text/javascript" language="javascript">
       <!--
       function ClientValidate(source, arguments)
       {
//            alert(arguments.Value);
          if ((arguments.Value) == 0)
             arguments.IsValid=false;
          else
             arguments.IsValid=true;
       }
       // -->
    </script>
    
    <script type="text/javascript" language="javascript">
	function RadioChecked(param)
	{
		{ 
			var frm = document.forms[0];
			for (i=0; i<frm.length; i++) 
				{
				if (frm.elements[i].type == "radio")
					{
						if (param != frm.elements[i].id && (frm.elements[i].id.search("gvVerification")!=-1))
						{
						frm.elements[i].checked = false;
						//alert(frm.elements[i].id);
						}
					}
				
				}
		}
	
	}



		</script>
		 <script type="text/javascript" language="javascript">
		
		      
		 function Checkbox1(param)
		 {
		  var frm = document.forms[0];
		  for(i=0;i<frm.length;i++)
		  {
		  if(frm.elements[i].type == "Checkbox")
		  {
		  if(frm.elements[i].id.search("gvVerification").checked==false)
		  {
		  alert("Please select rows");
		  }
		  
		  }
		 }
		   //=false;
		    // for (var i = 0; i < CheckBoxIDs.length; i++)
		    // {
		     //var cb = document.getElementById(id);
		     
		    // if( cb.checked)
		    //{
		        //c=true;
		     //}
		     //}
		     //if(c==false)
		     //{
		     //alert("Please select rows");
		     //}
		 }
		 </script>
		<table id="tblMain" width="99%">
        <tr><td style="padding-left:8px">
		<fieldset><legend class="FormHeading" style="width: 157px">Configuration&nbsp; Verification</legend>
        <table align="center" style="width:100%" id="TABLE1">
            <tr>
                <td >
                    </td>
                <td >
                  </td>
                <td >
                    <asp:Label ID="lblMsg" runat="server" ForeColor="Red" Text="Label" Width="219px" Visible="False"></asp:Label></td>
                <td style="width: 2px" >
                 
                </td>
                <td >
                </td>
                <td >
                </td>
                <td  >
                </td>
                <td style="width: 49px" >
                </td>
                <td colspan="2">
                </td>
            </tr>
            <tr>
                <td  valign="top" style="height: 20px">
                    Template</td>
                <td  valign="top" style="height: 20px">
                    :</td>
                <td  valign="top" style="height: 20px">
                    <asp:DropDownList ID="ddlTemplateName" runat="server" SkinID="ddlSkin" OnDataBound="ddlTemplateName_DataBound" DataSourceID="sdsddl" DataTextField="template_name" DataValueField="template_id" OnSelectedIndexChanged="ddlTemplateName_SelectedIndexChanged" AutoPostBack="True">
                    </asp:DropDownList>
                    <asp:Label ID="lblTemplate" runat="server" Text="Label" Visible="False" Font-Bold="True"></asp:Label></td>
                <td style="height: 20px; width: 2px;" >
                </td>
                <td style="height: 20px" >
                    </td>
                <td  valign="top" style="height: 20px">
                    <asp:Label ID="lblval" runat="server" Text="Values" Visible="False" ></asp:Label></td>
                <td valign="top" style="height: 20px" >
                    <asp:Label ID="lblcolonval" runat="server" Text=":"></asp:Label></td>
                <td  valign="top">
                         <asp:RadioButtonList ID="rbtnValues" SkinID="rdblSkin" runat="server" RepeatDirection="Horizontal"
                         OnSelectedIndexChanged="rbtnValues_SelectedIndexChanged" Visible="False" AutoPostBack="True" Height="14px" Width="211px">
                        <asp:ListItem Value="N">Single Values</asp:ListItem>
                        <asp:ListItem Selected="True" Value="Y">Multiple Values</asp:ListItem>
                    </asp:RadioButtonList>
                    <asp:Label ID="lblMulorSingValue" runat="server" Text="Label" Font-Bold="True"></asp:Label></td>
                <td colspan="2" style="height: 20px">
                    </td>
            </tr>
            <tr>
                <td  valign="top">
                    Column &nbsp; &nbsp;Selection</td>
                <td  valign="top">
                    :</td>
                <td  valign="top">
                    <asp:RadioButtonList ID="rbtnColumnSelection" SkinID="rdblSkin" runat="server" RepeatDirection="Horizontal" AutoPostBack="True" OnSelectedIndexChanged="rbtnColumnSelection_SelectedIndexChanged" ValidationGroup="valgrp" Height="14px">
                        <asp:ListItem Value="Y" Selected="True">Multicolumn</asp:ListItem>
                        <asp:ListItem Value="N">SingleColumn</asp:ListItem>
                    </asp:RadioButtonList>
                    <asp:Label ID="lblColumnslection" runat="server" Text="Label" Visible="False" Font-Bold="True"></asp:Label></td>
                <td style="width: 2px" >
                </td>
                <td >
                    </td>
                <td  valign="top">
                    <asp:Label ID="lblSeparator" runat="server" Text="Separator" Visible="False" ></asp:Label></td>
                <td  valign="top" >
                    <asp:Label ID="lbls" runat="server" Text=":"></asp:Label></td>
                <td  valign="top">
                    &nbsp;<asp:TextBox ID="txtSepareator" SkinID="txtSkin" runat="server" Visible="False" MaxLength="1"></asp:TextBox></td>
                <td colspan="2">
                    &nbsp;</td>
            </tr>
              </table>
                <fieldset>
                
                
                
                
              <table>
            <tr>
                <td  valign="top">
                    &nbsp;Column Name</td>
                <td  valign="top">
                    :</td>
                <td  valign="top">
                    <asp:TextBox ID="txtStringTemplate" SkinID="txtSkin" runat="server" MaxLength="1000" ></asp:TextBox></td>
                <td >
                </td>
                <td >
                    </td>
                <td valign="top" >
                    </td>
                <td  >
                    </td>
                <td valign="top" >
                    &nbsp;</td>
                <td >
                </td>
            </tr>
            <tr>
                <td valign="top" style="height: 26px" >
                    <asp:Label ID="lblcomval" runat="server" Text="Comparing Value" Width="106px"></asp:Label></td>
                <td valign="top" style="height: 26px" >
                    :</td>
                <td style="height: 26px">
                <asp:TextBox ID="txtComparingValue" SkinID="txtSkin" runat="server" MaxLength="100"></asp:TextBox></td>
                <td colspan="1" style="height: 26px">
                </td>
                <td colspan="1" style="height: 26px">
                </td>
                <td colspan="1" valign="top" style="height: 26px">
                    </td>
                <td colspan="1" style="height: 26px" >
                    </td>
                <td colspan="7"  valign="top" style="height: 26px" >
                </td>
            </tr>
                  <tr>
                      <td valign="top">
                    </td>
                      <td>
                      </td>
                      <td>
                      </td>
                      <td colspan="1">
                      </td>
                      <td colspan="1">
                      </td>
                      <td colspan="1" valign="top">
                      </td>
                      <td colspan="1" >
                      </td>
                      <td colspan="7" valign="top">
                      </td>
                  </tr>
            <tr>
                <td >
                    <asp:SqlDataSource ID="sdsgvSingleVerification" runat="server" ConnectionString="<%$ ConnectionStrings:CMConnectionString %>" ProviderName="<%$ ConnectionStrings:CMConnectionString.ProviderName %>"></asp:SqlDataSource>
                    <asp:HiddenField ID="hidverificationid" runat="server" />
                </td>
                <td colspan="2" valign="top">
                    &nbsp; &nbsp; &nbsp;&nbsp;
                <asp:GridView ID="gvVerification" SkinID="gridviewNoSort" runat="server" AutoGenerateColumns="False" DataSourceID="sdsgvVerification" OnRowDataBound="gvVerification_RowDataBound" HorizontalAlign="Center" Width="300px">
                        <Columns>
                            <asp:TemplateField>
                            <ItemTemplate>
                            <asp:RadioButton ID="rbtngvVerification" SkinID="rdbSkin" runat="server" /><asp:HiddenField ID="hidValue" runat="server"
                               Value='<%# DataBinder.Eval(Container.DataItem, "verification_type_id") %>' />
                            </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="verification_type_code" HeaderText="Verificaion" />
                        </Columns>
                    </asp:GridView>
                    <asp:GridView ID="gvSingleVerification" SkinID="gridviewNoSort" runat="server" DataSourceID="sdsgvSingleVerification" AutoGenerateColumns="False" HorizontalAlign="Center" Width="300px">
                      <Columns>
                            <asp:TemplateField>
                            <ItemTemplate>
                            <asp:CheckBox ID="chkngvVerification" SkinId="chkSkin" runat="server" /><asp:HiddenField ID="hidValue" runat="server"
                               Value='<%# DataBinder.Eval(Container.DataItem, "verification_type_id") %>' /><asp:HiddenField ID="hidcode" runat="server"
                               Value='<%# DataBinder.Eval(Container.DataItem, "verification_type_code") %>' />
                            </ItemTemplate>
                            </asp:TemplateField>
                          <asp:BoundField DataField="verification_type_code" HeaderText="Verificaion" />
                        </Columns>
                    </asp:GridView>
                    &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp;
                </td>
                <td colspan="1" valign="middle">
                    <asp:Button ID="btnAddMultiColumn" SkinID="btnAddNewSkin" runat="server" Text="Add" OnClick="btnAddMultiColumn_Click" ValidationGroup="valgrp" Visible="False" />
                    <asp:Button ID="btnAddSingleColumn" runat="server" OnClick="btnAddSingleColumn_Click"
                        Text="Add" Visible="False" SkinID="btnAddNewSkin" ValidationGroup="valgrp" /></td>
                <td  colspan="2" valign="top">
                    &nbsp; &nbsp;
                    <asp:GridView ID="gvsinglleverificationEdit" SkinID="gridviewNoSort" runat="server"  OnSelectedIndexChanged="gvsinglleverificationEdit_SelectedIndexChanged" OnRowDeleting="gvsinglleverificationEdit_RowDeleting" HorizontalAlign="Center" Width="300px" OnRowDataBound="gvsinglleverificationEdit_RowDataBound">
                     <Columns>
                     
                      <asp:TemplateField>
                          <ItemStyle VerticalAlign="Top" />
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkTemplate" runat="server" CausesValidation="False" 
                                        CommandName="Delete"><img src="../images/icon_delete.gif" alt="Delete" style="border:0" /></asp:LinkButton>
                                        

                                </ItemTemplate>
                         </asp:TemplateField>
                     
                         <asp:TemplateField HeaderText="String in Template"> 
                        
                          <ItemTemplate>
                             <asp:Label ID="lblverificationid" runat="server" />
                                </ItemTemplate>
                                
                         </asp:TemplateField> 
                            

                         </Columns>
                    </asp:GridView>
                    <asp:GridView ID="gvStringVerification" SkinID="gridviewNoSort" runat="server" OnRowDeleting="gvStringVerification_RowDeleting" OnRowDataBound="gvStringVerification_RowDataBound" HorizontalAlign="Center" Width="300px" OnSorting="gvStringVerification_Sorting">
                    <Columns>
                       <asp:TemplateField>
                                <ItemStyle VerticalAlign="Top" />
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkTemplate" runat="server" CausesValidation="False" 
                                        CommandName="Delete"><img src="../images/icon_delete.gif" alt="Delete" style="border:0" /></asp:LinkButton>
                                        

                                </ItemTemplate>
                            </asp:TemplateField>
                           
                       </Columns>
                    </asp:GridView>
                <asp:GridView ID="gvSindgleColumnStringVerification" SkinID="gridviewNoSort" runat="server" OnRowDeleting="gvSindgleColumnStringVerification_RowDeleting" OnRowDataBound="gvSindgleColumnStringVerification_RowDataBound" HorizontalAlign="Center" Width="300px" OnSorting="gvSindgleColumnStringVerification_Sorting">
                     <Columns>
                       <asp:TemplateField>
                                <ItemStyle VerticalAlign="Top" />
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkTemplate" runat="server" CausesValidation="False" 
                                        CommandName="Delete"><img src="../images/icon_delete.gif" alt="Delete" style="border:0" /></asp:LinkButton>
                                        <asp:HiddenField ID="hidcode1" runat="server" />
                            

                                </ItemTemplate>
                            </asp:TemplateField>
                         
                           
                       </Columns>
                    </asp:GridView>
                    </td>
                <td colspan="4" valign="top">
                    </td>
                <td >
                </td>
            </tr>
            <tr>
                <td >
                </td>
                <td >
                </td>
                <td >
                </td>
                <td colspan="1" >
                    <asp:Button ID="btnSubmitt" runat="server" Text="Submit" SkinID="btnSubmitSkin" OnClick="btnSubmitt_Click" Visible="False" ValidationGroup="valsum" /></td>
                <td colspan="2" >
                    </td>
                <td  >
                </td>
                <td >
                    </td>
                <td colspan="2" >
                    </td>
                <td >
                </td>
            </tr>
        </table>
     </fieldset>


    
        <asp:SqlDataSource ID="sdsddl" runat="server" ConnectionString="<%$ ConnectionStrings:CMConnectionString %>"
            ProviderName="<%$ ConnectionStrings:CMConnectionString.ProviderName %>" SelectCommand="SELECT DISTINCT &#13;&#10;                      IMPORT_DATA_MASTER.TEMPLATE_ID, IMPORT_DATA_MASTER.TEMPLATE_NAME, &#13;&#10;                      IMPORT_VERIFICATION_MASTER.TEMPLATE_ID AS Expr1&#13;&#10;FROM         IMPORT_DATA_MASTER LEFT OUTER JOIN&#13;&#10;                      IMPORT_VERIFICATION_MASTER ON IMPORT_DATA_MASTER.TEMPLATE_ID = IMPORT_VERIFICATION_MASTER.TEMPLATE_ID&#13;&#10;WHERE     (IMPORT_VERIFICATION_MASTER.TEMPLATE_ID IS NULL)">
        </asp:SqlDataSource>
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" DisplayMode="List" ShowMessageBox="True" ShowSummary="False" ValidationGroup="valgrp" />
        &nbsp;
        <asp:CustomValidator ID="valDDL" runat="server" ControlToValidate="ddlTemplateName"
            Display="None" ErrorMessage="Please select Template Name" SetFocusOnError="True" ValidationGroup="valgrp" ClientValidationFunction="ClientValidate"></asp:CustomValidator>&nbsp;
        <asp:SqlDataSource ID="sdsgvVerification" runat="server" ConnectionString="<%$ ConnectionStrings:CMConnectionString %>" ProviderName="<%$ ConnectionStrings:CMConnectionString.ProviderName %>"></asp:SqlDataSource>
        <asp:HiddenField ID="hidcount" runat="server" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
        <asp:HiddenField ID="hidtxtStringTemplate" runat="server" />
            &nbsp;
        <asp:RequiredFieldValidator ID="valtxtComparingValue" runat="server" ErrorMessage="Please  put the comparing value" ControlToValidate="txtComparingValue" Display="None" SetFocusOnError="True" ValidationGroup="valgrp"></asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="valtxtStringTemplate" runat="server" ErrorMessage="Please put the Column Name " ControlToValidate="txtStringTemplate" Display="None" SetFocusOnError="True" ValidationGroup="valgrp"></asp:RequiredFieldValidator>&nbsp;
        <asp:HiddenField ID="hidstr" runat="server" />
            &nbsp;
        <asp:RequiredFieldValidator ID="valtxtseparator" runat="server" ErrorMessage="please Put the separator value" ControlToValidate="txtSepareator" Display="None" SetFocusOnError="True" ValidationGroup="valsum"></asp:RequiredFieldValidator>&nbsp;
            <asp:RequiredFieldValidator  ID="valtxtStringTemplate1" runat="server" ControlToValidate="txtStringTemplate"
                Display="None" ErrorMessage="Please put the column name" SetFocusOnError="True"
                ValidationGroup="valsum"></asp:RequiredFieldValidator> 
        <asp:SqlDataSource ID="sdsgvstringVerification" runat="server" ConnectionString="<%$ ConnectionStrings:CMConnectionString %>" ProviderName="<%$ ConnectionStrings:CMConnectionString.ProviderName %>"></asp:SqlDataSource>
            <asp:ValidationSummary ID="Valsubmitt" runat="server" DisplayMode="List" ShowMessageBox="True"
                ShowSummary="False" ValidationGroup="valsum" />
   
   </fieldset>
</td></tr></table>
 </asp:Content>