using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace EmployeeDetails
{
    public partial class AddEmployee : System.Web.UI.Page
    {
        SqlConnection con;
        SqlCommand cmd;
        protected void Page_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString);            
            
            if(!IsPostBack)
            {
                LoadDept();
                txtName.Focus();
            }

        }
        private void LoadDept()
        {
            cmd = new SqlCommand("Select Did,Dname from Department Order by Did", con);

            if (con.State == ConnectionState.Closed)
                con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            ddlDept.DataSource = dr;
            ddlDept.DataTextField = "Dname";
            ddlDept.DataValueField = "Did";
            ddlDept.DataBind();
            ddlDept.Items.Insert(0, "-Select Department-");
            con.Close();
        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            if (ddlDept.SelectedIndex > 0)
            {
                cmd = new SqlCommand($"Insert Into Employee Values('{txtName.Text}', '{txtJob.Text}', {txtSalary.Text}, {ddlDept.SelectedValue})", con);
                
                con.Open();
                if (cmd.ExecuteNonQuery() > 0)
                {
                    cmd.CommandText = "Select Max(Eid) From Employee";
                    txtId.Text = cmd.ExecuteScalar().ToString();
                }
                else
                {
                    Response.Write("<script>alert('Failed inserting record into the table.')</script>");
                }
                con.Close();
            }
            else
            {
                Response.Write("<script>alert('Please choose a department to insert.')</script>");
            }

        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            txtId.Text = txtName.Text = txtJob.Text = txtSalary.Text = "";
            ddlDept.SelectedIndex = 0;
            txtName.Focus();

        }
    }
}