using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace LSPIntake
{
    public class Subheadings
    {
        public int _IntSubheadingId { get; set; }
        public int _IntSubheadingLanguageId { get; set; }
        public string _strSubheadingText { get; set; }
        public DataSet _dsSubheadingTexts { get; set; }
        public DataTable _dtSubheadingTexts { get; set; }

        //if we use the generalized version of prLSPHeadingTextsGet, the commented out line will work
        //otherwise, make a new proc that is just for subHeadings
        public DataTable GetHeadingTexts(int languageId)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["AdminConnectionString"].ConnectionString))
            using (var cmd = new SqlCommand("prLSPSubheadingTextsGet", con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.Parameters.AddWithValue("@LanguageId", languageId);
                //cmd.Parameters.AddWithValue("@Table", "LSPSubheadingTexts");
                cmd.CommandType = CommandType.StoredProcedure;

                da.SelectCommand = cmd;
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                da.Fill(ds);
                _dtSubheadingTexts = ds.Tables[0];

                return _dtSubheadingTexts;
            }
        }
    }
}