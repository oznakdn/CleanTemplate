namespace Clean.Domain.Orders;

public enum OrderStatus
{
    PaymentReveived,
    PaymentFailed,
    InProgress,
    Completed,
    Canceled
}
