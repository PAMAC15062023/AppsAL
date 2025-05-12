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
using System.Text;
using System.IO;
using System.Drawing;

public partial class Assets_BarcodeBreakup : System.Web.UI.Page
{
    CCommon objcon = new CCommon();
    protected void Page_Load(object sender, EventArgs e)
    {
        btnclear.Visible = false;
        txtbar.Focus();

    }
    public event EventHandler TextChanged;

    protected void btnsearch_Click(object sender, EventArgs e)
    {
       
    }
    
    protected void btnclear_Click(object sender, EventArgs e)
    {
        
        //txtbar.Text="";
        //txtasset.Text="";
        //txtassetcode.Text="";
        //Txtassetdesccode.Text="";
        //txtassetdesctype.Text="";
        //txtdeptcode.Text="";
        //txtdeptname.Text="";
        //txtloccode.Text="";
        //txtlocname.Text="";
        //txtname.Text="";
        //txtsrno.Text = "";
    }
    
        protected void txtbar_TextChanged(object sender, EventArgs e)
    {


        btnclear.Focus();
        if (txtbar.Text == "")
        {
            lblmsg.Visible = true;
            lblmsg.Text = "Barcode Textbox Cannot Be Blank.... ";
        }
        else
        {
            OleDbDataReader DR;
            string qry = "";
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            qry = "select * from asset_summary where barcode='" + txtbar.Text + "'";
            DR = OleDbHelper.ExecuteReader(objcon.ConnectionString, CommandType.Text, qry);
            if (DR.HasRows)
            {
                while (DR.Read())
                {
                    txtdeptcode.Text = DR["dept_code"].ToString();
                    txtdeptname.Text = DR["Dept"].ToString();
                    txtloccode.Text = DR["dept_location"].ToString();
                    txtlocname.Text = DR["location"].ToString();
                    txtassetcode.Text = DR["Asset_code"].ToString();
                    txtasset.Text = DR["Asset_type"].ToString();
                    txtname.Text = DR["name"].ToString();
                    txtsrno.Text = DR["asset_srno"].ToString();
                    Txtassetdesccode.Text = DR["Asset_description_code"].ToString();
                    txtassetdesctype.Text = DR["Asset_description"].ToString();
                }
            }
            lblasset.Visible = true;
            lblassetcode.Visible = true;
            lblassetdesccode.Visible = true;
            lblassetdesctype.Visible = true;
            lbldeptcode.Visible = true;
            lbldeptname.Visible = true;
            lblloccode.Visible = true;
            lbllocname.Visible = true;
            lblname.Visible = true;
            lblsrno.Visible = true;
            txtassetcode.Visible = true;
            txtasset.Visible = true;
            Txtassetdesccode.Visible = true;
            txtassetdesctype.Visible = true;
            txtdeptcode.Visible = true;
            txtdeptname.Visible = true;
            txtloccode.Visible = true;
            txtlocname.Visible = true;
            txtname.Visible = true;
            txtsrno.Visible = true;
        }
    }
}
