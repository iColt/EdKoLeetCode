namespace LeetCodeTasks.LeetCode;

public static class Strings
{
    #region 71 - Simplify path - 70/84 runtime/memory

    public static string SimplifyPath(string path)
    {
        if (string.IsNullOrEmpty(path))
        {
            return "/";
        }

        var stack = new Stack<string>();
        var parts = path.Split('/', StringSplitOptions.RemoveEmptyEntries);

        foreach (var part in parts)
        {
            if (part == ".")
            {
                continue;
            }
            else if (part == "..")
            {
                if (stack.Count > 0)
                {
                    stack.Pop();
                }
            }
            else
            {
                stack.Push(part);
            }
        }

        var result = "/" + string.Join('/', stack.Reverse());
        return result;
    }

    #endregion
}
