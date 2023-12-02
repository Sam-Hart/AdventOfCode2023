namespace Library.Day1

open System
open System.Text.RegularExpressions

module Part1 =
    let private firstNumberRx = Regex(@"(?<!\d.*)(\d)", RegexOptions.Compiled)
    let private lastNumberRx = Regex(@"(\d)(?!.*\d)", RegexOptions.Compiled)

    let Solve (calibrationDoc: string) =

        calibrationDoc.Split($"{Environment.NewLine}")
        |> Seq.map (fun calibration ->
            let first = firstNumberRx.Matches(calibration) |> Seq.head
            let last = lastNumberRx.Matches(calibration) |> Seq.head

            if (first.Success && last.Success) then
                $"{first}{last}" |> (fun s -> Int32.Parse(s))
            else
                0)
        |> Seq.sum

module Part2 =
    let private firstNumberRx =
        Regex(
            @"(?<!(\d|one|two|three|four|five|six|seven|eight|nine).*)(\d|one|two|three|four|five|six|seven|eight|nine)",
            RegexOptions.Compiled
        )

    // oneight parses as one instead of eight with this regex 💀
    // let private lastNumberRx =
    //     Regex(
    //         @"(\d|one|two|three|four|five|six|seven|eight|nine)(?!.*(\d|one|two|three|four|five|six|seven|eight|nine))",
    //         RegexOptions.Compiled
    //     )
    let private lastNumberRx =
        Regex(
            @"(?<!(\d|eno|owt|eerht|ruof|evif|xis|neves|thgie|enin).*)(\d|eno|owt|eerht|ruof|evif|xis|neves|thgie|enin)",
            RegexOptions.Compiled
        )

    let Solve (calibrationDoc: string) =
        let numbers =
            [ ("one", "1")
              ("two", "2")
              ("three", "3")
              ("four", "4")
              ("five", "5")
              ("six", "6")
              ("seven", "7")
              ("eight", "8")
              ("nine", "9") ]
            |> dict

        calibrationDoc.Split($"{Environment.NewLine}")
        |> Seq.map (fun calibration ->
            let first = firstNumberRx.Matches(calibration) |> Seq.head

            let last =
                calibration |> Seq.rev |> String.Concat |> lastNumberRx.Matches |> Seq.head

            if (first.Success && last.Success) then
                let unreversed = last.Value |> Seq.rev |> String.Concat

                let f =
                    if (numbers.ContainsKey first.Value) then
                        numbers[first.Value]
                    else
                        first.Value

                let l =
                    if (numbers.ContainsKey unreversed) then
                        numbers[unreversed]
                    else
                        last.Value

                Int32.Parse($"{f}{l}")
            else
                0)
        |> Seq.sum
