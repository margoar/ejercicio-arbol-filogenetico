# Ejercicio Árbol Filogenético

Aplicación de consola en C# (.NET 8) que arma un árbol filogenético a partir de un archivo de texto y muestra el subárbol de un nodo que elige el usuario.

## Cómo funciona

1. Lee las especies desde `Data/Input.txt`.
2. Arma el árbol: el padre de cada nodo se saca de su ID, cortando lo que viene después del último punto (por ejemplo, el padre de `1.2.3` es `1.2`).
3. Pide al usuario el ID de un nodo.
4. Muestra ese nodo y todos sus descendientes, con una sangría de 4 espacios por nivel.

## Estructura del proyecto

```
ejercicio-arbol-filogenetico/
├── ejercicio-arbol-filogenetico.sln
└── ejercicio-arbol-filogenetico/
    ├── Program.cs                     # Punto de entrada
    ├── Domain/
    │   └── Node.cs                    # Nodo: Id, Name y Children
    ├── Application/
    │   └── TreeService.cs             # Armado del árbol, búsqueda e impresión
    ├── Infrastructure/
    │   └── TreeFileReader.cs          # Lectura del archivo de entrada
    └── Data/
        └── Input.txt                  # Datos de ejemplo
```

| Capa | Clase | Qué hace |
|------|-------|----------|
| Domain | `Node` | Representa una especie con su ID, su nombre y sus hijos. |
| Application | `TreeService` | `BuildTree` conecta cada nodo con su padre, `FindNode` busca un nodo por ID y `PrintSubTree` imprime el subárbol de forma recursiva. |
| Infrastructure | `TreeFileReader` | Lee el archivo y crea un `Node` por cada línea. |

## Formato del archivo de entrada

Cada línea tiene la forma `ID,Nombre`:

```
1,Especie 1
1.1,Sub-Especie 1.1
1.1.1,Sub-Sub-Especie 1.1.1
2,Especie 2
```

- Los niveles del ID se separan con puntos.
- Las líneas pueden estar en cualquier orden.
- Los hijos se muestran en el mismo orden en que aparecen en el archivo.

## Requisitos

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)

## Cómo ejecutarlo

Desde la carpeta del proyecto:

```bash
cd ejercicio-arbol-filogenetico
dotnet run
```

También se puede abrir `ejercicio-arbol-filogenetico.sln` en Visual Studio y ejecutarlo con F5.

## Ejemplo

```
Ingrese el ID del nodo: 1.3
Sub-Especie 1.3
    Sub-Sub-Especie 1.3.1
    Sub-Sub-Especie 1.3.2
    Sub-Sub-Especie 1.3.3
    Sub-Sub-Especie 1.3.4
```

Si el ID no existe, se muestra:

```
Nodo no encontrado.
```

## Notas

- En `Program.cs` la ruta está escrita como `Data/input.txt` (con minúscula), pero el archivo se llama `Input.txt`. En Windows funciona igual, pero en Linux o macOS, donde se distinguen mayúsculas de minúsculas, no va a encontrar el archivo.
- La ruta es relativa, así que el programa tiene que ejecutarse desde una carpeta que contenga `Data/Input.txt`. Al compilar, el archivo se copia a la carpeta de salida.
