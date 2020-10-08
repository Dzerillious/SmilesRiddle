using System;
using static RiddleSolve.Model.ITile;

namespace RiddleSolve.Model
{
    public class Tile : ITile
    {
        public TileRotation Rotation => TileRotation.None;
        public Position FromPosition { get; }

        public FacePart Left { get; }
        public FacePart Top { get; }
        public FacePart Right { get; }
        public FacePart Bottom { get; }

        public Tile(Position fromPosition, FacePart left, FacePart top, FacePart right, FacePart bottom)
        {
            FromPosition = fromPosition;
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
                _                 => throw new ArgumentException("Invalid side of tile")
            };

        public RotatedTile GetRotated(TileRotation addedRotation)
            => new RotatedTile(this, addedRotation);

        public override string ToString() => $"l:{Left} t:{Top} r:{Right} b:{Bottom}";
    }
}