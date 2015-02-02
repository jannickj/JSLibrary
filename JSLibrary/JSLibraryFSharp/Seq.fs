namespace JSLibraryFSharp

module Seq = 
    open System

    let tryHead seq = Seq.tryFind (fun _ -> true) seq