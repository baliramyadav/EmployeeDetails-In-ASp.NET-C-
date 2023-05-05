using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Security.Cryptography;

namespace EmployeeDetails
{
    public partial class update_DeleteEmployee : System.Web.UI.Page
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        protected void Page_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString);
            cmd = new SqlCommand();
            cmd.Connection = con;
            if (!IsPostBack)
            {
                LoadEmp();
                LoadDept();
                ddlEmp.Focus();
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

        private void LoadEmp()
        {
            cmd.CommandText = "Select Eid from Employee Order By Eid";
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }
            dr = cmd.ExecuteReader();
            ddlEmp.DataSource = dr;
            ddlEmp.DataTextField = "Eid";
            ddlEmp.DataValueField = "Eid";
            ddlEmp.DataBind();
            ddlEmp.Items.Insert(0, "-Select Employee-");
            con.Close();

        }

        protected void ddlEmp_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlEmp.SelectedIndex > 0)
            {
                cmd.CommandText = "Select Ename, Job, Salary, Did From Employee Where Eid=" + ddlEmp.SelectedValue;
                con.Open();
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    txtName.Text = dr["Ename"].ToString();
                    txtJob.Text = dr["Job"].ToString();
                    txtSalary.Text = dr["Salary"].ToString();
                    ddlDept.SelectedValue = dr["Did"].ToString();
                }
                con.Close();
            }
            else
            {
                txtName.Text = txtJob.Text = txtSalary.Text = "";
                ddlDept.SelectedIndex = 0;
                ddlEmp.Focus();
            }

        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (ddlEmp.SelectedIndex > 0)
            {
                if (ddlDept.SelectedIndex > 0)
                {
                    cmd.CommandText = $"Update Employee Set Ename='{txtName.Text}', Job='{txtJob.Text}', Salary ={txtSalary.Text}, Did ={ddlDept.SelectedValue}  Where Eid = {ddlEmp.SelectedValue}";
                    con.Open();
                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        Response.Write("<script>alert('Record updated in the table.')</script>");
                    }
                    else
                    {
                        Response.Write("<script>alert('Failed updating record in the table.')</script>");
                    }
                    con.Close();
                }
                else
                {
                    Response.Write("<script>alert('Please choose a department to update.')</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Please choose a employee to update.')</script>");
            }

        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (ddlEmp.SelectedIndex > 0)
            {
                cmd.CommandText = "Delete From Employee Where Eid=" + ddlEmp.SelectedValue;
                con.Open();
                if (cmd.ExecuteNonQuery() > 0)
                {
                    Response.Write("<script>alert('Record deleted from the table.')</script>");
                    txtName.Text = txtJob.Text = txtSalary.Text = "";
                    ddlDept.SelectedIndex = 0;
                    LoadEmp();
                    ddlEmp.Focus();
                }
                else
                {
                    Response.Write("<script>alert('Failed deleting the record from table.')</script>");
                    con.Close();
                }
            }
            else
            {
                Response.Write("<script>alert('Please choose a employee to delete.')</script>");
            }

        }
    }
}