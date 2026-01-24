namespace LeetCodeTasks.Models;

public class PairOfIntModel
{
    public int Max1 = -1;
    public int Max2 = -1;

    public void Add(int val)
    {
        if (val > Max1)
        {
            Max2 = Max1;
            Max1 = val;
        }
        else if (val > Max2)
        {
            Max2 = val;
        }
    }
}
