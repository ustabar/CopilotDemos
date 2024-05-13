public class Transaction
{
    public string Date { get; set; }
    public int Amount { get; set; }
    public string Description { get; set; }
}

public class Customer
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string AccountNumber { get; set; }
    public int Balance { get; set; }
    public List<Transaction> Transactions { get; set; }
}

public class CustomerData
{
    public Customer Customer { get; set; }
}

public CustomerData CreateSampleCustomerData()
{
    return new CustomerData
    {
        Customer = new Customer
        {
            FirstName = "John",
            LastName = "Doe",
            AccountNumber = "123456789",
            Balance = 5000,
            Transactions = new List<Transaction>
            {
                new Transaction { Date = "2022-01-01", Amount = -100, Description = "ATM Withdrawal" },
                new Transaction { Date = "2022-01-02", Amount = 2000, Description = "Deposit" },
                new Transaction { Date = "2022-01-03", Amount = -500, Description = "Bill Payment" },
                new Transaction { Date = "2022-01-04", Amount = 100, Description = "Transfer" },
                new Transaction { Date = "2022-01-05", Amount = -200, Description = "ATM Withdrawal" },
                new Transaction { Date = "2022-01-06", Amount = 500, Description = "Deposit" },
                new Transaction { Date = "2022-01-07", Amount = -100, Description = "Bill Payment" },
                new Transaction { Date = "2022-01-08", Amount = 200, Description = "Transfer" },
                new Transaction { Date = "2022-01-09", Amount = -300, Description = "ATM Withdrawal" },
                new Transaction { Date = "2022-01-10", Amount = 1000, Description = "Deposit" }
            }
        }
    };
}