using System;
using Gravitrips.Core.GameFields;
using Gravitrips.Core.Players;

namespace Gravitrips.Core
{
    public class Game
    {
        public GameFieldBase GameField { get; }

        public bool Finished { get; private set; }

        public Player[] Players { get; }

        public event EventHandler<TurnEventArgs> OnTurn;

        public Game(GameFieldBase gameField, Player[] players)
        {
            GameField = gameField;
            GameField.Initialize();
            Players = players;
            WhoseTurn = Players[0];
        }

        public Player WhoseTurn { get; set; }

        public void StartNewGame()
        {
            GameField.Clear();
            WhoseTurn = Players[0];
            Finished = false;
        }

        public bool MakeTurn(int col, int row)
        {
            if (!GameField.IsTurnPossible(col, row) || Finished)
            {
                return false;
            }

            MakeTurnInner(new Position(col, row), WhoseTurn);
            Finished = GameField.CheckGameFinished();
            if (Finished)
            {
                return true;
            }

            SetWhoseTurn();
            if (!(WhoseTurn is AiPlayer))
            {
                return true;
            }
            return MakeAiTurn();
        }

        private bool MakeAiTurn()
        {
            var position = ((AiPlayer) WhoseTurn).Turn(GameField.Field);
            MakeTurnInner(position, WhoseTurn);

            Finished = GameField.CheckGameFinished();
            if (!Finished)
            {
                SetWhoseTurn();
            }
            return true;
        }

        private void MakeTurnInner(Position position, Player player)
        {
            GameField.Turn(position.Column, position.Row, WhoseTurn.Id);
            OnTurn?.Invoke(this, new TurnEventArgs
            {
                Column = position.Column,
                Row = position.Row,
                Player = player
            });
        }

        private void SetWhoseTurn()
        {
            WhoseTurn = WhoseTurn == Players[0]
                ? Players[1]
                : Players[0];
        }
    }
}
