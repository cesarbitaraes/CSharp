namespace Blog;

public static class Configuration
{
    // Token - JWT - Json Web Token
    public static string JwtKey = "3cd465bd-0326-45ea-abc1-ab2c289825c8";
    public static string ApiKeyName = "api_key";
    public static string ApiKey = "curso_api";
    public static SmtpConfiguration Smtp = new();
    
    public class SmtpConfiguration
    {
        public string Host { get; set; }
        public int Port { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}