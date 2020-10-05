namespace RiddleSolve.Model
{
    public enum Side { Left, Top, Right, Bottom }

    public static class SideHelper
    {
        public static Position ToRelativePosition(this Side side)
            => side switch
            {
                Side.Left   => (0, -1),
                Side.Top    => (-1, 0),
                Side.Right  => (0, 1),
                Side.Bottom => (1, 0),
                _           => (0, 0)
            };
    }
}