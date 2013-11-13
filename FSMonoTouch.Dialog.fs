module FSMonoTouch.Dialog

open System
open System.Drawing
open MonoTouch.Foundation
open MonoTouch.UIKit
open MonoTouch.Dialog
open System.Linq

//section creation helper
let inline createSection (elements:^T) = new Section(Elements = new ResizeArray<Element>(elements))

//StringElement creation helpers
type CreateStringElementHelper = CreateStringElementHelper with    
  static member ($) (_:CreateStringElementHelper, caption:string) = new StringElement(caption)
  static member ($) (_:CreateStringElementHelper, (caption:string, value:string)) = new StringElement(caption,value)
  static member ($) (_:CreateStringElementHelper, (caption:string, action:unit->unit)) = new StringElement(caption,action)

let inline createStringElement p = (CreateStringElementHelper $ p) :> Element

//ImageStringElement creation helpers
type CreateImageStringElementHelper = CreateImageStringElementHelper with    
  static member ($) (_:CreateImageStringElementHelper, (caption:string, image:UIImage)) = new ImageStringElement(caption, image)
  static member ($) (_:CreateImageStringElementHelper, (caption:string, value:string, image:UIImage)) = new ImageStringElement(caption, value, image)
  static member ($) (_:CreateImageStringElementHelper, (caption:string, action:unit->unit, image:UIImage)) = new ImageStringElement(caption, action, image)

let inline createImageStringElement p = (CreateImageStringElementHelper $ p) :> Element

//EntryElement creation helpers
type CreateEntryElementHelper = CreateEntryElementHelper with    
  static member ($) (_:CreateEntryElementHelper, (caption:string, placeholder:string, defaultValue:string)) = new EntryElement(caption, placeholder, defaultValue)
  static member ($) (_:CreateEntryElementHelper, (caption:string, placeholder:string, defaultValue:string, isPassword:bool)) = new EntryElement(caption, placeholder, defaultValue, isPassword)

let inline createEntryElement p = (CreateEntryElementHelper $ p) :> Element

