// Learn more about F# at http://fsharp.org

//type donkey()=
  

open System
open CppAst.CodeGen
[<EntryPoint>]
let main argv =
    CppAst.CppParser.ParseFiles()
    printfn "Hello World from F#!"
    0 // return an integer exit code
