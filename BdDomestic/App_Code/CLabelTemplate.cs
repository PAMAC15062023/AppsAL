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
/// Summary description for CLabelTemplate
/// </summary>
public class CLabelTemplate
{
    CCommon oCom = new CCommon();
    private string centerID;
    private string productID;
    private string clientID;
    private string activityID;
    private string activityIDD;
    private string templatename;
    private string verificationId;
    private string verificationExist;
    private string verificationNew;   
    private string address1;
    private string line;
    private string lineno;
    private string charcter;
    private string address2;
    private string templateid;
    private string serialno;
    private string printingdate;
    private string alltypeverification;
    private string selectedfield;
    private string tablename;
    private string strIS_TYPE_SPECIFIC;
    
    private string templatetype;

    //For HUTCH.......
    //private string actual_date;
    //private string recieved_date;
    public DataSet dsPanelList;

    //For HUTCH........

    //public string ActualDate
    //{
    //    get { }
    //    set { actual_date = value; }
    //}
    //public string RecievdDate
    //{
    //}

    public string TemplateType
    {
        get { return templatetype; }
        set { templatetype = value; }
    }    
    
    public string Tablename
    {
        get { return tablename; }
        set { tablename = value; }
    }
    public string VerificationNew 
    {
        get { return verificationNew; }
        set { verificationNew = value; }
    }
    public string VerificationExist
    {
        get { return verificationExist; }
        set { verificationExist = value; }
    }

    public string Selectedfield
    {
        get { return selectedfield; }
        set { selectedfield = value; }
    }
    public string Serialno
    {
        get { return serialno; }
        set { serialno = value; }
    }
    public string Printingdate
    {
        get { return printingdate; }
        set { printingdate = value; }
    }
    public string Alltypeverification
    {
        get { return alltypeverification; }
        set { alltypeverification = value; }
    }

    public string ActivityID
    {
        get { return activityID; }
        set { activityID = value; }
    }
    public string ActivityIDD
    {
        get { return activityIDD; }
        set { activityIDD = value; }
    }

    public string ProductID
    {
        get { return productID; }
        set { productID = value; }
    }


    public string ClientID
    {
        get { return clientID; }
        set { clientID = value; }
    }
    public string VerificationId
    {
        get { return verificationId; }
        set { verificationId = value; }
    }
    public string Templatename
    {
        get { return templatename; }
        set { templatename = value; }
    }
    public string TemplateId
    {
        get { return templateid; }
        set { templateid = value; }
    }

    public string Address1
    {
        get { return address1; }
        set { address1 = value; }
    }


    public string Line
    {
        get { return line; }
        set { line = value; }
    }
    public string Line_No
    {
        get { return lineno; }
        set { lineno = value; }
    }
    public string Charcter
    {
        get { return charcter; }
        set { charcter = value; }
    }
    public string Address2
    {
        get { return address2; }
        set { address2 = value; }
    }

    /* By Ashish...*/
    public string IS_TYPE_SPECIFIC
    {
        get { return strIS_TYPE_SPECIFIC; }
        set { strIS_TYPE_SPECIFIC = value; }
    }


    //************************//
    public CLabelTemplate()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public DataSet activity()
    {
        string Query1 = "";
        Query1 = "select distinct Activity_Name,Activity_ID from ce_ac_pr_ct_vw order by activity_name desc ";
        //where Activity_ID='" + centerID + "'";

        //return Query1;Select distinct Activity_ID from ce_ac_pr_ct_vw where Activity_Name='cpv'
        return OleDbHelper.ExecuteDataset(oCom.ConnectionString, CommandType.Text, Query1);


    }

    //public String Activity_name(string activity_name)
    //{
    //    string Query1 = "";
    //    Query1 = "Select distinct Activity_ID from ce_ac_pr_ct_vw where Activity_Name='" + activity_name + "'";
    //    return Query1;

    //}

