using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Globalization;

namespace EmployeeDetailsEasyHRToPMS
{
    class Program
    {
        static void Main(string[] args)
        {
            var objProgram = new Program();
            objProgram.Loaddata();
        }
        public void Loaddata()
        {
            try
            {
                string html = string.Empty;
                string url = @"https://pamac.easyhrworld.com/api/v2/Pamac/getRes?X-API-KEY=b43fa3ab7fc0ea078573fba9b02c98dcd611f2a8&Accept=application/json";
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.AutomaticDecompression = DecompressionMethods.GZip;
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                using (Stream stream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(stream))
                {
                    html = reader.ReadToEnd();//
                    reader.Close();

                    string s = html.Replace(@"\", string.Empty);

                    List<Employee> employee = new List<Employee>();
                    employee = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Employee>>(s);

                    DataTable dt = new DataTable();

                    dt.Columns.Add("zone");
                    dt.Columns.Add("employee_code");
                    dt.Columns.Add("employee_name");
                    dt.Columns.Add("mobile_phone");
                    dt.Columns.Add("pannumber");
                    dt.Columns.Add("dateofbirth");
                    dt.Columns.Add("dateofjoin");
                    dt.Columns.Add("dateofleaving");


                    foreach (Employee emp in employee)
                    {

                        var dateAndTime = DateTime.Now;
                        DateTime yesterday = dateAndTime.AddDays(-1);
                        //var date = yesterday.Date;

                        var date = Convert.ToDateTime("2024-09-24");

                        string DateFormat = "dd-MM-yyyy";

                        emp.dateofjoin = emp.dateofjoin.Replace("/", "-");
                        string DOJ = emp.dateofjoin;
                        DateTime DateOfJoin = DateTime.ParseExact(DOJ, DateFormat, CultureInfo.InvariantCulture);

                        emp.dateofleaving = emp.dateofleaving.Replace("/", "-");
                        string DOL = emp.dateofleaving;
                        DateTime DateOfLeaving = DateTime.ParseExact(DOL, DateFormat, CultureInfo.InvariantCulture);


                        if (date == DateOfJoin || date == DateOfLeaving)
                        {

                            if (emp.dateofleaving == "01-01-0101" || emp.dateofleaving == "01-01-1900")
                            {
                                emp.dateofleaving = null;
                            }

                            DataRow row = dt.NewRow();
                            row["zone"] = emp.zone;
                            row["employee_code"] = emp.employee_code;
                            row["employee_name"] = emp.employee_name;
                            row["mobile_phone"] = emp.mobile_phone;
                            row["pannumber"] = emp.pannumber;
                            row["dateofbirth"] = emp.dateofbirth;
                            row["dateofjoin"] = emp.dateofjoin;
                            row["dateofleaving"] = emp.dateofleaving;
                            dt.Rows.Add(row);
                        }
                    }

                    if (dt.Rows.Count > 0)
                    {
                        int count = 0;
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            string zone = dt.Rows[i]["zone"].ToString().ToUpper();
                            string Empcode = dt.Rows[i]["employee_code"].ToString().ToUpper();
                            if (zone != "" && Empcode != "")
                            {
                                CCommon objConn = new CCommon();
                                //SqlConnection sqlcon = new SqlConnection(ConfigurationManager.AppSettings[zone + "constring"].ToString());
                                SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
                                sqlcon.Open();
                                SqlCommand sqlcmd = new SqlCommand();
                                sqlcmd.Connection = sqlcon;
                                sqlcmd.CommandType = CommandType.StoredProcedure;
                                sqlcmd.CommandText = "Updatedata1new12N20";
                                sqlcmd.CommandTimeout = 360;
                                sqlcmd.Parameters.AddWithValue("@zone", dt.Rows[i]["zone"].ToString());
                                sqlcmd.Parameters.AddWithValue("@employee_code", dt.Rows[i]["employee_code"].ToString());
                                sqlcmd.Parameters.AddWithValue("@employee_name", dt.Rows[i]["employee_name"].ToString());
                                sqlcmd.Parameters.AddWithValue("@mobile_phone", dt.Rows[i]["mobile_phone"].ToString());
                                sqlcmd.Parameters.AddWithValue("@pannumber", dt.Rows[i]["pannumber"].ToString());
                                sqlcmd.Parameters.AddWithValue("@dateofbirth", dt.Rows[i]["dateofbirth"].ToString());
                                sqlcmd.Parameters.AddWithValue("@dateofjoin", dt.Rows[i]["dateofjoin"].ToString());
                                sqlcmd.Parameters.AddWithValue("@dateofleaving", dt.Rows[i]["dateofleaving"].ToString());

                                int RowEffected = 0;

                                RowEffected = sqlcmd.ExecuteNonQuery();

                                if (RowEffected > 0)
                                {
                                    //lblMessage.Text = "Data Import Successfully";

                                }
                                else
                                {

                                    //lblMessage.Text = "No Fresh Data Available..!";
                                }
                                sqlcon.Close();
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                //lblMessage.Text = "Error" + ex.Message;
            }
        }
        public class Employee
        {
            public string zone;
            public string employee_name;
            public string center;
            public string sub_center;
            public string employee_code;
            public string dateofbirth;
            public string dateofjoin;
            public string mobile_phone;
            public string activity;
            public string client;
            public string product;
            public string pannumber;
            public string dateofleaving;
            public string dateofresignation;
            public string accountno;
        }
        public class CCommon
        {
            public string AppConnectionString
            {
                get
                {
                    string zone;
                    zone = "West";// HttpContext.Current.Session["Zone"].ToString();
                    return (ConfigurationManager.AppSettings[zone + "constring"].ToString());
                }
            }
        }
    }
}
