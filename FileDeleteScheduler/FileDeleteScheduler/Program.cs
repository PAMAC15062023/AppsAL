using System;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;

namespace FileDeleteScheduler
{
    class Program
    {
        static void Main(string[] args)
        {
            var objProgram = new Program();

            var _directoryPath = "";
            var _directoryPath2 = "";
            var _userName = "";
            var _password = "";
            string UserId = string.Empty;
            string UserName = string.Empty;

            try
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand("SP_GetMachinePath", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter adp = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adp.Fill(dt);

                    if (dt != null && dt.Rows.Count > 0)
                    {
                        foreach (DataRow row in dt.Rows)
                        {
                            _directoryPath = row["MachinePath"].ToString();
                            _directoryPath2 = row["FolderPath"].ToString();
                            _userName = row["MachineUserId"].ToString();
                            _password = row["MachinePassword"].ToString();
                            UserId = row["UserId"].ToString();
                            UserName = row["UserName"].ToString();

                            try
                            {
                                using (new NetworkConnection(_directoryPath, new NetworkCredential(_userName, _password)))
                                {
                                    string path = _directoryPath + _directoryPath2;
                                    path = path.Replace(":", "$");

                                    DirectoryInfo dir_5 = new DirectoryInfo(path);
                                    FileInfo[] fileinfo = dir_5.GetFiles();
                                    foreach (FileInfo file in fileinfo)
                                    {
                                        string File_Name = file.Name;
                                        string filePath = Path.Combine(path, File_Name);

                                        using (SqlCommand cmd2 = new SqlCommand("SP_DeleteUserFile", con))
                                        {
                                            cmd2.CommandType = CommandType.StoredProcedure;
                                            cmd2.Parameters.AddWithValue("@UserId", UserId);
                                            cmd2.Parameters.AddWithValue("@UserName", UserName);
                                            cmd2.Parameters.AddWithValue("@FileName", File_Name);

                                            con.Open();
                                            int result = cmd2.ExecuteNonQuery();
                                            con.Close();

                                            if (result > 0)
                                            {
                                                FileInfo file_ = new FileInfo(filePath);
                                                file_.Delete();
                                            }
                                        }
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                // Log the error related to the network connection or file operations
                                LogException(ex,UserId);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Log the error related to database connection or query execution
                LogException(ex,UserId);
            }

        }
        static void LogException(Exception ex,string Userid)
        {
            // Define the path to the log file
            string logFilePath = "log.txt";

            // Create or append to the log file
            using (StreamWriter writer = new StreamWriter(logFilePath, true))
            {
                writer.WriteLine("Date and Time: " + DateTime.Now);
                writer.WriteLine("Exception Type: " + ex.GetType().ToString());
                writer.WriteLine("Message: "+Userid+":-"+ ex.Message);
                writer.WriteLine("Stack Trace: " + ex.StackTrace);
                writer.WriteLine(new string('-', 80)); // Separator line
            }
        }
        public class NetworkConnection : IDisposable
        {
            #region Variables

            /// <summary>
            /// The full path of the directory.
            /// </summary>
            private readonly string _networkName;

            #endregion

            #region Constructors

            /// <summary>
            /// Initializes a new instance of the <see cref="NetworkConnection"/> class.
            /// </summary>
            /// <param name="networkName">
            /// The full path of the network share.
            /// </param>
            /// <param name="credentials">
            /// The credentials to use when connecting to the network share.
            /// </param>
            public NetworkConnection(string networkName, NetworkCredential credentials)
            {
                _networkName = networkName;

                var netResource = new NetResource
                {
                    Scope = ResourceScope.GlobalNetwork,
                    ResourceType = ResourceType.Disk,
                    DisplayType = ResourceDisplaytype.Share,
                    RemoteName = networkName.TrimEnd('\\')
                };

                var result = WNetAddConnection2(
                    netResource, credentials.Password, credentials.UserName, 0);

                if (result != 0)
                {
                    throw new Win32Exception(result);
                }
            }

            #endregion

            #region Events

            /// <summary>
            /// Occurs when this instance has been disposed.
            /// </summary>
            public event EventHandler<EventArgs> Disposed;

            #endregion

            #region Public methods

            /// <summary>
            /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
            /// </summary>
            public void Dispose()
            {
                Dispose(true);
                GC.SuppressFinalize(this);
            }

            #endregion

            #region Protected methods

            /// <summary>
            /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
            /// </summary>
            /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
            protected virtual void Dispose(bool disposing)
            {
                if (disposing)
                {
                    var handler = Disposed;
                    if (handler != null)
                        handler(this, EventArgs.Empty);
                }

                WNetCancelConnection2(_networkName, 0, true);
            }

            #endregion

            #region Private static methods

            /// <summary>
            ///The WNetAddConnection2 function makes a connection to a network resource. The function can redirect a local device to the network resource.
            /// </summary>
            /// <param name="netResource">A <see cref="NetResource"/> structure that specifies details of the proposed connection, such as information about the network resource, the local device, and the network resource provider.</param>
            /// <param name="password">The password to use when connecting to the network resource.</param>
            /// <param name="username">The username to use when connecting to the network resource.</param>
            /// <param name="flags">The flags. See http://msdn.microsoft.com/en-us/library/aa385413%28VS.85%29.aspx for more information.</param>
            /// <returns></returns>
            [DllImport("mpr.dll")]
            private static extern int WNetAddConnection2(NetResource netResource,
                                                         string password,
                                                         string username,
                                                         int flags);

            /// <summary>
            /// The WNetCancelConnection2 function cancels an existing network connection. You can also call the function to remove remembered network connections that are not currently connected.
            /// </summary>
            /// <param name="name">Specifies the name of either the redirected local device or the remote network resource to disconnect from.</param>
            /// <param name="flags">Connection type. The following values are defined:
            /// 0: The system does not update information about the connection. If the connection was marked as persistent in the registry, the system continues to restore the connection at the next logon. If the connection was not marked as persistent, the function ignores the setting of the CONNECT_UPDATE_PROFILE flag.
            /// CONNECT_UPDATE_PROFILE: The system updates the user profile with the information that the connection is no longer a persistent one. The system will not restore this connection during subsequent logon operations. (Disconnecting resources using remote names has no effect on persistent connections.)
            /// </param>
            /// <param name="force">Specifies whether the disconnection should occur if there are open files or jobs on the connection. If this parameter is FALSE, the function fails if there are open files or jobs.</param>
            /// <returns></returns>
            [DllImport("mpr.dll")]
            private static extern int WNetCancelConnection2(string name, int flags, bool force);

            #endregion

            /// <summary>
            /// Finalizes an instance of the <see cref="NetworkConnection"/> class.
            /// Allows an <see cref="System.Object"></see> to attempt to free resources and perform other cleanup operations before the <see cref="System.Object"></see> is reclaimed by garbage collection.
            /// </summary>
            ~NetworkConnection()
            {
                Dispose(false);
            }
        }
        [StructLayout(LayoutKind.Sequential)]
        public class NetResource
        {
            public ResourceScope Scope;
            public ResourceType ResourceType;
            public ResourceDisplaytype DisplayType;
            public int Usage;
            public string LocalName;
            public string RemoteName;
            public string Comment;
            public string Provider;
        }
        public enum ResourceScope
        {
            Connected = 1,
            GlobalNetwork,
            Remembered,
            Recent,
            Context
        };
        public enum ResourceType
        {
            Any = 0,
            Disk = 1,
            Print = 2,
            Reserved = 8,
        }
        public enum ResourceDisplaytype
        {
            Generic = 0x0,
            Domain = 0x01,
            Server = 0x02,
            Share = 0x03,
            File = 0x04,
            Group = 0x05,
            Network = 0x06,
            Root = 0x07,
            Shareadmin = 0x08,
            Directory = 0x09,
            Tree = 0x0a,
            Ndscontainer = 0x0b
        }

    }
}
