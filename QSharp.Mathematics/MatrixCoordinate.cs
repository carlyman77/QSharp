#region Using References

using System;

#endregion

namespace QSharp.Mathematics
{
    internal struct MatrixCoordinate
    {
        public MatrixCoordinate(uint row, uint column)
        {
            _column = column;
            _row = row;
        }

        private readonly uint _column;
        private readonly uint _row;

        public uint Column
        {
            get
            {
                return _column;
            }
        }

        public uint Row
        {
            get
            {
                return _row;
            }
        }

        public override bool Equals(object value)
        {
            return (value is MatrixCoordinate) && Equals((MatrixCoordinate)(value));
        }

        public bool Equals(MatrixCoordinate value)
        {
            return
            (
                (_column == value._column) &&
                (_row == value._row)
            );
        }

        public override int GetHashCode()
        {
            return _column.GetHashCode() ^ _row.GetHashCode();
        }

        public override string ToString()
        {
            return String.Format("(Column {0}, Row {1})", _column, _row);
        }
    }
}
