namespace KEPABackend;

public class Settings
{
    public string ConString { get; set; }
    public string AdminEmail { get; set; }
    public string AdminPW { get; set; }
    public JWTSettings JWT { get; set; }
}

public class JWTSettings
{
    public string ValidAudience { get; set; }
    public string ValidIssuer { get; set; }
    public string Secret { get; set; }
}