namespace Gravitrips.Core.Players.AiStrategies
{
    public interface IAiStrategy
    {
        Position Turn(byte[,] field);
    }
}