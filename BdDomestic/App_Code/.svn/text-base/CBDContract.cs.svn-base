using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.OleDb;

/// <summary>
/// Summary description for CBDContract
/// </summary>
public class CBDContract
{
    CCommon oCmn;
    public CBDContract()
    {
        oCmn = new CCommon();
        strDate = System.DateTime.Now.ToString();
        //
        // TODO: Add constructor logic here
        //
    }
    //PRESALE CONTRACT DETAILS
    #region property declaration    
    public String strDate;
    private String strContID;
    private String strContRefNo;
    private String strClientID;
    private String strClientDomain;
    private String strClientAddress;
    private String strContactPerson;
    private String strContactDesignation;
    private String strContactPhone;
    private String strContactEmail;
    private String strPresaleStatus;    
    private String strSerial;
    private String strRemark;   
    private String strActID;
    private String strProdID;
    private String strLeadBy;
    private String strLeadDate;
    private String strBDManager;
    public String[] arrActProdID;

    //Contract Meeting Detalis
    private String strMeetingID;
    private String strIsConfirmed;
    private String strConfirmDate;
    private String strSourceConfirm;
    private String strOrderNo;
    private String strOrderDate;
    private String strContEmpID;
    private String strMeetingFor;
    //add by kamal
    private String strMeetingLead;
    private String strMeetingDate;
    private String strMeetingPlace;
    private String strOfficerName;
    private String strMinutsofMeeting;
    private String strMeetingRemark;
    private String strCurrentUser;
    private String sPrefix;
    //add by kamal matekar
    private String sUserId;
    public string Prefix
    {
        get { return sPrefix; }
        set { sPrefix = value; }
    }
    public string ContID
    {
        get { return strContID; }
        set
        {
            if (value == "")
                strContID = null;
            else
                strContID = value;
        }
    }
    //add by kamal matekar 
    public string MeetingLead
    {
        get { return strMeetingLead; }
        set
        {
            if (value == "")
                strMeetingLead = null;
            else
                strMeetingLead = value;
        }
    }
    //end 
    public string ContRefNo
    {
        get { return strContRefNo; }
        set
        {
            if (value == "")
                strContRefNo = null;
            else
                strContRefNo = value;
        }
    }
    public string ClientID
    {
        get { return strClientID; }
        set
        {
            if (value == "")
                strClientID = null;
            else
                strClientID = value;
        }
    }
    public string ClientDomain
    {
        get { return strClientDomain; }
        set
        {
            if (value == "")
                strClientDomain = null;
            else
                strClientDomain = value;
        }
    }
    public string ClientAddress
    {
        get { return strClientAddress; }
        set
        {
            if (value == "")
                strClientAddress = null;
            else
                strClientAddress = value;
        }
    }
    public string ContactPerson
    {
        get { return strContactPerson; }
        set
        {
            if (value == "")
                strContactPerson = null;
            else
                strContactPerson = value;
        }
    }
    public string ContactDesignation
    {
        get { return strContactDesignation; }
        set
        {
            if (value == "")
                strContactDesignation = null;
            else
                strContactDesignation = value;
        }
    }
    public string ContactPhone
    {
        get { return strContactPhone; }
        set
        {
            if (value == "")
                strContactPhone = null;
            else
                strContactPhone = value;
        }
    }
    public string ContactEmail
    {
        get { return strContactEmail; }
        set
        {
            if (value == "")
                strContactEmail = null;
            else
                strContactEmail = value;
        }
    }
    public string PresaleStatus
    {
        get { return strPresaleStatus; }
        set
        {
            if (value == "")
                strPresaleStatus = null;
            else
                strPresaleStatus = value;
        }
    }
    public string Serial
    {
        get { return strSerial; }
        set
        {
            if (value == "")
                strSerial = null;
            else
                strSerial = value;
        }
    }
    public string Remark
    {
        get { return strRemark; }
        set
        {
            if (value == "")
                strRemark = null;
            else
                strRemark = value;
        }
    }
    public string ActID
    {
        get { return strActID; }
        set
        {
            if (value == "")
                strActID = null;
            else
                strActID = value;
        }
    }
    public string ProdID
    {
        get { return strProdID; }
        set
        {
            if (value == "")
                strProdID = null;
            else
                strProdID = value;
        }
    }
    public string LeadBy
    {
        get { return strLeadBy; }
        set
        {
            if (value == "")
                strLeadBy = null;
            else
                strLeadBy = value;
        }
    }
    public string LeadDate
    {
        get { return strLeadDate; }
        set
        {
            if (value == "")
                strLeadDate = null;
            else
                strLeadDate = value;
        }
    }
    public string BDManager
    {
        get { return strBDManager; }
        set
        {
            if (value == "")
                strBDManager = null;
            else
                strBDManager = value;
        }
    }
    //Meeting Detail 
    public string MeetingID
    {
        get { return strMeetingID; }
        set
        {
            if (value == "")
                strMeetingID = null;
            else
                strMeetingID = value;
        }
    }
    public string IsConfirmed
    {
        get { return strIsConfirmed; }
        set
        {
            if (value == "")
                strIsConfirmed = null;
            else
                strIsConfirmed = value;
        }
    }
    public string ConfirmDate
    {
        get { return strConfirmDate; }
        set
        {
            if (value == "")
                strConfirmDate = null;
            else
                strConfirmDate = value;
        }
    }
    public string SourceConfirm
    {
        get { return strSourceConfirm; }
        set
        {
            if (value == "")
                strSourceConfirm = null;
            else
                strSourceConfirm = value;
        }
    }
    public string OrderNo
    {
        get { return strOrderNo; }
        set
        {
            if (value == "")
                strOrderNo = null;
            else
                strOrderNo = value;
        }
    }
    public string OrderDate
    {
        get { return strOrderDate; }
        set
        {
            if (value == "")
                strOrderDate = null;
            else
                strOrderDate = value;
        }
    }
    public string ContEmpID
    {
        get { return strContEmpID; }
        set
        {
            if (value == "")
                strContEmpID = null;
            else
                strContEmpID = value;
        }
    }
    public string MeetingFor
    {
        get { return strMeetingFor; }
        set
        {
            if (value == "")
                strMeetingFor = null;
            else
                strMeetingFor = value;
        }
    }
    public string MeetingDate
    {
        get { return strMeetingDate; }
        set
        {
            if (value == "")
                strMeetingDate = null;
            else
                strMeetingDate = value;
        }
    }
    public string MeetingPlace
    {
        get { return strMeetingPlace; }
        set
        {
            if (value == "")
                strMeetingPlace = null;
            else
                strMeetingPlace = value;
        }
    }
    public string OfficerName
    {
        get { return strOfficerName; }
        set
        {
            if (value == "")
                strOfficerName = null;
            else
                strOfficerName = value;
        }
    }
    public string MinutsofMeeting
    {
        get { return strMinutsofMeeting; }
        set
        {
            if (value == "")
                strMinutsofMeeting = null;
            else
                strMinutsofMeeting = value;
        }
    }
    public string MeetingRemark
    {
        get { return strMeetingRemark; }
        set
        {
            if (value == "")
                strMeetingRemark = null;
            else
                strMeetingRemark = value;
        }
    }
    public string CurrentUser
    {
        get { return strCurrentUser; }
        set
        {
            if (value == "")
                strCurrentUser = null;
            else
                strCurrentUser = value;
        }
    }
    #endregion
    
    public DataSet GetActProd()
    {
        DataSet ds;
        OleDbConnection conn = new OleDbConnection(oCmn.ConnectionString);
        conn.Open();
        OleDbTransaction trans = conn.BeginTransaction();
        try
        {
            String sSql = "SELECT ACTIVITY_ID, PRODUCT_ID FROM PRESALE_CONTRACT_ACTIVITY_PRODUCT WHERE CONT_PRESALE_ID='" + ContID + "'";
            ds = OleDbHelper.ExecuteDataset(trans, CommandType.Text, sSql);
            trans.Commit();
            conn.Close();
        }
        catch (Exception exp)
        {
            trans.Rollback();
            conn.Close();
            throw new Exception("An error occurred ", exp);
        }
        return ds;
    }

