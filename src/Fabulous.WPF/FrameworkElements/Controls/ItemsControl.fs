namespace Fabulous.WPF

open Fabulous
open System.Runtime.CompilerServices
open System.Windows
open System.Windows.Controls

type IItemsControl =
    inherit IControl

module ItemsControl =
    let WidgetKey = Widgets.register<ItemsControl>()
    
    //let ItemsSource =
    //    Attributes.defineDependency<WidgetItems<'T>, System.Collections.Generic.IEnumerable<Widget>>
    //        ItemsControl.ItemsSourceProperty
    //        (fun modelValue ->
    //            seq {
    //                for x in modelValue.OriginalItems do
    //                    modelValue.Template x
    //            })
    //        (fun a b -> ScalarAttributeComparers.equalityCompare a.OriginalItems b.OriginalItems)

    let ItemsSource<'T> =
        Attributes.defineSimpleScalar<WidgetItems<'T>>
            "ItemsControl_ItemsSource"
            (fun a b -> ScalarAttributeComparers.equalityCompare a.OriginalItems b.OriginalItems)
            (fun _ newValueOpt node ->
                let itemsControl = node.Target :?> ItemsControl

                match newValueOpt with
                | ValueNone ->
                    itemsControl.ClearValue(ItemsControl.ItemTemplateProperty)
                    itemsControl.ClearValue(ItemsControl.ItemsSourceProperty)                    
                | ValueSome value ->
                    //todo: Fix itemsControl.SetValue
                    //itemsControl.SetValue(
                    //    ItemsControl.ItemTemplateProperty,
                    //    WidgetDataTemplateSelector(node, unbox >> value.Template)
                    //)

                    itemsControl.SetValue(ItemsControl.ItemsSourceProperty, value.OriginalItems))
        
    let ItemTemplate = Attributes.defineDependencyWithEquality<DataTemplate> ItemsControl.ItemTemplateProperty

    let ItemsPanel = Attributes.defineDependencyWithEquality<ItemsPanelTemplate> ItemsControl.ItemsPanelProperty
    

[<AutoOpen>]
module ItemsControlBuilders =
    type Fabulous.WPF.View with
        //static member inline ItemsControl<'msg>(reference: ViewRef<IndicatorView>) =
        //           WidgetBuilder<'msg, IIndicatorView>(
        //               IndicatorView.WidgetKey,
        //               ViewRefAttributes.ViewRef.WithValue(reference.Unbox)
        //           )
        
        //  let buildItems<'msg, 'marker, 'itemData, 'itemMarker>
        static member inline ItemsControl<'msg, 'itemData, 'itemMarker when 'itemMarker :> IFrameworkElement>
            (items: seq<'itemData>)
            =
            WidgetHelpers.buildItems<'msg, IItemsControl, 'itemData, 'itemMarker>
                ItemsControl.WidgetKey
                ItemsControl.ItemsSource
                items
                        

[<Extension>]
type ItemsControlModifiers =
    [<Extension>]
    static member inline itemTemplate(this: WidgetBuilder<'msg, #IItemsControl>, value: DataTemplate) =
        this.AddScalar(ItemsControl.ItemTemplate.WithValue(value))

    [<Extension>]
    static member inline itemsPanel(this: WidgetBuilder<'msg, #IItemsControl>, value: ItemsPanelTemplate) =
        this.AddScalar(ItemsControl.ItemsPanel.WithValue(value))

    
