using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.Entity.Core.Objects;
using System.Text;
using System.Dynamic;
using System.Xml.Linq;
using System.Net.Mail;
using System.Web.UI.HtmlControls;


namespace LSPIntake
{
    public partial class IntakeForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(IsPostBack))
            {
                if (Convert.ToInt32(Session["Debug"] ) == 1)
                {
                    gvData.Visible = true;
                }
                else
                {
                    gvData.Visible = false;
                }
                if (Session["email"] == null || Session["nameidentifier"] == null)
                {
                    //Response.Redirect("https://login2.nbn.org.il/Account/Claims?Application=LSP");
                    //Authenticating user
                    lblDebugText.Text = "RandomID = " + (string)(Session["RandomID"]) + ", email = " + (string)(Session["email"]) + ", nameidentifier = " + (string)(Session["nameidentifier"]);
                }
                else
                {
                    int intLanguageId = Convert.ToInt32((string)Session["Language"]);
                    AddSelectToDropdowns();
                    AddDisclaimerText();
                    AddSubmitText();
                    AddFileUploadInstructionsText();
                    QuestionTextsGet();
                    ValidatorTextsGet();
                    HeadingTextsGet();
                    SubheadingTextsGet();
                    if (intLanguageId == 1)
                    {
                        MachalOptionShow();
                        OriginalMobileShow();
                    }
                    else
                    {
                        MachalOptionHide();
                        MachalHide();
                        OriginalMobileHide();
                    }
                    if (intLanguageId == 2)
                    {
                        ParentsEmailHide();
                    }
                    else
                    {
                        ParentsEmailShow();
                    }
                    if (gvData.Rows.Count > 0)
                    {
                        PopulateControlsFromDatabase();
                    }
                    else
                    {
                        txtEmail.Text = (string)(Session["email"]);
                        txtEmailVerification.Text = (string)(Session["email"]);
                        ddlLanguage.SelectedIndex = Convert.ToInt32(Session["language"]);
                    }
                }
            }
        }

        #region PopulateFormTexts

        protected void QuestionTextsGet()
        {
            Questions oQuestions = new Questions();
            oQuestions._IntLanguageId = Convert.ToInt32(Session["language"]);
            oQuestions.GetQuestionTexts(oQuestions._IntLanguageId);

            lblQ1Legalfirstname.Text = oQuestions._dtQuestionTexts.Rows[0][3].ToString();
            //lblQ2Legalmiddlename.Text = oQuestions._dtQuestionTexts.Rows[1][3].ToString();
            lblQ3Legallastname.Text = oQuestions._dtQuestionTexts.Rows[2][3].ToString();
            lblQ4DateofBirth.Text = oQuestions._dtQuestionTexts.Rows[3][3].ToString();
            lblQ5Gender.Text = oQuestions._dtQuestionTexts.Rows[4][3].ToString();
            lblQ6Maritalstatus.Text = oQuestions._dtQuestionTexts.Rows[5][3].ToString();
            lblQ7Education.Text = oQuestions._dtQuestionTexts.Rows[6][3].ToString();
            //lblQ8JewishAffiliation.Text = oQuestions._dtQuestionTexts.Rows[7][3].ToString();
            lblQ9PreferredLanguage.Text = oQuestions._dtQuestionTexts.Rows[8][3].ToString();
            lblQ10Email.Text = oQuestions._dtQuestionTexts.Rows[9][3].ToString();
            lblQ11Emailverification.Text = oQuestions._dtQuestionTexts.Rows[10][3].ToString();
            lblQ12OriginalCountry.Text = oQuestions._dtQuestionTexts.Rows[11][3].ToString();
            lblQ13IHoldTheFollowingCitizinship.Text = oQuestions._dtQuestionTexts.Rows[12][3].ToString();
            lblQ14OriginalAddressStreetAddress.Text = oQuestions._dtQuestionTexts.Rows[13][3].ToString();
            lblQ15OriginalState.Text = oQuestions._dtQuestionTexts.Rows[14][3].ToString();
            lblQ16OriginalCity.Text = oQuestions._dtQuestionTexts.Rows[15][3].ToString();
            lblQ17Zipcode.Text = oQuestions._dtQuestionTexts.Rows[16][3].ToString();
            lblQ18OriginalMobile.Text = oQuestions._dtQuestionTexts.Rows[17][3].ToString();
            lblQ20FathersFullNameEnglish.Text = oQuestions._dtQuestionTexts.Rows[19][3].ToString();
            lblQ21MothersFullNameEnglish.Text = oQuestions._dtQuestionTexts.Rows[20][3].ToString();
            lblQ22ParentsPhone.Text = oQuestions._dtQuestionTexts.Rows[21][3].ToString();
            lblQ23ParentsEmail.Text = oQuestions._dtQuestionTexts.Rows[22][3].ToString();
            lblQ24Whatcountrydoyouliveintoday.Text = oQuestions._dtQuestionTexts.Rows[23][3].ToString();
            lblQ25IsraelAddres.Text = oQuestions._dtQuestionTexts.Rows[24][3].ToString();
            lblQ26IsraelCity.Text = oQuestions._dtQuestionTexts.Rows[25][3].ToString();
            lblQ27IsraelCellPhone.Text = oQuestions._dtQuestionTexts.Rows[26][3].ToString();
            lblQ29DidyoumakeAliyah.Text = oQuestions._dtQuestionTexts.Rows[28][3].ToString();
            lblQ30DoyouhaveanisraeliIDnumber.Text = oQuestions._dtQuestionTexts.Rows[29][3].ToString();
            lblQ31TZNumber.Text = oQuestions._dtQuestionTexts.Rows[30][3].ToString();
            lblQ32FirstNameonTZHebrew.Text = oQuestions._dtQuestionTexts.Rows[31][3].ToString();
            lblQ33LastnameonTZHebrew.Text = oQuestions._dtQuestionTexts.Rows[32][3].ToString();
            lblQ34DateofAliyah.Text = oQuestions._dtQuestionTexts.Rows[33][3].ToString();
            lblQ36AreyoucurrentlyservingintheIDF.Text = oQuestions._dtQuestionTexts.Rows[35][3].ToString();
            lblQ37MachalStatus.Text = oQuestions._dtQuestionTexts.Rows[36][3].ToString();
            lblQ38Whichprogramdidyouapplyto.Text = oQuestions._dtQuestionTexts.Rows[37][3].ToString();
            lblQ39IDFIDNumberMisparIshi.Text = oQuestions._dtQuestionTexts.Rows[38][3].ToString();
            lblQ40MachalID.Text = oQuestions._dtQuestionTexts.Rows[39][3].ToString();
            lblQ41EnlistmentDate.Text = oQuestions._dtQuestionTexts.Rows[40][3].ToString();
            lblQ42LengthOfService.Text = oQuestions._dtQuestionTexts.Rows[41][3].ToString();
            lblQ43ArmyUnit.Text = oQuestions._dtQuestionTexts.Rows[42][3].ToString();
            lblQ44roleType.Text = oQuestions._dtQuestionTexts.Rows[43][3].ToString();
            lblQ45Passportphoto.Text = oQuestions._dtQuestionTexts.Rows[44][3].ToString();
            lblQ46LoneSoldiercertificate.Text = oQuestions._dtQuestionTexts.Rows[45][3].ToString();
            lblQ47Draftnotice.Text = oQuestions._dtQuestionTexts.Rows[46][3].ToString();
            rblAccept.Items.Add(new ListItem(oQuestions._dtQuestionTexts.Rows[47][3].ToString(), "1"));
            lblQ49EnlistmentDate.Text = oQuestions._dtQuestionTexts.Rows[48][3].ToString();
        }

        protected void ValidatorTextsGet()
        {
            Validators oValidator = new Validators();
            oValidator._IntValidatorLanguageId = Convert.ToInt32(Session["language"]);
            oValidator.GetValidatorTexts(oValidator._IntValidatorLanguageId);

            vldtrFirstNameRequired.ErrorMessage = oValidator._dtValidatorTexts.Rows[0][1].ToString();
            vldtrFirstNameRegex.ErrorMessage = oValidator._dtValidatorTexts.Rows[1][1].ToString();
            //vldtrMiddleNameRegex.ErrorMessage = oValidator._dtValidatorTexts.Rows[2][1].ToString();
            vldtrLastNameRequired.ErrorMessage = oValidator._dtValidatorTexts.Rows[3][1].ToString();
            vldtrLastNameRegex.ErrorMessage = oValidator._dtValidatorTexts.Rows[4][1].ToString();
            vldtrDOBRequired.ErrorMessage = oValidator._dtValidatorTexts.Rows[5][1].ToString();
            vldtrGenderRequired.ErrorMessage = oValidator._dtValidatorTexts.Rows[6][1].ToString();
            vldtrMaritalStatusRequired.ErrorMessage = oValidator._dtValidatorTexts.Rows[7][1].ToString();
            vldtrEducationRequired.ErrorMessage = oValidator._dtValidatorTexts.Rows[8][1].ToString();
            //vldtrAffiliationRequired.ErrorMessage = oValidator._dtValidatorTexts.Rows[9][1].ToString();
            vldtrLanguageRequired.ErrorMessage = oValidator._dtValidatorTexts.Rows[10][1].ToString();
            vldtrEmailRegex.ErrorMessage = oValidator._dtValidatorTexts.Rows[11][1].ToString();
            VldtrEmailRequired.ErrorMessage = oValidator._dtValidatorTexts.Rows[12][1].ToString();
            vldtrEmailVerificationCompare.ErrorMessage = oValidator._dtValidatorTexts.Rows[13][1].ToString();
            vldtrEmailVerificationRequired.ErrorMessage = oValidator._dtValidatorTexts.Rows[14][1].ToString();
            vldtrOriginalCountryRequired.ErrorMessage = oValidator._dtValidatorTexts.Rows[15][1].ToString();
            vldtrOriginalStateRequired.ErrorMessage = oValidator._dtValidatorTexts.Rows[16][1].ToString();
            vldtrOriginalCityRequired.ErrorMessage = oValidator._dtValidatorTexts.Rows[17][1].ToString();
            vldtrOriginalAddressRegex.ErrorMessage = oValidator._dtValidatorTexts.Rows[18][1].ToString();
            vldtrOriginalAddressRequired.ErrorMessage = oValidator._dtValidatorTexts.Rows[19][1].ToString();
            vldtrZipCodeRequired.ErrorMessage = oValidator._dtValidatorTexts.Rows[20][1].ToString();
            vldtrOriginalMobileRegex.ErrorMessage = oValidator._dtValidatorTexts.Rows[21][1].ToString();
            vldtrOriginalMobileRequired.ErrorMessage = oValidator._dtValidatorTexts.Rows[22][1].ToString();
            vldtrFathersNameEngRegex.ErrorMessage = oValidator._dtValidatorTexts.Rows[25][1].ToString();
            vldtrFathersNameEngRequired.ErrorMessage = oValidator._dtValidatorTexts.Rows[26][1].ToString();
            vldtrMothersNameEngRegex.ErrorMessage = oValidator._dtValidatorTexts.Rows[27][1].ToString();
            vldtrMothersNameEngRequired.ErrorMessage = oValidator._dtValidatorTexts.Rows[28][1].ToString();
            vldtrParentsPhoneRegex.ErrorMessage = oValidator._dtValidatorTexts.Rows[29][1].ToString();
            vldtrParentsPhoneRequired.ErrorMessage = oValidator._dtValidatorTexts.Rows[30][1].ToString();
            vldtrParentsEmailRegex.ErrorMessage = oValidator._dtValidatorTexts.Rows[31][1].ToString();
            vldtrParentsEmailRequired.ErrorMessage = oValidator._dtValidatorTexts.Rows[32][1].ToString();
            vldtrCurrentCountryRequired.ErrorMessage = oValidator._dtValidatorTexts.Rows[33][1].ToString();
            vldtrIsraelAddressRegex.ErrorMessage = oValidator._dtValidatorTexts.Rows[34][1].ToString();
            vldtrIsraelCityRequired.ErrorMessage = oValidator._dtValidatorTexts.Rows[35][1].ToString();
            vldtrIsraelMobileRequired.ErrorMessage = oValidator._dtValidatorTexts.Rows[36][1].ToString();
            vldtrIsraelMobileRegex.ErrorMessage = oValidator._dtValidatorTexts.Rows[37][1].ToString();
            vldtrAliyahOptionRequired.ErrorMessage = oValidator._dtValidatorTexts.Rows[40][1].ToString();
            vldtrAliyahDateRequired.ErrorMessage = oValidator._dtValidatorTexts.Rows[41][1].ToString();
            vldtrTZOptionRequired.ErrorMessage = oValidator._dtValidatorTexts.Rows[43][1].ToString();
            vldtrTZNumberRegex.ErrorMessage = oValidator._dtValidatorTexts.Rows[44][1].ToString();
            vldtrTZNumberRequired.ErrorMessage = oValidator._dtValidatorTexts.Rows[45][1].ToString();
            vldtrTZFirstNameRegex.ErrorMessage = oValidator._dtValidatorTexts.Rows[46][1].ToString();
            vldtrTZFirstNameRequired.ErrorMessage = oValidator._dtValidatorTexts.Rows[47][1].ToString();
            vldtrTZLastNameRegex.ErrorMessage = oValidator._dtValidatorTexts.Rows[48][1].ToString();
            vldtrTZLastNameRequired.ErrorMessage = oValidator._dtValidatorTexts.Rows[49][1].ToString();
            vldtrEnlistmentRequired.ErrorMessage = oValidator._dtValidatorTexts.Rows[50][1].ToString();
            vldtrEnlistmentDateRequired.ErrorMessage = oValidator._dtValidatorTexts.Rows[51][1].ToString();
            vldtrLengthOfServiceRequired.ErrorMessage = oValidator._dtValidatorTexts.Rows[62][1].ToString();
            vldtrMachalOptionRequired.ErrorMessage = oValidator._dtValidatorTexts.Rows[53][1].ToString();
            vldtrMachalStatusRequired.ErrorMessage = oValidator._dtValidatorTexts.Rows[54][1].ToString();
            vldtrMachalProgramRequired.ErrorMessage = oValidator._dtValidatorTexts.Rows[55][1].ToString();
            vldtrMachalIdRegex.ErrorMessage = oValidator._dtValidatorTexts.Rows[56][1].ToString();
            vldtrMachlIdRequired.ErrorMessage = oValidator._dtValidatorTexts.Rows[57][1].ToString();
            vldtrCurrentlyServingRequired.ErrorMessage = oValidator._dtValidatorTexts.Rows[58][1].ToString();
            vldtrArmyIdRegex.ErrorMessage = oValidator._dtValidatorTexts.Rows[59][1].ToString();
            vldtrAcceptRequired.ErrorMessage = oValidator._dtValidatorTexts.Rows[60][1].ToString();
            valSum.HeaderText = oValidator._dtValidatorTexts.Rows[61][1].ToString();
        }

        protected void HeadingTextsGet()
        {
            Headings oHeadings = new Headings();
            oHeadings._IntHeadingLanguageId = Convert.ToInt32(Session["language"]);
            oHeadings.GetHeadingTexts(oHeadings._IntHeadingLanguageId);

            lblHeadingPersonalDetails.Text = oHeadings._dtHeadingTexts.Rows[0][1].ToString();
            lblHeadingGeneralInformation.Text = oHeadings._dtHeadingTexts.Rows[1][1].ToString();
            lblHeadingArmyDetails.Text = oHeadings._dtHeadingTexts.Rows[2][1].ToString();
            lblHeadingDisclaimer.Text = oHeadings._dtHeadingTexts.Rows[3][1].ToString();
            lblHeadingDocumentUpload.Text = oHeadings._dtHeadingTexts.Rows[4][1].ToString();

            MiscTexts oMiscTexts = new MiscTexts();
            //teudat oleh
            oMiscTexts.GetMiscTexts(Convert.ToInt32(Session["language"]), 3);
            lblTeudatOleh.Text = oMiscTexts._strText;
            //Ishur machal
            oMiscTexts.GetMiscTexts(Convert.ToInt32(Session["language"]), 4);
            lblIshurMachal.Text = oMiscTexts._strText;
        }

        protected void SubheadingTextsGet()
        {
            Subheadings oSub = new Subheadings();
            oSub._IntSubheadingLanguageId = Convert.ToInt32(Session["language"]);
            oSub.GetHeadingTexts(oSub._IntSubheadingLanguageId);

            lblSubheadingPersonalDetails.Text = oSub._dtSubheadingTexts.Rows[0][1].ToString();
            lblSubheadingArmyDetails.Text = oSub._dtSubheadingTexts.Rows[1][1].ToString();
            lblSubheadingGeneralInformation.Text = oSub._dtSubheadingTexts.Rows[2][1].ToString();
            
           
            MiscTexts oMiscTexts = new MiscTexts();
            //teudat oleh
            oMiscTexts.GetMiscTexts(Convert.ToInt32(Session["language"]), 3);
            lblTeudatOleh.Text = oMiscTexts._strText;
            //Ishur machal
            oMiscTexts.GetMiscTexts(Convert.ToInt32(Session["language"]), 4);
            lblIshurMachal.Text = oMiscTexts._strText;
        }

        protected void AddSelectToDropdowns()
        {
            MiscTexts oMiscTexts = new MiscTexts();
            oMiscTexts.GetMiscTexts(Convert.ToInt32(Session["language"]), 2);
            
            ddlCurrentCountry.DataBind();
            ddlCurrentCountry.Items.Insert(0, "-"+ oMiscTexts._strText + "-");
            vldtrCurrentCountryRequired.InitialValue = "-" + oMiscTexts._strText + "-";

            ddlOriginalCountry.DataBind();
            ddlOriginalCountry.Items.Insert(0, "-"+ oMiscTexts._strText + "-");
            vldtrOriginalCountryRequired.InitialValue = "-" + oMiscTexts._strText + "-";

            //ddlJewishAffiliation.DataBind();
            //ddlJewishAffiliation.Items.Insert(0, "-"+ oMiscTexts._strText + "-");
            //vldtrAffiliationRequired.InitialValue = "-" + oMiscTexts._strText + "-";

            ddlArmyUnit.DataBind();
            ddlArmyUnit.Items.Insert(0, "-"+ oMiscTexts._strText + "-");
            
            ddlArmyTafkid.DataBind();
            ddlArmyTafkid.Items.Insert(0, "-"+ oMiscTexts._strText + "-");

            ddlGender.DataBind();
            ddlGender.Items.Insert(0, "-" + oMiscTexts._strText + "-");
            vldtrGenderRequired.InitialValue = "-" + oMiscTexts._strText + "-";

            ddlEducation.DataBind();
            ddlEducation.Items.Insert(0, "-"+ oMiscTexts._strText + "-");
            vldtrEducationRequired.InitialValue = "-" + oMiscTexts._strText + "-";

            ddlLanguage.DataBind();
            ddlLanguage.Items.Insert(0, "-"+ oMiscTexts._strText + "-");
            vldtrLanguageRequired.InitialValue = "-" + oMiscTexts._strText + "-";

            ddlMachalStatus.DataBind();
            ddlMachalStatus.Items.Insert(0, "-"+ oMiscTexts._strText + "-");
            vldtrMachalStatusRequired.InitialValue = "-" + oMiscTexts._strText + "-";

            ddlMachalProgram.DataBind();
            ddlMachalProgram.Items.Insert(0, "-"+ oMiscTexts._strText + "-");
            vldtrMachalProgramRequired.InitialValue = "-" + oMiscTexts._strText + "-";

            ddlLengthOfService.DataBind();
            ddlLengthOfService.Items.Insert(0, "-" + oMiscTexts._strText + "-");
            vldtrLengthOfServiceRequired.InitialValue = "-" + oMiscTexts._strText + "-";
        }
        
        #endregion

        #region ShowHide

        protected void IsraelContactInfoHide()
        {
            pnlIsraelContactInfo.Visible = false;
            txtIsraelAddress.Text = "";
            txtIsraelMobile.Text = "";
            vldtrIsraelMobileRequired.Enabled = false;
            vldtrIsraelMobileRegex.Enabled = false;
            ddlIsraelCity.ClearSelection();
            vldtrIsraelCityRequired.Enabled = false;
        }
        protected void IsraelContactInfoShow()
        {
            MiscTexts oMiscTexts = new MiscTexts();
            oMiscTexts.GetMiscTexts(Convert.ToInt32(Session["language"]), 2);
            pnlIsraelContactInfo.Visible = true;
            ddlIsraelCity.DataBind();
            ddlIsraelCity.Items.Insert(0, "-"+ oMiscTexts._strText + "-");
            vldtrIsraelCityRequired.Enabled = true;
            vldtrIsraelMobileRequired.Enabled = true;
            vldtrIsraelMobileRegex.Enabled = true;   
        }
        
        protected void AliyahPanelHide()
        {
            pnlAliyah.Visible = false;
            txtAliyahDate.Text = "";
            vldtrAliyahDateRequired.Enabled = false;
        }
        protected void AliyahPanelShow()
        {
            pnlAliyah.Visible = true;
            vldtrAliyahDateRequired.Enabled = true;
        }

        protected void TZShow()
        {
            pnlTeudatZehut.Visible = true;
            vldtrTZNumberRequired.Enabled = true;
            vldtrTZFirstNameRequired.Enabled = true;
            vldtrTZLastNameRequired.Enabled = true;
        }
        protected void TZHide()
        {
            pnlTeudatZehut.Visible = false;
            txtTZNumber.Text = "";
            txtTZFirstName.Text = "";
            txtTZLastName.Text = "";
            vldtrTZNumberRequired.Enabled = false;
            vldtrTZFirstNameRequired.Enabled = false;
            vldtrTZLastNameRequired.Enabled = false;
        }

        protected void ActiveDutyShow()
        {
            pnlActiveDuty.Visible = true;

        }
        protected void ActiveDutyHide()
        {
            pnlActiveDuty.Visible = false;
            txtArmyId.Text = "";
            ddlArmyUnit.ClearSelection();
            ddlArmyTafkid.ClearSelection();
        }

        protected void EnlistmentDateShow()
        {
            pnlEnlistmentDate.Visible = true;
            vldtrEnlistmentDateRequired.Enabled = true;
            vldtrLengthOfServiceRequired.Enabled = true;
        }
        protected void EnlistmentDateHide()
        {
            pnlEnlistmentDate.Visible = false;
            txtEnlistmentDate.Text = "";
            ddlLengthOfService.ClearSelection();
            vldtrEnlistmentDateRequired.Enabled = false;
            vldtrLengthOfServiceRequired.Enabled = false;
        }
        protected void ParentsEmailShow()
        {
            lblQ23ParentsEmail.Visible = true;
            txtParentsEmail.Visible = true;
            vldtrParentsEmailRegex.Enabled = true;
            vldtrParentsEmailRequired.Enabled = true;
        }
        protected void ParentsEmailHide()
        {
            lblQ23ParentsEmail.Visible = false;
            txtParentsEmail.Visible = false;
            txtParentsEmail.Text = "";
            vldtrParentsEmailRegex.Enabled = false;
            vldtrParentsEmailRequired.Enabled = false;
        }

        protected void OriginalMobileShow()
        {
            lblQ18OriginalMobile.Visible = true;
            txtOriginalMobile.Visible = true;
            vldtrOriginalMobileRequired.Enabled = true;
            vldtrOriginalMobileRegex.Enabled = true;
        }
        protected void OriginalMobileHide()
        {
            lblQ18OriginalMobile.Visible = false;
            txtOriginalMobile.Visible = false;
            txtOriginalMobile.Text = "";
            vldtrOriginalMobileRequired.Enabled = false;
            vldtrOriginalMobileRegex.Enabled = false;
        }


        protected void MachalOptionShow()
        {
            pnlMachalOption.Visible = true;
            vldtrMachalOptionRequired.Enabled = true;
        }
        protected void MachalOptionHide()
        {
            pnlMachalOption.Visible = false;
            vldtrMachalOptionRequired.Enabled = false;
        }

        protected void MachalShow()
        {
            pnlMachal.Visible = true;
            vldtrMachalStatusRequired.Enabled = true;
            vldtrMachalProgramRequired.Enabled = true;
            vldtrMachlIdRequired.Enabled = true;
        }
        protected void MachalHide()
        {
            pnlMachal.Visible = false;
            ddlMachalProgram.ClearSelection();
            ddlMachalStatus.ClearSelection();
            txtMachalId.Text = "";
            vldtrMachalStatusRequired.Enabled = false;
            vldtrMachalProgramRequired.Enabled = false;
            vldtrMachlIdRequired.Enabled = false;
        }

        protected void OriginalStateShow()
        {
            SetOriginalStateLabel();
            divOriginalState.Visible = true;
            ddlOriginalState.DataSource = SqlDataSourceOriginalState;
            ddlOriginalState.DataBind();
            MiscTexts oMiscTexts = new MiscTexts();
            oMiscTexts.GetMiscTexts(Convert.ToInt32(Session["language"]), 2);
            ddlOriginalState.Items.Insert(0, "-"+ oMiscTexts._strText + "-");
            vldtrOriginalStateRequired.Enabled = true;
            vldtrOriginalStateRequired.InitialValue = "-" + oMiscTexts._strText + "-";
        }
        protected void OriginalStateHide()
        {
            divOriginalState.Visible = false;
            ddlOriginalState.ClearSelection();
            vldtrOriginalStateRequired.Enabled = false;
        }

        protected void OriginalCityShow()
        {
            divOriginalCity.Visible = true;
            if (ddlOriginalCountry.SelectedIndex == 4) //Israel
            {
                ddlOriginalCity.DataSource = SqlDataSourceIsraelCity;
            }
            else
            {
                ddlOriginalCity.DataSource = SqlDataSourceOriginalCity;
            }
            ddlOriginalCity.DataBind();
            if (ddlOriginalCity.Items.Count > 1)
            {
                MiscTexts oMiscTexts = new MiscTexts();
                oMiscTexts.GetMiscTexts(Convert.ToInt32(Session["language"]), 2);
                ddlOriginalCity.Items.Insert(0, "-"+ oMiscTexts._strText + "-");
                vldtrOriginalCityRequired.Enabled = true;
            }
            else if (ddlOriginalCity.Items.Count == 1) //only 1 city ie Washington DC
            {
                ddlOriginalCity.SelectedIndex = 0;
            }
            else //if there are no cities (ie Gibraltar), hide the control
            {
                OriginalCityHide();
            }
            OriginalPostalAddressShow();

        }
        protected void OriginalCityHide()
        {
            divOriginalCity.Visible = false;
            ddlOriginalCity.ClearSelection();
            vldtrOriginalCityRequired.Enabled = false;
            OriginalPostalAddressHide();
        }

        protected void OriginalPostalAddressShow()
        {
            divOriginalPostalAddress.Visible = true;
            vldtrOriginalAddressRequired.Enabled = true;
            vldtrZipCodeRequired.Enabled = true;
        }
        protected void OriginalPostalAddressHide()
        {
            divOriginalPostalAddress.Visible = false;
            txtOriginalAddress.Text = "";
            txtZipCode.Text = "";
            vldtrOriginalAddressRequired.Enabled = false;
            vldtrZipCodeRequired.Enabled = false;
        }

        protected void CurrentNBNCitizenShow()
        {
            divCurrentNBNCitizen.Visible = true;
            //populate chkbxNotNBNCitizen checkbox label
            MiscTexts oMiscTexts = new MiscTexts();
            oMiscTexts.GetMiscTexts(Convert.ToInt32(Session["language"]), 14);
            lblNotNBNCitizen.Text = oMiscTexts._strText;

        }
        protected void CurrentNBNCitizenHide()
        {
            divCurrentNBNCitizen.Visible = false;
            chkbxUSCitizen.Checked = false;
            chkbxUKCitizen.Checked = false;
            chkbxCACitizen.Checked = false;
        }

        protected void IntakeFormHide()
        {
            pnlPersonalDetails.Visible = false;
            pnlGeneralInfo.Visible = false;
            pnlArmyDetails.Visible = false;
            pnlDisclaimer.Visible = false;
            pnlSubmit.Visible = false;
        }
        protected void IntakeFormShow()
        {
            pnlPersonalDetails.Visible = true;
            pnlGeneralInfo.Visible = true;
            pnlArmyDetails.Visible = true;
            pnlDisclaimer.Visible = true;
            pnlSubmit.Visible = true;
        }

        #endregion

        #region ControlMethods

        protected void txtFirstName_TextChanged(object sender, EventArgs e)
        {
            txtFirstName.Text = FirstCharToUpper(txtFirstName.Text);
        }

        //protected void txtMiddleName_TextChanged(object sender, EventArgs e)
        //{
        //    txtMiddleName.Text = FirstCharToUpper(txtMiddleName.Text);
        //}

        protected void txtLastName_TextChanged(object sender, EventArgs e)
        {
            txtLastName.Text = FirstCharToUpper(txtLastName.Text);
        }

        protected void txtFathersNameEng_TextChanged(object sender, EventArgs e)
        {
            txtFathersNameEng.Text = FirstCharToUpper(txtFathersNameEng.Text);
        }

        protected void txtMothersNameEng_TextChanged(object sender, EventArgs e)
        {
            txtMothersNameEng.Text = FirstCharToUpper(txtMothersNameEng.Text);
        }


        protected void rblCurrentlyServing_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rblCurrentlyServing.SelectedValue == "Yes")
            {
                ActiveDutyShow();
            }
            else
                ActiveDutyHide();
        }

        protected void rblAliyah_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rblAliyah.SelectedValue == "Yes")
            {
                AliyahPanelShow();
            }
            else
            {
                AliyahPanelHide();
            }
        }

        protected void ddlOriginalCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlOriginalCountry.SelectedIndex == 0)
            {
                OriginalStateHide();
                OriginalCityHide();
                CurrentNBNCitizenHide();
                vldtrOriginalCountryRequired.Validate();
            }
            else if (ddlOriginalCountry.SelectedIndex == 4) //Israel
            {
                OriginalStateHide();
                OriginalCityShow();
                CurrentNBNCitizenShow();
            }
            else if (ddlOriginalCountry.SelectedIndex > 0 && ddlOriginalCountry.SelectedIndex < 4) //US, UK, or Canada
            {
                OriginalStateShow();
                OriginalCityHide();
                CurrentNBNCitizenHide();
            }
            else if (ddlOriginalCountry.SelectedIndex > 4)
            {
                OriginalStateHide();
                OriginalCityHide();
                CurrentNBNCitizenShow();
            }
            
        }

        protected void ddlOriginalState_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (ddlOriginalState.SelectedValue != "Gibraltar" && ddlOriginalState.SelectedIndex > 0)
            if (ddlOriginalState.SelectedIndex > 0)
            {
                OriginalCityShow();
            }
            else
            {
                OriginalCityHide();
                vldtrOriginalStateRequired.Validate();
            }
        }

        protected void ddlOriginalCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlOriginalCity.SelectedIndex == 0)
            {
                vldtrOriginalCityRequired.Validate();
            }
        }

        protected void ddlCurrentCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlCurrentCountry.SelectedIndex == 0)
            {
                IsraelContactInfoHide();
                vldtrCurrentCountryRequired.Validate();
            }
            else if (ddlCurrentCountry.SelectedValue == "Israel")
            {
                IsraelContactInfoShow();
            }
            else
            {
                IsraelContactInfoHide();
            }
        }

        protected void rblTZ_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rblTZ.SelectedValue == "Yes")
            {
                TZShow();
            }
            else
            {
                TZHide();
            }
        }

        protected void rblEnlistmentDate_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rblEnlistmentDate.SelectedValue == "Yes")
            {
                EnlistmentDateShow();
            }
            else
            {
                EnlistmentDateHide();
            }
        }

        protected void rblMachal_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rblMachal.SelectedValue == "Yes")
            {
                MachalShow();
            }
            else
            {
                MachalHide();
            }
        }

        protected void chkbxUSCitizen_CheckedChanged(object sender, EventArgs e)
        {
            chkbxNotNBNCitizen.Checked = false;
        }

        protected void chkbxUKCitizen_CheckedChanged(object sender, EventArgs e)
        {
            chkbxNotNBNCitizen.Checked = false;
        }

        protected void chkbxCACitizen_CheckedChanged(object sender, EventArgs e)
        {
            chkbxNotNBNCitizen.Checked = false;
        }

        protected void chkbxNotNBNCitizen_CheckedChanged(object sender, EventArgs e)
        {
            chkbxUSCitizen.Checked = false;
            chkbxUKCitizen.Checked = false;
            chkbxCACitizen.Checked = false;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            InjectClassFromControls();
            lblResponseText.Text = "Thank you!";
            IntakeFormHide();
            pnlDocumentUpload.Visible = true;
            PopulateUploadLinks();
        }

        #endregion

        #region Private methods

        public static string FirstCharToUpper(string input)
        {
            if (String.IsNullOrEmpty(input))
                return "";
            return input.First().ToString().ToUpper() + input.Substring(1);
        }

        protected string CitizenshipString()
        {
            string strUSCitizenship = "";
            string strUKCitizenship = "";
            string strCACitizenship = "";
            string strCitizenship = ""; //initialize
            strCitizenship = ddlOriginalCountry.SelectedValue;
            if (chkbxUSCitizen.Checked)
            {
                strUSCitizenship = "/USA";
            }
            if (chkbxUKCitizen.Checked)
            {
                strUKCitizenship = "/UK";
            }
            if (chkbxCACitizen.Checked)
            {
                strCACitizenship = "/Canada";
            }
            strCitizenship = strCitizenship + strUSCitizenship + strUKCitizenship + strCACitizenship;
            return strCitizenship;
        }

        protected void PopulateControlsFromDatabase()
        {
            MiscTexts oMiscTexts = new MiscTexts();
            oMiscTexts.GetMiscTexts(Convert.ToInt32(Session["language"]), 2);
            txtFirstName.Text = gvData.Rows[0].Cells[0].Text.Replace("&nbsp;", "");
            //txtMiddleName.Text = gvData.Rows[0].Cells[38].Text.Replace("&nbsp;", "");
            txtLastName.Text = gvData.Rows[0].Cells[1].Text.Replace("&nbsp;", "");
            txtBirthDate.Text = Convert.ToDateTime(gvData.Rows[0].Cells[2].Text).ToString("yyyy-MM-dd");
            ddlGender.SelectedValue = gvData.Rows[0].Cells[3].Text;
            ddlMaritalStatus.SelectedValue = gvData.Rows[0].Cells[4].Text.Replace("&nbsp;", "-" + oMiscTexts._strText + "-");
            ddlEducation.SelectedValue = gvData.Rows[0].Cells[5].Text.Replace("&nbsp;", "-" + oMiscTexts._strText + "-");
            //ddlJewishAffiliation.SelectedValue = gvData.Rows[0].Cells[6].Text.Replace("&nbsp;", "-" + oMiscTexts._strText + "-");
            ddlLanguage.SelectedValue = gvData.Rows[0].Cells[7].Text.Replace("&nbsp;", "-" + oMiscTexts._strText + "-");
            txtEmail.Text = gvData.Rows[0].Cells[8].Text.Replace("&nbsp;", "");
            txtEmailVerification.Text = gvData.Rows[0].Cells[8].Text.Replace("&nbsp;", "");
            ddlOriginalCountry.SelectedValue = gvData.Rows[0].Cells[9].Text.Replace("&nbsp;", "-" + oMiscTexts._strText + "-");
            if (gvData.Rows[0].Cells[42].Text.Contains("/USA"))
            {
                divCurrentNBNCitizen.Visible = true;
                chkbxUSCitizen.Checked = true;
            }
            if (gvData.Rows[0].Cells[42].Text.Contains("/UK"))
            {
                divCurrentNBNCitizen.Visible = true;
                chkbxUKCitizen.Checked = true;
            }
            if (gvData.Rows[0].Cells[42].Text.Contains("/Canada"))
            {
                divCurrentNBNCitizen.Visible = true;
                chkbxCACitizen.Checked = true;
            }
            if (gvData.Rows[0].Cells[9].Text == "USA" || gvData.Rows[0].Cells[9].Text == "UK" || gvData.Rows[0].Cells[9].Text == "Canada")
            {
                OriginalStateShow();
                ddlOriginalState.SelectedValue = gvData.Rows[0].Cells[11].Text;
                OriginalCityShow();
                ddlOriginalCity.SelectedValue = gvData.Rows[0].Cells[12].Text;
            }
            else if (gvData.Rows[0].Cells[9].Text == "Israel")
            {
                OriginalCityShow();
                ddlOriginalCity.SelectedValue = gvData.Rows[0].Cells[12].Text;
            }
            txtOriginalAddress.Text = gvData.Rows[0].Cells[10].Text.Replace("&nbsp;", "");
            txtZipCode.Text = gvData.Rows[0].Cells[13].Text.Replace("&nbsp;", "");
            txtOriginalMobile.Text = gvData.Rows[0].Cells[14].Text.Replace("&nbsp;", "");
            //txtOriginalHomePhone.Text = gvData.Rows[0].Cells[15].Text.Replace("&nbsp;", "");
            txtFathersNameEng.Text = gvData.Rows[0].Cells[16].Text.Replace("&nbsp;", "");
            txtMothersNameEng.Text = gvData.Rows[0].Cells[17].Text.Replace("&nbsp;", "");
            txtParentsPhone.Text = gvData.Rows[0].Cells[18].Text.Replace("&nbsp;", "");
            txtParentsEmail.Text = gvData.Rows[0].Cells[19].Text.Replace("&nbsp;", "");

            if (gvData.Rows[0].Cells[21].Text.Replace("&nbsp;", "") != "")
            {
                pnlIsraelContactInfo.Visible = true;
                ddlCurrentCountry.SelectedValue = "Israel";
                txtIsraelAddress.Text = gvData.Rows[0].Cells[20].Text.Replace("&nbsp;", ""); ;
                ddlIsraelCity.DataBind();
                ddlIsraelCity.SelectedValue = gvData.Rows[0].Cells[21].Text;
                txtIsraelMobile.Text = gvData.Rows[0].Cells[22].Text.Replace("&nbsp;", "");
            }

            if (gvData.Rows[0].Cells[24].Text.Replace("&nbsp;", "") != "")
            {
                rblTZ.SelectedValue = "Yes";
                TZShow();
                txtTZNumber.Text = gvData.Rows[0].Cells[24].Text.Replace("&nbsp;", "");
                txtTZFirstName.Text = gvData.Rows[0].Cells[25].Text.Replace("&nbsp;", "");
                txtTZLastName.Text = gvData.Rows[0].Cells[26].Text.Replace("&nbsp;", "");
            }
            else
            {
                rblTZ.SelectedValue = "No";
                TZHide();
            }

            if (Convert.ToInt32(Convert.ToDateTime(gvData.Rows[0].Cells[27].Text).Year) > 1980)
            {
                rblAliyah.SelectedValue = "Yes";
                AliyahPanelShow();
                txtAliyahDate.Text = Convert.ToDateTime(gvData.Rows[0].Cells[27].Text).ToString("yyyy-MM-dd");                
            }
            else
            {
                rblAliyah.SelectedValue = "No";
                AliyahPanelHide();
            }
            if (gvData.Rows[0].Cells[32].Text.Replace("&nbsp;", "") != "" && Convert.ToDateTime(gvData.Rows[0].Cells[32].Text.Trim()).Year.ToString() != "1899")
            {
                rblEnlistmentDate.SelectedValue = "Yes";
                EnlistmentDateShow();
                txtEnlistmentDate.Text = Convert.ToDateTime(gvData.Rows[0].Cells[32].Text).ToString("yyyy-MM-dd");
                ddlLengthOfService.SelectedValue = gvData.Rows[0].Cells[33].Text;
            }
            else
            {
                rblEnlistmentDate.SelectedValue = "No";
                EnlistmentDateHide();
            }
            if (gvData.Rows[0].Cells[35].Text.Replace("&nbsp;", "") != "" || gvData.Rows[0].Cells[36].Text.Replace("&nbsp;", "") != "")
            {
                rblMachal.SelectedValue = "Yes";
                MachalShow();
                ddlMachalStatus.SelectedValue = gvData.Rows[0].Cells[35].Text;
                ddlMachalProgram.SelectedValue = gvData.Rows[0].Cells[36].Text;
                txtMachalId.Text = gvData.Rows[0].Cells[31].Text.Replace("&nbsp;", "");
            }
            else
            {
                rblMachal.SelectedValue = "No";
                MachalHide();
            }
            if (gvData.Rows[0].Cells[30].Text.Replace("&nbsp;", "") != "")
            {
                rblCurrentlyServing.SelectedValue = "Yes";
                ActiveDutyShow();
                txtArmyId.Text = gvData.Rows[0].Cells[30].Text.Replace("&nbsp;", "");
                ddlArmyUnit.SelectedValue = HttpUtility.HtmlDecode(gvData.Rows[0].Cells[34].Text.Replace("&nbsp;", ""));
                ddlArmyTafkid.SelectedValue = HttpUtility.HtmlDecode(gvData.Rows[0].Cells[41].Text.Replace("&nbsp;", ""));
            }
            else
            {
                rblCurrentlyServing.SelectedValue = "No";
                ActiveDutyHide();
            }
        }

        protected void SetOriginalStateLabel()
        {
            MiscTexts oMiscTexts = new MiscTexts();
            if (ddlOriginalCountry.SelectedItem.Text == "USA")
            {
                oMiscTexts.GetMiscTexts(Convert.ToInt32(Session["language"]), 5);
                lblOriginalState.Text = oMiscTexts._strText;
                oMiscTexts.GetMiscTexts(Convert.ToInt32(Session["language"]), 8);
                vldtrOriginalStateRequired.ErrorMessage = oMiscTexts._strText;
            }
            else if (ddlOriginalCountry.SelectedItem.Text == "UK")
            {
                oMiscTexts.GetMiscTexts(Convert.ToInt32(Session["language"]), 7);
                lblOriginalState.Text = oMiscTexts._strText;
                oMiscTexts.GetMiscTexts(Convert.ToInt32(Session["language"]), 10);
                vldtrOriginalStateRequired.ErrorMessage = oMiscTexts._strText;
            }
            else if (ddlOriginalCountry.SelectedItem.Text == "Canada")
            {
                oMiscTexts.GetMiscTexts(Convert.ToInt32(Session["language"]), 6);
                lblOriginalState.Text = oMiscTexts._strText;
                oMiscTexts.GetMiscTexts(Convert.ToInt32(Session["language"]), 9);
                vldtrOriginalStateRequired.ErrorMessage = oMiscTexts._strText;
            }
        }

        protected void InjectClassFromControls()
        {
            Lonesoldier oLoneSoldier = new Lonesoldier();
            oLoneSoldier._strNameIdentifier = (string)(Session["nameidentifier"]);
            if (string.IsNullOrEmpty((string)(Session["guid"])) == false)
            { oLoneSoldier._strSSOGuid = (string)(Session["guid"]); }
            else
            {
                oLoneSoldier._strSSOGuid = (string)(Session["nameidentifier"]);
            }
            oLoneSoldier._strFName = (txtFirstName.Text);
            //oLoneSoldier._strMName = (txtMiddleName.Text);
            oLoneSoldier._strLName = (txtLastName.Text);
            oLoneSoldier._dtDOB = Convert.ToDateTime(txtBirthDate.Text);
            oLoneSoldier._strGender = (ddlGender.SelectedValue);
            oLoneSoldier._strMaritalStatus = (ddlMaritalStatus.Text);
            oLoneSoldier._strEducation = (ddlEducation.Text);
            //oLoneSoldier._strJewishAffiliation = (ddlJewishAffiliation.Text);
            oLoneSoldier._strLanguage = (ddlLanguage.SelectedValue);
            oLoneSoldier._strEmail = (txtEmail.Text);
            oLoneSoldier._strOriginalCountry = (ddlOriginalCountry.SelectedValue);
            oLoneSoldier._strCitizenship = CitizenshipString();
            oLoneSoldier._strOriginalAddress = (txtOriginalAddress.Text);
            oLoneSoldier._strOriginalState = (ddlOriginalState.SelectedValue);
            oLoneSoldier._strOriginalCity = (ddlOriginalCity.SelectedValue);
            oLoneSoldier._strZipCode = (txtZipCode.Text);
            oLoneSoldier._strOriginalCell = (txtOriginalMobile.Text);
            //oLoneSoldier._strOriginalHomePhone = (txtOriginalHomePhone.Text);
            oLoneSoldier._strFathersNameEn = (txtFathersNameEng.Text);
            oLoneSoldier._strMothersNameEn = (txtMothersNameEng.Text);
            oLoneSoldier._strParentsPhone = (txtParentsPhone.Text);
            oLoneSoldier._strParentsEmail = (txtParentsEmail.Text);
            oLoneSoldier._strCurrentCountry = (ddlCurrentCountry.SelectedValue);
            oLoneSoldier._strIsraelAddress = (txtIsraelAddress.Text);
            oLoneSoldier._strIsraelCity = (ddlIsraelCity.SelectedValue);
            oLoneSoldier._strIsraelCell = (txtIsraelMobile.Text);
            oLoneSoldier._strTZNumber = (txtTZNumber.Text);
            oLoneSoldier._strTZFirstNameHe = (txtTZFirstName.Text);
            oLoneSoldier._strTZLastNameHe = (txtTZLastName.Text);
            if (rblAliyah.SelectedValue == "Yes")
            {
                oLoneSoldier._dtAliyahDate = Convert.ToDateTime(txtAliyahDate.Text);                
            }
            //oLoneSoldier._strCourseElite = rblCourseElite.SelectedValue;
            if (rblEnlistmentDate.SelectedValue == "Yes")
            {
                oLoneSoldier._dtEnlistmentDate = Convert.ToDateTime(txtEnlistmentDate.Text);
                oLoneSoldier._strLengthOfService = ddlLengthOfService.SelectedValue;
            }
            else
            {
                oLoneSoldier._dtEnlistmentDate = Convert.ToDateTime("1899-12-30 00:00:00.000");
                oLoneSoldier._strLengthOfService = "";
            }
            if (rblMachal.SelectedValue == "Yes")
            {
                oLoneSoldier._strMachalStatus = ddlMachalStatus.SelectedValue;
                oLoneSoldier._strMachalProgram = (ddlMachalProgram.SelectedValue);
            }
            if (rblCurrentlyServing.SelectedValue == "Yes")
            {
                oLoneSoldier._strArmyId = (txtArmyId.Text);
                oLoneSoldier._strMachalId = (txtMachalId.Text);
                oLoneSoldier._strArmyUnit = (ddlArmyUnit.SelectedValue);
                oLoneSoldier._strRoleType = (ddlArmyTafkid.SelectedValue);
            }
            ClayInjectorClass ClayInjector = new ClayInjectorClass();
            ClayInjector.CreateInjection(oLoneSoldier);

        }

        protected DocUpload DocUpload()
        {
            //ensure the injection happened by getting a non empty clay guid
            string strClayGuid = "";
            string strDagId = "";
            while (strClayGuid == "")
            {
                gvData.DataBind();
                if (gvData.Rows.Count > 0)
                {
                    strClayGuid = gvData.Rows[0].Cells[37].Text.Replace("&nbsp;", "");
                    strDagId = gvData.Rows[0].Cells[43].Text.Replace("&nbsp;", "");
                }

            }
            //populate class
            DocUpload oDocUpload = new DocUpload();
            oDocUpload._strUploadUrl = "https://start.nbn.org.il/DocumentUpload.aspx?";
            oDocUpload._strClayGuid = "&clayguid=" + strClayGuid;
            oDocUpload._strDagGuid = "&dagguid=" + strClayGuid;
            oDocUpload._strDagIdContact = "&dagcid=" + strClayGuid;
            oDocUpload._strFirstName = "&first=" + txtFirstName.Text;
            oDocUpload._strMiddleName = "&middle=" + gvData.Rows[0].Cells[38].Text.Replace("&nbsp;", "");
            if (ddlMaritalStatus.SelectedValue == "Married")
            {
                oDocUpload._strFamilyStatus = "&famstatus=Married";
            }
            else
            {
                oDocUpload._strFamilyStatus = "&famstatus=Single";
            }
            oDocUpload._strContactStatus = "&constatus=Primary";
            oDocUpload._strOverwrite = "&overwrite=0";

            return oDocUpload;
        }

        protected void AddDisclaimerText()
        {
            MiscTexts oMiscTexts = new MiscTexts();
            oMiscTexts.GetMiscTexts(Convert.ToInt32(Session["language"]), 1);
            txtDisclaimer.Text = oMiscTexts._strText;
        }

        protected void AddSubmitText()
        {
            MiscTexts oMiscTexts = new MiscTexts();
            oMiscTexts.GetMiscTexts(Convert.ToInt32(Session["language"]), 12);
            btnSubmit.Text = oMiscTexts._strText;
        }

        protected void AddThankYouText()
        {
            MiscTexts oMiscTexts = new MiscTexts();
            oMiscTexts.GetMiscTexts(Convert.ToInt32(Session["language"]), 13);
            lblThankYou.Text = oMiscTexts._strText;
        }

        protected void AddFileUploadInstructionsText()
        {
            MiscTexts oMiscTexts = new MiscTexts();
            oMiscTexts.GetMiscTexts(Convert.ToInt32(Session["language"]), 11);
            lblFileUploadInstructions.Text = oMiscTexts._strText;
        }

        protected string DocUploadURL(string strNamingStandard)
        {
            DocUpload oDocUpload = DocUpload();
            string strDocUploadURL = oDocUpload._strUploadUrl;
            strDocUploadURL += "ns=" + strNamingStandard;
            strDocUploadURL += oDocUpload._strClayGuid;
            strDocUploadURL += oDocUpload._strDagGuid;
            strDocUploadURL += oDocUpload._strDagIdContact;
            strDocUploadURL += oDocUpload._strFirstName;
            strDocUploadURL += oDocUpload._strMiddleName;
            strDocUploadURL += oDocUpload._strFamilyStatus;
            strDocUploadURL += oDocUpload._strContactStatus;
            strDocUploadURL += oDocUpload._strOverwrite;
            return strDocUploadURL;
        }

        protected void PopulateUploadLinks()
        {
            string strUploadLinkPrefix = "<a target=\"ifrmFileUpload\" href=\"";
            string strUploadLinkClose = "</a>";

            ltrlPassportPhotoLink.Text = strUploadLinkPrefix + DocUploadURL("Family%20Photo") + "#end\">";
            ltrlClosePassportPhotoLink.Text = strUploadLinkClose;

            ltrlLSPCertificateLink.Text = strUploadLinkPrefix + DocUploadURL("LSP%20Cert") + "#end\">";
            ltrlCloseLSPCertificateLink.Text = strUploadLinkClose;

            ltrlDraftNoticeLink.Text = strUploadLinkPrefix + DocUploadURL("Draft") + "#end\">";
            ltrlCloseDraftNoticeLink.Text = strUploadLinkClose;

            ltrlIshurMachalLink.Text = strUploadLinkPrefix + DocUploadURL("Ishur%20Machal") + "#end\">";
            ltrlCloseIshurMachalLink.Text = strUploadLinkClose;

            ltrlTeudatOlehLink.Text = strUploadLinkPrefix + DocUploadURL("TO%20-%20$$$") + "#end\">";
            ltrlCloseTeudatOlehLink.Text = strUploadLinkClose;
        }

        #endregion;

        
    }
}