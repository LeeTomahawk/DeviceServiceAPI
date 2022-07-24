namespace WebAPI.Installer
{
    public class SettingsOptionsClass
    {
        public string JwtKey { get; set; }
        public int JwtExpireDays { get; set; }
        public string JwtIssuer { get; set; }
    }
    public class DbContextOptions
    {
        public string DbConnection { get; set; }
    }
}
