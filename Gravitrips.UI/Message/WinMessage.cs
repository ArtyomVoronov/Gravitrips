using System.Collections.Generic;
using GalaSoft.MvvmLight.Messaging;
using Gravitrips.Core;

namespace Gravitrips.UI.Message
{
    public class WinMessage : MessageBase
    {
        public List<Position> WinLine { get; set; } 
    }
}