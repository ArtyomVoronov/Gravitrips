using Windows.UI;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using Gravitrips.UI.Models;

namespace Gravitrips.UI.ViewModels
{
    public class StartViewModel : ViewModelBase, INavigable
    {
        private readonly INavigationService _navigationService;
        private Color _player1Color;
        private Color _player2Color;

        public StartViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            StartCommand = new RelayCommand<GameType>(ExecuteStartCommand);
            Player1Color = Colors.Red;
            Player2Color = Colors.Black;
        }

        public RelayCommand<GameType> StartCommand
        {
            get;
        }

        private void ExecuteStartCommand(GameType gameType)
        {
            var startData = new StartData
            {
                GameType = gameType,
                Player1Color = _player1Color,
                Player2Color = _player2Color
            };

            _navigationService.NavigateTo(ViewModelLocator.GamePageKey, startData);
        }

        public void Activate(object parameter)
        {
        }

        public void Deactivate(object parameter)
        {
        }

        public Color Player1Color
        {
            get { return _player1Color; }
            set
            {
                _player1Color = value;
                RaisePropertyChanged(() => Player1Color);
            }
        }

        public Color Player2Color
        {
            get { return _player2Color; }
            set
            {
                _player2Color = value;
                RaisePropertyChanged(() => Player2Color);
            }
        }
    }
}
