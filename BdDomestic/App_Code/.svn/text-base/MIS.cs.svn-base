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
/// Summary description for MIS
/// </summary>
public class MIS
{
     private CCommon objCon;

	public MIS()
	{
     
	    objCon = new CCommon();
		//
		// TODO: Add constructor logic here
		//
    }
    #region Property Declaration
    private string clientCode;
    private string bdCode;
    private string activityCode;
    private string productCode;

    #endregion Property Declaration
    public string ClientCode
    {
        get 
        {
            return clientCode;
 
        }
        set
        {
            clientCode = value;
        }
    }
    public string BDCode
    {
        get
        {
            return bdCode;

        }
        set
        {
            bdCode = value;
        }
    }
    public string ActivityCode
    {
        get
        {
            return activityCode;

        }
        set
        {
            activityCode = value;
        }
    }

    public string ProductCode
    {
        get
        {
            return productCode;

        }
        set
        {
            productCode = value;
        }
    }
    public String GetAllBd()
    {
           String MYSQL = "";
            MYSQL = "SELECT pcd.CONT_PRESALE_REF_NO,cm.CLIENT_NAME,am.ACTIVITY_NAME,pm.PRODUCT_NAME,em.FULLNAME as Lead_Ganerated_By,Convert(char(25), pcd.Lead_date,103) as Lead_Generated_date,pcd.IS_CONFIRMED as Contract_Status,convert(char(25),pcd.CONFIRM_DATE,103) as Close_date FROM CLIENT_MASTER as cm inner join PRESALE_CONTRACT_DETAIL as pcd on cm.CLIENT_ID=pcd.CLIENT_ID inner join PRESALE_CONTRACT_ACTIVITY_PRODUCT as pcap on pcd.CONT_PRESALE_ID=pcap.CONT_PRESALE_ID inner join ACTIVITY_MASTER as am  on am.ACTIVITY_ID=pcap.ACTIVITY_ID inner join PRODUCT_MASTER as pm on pcap.PRODUCT_ID=pm.PRODUCT_ID inner join employee_master as em on pcd.LEAD_BY=em.EMP_ID where 1=1 ";
          
                MYSQL = MYSQL + " and  pcd.BD_Manager_ID = " + "'" + BDCode + " ' ";

                if (ClientCode != "0")
                {

                    MYSQL = MYSQL + " and  cm.client_id = " + "'" + ClientCode + "'";
                }
                if (ActivityCode != "0")
                {

                    MYSQL = MYSQL + " and  am.ACTIVITY_ID = " + "'" + ActivityCode + "'";
                }
                if (ProductCode != "0")
                {

                    MYSQL = MYSQL + " and  pm.PRODUCT_ID = " + "'" + ProductCode + "'";
                }

                return MYSQL;//OleDbHelper.ExecuteDataset(objCon.ConnectionString, CommandType.Text, MYSQL);
           }

    public String GetAllClient()
    {
        String MYSQL = "";
        MYSQL = "SELECT pcd.CONT_PRESALE_REF_NO,em1.fullname as BD_MANAGER,am.ACTIVITY_NAME,pm.PRODUCT_NAME,em.FULLNAME as Lead_Ganerated_By,Convert(char(25), pcd.Lead_date,103) as Lead_Generated_date,pcd.IS_CONFIRMED as Contract_Status,convert(char(25),pcd.CONFIRM_DATE,103) as Close_date FROM CLIENT_MASTER as cm inner join PRESALE_CONTRACT_DETAIL as pcd on cm.CLIENT_ID=pcd.CLIENT_ID  inner join PRESALE_CONTRACT_ACTIVITY_PRODUCT as pcap on pcd.CONT_PRESALE_ID=pcap.CONT_PRESALE_ID inner join ACTIVITY_MASTER as am  on am.ACTIVITY_ID=pcap.ACTIVITY_ID inner join PRODUCT_MASTER as pm on pcap.PRODUCT_ID=pm.PRODUCT_ID inner join employee_master as em on pcd.LEAD_BY=em.EMP_ID inner join employee_master as em1 on pcd.bd_manager_id=em1.EMP_ID where 1=1";

       

            MYSQL = MYSQL + " and  cm.client_id = " + "'" + ClientCode + "'";


            if (BDCode != "0")
            {
                MYSQL = MYSQL + " and  pcd.BD_Manager_ID = " + "'" + BDCode + " ' ";
            }


            if (ActivityCode != "0")
        {

            MYSQL = MYSQL + " and  am.ACTIVITY_ID = " + "'" + ActivityCode + "'";
        }
        if (ProductCode != "0")
        {

            MYSQL = MYSQL + " and  pm.PRODUCT_ID = " + "'" + ProductCode + "'";
        }

        return MYSQL;//OleDbHelper.ExecuteDataset(objCon.ConnectionString, CommandType.Text, MYSQL);
    }

