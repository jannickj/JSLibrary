namespace JSLibraryFSharp.Monad

module State = 
    open System
    open FSharpx.Functional.State


    let eval s m = m s |> fst
    let exec s m = m s |> snd

    let rec fold f value l = state {
        match l with
        | h::rest ->
            let! value' = f value h
            return! fold f value' rest
        | [] -> return value

        }