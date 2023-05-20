using System.Data;
using System.Data.SqlClient;

namespace WebAppADO.Models
{
    public class StudentDataAccessLayer
    {
        string connectionString = "Data Source=.;  Initial Catalog=StudentManagement;Integrated Security=True";


        public IEnumerable<Student> GetAllStudent()
        {
            List<Student> lstStudent = new List<Student>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("select * from Student", con);
                cmd.CommandType = CommandType.Text;

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Student student = new Student();

                    student.Id = Convert.ToInt32(rdr["id"]);
                    student.Name = rdr["name"].ToString();
                    student.Section = rdr["section"].ToString();

                    lstStudent.Add(student);
                }
                con.Close();

            }
            return lstStudent;
        }


        public void AddStudent(Student student)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_AddStudent", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Name", student.Name);
                cmd.Parameters.AddWithValue("@Section", student.Section);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}