    public String GetParticularBd()
    {
        String MYSQL = "";
        MYSQL = "SELECT pcd.CONT_PRESALE_REF_NO,cm.CLIENT_NAME,am.ACTIVITY_NAME,pm.PRODUCT_NAME,em.FULLNAME as Lead_Ganerated_By,Convert(char(25), pcd.Lead_date,103) as Lead_Generated_date,pcd.IS_CONFIRMED as Contract_Status,convert(char(25),pcd.CONFIRM_DATE,103) as Close_date FROM CLIENT_MASTER as cm inner join PRESALE_CONTRACT_DETAIL as pcd on cm.CLIENT_ID=pcd.CLIENT_ID inner join PRESALE_CONTRACT_ACTIVITY_PRODUCT as pcap on pcd.CONT_PRESALE_ID=pcap.CONT_PRESALE_ID inner join ACTIVITY_MASTER as am  on am.ACTIVITY_ID=pcap.ACTIVITY_ID inner join PRODUCT_MASTER as pm on pcap.PRODUCT_ID=pm.PRODUCT_ID inner join employee_master as em on pcd.LEAD_BY=em.EMP_ID where 1=1 ";
       if (BDCode != "0")
        {
            MYSQL = MYSQL + " and  pcd.BD_Manager_ID = " + "'" + BDCode + " ' ";
        }
        if (ClientCode != "0")
         {
        MYSQL = MYSQL + " and  cm.client_id = " + "'" + ClientCode + "'";
         }
         if (ActivityCode != "0")
        {

            MYSQL = MYSQL + " and  am.ACTIVITY_ID = " + "'" + ActivityCode + "'";
        }
        if (ProductCode != "0")
        {

            MYSQL = MYSQL + " and  pm.PRODUCT_ID = " + "'" + ProductCode + "'";
        }

        return MYSQL;//OleDbHelper.ExecuteDataset(objCon.ConnectionString, CommandType.Text, MYSQL);
    }

    public String GetParticularClient()
    {
        String MYSQL = "";
        MYSQL = "SELECT pcd.CONT_PRESALE_REF_NO,em1.fullname as BD_MANAGER,am.ACTIVITY_NAME,pm.PRODUCT_NAME,em.FULLNAME as Lead_Ganerated_By,Convert(char(25), pcd.Lead_date,103) as Lead_Generated_date,pcd.IS_CONFIRMED as Contract_Status,convert(char(25),pcd.CONFIRM_DATE,103) as Close_date FROM CLIENT_MASTER as cm inner join PRESALE_CONTRACT_DETAIL as pcd on cm.CLIENT_ID=pcd.CLIENT_ID  inner join PRESALE_CONTRACT_ACTIVITY_PRODUCT as pcap on pcd.CONT_PRESALE_ID=pcap.CONT_PRESALE_ID inner join ACTIVITY_MASTER as am  on am.ACTIVITY_ID=pcap.ACTIVITY_ID inner join PRODUCT_MASTER as pm on pcap.PRODUCT_ID=pm.PRODUCT_ID inner join employee_master as em on pcd.LEAD_BY=em.EMP_ID inner join employee_master as em1 on pcd.bd_manager_id=em1.EMP_ID where 1=1";
        if (BDCode != "0")
        {
            MYSQL = MYSQL + " and  pcd.BD_Manager_ID = " + "'" + BDCode + " ' ";
        }
        if (ClientCode != "0")
        {
            MYSQL = MYSQL + " and  cm.client_id = " + "'" + ClientCode + "'";
        }
        if (ActivityCode != "0")
        {

            MYSQL = MYSQL + " and  am.ACTIVITY_ID = " + "'" + ActivityCode + "'";
        }
        if (ProductCode != "0")
        {

            MYSQL = MYSQL + " and  pm.PRODUCT_ID = " + "'" + ProductCode + "'";
        }

        return MYSQL;//OleDbHelper.ExecuteDataset(objCon.ConnectionString, CommandType.Text, MYSQL);
    }

    public String Get_Bd_NAme()
    {
        String MYSQL = "";
        MYSQL = " select em.fullname from presale_contract_detail as pcd inner join EMPLOYEE_MASTER as em on pcd.bd_manager_id=em.emp_id  where bd_manager_id= " + "'" + BDCode + " ' ";
        return MYSQL;//OleDbHelper.ExecuteDataset(oledbcon.ConnectionString, CommandType.Text, MYSQL);

    }

    public String Get_Client_Name()
    {
        String MYSQL = "";
        MYSQL = "select cm.client_name  from client_master as cm  inner join presale_contract_detail as pcd on cm.client_id=pcd.client_id where pcd.client_id=  " + "'" + ClientCode + " ' ";
        return MYSQL;//OleDbHelper.ExecuteDataset(oledbcon.ConnectionString, CommandType.Text, MYSQL);

    }
      
}
