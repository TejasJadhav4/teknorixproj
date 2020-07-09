using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TeknorixWebApplication.Interface;
using TeknorixWebApplication.Models;

namespace TeknorixWebApplication.Implementation
{
    public class UserService: IUserService
    {
        private SqlConnection con;
        private void connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["getcon"].ToString();
            con = new SqlConnection(constr);
        }
        public List<UserModel> GetList()
        {
            List<UserModel> lst = new List<UserModel>();

            DataTable table = new DataTable();
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["getcon"].ConnectionString))
            using (var cmd = new SqlCommand("GetUserList", con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                da.Fill(table);
            }
            
            if(table != null)
            {
                if(table.Rows.Count > 0)
                {
                    for (int i = 0; i < table.Rows.Count; i++)
                    {
                        lst.Add(new UserModel());
                        lst[i].UserId = Convert.ToDecimal(table.Rows[i]["UserId"].ToString());
                        lst[i].firstname = table.Rows[i]["firstname"].ToString();
                        lst[i].lastname = table.Rows[i]["lastname"].ToString();
                        lst[i].email = table.Rows[i]["email"].ToString();
                        //lst[i].lstadddress = table.Rows[i]["city"].ToString() != "" ? table.Rows[i]["city"] + ", " : "" +
                        //    table.Rows[i]["state"] != "" ? table.Rows[i]["state"] + ", " : "" +
                        //    table.Rows[i]["country"] != "" ? table.Rows[i]["country"] + ", " : "";
                        lst[i].lstadddress = table.Rows[i]["city"].ToString() + ", " + table.Rows[i]["state"]  + ", "+ table.Rows[i]["country"];
                        //lst[i].phonecode = table.Rows[i]["phonecode"].ToString();
                        //lst[i].phone = table.Rows[i]["phone"].ToString();
                        //lst[i].city = table.Rows[i]["city"].ToString();
                        //lst[i].state = table.Rows[i]["state"].ToString();
                        //lst[i].country = table.Rows[i]["country"].ToString();
                        //lst[i].code = table.Rows[i]["code"].ToString();
                    }
                }
            }
            
            return lst;
        }

        public int SaveUser(UserModel Model)
        {
            int returnint = 0;
            DataTable table = new DataTable();
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["getcon"].ConnectionString))
            using (var cmd = new SqlCommand("AddNewUserDetails", con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserId", Model.UserId);
                cmd.Parameters.AddWithValue("@firstname", Model.firstname);
                cmd.Parameters.AddWithValue("@lastname", Model.lastname);
                cmd.Parameters.AddWithValue("@email", Model.email);
                cmd.Parameters.AddWithValue("@password", Model.password);
                cmd.Parameters.AddWithValue("@phonecode", Model.phonecode);
                cmd.Parameters.AddWithValue("@phone", Model.phone);
                cmd.Parameters.AddWithValue("@city", Model.city);
                cmd.Parameters.AddWithValue("@state", Model.state);
                cmd.Parameters.AddWithValue("@country", Model.country);
                cmd.Parameters.AddWithValue("@code", Model.code);
                da.Fill(table);
            }
            if (table != null)
            {
                if (table.Rows.Count > 0)
                {
                    returnint = int.Parse(table.Rows[0][""].ToString());
                }
            }
            return returnint;
        }

        public UserModel UserDetailById(int UserId)
        {
            UserModel model = new UserModel();
            if(UserId > 0)
            {
                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["getcon"].ConnectionString))
                using (var cmd = new SqlCommand("GetUserLDetailById", con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserId", UserId);
                    da.Fill(table);
                }

                if (table != null)
                {
                    if (table.Rows.Count > 0)
                    {
                        model.UserId = Convert.ToDecimal(table.Rows[0]["UserId"].ToString());
                        model.firstname = table.Rows[0]["firstname"].ToString();
                        model.lastname = table.Rows[0]["lastname"].ToString();
                        model.email = table.Rows[0]["email"].ToString();
                        model.phonecode = table.Rows[0]["phonecode"].ToString();
                        model.phone = table.Rows[0]["phone"].ToString();
                        model.city = table.Rows[0]["city"].ToString();
                        model.state = table.Rows[0]["state"].ToString();
                        model.country = table.Rows[0]["country"].ToString();
                        model.code = table.Rows[0]["code"].ToString();
                    }
                }
            }
            return model;
        }
    }
}