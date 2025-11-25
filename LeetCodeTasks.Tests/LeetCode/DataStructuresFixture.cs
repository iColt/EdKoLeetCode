using static LeetCodeTasks.LeetCode.DataStructures;

namespace LeetCodeTasks.Tests.LeetCode;

[TestFixture]
public sealed class DataStructuresFixture
{
    #region 146

    [TestCaseSource(typeof(LruCacheTestData), nameof(LruCacheTestData.TestCases))]
    public void TestLruCache(int capacity, string[] operations, int?[] args, int?[] expected)
    {
        var cache = new LRUCache(capacity);

        List<int?> results = new List<int?>();

        for (int i = 0; i < operations.Length; i++)
        {
            switch (operations[i])
            {
                case "put":
                    cache.Put(args[i * 2].Value, args[i * 2 + 1].Value);
                    results.Add(null);
                    break;

                case "get":
                    results.Add(cache.Get(args[i].Value));
                    break;
            }
        }

        Assert.That(results, Is.EqualTo(expected));
    }

    public class LruCacheTestData
    {
        public static IEnumerable<TestCaseData> TestCases
        {
            get
            {
                // -------------------------------------------------------
                // Test 1: LeetCode Basic Example
                // -------------------------------------------------------
                yield return new TestCaseData(
                    2,
                    new[] { "put", "put", "get", "put", "get", "get" },
                    new int?[] { 1, 1, 2, 2, 1, 3, 3, 2, 3, 1 }, // packed args
                    new int?[] { null, null, 1, null, -1, 3 }
                );

                // -------------------------------------------------------
                // Test 2: Overwrite existing key moves it to MRU position
                // -------------------------------------------------------
                yield return new TestCaseData(
                    2,
                    new[] { "put", "put", "put", "get", "get" },
                    new int?[] { 1, 1, 2, 2, 1, 10, 2, 1 },
                    new int?[] { null, null, null, 2, 10 }
                );

                // -------------------------------------------------------
                // Test 3: Access should update recency
                // -------------------------------------------------------
                // 1 becomes MRU after get(1), so when adding 3 the LRU = 2
                yield return new TestCaseData(
                    2,
                    new[] { "put", "put", "get", "put", "get", "get" },
                    new int?[] { 1, 1, 2, 2, 1, 3, 3, 2, 1, 3 },
                    new int?[] { null, null, 1, null, -1, 3 }
                );

                // -------------------------------------------------------
                // Test 4: Single capacity cache
                // -------------------------------------------------------
                yield return new TestCaseData(
                    1,
                    new[] { "put", "get", "put", "get", "get" },
                    new int?[] { 1, 1, 1, 2, 2, 1, 2 },
                    new int?[] { null, 1, null, -1, 2 }
                );

                // -------------------------------------------------------
                // Test 5: Heavy eviction sequence
                // -------------------------------------------------------
                yield return new TestCaseData(
                    3,
                    new[]
                    {
                    "put","put","put","put", // fill + evict
                    "get","get","get","get", // check state
                    "put","get","get"        // more recency moves
                    },
                    new int?[]
                    {
                    1,1, 2,2, 3,3, 4,4,   // LRU = 1 evicted
                    1, 2, 3, 4,           // only get operations
                    5,5, 3, 5             // add 5 -> evict 2
                    },
                    new int?[]
                    {
                    null, null, null, null,
                    -1, 2, 3, 4,
                    null, 3, 5
                    }
                );

                // -------------------------------------------------------
                // Test 6: Repeated gets should NOT change values
                // -------------------------------------------------------
                yield return new TestCaseData(
                    2,
                    new[] { "put", "put", "get", "get", "get" },
                    new int?[] { 1, 10, 2, 20, 1, 1, 2 },
                    new int?[] { null, null, 10, 10, 20 }
                );
            }
        }
    }

    #endregion
}