    public OleDbDataReader Activity_name(string activity_name)
    {
        OleDbConnection conn = new OleDbConnection(oCom.ConnectionString);
        CLabelTemplate commonPrint = new CLabelTemplate();
        conn.Open();
        String sqlQuery = "";
        sqlQuery = "Select distinct Activity_ID from ce_ac_pr_ct_vw where Activity_Name='" + activity_name + "' and activity_id is not null and activity_name is not null";
        return commonPrint.getDatainfo(sqlQuery);
    }
    public OleDbDataReader Product_name(string Productname)
    {
        OleDbConnection conn = new OleDbConnection(oCom.ConnectionString);
        CLabelTemplate commonPrint = new CLabelTemplate();
        conn.Open();
        String sqlQuery = "";
        sqlQuery = "Select distinct Product_id from ce_ac_pr_ct_vw where Product_name='" + Productname + "' and product_id is not null and product_name is not null";
        return commonPrint.getDatainfo(sqlQuery);
    }
    public OleDbDataReader Client_name(string Clientname)
    {
        OleDbConnection conn = new OleDbConnection(oCom.ConnectionString);
        CLabelTemplate commonPrint = new CLabelTemplate();
        conn.Open();
        String sqlQuery = "";
        sqlQuery = "Select distinct Client_id from ce_ac_pr_ct_vw where Client_name='" + Clientname + "' and Client_id is not null and Client_name is not null";
        return commonPrint.getDatainfo(sqlQuery);
    }
    public OleDbDataReader Verification_name(string Verificationname)
    {
        OleDbConnection conn = new OleDbConnection(oCom.ConnectionString);
        CLabelTemplate commonPrint = new CLabelTemplate();
        conn.Open();
        String sqlQuery = "";
        sqlQuery = "Select distinct verification_type_id from verification_type_master where Activity_id='" + Verificationname + "'";
        return commonPrint.getDatainfo(sqlQuery);
    }


    public DataSet Product()
    {
        string Query1 = "";
        Query1 = "select distinct Product_Name,Product_ID from ce_ac_pr_ct_vw where Product_ID='" + ActivityID + "' and product_id is not null and product_name is not null";
        // return Query1;
        return OleDbHelper.ExecuteDataset(oCom.ConnectionString, CommandType.Text, Query1);

    }
    public DataSet Verification()
    {
        string Query1 = "";
        Query1 = "SELECT VERIFICATION_TYPE_CODE,VERIFICATION_TYPE_ID from VERIFICATION_TYPE_MASTER  where ACTIVITY_ID='" + ActivityID + "'";
        return OleDbHelper.ExecuteDataset(oCom.ConnectionString, CommandType.Text, Query1);

    }

    public DataSet Client1()
    {
        string Query1 = "";
        Query1 = "select distinct Client_Name,Client_ID from ce_ac_pr_ct_vw where Product_ID='" + ProductID + "' and product_id is not null and product_name is not null";
        return OleDbHelper.ExecuteDataset(oCom.ConnectionString, CommandType.Text, Query1);

    }
    public String Client()
    {
        string Query1 = "";
        Query1 = "select distinct Client_Name,Client_ID from ce_ac_pr_ct_vw where Product_ID='" + ProductID + "' and product_id is not null and product_name is not null";
        return Query1;

    }
    public DataTable getSelectedField()
    {

        DataTable dtselectedField = new DataTable();
        String query = "";

        query = "select * from LABel_PRINTING_TEMPLATE_details where label_template_id='" + TemplateId + "' ";
        OleDbConnection conn = new OleDbConnection(oCom.ConnectionString);
        conn.Open();
        OleDbDataAdapter oledbDa = new OleDbDataAdapter(query, conn);
        DataSet ds = new DataSet();
        oledbDa.Fill(ds, "LABel_PRINTING_TEMPLATE_details");
        dtselectedField = ds.Tables["LABel_PRINTING_TEMPLATE_details"];
        return dtselectedField;
    }
    public DataTable Get_Total_Field(string Activity, string Product)
     {
        DataTable d_Tables = new DataTable();
        String sql = "select mt.table_name,name,id from syscolumns,map_table_master mt where id = (select id from sysobjects where name=mt.table_name) and activity_id='" + Activity + "' and product_id='" + Product + "' and mt.type='0'order by Name";

       
        
        OleDbConnection conn = new OleDbConnection(oCom.ConnectionString);
        conn.Open();
        OleDbDataAdapter da = new OleDbDataAdapter(sql, conn);
        DataSet Total_ds = new DataSet();
        da.Fill(Total_ds, "Template");
        d_Tables = Total_ds.Tables["Template"];
        return d_Tables;

    }
    public OleDbDataReader getDatainfo(string query)
    {
        OleDbConnection conn = new OleDbConnection(oCom.ConnectionString);
        OleDbCommand oledbCommand = new OleDbCommand();
        oledbCommand.CommandText = query;
        oledbCommand.Connection = conn;
        conn.Open();
        OleDbDataReader myr = oledbCommand.ExecuteReader();
        return myr;
    }
    public DataSet getfielgrid(string s1, string s2)
    {
        CLabelTemplate objLabel = new CLabelTemplate();
        String sql = "";
        sql = "select mt.table_name,name,id from syscolumns,map_table_master mt where id = (select id from sysobjects where name=mt.table_name) and activity_id='" + s1 + "' and product_id='" + s2 + "' and mt.type='0'order by Name";
        return OleDbHelper.ExecuteDataset(oCom.ConnectionString, CommandType.Text, sql);

    }

