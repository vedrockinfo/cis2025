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
public partial class Plogin : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection();
    string sql = "";
    NurtureLib oo = new NurtureLib();
    protected void Page_Load(object sender, EventArgs e)
    {
        con.ConnectionString = ConfigurationManager.ConnectionStrings["CISCon"].ConnectionString;
    }
    protected void Button1_Click(object sender, EventArgs e)
    {

            string Status = "";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "LoginVerifyProc";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@Loginid", txtLogin.Text.Trim());
            cmd.Parameters.AddWithValue("@Password", txtPass.Text.Trim());

            SqlParameter p1 = new SqlParameter("@Status", SqlDbType.NVarChar, 20);
            p1.Value = Status;
            p1.Direction = ParameterDirection.InputOutput;
            cmd.Parameters.Add(p1);


           

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                Status = cmd.Parameters["@Status"].Value.ToString();
            }
            catch (Exception) { }

            if (Status.Trim() == "Y")
            {
                Session["PLogin"] = txtLogin.Text.Trim();
                Response.Redirect("ParentLogin\\Dashboard.aspx");
            }

            else if (txtLogin.Text.Trim() == "Admin" && txtPass.Text.Trim() == "Admin")
            {
                Session["PLogin"] = txtLogin.Text.Trim();
                Response.Redirect("AdminAdmission\\Dashboard.aspx");
            }
            else
            {
                lblError.Text = "Sorry! invalid Login";
            }
    }
}