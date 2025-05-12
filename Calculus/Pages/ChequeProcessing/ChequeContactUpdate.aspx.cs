using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class Pages_ChequeProcessing_ChequeContactUpdate : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
          try
        {
            string[] arrDBFFilesName = new string[4];

            arrDBFFilesName[0] = "othbkchq.dbf";
            arrDBFFilesName[1] = "invldchq.dbf";
            arrDBFFilesName[2] = "upctry.dbf";
            arrDBFFilesName[3] = "validchq.dbf";

            for (int i = 0; i <= arrDBFFilesName.Length - 1; i++)
            {
                DataTable dt = new DataTable();
                dt=Get_ChequeInfo(arrDBFFilesName[i].Trim());
                if (dt.Rows.Count > 0)
                {
                    AssignValuetoControl(dt);
                    Display_Error("Record Founds " + dt.Rows.Count, "Success");
                    break;
                }
                else
                {
                    Clear_Controls(); 
                    Display_Error("No Records Found!", "Error");   
                }


            }
        }
        catch (Exception ex)
        {
            Display_Error(ex.Message, "Error");
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            Update_ChequeNo();
            Clear_Controls();
        }
        catch (Exception ex)
        {
            Display_Error(ex.Message, "Error");
        }

    }

    private DataTable  Get_ChequeInfo(string DBFName)
    {
        try
        {

            string DBFMaster = Convert.ToString(ConfigurationSettings.AppSettings["MasterDBFFiles"]); //this.Request.PhysicalApplicationPath;

            string pFilePath = DBFMaster +DBFName.Trim();

            System.Data.Odbc.OdbcConnection oConn = new System.Data.Odbc.OdbcConnection();
            oConn.ConnectionString = @"Driver={Microsoft Visual FoxPro Driver};SourceType=DBF;SourceDB=" + Convert.ToString(ConfigurationSettings.AppSettings["MasterDBFFiles"]) + ";Exclusive=No; Collate=Machine;NULL=NO;DELETED=NO;BACKGROUNDFETCH=NO;";
            oConn.Open();
            System.Data.Odbc.OdbcCommand oCmd = oConn.CreateCommand();

            string[] strTableName = pFilePath.Split('\\');
            string TableName = "";
            if (strTableName.Length > 0)
            {
                TableName = strTableName[strTableName.Length - 1];

            }
            pFilePath = pFilePath.Trim();
            pFilePath = pFilePath.Replace("\\\\", "\\");

            if (DBFName == "othbkchq.dbf")
            {
                oCmd.CommandText = @"  Select DTOC(pickup_dt) as PickupDate,Bank,dbMst.Dropname as Dropname,chq_amt,DTOC(chq_dt) as ChequeDate , '1' as TableID, Reason,Contact_de    from othbkchq.dbf invalid left outer join DrpBxMst.dbf dbMst on invalid.Drop_code=dbMst.Dropcode  where Chq_no Like '%" + txtChequeNo.Text.Trim() + "%' And between(pickup_dt,{^" + Get_DateFormat(txtPickupdate.Text.Trim(), "yyyy/MM/dd") + "},{^" + Get_DateFormat(txtPickupdate.Text.Trim(), "yyyy/MM/dd") + "}) ";
            }
            else if (DBFName == "invldchq.dbf")
            {
                oCmd.CommandText += @" Select DTOC(pickup_dt) as PickupDate,'' as Bank,dbMst.Dropname as Dropname,chq_amt,DTOC(chq_dt) as ChequeDate, '3' as TableID,Reason ,Contact_de  from invldchq.dbf invalid left outer join DrpBxMst.dbf dbMst on invalid.Col_pt_cd=dbMst.Dropcode  where Chq_no Like '%" + txtChequeNo.Text.Trim() + "%' And between(pickup_dt,{^" + Get_DateFormat(txtPickupdate.Text.Trim(), "yyyy/MM/dd") + "},{^" + Get_DateFormat(txtPickupdate.Text.Trim(), "yyyy/MM/dd") + "})";
           
            }
            else if (DBFName == "upctry.dbf")
            {
                oCmd.CommandText += @" Select DTOC(pickup_dt) as PickupDate,Bank,dbMst.Dropname as Dropname, chq_amt,DTOC(chq_dt) as ChequeDate,'2' as TableID, '' as  Reason ,Contact_de  from upctry.dbf  invalid left outer join DrpBxMst.dbf dbMst on invalid.Drop_code=dbMst.Dropcode  where Chq_no Like '%" + txtChequeNo.Text.Trim() + "%' And between(pickup_dt,{^" + Get_DateFormat(txtPickupdate.Text.Trim(), "yyyy/MM/dd") + "},{^" + Get_DateFormat(txtPickupdate.Text.Trim(), "yyyy/MM/dd") + "}) ";           
            }
            else if (DBFName == "validchq.dbf")
            {
                oCmd.CommandText += @" Select DTOC(pickup_dt) as PickupDate,BankMst.bankname as bank ,chq_amt,DTOC(chq_dt) as ChequeDate,'4' as TableID, '' as  Reason ,Contact_de  from validchq.dbf  invalid   left outer join BankMst.dbf BankMst on BankMst.bankid=invalid.bank_id  where Chq_no Like '%" + txtChequeNo.Text.Trim() + "%' And between(pickup_dt,{^" + Get_DateFormat(txtPickupdate.Text.Trim(), "yyyy/MM/dd") + "},{^" + Get_DateFormat(txtPickupdate.Text.Trim(), "yyyy/MM/dd") + "}) ";
            }
            //oCmd.CommandText += @" Union Select DTOC(pickup_dt) as PickupDate,dbMst.Dropname as Dropname, chq_amt,DTOC(chq_dt) as ChequeDate,'2' as TableID,'' as reason,'' as bank   from upctry.dbf  invalid left outer join DrpBxMst.dbf dbMst on invalid.Drop_code=dbMst.Dropcode  where Chq_no Like '%" + txtChequeNo.Text.Trim() + "%' And between(pickup_dt,{^" + Get_DateFormat(txtPickupdate.Text.Trim(), "yyyy/MM/dd") + "},{^" + Get_DateFormat(txtPickupdate.Text.Trim(), "yyyy/MM/dd") + "}) ";
            //oCmd.CommandText += @" Union Select DTOC(pickup_dt) as PickupDate,dbMst.Dropname as Dropname,chq_amt,DTOC(chq_dt) as ChequeDate, '3' as TableID,reason ,'' as bank  from invldchq.dbf invalid left outer join DrpBxMst.dbf dbMst on invalid.Col_pt_cd=dbMst.Dropcode  where Chq_no Like '%" + txtChequeNo.Text.Trim() + "%' And between(pickup_dt,{^" + Get_DateFormat(txtPickupdate.Text.Trim(), "yyyy/MM/dd") + "},{^" + Get_DateFormat(txtPickupdate.Text.Trim(), "yyyy/MM/dd") + "})";                      
            //oCmd.CommandText += @" union Select DTOC(pickup_dt) as PickupDate,'' as Bank,dbMst.Dropname as Dropname,Chq_no as ChequeNo,chq_amt,DTOC(chq_dt) as ChequeDate ,'' as Reason, Contact_de,'3' as TableID  from invldchq.dbf invalid2 left outer join DrpBxMst.dbf dbMst on invalid2.col_pt_cd=dbMst.Dropcode where Chq_no Like '%" + txtChequeNo.Text.Trim() + "%' And between(pickup_dt,{^" + Get_DateFormat(txtPickupdate.Text.Trim(), "yyyy/MM/dd") + "},{^" + Get_DateFormat(txtPickupdate.Text.Trim(), "yyyy/MM/dd") + "}) ";

            DataTable dt = new DataTable();
            dt.Load(oCmd.ExecuteReader());
            oConn.Close();

            return dt;

        }
        catch (Exception ex)
        {
            Display_Error(ex.Message, "Error");
            return null;
        }
    
    }
    private void AssignValuetoControl(DataTable dt)
    { 
          try
            {
                txtBankName.Text = dt.Rows[0]["Bank"].ToString();
                txtChequeDate.Text = dt.Rows[0]["ChequeDate"].ToString();
                txtChequeAmt.Text = dt.Rows[0]["chq_amt"].ToString();
                txtReason.Text = dt.Rows[0]["Reason"].ToString();
                txtContactNo.Text = dt.Rows[0]["Contact_de"].ToString();
                hdnTableID.Value = dt.Rows[0]["TableID"].ToString(); ;
            }
            catch (Exception ex)
            {
                Display_Error(ex.Message, "Error");
            }
    }
    private void Update_ChequeNo()
    {

        string DBFMaster = Convert.ToString(ConfigurationSettings.AppSettings["MasterDBFFiles"]); //this.Request.PhysicalApplicationPath;
        
        System.Data.Odbc.OdbcConnection oConn = new System.Data.Odbc.OdbcConnection();
        oConn.ConnectionString = @"Driver={Microsoft Visual FoxPro Driver};SourceType=DBF;SourceDB=" + Convert.ToString(ConfigurationSettings.AppSettings["MasterDBFFiles"]) + ";Exclusive=No; Collate=Machine;NULL=NO;DELETED=NO;BACKGROUNDFETCH=NO;";
        oConn.Open();
        System.Data.Odbc.OdbcCommand oCmd = oConn.CreateCommand();

         
        if (hdnTableID.Value == "1")
        {
            oCmd.CommandText = @"update othbkchq.dbf  set othbkchq.contact_de=" + txtContactNo.Text.Trim() + " Where Chq_no Like '%" + txtChequeNo.Text.Trim() + "%' And between(pickup_dt,{^" + Get_DateFormat(txtPickupdate.Text.Trim(), "yyyy/MM/dd") + "},{^" + Get_DateFormat(txtPickupdate.Text.Trim(), "yyyy/MM/dd") + "}) ";
        }
        else if (hdnTableID.Value == "2")
        {
            oCmd.CommandText = @"update upctry.dbf set upctry.contact_de=" + txtContactNo.Text.Trim() + " Where Chq_no Like '%" + txtChequeNo.Text.Trim() + "%' And between(pickup_dt,{^" + Get_DateFormat(txtPickupdate.Text.Trim(), "yyyy/MM/dd") + "},{^" + Get_DateFormat(txtPickupdate.Text.Trim(), "yyyy/MM/dd") + "}) ";
        }
        else if (hdnTableID.Value == "3")
        {
            oCmd.CommandText = @"update invldchq.dbf  set invldchq.contact_de=" + txtContactNo.Text.Trim() + " Where Chq_no Like '%" + txtChequeNo.Text.Trim() + "%' And between(pickup_dt,{^" + Get_DateFormat(txtPickupdate.Text.Trim(), "yyyy/MM/dd") + "},{^" + Get_DateFormat(txtPickupdate.Text.Trim(), "yyyy/MM/dd") + "}) ";
        }
        else if (hdnTableID.Value == "4")
        {
            oCmd.CommandText = @"update validchq.dbf  set validchq.contact_de=" + txtContactNo.Text.Trim() + " Where Chq_no Like '%" + txtChequeNo.Text.Trim() + "%' And between(pickup_dt,{^" + Get_DateFormat(txtPickupdate.Text.Trim(), "yyyy/MM/dd") + "},{^" + Get_DateFormat(txtPickupdate.Text.Trim(), "yyyy/MM/dd") + "}) ";
        }
      
        oCmd.ExecuteNonQuery();
        oConn.Close();

         
        Display_Error("Record Successfully Updated!", "Error");
         

    }
    private void Display_Error(string ErrorMessage, string MessageType)
    {
        try
        {
            if (MessageType == "Error")
            {
                lblMessage.Visible = true;
                lblMessage.Text = ErrorMessage.Trim();
                lblMessage.CssClass = "ErrorMessage";
            }
            else
            {
                lblMessage.Visible = true;
                lblMessage.Text = ErrorMessage.Trim();
                lblMessage.CssClass = "SuccessMessage";
            }


        }
        catch (Exception ex)
        {
            lblMessage.Visible = true;
            lblMessage.Text = ex.Message;
            lblMessage.CssClass = "ErrorMessage";
        }

    }
    private string Get_DateFormat(string cDate, string cDateFormat)
    {
        try
        {
            string strDate = cDate;
            string[] strArrDate = strDate.Split('/');

            if (strArrDate.Length > 0)
            {
                if (cDateFormat == "yyyy/MM/dd")
                {
                    strDate = strArrDate[2] + "/" + strArrDate[1] + "/" + strArrDate[0];

                }
            }

            return strDate;
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
            lblMessage.CssClass = "ErrorMessage";
            lblMessage.Visible = true;
            return "";
        }

    }
    private void Clear_Controls()
    {
        txtBankName.Text ="";
        txtChequeDate.Text = "";
        txtChequeAmt.Text = "";
        txtReason.Text ="";
        txtContactNo.Text ="";
        hdnTableID.Value = "";

    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/pages/Menu.aspx", false);
    }
}
