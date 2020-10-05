using System;

namespace RiddleSolve.Model
{
    public sealed class Position : IEquatable<Position>
    {
        public int Row { get; }
        public int Column { get; }

        public Position(Array array, int index)
        {
            Row = index / array.GetLength(1);
            Column = index % array.GetLength(1);
        }

        public Position(int row, int column)
        {
            Row = row;
            Column = column;
        }

        public bool IsInside(Array array)
            => Row >= 0
            && Column >= 0
            && Row < array.GetLength(0) 
            && Column < array.GetLength(1);
        
        public Position GetNext(Array array)
            => new Position(array, GetIndex(array) + 1);

        public int GetIndex(Array array)
            => Column + Row * array.GetLength(1);

        public int GetIndex(int arrayWidth)
            => Column + Row * arrayWidth;

        public void Deconstruct(out int row, out int column)
        {
            row = Row;
            column = Column;
        }

        public override string ToString() => $"({Row},{Column})";

        public static implicit operator Position((int row, int column) position)
            => new Position(position.row, position.column);

        public static Position operator +(Position position1, Position position2)
            => (position1.Row + position2.Row, position1.Column + position2.Column);

        public static Position operator -(Position position1, Position position2)
            => (position1.Row - position2.Row, position1.Column - position2.Column);

        public static Position operator *(Position position, Position position2)
            => (position.Row * position2.Row, position.Column * position2.Column);

        public static Position operator *(Position position, int coefficient)
            => (position.Row * coefficient, position.Column * coefficient);

        public static Position operator /(Position position, Position position2)
            => (position.Row / position2.Row, position.Column * position2.Column);

        public static Position operator /(Position position, int coefficient)
            => (position.Row / coefficient, position.Column * coefficient);

        public bool Equals(Position other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Row == other.Row && Column == other.Column;
        }

        public override bool Equals(object obj) => ReferenceEquals(this, obj) 
                                                || obj is Position other && Equals(other);

        public override int GetHashCode() => HashCode.Combine(Row, Column);
    }
}