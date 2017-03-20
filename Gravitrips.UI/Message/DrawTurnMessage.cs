using Windows.UI;
using GalaSoft.MvvmLight.Messaging;

namespace Gravitrips.UI.Message
{
    public class DrawTurnMessage : MessageBase
    {
        public int Column { get; set; }

        public int Row { get; set; }

        public Color Color { get; set; }
    }
}