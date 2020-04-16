namespace Shop.Domain.Backoffice.Enums
{
    public enum EOrderStatus
    {
        WaitingPayment = 1,
        Paid = 2,
        InTransit = 3,
        Completed = 4,
        Canceled = 4
    }
}