    public void insertTemplate()
    {

        OleDbConnection sqlConn = new OleDbConnection(oCom.ConnectionString);
        sqlConn.Open();
        string strPrefix = "101";
        //OleDbTransaction oledbTrans = sqlConn.BeginTransaction();
        //string strTemplateID;
        //TemplateId = oCom.GetUniqueID("LABEL_PRINTING_TEMPLATE_MASTER", strPrefix).ToString();
        string sql = "";
        string sql1 = "";
         
          
        OleDbTransaction oledbTrans = sqlConn.BeginTransaction();
        try
        {
            TemplateId = oCom.GetUniqueID("LABEL_PRINTING_TEMPLATE_MASTER", strPrefix).ToString();

            sql = "insert into LABEL_PRINTING_TEMPLATE_MASTER (label_template_id,template_name,"
                + "client_id,activity_id,product_id,verification_type_id,lines,"
                + "CharcterLength,additional1,additional2,sr_no,label_printing_date,all_verification_type,Template_For,IS_TYPE_SPECIFIC,Centre_id)"
                + " values (?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
            OleDbParameter[] param = new OleDbParameter[16];
            param[0] = new OleDbParameter("@TemplateId", OleDbType.VarChar);
            param[0].Value = TemplateId;
            param[1] = new OleDbParameter("@template_name", OleDbType.VarChar);
            param[1].Value = Templatename;
            param[2] = new OleDbParameter("@client_id", OleDbType.VarChar);
            param[2].Value = ClientID;
            param[3] = new OleDbParameter("@activity_id", OleDbType.VarChar);
            param[3].Value = ActivityID;
            param[4] = new OleDbParameter("@product_id", OleDbType.VarChar);
            param[4].Value = ProductID;
            param[5] = new OleDbParameter("@verification_type_id", OleDbType.VarChar);
            param[5].Value = VerificationId;
            param[6] = new OleDbParameter("@lines", OleDbType.VarChar);
            param[6].Value = Line_No;
            param[7] = new OleDbParameter("@CharcterLength", OleDbType.VarChar);
            param[7].Value = Charcter;
            param[8] = new OleDbParameter("@additional1", OleDbType.VarChar);
            param[8].Value = Address1;
            param[9] = new OleDbParameter("@additional2", OleDbType.VarChar);
            param[9].Value = Address2;
            param[10] = new OleDbParameter("@sr_no", OleDbType.VarChar);
            param[10].Value = Serialno;
            param[11] = new OleDbParameter("@label_printing_date", OleDbType.VarChar);
            param[11].Value = Printingdate;
            param[12] = new OleDbParameter("@all_verification_type", OleDbType.VarChar);
            param[12].Value = Alltypeverification;

            param[13] = new OleDbParameter("@Template_For", OleDbType.VarChar);
            param[13].Value = TemplateType;

            param[14] = new OleDbParameter("@IS_TYPE_SPECIFIC", OleDbType.VarChar);
            param[14].Value = IS_TYPE_SPECIFIC;
            param[15] = new OleDbParameter("@Centre_id", OleDbType.VarChar);
             param[15].Value = HttpContext.Current.Session["CentreId"].ToString();



            if (dsPanelList != null)
            {
                if (dsPanelList.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < dsPanelList.Tables[0].Rows.Count; i++)
                    {
                        sql1 = "insert into LABel_PRINTING_TEMPLATE_details (LABEL_TEMPLATE_ID,TABLE_NAME, " +
                              "SELECTED_FIELD,SERIAL_NO,line_no) values (?,?,?,?,?)";
                        OleDbParameter[] paramGrid = new OleDbParameter[5];

                        paramGrid[0] = new OleDbParameter("@LABEL_TEMPLATE_ID", OleDbType.VarChar);
                        paramGrid[0].Value = TemplateId;
                        paramGrid[1] = new OleDbParameter("@TABLE_NAME", OleDbType.VarChar);
                        paramGrid[1].Value = dsPanelList.Tables[0].Rows[i]["Tablename"].ToString();
                        paramGrid[2] = new OleDbParameter("@SELECTED_FIELD", OleDbType.VarChar);
                        paramGrid[2].Value = dsPanelList.Tables[0].Rows[i]["Selectedfield"].ToString();
                        paramGrid[3] = new OleDbParameter("@SERIAL_NO", OleDbType.VarChar);
                        paramGrid[3].Value = dsPanelList.Tables[0].Rows[i]["Serialno"].ToString();
                        paramGrid[4] = new OleDbParameter("@line_no", OleDbType.VarChar);
                        paramGrid[4].Value = dsPanelList.Tables[0].Rows[i]["Line_No"].ToString();

                        OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.Text, sql1, paramGrid);
                    }
                }

            }
            OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.Text, sql, param);
            oledbTrans.Commit();
            sqlConn.Close();
        }
        catch (Exception exp)
        {
            oledbTrans.Rollback();
            sqlConn.Close();
            throw new Exception("An error occurred ", exp);
        }
    }
    public void updateTemplate()
    {
        OleDbConnection sqlConn = new OleDbConnection(oCom.ConnectionString);
        sqlConn.Open();

        string strSQL2 = "";
        string sql1 = "";
        string sql = "";
        //string strTemplateID;

        OleDbTransaction sqlTrans = sqlConn.BeginTransaction();
        try
        {
            //pptTemplateID = objComm.GetUniqueID("SUMMARY_DETAIL_TEMPLATE_MASTER", strPrefix).ToString();

            sql = "Update LABEL_PRINTING_TEMPLATE_MASTER SET template_name=?,client_id=?,activity_id=?,product_id=?,verification_type_id=?,lines=?,CharcterLength=?,additional1=?,additional2=?,sr_no=?,label_printing_date=?,all_verification_type=? ,centre_id=? WHERE label_template_id=?";

            OleDbParameter[] param = new OleDbParameter[14];


            param[0] = new OleDbParameter("@template_name", OleDbType.VarChar);
            param[0].Value = Templatename;
            param[1] = new OleDbParameter("@client_id", OleDbType.VarChar);
            param[1].Value = ClientID;
            param[2] = new OleDbParameter("@activity_id", OleDbType.VarChar);
            param[2].Value = ActivityID;
            param[3] = new OleDbParameter("@product_id", OleDbType.VarChar);
            param[3].Value = ProductID;
            param[4] = new OleDbParameter("@verification_type_id", OleDbType.VarChar);
            param[4].Value = VerificationId;
            param[5] = new OleDbParameter("@lines", OleDbType.VarChar);
            param[5].Value = Line_No;
            param[6] = new OleDbParameter("@CharcterLength", OleDbType.VarChar);
            param[6].Value = Charcter;
            param[7] = new OleDbParameter("@additional1", OleDbType.VarChar);
            param[7].Value = Address1;
            param[8] = new OleDbParameter("@additional2", OleDbType.VarChar);
            param[8].Value = Address2;
            param[9] = new OleDbParameter("@sr_no", OleDbType.VarChar);
            param[9].Value = Serialno;
            param[10] = new OleDbParameter("@label_printing_date", OleDbType.VarChar);
            param[10].Value = Printingdate;
            param[11] = new OleDbParameter("@all_verification_type", OleDbType.VarChar);
            param[11].Value = Alltypeverification;           
            param[12] = new OleDbParameter("@Centre_id", OleDbType.VarChar);
            param[12].Value = HttpContext.Current.Session["CentreId"].ToString();
            param[13] = new OleDbParameter("@TemplateId", OleDbType.VarChar);
            param[13].Value = TemplateId;
            strSQL2 = "DELETE FROM [LABEL_PRINTING_TEMPLATE_details] WHERE [Label_TEMPLATE_ID]='" + TemplateId + "'";
            OleDbHelper.ExecuteNonQuery(sqlTrans, CommandType.Text, strSQL2);

            
           

            if (dsPanelList != null)
            {
                if (dsPanelList.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < dsPanelList.Tables[0].Rows.Count; i++)
                    {
                       


                        sql1 = "insert into LABel_PRINTING_TEMPLATE_details (LABEL_TEMPLATE_ID,TABLE_NAME, " +
                            "SELECTED_FIELD,SERIAL_NO,line_no) values (?,?,?,?,?)";
                        OleDbParameter[] paramGrid = new OleDbParameter[5];

                        paramGrid[0] = new OleDbParameter("@LABEL_TEMPLATE_ID", OleDbType.VarChar);
                        paramGrid[0].Value = TemplateId;
                        paramGrid[1] = new OleDbParameter("@TABLE_NAME", OleDbType.VarChar);
                        paramGrid[1].Value = dsPanelList.Tables[0].Rows[i]["Tablename"].ToString();
                        paramGrid[2] = new OleDbParameter("@SELECTED_FIELD", OleDbType.VarChar);
                        paramGrid[2].Value = dsPanelList.Tables[0].Rows[i]["Selectedfield"].ToString();
                        paramGrid[3] = new OleDbParameter("@SERIAL_NO", OleDbType.VarChar);
                        paramGrid[3].Value = dsPanelList.Tables[0].Rows[i]["Serialno"].ToString();
                        paramGrid[4] = new OleDbParameter("@line_no", OleDbType.VarChar);
                        paramGrid[4].Value = dsPanelList.Tables[0].Rows[i]["Line_No"].ToString();

                        OleDbHelper.ExecuteNonQuery(sqlTrans, CommandType.Text, sql1, paramGrid);
                    }
                }

            }

            OleDbHelper.ExecuteNonQuery(sqlTrans, CommandType.Text, sql, param);
            sqlTrans.Commit();
            sqlConn.Close();
        }
        catch (Exception exp)
        {
            sqlTrans.Rollback();
            sqlConn.Close();
            throw new Exception("An error occurred ", exp);
        }


    }


    public void InsertFields()
    {


        OleDbConnection oledbConn = new OleDbConnection(oCom.ConnectionString);
        oledbConn.Open();
        string strPrefix = "101";
        OleDbTransaction oledbTrans = oledbConn.BeginTransaction();
        if (HttpContext.Current.Session["TemplateId"] != null)
        {
            string sql = "";
            try
            {



                sql = "Update LABEL_PRINTING_TEMPLATE_MASTER SET template_name=?,client_id=?,activity_id=?,product_id=?,verification_type_id=?,lines=?,CharcterLength=?,additional1=?,additional2=?,sr_no=?,label_printing_date=?,all_verification_type=?,centre_id=? WHERE label_template_id=?";

                OleDbParameter[] param = new OleDbParameter[14];


                param[0] = new OleDbParameter("@template_name", OleDbType.VarChar);
                param[0].Value = Templatename;
                param[1] = new OleDbParameter("@client_id", OleDbType.VarChar);
                param[1].Value = ClientID;
                param[2] = new OleDbParameter("@activity_id", OleDbType.VarChar);
                param[2].Value = ActivityID;
                param[3] = new OleDbParameter("@product_id", OleDbType.VarChar);
                param[3].Value = ProductID;
                param[4] = new OleDbParameter("@verification_type_id", OleDbType.VarChar);
                param[4].Value = VerificationId;
                param[5] = new OleDbParameter("@lines", OleDbType.VarChar);
                param[5].Value = Line_No;
                param[6] = new OleDbParameter("@CharcterLength", OleDbType.VarChar);
                param[6].Value = Charcter;
                param[7] = new OleDbParameter("@additional1", OleDbType.VarChar);
                param[7].Value = Address1;
                param[8] = new OleDbParameter("@additional2", OleDbType.VarChar);
                param[8].Value = Address2;
                param[9] = new OleDbParameter("@sr_no", OleDbType.VarChar);
                param[9].Value = Serialno;
                param[10] = new OleDbParameter("@label_printing_date", OleDbType.VarChar);
                param[10].Value = Printingdate;
                param[11] = new OleDbParameter("@all_verification_type", OleDbType.VarChar);
                param[11].Value = Alltypeverification;
                param[12] = new OleDbParameter("@centre_id", OleDbType.VarChar);
                param[12].Value = HttpContext.Current.Session["CentreId"].ToString();
                param[13] = new OleDbParameter("@TemplateId", OleDbType.VarChar);
                param[13].Value = HttpContext.Current.Session["TemplateId"];
                OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.Text, sql, param);
               

                oledbTrans.Commit();
                oledbConn.Close();


            }
            catch (Exception ex)
            {
                oledbTrans.Rollback();
                oledbConn.Close();
                throw new Exception("Error while Inserting LabelPrinting " + ex.Message);
            }
        }




        else
        {
            TemplateId = oCom.GetUniqueID("LABEL_PRINTING_TEMPLATE_MASTER", strPrefix).ToString();
            string sql = "";
            try
            {
              

                sql = "insert into LABEL_PRINTING_TEMPLATE_MASTER (label_template_id,template_name,"
                 + "client_id,activity_id,product_id,verification_type_id,lines,"
                 + "CharcterLength,additional1,additional2,sr_no,label_printing_date,all_verification_type,centre_id)"
                 + " values (?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
                OleDbParameter[] param = new OleDbParameter[14];
                param[0] = new OleDbParameter("@TemplateId", OleDbType.VarChar);
                param[0].Value = TemplateId;
                param[1] = new OleDbParameter("@template_name", OleDbType.VarChar);
                param[1].Value = Templatename;
                param[2] = new OleDbParameter("@client_id", OleDbType.VarChar);
                param[2].Value = ClientID;
                param[3] = new OleDbParameter("@activity_id", OleDbType.VarChar);
                param[3].Value = ActivityID;
                param[4] = new OleDbParameter("@product_id", OleDbType.VarChar);
                param[4].Value = ProductID;
                param[5] = new OleDbParameter("@verification_type_id", OleDbType.VarChar);
                param[5].Value = VerificationId;
                param[6] = new OleDbParameter("@lines", OleDbType.VarChar);
                param[6].Value = Line_No;
                param[7] = new OleDbParameter("@CharcterLength", OleDbType.VarChar);
                param[7].Value = Charcter;
                param[8] = new OleDbParameter("@additional1", OleDbType.VarChar);
                param[8].Value = Address1;
                param[9] = new OleDbParameter("@additional2", OleDbType.VarChar);
                param[9].Value = Address2;
                param[10] = new OleDbParameter("@sr_no", OleDbType.VarChar);
                param[10].Value = Serialno;
                param[11] = new OleDbParameter("@label_printing_date", OleDbType.VarChar);
                param[11].Value = Printingdate;
                param[12] = new OleDbParameter("@all_verification_type", OleDbType.VarChar);
                param[12].Value = Alltypeverification;
                param[13] = new OleDbParameter("@centre_id", OleDbType.VarChar);
                param[13].Value = HttpContext.Current.Session["CentreId"].ToString();



                OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.Text, sql, param);


                oledbTrans.Commit();
                oledbConn.Close();


            }
            catch (Exception ex)
            {
                oledbTrans.Rollback();
                oledbConn.Close();
                throw new Exception("Error while Inserting LabelPrinting " + ex.Message);
            }
        }
    }

    public void insertGridFields()
    {


        OleDbConnection oledbConn = new OleDbConnection(oCom.ConnectionString);
        oledbConn.Open();
        string sql = "";
        OleDbTransaction oledbTrans = oledbConn.BeginTransaction();
        if (HttpContext.Current.Session["TemplateId"] != null)
        {
            try
            {

                sql = "";
                sql = "UPDATE  LABel_PRINTING_TEMPLATE_details  SET TABLE_NAME=?, SELECTED_FIELD=?,SERIAL_NO=?,line_no=? where LABEL_TEMPLATE_ID=?";

                OleDbParameter[] paramGrid = new OleDbParameter[5];


                paramGrid[0] = new OleDbParameter("@TABLE_NAME", OleDbType.VarChar);
                paramGrid[0].Value = Tablename;
                paramGrid[1] = new OleDbParameter("@SELECTED_FIELD", OleDbType.VarChar);
                paramGrid[1].Value = Selectedfield;
                paramGrid[2] = new OleDbParameter("@SERIAL_NO", OleDbType.VarChar);
                paramGrid[2].Value = Serialno;
                paramGrid[3] = new OleDbParameter("@line_no", OleDbType.VarChar);
                paramGrid[3].Value = Line_No;
                paramGrid[4] = new OleDbParameter("@TemplateId", OleDbType.VarChar);
                paramGrid[4].Value = HttpContext.Current.Session["TemplateId"];
                OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.Text, sql, paramGrid);
                oledbTrans.Commit();
                oledbConn.Close();

            }
            catch (Exception ex)
            {
                oledbTrans.Rollback();
                oledbConn.Close();
                throw new Exception("Error while Inserting LabelPrinting " + ex.Message);
            }
        }
        else
        {
            try
            {

                sql = "";
                sql = "insert into LABel_PRINTING_TEMPLATE_details (LABEL_TEMPLATE_ID,TABLE_NAME, " +
                      "SELECTED_FIELD,SERIAL_NO,line_no) values (?,?,?,?,?)";
                OleDbParameter[] paramGrid = new OleDbParameter[5];

                paramGrid[0] = new OleDbParameter("@LABEL_TEMPLATE_ID", OleDbType.VarChar);
                paramGrid[0].Value = TemplateId;
                paramGrid[1] = new OleDbParameter("@TABLE_NAME", OleDbType.VarChar);
                paramGrid[1].Value = Tablename;
                paramGrid[2] = new OleDbParameter("@SELECTED_FIELD", OleDbType.VarChar);
                paramGrid[2].Value = Selectedfield;
                paramGrid[3] = new OleDbParameter("@SERIAL_NO", OleDbType.VarChar);
                paramGrid[3].Value = Serialno;
                paramGrid[4] = new OleDbParameter("@line_no", OleDbType.VarChar);
                paramGrid[4].Value = Line_No;
                OleDbHelper.ExecuteNonQuery(oledbTrans, CommandType.Text, sql, paramGrid);

                oledbTrans.Commit();
                oledbConn.Close();


            }
            catch (Exception ex)
            {
                oledbTrans.Rollback();
                oledbConn.Close();
                throw new Exception("Error while Inserting LabelPrinting " + ex.Message);
            }

        }



    }
    public OleDbDataReader getinfo()
    {
        OleDbConnection conn = new OleDbConnection(oCom.ConnectionString);
        CLabelTemplate commonPrint = new CLabelTemplate();
        conn.Open();
        String sqlQuery = "";
        sqlQuery = "select lptm.template_name,cm.client_name,cm.client_id,am.activity_name,am.activity_id,pm.product_name,pm.product_id,vtm.verification_type_code ,vtm.verification_type_id  ,lptm.lines,lptm.Charcterlength,lptm.additional1,lptm.additional2,lptm.sr_no,lptm.label_printing_date,lptm.all_verification_type from LABEL_PRINTING_TEMPLATE_MASTER as lptm inner join Client_master as cm on lptm.client_id=cm.client_id inner join  activity_master as am on lptm.activity_id=am.activity_id inner join product_master as pm on lptm.product_id=pm.product_id inner join verification_type_master as vtm on lptm.verification_type_id=vtm.verification_type_id  where lptm.label_template_id= " + TemplateId + " ";
        return commonPrint.getDatainfo(sqlQuery);
    }

    //change
    public void getTemplates()
    {
        OleDbConnection sqlConn = new OleDbConnection(oCom.ConnectionString);
        //sqlConn.Open();
        CLabelTemplate commonPrint = new CLabelTemplate();

        string strSQL = "";
        strSQL = "select Activity_id,product_id,client_id,verification_type_id,template_name,lines,charcterlength,additional1,additional2,sr_no,label_printing_date,all_verification_type,template_for from LABEL_PRINTING_TEMPLATE_MASTER  WHERE LABEL_TEMPLATE_ID='" + templateid + "'";

        OleDbDataReader dr;
        dr = OleDbHelper.ExecuteReader(sqlConn, CommandType.Text, strSQL);
        while (dr.Read())
        {
            ActivityID = dr[0].ToString();
            ProductID = dr[1].ToString();
            ClientID = dr[2].ToString();
            VerificationId = dr[3].ToString();
            Templatename = dr[4].ToString();
            Line = dr[5].ToString();
            Charcter = dr[6].ToString();
            Address1 = dr[7].ToString();
            Address2 = dr[8].ToString();
            Serialno = dr[9].ToString();
            Printingdate = dr[10].ToString();
            Alltypeverification = dr[11].ToString();
            TemplateType = dr[12].ToString();
        }
        dr.Close();

        DataSet objDataSet = new DataSet();
        strSQL = "";
        strSQL = strSQL + " select * from LABEL_PRINTING_TEMPLATE_details where LABEL_TEMPLATE_ID='" + HttpContext.Current.Session["TemplateId"] + "'";
        objDataSet = OleDbHelper.ExecuteDataset(sqlConn, CommandType.Text, strSQL);
        // dsPanelList = objDataSet;

    }
    public void deleteTemplate()
    {
        OleDbConnection sqlConn = new OleDbConnection(oCom.ConnectionString);
        sqlConn.Open();

        string strSQL = "";
        string strSQL1 = "";

        OleDbTransaction sqlTrans = sqlConn.BeginTransaction();

        try
        {
            strSQL = " DELETE FROM LABEL_PRINTING_TEMPLATE_MASTER WHERE [label_template_id]='" + TemplateId + "'";
            strSQL1 = " DELETE FROM LABEL_PRINTING_TEMPLATE_details WHERE [label_template_id]='" + TemplateId + "'";

            OleDbHelper.ExecuteNonQuery(sqlTrans, CommandType.Text, strSQL);
            OleDbHelper.ExecuteNonQuery(sqlTrans, CommandType.Text, strSQL1);

            sqlTrans.Commit();
            sqlConn.Close();
        }
        catch (Exception exp)
        {
            sqlTrans.Rollback();
            sqlConn.Close();
            throw new Exception("An error occurred ", exp);
        }
    }

    public Boolean getDuplicateValue(String strTemplate_ID)
    {
        OleDbConnection sqlConn = new OleDbConnection(oCom.ConnectionString);
        sqlConn.Open();
        Boolean blnResult = false;

        string strSQL = "";
        strSQL = " SELECT [ACTIVITY_ID],[PRODUCT_ID],[CLIENT_ID],[VERIFICATION_TYPE_ID] FROM [LABEL_PRINTING_TEMPLATE_MASTER] ";
        strSQL = strSQL + " WHERE [ACTIVITY_ID]='" + ActivityID + "' AND ";
        //strSQL = strSQL + "  [ACTIVITY_ID]='" + ActivityID + "' AND ";
        strSQL = strSQL + "  [PRODUCT_ID]='" + ProductID + "' AND ";
        strSQL = strSQL + "  [CLIENT_ID]='" + ClientID + "' AND ";
        strSQL = strSQL + "  [VERIFICATION_TYPE_ID]='" + VerificationId + "'";
        strSQL = strSQL + " AND [Template_For]='" + TemplateType + "'";
        if (strTemplate_ID != "")
        {
            strSQL = strSQL + " AND [label_template_id]<>'" + strTemplate_ID + "'";
        }

        OleDbDataReader objOLEDBHelper = OleDbHelper.ExecuteReader(sqlConn, CommandType.Text, strSQL);

        if (objOLEDBHelper.Read())
        {
            blnResult = true;
        }
        objOLEDBHelper.Close();
        sqlConn.Close();
        return blnResult;
    }
   
}
