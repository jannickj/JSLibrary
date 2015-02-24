namespace JSLibraryFSharp.IO
open System
open FSharpx.Functional.Operators
open FSharpx.Functional.IO
open Time

module Logger =
    type Level  = None = 0
                | Critical = 1
                | Error = 2
                | Warning = 3
                | Important = 4
                | Info = 5
                | All = 6

    let log (level:Level) (curLevel:Level) (msg:string) = io {
        if curLevel >= level then
            let! time = getCurrentTime
            let timeStamp = time.ToString("[dd/MM-yyyy HH:mm:ss]")
            do! putStr <| sprintf "%s : [%s] %s\n" timeStamp (level.ToString()) msg
        }
        //if Set.exists ((=) debugFlag) allowFlags then
         //   lock logLock (fun () -> logger.LogStringWithTimeStamp (str, debugLevel))

   
    let logCritical = log Level.Critical
    let logError = log Level.Error
    let logWarning = log Level.Warning
    let logImportant = log Level.Important
    let logInfo = log Level.Info
    let logAll = log Level.All   