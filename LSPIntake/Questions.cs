using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;


namespace LSPIntake
{
    public class Questions
    {
        public int _IntQuestionId { get; set; }
        public int _IntLanguageId { get; set; }
        public string _strQuestionText { get; set; }
        public DataSet _dsQuestionTexts { get; set; }
        public DataTable _dtQuestionTexts { get; set; }

        public DataTable GetQuestionTexts(int IntLanguageId)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["AdminConnectionString"].ConnectionString))
            using (var cmd = new SqlCommand("LSPQuestionTextsGet", con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.Parameters.AddWithValue("@LanguageId", IntLanguageId);
                cmd.CommandType = CommandType.StoredProcedure;

                da.SelectCommand = cmd;
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                da.Fill(ds);
                _dtQuestionTexts = ds.Tables[0];

                return _dtQuestionTexts;
            }
        }
    }
}
