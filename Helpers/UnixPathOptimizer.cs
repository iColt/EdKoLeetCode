using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeTasks.Helpers;

public sealed class UnixPathOptimizer
{
    private StringBuilder _object;

    public UnixPathOptimizer InitializePath(string path)
    {
        _object = new StringBuilder(path);
        return this;
    }

    public string Optimize()
    {


        return _object.ToString();
    } 
}
