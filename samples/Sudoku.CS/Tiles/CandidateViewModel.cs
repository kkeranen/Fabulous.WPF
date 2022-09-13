using System.Collections.Specialized;
using Sudoku.CS.Common;

namespace Sudoku.CS.Tiles
{
    public class CandidateViewModel : ViewModelBase
    {
        /// <summary>
        /// Candidate number. Does NOT mean the known number of the tile. In view model there are always 9 candidate viewmodels so that e.g. candiate number 5 is alwasy in the middle.
        /// </summary>
        public int Number { get; private set; }

        public bool IsVisible
        {
            get
            {
                return this.Tile.Candidates == null || this.Tile.Candidates.Contains(Number);
            }
        }

        #region Candidate Clicked
        private RelayCommand mouseUpCommand;
        public RelayCommand MouseUpCommand
        {
            get
            {
                if (mouseUpCommand == null)
                {
                    mouseUpCommand = new RelayCommand(param => this.tileVM.OnCandidateClick(this.Number));
                }
                return mouseUpCommand;
            }
        }

        #endregion Candidate Clicked

        private TileViewModel tileVM;

        private Tile Tile
        {
            get
            {
                return tileVM.Tile;
            }
        }

        public CandidateViewModel(TileViewModel tileVM, int number)
        {
            this.tileVM = tileVM;
            this.Number = number;
            if (this.Tile.Candidates != null)
            {
                this.Tile.Candidates.CollectionChanged += CandidatesOnCollectionChanged;
            }
        }

        private void CandidatesOnCollectionChanged(object sender, NotifyCollectionChangedEventArgs notifyCollectionChangedEventArgs)
        {
            if (notifyCollectionChangedEventArgs.OldItems.Contains(this.Number))
            {
                RaisePropertyChanged(() => this.IsVisible);
            }
        }

        public override string ToString()
        {
            return Number.ToString();
        }
    }
}