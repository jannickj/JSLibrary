namespace JSLibraryFSharp

module Type = 

    let tryCast<'b,'a> (a:'a) =
        match box a with
        | :? 'b as b -> Some b
        | _ -> None