public interface IOrderState
{
    void Process();
    void Cancel();
    void MarkAsDelivered();
    string GetStatus();
}