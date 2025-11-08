namespace LeetCodeTasks.Tests;

[TestFixture]
public sealed class StringsFixture
{
    public void Test_SimplifyPath(string path, string result)
    {
        Assert.That(Strings.SimplifyPath(path), Is.EqualTo(result));
    }
}
