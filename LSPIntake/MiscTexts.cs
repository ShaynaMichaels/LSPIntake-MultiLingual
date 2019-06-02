using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace LSPIntake
{
    public class MiscTexts
    {
        public string _strDisclaimer { get; set; }
        public string _strSelect { get; set; }
        public string _strTeudatOleh { get; set; }
        public string _strIshurMachal { get; set; }
        public string _strText { get; set; }
        public DataSet _dsMiscTexts { get; set; }
        public DataTable _dtMiscTexts { get; set; }

        public String GetMiscTexts(int IntMiscTextLanguageId, int intMiscTextItem)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["AdminConnectionString"].ConnectionString))
            using (var cmd = new SqlCommand("prLSPMiscTextsGet", con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.Parameters.AddWithValue("@LanguageId", IntMiscTextLanguageId);
                cmd.Parameters.AddWithValue("@MiscTextItemId", intMiscTextItem);
                cmd.CommandType = CommandType.StoredProcedure;

                da.SelectCommand = cmd;
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                da.Fill(ds);
                _dtMiscTexts = ds.Tables[0];
                _strText = _dtMiscTexts.Rows[0][1].ToString();
                return _strText;

                //switch (intMiscTextItem)
                //{
                //    case 1:
                //        _strDisclaimer = _dtMiscTexts.Rows[0][1].ToString();
                //        return _strDisclaimer;
                //    case 2:
                //        _strSelect = _dtMiscTexts.Rows[0][1].ToString();
                //        return _strSelect;
                //    case 3:
                //        _strTeudatOleh = _dtMiscTexts.Rows[0][1].ToString();
                //        return _strTeudatOleh;
                //    case 4:
                //        _strIshurMachal = _dtMiscTexts.Rows[0][1].ToString();
                //        return _strIshurMachal;
                //    default:
                //        return "";
                //}

            }
        }
    }
}