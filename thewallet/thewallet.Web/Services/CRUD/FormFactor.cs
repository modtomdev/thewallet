using thewallet.Shared.Interfaces.CRUD;

namespace thewallet.Web.Services.CRUD;

public class FormFactor : IFormFactor
{
    public string GetFormFactor()
    {
        return "Web";
    }

    public string GetPlatform()
    {
        return Environment.OSVersion.ToString();
    }
}
