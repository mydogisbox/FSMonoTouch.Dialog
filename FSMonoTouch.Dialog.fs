module FSMonoTouch.Dialog

open System
open System.Drawing
open MonoTouch.Foundation
open MonoTouch.UIKit
open MonoTouch.Dialog
open System.Linq

let inline createSection (elements:^T) = new Section(Elements = new ResizeArray<Element>(elements))

type CreateStringElementHelper = CreateStringElementHelper with    
  static member ($) (_:CreateStringElementHelper, caption:string) = new StringElement(caption)
  static member ($) (_:CreateStringElementHelper, (caption:string, value:string)) = new StringElement(caption,value)
  static member ($) (_:CreateStringElementHelper, (caption:string, action:unit->unit)) = new StringElement(caption,action)

let inline createStringElement p = (CreateStringElementHelper $ p) :> Element