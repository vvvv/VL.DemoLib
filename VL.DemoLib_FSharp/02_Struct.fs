namespace FSharpDemoLib

//this can be imported as immutable record in VL because the mutable keyword is not used
[<Struct>]
type SimpleStruct (x:int) =
    member this.X = x
    member this.TwoX = this.X * 2;

