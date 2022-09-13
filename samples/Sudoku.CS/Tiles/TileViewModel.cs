using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Sudoku.CS.Common;

namespace Sudoku.CS.Tiles
{
    public class TileViewModel : ViewModelBase
    {

        public Tile Tile { get; private set; }

        public List<CandidateViewModel> Candidates { get; private set; }

        public TileViewModel(Tile tile)
        {
            this.Tile = tile;
            Candidates = new List<CandidateViewModel>();
            for (int i = 0; i < 9; i++)
            {
                var candidateVM = new CandidateViewModel(this, i + 1);
                Candidates.Add(candidateVM);
            }
        }

        public TileViewModel() : this(DesignData)
        { }

        private static readonly Tile DesignData = new Tile(new ObservableCollection<int> { 1, 2, 3, 4, 5, 6, 7, 9 });

        public int? Number
        {
            get
            {
                return this.Tile.Number;
            }

            set
            {
                if (this.Tile.Number != value)
                {
                    this.Tile.Number = value;
                    RaisePropertyChanged(() => this.Number);
                    RaisePropertyChanged(() => this.IsNumberVisible);
                    RaisePropertyChanged(() => this.IsCandidatesVisible);
                }
            }
        }

        public bool IsNumberVisible
        {
            get
            {
                return this.Number != null;
            }
        }

        public bool IsCandidatesVisible
        {
            get
            {
                return !IsNumberVisible;
            }
        }

        public event EventHandler<EventArgs<int>> CandidateClicked;

        public void OnCandidateClick(int candidate)
        {
            this.Number = candidate;
            if (CandidateClicked != null)
            {
                CandidateClicked(this, new EventArgs<int>(candidate));
            }
        }

        public TileViewModel SampleTile => new TileViewModel(new Tile(0));
    }
}