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
using System.Data.OleDb;
using System.Data.SqlClient;

public partial class application : System.Web.UI.Page
{
    UserInfo Objna = new UserInfo();
    protected void Page_Load(object sender, EventArgs e)
    {
        try 
        {

            txtTowardAd.Attributes.Add("onchange", "javascript:Compute_Columns();");
            txtTowStamp.Attributes.Add("onchange", "javascript:Compute_Columns();");
            txtTowardAdInt.Attributes.Add("onchange", "javascript:Compute_Columns();");
            txtTowardAppli.Attributes.Add("onchange", "javascript:Compute_Columns();");

            if (Session["UserInfo"] == null)
            {
                Response.Redirect("InvalidRequest.aspx",false);
            }

            if (!IsPostBack)
            {
                if ((Request.QueryString["ApplicationNo"] != null) && (Request.QueryString["PUID"]!=null))
                {
                    txtAppNo.Text =Convert.ToString(Request.QueryString["ApplicationNo"]);
                    txtPUId.Text = Convert.ToString(Request.QueryString["PUID"]);
                    if (txtAppNo.Text != "")
                    {
                        GetNanoCaseDetail();
                    }
                    
                }
            }
        }
        catch (Exception ex)
        {
            lblMess.CssClass = "ErrorMessage";
            lblMess.Visible = true;
            lblMess.Text = ex.Message;

        }
    }

    protected void btnRet_Click(object sender, EventArgs e)
    {
        if (txtAppNo.Text != "")
        {
            GetNanoCaseDetail();
        }

    }

