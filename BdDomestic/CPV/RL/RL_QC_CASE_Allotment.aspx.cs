using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class CPV_RL_RL_QC_CASE_Allotment : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnSearch_Click1(object sender, EventArgs e)
    {
        try
        {
            Get_QC_CASES_FOR_Allotment();
        }
        catch (Exception ex)
        {

        }

    }

    protected void gvQC_DataBound(object sender, EventArgs e)
    {
        try
        {
            int i = 0;
            int j = 0;
            CheckBox chkQRV;
            CheckBox chkQBV;
            CheckBox chkQRT;
            CheckBox chkQBT;
            CheckBox chkQTRV;
            CheckBox chkQTBV;

            for (i = 0; i <= gvQC.Rows.Count - 1; i++)
            {
                chkQRV = (CheckBox)gvQC.Rows[i].FindControl("chkQCRV");
                chkQBV = (CheckBox)gvQC.Rows[i].FindControl("chkQCBV");
                chkQRT = (CheckBox)gvQC.Rows[i].FindControl("chkQCRT");
                chkQBT = (CheckBox)gvQC.Rows[i].FindControl("chkQCBT");
                chkQTRV = (CheckBox)gvQC.Rows[i].FindControl("chkQTRV");
                chkQTBV = (CheckBox)gvQC.Rows[i].FindControl("chkQTBV");

                string StrValue = gvQC.Rows[i].Cells[6].Text.Trim();
                string[] strArr = StrValue.Split('+');

                for (j = 0; j <= strArr.Length - 1; j++)
                {
                    if (strArr[j] == "RV")
                    {
                        chkQRV.Enabled = true;
                        chkQTRV.Enabled = true;

                    }
                    else if (strArr[j] == "BV")
                    {
                        chkQBV.Enabled = true;
                        chkQTBV.Enabled = true;
                    }
                    else if (strArr[j] == "RT")
                    {
                        chkQRT.Enabled = true;
                    }
                    else if (strArr[j] == "BT")
                    {
                        chkQBT.Enabled = true;
                    }

                }


            }

        }
        catch
        {

        }

    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            //Get_QC_CASE_DETAILS_for_Insert();
            Insert_QC_CASE_Details();

        }
        catch
        {

        }

    }

    private void Get_QC_CASES_FOR_Allotment()
    {
        try
        {
            CCommon objCommon = new CCommon();
            SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["constring"]);
            sqlCon.Open();
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlCon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "Get_Case_For_QC_Allotment";
            sqlCom.CommandTimeout = 0;

            SqlParameter FromDate = new SqlParameter();
            FromDate.SqlDbType = SqlDbType.VarChar;
            FromDate.ParameterName = "@FrmDate";
            FromDate.Value = txtFromDate.Text;
            sqlCom.Parameters.Add(FromDate);

            SqlParameter ToDate = new SqlParameter();
            ToDate.SqlDbType = SqlDbType.VarChar;
            ToDate.ParameterName = "@ToDate";
            ToDate.Value = txtToDate.Text;
            sqlCom.Parameters.Add(ToDate);

            SqlParameter ProductCode = new SqlParameter();
            ProductCode.SqlDbType = SqlDbType.VarChar;
            ProductCode.ParameterName = "@ProductCode";
            ProductCode.Value = "RL";
            sqlCom.Parameters.Add(ProductCode);

            SqlParameter ClientId = new SqlParameter();
            ClientId.SqlDbType = SqlDbType.VarChar;
            ClientId.ParameterName = "@ClientId";
            ClientId.Value = Session["ClientId"].ToString();
            sqlCom.Parameters.Add(ClientId);

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = sqlCom;

            da.Fill(dt);

            gvQC.DataSource = dt;
            gvQC.DataBind();

            if (gvQC.Rows.Count <= 0)
            {
                lblMessage.CssClass = "ErrorMessage";
                lblMessage.Text = "No Record(s) Found";
            }
            else
            {

                lblMessage.CssClass = "UpdateMessage";
                lblMessage.Text = "Record(s) Found" + dt.Rows.Count;
            }

        }

        catch (Exception ex)
        {
            lblMessage.CssClass = "ErrorMessage";
            lblMessage.Text = ex.Message;
        }

    }

    private void Insert_QC_CASE_Details()
    {
        try
        {
            CCommon objCommon = new CCommon();
            SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["constring"]);
            sqlCon.Open();
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlCon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "Insert_QC_Case_Details";
            sqlCom.CommandTimeout = 0;

            SqlParameter CASE_DETAILS = new SqlParameter();
            CASE_DETAILS.SqlDbType = SqlDbType.VarChar;
            CASE_DETAILS.ParameterName = "@CASE_DETAILS";
            CASE_DETAILS.Value = Get_QC_CASE_DETAILS_for_Insert();
            sqlCom.Parameters.Add(CASE_DETAILS);

            SqlParameter PRODUCT_TYPE = new SqlParameter();
            PRODUCT_TYPE.SqlDbType = SqlDbType.VarChar;
            PRODUCT_TYPE.ParameterName = "@PRODUCT_TYPE";
            PRODUCT_TYPE.Value = "RL";
            sqlCom.Parameters.Add(PRODUCT_TYPE);

            int Rows = sqlCom.ExecuteNonQuery();

            if (Rows > 0)
            {
                lblMessage.CssClass = "UpdateMessage";
                lblMessage.Text = "Record Updated Successfully!";

                gvQC.DataSource = null;
                gvQC.DataBind();
                //Get_QC_CASES_FOR_Allotment();
            }
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }
    private string Get_QC_CASE_DETAILS_for_Insert()
    {
        try
        {
            string strReturnValue = "";
            string strCheckBox = "";
            Boolean IS_selected = false;

            int i = 0;

            CheckBox chkQRV;
            CheckBox chkQBV;
            CheckBox chkQRT;
            CheckBox chkQBT;
            CheckBox chkQTRT;
            CheckBox chkQTBT;

            for (i = 0; i <= gvQC.Rows.Count - 1; i++)
            {
                chkQRV = (CheckBox)gvQC.Rows[i].FindControl("chkQCRV");
                chkQBV = (CheckBox)gvQC.Rows[i].FindControl("chkQCBV");
                chkQRT = (CheckBox)gvQC.Rows[i].FindControl("chkQCRT");
                chkQBT = (CheckBox)gvQC.Rows[i].FindControl("chkQCBT");
                chkQTRT = (CheckBox)gvQC.Rows[i].FindControl("chkQTRV");
                chkQTBT = (CheckBox)gvQC.Rows[i].FindControl("chkQTBV");

                strCheckBox = "";
                IS_selected = false;

                if (chkQRV.Checked)
                {
                    IS_selected = true;
                    strCheckBox = strCheckBox + "|QRV";
                }
                else
                {
                    strCheckBox = strCheckBox + "|";
                }

                if (chkQBV.Checked)
                {
                    IS_selected = true;
                    strCheckBox = strCheckBox + "|QBV";
                }
                else
                {
                    strCheckBox = strCheckBox + "|";
                }

                if (chkQRT.Checked)
                {
                    IS_selected = true;
                    strCheckBox = strCheckBox + "|QRT";
                }
                else
                {
                    strCheckBox = strCheckBox + "|";
                }

                if (chkQBT.Checked)
                {
                    IS_selected = true;
                    strCheckBox = strCheckBox + "|QBT";
                }
                else
                {
                    strCheckBox = strCheckBox + "|";
                }

                if (chkQTRT.Checked)
                {
                    IS_selected = true;
                    strCheckBox = strCheckBox + "|QTRV";
                }
                else
                {
                    strCheckBox = strCheckBox + "|";
                }

                if (chkQTBT.Checked)
                {
                    IS_selected = true;
                    strCheckBox = strCheckBox + "|QTBV";
                }
                else
                {
                    strCheckBox = strCheckBox + "|";
                }

                if (IS_selected == true)
                {

                    strReturnValue = strReturnValue + gvQC.Rows[i].Cells[1].Text + strCheckBox + "^";
                }


            }

            return strReturnValue;

        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
            return "";
        }

    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {

    }
}
