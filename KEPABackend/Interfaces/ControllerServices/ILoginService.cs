namespace KEPABackend.Interfaces.ControllerServices;

/// <summary>
/// Interface für LoginService
/// </summary>
public interface ILoginService
{
    /// <summary>
    /// Überprüfung, ob die Credentails korrekt sind
    /// </summary>
    /// <param name="sUsername"></param>
    /// <param name="sPassword"></param>
    /// <returns></returns>
    Task<bool> AreCredentialsCorrectAsync(string sUsername, string sPassword);
}
