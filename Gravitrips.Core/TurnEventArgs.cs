using System;
using Gravitrips.Core.Players;

namespace Gravitrips.Core
{
    public class TurnEventArgs : EventArgs
    {
        public int Row { get; set; }

        public int Column { get; set; }

        public Player Player { get; set; }
    }
}