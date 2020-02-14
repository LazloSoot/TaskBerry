using System;
using System.Windows;
using System.ComponentModel;
using System.Windows.Forms;
using System.Windows.Media;
using System.Windows.Interop;
using System.Windows.Media.Imaging;
using TaskBerry.Infrastructure.Models.TaskBerry;
using TaskBerry.Infrastructure.Contracts.Services;
using TaskBerry.Infrastructure.Contracts.View.TrayApp;
using System.Reflection;

namespace TaskBerry.TrayApp.Views
{
    public abstract class BaseView : IBaseView
    {
        private readonly ILogger _logger;
        private readonly IStateManager _stateManager;
        // This allows code to be run on a GUI thread
        private readonly Window _hiddenWindow;

        private readonly IContainer _components;
        // The Windows system tray class
        protected NotifyIcon _notifyIcon;

        private readonly ToolStripMenuItem _aboutMenuItem;
        private readonly ToolStripMenuItem _settingsMenuItem;
        private readonly ToolStripMenuItem _clearLogsMenuItem;
        private readonly ToolStripMenuItem _exitMenuItem;

        public event EventHandler OnExitClicked;
        public event EventHandler OnAboutClicked;
        public event EventHandler OnSettingsClicked;
        public event EventHandler OnClearLogsClicked;
        public event EventHandler OnNotificationClicked;

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

        protected bool IsMenuInitialized { get; private set; }

        protected ILogger Logger => _logger;
        protected IStateManager StateManager => _stateManager;

        public BaseView(IStateManager stateManager, ILogger logger)
        {
            _stateManager = stateManager;
            _logger = logger;
            _components = new Container();

            _exitMenuItem = ToolStripMenuItemHandler("&Exit", "Closes TaskBerry application", OnExitClicked);
            _settingsMenuItem = ToolStripMenuItemHandler("&Settings", "Shows the settings dialog", OnSettingsClicked);
            _aboutMenuItem = ToolStripMenuItemHandler("&About", "Shows the About dialog", OnAboutClicked);
            _clearLogsMenuItem = ToolStripMenuItemHandler("&Clear logs", "Removes all logs", OnClearLogsClicked);

            _notifyIcon = new NotifyIcon(_components)
            {
                ContextMenuStrip = new ContextMenuStrip(),
                Visible = true
            };

            _notifyIcon.ContextMenuStrip.Opening += ContextMenuStrip_Opening;
            _notifyIcon.DoubleClick += _notifyIcon_DoubleClick;
            _notifyIcon.MouseUp += _notifyIcon_MouseUp;

            _notifyIcon.ContextMenuStrip.Items.Add(new ToolStripSeparator());
            _notifyIcon.ContextMenuStrip.Items.Add(_clearLogsMenuItem);
            _notifyIcon.ContextMenuStrip.Items.Add(_settingsMenuItem);
            _notifyIcon.ContextMenuStrip.Items.Add(_aboutMenuItem);
            _notifyIcon.ContextMenuStrip.Items.Add(_exitMenuItem);

            _hiddenWindow = new Window();
            _hiddenWindow.Hide();

            OnStatusChange();
            _stateManager.OnStateChanged += ((object sender, EventArgs args) => OnStatusChange());
        }

        private void _notifyIcon_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                var methodInfo = typeof(NotifyIcon).GetMethod("ShowContextMenu", BindingFlags.Instance | BindingFlags.NonPublic);
                methodInfo.Invoke(_notifyIcon, new object[0]);
            }
        }

        private void _notifyIcon_DoubleClick(object sender, EventArgs e)
        {
            lock(this)
            {
                if (OnNotificationClicked != null)
                    OnNotificationClicked.Invoke(this, null);
            }
        }

        private void ContextMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            e.Cancel = false;
            SetMenuItems();
        }

        public void OnStatusChange()
        {
            _notifyIcon.Text = $"{_stateManager.SubjectName}:{_stateManager.ActionName}";

            switch (_stateManager.CurrentStatus)
            {
                case AppStatus.Uninitialised:
                    _notifyIcon.Icon = Properties.Resources.DefaultIcon;
                    break;
                case AppStatus.Initialised:
                    _notifyIcon.Icon = Properties.Resources.Main;
                    break;
                case AppStatus.Starting:
                    _notifyIcon.Icon = Properties.Resources.Running;
                    break;
                case AppStatus.Running:
                    _notifyIcon.Icon = Properties.Resources.Running;
                    break;
                case AppStatus.Error:
                    _notifyIcon.Icon = Properties.Resources.Alert;
                    break;
                default:
                    _logger.LogDebug($"'{_stateManager.CurrentStatus}' is unknown state for {nameof(OnStatusChange)}");
                    _notifyIcon.Icon = Properties.Resources.DefaultIcon;
                    break;
            }
            DisplayStatusMessage(_stateManager.Description);
            SetMenuItems();
        }

        protected virtual void SetMenuItems()
        {
            switch (_stateManager.CurrentStatus)
            {
                case AppStatus.Initialised:
                case AppStatus.Starting:
                case AppStatus.Running:
                    _clearLogsMenuItem.Enabled = false;
                    _aboutMenuItem.Enabled = false;
                    _settingsMenuItem.Enabled = false;
                    break;
                default:
                    _logger.LogDebug($"'{_stateManager.CurrentStatus}' is unknown state for {nameof(SetMenuItems)}");
                    _clearLogsMenuItem.Enabled = true;
                    _aboutMenuItem.Enabled = true;
                    _settingsMenuItem.Enabled = true;
                    break;
            }
        }

        protected ToolStripMenuItem ToolStripMenuItemHandler(string displayText, string toolTipText, EventHandler eventHandler)
        {
            var item = new ToolStripMenuItem(displayText);
            lock(this)
            {
                if (eventHandler != null)
                {
                    item.Click += eventHandler;
                }
            }

            item.ToolTipText = toolTipText;
            return item;
        }

        private void DisplayStatusMessage(string message)
        {
            _hiddenWindow.Dispatcher.Invoke(delegate
            {
                _notifyIcon.BalloonTipText = message;
                // The timeout is ignored on recent Windows
                _notifyIcon.ShowBalloonTip(3000);
            });
        }
    }
}
