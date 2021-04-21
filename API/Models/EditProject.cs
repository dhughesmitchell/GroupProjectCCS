using API.Models.Interfaces;
using MySql.Data.MySqlClient;

namespace API.Models
{
    public class EditProject : IEdit
    {
        public void EditProjectByID(Project myProject) {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = @"UPDATE projects set currentStatus = @currentStatus WHERE projectID = @projectID";
            using var cmd = new MySqlCommand(stm, con);

            cmd.Parameters.AddWithValue("@projectID", myProject.projectID);
            cmd.Parameters.AddWithValue("@startDate", myProject.startDate);
            cmd.Parameters.AddWithValue("@deliveryDate", myProject.deliveryDate);
            cmd.Parameters.AddWithValue("@projectName", myProject.projectName);
            cmd.Parameters.AddWithValue("@paymentMethod", myProject.paymentMethod);
            cmd.Parameters.AddWithValue("@currentStatus", myProject.currentStatus);
            cmd.Parameters.AddWithValue("@managerName", myProject.managerName);
            cmd.Parameters.AddWithValue("@clientName", myProject.clientName);
            

            cmd.Prepare();

            cmd.ExecuteNonQuery();

        }
    }
}