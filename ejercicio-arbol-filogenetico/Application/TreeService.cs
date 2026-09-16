using ejercicio_arbol_filogenetico.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejercicio_arbol_filogenetico.Application
{
    public class TreeService
    {
        public void BuildTree(List<Node> nodes)
        {
            var nodesById = nodes.ToDictionary(node => node.Id);


            foreach (var node in nodes)
            {
                var parentId = GetParentId(node.Id);

                if (parentId != null && nodesById.TryGetValue(parentId, out var parent))
                {
                    parent.Children.Add(node);
                }
            }

        }

        public Node? FindNode(List<Node> nodes, string nodeId)
        {
            return nodes.FirstOrDefault(node => node.Id == nodeId);
        }

        private string? GetParentId(string nodeId)
        {
            var lastDot = nodeId.LastIndexOf('.');

            if (lastDot == -1)
            {
                return null;
            }

            return nodeId[..lastDot];
        }


        public void PrintSubTree(Node node, int level = 0)
        {
            Console.WriteLine($"{new string(' ', level * 4)}{node.Name}");

            foreach (var child in node.Children)
            {
                PrintSubTree(child, level + 1);
            }
        }
    }
}
