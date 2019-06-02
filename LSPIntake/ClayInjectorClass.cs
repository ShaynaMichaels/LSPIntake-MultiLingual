using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Text;
using System.Dynamic;
using System.Xml.Linq;
using System.Net.Mail;

namespace LSPIntake
{
    public class ClayInjectorClass
    {
        #region Members
        public Lonesoldier _oLoneSoldier;
        public string _strInjectionSource = "LSP";
        public string _strFamilyXML;
        public string _strContactXML;
        public string _strContactTypeXML;
        public string _strPrimaryContactXML;
        public string _strLSPXML;
        public string _strInjection;
        public string _strDagId;
        #endregion


        #region PublicMethods

        public void CreateFamilyInjection(Lonesoldier oLoneSoldier)
        {
            XElement xml = new XElement("ClayData",
                new XAttribute("Username", "LSPInjector"),
                new XAttribute("Password", "s.m.r.MRH4614447"),
                new XAttribute("TableID", "150"),
                new XAttribute("SkipErrors", "1"),
                new XAttribute("DuplicateHandling", "1"),
                new XAttribute("UniqueFields", "849"),

                new XElement("Field",
                    new XAttribute("ID", "197"),
                    oLoneSoldier._strEmail),
                new XElement("Field",
                    new XAttribute("ID", "82"),
                    oLoneSoldier._strNameIdentifier),
                new XElement("Field",
                    new XAttribute("ID", "849"),
                    oLoneSoldier._strNameIdentifier),
                new XElement("Field",
                    new XAttribute("ID", "668"),
                    oLoneSoldier._strNameIdentifier),
                new XElement("Field",
                    new XAttribute("ID", "491"),
                    oLoneSoldier._strDagId),
                new XElement("Field",
                    new XAttribute("ID", "2"),
                    oLoneSoldier._strFName + " " + oLoneSoldier._strLName),
                new XElement("Field",
                    new XAttribute("ID", "195"),
                    oLoneSoldier._strJewishAffiliation),
                new XElement("Field",
                    new XAttribute("ID", "199"),
                    oLoneSoldier._strIsraelAddress),
                new XElement("Field",
                    new XAttribute("ID", "223"),
                    oLoneSoldier._strOriginalCountry),
                new XElement("Field",
                    new XAttribute("ID", "215"),
                    oLoneSoldier._strOriginalAddress),
                new XElement("Field",
                    new XAttribute("ID", "222"),
                    oLoneSoldier._strOriginalState),
                new XElement("Field",
                    new XAttribute("ID", "220"),
                    oLoneSoldier._strOriginalCity),
                new XElement("Field",
                    new XAttribute("ID", "224"),
                    oLoneSoldier._strZipCode),
                new XElement("Field",
                    new XAttribute("ID", "225"),
                    oLoneSoldier._strOriginalCell),
                new XElement("Field",
                    new XAttribute("ID", "226"),
                    oLoneSoldier._strOriginalHomePhone),
                new XElement("Field",
                    new XAttribute("ID", "203"),
                    oLoneSoldier._strIsraelCity),
                new XElement("Field",
                    new XAttribute("ID", "212"),
                    oLoneSoldier._strIsraelCell),
                new XElement("Field",
                    new XAttribute("ID", "209"),
                    oLoneSoldier._strIsraelHomePhone),
                new XElement("Field",
                    new XAttribute("ID", "736"),
                    oLoneSoldier._dtAliyahDate.ToString("MM/dd/yyyy")),
                new XElement("Field",
                    new XAttribute("ID", "952"),
                    "LSP")
                );
            _strFamilyXML = Convert.ToString(xml);
           
        }


        public void CreateContactInjection(Lonesoldier oLoneSoldier)
        {
            XElement xml = new XElement("ClayData",
                new XAttribute("Username", "LSPInjector"),
                new XAttribute("Password", "s.m.r.MRH4614447"),
                new XAttribute("TableID", "1"),
                new XAttribute("SkipErrors", "1"),
                new XAttribute("DuplicateHandling", "1"),
                new XAttribute("UniqueFields", "502"),
                new XElement("Field",
                    new XAttribute("ID", "178"),
                    new XAttribute("InnerID", "849"),
                    oLoneSoldier._strNameIdentifier),
                new XElement("Field",
                    new XAttribute("ID", "502"),
                    oLoneSoldier._strNameIdentifier),
               new XElement("Field",
                    new XAttribute("ID", "6"),
                    oLoneSoldier._strFName),
                new XElement("Field",
                    new XAttribute("ID", "7"),
                    oLoneSoldier._strLName),
                new XElement("Field",
                    new XAttribute("ID", "254"),
                    oLoneSoldier._strMName),
                new XElement("Field",
                    new XAttribute("ID", "19"),
                    oLoneSoldier._dtDOB.ToString("MM/dd/yyyy")),
                new XElement("Field",
                    new XAttribute("ID", "156"),
                    oLoneSoldier._strGender),
                new XElement("Field",
                    new XAttribute("ID", "154"),
                    oLoneSoldier._strMaritalStatus),
                new XElement("Field",
                    new XAttribute("ID", "185"),
                    oLoneSoldier._strEducation),
                new XElement("Field",
                    new XAttribute("ID", "158"),
                    oLoneSoldier._strCitizenship),
                    new XElement("Field",
                    new XAttribute("ID", "209"),
                    oLoneSoldier._strFathersNameEn),
                new XElement("Field",
                    new XAttribute("ID", "203"),
                    oLoneSoldier._strMothersNameEn),
                new XElement("Field",
                    new XAttribute("ID", "183"),
                    oLoneSoldier._strTZNumber),
                new XElement("Field",
                    new XAttribute("ID", "171"),
                    oLoneSoldier._strTZFirstNameHe),
                new XElement("Field",
                    new XAttribute("ID", "172"),
                    oLoneSoldier._strTZLastNameHe),
                new XElement("Field",
                    new XAttribute("ID", "166"),
                    oLoneSoldier._strArmyId),
                new XElement("Field",
                    new XAttribute("ID", "163"),
                    oLoneSoldier._dtEnlistmentDate.ToString("MM/dd/yyyy")),
                new XElement("Field",
                    new XAttribute("ID", "552"),
                    oLoneSoldier._strLengthOfService),
                new XElement("Field",
                    new XAttribute("ID", "542"),
                    "LSP")
                );
            _strContactXML = Convert.ToString(xml);
            
        }

