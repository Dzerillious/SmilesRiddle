using System;

namespace RiddleSolve.Model
{
    public class RotatedTile : ITile, IEquatable<RotatedTile>
    {
        private readonly ITile _innerTile;
        
        public Position TilePosition => _innerTile.TilePosition;
        public ITile.TileRotation Rotation { get; }

        public FacePart Left => GetFacePart(Side.Left);
        public FacePart Top => GetFacePart(Side.Top);
        public FacePart Right => GetFacePart(Side.Right);
        public FacePart Bottom => GetFacePart(Side.Bottom);

        public RotatedTile(ITile innerTile, ITile.TileRotation rotation)
        {
            _innerTile = innerTile;
            Rotation = rotation;
        }

        public RotatedTile GetRotated(ITile.TileRotation rotationType)
        {
            int composedRotation = ((int) Rotation + (int) rotationType) % 4;
            return _innerTile.GetRotated((ITile.TileRotation) composedRotation);
        }

        public FacePart GetFacePart(Side position)
        {
            ITile.TileRotation inverseRotation = 4 - Rotation;
            int side = ((int) inverseRotation + (int) position) % 4;
            return _innerTile.GetFacePart((Side) side);
        }

        public bool Equals(RotatedTile other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Rotation == other.Rotation && Equals(_innerTile, other._innerTile);
        }

        public override bool Equals(object obj) 
            => obj is RotatedTile tile && Equals(tile);

        public override int GetHashCode() => HashCode.Combine((int) Rotation, _innerTile);

        public override string ToString() => $"l:{Left} t:{Top} r:{Right} b:{Bottom}";
    }
}