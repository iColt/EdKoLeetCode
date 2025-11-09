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
        EscapeEndSlash();

        return _object.ToString();
    } 

    private void EscapeEndSlash() {
        int length = _object.Length;
        if (_object[length - 1].Equals('/')) {
            _object.Remove(length - 2, 1);
        } 
    }
}
