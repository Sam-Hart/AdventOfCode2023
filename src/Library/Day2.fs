namespace Library.Day2

open System
open System.Text.RegularExpressions

module Part1 =
    let gameRx = Regex(@"^Game (\d+)", RegexOptions.Compiled)
    let greenRx = Regex(@"(\d+) green", RegexOptions.Compiled)
    let blueRx = Regex(@"(\d+) blue", RegexOptions.Compiled)
    let redRx = Regex(@"(\d+) red", RegexOptions.Compiled)

    let Solve (games: string) =
        games.Split($"{Environment.NewLine}")
        |> Seq.where (fun game -> game.Split(": ").Length = 2)
        |> Seq.where (fun game ->
            let cuberesults = (game.Split(": ")[1]).Split("; ")

            let successes =
                cuberesults
                |> Seq.where (fun result ->
                    let greenMatch = greenRx.Match(result)
                    let blueMatch = blueRx.Match(result)
                    let redMatch = redRx.Match(result)

                    (redMatch.Success <> true || Int32.Parse(redMatch.Groups[1].Value) <= 12)
                    && (greenMatch.Success <> true || Int32.Parse(greenMatch.Groups[1].Value) <= 13)
                    && (blueMatch.Success <> true || Int32.Parse(blueMatch.Groups[1].Value) <= 14))

            cuberesults.Length = (successes |> Seq.length))
        |> Seq.map (fun game -> Int32.Parse(gameRx.Match(game).Groups[1].Value))
        |> Seq.sum

module Part2 =
    type Pull(red: int, green: int, blue: int) =
        member _.Red = red
        member _.Green = green
        member _.Blue = blue

    let Solve (games: string) =
        games.Split($"{Environment.NewLine}")
        |> Seq.where (fun game -> game.Split(": ").Length = 2)
        |> Seq.map (fun game ->
            let cuberesults = (game.Split(": ")[1]).Split("; ")

            cuberesults
            |> Seq.map (fun result ->
                let greenMatch = Part1.greenRx.Match(result)
                let blueMatch = Part1.blueRx.Match(result)
                let redMatch = Part1.redRx.Match(result)

                new Pull(
                    (if redMatch.Success then
                         Int32.Parse(redMatch.Groups[1].Value)
                     else
                         0),

                    (if greenMatch.Success then
                         Int32.Parse(greenMatch.Groups[1].Value)
                     else
                         0),

                    (if blueMatch.Success then
                         Int32.Parse(blueMatch.Groups[1].Value)
                     else
                         0)
                )))
        |> Seq.map (fun game ->
            let maxRed = game |> Seq.map (fun r -> r.Red) |> Seq.max
            let maxBlue = game |> Seq.map (fun r -> r.Blue) |> Seq.max
            let maxGreen = game |> Seq.map (fun r -> r.Green) |> Seq.max
            maxRed * maxBlue * maxGreen)
        |> Seq.sum
