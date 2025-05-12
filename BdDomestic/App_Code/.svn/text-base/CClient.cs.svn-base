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
using System.Collections;

/// <summary>
/// Summary description for CClient
/// </summary>
public class CClient
{
    private CCommon oCmn;
    private string strMassage;
    private string strClientName;
    private string strClientCode;
    private string strSelectedProduct;
    private string strStatus;
    private string strClientId;

    private ArrayList alistOld;
    private ArrayList alistNew;

    public ArrayList alist;


    public ArrayList New
    {
        get { return alistNew; }
        set { alistNew = value; }
    }

    public ArrayList Old
    {
        get { return alistOld; }
        set { alistOld = value; }
    }

    private string strPrefix;

    public string ClientName
    {
        get { return strClientName; }
        set { strClientName = value; }
    }

    public string ClientCode
    {
        get { return strClientCode; }
        set { strClientCode = value; }
    }

    public string SelectedProduct
    {
        get { return strSelectedProduct; }
        set { strSelectedProduct = value; }
    }

    public string Status
    {
        get { return strStatus; }
    }

    public string ClientId
    {
        get { return strClientId; }
    }
    public string Massage
    {
        get { return strMassage; }
        set { strMassage = value; }
    }
    public CClient()
	{
        oCmn = new CCommon();
        alist = new ArrayList();
    }

    public void InsertClient()
    {
        OleDbConnection sqlConn = new OleDbConnection(oCmn.ConnectionString);
        sqlConn.Open();
        strPrefix = "101";
        //Create and open Transaction
        OleDbTransaction sqlTrans = sqlConn.BeginTransaction();
        try
        {
            //To Get Unique Client_id.
            strClientId = oCmn.GetUniqueID("CLIENT_MASTER", strPrefix).ToString();
            string strClient = "Insert Into Client_Master (Client_Id, Client_Code, Client_Name) values(?, ?, ?)";

            //Insert record in Client_Master.
            OleDbParameter[] paramClient = new OleDbParameter[3];
            paramClient[0] = new OleDbParameter("@ClientId", OleDbType.VarChar,15);
            paramClient[0].Value = strClientId;
            paramClient[1] = new OleDbParameter("@ClientCode", OleDbType.VarChar,15);
            paramClient[1].Value = strClientCode;
            paramClient[2] = new OleDbParameter("@ClientName", OleDbType.VarChar,100);
            paramClient[2].Value = strClientName;

            OleDbHelper.ExecuteNonQuery(sqlTrans, CommandType.Text, strClient, paramClient);

            int alistCounter = 0;
            //foreach (ListItem litem in alist)
            while(alistCounter < alist.Count)
            {
                string[] strHierId = alist[alistCounter].ToString().Split(',');
                //To get Unique Hier_Id.
                string strUniqueHierId = oCmn.GetUniqueID("COMPANY_HIERARCHY_MASTER", strPrefix).ToString();


                OleDbParameter[] paramHier =new OleDbParameter[3];
                paramHier[0] = new OleDbParameter("RefIdPr", OleDbType.VarChar);
                paramHier[0].Value = strHierId[0];

                paramHier[1]= new OleDbParameter("RefIdAc", OleDbType.VarChar);
                paramHier[1].Value = strHierId[1];

                paramHier[2] = new OleDbParameter("RefIdCe", OleDbType.VarChar);
                paramHier[2].Value = strHierId[2];


                //paramHier.Value=str;

                string strGetHier = "select CHM0.Hier_Id from Company_Hierarchy_Master CHM0 " +
                                    "where CHM0.Ref_Id=? and CHM0.Type='PR' " +
                                    "and CHM0.Parent_Id in " +
                                    "(select CHM.Hier_id from company_hierarchy_master CHM " +
                                    "where CHM.Ref_Id=? and CHM.Type='AC' " +
                                    "and CHM.Parent_Id in  " +
                                    "(select Hier_id from Company_Hierarchy_Master CHM1  " +
                                    "where CHM1.Ref_Id=? and CHM1.Type='CE' " +
                                    "and CHM1.Hier_id=CHM.Parent_Id))";

                //OleDbDataReader odrHier = OleDbHelper.ExecuteReader
                //                            (oCmn.ConnectionString, CommandType.Text,
                //                            strGetHier, paramHier);

                OleDbDataReader odrHier = OleDbHelper.ExecuteReader
                                            (sqlTrans, CommandType.Text,
                                            strGetHier, paramHier);

                while (odrHier.Read())
                {

                    //Insert record in COMPANY_HIERARCHY_MASTER.
                    string strHierarchy = "Insert into COMPANY_HIERARCHY_MASTER values (?, ?, ?, ?, ?)";
                    OleDbParameter[] paramHierarchy = new OleDbParameter[5];
                    paramHierarchy[0] = new OleDbParameter("@HIER_ID", OleDbType.VarChar, 50);
                    paramHierarchy[0].Value = oCmn.GetUniqueID("COMPANY_HIERARCHY_MASTER", strPrefix).ToString(); //strUniqueHierId;
                    paramHierarchy[1] = new OleDbParameter("@REF_ID", OleDbType.VarChar, 50);
                    paramHierarchy[1].Value = strClientId;
                    paramHierarchy[2] = new OleDbParameter("@HIER_LEVEL", OleDbType.Numeric);
                    paramHierarchy[2].Value = 6;
                    paramHierarchy[3] = new OleDbParameter("@PARENT_ID", OleDbType.VarChar, 50);
                    paramHierarchy[3].Value = odrHier["Hier_Id"].ToString();
                    paramHierarchy[4] = new OleDbParameter("@TYPE", OleDbType.VarChar, 5);
                    paramHierarchy[4].Value = "CT";


                    OleDbHelper.ExecuteNonQuery(sqlTrans, CommandType.Text, strHierarchy, paramHierarchy);
                }
                odrHier.Close();
                alistCounter += 1;
            }
            sqlTrans.Commit();
            sqlConn.Close();

        }
        catch (System.Exception ex)
        {
            sqlTrans.Rollback();
            sqlConn.Close();
            throw new Exception("An error occurred while executing the saving Client " + ex.Message , ex);
        }
    }