    private void GetNanoCaseDetail()
    {
        try
        {
            Object SaveUSERInfo = (Object)Session["UserInfo"];
            SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

            sqlCon.Open();
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlCon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "Get_ScheduleDetailsFor_Update";

            SqlParameter BranchId = new SqlParameter();
            BranchId.SqlDbType = SqlDbType.Int;
            BranchId.Value = Convert.ToInt32(((UserInfo.structUSERInfo)(SaveUSERInfo)).BranchId);
            BranchId.ParameterName = "@BranchId";
            sqlCom.Parameters.Add(BranchId);


            SqlParameter NanoApplicationNo = new SqlParameter();
            NanoApplicationNo.SqlDbType = SqlDbType.VarChar;
            NanoApplicationNo.Value = txtAppNo.Text.Trim();
            NanoApplicationNo.ParameterName = "@NanoApplicationNo";
            sqlCom.Parameters.Add(NanoApplicationNo);

            SqlDataAdapter sqlDA = new SqlDataAdapter();
            sqlDA.SelectCommand = sqlCom;
            DataTable dt = new DataTable();
            sqlDA.Fill(dt);
            sqlCon.Close();
            if (dt.Rows.Count > 0)
            {
                txtAppNo.ReadOnly = true;
                txtPUId.ReadOnly = true;
                string dtReportDate=Convert.ToString(dt.Rows[0]["ReportSentDate"]);
                if (dtReportDate!="")
                {
                    BtnSave1.Enabled = false;
                    lblMess.Text = "you can not update the changes, due file closed! ";
                    lblMess.Visible = true;
                    lblMess.CssClass = "ErrorMessage";
                }

                txtPUId.Text = Convert.ToString(dt.Rows[0]["PUID"]);
                txtAgriDate.Text = Convert.ToString(dt.Rows[0]["AgreementDate"]);
                txtAnnInco.Text = Convert.ToString(dt.Rows[0]["AnnInc"]);
                txtBirthDate.Text = Convert.ToString(dt.Rows[0]["DOB"]);
                txtBookDep.Text = Convert.ToString(dt.Rows[0]["BookDepo"]);
                txtBorroName.Text = Convert.ToString(dt.Rows[0]["BorroName"]);
                txtInPay.Text = Convert.ToString(dt.Rows[0]["IntPay"]);
                txtLastBook.Text = Convert.ToString(dt.Rows[0]["LastBookDate"]);

                txtNoDept.Text = Convert.ToString(dt.Rows[0]["NoDep"]);
                txtOffAdd.Text = Convert.ToString(dt.Rows[0]["OffAdd"]);
                txtOffMob.Text = Convert.ToString(dt.Rows[0]["OffMob"]);
                txtOffPin.Text = Convert.ToString(dt.Rows[0]["OffPin"]);
                txtOffTel.Text = Convert.ToString(dt.Rows[0]["OffTel"]);

                txtPaiddate.Text = Convert.ToString(dt.Rows[0]["PaidDate"]);
                txtPaidRs.Text = Convert.ToString(dt.Rows[0]["PaidRs"]);
                txtPaidVaid.Text = Convert.ToString(dt.Rows[0]["PaidVide"]);
                txtPeriodLoan.Text = Convert.ToString(dt.Rows[0]["PeriodLoan"]);

                txtPlace.Text = Convert.ToString(dt.Rows[0]["ExecuPlace"]);
             

                txtRateInt.Text = Convert.ToString(dt.Rows[0]["IntRate"]);

                txtResiAdd.Text = Convert.ToString(dt.Rows[0]["ResiAdd"]);
                txtResiPin.Text = Convert.ToString(dt.Rows[0]["ResiPin"]);
                txtResiTel.Text = Convert.ToString(dt.Rows[0]["ResiTel"]);

                txtTowardAd.Text = Convert.ToString(dt.Rows[0]["TowAdv"]);
                txtTowardAdInt.Text = Convert.ToString(dt.Rows[0]["TowRefund"]);
                txtTowardAppli.Text = Convert.ToString(dt.Rows[0]["TowAppli"]);
                txtTowStamp.Text = Convert.ToString(dt.Rows[0]["TowStamp"]);
                txtVehBook.Text = Convert.ToString(dt.Rows[0]["VehicleBokk"]);

                ddlAppli.SelectedValue = Convert.ToString(dt.Rows[0]["Applicant"]);
                ddlLandTele.SelectedValue = Convert.ToString(dt.Rows[0]["LandTel"]);
                ddlOccu.SelectedValue = Convert.ToString(dt.Rows[0]["Occu"]);
                ddlPreVeh.SelectedValue = Convert.ToString(dt.Rows[0]["PreVehicle"]);
                ddlresiAdd.SelectedValue = Convert.ToString(dt.Rows[0]["ResiAddSel"]);
                ddlVehMod.SelectedValue = Convert.ToString(dt.Rows[0]["VehicleMod"]); 
                




             }
            


           
        }
        catch (Exception ex)
        {
            lblMess.CssClass = "ErrorMessage";
            lblMess.Visible = true;
            lblMess.Text = ex.Message;

        }
    
    }

     protected void BtnSave1_Click(object sender, EventArgs e)
    {
        try
        {

             Update_NEWApplication();
            

        }

        catch (Exception ex)
        {
            // lblMessage.CssClass = "ErrorMessage";
            lblMess.Visible = true;
            lblMess.Text = ex.Message;
        }

    }

