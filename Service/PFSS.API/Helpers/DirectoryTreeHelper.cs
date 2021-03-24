using PFSS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PFSS.API.Helpers
{
    public class DirectoryTreeHelper
    {
        public async Task<DirectoryTree> FindNode(DirectoryTree tree, string directoryId)
        {
            DirectoryTree node = null;

            var stack = new Stack<DirectoryTree>();
            stack.Push(tree);
            while (stack.Count > 0 && node == null)
            {
                var current = stack.Pop();
                if (current.DirectoryId == directoryId)
                {
                    node = current;
                    break;
                }
                foreach (var child in current.Childs)
                    stack.Push(child);
            }
            return node;
        }
        private IEnumerable<DirectoryTree> Traverse(DirectoryTree root)
        {
            var stack = new Stack<DirectoryTree>();
            stack.Push(root);
            while (stack.Count > 0)
            {
                var current = stack.Pop();
                yield return current;
                foreach (var child in current.Childs)
                    stack.Push(child);
            }
        }

    }
}
