namespace KEPABackend.Interfaces.ControllerServices;

public interface ILoginService
{
    Task<bool> AreCredentialsCorrectAsync(string sUsername, string sPassword);
}
