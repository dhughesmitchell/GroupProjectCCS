namespace API.Models
{
    public class Project
    {
        public int projectID {get; set;}
        public string startDate {get; set;}
        public string deliveryDate {get; set;}
        public string projectName {get; set;}
        public string paymentMethod {get; set;}
        public string currentStatus {get; set;}
        public string managerName {get; set;}
        public string clientName {get; set;}

        public override string ToString()
        {
            return projectID + " " + projectName;
        }
    }
}