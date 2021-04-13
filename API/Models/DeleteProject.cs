using MySql.Data.MySqlClient;

namespace API.Models
{
    public class DeleteProject
    {
        public void DeleteProjectByID(int projectID) {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;

            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = @"DELETE FROM projects WHERE projectID = @projectID";
            using var cmd = new MySqlCommand(stm, con);

            cmd.Parameters.AddWithValue("@projectID", projectID);
            cmd.Prepare();

            cmd.ExecuteNonQuery();

        }
    }
}