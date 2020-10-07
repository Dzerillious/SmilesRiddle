using System;

namespace RiddleSolve.Model
{
    public class Tile : ITile
    {
        public ITile.TileRotation Rotation => ITile.TileRotation.Up;
        public Position TileFromPosition { get; }

        public FacePart Left { get; }
        public FacePart Top { get; }
        public FacePart Right { get; }
        public FacePart Bottom { get; }

        public Tile(Position tilePosition, FacePart left, FacePart top, FacePart right, FacePart bottom)
        {
            TileFromPosition = tilePosition;
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

        public RotatedTile GetRotated(ITile.TileRotation rotation)
            => new RotatedTile(this, rotation);

        public override string ToString() => $"l:{Left} t:{Top} r:{Right} b:{Bottom}";
    }
}