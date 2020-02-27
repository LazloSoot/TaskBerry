using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskBerry.Infrastructure.Contracts.Presenter;
using TaskBerry.Infrastructure.Contracts.Services.UI;
using TaskBerry.Infrastructure.Contracts.View.Forms;
using TaskBerry.Infrastructure.ViewModels;

namespace TaskBerry.FormsPresenter
{
    public class FormsPresenter : IFormsPresenter
    {
        private IFormView _aboutView;
        private readonly IFormViewBuilder _viewBuilder;
        private readonly IViewModel _aboutViewModel;
        public Bitmap AppIcon { get; set; }

        public FormsPresenter(IFormViewBuilder viewBuilder, IViewModel aboutViewModel)
        {
            _viewBuilder = viewBuilder;
            _aboutViewModel = aboutViewModel;
        }


        public void ShowAbout()
        {
            if(_aboutView == null)
            {
                _aboutView = _viewBuilder.CreateView(_aboutViewModel);
                _aboutView.Closing += ((arg, arg2) => _aboutView = null);
                _aboutView.Show();
            } else
            {
                _aboutView.Activate();
            }

            _aboutView.Icon = AppIcon;
        }

        public void ShowSettings()
        {
            throw new NotImplementedException();
        }
    }
}
