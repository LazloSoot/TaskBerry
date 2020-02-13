using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskBerry.Infrastructure.Contracts.Services;
using TaskBerry.Infrastructure.Contracts.View.TrayApp;

namespace TaskBerry.TrayApp.Views
{
    public sealed class ActionMenuView : BaseView, IActionMenuView
    {
        public ActionMenuView(IStateManager stateManager, ILogger logger)
            :base(stateManager, logger)
        {

        }
    }
}
