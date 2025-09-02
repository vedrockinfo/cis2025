using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Net;
using System.Text;
using System.Net.Mail;
using System.IO;
using System.Net.NetworkInformation;
using System.Security.Cryptography;

public partial class admit : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection();
    string sql = "";
    NurtureLib oo = new NurtureLib();



    string XMLDATASTring;
    cls_connection Mycon = new cls_connection();
    SqlConnection con1 = new SqlConnection();
    protected void Page_Load(object sender, EventArgs e)
    {
        con.ConnectionString = ConfigurationManager.ConnectionStrings["CISCon"].ConnectionString;
        con1.ConnectionString = ConfigurationManager.ConnectionStrings["MockCon"].ConnectionString;

        sql = "select sno from SerialNo  ";

        if (!IsPostBack)
        {
            
            Panel2.Visible = false;
            bb.Visible = false;
            Panel3.Visible = false;
            Panel4.Visible = false;


            sql = "select id,name,CountryCode  from Icountry where Countrycode <>'N/A'";

            oo.FillDropDownWithID(sql, drpCountry, "name", "id");

            drpCountry.SelectedValue = "101";


            sql = "Select id,name, country_id  from Istate  where country_id=" + drpCountry.SelectedValue.ToString();
            oo.FillDropDownWithID(sql, drpState, "Name", "id");

            drpState.SelectedValue = "38";
            sql = "select id,name from icity  where state_id=" + drpState.SelectedValue.ToString();
            oo.FillDropDownWithID(sql, drpCity, "name", "id");


            drpCountry.Enabled = false;

        }

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        //@Country,					@State,					@City

        string Loginid = "", Pas = "", ss = "";
        sql = "select FName+' '+Mname+' '+LName as StudentName,Email,mobileno,City,State from OnlineAdmissionMast where Email='" + txtEmail.Text.Trim() + "'";

        if (oo.Duplicate(sql))
        {
            lbl_messageNext.Text = "Email ID already used. Please try another.";
        }
        else
        {

            if (txtOTP.Text == Session["OTP"].ToString())
            {
                XmlDataValue();
               InsertDataInReadinessDB();
                try
                {
                    Mycon.cmd.Parameters.Clear();
                    Mycon.cmd.Connection = Mycon.con;
                    Mycon.cmd.CommandText = "Proc_OnlineAdmissionMast_Insert";
                    Mycon.cmd.CommandType = CommandType.StoredProcedure;
                    //Mycon.cmd.Parameters.AddWithValue("@AdmissionId", txtAdmissionId.Text);
                    Mycon.cmd.Parameters.AddWithValue("@PrimeContact", drpPrime.SelectedItem.Text);
                    Mycon.cmd.Parameters.AddWithValue("@FName", txtFName.Text);
                    Mycon.cmd.Parameters.AddWithValue("@MName", txtMName.Text);
                    Mycon.cmd.Parameters.AddWithValue("@LName", txtLName.Text);
                    Mycon.cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                    Mycon.cmd.Parameters.AddWithValue("@Mobileno", txtMobile.Text);
                    Mycon.cmd.Parameters.AddWithValue("@NoofChildren", Convert.ToInt32(txtNoOfChildren.Text));
                    //Mycon.cmd.Parameters.AddWithValue("@RecordDate", txtRecordDate.Text);
                    //Mycon.cmd.Parameters.AddWithValue("@Password", "123");
                    Mycon.cmd.Parameters.AddWithValue("@Preference1", drpCampus1.SelectedItem.ToString());
                    Mycon.cmd.Parameters.AddWithValue("@Preference2", drpCampus2.SelectedItem.ToString());
                    Mycon.cmd.Parameters.AddWithValue("@Preference3", drpCampus3.SelectedItem.ToString());
                    Mycon.cmd.Parameters.AddWithValue("@Country", drpCountry.SelectedItem.ToString());
                    Mycon.cmd.Parameters.AddWithValue("@State", drpState.SelectedItem.ToString());
                    Mycon.cmd.Parameters.AddWithValue("@City", drpCity.SelectedItem.ToString());
                    Mycon.cmd.Parameters.AddWithValue("@PreferenceID1", drpCampus1.SelectedValue.ToString());
                    Mycon.cmd.Parameters.AddWithValue("@PreferenceID2", drpCampus2.SelectedValue.ToString());
                    Mycon.cmd.Parameters.AddWithValue("@PreferenceID3", drpCampus3.SelectedValue.ToString());

                   

                    Mycon.cmd.Parameters.AddWithValue("@XMLDATA", XMLDATASTring);

                    Mycon.cmd.Parameters.AddWithValue("@CommandType", "INSERT");

                    SqlParameter p1 = new SqlParameter("AdmissionId", SqlDbType.NVarChar, 6);
                    Mycon.cmd.Parameters.Add(p1);
                    p1.Direction = ParameterDirection.InputOutput;


                    SqlParameter p2 = new SqlParameter("IsSuccess", SqlDbType.Int);
                    Mycon.cmd.Parameters.Add(p2);
                    p2.Direction = ParameterDirection.InputOutput;



                    SqlParameter p3 = new SqlParameter("Password", SqlDbType.NVarChar, 6);
                    Mycon.cmd.Parameters.Add(p3);
                    p3.Direction = ParameterDirection.InputOutput;



                    Mycon.open();
                    int cnt = Mycon.cmd.ExecuteNonQuery();
                    string strAdmissionId = Mycon.cmd.Parameters["AdmissionId"].Value.ToString();
                    cnt = Convert.ToInt32(Mycon.cmd.Parameters["IsSuccess"].Value.ToString());
                    string Pass = Mycon.cmd.Parameters["Password"].Value.ToString();


                    if (cnt == 1)
                    {
                        lbl_message.Text = "Record Saved Successfully.your referenceid:" + strAdmissionId;
                        lbl_message.Text = "Your Online Application Accept Login id & Password send to your Mobile No.";
                        ss = "Dear Parents, " + txtFName.Text.Trim() + " Login id: " + strAdmissionId + " Password: " + Pass;
                        SendSMS(ss, txtMobile.Text.Trim());
                        Session["Cid"] = strAdmissionId.ToString();

                        Panel3.Visible = true;
                        Panel2.Visible = false;
                        Panel1.Visible = false;
                        SendMail(strAdmissionId, Pass);

                    }
                    else
                    {
                        lbl_message.Text = "Record not Saved.";
                        //divmsg.Visible = true;
                    }


                }
                catch (Exception ex)
                {

                }
                finally
                {
                    Mycon.close();
                }
            }
            else
            {
                lbl_message.Text = "Please press Resend OTP to get a new one. In case of difficulty, please call Manish Srivastava 998 455 8888.";
            }
        }
    }
    public void ClearControls(Control parent)
    {

        foreach (Control _ChildControl in parent.Controls)
        {
            if ((_ChildControl.Controls.Count > 0))
            {
                ClearControls(_ChildControl);
            }
            else
            {
                if (_ChildControl is TextBox)
                {
                    ((TextBox)_ChildControl).Text = string.Empty;
                }
                else if (_ChildControl is DropDownList)
                {
                    ((DropDownList)_ChildControl).SelectedIndex = 0;
                }

            }
        }

    }
    public void XmlDataValue()
    {

        XMLDATASTring = "<data>";

        for (int i = 0; i <= GridView1.Rows.Count - 1; i++)
        {

            //lblsno txtStuFName    drpClass 

            string DD = "";

            //Label lblQuestionId = (Label)GridView2.Rows[i].FindControl("QuestionId2");
            HiddenField hidquestionid2 = (HiddenField)GridView1.Rows[i].FindControl("hidquestionid2");
            Label lblsno = (Label)GridView1.Rows[i].FindControl("lblsno");
            TextBox txtStuFName = (TextBox)GridView1.Rows[i].FindControl("txtStuFName");
            TextBox txtStuMName = (TextBox)GridView1.Rows[i].FindControl("txtStuMName");
            TextBox txtStuLName = (TextBox)GridView1.Rows[i].FindControl("txtStuLName");


            //  TextBox txtDate = (TextBox)GridView1.Rows[i].FindControl("txtDate");
            DropDownList drpYY = (DropDownList)GridView1.Rows[i].FindControl("drpYY");
            DropDownList drpMM = (DropDownList)GridView1.Rows[i].FindControl("drpMM");
            DropDownList drpDD = (DropDownList)GridView1.Rows[i].FindControl("drpDD");
            DD = drpYY.SelectedItem.ToString() + "/" + drpMM.SelectedItem.ToString() + "/" + drpDD.SelectedItem.ToString();

            // string datestr = txtDate.Text; //"01/01/1900";//
            DropDownList drpClass = (DropDownList)GridView1.Rows[i].FindControl("drpClass");
            DropDownList ddlGender = (DropDownList)GridView1.Rows[i].FindControl("ddlGender");


            sql = " select max(AdmissiondetailId)+1 as  TT  from OnlineAdmissionDetail  ";
            string ss = "";
            ss = oo.ReturnTag(sql, "TT");


            XMLDATASTring += "<node>";
            XMLDATASTring += "<AdmissiondetailId>" + ss + "</AdmissiondetailId>";
            XMLDATASTring += "<Sno>" + lblsno.Text.Trim() + "</Sno>";
            XMLDATASTring += "<FName>" + txtStuFName.Text.Trim() + "</FName>";
            XMLDATASTring += "<MName>" + txtStuMName.Text.Trim() + "</MName>";
            XMLDATASTring += "<LName>" + txtStuLName.Text.Trim() + "</LName>";
            //XMLDATASTring += "<Dob>" + txtDate.Text.Trim() + "</Dob>";
            XMLDATASTring += "<Dob>" + DD + "</Dob>";
            XMLDATASTring += "<Class>" + drpClass.SelectedItem.Text + "</Class>";
            XMLDATASTring += "<Gender>" + ddlGender.SelectedItem.Text + "</Gender>";
            XMLDATASTring += "</node>";



        }

        XMLDATASTring += "</data>";
    }
    protected void txtNoOfChildren_TextChanged(object sender, EventArgs e)
    {

        int i = 0;
        sql = " exec Proc_NoOfAdmission " + Convert.ToInt32(txtNoOfChildren.Text) + "";
        GridView1.DataSource = oo.GridFill(sql);
        GridView1.DataBind();


        if (GridView1.Rows.Count >= 1)
        {
            bb.Visible = true;

            for (i = 0; i <= GridView1.Rows.Count - 1; i++)
            {
                DropDownList drpYY = (DropDownList)GridView1.Rows[i].FindControl("drpYY");
                DropDownList drpMM = (DropDownList)GridView1.Rows[i].FindControl("drpMM");
                DropDownList drpDD = (DropDownList)GridView1.Rows[i].FindControl("drpDD");

                oo.AddDateMonthYearDropDown(drpYY, drpMM, drpDD);
                oo.FindCurrentDateandSetinDropDown(drpYY, drpMM, drpDD);
            }



        }
        else
        {
            bb.Visible = false;
        }
        //Panel2.Visible = false;
    }



    protected void Button2_Click(object sender, EventArgs e)
    {
        string Loginid = "", Pas = "", ss = "";
        sql = "select FName+' '+Mname+' '+LName as StudentName,Email,mobileno,City,State from OnlineAdmissionMast where Email='" + txtEmail.Text.Trim() + "'";

        if (oo.Duplicate(sql))
        {
            lbl_messageNext.Text = "Email ID already used. Please try another.";
        }
        else
        {

              XmlDataValue();
                InsertDataInReadinessDB();
                try
                {
                    Mycon.cmd.Parameters.Clear();
                    Mycon.cmd.Connection = Mycon.con;
                    Mycon.cmd.CommandText = "Proc_OnlineAdmissionMast_Insert";
                    Mycon.cmd.CommandType = CommandType.StoredProcedure;
                    //Mycon.cmd.Parameters.AddWithValue("@AdmissionId", txtAdmissionId.Text);
                    Mycon.cmd.Parameters.AddWithValue("@PrimeContact", drpPrime.SelectedItem.Text);
                    Mycon.cmd.Parameters.AddWithValue("@FName", txtFName.Text);
                    Mycon.cmd.Parameters.AddWithValue("@MName", txtMName.Text);
                    Mycon.cmd.Parameters.AddWithValue("@LName", txtLName.Text);
                    Mycon.cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                    Mycon.cmd.Parameters.AddWithValue("@Mobileno", txtMobile.Text);
                    Mycon.cmd.Parameters.AddWithValue("@NoofChildren", Convert.ToInt32(txtNoOfChildren.Text));
                    //Mycon.cmd.Parameters.AddWithValue("@RecordDate", txtRecordDate.Text);
                    //Mycon.cmd.Parameters.AddWithValue("@Password", "123");
                    Mycon.cmd.Parameters.AddWithValue("@Preference1", drpCampus1.SelectedItem.ToString());
                    Mycon.cmd.Parameters.AddWithValue("@Preference2", drpCampus2.SelectedItem.ToString());
                    Mycon.cmd.Parameters.AddWithValue("@Preference3", drpCampus3.SelectedItem.ToString());
                    Mycon.cmd.Parameters.AddWithValue("@Country", drpCountry.SelectedItem.ToString());
                    Mycon.cmd.Parameters.AddWithValue("@State", drpState.SelectedItem.ToString());
                    Mycon.cmd.Parameters.AddWithValue("@City", drpCity.SelectedItem.ToString());
                    Mycon.cmd.Parameters.AddWithValue("@PreferenceID1", drpCampus1.SelectedValue.ToString());
                    Mycon.cmd.Parameters.AddWithValue("@PreferenceID2", drpCampus2.SelectedValue.ToString());
                    Mycon.cmd.Parameters.AddWithValue("@PreferenceID3", drpCampus3.SelectedValue.ToString());



                    Mycon.cmd.Parameters.AddWithValue("@XMLDATA", XMLDATASTring);

                    Mycon.cmd.Parameters.AddWithValue("@CommandType", "INSERT");

                    SqlParameter p1 = new SqlParameter("AdmissionId", SqlDbType.NVarChar, 6);
                    Mycon.cmd.Parameters.Add(p1);
                    p1.Direction = ParameterDirection.InputOutput;


                    SqlParameter p2 = new SqlParameter("IsSuccess", SqlDbType.Int);
                    Mycon.cmd.Parameters.Add(p2);
                    p2.Direction = ParameterDirection.InputOutput;



                    SqlParameter p3 = new SqlParameter("Password", SqlDbType.NVarChar, 6);
                    Mycon.cmd.Parameters.Add(p3);
                    p3.Direction = ParameterDirection.InputOutput;



                    Mycon.open();
                    int cnt = Mycon.cmd.ExecuteNonQuery();
                    string strAdmissionId = Mycon.cmd.Parameters["AdmissionId"].Value.ToString();
                    cnt = Convert.ToInt32(Mycon.cmd.Parameters["IsSuccess"].Value.ToString());
                    string Pass = Mycon.cmd.Parameters["Password"].Value.ToString();


                    if (cnt == 1)
                    {
                        lbl_message.Text = "Record Saved Successfully.your referenceid:" + strAdmissionId;
                        //lbl_message.Text = "Your Online Application Accept Login id & Password send to your Mobile No.";
                        //ss = "Dear Parents, " + txtFName.Text.Trim() + " Login id: " + strAdmissionId + " Password: " + Pass;
                        //SendSMS(ss, txtMobile.Text.Trim());
                        Session["Cid"] = strAdmissionId.ToString();
                        lblMEss.Text = "Record Saved Successfully.your referenceid:" + strAdmissionId;
                        Panel3.Visible = false ;
                        Panel2.Visible = false;
                        Panel1.Visible = false;
                        Panel4.Visible = true;
                        SendMail(strAdmissionId, Pass);

                    }
                    else
                    {
                        lbl_message.Text = "Record not Saved.";
                        //divmsg.Visible = true;
                    }

                }

                catch (Exception ex)
                {

                }
                finally
                {
                    Mycon.close();
                }
           
           
        }
    }

    public void SendSMS(string Message, string mob)
    {
        string ss = "";
        ss = Message;
        // priority.callcum.in/ app / smsapi / index.php ? key = 4591D844372BD4 & routeid = 295 & type = text & contacts = 9044112299 & senderid = Edison & msg = Hello

        WebClient client = new WebClient();
        
        //priority.callcum.in/app/smsapi/index.php?key=559EDCA7F6D26A&routeid=15&type=text&contacts=9984558888&senderid=EDISON&msg=Hello
        string baseurl = "http://priority.callcum.in/app/smsapi/index.php?key=559EDCA7F6D26A&routeid=15&type=text&contacts=" + mob + "&senderid=CISEDU&msg=" + ss;
        Stream data = client.OpenRead(baseurl);
        StreamReader reader = new StreamReader(data);
        string s = reader.ReadToEnd();
        data.Close();
        reader.Close();


    }

    public int GenerateRandomNo()
    {
        int _min = 0000;
        int _max = 9999;
        Random _rdm = new Random();
        return _rdm.Next(_min, _max);
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        string ss = "";
        string OTP = GenerateRandomNo().ToString();
        ss = "Your OTP for Online Registration is " + OTP + ". It is valid for 10 minutes.";
        SendSMS(ss, txtMobile.Text.Trim());
        Session["OTP"] = OTP;
    }
    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        // Response.Redirect("OnlineAdmission1.aspx");
        Panel1.Visible = true;
        Panel2.Visible = false;
    }
    protected void drpCountry_SelectedIndexChanged(object sender, EventArgs e)
    {
        sql = "select id,name,'+'+CountryCode  as CCode from Icountry  where id=" + drpCountry.SelectedValue.ToString();


        oo.FillDropDownWithOutSelect(sql, drpMobileCountry, "CCode");


        sql = "Select id,name, country_id  from Istate  where country_id=" + drpCountry.SelectedValue.ToString();
        oo.FillDropDownWithID(sql, drpState, "Name", "id");
    }
    protected void drpState_SelectedIndexChanged(object sender, EventArgs e)
    {
        sql = "select id,name from icity  where state_id=" + drpState.SelectedValue.ToString();
        oo.FillDropDownWithID(sql, drpCity, "name", "id");
    }
    protected void drpYY_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow row = (GridViewRow)((DropDownList)sender).NamingContainer;

        DropDownList drpYY = (DropDownList)row.FindControl("drpYY");
        DropDownList drpMM = (DropDownList)row.FindControl("drpMM");
        DropDownList drpDD = (DropDownList)row.FindControl("drpDD");
        oo.YearDropDown(drpYY, drpMM, drpDD);
    }
    protected void drpMM_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow row = (GridViewRow)((DropDownList)sender).NamingContainer;

        DropDownList drpYY = (DropDownList)row.FindControl("drpYY");
        DropDownList drpMM = (DropDownList)row.FindControl("drpMM");
        DropDownList drpDD = (DropDownList)row.FindControl("drpDD");
        oo.MonthDropDown(drpYY, drpMM, drpDD);
    }
    protected void Button3_Click(object sender, EventArgs e)
    {




        Session["Cid"] = "11";
        Session["name"] = "Manish";
        Session["Email"] = "Manish@globalmail.in";
        Session["Mobile"] = "9984558888";
        Session["Address"] = "LKO";
        Session["City"] = "LKO";
        Session["state"] = "U.P.";
        Session["ZipCode"] = "226001";

        Session["amount"] = "500";



        ClearControls(this.Page);
        Response.Redirect("PayU/Default.aspx");

    }
    protected void btnPayment_Click(object sender, EventArgs e)
    {

        int amt = 0;
        try
        {
            amt = (Convert.ToInt32(txtNoOfChildren.Text) * 700);
        }
        catch (Exception) { }
        sql = "select FName+' '+Mname+' '+LName as StudentName,Email,mobileno,City,State from OnlineAdmissionMast where AdmissionId='" + Session["Cid"].ToString() + "'";

        // Session["Cid"] = strLoginId;
        Session["name"] = oo.ReturnTag(sql, "StudentName");
        Session["Email"] = oo.ReturnTag(sql, "Email");
        Session["Mobile"] = oo.ReturnTag(sql, "mobileno");
        Session["Address"] = oo.ReturnTag(sql, "City");
        Session["City"] = oo.ReturnTag(sql, "City");
        Session["state"] = oo.ReturnTag(sql, "State");
        Session["ZipCode"] = "226001";
        Session["amount"] = amt.ToString();

        Response.Redirect("PayU/Default.aspx");
    }



    private void SendMail(string login, string Pass)
    {
        string email = "";
        MailMessage mail = new MailMessage();

        sql = "select FName+' '+Mname+' '+LName as StudentName,Email,mobileno,City,State from OnlineAdmissionMast where AdmissionId='" + Session["Cid"].ToString() + "'";


        email = oo.ReturnTag(sql, "Email");
        mail.To.Add("manish@globalmail.in");
        mail.To.Add("sunitag@globaleducation.org");
        mail.To.Add(email);
        mail.From = new MailAddress("donotreply@globaleducation.org", "donotreply@1");

        mail.Subject = "Admissions Registration for 2024-25";
        string Body = null;
        Body = htmlemailbodyNew(login, Pass);
        mail.Body = Body;
        mail.IsBodyHtml = true;
        mail.Priority = MailPriority.High;
        SmtpClient smtp = new SmtpClient();
        smtp.Host = "smtp.gmail.com";
        // //Or Your SMTP Server Address
        smtp.Credentials = new System.Net.NetworkCredential("donotreply@globaleducation.org", "donotreply@1");
        smtp.EnableSsl = true;
        try
        {
            smtp.Send(mail);
        }
        catch { }
    }

    private string htmlemailbody(string Loginid, string Pass)
    {
        string ss = "";
        StringBuilder body = new StringBuilder();



        ss = ss + "<table>";
        ss = ss + "<tr><td><b>Admissions Registration for 2024-25</b><td><tr>";
        ss = ss + "<tr><td><br /></td></tr>";
        ss = ss + "<tr><td>Your children are now registered.</td></tr>";
        ss = ss + "<tr><td><br /></td></tr>";


        ss = ss + "<tr><td>Please complete the remaining admission formalities on</td></tr>";
        ss = ss + "<tr><td> http://www.ciseducation.org/plogin.aspx </td></tr>";
        ss = ss + "<tr><td><br /></td></tr>";
        ss = ss + "<tr><td>Use ID and PASSWORD as below: </td></tr>";
        ss = ss + "<tr><td><br /></td></tr>";
        ss = ss + "<tr><td>Login id: " + Loginid + "</td></tr>";
        ss = ss + "<tr><td>Password: " + Pass + "</td></tr>";

        ss = ss + "<tr><td>In case of difficulties, or for Talent Scholarships, please WhatsApp on +91 911 509 9992. We will get back to you.</td></tr>";
        ss = ss + "<tr><td><br /></td></tr>";
        ss = ss + "<tr><td>Regards,</td></tr>";
        ss = ss + "<tr><td>Sumita Bhatt</td></tr>";
        ss = ss + "<tr><td>Admissions Counselor</td></tr>";
        ss = ss + "</table>";


        body.Append(ss);
        return body.ToString();





    }

    public void InsertDataInReadinessDB()
    {
        int i = 0;
        string ss = "", scsid = "", BoardId = "", Sessionid = "", SessionName = "", StudentId = "", Pass1 = "", SurveyId = "";
        string DD = "";
        XMLDATASTring = "<data>";
        for (i = 0; i <= GridView1.Rows.Count - 1; i++)
        {

            TextBox txtStuFName = (TextBox)GridView1.Rows[i].FindControl("txtStuFName");
            TextBox txtStuMName = (TextBox)GridView1.Rows[i].FindControl("txtStuMName");
            TextBox txtStuLName = (TextBox)GridView1.Rows[i].FindControl("txtStuLName");
            ss = txtStuFName.Text.Trim() + " " + txtStuMName.Text.Trim() + " " + txtStuLName.Text.Trim();
            DropDownList drpClass = (DropDownList)GridView1.Rows[i].FindControl("drpClass");
            DropDownList ddlGender = (DropDownList)GridView1.Rows[i].FindControl("ddlGender");
            Label lblsno = (Label)GridView1.Rows[i].FindControl("lblsno");


            DropDownList drpYY = (DropDownList)GridView1.Rows[i].FindControl("drpYY");
            DropDownList drpMM = (DropDownList)GridView1.Rows[i].FindControl("drpMM");
            DropDownList drpDD = (DropDownList)GridView1.Rows[i].FindControl("drpDD");
            DD = drpYY.SelectedItem.ToString() + "/" + drpMM.SelectedItem.ToString() + "/" + drpDD.SelectedItem.ToString();




            sql = "  select ReadinessSurveyDB.dbo.FindSCSIDOFClassSchool('" + drpClass.SelectedValue.ToString() + "','" + drpCampus1.SelectedValue.ToString() + "') as Scsid";

            scsid = oo.ReturnTag(sql, "scsid");


            sql = "select BoardId  from ReadinessSurveyDB.dbo.tblSchool where Schoolid='" + drpCampus1.SelectedValue.ToString() + "'";
            BoardId = oo.ReturnTag(sql, "BoardId");

            sql = "select top 1 SessionId,SessionName  from ReadinessSurveyDB.dbo.SessionTab order by SessionId desc";

            Sessionid = oo.ReturnTag(sql, "SessionId");
            SessionName = oo.ReturnTag(sql, "SessionName");


            sql = "  SELECT        ReadinessSurveyDB.dbo.tblSurvey.Surveyid, ReadinessSurveyDB.dbo.tblSurvey.Surveyname, ReadinessSurveyDB.dbo.tblClass.Classname, ReadinessSurveyDB.dbo.tblClass.Classid, ReadinessSurveyDB.dbo.tblSubject.Subjectname  ";
            sql = sql + "  FROM            ReadinessSurveyDB.dbo.tblSurvey INNER JOIN  ";
            sql = sql + "                           ReadinessSurveyDB.dbo.tblClass ON ReadinessSurveyDB.dbo.tblSurvey.Classid = ReadinessSurveyDB.dbo.tblClass.Classid INNER JOIN  ";
            sql = sql + "   ReadinessSurveyDB.dbo.tblSubject ON ReadinessSurveyDB.dbo.tblSurvey.Subjectid = ReadinessSurveyDB.dbo.tblSubject.Subjectid  ";
            sql = sql + "  WHERE        (ReadinessSurveyDB.dbo.tblClass.Classid = '" + drpClass.SelectedValue.ToString() + "') AND (ReadinessSurveyDB.dbo.tblSubject.Subjectname = 'Combined Exam')  ";


            if (oo.Duplicate(sql))
            {
                SurveyId = oo.ReturnTag(sql, "Surveyid");

            }




            SqlCommand cmd1 = new SqlCommand();
            cmd1.CommandText = "tblStudentandStudentDetailsNewReturnStudentidProc";
            cmd1.CommandType = CommandType.StoredProcedure;
            cmd1.Parameters.AddWithValue("@Studentname", ss);
            cmd1.Parameters.AddWithValue("@SCSId", scsid);
            cmd1.Parameters.AddWithValue("@Gender", ddlGender.SelectedItem.ToString());
            cmd1.Parameters.AddWithValue("@Address", "");
            cmd1.Parameters.AddWithValue("@Hphone", " ");
            cmd1.Parameters.AddWithValue("@Mother", "");
            cmd1.Parameters.AddWithValue("@Father", "");
            cmd1.Parameters.AddWithValue("@Contactno", txtMobile.Text.Trim());
            cmd1.Parameters.AddWithValue("@SchoolName", "-");
            cmd1.Parameters.AddWithValue("@SchoolPrincipal", "-");
            cmd1.Parameters.AddWithValue("@Country", "India");
            cmd1.Parameters.AddWithValue("@email", txtEmail.Text.Trim());
            cmd1.Parameters.AddWithValue("@state", "");
            cmd1.Parameters.AddWithValue("@city", "");
            cmd1.Parameters.AddWithValue("@BoardId", BoardId);
            cmd1.Parameters.AddWithValue("@StudentIndex", "");
            cmd1.Parameters.AddWithValue("@Session", SessionName);
            cmd1.Parameters.AddWithValue("@sessionid", Sessionid);
            cmd1.Parameters.AddWithValue("@Surveyid", SurveyId);
            SqlParameter p1 = new SqlParameter("@StudentId", SqlDbType.NVarChar, 6);
            p1.Value = StudentId;
            cmd1.Parameters.Add(p1);
            p1.Direction = ParameterDirection.InputOutput;



            SqlParameter p2 = new SqlParameter("@Pass1", SqlDbType.NVarChar, 6);
            cmd1.Parameters.Add(p2);
            p2.Value = Pass1;
            p2.Direction = ParameterDirection.InputOutput;
            cmd1.Connection = con1;
            try
            {
                con1.Open();
                cmd1.ExecuteNonQuery();
                con1.Close();
                StudentId = cmd1.Parameters["@StudentId"].Value.ToString();
                Pass1 = cmd1.Parameters["@Pass1"].Value.ToString();



            }
            catch (Exception) { con1.Close(); }
            sql = " select max(AdmissiondetailId)+1 as  TT  from OnlineAdmissionDetail  ";

            ss = oo.ReturnTag(sql, "TT");


            XMLDATASTring += "<node>";
            XMLDATASTring += "<AdmissiondetailId>" + ss + "</AdmissiondetailId>";
            XMLDATASTring += "<Sno>" + lblsno.Text.Trim() + "</Sno>";
            XMLDATASTring += "<FName>" + txtStuFName.Text.Trim() + "</FName>";
            XMLDATASTring += "<MName>" + txtStuMName.Text.Trim() + "</MName>";
            XMLDATASTring += "<LName>" + txtStuLName.Text.Trim() + "</LName>";
            //XMLDATASTring += "<Dob>" + txtDate.Text.Trim() + "</Dob>";
            XMLDATASTring += "<Dob>" + DD + "</Dob>";
            XMLDATASTring += "<Class>" + drpClass.SelectedItem.Text + "</Class>";
            XMLDATASTring += "<Gender>" + ddlGender.SelectedItem.Text + "</Gender>";
            XMLDATASTring += "<StudentId>" + StudentId + "</StudentId>";
            XMLDATASTring += "<Password>" + Pass1 + "</Password>";
            XMLDATASTring += "</node>";



          //  InsertDataInMElimu(StudentId, txtStuFName.Text.Trim(), txtStuLName.Text.Trim(), txtEmail.Text.ToString(), Pass1, SurveyId);
        }

        XMLDATASTring += "</data>";



        
    }



    
    private string htmlemailbodyNew(string Loginid, string Pass)
    {
        string ss = "";
        StringBuilder body = new StringBuilder();
        string PName="";
        string CName1 = "";


        


            sql="   SELECT        dbo.OnlineAdmissionMast.PrimeContact, dbo.OnlineAdmissionMast.FName+' '+ dbo.OnlineAdmissionMast.MName+' '+ dbo.OnlineAdmissionMast.LName as FatherName, dbo.OnlineAdmissionDetail.Sno, dbo.OnlineAdmissionDetail.FName AS Expr1, ";
            sql=sql+"                   dbo.OnlineAdmissionDetail.MName AS Expr2, dbo.OnlineAdmissionDetail.LName AS Expr3, dbo.OnlineAdmissionDetail.Dob, dbo.OnlineAdmissionDetail.Class, dbo.OnlineAdmissionDetail.StudentId, ";
            sql=sql+"              dbo.OnlineAdmissionMast.Email, dbo.OnlineAdmissionMast.Mobileno, dbo.OnlineAdmissionMast.NoofChildren, dbo.OnlineAdmissionMast.Password, dbo.OnlineAdmissionMast.AdmissionId ,";
            sql = sql + "    dbo.OnlineAdmissionDetail.FName + ' ' + dbo.OnlineAdmissionDetail.MName + ' ' + dbo.OnlineAdmissionDetail.LName AS StudentName  ";
            sql=sql+" FROM            dbo.OnlineAdmissionMast INNER JOIN ";
            sql = sql + "                      dbo.OnlineAdmissionDetail ON dbo.OnlineAdmissionMast.AdmissionId = dbo.OnlineAdmissionDetail.OnlineAdmissionid ";
            sql = sql + "  where dbo.OnlineAdmissionMast.AdmissionId='" + Loginid + "'";


            int co = 0;
            Boolean flag = false;
            SqlCommand cmd = new SqlCommand();
            try
            {
                cmd.CommandText = sql;
                SqlDataReader dr;
                cmd.Connection = con;

                con.Open();
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    CName1 = CName1 + oo.ReturnTag(sql, "StudentName") + " ,";
                }
                con.Close();
            }
            catch (SqlException)
            {
                con.Close();
            }

            PName = oo.ReturnTag(sql, "FatherName");
        
        
     

           

            ss="<table>";

            ss=ss+"<tr>";
            ss=ss+"<td> Dear "+ PName +":";
            ss=ss+"</td>";
            ss=ss+"</tr>";

            ss = ss + "<tr>";
            ss = ss + "<td>";
            ss = ss + "&nbsp;";
            ss = ss + "</td>";
            ss = ss + "</tr>";
        
            ss=ss+"<tr>";
            ss=ss+"<td>";
            ss = ss + " Your child/ren " + CName1 + " is/are now pre-registered on www.ciseducation.org/admissions2024. ";
            ss=ss+"</td>";
            ss=ss+"</tr>";

            ss = ss + "<tr>";
            ss = ss + "<td>";
            ss = ss + "&nbsp;";
            ss = ss + "</td>";
            ss = ss + "</tr>";

            ss=ss+"<tr>";
            ss=ss+"<td>";
            ss=ss+" Your Login ID and Password for the same have been sent on your mobile and further given below herewith:";
            ss=ss+"</td>";

            ss=ss+"<tr>";
            ss=ss+"<td>";
            ss = ss + "Please pay a Registration Fee of Rs. 700 and complete the Admission Form.";
            ss=ss+"</td>";
            ss=ss+"</tr>";

            ss=ss+"<tr>";
            ss=ss+"<td>";
            ss = ss + "Next, you may visit the school for a Readiness Survey of your child/children which provides <b>iversusi</b> personalized ";
            ss=ss+"</td>";
            ss=ss+"</tr>";


            ss=ss+"<tr>";
            ss=ss+"<td>";
            ss = ss + "diagnostic reports of your child/children's current areas of strength and improvement in the core subjects.";
            ss=ss+"</td>";


            ss=ss+"<tr>";
            ss=ss+"<td>";
            ss = ss + " <p>&#10003;Get appointment to visit the school with your child/children (contact numbers as below). Allocate two hours or more of your time at the school. </p>";
            ss=ss+"</td>";
            ss=ss+"</tr>";


            ss = ss + "<tr>";
            ss = ss + "<td>";
            ss = ss + " <p>&#10003;You will be informed by text message, or a call, that will confirm your children’s admission. </p> ";
            ss = ss + "</td>";
            ss = ss + "</tr>";

       
            ss=ss+"<tr>";
            ss=ss+"<td>";
            ss = ss + " <p>&#10003;Once admission is confirmed, you will be asked review and sign a parent undertaking.</p>	 ";
            ss=ss+"</td>";
            ss=ss+"</tr>";



            ss=ss+"<tr>";
            ss=ss+"<td>";
            ss = ss + " <p>&#10003;	Submit the admission form, all required documents, and requisite fees to confirm admission within a week. After this date, admission will depend upon availability on first come, first served basis. </p>";
            ss=ss+"</td>";
            ss=ss+"</tr>";

            ss=ss+"<tr>";
            ss=ss+"<td>";
            ss=ss+"&nbsp;";
            ss=ss+"</td>";
            ss=ss+"</tr>";


            ss=ss+"<tr>";
            ss=ss+"<td>";
            ss=ss+"<b>TALENT HUNT</b>";
            ss=ss+"</td>";
            ss=ss+"</tr>";

            ss=ss+"<tr>";
            ss=ss+"<td>";
            ss=ss+"&nbsp;";
            ss=ss+"</td>";
            ss=ss+"</tr>";


            ss=ss+"<tr>";
            ss=ss+"<td>";

            ss=ss+"CIS provides two types of scholarships: Academic Scholarship and Talent Scholarship. Students that qualify get a scholarship and a Scholarship Award Certificate.  ";
            ss=ss+"</td>";
            ss=ss+"</tr>";


            ss=ss+"<tr>";
            ss=ss+"<td>";
            ss=ss+"Sincerely,";
            ss=ss+"</td>";
            ss=ss+"</tr>";

            ss = ss + "<tr>";
            ss = ss + "<td>";
            ss = ss + "&nbsp;";
            ss = ss + "</td>";
            ss = ss + "</tr>";

            ss = ss + "<tr>";
            ss = ss + "<td>";
            ss = ss + "&nbsp;";
            ss = ss + "</td>";
            ss = ss + "</tr>";


            ss=ss+"<tr>";
            ss=ss+"<td>";
            ss=ss+"The Principal";
            ss=ss+"</td>";
            ss=ss+"</tr>";

            ss=ss+"<tr>";
            ss=ss+"<td>";
            ss=ss+"PS: For all admission related queries, please call the numbers below. For technical queries, please call Saurabh Kumar or Manish Srivastava on +91 923 562 0009; +91 998 455 8888 respectively.";
            ss=ss+"</td>";
            ss=ss+"</tr>";

            ss=ss+"<tr>";
            ss=ss+"<td>";
            ss=ss+"*SCHOOL LOCATIONS WITH MOBILE NUMBERS ";
            ss=ss+"</td>";
            ss=ss+"</tr>";


            ss = ss + "<tr>";
            ss = ss + "<td>";
            ss = ss + "&nbsp;";
            ss = ss + "</td>";
            ss = ss + "</tr>";

            ss=ss+"<tr>";
            ss=ss+"<td>";
            ss=ss+"CAMPUS LOCATIONS & CONTACT NUMBERS:";
            ss=ss+"</td>";
            ss=ss+"</tr>";


            ss = ss + "<tr>";
            ss = ss + "<td>";
            ss = ss + "&nbsp;";
            ss = ss + "</td>";
            ss = ss + "</tr>";


            ss=ss+"<tr>";
            ss=ss+"<td>";
            ss=ss+"• Indira Nagar, Lucknow (911 509 9992)";
            ss=ss+"</td>";
            ss=ss+"</tr>";

            ss = ss + "<tr>";
            ss = ss + "<td>";
            ss = ss + "• Shakti Nagar, Lucknow (740 854 4111)";
            ss = ss + "</td>";
            ss = ss + "</tr>";


            ss = ss + "<tr>";
            ss = ss + "<td>";
            ss = ss + "• Balaganj, Lucknow (926 097 8683)";
            ss = ss + "</td>";
            ss = ss + "</tr>";


           
            ss=ss+"<tr>";
            ss=ss+"<td>";
            ss=ss+"• Gomti Nagar Extension, Lucknow (700 791 1415)";
            ss=ss+"</td>";
            ss=ss+"</tr>";


            ss = ss + "<tr>";
            ss = ss + "<td>";
            ss = ss + "• Deva Road, Lucknow (933 669 3127)";
            ss = ss + "</td>";
            ss = ss + "</tr>";


            ss = ss + "<tr>";
            ss = ss + "<td>";
            ss = ss + "• Kursi Road, Lucknow (993 562 4851)";
            ss = ss + "</td>";
            ss = ss + "</tr>";
       

            ss = ss + "<tr>";
            ss = ss + "<td>";
            ss = ss + "• Rani Shanti Devi Palace, Hathondha, Ram Snehi Ghaat, Barabanki (740 840 3000)";
            ss = ss + "</td>";
            ss = ss + "</tr>";


            ss = ss + "<tr>";
            ss = ss + "<td>";
            ss = ss + "• Pratap Nagar, Jaipur (958 068 1000)";
            ss = ss + "</td>";
            ss = ss + "</tr>";


            ss = ss + "<tr><td><br /></td></tr>";
            ss = ss + "<tr><td>Your children are now registered.</td></tr>";
            ss = ss + "<tr><td><br /></td></tr>";


            ss = ss + "<tr><td>Please complete the remaining admission formalities on</td></tr>";
            ss = ss + "<tr><td> http://www.ciseducation.org/plogin.aspx </td></tr>";
            ss = ss + "<tr><td><br /></td></tr>";
            ss = ss + "<tr><td>Use ID and PASSWORD as below: </td></tr>";
            ss = ss + "<tr><td><br /></td></tr>";
            ss = ss + "<tr><td>Login id: " + Loginid + "</td></tr>";
            ss = ss + "<tr><td>Password: " + Pass + "</td></tr>";

           
            ss = ss + "</table>";


        body.Append(ss);
        return body.ToString();





    }


    public void InsertDataInMElimu(string Loginid, string Fname,string Lname,string Email,string Pass,string ExamID)
    {
        string ss = "";
     
        // priority.callcum.in/ app / smsapi / index.php ? key = 4591D844372BD4 & routeid = 295 & type = text & contacts = 9044112299 & senderid = Edison & msg = Hello

        WebClient client = new WebClient();

        //priority.callcum.in/app/smsapi/index.php?key=559EDCA7F6D26A&routeid=15&type=text&contacts=9984558888&senderid=EDISON&msg=Hello
        //string baseurl = "http://priority.callcum.in/app/smsapi/index.php?key=559EDCA7F6D26A&routeid=15&type=text&contacts=" + mob + "&senderid=CISEDU&msg=" + ss;

        string baseurl = "https://cis-exam.melimu.com/local/geti_registration/receiver.php?token=62f4ff9d248b4dd02e4fc796349a6a49&method=enrollment&username="+Loginid+"&firstname="+Fname+"&lastname="+Lname+"&email="+Email +"&password="+Pass+"&exam_id="+ExamID;
        Stream data = client.OpenRead(baseurl);
        StreamReader reader = new StreamReader(data);
        string s = reader.ReadToEnd();
        data.Close();
        reader.Close();

    
    }

    protected void Button4_Click(object sender, EventArgs e)
    {
        Response.Redirect("https://ciseducation.org/admit");
    }
}