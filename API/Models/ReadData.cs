using System.Collections.Generic;
using API.Models.Interfaces;
using MySql.Data.MySqlClient;

namespace API.Models
{
    public class ReadData : IGetAll, IGet
    {
        public List <Project> GetAllProjects() {
            List <Project> allProjects = new List<Project>();

            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;

            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = "SELECT * FROM projects";
            using var cmd = new MySqlCommand(stm, con);

            using MySqlDataReader rdr = cmd.ExecuteReader();

            while(rdr.Read()) {
                Project temp = new Project(){projectID=rdr.GetInt32(0), startDate=rdr.GetString(1), deliveryDate=rdr.GetString(2), projectName=rdr.GetString(3), paymentMethod=rdr.GetString(4), currentStatus=rdr.GetString(5), managerName=rdr.GetString(6), clientName=rdr.GetString(7)};
                allProjects.Add(temp);
            }
            return allProjects;
        }
        public Project GetProject(int projectID) {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;

            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = "SELECT * FROM projects WHERE projectID = @projectID";
            using var cmd = new MySqlCommand(stm, con);
            cmd.Parameters.AddWithValue("@projectID", projectID);
            cmd.Prepare();
            using MySqlDataReader rdr = cmd.ExecuteReader();

            rdr.Read();
            return new Project(){projectID=rdr.GetInt32(0), startDate=rdr.GetString(1), deliveryDate=rdr.GetString(2), projectName=rdr.GetString(3), paymentMethod=rdr.GetString(4), currentStatus=rdr.GetString(5), managerName=rdr.GetString(6), clientName=rdr.GetString(7)};

        }
    }
}