using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LNTFinance.Pages
{
    public partial class MenuPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Object SaveUSERInfo = (Object)Session["UserInfo"];

                if (Session["UserInfo"] == null)
                {
                    Response.Redirect("LNT_InvalidRequest.aspx", true);
                }
                else
                {
                    if (!IsPostBack)
                    {
                        Load_UserStatus();
                    }
                }
            }
            catch
            {

            }
        }
        private void Load_UserStatus()
        {
            try
            {
                if (Session["UserInfo"] == null)
                {
                    Response.Redirect("LNT_InvalidRequest.aspx", false);
                }
                else
                {
                    Object SaveUSERInfo = (Object)Session["UserInfo"];
                    lblUserName.Text = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).LoginName);
                    lblBranch.Text = "MUMBAI";
                    lblRole.Text = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).RoleName);
                    lblClient.Text = Convert.ToString(((UserInfo.structUSERInfo)(SaveUSERInfo)).ClientName);


                    int intMonth = Convert.ToInt32(DateTime.Now.Month);

                    lblMonth.Text = Get_MonthName(intMonth);
                    lblDate.Text = DateTime.Now.Day.ToString();


                }
            }
            catch (Exception ex)
            {

            }
        }
        private string Get_MonthName(int intMonth)
        {
            string Month = "";
            if (intMonth == 1)
            {
                Month = "Jan";
            }
            else if (intMonth == 2)
            {
                Month = "Feb";
            }
            else if (intMonth == 3)
            {
                Month = "Mar";
            }
            else if (intMonth == 4)
            {
                Month = "Apr";
            }
            else if (intMonth == 5)
            {
                Month = "May";
            }
            else if (intMonth == 6)
            {
                Month = "Jun";
            }
            else if (intMonth == 7)
            {
                Month = "Jul";
            }
            else if (intMonth == 8)
            {
                Month = "Aug";
            }
            else if (intMonth == 9)
            {
                Month = "Sep";
            }
            else if (intMonth == 10)
            {
                Month = "Oct";
            }
            else if (intMonth == 11)
            {
                Month = "Nov";
            }
            else if (intMonth == 12)
            {
                Month = "Dec";
            }

            return Month;
        }
    }
}