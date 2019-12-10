namespace BasicAuthentication.Func
{
    public class Login
    {
        public static bool User(string name, string password)
        {
            return name == "test" && password == "test";
        }
    }
}