using PFSS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PFSS.API.Helpers
{
    public class DirectoryTreeHelper
    {
        public DirectoryTree FindNode(DirectoryTree tree, string directoryId)
        {
            var stack = new Stack<DirectoryTree>();
            stack.Push(tree);
            while (stack.Count > 0)
            {
                var current = stack.Pop();
                if (current.DirectoryId == directoryId) return current;
                foreach (var child in current.Childs) stack.Push(child);
            }
            return null;
        }
    }
}
