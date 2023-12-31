using Lab5.Application.Services.Contracts;
using Lab5.Application.Services.Contracts.UserRole;

namespace Lab5.Application.Services.UserRole;

public class AdminVerificationService : IUserRoleService
{
    private string _password;

    public AdminVerificationService(string password)
    {
        _password = password;
    }

    public OperationResult VerifyAdmin(string password)
    {
        if (password == _password)
            return new OperationResult.Success();
        return new OperationResult.Failure("wrong password");
    }
}