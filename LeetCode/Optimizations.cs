namespace LeetCodeTasks.LeetCode;

public static class Optimizations
{
    #region 121 - Best Time to Buy and Sell Stock

    public static int MaxProfit(int[] prices)
    {
        Dictionary<int, int> dayValueArray = prices.Select((value, index) => new { value, index }).OrderByDescending(x => x.value)
                      .ToDictionary(pair => pair.index, pair => pair.value);

        int maxProfit = 0;

        for(int i = 0; i < prices.Length - 1; i++)
        {
            
        }
        return maxProfit;
    }

    private static int MaxProfitForBuyDay(Dictionary<int, int> dayValueArray, int buyIndex)
    {
        int index = -1;

        return index;
    }

    #endregion
}
