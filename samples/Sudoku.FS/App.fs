namespace Sudoku

open System
open System.Collections.ObjectModel
open System.Windows
open Fabulous.WPF

open type Fabulous.WPF.View
   
/// Represents an update to the game
type Msg =        
    | Restart        
    | Ignore

/// Represents the state of the game board
// type Board = Map<Pos, GameCell>

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
       //public ObservableCollection<int> Candidates { get; private set; }
       Candidates: ObservableCollection<int>}
       

/// Represents the state of the game
type Model =
    {
      Tile: Tile }

/// The model, update and view content of the app. This is placed in an
/// independent model to facilitate unit testing.
module App =   

    let init () =
        {
            Tile =  { Number = Nullable 5
                      Candidates = null } }

    /// The 'update' function to update the model
    let update gameOver msg (model: Model) =
        match msg with
        | Restart -> 
            gameOver("Game over")
            model
        | Ignore -> model

    /// The dynamic 'view' function giving the updated content for the view
    let view (model: Model) =
        Window(
            "Sudoku F# with Fabulous.WPF",
            (TextBlock(model.Tile.Number.Value.ToString())
                .center()
            )                
        )
            .width(800)
            .height(800)

    // Display a modal message giving the game result. This is doing a UI
    // action in the model update, which is ok for modal messages. We factor
    // this dependency out to allow unit testing of the 'update' function.

    let gameOver msg =
        Application.Current.Dispatcher.InvokeAsync
            (fun () ->
                MessageBox.Show("Game over", msg)
                |> ignore) |> ignore

    let program =
        Program.stateful init (update gameOver) view

type App() as app =
    inherit Application(ShutdownMode = ShutdownMode.OnMainWindowClose)
    do Program.start app App.program