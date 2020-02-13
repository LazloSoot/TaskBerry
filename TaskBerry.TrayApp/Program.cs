using System;
using System.Threading;
using System.Windows.Forms;
using TaskBerry.Infrastructure.Contracts.Services;
using TaskBerry.TrayApp.Views;

namespace TaskBerry.TrayApp
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Use the assembly GUID as the name of the mutex which we use to detect if an application instance is already running
            var createdNew = false;
            var mutexName = System.Reflection.Assembly.GetExecutingAssembly().GetType().GUID.ToString();

            using (var mutex = new Mutex(false, mutexName, out createdNew))
            {
                if(!createdNew)
                {
                    // only one instance allowed
                    return;
                }

#warning get instances from di
                IStateManager stateManager = null;
                ILogger logger = null;
                var actionMenuView = new ActionMenuView(stateManager, logger);

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                try
                {
                    logger.LogInfo("Init menu");
                    var context = new STAApplicationContext(actionMenuView, logger);
                    Application.Run(context);
                }
                catch (Exception e)
                {
                    logger.LogError("Program was stopped because of an exception", e);
                    MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    logger.Shutdown();
                }
            }
        }
    }
}
