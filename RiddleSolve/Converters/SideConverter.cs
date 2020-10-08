using RiddleSolve.Model;

namespace RiddleSolve.Converters
{
    public static class SideConverter
    {
        public static Position ToRelativePosition(this ITile.TileSide side)
            => side switch
            {
                ITile.TileSide.Left   => (0, -1),
                ITile.TileSide.Top    => (-1, 0),
                ITile.TileSide.Right  => (0, 1),
                ITile.TileSide.Bottom => (1, 0),
                _                     => (0, 0)
            };
    }
}