using System;
using System.Linq;
using System.Reactive.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.VisualTree;
using ReactiveUI;

namespace AvaloniaApplication2;

public class AutoHideFlyout : Flyout
{
    private IDisposable? disposable;
    private Control? presenter;

    protected override Control CreatePresenter()
    {
        presenter = base.CreatePresenter();
        presenter.AttachedToVisualTree += OnAttached;
        presenter.DetachedFromVisualTree += OnDetached;
        return presenter;
    }

    private static IObservable<Button> DescendantButtonClicked(Visual control)
    {
        var buttons = control.GetVisualDescendants().OfType<Button>();
        return buttons
            .Select(button => Observable.FromEventPattern<RoutedEventArgs>(h => button.Click += h, h => button.Click -= h)
                .Select(pattern => pattern.Sender as Button).WhereNotNull()).Merge();
    }

    private void OnDetached(object? sender, VisualTreeAttachmentEventArgs e)
    {
        disposable?.Dispose();
    }

    private void OnAttached(object? sender, VisualTreeAttachmentEventArgs e)
    {
        if (presenter != null)
        {
            disposable = DescendantButtonClicked(presenter)
                .Do(clicked =>
                {
                    clicked.Command?.Execute(clicked.CommandParameter);
                    Hide();
                })
                .Subscribe();
        }
    }
}