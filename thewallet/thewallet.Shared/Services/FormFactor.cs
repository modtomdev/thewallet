using thewallet.Shared.Interfaces.CRUD;

namespace thewallet.Web.Client.Services.DomainServices;

public class FormFactor : IFormFactor
{
    public string GetFormFactor()
    {
        return "WebAssembly";
    }

    public string GetPlatform()
    {
        return Environment.OSVersion.ToString();
    }
}
