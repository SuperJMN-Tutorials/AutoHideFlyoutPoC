using System.Reactive;
using ReactiveUI;

namespace AvaloniaApplication2;

public class MainViewModel : ReactiveObject
{
    public MainViewModel()
    {
        MyCommand = ReactiveCommand.Create(() => { });
    }

    public ReactiveCommand<Unit, Unit> MyCommand { get; set; }
}