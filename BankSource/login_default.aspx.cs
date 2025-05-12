// Decompiled with JetBrains decompiler
// Type: Login
// Assembly: App_Web_default.aspx.cdcab7d2, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 98010503-C83C-4966-9EC5-A12CCEC2C8FE
// Assembly location: D:\RK\RAMKI CONSULTANCY\PAMAC\Technology support\Projects\HDFC Bank\Decompiled source\App_Web_default.aspx.cdcab7d2.dll

using myinfo;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public class Login : Page, IRequiresSessionState
{
  protected Label lblMsg;
  protected TextBox txtUserName;
  protected RequiredFieldValidator rfvUserName;
  protected TextBox txtPassword;
  protected RequiredFieldValidator rfvPassword;
  protected DropDownList ddlCenter;
  protected RequiredFieldValidator rfvCenter;
  protected ASPNET_Captcha.ASPNET_Captcha ucCaptcha;
  protected Label lblMessage;
  protected TextBox txtCaptcha;
  protected Button btnSubmit;
  protected ValidationSummary vsLogin;
  protected Label Label1;
  protected Panel pnlLogin;
  protected SqlDataSource sdsCenter;
  protected HiddenField HiddenField1;
  protected HtmlForm form1;
  private Info obj = new Info();
  private SqlConnection sqlcon;
  private CCommon objConn = new CCommon();
  private Info objInfo = new Info();
  private string getDecryptpass;
  private string pass;
  private string DecrOldpass;

  protected DefaultProfile Profile => (DefaultProfile) this.Context.Profile;

  protected HttpApplication ApplicationInstance => this.Context.ApplicationInstance;

  private void Page_Init(object sender, EventArgs e)
  {
  }

  protected void Page_Load(object sender, EventArgs e)
  {
    try
    {
      this.Response.CacheControl = "no-cache";
      if (!this.IsPostBack)
      {
        this.Session.Abandon();
        this.Response.Cache.SetCacheability(HttpCacheability.NoCache);
        this.Response.Cookies.Add(new HttpCookie("ASP.NET_SessionId", ""));
      }
      HttpContext.Current.Session["Zone"] = (object) this.Request.QueryString["zone"];
      CCommon ccommon = new CCommon();
      this.sqlcon = new SqlConnection(ccommon.AppConnectionString);
      this.sdsCenter.ConnectionString = ccommon.ConnectionString;
      this.lblMsg.Text = "";
      this.txtUserName.Focus();
      if (this.Request.QueryString["Message"] == null)
      {
        if (this.Request.QueryString["HelpId"] != null)
          ;
      }
      else
        this.lblMsg.Text = this.Request.QueryString["Message"].ToString();
    }
    catch (Exception ex)
    {
      this.lblMsg.Text = ex.Message;
    }
  }

  protected void Session_Start(object sender, EventArgs e)
  {
  }

  protected void btnLogin_Click(object sender, EventArgs e)
  {
    try
    {
      if (this.ucCaptcha.Validate(this.txtCaptcha.Text.Trim()))
      {
        this.pass = Login.DecryptStringAES(this.HiddenField1.Value);
        DataSet dataSet = new DataSet();
        this.getDecryptpass = CEncDec.Decrypt(this.obj.GetPasslogin(this.txtUserName.Text.Trim()).Tables[0].Rows[0]["password"].ToString(), "AKR");
        int length = this.pass.Length;
        this.DecrOldpass = this.pass.Substring(0, this.getDecryptpass.Length);
        CLogin clogin = new CLogin();
        clogin.UserName = this.txtUserName.Text;
        clogin.Password = CEncDec.Encrypt(this.DecrOldpass, "AKR");
        clogin.CentreId = this.ddlCenter.SelectedValue;
        string str1 = clogin.UserAuthenticate();
        if (str1 == "0" && clogin.RoleId == null)
          str1 = "2";
        switch (str1)
        {
          case "0":
            this.Session["CentreId"] = (object) clogin.CentreId;
            this.Session["SubCentreID"] = (object) clogin.GetSubCenter();
            this.Session["Prefix"] = (object) clogin.Prefix;
            this.Session["HierarchyId"] = (object) clogin.HierarchyId;
            this.Session["HierLevel"] = (object) clogin.UserLevel.ToString();
            this.Session["RoleId"] = (object) clogin.RoleId;
            this.Session["UserId"] = (object) clogin.UserId;
            this.Session["LogId"] = (object) clogin.LogId;
            this.Session["FLName"] = (object) clogin.FLName;
            this.Session["UserName"] = (object) clogin.UserName;
            this.Session["CentreCode"] = (object) this.ddlCenter.SelectedItem.Text;
            this.Session["ClusterId"] = (object) clogin.GetCluster();
            string str2 = Guid.NewGuid().ToString();
            this.Session["AuthToken"] = (object) str2;
            this.Response.Cookies.Add(new HttpCookie("AuthToken", str2));
            if (this.Check_SystemPassword())
            {
              if (!(this.getDecryptpass == this.DecrOldpass))
                break;
              int num = new Random().Next();
              clogin.InsertLoginDetail();
              this.Session["LogID"] = (object) clogin.LogId;
              this.Session["Token"] = (object) num;
              this.Session["LogID"].ToString();
              this.logedindetails();
              this.Get_EmployeeDetails();
              this.objInfo.InsertTokenDetail();
              break;
            }
            this.Response.Redirect("~/ChangePassword.aspx?Err=" + this.lblMsg.Text.Trim(), false);
            break;
          case "1":
            this.lblMsg.Text = "Invalid Username or Password";
            this.lblMessage.Text = "";
            this.txtCaptcha.Text = "";
            break;
          case "2":
            this.lblMsg.Text = "Please verify your centre as you are not authorised for this centre";
            this.lblMessage.Text = "";
            this.txtCaptcha.Text = "";
            break;
          default:
            this.lblMsg.Text = "Invalid input";
            break;
        }
      }
      else
      {
        this.lblMessage.Text = "Invalid!";
        this.lblMessage.ForeColor = Color.Red;
      }
    }
    catch (Exception ex)
    {
      this.lblMsg.Text = "Invalid Username or Password";
    }
  }

  public static string DecryptStringAES(string ciphertext)
  {
    byte[] bytes1 = Encoding.UTF8.GetBytes("7061737323313233");
    byte[] bytes2 = Encoding.UTF8.GetBytes("7061737323313233");
    return Login.DecryptStringFromBytes(Convert.FromBase64String(ciphertext), bytes1, bytes2);
  }

  private static string DecryptStringFromBytes(byte[] cipherText, byte[] key, byte[] iv)
  {
    if (cipherText == null || cipherText.Length <= 0)
      throw new ArgumentNullException(nameof (cipherText));
    if (key == null || key.Length <= 0)
      throw new ArgumentNullException(nameof (key));
    if (iv == null || iv.Length <= 0)
      throw new ArgumentNullException(nameof (key));
    using (RijndaelManaged rijndaelManaged = new RijndaelManaged())
    {
      rijndaelManaged.Mode = CipherMode.CBC;
      rijndaelManaged.Padding = PaddingMode.PKCS7;
      rijndaelManaged.FeedbackSize = 128;
      rijndaelManaged.Key = key;
      rijndaelManaged.IV = iv;
      using (MemoryStream memoryStream = new MemoryStream(cipherText))
      {
        using (CryptoStream cryptoStream = new CryptoStream((Stream) memoryStream, rijndaelManaged.CreateDecryptor(rijndaelManaged.Key, rijndaelManaged.IV), CryptoStreamMode.Read))
        {
          using (StreamReader streamReader = new StreamReader((Stream) cryptoStream))
            return streamReader.ReadToEnd();
        }
      }
    }
  }

  public static string EncryptString(string InputText, string Key)
  {
    RijndaelManaged rijndaelManaged = new RijndaelManaged();
    byte[] bytes1 = Encoding.Unicode.GetBytes(InputText);
    byte[] bytes2 = Encoding.ASCII.GetBytes(Key.Length.ToString());
    PasswordDeriveBytes passwordDeriveBytes = new PasswordDeriveBytes(Key, bytes2);
    ICryptoTransform encryptor = rijndaelManaged.CreateEncryptor(passwordDeriveBytes.GetBytes(32), passwordDeriveBytes.GetBytes(16));
    MemoryStream memoryStream = new MemoryStream();
    CryptoStream cryptoStream = new CryptoStream((Stream) memoryStream, encryptor, CryptoStreamMode.Write);
    cryptoStream.Write(bytes1, 0, bytes1.Length);
    cryptoStream.FlushFinalBlock();
    byte[] array = memoryStream.ToArray();
    memoryStream.Close();
    cryptoStream.Close();
    return Convert.ToBase64String(array);
  }

  public static string DecryptString(string InputText, string Key)
  {
    RijndaelManaged rijndaelManaged = new RijndaelManaged();
    byte[] buffer = Convert.FromBase64String(InputText);
    byte[] bytes = Encoding.ASCII.GetBytes(Key.Length.ToString());
    PasswordDeriveBytes passwordDeriveBytes = new PasswordDeriveBytes(Key, bytes);
    ICryptoTransform decryptor = rijndaelManaged.CreateDecryptor(passwordDeriveBytes.GetBytes(32), passwordDeriveBytes.GetBytes(16));
    MemoryStream memoryStream = new MemoryStream(buffer);
    CryptoStream cryptoStream = new CryptoStream((Stream) memoryStream, decryptor, CryptoStreamMode.Read);
    byte[] numArray = new byte[buffer.Length];
    int count = cryptoStream.Read(numArray, 0, numArray.Length);
    memoryStream.Close();
    cryptoStream.Close();
    return Encoding.Unicode.GetString(numArray, 0, count);
  }

  private void Get_EmployeeDetails()
  {
    this.Label1.Text = this.Request.UserHostName.ToString();
    if (this.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] == null)
      this.Label1.Text = this.Request.ServerVariables["REMOTE_ADDR"];
    SqlCommand sqlCommand = new SqlCommand();
    sqlCommand.Connection = this.sqlcon;
    sqlCommand.CommandType = CommandType.StoredProcedure;
    sqlCommand.CommandText = "Get_EmployeeDetails_HDFC_Client";
    sqlCommand.CommandTimeout = 0;
    SqlParameter sqlParameter1 = new SqlParameter();
    sqlParameter1.SqlDbType = SqlDbType.VarChar;
    sqlParameter1.Value = (object) this.Session["userid"].ToString();
    sqlParameter1.ParameterName = "@Emp_id";
    sqlCommand.Parameters.Add(sqlParameter1);
    SqlParameter sqlParameter2 = new SqlParameter();
    sqlParameter2.SqlDbType = SqlDbType.NVarChar;
    sqlParameter2.Value = (object) this.Label1.Text.Trim();
    sqlParameter2.ParameterName = "@STIP";
    sqlCommand.Parameters.Add(sqlParameter2);
    this.sqlcon.Open();
    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
    sqlDataAdapter.SelectCommand = sqlCommand;
    DataSet dataSet = new DataSet();
    sqlDataAdapter.Fill(dataSet);
    this.sqlcon.Close();
    if (dataSet.Tables[0].Rows.Count <= 0)
      return;
    if (dataSet.Tables[1].Rows.Count > 0)
    {
      this.Session["ProductId"] = (object) dataSet.Tables[2].Rows[0]["Product_Id"].ToString();
      this.Session["ActivityId"] = (object) dataSet.Tables[2].Rows[0]["Activity_Id"].ToString();
      this.Response.Redirect("~/HDFCBANK/HDFCBANK/Default.aspx", false);
    }
    else
      this.Response.Redirect("~/Error20.aspx");
  }

  protected void logedindetails()
  {
    try
    {
      SqlConnection sqlConnection = new SqlConnection(new CCommon().AppConnectionString);
      sqlConnection.Open();
      SqlCommand sqlCommand = new SqlCommand();
      sqlCommand.Connection = sqlConnection;
      sqlCommand.CommandType = CommandType.StoredProcedure;
      sqlCommand.CommandText = "Sp_Login_Details_2";
      sqlCommand.CommandTimeout = 0;
      SqlParameter sqlParameter = new SqlParameter();
      sqlParameter.SqlDbType = SqlDbType.VarChar;
      sqlParameter.Value = (object) this.Session["userid"].ToString().Trim();
      sqlParameter.ParameterName = "@LoginName";
      sqlCommand.Parameters.Add(sqlParameter);
      SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
      sqlDataAdapter.SelectCommand = sqlCommand;
      DataTable dataTable = new DataTable();
      sqlDataAdapter.Fill(dataTable);
      sqlConnection.Close();
      if (dataTable.Rows.Count <= 0)
        return;
      this.Session["Old"] = (object) dataTable.Rows[0]["log_det_id"].ToString();
    }
    catch (Exception ex)
    {
      this.lblMsg.Text = ex.Message;
    }
  }

  private bool Check_SystemPassword()
  {
    try
    {
      switch (Convert.ToInt16(OleDbHelper.ExecuteScalar(new CCommon().ConnectionString, CommandType.Text, "Exec Get_UserPasswordStatus @LoginId='" + this.txtUserName.Text.Trim() + "' ,@ReturnValue=null ")))
      {
        case 1:
          this.lblMsg.Text = "Please Change your Password ,Your Password has been Expired!";
          return false;
        case 2:
          this.lblMsg.Text = "Please Change your Password , your password is set by admin!";
          return false;
        case 3:
          this.lblMsg.Text = "Please Change your Password , your reached the days limit!";
          return false;
        default:
          if (this.Check_Password(this.DecrOldpass))
            return true;
          this.lblMsg.Text = "Your password is not complying with Standard Password Policy!";
          return false;
      }
    }
    catch (Exception ex)
    {
      this.lblMsg.Text = ex.Message;
      return false;
    }
  }

  private bool Check_Password(string pstrPassword)
  {
    try
    {
      this.lblMsg.Text = "";
      bool flag1 = false;
      bool flag2 = false;
      bool flag3 = false;
      string str = pstrPassword;
      if (str.Length < 8)
      {
        this.lblMsg.Text = "Password Length should be minimum equals to 8 char";
        return false;
      }
      string[] strArray1 = new string[6]
      {
        "@",
        "#",
        "$",
        "%",
        "_",
        "^"
      };
      strArray1[5] = "*";
      for (int index1 = 0; index1 <= strArray1.Length - 1; ++index1)
      {
        for (int index2 = 0; index2 <= str.Length - 1; ++index2)
        {
          if (Convert.ToString(str[index2]) == strArray1[index1].ToString())
            flag2 = true;
        }
      }
      if (!flag2)
      {
        this.lblMsg.Text = "your password should contains any of the special char!";
        return false;
      }
      string[] strArray2 = new string[26]
      {
        "Z",
        "A",
        "B",
        "C",
        "D",
        "E",
        "F",
        "G",
        "H",
        "I",
        "J",
        "K",
        "L",
        "M",
        "N",
        "O",
        "P",
        "Q",
        "R",
        "S",
        "T",
        "U",
        "V",
        "W",
        "X",
        "Y"
      };
      for (int index1 = 0; index1 <= strArray2.Length - 1; ++index1)
      {
        for (int index2 = 0; index2 <= str.Length - 1; ++index2)
        {
          if (Convert.ToString(str[index2].ToString().ToUpper()) == strArray2[index1].ToString())
            flag3 = true;
        }
      }
      if (!flag3)
      {
        this.lblMsg.Text = "your password should contains any of the Alphabets!";
        return false;
      }
      int[] numArray = new int[10]
      {
        0,
        1,
        2,
        3,
        4,
        5,
        6,
        7,
        8,
        9
      };
      for (int index1 = 0; index1 <= numArray.Length - 1; ++index1)
      {
        for (int index2 = 0; index2 <= str.Length - 1; ++index2)
        {
          if (str[index2].ToString() == numArray[index1].ToString())
            flag1 = true;
        }
      }
      if (flag1)
        return true;
      this.lblMsg.Text = "your password should contains any of the Numeric!";
      return false;
    }
    catch (Exception ex)
    {
      this.lblMsg.Text = ex.Message;
      return false;
    }
  }
}
