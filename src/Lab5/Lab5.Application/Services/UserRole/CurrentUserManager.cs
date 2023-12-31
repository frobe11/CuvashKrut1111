using Lab5.Application.Services.Contracts.UserRole;

namespace Lab5.Application.Services.UserRole;

public class CurrentUserManager : ICurrentUserService
{
    public Models.UserRole User { get; set; }
}