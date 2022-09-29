namespace Fabulous.WPF

open System.Windows
open System.Runtime.CompilerServices
open Fabulous

type IItemsPanelTemplate =
    inherit IFrameworkTemplate  

module ItemsPanelTemplate =  
    //let HasContent =
    //    Attributes.defineSimpleScalarWithEquality<bool>
    //        "HasContent"
    //        (fun _ _ node ->
    //            let FrameworkTemplate = node.Target :?> FrameworkTemplate

    //            ())
           
    let Template =
        Attributes.defineSimpleScalarWithEquality<TemplateContent>
            "Template"
            (fun _ newValueOpt node ->
                let FrameworkTemplate = node.Target :?> FrameworkTemplate

                let value =
                    match newValueOpt with
                    | ValueNone -> FrameworkTemplate.Template
                    | ValueSome v -> v

                FrameworkTemplate.Template <- value)
    
    let Resources =
        Attributes.defineSimpleScalarWithEquality<ResourceDictionary>
            "Resources"
            (fun _ newValueOpt node ->
                let FrameworkTemplate = node.Target :?> FrameworkTemplate

                let value =
                    match newValueOpt with
                    | ValueNone -> FrameworkTemplate.Resources
                    | ValueSome v -> v

                FrameworkTemplate.Resources <- value)

//[<AutoOpen>]
//module ItemsPanelTemplateBuilders =
//type Fabulous.WPF.View with
//    static member inline Grid<'msg>(coldefs: seq<Dimension>, rowdefs: seq<Dimension>) =
//        CollectionBuilder<'msg, IGrid, IFrameworkElement>(
//            Grid.WidgetKey,
//            Panel.Children,
//            Grid.ColumnDefinitions.WithValue(Array.ofSeq coldefs),
//            Grid.RowDefinitions.WithValue(Array.ofSeq rowdefs)
//        )

//    static member inline Grid<'msg>() = View.Grid<'msg>([ Star ], [ Star ])

//[<AutoOpen>]
//module ButtonBuilders =
//    type Fabulous.WPF.View with
//        static member inline Button<'msg>(text: string, onClicked: 'msg) =
//            WidgetBuilder<'msg, IButton>(
//                Button.WidgetKey,
//                ContentControl.ContentAsString.WithValue(text),
//                ButtonBase.Click.WithValue(onClicked)
//            )

