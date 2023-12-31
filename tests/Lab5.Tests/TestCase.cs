using Lab5.Application.Models;
using Lab5.Application.Repository;
using Lab5.Application.Services.BankAccount;
using Lab5.Application.Services.Contracts;
using NSubstitute;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab5.Tests;

public class TestCase
{
    // TestedMethodName_ExpectedResult_TestCondition
    [Fact]
    public void Widthraw_Success_CorrectAmount()
    {
        var manager = new CurrentBankAccountManager();
        var account = new BankAccount(1, "nip", 100);
        manager.Account = account;
        IBankAccountRepository bankAccountRepository = Substitute.For<IBankAccountRepository>();
        var moneyOperationService = new BankAccountMoneyOperationService(new BankAccountService(bankAccountRepository));
        Assert.True(moneyOperationService.Withdraw(50, manager) is OperationResult.Success);
        Assert.Equal(50, account.Balance);
    }

    [Fact]
    public void Widthraw_Failure_IncorrectAmount()
    {
        var manager = new CurrentBankAccountManager();
        var account = new BankAccount(1, "nip", 100);
        manager.Account = account;
        IBankAccountRepository bankAccountRepository = Substitute.For<IBankAccountRepository>();
        var moneyOperationService = new BankAccountMoneyOperationService(new BankAccountService(bankAccountRepository));
        Assert.True(moneyOperationService.Withdraw(500, manager) is OperationResult.Failure);
        Assert.Equal(100, account.Balance);
    }

    [Fact]
    public void Deposit_Success_SomeAmount()
    {
        var manager = new CurrentBankAccountManager();
        var account = new BankAccount(1, "nip", 100);
        manager.Account = account;
        IBankAccountRepository bankAccountRepository = Substitute.For<IBankAccountRepository>();
        var moneyOperationService = new BankAccountMoneyOperationService(new BankAccountService(bankAccountRepository));
        Assert.True(moneyOperationService.Deposit(500, manager) is OperationResult.Success);
        Assert.Equal(600, account.Balance);
    }
}