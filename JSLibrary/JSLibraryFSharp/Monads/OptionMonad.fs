namespace JSLibraryFSharp

module OptionMonad = 
    open System
    open Option

    type Return = Return with
        static member (?<-) (_, _Monad:Return, _:'a option   ) = fun (x:'a) -> Some x
        static member (?<-) (_, _Monad:Return, _:'a list     ) = fun (x:'a) -> [x]
    
    let inline return' x : ^R = (() ? (Return) <- Unchecked.defaultof< ^R> ) x
     
    type Bind = Bind with
        static member (?<-) (x:option<_>  , _Monad:Bind,_:option<'b>) = fun f -> Option.bind f x
        static member (?<-) (x:list<_>    , _Monad:Bind,_:list<'b>  ) = 
            fun f -> 
                let rec bind f = function
                                 | x::xs -> f x @ bind f xs
                                 | []    -> []
                bind f x
    
    let inline (>>=) x f : ^R = (x ? (Bind) <- Unchecked.defaultof< ^R> ) f

    type DoNotationBuilder() =
        member inline b.Return(x) = return' x
        member inline b.Bind(p,rest) = p >>= rest
        member b.Let(p,rest) = rest p
        member b.ReturnFrom(expr) = expr
    let do' = new DoNotationBuilder()


    type Option2<'a> =
        | Some2 of 'a
        | None2

    type Option2<'a> with
        static member (?<-) (_, _Monad:Return, _: Option2<'a>) = fun (x: 'a) -> Some2 x
        static member (?<-) (x:Option2<_>  , _Monad:Bind,_:Option2<_>) = 
            fun f -> 
                match x with 
                | Some2 y -> f y 
                | None2 -> None2


    let inline Add mx my =
        do' {
            let! x = mx
            let! y = my
            return x + y
        }

    let test0 (mx:int option) (my:int option)  =
        do' {
            let! x = Some 2
            let! y = Some 2
            return x + y
        }
    
