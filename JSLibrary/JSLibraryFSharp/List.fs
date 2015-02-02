namespace JSLibraryFSharp

module List = 
    open System

    let tryHead list = List.tryFind (fun _ -> true) list