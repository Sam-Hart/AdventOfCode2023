namespace Library.Tests.Day1

open System.IO
open NUnit.Framework
open Library.Day1

[<TestFixture>]
type Day1Tests() =

    [<Test>]
    member public _.Part1TestInput() =
        let input = (File.ReadAllText @"Data/Day1/testinput1.txt").Trim()
        Assert.AreEqual(142, Part1.Solve(input))

    [<Test>]
    member public _.Part1ChallengeInput() =
        let input = (File.ReadAllText @"Data/Day1/challengeinput.txt").Trim()
        Assert.AreEqual(55834, Part1.Solve(input))

    [<Test>]
    member public _.Part2TestInput() =
        let input = (File.ReadAllText @"Data/Day1/testinput2.txt").Trim()
        Assert.AreEqual(281, Part2.Solve(input))

    [<Test>]
    member public _.Part2ChallengeInput() =
        let input = (File.ReadAllText @"Data/Day1/challengeinput.txt").Trim()
        Assert.AreEqual(53221, Part2.Solve(input))
