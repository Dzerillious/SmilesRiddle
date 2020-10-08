using RiddleSolve.Model;

namespace RiddleSolve.Converters
{
    public static class SideConverter
    {
        public static Position ToRelativePosition(this ITile.Side side)
            => side switch
            {
                ITile.Side.Left   => (0, -1),
                ITile.Side.Top    => (-1, 0),
                ITile.Side.Right  => (0, 1),
                ITile.Side.Bottom => (1, 0),
                _                 => (0, 0)
            };
    }
}