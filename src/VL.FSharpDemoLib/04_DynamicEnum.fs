namespace FSharpDemoLib
open System
open System.Runtime.InteropServices //for the parameter attributes
open System.Collections.Generic
open System.Collections.Specialized
open System.Collections.ObjectModel
open VL.Lib.Collections
open System.Reactive.Linq

type MyEnumDefinition () = 
    inherit DynamicEnumDefinitionBase<MyEnumDefinition> ()

    let FMyEntries = ObservableCollection<string>()

    //add two default entries on initialization
    override this.Initialize() =
        this.AddEntry "abara"
        this.AddEntry "kadabara"

    override this.GetEntries() = FMyEntries :> IReadOnlyList<string>

    //inform the system that the enum has changed
    override this.GetEntriesChangedObservable() =
        Observable.FromEventPattern<NotifyCollectionChangedEventHandler, NotifyCollectionChangedEventArgs>( 
            (fun h -> FMyEntries.CollectionChanged.AddHandler h),
            (fun h -> FMyEntries.CollectionChanged.RemoveHandler h)).Select(fun ep -> ep :> Object)

    member this.AddEntry entry = FMyEntries.Add(entry)

    //ignore the boolean succees to get a node without output pins that automatically has a apply pin
    member this.RemoveEntry entry = FMyEntries.Remove(entry) |> ignore
    
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

    member this.AddEnumEntry entry = MyEnumDefinition.Instance.AddEntry entry
    member this.RemoveEnumEntry entry = MyEnumDefinition.Instance.RemoveEntry entry

