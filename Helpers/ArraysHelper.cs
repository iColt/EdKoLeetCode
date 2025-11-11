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

}
