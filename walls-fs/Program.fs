let store = [| 3; 5; 6 |]


let rec calc (store: int array) (parts: int array) (prevSum: int) (target: int) (count: int) =

    let s = parts |> Array.sum
    let diff = s - prevSum
    let newCount = if diff > 0 then 10 else (count - 1)

    printfn "%i" s

    match count, Array.sum parts with
    | 0, sum -> sum
    | _, sum when sum < target ->
        let maxElement = Array.max store
        let newP = Array.append parts [| maxElement |]
        calc store newP s target newCount
    | _, sum when sum > target ->
        let minElement = Array.min store
        let allButBiggest = Array.sort parts |> Array.rev |> Array.tail
        let newP = Array.append allButBiggest [| minElement |]
        calc store newP s target newCount
    | _ -> s



let result = calc store [||] 0 100 10

printfn "%i" result
