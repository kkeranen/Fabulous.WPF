namespace Fabulous.WPF

open Fabulous
open System.Windows
open System.Windows.Controls

type IUserControl =
    inherit IContentControl

module UserControl =
    let WidgetKey = Widgets.register<UserControl>()
    
[<AutoOpen>]
module UserControlBuilders =
    type Fabulous.WPF.View with
        static member inline UserControl<'msg, 'marker when 'marker :> IFrameworkElement>(content: WidgetBuilder<'msg, 'marker>) =
            WidgetHelpers.buildWidgets<'msg, IContentControl>
                UserControl.WidgetKey
                [| ContentControl.Content.WithValue(content.Compile()) |]
            