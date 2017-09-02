namespace FSharpDemoLib

//F# types are immutable by default, 
//so every type that does not contain the keyword 'mutable'
//and has members that are also immutable can be imported as VL record

//the most easy example is F#'s own record type.
//we can even attach some helper methods to "modify" instances of the record
//using the 'with' keyword
type MyFSharpRecord = { X:float32; Y:float32; Name:string }
    with //helper methods
    member this.SetX x = { this with X=x }
    member this.SetY y = { this with Y=y }
    member this.SetName name = { this with Name=name }