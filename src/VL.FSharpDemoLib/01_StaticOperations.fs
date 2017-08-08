namespace FSharpDemoLib
open System.Runtime.InteropServices //for the parameter attributes

//use enum types not union types to be compatible with VL enums
type DemoEnum = Foo=0 | Bar=1

module SomeStaticVLNodes =

    //simple static operation node
    let MyAddition input input2 : float32 = input + input2

    //pinnames are separated at camelCasing for better reading in VL
    let PinNames firstInput secondInput : float32 = firstInput + secondInput

    //setting pin defaults, needs F# compiler tools 4.1 or Visual Studio 2017
    let Defaults ([<Optional; DefaultParameterValue(44)>] firstInput:float32) ([<Optional; DefaultParameterValue(0.44f)>] secondInput:float32) = firstInput + secondInput

    //multiple outputs via out parameters
    let MultipleOutputs (firstInput:float32) (secondInput:float32) ([<Out>] added:byref<float32>) ([<Out>] multiplied:byref<float32>) =
        added <- firstInput + secondInput
        multiplied <- firstInput * secondInput

    //using generics
    let Generic input = input.ToString()

    //seq<> appears as Sequence<> in vl
    let ReverseSequence input : seq<float32> = Seq.rev input

    //static enum
    let StaticEnumDemo (e:DemoEnum) = e.ToString()

    //to use XML documentation don't forget to enable "XML Documentation File" in the projects properties!
    ///<summary>An operation to test xml documentation</summary>
    ///<remarks>This is only an example node</remarks>
    ///<tags>html documentation test</tags>
    ///<param name="a">the param a</param>
    ///<returns>returns 2 a</returns>
    let XMLDocuTest a = a*2

    //you can use ref parameters, but
    //beware: assigning the parameter in the method leads to undefined behavior in VL (for now)
    //so only make use of it in a readonly fashion
    let RefParams (input:byref<int>) = input + 4444
