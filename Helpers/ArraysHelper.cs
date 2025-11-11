namespace LeetCodeTasks.Helpers;

public static class ArraysHelper
{
    // Find position of targetValue or position of MAX element < targetValue (distinct values)
    public static int FindPosBinarySearch(int[] array, int targetValue)
    {
        int length = array.Length;
        int currentLeftPointer = 0;
        int currentRightPointer = length;

        if(length == 0)
        {
            return -1;
        }

        while (true)
        {
            int currentPosition = (currentRightPointer + currentLeftPointer) / 2;

            if ((array[currentPosition] == targetValue))
            {
                return currentPosition;
            }
            if ((array[currentPosition] > targetValue ))
            {
                currentRightPointer = currentPosition;
            } else
            {
                currentLeftPointer = currentPosition;
            }

            if(currentRightPointer - currentLeftPointer < 2)
            {
                if (array[currentLeftPointer] >= targetValue)
                {
                    return currentLeftPointer;
                } else
                {
                    return currentRightPointer;
                }
            }
        }
    }

    //permute array of DISTINCT values
    public static IList<IList<int>> PermuteArray(int[] array)
    {
        List<IList<int>> result = new List<IList<int>>();

        for (int i = 0; i < array.Length; i++)
        {
            var buffer = array[0];
            array[0] = array[i];
            array[i] = buffer;
            result.AddRange(PermuteSubArrayReccursive(array, array[i]));
        }

        return result;
    }

    private static IList<IList<int>> PermuteSubArrayReccursive(int[] subArray, int startingIndex)
    {
        List<IList<int>> result = new List<IList<int>>();
        return result;
    }

}
