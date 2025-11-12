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

    //permute array of DISTINCT values, min length = 3
    public static IList<IList<int>> PermuteArray(int[] array)
    {
        IList<IList<int>> result = new List<IList<int>>();

        if (array.Length == 1)
        {
            result.Add(array);
            return result;
        }
        if (array.Length == 2)
        {
            result.Add(array);
            result.Add(new List<int> { array[1], array[0] });
            return result;
        }

        return PermuteSubArrayReccursive(array, 0);
    }

    private static IList<IList<int>> PermuteSubArrayReccursive(int[] subArray, int startingIndex)
    {
        List<IList<int>> result = new List<IList<int>>();

        if(subArray.Length - startingIndex == 2)
        {
            result.Add(subArray);

            //change 2 last digits
            int[] swappedArray = new int[subArray.Length];
            Array.Copy(subArray, swappedArray, subArray.Length);
            var buffer = swappedArray[subArray.Length - 1];
            swappedArray[subArray.Length - 1] = swappedArray[subArray.Length - 2];
            swappedArray[subArray.Length - 2] = buffer;

            result.Add(swappedArray);
            return result;
        }

        for (int i = startingIndex; i < subArray.Length; i++)
        {
            int[] swappedArray = new int[subArray.Length];
            Array.Copy(subArray, swappedArray, subArray.Length);
            var buffer = swappedArray[startingIndex];
            swappedArray[startingIndex] = swappedArray[i];
            swappedArray[i] = buffer;
            result.AddRange(PermuteSubArrayReccursive(swappedArray, startingIndex + 1));
        }

        return result;
    }

}
