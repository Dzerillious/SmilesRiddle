using System;

namespace RiddleSolve.Model
{
    public readonly struct FacePart : IEquatable<FacePart>
    {
        public static FacePart Any = new FacePart(PartType.Any, FaceColor.Any);
        
        public enum PartType { Any, Eyes, Mouth }
        public PartType Type { get; }
        
        public enum FaceColor { Any, Yellow, Red, Green, Blue }
        public FaceColor Color { get; }

        public FacePart(PartType type, FaceColor color)
        {
            Type = type;
            Color = color;
        }
        
        public FacePart GetMatching() 
            => new FacePart(Type switch
                            {
                                PartType.Eyes  => PartType.Mouth,
                                PartType.Mouth => PartType.Eyes,
                                _              => PartType.Any,
                            },
                            Color);

        public bool Equals(FacePart other) => Type == other.Type && Color == other.Color;

        public override bool Equals(object? obj) => obj is FacePart other && Equals(other);

        public override int GetHashCode() => HashCode.Combine((int) Type, (int) Color);

        public override string ToString() => $"{Color.ToString()}{Type.ToString()}";
    }
}