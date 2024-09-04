using KEPABackend.Interfaces.ControllerServices;
using KEPABackend.Interfaces.DBServices;

namespace KEPABackend.Services;

/// <summary>
/// LoginService
/// </summary>
public class LoginService : ILoginService
{
    private IMitgliederDBService MitgliederDBService { get; }

    /// <summary>
    /// Contructor
    /// </summary>
    /// <param name="mitgliederDBService"></param>
    public LoginService(IMitgliederDBService mitgliederDBService)
    {
        MitgliederDBService = mitgliederDBService;
    }

    /// <summary>
    /// Überprüfung, ob die Credentails korrekt sind
    /// </summary>
    /// <param name="sUsername"></param>
    /// <param name="sPassword"></param>
    /// <returns></returns>
    public async Task<bool> AreCredentialsCorrectAsync(string sUsername, string sPassword)
    {
        return await MitgliederDBService.AreCredentialsCorrectAsync(sUsername, sPassword);
    }
}
