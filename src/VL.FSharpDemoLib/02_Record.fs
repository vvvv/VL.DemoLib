namespace FSharpDemoLib

//this can be imported as immutable record in VL
type MyFSharpRecord = { X:float32; Y:float32 }

module MyFSharpRecordOperations =
    let SetX (input:MyFSharpRecord) x = { input with X=x }
    let SetY (input:MyFSharpRecord) y = { input with Y=y }