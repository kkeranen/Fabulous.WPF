using System.Collections.ObjectModel;

namespace Sudoku.CS.Tiles
{
    public class Tile
    {
        /// <summary>
        /// Gets or sets the known number of the tile (if not null). Null means that the number is not known and candidate list contains all the number candidates. 
        /// </summary>
        public int? Number { get; set; }

        /// <summary>
        /// Gets the candidate numbers. Null if the are no candidates in the creation time of tile and the number in this tile is known.
        /// If number is later set the candidates collection exists but is empty
        /// </summary>
        public ObservableCollection<int> Candidates { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Tile"/> class. if number == 0, default tile with all possible candidates is created.
        /// </summary>
        /// <param name="number">
        /// The number.
        /// </param>
        public Tile(int number)
        {
            if (number > 0)
            {
                Number = number;
                Candidates = null;
            }
            else
            {
                Number = null;
                Candidates = new ObservableCollection<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            }
        }

        public Tile(ObservableCollection<int> candidates)
        {
            Number = null;
            Candidates = candidates;
        }
    }
}