open System.IO

let readFileAsString (path: string) =
    let basePath = Directory.GetCurrentDirectory()
    let filePath = Path.Combine(basePath, path)
    File.ReadAllText(filePath)

let parts = readFileAsString "day03-fs/input.txt" |> Seq.toArray
let example = readFileAsString "day03-fs/example.txt" |> Seq.toArray

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

let union a b = Array.append a b |> Array.distinct

let splitList arr =
    let evens, odds =
        arr |> Array.indexed |> Array.partition (fun (index, _) -> index % 2 = 0)

    evens |> Array.map snd, odds |> Array.map snd

let calcPart2 parts =
    let start = [| (0, 0) |]
    let santaParts, roboParts = splitList parts
    let santa = santaParts |> Array.fold calc start
    let robo = roboParts |> Array.fold calc start
    union santa robo |> Array.length

let calcPart1 parts =
    parts |> Array.fold calc [| (0, 0) |] |> Array.distinct |> Array.length

let part1 = calcPart1 parts
let part2 = calcPart2 parts

printfn "%A" part1
printfn "%A" part2

// Part1: 2565
// Part2: 2639
