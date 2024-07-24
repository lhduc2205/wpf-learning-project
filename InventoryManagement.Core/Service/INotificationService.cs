namespace InventoryManagement.Core.Service
{
    public interface INotificationService
    {
        void PushInfo(string title, string message);
        void PushWarning(string title, string message);
        void PushError(string title, string message);
    }
}
