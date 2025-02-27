using LeetCodeTasks.LeetCode;

namespace LeetCodeTasks.Tests;

internal class ArraysTests
{
    public static void Test()
    {
        Test_CanConstruct();
    }

    private static void Test_CanConstruct()
    {
        var testCaseA = Arrays.CanConstruct("aab", "baa");
        Console.WriteLine($"Expected = true, Result = {testCaseA}");

        var testCaseB = Arrays.CanConstruct("bg", "efjbdfbdgfjhhaiigfhbaejahgfbbgbjagbddfgdiaigdadhcfcj");
        Console.WriteLine($"Expected = true, Result = {testCaseB}");

        var testCaseC = Arrays.CanConstruct("aa", "ab");
        Console.WriteLine($"Expected = false, Result = {testCaseC}");

        var testCaseD = Arrays.CanConstruct("a", "b");
        Console.WriteLine($"Expected = false, Result = {testCaseD}");
    }
}
