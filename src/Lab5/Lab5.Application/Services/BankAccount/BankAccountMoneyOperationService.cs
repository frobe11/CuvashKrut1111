using Lab5.Application.Services.Contracts;
using Lab5.Application.Services.Contracts.BankAccount;

namespace Lab5.Application.Services.BankAccount;

public class BankAccountMoneyOperationService : IBankAccountMoneyOperationService
{
    private readonly IUpdateBankAccountService _updateBankAccountService;

    public BankAccountMoneyOperationService(IUpdateBankAccountService updateBankAccountService)
    {
        _updateBankAccountService = updateBankAccountService;
    }

    public OperationResult Withdraw(double amount, ICurrentBankAccountService currentBankAccountService)
    {
        if (currentBankAccountService.Account == null)
            return new OperationResult.Failure("no current bank account");
        if (currentBankAccountService.Account.Balance < amount)
            return new OperationResult.Failure("not enough money");
        currentBankAccountService.Account.Balance -= amount;
        _updateBankAccountService.Update(currentBankAccountService.Account);
        return new OperationResult.Success();
    }

    public OperationResult Deposit(double amount, ICurrentBankAccountService currentBankAccountService)
    {
        if (currentBankAccountService.Account == null)
            return new OperationResult.Failure("no current bank account");
        currentBankAccountService.Account.Balance += amount;
        _updateBankAccountService.Update(currentBankAccountService.Account);
        return new OperationResult.Success();
    }
}