using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskBerry.Infrastructure.Contracts.Command;
using TaskBerry.Infrastructure.Contracts.Presenter;
using TaskBerry.Infrastructure.Contracts.Services;
using TaskBerry.Infrastructure.Contracts.View.TrayApp;

namespace TaskBerry.TrayPresenter
{
    public class BaseMenuPresenter : IBaseMenuPresenter
    {
        private readonly IScriptProvider _scriptProvider;
        private readonly IBaseView _baseView;
        private readonly ILogger _logger;
        public BaseMenuPresenter(IScriptProvider scriptProvider, IBaseView view, ILogger logger)
        {
            _logger = logger;
            _scriptProvider = scriptProvider;
            _baseView = view;

            _baseView.OnSettingsClicked += _baseView_OnSettingsClicked;
            _baseView.OnNotificationClicked += _baseView_OnNotificationClicked;
            _baseView.OnExitClicked += _baseView_OnExitClicked;
            _baseView.OnClearLogsClicked += _baseView_OnClearLogsClicked;
            _baseView.OnAboutClicked += _baseView_OnAboutClicked;
        }

        private void _baseView_OnAboutClicked(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void _baseView_OnClearLogsClicked(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void _baseView_OnExitClicked(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void _baseView_OnNotificationClicked(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void _baseView_OnSettingsClicked(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
