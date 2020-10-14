using System;
using System.Diagnostics;

namespace RiddleSolve.Model
{
    [DebuggerDisplay("({Y},{X})")]
    public sealed class Position : IEquatable<Position>
    {
        public int Y { get; }
        public int X { get; }

        public Position(Array array, int index)
        {
            Y = index / array.GetLength(1);
            X = index % array.GetLength(1);
        }

        public Position(int y, int x)
        {
            Y = y;
            X = x;
        }

        public bool IsInside(Array array)
            => Y >= 0
            && X >= 0
            && Y < array.GetLength(0) 
            && X < array.GetLength(1);
        
        public Position GetNext(Array array)
            => new Position(array, GetIndex(array) + 1);

        public int GetIndex(Array array)
            => X + Y * array.GetLength(1);

        public int GetIndex(int arrayWidth)
            => X + Y * arrayWidth;

        public void Deconstruct(out int y, out int x)
        {
            y = Y;
            x = X;
        }

        public static implicit operator Position((int row, int column) position)
            => new Position(position.row, position.column);

        public static Position operator +(Position position1, Position position2)
            => (position1.Y + position2.Y, position1.X + position2.X);

        public static Position operator -(Position position1, Position position2)
            => (position1.Y - position2.Y, position1.X - position2.X);

        public static Position operator *(Position position, Position position2)
            => (position.Y * position2.Y, position.X * position2.X);

        public static Position operator *(Position position, int coefficient)
            => (position.Y * coefficient, position.X * coefficient);

        public static Position operator /(Position position, Position position2)
            => (position.Y / position2.Y, position.X * position2.X);

        public static Position operator /(Position position, int coefficient)
            => (position.Y / coefficient, position.X * coefficient);

        public bool Equals(Position? other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Y == other.Y && X == other.X;
        }

        public override bool Equals(object? obj) => ReferenceEquals(this, obj) 
                                                 || obj is Position other && Equals(other);

        public override int GetHashCode() => HashCode.Combine(Y, X);
    }
}