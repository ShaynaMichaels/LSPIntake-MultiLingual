using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace LSPIntake
{
    public class Headings
    {
        public int _IntHeadingId { get; set; }
        public int _IntHeadingLanguageId { get; set; }
        public string _strHeadingText { get; set; }
        public DataSet _dsHeadingTexts { get; set; }
        public DataTable _dtHeadingTexts { get; set; }

        public DataTable GetHeadingTexts(int IntHeadingLanguageId)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["AdminConnectionString"].ConnectionString))
            using (var cmd = new SqlCommand("prLSPHeadingTextsGet", con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.Parameters.AddWithValue("@LanguageId", IntHeadingLanguageId);
                cmd.CommandType = CommandType.StoredProcedure;

                da.SelectCommand = cmd;
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                da.Fill(ds);
                _dtHeadingTexts = ds.Tables[0];

                return _dtHeadingTexts;
            }
        }
    }
}