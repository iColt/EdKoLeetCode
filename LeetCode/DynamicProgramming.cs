namespace LeetCodeTasks.LeetCode;

public static class DynamicProgramming
{
    #region 121 - Best Time to Buy and Sell Stock. Old approach is O(nlogn) and is too slow. Second solved - 42/43

    public static int MaxProfitOld(int[] prices)
    {
        if(prices.Length < 2) return 0;
        int maxProfit = 0;

        for(int i = 0; i < prices.Length - 1; i++)
        {
            int buyPrice = prices[i];
            for(int j = i; j < prices.Length; j++)
            {
                if(prices[j] - buyPrice > maxProfit)
                {
                    maxProfit = prices[j] - buyPrice;
                }
            }
        }
        return maxProfit;
    }

    public static int MaxProfit(int[] prices)
    {
        if (prices.Length < 2)
        {
            return 0;
        }

        int foundMaxProfit = 0;

        int currentMaxProfit = 0;

        bool subArrayFound = false;

        // phase 1 - instead of real values, set differencies
        for( int i = 0; i < prices.Length - 1; i++)
        {
            prices[i] = prices[i + 1] - prices[i];
        }

        // pahse 2 - find subArray's, set start and end indexes?
        for (int i = 0; i < prices.Length - 1; i++)
        {
            int tempMaxProfit = currentMaxProfit + prices[i];
            if(tempMaxProfit <= 0)
            {
                // check and save found if possible. CurrentMaxProfit contains largest subArray sum for the last subArray
                if(subArrayFound)
                {
                    subArrayFound = false;
                   
                    if(currentMaxProfit > foundMaxProfit)
                    {
                        foundMaxProfit = currentMaxProfit;
                    }

                    currentMaxProfit = 0;

                }
                continue;
            } else
            {
                if(!subArrayFound)
                {
                    subArrayFound = true;
                }
            }
            if(currentMaxProfit > foundMaxProfit)
            {
                foundMaxProfit = currentMaxProfit;
            }
            currentMaxProfit = tempMaxProfit;

        }
        
        return currentMaxProfit > foundMaxProfit ? currentMaxProfit : foundMaxProfit;
    }
    #endregion
}
