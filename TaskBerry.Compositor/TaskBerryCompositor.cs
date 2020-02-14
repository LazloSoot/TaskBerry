using LightInject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TaskBerry.Infrastructure.Contracts.Services;
using TaskBerry.Infrastructure.Contracts.View.TrayApp;
using TaskBerry.Logger;
using TaskBerry.TrayApp;
using TaskBerry.TrayApp.Views;

namespace TaskBerry.Compositor
{
    public class TaskBerryCompositor: IDisposable
    {
        private readonly ServiceContainer _container;
        public TaskBerryCompositor()
        {
            _container = new ServiceContainer();
            RegisterModels();
            RegisterServices();
            RegisterViewModels();
            RegisterViews();
            RegisterPresenters();
            

            _container.Register<ApplicationContext, STAApplicationContext>(new PerContainerLifetime());
            //_container.Register<IActionMenuView, ApplicationContext>((factory, actionMenuView) => new STAApplicationContext(actionMenuView, factory.GetInstance<ILogger>()));

        }

        public void Register<TService, TImplementation>() where TImplementation : TService
        {
            _container.Register<TService, TImplementation>();
        }

        public T GetService<T>()
        {
            return _container.GetInstance<T>();
        }

        public T GetService<T>(params object[] args)
        {
            return (T)_container.GetInstance(typeof(T), args);
        }

        public void Dispose()
        {
            _container.Dispose();
        }

        private void RegisterServices()
        {
            _container.Register<ILogger, NLogAdapter>(new PerContainerLifetime());
            //_container.Register<string, ILogger>((factory, arg) => new NLogAdapter(arg));
        }

        private void RegisterPresenters()
        {

        }

        private void RegisterViews()
        {
            _container.Register<IActionMenuView, ActionMenuView>(new PerRequestLifeTime());
            //_container.Register<IStateManager, IActionMenuView>((factory, stateManager) => new ActionMenuView(stateManager, factory.GetInstance<ILogger>()));
        }

        private void RegisterViewModels()
        {

        }

        private void RegisterModels()
        {

        }
    }
}
