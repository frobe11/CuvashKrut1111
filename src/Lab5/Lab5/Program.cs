using Lab5.Application.Services.BankAccount;
using Lab5.Application.Services.TransactionHistory;
using Lab5.Application.Services.UserRole;
using Lab5.Infrastructure.ConnectionProvider;
using Lab5.Infrastructure.DB;
using Lab5.Infrastructure.Repository;
using Lab5.Presentation.Console;
using Lab5.Presentation.Console.Scenarios;
using Lab5.Presentation.Console.Scenarios.AdminLogin;
using Lab5.Presentation.Console.Scenarios.CreateAccount;
using Lab5.Presentation.Console.Scenarios.DepositMoney;
using Lab5.Presentation.Console.Scenarios.Logout;
using Lab5.Presentation.Console.Scenarios.UserLogin;
using Lab5.Presentation.Console.Scenarios.ViewBalance;
using Lab5.Presentation.Console.Scenarios.ViewHistory;
using Lab5.Presentation.Console.Scenarios.WithdrawMoney;

var connection =
    new ConnectionProvider(
        "host=localhost; port=5432; database=postgres; username=postgres; password=123; sslmode=prefer;");
var db = new MyCoolDataBase(connection);
await db.SetUp();

var bankAccountRepository = new BankAccountRepository(connection);
var transactionHistoryRepository = new TransactionHistoryRepository(connection);

var currentUserService = new CurrentUserManager();
var currentAccountService = new CurrentBankAccountManager();
var userRoleService = new AdminVerificationService("admin");
var bankAccountVerificationService = new BankAccountVerificationService(bankAccountRepository);
var bankAccountService = new BankAccountService(bankAccountRepository);
var bankAccountMoneyOperationService =
    new BankAccountMoneyOperationServiceWithHistory(transactionHistoryRepository, new BankAccountMoneyOperationService(bankAccountService));
var transactionHistoryService = new TransactionHistoryService(transactionHistoryRepository);

var providers = new List<IScenarioProvider>();
providers.Add(new AdminLoginScenarioProvider(
    currentUserService,
    userRoleService,
    "Login as admin"));
providers.Add(new UserLoginScenarioProvider(
    bankAccountVerificationService,
    currentAccountService,
    currentUserService,
    "Login as user"));
providers.Add(new DepositMoneyScenarioProvider(
        bankAccountMoneyOperationService,
        currentAccountService,
        "Deposit money"));
providers.Add(new WithdrawMoneyScenarioProvider(
    bankAccountMoneyOperationService,
    currentAccountService,
    "Withdraw money"));
providers.Add(new ViewBalanceScenarioProvider(
    currentAccountService,
    "View balance"));
providers.Add(new ViewHistoryScenarioProvider(
    currentAccountService,
    transactionHistoryService,
    "View transaction history"));
providers.Add(new CreateAccountScenarioProvider(
    bankAccountService,
    "Create account",
    currentUserService));
providers.Add(new LogoutScenarioProvider(
    currentUserService,
    currentAccountService,
    "Logout"));

var runner = new ScenarioRunner(providers);
while (true)
{
    runner.Run();
}