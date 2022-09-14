namespace Sudoku

open System
open System.Collections.ObjectModel
open System.Windows
open Fabulous.WPF

open type Fabulous.WPF.View


module Tiles =
    type Tile =
        {
           /// <summary>
           /// Gets or sets the known number of the tile (if not null). Null means that the number is not known and candidate list contains all the number candidates. 
           /// </summary>
           Number: Nullable<int>

           /// <summary>
           /// Gets the candidate numbers. Null if the are no candidates in the creation time of tile and the number in this tile is known.
           /// If number is later set the candidates collection exists but is empty
           /// </summary>           
           Candidates: ObservableCollection<int>
        }

    let isNumberVisible tile = tile.Number.HasValue

    /// Represents an update to the game
    type Msg =        
        | CandidateClicked        
        

    let init () =
        {
            Number = Nullable 5
            Candidates = null } //ObservableCollection ([1; 2;]) }
            

    /// The 'update' function to update the model
    let update msg (tile: Tile) =
        match msg with
        | CandidateClicked -> tile                       
        //| _ -> tile

    /// The dynamic 'view' function giving the updated content for the view
    let view (tile: Tile) =
        UserControl(
            (Grid() {           
                if isNumberVisible tile then
                    TextBlock(tile.Number.Value.ToString())
                        .center()
                else
                    //Image("")
                    (ItemsControl
                        (tile.Candidates)
                        (fun item -> TextBlock("test")))

                        .itemTemplate(new DataTemplate(TextBlock("test")))    
            }
            )
        )
                            
        
            

       

