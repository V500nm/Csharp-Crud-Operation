using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
 
namespace WebApplication1.Models
{
    public class DbService
    {
        //connection
        public SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ConnectionString);
        //Get data
        public List<EmpModel> GetData()
        {
            List<EmpModel> emplist = new List<EmpModel>();
            SqlCommand cmd = new SqlCommand("EmpCrud", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", "get");
            cmd.Parameters.AddWithValue("@id",0);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            adp.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                emplist.Add(new EmpModel
                {
                    ID = Convert.ToInt32(dr[0]),
                    NAME = Convert.ToString(dr[1]),
                    EMAIL = Convert.ToString(dr[2])
                });
            }
            return emplist;
        }

        //Details

        public bool Details(EmpModel obj)
        {
            SqlCommand cmd = new SqlCommand("EmpCrud", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", "get");
            cmd.Parameters.AddWithValue("@id", obj.ID);

            if (con.State == ConnectionState.Closed)
                con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        //update
        public bool Update(EmpModel obj)
        {
            SqlCommand cmd = new SqlCommand("EmpCrud", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", "update");
            cmd.Parameters.AddWithValue("@id", obj.ID);
            cmd.Parameters.AddWithValue("@name", obj.NAME);
            cmd.Parameters.AddWithValue("@email", obj.EMAIL);

            if (con.State == ConnectionState.Closed)
                con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        //Add
        public bool Add(EmpModel obj)
        {
            SqlCommand cmd = new SqlCommand("EmpCrud", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", "add");
            cmd.Parameters.AddWithValue("@id", obj.ID);
            cmd.Parameters.AddWithValue("@name", obj.NAME);
            cmd.Parameters.AddWithValue("@email", obj.EMAIL);

            if (con.State == ConnectionState.Closed)
                con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i>=1)
            {
                return true;
            }
            else
            {
                return false;
            }
          
        }

        //Delete
        public bool Delete(EmpModel obj)
        {
            SqlCommand cmd = new SqlCommand("EmpCrud", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", "delete");
            cmd.Parameters.AddWithValue("@id", obj.ID);

            if (con.State == ConnectionState.Closed)
                con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}