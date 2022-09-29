namespace Sudoku

open System
open System.Collections.ObjectModel
open System.Windows
open Fabulous.WPF

open Sudoku.Tiles

open type Fabulous.WPF.View


module Regions =
    type Region =
        {
           /// <summary>
           /// Gets the candidate numbers. Null if the are no candidates in the creation time of tile and the number in this tile is known.
           /// If number is later set the candidates collection exists but is empty
           /// </summary>           
           Tiles: ObservableCollection<Tile>
        }

    let designData = {
        Tiles = ObservableCollection ([
            {
                Number = Nullable 7
                Candidates = null };
            {
                Number = Nullable()
                Candidates = ObservableCollection ([2; 6; 8; 9]) };
            {
                Number = Nullable()
                Candidates = ObservableCollection ([1; 2; 6; 8; 9]) };
            {
                Number = Nullable()
                Candidates = ObservableCollection ([4; 4]) };
            {
                Number = Nullable 3
                Candidates = null };
            {
                Number = Nullable()
                Candidates = ObservableCollection ([4; 5]) };
            {
                Number = Nullable()
                Candidates = ObservableCollection ([1; 2; 9]) };
            {
                Number = Nullable()
                Candidates = ObservableCollection ([8; 9]) };
            {
                Number = Nullable()
                Candidates = ObservableCollection ([2; 6; 8]) };
        ])
    }

    /// Represents an update to the game
    type Msg =        
        | CandidateClicked        
        

    let init () = designData
            

    /// The 'update' function to update the model
    let update msg (region: Region) =
        match msg with
        | CandidateClicked -> region                       
        //| _ -> tile

    /// The dynamic 'view' function giving the updated content for the view
    let view (region: Region) =
        UserControl(
            (Grid() {           
                
                (ItemsControl
                    (region.Tiles)
                    (fun tile -> Tiles.view tile ))

                    .itemTemplate(new DataTemplate(TextBlock("test")))    
            }
            )
        )