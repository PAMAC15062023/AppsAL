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

public partial class CPV_Cellular_CC_QCCELLULAR_VERIFICATION_VIEW : System.Web.UI.Page
{
    C_CELLULAR_ENTRY objCellular = new C_CELLULAR_ENTRY();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["isView"].ToString() != "1")
            Response.Redirect("NoAccess.aspx");

        if (Session["CaseID"] != null)
        {
            if (txtCaseId.Text == "")
                txtCaseId.Text = Session["CaseID"].ToString();
        }

        lblMsg.Visible = false;
        txtCaseId.Focus();
        if (Context.Request.QueryString["Msg"] != null && Context.Request.QueryString["Msg"] != "")
        {
            lblMsg.ForeColor = System.Drawing.Color.Yellow;
            lblMsg.BackColor = System.Drawing.Color.Black;
            lblMsg.Font.Bold = true;
            lblMsg.Visible = true;
            lblMsg.Text = "&nbsp;" + Request.QueryString["Msg"].ToString();

            //if (objCellular.IsVerificationComplete(txtCaseId.Text.ToString()) == "true")
            //{
            //    objCellular.VerificationComplete(txtCaseId.Text.ToString());
            //    lblMsg.Text += " Case verification data entry completed.";
            //}
        }
        else
        {
            lblMsg.Text = "";
        }

    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
       
       
        string sCaseId = txtCaseId.Text.Trim();
        Session.Remove("CaseID");
        Session["CaseID"] = txtCaseId.Text.Trim();


        string sClientId = Session["ClientId"].ToString();
        string sCentreId = Session["CentreId"].ToString();

        OleDbDataReader oledbRead;
        oledbRead = objCellular.GetQCCaseID(sCaseId, sClientId, sCentreId);

        //added by kamal matekar..
        if (oledbRead.Read() == true)
        {
            OleDbDataReader oledbReadFEId;
            oledbReadFEId = objCellular.GetQCVerifierID(sCaseId);

            if (oledbReadFEId.Read() == true)
            {
                hdnFEID.Value = oledbReadFEId["FE_ID"].ToString();
            }

            else
            {
                lblMsg.Visible = true;
                lblMsg.Text = "First Do the FE Assignment!! ";

            }

            if (hdnFEID.Value.Trim() != "")
            {
                //if (oledbReadFEId.Read() == true)
                //{
                //    ////commented by kamal matekar
                ////Response.Redirect("CEL_Cellular_Verification_Entry.aspx?CaseID=" + sCaseId);
                Response.Redirect("CEL_QCCellular_Verification_FEData_Entry.aspx?CaseID=" + sCaseId);
                // }
            }
            oledbReadFEId.Close();
        }
        else
        {
            lblMsg.Visible = true;
            lblMsg.Text = "Records Does Not Exist !! ";

        }

        oledbRead.Close();
    }
}
