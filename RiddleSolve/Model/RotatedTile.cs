using System;
using static RiddleSolve.Model.ITile;

namespace RiddleSolve.Model
{
    public class RotatedTile : ITile, IEquatable<RotatedTile>
    {
        private readonly ITile _innerTile;
        
        public TileRotation Rotation { get; }
        
        public Position FromPosition => _innerTile.FromPosition;

        public FacePart Left => GetFacePart(TileSide.Left);
        public FacePart Top => GetFacePart(TileSide.Top);
        public FacePart Right => GetFacePart(TileSide.Right);
        public FacePart Bottom => GetFacePart(TileSide.Bottom);

        public RotatedTile(ITile innerTile, TileRotation rotation)
        {
            _innerTile = innerTile;
            Rotation = rotation;
        }

        public RotatedTile GetRotated(TileRotation addedRotation)
        {
            int composedRotation = ((int) Rotation + (int) addedRotation) % 4;
            return _innerTile.GetRotated((TileRotation) composedRotation);
        }

        public FacePart GetFacePart(TileSide side)
        {
            TileRotation inverseRotation = 4 - Rotation;
            int resultSide = ((int) inverseRotation + (int) side) % 4;
            return _innerTile.GetFacePart((TileSide) resultSide);
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