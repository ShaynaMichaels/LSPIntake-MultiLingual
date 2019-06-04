<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="True" CodeBehind="IntakeForm.aspx.cs" Inherits="LSPIntake.IntakeForm" MaintainScrollPositionOnPostback="true" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

        <div class="jumbotron">
        <h1>LSP Intake Form</h1>
        <p class="lead">Please Answer the following questions</p>
        </div>
    <asp:ValidationSummary ID="valSum"
        DisplayMode="List"
        EnableClientScript="true"
        HeaderText="Required Fields:"
        runat="server"
        ForeColor="Red" />
    <asp:Label ID="lblDebugText" runat="server" Text=""></asp:Label>
    <asp:Panel ID="pnlPersonalDetails" runat="server">
        <h2>
            <asp:Label ID="lblHeadingPersonalDetails" runat="server" Text="Label"></asp:Label></h2>
        <h3>
            <asp:Label ID="lblSubheadingPersonalDetails" runat="server" Text="Label"></asp:Label></h3>
        <p>
            <asp:Label ID="lblQ1Legalfirstname" runat="server"></asp:Label>
        </p>

        <p>
            <asp:TextBox ID="txtFirstName" runat="server" AutoPostBack="false" CssClass="Capitalize" OnFocusOut="javascript:capitalize(this.id, this.value);"></asp:TextBox>
            <asp:RequiredFieldValidator ID="vldtrFirstNameRequired" runat="server" ErrorMessage="First Name is Required" ControlToValidate="txtFirstName" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="vldtrFirstNameRegex" runat="server" ErrorMessage="Invalid First Name" ValidationExpression="^[a-zA-Z ]+$" ControlToValidate="txtFirstName" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
        </p>
        <%--<p>

            <asp:Label ID="lblQ2Legalmiddlename" runat="server"></asp:Label>
        </p>
        <p>
            <asp:TextBox ID="txtMiddleName" runat="server" AutoPostBack="false" CssClass="Capitalize" OnFocusOut="javascript:capitalize(this.id, this.value);"></asp:TextBox>
            <asp:RegularExpressionValidator ID="vldtrMiddleNameRegex" runat="server" ErrorMessage="Invalid Middle Name" ValidationExpression="^[a-zA-Z ]+$" ControlToValidate="txtMiddleName" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
        </p>--%>
        <p>
            <asp:Label ID="lblQ3Legallastname" runat="server"></asp:Label>
        </p>
        <p>
            <asp:TextBox ID="txtLastName" runat="server" AutoPostBack="false" CssClass="Capitalize" OnFocusOut="javascript:capitalize(this.id, this.value);"></asp:TextBox>
            <asp:RequiredFieldValidator ID="vldtrLastNameRequired" runat="server" ErrorMessage="Last Name is Required" ControlToValidate="txtLastName" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="vldtrLastNameRegex" runat="server" ErrorMessage="Invalid Last Name" ValidationExpression="^[a-zA-Z ]+$" ControlToValidate="txtLastName" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
        </p>
        <p>
            <asp:Label ID="lblQ4DateofBirth" runat="server"></asp:Label>
        </p>
        <p>
            <asp:TextBox ID="txtBirthDate" CssClass="datepicker" TextMode="Date" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="vldtrDOBRequired" runat="server" ControlToValidate="txtBirthDate" ErrorMessage="Birthdate is Required" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
        </p>
        <p>
            <asp:Label ID="lblQ5Gender" runat="server"></asp:Label>
        </p>
        <%--<asp:RadioButtonList ID="rblAliyah" RepeatDirection="Horizontal" runat="server" CellPadding="10" OnSelectedIndexChanged="rblAliyah_SelectedIndexChanged" AutoPostBack="True" DataSourceID="datasrcYesNo" DataTextField="Text" DataValueField="Value">
                </asp:RadioButtonList>--%>
        <asp:RadioButtonList ID="ddlGender" CssClass="radiobuttons" RepeatDirection="Horizontal" runat="server" CellPadding="10" DataSourceID="datasrcDdlGender" DataTextField="Text" DataValueField="Value"></asp:RadioButtonList>
         <asp:SqlDataSource ID="datasrcDdlGender" runat="server" ConnectionString="<%$ ConnectionStrings:AdminConnectionString %>" SelectCommand="prLSPDropDownTextsGet" SelectCommandType="StoredProcedure">
                <SelectParameters>
                    <asp:Parameter DefaultValue="8" Name="DropdownId" Type="Int32" />
                    <asp:SessionParameter DefaultValue="1" Name="LanguageId" SessionField="language" Type="Int32" />
                </SelectParameters>
            </asp:SqlDataSource>
        <asp:RequiredFieldValidator ID="vldtrGenderRequired" runat="server" ErrorMessage="Gender is Required" ControlToValidate="ddlGender" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
        <p>
            <asp:Label ID="lblQ6Maritalstatus" runat="server"></asp:Label>
        </p>
        <p>
            <asp:DropDownList id="ddlMaritalStatus" CssClass="dropdown" runat="server" DataSourceID="dataSrcDdlMaritalStatus" DataTextField="Text" DataValueField="Value">
            </asp:DropDownList>
            <asp:SqlDataSource ID="dataSrcDdlMaritalStatus" runat="server" ConnectionString="<%$ ConnectionStrings:AdminConnectionString %>" SelectCommand="prLSPDropDownTextsGet" SelectCommandType="StoredProcedure">
                <SelectParameters>
                    <asp:Parameter DefaultValue="1" Name="DropdownId" Type="Int32" />
                    <asp:SessionParameter DefaultValue="1" Name="LanguageId" SessionField="language" Type="Int32" />
                </SelectParameters>
            </asp:SqlDataSource>
            <asp:RequiredFieldValidator ID="vldtrMaritalStatusRequired" runat="server" InitialValue="-Select-" ErrorMessage="Marital Status is Required" ControlToValidate="ddlMaritalStatus" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
        </p>
        <p>
            <asp:Label ID="lblQ7Education" runat="server"></asp:Label>
        </p>
        <p>
            <asp:DropDownList ID="ddlEducation" CssClass="dropdown" runat="server" DataSourceID="dataSrcEducation" DataTextField="Text" DataValueField="Value" AutoPostBack="false">
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="vldtrEducationRequired" runat="server" InitialValue="-Select-" ErrorMessage="Education is Required" ControlToValidate="ddlEducation" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
            <asp:SqlDataSource ID="dataSrcEducation" runat="server" ConnectionString="<%$ ConnectionStrings:AdminConnectionString %>" SelectCommand="prLSPDropDownTextsGet" SelectCommandType="StoredProcedure">
                <SelectParameters>
                    <asp:Parameter DefaultValue="2" Name="DropdownId" Type="Int32" />
                    <asp:SessionParameter DefaultValue="1" Name="LanguageId" SessionField="language" Type="Int32" />
                </SelectParameters>
            </asp:SqlDataSource>
        </p>
        <%--<p>
            <asp:Label ID="lblQ8JewishAffiliation" runat="server"></asp:Label>
        </p>
        <p>
            <asp:DropDownList ID="ddlJewishAffiliation" CssClass="dropdown" runat="server" DataSourceID="dataSrcAffiliation" DataTextField="Text" DataValueField="Value" AutoPostBack="false">
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="vldtrAffiliationRequired" runat="server" InitialValue="-Select-" ErrorMessage="Jewish Affiliation is Required" ControlToValidate="ddlJewishAffiliation" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
            <asp:SqlDataSource ID="dataSrcAffiliation" runat="server" ConnectionString="<%$ ConnectionStrings:AdminConnectionString %>" SelectCommand="prLSPDropDownTextsGet" SelectCommandType="StoredProcedure">
                <SelectParameters>
                    <asp:Parameter DefaultValue="3" Name="DropdownId" Type="Int32" />
                    <asp:SessionParameter DefaultValue="1" Name="LanguageId" SessionField="language" Type="Int32" />
                </SelectParameters>
            </asp:SqlDataSource>
        </p>--%>
        <p>
            <asp:Label ID="lblQ9PreferredLanguage" runat="server"></asp:Label>
        </p>
        <p>
            <asp:DropDownList ID="ddlLanguage" CssClass="dropdown" runat="server" DataSourceID="dataSrcLanguage" DataTextField="LanguageDisplayName" DataValueField="Language" AutoPostBack="false">
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="vldtrLanguageRequired" runat="server" InitialValue="-Select-" ErrorMessage="Preferred language is Required" ControlToValidate="ddlLanguage" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
            <asp:SqlDataSource ID="dataSrcLanguage" runat="server" ConnectionString="<%$ ConnectionStrings:AdminConnectionString %>" SelectCommand="SELECT [Language], [LanguageDisplayName] FROM [Languages]"></asp:SqlDataSource>
        </p>
        <p>
            <asp:Label ID="lblQ10Email" runat="server"></asp:Label>
        </p>
        <p>
            <asp:TextBox ID="txtEmail" runat="server" AutoPostBack="false"></asp:TextBox>
            <asp:RegularExpressionValidator ID="vldtrEmailRegex" runat="server" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txtEmail" ErrorMessage="Invalid Email Format" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
            <asp:RequiredFieldValidator ID="VldtrEmailRequired" runat="server" ErrorMessage="Email is Required" ControlToValidate="txtEmail" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
        </p>
        <p>
            <asp:Label ID="lblQ11Emailverification" runat="server"></asp:Label>
        </p>
        <p>
            <asp:TextBox ID="txtEmailVerification" runat="server" AutoPostBack="false"></asp:TextBox>
            <asp:CompareValidator ID="vldtrEmailVerificationCompare" runat="server" ErrorMessage="Verification Email does not match" ControlToValidate="txtEmailVerification" ControlToCompare="txtEmail" ForeColor="Red" Display="Dynamic"></asp:CompareValidator>
            <asp:RequiredFieldValidator ID="vldtrEmailVerificationRequired" runat="server" ErrorMessage="Email verification is Required" ControlToValidate="txtEmailVerification" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
        </p>
        <asp:UpdatePanel ID="UpdatePanelOriginalCountry" runat="server">
            <ContentTemplate>
                <p>
                    <asp:Label ID="lblQ12OriginalCountry" runat="server"></asp:Label>
                </p>
                <p>
                    <asp:DropDownList ID="ddlOriginalCountry" CssClass="dropdown" runat="server" DataSourceID="SqlDataSource3" DataTextField="Country" DataValueField="Country" AutoPostBack="true" OnSelectedIndexChanged="ddlOriginalCountry_SelectedIndexChanged">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:AdminConnectionString %>" SelectCommand="prCountryStateCityGet" SelectCommandType="StoredProcedure">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="1" Name="SearchType" Type="Int32" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                    <asp:RequiredFieldValidator ID="vldtrOriginalCountryRequired" InitialValue="-Select-" runat="server" ErrorMessage="Original Country is Required" ControlToValidate="ddlOriginalCountry" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                </p>
                <div id="divCurrentNBNCitizen" runat="server" visible="false">
                    <p>
                        <asp:Label ID="lblQ13IHoldTheFollowingCitizinship" runat="server"></asp:Label><br />
                        <asp:CheckBox ID="chkbxUSCitizen" runat="server" AutoPostBack="true" OnCheckedChanged="chkbxUSCitizen_CheckedChanged" />USA<br />
                        <asp:CheckBox ID="chkbxUKCitizen" runat="server" AutoPostBack="true" OnCheckedChanged="chkbxUKCitizen_CheckedChanged" />UK<br />
                        <asp:CheckBox ID="chkbxCACitizen" runat="server" AutoPostBack="true" OnCheckedChanged="chkbxCACitizen_CheckedChanged" />Canada<br />
                        <asp:CheckBox ID="chkbxNotNBNCitizen" runat="server" AutoPostBack="true" OnCheckedChanged="chkbxNotNBNCitizen_CheckedChanged" /><asp:Label ID="lblNotNBNCitizen" runat="server"></asp:Label>
                    </p>
                </div>
                <div id="divOriginalState" visible="false" runat="server">
                    <p>
                        <asp:Label ID="lblQ15OriginalState" runat="server"></asp:Label>
                        <asp:Label ID="lblOriginalState" runat="server" Text=""></asp:Label>
                    </p>
                    <p>
                        <asp:DropDownList ID="ddlOriginalState" CssClass="dropdown" runat="server" DataTextField="State" DataValueField="State" AutoPostBack="true" OnSelectedIndexChanged="ddlOriginalState_SelectedIndexChanged">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="vldtrOriginalStateRequired" runat="server" InitialValue="-Select-" ErrorMessage="Required" ForeColor="Red" Display="Dynamic" ControlToValidate="ddlOriginalState"></asp:RequiredFieldValidator>
                        <asp:SqlDataSource ID="SqlDataSourceOriginalState" runat="server" ConnectionString="<%$ ConnectionStrings:AdminConnectionString %>" SelectCommand="prCountryStateCityGet" SelectCommandType="StoredProcedure">
                            <SelectParameters>
                                <asp:Parameter DefaultValue="2" Name="SearchType" Type="Int32" />
                                <asp:ControlParameter ControlID="ddlOriginalCountry" DefaultValue="" Name="Country" PropertyName="SelectedValue" Type="String" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                    </p>
                </div>
                <div id="divOriginalCity" visible="false" runat="server">
                    <p>
                        <asp:Label ID="lblQ16OriginalCity" runat="server"></asp:Label>
                    </p>
                    <p>
                        <asp:DropDownList ID="ddlOriginalCity" CssClass="dropdown" runat="server" DataTextField="City" DataValueField="City" AutoPostBack="true" OnSelectedIndexChanged="ddlOriginalCity_SelectedIndexChanged">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="vldtrOriginalCityRequired" runat="server" InitialValue="-Select-" ErrorMessage="Original City is Required" ForeColor="Red" Display="Dynamic" ControlToValidate="ddlOriginalCity"></asp:RequiredFieldValidator>
                        <asp:SqlDataSource ID="SqlDataSourceOriginalCity" runat="server" ConnectionString="<%$ ConnectionStrings:AdminConnectionString %>" SelectCommand="prCountryStateCityGet" SelectCommandType="StoredProcedure">
                            <SelectParameters>
                                <asp:Parameter DefaultValue="3" Name="SearchType" Type="Int32" />
                                <asp:ControlParameter ControlID="ddlOriginalCountry" Name="Country" PropertyName="SelectedValue" Type="String" />
                                <asp:ControlParameter ControlID="ddlOriginalState" DefaultValue="" Name="State" PropertyName="SelectedValue" Type="String" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                    </p>
                </div>
                <div id="divOriginalPostalAddress" visible="false" runat="server">
                    <p>
                        <asp:Label ID="lblQ14OriginalAddressStreetAddress" runat="server"></asp:Label>
                    </p>
                    <p>
                        <asp:TextBox ID="txtOriginalAddress" runat="server"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="vldtrOriginalAddressRegex" runat="server" ControlToValidate="txtOriginalAddress" ValidationExpression="^$|^[A-Za-z0-9 _.,-]{5,35}$" ErrorMessage="Original Address contains invalid characters" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                        <asp:RequiredFieldValidator ID="vldtrOriginalAddressRequired" runat="server" ErrorMessage="Original address is Required" ControlToValidate="txtOriginalAddress" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                    </p>
                    <p>
                        <asp:Label ID="lblQ17Zipcode" runat="server"></asp:Label>
                    </p>
                    <p>
                        <asp:TextBox ID="txtZipCode" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="vldtrZipCodeRequired" runat="server" ErrorMessage="Postal Code is Required" ControlToValidate="txtZipCode" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                    </p>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        <p>
            <asp:Label ID="lblQ18OriginalMobile" runat="server"></asp:Label>
        </p>
        <p>
            <asp:TextBox ID="txtOriginalMobile" runat="server"></asp:TextBox>
            <asp:RegularExpressionValidator ID="vldtrOriginalMobileRegex" runat="server" ControlToValidate="txtOriginalMobile" ValidationExpression="\d{3}-\d{3}-\d{4}" ErrorMessage="Original Mobile Phone must be in the format xxx-xxx-xxxx" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
            <asp:RequiredFieldValidator ID="vldtrOriginalMobileRequired" runat="server" ErrorMessage="Original Mobile Phone is Required" ControlToValidate="txtOriginalMobile" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
        </p>
        <p>
            <asp:Label ID="lblQ20FathersFullNameEnglish" runat="server"></asp:Label>
        </p>
        <p>
            <asp:TextBox ID="txtFathersNameEng" runat="server" AutoPostBack="false" CssClass="Capitalize" OnFocusOut="javascript:capitalize(this.id, this.value);"></asp:TextBox>
            <asp:RegularExpressionValidator ID="vldtrFathersNameEngRegex" runat="server" ErrorMessage="Invalid Fathers Name" ValidationExpression="^[a-zA-Z ]+$" ControlToValidate="txtFathersNameEng" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
            <asp:RequiredFieldValidator ID="vldtrFathersNameEngRequired" runat="server" ErrorMessage="Fathers name is Required" ControlToValidate="txtFathersNameEng" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
        </p>
        <p>
            <asp:Label ID="lblQ21MothersFullNameEnglish" runat="server"></asp:Label>
        </p>
        <p>
            <asp:TextBox ID="txtMothersNameEng" runat="server" AutoPostBack="false" CssClass="Capitalize" OnFocusOut="javascript:capitalize(this.id, this.value);"></asp:TextBox>
            <asp:RegularExpressionValidator ID="vldtrMothersNameEngRegex" runat="server" ErrorMessage="Invalid Mothers Name" ValidationExpression="^[a-zA-Z ]+$" ControlToValidate="txtMothersNameEng" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
            <asp:RequiredFieldValidator ID="vldtrMothersNameEngRequired" runat="server" ErrorMessage="Mothers Name is Required" ControlToValidate="txtMothersNameEng" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
        </p>
        <p>
            <asp:Label ID="lblQ22ParentsPhone" runat="server"></asp:Label>
        </p>
        <p>
            <asp:TextBox ID="txtParentsPhone" runat="server"></asp:TextBox>
            <asp:RegularExpressionValidator ID="vldtrParentsPhoneRegex" runat="server" ErrorMessage="Invalid Parents Phone number" ControlToValidate="txtParentsPhone" ValidationExpression="^$|^[0-9 _.,\(\)-]{5,35}$" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
            <asp:RequiredFieldValidator ID="vldtrParentsPhoneRequired" runat="server" ErrorMessage="Parents Phone is Required" ControlToValidate="txtParentsPhone" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
        </p>
        <p>
            <asp:Label ID="lblQ23ParentsEmail" runat="server"></asp:Label>
        </p>
        <p>
            <asp:TextBox ID="txtParentsEmail" runat="server"></asp:TextBox>
            <asp:RegularExpressionValidator ID="vldtrParentsEmailRegex" runat="server" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txtParentsEmail" ErrorMessage="Invalid Parents Email Format" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
            <asp:RequiredFieldValidator ID="vldtrParentsEmailRequired" runat="server" ErrorMessage="Parents Email is Required" ControlToValidate="txtParentsEmail" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
        </p>
    </asp:Panel>
    <asp:Panel ID="pnlGeneralInfo" runat="server">
        <h2>
            <asp:Label ID="lblHeadingGeneralInformation" runat="server" Text="Label"></asp:Label></h2>
        <h3>
            <asp:Label ID="lblSubheadingGeneralInformation" runat="server" Text="Label"></asp:Label></h3>
        <asp:UpdatePanel ID="UpdatePanelGeneralInfo" runat="server">
            <ContentTemplate>
                <p>
                    <asp:Label ID="lblQ24Whatcountrydoyouliveintoday" runat="server"></asp:Label>
                </p>
                <p>
                    <asp:DropDownList ID="ddlCurrentCountry" CssClass="dropdown" runat="server" DataSourceID="SqlDataSource1" DataTextField="Country" DataValueField="Country" OnSelectedIndexChanged="ddlCurrentCountry_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="vldtrCurrentCountryRequired" runat="server" InitialValue="-Select-" ErrorMessage="Country of residence is Required" ControlToValidate="ddlCurrentCountry" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:AdminConnectionString %>" SelectCommand="prCountryStateCityGet" SelectCommandType="StoredProcedure">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="1" Name="SearchType" Type="Int32" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                </p>
                <asp:Panel ID="pnlIsraelContactInfo" runat="server" Visible="false">
                    <p>
                        <asp:Label ID="lblQ25IsraelAddres" runat="server"></asp:Label>
                    </p>
                    <p>
                        <asp:TextBox ID="txtIsraelAddress" runat="server"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="vldtrIsraelAddressRegex" runat="server" ErrorMessage="Israel address contains invalid characters" ValidationExpression="^[0-9a-zA-Z ,/.]+$" ControlToValidate="txtIsraelAddress" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                    </p>
                    <p>
                        <asp:Label ID="lblQ26IsraelCity" runat="server"></asp:Label>
                    </p>    
                    <p>
                        <asp:DropDownList ID="ddlIsraelCity" CssClass="dropdown" runat="server" DataSourceID="SqlDataSourceIsraelCity" DataTextField="City" DataValueField="City">
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="SqlDataSourceIsraelCity" runat="server" ConnectionString="<%$ ConnectionStrings:AdminConnectionString %>" SelectCommand="prCountryStateCityGet" SelectCommandType="StoredProcedure">
                            <SelectParameters>
                                <asp:Parameter DefaultValue="3" Name="SearchType" Type="Int32" />
                                <asp:Parameter DefaultValue="Israel" Name="Country" Type="String" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                        <asp:RequiredFieldValidator ID="vldtrIsraelCityRequired" runat="server" InitialValue="-Select-" ErrorMessage="City is required" ControlToValidate="ddlIsraelCity" Enabled="false" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                    </p>
                    <p>
                        <asp:Label ID="lblQ27IsraelCellPhone" runat="server"></asp:Label>
                    </p>
                    <p>
                        <asp:TextBox ID="txtIsraelMobile" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="vldtrIsraelMobileRequired" runat="server" ErrorMessage="Israel mobile is required" ForeColor="Red" Display="Dynamic" ControlToValidate="txtIsraelMobile"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="vldtrIsraelMobileRegex" ControlToValidate="txtIsraelMobile" ValidationExpression="\d{3}-\d{3}-\d{4}" runat="server" ErrorMessage="Israel Mobile number must be in the format xxx-xxx-xxxx" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                    </p>
               </asp:Panel>
                <p>
                    <asp:Label ID="lblQ29DidyoumakeAliyah" runat="server"></asp:Label>
                </p>
                <asp:RadioButtonList ID="rblAliyah" CssClass="radiobuttons" RepeatDirection="Horizontal" runat="server" CellPadding="10" OnSelectedIndexChanged="rblAliyah_SelectedIndexChanged" AutoPostBack="True" DataSourceID="datasrcYesNo" DataTextField="Text" DataValueField="Value">
                </asp:RadioButtonList>
                <asp:SqlDataSource ID="datasrcYesNo" runat="server" ConnectionString="<%$ ConnectionStrings:AdminConnectionString %>" SelectCommand="prLSPDropDownTextsGet" SelectCommandType="StoredProcedure">
                    <SelectParameters>
                        <asp:Parameter DefaultValue="6" Name="DropdownId" Type="Int32" />
                        <asp:SessionParameter DefaultValue="1" Name="LanguageId" SessionField="language" Type="Int32" />
                    </SelectParameters>
                </asp:SqlDataSource>
                <asp:RequiredFieldValidator ID="vldtrAliyahOptionRequired" runat="server" ControlToValidate="rblAliyah" ErrorMessage="Please select an Aliyah Option" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                <asp:Panel ID="pnlAliyah" runat="server" Visible="false">
                    <p>
                        <asp:Label ID="lblQ34DateofAliyah" runat="server"></asp:Label>
                    </p>
                    <p>
                        <asp:TextBox ID="txtAliyahDate" class ="datepicker" TextMode="Date" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="vldtrAliyahDateRequired" runat="server" ControlToValidate="txtAliyahDate" ErrorMessage="Aliyah Date is Required" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                    </p>
                </asp:Panel>
                <p>
                    <asp:Label ID="lblQ30DoyouhaveanisraeliIDnumber" runat="server"></asp:Label>
                </p>
                <asp:RadioButtonList ID="rblTZ" CssClass="radiobuttons" runat="server" CellPadding="10" RepeatDirection="Horizontal" AutoPostBack="true" OnSelectedIndexChanged="rblTZ_SelectedIndexChanged" DataSourceID="datasrcYesNo" DataTextField="Text" DataValueField="Value">
                </asp:RadioButtonList>
                <asp:RequiredFieldValidator ID="vldtrTZOptionRequired" runat="server" ControlToValidate="rblTZ" ErrorMessage="Please select an Israeli Id option" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                <asp:Panel ID="pnlTeudatZehut" runat="server" Visible="false">
                    <p>
                        <asp:Label ID="lblQ31TZNumber" runat="server"></asp:Label>
                    </p>
                    <p>
                        <asp:TextBox ID="txtTZNumber" runat="server"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="vldtrTZNumberRegex" runat="server" ErrorMessage="Invalid Israeli ID number" ValidationExpression="^[0-9]{9}$" ControlToValidate="txtTZNumber" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                        <asp:RequiredFieldValidator ID="vldtrTZNumberRequired" runat="server" ErrorMessage="ID Number is required" ControlToValidate="txtTZNumber" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                    </p>
                    <p>
                        <asp:Label ID="lblQ32FirstNameonTZHebrew" runat="server"></asp:Label>
                    </p>
                    <p>
                        <asp:TextBox ID="txtTZFirstName" runat="server"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="vldtrTZFirstNameRegex" runat="server" ControlToValidate="txtTZFirstName" ErrorMessage="Please enter TZ first name in Hebrew" ValidationExpression="[אבגדהוזחטיכלמנסעפצקרשתץףןם\s\.]*" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                        <asp:RequiredFieldValidator ID="vldtrTZFirstNameRequired" runat="server" ErrorMessage="First Name on Teudat Zehut is required" ControlToValidate="txtTZFirstName" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                    </p>
                    <p>
                        <asp:Label ID="lblQ33LastnameonTZHebrew" runat="server"></asp:Label>
                    </p>
                    <p>
                        <asp:TextBox ID="txtTZLastName" runat="server"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="vldtrTZLastNameRegex" runat="server" ControlToValidate="txtTZLastName" ErrorMessage="Please enter TZ last name in Hebrew" ValidationExpression="[אבגדהוזחטיכלמנסעפצקרשתץףןם\s\.]*" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                        <asp:RequiredFieldValidator ID="vldtrTZLastNameRequired" runat="server" ErrorMessage="Last Name on Teudat Zehut is required" ControlToValidate="txtTZLastName" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                    </p>
                </asp:Panel>
            </ContentTemplate>
        </asp:UpdatePanel>
    </asp:Panel>
    <asp:Panel ID="pnlArmyDetails" runat="server">
        <asp:UpdatePanel ID="updatePanelArmy" runat="server">
            <ContentTemplate>
                <h2>
                    <asp:Label ID="lblHeadingArmyDetails" runat="server" Text="Label"></asp:Label></h2>
                <h3>
                    <asp:Label ID="lblSubheadingArmyDetails" runat="server" Text="Label"></asp:Label></h3>
                <p>
                    <asp:Label ID="lblQ49EnlistmentDate" runat="server"></asp:Label>
                </p>
                <p>
                    <asp:RadioButtonList ID="rblEnlistmentDate" CssClass="radiobuttons" runat="server" CellPadding="10" RepeatDirection="Horizontal" Width="116px" AutoPostBack="true" OnSelectedIndexChanged="rblEnlistmentDate_SelectedIndexChanged" DataSourceID="datasrcYesNo" DataTextField="Text" DataValueField="Value">
                    </asp:RadioButtonList>
                    <asp:RequiredFieldValidator ID="vldtrEnlistmentRequired" runat="server" ControlToValidate="rblEnlistmentDate" ErrorMessage="Please select an Enlistment Date option" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                </p>
                <asp:Panel ID="pnlEnlistmentDate" runat="server" Visible="false">
                    <p>
                        <asp:Label ID="lblQ41EnlistmentDate" runat="server"></asp:Label>
                    </p>
                    <p>
                        <asp:TextBox ID="txtEnlistmentDate" CssClass="datepicker" TextMode="Date" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="vldtrEnlistmentDateRequired" runat="server" ErrorMessage="Enlistment date is required" ControlToValidate="txtEnlistmentDate" Enabled="false" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                    </p>
                    <p>
                        <asp:Label ID="lblQ42LengthOfService" runat="server"></asp:Label>
                    </p>
                    <p>
                        <asp:DropDownList ID="ddlLengthOfService" CssClass="dropdown" runat="server" DataSourceID="datasrcLengthOfService" DataTextField="Val" DataValueField="Val"></asp:DropDownList>
                        <asp:SqlDataSource ID="datasrcLengthOfService" runat="server" ConnectionString="<%$ ConnectionStrings:ClayConnectionString %>" SelectCommand="SELECT Val FROM DCDB..LookupLists WHERE ItemType = 1 and FieldConst = 552"></asp:SqlDataSource>
                        <asp:RequiredFieldValidator ID="vldtrLengthOfServiceRequired" runat="server" ErrorMessage="Length of Service is required" ControlToValidate="ddlLengthOfService" Enabled="false" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                    </p>
                </asp:Panel>
                <asp:Panel ID="pnlMachalOption" runat="server" Visible="false">
                <p>Are you planning to join/part of Machal?</p>
                <p>
                    <asp:RadioButtonList ID="rblMachal" CssClass="radiobuttons" runat="server" CellPadding="10" RepeatDirection="Horizontal" Width="116px" OnSelectedIndexChanged="rblMachal_SelectedIndexChanged" AutoPostBack="true" DataSourceID="datasrcYesNo" DataTextField="Text" DataValueField="Value">
                    </asp:RadioButtonList>
                    <asp:RequiredFieldValidator ID="vldtrMachalOptionRequired" runat="server" ControlToValidate="rblMachal" ErrorMessage="Please select a Machal option" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                </p>
                </asp:Panel>
                <asp:Panel ID="pnlMachal" runat="server" Visible="false">
                    <p>
                        <asp:Label ID="lblQ37MachalStatus" runat="server"></asp:Label>
                    </p>
                    <p>
                        <asp:DropDownList ID="ddlMachalStatus" CssClass="dropdown" runat="server" Width="116px" DataSourceID="SqlDataSourceMachalStatus" DataTextField="Text" DataValueField="Value">
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="SqlDataSourceMachalStatus" runat="server" ConnectionString="<%$ ConnectionStrings:AdminConnectionString %>" SelectCommand="prLSPDropDownTextsGet" SelectCommandType="StoredProcedure">
                            <SelectParameters>
                                <asp:Parameter DefaultValue="4" Name="DropdownId" Type="Int32" />
                                <asp:SessionParameter DefaultValue="1" Name="LanguageId" SessionField="language" Type="Int32" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                        <asp:RequiredFieldValidator ID="vldtrMachalStatusRequired" runat="server" ErrorMessage="Machal Status is required" ControlToValidate="ddlMachalStatus" InitialValue="-Select-" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                    </p>
                    <p>
                        <asp:Label ID="lblQ38Whichprogramdidyouapplyto" runat="server"></asp:Label>
                    </p>
                    <p>
                        <asp:DropDownList ID="ddlMachalProgram" class="dropdown" runat="server" DataSourceID="SqlDataSourceMachalProgram" DataTextField="Text" DataValueField="Value">
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="SqlDataSourceMachalProgram" runat="server" ConnectionString="<%$ ConnectionStrings:AdminConnectionString %>" SelectCommand="prLSPDropDownTextsGet" SelectCommandType="StoredProcedure">
                            <SelectParameters>
                                <asp:Parameter DefaultValue="5" Name="DropdownId" Type="Int32" />
                                <asp:SessionParameter DefaultValue="1" Name="LanguageId" SessionField="language" Type="Int32" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                        <asp:RequiredFieldValidator ID="vldtrMachalProgramRequired" runat="server" ErrorMessage="Machal Program is required" ControlToValidate="ddlMachalProgram" InitialValue="-Select-" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                    </p>
                    <p>
                        <asp:Label ID="lblQ40MachalID" runat="server"></asp:Label>
                    </p>
                    <p>
                        <asp:TextBox ID="txtMachalId" runat="server"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="vldtrMachalIdRegex" runat="server" ErrorMessage="Invalid number" ValidationExpression="^[0-9]+$" ControlToValidate="txtMachalId" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                        <asp:RequiredFieldValidator ID="vldtrMachlIdRequired" runat="server" ErrorMessage="Id is required" ControlToValidate="txtMachalId" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                    </p>
                </asp:Panel>
                <p>
                    <asp:Label ID="lblQ36AreyoucurrentlyservingintheIDF" runat="server"></asp:Label>
                </p>
                <p>
                    <asp:RadioButtonList ID="rblCurrentlyServing" class="radiobuttons" runat="server" CellPadding="10" RepeatDirection="Horizontal" Width="116px" AutoPostBack="true" OnSelectedIndexChanged="rblCurrentlyServing_SelectedIndexChanged" DataSourceID="datasrcYesNo" DataTextField="Text" DataValueField="Value">
                    </asp:RadioButtonList>
                    <asp:RequiredFieldValidator ID="vldtrCurrentlyServingRequired" runat="server" ControlToValidate="rblCurrentlyServing" ErrorMessage="Please select an Army Service option" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                </p>
                <asp:Panel ID="pnlActiveDuty" runat="server" Visible="false">
                    <p>
                        <asp:Label ID="lblQ39IDFIDNumberMisparIshi" runat="server"></asp:Label>
                    </p>
                    <p>
                        <asp:TextBox ID="txtArmyId" runat="server"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="vldtrArmyIdRegex" runat="server" ErrorMessage="Invalid number" ValidationExpression="^[0-9]+$" ControlToValidate="txtArmyId" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                    </p>
                    <p>
                        <asp:Label ID="lblQ43ArmyUnit" runat="server"></asp:Label>
                    </p>
                    <p>
                        <asp:DropDownList ID="ddlArmyUnit" CssClass="dropdown" runat="server" DataSourceID="SqlDataSource7" DataTextField="ArmyUnit" DataValueField="ArmyUnit">
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="SqlDataSource7" runat="server" ConnectionString="<%$ ConnectionStrings:ClayConnectionString %>" SelectCommand="select Val as [ArmyUnit] from LookupLists where ItemType = 1 and FieldConst = 165 order by Position"></asp:SqlDataSource>
                    </p>
                    <p>
                        <asp:Label ID="lblQ44roleType" runat="server"></asp:Label>
                    </p>
                    <p>
                        <asp:DropDownList ID="ddlArmyTafkid" CssClass="dropdown" runat="server" DataSourceID="SqlDataSource8" DataTextField="ArmyTafkid" DataValueField="ArmyTafkid">
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="SqlDataSource8" runat="server" ConnectionString="<%$ ConnectionStrings:ClayConnectionString %>" SelectCommand="select Val as [ArmyTafkid] from LookupLists where ItemType = 241 and FieldConst = 215 order by Position"></asp:SqlDataSource>
                    </p>
                </asp:Panel>
            </ContentTemplate>
        </asp:UpdatePanel>
    </asp:Panel>
    <asp:Panel ID="pnlDisclaimer" runat="server">
        <h2>
            <asp:Label ID="lblHeadingDisclaimer" runat="server" Text="Label"></asp:Label></h2>
        <p>
            <asp:TextBox ID="txtDisclaimer" runat="server" TextMode="MultiLine" Width="500px" Rows="6" ReadOnly="true"></asp:TextBox>
        </p>
        <p>
            <asp:RadioButtonList ID="rblAccept" CssClass="radiobuttons" runat="server">
            </asp:RadioButtonList>

        </p>
        <asp:RequiredFieldValidator ID="vldtrAcceptRequired" runat="server" ControlToValidate="rblAccept" ErrorMessage="Please read and Accept the Disclaimer" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
    </asp:Panel>

    <asp:Panel ID="pnlSubmit" runat="server">
        <p>
            <asp:Button ID="btnSubmit" runat="server" Text="Sign Up" OnClick="btnSubmit_Click" />
        </p>
        <p>
            <asp:Label ID="lblResponseText" runat="server" Text=""></asp:Label>
        </p>
    </asp:Panel>
    <asp:Panel ID="pnlDocumentUpload" runat="server" Visible="false">
        <h3 style="font-style: italic; color: cadetblue; font-weight: bold;"><asp:Label ID="lblThankYou" runat="server" Text=""></asp:Label></h3>
        <asp:Label ID="lblFileUploadInstructions" runat="server" Text=""></asp:Label>
        <h2>
            <asp:Label ID="lblHeadingDocumentUpload" runat="server" Text=""></asp:Label></h2>

        <p>
            <asp:Literal ID="ltrlPassportPhotoLink" runat="server"></asp:Literal>
            <asp:Label ID="lblQ45Passportphoto" runat="server"></asp:Label>
            <asp:Literal ID="ltrlClosePassportPhotoLink" runat="server"></asp:Literal>
        </p>
        <p>
            <asp:Literal ID="ltrlLSPCertificateLink" runat="server"></asp:Literal>
            <asp:Label ID="lblQ46LoneSoldiercertificate" runat="server"></asp:Label>
            <asp:Literal ID="ltrlCloseLSPCertificateLink" runat="server"></asp:Literal>
        </p>
        <p>
            <asp:Literal ID="ltrlDraftNoticeLink" runat="server"></asp:Literal>
            <asp:Label ID="lblQ47Draftnotice" runat="server"></asp:Label>
            <asp:Literal ID="ltrlCloseDraftNoticeLink" runat="server"></asp:Literal>
        </p>
        <p>
            <asp:Literal ID="ltrlIshurMachalLink" runat="server"></asp:Literal>
            <asp:Label ID="lblIshurMachal" runat="server" Text="Label"></asp:Label>
            <asp:Literal ID="ltrlCloseIshurMachalLink" runat="server"></asp:Literal>
        </p>
        <p>
            <asp:Literal ID="ltrlTeudatOlehLink" runat="server"></asp:Literal>
            <asp:Label ID="lblTeudatOleh" runat="server" Text="Label"></asp:Label>
            <asp:Literal ID="ltrlCloseTeudatOlehLink" runat="server"></asp:Literal>
        </p>

        <div class="FileUploadWrapper">
            <iframe id="ifrmFileUpload" name="ifrmFileUpload" runat="server"  frameBorder="0" scrolling="no" style="overflow:hidden;"></iframe>
        </div>

    </asp:Panel>
    <p>
        <asp:GridView ID="gvData" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource11" Visible="false">
            <Columns>
                <asp:BoundField DataField="FName" HeaderText="FName" SortExpression="FName" />
                <asp:BoundField DataField="LName" HeaderText="LName" SortExpression="LName" />
                <asp:BoundField DataField="DOB" HeaderText="DOB" SortExpression="DOB" />
                <asp:BoundField DataField="Gender" HeaderText="Gender" SortExpression="Gender" />
                <asp:BoundField DataField="MaritalStatus" HeaderText="MaritalStatus" SortExpression="MaritalStatus" />
                <asp:BoundField DataField="Education" HeaderText="Education" SortExpression="Education" />
                <asp:BoundField DataField="JewishAffiliation" HeaderText="JewishAffiliation" SortExpression="JewishAffiliation" />
                <asp:BoundField DataField="PreferredLanguage" HeaderText="PreferredLanguage" SortExpression="PreferredLanguage" />
                <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
                <asp:BoundField DataField="OriginalCountry" HeaderText="OriginalCountry" SortExpression="OriginalCountry" />
                <asp:BoundField DataField="OriginalAddress" HeaderText="OriginalAddress" SortExpression="OriginalAddress" />
                <asp:BoundField DataField="OriginalState" HeaderText="OriginalState" SortExpression="OriginalState" />
                <asp:BoundField DataField="OriginalCity" HeaderText="OriginalCity" SortExpression="OriginalCity" />
                <asp:BoundField DataField="ZipCode" HeaderText="ZipCode" SortExpression="ZipCode" />
                <asp:BoundField DataField="OriginalCell" HeaderText="OriginalCell" SortExpression="OriginalCell" />
                <asp:BoundField DataField="OriginalHomePhone" HeaderText="OriginalHomePhone" SortExpression="OriginalHomePhone" />
                <asp:BoundField DataField="FathersNameEn" HeaderText="FathersNameEn" SortExpression="FathersNameEn" />
                <asp:BoundField DataField="MothersNameEn" HeaderText="MothersNameEn" SortExpression="MothersNameEn" />
                <asp:BoundField DataField="ParentsPhone" HeaderText="ParentsPhone" SortExpression="ParentsPhone" />
                <asp:BoundField DataField="ParentsEmail" HeaderText="ParentsEmail" SortExpression="ParentsEmail" />
                <asp:BoundField DataField="IsraelAddress" HeaderText="IsraelAddress" SortExpression="IsraelAddress" />
                <asp:BoundField DataField="IsraelCity" HeaderText="IsraelCity" SortExpression="IsraelCity" />
                <asp:BoundField DataField="IsraelCell" HeaderText="IsraelCell" SortExpression="IsraelCell" />
                <asp:BoundField DataField="IsraelHomePhone" HeaderText="IsraelHomePhone" SortExpression="IsraelHomePhone" />
                <asp:BoundField DataField="TZNumber" HeaderText="TZNumber" SortExpression="TZNumber" />
                <asp:BoundField DataField="TZFirstNameHe" HeaderText="TZFirstNameHe" SortExpression="TZFirstNameHe" />
                <asp:BoundField DataField="TZLastNameHe" HeaderText="TZLastNameHe" SortExpression="TZLastNameHe" />
                <asp:BoundField DataField="AliyahDate" HeaderText="AliyahDate" SortExpression="AliyahDate" />
                <asp:BoundField DataField="AliyahReason" HeaderText="AliyahReason" SortExpression="AliyahReason" />
                <asp:BoundField DataField="CourseElite" HeaderText="CourseElite" SortExpression="CourseElite" />
                <asp:BoundField DataField="ArmyId" HeaderText="ArmyId" SortExpression="ArmyId" />
                <asp:BoundField DataField="MachalId" HeaderText="MachalId" SortExpression="MachalId" />
                <asp:BoundField DataField="EnlistmentDate" HeaderText="EnlistmentDate" SortExpression="EnlistmentDate" />
                <asp:BoundField DataField="LengthOfService" HeaderText="LengthOfService" SortExpression="LengthOfService" />
                <asp:BoundField DataField="ArmyUnit" HeaderText="ArmyUnit" SortExpression="ArmyUnit" />
                <asp:BoundField DataField="MachalStatus" HeaderText="MachalStatus" SortExpression="MachalStatus" />
                <asp:BoundField DataField="MachalProgram" HeaderText="MachalProgram" SortExpression="MachalProgram" />
                <asp:BoundField DataField="GUID" HeaderText="GUID" SortExpression="GUID" />
                <asp:BoundField DataField="MiddleName" HeaderText="MiddleName" SortExpression="MiddleName" />
                <asp:BoundField DataField="FamilyId" HeaderText="FamilyId" SortExpression="FamilyId" />
                <asp:BoundField DataField="FamilyIdc" HeaderText="FamilyIdc" SortExpression="FamilyIdc" />
                <asp:BoundField DataField="ArmyTafkid" HeaderText="ArmyTafkid" SortExpression="ArmyTafkid" />
                <asp:BoundField DataField="Citizenship" HeaderText="Citizenship" SortExpression="Citizenship" />
                <asp:BoundField DataField="DagId" HeaderText="DagId" SortExpression="DagId" />
                <asp:BoundField DataField="SSOGuid" HeaderText="SSOGuid" SortExpression="SSOGuid" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource11" runat="server" ConnectionString="<%$ ConnectionStrings:AdminConnectionString %>" SelectCommand="prLSPRecordGet" SelectCommandType="StoredProcedure">
            <SelectParameters>
                <asp:SessionParameter Name="Email" SessionField="email" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
    </p>
    <script type="text/javascript">
        function capitalize(textboxid, str) {
            // string with alteast one character
            if (str && str.length >= 1) {
                var firstChar = str.charAt(0);
                var remainingStr = str.slice(1);
                str = firstChar.toUpperCase() + remainingStr.toLowerCase();
            }
            document.getElementById(textboxid).value = str;
        }
    </script>
</asp:Content>
