using System;

namespace TaskBerry.Infrastructure.Contracts.View.TrayApp
{
    public interface IActionMenuView
    {
        event EventHandler OnExitClicked;
        event EventHandler OnAboutClicked;
        event EventHandler OnSettingsClicked;
        event EventHandler OnClearLogsClicked;
        event EventHandler OnNotificationClicked;
        void OnStatusChange();
    }
}
