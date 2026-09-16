using ejercicio_arbol_filogenetico.Application;
using ejercicio_arbol_filogenetico.Infrastructure;

var fileReader = new TreeFileReader();
var treeService = new TreeService();

var nodes = fileReader.Read("Data/Input.txt");

treeService.BuildTree(nodes);

Console.Write("Ingrese el ID del nodo: ");
var nodeId = Console.ReadLine();

var node = treeService.FindNode(nodes, nodeId!);

if (node != null)
{
    treeService.PrintSubTree(node);
}
else
{
    Console.WriteLine("Nodo no encontrado.");
}