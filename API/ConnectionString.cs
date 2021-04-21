namespace API
{
    public class ConnectionString
    {
        public string cs {get; set;}
        public ConnectionString() {
            string server = "cis9cbtgerlk68wl.cbetxkdyhwsb.us-east-1.rds.amazonaws.com";
            string database = "e3f62d2nfi32fcfa";
            string port = "3306";
            string userName = "pcevcp7lz1zuhjj2";
            string password = "y6wvwvl0nsbqj2kb";

            cs = $@"server={server};user={userName};database={database};port={port};password={password};";

        }
    }
}