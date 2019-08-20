using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Data;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Day5_8
{
    public partial class Sample : System.Web.UI.Page
    {
        AllMessage m = new AllMessage();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindGrid();
                //Adding an Attribute to Server Control(i.e. ButtonDeleteRecord)  
                ButtonDeleteRecord.Attributes.Add("onclick", "javascript:return DeleteConfirm()");
            }
        }
        protected void BindGrid()
        {
            try
            {
                string cstring = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
                MySqlConnection con = new MySqlConnection(cstring);
                MySqlCommand cmd = new MySqlCommand("select * from territories", con);
                MySqlDataAdapter sda = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                GridView1.DataSource = ds;
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            BindGrid();
        }
        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            BindGrid();
        }
        protected void ButtonDeleteRecord_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (GridViewRow grow in GridView1.Rows)
                {
                    //Searching CheckBox("CheckBoxDelete") in an individual row of Grid
                    CheckBox checkdel = (CheckBox)grow.FindControl("CheckBoxDelete");
                    //If CheckBox is checked than delete the record with particular empid and terid
                    if (checkdel.Checked)
                    {
                        int terID = Convert.ToInt32(GridView1.DataKeys[grow.RowIndex].Values["TerritoryID"]);
                        string cstring = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
                        MySqlConnection con = new MySqlConnection(cstring);
                        MySqlCommand cmd1 = new MySqlCommand(m.strEmTerDel + terID + "' ", con);
                        con.Open();
                        cmd1.ExecuteNonQuery();
                        MySqlCommand cmd2 = new MySqlCommand(m.strTerDel + terID + "'", con);
                        cmd2.ExecuteNonQuery();
                        con.Close();
                        BindGrid();
                        ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert('Record is deleted successfully');", true);
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
            finally
            {
                m = null;
            }
        }
        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            object TerrUpID; //Object needed to fetch the current values of gridview rows
            MySqlCommand verifyTerID;
            MySqlCommand verifyInEmp;
            int terIDValue;
            int terInEmpValue;
            TerrUpID = GridView1.DataKeys[e.RowIndex].Values["TerritoryID"];
            GridViewRow row = GridView1.Rows[e.RowIndex];
            string ter = ((TextBox)row.FindControl("textGridTerritoryID")).Text;
            try
            {
                string cstring = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
                MySqlConnection con = new MySqlConnection(cstring);
                if (con != null && con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                //Checking if territory id exists or not in territories Table
                StringBuilder strter = new StringBuilder(m.strTerrCheck + ter + "'");
                verifyTerID = new MySqlCommand(strter.ToString(), con);
                terIDValue = Convert.ToInt32(verifyTerID.ExecuteScalar());
                //Checking if territory id exists or not in employeeterritories Table
                StringBuilder strTerInEmp = new StringBuilder(m.strTerInEmCheck + ter + "'");
                verifyInEmp = new MySqlCommand(strTerInEmp.ToString(), con);
                terInEmpValue = Convert.ToInt32(verifyInEmp.ExecuteScalar());
                if(terIDValue > 0)
                {
                    ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert('TerritoryID already exists in Territories Table');", true);
                }
                if (terInEmpValue > 0)
                {
                    ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert('TerritoryID already exists in EmployeeTerritories Table');", true);
                }
                else
                {
                    GridView1.EditIndex = -1;
                    MySqlCommand cmd = new MySqlCommand(m.strUpdate1 + ter + "' where TerritoryID = '" + TerrUpID + "'; " + m.strUpdate2 + ter + "' where TerritoryID = '" + TerrUpID + "'", con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    BindGrid();
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
            finally
            {
                TerrUpID = null;
                verifyInEmp = null;
                verifyTerID = null;
                m = null;
            }
        }
        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            BindGrid();
        }
        protected void AddButtonClick(object sender, EventArgs e)
        {
            AllMessage m = new AllMessage();
            //MySqlCommand verifyEmpID;
            MySqlCommand verifyTerID;
            MySqlCommand verifyEmpTerID;
            //int empIDvalue;
            int terIDvalue;
            int empTerIDvalue;
            try
            {
                string cstring = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
                MySqlConnection con = new MySqlConnection(cstring);
                if (con != null && con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                ////Check if EmployeeID Present in in Employees Table
                //StringBuilder strEmpCheck = new StringBuilder(m.strEmpCheck + textEmployeeID.Text + "'");
                //verifyEmpID = new MySqlCommand(strEmpCheck.ToString(), con);
                //empIDvalue = Convert.ToInt32(verifyEmpID.ExecuteScalar());

                //Check if TerritoryID Present in in Territory Table
                StringBuilder strTerr = new StringBuilder(m.strTerrCheck + textTerritoryID.Text + "'");
                verifyTerID = new MySqlCommand(strTerr.ToString(), con);
                terIDvalue = Convert.ToInt32(verifyTerID.ExecuteScalar());

                //Check if TerritoryID for corresponding EmployeeID are present in Employeeterritories Table
                StringBuilder strEmpTerr = new StringBuilder(m.strEmpTerCheck + textEmployeeID.Text + "' AND TerritoryID='" + textTerritoryID.Text + "'");
                verifyEmpTerID = new MySqlCommand(strEmpTerr.ToString(), con);
                empTerIDvalue = Convert.ToInt32(verifyEmpTerID.ExecuteScalar());
                //if(empIDvalue > 0)
                //{
                //    ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert('EmployeeID already exists in Employees Table');", true);
                //}
                if (terIDvalue > 0)
                {
                    ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert('TerritoryID already exists in Territories Table');", true);
                }
                else if (empTerIDvalue > 0)
                {
                    ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert('EmployeeID and TerritoryID already exists in Employees table');", true);
                }
                else
                {
                    MySqlCommand cmd2 = new MySqlCommand(m.strInsertInEmpTer + textEmployeeID.Text + "', '" + textTerritoryID.Text + "');" + m.strInsertTer + textTerritoryID.Text + "','" + textTerritoryDescription.Text + "','" + textRegionID+"');", con);
                    cmd2.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
            finally
            {
                m = null;
                verifyTerID = null;
                verifyEmpTerID = null;
            }
        }
    }
}