using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskBerry.Infrastructure.Contracts.Presenter
{
    public interface IFormsPresenter
    {
        Bitmap AppIcon { get; set; }
        void ShowAbout();
        void ShowSettings();
    }
}
