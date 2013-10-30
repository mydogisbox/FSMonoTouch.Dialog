//This is intented to be used as the MasterViewController for a UISplitView controller
//See here for an example of a UISplitView in C#: http://docs.xamarin.com/recipes/ios/content_controls/split_view/use_split_view_to_show_two_controllers/

namespace Example

open System
open System.Drawing
open MonoTouch.Foundation
open MonoTouch.UIKit
open MonoTouch.Dialog
open System.Linq
open FSMonoTouch.Dialog

[<Register ("MasterViewController")>]
type MasterViewController (window:UIWindow) as this =
    inherit DialogViewController (new RootElement("Items"))

    do this.Root.Add [createSection [yield createStringElement "Section1";
                                     for i in 1..10 -> createStringElement ("num"+i.ToString())];
                      createSection [yield createStringElement "Section2";
                                     for i in 1..10 -> createStringElement ("num"+i.ToString(), "value")];
                      createSection [yield createStringElement "Section3";
                                     for i in 1..10 -> createStringElement ("num"+i.ToString(), fun ()->Console.WriteLine "test")]]

    override this.ShouldAutorotateToInterfaceOrientation toInterfaceOrientation =
        true

