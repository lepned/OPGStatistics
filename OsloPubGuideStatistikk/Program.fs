open System
open FSharp.Data





//let fil = @"C:\Users\lepne_000\Downloads\OpgData.json"
type opg = JsonProvider<"C:\Users\lepne_000\Downloads\OpgData.json">
let pubs = opg.GetSamples()

let extract =
    let report = ref String.Empty
    pubs
    |>Seq.map(fun e -> String.length(e.JsonValue.ToString()), e.Navn, e.SistOppdatert, e.Hovedområde)
    |>Seq.sortBy(fun (_,_,_,o) -> o)
    //|>Seq.choose(fun (txt,navn,tid) -> tid.DateTime.IsSome)
    |>Seq.mapi(fun idx (txt,navn,tid,o) -> sprintf "%d, %d, %s, %s, %A" (idx+1) txt navn o tid.JsonValue)
    |>Seq.iter(fun e -> report.Value <- (report.Value + e + "\n"))
    report

let stop = 1

[<EntryPoint>]
let main argv = 
    printfn "%A" argv
    0 // return an integer exit code
