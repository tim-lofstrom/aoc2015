open System.IO

let readFileAsArray (path: string) =
    let basePath = Directory.GetCurrentDirectory()
    let filePath = Path.Combine(basePath, path)
    File.ReadAllLines(filePath)

let input = readFileAsArray "input.txt"
let example = readFileAsArray "example.txt"

let area length width height =
    [| (length * width); (width * height); (height * length) |]

let arrayProduct (arr: int[]) = arr |> Array.fold (*) 1

let calcDimensions (arr: int array) =
    match arr with
    | [| length; width; height |] -> area length width height
    | _ -> raise (System.Exception("Fel antal parametrar."))

let calculateBox (dimensions: int array) =
    let sortedDimensions = calcDimensions dimensions |> Array.sort
    let smallest = sortedDimensions |> Array.head
    let dimensions = sortedDimensions |> Array.sum
    smallest + dimensions * 2

let calculateRibbon (dimensions: int array) =
    let sortedDimensions = dimensions |> Array.sort
    let perimeter = 2 * (sortedDimensions[0..1] |> Array.sum)
    let bow = dimensions |> arrayProduct
    bow + perimeter

let toIntArray = (fun (line: string) -> line.Split('x') |> Array.map int)

let part1 =
    input
    |> Array.map toIntArray
    |> Array.fold (fun sum dimensions -> sum + (calculateBox dimensions)) 0

let part2 =
    input
    |> Array.map toIntArray
    |> Array.fold (fun sum dimensions -> sum + (calculateRibbon dimensions)) 0

printfn "%i" part1
printfn "%i" part2
