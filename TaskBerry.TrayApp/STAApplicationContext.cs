using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TaskBerry.Infrastructure.Contracts.Services;
using TaskBerry.Infrastructure.Contracts.View;
using TaskBerry.Infrastructure.Contracts.View.TrayApp;

namespace TaskBerry.TrayApp
{
    public class STAApplicationContext : ApplicationContext
    {
        private readonly IActionMenuView _actionMenuView;
        private readonly ILogger _logger;
        public STAApplicationContext(IActionMenuView actionMenuView, ILogger logger)
        {
            _actionMenuView = actionMenuView;
            _logger = logger;
        }
    }
}
