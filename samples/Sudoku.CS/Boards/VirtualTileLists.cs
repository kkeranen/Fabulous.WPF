namespace Sudoku.CS.Boards
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using Tiles;

    public class VirtualRow : VirtualTileList
    {
        private int row;

        public VirtualRow(Tile[,] tiles, int row)
            : base(tiles)
        {
            this.row = row;
        }

        public override Tile this[int col]
        {
            get
            {
                return tiles[col, row];
            }
            set
            {
                tiles[col, row] = value;
            }
        }

        public override int Count
        {
            get
            {
                return 9;
            }
        }
    }

    public class VirtualColumn : VirtualTileList
    {
        private int col;

        public VirtualColumn(Tile[,] tiles, int col)
            : base(tiles)
        {
            this.col = col;
        }

        public override Tile this[int row]
        {
            get
            {
                return tiles[col, row];
            }
            set
            {
                tiles[col, row] = value;
            }
        }

        public override int Count
        {
            get
            {
                return 9;
            }
        }
    }

    public class VirtualSquare : VirtualTileList
    {
        private int squareIndex;

        public VirtualSquare(Tile[,] tiles, int squareIndex)
            : base(tiles)
        {
            this.squareIndex = squareIndex;
        }

        public override Tile this[int tileIndexInSquare]
        {
            get
            {
                return tiles[GetColIndex(tileIndexInSquare), GetRowIndex(tileIndexInSquare)];
            }
            set
            {
                tiles[GetColIndex(tileIndexInSquare), GetRowIndex(tileIndexInSquare)] = value;
            }
        }

        private int GetColIndex(int tileIndexInSquare)
        {
            return (squareIndex % 3) * 3 + tileIndexInSquare % 3;
        }

        private int GetRowIndex(int tileIndexInSquare)
        {
            return (squareIndex / 3) * 3 + tileIndexInSquare / 3;
        }

        public override int Count
        {
            get
            {
                return 9;
            }
        }
    }

    public abstract class VirtualTileList : VirtualList<Tile>
    {
        protected Tile[,] tiles;

        public VirtualTileList(Tile[,] tiles)
        {
            this.tiles = tiles;
        }
    }

    public abstract class VirtualList<T> : IList<T>
    {

        #region Implementation of IEnumerable

        public IEnumerator<T> GetEnumerator()
        {
            return new Enumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion

        #region Implementation of ICollection<Tile>

        public void Add(T item)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(T item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public bool Remove(T item)
        {
            throw new NotImplementedException();
        }

        public virtual int Count
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return true;
            }
        }

        #endregion

        #region Implementation of IList<Tile>

        public int IndexOf(T item)
        {
            throw new NotImplementedException();
        }

        public void Insert(int index, T item)
        {
            throw new NotImplementedException();
        }

        public void RemoveAt(int index)
        {
            throw new NotImplementedException();
        }

        public abstract T this[int index] { get; set; }

        #endregion

        private class Enumerator : IEnumerator<T>
        {
            private int index = -1;

            private VirtualList<T> virtualList;

            public Enumerator(VirtualList<T> virtualList)
            {
                this.virtualList = virtualList;
            }

            public T Current
            {
                get
                {
                    return virtualList[index];
                }
            }

            object System.Collections.IEnumerator.Current
            {
                get
                {
                    return Current;
                }
            }

            public bool MoveNext()
            {
                index++;
                return (index < virtualList.Count);
            }

            public void Reset()
            {
                index = -1;
            }

            public void Dispose()
            {
            }
        }
    }
}
