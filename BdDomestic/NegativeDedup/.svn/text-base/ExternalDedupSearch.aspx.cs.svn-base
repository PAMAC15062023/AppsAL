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
using System.IO;
using System.Data.OleDb;
using System.Drawing;


public partial class ExternalDedupSearch : System.Web.UI.Page
{    
    
    #region Property Declaration
    private string sRefNo;
    private string sCaseId;
    private string sFirstNm;
    private string sMiddleNm;
    private string sLastNm;
    private string sDateOfBirth;
    private string sResAdd1;
    private string sResAdd2;
    private string sResAdd3;
    private string sResCity;
    private string sResPin;
    private string sResPhone;
    private string sOffName;
    private string sOffAdd1;
    private string sOffAdd2;
    private string sOffAdd3;
    private string sOffCity;
    private string sOffPin;
    private string sOffPhone1;
    private string sOffPhone2;
    private string sDesgn;

    public string CaseId
    {
        get { return sCaseId; }
        set { sCaseId = value; }
    }
    public string RefNo
    {
        get { return sRefNo; }
        set { sRefNo = value; }
    }

    public string FirstName
    {
        get { return sFirstNm; }
        set { sFirstNm = value; }
    }

    public string MiddleName
    {
        get { return sMiddleNm; }
        set { sMiddleNm = value; }
    }

    public string LastName
    {
        get { return sLastNm; }
        set { sLastNm = value; }
    }
    
    public string DateOfBirth
    {
        get { return sDateOfBirth; }
        set { sDateOfBirth = value; }
    }
    public string Designation
    {
        get { return sDesgn; }
        set { sDesgn = value; }
    }
    public string ResAdd1
    {
        get { return sResAdd1; }
        set { sResAdd1 = value; }
    }

    public string ResAdd2
    {
        get { return sResAdd2; }
        set { sResAdd2 = value; }
    }

    public string ResAdd3
    {
        get { return sResAdd3; }
        set { sResAdd3 = value; }
    }

    public string ResCity
    {
        get { return sResCity; }
        set { sResCity = value; }
    }
    public string ResPin
    {
        get { return sResPin; }
        set { sResPin = value; }
    }
    public string ResPhone
    {
        get { return sResPhone; }
        set { sResPhone = value; }
    }
    public string OfficeName
    {
        get { return sOffName; }
        set { sOffName = value; }
    }

    public string OfficeAdd1
    {
        get { return sOffAdd1; }
        set { sOffAdd1 = value; }
    }

    public string OfficeAdd2
    {
        get { return sOffAdd2; }
        set { sOffAdd2 = value; }
    }

    public string OfficeAdd3
    {
        get { return sOffAdd3; }
        set { sOffAdd3 = value; }
    }

    public string OfficeCity
    {
        get { return sOffCity; }
        set { sOffCity = value; }
    }
    public string OfficePin
    {
        get { return sOffPin; }
        set { sOffPin = value; }
    }

