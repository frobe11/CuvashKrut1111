namespace Lab5.Application.Services.Contracts.UserRole;

public interface IUserRoleService
{
    OperationResult VerifyAdmin(string password);
}