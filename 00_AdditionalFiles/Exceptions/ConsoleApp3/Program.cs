

//Implement a custom exception class called InvalidTransactionException according to the following requirements:

//It should have a public get -only TransactionData property of the TransactionData type

//It should have three basic constructors that any exception should have

//It should have two extra constructors - one setting the message and the TransactionData and one setting
//the message, TransactionData and InnerException (please keep the paramthe gieters of the constructors in ven order)

throw new InvalidTransactionException();

public class TransactionData
{
    public string Sender { get; init; }
    public string Receiver { get; init; }
    public decimal Amount { get; init; }
}

class InvalidTransactionException : Exception
{
    public InvalidTransactionException() { }
    public InvalidTransactionException(string message) : base(message) { }
    public InvalidTransactionException(string message, Exception innerEx) : base(message, innerEx) { }
    public InvalidTransactionException(string message, TransactionData transactionData) : base (message)
    {
        this.TransactionData = transactionData;
    }
    

    public TransactionData TransactionData { get; }
}