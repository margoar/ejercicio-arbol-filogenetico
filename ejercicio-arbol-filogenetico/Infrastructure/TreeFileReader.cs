using ejercicio_arbol_filogenetico.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejercicio_arbol_filogenetico.Infrastructure
{
    public class TreeFileReader
    {
        public List<Node> Read(string filePath)
        {
            var lines = File.ReadAllLines(filePath);

            return lines.Select(line =>
            {
                var parts = line.Split(',');

                return new Node
                {
                    Id = parts[0],
                    Name = parts[1]
                };
            }).ToList();
        }
    }
}
