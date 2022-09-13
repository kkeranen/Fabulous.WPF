using System.Windows.Controls;

namespace Sudoku.CS.Tiles
{
    ////using System.Windows.Input;
    ////using ViewModels;

    /// <summary>
    /// Interaction logic for TileView.xaml
    /// </summary>
    public partial class TileView : UserControl
    {
        public TileView()
        {
            InitializeComponent();
        }

        ////private void UIElement_OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        ////{
        ////    int candidate = (int)(sender as Label).Content;
        ////    ViewModel.OnCandidateClick(candidate);
        ////}

        ////private TileViewModel ViewModel
        ////{
        ////    get
        ////    {
        ////        return this.DataContext as TileViewModel;
        ////    }
        ////}
    }
}
