namespace Freelance_Api.Models.APIs.Login.CampusNet
{
    public struct CNUserAuth
    {
        public CNUserAuth(string mAuthUsername, string mAuthPassword)
        {
            this.AuthUsername = mAuthUsername;
            this.AuthPassword = mAuthPassword;
        }
        
        public string AuthUsername { get; set; }
        public string AuthPassword { get; set; }
    }
}