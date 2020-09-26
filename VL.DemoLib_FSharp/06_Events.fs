namespace FSharpDemoLib
open System.Runtime.InteropServices //for the parameter attributes


type MyGenericEventArgs<'s, 'v> (sender:'s, value:'v) =
    member this.Sender = sender
    member this.Value = value

type MyDataTypeWithEvents (x:float32) =
    
    //private field
    let mutable FX = x
    let mutable FThreshold = 10.0f

    //event definitions
    let OnValueChanged = new Event<unit>()
    static let OnAnyValueChanged = new Event<unit>()

    let OnValueExceeded = new Event<MyGenericEventArgs<MyDataTypeWithEvents, float32>>()
    static let OnAnyValueExceeded = new Event<MyGenericEventArgs<MyDataTypeWithEvents, float32>>()

    //event publishing
    member this.ValueChanged = OnValueChanged.Publish
    static member AnyValueChanged = OnAnyValueChanged.Publish

    member this.ValueExceeded = OnValueExceeded.Publish
    static member AnyValueExceeded = OnAnyValueExceeded.Publish

    //an operation
    member this.AddValue (value:float32) =         
        if value <> 0.0f then 
            FX <- FX + value
            OnValueChanged.Trigger()
            OnAnyValueChanged.Trigger()
            
        if FX > FThreshold then 
            FX <- FX + value
            OnValueExceeded.Trigger(new MyGenericEventArgs<MyDataTypeWithEvents, float32>(this, FX))
            OnAnyValueExceeded.Trigger(new MyGenericEventArgs<MyDataTypeWithEvents, float32>(this, FX))
        FX

    //another operation
    member this.SetThreshold ([<Optional; DefaultParameterValue(10.0f)>] threshold) = 
        FThreshold <- threshold



