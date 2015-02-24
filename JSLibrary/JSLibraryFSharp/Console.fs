namespace JSLibraryFSharp.IO
open System
open FSharpx.Functional.Operators

module Console =

    let putStr (str : string) = async { do Console.Write(str) }
