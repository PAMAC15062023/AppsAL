using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using System.Drawing;
using iTextSharp.text;
using System.Text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;

public partial class Pages_TCFSL_CDLOAN_DailyTracker : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

        }
        Object SaveUSERInfo = (Object)Session["UserInfo"];
    }
    public string strDate(string strInDate)
    {
        string strDD = strInDate.Substring(0, 2);
        string strMM = strInDate.Substring(3, 2);
        string strYYYY = strInDate.Substring(6, 4);
        string strMMDDYYYY = strMM + "/" + strDD + "/" + strYYYY;
        DateTime dtConvertDate = Convert.ToDateTime(strMMDDYYYY);
        string strOutDate = dtConvertDate.ToString("dd-MMM-yyyy");
        return strOutDate;
    }
    protected void btncancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Pages/Menu.aspx", true);
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            Object LoginInfo = (Object)Session["userInfo"];

            SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlCon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "TCFSL__Daily_Hour_SP";
            sqlCom.CommandTimeout = 0;
            sqlCon.Open();


            //SqlParameter FromDate = new SqlParameter();
            //FromDate.SqlDbType = SqlDbType.DateTime;
            //FromDate.Value = textFromDate.Text.Trim();
            //FromDate.ParameterName = "@FromDate";
            //sqlCom.Parameters.Add(FromDate);

            //SqlParameter ToDate = new SqlParameter();
            //ToDate.SqlDbType = SqlDbType.DateTime;
            //ToDate.Value = textToDate.Text.Trim();
            //ToDate.ParameterName = "@ToDate";
            //sqlCom.Parameters.Add(ToDate);


            SqlParameter FromDate = new SqlParameter();
            FromDate.SqlDbType = SqlDbType.VarChar;
            FromDate.Value = strDate(textFromDate.Text.Trim());
            FromDate.ParameterName = "@FromDate";
            sqlCom.Parameters.Add(FromDate);

            SqlParameter ToDate = new SqlParameter();
            ToDate.SqlDbType = SqlDbType.VarChar;
            ToDate.Value = strDate(textToDate.Text.Trim());
            ToDate.ParameterName = "@ToDate";
            sqlCom.Parameters.Add(ToDate);

            SqlParameter VarResult = new SqlParameter();
            VarResult.SqlDbType = SqlDbType.VarChar;
            VarResult.Value = lblScreenCom.Text;
            VarResult.ParameterName = "@ScrTotal";
            VarResult.Size = 200;
            VarResult.Direction = ParameterDirection.Output;
            sqlCom.Parameters.Add(VarResult);

            SqlParameter VarResult1 = new SqlParameter();
            VarResult1.SqlDbType = SqlDbType.VarChar;
            VarResult1.Value = lblScreenRej.Text;
            VarResult1.ParameterName = "@ScrReject";
            VarResult1.Size = 200;
            VarResult1.Direction = ParameterDirection.Output;
            sqlCom.Parameters.Add(VarResult1);

            SqlParameter APProv = new SqlParameter();
            APProv.SqlDbType = SqlDbType.VarChar;
            APProv.Value = lblScreenAppr.Text;
            APProv.ParameterName = "@ScrAPProv";
            APProv.Size = 200;
            APProv.Direction = ParameterDirection.Output;
            sqlCom.Parameters.Add(APProv);

            SqlParameter Hold = new SqlParameter();
            Hold.SqlDbType = SqlDbType.VarChar;
            Hold.Value = lblScreenHold.Text;
            Hold.ParameterName = "@ScrHold";
            Hold.Size = 200;
            Hold.Direction = ParameterDirection.Output;
            sqlCom.Parameters.Add(Hold);

            SqlParameter Remain = new SqlParameter();
            Remain.SqlDbType = SqlDbType.VarChar;
            Remain.Value = lblScreenRemain.Text;
            Remain.ParameterName = "@ScrRemain";
            Remain.Size = 200;
            Remain.Direction = ParameterDirection.Output;
            sqlCom.Parameters.Add(Remain);

            //////////Screen QC



            SqlParameter VarReIntia = new SqlParameter();
            VarReIntia.SqlDbType = SqlDbType.VarChar;
            VarReIntia.Value = lblScreenReinit.Text;
            VarReIntia.ParameterName = "@ScrReIntia";
            VarReIntia.Size = 200;
            VarReIntia.Direction = ParameterDirection.Output;
            sqlCom.Parameters.Add(VarReIntia);

            SqlParameter VarInit = new SqlParameter();
            VarInit.SqlDbType = SqlDbType.VarChar;
            VarInit.Value = lblScreeninit.Text;
            VarInit.ParameterName = "@ScrInit";
            VarInit.Size = 200;
            VarInit.Direction = ParameterDirection.Output;
            sqlCom.Parameters.Add(VarInit);

            SqlParameter Pending = new SqlParameter();
            Pending.SqlDbType = SqlDbType.VarChar;
            Pending.Value = lblScreenPend.Text;
            Pending.ParameterName = "@ScrPending";
            Pending.Size = 200;
            Pending.Direction = ParameterDirection.Output;
            sqlCom.Parameters.Add(Pending);

            SqlParameter QCScrAPProv = new SqlParameter();
            QCScrAPProv.SqlDbType = SqlDbType.VarChar;
            QCScrAPProv.Value = lblQCapp.Text;
            QCScrAPProv.ParameterName = "@QCScrAPProv";
            QCScrAPProv.Size = 200;
            QCScrAPProv.Direction = ParameterDirection.Output;
            sqlCom.Parameters.Add(QCScrAPProv);

            SqlParameter QCScrTotal = new SqlParameter();
            QCScrTotal.SqlDbType = SqlDbType.VarChar;
            QCScrTotal.Value = lblScreenQCCom.Text;
            QCScrTotal.ParameterName = "@QCScrTotal";
            QCScrTotal.Size = 200;
            QCScrTotal.Direction = ParameterDirection.Output;
            sqlCom.Parameters.Add(QCScrTotal);

            SqlParameter QCScrReject = new SqlParameter();
            QCScrReject.SqlDbType = SqlDbType.VarChar;
            QCScrReject.Value = lblQCRej.Text;
            QCScrReject.ParameterName = "@QCScrReject";
            QCScrReject.Size = 200;
            QCScrReject.Direction = ParameterDirection.Output;
            sqlCom.Parameters.Add(QCScrReject);

            SqlParameter QCScrHold = new SqlParameter();
            QCScrHold.SqlDbType = SqlDbType.VarChar;
            QCScrHold.Value = lblQCHld.Text;
            QCScrHold.ParameterName = "@QCScrHold";
            QCScrHold.Size = 200;
            QCScrHold.Direction = ParameterDirection.Output;
            sqlCom.Parameters.Add(QCScrHold);

            SqlParameter QCScrRemain = new SqlParameter();
            QCScrRemain.SqlDbType = SqlDbType.VarChar;
            QCScrRemain.Value = lblQCRemn.Text;
            QCScrRemain.ParameterName = "@QCScrRemain";
            QCScrRemain.Size = 200;
            QCScrRemain.Direction = ParameterDirection.Output;
            sqlCom.Parameters.Add(QCScrRemain);

            /////////////////////MAKER

            SqlParameter Maker = new SqlParameter();
            Maker.SqlDbType = SqlDbType.VarChar;
            Maker.Value = lblMKR.Text;
            Maker.ParameterName = "@MKRComp";
            Maker.Size = 200;
            Maker.Direction = ParameterDirection.Output;
            sqlCom.Parameters.Add(Maker);

            SqlParameter MakerHld = new SqlParameter();
            MakerHld.SqlDbType = SqlDbType.VarChar;
            MakerHld.Value = lblMKRHold.Text;
            MakerHld.ParameterName = "@MKRHold";
            MakerHld.Size = 200;
            MakerHld.Direction = ParameterDirection.Output;
            sqlCom.Parameters.Add(MakerHld);

            SqlParameter MakerPend = new SqlParameter();
            MakerPend.SqlDbType = SqlDbType.VarChar;
            MakerPend.Value = lblMKRPend.Text;
            MakerPend.ParameterName = "@MKRpending";
            MakerPend.Size = 200;
            MakerPend.Direction = ParameterDirection.Output;
            sqlCom.Parameters.Add(MakerPend);

            ////////////////////AUTHOR

            SqlParameter Author = new SqlParameter();
            Author.SqlDbType = SqlDbType.VarChar;
            Author.Value = lblATH.Text;
            Author.ParameterName = "@ATHComp";
            Author.Size = 200;
            Author.Direction = ParameterDirection.Output;
            sqlCom.Parameters.Add(Author);

            SqlParameter ATHHld = new SqlParameter();
            ATHHld.SqlDbType = SqlDbType.VarChar;
            ATHHld.Value = lblAHld.Text;
            ATHHld.ParameterName = "@ATHHold";
            ATHHld.Size = 200;
            ATHHld.Direction = ParameterDirection.Output;
            sqlCom.Parameters.Add(ATHHld);

            SqlParameter ATHPend = new SqlParameter();
            ATHPend.SqlDbType = SqlDbType.VarChar;
            ATHPend.Value = lblAPend.Text;
            ATHPend.ParameterName = "@ATHPend";
            ATHPend.Size = 200;
            ATHPend.Direction = ParameterDirection.Output;
            sqlCom.Parameters.Add(ATHPend);

            sqlCom.ExecuteNonQuery();
            //string RowEffected = Convert.ToString(sqlCom.Parameters["@ScrTotal"].Value);
            //string RowEffectedrej = Convert.ToString(sqlCom.Parameters["@ScrReject"].Value);

            lblScreenCom.Text = sqlCom.Parameters["@ScrTotal"].Value.ToString();
            lblScreenRej.Text = sqlCom.Parameters["@ScrReject"].Value.ToString();
            lblScreenAppr.Text = sqlCom.Parameters["@ScrAPProv"].Value.ToString();
            lblScreenHold.Text = sqlCom.Parameters["@ScrHold"].Value.ToString();
            lblScreenRemain.Text = sqlCom.Parameters["@ScrRemain"].Value.ToString();

            lblMKR.Text = sqlCom.Parameters["@MKRComp"].Value.ToString();
            lblMKRHold.Text = sqlCom.Parameters["@MKRHold"].Value.ToString();
            lblMKRPend.Text = sqlCom.Parameters["@MKRpending"].Value.ToString();
            lblATH.Text = sqlCom.Parameters["@ATHComp"].Value.ToString();
            lblAHld.Text = sqlCom.Parameters["@ATHHold"].Value.ToString();
            lblAPend.Text = sqlCom.Parameters["@ATHPend"].Value.ToString();



            lblScreenQCCom.Text = sqlCom.Parameters["@QCScrTotal"].Value.ToString();
            lblQCRej.Text = sqlCom.Parameters["@QCScrReject"].Value.ToString();
            lblQCapp.Text = sqlCom.Parameters["@QCScrAPProv"].Value.ToString();
            lblQCHld.Text = sqlCom.Parameters["@QCScrHold"].Value.ToString();
            lblQCRemn.Text = sqlCom.Parameters["@QCScrRemain"].Value.ToString();
            lblScreenReinit.Text = sqlCom.Parameters["@ScrReIntia"].Value.ToString();
            lblScreeninit.Text = sqlCom.Parameters["@ScrInit"].Value.ToString();
            lblScreenPend.Text = sqlCom.Parameters["@ScrPending"].Value.ToString();

            sqlCon.Close();

            //if (RowEffected != "")
            //{
            //    lblScreenCom.Text = RowEffected;
            //}
            //else if (RowEffectedrej != "")
            //{
            //    lblScreenRej.Text = RowEffectedrej;
            //}
        }

        catch (Exception ex)
        {
            result.Value = "Error :" + ex.Message;
            return;
        }
    }
}