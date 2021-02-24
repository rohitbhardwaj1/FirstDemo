using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Web.Mvc;

namespace FirstDemo.Models
{
    public class StudentDBHandle
    {
        private SqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["studentconn"].ToString();
            con = new SqlConnection(constring);
        }

        // **************** ADD NEW STUDENT *********************
        public bool AddStudent(StudentModel smodel)
        {
            try
            {
                connection();
                SqlCommand cmd;
                //if (smodel.Id > 0)
                //{
                //    cmd = new SqlCommand("UpdateStudentDetails", con);
                //    cmd.Parameters.AddWithValue("@StdId", smodel.Id);
                //}
                //else
                //{
                cmd = new SqlCommand("AddNewStudent", con);
                //}
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Name", smodel.Name);
                cmd.Parameters.AddWithValue("@City", smodel.City);
                cmd.Parameters.AddWithValue("@Address", smodel.Address);
                cmd.Parameters.AddWithValue("@DOB", smodel.DOB);
                cmd.Parameters.AddWithValue("@GenderId", smodel.GenderId);
                cmd.Parameters.AddWithValue("@Gender", smodel.Gender);
                cmd.Parameters.AddWithValue("@IsMovie", smodel.IsMovie);
                cmd.Parameters.AddWithValue("@IsCricket", smodel.IsCricket);

                con.Open();
                int i = cmd.ExecuteNonQuery();
                con.Close();

                if (i >= 1)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            { return false; }
        }

        // ********** VIEW STUDENT DETAILS ********************
        public List<StudentModel> GetStudent()
        {
            connection();
            List<StudentModel> studentlist = new List<StudentModel>();
            try
            {
                SqlCommand cmd = new SqlCommand("GetStudentDetails", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sd = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                con.Open();
                sd.Fill(dt);
                con.Close();

                foreach (DataRow dr in dt.Rows)
                {
                    studentlist.Add(
                        new StudentModel
                        {
                            Id = Convert.ToInt32(dr["Id"]),
                            Name = Convert.ToString(dr["Name"]),
                            City = Convert.ToString(dr["City"]),
                            Address = Convert.ToString(dr["Address"]),
                            DOB = Convert.ToDateTime(dr["DOB"].ToString()),
                            GenderId = Convert.ToInt32(dr["GenderId"]),
                            Gender = dr["Gender"].ToString(),
                            IsCricket = Convert.ToBoolean(dr["Hobbi1"].ToString()),
                            IsMovie = Convert.ToBoolean(dr["Hobbi2"].ToString())
                        });
                }
            }
            catch (Exception ex)
            { }
            return studentlist;
        }
       

        // ***************** UPDATE STUDENT DETAILS *********************
        public bool UpdateDetails(StudentModel smodel)
        {
            try
            { 
            connection();
            SqlCommand cmd = new SqlCommand("UpdateStudentDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@StdId", smodel.Id);
            cmd.Parameters.AddWithValue("@Name", smodel.Name);
            cmd.Parameters.AddWithValue("@City", smodel.City);
            cmd.Parameters.AddWithValue("@Address", smodel.Address);
            cmd.Parameters.AddWithValue("@DOB", smodel.DOB);
            cmd.Parameters.AddWithValue("@GenderId", smodel.GenderId);
                cmd.Parameters.AddWithValue("@Gender", smodel.Gender);
                cmd.Parameters.AddWithValue("@IsMovie", smodel.IsMovie);
                cmd.Parameters.AddWithValue("@IsCricket", smodel.IsCricket);

                con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
            }
            catch (Exception ex)
            { return false; }
        }

        // ********************** DELETE STUDENT DETAILS *******************
        public bool DeleteStudent(int id)
        {
            connection();
            SqlCommand cmd = new SqlCommand("DeleteStudent", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@StdId", id);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        public List<StudentModel> GenList()
        {
            connection();
            List<StudentModel> genlist = new List<StudentModel>();
            try
            {
                SqlCommand cmd = new SqlCommand("GetGenderMst", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sd = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                con.Open();
                sd.Fill(dt);
                con.Close();

                foreach (DataRow dr in dt.Rows)
                {
                    genlist.Add(
                        new StudentModel
                        {
                            Id = Convert.ToInt32(dr["Id"]),
                            Name = Convert.ToString(dr["Name"])
                        });
                }
            }
            catch (Exception ex)
            { }
            return genlist;
        }
    }
}