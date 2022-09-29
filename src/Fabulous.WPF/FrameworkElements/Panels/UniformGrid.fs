
namespace Fabulous.WPF

open System.Runtime.CompilerServices
open Fabulous
open System.Windows
open System.Windows.Controls
open System.Windows.Controls.Primitives

type IUniformGrid=
    inherit IPanel

//module UniformGridUpdaters =
//    let updateGridColumnDefinitions _ (newValueOpt: Dimension [] voption) (node: IViewNode) =
//        let grid = node.Target :?> UniformGrid

//        match newValueOpt with
//        | ValueNone -> grid.ColumnDefinitions.Clear()
//        | ValueSome coll ->
//            grid.ColumnDefinitions.Clear()

//            for c in coll do
//                let gridLength =
//                    match c with
//                    | Auto -> GridLength.Auto
//                    | Star -> GridLength(1, GridUnitType.Star)
//                    | Stars x -> GridLength(x, GridUnitType.Star)
//                    | Absolute x -> GridLength(x, GridUnitType.Pixel)

//                grid.ColumnDefinitions.Add(ColumnDefinition(Width = gridLength))

//    let updateGridRowDefinitions _ (newValueOpt: Dimension [] voption) (node: IViewNode) =
//        let grid = node.Target :?> Grid

//        match newValueOpt with
//        | ValueNone -> grid.RowDefinitions.Clear()
//        | ValueSome coll ->
//            grid.RowDefinitions.Clear()

//            for c in coll do
//                let gridLength =
//                    match c with
//                    | Auto -> GridLength.Auto
//                    | Star -> GridLength(1, GridUnitType.Star)
//                    | Stars x -> GridLength(x, GridUnitType.Star)
//                    | Absolute x -> GridLength(x, GridUnitType.Pixel)

//                grid.RowDefinitions.Add(RowDefinition(Height = gridLength))

module UniformGrid =
    let WidgetKey = Widgets.register<UniformGrid>()
        
    let Columns =
        Attributes.defineDependencyInt UniformGrid.ColumnsProperty
    
    let Row =
        Attributes.defineDependencyInt UniformGrid.RowsProperty
    
    
    
//[<AutoOpen>]
//module GridBuilders =
//    type Fabulous.WPF.View with
//        static member inline Grid<'msg>(coldefs: seq<Dimension>, rowdefs: seq<Dimension>) =
//            CollectionBuilder<'msg, IUniformGrid, IFrameworkElement>(
//                Grid.WidgetKey,
//                Panel.Children,
//                Grid.ColumnDefinitions.WithValue(Array.ofSeq coldefs),
//                Grid.RowDefinitions.WithValue(Array.ofSeq rowdefs)
//            )
    
//        static member inline Grid<'msg>() = View.Grid<'msg>([ Star ], [ Star ])

