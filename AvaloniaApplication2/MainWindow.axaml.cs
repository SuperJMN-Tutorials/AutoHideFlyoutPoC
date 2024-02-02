using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Input;
using Avalonia.Interactivity;

namespace AvaloniaApplication2
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_OnClick(object? sender, RoutedEventArgs e)
        {
            
        }
    }

    public class MyToggleButton : ToggleButton
    {
        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (IsFocused)
            {
                base.OnKeyDown(e);
            }

            
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            if (IsFocused)
            {
                base.OnKeyUp(e);
            }
        }
    }
}