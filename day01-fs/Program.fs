open System.IO

let readFileAsString (path: string) =
    let basePath = Directory.GetCurrentDirectory()
    let filePath = Path.Combine(basePath, path)
    File.ReadAllText(filePath)

let (parts: char array) = readFileAsString "day01-fs/input.txt" |> Seq.toArray

let calcNext (floor: int) (direction: char) =
    match direction with
    | '(' -> floor + 1
    | ')' -> floor - 1
    | _ -> floor

let rec basement (parts: char array) (floor: int) =
    match parts with
    | _ when floor = -1 -> 0
    | arr when arr.Length > 0 ->
        let direction = arr.[0]
        let rest = arr.[1..]
        let next = calcNext floor direction
        1 + basement rest next
    | _ -> 0

let part1 = parts |> Array.fold (fun floor direction -> calcNext floor direction) 0
let part2 = basement parts 0

printfn "Part 1: %i" part1
printfn "Part 2: %i" part2
