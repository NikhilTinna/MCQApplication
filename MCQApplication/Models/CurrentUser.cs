namespace MCQApplication.Models
{
    public class CurrentUser
    {
       public static string Username { get; set; }
       public static string Password { get; set; }
        public static bool isLoggedIn { get; set; } = false;
    }
}
