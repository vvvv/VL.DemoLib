﻿namespace FSharpDemoLib
open System.Runtime.InteropServices //for the out parameters

//use enum types not union types to be compatible with VL enums
type DemoEnum = Foo=0 | bar=1

module SomeFSharpVLOperations =

    //simple static operation node
    let MyAddition input input2 : float32 = input + input2

    //pinnames are separated at camelCasing for better reading in VL
    let PinNames firstInput secondInput : float32 = firstInput + secondInput

    //setting pin defaults, doesnt work yet, see:
    //https://github.com/Microsoft/visualfsharp/issues/96#issuecomment-320355720
    //let DefaultTest ([<Optional; DefaultParameterValue(42)>] input) : int = input

    //multiple outputs via out parameters
    let MultipleOutputs (firstInput:float32) (secondInput:float32) ([<Out>] added:byref<float32>) ([<Out>] multiplied:byref<float32>) =
        added <- firstInput + secondInput
        multiplied <- firstInput * secondInput

    //using generics
    let Generic input = input.ToString()

    //static enum
    let StaticEnumDemo (e:DemoEnum) = e.ToString()

    //to use XML documentation don't forget to enable "XML Documentation File" in the projects properties!
    ///<summary>An operation to test xml documentation</summary>
    ///<remarks>No remarks</remarks>
    ///<tags>html documentation test</tags>
    ///<param name="a">the param a</param>
    ///<returns>returns 2 a</returns>
    let HTMLDocuTest a = a*2

    //you can use ref parameters, but
    //beware: assigning the parameter in the method leads to undefined behavior in VL (for now)
    //so only make use of it in a readonly fashion
    let RefParams (input:byref<int>) = input + 4444
