using System.Linq;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using GalaSoft.MvvmLight.Messaging;
using Gravitrips.Core;
using Gravitrips.UI.Message;
using Gravitrips.UI.ViewModels;

namespace Gravitrips.UI.Views
{
    public sealed partial class GamePage : Page
    {
        public readonly Color ButtonDefaultColor = Color.FromArgb(20, 0, 0, 0);

        public GamePage()
        {
            InitializeComponent();
            InitializeGameField();
            SubscribeToMessages();
        }

        private void SubscribeToMessages()
        {
            Messenger.Default.Register<ClearFieldMessage>(this, ClearField);
            Messenger.Default.Register<WinMessage>(this, ShowWinLine);
            Messenger.Default.Register<DrawTurnMessage>(this, DrawTurn);
        }

        private void InitializeGameField()
        {
            for (var row = 0; row < 6; row++)
            {
                for (var col = 0; col < 7; col++)
                {
                    var button = new Button
                    {
                        Height = 35,
                        Width = 35,
                        Template = (ControlTemplate) Resources["GameButton"],
                        BorderBrush = new SolidColorBrush(Colors.Black),
                        Background = new SolidColorBrush(ButtonDefaultColor)
                };
                    FieldGrid.Children.Add(button);
                    Grid.SetRow(button, row);
                    Grid.SetColumn(button, col);

                    var binding = new Binding
                    {
                        Source = DataContext,
                        Path = new PropertyPath("TurnCommand"),
                    };

                    button.SetBinding(Button.CommandProperty, binding);
                    button.CommandParameter = new Position
                    {
                        Column = col,
                        Row = row
                    };
                }
            }
        }       

        public void ClearField(ClearFieldMessage message)
        {
            var buttons = FieldGrid.Children.OfType<Button>().ToList();
            var fillBrush = new SolidColorBrush(ButtonDefaultColor);
            var borderBrush = new SolidColorBrush(Colors.Black);
            foreach (var button in buttons)
            {
                button.Background = fillBrush;
                button.BorderBrush = borderBrush;
            }
        }
        
        private void ShowWinLine(WinMessage message)
        {
            var buttons = FieldGrid.Children.Cast<Button>().ToList();
            var borderBrush = new SolidColorBrush(Colors.Blue);
            foreach (var position in message.WinLine)
            {
                var button = buttons.FirstOrDefault(b => Grid.GetRow(b) == position.Row && Grid.GetColumn(b) == position.Column);
                if (button == null)
                {
                    continue;
                }
                
                button.BorderBrush = borderBrush;
            }
        }

        private void DrawTurn(DrawTurnMessage message)
        {
            var button =
                FieldGrid.Children.Cast<Button>()
                    .FirstOrDefault(b => Grid.GetRow(b) == message.Row && Grid.GetColumn(b) == message.Column);
            if (button == null)
            {
                return;
            }

            var brush = new SolidColorBrush(message.Color);
            button.Background = brush;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            var navigableViewModel = DataContext as INavigable;
            navigableViewModel?.Activate(e.Parameter);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);

            var navigableViewModel = DataContext as INavigable;
            navigableViewModel?.Deactivate(e.Parameter);
        }
    }
}
