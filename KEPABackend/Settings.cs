namespace KEPABackend;

/// <summary>
/// Configuration
/// </summary>
public class Settings
{
    /// <summary>
    /// Connectionstring
    /// </summary>
    public string ConString { get; set; } = default!;
    //public string AdminEmail { get; set; }
    //public string AdminPW { get; set; }

    /// <summary>
    /// JSON Web Token
    /// </summary>
    public JWTSettings JWT { get; set; } = default!;
}

/// <summary>
/// JSON Web Token
/// </summary>
public class JWTSettings
{
    /// <summary>
    /// 
    /// </summary>
    public string ValidAudience { get; set; } = default!;

    /// <summary>
    /// 
    /// </summary>
    public string ValidIssuer { get; set; } = default!;

    /// <summary>
    /// 
    /// </summary>
    public string Secret { get; set; } = default!;
}