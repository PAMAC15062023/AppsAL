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
using System.IO;
using System.Drawing;
using System.Drawing.Printing;

public partial class DeDupeSearch : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (Session["isView"].ToString() != "1")
        //    Response.Redirect("NoAccess.aspx");
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        string strDedup = "SELECT   CSD.CASE_ID,CM.CLIENT_NAME, IsNull(CSD.FIRST_NAME,'') + ' ' + IsNull(CSD.MIDDLE_NAME,'') + ' ' + IsNull(CSD.LAST_NAME,'') as FullName, " +
                          " IsNull(CSD.RES_ADD_LINE_1,'') + ' ' + IsNull(CSD.RES_ADD_LINE_2,'') + ' ' + IsNull(CSD.RES_ADD_LINE_3,'') as RecAddress, " +
                          " CSD.RES_CITY, CSD.RES_PIN_CODE, " +
                          " IsNull(CSD.OFF_ADD_LINE_1,'') + ' ' + IsNull(CSD.OFF_ADD_LINE_2,'') + ' ' + IsNull(CSD.OFF_ADD_LINE_3,'') as OffAddress, " +
                          " CSD.OFF_CITY, CSD.OFF_PIN_CODE, DCM.DECLINED_CODE AS DecCode, " +
                          " CVD.REASON,  CSM.STATUS_CODE, DCM.DECLINED_CODE " +
                          " FROM  CPV_CC_CASE_DETAILS CSD INNER JOIN " +
                          "  CLIENT_MASTER CM ON CSD.CLIENT_ID = CM.CLIENT_ID INNER JOIN " +
                          " CPV_CC_VERI_DETAILS CVD ON CSD.CASE_ID = CVD.CASE_ID LEFT OUTER JOIN " +
                          " DECLINED_CODE_MASTER DCM ON CVD.DECLINED_CODE = DCM.ID LEFT OUTER JOIN " +
                          " CASE_STATUS_MASTER CSM ON CVD.CASE_STATUS_ID = CSM.CASE_STATUS_ID " +
                          " where CSM.STATUS_CODE='NEGATIVE'";
        
        string strSearch = "";
        if (txtSearchCust.Text != "")
        {
            switch (ddlSearchCust.SelectedValue)
            {
                case "1":
                    strSearch = " and (CSD.FIRST_NAME Like ('%" + txtSearchCust.Text.Trim().Replace("'", "''") + "%') " +
                                " or CSD.LAST_NAME Like ('%" + txtSearchCust.Text.Trim().Replace("'", "''") + "%') " +
                                " or CSD.MIDDLE_NAME Like ('%" + txtSearchCust.Text.Trim().Replace("'", "''") + "%'))";
                    break;
                case "2":
                    strSearch = " and (CSD.FIRST_NAME Like ('" + txtSearchCust.Text.Trim().Replace("'", "''") + "%') " +
                                " or CSD.LAST_NAME Like ('" + txtSearchCust.Text.Trim().Replace("'", "''") + "%') " +
                                " or CSD.MIDDLE_NAME Like ('" + txtSearchCust.Text.Trim().Replace("'", "''") + "%'))";
                    break;
                case "3":
                    strSearch = " and (CSD.FIRST_NAME = '" + txtSearchCust.Text.Trim().Replace("'", "''") + "' " +
                                " or (CSD.LAST_NAME = '" + txtSearchCust.Text.Trim().Replace("'", "''") + "' " +
                                " or (CSD.MIDDLE_NAME = '" + txtSearchCust.Text.Trim().Replace("'", "''") + "') ";
                    break;
            }
        }

        if (txtSearchCity.Text != "")
        {
            switch (ddlSearchCity.SelectedValue)
            {
                case "1":
                    strSearch = strSearch + " and CSD.RES_CITY Like ('%" + txtSearchCity.Text.Trim().Replace("'", "''") + "%') ";
                    break;
                case "2":
                    strSearch = strSearch + " and CSD.RES_CITY Like ('" + txtSearchCity.Text.Trim().Replace("'", "''") + "%') ";
                    break;
                case "3":
                    strSearch = strSearch + " and CSD.RES_CITY = '" + txtSearchCity.Text.Trim().Replace("'", "''") + "' ";
                    break;
            }
        }

        if (txtSearchPin.Text != "")
        {
            strSearch = strSearch + " and (CSD.RES_PIN_CODE = '" + txtSearchPin.Text.Trim().Replace("'", "''") + "' ";
            strSearch = strSearch + " OR CSD.OFF_PIN_CODE = '" + txtSearchPin.Text.Trim().Replace("'", "''") + "') ";
        }

        if (txtSearchAdd.Text != "")
        {
            switch (ddlSearchAdd.SelectedValue)
            {
                case "1":
                    strSearch = strSearch + " and (CSD.RES_ADD_LINE_1  Like ('%" + txtSearchAdd.Text.Trim().Replace("'", "''") + "%') OR CSD.RES_ADD_LINE_2 Like ('%" + txtSearchAdd.Text.Trim().Replace("'", "''") + "%') OR CSD.RES_ADD_LINE_3 Like ('%" + txtSearchAdd.Text.Trim().Replace("'", "''") + "%')";
                    strSearch = strSearch + " OR CSD.OFF_ADD_LINE_1  Like ('%" + txtSearchAdd.Text.Trim().Replace("'", "''") + "%') OR CSD.OFF_ADD_LINE_2 Like ('%" + txtSearchAdd.Text.Trim().Replace("'", "''") + "%') OR CSD.OFF_ADD_LINE_3 Like ('%" + txtSearchAdd.Text.Trim().Replace("'", "''") + "%'))";
                    break;
                case "2":
                    strSearch = strSearch + " and (CSD.RES_ADD_LINE_1  Like ('%" + txtSearchAdd.Text.Trim().Replace("'", "''") + "') OR CSD.RES_ADD_LINE_2 Like ('%" + txtSearchAdd.Text.Trim().Replace("'", "''") + "') OR CSD.RES_ADD_LINE_3 Like ('%" + txtSearchAdd.Text.Trim().Replace("'", "''") + "')";
                    strSearch = strSearch + " OR CSD.OFF_ADD_LINE_1  Like ('%" + txtSearchAdd.Text.Trim().Replace("'", "''") + "') OR CSD.OFF_ADD_LINE_2 Like ('%" + txtSearchAdd.Text.Trim().Replace("'", "''") + "') OR CSD.OFF_ADD_LINE_3 Like ('%" + txtSearchAdd.Text.Trim().Replace("'", "''") + "'))";
                    break;
            }
        }
        
        strDedup = strDedup + strSearch ;
        sdsDeDupe.SelectCommand = strDedup;
        gvDeDupe.DataBind();
        if (gvDeDupe.Rows.Count == 0)
            lblInitialMsg.Text = "No case found for search criteria";
        else
            lblInitialMsg.Text = "";
    }
    protected void gvDeDupe_Sorting(object sender, GridViewSortEventArgs e)
    {
        string strDedup = "SELECT   CSD.CASE_ID,CM.CLIENT_NAME, IsNull(CSD.FIRST_NAME,'') + ' ' + IsNull(CSD.MIDDLE_NAME,'') + ' ' + IsNull(CSD.LAST_NAME,'') as FullName, " +
                          " IsNull(CSD.RES_ADD_LINE_1,'') + ' ' + IsNull(CSD.RES_ADD_LINE_2,'') + ' ' + IsNull(CSD.RES_ADD_LINE_3,'') as RecAddress, " +
                          " CSD.RES_CITY, CSD.RES_PIN_CODE, " +
                          " IsNull(CSD.OFF_ADD_LINE_1,'') + ' ' + IsNull(CSD.OFF_ADD_LINE_2,'') + ' ' + IsNull(CSD.OFF_ADD_LINE_3,'') as OffAddress, " +
                          " CSD.OFF_CITY, CSD.OFF_PIN_CODE, DCM.DECLINED_CODE AS DecCode, " +
                          " CVD.REASON,  CSM.STATUS_CODE, DCM.DECLINED_CODE " +
                          " FROM  CPV_CC_CASE_DETAILS CSD INNER JOIN " +
                          "  CLIENT_MASTER CM ON CSD.CLIENT_ID = CM.CLIENT_ID INNER JOIN " +
                          " CPV_CC_VERI_DETAILS CVD ON CSD.CASE_ID = CVD.CASE_ID LEFT OUTER JOIN " +
                          " DECLINED_CODE_MASTER DCM ON CVD.DECLINED_CODE = DCM.ID LEFT OUTER JOIN " +
                          " CASE_STATUS_MASTER CSM ON CVD.CASE_STATUS_ID = CSM.CASE_STATUS_ID " +
                          " where CSM.STATUS_CODE='NEGATIVE'";

        string strSearch = "";
        if (txtSearchCust.Text != "")
        {
            switch (ddlSearchCust.SelectedValue)
            {
                case "1":
                    strSearch = " and (CSD.FIRST_NAME Like ('%" + txtSearchCust.Text.Trim().Replace("'", "''") + "%') " +
                                " or CSD.LAST_NAME Like ('%" + txtSearchCust.Text.Trim().Replace("'", "''") + "%') " +
                                " or CSD.MIDDLE_NAME Like ('%" + txtSearchCust.Text.Trim().Replace("'", "''") + "%'))";
                    break;
                case "2":
                    strSearch = " and (CSD.FIRST_NAME Like ('" + txtSearchCust.Text.Trim().Replace("'", "''") + "%') " +
                                " or CSD.LAST_NAME Like ('" + txtSearchCust.Text.Trim().Replace("'", "''") + "%') " +
                                " or CSD.MIDDLE_NAME Like ('" + txtSearchCust.Text.Trim().Replace("'", "''") + "%'))";
                    break;
                case "3":
                    strSearch = " and (CSD.FIRST_NAME = '" + txtSearchCust.Text.Trim().Replace("'", "''") + "' " +
                                " or (CSD.LAST_NAME = '" + txtSearchCust.Text.Trim().Replace("'", "''") + "' " +
                                " or (CSD.MIDDLE_NAME = '" + txtSearchCust.Text.Trim().Replace("'", "''") + "') ";
                    break;
            }
        }

        if (txtSearchCity.Text != "")
        {
            switch (ddlSearchCity.SelectedValue)
            {
                case "1":
                    strSearch = strSearch + " and CSD.RES_CITY Like ('%" + txtSearchCity.Text.Trim().Replace("'", "''") + "%') ";
                    break;
                case "2":
                    strSearch = strSearch + " and CSD.RES_CITY Like ('" + txtSearchCity.Text.Trim().Replace("'", "''") + "%') ";
                    break;
                case "3":
                    strSearch = strSearch + " and CSD.RES_CITY = '" + txtSearchCity.Text.Trim().Replace("'", "''") + "' ";
                    break;
            }
        }

        if (txtSearchPin.Text != "")
        {
            strSearch = strSearch + " and (CSD.RES_PIN_CODE = '" + txtSearchPin.Text.Trim().Replace("'", "''") + "' ";
            strSearch = strSearch + " OR CSD.OFF_PIN_CODE = '" + txtSearchPin.Text.Trim().Replace("'", "''") + "') ";
        }

        if (txtSearchAdd.Text != "")
        {
            switch (ddlSearchAdd.SelectedValue)
            {
                case "1":
                    strSearch = strSearch + " and (CSD.RES_ADD_LINE_1  Like ('%" + txtSearchAdd.Text.Trim().Replace("'", "''") + "%') OR CSD.RES_ADD_LINE_2 Like ('%" + txtSearchAdd.Text.Trim().Replace("'", "''") + "%') OR CSD.RES_ADD_LINE_3 Like ('%" + txtSearchAdd.Text.Trim().Replace("'", "''") + "%')";
                    strSearch = strSearch + " OR CSD.OFF_ADD_LINE_1  Like ('%" + txtSearchAdd.Text.Trim().Replace("'", "''") + "%') OR CSD.OFF_ADD_LINE_2 Like ('%" + txtSearchAdd.Text.Trim().Replace("'", "''") + "%') OR CSD.OFF_ADD_LINE_3 Like ('%" + txtSearchAdd.Text.Trim().Replace("'", "''") + "%'))";
                    break;
                case "2":
                    strSearch = strSearch + " and (CSD.RES_ADD_LINE_1  Like ('%" + txtSearchAdd.Text.Trim().Replace("'", "''") + "') OR CSD.RES_ADD_LINE_2 Like ('%" + txtSearchAdd.Text.Trim().Replace("'", "''") + "') OR CSD.RES_ADD_LINE_3 Like ('%" + txtSearchAdd.Text.Trim().Replace("'", "''") + "')";
                    strSearch = strSearch + " OR CSD.OFF_ADD_LINE_1  Like ('%" + txtSearchAdd.Text.Trim().Replace("'", "''") + "') OR CSD.OFF_ADD_LINE_2 Like ('%" + txtSearchAdd.Text.Trim().Replace("'", "''") + "') OR CSD.OFF_ADD_LINE_3 Like ('%" + txtSearchAdd.Text.Trim().Replace("'", "''") + "'))";
                    break;
            }
        }

        strDedup = strDedup + strSearch;
        sdsDeDupe.SelectCommand = strDedup;
        gvDeDupe.DataBind();
        if (gvDeDupe.Rows.Count == 0)
            lblInitialMsg.Text = "No case found for search criteria";
        else
            lblInitialMsg.Text = "";

    }
    protected void btnExport_Click(object sender, EventArgs e)
    {
        ExportExcel();
    }

    private void ExportExcel()
    {
        bool IsRecord = true;
        Response.ClearContent();
        //DataSet dsDedupRpt = new DataSet();
        GetDedup("ExportExcel");

        gvDeDupe.DataBind();
        if(gvDeDupe.Rows.Count==0)
        {
            lblInitialMsg.Text = "No data found for exporting to excel.";
        }
        else//if (IsRecord == true)
        {
            gvDeDupe.BackColor = System.Drawing.Color.White;
            gvDeDupe.GridLines = GridLines.Both;

            gvDeDupe.AutoGenerateDeleteButton = false;
            gvDeDupe.AutoGenerateEditButton = false;
            gvDeDupe.AllowSorting = false;
            gvDeDupe.AllowPaging = false;
            gvDeDupe.DataBind();
            string attachment = "attachment; filename=DedupSearch.xls";


            Response.AddHeader("content-disposition", attachment);

            Response.ContentType = "application/ms-excel";

            StringWriter sw = new System.IO.StringWriter();

            HtmlTextWriter htw = new HtmlTextWriter(sw);
            gvDeDupe.EnableViewState = false;
            gvDeDupe.RenderControl(htw);

            Response.Write(sw.ToString());

            Response.End();
        }

    }

    public override void VerifyRenderingInServerForm(Control control)
    {

    }

    private void GetDedup(string str)
    {
        if (Session["isView"].ToString() != "1")
            Response.Redirect("NoAccess.aspx");

        //dsAckSheet = new DataSet();
        try
        {
            string strDedup = "SELECT CM.CASE_ID, CM.CUSTOMER_NAME, CM.CITY, CM.PIN,  " +
                              " (IsNull(CM.ADD1,'') + IsNull(CM.ADD2,'') + IsNull(CM.ADD3,'')) as address,  " +
                              " CSD.CASE_STATUS AS Status, " +
                              " CSD.SEND_DT AS SendDate, CSD.SEND_TIME + ' ' + CSD.TIME_TYPE AS SendTime, " +
                              " CSD.FE_REMARK,  CSD.INCLINED_CODE as DeclienCode " +
                              " FROM CASE_MASTER CM INNER JOIN CASE_STATUS_DETAIL CSD  " +
                              " ON CM.CASE_ID = CSD.CASE_ID " +
                              " WHERE (CSD.CASE_STATUS = 'NEGATIVE')";
            string strSearch = "";
            if (txtSearchCust.Text != "")
            {
                switch (ddlSearchCust.SelectedValue)
                {
                    case "1":
                        strSearch = " and CM.CUSTOMER_NAME Like ('%" + txtSearchCust.Text.Trim().Replace("'", "''") + "%') ";
                        break;
                    case "2":
                        strSearch = " and CM.CUSTOMER_NAME Like ('" + txtSearchCust.Text.Trim().Replace("'", "''") + "%') ";
                        break;
                    case "3":
                        strSearch = " and CM.CUSTOMER_NAME = '" + txtSearchCust.Text.Trim().Replace("'", "''") + "' ";
                        break;
                }
            }

            if (txtSearchCity.Text != "")
            {
                switch (ddlSearchCity.SelectedValue)
                {
                    case "1":
                        strSearch = strSearch + " and CM.CITY Like ('%" + txtSearchCity.Text.Trim().Replace("'", "''") + "%') ";
                        break;
                    case "2":
                        strSearch = strSearch + " and CM.CITY Like ('" + txtSearchCity.Text.Trim().Replace("'", "''") + "%') ";
                        break;
                    case "3":
                        strSearch = strSearch + " and CM.CITY = '" + txtSearchCity.Text.Trim().Replace("'", "''") + "' ";
                        break;
                }
            }

            if (txtSearchPin.Text != "")
            {
                strSearch = strSearch + " and CM.PIN = '" + txtSearchPin.Text.Trim().Replace("'", "''") + "' ";
            }

            if (txtSearchAdd.Text != "")
            {
                switch (ddlSearchAdd.SelectedValue)
                {
                    case "1":
                        strSearch = strSearch + " and (IsNull(CM.ADD1,'') + IsNull(CM.ADD2,'') + IsNull(CM.ADD3,'') Like ('%" + txtSearchAdd.Text.Trim().Replace("'", "''") + "%'))";
                        break;
                    case "2":
                        strSearch = strSearch + " and (CM.ADD1 Like ('" + txtSearchAdd.Text.Trim().Replace("'", "''") + "%') or CM.ADD2 Like ('" + txtSearchAdd.Text.Trim().Replace("'", "''") + "%') or  CM.ADD3 Like ('" + txtSearchAdd.Text.Trim().Replace("'", "''") + "%'))";
                        break;
                }
            }

            strDedup = strDedup + strSearch + " order by CM.Alocation_Date";
            sdsDeDupe.SelectCommand = strDedup;



            /*
            string sSql = "";
            sSql = "select Alocation_Date,Case_Type,MSIsDN,Customer_Name " +
                 " FROM Case_master CM , Case_status_detail CSD, Case_type_master CT " +
                 " WHERE CM.Case_id=CSD.Case_Id and CM.Case_type_code=CT.Case_type_code " +
                 " AND CM.Alocation_date Between " +
                 "'" + txtFromDate.Text.Trim().Replace("'", "''") + "' and '" + txtToDate.Text.Trim().Replace("'", "''") + "'";

            if (ddlCases.SelectedItem.Text != "ALL")
                sSql += " AND CM.CASE_TYPE_CODE='" + ddlCases.SelectedValue.Trim() + "'";
            if (ddlCenter.SelectedItem.Text != "ALL")
                sSql += " AND CM.Centre_ID='" + ddlCenter.SelectedValue.Trim() + "'";

            if (str == "ExcelExport" || str == "Report")
                sSql += " ORDER BY Alocation_Date,Case_type,Customer_name ";

            dsAckSheet = SqlHelper.ExecuteDataset(objComm.ConnectionString, CommandType.Text, sSql);
            */
        }
        catch (Exception ex)
        {
            throw new Exception("Error while AcknowledgementSheet Report." + ex.Message);
        }

        //return dsAckSheet;
    }


}