    public DataSet GetPresaleContractDetail()
    {
        DataSet ds;
        OleDbConnection conn = new OleDbConnection(oCmn.ConnectionString);
        conn.Open();
        OleDbTransaction trans = conn.BeginTransaction();
        try
        {
            String sSql = "SELECT CONT_PRESALE_REF_NO, CLIENT_ID, CLIENT_DOMAIN, CLIENT_ADDRESS, CONTACT_PERSON, CONTACT_DESIGNATION, " +
                            "CONTACT_TELEPHONE, CONTACT_EMAIL, PRESALE_STATUS, IS_CONFIRMED, " +
                            "SERIAL, REMARK, LEAD_BY, LEAD_DATE, BD_MANAGER_ID FROM PRESALE_CONTRACT_DETAIL WHERE CONT_PRESALE_ID='" + ContID + "'";
            ds = OleDbHelper.ExecuteDataset(trans, CommandType.Text, sSql);
            trans.Commit();
            conn.Close();
        }
        catch (Exception exp)
        {
            trans.Rollback();
            conn.Close();
            throw new Exception("An error occurred ", exp);
        }
        return ds;
    }    
    public String getDomain(String strClientID)
    {
        String strDomain = "";
        OleDbConnection conn = new OleDbConnection(oCmn.ConnectionString);
        conn.Open();
        OleDbTransaction trans = conn.BeginTransaction();
        try
        {
            String sSql = "SELECT CLIENT_DOMAIN FROM CLIENT_MASTER WHERE CLIENT_ID='" + strClientID + "'";
            OleDbDataReader sqlRead = OleDbHelper.ExecuteReader(trans, CommandType.Text, sSql);

            if (sqlRead.Read())
                strDomain = sqlRead[0].ToString();
           
            trans.Commit();
            conn.Close();
        }
        catch (Exception exp)
        {
            trans.Rollback();
            conn.Close();
            throw new Exception("An error occurred ", exp);
        }
        return strDomain;
    }
    public void getSerial()
    {
        OleDbConnection conn = new OleDbConnection(oCmn.ConnectionString);
        conn.Open();
        OleDbTransaction trans = conn.BeginTransaction();
        try
        {
            String sSql = "SELECT LAST_ID FROM LAST_DETAIL WHERE TABLE_NAME='PRESALE_CONTRACT_DETAIL'";
            OleDbDataReader sqlRead = OleDbHelper.ExecuteReader(trans, CommandType.Text, sSql);
           
            if (sqlRead.Read())
                Serial = sqlRead[0].ToString();
            if (Serial == null || Serial == "")
                Serial = "1";  
            trans.Commit();
            conn.Close();
        }
        catch (Exception exp)
        {
            trans.Rollback();
            conn.Close();
            throw new Exception("An error occurred ", exp);
        }        
    }
    public void getContSerial()
    {
        OleDbConnection conn = new OleDbConnection(oCmn.ConnectionString);
        conn.Open();
        OleDbTransaction trans = conn.BeginTransaction();
        try
        {
            String sSql = "SELECT LAST_ID FROM LAST_DETAIL WHERE TABLE_NAME='CONTRACT_DETAILS'";
            OleDbDataReader sqlRead = OleDbHelper.ExecuteReader(trans, CommandType.Text, sSql);

            if (sqlRead.Read())
                Serial = sqlRead[0].ToString();
            if (Serial == null || Serial == "")
                Serial = "1";
            trans.Commit();
            conn.Close();
        }
        catch (Exception exp)
        {
            trans.Rollback();
            conn.Close();
            throw new Exception("An error occurred ", exp);
        }
    }
    public void InsertPresaleContractDetail()
    {
        OleDbConnection conn = new OleDbConnection(oCmn.ConnectionString);
        conn.Open();
        OleDbTransaction trans = conn.BeginTransaction();       
        try
        {
            //add by kamal matekar
            ContID = oCmn.GetUniqueID("PRESALE_CONTRACT_DETAIL_SERIAL", "");
            //end
            ContID = oCmn.GetUniqueID("PRESALE_CONTRACT_DETAIL", Prefix);

            String sQuery = "INSERT INTO PRESALE_CONTRACT_DETAIL (CONT_PRESALE_ID, CONT_PRESALE_REF_NO, " +
                            "CLIENT_ID, CLIENT_DOMAIN, CLIENT_ADDRESS, CONTACT_PERSON, CONTACT_DESIGNATION, " +
                            "CONTACT_TELEPHONE, CONTACT_EMAIL, PRESALE_STATUS, IS_CONFIRMED, " +
                            "SERIAL, REMARK, LEAD_BY, LEAD_DATE, BD_MANAGER_ID) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
            OleDbParameter[] paramPreCont = new OleDbParameter[16];
            paramPreCont[0] = new OleDbParameter("@CONT_PRESALE_ID", OleDbType.VarChar, 15);
            paramPreCont[0].Value = ContID;
            paramPreCont[1] = new OleDbParameter("@CONT_PRESALE_REF_NO", OleDbType.VarChar, 50);
            paramPreCont[1].Value = ContRefNo;
            paramPreCont[2] = new OleDbParameter("@CLIENT_ID", OleDbType.VarChar, 15);
            paramPreCont[2].Value = ClientID;
            paramPreCont[3] = new OleDbParameter("@CLIENT_DOMAIN", OleDbType.VarChar, 100);
            paramPreCont[3].Value = ClientDomain;
            paramPreCont[4] = new OleDbParameter("@CLIENT_ADDRESS", OleDbType.VarChar, 300);
            paramPreCont[4].Value = ClientAddress;
            paramPreCont[5] = new OleDbParameter("@CONTACT_PERSON", OleDbType.VarChar, 100);
            paramPreCont[5].Value = ContactPerson;
            paramPreCont[6] = new OleDbParameter("@CONTACT_DESIGNATION", OleDbType.VarChar, 100);
            paramPreCont[6].Value = ContactDesignation;
            paramPreCont[7] = new OleDbParameter("@CONTACT_TELEPHONE", OleDbType.VarChar, 100);
            paramPreCont[7].Value = ContactPhone;
            paramPreCont[8] = new OleDbParameter("@CONTACT_EMAIL", OleDbType.VarChar, 200);
            paramPreCont[8].Value = ContactEmail;
            paramPreCont[9] = new OleDbParameter("@PRESALE_STATUS", OleDbType.VarChar, 30);
            paramPreCont[9].Value = PresaleStatus;
            paramPreCont[10] = new OleDbParameter("@IS_CONFIRMED", OleDbType.VarChar, 1);
            paramPreCont[10].Value = IsConfirmed;
            //paramPreCont[11] = new OleDbParameter("@CONFIRM_DATE", OleDbType.Date, 8);
            //paramPreCont[11].Value = ConfirmDate;
            //paramPreCont[12] = new OleDbParameter("@ORDER_NO", OleDbType.VarChar, 100);
            //paramPreCont[12].Value = OrderNo;
            //paramPreCont[13] = new OleDbParameter("@ORDER_DATE", OleDbType.Date, 8);
            //paramPreCont[13].Value = OrderDate;
            paramPreCont[11] = new OleDbParameter("@SERIAL", OleDbType.Numeric, 9);
            paramPreCont[11].Value = Serial;
            paramPreCont[12] = new OleDbParameter("@REMARK", OleDbType.VarChar, 500);
            paramPreCont[12].Value = Remark;
            paramPreCont[13] = new OleDbParameter("@LEAD_BY", OleDbType.VarChar, 15);
            paramPreCont[13].Value = LeadBy;
            paramPreCont[14] = new OleDbParameter("@LEAD_DATE", OleDbType.Date, 8);
            paramPreCont[14].Value = LeadDate;
            paramPreCont[15] = new OleDbParameter("@BD_MANAGER_ID", OleDbType.VarChar, 15);
            paramPreCont[15].Value = BDManager;

            String sQuery1 = "INSERT INTO PRESALE_CONTRACT_ACTIVITY_PRODUCT (CONT_PRESALE_ID, ACTIVITY_ID, PRODUCT_ID) "+
                             "VALUES(?,?,?)";
                        
             foreach (string a in arrActProdID)
             {
                 OleDbParameter[] paramProAct = new OleDbParameter[3];
                 paramProAct[0] = new OleDbParameter("@CONT_PRESALE_ID", OleDbType.VarChar, 15);
                 paramProAct[0].Value = ContID;
                 paramProAct[1] = new OleDbParameter("@ACTIVITY_ID", OleDbType.VarChar, 15);
                 paramProAct[2] = new OleDbParameter("@PRODUCT_ID", OleDbType.VarChar, 15);

                 ActID = a.Substring(0, a.LastIndexOf(":"));
                 ProdID = a.Substring(a.LastIndexOf(":") + 1);
                 paramProAct[1].Value = ActID;
                 paramProAct[2].Value = ProdID;
                 OleDbHelper.ExecuteNonQuery(trans, CommandType.Text, sQuery1, paramProAct);

             }
            OleDbHelper.ExecuteNonQuery(trans, CommandType.Text, sQuery, paramPreCont);            
            trans.Commit();
            conn.Close();
        }
        catch (Exception exp)
        {
            trans.Rollback();
            conn.Close();
            throw new Exception("An error occurred ", exp);
        }
    }
    public void UpdatePresaleContractDetail()
    {
        OleDbConnection conn = new OleDbConnection(oCmn.ConnectionString);
        conn.Open();
        OleDbTransaction trans = conn.BeginTransaction();
        try
        {
            String sQuery = "UPDATE PRESALE_CONTRACT_DETAIL SET CLIENT_ID=?, CLIENT_DOMAIN=?, CLIENT_ADDRESS=?, CONTACT_PERSON=?, CONTACT_DESIGNATION=?, " +
                            "CONTACT_TELEPHONE=?, CONTACT_EMAIL=?, REMARK=?, LEAD_BY=?, LEAD_DATE=?, BD_MANAGER_ID=? WHERE CONT_PRESALE_ID='" + ContID + "'";
            OleDbParameter[] paramPreCont = new OleDbParameter[11];            
            paramPreCont[0] = new OleDbParameter("@CLIENT_ID", OleDbType.VarChar, 15);
            paramPreCont[0].Value = ClientID;
            paramPreCont[1] = new OleDbParameter("@CLIENT_DOMAIN", OleDbType.VarChar, 100);
            paramPreCont[1].Value = ClientDomain;
            paramPreCont[2] = new OleDbParameter("@CLIENT_ADDRESS", OleDbType.VarChar, 300);
            paramPreCont[2].Value = ClientAddress;
            paramPreCont[3] = new OleDbParameter("@CONTACT_PERSON", OleDbType.VarChar, 100);
            paramPreCont[3].Value = ContactPerson;
            paramPreCont[4] = new OleDbParameter("@CONTACT_DESIGNATION", OleDbType.VarChar, 100);
            paramPreCont[4].Value = ContactDesignation;
            paramPreCont[5] = new OleDbParameter("@CONTACT_TELEPHONE", OleDbType.VarChar, 100);
            paramPreCont[5].Value = ContactPhone;
            paramPreCont[6] = new OleDbParameter("@CONTACT_EMAIL", OleDbType.VarChar, 200);
            paramPreCont[6].Value = ContactEmail;
            //paramPreCont[7] = new OleDbParameter("@PRESALE_STATUS", OleDbType.VarChar, 30);
            //paramPreCont[7].Value = PresaleStatus;
            //paramPreCont[8] = new OleDbParameter("@IS_CONFIRMED", OleDbType.VarChar, 1);
            //paramPreCont[8].Value = IsConfirmed;                       
            paramPreCont[7] = new OleDbParameter("@REMARK", OleDbType.VarChar, 500);
            paramPreCont[7].Value = Remark;
            paramPreCont[8] = new OleDbParameter("@LEAD_BY", OleDbType.VarChar, 15);
            paramPreCont[8].Value = LeadBy;
            paramPreCont[9] = new OleDbParameter("@LEAD_DATE", OleDbType.Date, 8);
            paramPreCont[9].Value = LeadDate;
            paramPreCont[10] = new OleDbParameter("@BD_MANAGER_ID", OleDbType.VarChar, 15);
            paramPreCont[10].Value = BDManager;

            String sQuery2 = "DELETE PRESALE_CONTRACT_ACTIVITY_PRODUCT WHERE CONT_PRESALE_ID='" + ContID + "'";
            
            String sQuery1 = "INSERT INTO PRESALE_CONTRACT_ACTIVITY_PRODUCT (CONT_PRESALE_ID, ACTIVITY_ID, PRODUCT_ID) " +
                             "VALUES(?,?,?)";
            OleDbHelper.ExecuteNonQuery(trans, CommandType.Text, sQuery2);
            if(arrActProdID!=null)
            foreach (string a in arrActProdID)
            {
                OleDbParameter[] paramProAct = new OleDbParameter[3];
                paramProAct[0] = new OleDbParameter("@CONT_PRESALE_ID", OleDbType.VarChar, 15);
                paramProAct[0].Value = ContID;
                paramProAct[1] = new OleDbParameter("@ACTIVITY_ID", OleDbType.VarChar, 15);
                paramProAct[2] = new OleDbParameter("@PRODUCT_ID", OleDbType.VarChar, 15);

                ActID = a.Substring(0, a.LastIndexOf(":"));
                ProdID = a.Substring(a.LastIndexOf(":") + 1);
                paramProAct[1].Value = ActID;
                paramProAct[2].Value = ProdID;
                OleDbHelper.ExecuteNonQuery(trans, CommandType.Text, sQuery1, paramProAct);
            }
            OleDbHelper.ExecuteNonQuery(trans, CommandType.Text, sQuery, paramPreCont);
            trans.Commit();
            conn.Close();
        }
        catch (Exception exp)
        {
            trans.Rollback();
            conn.Close();
            throw new Exception("An error occurred ", exp);
        }
    }
    public DataSet GetMeetingDetail()
    {
        DataSet ds;
        OleDbConnection conn = new OleDbConnection(oCmn.ConnectionString);
        conn.Open();
        OleDbTransaction trans = conn.BeginTransaction();
        try
        {
            String sSql = "SELECT A.CONTACT_EMP_ID, A.MEETING_FOR, A.Meeting_Lead, A.MEETING_DATE, A.MEETING_PLACE, A.OFFICER_NAME, " +
                            "A.MINUTES_MEETING, A.REMARK, B.IS_CONFIRMED, B.SOURCE_CONFIRM, B.CONFIRM_DATE, B.ORDER_NO, B.ORDER_DATE " +
                            "FROM PRESALE_CONTRACT_MEETING_DETAIL A LEFT JOIN PRESALE_CONTRACT_DETAIL B ON A.CONT_PRESALE_ID=B.CONT_PRESALE_ID " +
                            "WHERE A.CONT_PRESALE_ID='" + ContID + "' AND A.MEETING_DET_ID='" + MeetingID + "'";
            ds = OleDbHelper.ExecuteDataset(trans, CommandType.Text, sSql);
            trans.Commit();
            conn.Close();
        }
        catch (Exception exp)
        {
            trans.Rollback();
            conn.Close();
            throw new Exception("An error occurred ", exp);
        }
        return ds;
    }
    public void InsertPresaleMeetingDetail()
    {
        OleDbConnection conn = new OleDbConnection(oCmn.ConnectionString);
        conn.Open();
        OleDbTransaction trans = conn.BeginTransaction();
        try
        {
            MeetingID = oCmn.GetUniqueID("PRESALE_CONTRACT_MEETING_DETAIL", Prefix);

            String sQuery = "INSERT INTO PRESALE_CONTRACT_MEETING_DETAIL (CONT_PRESALE_ID, CONTACT_EMP_ID, " +
                           "MEETING_FOR,MEETING_DATE, MEETING_PLACE, OFFICER_NAME, MINUTES_MEETING, REMARK, " +
                           "ADD_BY, ADD_DATE, MEETING_DET_ID,Meeting_Lead) VALUES(?,?,?,?,?,?,?,?,?,?,?,?)";
            OleDbParameter[] paramMeetingDetail = new OleDbParameter[12];
            paramMeetingDetail[0] = new OleDbParameter("@CONT_PRESALE_ID", OleDbType.VarChar, 15);
            paramMeetingDetail[0].Value = ContID;
            paramMeetingDetail[1] = new OleDbParameter("@CONTACT_EMP_ID", OleDbType.VarChar, 50);
            paramMeetingDetail[1].Value = ContEmpID;
            paramMeetingDetail[2] = new OleDbParameter("@MEETING_FOR", OleDbType.VarChar, 15);
            paramMeetingDetail[2].Value = MeetingFor;
            paramMeetingDetail[3] = new OleDbParameter("@MEETING_DATE", OleDbType.VarChar, 100);
            paramMeetingDetail[3].Value = MeetingDate;
            paramMeetingDetail[4] = new OleDbParameter("@MEETING_PLACE", OleDbType.VarChar, 300);
            paramMeetingDetail[4].Value = MeetingPlace;
            paramMeetingDetail[5] = new OleDbParameter("@OFFICER_NAME", OleDbType.VarChar, 100);
            paramMeetingDetail[5].Value = OfficerName;
            paramMeetingDetail[6] = new OleDbParameter("@MINUTES_MEETING", OleDbType.VarChar, 500);
            paramMeetingDetail[6].Value = MinutsofMeeting;
            paramMeetingDetail[7] = new OleDbParameter("@REMARK", OleDbType.VarChar, 500);
            paramMeetingDetail[7].Value = MeetingRemark;
            paramMeetingDetail[8] = new OleDbParameter("@ADD_BY", OleDbType.VarChar, 200);
            paramMeetingDetail[8].Value = CurrentUser;
            paramMeetingDetail[9] = new OleDbParameter("@ADD_DATE", OleDbType.VarChar, 30);
            paramMeetingDetail[9].Value = strDate;
            paramMeetingDetail[10] = new OleDbParameter("@MEETING_DET_ID", OleDbType.VarChar, 15);
            paramMeetingDetail[10].Value = MeetingID;
            //add by kamal matekar
            paramMeetingDetail[11] = new OleDbParameter("@Meeting_Lead", OleDbType.VarChar, 15);
            paramMeetingDetail[11].Value = MeetingLead;
            //end
            String sQuery1 = "UPDATE PRESALE_CONTRACT_DETAIL SET PRESALE_STATUS=?, IS_CONFIRMED=?, " +
                            "CONFIRM_DATE=?, ORDER_NO=?, ORDER_DATE=?, SOURCE_CONFIRM=? WHERE CONT_PRESALE_ID='" + ContID + "'";
            OleDbParameter[] paramPreCont = new OleDbParameter[6];            
            paramPreCont[0] = new OleDbParameter("@PRESALE_STATUS", OleDbType.VarChar, 30);
            paramPreCont[0].Value = PresaleStatus;
            paramPreCont[1] = new OleDbParameter("@IS_CONFIRMED", OleDbType.VarChar, 1);
            paramPreCont[1].Value = IsConfirmed;
            paramPreCont[2] = new OleDbParameter("@CONFIRM_DATE", OleDbType.Date, 8);
            paramPreCont[2].Value = ConfirmDate;           
            paramPreCont[3] = new OleDbParameter("@ORDER_NO", OleDbType.VarChar, 100);
            paramPreCont[3].Value = OrderNo;
            paramPreCont[4] = new OleDbParameter("@ORDER_DATE", OleDbType.Date, 8);
            paramPreCont[4].Value = OrderDate;
            paramPreCont[5] = new OleDbParameter("@SOURCE_CONFIRM", OleDbType.VarChar, 200);
            paramPreCont[5].Value = SourceConfirm;

            OleDbHelper.ExecuteNonQuery(trans, CommandType.Text, sQuery, paramMeetingDetail);
            OleDbHelper.ExecuteNonQuery(trans, CommandType.Text, sQuery1, paramPreCont);
            trans.Commit();
            conn.Close();
        }
        catch (Exception exp)
        {
            trans.Rollback();
            conn.Close();
            throw new Exception("An error occurred ", exp);
        }
    }
    public void UpdatePresaleMeetingDetail()
    {
        OleDbConnection conn = new OleDbConnection(oCmn.ConnectionString);
        conn.Open();
        OleDbTransaction trans = conn.BeginTransaction();
        try
        {
            String sQuery = "UPDATE PRESALE_CONTRACT_MEETING_DETAIL SET CONTACT_EMP_ID=?, " +
                            "MEETING_FOR=?, MEETING_DATE=?, MEETING_PLACE=?, OFFICER_NAME=?, MINUTES_MEETING=?, REMARK=?, " +
                            "MODIFY_BY=?, MODIFY_DATE=?, Meeting_Lead=? WHERE MEETING_DET_ID='" + MeetingID + "'";
            OleDbParameter[] paramMeetingDetail = new OleDbParameter[10];           
            paramMeetingDetail[0] = new OleDbParameter("@CONTACT_EMP_ID", OleDbType.VarChar, 50);
            paramMeetingDetail[0].Value = ContEmpID;
            paramMeetingDetail[1] = new OleDbParameter("@MEETING_FOR", OleDbType.VarChar, 15);
            paramMeetingDetail[1].Value = MeetingFor;
            paramMeetingDetail[2] = new OleDbParameter("@MEETING_DATE", OleDbType.VarChar, 100);
            paramMeetingDetail[2].Value = MeetingDate;
            paramMeetingDetail[3] = new OleDbParameter("@MEETING_PLACE", OleDbType.VarChar, 300);
            paramMeetingDetail[3].Value = MeetingPlace;
            paramMeetingDetail[4] = new OleDbParameter("@OFFICER_NAME", OleDbType.VarChar, 100);
            paramMeetingDetail[4].Value = OfficerName;
            paramMeetingDetail[5] = new OleDbParameter("@MINUTES_MEETING", OleDbType.VarChar, 500);
            paramMeetingDetail[5].Value = MinutsofMeeting;
            paramMeetingDetail[6] = new OleDbParameter("@REMARK", OleDbType.VarChar, 500);
            paramMeetingDetail[6].Value = MeetingRemark;
            paramMeetingDetail[7] = new OleDbParameter("@MODIFY_BY", OleDbType.VarChar, 200);
            paramMeetingDetail[7].Value = CurrentUser;
            paramMeetingDetail[8] = new OleDbParameter("@MODIFY_DATE", OleDbType.VarChar, 30);
            paramMeetingDetail[8].Value = strDate;
            //add by kamal matekar
            paramMeetingDetail[9] = new OleDbParameter("@Meeting_Lead", OleDbType.VarChar, 30);
            paramMeetingDetail[9].Value = MeetingLead;
            //end

            String sQuery1 = "UPDATE PRESALE_CONTRACT_DETAIL SET IS_CONFIRMED=?, " +
                            "CONFIRM_DATE=?, ORDER_NO=?, ORDER_DATE=?, SOURCE_CONFIRM=? WHERE CONT_PRESALE_ID='" + ContID + "'";
            OleDbParameter[] paramPreCont = new OleDbParameter[5];            
            paramPreCont[0] = new OleDbParameter("@IS_CONFIRMED", OleDbType.VarChar, 1);
            paramPreCont[0].Value = IsConfirmed;
            paramPreCont[1] = new OleDbParameter("@CONFIRM_DATE", OleDbType.Date, 8);
            paramPreCont[1].Value = ConfirmDate;
            paramPreCont[2] = new OleDbParameter("@ORDER_NO", OleDbType.VarChar, 100);
            paramPreCont[2].Value = OrderNo;
            paramPreCont[3] = new OleDbParameter("@ORDER_DATE", OleDbType.Date, 8);
            paramPreCont[3].Value = OrderDate;
            paramPreCont[4] = new OleDbParameter("@SOURCE_CONFIRM", OleDbType.VarChar, 200);
            paramPreCont[4].Value = SourceConfirm;

            OleDbHelper.ExecuteNonQuery(trans, CommandType.Text, sQuery, paramMeetingDetail);
            OleDbHelper.ExecuteNonQuery(trans, CommandType.Text, sQuery1, paramPreCont);
            trans.Commit();
            conn.Close();
        }
        catch (Exception exp)
        {
            trans.Rollback();
            conn.Close();
            throw new Exception("An error occurred ", exp);
        }
    }

