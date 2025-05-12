using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;


public partial class _Default : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["UserInfo"] == null)
            {
                Response.Redirect("InvalidRequest.aspx", false);
            }

            if (!IsPostBack)
            {
                get_NanoModelList();
                Get_BranchList();    
            }
            Add_javascript();
        }
        catch (Exception ex)
        {
            lblMessage.CssClass = "ErrorMessage";
            lblMessage.Visible = true;
            lblMessage.Text = ex.Message;
        }

    }
    private void Add_javascript()
    {
        try{
            //ddlApplicant_CategoryList.Attributes.Add("onchange", "javascript:change_ApplicantCatgory();");
            ddlApplicant_CategoryList.Attributes.Add("onchange", "javascript:HideControl('ddlApplicant_CategoryList','txtApplicantCategory','Other');");
            ddlPhotoIdProff.Attributes.Add("onchange", "javascript:HideControl('ddlPhotoIdProff','txtPhotoIdProff','Any Other');");
            
            //ddlDiscrepancy.Attributes.Add("onchange", "javascript:return Check_Discrepancy();");

        }
         catch (Exception ex)
        {
            lblMessage.CssClass = "ErrorMessage";
            lblMessage.Visible = true;
            lblMessage.Text = ex.Message;
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if ((txtPanNo.Text == "") && (ddlForm60601.SelectedValue == "(Select)"))
            {
                lblMessage.CssClass = "ErrorMessage";
                lblMessage.Visible = true;
                lblMessage.Text = "If you do not have a PAN number please select any of one Form60 or Form61!";
            }
            else
            {

                Upadte_NEWApplication();
                Clear_AllControls();
            }
            //string strClientStript="";
            //Page.ClientScript("<language=""javascript"" tyepe=""text/javascript""> alert(") </script>");
        
        }

        catch (Exception ex)
        {
            lblMessage.CssClass = "ErrorMessage";
            lblMessage.Visible = true;
            lblMessage.Text = ex.Message;
        }

    }
    private void get_NanoModelList()
    {
        try
        {
            Object SaveUSERInfo = (Object)Session["UserInfo"];
           
            SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

            sqlCon.Open();
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlCon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "Get_AllNanoModels";

            SqlParameter BranchId = new SqlParameter();
            BranchId.SqlDbType = SqlDbType.Int;
            BranchId.Value = Convert.ToInt32(((UserInfo.structUSERInfo)(SaveUSERInfo)).BranchId);
            BranchId.ParameterName = "@BranchId";
            sqlCom.Parameters.Add(BranchId);

            SqlDataAdapter sqlDA = new SqlDataAdapter();
            sqlDA.SelectCommand = sqlCom;
            DataTable dt = new DataTable();
            sqlDA.Fill(dt);
            sqlCon.Close();

            ddlNanoModelNo.DataTextField = "ModelNo";
            ddlNanoModelNo.DataValueField = "ModelId";
            ddlNanoModelNo.DataSource = dt;
            ddlNanoModelNo.DataBind();

            ddlNanoModelNo.Items.Insert(0, "(Select)");
            ddlNanoModelNo.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            lblMessage.CssClass = "ErrorMessage";
            lblMessage.Visible = true;
            lblMessage.Text = ex.Message;
        }
    }
    private void get_NanoModelColorList(int pModelId)
    {
        try
        {
            Object SaveUSERInfo = (Object)Session["UserInfo"];

            SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

            sqlCon.Open();
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlCon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "Get_NanoColorByModel";

            SqlParameter BranchId = new SqlParameter();
            BranchId.SqlDbType = SqlDbType.Int;
            BranchId.Value = Convert.ToInt32(((UserInfo.structUSERInfo)(SaveUSERInfo)).BranchId);
            BranchId.ParameterName = "@BranchId";
            sqlCom.Parameters.Add(BranchId);

            SqlParameter ModelId = new SqlParameter();
            ModelId.SqlDbType = SqlDbType.Int;
            ModelId.Value = Convert.ToInt32(pModelId);
            ModelId.ParameterName = "@ModelId";
            sqlCom.Parameters.Add(ModelId);

            string strColor =sqlCom.ExecuteScalar().ToString() ;
            sqlCon.Close(); 
            string[] strColorArray = strColor.Split(',');
            int i=0;
            ddlNanoColor.Items.Clear();
            for (i = 0; i <= strColorArray.Length - 1; i++)
            { 
                ddlNanoColor.Items.Add(strColorArray[i]);
            }
            ddlNanoColor.Items.Insert(0,"--Select--");
            ddlNanoColor.SelectedIndex = 0;
           
        }
        catch (Exception ex)
        {
            lblMessage.CssClass = "ErrorMessage";
            lblMessage.Visible = true;
            lblMessage.Text = ex.Message;
        }
    }
    protected void ddlNanoModelNo_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            get_NanoModelColorList(Convert.ToInt32(ddlNanoModelNo.SelectedValue));
        }
        catch (Exception ex)
        {
            lblMessage.CssClass = "ErrorMessage";
            lblMessage.Visible = true;
            lblMessage.Text = ex.Message;
        }
    }
    protected void lnkApplicationExists_Click(object sender, EventArgs e)
    {
        try
        {
            CheckApplicationAvailablily();
        }
        catch (Exception ex)
        {
            lblMessage.CssClass = "ErrorMessage";
            lblMessage.Visible = true;
            lblMessage.Text = ex.Message;
        }
    }
    private void CheckApplicationAvailablily()
    {
        try
        {
            Object SaveUSERInfo = (Object)Session["UserInfo"];

            SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

            sqlCon.Open();
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlCon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "CheckApplicationNo";

            SqlParameter BranchId = new SqlParameter();
            BranchId.SqlDbType = SqlDbType.Int;
            BranchId.Value = Convert.ToInt32(((UserInfo.structUSERInfo)(SaveUSERInfo)).BranchId);
            BranchId.ParameterName = "@BranchId";
            sqlCom.Parameters.Add(BranchId);

            SqlParameter ApplicationNo = new SqlParameter();
            ApplicationNo.SqlDbType = SqlDbType.VarChar;
            ApplicationNo.Value = txtNanoApplicationNo.Text.Trim();
            ApplicationNo.ParameterName = "@ApplicationNo";
            sqlCom.Parameters.Add(ApplicationNo);

            SqlParameter Message = new SqlParameter();
            Message.Direction = ParameterDirection.Output; 
            Message.SqlDbType = SqlDbType.VarChar;
            Message.Value = "";
            Message.ParameterName = "@Message";
            sqlCom.Parameters.Add(Message);

            lblMessage.Visible = true;
            
            lblMessage.Text = sqlCom.ExecuteScalar().ToString();

            if (lblMessage.Text == "New No! Please continue to save!")
            {
                lblMessage.CssClass = "UpdateMessage";
            }
            else 
            {
                lblMessage.CssClass = "ErrorMessage";
            }

            sqlCon.Close();

             


        }
        catch (Exception ex)
        {
            lblMessage.CssClass = "ErrorMessage";
            lblMessage.Visible = true;
            lblMessage.Text = ex.Message;
        }
    }
    private void Upadte_NEWApplication()
    {
        try
        {
            Object SaveUSERInfo = (Object)Session["UserInfo"];

            SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

            sqlCon.Open();
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlCon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "Update_ApplicationInfo";

            SqlParameter BranchId = new SqlParameter();
            BranchId.SqlDbType = SqlDbType.Int;
            BranchId.Value = Convert.ToInt32(((UserInfo.structUSERInfo)(SaveUSERInfo)).BranchId);
            BranchId.ParameterName = "@BranchId";
            sqlCom.Parameters.Add(BranchId);

            SqlParameter NanoApplicationNo = new SqlParameter();
            NanoApplicationNo.SqlDbType = SqlDbType.VarChar;
            NanoApplicationNo.Value = txtNanoApplicationNo.Text.Trim();
            NanoApplicationNo.ParameterName = "@NanoApplicationNo";
            sqlCom.Parameters.Add(NanoApplicationNo);

            SqlParameter NanoApplicationDate = new SqlParameter();
            NanoApplicationDate.SqlDbType = SqlDbType.VarChar;
            NanoApplicationDate.Value = txtApplicationDate.Text.Trim();//Convert.ToDateTime(txtApplicationDate.Text.Trim()).ToString("dd-MM-yyyy");
            NanoApplicationDate.ParameterName = "@NanoApplicationDate";
            sqlCom.Parameters.Add(NanoApplicationDate);

            SqlParameter Customer_Salutation = new SqlParameter();
            Customer_Salutation.SqlDbType = SqlDbType.VarChar;
            Customer_Salutation.Value = ddlSalutation.SelectedValue.ToString().Trim();
            Customer_Salutation.ParameterName = "@Customer_Salutation";
            sqlCom.Parameters.Add(Customer_Salutation);

            SqlParameter Customer_FirstName = new SqlParameter();
            Customer_FirstName.SqlDbType = SqlDbType.VarChar;
            Customer_FirstName.Value = txtFirstName.Text.Trim();
            Customer_FirstName.ParameterName = "@Customer_FirstName";
            sqlCom.Parameters.Add(Customer_FirstName);

            SqlParameter Customer_MiddleName = new SqlParameter();
            Customer_MiddleName.SqlDbType = SqlDbType.VarChar;
            Customer_MiddleName.Value = txtMiddleName.Text.Trim();
            Customer_MiddleName.ParameterName = "@Customer_MiddleName";
            sqlCom.Parameters.Add(Customer_MiddleName);

            SqlParameter Customer_LastName = new SqlParameter();
            Customer_LastName.SqlDbType = SqlDbType.VarChar;
            Customer_LastName.Value = txtLastName.Text.Trim();
            Customer_LastName.ParameterName = "@Customer_LastName";
            sqlCom.Parameters.Add(Customer_LastName);

            string applicant_Category = ddlApplicant_CategoryList.SelectedValue.ToString().Trim();
            if (ddlApplicant_CategoryList.SelectedValue=="Other")
                {
                    applicant_Category = txtApplicantCategory.Text.Trim();
                }

            SqlParameter Customer_Category = new SqlParameter();
            Customer_Category.SqlDbType = SqlDbType.VarChar;
            Customer_Category.Value = applicant_Category;
            Customer_Category.ParameterName = "@Customer_Category";
            sqlCom.Parameters.Add(Customer_Category);

            SqlParameter Gender = new SqlParameter();
            Gender.SqlDbType = SqlDbType.VarChar;
            Gender.Value = ddlGender.SelectedValue.ToString().Trim();
            Gender.ParameterName = "@Gender";
            sqlCom.Parameters.Add(Gender);

            SqlParameter DateOfBirth = new SqlParameter();
            DateOfBirth.SqlDbType = SqlDbType.VarChar; //SqlDbType.DateTime;
            DateOfBirth.Value = txtDateOfBirth.Text.Trim();//Convert.ToDateTime(txtDateOfBirth.Text).ToString("dd-MM-yyyy");
            DateOfBirth.ParameterName = "@DateOfBirth";
            sqlCom.Parameters.Add(DateOfBirth);

            SqlParameter Marrital_Status = new SqlParameter();
            Marrital_Status.SqlDbType = SqlDbType.VarChar;
            Marrital_Status.Value ="";
            Marrital_Status.ParameterName = "@Marrital_Status";
            sqlCom.Parameters.Add(Marrital_Status);

            string Address = Convert.ToString(txtAdd1.Text.ToString()) +", "+ Convert.ToString(txtAdd2.Text.Trim());

            SqlParameter Correspondence_Address = new SqlParameter();
            Correspondence_Address.SqlDbType = SqlDbType.VarChar;
            Correspondence_Address.Value = Address;
            Correspondence_Address.ParameterName = "@Correspondence_Address";
            sqlCom.Parameters.Add(Correspondence_Address);

            SqlParameter Correspondence_City = new SqlParameter();
            Correspondence_City.SqlDbType = SqlDbType.VarChar;
            Correspondence_City.Value = txtApplicantCity.Text.Trim();
            Correspondence_City.ParameterName = "@Correspondence_City";
            sqlCom.Parameters.Add(Correspondence_City);

            SqlParameter Correspondence_PinCode = new SqlParameter();
            Correspondence_PinCode.SqlDbType = SqlDbType.VarChar;
            Correspondence_PinCode.Value = txtApplicantPincode.Text.Trim();
            Correspondence_PinCode.ParameterName = "@Correspondence_PinCode";
            sqlCom.Parameters.Add(Correspondence_PinCode);

            SqlParameter Correspondence_State = new SqlParameter();
            Correspondence_State.SqlDbType = SqlDbType.VarChar;
            Correspondence_State.Value = txtApplicantState.Text.Trim();
            Correspondence_State.ParameterName = "@Correspondence_State";
            sqlCom.Parameters.Add(Correspondence_State);

          

            SqlParameter Residence_Phone = new SqlParameter();
            Residence_Phone.SqlDbType =SqlDbType.BigInt ;
            if (txtApplicantLandLineNo.Text != "")
            {
                Residence_Phone.Value = Convert.ToInt64(txtApplicantMobNo.Text.Trim());
            }
            else
            {
                Residence_Phone.Value = 0;

            }
                       
            Residence_Phone.ParameterName = "@Residence_Phone";
            sqlCom.Parameters.Add(Residence_Phone);

             

            SqlParameter MobileNo = new SqlParameter();
            MobileNo.SqlDbType = SqlDbType.BigInt;
           
            if (txtApplicantMobNo.Text != "")
            {
                MobileNo.Value = Convert.ToInt64(txtApplicantMobNo.Text.Trim());
            }  
            else
            {
                MobileNo.Value = 0;
          
            }
            MobileNo.ParameterName = "@MobileNo";
            sqlCom.Parameters.Add(MobileNo);

            SqlParameter EmailAddress = new SqlParameter();
            EmailAddress.SqlDbType = SqlDbType.VarChar;
            EmailAddress.Value = txtEmailId.Text.Trim();
            EmailAddress.ParameterName = "@EmailAddress";
            sqlCom.Parameters.Add(EmailAddress);

            SqlParameter PANNo = new SqlParameter();
            PANNo.SqlDbType = SqlDbType.VarChar;
            PANNo.Value = txtPanNo.Text.Trim();
            PANNo.ParameterName = "@PANNo";
            sqlCom.Parameters.Add(PANNo);


          

            string Form60 = "";
            string Form61 = "";
            if (ddlForm60601.SelectedValue == "Form 60")
                {
                    Form60 = "FORM 60";
                }
                else if (ddlForm60601.SelectedValue == "Form 61")
                {
                    Form61 = "FORM 61";
                }
                else
                {
                    Form61 = "";
                    Form60 = "";
                }


            SqlParameter pForm60 = new SqlParameter();
            pForm60.SqlDbType = SqlDbType.VarChar;
            pForm60.Value = Form60;
            pForm60.ParameterName = "@Form60";
            sqlCom.Parameters.Add(pForm60);

            SqlParameter pForm61 = new SqlParameter();
            pForm61.SqlDbType = SqlDbType.VarChar;
            pForm61.Value = Form61;
            pForm61.ParameterName = "@Form61";
            sqlCom.Parameters.Add(pForm61);


            SqlParameter SourchBranchId = new SqlParameter();
            SourchBranchId.SqlDbType = SqlDbType.Int;
            SourchBranchId.Value =Convert.ToInt32(ddlSourceBranch.SelectedValue);
            SourchBranchId.ParameterName = "@SourchBranchId";
            sqlCom.Parameters.Add(SourchBranchId);

            SqlParameter EmployeeName = new SqlParameter();
            EmployeeName.SqlDbType = SqlDbType.VarChar;
            EmployeeName.Value = txtEmpCode.Text.Trim();
            EmployeeName.ParameterName = "@EmployeeName";
            sqlCom.Parameters.Add(EmployeeName);

            SqlParameter Delivery_Store = new SqlParameter();
            Delivery_Store.SqlDbType = SqlDbType.VarChar;
            Delivery_Store.Value = ddlDeliveryList.SelectedValue.ToString() ;
            Delivery_Store.ParameterName = "@Delivery_Store";
            sqlCom.Parameters.Add(Delivery_Store);

            SqlParameter PhotoIdProffNo = new SqlParameter();
            PhotoIdProffNo.SqlDbType = SqlDbType.VarChar;
            PhotoIdProffNo.Value = txtPhotoIdProffNo.Text.Trim();
            PhotoIdProffNo.ParameterName = "@PhotoIdProffNo";
            sqlCom.Parameters.Add(PhotoIdProffNo);

            SqlParameter Enclosers = new SqlParameter();
            Enclosers.SqlDbType = SqlDbType.VarChar;
            Enclosers.Value = ddlEncloser.SelectedValue.ToString();
            Enclosers.ParameterName = "@Enclosers";
            sqlCom.Parameters.Add(Enclosers);

            SqlParameter Pay_ChqDDNo = new SqlParameter();
            Pay_ChqDDNo.SqlDbType = SqlDbType.VarChar;
            Pay_ChqDDNo.Value = txtCheque_ddNo.Text.Trim();
            Pay_ChqDDNo.ParameterName = "@Pay_ChqDDNo";
            sqlCom.Parameters.Add(Pay_ChqDDNo);

            SqlParameter Pay_DraweeBank = new SqlParameter();
            Pay_DraweeBank.SqlDbType = SqlDbType.VarChar;
            Pay_DraweeBank.Value = txtDraweeBank.Text.Trim();
            Pay_DraweeBank.ParameterName = "@Pay_DraweeBank";
            sqlCom.Parameters.Add(Pay_DraweeBank);

            SqlParameter Pay_ChqDD_Date = new SqlParameter();
            Pay_ChqDD_Date.SqlDbType = SqlDbType.VarChar;//SqlDbType.DateTime;
            Pay_ChqDD_Date.Value = txtCheque_DD_date.Text.Trim();//Convert.ToDateTime(txtCheque_DD_date.Text.Trim()).ToString("dd-MM-yyyy");
            Pay_ChqDD_Date.ParameterName = "@Pay_ChqDD_Date";
            sqlCom.Parameters.Add(Pay_ChqDD_Date);

            SqlParameter Pay_BankingBranch = new SqlParameter();
            Pay_BankingBranch.SqlDbType = SqlDbType.VarChar;
            Pay_BankingBranch.Value = txtSellingBank.Text.Trim();
            Pay_BankingBranch.ParameterName = "@Pay_BankingBranch";
            sqlCom.Parameters.Add(Pay_BankingBranch);

            SqlParameter RententionBook1 = new SqlParameter();
            RententionBook1.SqlDbType = SqlDbType.Bit;
            RententionBook1.Value =Convert.ToBoolean(chkRentention1.Checked) ;
            RententionBook1.ParameterName = "@RententionBook1";
            sqlCom.Parameters.Add(RententionBook1);

            SqlParameter RententionBook2 = new SqlParameter();
            RententionBook2.SqlDbType = SqlDbType.Bit;
            RententionBook2.Value = Convert.ToBoolean(chkRentention2.Checked);
            RententionBook2.ParameterName = "@RententionBook2";
            sqlCom.Parameters.Add(RententionBook2);

            SqlParameter Model = new SqlParameter();
            Model.SqlDbType = SqlDbType.VarChar;
            Model.Value = ddlNanoModelNo.SelectedValue.ToString().Trim() ;
            Model.ParameterName = "@Model";
            sqlCom.Parameters.Add(Model);

            SqlParameter Color = new SqlParameter();
            Color.SqlDbType = SqlDbType.VarChar;
            Color.Value = ddlNanoColor.SelectedValue.ToString().Trim() ;
            Color.ParameterName = "@Color";
            sqlCom.Parameters.Add(Color);

            
            SqlParameter Delivery_City = new SqlParameter();
            Delivery_City.SqlDbType = SqlDbType.VarChar;
            Delivery_City.Value = txtDeliveryCity.Text.Trim() ;
            Delivery_City.ParameterName = "@Delivery_City";
            sqlCom.Parameters.Add(Delivery_City);

            SqlParameter Delivery_State = new SqlParameter();
            Delivery_State.SqlDbType = SqlDbType.VarChar;
            Delivery_State.Value = txtDeliveryState.Text.ToString().Trim() ;
            Delivery_State.ParameterName = "@Delivery_State";
            sqlCom.Parameters.Add(Delivery_State);

            SqlParameter Delearship_Name = new SqlParameter();
            Delearship_Name.SqlDbType = SqlDbType.VarChar;
            Delearship_Name.Value = txtDeliveryDelearship.Text.Trim() ;
            Delearship_Name.ParameterName = "@Delearship_Name";
            sqlCom.Parameters.Add(Delearship_Name);

            string strPhotoIdProofType = ddlPhotoIdProff.SelectedValue.ToString().Trim();
            if (ddlPhotoIdProff.SelectedItem.Text== "Any Other")
            {
                strPhotoIdProofType = txtPhotoIdProff.Text.Trim();
            }


            SqlParameter PhotoIdProofType = new SqlParameter();
            PhotoIdProofType.SqlDbType = SqlDbType.VarChar;
            PhotoIdProofType.Value = strPhotoIdProofType;
            PhotoIdProofType.ParameterName = "@PhotoIdProofType";
            sqlCom.Parameters.Add(PhotoIdProofType);

        

            SqlParameter Location = new SqlParameter();
            Location.SqlDbType = SqlDbType.VarChar;
            Location.Value =txtLocation.Text.ToString().Trim() ;
            Location.ParameterName = "@Location";
            sqlCom.Parameters.Add(Location);

            SqlParameter AccounHolder_Name = new SqlParameter();
            AccounHolder_Name.SqlDbType = SqlDbType.VarChar;
            AccounHolder_Name.Value =txtAccountHolder.Text.ToString().Trim() ;
            AccounHolder_Name.ParameterName = "@AccounHolder_Name";
            sqlCom.Parameters.Add(AccounHolder_Name);

             SqlParameter BankAccount_No = new SqlParameter();
            BankAccount_No.SqlDbType = SqlDbType.VarChar;
            BankAccount_No.Value =txtBankAccount.Text.ToString().Trim() ;
            BankAccount_No.ParameterName = "@BankAccount_No";
            sqlCom.Parameters.Add(BankAccount_No);

            SqlParameter BankName = new SqlParameter();
            BankName.SqlDbType = SqlDbType.VarChar;
            BankName.Value =txtBankName.Text.ToString().Trim() ;
            BankName.ParameterName = "@BankName";
            sqlCom.Parameters.Add(BankName);

              SqlParameter Branch_Name = new SqlParameter();
            Branch_Name.SqlDbType = SqlDbType.VarChar;
            Branch_Name.Value =txtBranchName.Text.ToString().Trim() ;
            Branch_Name.ParameterName = "@Branch_Name";
            sqlCom.Parameters.Add(Branch_Name);

            SqlParameter Branch_MICRCode = new SqlParameter();
            Branch_MICRCode.SqlDbType = SqlDbType.VarChar;
            Branch_MICRCode.Value =txtBranchMICRCode.Text.ToString().Trim() ;
            Branch_MICRCode.ParameterName = "@Branch_MICRCode";
            sqlCom.Parameters.Add(Branch_MICRCode);

                SqlParameter Branch_Pincode = new SqlParameter();
            Branch_Pincode.SqlDbType = SqlDbType.VarChar;
            Branch_Pincode.Value =txtBranchPincode.Text.ToString().Trim() ;
            Branch_Pincode.ParameterName = "@Branch_Pincode";
            sqlCom.Parameters.Add(Branch_Pincode);

            SqlParameter Status = new SqlParameter();
            Status.SqlDbType = SqlDbType.VarChar;
            Status.Value ="CLEAR";
            Status.ParameterName = "@Status";
            sqlCom.Parameters.Add(Status);

            SqlParameter Str_PUID = new SqlParameter();
            Str_PUID.SqlDbType = SqlDbType.VarChar;
            Str_PUID.Value = txtPUID.Text.Trim();
            Str_PUID.ParameterName = "@PUID";
            sqlCom.Parameters.Add(Str_PUID);

            
            int rows=sqlCom.ExecuteNonQuery();
             
            sqlCon.Close();
            if (rows > 0)
            {

                lblMessage.CssClass = "UpdateMessage";
                lblMessage.Visible = true;
                lblMessage.Text = " Data Successfully Updated!";
            }


        }
        catch (Exception ex)
        {
            lblMessage.CssClass = "ErrorMessage";
            lblMessage.Visible = true;
            lblMessage.Text = ex.Message;
        }
    
    }
    private void Get_BranchList()
    {
        try
        {
            Object SaveUSERInfo = (Object)Session["UserInfo"];

            SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

            sqlCon.Open();
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlCon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "Get_SourceBranhList";
            SqlDataAdapter sqlDA = new SqlDataAdapter();
            sqlDA.SelectCommand = sqlCom;

            SqlParameter BranchId = new SqlParameter();
            BranchId.SqlDbType = SqlDbType.Int;
            BranchId.Value = Convert.ToInt32(((UserInfo.structUSERInfo)(SaveUSERInfo)).BranchId);
            BranchId.ParameterName = "@BranchId";
            sqlCom.Parameters.Add(BranchId);


            DataTable dt = new DataTable();
            sqlDA.Fill(dt);
            sqlCon.Close();

            ddlSourceBranch.DataTextField = "SourceBranchName";
            ddlSourceBranch.DataValueField = "SourceBranchId";
            ddlSourceBranch.DataSource = dt;
            ddlSourceBranch.DataBind();

            ddlSourceBranch.Items.Insert(0, "(Select)");
            ddlSourceBranch.SelectedIndex = 0;



        }
        catch (Exception ex)
        {
            lblMessage.CssClass = "ErrorMessage";
            lblMessage.Visible = true;
            lblMessage.Text = ex.Message;
                
        }
    }
    private void Clear_AllControls()
    {
        try 
        {
            txtAccountHolder.Text = "";
            txtAdd1.Text = "";
            txtAdd2.Text = "";
            txtApplicantCategory.Text = "";
            txtApplicantCity.Text = "";
            txtApplicantDistrict.Text = "";
            txtApplicantLandLineNo.Text = "";
            txtApplicantMobNo.Text = "";
            txtApplicantPincode.Text = "";
            txtApplicantState.Text = "";
            txtApplicationDate.Text = "";
            txtBankAccount.Text = "";
            txtBankName.Text = "";
            txtBranchMICRCode.Text = "";
            txtBranchName.Text = "";
            txtBranchPincode.Text = "";
            txtCheque_DD_date.Text = "";
            txtCheque_ddNo.Text = "";
            txtDateOfBirth.Text = "";
            txtDeliveryCity.Text = "";
            txtDeliveryDelearship.Text = "";
            txtDeliveryState.Text = "";
            txtDraweeBank.Text = "";
            txtEmailId.Text = "";
            txtEmpCode.Text = "";
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtLocation.Text = "";
            txtMiddleName.Text = "";
           
            txtPanNo.Text = "";
            txtPhotoIdProff.Text = "";
            txtPhotoIdProffNo.Text = "";
            txtReceiptDate.Text = "";
            txtSBIBranchCode.Text="";
            txtSellingBank.Text = "";
            ddlApplicant_CategoryList.SelectedIndex = 0;
            ddlApplicant_CategoryList.SelectedIndex = 0;
            ddlEncloser.SelectedIndex = 0;
            ddlForm60601.SelectedIndex = 0;
            ddlGender.SelectedIndex = 0;
            ddlNanoColor.SelectedIndex = 0;
            ddlNanoModelNo.SelectedIndex = 0;
            ddlPhotoIdProff.SelectedIndex = 0;
            ddlReceivedAt.SelectedIndex = 0;
            ddlSalutation.SelectedIndex = 0;
            ddlSourceBranch.SelectedIndex = 0;
            
        }

        catch (Exception ex)
        {
            lblMessage.CssClass = "ErrorMessage";
            lblMessage.Visible = true;
            lblMessage.Text = ex.Message;
        }

    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        try
        { 
        Clear_AllControls();
        }
        catch (Exception ex)
        {
            lblMessage.CssClass = "ErrorMessage";
            lblMessage.Visible = true;
            lblMessage.Text = ex.Message;
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("Menu.aspx", false);
        }
        catch (Exception ex)
        {
            lblMessage.CssClass = "ErrorMessage";
            lblMessage.Visible = true;
            lblMessage.Text = ex.Message;
        }
    }
    protected void btnRetreive_Click(object sender, EventArgs e)
    {
        try 
        {
            Retrive_ApplicationDetails();
        }
        catch (Exception ex)
        {
            lblMessage.CssClass = "ErrorMessage";
            lblMessage.Visible = true;
            lblMessage.Text = ex.Message;
        }
    }
    private void Retrive_ApplicationDetails()
    {
        try
        {

            Object SaveUSERInfo = (Object)Session["UserInfo"];

            SqlConnection sqlCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);

            sqlCon.Open();
            SqlCommand sqlCom = new SqlCommand();
            sqlCom.Connection = sqlCon;
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.CommandText = "Get_ApplicationAllDetails";
            SqlDataAdapter sqlDA = new SqlDataAdapter();
            sqlDA.SelectCommand = sqlCom;

            SqlParameter BranchId = new SqlParameter();
            BranchId.SqlDbType = SqlDbType.Int;
            BranchId.Value = Convert.ToInt32(((UserInfo.structUSERInfo)(SaveUSERInfo)).BranchId);
            BranchId.ParameterName = "@BranchId";
            sqlCom.Parameters.Add(BranchId);

            SqlParameter NanoApplicationNo = new SqlParameter();
            NanoApplicationNo.SqlDbType = SqlDbType.VarChar;
            NanoApplicationNo.Value = txtNanoApplicationNo.Text.Trim();
            NanoApplicationNo.ParameterName = "@NanoApplicationNo";
            sqlCom.Parameters.Add(NanoApplicationNo);


            DataTable dt = new DataTable();
            sqlDA.Fill(dt);
            sqlCon.Close();
            if (dt.Rows.Count > 0)
            {
                lblMessage.Visible = false;
                lblMessage.Text = "";
                Assing_ValuestoControls(dt);
            }
            else
            {
                lblMessage.CssClass = "ErrorMessage";
                lblMessage.Visible = true;
                lblMessage.Text = "No Details Found!";
            }

        }
        catch (Exception ex)
        {
            lblMessage.CssClass = "ErrorMessage";
            lblMessage.Visible = true;
            lblMessage.Text = ex.Message;
        }
    }
    private void Assing_ValuestoControls(DataTable dt)
    { 
            try
            {

                txtPUID.Text =Convert.ToString(dt.Rows[0]["PUID"]);
                txtApplicationDate.Text = Convert.ToString(dt.Rows[0]["NanoApplicationDate"]);
                txtFirstName.Text =Convert.ToString( dt.Rows[0]["Customer_FirstName"]);
                txtMiddleName.Text = Convert.ToString(dt.Rows[0]["Customer_MiddleName"]);
                txtLastName.Text =Convert.ToString( dt.Rows[0]["Customer_LastName"]);
                if (dt.Rows[0]["Customer_Category"]!="")
                { 
                
                }
                ddlApplicant_CategoryList.SelectedValue=Convert.ToString(dt.Rows[0]["Customer_Category"]);
               
                ddlSalutation.SelectedValue  = Convert.ToString(dt.Rows[0]["Customer_Salutation"]);
                ddlNanoModelNo.SelectedValue = Convert.ToString(dt.Rows[0]["Model"]);
                ddlNanoColor.SelectedItem.Text  = Convert.ToString(dt.Rows[0]["Color"]);
                ddlDeliveryList.SelectedValue = Convert.ToString(dt.Rows[0]["Delivery_Store"]);
                ddlSourceBranch.SelectedValue = Convert.ToString(dt.Rows[0]["SourchBranchId"]);
                ddlGender.SelectedValue = Convert.ToString(dt.Rows[0]["Gender"]);
                ddlEncloser.SelectedValue = Convert.ToString(dt.Rows[0]["Enclosers"]);
                ddlPhotoIdProff.SelectedValue = Convert.ToString(dt.Rows[0]["PhotoIdProofType"]);


                txtDateOfBirth.Text= Convert.ToString(dt.Rows[0]["DateOfBirth"]);
                txtAdd1.Text= Convert.ToString(dt.Rows[0]["Correspondence_Address"]);
                txtApplicantCity.Text = Convert.ToString(dt.Rows[0]["Correspondence_City"]);
                txtApplicantPincode.Text = Convert.ToString(dt.Rows[0]["Correspondence_PinCode"]);
                txtApplicantState.Text = Convert.ToString(dt.Rows[0]["Correspondence_State"]);
                txtApplicantLandLineNo.Text = Convert.ToString(dt.Rows[0]["Residence_Phone"]);
                txtApplicantMobNo.Text = Convert.ToString(dt.Rows[0]["MobileNo"]);
                txtEmailId.Text = Convert.ToString(dt.Rows[0]["EmailAddress"]);
                txtPanNo.Text = Convert.ToString(dt.Rows[0]["PANNo"]);

                if (dt.Rows[0]["Form60"]== "Form60")
                {
                    ddlForm60601.SelectedValue = "Form60";
                }
                else if (dt.Rows[0]["Form61"] == "Form61")
                {
                    ddlForm60601.SelectedValue = "Form61";
                }
                else 
                {
                    ddlForm60601.SelectedValue  = "(Select)";
                }
                
                txtEmpCode.Text = Convert.ToString(dt.Rows[0]["EmployeeName"]);

               
                txtDeliveryCity.Text = Convert.ToString(dt.Rows[0]["Delivery_City"]);
                txtDeliveryState.Text = Convert.ToString(dt.Rows[0]["Delivery_State"]);
                txtDeliveryDelearship.Text = Convert.ToString(dt.Rows[0]["Delearship_Name"]);

               
               

                txtPhotoIdProffNo.Text= Convert.ToString(dt.Rows[0]["PhotoIdProffNo"]);
                txtLocation.Text = Convert.ToString(dt.Rows[0]["Location"]);
                txtAccountHolder.Text = Convert.ToString(dt.Rows[0]["AccounHolder_Name"]);
                txtBankAccount.Text = Convert.ToString(dt.Rows[0]["BankAccount_No"]);
                txtBankName.Text = Convert.ToString(dt.Rows[0]["BankName"]);

                txtBranchName.Text = Convert.ToString(dt.Rows[0]["Branch_Name"]);
                txtBranchMICRCode.Text = Convert.ToString(dt.Rows[0]["Branch_MICRCode"]);
                txtBranchPincode.Text = Convert.ToString(dt.Rows[0]["Branch_Pincode"]);
                txtCheque_ddNo.Text = Convert.ToString(dt.Rows[0]["Pay_ChqDDNo"]);
                txtDraweeBank.Text = Convert.ToString(dt.Rows[0]["Pay_DraweeBank"]);
                txtCheque_DD_date.Text = Convert.ToString(dt.Rows[0]["Pay_ChqDD_Date"]);
                txtSellingBank.Text = Convert.ToString(dt.Rows[0]["Pay_BankingBranch"]);

                chkRentention1.Checked = Convert.ToBoolean(dt.Rows[0]["RententionBook1"]);
                chkRentention2.Checked = Convert.ToBoolean(dt.Rows[0]["RententionBook2"]);
                txtStatus.Text = Convert.ToString(dt.Rows[0]["Status"]);

                txtReportSentDate.Text = Convert.ToString(dt.Rows[0]["ReportSentDate"]);
                if (txtReportSentDate.Text != "")
                {
                    btnSave.Enabled = false;                 
                }



            }
            catch (Exception ex)
            {
            lblMessage.CssClass = "ErrorMessage";
            lblMessage.Visible = true;
            lblMessage.Text = ex.Message;
            }
    
    
    }
}
