namespace VL.FSharpDemoLib
open System.Runtime.InteropServices //for the out parameters

module SomeFSharpVLOperations =

    //simple static operation node
    let MyFSharpAddition input input2 : float32 = input + input2

    //multiple outputs via out parameters
    let MultipleOutputs (firstInput:float32) (secondInput:float32) ([<Out>] added:byref<float32>) ([<Out>] multiplied:byref<float32>) =
        added <- firstInput + secondInput
        multiplied <- firstInput * secondInput

//this can be imported as immutable record in VL
type MyFSharpRecord(x) = 
    member this.X:float32 = x
