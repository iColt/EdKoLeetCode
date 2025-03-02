namespace LeetCodeTasks.Tests;
[TestFixture]
public class ArrayFixture
{
    [SetUp]
    public void Setup()
    {
    }

    [TestCase("aab", "baa", true)]
    [TestCase("bg", "efjbdfbdgfjhhaiigfhbaejahgfbbgbjagbddfgdiaigdadhcfcj", true)]
    [TestCase("aa", "ab", false)]
    [TestCase("a", "b", false)]
    public void Test_CanConstruct2(string ransom, string magaz, bool result)
    {
        Assert.That(Arrays.CanConstruct2(ransom, magaz), Is.EqualTo(result));
    }
}