    //CONFIRMED CONTRACT DETAILS
#region property declaration
    private String strPresaleContID;
    private String strContractID;
    private String strContractNo;
    private String strContractDate;
    private String strContractExpiryDate;
    private String strProjectImplementDate;
    private String strProjectStartDate;
    private String strProjectImplementBy;
    private String strExpectedTo;
    private String strStatusAfterMonths;
    private String strMinVolMonth;
    private String strRateChartID;
    public DataSet dsRateChart;
    private String strVolumeSlabID;
    public DataSet dsVolumeSlab;
    private String strPenaltyID;
    public DataSet dsPenalty;
    private String strBonusID;
    public DataSet dsBonus;
    private String strMinGrtMonth;
    private String strIETax;
    public string PresaleContID
    {
        get { return strPresaleContID; }
        set
        {
            if (value == "")
                strPresaleContID = null;
            else
                strPresaleContID = value;
        }
    }
    public string ContractID
    {
        get { return strContractID; }
        set
        {
            if (value == "")
                strContractID = null;
            else
                strContractID = value;
        }
    }
    public string ContractNo
    {
        get { return strContractNo; }
        set
        {
            if (value == "")
                strContractNo = null;
            else
                strContractNo = value;
        }
    }
    public string ContractDate
    {
        get { return strContractDate; }
        set
        {
            if (value == "")
                strContractDate = null;
            else
                strContractDate = value;
        }
    }
    public string ContractExpiryDate
    {
        get { return strContractExpiryDate; }
        set
        {
            if (value == "")
                strContractExpiryDate = null;
            else
                strContractExpiryDate = value;
        }
    }
    public string ProjectImplementDate
    {
        get { return strProjectImplementDate; }
        set
        {
            if (value == "")
                strProjectImplementDate = null;
            else
                strProjectImplementDate = value;
        }
    }
    public string ProjectStartDate
    {
        get { return strProjectStartDate; }
        set
        {
            if (value == "")
                strProjectStartDate = null;
            else
                strProjectStartDate = value;
        }
    }
    public string ProjectImplementBy
    {
        get { return strProjectImplementBy; }
        set
        {
            if (value == "")
                strProjectImplementBy = null;
            else
                strProjectImplementBy = value;
        }
    }
    public string ExpectedTo
    {
        get { return strExpectedTo; }
        set
        {
            if (value == "")
                strExpectedTo = null;
            else
                strExpectedTo = value;
        }
    }
    public string StatusAfterMonths
    {
        get { return strStatusAfterMonths; }
        set
        {
            if (value == "")
                strStatusAfterMonths = null;
            else
                strStatusAfterMonths = value;
        }
    }
    public string MinVolMonth
    {
        get { return strMinVolMonth; }
        set
        {
            if (value == "")
                strMinVolMonth = null;
            else
                strMinVolMonth = value;
        }
    }

