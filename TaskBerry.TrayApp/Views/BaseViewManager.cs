using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskBerry.Infrastructure.Contracts.Services;
using TaskBerry.Infrastructure.Contracts.View;
using System.Windows;
using System.ComponentModel;
using System.Windows.Forms;
using System.Windows.Media;
using System.Windows.Interop;
using System.Windows.Media.Imaging;

namespace TaskBerry.TrayApp.Views
{
    public abstract class BaseViewManager : IViewManager
    {
        private readonly ILogger _logger;
        // This allows code to be run on a GUI thread
        private readonly Window _hiddenWindow;

        private readonly IContainer _components;
        // The Windows system tray class
        protected NotifyIcon _notifyIcon;

        protected readonly ToolStripMenuItem _aboutMenuItem;
        protected readonly ToolStripMenuItem _settingsMenuItem;
        protected readonly ToolStripMenuItem _clearLogsMenuItem;
        protected readonly ToolStripMenuItem _exitMenuItem;


        public ImageSource AppIcon
        {
            get
            {
                return Imaging.CreateBitmapSourceFromHIcon(
                        Properties.Resources.Main.Handle,
                        Int32Rect.Empty,
                        BitmapSizeOptions.FromEmptyOptions());
            }
        }

        public ImageSource SettingsIcon
        {
            get
            {
                return Imaging.CreateBitmapSourceFromHIcon(
                        Properties.Resources.Settings.Handle,
                        Int32Rect.Empty,
                        BitmapSizeOptions.FromEmptyOptions());
            }
        }

        protected bool IsMenuInitialized
        {
            get;
            private set;
        }

        protected ILogger Logger => _logger;
        public void OnStatusChange()
        {
            throw new NotImplementedException();
        }
    }
}
