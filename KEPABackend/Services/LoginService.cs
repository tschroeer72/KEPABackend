using KEPABackend.Interfaces.ControllerServices;
using KEPABackend.Interfaces.DBServices;

namespace KEPABackend.Services;

public class LoginService : ILoginService
{
    private IMitgliederDBService MitgliederDBService { get; }

    public LoginService(IMitgliederDBService mitgliederDBService)
    {
        MitgliederDBService = mitgliederDBService;
    }

    public async Task<bool> AreCredentialsCorrectAsync(string sUsername, string sPassword)
    {
        return await MitgliederDBService.AreCredentialsCorrectAsync(sUsername, sPassword);
    }
}
