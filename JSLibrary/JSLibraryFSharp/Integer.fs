namespace JSLibraryFSharp

module Integer = 
    open System


    let parse (str:string)  = 
        match Int32.TryParse str with
        | (true, v) -> Some v
        | (false, _) -> None

