using System;

namespace RiddleSolve.Model
{
    public class RotatedTile : IEquatable<RotatedTile>
    {
        public Tile Tile { get; }
        
        public enum TileRotation { Up, Right, Down, Left }
        public TileRotation Rotation { get; }

        public FacePart Left => GetFacePart(Side.Left);
        public FacePart Top => GetFacePart(Side.Top);
        public FacePart Right => GetFacePart(Side.Right);
        public FacePart Bottom => GetFacePart(Side.Bottom);

        public RotatedTile(Tile tile, TileRotation rotation)
        {
            Tile = tile;
            Rotation = rotation;
        }

        public RotatedTile GetComposedRotation(TileRotation rotationType)
        {
            int composedRotation = ((int) Rotation + (int) rotationType) % 4;
            return new RotatedTile(Tile, (TileRotation) composedRotation);
        }

        public FacePart GetFacePart(Side position)
        {
            TileRotation inverseRotation = 4 - Rotation;
            int side = ((int) inverseRotation + (int) position) % 4;
            return Tile.GetFacePart((Side) side);
        }

        public bool Equals(RotatedTile other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Rotation == other.Rotation && Equals(Tile, other.Tile);
        }

        public override bool Equals(object obj) 
            => obj is RotatedTile tile && Equals(tile);

        public override int GetHashCode() => HashCode.Combine((int) Rotation, Tile);

        public override string ToString() => $"l:{Left} t:{Top} r:{Right} b:{Bottom}";
    }
}