    public string OfficePhone1
    {
        get { return sOffPhone1; }
        set { sOffPhone1 = value; }
    }
    public string OfficePhone2
    {
        get { return sOffPhone2; }
        set { sOffPhone2 = value; }
    }
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GetInfileData();
        }
    }

    private string GetCentreNameById(string sCentreId)
    {
        string sCentreName = "";
        try
        {
            CCommon objCmn = new CCommon();            
            OleDbDataReader oledbRead;
            string sSql = "select Centre_Name from Centre_Master where Centre_Id=" + sCentreId;
            oledbRead = OleDbHelper.ExecuteReader(objCmn.ConnectionString, CommandType.Text, sSql);
            if (oledbRead.Read() == true)
                sCentreName = oledbRead["Centre_Name"].ToString();
            oledbRead.Close();
        }
        catch (Exception ex)
        {
            lblMsg.Visible = true;
            lblMsg.Text = "Error while getting centre name: " + ex.Message;
        }
        return sCentreName;
    }

    private string GetClientNameById(string sClientId)
    {
        string sClientName = "";
        try
        {
            CCommon objCmn = new CCommon();            
            OleDbDataReader oledbRead;
            string sSql = "select Client_Name from Client_Master where Client_Id=" + sClientId;
            oledbRead = OleDbHelper.ExecuteReader(objCmn.ConnectionString, CommandType.Text, sSql);
            if (oledbRead.Read() == true)
                sClientName = oledbRead["Client_Name"].ToString();
            oledbRead.Close();
        }
        catch (Exception ex)
        {
            lblMsg.Visible = true;
            lblMsg.Text = "Error while getting client name: " + ex.Message;
        }
        return sClientName;
    }

    private void GetInfileData()
    {
        try
        {
            CCommon objCmn = new CCommon();
            string sSql = "";
            DataTable dtResultant;
            dtResultant = new DataTable();
            if (Context.Request.QueryString["CID"] != null && Context.Request.QueryString["CID"] != ""
                && Context.Request.QueryString["PR"] != null && Context.Request.QueryString["PR"] != ""
                && Context.Request.QueryString["CLID"] != null && Context.Request.QueryString["CLID"] != ""
                && Context.Request.QueryString["RcdDt"] != null && Context.Request.QueryString["RcdDt"] != "")
            {
                ArrayList arrInfileSrNo = new ArrayList();
                ArrayList arrNegSrNo = new ArrayList();

                switch (Request.QueryString["PR"].ToString())
                {
                    case "CC":
                        sSql = "SELECT '' as SR_NO,CASE_ID,REF_NO,FIRST_NAME,MIDDLE_NAME,LAST_NAME,DOB,RES_ADD_LINE_1,RES_ADD_LINE_2," +
                                "RES_ADD_LINE_3,RES_PIN_CODE,RES_PHONE,OFF_NAME,DESIGNATION,OFF_ADD_LINE_1," +
                                "OFF_ADD_LINE_2,OFF_PIN_CODE,OFF_PHONE,RES_CITY,OFF_ADD_LINE_3,OFF_PHONE,OFF_CITY " +
                                " FROM CPV_CC_CASE_DETAILS WHERE SEND_DATETIME IS NULL";

                        break;
                    case "RL":
                        sSql = "SELECT '' as SR_NO,CASE_ID,REF_NO,FIRST_NAME,MIDDLE_NAME,LAST_NAME,DOB,RES_ADD_LINE_1,RES_ADD_LINE_2," +
                                 "RES_ADD_LINE_3,RES_PIN_CODE,RES_PHONE,OFF_NAME,DESIGNATION,OFF_ADD_LINE_1," +
                                 "OFF_ADD_LINE_2,OFF_PIN_CODE,OFF_PHONE,RES_CITY,OFF_ADD_LINE_3,OFF_PHONE,OFF_CITY " +
                                 " FROM CPV_RL_CASE_DETAILS WHERE SEND_DATETIME IS NULL";

                        break;
                    case "IDOC":
                        sSql = "SELECT '' as SR_NO,CASE_ID,REF_NO,FIRST_NAME,MIDDLE_NAME,LAST_NAME,DOB,RES_ADD_LINE_1,RES_ADD_LINE_2," +
                                 "RES_ADD_LINE_3,RES_PIN_CODE,RES_PHONE,OFF_NAME,DESIGNATION,OFF_ADD_LINE_1," +
                                 "OFF_ADD_LINE_2,OFF_PIN_CODE,OFF_PHONE,RES_CITY,OFF_ADD_LINE_3,OFF_PHONE,OFF_CITY " +
                                 " FROM CPV_RL_CASE_DETAILS WHERE SEND_DATETIME IS NULL";

                        break;
                    case "EBC":
                        sSql = "SELECT '' as SR_NO,CASE_ID,REF_NO,FIRST_NAME,MIDDLE_NAME,LAST_NAME,DOB,ADD_LINE_1,ADD_LINE_2," +
                                "ADD_LINE_3,PIN_CODE,PHONE1,DESIGNATION,CITY " +
                                " FROM CPV_EBC_CASE_DETAILS WHERE SEND_DATETIME IS NULL";

                        break;
                    case "KYC":
                        sSql = "SELECT '' as SR_NO,CASE_ID,REF_NO,FIRST_NAME,MIDDLE_NAME,LAST_NAME,DOB,RES_ADD_LINE_1,RES_ADD_LINE_2," +
                                "RES_ADD_LINE_3,RES_PIN_CODE,RES_PHONE,OFF_NAME,DESIGNATION,OFF_ADD_LINE_1," +
                                "OFF_ADD_LINE_2,OFF_PIN_CODE,OFF_PHONE,RES_CITY,OFF_ADD_LINE_3,OFF_PHONE,OFF_CITY " +
                                " FROM CPV_KYC_CASE_DETAILS WHERE SEND_DATETIME IS NULL";

                        break;
                    case "CELLULAR":
                        sSql = "SELECT '' as SR_NO,CELLNO,CASE_ID,APP_FNAME,APP_MNAME,APP_LNAME,DATE_OF_BIRTH,APP_ADDR1,APP_ADDR2," +
                                "APP_ADDR3,APP_PINCODE,APP_PHONE1,COMP_NAME,DESIGNATION,COMP_ADDR1," +
                                "COMP_ADDR2,COMP_PINCODE,COMP_PHONE1,APP_CITY,COMP_ADDR3,COMP_PHONE2,COMP_CITY " +
                                " FROM CPV_CELLULAR_CASES WHERE SEND_DATETIME IS NULL";

                        break;
                    default:
                        break;
                }   //End of SWITCH
                DataSet dsInFileData = new DataSet();
                if (sSql.ToString() != "")
                {
                    if (Request.QueryString["CID"].ToString() != "")
                        sSql += " AND CENTRE_ID=" + Request.QueryString["CID"].ToString();

                    if (Request.QueryString["CLID"].ToString() != "")
                        sSql += " AND CLIENT_ID=" + Request.QueryString["CLID"].ToString();

                    if (Request.QueryString["RcdDt"].ToString() != "")
                    {
                        string strCaseRecdFDate = "";
                        string strCaseRecdTDate = "";
                        strCaseRecdFDate = objCmn.strDate(Request.QueryString["RcdDt"].ToString());
                        strCaseRecdTDate = Convert.ToDateTime(objCmn.strDate(Request.QueryString["RcdDt"].ToString())).AddDays(1.0).ToString("dd-MMM-yyyy");

                        sSql += " AND CASE_REC_DATETIME>='" + strCaseRecdFDate + "' AND CASE_REC_DATETIME<'" + strCaseRecdTDate + "'";

                    }
                    
                    dsInFileData = OleDbHelper.ExecuteDataset(objCmn.ConnectionString, CommandType.Text, sSql);
                }
                if (dsInFileData.Tables[0].Rows.Count > 0)
                {
                    DataSet dsNegMatchData;
                    DataSet dsResultant = new DataSet();
                    //---------------------------------------                    
                    DataColumn dcSrNo = new DataColumn("Sr_No");
                    DataColumn dcCaseId = new DataColumn("CaseId");
                    DataColumn dcSip_ref_no = new DataColumn("Sip_ref_no");
                    DataColumn dcFname = new DataColumn("Fname");
                    DataColumn dcMname = new DataColumn("Mname");
                    DataColumn dcSname = new DataColumn("Sname");
                    DataColumn dcDOB = new DataColumn("DOB");
                    DataColumn dcRadd1 = new DataColumn("Radd1");
                    DataColumn dcRadd2 = new DataColumn("Radd2");
                    DataColumn dcRadd3 = new DataColumn("Radd3");
                    DataColumn dcRpincode = new DataColumn("Rpincode");
                    DataColumn dcRTel = new DataColumn("RTel");
                    DataColumn dccompany = new DataColumn("company");
                    DataColumn dcDesgn = new DataColumn("Desgn");
                    DataColumn dcBadd1 = new DataColumn("Badd1");
                    DataColumn dcBadd2 = new DataColumn("Badd2");
                    DataColumn dcBPincode = new DataColumn("BPincode");
                    DataColumn dcbtel1 = new DataColumn("btel1");
                    DataColumn dccomment = new DataColumn("comment");

                    dtResultant.Columns.Add(dcSrNo);
                    dtResultant.Columns.Add(dcCaseId);
                    dtResultant.Columns.Add(dcSip_ref_no);
                    dtResultant.Columns.Add(dcFname);
                    dtResultant.Columns.Add(dcMname);
                    dtResultant.Columns.Add(dcSname);
                    dtResultant.Columns.Add(dcDOB);
                    dtResultant.Columns.Add(dcRadd1);
                    dtResultant.Columns.Add(dcRadd2);
                    dtResultant.Columns.Add(dcRadd3);
                    dtResultant.Columns.Add(dcRpincode);
                    dtResultant.Columns.Add(dcRTel);
                    dtResultant.Columns.Add(dccompany);
                    dtResultant.Columns.Add(dcDesgn);
                    dtResultant.Columns.Add(dcBadd1);
                    dtResultant.Columns.Add(dcBadd2);
                    dtResultant.Columns.Add(dcBPincode);
                    dtResultant.Columns.Add(dcbtel1);
                    dtResultant.Columns.Add(dccomment);
                    
                    for (int i = 0; i < dsInFileData.Tables[0].Rows.Count; i++)
                    {
                        
                        switch (Request.QueryString["PR"].ToString())
                        {
                            case "CC":
                            case "RL":
                            case "KYC":
                            case "IDOC":
                                //Assign values to property
                                CaseId = dsInFileData.Tables[0].Rows[i]["CASE_ID"].ToString();
                                RefNo = dsInFileData.Tables[0].Rows[i]["REF_NO"].ToString();
                                FirstName = dsInFileData.Tables[0].Rows[i]["FIRST_NAME"].ToString();
                                MiddleName = dsInFileData.Tables[0].Rows[i]["MIDDLE_NAME"].ToString();
                                LastName = dsInFileData.Tables[0].Rows[i]["LAST_NAME"].ToString();
                                if (dsInFileData.Tables[0].Rows[i]["DOB"].ToString() != "")
                                    DateOfBirth = dsInFileData.Tables[0].Rows[i]["DOB"].ToString(); 
                                else
                                    DateOfBirth = "";
                                ResAdd1 = dsInFileData.Tables[0].Rows[i]["RES_ADD_LINE_1"].ToString();
                                ResAdd2 = dsInFileData.Tables[0].Rows[i]["RES_ADD_LINE_2"].ToString();
                                ResAdd3 = dsInFileData.Tables[0].Rows[i]["RES_ADD_LINE_3"].ToString();
                                ResPin = dsInFileData.Tables[0].Rows[i]["RES_PIN_CODE"].ToString();
                                ResPhone = dsInFileData.Tables[0].Rows[i]["RES_PHONE"].ToString();
                                OfficeName = dsInFileData.Tables[0].Rows[i]["OFF_NAME"].ToString();
                                OfficeAdd1 = dsInFileData.Tables[0].Rows[i]["OFF_ADD_LINE_1"].ToString();
                                OfficeAdd2 = dsInFileData.Tables[0].Rows[i]["OFF_ADD_LINE_2"].ToString();
                                OfficeAdd3 = dsInFileData.Tables[0].Rows[i]["OFF_ADD_LINE_3"].ToString();
                                OfficePin = dsInFileData.Tables[0].Rows[i]["OFF_PIN_CODE"].ToString();
                                OfficePhone1 = dsInFileData.Tables[0].Rows[i]["OFF_PHONE"].ToString();
                                OfficePhone2 = dsInFileData.Tables[0].Rows[i]["OFF_PHONE"].ToString();
                                ResCity = dsInFileData.Tables[0].Rows[i]["RES_CITY"].ToString();
                                OfficeCity = dsInFileData.Tables[0].Rows[i]["OFF_CITY"].ToString();
                                break;
                            case "EBC":
                                CaseId = dsInFileData.Tables[0].Rows[i]["CASE_ID"].ToString();
                                RefNo = dsInFileData.Tables[0].Rows[i]["REF_NO"].ToString();
                                FirstName = dsInFileData.Tables[0].Rows[i]["FIRST_NAME"].ToString();
                                MiddleName = dsInFileData.Tables[0].Rows[i]["MIDDLE_NAME"].ToString();
                                LastName = dsInFileData.Tables[0].Rows[i]["LAST_NAME"].ToString();
                                if (dsInFileData.Tables[0].Rows[i]["DOB"].ToString() != "")
                                {
                                    DateOfBirth = dsInFileData.Tables[0].Rows[i]["DOB"].ToString(); 
                                }
                                else
                                    DateOfBirth = "";
                                ResAdd1 = dsInFileData.Tables[0].Rows[i]["ADD_LINE_1"].ToString();
                                ResAdd2 = dsInFileData.Tables[0].Rows[i]["ADD_LINE_2"].ToString();
                                ResAdd3 = dsInFileData.Tables[0].Rows[i]["ADD_LINE_3"].ToString();
                                ResPin = dsInFileData.Tables[0].Rows[i]["PIN_CODE"].ToString();
                                ResPhone = dsInFileData.Tables[0].Rows[i]["PHONE1"].ToString();
                                OfficeName = "";
                                OfficeAdd1 = "";
                                OfficeAdd2 = "";
                                OfficeAdd3 = "";
                                OfficePin = "";
                                OfficePhone1 = "";
                                OfficePhone2 = "";
                                ResCity = dsInFileData.Tables[0].Rows[i]["CITY"].ToString();
                                OfficeCity = "";
                                break;
                            case "CELLULAR":
                                CaseId = dsInFileData.Tables[0].Rows[i]["CASE_ID"].ToString();
                                RefNo = dsInFileData.Tables[0].Rows[i]["CELLNO"].ToString();
                                FirstName = dsInFileData.Tables[0].Rows[i]["APP_FNAME"].ToString();
                                MiddleName = dsInFileData.Tables[0].Rows[i]["APP_MNAME"].ToString();
                                LastName = dsInFileData.Tables[0].Rows[i]["APP_LNAME"].ToString();
                                if (dsInFileData.Tables[0].Rows[i]["DATE_OF_BIRTH"].ToString() != "")
                                    DateOfBirth = dsInFileData.Tables[0].Rows[i]["DATE_OF_BIRTH"].ToString();
                                else
                                    DateOfBirth = "";
                                ResAdd1 = dsInFileData.Tables[0].Rows[i]["APP_ADDR1"].ToString();
                                ResAdd2 = dsInFileData.Tables[0].Rows[i]["APP_ADDR2"].ToString();
                                ResAdd3 = dsInFileData.Tables[0].Rows[i]["APP_ADDR3"].ToString();
                                ResPin = dsInFileData.Tables[0].Rows[i]["APP_PINCODE"].ToString();
                                ResPhone = dsInFileData.Tables[0].Rows[i]["APP_PHONE1"].ToString();
                                OfficeName = dsInFileData.Tables[0].Rows[i]["COMP_NAME"].ToString();
                                OfficeAdd1 = dsInFileData.Tables[0].Rows[i]["COMP_ADDR1"].ToString();
                                OfficeAdd2 = dsInFileData.Tables[0].Rows[i]["COMP_ADDR2"].ToString();
                                OfficeAdd3 = dsInFileData.Tables[0].Rows[i]["COMP_ADDR3"].ToString();
                                OfficePin = dsInFileData.Tables[0].Rows[i]["COMP_PINCODE"].ToString();
                                OfficePhone1 = dsInFileData.Tables[0].Rows[i]["COMP_PHONE1"].ToString();
                                OfficePhone2 = dsInFileData.Tables[0].Rows[i]["COMP_PHONE2"].ToString();
                                ResCity = dsInFileData.Tables[0].Rows[i]["APP_CITY"].ToString();
                                OfficeCity = dsInFileData.Tables[0].Rows[i]["COMP_CITY"].ToString();
                                break;
                        }
                        //----------------------------------------------------------------------
                        OleDbParameter[] paramInFileData = new OleDbParameter[18];

                        paramInFileData[0] = new OleDbParameter("@fname", OleDbType.VarChar, 2000);
                        paramInFileData[0].Value = FirstName;
                        paramInFileData[0].Direction = ParameterDirection.Input;

                        paramInFileData[1] = new OleDbParameter("@mname", OleDbType.VarChar, 2000);
                        paramInFileData[1].Value = MiddleName;
                        paramInFileData[1].Direction = ParameterDirection.Input;

                        paramInFileData[2] = new OleDbParameter("@sname", OleDbType.VarChar, 2000);
                        paramInFileData[2].Value = LastName;
                        paramInFileData[2].Direction = ParameterDirection.Input;

                        paramInFileData[3] = new OleDbParameter("@dob", OleDbType.VarChar, 2000);
                        paramInFileData[3].Value = DateOfBirth;
                        paramInFileData[3].Direction = ParameterDirection.Input;

                        paramInFileData[4] = new OleDbParameter("@radd1", OleDbType.VarChar, 2000);
                        paramInFileData[4].Value = ResAdd1;
                        paramInFileData[4].Direction = ParameterDirection.Input;

                        paramInFileData[5] = new OleDbParameter("@radd2", OleDbType.VarChar, 2000);
                        paramInFileData[5].Value = ResAdd2;
                        paramInFileData[5].Direction = ParameterDirection.Input;

                        paramInFileData[6] = new OleDbParameter("@radd3", OleDbType.VarChar, 2000);
                        paramInFileData[6].Value = ResAdd3;
                        paramInFileData[6].Direction = ParameterDirection.Input;

                        paramInFileData[7] = new OleDbParameter("@rpincode", OleDbType.VarChar, 2000);
                        paramInFileData[7].Value = ResPin;
                        paramInFileData[7].Direction = ParameterDirection.Input;

                        paramInFileData[8] = new OleDbParameter("@rtel", OleDbType.VarChar, 2000);
                        paramInFileData[8].Value = ResPhone;
                        paramInFileData[8].Direction = ParameterDirection.Input;

                        paramInFileData[9] = new OleDbParameter("@company", OleDbType.VarChar, 2000);
                        paramInFileData[9].Value = OfficeName;
                        paramInFileData[9].Direction = ParameterDirection.Input;

                        paramInFileData[10] = new OleDbParameter("@badd1", OleDbType.VarChar, 2000);
                        paramInFileData[10].Value = OfficeAdd1;
                        paramInFileData[10].Direction = ParameterDirection.Input;

                        paramInFileData[11] = new OleDbParameter("@badd2", OleDbType.VarChar, 2000);
                        paramInFileData[11].Value = OfficeAdd2;
                        paramInFileData[11].Direction = ParameterDirection.Input;

                        paramInFileData[12] = new OleDbParameter("@bpincode", OleDbType.VarChar, 2000);
                        paramInFileData[12].Value = OfficePin;
                        paramInFileData[12].Direction = ParameterDirection.Input;

                        paramInFileData[13] = new OleDbParameter("@btel1", OleDbType.VarChar, 2000);
                        paramInFileData[13].Value = OfficePhone1;
                        paramInFileData[13].Direction = ParameterDirection.Input;

                        paramInFileData[14] = new OleDbParameter("@rcity", OleDbType.VarChar, 2000);
                        paramInFileData[14].Value = ResCity;
                        paramInFileData[14].Direction = ParameterDirection.Input;

                        paramInFileData[15] = new OleDbParameter("@badd3", OleDbType.VarChar, 2000);
                        paramInFileData[15].Value = OfficeAdd3;
                        paramInFileData[15].Direction = ParameterDirection.Input;

                        paramInFileData[16] = new OleDbParameter("@btel2", OleDbType.VarChar, 2000);
                        paramInFileData[16].Value = OfficePhone2;
                        paramInFileData[16].Direction = ParameterDirection.Input;

                        paramInFileData[17] = new OleDbParameter("@bcity", OleDbType.VarChar, 2000);
                        paramInFileData[17].Value = OfficeCity;
                        paramInFileData[17].Direction = ParameterDirection.Input;

                        ///get all records from negative database by using stored procedure "spExternalDedup"
                        ///where paramInFileData is input parameter ---------
                        dsNegMatchData = new DataSet();
                        dsNegMatchData = OleDbHelper.ExecuteDataset(objCmn.NegMatchConnectionString, CommandType.StoredProcedure, "spExternalDedup", paramInFileData);

                        //Create dataTable with Negative match cases -----

                        if (dsNegMatchData.Tables[0].Rows.Count > 0)
                        {
                            DataRow drResultant;
                            drResultant = dtResultant.NewRow();
                            
                            drResultant["Sr_NO"] = (i+1) + ".";
                            drResultant["CaseId"] = CaseId;
                            drResultant["Sip_ref_no"] = RefNo;                            
                            drResultant["Fname"] = FirstName;
                            drResultant["Mname"] = MiddleName;
                            drResultant["Sname"] = LastName;
                            drResultant["DOB"] = DateOfBirth;
                            drResultant["Radd1"] = ResAdd1;
                            drResultant["Radd2"] = ResAdd2;
                            drResultant["Radd3"] = ResAdd3;
                            drResultant["Rpincode"] = ResPin;
                            drResultant["RTel"] = ResPhone;
                            drResultant["company"] = OfficeName;
                            drResultant["Desgn"] = Designation;
                            drResultant["Badd1"] = OfficeAdd1;
                            drResultant["Badd2"] = OfficeAdd2;
                            drResultant["BPincode"] = OfficePin;
                            drResultant["btel1"] = OfficePhone1;
                            drResultant["comment"] = "";

                            dtResultant.Rows.Add(drResultant);

                            for (int j = 0; j < dsNegMatchData.Tables[0].Rows.Count; j++)
                            {
                                arrInfileSrNo.Add(j);
                                arrNegSrNo.Add(j);
                                drResultant = dtResultant.NewRow();
                                
                                drResultant["Sr_NO"] = j + 1;
                                drResultant["CaseId"] = "";
                                drResultant["Sip_ref_no"] = dsNegMatchData.Tables[0].Rows[j]["sip_ref_no"].ToString();
                                drResultant["Fname"] = dsNegMatchData.Tables[0].Rows[j]["fname"].ToString();
                                drResultant["Mname"] = dsNegMatchData.Tables[0].Rows[j]["mname"].ToString();
                                drResultant["Sname"] = dsNegMatchData.Tables[0].Rows[j]["sname"].ToString();
                                drResultant["DOB"] = dsNegMatchData.Tables[0].Rows[j]["dob"].ToString();
                                drResultant["Radd1"] = dsNegMatchData.Tables[0].Rows[j]["radd1"].ToString();
                                drResultant["Radd2"] = dsNegMatchData.Tables[0].Rows[j]["radd2"].ToString();
                                drResultant["Radd3"] = dsNegMatchData.Tables[0].Rows[j]["radd3"].ToString();
                                drResultant["Rpincode"] = dsNegMatchData.Tables[0].Rows[j]["rpincode"].ToString();
                                drResultant["RTel"] = dsNegMatchData.Tables[0].Rows[j]["rtel"].ToString();
                                drResultant["company"] = dsNegMatchData.Tables[0].Rows[j]["company"].ToString();
                                drResultant["Desgn"] = dsNegMatchData.Tables[0].Rows[j]["desgn"].ToString();
                                drResultant["Badd1"] = dsNegMatchData.Tables[0].Rows[j]["badd1"].ToString();
                                drResultant["Badd2"] = dsNegMatchData.Tables[0].Rows[j]["badd2"].ToString();
                                drResultant["BPincode"] = dsNegMatchData.Tables[0].Rows[j]["bpincode"].ToString();
                                drResultant["btel1"] = dsNegMatchData.Tables[0].Rows[j]["btel1"].ToString();
                                drResultant["comment"] = dsNegMatchData.Tables[0].Rows[j]["comment"].ToString();

                                dtResultant.Rows.Add(drResultant);                                    
                            }
                        }   //END of if (dsNegMatchData.Tables[0].Rows.Count > 0)
                        //-------------------------------------------------                        
                    }   //END of FOR each dsInFileData.Tables[0].Rows
                    //Insert into NEGTIVE_DEDUP_LOG table to update status ---
                    sSql = "";
                    sSql = "INSERT INTO NEGTIVE_DEDUP_LOG (ACTIVITY_ID,PRODUCT_ID,CLIENT_ID,CENTRE_ID," +
                         "CASES,DEDUP_DATE,DEDUP_STATUS,ADDBY,ADDDATE) VALUES(" +
                         "'" + Request.QueryString["AcID"].ToString() + "', " +
                         "'" + Request.QueryString["PID"].ToString() + "', " +
                         "'" + Request.QueryString["CLID"].ToString() + "', " +
                         "'" + Request.QueryString["CID"].ToString() + "', " +
                         dsInFileData.Tables[0].Rows.Count + ", " +
                         "'" + objCmn.strDate(Request.QueryString["RcdDt"].ToString()) + "', 'C'," +
                         "'" + Request.QueryString["UID"].ToString() + "', " +
                         "'" + System.DateTime.Now + "')";

                    OleDbHelper.ExecuteNonQuery(objCmn.ConnectionString, CommandType.Text, sSql);
                    ///---------------------------------------------------------------
                }   // END of dsInFileData.Tables[0].Rows.Count>0

                              
               
                if (dtResultant.Rows.Count > 0)
                {
                    StringWriter sw = new System.IO.StringWriter();
                    HtmlTextWriter htw = new HtmlTextWriter(sw);

                    Table tblDedupHead = new Table();                    
                    TableRow tblRow = new TableRow();
                    tblDedupHead.HorizontalAlign = HorizontalAlign.Center;
                    TableCell tblCell = new TableCell();
                    tblCell.HorizontalAlign = HorizontalAlign.Center;

                    tblCell.Text = "<br/><b><u><font size='5'>Dedup Status</font></u></b> <br/>" +
                                    "<b><font size='2'> Date :</font></b> " + Request.QueryString["RcdDt"].ToString() + "<br/>";
                    
                    tblCell.CssClass = "label";
                    tblCell.ColumnSpan = gvNegMatchData.Columns.Count;
                    tblRow.Cells.Add(tblCell);                    
                    tblDedupHead.Rows.Add(tblRow);

                    tblDedupHead.RenderControl(htw);
                    //-----------------
                    gvNegMatchData.Visible = true;
                    Response.ClearContent();
                    gvNegMatchData.BackColor = System.Drawing.Color.White;
                    gvNegMatchData.GridLines = GridLines.Both;
                    //gvNegMatchData.AutoGenerateColumns = false;
                    gvNegMatchData.AutoGenerateDeleteButton = false;
                    gvNegMatchData.AutoGenerateEditButton = false;
                    gvNegMatchData.AllowSorting = false;
                    gvNegMatchData.AllowPaging = false;
                    gvNegMatchData.EnableViewState = false;
                    gvNegMatchData.DataSource = dtResultant;
                    gvNegMatchData.DataBind();                   
                    
                    gvNegMatchData.Visible = true;                    
                    gvNegMatchData.RenderControl(htw);
                    
                    string HtmlInfo;
                    HtmlInfo = sw.ToString().Trim();
                    string sCentreName = "";
                    string sClientName = "";
                    sCentreName = GetCentreNameById(Request.QueryString["CID"].ToString());
                    sClientName = GetClientNameById(Request.QueryString["CLID"].ToString());

                    string strMapPath = Server.MapPath("../NegativeCases") + "/" +
                        sCentreName + "//" + Request.QueryString["PR"].ToString() + "//" + sClientName;

                    if (!Directory.Exists(strMapPath))
                    {
                        Directory.CreateDirectory(strMapPath);
                    }

                    strMapPath += "/" + sCentreName + "_" + Request.QueryString["PR"].ToString() + "_"
                                + sClientName + "_" + DateTime.Now.ToString("ddMMyyyyhhmmtt") + ".xls";

                    FileStream fs = new FileStream(strMapPath, FileMode.Create, FileAccess.ReadWrite);
                    BinaryWriter bWriter = new BinaryWriter(fs, System.Text.Encoding.GetEncoding("UTF-8"));
                    bWriter.Write(HtmlInfo);
                    bWriter.Close();
                    fs.Close();
                    gvNegMatchData.Visible = false;
                    lblMsg.Visible = true;
                    lblMsg.Text = "Negative dedup search has been completed for Client: '" +
                           GetClientById(Request.QueryString["CLID"].ToString()) + "' of " + 
                           GetCentreById(Request.QueryString["CID"].ToString()) + " Centre." ;
                            
                    lblMsg.Font.Bold = true;
                    dtResultant.Clear();
                    dtResultant.Dispose();
                }
                else
                {
                    lblMsg.Visible = true;
                    lblMsg.Text = "Record not found for Client: '" +
                           GetClientById(Request.QueryString["CLID"].ToString()) + "' of " +
                           GetCentreById(Request.QueryString["CID"].ToString()) + " Centre.";

                    lblMsg.Font.Bold = true;

                }
                dsInFileData.Clear();
                dsInFileData.Dispose();
                //----------------------------------------------------------
            }   //END of IF QueryString
            
        }   //End of TRY
        catch (Exception ex)
        {
            lblMsg.Visible = true;
            lblMsg.Text = "Error while External Dedup Search: " + ex.Message;
        }
    }

    private string GetCentreById(string strCentreID)
    {
        string SCentreNm = "";
        try
        {
            CCommon objCmn = new CCommon();
            string sSql = "";            
            OleDbDataReader oledbRead;
            sSql = "SELECT CENTRE_NAME FROM CENTRE_MASTER WHERE CENTRE_ID='" + strCentreID + "'";
            oledbRead = OleDbHelper.ExecuteReader(objCmn.ConnectionString, CommandType.Text, sSql);
            if (oledbRead.Read() == true)
                SCentreNm = oledbRead["CENTRE_NAME"].ToString();
            oledbRead.Close();
        }
        catch (Exception ex)
        {
            lblMsg.Visible = true;
            lblMsg.Text="Error while getting centre name: " + ex.Message;
        }
        return SCentreNm;
    }

    private string GetClientById(string strClientID)
    {
        string SClientNm = "";
        try
        {
            CCommon objCmn = new CCommon();
            string sSql = "";

            OleDbDataReader oledbRead;
            sSql = "SELECT CLIENT_NAME FROM CLIENT_MASTER WHERE CLIENT_ID='" + strClientID + "'";
            oledbRead = OleDbHelper.ExecuteReader(objCmn.ConnectionString, CommandType.Text, sSql);
            if (oledbRead.Read() == true)
                SClientNm = oledbRead["CLIENT_NAME"].ToString();
            oledbRead.Close();
        }
        catch (Exception ex)
        {
            lblMsg.Visible = true;
            lblMsg.Text="Error while getting Client name: " + ex.Message;
        }
        return SClientNm;
    }

    private string GetProductById(string strProductID)
    {
        string SProductNm = "";
        try
        {
            CCommon objCmn = new CCommon();
            string sSql = "";            
            OleDbDataReader oledbRead;
            sSql = "SELECT PRODUCT_NAME FROM CENTRE_MASTER WHERE PRODUCT_ID='" + strProductID + "'";
            oledbRead = OleDbHelper.ExecuteReader(objCmn.ConnectionString, CommandType.Text, sSql);
            if (oledbRead.Read() == true)
                SProductNm = oledbRead["PRODUCT_NAME"].ToString();
            oledbRead.Close();
        }
        catch (Exception ex)
        {
            lblMsg.Visible = true;
            lblMsg.Text="Error while getting Product name: " + ex.Message;
        }
        return SProductNm;
    }

    public override void VerifyRenderingInServerForm(Control control)
    {

    }

    protected void gvNegMatchData_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string str = "";
            str= e.Row.Cells[0].Text;

            if (str.Contains("."))
            {
                e.Row.BackColor = Color.LightBlue;
                e.Row.Font.Bold = true;
            }
            else
                e.Row.BackColor = Color.FromName("#FFFFE1");
        }

    }
}
