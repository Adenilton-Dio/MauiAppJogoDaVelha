using CommunityToolkit.Mvvm.Input;
using MauiAppJogoDaVelha.Models;

namespace MauiAppJogoDaVelha.PageModels
{
    public interface IProjectTaskPageModel
    {
        IAsyncRelayCommand<ProjectTask> NavigateToTaskCommand { get; }
        bool IsBusy { get; }
    }
}