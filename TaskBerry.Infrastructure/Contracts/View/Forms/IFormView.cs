using System.ComponentModel;
using System.Drawing;
using TaskBerry.Infrastructure.Models.TaskBerry;

namespace TaskBerry.Infrastructure.Contracts.View.Forms
{
    public interface IFormView
    {
        Bitmap Icon { get; set; }
        event CancelEventHandler Closing;
        object DataContext { get; set; }
        WindowStartupLocation WindowStartupLocation { get; set; }
        bool Activate();
        void Close();
        void Hide();
        void Show();
    }
}
