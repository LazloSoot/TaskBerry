using System;
using System.Windows.Forms;
using TaskBerry.Infrastructure.Contracts.Command;
using TaskBerry.Infrastructure.Contracts.Presenter;
using TaskBerry.Infrastructure.Contracts.Services;
using TaskBerry.Infrastructure.Contracts.View.TrayApp;

namespace TaskBerry.Core.Presenters
{
    public class MainPresenter
    {
        private readonly IScriptProvider _scriptProvider;
        private readonly IActionMenuView _actionMenuView;
        private readonly ILogger _logger;

        private readonly IFormsPresenter _formsPresenter;
        public MainPresenter(IFormsPresenter formsPresenter, IScriptProvider scriptProvider, IActionMenuView actionMenu, ILogger logger)
        {
            _formsPresenter = formsPresenter;
            _logger = logger;
            _scriptProvider = scriptProvider;
            _actionMenuView = actionMenu;

            _actionMenuView.OnSettingsClicked += (object sender, EventArgs args) => _formsPresenter.ShowSettings();
            _actionMenuView.OnAboutClicked += (object sender, EventArgs args) => _formsPresenter.ShowAbout();
            _actionMenuView.OnNotificationClicked += (object sender, EventArgs args) => { throw new NotImplementedException(); };
            _actionMenuView.OnExitClicked += _actionMenuView_OnExitClicked;
            _actionMenuView.OnClearLogsClicked += _actionMenuView_OnClearLogsClicked;
        }

        private void _actionMenuView_OnClearLogsClicked(object sender, EventArgs e)
        {
            _logger.ClearLogs();
        }

        private void _actionMenuView_OnExitClicked(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
