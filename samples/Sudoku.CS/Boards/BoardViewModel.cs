namespace Sudoku.CS.Boards
{
    using System.Collections.ObjectModel;
    using Common;
    using Regions;

    public class BoardViewModel : ViewModelBase
    {
        public BoardViewModel(Board board)
        {
            this.Regions = new ObservableCollection<RegionViewModel>();
            for (int i = 0; i < 9; i++)
            {
                var squareVM = new RegionViewModel(board.GetSquare(i));
                this.Regions.Add(squareVM);
                squareVM.CandidateClicked += (sender, args) => board.RemoveCandidates();
            }
        }

        /// <summary>
        /// Design time constructor: Initializes a new instance of the <see cref="BoardViewModel"/> class. 
        /// </summary>
        public BoardViewModel() : this(new Board())
        {
        }

        public ObservableCollection<RegionViewModel> Regions { get; set; }
    }
}
