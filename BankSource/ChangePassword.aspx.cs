// Decompiled with JetBrains decompiler
// Type: ChangePassword
// Assembly: App_Web_changepassword.aspx.cdcab7d2, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5330E35A-1F54-48E8-9542-F64D3FD183B0
// Assembly location: D:\RK\RAMKI CONSULTANCY\PAMAC\Technology support\Projects\HDFC Bank\Decompiled source\App_Web_changepassword.aspx.cdcab7d2.dll

using myinfo;
using System;
using System.Data;
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

public class ChangePassword : Page, IRequiresSessionState
{
  protected HtmlHead Head1;
  protected Label lblMsg;
  protected TextBox txtOldPwd;
  protected RequiredFieldValidator rfvOld;
  protected TextBox txtNewPwd;
  protected RequiredFieldValidator rfvNew;
  protected CompareValidator cmvNewOld;
  protected TextBox txtConfirmPwd;
  protected CompareValidator cmvConfirmNew;
  protected RequiredFieldValidator rfvConfirm;
  protected ASPNET_Captcha.ASPNET_Captcha ucCaptcha;
  protected TextBox txtCaptcha;
  protected Label lblMessage;
  protected RegularExpressionValidator regExAlphabets;
  protected RegularExpressionValidator RegExSpecialChar;
  protected RegularExpressionValidator RegularExpressionValidator2;
  protected RegularExpressionValidator RegularExpressionValidator1;
  protected Button btnSave;
  protected Button btnCancel;
  protected HiddenField HiddenField1;
  protected HiddenField Hidnvalue;
  protected HiddenField HiddenField2;
  protected ValidationSummary ValidationSummary1;
  protected HtmlForm form1;
  private Info obj = new Info();
  private string strDecpript;
  private string oldpass;
  private string Newpass;
  private string DecrOldpass;

  protected DefaultProfile Profile => (DefaultProfile) this.Context.Profile;

  protected HttpApplication ApplicationInstance => this.Context.ApplicationInstance;

  private void Page_Init(object sender, EventArgs e)
  {
    if (this.Session.Count != 0)
      return;
    this.Session.Abandon();
    this.Response.Redirect("~/InvalidRequest.aspx");
  }

  protected void Page_Load(object sender, EventArgs e)
  {
    this.Hidnvalue.Value = "0";
    if (!this.IsPostBack)
    {
      if (this.Request.QueryString["Err"] != null)
      {
        this.lblMsg.Visible = true;
        this.lblMsg.CssClass = "ErrorMessage";
        this.lblMsg.Text = this.Request.QueryString["Err"].ToString();
        if (this.Request.QueryString["Err"].ToString() == "Please Change your Password , your password is set by admin!")
          this.Hidnvalue.Value = "2";
        else if (this.Request.QueryString["Err"].ToString() == "Please Change your Password , your reached the days limit!")
          this.Hidnvalue.Value = "2";
        else if (this.Request.QueryString["Err"].ToString() == "Please Change your Password ,Your Password has been Expired!")
        {
          this.Hidnvalue.Value = "2";
        }
        else
        {
          this.Call();
          this.token();
        }
      }
      else
        this.btnCancel.Visible = true;
    }
    this.Session["userid"].ToString();
  }

  public void Call()
  {
    string str = this.Session["userid"].ToString();
    DataSet dataSet1 = new DataSet();
    DataSet dataSet2 = this.obj.NewMethod(str);
    if (dataSet2.Tables[0].Rows.Count > 0)
      this.Session["Old"] = (object) dataSet2.Tables[0].Rows[0]["log_det_id"].ToString();
    if (!(this.Session["LogId"].ToString() != this.Session["Old"].ToString()))
      return;
    this.Response.Redirect("~/OldSession.aspx");
  }

