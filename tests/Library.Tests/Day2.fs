namespace Library.Tests.Day2

open System.IO
open NUnit.Framework
open Library.Day2

[<TestFixture>]
type Day2Tests() =
    [<Test>]
    member public _.Part1TestInput() =
        let input = (File.ReadAllText("Data/Day2/testinput1.txt")).Trim()
        Assert.AreEqual(8, Part1.Solve(input))

    [<Test>]
    member public _.Part1ChallengeInput() =
        let input = (File.ReadAllText("Data/Day2/challengeinput.txt")).Trim()
        Assert.AreEqual(2285, Part1.Solve(input))

    [<Test>]
    member public _.Part2TestInput() =
        let input = (File.ReadAllText("Data/Day2/testinput1.txt")).Trim()
        Assert.AreEqual(2286, Part2.Solve(input))

    [<Test>]
    member public _.Part2ChallengeInput() =
        let input = (File.ReadAllText("Data/Day2/challengeinput.txt")).Trim()
        Assert.AreEqual(77021, Part2.Solve(input))
