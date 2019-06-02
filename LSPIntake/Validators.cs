using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace LSPIntake
{
    public class Validators
    {
        public int _IntValidatorId { get; set; }
        public int _IntValidatorLanguageId { get; set; }
        public string _strValidatorText { get; set; }
        public DataSet _dsValidatorTexts { get; set; }
        public DataTable _dtValidatorTexts { get; set; }

        public DataTable GetValidatorTexts(int IntLanguageId)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["AdminConnectionString"].ConnectionString))
            using (var cmd = new SqlCommand("prLSPValidationTextsGet", con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.Parameters.AddWithValue("@LanguageId", IntLanguageId);
                cmd.CommandType = CommandType.StoredProcedure;

                da.SelectCommand = cmd;
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                da.Fill(ds);
                _dtValidatorTexts = ds.Tables[0];

                return _dtValidatorTexts;
            }



        }


    }
}