    public void EditClient(string strId)
    {
        OleDbConnection sqlConn = new OleDbConnection(oCmn.ConnectionString);
        sqlConn.Open();
        strPrefix = "101";
        //Create and open Transaction
        OleDbTransaction sqlTrans = sqlConn.BeginTransaction();
        try
        {
            //To Get Unique Client_id.
            strClientId = strId;//oCmn.GetUniqueID("Client_MASTER", strPrefix).ToString();
            string strClient = "Update Client_Master set Client_Code=?, Client_Name=? where Client_Id = ?";

            //Insert record in Client_Master.
            OleDbParameter[] paramClient = new OleDbParameter[3];
            paramClient[0] = new OleDbParameter("@ClientCode", OleDbType.VarChar, 15);
            paramClient[0].Value = strClientCode;
            paramClient[1] = new OleDbParameter("@ClientName", OleDbType.VarChar, 100);
            paramClient[1].Value = strClientName;
            paramClient[2] = new OleDbParameter("@ClientId", OleDbType.VarChar, 15);
            paramClient[2].Value = strClientId;

            OleDbHelper.ExecuteNonQuery(sqlTrans, CommandType.Text, strClient, paramClient);

            //Changes in Company_Hierarchy_Master
            ArrayList alistDelete = new ArrayList();
            foreach (string str in alistOld)
            {
                string strDelete = "SELECT DISTINCT c.CENTRE_ID, c.CENTRE_NAME, ch1.REF_ID AS activity_id, ac.ACTIVITY_NAME,  " +
                                   " ch2.REF_ID AS product_id, pm.PRODUCT_NAME, ch3.REF_ID AS client_id, cm.CLIENT_NAME,  " +
                                   " ch.HIER_ID AS HierCe, ch1.HIER_ID AS HierAc, ch2.HIER_ID AS HierPr, ch3.HIER_ID AS HierCt " +
                                   " FROM COMPANY_HIERARCHY_MASTER ch INNER JOIN " +
                                   " COMPANY_HIERARCHY_MASTER ch1 ON ch1.PARENT_ID = ch.HIER_ID AND ch1.TYPE = 'AC' INNER JOIN " +
                                   " CENTRE_MASTER c ON ch.REF_ID = c.CENTRE_ID LEFT OUTER JOIN " +
                                   " COMPANY_HIERARCHY_MASTER ch2 ON ch2.PARENT_ID = ch1.HIER_ID LEFT OUTER JOIN " +
                                   " PRODUCT_MASTER pm ON ch2.REF_ID = pm.PRODUCT_ID LEFT OUTER JOIN " +
                                   " ACTIVITY_MASTER ac ON ch1.REF_ID = ac.ACTIVITY_ID LEFT OUTER JOIN " +
                                   " COMPANY_HIERARCHY_MASTER ch3 ON ch3.PARENT_ID = ch2.HIER_ID LEFT OUTER JOIN " +
                                   " CLIENT_MASTER cm ON ch3.REF_ID = cm.CLIENT_ID AND ch3.TYPE = 'CT' AND ch2.TYPE = 'PR' ";

                string[] strCeAc = str.Split(',');
                strDelete += "where c.Centre_Id=? and ch1.REF_ID=? and Product_Id=? and ch3.REF_ID=?";
                OleDbParameter[] paramDel = new OleDbParameter[4];
                paramDel[0] = new OleDbParameter("@CeId", OleDbType.VarChar, 15);
                paramDel[0].Value = strCeAc[2];
                paramDel[1] = new OleDbParameter("@AcId", OleDbType.VarChar, 100);
                paramDel[1].Value = strCeAc[1];
                paramDel[2] = new OleDbParameter("@PrId", OleDbType.VarChar, 15);
                paramDel[2].Value = strCeAc[0];
                paramDel[3] = new OleDbParameter("@CtId", OleDbType.VarChar, 15);
                paramDel[3].Value = strClientId;

                OleDbDataReader olerd = OleDbHelper.ExecuteReader(sqlTrans, CommandType.Text, strDelete, paramDel);
                bool First = true;
                while (olerd.Read())
                {
                    try
                    {
                        OleDbHelper.ExecuteScalar(sqlTrans, CommandType.Text, "delete from Company_Hierarchy_master where Hier_Id =" + olerd["HierCt"].ToString());
                        if (First)
                        {
                            alistDelete.Add(str);
                            First = false;
                            strMassage = "Deleted successfully";
                        }
                    }
                    catch (Exception ex)
                    {
                        strMassage = "Error occurred while record is deliting";
                    }
                }
                olerd.Close();
            }

            foreach (string strChk in alistNew)
            {
                int lstCount = 0;
                bool bolMatch = true;
                while (lstCount < alistOld.Count && bolMatch)
                {
                    if (strChk == alistOld[lstCount].ToString())
                    {
                        bolMatch = false;
                    }
                    lstCount += 1;
                }

                lstCount = 0;
                while (lstCount < alistDelete.Count && !bolMatch)
                {
                    if (strChk == alistDelete[lstCount].ToString())
                    {
                        bolMatch = true;
                    }
                    lstCount += 1;
                }

                if (bolMatch)
                {
                    //insert hier here
                    string[] strCeAcPr = strChk.Split(',');

                    OleDbParameter[] paramHier = new OleDbParameter[3];

                    paramHier[0] = new OleDbParameter("RefIdPr", OleDbType.VarChar);
                    paramHier[0].Value = strCeAcPr[0];

                    paramHier[1] = new OleDbParameter("RefIdAc", OleDbType.VarChar);
                    paramHier[1].Value = strCeAcPr[1];

                    paramHier[2] = new OleDbParameter("RefIdCe", OleDbType.VarChar);
                    paramHier[2].Value = strCeAcPr[2];

                    OleDbDataReader odrHier = OleDbHelper.ExecuteReader
                                                (sqlTrans, CommandType.Text,
                                                "select Hier_id from COMPANY_HIERARCHY_MASTER CHM0 where (CHM0.REF_ID = ?) AND " +
                                                "(TYPE = 'PR') AND (CHM0.PARENT_ID IN " +
                                                "(SELECT HIER_ID FROM COMPANY_HIERARCHY_MASTER CHM WHERE (CHM.REF_ID = ?) AND " +
                                                "(TYPE = 'AC') AND (CHM.PARENT_ID IN " +
                                                "(SELECT Hier_id FROM Company_Hierarchy_Master CHM1 WHERE (CHM1.Ref_Id = ?) AND " +
                                                "CHM1.Type = 'CE' AND CHM1.Hier_id = CHM.Parent_Id))))", paramHier);

                    while (odrHier.Read())
                    {
                        //Insert record in COMPANY_HIERARCHY_MASTER.
                        string strHierarchy = "Insert into COMPANY_HIERARCHY_MASTER values (?, ?, ?, ?, ?)";
                        OleDbParameter[] paramHierarchy = new OleDbParameter[5];
                        paramHierarchy[0] = new OleDbParameter("@HIER_ID", OleDbType.VarChar, 50);
                        paramHierarchy[0].Value = oCmn.GetUniqueID("COMPANY_HIERARCHY_MASTER", strPrefix).ToString(); //strUniqueHierId;
                        paramHierarchy[1] = new OleDbParameter("@REF_ID", OleDbType.VarChar, 50);
                        paramHierarchy[1].Value = strClientId;
                        paramHierarchy[2] = new OleDbParameter("@HIER_LEVEL", OleDbType.Numeric);
                        paramHierarchy[2].Value = 6;
                        paramHierarchy[3] = new OleDbParameter("@PARENT_ID", OleDbType.VarChar, 50);
                        paramHierarchy[3].Value = odrHier["Hier_Id"].ToString();
                        paramHierarchy[4] = new OleDbParameter("@TYPE", OleDbType.VarChar, 5);
                        paramHierarchy[4].Value = "CT";

                        OleDbHelper.ExecuteNonQuery(sqlTrans, CommandType.Text, strHierarchy, paramHierarchy);
                    }
                    odrHier.Close();

                }
            }

            sqlTrans.Commit();
            sqlConn.Close();
            if(strMassage!="")
            {
                strMassage = "Edited successfully";
            }
        }
        catch (System.Exception ex)
        {
            sqlTrans.Rollback();
            sqlConn.Close();
            strMassage ="An error occurred while executing the update client " + ex.Message ;
        }
    }

