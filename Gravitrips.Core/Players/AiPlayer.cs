using Gravitrips.Core.Players.AiStrategies;

namespace Gravitrips.Core.Players
{
    public class AiPlayer : Player
    {
        public AiPlayer(IAiStrategy strategy)
        {
            Strategy = strategy;
        }

        public IAiStrategy Strategy { get; }

        public Position Turn(byte[,] field)
        {
            return Strategy.Turn(field);
        }
    }
}