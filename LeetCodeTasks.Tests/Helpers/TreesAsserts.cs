namespace LeetCodeTasks.Tests.Helpers;

internal class TreesAsserts
{
    // ----------------------
    // Helper assertion
    // ----------------------
    public static void AssertLevelsEqual(
        IList<IList<int>> expected,
        IList<IList<int>> actual)
    {
        Assert.That(actual.Count, Is.EqualTo(expected.Count), "Level count mismatch");

        for (int i = 0; i < expected.Count; i++)
        {
            CollectionAssert.AreEqual(
                expected[i],
                actual[i],
                $"Mismatch at level {i}"
            );
        }
    }

}
