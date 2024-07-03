using ProjectForCurs.Model;

namespace ProjectForCurs.Services.Database;

internal interface IDbLoginService
{
    public Profile? GetProfileOrNull(string email);
}