    private int Update_NEWApplication()
    {
        try
        {
            Object SaveUSERInfo = (Object)Session["UserInfo"];

            SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

            sqlCon.Open();
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlCon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "Update_SheduleInfo";

            SqlParameter BranchId = new SqlParameter();
            BranchId.SqlDbType = SqlDbType.Int;
            BranchId.Value = Convert.ToInt32(((UserInfo.structUSERInfo)(SaveUSERInfo)).BranchId);
            BranchId.ParameterName = "@BranchId";
            sqlCom.Parameters.Add(BranchId);

            SqlParameter NanoApplicationNo = new SqlParameter();
            NanoApplicationNo.SqlDbType = SqlDbType.VarChar;
            NanoApplicationNo.Value = txtAppNo.Text.Trim();
            NanoApplicationNo.ParameterName = "@NanoApplicationNo";
            sqlCom.Parameters.Add(NanoApplicationNo);

            SqlParameter PUID = new SqlParameter();
            PUID.SqlDbType = SqlDbType.VarChar;
            PUID.Value = txtPUId.Text.Trim();
            PUID.ParameterName = "@PUID";
            sqlCom.Parameters.Add(PUID);

            SqlParameter ExecuPlace = new SqlParameter();
            ExecuPlace.SqlDbType = SqlDbType.VarChar;
            ExecuPlace.Value = txtPlace.Text.Trim();
            ExecuPlace.ParameterName = "@ExecuPlace";
            sqlCom.Parameters.Add(ExecuPlace);

            SqlParameter AgreementDate = new SqlParameter();
            AgreementDate.SqlDbType = SqlDbType.VarChar; //SqlDbType.DateTime;
            AgreementDate.Value = txtAgriDate.Text.Trim();//Convert.ToDateTime(txtAgriDate.Text.Trim()).ToString("dd-MM-yyyy");
            AgreementDate.ParameterName = "@AgreementDate";
            sqlCom.Parameters.Add(AgreementDate);

            SqlParameter BorroName = new SqlParameter();
            BorroName.SqlDbType = SqlDbType.VarChar;
            BorroName.Value = txtBorroName.Text.Trim();
            BorroName.ParameterName = "@BorroName";
            sqlCom.Parameters.Add(BorroName);

            SqlParameter DOB = new SqlParameter();
            DOB.SqlDbType = SqlDbType.VarChar; //SqlDbType.DateTime;
            DOB.Value = txtBirthDate.Text.Trim(); //Convert.ToDateTime(txtBirthDate.Text.Trim()).ToString("dd-MM-yyyy");
            DOB.ParameterName = "@DOB";
            sqlCom.Parameters.Add(DOB);

            SqlParameter ResiAdd = new SqlParameter();
            ResiAdd.SqlDbType = SqlDbType.VarChar;
            ResiAdd.Value = txtResiAdd.Text.Trim();
            ResiAdd.ParameterName = "@ResiAdd";
            sqlCom.Parameters.Add(ResiAdd);

            SqlParameter ResiPin = new SqlParameter();
            ResiPin.SqlDbType = SqlDbType.VarChar;
            ResiPin.Value = txtResiPin.Text.Trim();
            ResiPin.ParameterName = "@ResiPin";
            sqlCom.Parameters.Add(ResiPin);

            SqlParameter ResiTel = new SqlParameter();
            ResiTel.SqlDbType = SqlDbType.VarChar;
            ResiTel.Value = txtResiTel.Text.Trim();
            ResiTel.ParameterName = "@ResiTel";
            sqlCom.Parameters.Add(ResiTel);

            SqlParameter ResiMob = new SqlParameter();
            ResiMob.SqlDbType = SqlDbType.VarChar;
            ResiMob.Value = txtMob.Text.Trim();
            ResiMob.ParameterName = "@ResiMob";
            sqlCom.Parameters.Add(ResiMob);

            SqlParameter OffAdd = new SqlParameter();
            OffAdd.SqlDbType = SqlDbType.VarChar;
            OffAdd.Value = txtOffAdd.Text.Trim();
            OffAdd.ParameterName = "@OffAdd";
            sqlCom.Parameters.Add(OffAdd);

            SqlParameter OffPin = new SqlParameter();
            OffPin.SqlDbType = SqlDbType.VarChar;
            OffPin.Value = txtOffPin.Text.Trim();
            OffPin.ParameterName = "@OffPin";
            sqlCom.Parameters.Add(OffPin);

            SqlParameter OffTel = new SqlParameter();
            OffTel.SqlDbType = SqlDbType.VarChar;
            OffTel.Value = txtOffTel.Text.Trim();
            OffTel.ParameterName = "@OffTel";
            sqlCom.Parameters.Add(OffTel);

            SqlParameter OffMob = new SqlParameter();
            OffMob.SqlDbType = SqlDbType.VarChar;
            OffMob.Value = txtOffMob.Text.Trim();
            OffMob.ParameterName = "@OffMob";
            sqlCom.Parameters.Add(OffMob);

            SqlParameter ResiAddSel = new SqlParameter();
            ResiAddSel.SqlDbType = SqlDbType.VarChar;
            ResiAddSel.Value = ddlresiAdd.SelectedValue.ToString().Trim();
            ResiAddSel.ParameterName = "@ResiAddSel";
            sqlCom.Parameters.Add(ResiAddSel);

            SqlParameter Applicant = new SqlParameter();
            Applicant.SqlDbType = SqlDbType.VarChar;
            Applicant.Value = ddlAppli.SelectedValue.ToString().Trim();
            Applicant.ParameterName = "@Applicant";
            sqlCom.Parameters.Add(Applicant);

            SqlParameter Occu = new SqlParameter();
            Occu.SqlDbType = SqlDbType.VarChar;
            Occu.Value = ddlOccu.SelectedValue.ToString().Trim();
            Occu.ParameterName = "@Occu";
            sqlCom.Parameters.Add(Occu);

            SqlParameter AnnInc = new SqlParameter();
            AnnInc.SqlDbType = SqlDbType.VarChar;
            AnnInc.Value = txtAnnInco.Text.Trim();
            AnnInc.ParameterName = "@AnnInc";
            sqlCom.Parameters.Add(AnnInc);

            SqlParameter NoDep = new SqlParameter();
            NoDep.SqlDbType = SqlDbType.VarChar;
            NoDep.Value = txtNoDept.Text.Trim();
            NoDep.ParameterName = "@NoDep";
            sqlCom.Parameters.Add(NoDep);

            SqlParameter BookDepo = new SqlParameter();
            BookDepo.SqlDbType = SqlDbType.VarChar;
            BookDepo.Value = txtBookDep.Text.Trim();
            BookDepo.ParameterName = "@BookDepo";
            sqlCom.Parameters.Add(BookDepo);

            SqlParameter VehicleBokk = new SqlParameter();
            VehicleBokk.SqlDbType = SqlDbType.VarChar;
            VehicleBokk.Value = txtVehBook.Text.Trim();
            VehicleBokk.ParameterName = "@VehicleBokk";
            sqlCom.Parameters.Add(VehicleBokk);

            SqlParameter IntPay = new SqlParameter();
            IntPay.SqlDbType = SqlDbType.VarChar;
            IntPay.Value = txtInPay.Text.Trim();
            IntPay.ParameterName = "@IntPay";
            sqlCom.Parameters.Add(IntPay);

            SqlParameter TowRefund = new SqlParameter();
            TowRefund.SqlDbType = SqlDbType.VarChar;
            TowRefund.Value = txtTowardAd.Text.Trim();
            TowRefund.ParameterName = "@TowRefund";
            sqlCom.Parameters.Add(TowRefund);

            SqlParameter TowStamp = new SqlParameter();
            TowStamp.SqlDbType = SqlDbType.VarChar;
            TowStamp.Value = txtTowStamp.Text.Trim();
            TowStamp.ParameterName = "@TowStamp";
            sqlCom.Parameters.Add(TowStamp);

            SqlParameter TowAdv = new SqlParameter();
            TowAdv.SqlDbType = SqlDbType.VarChar;
            TowAdv.Value = txtTowardAdInt.Text.Trim();
            TowAdv.ParameterName = "@TowAdv";
            sqlCom.Parameters.Add(TowAdv);

            SqlParameter TowAppli = new SqlParameter();
            TowAppli.SqlDbType = SqlDbType.VarChar;
            TowAppli.Value =  txtTowardAppli.Text.Trim();
            TowAppli.ParameterName = "@TowAppli";
            sqlCom.Parameters.Add(TowAppli);

            SqlParameter PaidVide = new SqlParameter();
            PaidVide.SqlDbType = SqlDbType.VarChar;
            PaidVide.Value = txtPaidVaid.Text.Trim();
            PaidVide.ParameterName = "@PaidVide";
            sqlCom.Parameters.Add(PaidVide);

            SqlParameter PaidDate = new SqlParameter();
            PaidDate.SqlDbType = SqlDbType.VarChar; //SqlDbType.DateTime;
            PaidDate.Value = txtPaiddate.Text.Trim();//Convert.ToDateTime(txtPaiddate.Text.Trim()).ToString("dd-MM-yyyy"); 
            PaidDate.ParameterName = "@PaidDate";
            sqlCom.Parameters.Add(PaidDate);

            SqlParameter PaidRs = new SqlParameter();
            PaidRs.SqlDbType = SqlDbType.VarChar;
            PaidRs.Value = txtPaidRs.Text.Trim();
            PaidRs.ParameterName = "@PaidRs";
            sqlCom.Parameters.Add(PaidRs);

            SqlParameter LastBookDate = new SqlParameter();
            LastBookDate.SqlDbType = SqlDbType.VarChar; //SqlDbType.DateTime;
            LastBookDate.Value = txtLastBook.Text.Trim(); //Convert.ToDateTime(txtLastBook.Text.Trim()).ToString("dd-MM-yyyy");
            LastBookDate.ParameterName = "@LastBookDate";
            sqlCom.Parameters.Add(LastBookDate);

            SqlParameter PeriodLoan = new SqlParameter();
            PeriodLoan.SqlDbType = SqlDbType.VarChar;
            PeriodLoan.Value = txtPeriodLoan.Text.Trim();
            PeriodLoan.ParameterName = "@PeriodLoan";
            sqlCom.Parameters.Add(PeriodLoan);

            SqlParameter IntRate = new SqlParameter();
            IntRate.SqlDbType = SqlDbType.VarChar;
            IntRate.Value = txtRateInt.Text.Trim();
            IntRate.ParameterName = "@IntRate";
            sqlCom.Parameters.Add(IntRate);
                        
            SqlParameter VehicleMod = new SqlParameter();
            VehicleMod.SqlDbType = SqlDbType.VarChar;
            VehicleMod.Value = ddlVehMod.SelectedValue.ToString().Trim();
            VehicleMod.ParameterName = "@VehicleMod";
            sqlCom.Parameters.Add(VehicleMod);

            SqlParameter PreVehicle = new SqlParameter();
            PreVehicle.SqlDbType = SqlDbType.VarChar;
            PreVehicle.Value = ddlPreVeh.SelectedValue.ToString().Trim();
            PreVehicle.ParameterName = "@PreVehicle";
            sqlCom.Parameters.Add(PreVehicle);

            SqlParameter LandTel = new SqlParameter();
            LandTel.SqlDbType = SqlDbType.VarChar;
            LandTel.Value = ddlLandTele.SelectedValue.ToString().Trim();
            LandTel.ParameterName = "@LandTel";
            sqlCom.Parameters.Add(LandTel);

            int intRows=sqlCom.ExecuteNonQuery();
             

            sqlCon.Close();

            if (intRows > 0)
            {
                lblMess.CssClass = "UpdateMessage";
                lblMess.Visible = true;
                lblMess.Text = " Data Successfully Updated!";
            }
            else
            { 
            
                lblMess.CssClass = "ErrorMessage";
                lblMess.Visible = true;
                lblMess.Text = " Record Not Updated!";
            }
            return intRows;
            }


         
        catch (Exception ex)
        {
    
            lblMess.Visible = true;
            lblMess.Text = ex.Message;
            return 0;
        }
    }

    private void Clear_Controls()
    { 
    
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("Menu.aspx", false);
    }
}
