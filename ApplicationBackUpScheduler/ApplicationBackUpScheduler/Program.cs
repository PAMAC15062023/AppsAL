using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationBackUpScheduler
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string rootPath = @"D:\UAT_Applications\";
                string[] dirs = Directory.GetDirectories(rootPath, "*", SearchOption.AllDirectories);

                foreach (string dir in dirs)
                {




                    var directory = new DirectoryInfo(dir);
                    DateTime from_date = DateTime.Now.AddDays(-8);
                    DateTime to_date = DateTime.Now;

                    var files = directory.GetFiles().Where(file => file.LastWriteTime >= from_date && file.LastWriteTime <= to_date);

                    foreach (var i in files)
                    {
                        string file = directory + "\\" + i.ToString();

                        //string str = Server.MapPath("~/Pages/Inword Tracking Module/Copy/") + i.ToString();


                        string targetfile = directory.ToString().Replace("D:\\UAT_Applications\\", "E:\\UATApplicationBackUp\\");



                        if (!Directory.Exists(targetfile))
                        {
                            Directory.CreateDirectory(targetfile);
                        }


                        string str = targetfile + "\\" + i.ToString(); // Server.MapPath("@E:/BackUp/") + i.ToString();

                        if (File.Exists(str))
                        {
                            File.Delete(str);
                        }


                        File.Copy(file, str);
                    }



                }


                //var directory = new DirectoryInfo((Server.MapPath("~/Pages/Inword Tracking Module/")));
                //DateTime from_date = DateTime.Now.AddDays(-40);
                //DateTime to_date = DateTime.Now;
                //var a =  directory.GetDirectories();



                //var files = directory.GetFiles().Where(file => file.LastWriteTime >= from_date && file.LastWriteTime <= to_date);

                //foreach (var i in files)
                //{
                //    Console.WriteLine(i);

                //    string file = directory + i.ToString();
                //    string str = Server.MapPath("~/Pages/Inword Tracking Module/Copy/") + i.ToString();

                //    File.Copy(file, str);

                //}
            }
            catch (Exception ex)
            {

            }
        }
    }
}
