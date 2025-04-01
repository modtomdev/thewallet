namespace thewallet.Web.Helpers;

public static class PasswordHasher
{
    public static (string salt, string passwordHash) HashPassword(string password)
    {
        string salt = BCrypt.Net.BCrypt.GenerateSalt(workFactor: 12);

        string passwordHash = BCrypt.Net.BCrypt.HashPassword(password, salt);

        return (salt, passwordHash);
    }
}
