namespace Sudoku.CS.Regions
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    
    using Common;
    using Tiles;

    public class RegionViewModel : ViewModelBase
    {
        public RegionViewModel(IList<Tile> region)
        {
            this.Tiles = new ObservableCollection<TileViewModel>();
            for (int i = 0; i < 9; i++)
            {
                var tileVM = new TileViewModel(region[i]);
                this.Tiles.Add(tileVM);
                tileVM.CandidateClicked += (sender, args) =>
                {
                    if (CandidateClicked != null)
                    {
                        CandidateClicked(sender, args);
                    }
                };
            }
        }

        #region Design Data

        public RegionViewModel()
            : this(DesignData)
        {
        }

        private static readonly IList<Tile> DesignData = new List<Tile> { new Tile(7), 
            new Tile(new ObservableCollection<int> { 2, 6, 8, 9 }), 
            new Tile(new ObservableCollection<int> { 1, 2, 6, 8, 9 }), 
            new Tile(new ObservableCollection<int> { 4, 5 }), 
            new Tile(3), 
            new Tile(new ObservableCollection<int> { 4, 5 }), 
            new Tile(new ObservableCollection<int> { 1, 2, 9 }), 
            new Tile(new ObservableCollection<int> { 8, 9 }), 
            new Tile(new ObservableCollection<int> { 2, 6, 8 }) };

        #endregion Design Data

        public event EventHandler<EventArgs<int>> CandidateClicked;

        public ObservableCollection<TileViewModel> Tiles { get; private set; }
    }
}