    public string MinGrtMonth
    {
        get { return strMinGrtMonth; }
        set
        {
            if (value == "")
                strMinGrtMonth = null;
            else
                strMinGrtMonth = value;
        }
    }
    public string IETax
    {
        get { return strIETax; }
        set
        {
            if (value == "")
                strIETax = null;
            else
                strIETax = value;
        }
    }
    public string RateChartID
    {
        get { return strRateChartID; }
        set
        {
            if (value == "")
                strRateChartID = null;
            else
                strRateChartID = value;
        }
    }
    public string VolumeSlabID
    {
        get { return strVolumeSlabID; }
        set
        {
            if (value == "")
                strVolumeSlabID = null;
            else
                strVolumeSlabID = value;
        }
    }
    public string PenaltyID
    {
        get { return strPenaltyID; }
        set
        {
            if (value == "")
                strPenaltyID = null;
            else
                strPenaltyID = value;
        }
    }
    public string BonusID
    {
        get { return strBonusID; }
        set
        {
            if (value == "")
                strBonusID = null;
            else
                strBonusID = value;
        }
    }

#endregion
    public DataSet GetCentre()
    {
        DataSet ds;
        OleDbConnection conn = new OleDbConnection(oCmn.ConnectionString);
        conn.Open();
        OleDbTransaction trans = conn.BeginTransaction();
        try
        {
            String sSql = "SELECT DISTINCT CENTRE_ID, CENTRE_NAME FROM CE_AC_PR_CT_VW WHERE CENTRE_NAME IS NOT NULL";
            ds = OleDbHelper.ExecuteDataset(trans, CommandType.Text, sSql);
            trans.Commit();
            conn.Close();
        }
        catch (Exception exp)
        {
            trans.Rollback();
            conn.Close();
            throw new Exception("An error occurred ", exp);
        }
        return ds;
    }
    public DataSet GetActivity(String strCentreID)
    {
        DataSet ds;
        OleDbConnection conn = new OleDbConnection(oCmn.ConnectionString);
        conn.Open();
        OleDbTransaction trans = conn.BeginTransaction();
        try
        {
            String sSql = "SELECT DISTINCT ACTIVITY_ID, ACTIVITY_NAME FROM CE_AC_PR_CT_VW WHERE CENTRE_ID='" + strCentreID + "' AND ACTIVITY_NAME IS NOT NULL";
            ds = OleDbHelper.ExecuteDataset(trans, CommandType.Text, sSql);
            trans.Commit();
            conn.Close();
        }
        catch (Exception exp)
        {
            trans.Rollback();
            conn.Close();
            throw new Exception("An error occurred ", exp);
        }
        return ds;
    }
    public DataSet GetProduct(String strActivityID)
    {
        DataSet ds;
        OleDbConnection conn = new OleDbConnection(oCmn.ConnectionString);
        conn.Open();
        OleDbTransaction trans = conn.BeginTransaction();
        try
        {
            String sSql = "SELECT DISTINCT  PRODUCT_ID, PRODUCT_NAME FROM CE_AC_PR_CT_VW WHERE ACTIVITY_ID='" + strActivityID + "' AND PRODUCT_NAME IS NOT NULL";
            ds = OleDbHelper.ExecuteDataset(trans, CommandType.Text, sSql);
            trans.Commit();
            conn.Close();
        }
        catch (Exception exp)
        {
            trans.Rollback();
            conn.Close();
            throw new Exception("An error occurred ", exp);
        }
        return ds;
    }
    public DataSet GetPresaleConfirmContractDetail(String strPresaleContID)
    {
        DataSet ds;
        OleDbConnection conn = new OleDbConnection(oCmn.ConnectionString);
        conn.Open();
        OleDbTransaction trans = conn.BeginTransaction();
        try
        {
            String sSql = "SELECT A.CONT_PRESALE_ID, A.CONT_PRESALE_REF_NO, B.CLIENT_NAME, A.ORDER_NO, A.ORDER_DATE FROM PRESALE_CONTRACT_DETAIL AS A LEFT OUTER JOIN CLIENT_MASTER AS B ON A.CLIENT_ID = B.CLIENT_ID WHERE A.CONT_PRESALE_ID='" + strPresaleContID + "'";
            ds = OleDbHelper.ExecuteDataset(trans, CommandType.Text, sSql);
            trans.Commit();
            conn.Close();
        }
        catch (Exception exp)
        {
            trans.Rollback();
            conn.Close();
            throw new Exception("An error occurred ", exp);
        }
        return ds;
    }
    public DataSet GetConfirmContractDetail(String strPresaleContID)
    {
        DataSet ds;
        OleDbConnection conn = new OleDbConnection(oCmn.ConnectionString);
        conn.Open();
        OleDbTransaction trans = conn.BeginTransaction();
        try
        {
            String sSql = "SELECT CONTRACT_ID, CONTRACT_NO, CONTRACT_DATE, CONTRACT_EXPIRY_DATE, PROJECT_IMPLEMENT_DATE, "+
                            "PROJECT_START_DATE, PROJECT_IMPLEMENTED_BY, EXPECTED_TO, STATUS_AFTER_MONTHS, MIN_VOL_MONTH, MIN_GUARANTEE_MONTH, IN_EX_TAX " +
                            "FROM CONTRACT_DETAILS WHERE CONT_PRESALE_ID='" + strPresaleContID + "'";
            ds = OleDbHelper.ExecuteDataset(trans, CommandType.Text, sSql);
            trans.Commit();
            conn.Close();
        }
        catch (Exception exp)
        {
            trans.Rollback();
            conn.Close();
            throw new Exception("An error occurred ", exp);
        }
        return ds;
    }
    public void GetContractTables(String strContID)
    {  
        OleDbConnection conn = new OleDbConnection(oCmn.ConnectionString);
        conn.Open();
        OleDbTransaction trans = conn.BeginTransaction();
        try
        {
            //String sSql1 = "SELECT RATE_CHART_ID, CENTRE_ID, ACTIVITY_ID, PRODUCT_ID, VERIFICATION_TYPE, RATE FROM RATE_CHART WHERE CONTRACT_ID ='" + strContID + "'";
            String sSql1 = "SELECT A.RATE_CHART_ID, A.CENTRE_ID, B.CENTRE_NAME, A.ACTIVITY_ID, C.ACTIVITY_NAME, A.PRODUCT_ID, D.PRODUCT_NAME, A.VERIFICATION_TYPE, A.RATE FROM RATE_CHART A "+
                            "INNER JOIN CENTRE_MASTER  B ON (A.CENTRE_ID=B.CENTRE_ID) "+
                            "INNER JOIN ACTIVITY_MASTER C ON (A.ACTIVITY_ID=C.ACTIVITY_ID) "+
                            "INNER JOIN PRODUCT_MASTER D ON (A.PRODUCT_ID=D.PRODUCT_ID) "+
                            "WHERE CONTRACT_ID ='" + strContID + "'";
            dsRateChart = OleDbHelper.ExecuteDataset(trans, CommandType.Text, sSql1);

            String sSql2 = "SELECT VOLUME_SLAB_ID, FROM_NO_OF_CASES, TO_NO_OF_CASES, VERIFICATION_TYPE, RATE_CASES FROM VOLUME_SLAB WHERE CONTRACT_ID ='" + strContID + "'";
            dsVolumeSlab = OleDbHelper.ExecuteDataset(trans, CommandType.Text, sSql2);

            String sSql3 = "SELECT PENALTY_ID, FROM_BEYOND_TAT, TO_BEYOND_TAT, PENALTY_ON, VALUE_TYPE, PENALTY_VALUE FROM TAT_PENALTY WHERE CONTRACT_ID ='" + strContID + "'";
            dsPenalty = OleDbHelper.ExecuteDataset(trans, CommandType.Text, sSql3);

            String sSql4 = "SELECT BONUS_ID, FROM_WITHIN_TAT, TO_WITHIN_TAT, BONUS_ON, VALUE_TYPE, BONUS_VALUE FROM TAT_BONUS WHERE CONTRACT_ID ='" + strContID + "'";
            dsBonus = OleDbHelper.ExecuteDataset(trans, CommandType.Text, sSql4);

            trans.Commit();
            conn.Close();
        }
        catch (Exception exp)
        {
            trans.Rollback();
            conn.Close();
            throw new Exception("An error occurred ", exp);
        }       
    }    
    public void InsertContractDetail()
    {
        OleDbConnection conn = new OleDbConnection(oCmn.ConnectionString);
        conn.Open();
        OleDbTransaction trans = conn.BeginTransaction();
        try
        {
            ContractID = oCmn.GetUniqueID("CONTRACT_DETAILS", Prefix);

            String sQuery = "INSERT INTO CONTRACT_DETAILS (CONTRACT_ID, CONT_PRESALE_ID, CONTRACT_NO, CONTRACT_DATE, " +
                            "CONTRACT_EXPIRY_DATE, PROJECT_IMPLEMENT_DATE, PROJECT_START_DATE, PROJECT_IMPLEMENTED_BY, " +
                            "EXPECTED_TO, STATUS_AFTER_MONTHS, MIN_VOL_MONTH, ADD_BY, ADD_DATE, MIN_GUARANTEE_MONTH, IN_EX_TAX) " +
                            "VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
            OleDbParameter[] paramPreCont = new OleDbParameter[15];
            paramPreCont[0] = new OleDbParameter("@CONTRACT_ID", OleDbType.VarChar, 15);
            paramPreCont[0].Value = ContractID;
            paramPreCont[1] = new OleDbParameter("@CONT_PRESALE_ID", OleDbType.VarChar, 50);
            paramPreCont[1].Value = PresaleContID;
            paramPreCont[2] = new OleDbParameter("@CONTRACT_NO", OleDbType.VarChar, 15);
            paramPreCont[2].Value = ContractNo;
            paramPreCont[3] = new OleDbParameter("@CONTRACT_DATE", OleDbType.VarChar, 100);
            paramPreCont[3].Value = ContractDate;
            paramPreCont[4] = new OleDbParameter("@CONTRACT_EXPIRY_DATE", OleDbType.VarChar, 300);
            paramPreCont[4].Value = ContractExpiryDate;
            paramPreCont[5] = new OleDbParameter("@PROJECT_IMPLEMENT_DATE", OleDbType.VarChar, 100);
            paramPreCont[5].Value = ProjectImplementDate;
            paramPreCont[6] = new OleDbParameter("@PROJECT_START_DATE", OleDbType.VarChar, 100);
            paramPreCont[6].Value = ProjectStartDate;
            paramPreCont[7] = new OleDbParameter("@PROJECT_IMPLEMENT_BY", OleDbType.VarChar, 100);
            paramPreCont[7].Value = ProjectImplementBy;
            paramPreCont[8] = new OleDbParameter("@EXPECTED_TO", OleDbType.VarChar, 200);
            paramPreCont[8].Value = ExpectedTo;
            paramPreCont[9] = new OleDbParameter("@STATUS_AFTER_MONTHS", OleDbType.VarChar, 30);
            paramPreCont[9].Value = StatusAfterMonths;
            paramPreCont[10] = new OleDbParameter("@MIN_VOL_MONTH", OleDbType.VarChar, 10);
            paramPreCont[10].Value = MinVolMonth;
            paramPreCont[11] = new OleDbParameter("@ADD_BY", OleDbType.Numeric, 9);
            paramPreCont[11].Value = CurrentUser;
            paramPreCont[12] = new OleDbParameter("@ADD_DATE", OleDbType.VarChar, 500);
            paramPreCont[12].Value = strDate;
            paramPreCont[13] = new OleDbParameter("@MIN_GUARANTEE_MONTH", OleDbType.VarChar, 10);
            paramPreCont[13].Value = MinGrtMonth;
            paramPreCont[14] = new OleDbParameter("@IN_EX_TAX", OleDbType.VarChar, 1);
            paramPreCont[14].Value = IETax;

            if (dsRateChart != null)
            {
                if (dsRateChart.Tables[0].Rows.Count > 0)
                {
                    String sQuery1 = "INSERT INTO RATE_CHART (RATE_CHART_ID, CONTRACT_ID, CENTRE_ID, ACTIVITY_ID, PRODUCT_ID, VERIFICATION_TYPE, RATE) " +
                                    "VALUES(?,?,?,?,?,?,?)";
                    for (int i = 0; i < dsRateChart.Tables[0].Rows.Count; i++)
                    {                       
                        RateChartID = oCmn.GetUniqueID("RATE_CHART", Prefix);
                        OleDbParameter[] paramRateChart = new OleDbParameter[7];
                        paramRateChart[0] = new OleDbParameter("@RATE_CHART_ID", OleDbType.VarChar, 15);
                        paramRateChart[0].Value = RateChartID;
                        paramRateChart[1] = new OleDbParameter("@CONTRACT_ID", OleDbType.VarChar, 15);
                        paramRateChart[1].Value = ContractID;
                        paramRateChart[2] = new OleDbParameter("@CENTRE_ID", OleDbType.VarChar, 15);
                        paramRateChart[2].Value = dsRateChart.Tables[0].Rows[i].ItemArray[1].ToString();
                        paramRateChart[3] = new OleDbParameter("@ACTIVITY_ID", OleDbType.VarChar, 15);
                        paramRateChart[3].Value = dsRateChart.Tables[0].Rows[i].ItemArray[2].ToString();
                        paramRateChart[4] = new OleDbParameter("@PRODUCT_ID", OleDbType.VarChar, 15);
                        paramRateChart[4].Value = dsRateChart.Tables[0].Rows[i].ItemArray[3].ToString();
                        paramRateChart[5] = new OleDbParameter("@VERIFICATION_TYPE", OleDbType.VarChar, 15);
                        paramRateChart[5].Value = dsRateChart.Tables[0].Rows[i].ItemArray[4].ToString();
                        paramRateChart[6] = new OleDbParameter("@RATE", OleDbType.Numeric, 9);
                        paramRateChart[6].Value = Convert.ToInt32(dsRateChart.Tables[0].Rows[i].ItemArray[5]);
                        OleDbHelper.ExecuteNonQuery(trans, CommandType.Text, sQuery1, paramRateChart);
                    }
                }
            }

            if (dsVolumeSlab != null)
            {
                if (dsVolumeSlab.Tables[0].Rows.Count > 0)
                {
                    String sQuery2 = "INSERT INTO VOLUME_SLAB (VOLUME_SLAB_ID, CONTRACT_ID, FROM_NO_OF_CASES, TO_NO_OF_CASES, VERIFICATION_TYPE, RATE_CASES) " +
                                        "VALUES(?,?,?,?,?,?)";
                    for (int i = 0; i < dsVolumeSlab.Tables[0].Rows.Count; i++)
                    {                        
                        VolumeSlabID = oCmn.GetUniqueID("VOLUME_SLAB", Prefix);
                        OleDbParameter[] paramVolumeSlab = new OleDbParameter[6];
                        paramVolumeSlab[0] = new OleDbParameter("@VOLUME_SLAB_ID", OleDbType.VarChar, 15);
                        paramVolumeSlab[0].Value = VolumeSlabID;
                        paramVolumeSlab[1] = new OleDbParameter("@CONTRACT_ID", OleDbType.VarChar, 15);
                        paramVolumeSlab[1].Value = ContractID;
                        paramVolumeSlab[2] = new OleDbParameter("@FROM_NO_OF_CASES", OleDbType.Numeric, 9);
                        paramVolumeSlab[2].Value = Convert.ToInt32(dsVolumeSlab.Tables[0].Rows[i].ItemArray[0]);
                        paramVolumeSlab[3] = new OleDbParameter("@TO_NO_OF_CASES", OleDbType.Numeric, 9);
                        paramVolumeSlab[3].Value = Convert.ToInt32(dsVolumeSlab.Tables[0].Rows[i].ItemArray[1]);
                        paramVolumeSlab[4] = new OleDbParameter("@VERIFICATION_TYPE", OleDbType.VarChar, 15);
                        paramVolumeSlab[4].Value = dsVolumeSlab.Tables[0].Rows[i].ItemArray[2].ToString();
                        paramVolumeSlab[5] = new OleDbParameter("@RATE_CASES", OleDbType.Numeric, 9);
                        paramVolumeSlab[5].Value = Convert.ToInt32(dsVolumeSlab.Tables[0].Rows[i].ItemArray[3]);
                        OleDbHelper.ExecuteNonQuery(trans, CommandType.Text, sQuery2, paramVolumeSlab);                        
                    }
                }
            }

            if (dsPenalty != null)
            {
                if (dsPenalty.Tables[0].Rows.Count > 0)
                {
                    String sQuery3 = "INSERT INTO TAT_PENALTY (PENALTY_ID, CONTRACT_ID, FROM_BEYOND_TAT, TO_BEYOND_TAT, PENALTY_ON, VALUE_TYPE, PENALTY_VALUE) " +
                                        "VALUES(?,?,?,?,?,?,?)";
                    for (int i = 0; i < dsPenalty.Tables[0].Rows.Count; i++)
                    {
                        PenaltyID = oCmn.GetUniqueID("TAT_PENALTY", Prefix);
                        OleDbParameter[] paramPenalty = new OleDbParameter[7];
                        paramPenalty[0] = new OleDbParameter("@PENALTY_ID", OleDbType.VarChar, 15);
                        paramPenalty[0].Value = PenaltyID;
                        paramPenalty[1] = new OleDbParameter("@CONTRACT_ID", OleDbType.VarChar, 15);
                        paramPenalty[1].Value = ContractID;
                        paramPenalty[2] = new OleDbParameter("@FROM_BEYOND_TAT", OleDbType.Numeric, 9);
                        paramPenalty[2].Value = Convert.ToInt32(dsPenalty.Tables[0].Rows[i].ItemArray[0]);
                        paramPenalty[3] = new OleDbParameter("@TO_BEYOND_TAT", OleDbType.Numeric, 9);
                        paramPenalty[3].Value = Convert.ToInt32(dsPenalty.Tables[0].Rows[i].ItemArray[1]);
                        paramPenalty[4] = new OleDbParameter("@PENALTY_ON", OleDbType.VarChar, 1);
                        paramPenalty[4].Value = dsPenalty.Tables[0].Rows[i].ItemArray[2].ToString();
                        paramPenalty[5] = new OleDbParameter("@VALUE_TYPE", OleDbType.VarChar, 1);
                        paramPenalty[5].Value = dsPenalty.Tables[0].Rows[i].ItemArray[3].ToString();
                        paramPenalty[6] = new OleDbParameter("@PENALTY_VALUE", OleDbType.Numeric, 9);
                        paramPenalty[6].Value = Convert.ToInt32(dsPenalty.Tables[0].Rows[i].ItemArray[4]);
                        OleDbHelper.ExecuteNonQuery(trans, CommandType.Text, sQuery3, paramPenalty);
                    }
                }
            }           
            
            if (dsBonus != null)
            {
                if (dsBonus.Tables[0].Rows.Count > 0)
                {
                    String sQuery4 = "INSERT INTO TAT_BONUS (BONUS_ID, CONTRACT_ID, FROM_WITHIN_TAT, TO_WITHIN_TAT, BONUS_ON, VALUE_TYPE, BONUS_VALUE) " +
                            "VALUES(?,?,?,?,?,?,?)";

                    for (int i = 0; i < dsBonus.Tables[0].Rows.Count; i++)
                    {
                        BonusID = oCmn.GetUniqueID("TAT_BONUS", Prefix);
                        OleDbParameter[] paramBonus = new OleDbParameter[7];
                        paramBonus[0] = new OleDbParameter("@BONUS_ID", OleDbType.VarChar, 15);
                        paramBonus[0].Value = BonusID;
                        paramBonus[1] = new OleDbParameter("@CONTRACT_ID", OleDbType.VarChar, 15);
                        paramBonus[1].Value = ContractID;
                        paramBonus[2] = new OleDbParameter("@FROM_WITHIN_TAT", OleDbType.Numeric, 9);
                        paramBonus[2].Value = Convert.ToInt32(dsBonus.Tables[0].Rows[i].ItemArray[0]);
                        paramBonus[3] = new OleDbParameter("@TO_WITHIN_TAT", OleDbType.Numeric, 9);
                        paramBonus[3].Value = Convert.ToInt32(dsBonus.Tables[0].Rows[i].ItemArray[1]);
                        paramBonus[4] = new OleDbParameter("@BONUS_ON", OleDbType.VarChar, 1);
                        paramBonus[4].Value = dsBonus.Tables[0].Rows[i].ItemArray[2].ToString();
                        paramBonus[5] = new OleDbParameter("@VALUE_TYPE", OleDbType.VarChar, 1);
                        paramBonus[5].Value = dsBonus.Tables[0].Rows[i].ItemArray[3].ToString();
                        paramBonus[6] = new OleDbParameter("@BONUS_VALUE", OleDbType.Numeric, 9);
                        paramBonus[6].Value = Convert.ToInt32(dsBonus.Tables[0].Rows[i].ItemArray[4]);
                        OleDbHelper.ExecuteNonQuery(trans, CommandType.Text, sQuery4, paramBonus);
                    }
                }
            }
            OleDbHelper.ExecuteNonQuery(trans, CommandType.Text, sQuery, paramPreCont);
            trans.Commit();
            conn.Close();
        }
        catch (Exception exp)
        {
            trans.Rollback();
            conn.Close();
            throw new Exception("An error occurred ", exp);
        }
    }
    public void UpdateContractDetail()
    {
        OleDbConnection conn = new OleDbConnection(oCmn.ConnectionString);
        conn.Open();
        OleDbTransaction trans = conn.BeginTransaction();
        try
        {
            String sQuery = "UPDATE CONTRACT_DETAILS SET CONTRACT_NO=?, CONTRACT_DATE=?, " +
                            "CONTRACT_EXPIRY_DATE=?, PROJECT_IMPLEMENT_DATE=?, PROJECT_START_DATE=?, PROJECT_IMPLEMENTED_BY=?, " +
                            "EXPECTED_TO=?, STATUS_AFTER_MONTHS=?, MIN_VOL_MONTH=?, MODIFY_BY=?, MODIFY_DATE=?, MIN_GUARANTEE_MONTH=?, IN_EX_TAX=? " +
                            "WHERE CONTRACT_ID=?";
            OleDbParameter[] paramPreCont = new OleDbParameter[14];
            //paramPreCont[0] = new OleDbParameter("@CONTRACT_ID", OleDbType.VarChar, 15);
            //paramPreCont[0].Value = ContractID;
            //paramPreCont[1] = new OleDbParameter("@CONT_PRESALE_ID", OleDbType.VarChar, 50);
            //paramPreCont[1].Value = PresaleContID;
            paramPreCont[0] = new OleDbParameter("@CONTRACT_NO", OleDbType.VarChar, 15);
            paramPreCont[0].Value = ContractNo;
            paramPreCont[1] = new OleDbParameter("@CONTRACT_DATE", OleDbType.VarChar, 100);
            paramPreCont[1].Value = ContractDate;
            paramPreCont[2] = new OleDbParameter("@CONTRACT_EXPIRY_DATE", OleDbType.VarChar, 300);
            paramPreCont[2].Value = ContractExpiryDate;
            paramPreCont[3] = new OleDbParameter("@PROJECT_IMPLEMENT_DATE", OleDbType.VarChar, 100);
            paramPreCont[3].Value = ProjectImplementDate;
            paramPreCont[4] = new OleDbParameter("@PROJECT_START_DATE", OleDbType.VarChar, 100);
            paramPreCont[4].Value = ProjectStartDate;
            paramPreCont[5] = new OleDbParameter("@PROJECT_IMPLEMENT_BY", OleDbType.VarChar, 100);
            paramPreCont[5].Value = ProjectImplementBy;
            paramPreCont[6] = new OleDbParameter("@EXPECTED_TO", OleDbType.VarChar, 200);
            paramPreCont[6].Value = ExpectedTo;
            paramPreCont[7] = new OleDbParameter("@STATUS_AFTER_MONTHS", OleDbType.VarChar, 30);
            paramPreCont[7].Value = StatusAfterMonths;
            paramPreCont[8] = new OleDbParameter("@MIN_VOL_MONTH", OleDbType.VarChar, 10);
            paramPreCont[8].Value = MinVolMonth;
            paramPreCont[9] = new OleDbParameter("@ADD_BY", OleDbType.Numeric, 9);
            paramPreCont[9].Value = CurrentUser;
            paramPreCont[10] = new OleDbParameter("@ADD_DATE", OleDbType.VarChar, 500);
            paramPreCont[10].Value = strDate;
            paramPreCont[11] = new OleDbParameter("@MIN_GUARANTEE_MONTH", OleDbType.VarChar, 10);
            paramPreCont[11].Value = MinGrtMonth;
            paramPreCont[12] = new OleDbParameter("@IN_EX_TAX", OleDbType.VarChar, 1);
            paramPreCont[12].Value = IETax;
            paramPreCont[13] = new OleDbParameter("@CONTRACT_ID", OleDbType.VarChar, 15);
            paramPreCont[13].Value = ContractID;

            if (dsRateChart != null)
            {
                if (dsRateChart.Tables[0].Rows.Count > 0)
                {
                    String sQuery1 = "";
                    OleDbParameter[] paramRateChart;
                    for (int i = 0; i < dsRateChart.Tables[0].Rows.Count; i++)
                    {
                        RateChartID = dsRateChart.Tables[0].Rows[i].ItemArray[0].ToString();
                        if (RateChartID == null || RateChartID=="")
                        {
                            sQuery1 = "INSERT INTO RATE_CHART (RATE_CHART_ID, CONTRACT_ID, CENTRE_ID, ACTIVITY_ID, PRODUCT_ID, VERIFICATION_TYPE, RATE) " +
                                     "VALUES(?,?,?,?,?,?,?)";
                            RateChartID = oCmn.GetUniqueID("RATE_CHART", Prefix);
                            paramRateChart = new OleDbParameter[7];
                            paramRateChart[0] = new OleDbParameter("@RATE_CHART_ID", OleDbType.VarChar, 15);
                            paramRateChart[0].Value = RateChartID;
                            paramRateChart[1] = new OleDbParameter("@CONTRACT_ID", OleDbType.VarChar, 15);
                            paramRateChart[1].Value = ContractID;
                            paramRateChart[2] = new OleDbParameter("@CENTRE_ID", OleDbType.VarChar, 15);
                            paramRateChart[2].Value = dsRateChart.Tables[0].Rows[i].ItemArray[1].ToString();
                            paramRateChart[3] = new OleDbParameter("@ACTIVITY_ID", OleDbType.VarChar, 15);
                            paramRateChart[3].Value = dsRateChart.Tables[0].Rows[i].ItemArray[2].ToString();
                            paramRateChart[4] = new OleDbParameter("@PRODUCT_ID", OleDbType.VarChar, 15);
                            paramRateChart[4].Value = dsRateChart.Tables[0].Rows[i].ItemArray[3].ToString();
                            paramRateChart[5] = new OleDbParameter("@VERIFICATION_TYPE", OleDbType.VarChar, 15);
                            paramRateChart[5].Value = dsRateChart.Tables[0].Rows[i].ItemArray[4].ToString();
                            paramRateChart[6] = new OleDbParameter("@RATE", OleDbType.Numeric, 9);
                            paramRateChart[6].Value = Convert.ToInt32(dsRateChart.Tables[0].Rows[i].ItemArray[5]);
                        }
                        else
                        {
                            sQuery1 = "UPDATE RATE_CHART SET CENTRE_ID=?, ACTIVITY_ID=?, PRODUCT_ID=?, VERIFICATION_TYPE=?, RATE=? WHERE RATE_CHART_ID='" + RateChartID + "'";                                 
                            paramRateChart = new OleDbParameter[5];                           
                            paramRateChart[0] = new OleDbParameter("@CENTRE_ID", OleDbType.VarChar, 15);
                            paramRateChart[0].Value = dsRateChart.Tables[0].Rows[i].ItemArray[1].ToString();
                            paramRateChart[1] = new OleDbParameter("@ACTIVITY_ID", OleDbType.VarChar, 15);
                            paramRateChart[1].Value = dsRateChart.Tables[0].Rows[i].ItemArray[2].ToString();
                            paramRateChart[2] = new OleDbParameter("@PRODUCT_ID", OleDbType.VarChar, 15);
                            paramRateChart[2].Value = dsRateChart.Tables[0].Rows[i].ItemArray[3].ToString();
                            paramRateChart[3] = new OleDbParameter("@VERIFICATION_TYPE", OleDbType.VarChar, 15);
                            paramRateChart[3].Value = dsRateChart.Tables[0].Rows[i].ItemArray[4].ToString();
                            paramRateChart[4] = new OleDbParameter("@RATE", OleDbType.Numeric, 9);
                            paramRateChart[4].Value = Convert.ToInt32(dsRateChart.Tables[0].Rows[i].ItemArray[5]);
                        }
                        OleDbHelper.ExecuteNonQuery(trans, CommandType.Text, sQuery1, paramRateChart);
                    }
                }
            }

            if (dsVolumeSlab != null)
            {
                if (dsVolumeSlab.Tables[0].Rows.Count > 0)
                {
                    String sQuery2 = "";
                    OleDbParameter[] paramVolumeSlab;
                    for (int i = 0; i < dsVolumeSlab.Tables[0].Rows.Count; i++)
                    {
                        VolumeSlabID = dsVolumeSlab.Tables[0].Rows[i].ItemArray[4].ToString();
                        if (VolumeSlabID == null || VolumeSlabID == "")
                        {
                            sQuery2 = "INSERT INTO VOLUME_SLAB (VOLUME_SLAB_ID, CONTRACT_ID, FROM_NO_OF_CASES, TO_NO_OF_CASES, VERIFICATION_TYPE, RATE_CASES) " +
                                        "VALUES(?,?,?,?,?,?)";
                            VolumeSlabID = oCmn.GetUniqueID("VOLUME_SLAB", Prefix);
                            paramVolumeSlab = new OleDbParameter[6];
                            paramVolumeSlab[0] = new OleDbParameter("@VOLUME_SLAB_ID", OleDbType.VarChar, 15);
                            paramVolumeSlab[0].Value = VolumeSlabID;
                            paramVolumeSlab[1] = new OleDbParameter("@CONTRACT_ID", OleDbType.VarChar, 15);
                            paramVolumeSlab[1].Value = ContractID;
                            paramVolumeSlab[2] = new OleDbParameter("@FROM_NO_OF_CASES", OleDbType.Numeric, 9);
                            paramVolumeSlab[2].Value = Convert.ToInt32(dsVolumeSlab.Tables[0].Rows[i].ItemArray[0]);
                            paramVolumeSlab[3] = new OleDbParameter("@TO_NO_OF_CASES", OleDbType.Numeric, 9);
                            paramVolumeSlab[3].Value = Convert.ToInt32(dsVolumeSlab.Tables[0].Rows[i].ItemArray[1]);
                            paramVolumeSlab[4] = new OleDbParameter("@VERIFICATION_TYPE", OleDbType.VarChar, 15);
                            paramVolumeSlab[4].Value = dsVolumeSlab.Tables[0].Rows[i].ItemArray[2].ToString();
                            paramVolumeSlab[5] = new OleDbParameter("@RATE_CASES", OleDbType.Numeric, 9);
                            paramVolumeSlab[5].Value = Convert.ToInt32(dsVolumeSlab.Tables[0].Rows[i].ItemArray[3]);
                        }
                        else
                        {
                            sQuery2 = "UPDATE VOLUME_SLAB SET FROM_NO_OF_CASES=?, TO_NO_OF_CASES=?, VERIFICATION_TYPE=?, RATE_CASES=? WHERE VOLUME_SLAB_ID='" + VolumeSlabID + "'";                                                                    
                            paramVolumeSlab = new OleDbParameter[4];                            
                            paramVolumeSlab[0] = new OleDbParameter("@FROM_NO_OF_CASES", OleDbType.Numeric, 9);
                            paramVolumeSlab[0].Value = Convert.ToInt32(dsVolumeSlab.Tables[0].Rows[i].ItemArray[0]);
                            paramVolumeSlab[1] = new OleDbParameter("@TO_NO_OF_CASES", OleDbType.Numeric, 9);
                            paramVolumeSlab[1].Value = Convert.ToInt32(dsVolumeSlab.Tables[0].Rows[i].ItemArray[1]);
                            paramVolumeSlab[2] = new OleDbParameter("@VERIFICATION_TYPE", OleDbType.VarChar, 15);
                            paramVolumeSlab[2].Value = dsVolumeSlab.Tables[0].Rows[i].ItemArray[2].ToString();
                            paramVolumeSlab[3] = new OleDbParameter("@RATE_CASES", OleDbType.Numeric, 9);
                            paramVolumeSlab[3].Value = Convert.ToInt32(dsVolumeSlab.Tables[0].Rows[i].ItemArray[3]);
                        }
                        OleDbHelper.ExecuteNonQuery(trans, CommandType.Text, sQuery2, paramVolumeSlab);
                    }
                }
            }

            if (dsPenalty != null)
            {
                if (dsPenalty.Tables[0].Rows.Count > 0)
                {
                    String sQuery3="";
                    OleDbParameter[] paramPenalty;
                    for (int i = 0; i < dsPenalty.Tables[0].Rows.Count; i++)
                    {
                        PenaltyID = dsPenalty.Tables[0].Rows[i].ItemArray[5].ToString();
                        if (PenaltyID == null || PenaltyID == "")
                        {
                            sQuery3 = "INSERT INTO TAT_PENALTY (PENALTY_ID, CONTRACT_ID, FROM_BEYOND_TAT, TO_BEYOND_TAT, PENALTY_ON, VALUE_TYPE, PENALTY_VALUE) " +
                                            "VALUES(?,?,?,?,?,?,?)";
                            PenaltyID = oCmn.GetUniqueID("TAT_PENALTY", Prefix);
                            paramPenalty = new OleDbParameter[7];
                            paramPenalty[0] = new OleDbParameter("@PENALTY_ID", OleDbType.VarChar, 15);
                            paramPenalty[0].Value = PenaltyID;
                            paramPenalty[1] = new OleDbParameter("@CONTRACT_ID", OleDbType.VarChar, 15);
                            paramPenalty[1].Value = ContractID;
                            paramPenalty[2] = new OleDbParameter("@FROM_BEYOND_TAT", OleDbType.Numeric, 9);
                            paramPenalty[2].Value = Convert.ToInt32(dsPenalty.Tables[0].Rows[i].ItemArray[0]);
                            paramPenalty[3] = new OleDbParameter("@TO_BEYOND_TAT", OleDbType.Numeric, 9);
                            paramPenalty[3].Value = Convert.ToInt32(dsPenalty.Tables[0].Rows[i].ItemArray[1]);
                            paramPenalty[4] = new OleDbParameter("@PENALTY_ON", OleDbType.VarChar, 1);
                            paramPenalty[4].Value = dsPenalty.Tables[0].Rows[i].ItemArray[2].ToString();
                            paramPenalty[5] = new OleDbParameter("@VALUE_TYPE", OleDbType.VarChar, 1);
                            paramPenalty[5].Value = dsPenalty.Tables[0].Rows[i].ItemArray[3].ToString();
                            paramPenalty[6] = new OleDbParameter("@PENALTY_VALUE", OleDbType.Numeric, 9);
                            paramPenalty[6].Value = Convert.ToInt32(dsPenalty.Tables[0].Rows[i].ItemArray[4]);
                        }
                        else 
                        {
                            sQuery3 = "UPDATE TAT_PENALTY SET FROM_BEYOND_TAT=?, TO_BEYOND_TAT=?, PENALTY_ON=?, VALUE_TYPE=?, PENALTY_VALUE=? WHERE PENALTY_ID='" + PenaltyID + "'";                                      
                            paramPenalty = new OleDbParameter[5];
                            paramPenalty[0] = new OleDbParameter("@FROM_BEYOND_TAT", OleDbType.Numeric, 9);
                            paramPenalty[0].Value = Convert.ToInt32(dsPenalty.Tables[0].Rows[i].ItemArray[0]);
                            paramPenalty[1] = new OleDbParameter("@TO_BEYOND_TAT", OleDbType.Numeric, 9);
                            paramPenalty[1].Value = Convert.ToInt32(dsPenalty.Tables[0].Rows[i].ItemArray[1]);
                            paramPenalty[2] = new OleDbParameter("@PENALTY_ON", OleDbType.VarChar, 1);
                            paramPenalty[2].Value = dsPenalty.Tables[0].Rows[i].ItemArray[2].ToString();
                            paramPenalty[3] = new OleDbParameter("@VALUE_TYPE", OleDbType.VarChar, 1);
                            paramPenalty[3].Value = dsPenalty.Tables[0].Rows[i].ItemArray[3].ToString();
                            paramPenalty[4] = new OleDbParameter("@PENALTY_VALUE", OleDbType.Numeric, 9);
                            paramPenalty[4].Value = Convert.ToInt32(dsPenalty.Tables[0].Rows[i].ItemArray[4]);
                        }
                        OleDbHelper.ExecuteNonQuery(trans, CommandType.Text, sQuery3, paramPenalty);
                    }
                }
            }

            if (dsBonus != null)
            {
                if (dsBonus.Tables[0].Rows.Count > 0)
                {
                    String sQuery4 = "";
                    OleDbParameter[] paramBonus;
                    for (int i = 0; i < dsBonus.Tables[0].Rows.Count; i++)
                    {
                        BonusID = dsBonus.Tables[0].Rows[i].ItemArray[5].ToString();
                        if (BonusID == null || BonusID == "")
                        {
                            sQuery4 = "INSERT INTO TAT_BONUS (BONUS_ID, CONTRACT_ID, FROM_WITHIN_TAT, TO_WITHIN_TAT, BONUS_ON, VALUE_TYPE, BONUS_VALUE) " +
                                "VALUES(?,?,?,?,?,?,?)";
                            BonusID = oCmn.GetUniqueID("TAT_BONUS", Prefix);
                            paramBonus = new OleDbParameter[7];
                            paramBonus[0] = new OleDbParameter("@BONUS_ID", OleDbType.VarChar, 15);
                            paramBonus[0].Value = BonusID;
                            paramBonus[1] = new OleDbParameter("@CONTRACT_ID", OleDbType.VarChar, 15);
                            paramBonus[1].Value = ContractID;
                            paramBonus[2] = new OleDbParameter("@FROM_WITHIN_TAT", OleDbType.Numeric, 9);
                            paramBonus[2].Value = Convert.ToInt32(dsBonus.Tables[0].Rows[i].ItemArray[0]);
                            paramBonus[3] = new OleDbParameter("@TO_WITHIN_TAT", OleDbType.Numeric, 9);
                            paramBonus[3].Value = Convert.ToInt32(dsBonus.Tables[0].Rows[i].ItemArray[1]);
                            paramBonus[4] = new OleDbParameter("@BONUS_ON", OleDbType.VarChar, 1);
                            paramBonus[4].Value = dsBonus.Tables[0].Rows[i].ItemArray[2].ToString();
                            paramBonus[5] = new OleDbParameter("@VALUE_TYPE", OleDbType.VarChar, 1);
                            paramBonus[5].Value = dsBonus.Tables[0].Rows[i].ItemArray[3].ToString();
                            paramBonus[6] = new OleDbParameter("@BONUS_VALUE", OleDbType.Numeric, 9);
                            paramBonus[6].Value = Convert.ToInt32(dsBonus.Tables[0].Rows[i].ItemArray[4]);
                        }
                        else
                        {
                            sQuery4 = "UPDATE TAT_BONUS SET FROM_WITHIN_TAT=?, TO_WITHIN_TAT=?, BONUS_ON=?, VALUE_TYPE=?, BONUS_VALUE=? WHERE BONUS_ID='" + BonusID + "'";                                                         
                            paramBonus = new OleDbParameter[5];
                            paramBonus[0] = new OleDbParameter("@FROM_WITHIN_TAT", OleDbType.Numeric, 9);
                            paramBonus[0].Value = Convert.ToInt32(dsBonus.Tables[0].Rows[i].ItemArray[0]);
                            paramBonus[1] = new OleDbParameter("@TO_WITHIN_TAT", OleDbType.Numeric, 9);
                            paramBonus[1].Value = Convert.ToInt32(dsBonus.Tables[0].Rows[i].ItemArray[1]);
                            paramBonus[2] = new OleDbParameter("@BONUS_ON", OleDbType.VarChar, 1);
                            paramBonus[2].Value = dsBonus.Tables[0].Rows[i].ItemArray[2].ToString();
                            paramBonus[3] = new OleDbParameter("@VALUE_TYPE", OleDbType.VarChar, 1);
                            paramBonus[3].Value = dsBonus.Tables[0].Rows[i].ItemArray[3].ToString();
                            paramBonus[4] = new OleDbParameter("@BONUS_VALUE", OleDbType.Numeric, 9);
                            paramBonus[4].Value = Convert.ToInt32(dsBonus.Tables[0].Rows[i].ItemArray[4]);
                        }
                        OleDbHelper.ExecuteNonQuery(trans, CommandType.Text, sQuery4, paramBonus);
                    }
                }
            }
            OleDbHelper.ExecuteNonQuery(trans, CommandType.Text, sQuery, paramPreCont);
            trans.Commit();
            conn.Close();
        }
        catch (Exception exp)
        {
            trans.Rollback();
            conn.Close();
            throw new Exception("An error occurred ", exp);
        }
    }
    public void DeleteRateChart(String strID)
    {
        OleDbConnection conn = new OleDbConnection(oCmn.ConnectionString);
        conn.Open();
        OleDbTransaction trans = conn.BeginTransaction();
        try
        {
            String sSql1 = "DELETE FROM RATE_CHART WHERE RATE_CHART_ID  ='" + strID + "'";
            dsRateChart = OleDbHelper.ExecuteDataset(trans, CommandType.Text, sSql1);

            trans.Commit();
            conn.Close();
        }
        catch (Exception exp)
        {
            trans.Rollback();
            conn.Close();
            throw new Exception("An error occurred ", exp);
        }
    }
    public void DeleteVolumeSlab(String strID)
    {
        OleDbConnection conn = new OleDbConnection(oCmn.ConnectionString);
        conn.Open();
        OleDbTransaction trans = conn.BeginTransaction();
        try
        {
            String sSql1 = "DELETE FROM VOLUME_SLAB WHERE VOLUME_SLAB_ID ='" + strID + "'";
            dsRateChart = OleDbHelper.ExecuteDataset(trans, CommandType.Text, sSql1);

            trans.Commit();
            conn.Close();
        }
        catch (Exception exp)
        {
            trans.Rollback();
            conn.Close();
            throw new Exception("An error occurred ", exp);
        }
    }
    public void DeletePenalty(String strID)
    {
        OleDbConnection conn = new OleDbConnection(oCmn.ConnectionString);
        conn.Open();
        OleDbTransaction trans = conn.BeginTransaction();
        try
        {
            String sSql1 = "DELETE FROM TAT_PENALTY WHERE PENALTY_ID  ='" + strID + "'";
            dsRateChart = OleDbHelper.ExecuteDataset(trans, CommandType.Text, sSql1);

            trans.Commit();
            conn.Close();
        }
        catch (Exception exp)
        {
            trans.Rollback();
            conn.Close();
            throw new Exception("An error occurred ", exp);
        }
    }
    public void DeleteBonus(String strID)
    {
        OleDbConnection conn = new OleDbConnection(oCmn.ConnectionString);
        conn.Open();
        OleDbTransaction trans = conn.BeginTransaction();
        try
        {
            String sSql1 = "DELETE FROM TAT_BONUS WHERE BONUS_ID ='" + strID + "'";
            dsRateChart = OleDbHelper.ExecuteDataset(trans, CommandType.Text, sSql1);

            trans.Commit();
            conn.Close();
        }
        catch (Exception exp)
        {
            trans.Rollback();
            conn.Close();
            throw new Exception("An error occurred ", exp);
        }
    }
    public String getOfficerName()
    {
        OleDbConnection conn = new OleDbConnection(oCmn.ConnectionString);
        conn.Open();
        String strOfficerName = "";
        OleDbTransaction trans = conn.BeginTransaction();
        try
        {
            String sSql1 = "SELECT CONTACT_PERSON FROM PRESALE_CONTRACT_DETAIL WHERE CONT_PRESALE_ID='" + ContID + "'";
            OleDbDataReader oDr = OleDbHelper.ExecuteReader(trans, CommandType.Text, sSql1);
            if (oDr.HasRows)
                if (oDr.Read())
                    strOfficerName = oDr[0].ToString();
            trans.Commit();
            conn.Close();
        }
        catch (Exception exp)
        {
            trans.Rollback();
            conn.Close();
            throw new Exception("An error occurred ", exp);
        }
        return strOfficerName;
    }
    public Boolean getMDet()
    {
        OleDbConnection conn = new OleDbConnection(oCmn.ConnectionString);
        conn.Open();
        Boolean bln = true;
        OleDbTransaction trans = conn.BeginTransaction();
        try
        {
            String sSql1 = "SELECT MEETING_DET_ID FROM PRESALE_CONTRACT_MEETING_DETAIL WHERE CONT_PRESALE_ID='" + ContID + "'";
            OleDbDataReader oDr = OleDbHelper.ExecuteReader(trans, CommandType.Text, sSql1);
            if (oDr.HasRows)
                if (oDr.Read())
                    bln = false;
            trans.Commit();
            conn.Close();
        }
        catch (Exception exp)
        {
            trans.Rollback();
            conn.Close();
            throw new Exception("An error occurred ", exp);
        }
        return bln;
    }
    public Boolean getIsConfirm()
    {
        OleDbConnection conn = new OleDbConnection(oCmn.ConnectionString);
        conn.Open();
        Boolean bln = true;
        OleDbTransaction trans = conn.BeginTransaction();
        try
        {
            String sSql1 = "SELECT IS_CONFIRMED FROM PRESALE_CONTRACT_DETAIL WHERE CONT_PRESALE_ID='" + ContID + "' AND IS_CONFIRMED='Y'";
            OleDbDataReader oDr = OleDbHelper.ExecuteReader(trans, CommandType.Text, sSql1);
            if (oDr.HasRows)
                if (oDr.Read())
                    bln = false;
            trans.Commit();
            conn.Close();
        }
        catch (Exception exp)
        {
            trans.Rollback();
            conn.Close();
            throw new Exception("An error occurred ", exp);
        }
        return bln;
    }

