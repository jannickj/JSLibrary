namespace JSLibraryFSharp

module String = 
    open System


    let seperate (str:string) (seperator:string)  = 
        let asArray = seperator.ToCharArray()
        List.ofArray <| str.Split(asArray)
        
    let replace (str:string)  (oldValue:string) (newValue:string) = 
        str.Replace(oldValue,newValue)

    let toLower (str:string) = str.ToLower()


    //skips the first count of charactors
    let skip (str:string) count = str.Substring(count)

    let substring (str:string) idx length = str.Substring(idx,length)