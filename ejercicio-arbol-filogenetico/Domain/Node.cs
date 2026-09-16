using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejercicio_arbol_filogenetico.Domain
{
    public class Node
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;

        public List<Node> Children { get; set; } = new();
    }
}