    public DataSet fillgridview(string UserId)
    {
        //add by kamal matekar

        DataSet ds = new DataSet();
        CCommon con = new CCommon();
        string sqlstr = "";
        string strselectcriteria = "";
        string strselectcriteria1 = "";
 
        if (LeadBy != null && BDManager != null && MeetingLead != null)
        {

            strselectcriteria = "and a.lead_by='" + LeadBy + "' and A.BD_MANAGER_ID='" + BDManager + "'and H.Meeting_Lead='" + MeetingLead + "'and H.Meeting_det_Id in(Select top 1 Meeting_det_Id  from PRESALE_CONTRACT_MEETING_DETAIL Where CONT_PRESALE_ID= A.CONT_PRESALE_ID  Order By Meeting_Date desc)";
        }
        if (LeadBy == null && BDManager != null && MeetingLead != null)
        {

            strselectcriteria = "and A.BD_MANAGER_ID='" + BDManager + "'and H.Meeting_Lead='" + MeetingLead + "'and H.Meeting_det_Id in(Select top 1 Meeting_det_Id  from PRESALE_CONTRACT_MEETING_DETAIL Where CONT_PRESALE_ID= A.CONT_PRESALE_ID  Order By Meeting_Date desc)";
        }
        if (LeadBy != null && BDManager == null && MeetingLead == null)
        {

            strselectcriteria = "and a.lead_by='" + LeadBy + "'";
        }
        if (LeadBy != null && BDManager == null && MeetingLead != null)
        {
            strselectcriteria = "and a.lead_by='" + LeadBy + "'and H.Meeting_Lead='" + MeetingLead + "'and H.Meeting_det_Id in(Select top 1 Meeting_det_Id  from PRESALE_CONTRACT_MEETING_DETAIL Where CONT_PRESALE_ID= A.CONT_PRESALE_ID  Order By Meeting_Date desc)";
        }
        if (LeadBy == null && BDManager != null && MeetingLead == null)
        {
            strselectcriteria = "and A.BD_MANAGER_ID='" + BDManager + "'";
        }
        if (LeadBy == null && BDManager == null && MeetingLead != null)
        {
            strselectcriteria = "and H.Meeting_Lead='" + MeetingLead + "'and H.Meeting_det_Id in(Select top 1 Meeting_det_Id  from PRESALE_CONTRACT_MEETING_DETAIL Where CONT_PRESALE_ID= A.CONT_PRESALE_ID  Order By Meeting_Date desc)";
        }
        if (LeadBy != null && BDManager != null && MeetingLead == null)
        {
            strselectcriteria = "and a.lead_by='" + LeadBy + "'and A.BD_MANAGER_ID='" + BDManager + "'"; ;
        }
      if ("103386" == UserId)
        {
            strselectcriteria1 = "or E.activity_id='10133'";
        }

        if ("101103546" == UserId)
        {
            strselectcriteria1 = "or E.activity_id='10135'";
        }

        if ("101103547" == UserId)
        {
            strselectcriteria1 = "or E.activity_id='10137'";
        }

        if ("103388" == UserId)
        {
            strselectcriteria1 = "or E.activity_id='10138'";
        }

        if ("101565" == UserId)
        {
            strselectcriteria1 = "or E.activity_id='1011'";
        }

        if ("101889" == UserId)
        {
            strselectcriteria1 = "or E.activity_id='10136'";
        }

        if ("101103545" == UserId || "101190" == UserId || "101566" == UserId || "10133" == UserId || "101335" == UserId || "101546" == UserId)
        {
            sqlstr = "SELECT DISTINCT A.CONT_PRESALE_ID, A.CONT_PRESALE_REF_NO,convert(varchar,A.LEAD_DATE,106)AS LeadGen_DATE," +
                     "C.FULLNAME AS [BD Manager],g.FullName as [Lead By],B.CLIENT_NAME,A.CONTACT_PERSON AS " +
                     "[Client officer Name],D.ACTIVITY_NAME,F.PRODUCT_NAME,Isnull((Select (convert(varchar,Max(Meeting_Date),106)) from PRESALE_CONTRACT_MEETING_DETAIL Where CONT_PRESALE_ID=A.CONT_PRESALE_ID),convert(varchar,A.lead_date,106)) as Meeting_dt, " +
                     "Isnull((Select Top 1 REMARK from PRESALE_CONTRACT_MEETING_DETAIL Where CONT_PRESALE_ID=A.CONT_PRESALE_ID And Meeting_Date in ( Select Max(Meeting_Date) from PRESALE_CONTRACT_MEETING_DETAIL " +
                     "Where CONT_PRESALE_ID=A.CONT_PRESALE_ID )), A.Remark) as remark1 FROM PRESALE_CONTRACT_DETAIL AS A LEFT OUTER JOIN CLIENT_MASTER AS B ON A.CLIENT_ID = B.CLIENT_ID " +
                     "LEFT OUTER JOIN EMPLOYEE_MASTER C ON A.BD_MANAGER_ID=C.EMP_ID Left Outer Join Employee_master g on a.lead_by=g.emp_id LEFT OUTER JOIN " +
                     "PRESALE_CONTRACT_ACTIVITY_PRODUCT E ON A.CONT_PRESALE_ID=E.CONT_PRESALE_ID " +
                     "LEFT OUTER JOIN ACTIVITY_MASTER D ON E.ACTIVITY_ID=D.ACTIVITY_ID LEFT OUTER JOIN PRODUCT_MASTER F " +
                     "ON E.PRODUCT_ID=F.PRODUCT_ID left outer join PRESALE_CONTRACT_MEETING_DETAIL H on A.CONT_PRESALE_ID=H.CONT_PRESALE_ID " +
                     "where 1=1 " + strselectcriteria + " ORDER BY C.FULLNAME ";
        }
        else
        {
            sqlstr = "SELECT DISTINCT A.CONT_PRESALE_ID, A.CONT_PRESALE_REF_NO,convert(varchar,A.LEAD_DATE,106)AS LeadGen_DATE," +
                     "C.FULLNAME AS [BD Manager],g.FullName as [Lead By],B.CLIENT_NAME,A.CONTACT_PERSON AS " +
                     "[Client officer Name],D.ACTIVITY_NAME,F.PRODUCT_NAME,Isnull((Select (convert(varchar,Max(Meeting_Date),106)) from PRESALE_CONTRACT_MEETING_DETAIL Where CONT_PRESALE_ID=A.CONT_PRESALE_ID),convert(varchar,A.lead_date,106)) as Meeting_dt, " +
                     "Isnull((Select Top 1 REMARK from PRESALE_CONTRACT_MEETING_DETAIL Where CONT_PRESALE_ID=A.CONT_PRESALE_ID And Meeting_Date in ( Select Max(Meeting_Date) from PRESALE_CONTRACT_MEETING_DETAIL " +
                     "Where CONT_PRESALE_ID=A.CONT_PRESALE_ID )), A.Remark) as remark1 FROM PRESALE_CONTRACT_DETAIL AS A LEFT OUTER JOIN CLIENT_MASTER AS B ON A.CLIENT_ID = B.CLIENT_ID " +
                     "LEFT OUTER JOIN EMPLOYEE_MASTER C ON A.BD_MANAGER_ID=C.EMP_ID Left Outer Join Employee_master g on a.lead_by=g.emp_id LEFT OUTER JOIN " +
                     "PRESALE_CONTRACT_ACTIVITY_PRODUCT E ON A.CONT_PRESALE_ID=E.CONT_PRESALE_ID " +
                     "LEFT OUTER JOIN ACTIVITY_MASTER D ON E.ACTIVITY_ID=D.ACTIVITY_ID LEFT OUTER JOIN PRODUCT_MASTER F " +
                     "ON E.PRODUCT_ID=F.PRODUCT_ID left outer join PRESALE_CONTRACT_MEETING_DETAIL H on A.CONT_PRESALE_ID=H.CONT_PRESALE_ID " +
                     "where (A.BD_MANAGER_ID='" + UserId + "' or a.lead_by='" + UserId + "' " + strselectcriteria1 + " ) and 1=1 " + strselectcriteria + " ORDER BY C.FULLNAME ";

        }

        ds = OleDbHelper.ExecuteDataset(con.ConnectionString, CommandType.Text, sqlstr);
        return ds;

    }
}
