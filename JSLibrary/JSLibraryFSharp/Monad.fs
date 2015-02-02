namespace JSLibraryFSharp

module Monad = 
    open System

    let  inline bind a f =  (^a : (member Bind: (^b -> ^a) ->  ^a) (a,f))

   
    let inline returns a = ( ^a : (member Return: ^a ) (a))

    let inline (>>=) a f =bind a f

    let inline Add mx my =
        mx >>= (fun x -> 
            my >>= (fun y ->
                returns (x + y)))
