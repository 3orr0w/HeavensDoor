namespace HeavensDoorServer.Classes
{
    public class Autorization
    {
        public string Login { get; set; }
        public string Password { get; set; }

        public Autorization(string login,string password)
        {
            this.Login = login;
            this.Password = password;
        }
    }
}
