using System;
using System.Linq;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Views;
using Gravitrips.Core;
using Gravitrips.Core.GameFields;
using Gravitrips.Core.Players;
using Gravitrips.Core.Players.AiStrategies;
using Gravitrips.UI.Message;
using Gravitrips.UI.Models;

namespace Gravitrips.UI.ViewModels
{
    public class GameViewModel : ViewModelBase, INavigable
    {
        private Game _game;
        public RelayCommand<Position> TurnCommand { get; }
        public RelayCommand NewGameCommand { get; }
        public RelayCommand ToMenuCommand { get; }

        public Player WhoseTurn => _game?.WhoseTurn;

        public bool Finished => _game?.Finished ?? false;

        public GameViewModel(INavigationService navigationService)
        {
            TurnCommand = new RelayCommand<Position>(MakeTurn);
            NewGameCommand = new RelayCommand(StartNewGame);
            ToMenuCommand = new RelayCommand(navigationService.GoBack);
        }
        
        private void MakeTurn(Position position)
        {
            if (!_game.MakeTurn(position.Column, position.Row))
            {
              return;  
            }

            RaisePropertyChanged(() => WhoseTurn);
            RaisePropertyChanged(() => Finished);
            if (Finished)
            {
                var winLine = _game.GameField.WinLine.Select(cell => new Position
                {
                    Row = cell.Row, Column = cell.Column
                }).ToList();
                Messenger.Default.Send(new WinMessage
                {
                    WinLine = winLine
                });
            } 
        }

        private void StartNewGame()
        {
            _game.StartNewGame();
            RaisePropertyChanged(() => WhoseTurn);
            RaisePropertyChanged(() => Finished);
            Messenger.Default.Send(new ClearFieldMessage());
        }

        public void Activate(object parameter)
        {
            var startData = (StartData) parameter;

            var player1 = new Player { Id = 1, Color = startData.Player1Color };
            Player player2;
            switch (startData.GameType)
            {
                case GameType.Single:
                    var aiStrategy = new RandomAiStrategy();
                    player2 = new AiPlayer(aiStrategy)
                    {
                        Id = 2,
                        Color = startData.Player2Color
                    };
                    break;
                case GameType.TwoPlayers:
                    player2 = new Player { Id = 2, Color = startData.Player2Color };
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
                         
            var players = new[] {player1, player2};
            _game = new Game(new ClassicGameField(), players);
            _game.OnTurn += OnTurn;
        }

        public void Deactivate(object parameter)
        {
            _game.OnTurn -= OnTurn;
        }

        private void OnTurn(object sender, TurnEventArgs e)
        {
            Messenger.Default.Send(new DrawTurnMessage
            {
                Column = e.Column,
                Row = e.Row,
                Color = e.Player.Color
            });
        }
    }
}
