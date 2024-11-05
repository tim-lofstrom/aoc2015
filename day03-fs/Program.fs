open System.IO

let readFileAsString (path: string) =
    let basePath = Directory.GetCurrentDirectory()
    let filePath = Path.Combine(basePath, path)
    File.ReadAllText(filePath)

let parts = readFileAsString "day03-fs/input.txt" |> Seq.toArray
let input = readFileAsString "day03-fs/input.txt"
let example = readFileAsString "day03-fs/example.txt"

let nextCoordinate (coordinate: (int * int)) (dir: char) =
    match coordinate, dir with
    | (x, y), '^' -> (x, y + 1)
    | (x, y), '>' -> (x + 1, y)
    | (x, y), '<' -> (x - 1, y)
    | (x, y), 'v' -> (x, y - 1)
    | _, _ -> coordinate

let calc (coordinates: ((int * int) array)) (direction: char) =
    let last = Array.last coordinates
    let next = nextCoordinate last direction
    Array.append coordinates [| next |]

let part1 =
    parts
    |> Array.fold (fun coordinates direction -> calc coordinates direction) [| (0, 0) |]
    |> Array.distinct
    |> Array.length

printfn "%A" part1
