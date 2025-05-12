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
/// Summary description for C_FE_PinCodeMapping
/// </summary>
public class C_FE_PinCodeMapping
{
    CCommon objconn = new CCommon();
	public C_FE_PinCodeMapping()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    private string sCentreId;
    public string CentreId
    {
        get { return sCentreId; }
        set { sCentreId = value; }
    }

    private string sClientId;
    public string ClientId
    {
        get { return sClientId; }
        set { sClientId = value; }
    }

    public DataTable GetFEPinCodeMappingSearch()
    {
        string sSql = "";

        DataTable dt = new DataTable();

        sSql = "SELECT D.PINCODE,FE_VW.FULLNAME,D.FE_ID,CL.CLIENT_ID,CL.CLIENT_NAME FROM FE_PINCODE_MAPPING AS D  " +
               "INNER JOIN FE_VW ON D.FE_ID = FE_VW.EMP_ID INNER JOIN CLIENT_MASTER CL ON D.CLIENT_ID = CL.CLIENT_ID  " +
               "Where FE_VW.CENTRE_ID = '" + CentreId + "'" ;

        if ((ClientId != "") && (ClientId != null))
        {
            if (ClientId != "0")
            {
                sSql += " AND D.CLIENT_ID IN (" + ClientId + ")";
            }
        }
        sSql += " ORDER BY FULLNAME ";

       

        OleDbDataAdapter oledbDa = new OleDbDataAdapter(sSql, objconn.ConnectionString);
        DataSet ds = new DataSet();
        oledbDa.Fill(ds, "FEMapping");
        dt = ds.Tables["FEMapping"];
        return dt;

    }
}
