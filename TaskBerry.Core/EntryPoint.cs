using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using TaskBerry.Compositor;
using TaskBerry.Core.Services;
using TaskBerry.Infrastructure.Contracts.Services;

namespace TaskBerry.Core
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
                if (!createdNew)
                {
                    // only one instance allowed
                    return;
                }

                var diContainer = new TaskBerryCompositor();
                var logger = diContainer.GetService<ILogger>();
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                try
                {
                    diContainer.Register<IStateManager, StateService>();
                    var context = diContainer.GetService<ApplicationContext>();
                    logger.LogInfo("Init menu");
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
