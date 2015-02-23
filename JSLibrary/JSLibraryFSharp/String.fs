namespace JSLibraryFSharp

module String = 
    open System


    let seperate (str:string) (seperator:string)  = 
        let asArray = seperator.ToCharArray()
        List.ofArray <| str.Split(asArray)
        
    let replace (oldValue:string) (newValue:string) (str:string)  = 
        str.Replace(oldValue,newValue)

    let toLower (str:string) = str.ToLower()


    //skips the first count of charactors
    let skip (str:string) count = str.Substring(count)

    let substring (str:string) idx length = str.Substring(idx,length)


    let editDist (strOne : string) (strTwo : string) =
        let strOne = strOne.ToCharArray ()
        let strTwo = strTwo.ToCharArray ()
     
        let (distArray : int[,]) = Array2D.zeroCreate (strOne.Length + 1) (strTwo.Length + 1)
     
        for i = 0 to strOne.Length do distArray.[i, 0] <- i
        for j = 0 to strTwo.Length do distArray.[0, j] <- j
     
        for j = 1 to strTwo.Length do
            for i = 1 to strOne.Length do
                if strOne.[i - 1] = strTwo.[j - 1] then distArray.[i, j] <- distArray.[i - 1, j - 1]
                else
                    distArray.[i, j] <- List.min (
                        [distArray.[i-1, j] + 1; 
                        distArray.[i, j-1] + 1; 
                        distArray.[i-1, j-1] + 1]
                    )
        distArray.[strOne.Length, strTwo.Length]