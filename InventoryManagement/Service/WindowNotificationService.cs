using InventoryManagement.Core.Service;
using System.Drawing;
using System.Windows.Forms;

namespace InventoryManagement.Service
{
    public class WindowNotificationService : INotificationService
    {
        private readonly NotifyIcon _notifyIcon = new();
        private const int OneSecond = 1000;

        public WindowNotificationService()
        {
            InitializeNotifyIcon();
        }

        private void InitializeNotifyIcon()
        {
            _notifyIcon.Icon = SystemIcons.Information;
            _notifyIcon.Visible = true;
        }

        public void PushInfo(string title, string message)
        {
            ShowBalloonNotification(title, message, ToolTipIcon.Info);
        }

        public void PushWarning(string title, string message)
        {
            ShowBalloonNotification(title, message, ToolTipIcon.Warning);
        }

        public void PushError(string title, string message)
        {
            ShowBalloonNotification(title, message, ToolTipIcon.Error);
        }

        private void ShowBalloonNotification(string title, string message, ToolTipIcon toolTipIcon)
        {
            _notifyIcon.ShowBalloonTip(OneSecond, title, message, toolTipIcon);
        }
    }
}
