namespace Sudoku.CS.Boards
{
    using System;
    using System.Collections.Generic;
    using Regions;
    using Tiles;

    public class Board
    {
        public Tile[,] Tiles { get; set; }

        private int[,] sampleBoard = new int[9,9]
        {
            { 0, 0, 0, 0, 0, 6, 9, 5, 2 }, 
            { 0, 1, 7, 0, 0, 0, 0, 0, 0 }, 
            { 6, 0, 0, 8, 0, 0, 0, 4, 0 }, 
            { 5, 0, 8, 0, 0, 0, 2, 0, 0 }, 
            { 3, 0, 0, 0, 9, 0, 0, 0, 4 }, 
            { 0, 0, 0, 1, 2, 0, 3, 0, 0 }, 
            { 1, 0, 9, 0, 0, 0, 0, 0, 0 }, 
            { 0, 7, 0, 0, 0, 1, 5, 6, 0 }, 
            { 0, 6, 0, 0, 8, 0, 0, 9, 3 }
        };

        public Board()
        {
            Tiles = new Tile[9,9];
            
            for (int y = 0; y < 9; y++)
            {
                for (int x = 0; x < 9; x++)
                {
                    Tiles[x, y] = new Tile(sampleBoard[y, x]);
                }
            }
            RemoveCandidates();
        }

        public void RemoveCandidates()
        {
            RemoveCandidatesFoundInRegions();
            RemoveCandidatesFoundInRows();
            RemoveCandidatesFoundInColumns();    
        }

        public IList<Tile> GetRow(int row)
        {
            return new VirtualRow(Tiles, row);
        }

        public IList<Tile> GetColumn(int col)
        {
            return new VirtualColumn(Tiles, col);
        }

        public IList<Tile> GetRegion(int regionIndex)
        {
            return new VirtualRegion(Tiles, regionIndex);
        }

        private void RemoveCandidatesFoundInRegions()
        {
            RemoveCandidates(this.GetRegion);
        }

        private void RemoveCandidatesFoundInRows()
        {
            RemoveCandidates(this.GetRow);
        }

        private void RemoveCandidatesFoundInColumns()
        {
            RemoveCandidates(this.GetColumn);
        }

        private void RemoveCandidates(Func<int, IList<Tile>> getTiles)
        {
            for (int i = 0; i < 9; i++)
            {
                List<int> found = new List<int>();
                var tiles = getTiles(i);

                foreach (var tile in tiles)
                {
                    if (tile.Number.HasValue)
                    {
                        found.Add(tile.Number.Value);
                    }
                }

                foreach (var tile in tiles)
                {
                    if (tile.Candidates != null)
                    {
                        foreach (int existingNumber in found)
                        {
                            tile.Candidates.Remove(existingNumber);
                        }
                    }
                }
            }
        }
    }
}
