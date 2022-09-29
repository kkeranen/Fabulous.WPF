namespace Sudoku

open System
open System.Collections.ObjectModel
open System.Windows
open System.Windows.Controls
open System.Windows.Controls.Primitives
open FSharp.Collections
open Fabulous.WPF

open Sudoku.Tiles
open Sudoku.Regions

open type Fabulous.WPF.View


module Boards =
    type Board =
        {
           Tiles: Tile [,]
        }

    let designData: Board = {        
        Tiles = array2D [
           [ 0; 0; 0; 0; 0; 6; 9; 5; 2 ]
           [ 0; 1; 7; 0; 0; 0; 0; 0; 0 ] 
           [ 6; 0; 0; 8; 0; 0; 0; 4; 0 ] 
           [ 5; 0; 8; 0; 0; 0; 2; 0; 0 ] 
           [ 3; 0; 0; 0; 9; 0; 0; 0; 4 ] 
           [ 0; 0; 0; 1; 2; 0; 3; 0; 0 ] 
           [ 1; 0; 9; 0; 0; 0; 0; 0; 0 ] 
           [ 0; 7; 0; 0; 0; 1; 5; 6; 0 ] 
           [ 0; 6; 0; 0; 8; 0; 0; 9; 3 ]
        ]
        |> Array2D.mapi (fun i j n -> 
            if n=0 then Tiles.createC null 
            else Tiles.createN n )
    }

    /// Represents an update to the game
    type Msg =        
        | CandidateClicked        
        

    let init () = designData

    let twoDimArrayToSeq (twoDimArray:'a[,])  =
        seq { for x in twoDimArray do yield x :?> 'a }  

    /// The 'update' function to update the model
    let update msg (region: Region) =
        match msg with
        | CandidateClicked -> region                       
        //| _ -> tile

    /// The dynamic 'view' function giving the updated content for the view
    let view (board: Board) =
        UserControl(
            (Grid() {           
                
                //TextBlock("test")
                
                //ItemsControl
                //    ([ "a"; "b"; "c";])
                //    (fun tile -> TextBlock(tile))
                
                // Setting ItemsPanelTemplate programmatically in C#:
                //  ItemsControl.ItemsPanel = 
                //      new ItemsPanelTemplate(
                //          new FrameworkElementFactory(
                //              typeof(UniformGrid)));
                

                (ItemsControl
                    (board.Tiles |> twoDimArrayToSeq)
                    (fun tile -> Tiles.view tile ))
                
                    .itemsPanel(ItemsPanelTemplate(FrameworkElementFactory(typeof<UniformGrid>)))    
            }
            )
        )