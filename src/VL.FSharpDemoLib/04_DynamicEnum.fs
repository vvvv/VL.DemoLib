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
    
    let FMyEntries : ObservableCollection<string> = new ObservableCollection<string>()

    //return the current enum entries
    override this.GetEntries() = FMyEntries :> IReadOnlyList<string>

    //inform the system that the enum has changed
    override this.GetEntriesChangedObservable() =
        Observable.FromEventPattern<NotifyCollectionChangedEventHandler, NotifyCollectionChangedEventArgs>( 
            (fun h -> FMyEntries.CollectionChanged.AddHandler h),
            (fun h -> FMyEntries.CollectionChanged.RemoveHandler h)).Select(fun ep -> ep :> Object)

    member this.AddEntry entry = FMyEntries.Add(entry)

    member this.RemoveEntry entry = FMyEntries.Remove(entry)
    
[<Serializable>]
type MyEnum (value:string) =
    inherit DynamicEnumBase<MyEnum, MyEnumDefinition> (value)

    //this method needs to be imported in VL to set the default
    static member CreateDefault() =
        //use method of base class if nothing special required
        DynamicEnumBase<MyEnum, MyEnumDefinition>.CreateDefaultBase()

type DynamicEnumDemo () =
    do MyEnumDefinition.Instance.AddEntry("abara")
    do MyEnumDefinition.Instance.AddEntry("kadabara")   

    member this.Update (enumInput:MyEnum) = 
        if enumInput.IsValid()
        then enumInput.Definition.Entries.Item (enumInput.SelectedIndex())
        else "No valid entry selected"

    member this.AddEnumEntry entry = MyEnumDefinition.Instance.AddEntry entry
    member this.RemoveEnumEntry entry = MyEnumDefinition.Instance.RemoveEntry entry

