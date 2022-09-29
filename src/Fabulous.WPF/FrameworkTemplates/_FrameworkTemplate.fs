namespace Fabulous.WPF

open System.Windows
open System.Runtime.CompilerServices
open Fabulous

type IFrameworkTemplate =
    interface
    end

module FrameworkTemplate =
    //let HasContent = FrameworkTemplate.HasContent

    //let HasContent = Attributes.defineDependencyWithEquality<bool> System.Windows.FrameworkTemplate.HasContentProperty
    
    //let Height = Attributes.defineDependencyWithEquality<double> FrameworkTemplate.HeightProperty   

    //let Margin = Attributes.defineDependencyWithEquality<Thickness> FrameworkTemplate.MarginProperty

    //let HorizontalAlignment = Attributes.defineDependencyWithEquality<HorizontalAlignment> FrameworkTemplate.HorizontalAlignmentProperty

    //let VerticalAlignment = Attributes.defineDependencyWithEquality<VerticalAlignment> FrameworkTemplate.VerticalAlignmentProperty

    //let ClipToBounds = Attributes.defineDependencyWithEquality<bool> FrameworkTemplate.ClipToBoundsProperty
    
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

//[<Extension>]
//type FrameworkTemplateModifiers =
//    [<Extension>]
//    static member inline width(this: WidgetBuilder<'msg, #IFrameworkTemplate>, value: double) =
//        this.AddScalar(FrameworkTemplate.Width.WithValue(value))

//    [<Extension>]
//    static member inline height(this: WidgetBuilder<'msg, #IFrameworkTemplate>, value: double) =
//        this.AddScalar(FrameworkTemplate.Height.WithValue(value))

//    [<Extension>]
//    static member inline margin(this: WidgetBuilder<'msg, #IFrameworkTemplate>, value: Thickness) =
//        this.AddScalar(FrameworkTemplate.Margin.WithValue(value))

//    [<Extension>]
//    static member inline horizontalAlignment(this: WidgetBuilder<'msg, #IFrameworkTemplate>, value: HorizontalAlignment) =
//        this.AddScalar(FrameworkTemplate.HorizontalAlignment.WithValue(value))

//    [<Extension>]
//    static member inline verticalAlignment(this: WidgetBuilder<'msg, #IFrameworkTemplate>, value: VerticalAlignment) =
//        this.AddScalar(FrameworkTemplate.VerticalAlignment.WithValue(value))

//    [<Extension>]
//    static member inline clipToBounds(this: WidgetBuilder<'msg, #IFrameworkTemplate>, value: bool) =
//        this.AddScalar(FrameworkTemplate.ClipToBounds.WithValue(value))

//[<Extension>]
//type FrameworkTemplateExtraModifiers =
//    [<Extension>]
//    static member inline margin(this: WidgetBuilder<'msg, #IFrameworkTemplate>, uniformLength: float) =
//        this.margin(Thickness(uniformLength))

//    [<Extension>]
//    static member inline margin(this: WidgetBuilder<'msg, #IFrameworkTemplate>, left: float, top: float, right: float, bottom: float) =
//        this.margin(Thickness(left, top, right, bottom))

//    [<Extension>]
//    static member inline centerHorizontal(this: WidgetBuilder<'msg, #IFrameworkTemplate>) =
//        this.horizontalAlignment(HorizontalAlignment.Center)

//    [<Extension>]
//    static member inline centerVertical(this: WidgetBuilder<'msg, #IFrameworkTemplate>) =
//        this.verticalAlignment(VerticalAlignment.Center)

//    [<Extension>]
//    static member inline center(this: WidgetBuilder<'msg, #IFrameworkTemplate>) =
//        this.verticalAlignment(VerticalAlignment.Center)
//            .horizontalAlignment(HorizontalAlignment.Center)
