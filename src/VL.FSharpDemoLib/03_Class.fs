namespace FSharpDemoLib
open System.Runtime.InteropServices //for the parameter attributes

type MyDataType (x:float32) =
    
    //private field
    let mutable FX = x

    //private operations declared with 'let' will not show up
    let PrivateOp factor = 
        FX <- FX * factor
        FX

    //public mutable property
    member val Y = 0.0f with get, set

    //an operation called update
    member this.Update ([<Optional; DefaultParameterValue(1)>] factor) = 
        FX <- FX * factor
        FX

    //another operation
    member this.Another ([<Optional; DefaultParameterValue(1)>] factor) = 
        FX <- FX * factor
        FX

