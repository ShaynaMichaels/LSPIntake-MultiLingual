using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace LSPIntake
{
    public class AuthorizationClass
    {

        public string _strRandomId { get; set; }
        public string _strEmail { get; set; }
        public string _strNameIdentifier { get; set; }
        public int _intIsAuthorized { get; set; }
        public DataSet _dsAuthorization { get; set; }
        public DataTable _dtAuthorization { get; set; }

        public DataTable AuthorizationGet(string strEmail, string strNameIdentifier, string strRandomId)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["AdminConnectionString"].ConnectionString))
            using (var cmd = new SqlCommand("prAuthorizationGet", con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.Parameters.AddWithValue("@Email", strEmail);
                cmd.Parameters.AddWithValue("@NameIdentifier", strNameIdentifier);
                cmd.Parameters.AddWithValue("@RandomId", strRandomId);
                cmd.CommandType = CommandType.StoredProcedure;

                da.SelectCommand = cmd;
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                da.Fill(ds);
                _dtAuthorization = ds.Tables[0];

                return _dtAuthorization;
            }
        }
    }
}