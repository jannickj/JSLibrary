﻿namespace JSLibraryFSharp.IO
open System
open FSharpx.Functional.Operators
open FSharpx.Functional.IO

module Time =


    let getCurrentTime = io {
        return DateTime.Now
        }