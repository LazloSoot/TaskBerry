using TaskBerry.Infrastructure.Contracts.View.Forms;
using TaskBerry.Infrastructure.ViewModels;

namespace TaskBerry.Infrastructure.Contracts.Services.UI
{
    public interface IFormViewBuilder
    {
        IFormView CreateView(IViewModel viewModel);
    }
}
