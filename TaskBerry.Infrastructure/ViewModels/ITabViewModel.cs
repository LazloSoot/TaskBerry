namespace TaskBerry.Infrastructure.ViewModels
{
    public interface ITabViewModel : IViewModel
    {
        string TabName { get; }
        string Name { get; }
    }
}
