using System;

namespace RiddleSolve.Model
{
    public class Tile
    {
        public int Row { get; }
        public int Column { get; }
        
        public FacePart Left { get; }
        public FacePart Top { get; }
        public FacePart Right { get; }
        public FacePart Bottom { get; }

        public Tile(int row, int column, FacePart left, FacePart top, FacePart right, FacePart bottom)
        {
            Row = row;
            Column = column;
            
            Left = left;
            Top = top;
            Right = right;
            Bottom = bottom;
        }

        public FacePart GetFacePart(Side side)
            => side switch
            {
                Side.Left   => Left,
                Side.Top    => Top,
                Side.Right  => Right,
                Side.Bottom => Bottom,
                _           => throw new ArgumentException("Invalid side of tile")
            };

        public override string ToString() => $"l:{Left} t:{Top} r:{Right} b:{Bottom}";
    }
}