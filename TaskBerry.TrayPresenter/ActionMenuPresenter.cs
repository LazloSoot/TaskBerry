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
    public class ActionMenuPresenter : IActionMenuPresenter
    {
        private readonly IScriptProvider _scriptProvider;
        private readonly IActionMenuView _actionMenuView;
        private readonly ILogger _logger;
        public ActionMenuPresenter(IScriptProvider scriptProvider, IActionMenuView actionMenu, ILogger logger)
        {
            _logger = logger;
            _scriptProvider = scriptProvider;
            _actionMenuView = actionMenu;

            
        }
    }
}
