using MySql.Data.MySqlClient;
using API.Models.Interfaces;

namespace API.Models
{
    public class SaveProject : IInsert
    {
        public static void CreateProjectTable() {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;

            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = @"CREATE TABLE projects(projectID INTEGER PRIMARY KEY AUTO_INCREMENT, startDate TEXT, deliveryDate TEXT, projectName TEXT, paymentMethod TEXT, currentStatus TEXT, managerName TEXT, clientName TEXT)";

            using var cmd = new MySqlCommand(stm, con);

            cmd.ExecuteNonQuery();
        }
        public void InsertProject(Project myProject) {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = @"INSERT INTO projects(projectID, startDate, deliveryDate, projectName, paymentMethod, currentStatus, managerName, clientName) VALUES(@projectID, @startDate, @deliveryDate, @projectName, @paymentMethod, @currentStatus, @managerName, @clientName)";
            using var cmd = new MySqlCommand(stm, con);

            cmd.Parameters.AddWithValue("@projectID", myProject.projectID);
            cmd.Parameters.AddWithValue("@startDate", myProject.startDate);
            cmd.Parameters.AddWithValue("@deliveryDate", myProject.deliveryDate);
            cmd.Parameters.AddWithValue("@projectName", myProject.projectName);
            cmd.Parameters.AddWithValue("@paymentMethod", myProject.paymentMethod);
            cmd.Parameters.AddWithValue("@currentStatus", myProject.currentStatus);
            cmd.Parameters.AddWithValue("@managerID", myProject.managerName);
            cmd.Parameters.AddWithValue("@clientID", myProject.clientName);
            

            cmd.Prepare();

            cmd.ExecuteNonQuery();

        }
    }
}