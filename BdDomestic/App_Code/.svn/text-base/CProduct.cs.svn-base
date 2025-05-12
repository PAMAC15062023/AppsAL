using System;
using System.Data;
using System.Data.OleDb;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Summary description for CProduct
/// </summary>
public class CProduct
{
    private CCommon oCmn;

    private string strProductName;
    private string strProductCode;
    //private string strSelectedActivities;
    private string strStatus;
    private string strProductId;
    private ArrayList alistOld;
    private string strMassage;
    public ArrayList alist;

    private ArrayList alistNew;

    public ArrayList New
    {
        get { return alistNew; }
        set { alistNew = value; }
    }

    private string strPrefix;

    public string ProductName
    {
        get { return strProductName; }
        set { strProductName = value; }
    }

    public string ProductCode
    {
        get { return strProductCode; }
        set { strProductCode = value; }
    }
    public string Massage
    {
        get { return strMassage; }
        set { strMassage = value; }
    }
    public string Status
    {
        get { return strStatus; }
    }

    public string ProductId
    {
        get { return strProductId; }
    }

    public CProduct()
	{
        oCmn = new CCommon();
        alist = new ArrayList();
    }

    public ArrayList Old
    {
        get { return alistOld; }
        set { alistOld = value; }
    }

    public void InsertProduct()
    {
        OleDbConnection sqlConn = new OleDbConnection(oCmn.ConnectionString);
        sqlConn.Open();
        strPrefix = "101";
        //Create and open Transaction
        OleDbTransaction sqlTrans = sqlConn.BeginTransaction();
        try
        {
            //To Get Unique Product_id.
            strProductId = oCmn.GetUniqueID("PRODUCT_MASTER", strPrefix).ToString();
            string strProduct = "Insert Into Product_Master(Product_Id, Product_Code, Product_Name) values(?, ?, ?)";

            //Insert record in Product_Master.
            OleDbParameter[] paramProduct = new OleDbParameter[3];
            paramProduct[0] = new OleDbParameter("@ProductId", OleDbType.VarChar,15);
            paramProduct[0].Value = strProductId;
            paramProduct[1] = new OleDbParameter("@ProductCode", OleDbType.VarChar,15);
            paramProduct[1].Value = strProductCode;
            paramProduct[2] = new OleDbParameter("@ProductName", OleDbType.VarChar,100);
            paramProduct[2].Value = strProductName;

            OleDbHelper.ExecuteNonQuery(sqlTrans, CommandType.Text, strProduct, paramProduct);

            int alistCounter = 0;
            //foreach (ListItem litem in alist)
            while(alistCounter < alist.Count)
            {
                string[] strHierId = alist[alistCounter].ToString().Split(',');
                //To get Unique Hier_Id.
                //string strUniqueHierId = oCmn.GetUniqueID("COMPANY_HIERARCHY_MASTER", strPrefix).ToString();


                OleDbParameter[] paramHier =new OleDbParameter[2];
                paramHier[0]= new OleDbParameter("RefIdAc", OleDbType.VarChar);
                paramHier[0].Value = strHierId[0];

                paramHier[1] = new OleDbParameter("RefIdCe", OleDbType.VarChar);
                paramHier[1].Value = strHierId[1];

                //paramHier.Value=str;

                OleDbDataReader odrHier = OleDbHelper.ExecuteReader
                                            (sqlTrans, CommandType.Text,
                                            "select CHM.Hier_id from company_hierarchy_master CHM " +
                                            "where CHM.Ref_Id=? and CHM.Type='AC' " +
                                            "and CHM.Parent_Id in  " +
                                            "(select Hier_id from Company_Hierarchy_Master CHM1  " +
                                            "where CHM1.Ref_Id=? and CHM1.Type='CE' " +
                                            "and CHM1.Hier_id=CHM.Parent_Id)", paramHier);

                while (odrHier.Read())
                {

                    //Insert record in COMPANY_HIERARCHY_MASTER.
                    string strHierarchy = "Insert into COMPANY_HIERARCHY_MASTER values (?, ?, ?, ?, ?)";
                    OleDbParameter[] paramHierarchy = new OleDbParameter[5];
                    paramHierarchy[0] = new OleDbParameter("@HIER_ID", OleDbType.VarChar, 50);
                    paramHierarchy[0].Value = oCmn.GetUniqueID("COMPANY_HIERARCHY_MASTER", strPrefix).ToString(); //strUniqueHierId;
                    paramHierarchy[1] = new OleDbParameter("@REF_ID", OleDbType.VarChar, 50);
                    paramHierarchy[1].Value = strProductId;
                    paramHierarchy[2] = new OleDbParameter("@HIER_LEVEL", OleDbType.Numeric);
                    paramHierarchy[2].Value = 5;
                    paramHierarchy[3] = new OleDbParameter("@PARENT_ID", OleDbType.VarChar, 50);
                    paramHierarchy[3].Value = odrHier["Hier_Id"].ToString();
                    paramHierarchy[4] = new OleDbParameter("@TYPE", OleDbType.VarChar, 5);
                    paramHierarchy[4].Value = "PR";

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
            throw new Exception("An error occurred while executing the Insert Product " + ex.Message , ex);
        }
    }

    public void EditProduct(string strId)//ArrayList alistOld, ArrayList alistNew)
    {
        OleDbConnection sqlConn = new OleDbConnection(oCmn.ConnectionString);
        sqlConn.Open();
        strPrefix = "101";

        //Create and open Transaction
        OleDbTransaction sqlTrans = sqlConn.BeginTransaction();
        try
        {
            //To Get Unique Product_id.
            strProductId = strId;
            string strProduct = "Update Product_Master set Product_Code=?, Product_Name=? where Product_Id = ?";

            //Edit record in Product_Master.
            OleDbParameter[] paramProduct = new OleDbParameter[3];
            paramProduct[0] = new OleDbParameter("@ProductCode", OleDbType.VarChar, 15);
            paramProduct[0].Value = strProductCode;
            paramProduct[1] = new OleDbParameter("@ProductName", OleDbType.VarChar, 100);
            paramProduct[1].Value = strProductName;
            paramProduct[2] = new OleDbParameter("@ProductId", OleDbType.VarChar, 15);
            paramProduct[2].Value = strProductId;

            OleDbHelper.ExecuteNonQuery(sqlTrans, CommandType.Text, strProduct, paramProduct);

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
                strDelete += "where c.Centre_Id=? and ch1.REF_ID=? and Product_Id=?";
                OleDbParameter[] paramDel = new OleDbParameter[3];
                paramDel[0] = new OleDbParameter("@CeId", OleDbType.VarChar, 15);
                paramDel[0].Value = strCeAc[1];
                paramDel[1] = new OleDbParameter("@AcId", OleDbType.VarChar, 100);
                paramDel[1].Value = strCeAc[0];
                paramDel[2] = new OleDbParameter("@PrId", OleDbType.VarChar, 15);
                paramDel[2].Value = strProductId;

                OleDbDataReader olerd = OleDbHelper.ExecuteReader(sqlTrans, CommandType.Text, strDelete, paramDel);
                while (olerd.Read())
                {
                    try
                    {
                        OleDbHelper.ExecuteScalar(sqlTrans, CommandType.Text, "delete from Company_Hierarchy_master where Hier_Id =" + olerd["HierPr"].ToString());
                        alistDelete.Add(str);
                        strMassage = "Unassigned successfully";
                    }
                    catch (Exception ex)
                    {
                       
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
                    string[] strCeAc = strChk.Split(',');

                    OleDbParameter[] paramHier = new OleDbParameter[2];
                    paramHier[0] = new OleDbParameter("RefIdAc", OleDbType.VarChar);
                    paramHier[0].Value = strCeAc[0];

                    paramHier[1] = new OleDbParameter("RefIdCe", OleDbType.VarChar);
                    paramHier[1].Value = strCeAc[1];

                    //paramHier.Value=str;

                    OleDbDataReader odrHier = OleDbHelper.ExecuteReader
                                                (sqlTrans, CommandType.Text,
                                                "select CHM.Hier_id from company_hierarchy_master CHM " +
                                                "where CHM.Ref_Id=? and CHM.Type='AC' " +
                                                "and CHM.Parent_Id in  " +
                                                "(select Hier_id from Company_Hierarchy_Master CHM1  " +
                                                "where CHM1.Ref_Id=? and CHM1.Type='CE' " +
                                                "and CHM1.Hier_id=CHM.Parent_Id)", paramHier);

                    while (odrHier.Read())
                    {

                        //Insert record in COMPANY_HIERARCHY_MASTER.
                        string strHierarchy = "Insert into COMPANY_HIERARCHY_MASTER values (?, ?, ?, ?, ?)";
                        OleDbParameter[] paramHierarchy = new OleDbParameter[5];
                        paramHierarchy[0] = new OleDbParameter("@HIER_ID", OleDbType.VarChar, 50);
                        paramHierarchy[0].Value = oCmn.GetUniqueID("COMPANY_HIERARCHY_MASTER", strPrefix).ToString(); //strUniqueHierId;
                        paramHierarchy[1] = new OleDbParameter("@REF_ID", OleDbType.VarChar, 50);
                        paramHierarchy[1].Value = strProductId;
                        paramHierarchy[2] = new OleDbParameter("@HIER_LEVEL", OleDbType.Numeric);
                        paramHierarchy[2].Value = 5;
                        paramHierarchy[3] = new OleDbParameter("@PARENT_ID", OleDbType.VarChar, 50);
                        paramHierarchy[3].Value = odrHier["Hier_Id"].ToString();
                        paramHierarchy[4] = new OleDbParameter("@TYPE", OleDbType.VarChar, 5);
                        paramHierarchy[4].Value = "PR";

                        OleDbHelper.ExecuteNonQuery(sqlTrans, CommandType.Text, strHierarchy, paramHierarchy);
                        strMassage = "";
                    }
                    odrHier.Close();

                }
            }
            
            sqlTrans.Commit();
            sqlConn.Close();
            if (strMassage == "")
            {
                strMassage = "Updated Succesfully";
            }
        }
        catch (System.Exception ex)
        {
            sqlTrans.Rollback();
            sqlConn.Close();
            strMassage= "An error occurred while executing the update Product" + ex.Message;
        }
    }



    public DataSet GetHierCeAc()
    {
        string strSql = "SELECT DISTINCT CM.CENTRE_ID, CM.CENTRE_NAME, AM.ACTIVITY_ID, AM.ACTIVITY_NAME " +
                        "FROM COMPANY_HIERARCHY_MASTER CHM1 INNER JOIN " +
                        "CENTRE_MASTER CM ON CHM1.REF_ID = CM.CENTRE_ID AND CHM1.TYPE = 'CE' INNER JOIN " +
                        "COMPANY_HIERARCHY_MASTER CHM2 ON CHM1.HIER_ID = CHM2.PARENT_ID INNER JOIN " +
                        "ACTIVITY_MASTER AM ON CHM2.REF_ID = AM.ACTIVITY_ID";
        return OleDbHelper.ExecuteDataset(oCmn.ConnectionString, CommandType.Text, strSql);
    }

    public bool GetChech(string strCentre, string strProductId, string strActivityId)
    {
        string strSql = "select centre_Id,Product_id from ce_ac_pr_ct_vw " +
                        "where Centre_Id=? and product_Id=? and activity_id=?";
        OleDbParameter[] paramGetCheck = new OleDbParameter[3];
        paramGetCheck[0] = new OleDbParameter("CentreId", OleDbType.VarChar);
        paramGetCheck[0].Value = strCentre;
        paramGetCheck[1] = new OleDbParameter("ProductId", OleDbType.VarChar);
        paramGetCheck[1].Value = strProductId;
        paramGetCheck[2] = new OleDbParameter("ActivityId", OleDbType.VarChar);
        paramGetCheck[2].Value = strActivityId;

        object obj = OleDbHelper.ExecuteScalar(oCmn.ConnectionString , CommandType.Text, strSql, paramGetCheck);
        if (obj == null)
            return false;
        else
            return true;
    }
}
