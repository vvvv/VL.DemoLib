namespace FSharpDemoLib
open System
open System.Runtime.InteropServices //for the parameter attributes
open System.Collections.Generic
open System.Collections.Specialized
open System.Collections.ObjectModel
open VL.Lib.Collections
open System.Reactive.Linq

type MyEnumDefinition () = 
    inherit ManualDynamicEnumDefinitionBase<MyEnumDefinition> ()

    //add two default entries on initialization
    override this.Initialize() =
        this.AddEntry ("abara", null)
        this.AddEntry ("kadabara", null)
    
[<Serializable>]
type MyEnum (value:string) =
    inherit DynamicEnumBase<MyEnum, MyEnumDefinition> (value)

    //this method needs to be imported in VL to set the default
    static member CreateDefault() =
        //use method of base class if nothing special required
        DynamicEnumBase<MyEnum, MyEnumDefinition>.CreateDefaultBase()

type DynamicEnumDemo () =

    member this.Update (enumInput:MyEnum) = 
        if enumInput.IsValid()
        then enumInput.Definition.Entries.Item (enumInput.SelectedIndex())
        else "No valid entry selected"

    member this.AddEnumEntry entry = MyEnumDefinition.Instance.AddEntry (entry, null)
    member this.RemoveEnumEntry entry = MyEnumDefinition.Instance.RemoveEntry entry |> ignore

