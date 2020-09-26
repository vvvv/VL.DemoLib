namespace FSharpDemoLib
open System.Runtime.InteropServices //for the parameter attributes

type MyDataType (x:float32) =
    
    //private field
    let mutable FX = x
    let mutable FThreshold = 10.0f

    //private operations declared with 'let' will not show up
    let PrivateOp factor = 
        FX <- FX * factor
        FX

    //public mutable property
    member val Y = 0.0f with get, set

    //an operation called AddValue
    member this.AddValue (value) = 
        FX <- FX + value
        FX <- min FX FThreshold
        FX

    //another operation
    member this.SetThreshold ([<Optional; DefaultParameterValue(10)>] threshold) = 
        FThreshold <- threshold

