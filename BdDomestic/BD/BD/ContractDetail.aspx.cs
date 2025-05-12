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

public partial class BD_ContractDetail : System.Web.UI.Page
{
    CBDContract oBD = new CBDContract();
    DataTable dtRateChart;
    DataRow dr;
    CCommon oCmn = new CCommon();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {

            string UserId = Session["UserId"].ToString();
            if (UserId == "101103548")
            {
                btnAdd.Visible = false;
                btnCancel.Visible = false;
                //btnCancelRC = false;
                //btnSubmit = false;

            }
            if (!IsPostBack)
            {
                if (Request.QueryString.Count > 0)
                {
                    if (Request.QueryString["NID"].ToString() != "" || Request.QueryString["NID"].ToString() != null)
                    {
                        String strPresaleContID = Request.QueryString["NID"].ToString();
                        hdnPresaleContID.Value = strPresaleContID;
                        hdnMode.Value = "A";
                        DataSet ds = oBD.GetPresaleConfirmContractDetail(strPresaleContID);

                        if (ds != null)
                        {
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                                {
                                    lblContRefNo.Text = ds.Tables[0].Rows[i]["CONT_PRESALE_REF_NO"].ToString();
                                    lblClientName.Text = ds.Tables[0].Rows[i]["CLIENT_NAME"].ToString();
                                    lblOrderNo.Text = ds.Tables[0].Rows[i]["ORDER_NO"].ToString();
                                    if (ds.Tables[0].Rows[i]["ORDER_DATE"].ToString() != "")
                                        lblOrderDate.Text = Convert.ToDateTime(ds.Tables[0].Rows[i]["ORDER_DATE"]).ToString("dd/MM/yyyy");
                                }
                            }
                        }
                        DataSet dsContractDetails = oBD.GetConfirmContractDetail(strPresaleContID);
                        if (dsContractDetails != null)
                        {
                            if (dsContractDetails.Tables[0].Rows.Count > 0)
                            {
                                String strContID = dsContractDetails.Tables[0].Rows[0]["CONTRACT_ID"].ToString();
                                hdnContID.Value = strContID;
                                hdnMode.Value = "E";
                                txtContractNo.Text = dsContractDetails.Tables[0].Rows[0]["CONTRACT_NO"].ToString();
                                if (dsContractDetails.Tables[0].Rows[0]["CONTRACT_DATE"].ToString() != "")
                                    txtContractDate.Text = Convert.ToDateTime(dsContractDetails.Tables[0].Rows[0]["CONTRACT_DATE"]).ToString("dd/MM/yyyy");
                                if (dsContractDetails.Tables[0].Rows[0]["CONTRACT_EXPIRY_DATE"].ToString() != "")
                                    txtExpiryDate.Text = Convert.ToDateTime(dsContractDetails.Tables[0].Rows[0]["CONTRACT_EXPIRY_DATE"]).ToString("dd/MM/yyyy");
                                if (dsContractDetails.Tables[0].Rows[0]["PROJECT_IMPLEMENT_DATE"].ToString() != "")
                                    txtImplementDate.Text = Convert.ToDateTime(dsContractDetails.Tables[0].Rows[0]["PROJECT_IMPLEMENT_DATE"]).ToString("dd/MM/yyyy");
                                if (dsContractDetails.Tables[0].Rows[0]["PROJECT_START_DATE"].ToString() != "")
                                    txtStartDate.Text = Convert.ToDateTime(dsContractDetails.Tables[0].Rows[0]["PROJECT_START_DATE"]).ToString("dd/MM/yyyy");
                                if(dsContractDetails.Tables[0].Rows[0]["PROJECT_IMPLEMENTED_BY"].ToString()!="")
                                ddlImplementedBy.SelectedValue = dsContractDetails.Tables[0].Rows[0]["PROJECT_IMPLEMENTED_BY"].ToString();
                                txtExpectedTo.Text = dsContractDetails.Tables[0].Rows[0]["EXPECTED_TO"].ToString();
                                txtStatusAfterMonths.Text = dsContractDetails.Tables[0].Rows[0]["STATUS_AFTER_MONTHS"].ToString();
                                txtMinVolMonth.Text = dsContractDetails.Tables[0].Rows[0]["MIN_VOL_MONTH"].ToString();
                                txtMinGrtMonth.Text = dsContractDetails.Tables[0].Rows[0]["MIN_GUARANTEE_MONTH"].ToString();
                                ddlTaxing.SelectedValue = dsContractDetails.Tables[0].Rows[0]["IN_EX_TAX"].ToString();
                                DataSet dsTables;
                                // RATE CHART
                                oBD.GetContractTables(strContID);
                                dsTables = oBD.dsRateChart;
                                                               
                                if (dsTables != null)
                                {
                                    if (dsTables.Tables[0].Rows.Count > 0)
                                    {
                                        if (dtRateChart == null)
                                        {
                                            CreateRateChartTable();
                                        }

                                        foreach (DataRow sdr in dsTables.Tables[0].Rows)
                                        {
                                            dr = dtRateChart.NewRow();
                                            dr["RATE_CHART_ID"] = sdr["RATE_CHART_ID"].ToString();
                                            dr["CENTRE_ID"] = sdr["CENTRE_ID"].ToString();
                                            dr["ACTIVITY_ID"] = sdr["ACTIVITY_ID"].ToString();
                                            dr["PRODUCT_ID"] = sdr["PRODUCT_ID"].ToString();
                                            dr["VERIFICATION_TYPE"] = sdr["VERIFICATION_TYPE"].ToString();
                                            dr["RATE"] = sdr["RATE"].ToString();
                                            dr["CENTRE_NAME"] = sdr["CENTRE_NAME"].ToString();
                                            dr["ACTIVITY_NAME"] = sdr["ACTIVITY_NAME"].ToString();
                                            dr["PRODUCT_NAME"] = sdr["PRODUCT_NAME"].ToString();

                                            dtRateChart.Rows.Add(dr);
                                        }
                                    }
                                    gvRateChart.DataSource = dtRateChart;
                                    gvRateChart.DataBind();
                                }
                                    //VOLUME SLAB
                                dsTables = oBD.dsVolumeSlab;
                                if (dsTables != null)
                                {
                                    if (dsTables.Tables[0].Rows.Count > 0)
                                    {
                                        for (int i = 0; i < dsTables.Tables[0].Rows.Count; i++)
                                        {
                                            CountVolumeSlabRows += 1;
                                            CreateVolumeSlabRow(dsTables.Tables[0].Rows[i]["VOLUME_SLAB_ID"].ToString(), dsTables.Tables[0].Rows[i]["FROM_NO_OF_CASES"].ToString(), dsTables.Tables[0].Rows[i]["TO_NO_OF_CASES"].ToString(), dsTables.Tables[0].Rows[i]["VERIFICATION_TYPE"].ToString(), dsTables.Tables[0].Rows[i]["RATE_CASES"].ToString());
                                        }
                                    }
                                }
                                    //PENALTY
                                dsTables = oBD.dsPenalty;
                                if (dsTables != null)
                                {
                                    if (dsTables.Tables[0].Rows.Count > 0)
                                    {
                                        for (int i = 0; i < dsTables.Tables[0].Rows.Count; i++)
                                        {
                                            CountPenaltyRows += 1;
                                            CreatePenaltyRow(dsTables.Tables[0].Rows[i]["PENALTY_ID"].ToString(), dsTables.Tables[0].Rows[i]["FROM_BEYOND_TAT"].ToString(), dsTables.Tables[0].Rows[i]["TO_BEYOND_TAT"].ToString(), dsTables.Tables[0].Rows[i]["PENALTY_ON"].ToString(), dsTables.Tables[0].Rows[i]["VALUE_TYPE"].ToString(), dsTables.Tables[0].Rows[i]["PENALTY_VALUE"].ToString());
                                        }
                                    }
                                }
                                    //BONUS
                                dsTables = oBD.dsBonus;
                                if (dsTables != null)
                                {
                                    if (dsTables.Tables[0].Rows.Count > 0)
                                    {
                                        for (int i = 0; i < dsTables.Tables[0].Rows.Count; i++)
                                        {
                                            CountBonusRows += 1;
                                            CreateBonusRow(dsTables.Tables[0].Rows[i]["BONUS_ID"].ToString(), dsTables.Tables[0].Rows[i]["FROM_WITHIN_TAT"].ToString(), dsTables.Tables[0].Rows[i]["TO_WITHIN_TAT"].ToString(), dsTables.Tables[0].Rows[i]["BONUS_ON"].ToString(), dsTables.Tables[0].Rows[i]["VALUE_TYPE"].ToString(), dsTables.Tables[0].Rows[i]["BONUS_VALUE"].ToString());
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                ViewState["dt1"] = dtRateChart;
                if (hdnMode.Value == "A")
                {
                    //imgGet.Visible = true;
                }
            }
            else
            {
                //if (CountRateChartRows != 0)
                //{
                //    for (int i = 0; i < CountRateChartRows; i++)
                //    {
                //        CreateRateChartRow();
                //    }
                //}
                if (CountVolumeSlabRows != 0)
                {
                    for (int i = 0; i < CountVolumeSlabRows; i++)
                    {
                        CreateVolumeSlabRow();
                    }
                }
                if (CountPenaltyRows != 0)
                {
                    for (int i = 0; i < CountPenaltyRows; i++)
                    {
                        CreatePenaltyRow();
                    }
                }
                if (CountBonusRows != 0)
                {
                    for (int i = 0; i < CountBonusRows; i++)
                    {
                        CreateBonusRow();
                    }
                }
            }            
        }
        catch (Exception exp)
        {
            lblMgs.Text = "Error : " + exp.Message;
        }
    }
    //RATE CHART
    protected void lnkInsertRateChart_Click(object sender, EventArgs e)
    {
        //CountRateChartRows += 1;
        //CreateRateChartRow();
        int index = gvRateChart.Rows.Count;
        gvRateChart.EditIndex = index;
        if (dtRateChart == null)
        {
            CreateRateChartTable();
        }
        if (ViewState["dt1"] != null)
        {
            dtRateChart = (DataTable)ViewState["dt1"];
        }
        dr = dtRateChart.NewRow();
        dtRateChart.Rows.Add(dr);
        gvRateChart.DataSource = dtRateChart;
        gvRateChart.DataBind();
    }
   
    //VOLUME SLAB    
    protected void lnkInsertVolSlab_Click(object sender, EventArgs e)
    {
        CountVolumeSlabRows += 1;
        CreateVolumeSlabRow();
    }
    protected void lnkRemoveVolSlab_Click(object sender, EventArgs e)
    {
        if (CountVolumeSlabRows > 0)
        {
            CountVolumeSlabRows -= 1;
            
            String strVolumeSlabID = "";
            strVolumeSlabID = ((HiddenField)(tblVolumeSlab.Rows[tblVolumeSlab.Rows.Count - 1].FindControl("hdnVolumeSlab" + (tblVolumeSlab.Rows.Count - 1) + "5"))).Value.ToString();
            if (strVolumeSlabID != "")
            {
                oBD.DeleteVolumeSlab(strVolumeSlabID);
            }

            tblVolumeSlab.Rows.RemoveAt(tblVolumeSlab.Rows.Count - 1);
        }
    }
    public int CountVolumeSlabRows
    {
        get
        {
            if (ViewState["cntVolumeSlabRows"] == null)
                return 0;
            else
                return (int)ViewState["cntVolumeSlabRows"];
        }
        set
        {
            ViewState["cntVolumeSlabRows"] = value;
        }
    }
    private void CreateVolumeSlabRow(params string[] args)
    {
        //THIS METHOD RECEIVES 3 ARGUMENST IN FOLLOWING ORDER

        try
        {
            TableRow r;
            int intRows = tblVolumeSlab.Rows.Count;
            int j = intRows;
            r = new TableRow();
            for (int i = 0; i < 6; i++)
            {
                TableCell c = new TableCell();
                c.Controls.Add(new LiteralControl());

                switch (i)
                {
                    case 0:
                        Label lblVolumeSrNo = new Label();
                        lblVolumeSrNo.ID = "lblVolumeSrNo" + j.ToString() + i.ToString();
                        lblVolumeSrNo.Text = (intRows + 1).ToString();
                        //if (args.GetLength(0) > 0)
                        //{
                        //    if (args[0] != "")
                        //    {
                        //        lblVolumeSrNo.Text = args[0];
                        //    }
                        //}
                        c.Controls.Add(lblVolumeSrNo);
                        c.Width = Unit.Pixel(50);
                        break;
                    case 1:
                        TextBox txtFromNoCases = new TextBox();
                        txtFromNoCases.SkinID = "txtSkin";
                        txtFromNoCases.ID = "txtFromNoCases" + j.ToString() + i.ToString();
                        txtFromNoCases.Text = "";
                        if (args.GetLength(0) > 0)
                        {
                            if (args[0] != "")
                            {
                                txtFromNoCases.Text = args[1];
                            }
                        }
                        c.Controls.Add(txtFromNoCases);
                        //REQUIRED FIELD VALIDATOR
                        RequiredFieldValidator rfvFromNoCases = new RequiredFieldValidator();
                        rfvFromNoCases.ID = "rfvFromNoCases" + j.ToString() + i.ToString();
                        rfvFromNoCases.ControlToValidate = txtFromNoCases.ID;
                        rfvFromNoCases.Display = ValidatorDisplay.None;
                        rfvFromNoCases.ValidationGroup = "grpRateChart";
                        rfvFromNoCases.ErrorMessage = "Please enter From No Cases";
                        c.Controls.Add(rfvFromNoCases);
                        //REGULAR EXPRESSION VALIDATOR
                        RegularExpressionValidator revFromNoCases = new RegularExpressionValidator();
                        revFromNoCases.ID = "revFromNoCases" + j.ToString() + i.ToString();
                        revFromNoCases.ControlToValidate = txtFromNoCases.ID;
                        revFromNoCases.Display = ValidatorDisplay.None;
                        revFromNoCases.ValidationExpression = "^[0-9]*$";
                        revFromNoCases.ValidationGroup = "grpRateChart";
                        revFromNoCases.ErrorMessage = "Please enter only numbers for From No Cases";
                        c.Controls.Add(revFromNoCases);
                        c.Width = Unit.Pixel(150);
                        break;
                    case 2:
                        TextBox txtToNoCases = new TextBox();
                        txtToNoCases.SkinID = "txtSkin";
                        txtToNoCases.ID = "txtToNoCases" + j.ToString() + i.ToString();
                        txtToNoCases.Text = "";
                        if (args.GetLength(0) > 0)
                        {
                            if (args[0] != "")
                            {
                                txtToNoCases.Text = args[2];
                            }
                        }
                        c.Controls.Add(txtToNoCases);
                        //REQUIRED FIELD VALIDATOR
                        RequiredFieldValidator rfvToNoCases = new RequiredFieldValidator();
                        rfvToNoCases.ID = "rfvToNoCases" + j.ToString() + i.ToString();
                        rfvToNoCases.ControlToValidate = txtToNoCases.ID;
                        rfvToNoCases.Display = ValidatorDisplay.None;
                        rfvToNoCases.ValidationGroup = "grpRateChart";
                        rfvToNoCases.ErrorMessage = "Please enter To No Cases";
                        c.Controls.Add(rfvToNoCases);
                        //REGULAR EXPRESSION VALIDATOR
                        RegularExpressionValidator revToNoCases = new RegularExpressionValidator();
                        revToNoCases.ID = "revToNoCases" + j.ToString() + i.ToString();
                        revToNoCases.ControlToValidate = txtToNoCases.ID;
                        revToNoCases.Display = ValidatorDisplay.None;
                        revToNoCases.ValidationExpression = "^[0-9]*$";
                        revToNoCases.ValidationGroup = "grpRateChart";
                        revToNoCases.ErrorMessage = "Please enter only numbers for To No Cases";
                        c.Controls.Add(revToNoCases);
                        c.Width = Unit.Pixel(150);
                        break;
                    case 3:
                        TextBox txtVType = new TextBox();
                        txtVType.SkinID = "txtSkin";
                        txtVType.ID = "txtType" + j.ToString() + i.ToString();
                        txtVType.MaxLength = 15;
                        txtVType.Text = "";
                        if (args.GetLength(0) > 0)
                        {
                            if (args[0] != "")
                            {
                                txtVType.Text = args[3];
                            }
                        }
                        c.Controls.Add(txtVType);

                        //REQUIRED FIELD VALIDATOR
                        RequiredFieldValidator rfvVType = new RequiredFieldValidator();
                        rfvVType.ID = "rfvVType" + j.ToString() + i.ToString();
                        rfvVType.ControlToValidate = txtVType.ID;
                        rfvVType.Display = ValidatorDisplay.None;
                        rfvVType.ValidationGroup = "grpRateChart";
                        rfvVType.ErrorMessage = "Please enter Type";
                        c.Controls.Add(rfvVType);
                        c.Width = Unit.Pixel(150);
                        break;
                    case 4:
                        TextBox txtVRate = new TextBox();
                        txtVRate.SkinID = "txtSkin";
                        txtVRate.ID = "txtVRate" + j.ToString() + i.ToString();
                        txtVRate.Text = "";
                        if (args.GetLength(0) > 0)
                        {
                            if (args[0] != "")
                            {
                                txtVRate.Text = args[4];
                            }
                        }
                        c.Controls.Add(txtVRate);
                        //REQUIRED FIELD VALIDATOR
                        RequiredFieldValidator rfvVRate = new RequiredFieldValidator();
                        rfvVRate.ID = "rfvVRate" + j.ToString() + i.ToString();
                        rfvVRate.ControlToValidate = txtVRate.ID;
                        rfvVRate.Display = ValidatorDisplay.None;
                        rfvVRate.ValidationGroup = "grpRateChart";
                        rfvVRate.ErrorMessage = "Please enter Rate";
                        c.Controls.Add(rfvVRate);
                        //REGULAR EXPRESSION VALIDATOR
                        RegularExpressionValidator revVRate = new RegularExpressionValidator();
                        revVRate.ID = "revVRate" + j.ToString() + i.ToString();
                        revVRate.ControlToValidate = txtVRate.ID;
                        revVRate.Display = ValidatorDisplay.None;
                        revVRate.ValidationExpression = "^[0-9]*$";
                        revVRate.ValidationGroup = "grpRateChart";
                        revVRate.ErrorMessage = "Please enter only numbers for Rate";
                        c.Controls.Add(revVRate);
                        c.Width = Unit.Pixel(150);
                        break;
                    case 5:
                        HiddenField hdnVolumeSlab = new HiddenField();
                        hdnVolumeSlab.ID = "hdnVolumeSlab" + j.ToString() + i.ToString();
                        hdnVolumeSlab.Value = "";
                        if (args.GetLength(0) > 0)
                        {
                            if (args[0] != "")
                            {
                                hdnVolumeSlab.Value = args[0];
                            }
                        }
                        c.Controls.Add(hdnVolumeSlab);
                        //CheckBox chkVolumeSlab = new CheckBox();
                        //chkVolumeSlab.ID = "chkVolumeSlab" + j.ToString() + i.ToString();
                        //c.Controls.Add(chkVolumeSlab);
                        break;
                }
                c.BorderStyle = BorderStyle.None;
                r.Cells.Add(c);
            }
            tblVolumeSlab.Rows.Add(r);
        }
        catch (Exception exp)
        {
            lblMgs.Text = "Error : " + exp.Message;
        }
    }
    //PENALTY
    protected void lnkInsertPenalty_Click(object sender, EventArgs e)
    {
        CountPenaltyRows += 1;
        CreatePenaltyRow();
    }
    protected void lnkRemovePenalty_Click(object sender, EventArgs e)
    {
        if (CountPenaltyRows > 0)
        {
            CountPenaltyRows -= 1;
            String strPenaltyID = "";
            strPenaltyID = ((HiddenField)(tblPenalty.Rows[tblPenalty.Rows.Count - 1].FindControl("hdnPenalty" + (tblPenalty.Rows.Count - 1) + "6"))).Value.ToString();
            if (strPenaltyID != "")
            {
                oBD.DeletePenalty(strPenaltyID);
            }

            tblPenalty.Rows.RemoveAt(tblPenalty.Rows.Count-1);              
        }
    }
    public int CountPenaltyRows
    {
        get
        {
            if (ViewState["cntPenaltyRows"] == null)
                return 0;
            else
                return (int)ViewState["cntPenaltyRows"];
        }
        set
        {
            ViewState["cntPenaltyRows"] = value;
        }
    }
    private void CreatePenaltyRow(params string[] args)
    {
        //THIS METHOD RECEIVES 3 ARGUMENST IN FOLLOWING ORDER

        try
        {
            TableRow r;
            int intRows = tblPenalty.Rows.Count;
            int j = intRows;
            r = new TableRow();
            for (int i = 0; i < 7; i++)
            {
                TableCell c = new TableCell();
                c.Controls.Add(new LiteralControl());

                switch (i)
                {
                    case 0:
                        Label lblPenaltySrNo = new Label();
                        lblPenaltySrNo.ID = "lblPenaltySrNo" + j.ToString() + i.ToString();
                        lblPenaltySrNo.Text = (intRows + 1).ToString();
                        //if (args.GetLength(0) > 0)
                        //{
                        //    if (args[0] != "")
                        //    {
                        //        lblPenaltySrNo.Text = args[0];
                        //    }
                        //}

                        c.Controls.Add(lblPenaltySrNo);
                        c.Width = Unit.Pixel(50);
                        break;
                    case 1:
                        TextBox txtFromBeyondTAT = new TextBox();
                        txtFromBeyondTAT.SkinID = "txtSkin";
                        txtFromBeyondTAT.ID = "txtFromBeyondTAT" + j.ToString() + i.ToString();
                        txtFromBeyondTAT.Text = "";
                        if (args.GetLength(0) > 0)
                        {
                            if (args[0] != "")
                            {
                                txtFromBeyondTAT.Text = args[1];
                            }
                        }
                        c.Controls.Add(txtFromBeyondTAT);
                        //REQUIRED FIELD VALIDATOR
                        RequiredFieldValidator rfvFromBeyondTAT = new RequiredFieldValidator();
                        rfvFromBeyondTAT.ID = "rfvtxtVRate" + j.ToString() + i.ToString();
                        rfvFromBeyondTAT.ControlToValidate = txtFromBeyondTAT.ID;
                        rfvFromBeyondTAT.Display = ValidatorDisplay.None;
                        rfvFromBeyondTAT.ValidationGroup = "grpRateChart";
                        rfvFromBeyondTAT.ErrorMessage = "Please enter From Beyond TAT";
                        c.Controls.Add(rfvFromBeyondTAT);
                        //REGULAR EXPRESSION VALIDATOR
                        RegularExpressionValidator revFromBeyondTAT = new RegularExpressionValidator();
                        revFromBeyondTAT.ID = "revFromBeyondTAT" + j.ToString() + i.ToString();
                        revFromBeyondTAT.ControlToValidate = txtFromBeyondTAT.ID;
                        revFromBeyondTAT.Display = ValidatorDisplay.None;
                        revFromBeyondTAT.ValidationExpression = "^[0-9]*$";
                        revFromBeyondTAT.ValidationGroup = "grpRateChart";
                        revFromBeyondTAT.ErrorMessage = "Please enter only numbers for From Beyond TAT";
                        c.Controls.Add(revFromBeyondTAT);
                        c.Width = Unit.Pixel(150);
                        break;
                    case 2:
                        TextBox txtToBeyondTAT = new TextBox();
                        txtToBeyondTAT.SkinID = "txtSkin";
                        txtToBeyondTAT.ID = "txtToBeyondTAT" + j.ToString() + i.ToString();
                        txtToBeyondTAT.Text = "";
                        if (args.GetLength(0) > 0)
                        {
                            if (args[0] != "")
                            {
                                txtToBeyondTAT.Text = args[2];
                            }
                        }
                        c.Controls.Add(txtToBeyondTAT);
                        //REQUIRED FIELD VALIDATOR
                        RequiredFieldValidator rfvToBeyondTAT = new RequiredFieldValidator();
                        rfvToBeyondTAT.ID = "rfvToBeyondTAT" + j.ToString() + i.ToString();
                        rfvToBeyondTAT.ControlToValidate = txtToBeyondTAT.ID;
                        rfvToBeyondTAT.Display = ValidatorDisplay.None;
                        rfvToBeyondTAT.ValidationGroup = "grpRateChart";
                        rfvToBeyondTAT.ErrorMessage = "Please enter To Beyond TAT";
                        c.Controls.Add(rfvToBeyondTAT);
                        //REGULAR EXPRESSION VALIDATOR
                        RegularExpressionValidator revToBeyondTAT = new RegularExpressionValidator();
                        revToBeyondTAT.ID = "revToBeyondTAT" + j.ToString() + i.ToString();
                        revToBeyondTAT.ControlToValidate = txtToBeyondTAT.ID;
                        revToBeyondTAT.Display = ValidatorDisplay.None;
                        revToBeyondTAT.ValidationExpression = "^[0-9]*$";
                        revToBeyondTAT.ValidationGroup = "grpRateChart";
                        revToBeyondTAT.ErrorMessage = "Please enter only numbers for To Beyond TAT";
                        c.Controls.Add(revToBeyondTAT);
                        c.Width = Unit.Pixel(150);
                        break;
                    case 3:
                        DropDownList ddlPenaltyOn = new DropDownList();
                        ddlPenaltyOn.SkinID = "ddlSkin";
                        ddlPenaltyOn.ID = "ddlPenaltyOn" + j.ToString() + i.ToString();
                        ddlPenaltyOn.Items.Clear();
                        ListItem liPenaltyOn = new ListItem("--Select--", "");
                        ddlPenaltyOn.Items.Add(liPenaltyOn);
                        liPenaltyOn = new ListItem("Bill Amount", "B");
                        ddlPenaltyOn.Items.Add(liPenaltyOn);
                        liPenaltyOn = new ListItem("Per Case", "P");
                        ddlPenaltyOn.Items.Add(liPenaltyOn);

                        if (args.GetLength(0) > 0)
                        {
                            if (args[0] != "")
                            {
                                ddlPenaltyOn.SelectedValue = args[3];
                            }
                        }
                        c.Controls.Add(ddlPenaltyOn);
                        //REQUIRED FIELD VALIDATOR
                        RequiredFieldValidator rfvPenaltyOn = new RequiredFieldValidator();
                        rfvPenaltyOn.ID = "rfvPenaltyOn" + j.ToString() + i.ToString();
                        rfvPenaltyOn.ControlToValidate = ddlPenaltyOn.ID;
                        rfvPenaltyOn.Display = ValidatorDisplay.None;
                        rfvPenaltyOn.ValidationGroup = "grpRateChart";
                        rfvPenaltyOn.ErrorMessage = "Please select Penalty On";
                        c.Controls.Add(rfvPenaltyOn);
                        c.Width = Unit.Pixel(150);
                        break;
                    case 4:
                        DropDownList ddlValueTypePenalty = new DropDownList();
                        ddlValueTypePenalty.SkinID = "ddlSkin";
                        ddlValueTypePenalty.ID = "ddlValueTypePenalty" + j.ToString() + i.ToString();
                        ddlValueTypePenalty.Items.Clear();
                        ListItem liValueType = new ListItem("--Select--", "");
                        ddlValueTypePenalty.Items.Add(liValueType);
                        liValueType = new ListItem("Percent", "P");
                        ddlValueTypePenalty.Items.Add(liValueType);
                        liValueType = new ListItem("Constant", "C");
                        ddlValueTypePenalty.Items.Add(liValueType);

                        if (args.GetLength(0) > 0)
                        {
                            if (args[0] != "")
                            {
                                ddlValueTypePenalty.SelectedValue = args[4];
                            }
                        }
                        c.Controls.Add(ddlValueTypePenalty);

                        //REQUIRED FIELD VALIDATOR
                        RequiredFieldValidator rfvValueTypePenalty = new RequiredFieldValidator();
                        rfvValueTypePenalty.ID = "rfvValueTypePenalty" + j.ToString() + i.ToString();
                        rfvValueTypePenalty.ControlToValidate = ddlValueTypePenalty.ID;
                        rfvValueTypePenalty.Display = ValidatorDisplay.None;
                        rfvValueTypePenalty.ValidationGroup = "grpRateChart";
                        rfvValueTypePenalty.ErrorMessage = "Please select Value Type";
                        c.Controls.Add(rfvValueTypePenalty);
                        c.Width = Unit.Pixel(150);
                        break;
                    case 5:
                        TextBox txtValuePenalty = new TextBox();
                        txtValuePenalty.SkinID = "txtSkin";
                        txtValuePenalty.ID = "txtValuePenalty" + j.ToString() + i.ToString();
                        txtValuePenalty.Text = "";
                        if (args.GetLength(0) > 0)
                        {
                            if (args[0] != "")
                            {
                                txtValuePenalty.Text = args[5];
                            }
                        }
                        c.Controls.Add(txtValuePenalty);
                        //REQUIRED FIELD VALIDATOR
                        RequiredFieldValidator rfvValuePenalty = new RequiredFieldValidator();
                        rfvValuePenalty.ID = "rfvValueTypePenalty" + j.ToString() + i.ToString();
                        rfvValuePenalty.ControlToValidate = txtValuePenalty.ID;
                        rfvValuePenalty.Display = ValidatorDisplay.None;
                        rfvValuePenalty.ValidationGroup = "grpRateChart";
                        rfvValuePenalty.ErrorMessage = "Please enter Value";
                        c.Controls.Add(rfvValuePenalty);
                        //REGULAR EXPRESSION VALIDATOR
                        RegularExpressionValidator revValuePenalty = new RegularExpressionValidator();
                        revValuePenalty.ID = "revValuePenalty" + j.ToString() + i.ToString();
                        revValuePenalty.ControlToValidate = txtValuePenalty.ID;
                        revValuePenalty.Display = ValidatorDisplay.None;
                        revValuePenalty.ValidationExpression = "^[0-9]*$";
                        revValuePenalty.ValidationGroup = "grpRateChart";
                        revValuePenalty.ErrorMessage = "Please enter only numbers for Value";
                        c.Controls.Add(revValuePenalty);
                        c.Width = Unit.Pixel(150);
                        break;
                    case 6:
                        HiddenField hdnPenalty = new HiddenField();
                        hdnPenalty.ID = "hdnPenalty" + j.ToString() + i.ToString();
                        hdnPenalty.Value = "";
                        if (args.GetLength(0) > 0)
                        {
                            if (args[0] != "")
                            {
                                hdnPenalty.Value = args[0];
                            }
                        }
                        c.Controls.Add(hdnPenalty);
                        //CheckBox chkPenalty= new CheckBox();
                        //chkPenalty.ID = "chkPenalty" + j.ToString() + i.ToString();
                        //c.Controls.Add(chkPenalty);
                        break;
                }
                c.BorderStyle = BorderStyle.None;
                r.Cells.Add(c);
            }
            tblPenalty.Rows.Add(r);
        }
        catch (Exception exp)
        {
            lblMgs.Text = "Error : " + exp.Message;
        }
    }
    //BONUS
    protected void lnkInsertBonus_Click(object sender, EventArgs e)
    {
        CountBonusRows += 1;
        CreateBonusRow();
    }
    protected void lnkRemoveBonus_Click(object sender, EventArgs e)
    {
        if (CountBonusRows > 0)
        {
            CountBonusRows -= 1;
            String strBonusID = "";
            strBonusID = ((HiddenField)(tblBonus.Rows[tblBonus.Rows.Count - 1].FindControl("hdnBonus" + (tblBonus.Rows.Count - 1) + "6"))).Value.ToString();
            if (strBonusID != "")
            {
                oBD.DeleteBonus(strBonusID);
            }

            tblBonus.Rows.RemoveAt(tblBonus.Rows.Count - 1);
        }
    }
    public int CountBonusRows
    {
        get
        {
            if (ViewState["cntBonusRows"] == null)
                return 0;
            else
                return (int)ViewState["cntBonusRows"];
        }
        set
        {
            ViewState["cntBonusRows"] = value;
        }
    }
    private void CreateBonusRow(params string[] args)
    {
        //THIS METHOD RECEIVES 3 ARGUMENST IN FOLLOWING ORDER

        try
        {
            TableRow r;
            int intRows = tblBonus.Rows.Count;
            int j = intRows;
            r = new TableRow();
            for (int i = 0; i < 7; i++)
            {
                TableCell c = new TableCell();
                c.Controls.Add(new LiteralControl());

                switch (i)
                {
                    case 0:
                        Label lblBonusSrNo = new Label();
                        lblBonusSrNo.ID = "lblBonusSrNo" + j.ToString() + i.ToString();
                        lblBonusSrNo.Text = (intRows + 1).ToString();
                        //if (args.GetLength(0) > 0)
                        //{
                        //    if (args[0] != "")
                        //    {
                        //        lblBonusSrNo.Text = args[0];
                        //    }
                        //}
                        c.Controls.Add(lblBonusSrNo);
                        c.Width = Unit.Pixel(50);
                        break;
                    case 1:
                        TextBox txtFromWithinTAT = new TextBox();
                        txtFromWithinTAT.SkinID = "txtSkin";
                        txtFromWithinTAT.ID = "txtFromWithinTAT" + j.ToString() + i.ToString();
                        txtFromWithinTAT.Text = "";
                        if (args.GetLength(0) > 0)
                        {
                            if (args[0] != "")
                            {
                                txtFromWithinTAT.Text = args[1];
                            }
                        }
                        c.Controls.Add(txtFromWithinTAT);
                        //REQUIRED FIELD VALIDATOR
                        RequiredFieldValidator rfvFromWithinTAT = new RequiredFieldValidator();
                        rfvFromWithinTAT.ID = "rfvPenaltyOn" + j.ToString() + i.ToString();
                        rfvFromWithinTAT.ControlToValidate = txtFromWithinTAT.ID;
                        rfvFromWithinTAT.Display = ValidatorDisplay.None;
                        rfvFromWithinTAT.ValidationGroup = "grpRateChart";
                        rfvFromWithinTAT.ErrorMessage = "Please enter From Within TAT";
                        c.Controls.Add(rfvFromWithinTAT);
                        //REGULAR EXPRESSION VALIDATOR
                        RegularExpressionValidator revFromWithinTAT = new RegularExpressionValidator();
                        revFromWithinTAT.ID = "revFromWithinTAT" + j.ToString() + i.ToString();
                        revFromWithinTAT.ControlToValidate = txtFromWithinTAT.ID;
                        revFromWithinTAT.Display = ValidatorDisplay.None;
                        revFromWithinTAT.ValidationExpression = "^[0-9]*$";
                        revFromWithinTAT.ValidationGroup = "grpRateChart";
                        revFromWithinTAT.ErrorMessage = "Please enter only numbers for From Within TAT";
                        c.Controls.Add(revFromWithinTAT);
                        c.Width = Unit.Pixel(150);
                        break;
                    case 2:
                        TextBox txtToWithinTAT = new TextBox();
                        txtToWithinTAT.SkinID = "txtSkin";
                        txtToWithinTAT.ID = "txtToWithinTAT" + j.ToString() + i.ToString();
                        txtToWithinTAT.Text = "";
                        if (args.GetLength(0) > 0)
                        {
                            if (args[0] != "")
                            {
                                txtToWithinTAT.Text = args[2];
                            }
                        }
                        c.Controls.Add(txtToWithinTAT);
                        //REQUIRED FIELD VALIDATOR
                        RequiredFieldValidator rfvToWithinTAT = new RequiredFieldValidator();
                        rfvToWithinTAT.ID = "rfvToWithinTAT" + j.ToString() + i.ToString();
                        rfvToWithinTAT.ControlToValidate = txtToWithinTAT.ID;
                        rfvToWithinTAT.Display = ValidatorDisplay.None;
                        rfvToWithinTAT.ValidationGroup = "grpRateChart";
                        rfvToWithinTAT.ErrorMessage = "Please enter To Within TAT";
                        c.Controls.Add(rfvToWithinTAT);
                        //REGULAR EXPRESSION VALIDATOR
                        RegularExpressionValidator revToWithinTAT = new RegularExpressionValidator();
                        revToWithinTAT.ID = "revToWithinTAT" + j.ToString() + i.ToString();
                        revToWithinTAT.ControlToValidate = txtToWithinTAT.ID;
                        revToWithinTAT.Display = ValidatorDisplay.None;
                        revToWithinTAT.ValidationExpression = "^[0-9]*$";
                        revToWithinTAT.ValidationGroup = "grpRateChart";
                        revToWithinTAT.ErrorMessage = "Please enter only numbers for To Within TAT";
                        c.Controls.Add(revToWithinTAT);
                        c.Width = Unit.Pixel(150);
                        break;
                    case 3:
                        DropDownList ddlBonusOn = new DropDownList();
                        ddlBonusOn.SkinID = "ddlSkin";
                        ddlBonusOn.ID = "ddlBonusOn" + j.ToString() + i.ToString();
                        ddlBonusOn.Items.Clear();
                        ListItem liBonusOn = new ListItem("--Select--", "");
                        ddlBonusOn.Items.Add(liBonusOn);
                        liBonusOn = new ListItem("Bill Amount", "B");
                        ddlBonusOn.Items.Add(liBonusOn);
                        liBonusOn = new ListItem("Per Case", "P");
                        ddlBonusOn.Items.Add(liBonusOn);

                        if (args.GetLength(0) > 0)
                        {
                            if (args[0] != "")
                            {
                                ddlBonusOn.SelectedValue = args[3];
                            }
                        }
                        c.Controls.Add(ddlBonusOn);

                        //REQUIRED FIELD VALIDATOR
                        RequiredFieldValidator rfvBonusOn = new RequiredFieldValidator();
                        rfvBonusOn.ID = "rfvBonusOn" + j.ToString() + i.ToString();
                        rfvBonusOn.ControlToValidate = ddlBonusOn.ID;
                        rfvBonusOn.Display = ValidatorDisplay.None;
                        rfvBonusOn.ValidationGroup = "grpRateChart";
                        rfvBonusOn.ErrorMessage = "Please select Bonus On";
                        c.Controls.Add(rfvBonusOn);
                        c.Width = Unit.Pixel(150);
                        break;
                    case 4:
                        DropDownList ddlValueTypeBonus = new DropDownList();
                        ddlValueTypeBonus.SkinID = "ddlSkin";
                        ddlValueTypeBonus.ID = "ddlValueTypeBonus" + j.ToString() + i.ToString();
                        ddlValueTypeBonus.Items.Clear();
                        ListItem liValueType = new ListItem("--Select--", "");
                        ddlValueTypeBonus.Items.Add(liValueType);
                        liValueType = new ListItem("Percent", "P");
                        ddlValueTypeBonus.Items.Add(liValueType);
                        liValueType = new ListItem("Constant", "C");
                        ddlValueTypeBonus.Items.Add(liValueType);

                        if (args.GetLength(0) > 0)
                        {
                            if (args[0] != "")
                            {
                                ddlValueTypeBonus.SelectedValue = args[4];
                            }
                        }
                        c.Controls.Add(ddlValueTypeBonus);
                        //REQUIRED FIELD VALIDATOR
                        RequiredFieldValidator rfvValueTypeBonus = new RequiredFieldValidator();
                        rfvValueTypeBonus.ID = "rfvValueTypeBonus" + j.ToString() + i.ToString();
                        rfvValueTypeBonus.ControlToValidate = ddlValueTypeBonus.ID;
                        rfvValueTypeBonus.Display = ValidatorDisplay.None;
                        rfvValueTypeBonus.ValidationGroup = "grpRateChart";
                        rfvValueTypeBonus.ErrorMessage = "Please select Value Type";
                        c.Controls.Add(rfvValueTypeBonus);
                        c.Width = Unit.Pixel(150);
                        break;
                    case 5:
                        TextBox txtValueBonus = new TextBox();
                        txtValueBonus.SkinID = "txtSkin";
                        txtValueBonus.ID = "txtValueBonus" + j.ToString() + i.ToString();
                        txtValueBonus.Text = "";
                        if (args.GetLength(0) > 0)
                        {
                            if (args[0] != "")
                            {
                                txtValueBonus.Text = args[5];
                            }
                        }
                        c.Controls.Add(txtValueBonus);
                        //REQUIRED FIELD VALIDATOR
                        RequiredFieldValidator rfvValueBonus = new RequiredFieldValidator();
                        rfvValueBonus.ID = "rfvValueBonus" + j.ToString() + i.ToString();
                        rfvValueBonus.ControlToValidate = txtValueBonus.ID;
                        rfvValueBonus.Display = ValidatorDisplay.None;
                        rfvValueBonus.ValidationGroup = "grpRateChart";
                        rfvValueBonus.ErrorMessage = "Please enter Value";
                        c.Controls.Add(rfvValueBonus);
                        //REGULAR EXPRESSION VALIDATOR
                        RegularExpressionValidator revValueBonus = new RegularExpressionValidator();
                        revValueBonus.ID = "revValueBonus" + j.ToString() + i.ToString();
                        revValueBonus.ControlToValidate = txtValueBonus.ID;
                        revValueBonus.Display = ValidatorDisplay.None;
                        revValueBonus.ValidationExpression = "^[0-9]*$";
                        revValueBonus.ValidationGroup = "grpRateChart";
                        revValueBonus.ErrorMessage = "Please enter only numbers for Value";
                        c.Controls.Add(revValueBonus);
                        c.Width = Unit.Pixel(150);
                        break;
                    case 6:
                        HiddenField hdnBonus = new HiddenField();
                        hdnBonus.ID = "hdnBonus" + j.ToString() + i.ToString();
                        hdnBonus.Value = "";
                        if (args.GetLength(0) > 0)
                        {
                            if (args[0] != "")
                            {
                                hdnBonus.Value = args[0];
                            }
                        }
                        c.Controls.Add(hdnBonus);
                        break;
                }
                c.BorderStyle = BorderStyle.None;
                r.Cells.Add(c);
            }
            tblBonus.Rows.Add(r);
        }
        catch (Exception exp)
        {
            lblMgs.Text = "Error : " + exp.Message;
        }
    }
    protected void ddlImplementedBy_DataBound(object sender, EventArgs e)
    {
        ddlImplementedBy.Items.Insert(0, new ListItem("--Select--", ""));
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            if (dtRateChart == null)
            {
                CreateRateChartTable();
            }
            if (ViewState["dt1"] != null)
            {
                dtRateChart = (DataTable)ViewState["dt1"];
            }
            oBD.ContractID = hdnContID.Value.ToString();
            oBD.PresaleContID = hdnPresaleContID.Value.ToString();
            oBD.ContractNo = txtContractNo.Text.Trim();
            if (txtContractDate.Text.Trim()!="")
            oBD.ContractDate = Convert.ToDateTime(oCmn.strDate(txtContractDate.Text.Trim())).ToString();
        if (txtExpiryDate.Text.Trim() != "")
            oBD.ContractExpiryDate = Convert.ToDateTime(oCmn.strDate(txtExpiryDate.Text.Trim())).ToString();
        if (txtImplementDate.Text.Trim() != "")
            oBD.ProjectImplementDate = Convert.ToDateTime(oCmn.strDate(txtImplementDate.Text.Trim())).ToString();
        if (txtStartDate.Text.Trim() != "")
            oBD.ProjectStartDate = Convert.ToDateTime(oCmn.strDate(txtStartDate.Text.Trim())).ToString();
            oBD.ProjectImplementBy = ddlImplementedBy.SelectedValue.ToString();
            oBD.ExpectedTo = txtExpectedTo.Text.Trim();
            oBD.StatusAfterMonths = txtStatusAfterMonths.Text.Trim();
            oBD.MinVolMonth = txtMinVolMonth.Text.Trim();
            oBD.MinGrtMonth = txtMinGrtMonth.Text.Trim();
            oBD.IETax = ddlTaxing.SelectedValue.ToString();
            DataTable dt;
            DataRow dr;
            int iCtr = 0;
            if (dtRateChart.Rows.Count > 0)
            {
                //dt = new DataTable();
                //dt.Columns.Add();
                //dt.Columns.Add();
                //dt.Columns.Add();
                //dt.Columns.Add();
                //dt.Columns.Add();
                //dt.Columns.Add();
                //foreach (GridViewRow row in gvRateChart.Rows)
                //{
                //    dr = dt.NewRow();
                //    dr[0] = ((DropDownList)row.FindControl("ddlCentre" + iCtr)).SelectedValue.ToString();
                //    dr[1] = ((DropDownList)row.FindControl("ddlActivity" + iCtr)).SelectedValue.ToString();
                //    dr[2] = ((DropDownList)row.FindControl("ddlProduct" + iCtr)).SelectedValue.ToString();
                //    dr[3] = ((TextBox)row.FindControl("txtType" + iCtr)).Text.Trim();
                //    dr[4] = ((TextBox)row.FindControl("txtRate" + iCtr)).Text.Trim();
                //    dr[5] = ((HiddenField)row.FindControl("hdnRateChart" + iCtr)).Value.Trim();
                //    iCtr = iCtr + 1;
                //    dt.Rows.Add(dr);
                //}
                oBD.dsRateChart = new DataSet();
                oBD.dsRateChart.Tables.Add(dtRateChart);
            }
            iCtr = 0;
            if (tblVolumeSlab.Rows.Count > 0)
            {
                dt = new DataTable();
                dt.Columns.Add();
                dt.Columns.Add();
                dt.Columns.Add();
                dt.Columns.Add();
                dt.Columns.Add();
                foreach (TableRow row in tblVolumeSlab.Rows)
                {
                    dr = dt.NewRow();
                    dr[0] = ((TextBox)row.FindControl("txtFromNoCases" + iCtr + "1")).Text.Trim();
                    dr[1] = ((TextBox)row.FindControl("txtToNoCases" + iCtr + "2")).Text.Trim();
                    dr[2] = ((TextBox)row.FindControl("txtType" + iCtr + "3")).Text.Trim();
                    dr[3] = ((TextBox)row.FindControl("txtVRate" + iCtr + "4")).Text.Trim();
                    dr[4] = ((HiddenField)row.FindControl("hdnVolumeSlab" + iCtr + "5")).Value.Trim();
                    iCtr = iCtr + 1;
                    dt.Rows.Add(dr);
                }
                oBD.dsVolumeSlab = new DataSet();
                oBD.dsVolumeSlab.Tables.Add(dt);
            }
            iCtr = 0;
            if (tblPenalty.Rows.Count > 0)
            {
                dt = new DataTable();
                dt.Columns.Add();
                dt.Columns.Add();
                dt.Columns.Add();
                dt.Columns.Add();
                dt.Columns.Add();
                dt.Columns.Add();
                foreach (TableRow row in tblPenalty.Rows)
                {
                    dr = dt.NewRow();
                    dr[0] = ((TextBox)row.FindControl("txtFromBeyondTAT" + iCtr + "1")).Text.Trim();
                    dr[1] = ((TextBox)row.FindControl("txtToBeyondTAT" + iCtr + "2")).Text.Trim();
                    dr[2] = ((DropDownList)row.FindControl("ddlPenaltyOn" + iCtr + "3")).SelectedValue.ToString();
                    dr[3] = ((DropDownList)row.FindControl("ddlValueTypePenalty" + iCtr + "4")).SelectedValue.ToString();
                    dr[4] = ((TextBox)row.FindControl("txtValuePenalty" + iCtr + "5")).Text.Trim();
                    dr[5] = ((HiddenField)row.FindControl("hdnPenalty" + iCtr + "6")).Value.Trim();
                    iCtr = iCtr + 1;
                    dt.Rows.Add(dr);
                }
                oBD.dsPenalty = new DataSet();
                oBD.dsPenalty.Tables.Add(dt);
            }
            iCtr = 0;
            if (tblBonus.Rows.Count > 0)
            {
                dt = new DataTable();
                dt.Columns.Add();
                dt.Columns.Add();
                dt.Columns.Add();
                dt.Columns.Add();
                dt.Columns.Add();
                dt.Columns.Add();
                foreach (TableRow row in tblBonus.Rows)
                {
                    dr = dt.NewRow();
                    dr[0] = ((TextBox)row.FindControl("txtFromWithinTAT" + iCtr + "1")).Text.Trim();
                    dr[1] = ((TextBox)row.FindControl("txtToWithinTAT" + iCtr + "2")).Text.Trim();
                    dr[2] = ((DropDownList)row.FindControl("ddlBonusOn" + iCtr + "3")).SelectedValue.ToString();
                    dr[3] = ((DropDownList)row.FindControl("ddlValueTypeBonus" + iCtr + "4")).SelectedValue.ToString();
                    dr[4] = ((TextBox)row.FindControl("txtValueBonus" + iCtr + "5")).Text.Trim();
                    dr[5] = ((HiddenField)row.FindControl("hdnBonus" + iCtr + "6")).Value.Trim();
                    iCtr = iCtr + 1;
                    dt.Rows.Add(dr);
                }
                oBD.dsBonus = new DataSet();
                oBD.dsBonus.Tables.Add(dt);
            }
            if (hdnMode.Value == "A")
            {
                oBD.Prefix = Session["Prefix"].ToString();
                oBD.InsertContractDetail();
                lblMgs.Text = "Record added successfully";
            }
            if (hdnMode.Value == "E")
            {
                oBD.UpdateContractDetail();
                lblMgs.Text = "Record updated successfully";
            }
        }
        catch (Exception exp)
        {
            lblMgs.Text = "Error : " + exp.Message;
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {        
        Response.Redirect("ViewConfirmContract.aspx");
    }
    protected void gvRateChart_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (dtRateChart == null)
        {
            CreateRateChartTable();
        }
        if (ViewState["dt1"] != null)
        {
            dtRateChart = (DataTable)ViewState["dt1"];
        }
        int index = Convert.ToInt16(e.CommandArgument);

        if (e.CommandName == "EditRateChart")
        {
            hdnIndex.Value = index.ToString(); ;
            if (((HiddenField)gvRateChart.Rows[index].FindControl("hdnCentre")).Value.ToString() == "")
                ddlCentre.SelectedIndex = 0;
            else
                ddlCentre.SelectedValue = ((HiddenField)gvRateChart.Rows[index].FindControl("hdnCentre")).Value.ToString();
            ddlActivity.DataSourceID = "sdsActivity";
            ddlActivity.DataBind();
            if (ddlActivity.Items.Count > 0)
                if (((HiddenField)gvRateChart.Rows[index].FindControl("hdnActivity")).Value.ToString() != "")
                    ddlActivity.SelectedValue = ((HiddenField)gvRateChart.Rows[index].FindControl("hdnActivity")).Value.ToString();
            ddlProduct.DataSourceID = "sdsProduct";
            ddlProduct.DataBind();
            if (ddlProduct.Items.Count > 0)
                if (((HiddenField)gvRateChart.Rows[index].FindControl("hdnProduct")).Value.ToString() != "")
                    ddlProduct.SelectedValue = ((HiddenField)gvRateChart.Rows[index].FindControl("hdnProduct")).Value.ToString();
            txtType.Text = ((Label)gvRateChart.Rows[index].FindControl("lblType")).Text.Trim().ToString();
            txtRate.Text = ((Label)gvRateChart.Rows[index].FindControl("lblRate")).Text.Trim().ToString();
        }
        if (e.CommandName == "CancelRateChart")
        {
            ViewState["dt1"] = dtRateChart;
            gvRateChart.DataBind();
        }
        if (e.CommandName == "DeleteRateChart")
        {
            String strRateChartID = "";
            strRateChartID = dtRateChart.Rows[index]["RATE_CHART_ID"].ToString();
            if (strRateChartID != "")
            {
                oBD.DeleteRateChart(strRateChartID);
            }
            dtRateChart.Rows[index].Delete();
            ViewState["dt1"] = dtRateChart;
            gvRateChart.DataSource = dtRateChart;
            gvRateChart.DataBind();
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if (dtRateChart == null)
        {
            CreateRateChartTable();
        }
        if (ViewState["dt1"] != null)
        {
            dtRateChart = (DataTable)ViewState["dt1"];
        }

        if (hdnIndex.Value == "")
        {
            dr = dtRateChart.NewRow();
            //dr["RATE_CHART_ID"] = "";
            dr["CENTRE_ID"] = ddlCentre.SelectedValue.ToString();
            dr["ACTIVITY_ID"] = ddlActivity.SelectedValue.ToString();
            dr["PRODUCT_ID"] = ddlProduct.SelectedValue.ToString();
            dr["VERIFICATION_TYPE"] = txtType.Text.ToString();
            dr["RATE"] = txtRate.Text.ToString();
            dr["CENTRE_NAME"] = ddlCentre.SelectedItem.Text.ToString();
            dr["ACTIVITY_NAME"] = ddlActivity.SelectedItem.Text.ToString();
            dr["PRODUCT_NAME"] = ddlProduct.SelectedItem.Text.ToString();
            dtRateChart.Rows.Add(dr);
        }
        else
        {
            int index = Convert.ToInt16(hdnIndex.Value);
            //dtRateChart.Rows[index]["RATE_CHART_ID"] = "";
            dtRateChart.Rows[index]["CENTRE_ID"] = ddlCentre.SelectedValue.ToString();
            dtRateChart.Rows[index]["ACTIVITY_ID"] = ddlActivity.SelectedValue.ToString();
            dtRateChart.Rows[index]["PRODUCT_ID"] = ddlProduct.SelectedValue.ToString();
            dtRateChart.Rows[index]["VERIFICATION_TYPE"] = txtType.Text.ToString();
            dtRateChart.Rows[index]["RATE"] = txtRate.Text.ToString();
            dtRateChart.Rows[index]["CENTRE_NAME"] = ddlCentre.SelectedItem.Text.ToString();
            dtRateChart.Rows[index]["ACTIVITY_NAME"] = ddlActivity.SelectedItem.Text.ToString();
            dtRateChart.Rows[index]["PRODUCT_NAME"] = ddlProduct.SelectedItem.Text.ToString();
        }
        ViewState["dt1"] = dtRateChart;
        gvRateChart.DataSource = dtRateChart;
        gvRateChart.DataBind();
        ddlCentre.SelectedIndex = 0;
        ddlActivity.Items.Clear();
        ddlProduct.Items.Clear();
        txtType.Text = "";
        txtRate.Text = "";
        hdnIndex.Value = "";

    }
    public void CreateRateChartTable()
    {
        dtRateChart = new DataTable();
        dtRateChart.Columns.Add("RATE_CHART_ID");
        dtRateChart.Columns.Add("CENTRE_ID");
        dtRateChart.Columns.Add("ACTIVITY_ID");
        dtRateChart.Columns.Add("PRODUCT_ID");
        dtRateChart.Columns.Add("VERIFICATION_TYPE");
        dtRateChart.Columns.Add("RATE");
        dtRateChart.Columns.Add("CENTRE_NAME");
        dtRateChart.Columns.Add("ACTIVITY_NAME");
        dtRateChart.Columns.Add("PRODUCT_NAME");
    }
    protected void btnCancelRC_Click(object sender, EventArgs e)
    {
        if (dtRateChart == null)
        {
            CreateRateChartTable();
        }
        if (ViewState["dt1"] != null)
        {
            dtRateChart = (DataTable)ViewState["dt1"];
        }
        gvRateChart.DataSource = dtRateChart;
        gvRateChart.DataBind();
        ddlCentre.DataBind();
        if (ddlCentre.Items.Count > 0)
            ddlCentre.SelectedIndex = 0;
        ddlActivity.Items.Clear();
        ddlProduct.Items.Clear();

        txtType.Text = "";
        txtRate.Text = "";
    }
    protected void ddlCentre_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlActivity.Items.Clear();
        ddlActivity.DataSourceID = "sdsActivity";
        ddlActivity.DataBind();
        if (ddlActivity.Items.Count > 0)
            ddlActivity.SelectedIndex = 0;

        ddlProduct.Items.Clear();
        ddlProduct.DataSourceID = "sdsProduct";
        ddlProduct.DataBind();
        if (ddlProduct.Items.Count > 0)
            ddlProduct.SelectedIndex = 0;
    }
    protected void ddlActivity_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlProduct.Items.Clear();
        ddlProduct.DataSourceID = "sdsProduct";
        ddlProduct.DataBind();
        if (ddlProduct.Items.Count > 0)
            ddlProduct.SelectedIndex = 0;
    }
    protected void imgGet_Click(object sender, ImageClickEventArgs e)
    {
        //TO GENERATE UNIQUE CODE
        String strCont = oCmn.GetUniqueID("CONTRACT_DETAIL_SERIAL", "");
        txtContractNo.Text = "Cont" + strCont;
    }
}