        public void CreatePrimaryContactInjection(Lonesoldier oLoneSoldier)
        {
            XElement xml = new XElement("ClayData",
                new XAttribute("Username", "LSPInjector"),
                new XAttribute("Password", "s.m.r.MRH4614447"),
                new XAttribute("TableID", "150"),
                new XAttribute("SkipErrors", "1"),
                new XAttribute("DuplicateHandling", "1"),
                new XAttribute("UniqueFields", "849"),

                new XElement("Field",
                    new XAttribute("ID", "150"),
                    new XAttribute("InnerID", "502"),
                    oLoneSoldier._strNameIdentifier),
                new XElement("Field",
                    new XAttribute("ID", "849"),
                    oLoneSoldier._strNameIdentifier)
                    );
            _strPrimaryContactXML = Convert.ToString(xml);
        }

        public void CreateLoneSoldierInjection(Lonesoldier oLoneSoldier)
        {
            XElement xml = new XElement("ClayData",
                new XAttribute("Username", "LSPInjector"),
                new XAttribute("Password", "s.m.r.MRH4614447"),
                new XAttribute("TableID", "241"),
                new XAttribute("SkipErrors", "1"),
                new XAttribute("DuplicateHandling", "1"),
                new XAttribute("UniqueFields", "261"),

                 new XElement("Field",
                    new XAttribute("ID", "150"),
                    new XAttribute("InnerID", "849"),
                    oLoneSoldier._strNameIdentifier),
                new XElement("Field",
                    new XAttribute("ID", "261"),
                   oLoneSoldier._strNameIdentifier),
                new XElement("Field",
                    new XAttribute("ID", "191"),
                    oLoneSoldier._strLanguage),
                new XElement("Field",
                    new XAttribute("ID", "174"),
                    oLoneSoldier._strParentsPhone),
                new XElement("Field",
                    new XAttribute("ID", "153"),
                    oLoneSoldier._strParentsEmail),
                new XElement("Field",
                    new XAttribute("ID", "203"),
                    oLoneSoldier._strAliyahReason),
                new XElement("Field",
                    new XAttribute("ID", "224"),
                    oLoneSoldier._strCourseElite),
                new XElement("Field",
                    new XAttribute("ID", "253"),
                    oLoneSoldier._strMachalStatus),
                new XElement("Field",
                    new XAttribute("ID", "254"),
                    oLoneSoldier._strMachalProgram),
                new XElement("Field",
                    new XAttribute("ID", "166"),
                    oLoneSoldier._strArmyId),
                new XElement("Field",
                    new XAttribute("ID", "199"),
                    oLoneSoldier._strCourseElite),
                new XElement("Field",
                    new XAttribute("ID", "245"),
                    oLoneSoldier._strMachalId),
                new XElement("Field",
                    new XAttribute("ID", "216"),
                    oLoneSoldier._strArmyUnit),
                new XElement("Field",
                    new XAttribute("ID", "215"),
                    oLoneSoldier._strRoleType),
                new XElement("Field",
                    new XAttribute("ID", "234"),
                    "LSP")
                );
            _strLSPXML = Convert.ToString(xml);
            
        }

        public void CreateInjection(Lonesoldier oLoneSoldier)
        {
            CreateFamilyInjection(oLoneSoldier);
            CreateContactInjection(oLoneSoldier);
            CreatePrimaryContactInjection(oLoneSoldier);
            CreateLoneSoldierInjection(oLoneSoldier);
            _strInjection = _strFamilyXML;
            _strInjection += _strContactXML;
            _strInjection += _strPrimaryContactXML;
            _strInjection += _strLSPXML;
            SendXML();
        }
        
        public void SendXML()
        {
            SmtpClient client = new SmtpClient();
            client.Port = 25;
            client.Host = "mail.nbnonline.org";
            client.EnableSsl = false;
            client.Timeout = 10000;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential("dag@nbnonline.org", "DAG22ics");

            //To test: take out clay@nbnonline and just send to myself to look over fields and structure of xml
            MailMessage mm = new MailMessage("clay@nbnonline.org", "clay@nbnonline.org, sfishman@nbn.org.il", "LSP Intake", _strInjection);
            //MailMessage mm = new MailMessage("clay@nbnonline.org", "mhandel@nbn.org.il", "LSP Intake", _strInjection);
            mm.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
            //set the BodyTransferEncoding to prevent the default Quoted-printable encoding which causes injections to fail
            mm.BodyTransferEncoding = System.Net.Mime.TransferEncoding.Base64;
            client.Send(mm);
        }

        #endregion
    }
}