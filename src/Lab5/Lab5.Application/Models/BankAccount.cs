namespace Lab5.Application.Models;

public record BankAccount(int Id, string Pin, double Balance)
{
    public double Balance { get; set; } = Balance;
}