namespace JSLibraryFSharp

module Regex = 
    open System
    open System.Text.RegularExpressions
    open System.Linq

    let tryMatch pattern input  =
       try 
           let m = Regex.Match(input, pattern)
           Some (m.Index, m.Value)
       with
          | _ -> None
      
    let matches pattern input =
        let ms = Regex.Matches(input, pattern)
        Seq.map (fun (m:Match) -> (m.Index,m.Value)) <| seq (ms.Cast<Match>())