  protected void btnSave_Click(object sender, EventArgs e)
  {
    this.strDecpript = ChangePassword.DecryptStringAES(this.HiddenField2.Value);
    this.oldpass = ChangePassword.DecryptStringAES(this.HiddenField1.Value);
    if (this.Hidnvalue.Value != "2")
    {
      DataSet dataSet = new DataSet();
      string str = CEncDec.Decrypt(this.obj.GetPass().Tables[0].Rows[0]["password"].ToString(), "AKR");
      int length1 = str.Length;
      int length2 = this.oldpass.Length;
      int length3 = this.strDecpript.Length;
      int startIndex = (length2 - length1) / 2;
      this.DecrOldpass = this.oldpass.Substring(startIndex, length1);
      this.Newpass = this.strDecpript.Substring(startIndex, length3 - startIndex * 2);
      if (this.DecrOldpass == str)
      {
        if (this.Check_Password(this.Newpass))
        {
          this.savepass();
        }
        else
        {
          this.lblMsg.Visible = true;
          this.lblMsg.CssClass = "ErrorMessage";
          this.lblMsg.Text = "Your password is not complying with Standard Password Policy!";
        }
      }
      else
      {
        this.lblMsg.Visible = true;
        this.lblMsg.CssClass = "ErrorMessage";
        this.lblMsg.Text = "Wrong Old Password";
      }
    }
    else if (this.Check_Password(this.Newpass))
    {
      this.savepass();
    }
    else
    {
      this.lblMsg.Visible = true;
      this.lblMsg.CssClass = "ErrorMessage";
      this.lblMsg.Text = "Your password is not complying with Standard Password Policy!";
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

  public void savepass()
  {
    try
    {
      if (this.ucCaptcha.Validate(this.txtCaptcha.Text.Trim()))
      {
        CChangePwd cchangePwd = new CChangePwd();
        cchangePwd.NewPwd = CEncDec.Encrypt(this.Newpass, "AKR");
        cchangePwd.OldPwd = CEncDec.Encrypt(this.DecrOldpass, "AKR");
        cchangePwd.UserId = this.Session["UserId"].ToString();
        cchangePwd.UserpasswordVerify();
        if (cchangePwd.Status1 == "1")
        {
          this.lblMsg.Visible = true;
          this.lblMsg.CssClass = "ErrorMessage";
          this.lblMsg.Text = "You Cant Set Password Same As Old Password";
        }
        cchangePwd.UserAuthenticate();
        CLogin clogin = new CLogin();
        clogin.UserId = this.Session["UserId"].ToString();
        clogin.CentreId = this.Session["CentreId"].ToString();
        clogin.RoleId = this.Session["RoleId"].ToString();
        clogin.InsertLoginDetail_ChangePass();
        this.Session["LogID"] = (object) clogin.LogId;
        this.lblMsg.Visible = true;
        this.lblMsg.CssClass = "UpdateMessage";
        this.lblMsg.Text = "Password has been reset,Please login Again!";
        this.btnCancel.Visible = false;
        this.txtNewPwd.ReadOnly = true;
        this.txtOldPwd.ReadOnly = true;
        this.txtConfirmPwd.ReadOnly = true;
        this.btnSave.Enabled = false;
        this.Response.Redirect("Client.aspx");
      }
      else
      {
        this.lblMessage.Text = "Invalid!";
        this.lblMessage.ForeColor = Color.Red;
      }
    }
    catch (Exception ex)
    {
      this.lblMsg.Visible = true;
      this.lblMsg.CssClass = "ErrorMessage";
      this.lblMsg.Text = ex.Message;
    }
  }

  protected void btnCancel_Click(object sender, EventArgs e) => this.Response.Redirect("~/HDFCBANK/HDFCBANK/Default.aspx");

  public void token()
  {
    DataSet dataSet = new DataSet();
    DataSet tokenUpdate = this.obj.Get_TokenUpdate();
    if (this.Session["Token"].ToString() == tokenUpdate.Tables[0].Rows[0]["Token"].ToString())
    {
      this.Session.Remove("Token");
      int num = new Random().Next();
      this.obj.UpdateTokenDetail(num);
      this.Session["Token"] = (object) num;
    }
    else
      this.Response.Redirect("~/Error20.aspx");
  }

  public static string DecryptStringAES(string ciphertext)
  {
    byte[] bytes1 = Encoding.UTF8.GetBytes("7061737323313233");
    byte[] bytes2 = Encoding.UTF8.GetBytes("7061737323313233");
    return ChangePassword.DecryptStringFromBytes(Convert.FromBase64String(ciphertext), bytes1, bytes2);
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
}