    public DataSet GetHierCeAcPr()
    {
        string strSql = "SELECT DISTINCT c.CENTRE_ID, c.CENTRE_NAME, ch1.REF_ID AS activity_id,  " +
                        "ac.ACTIVITY_NAME, ch2.REF_ID AS product_id, pm.PRODUCT_NAME " +
                        "FROM COMPANY_HIERARCHY_MASTER ch INNER JOIN " +
                        "COMPANY_HIERARCHY_MASTER ch1 ON ch1.PARENT_ID = ch.HIER_ID AND ch1.TYPE = 'AC' INNER JOIN " +
                        "CENTRE_MASTER c ON ch.REF_ID = c.CENTRE_ID LEFT OUTER JOIN " +
                        "COMPANY_HIERARCHY_MASTER ch2 ON ch2.PARENT_ID = ch1.HIER_ID LEFT OUTER JOIN " +
                        "PRODUCT_MASTER pm ON ch2.REF_ID = pm.PRODUCT_ID LEFT OUTER JOIN " +
                        "ACTIVITY_MASTER ac ON ch1.REF_ID = ac.ACTIVITY_ID";
        //string strSql = "Select Centre_Name, Centre_Id, Activity_Name, Activity_Id, Product_Name, " + 
        //                "Product_id from ce_ac_pr_ct_vw where product_name is not null";

        return OleDbHelper.ExecuteDataset(oCmn.ConnectionString, CommandType.Text, strSql);
    }

    public bool GetChech(string strCentre, string strProductId, string strActivityId, string strClientId)
    {
        string strSql = "select centre_Id,Product_id from ce_ac_pr_ct_vw " +
                        "where Centre_Id=? and product_Id=? and activity_id=? and Client_Id=?";
        OleDbParameter[] paramGetCheck = new OleDbParameter[4];
        paramGetCheck[0] = new OleDbParameter("CentreId", OleDbType.VarChar);
        paramGetCheck[0].Value = strCentre;
        paramGetCheck[1] = new OleDbParameter("ProductId", OleDbType.VarChar);
        paramGetCheck[1].Value = strProductId;
        paramGetCheck[2] = new OleDbParameter("ActivityId", OleDbType.VarChar);
        paramGetCheck[2].Value = strActivityId;
        paramGetCheck[3] = new OleDbParameter("ClientId", OleDbType.VarChar);
        paramGetCheck[3].Value = strClientId;

        object obj = OleDbHelper.ExecuteScalar(oCmn.ConnectionString, CommandType.Text, strSql, paramGetCheck);
        if (obj == null)
            return false;
        else
            return true;
    }

}
