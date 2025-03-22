using System;

// Clase Nodo para representar un nodo en el Árbol Binario de Búsqueda
class Nodo
{
    public string titulo;     // Título de la revista
    public Nodo izquierdo, derecho; // Punteros a los subárboles izquierdo y derecho

    // Constructor para inicializar el nodo con el título de la revista
    public Nodo(string valor)
    {
        titulo = valor;
        izquierdo = derecho = null;
    }
}

// Clase para el Árbol Binario de Búsqueda (ABB)
class ArbolBinarioBusqueda
{
    private Nodo raiz;  // Raíz del árbol

    // Constructor que inicializa el árbol vacío
    public ArbolBinarioBusqueda()
    {
        raiz = null;
    }

    // Método público para insertar un nuevo título de revista
    public void Insertar(string valor)
    {
        raiz = Insertar(raiz, valor);  // Llama al método recursivo de inserción
    }

    // Método recursivo para insertar el título de revista en la posición correcta
    private Nodo Insertar(Nodo nodo, string valor)
    {
        if (nodo == null)
            return new Nodo(valor);  // Si el nodo es nulo, se crea un nuevo nodo

        // Si el valor a insertar es menor que el nodo actual, se inserta en el subárbol izquierdo
        if (string.Compare(valor, nodo.titulo) < 0)
            nodo.izquierdo = Insertar(nodo.izquierdo, valor);
        // Si el valor a insertar es mayor o igual, se inserta en el subárbol derecho
        else if (string.Compare(valor, nodo.titulo) > 0)
            nodo.derecho = Insertar(nodo.derecho, valor);

        return nodo;  // Retorna el nodo actualizado
    }

    // Método público para mostrar los títulos de las revistas en orden (In-Order)
    public void MostrarInOrden()
    {
        MostrarInOrden(raiz);  // Llama al método recursivo para realizar el recorrido in-orden
        Console.WriteLine();
    }

    // Método recursivo para mostrar los títulos de las revistas en orden
    private void MostrarInOrden(Nodo nodo)
    {
        if (nodo != null)
        {
            MostrarInOrden(nodo.izquierdo);  // Muestra el subárbol izquierdo
            Console.Write(nodo.titulo + " ");  // Muestra el título del nodo
            MostrarInOrden(nodo.derecho);  // Muestra el subárbol derecho
        }
    }

    // Método público para buscar un título de revista en el árbol
    public bool Buscar(string valor)
    {
        return Buscar(raiz, valor);  // Llama al método recursivo de búsqueda
    }

    // Método recursivo para buscar un título de revista
    private bool Buscar(Nodo nodo, string valor)
    {
        if (nodo == null) return false;  // Si el nodo es nulo, no se encontró el título
        if (valor == nodo.titulo) return true;  // Si se encuentra el título, retorna verdadero

        // Busca en el subárbol izquierdo si el valor es menor que el nodo actual
        if (string.Compare(valor, nodo.titulo) < 0)
            return Buscar(nodo.izquierdo, valor);
        // Busca en el subárbol derecho si el valor es mayor
        else
            return Buscar(nodo.derecho, valor);
    }

    // Método para eliminar un título de revista
    public void Eliminar(string valor)
    {
        raiz = Eliminar(raiz, valor);  // Llama al método recursivo de eliminación
    }

    // Método recursivo para eliminar un nodo con un título específico
    private Nodo Eliminar(Nodo nodo, string valor)
    {
        if (nodo == null) return null;  // Si el nodo es nulo, no hay nada que eliminar

        // Si el valor a eliminar es menor que el nodo actual, lo buscamos en el subárbol izquierdo
        if (string.Compare(valor, nodo.titulo) < 0)
            nodo.izquierdo = Eliminar(nodo.izquierdo, valor);
        // Si el valor a eliminar es mayor que el nodo actual, lo buscamos en el subárbol derecho
        else if (string.Compare(valor, nodo.titulo) > 0)
            nodo.derecho = Eliminar(nodo.derecho, valor);
        else
        {
            // Si el nodo tiene un solo hijo o no tiene hijos, lo eliminamos directamente
            if (nodo.izquierdo == null) return nodo.derecho;
            if (nodo.derecho == null) return nodo.izquierdo;

            // Si el nodo tiene dos hijos, buscamos el sucesor (el nodo más pequeño en el subárbol derecho)
            Nodo sucesor = EncontrarMinimo(nodo.derecho);
            nodo.titulo = sucesor.titulo;  // Sustituimos el título del nodo por el del sucesor
            nodo.derecho = Eliminar(nodo.derecho, sucesor.titulo);  // Eliminamos el sucesor
        }

        return nodo;  // Retorna el nodo actualizado
    }

    // Método para encontrar el nodo con el título más pequeño en el subárbol derecho
    private Nodo EncontrarMinimo(Nodo nodo)
    {
        while (nodo.izquierdo != null)
            nodo = nodo.izquierdo;
        return nodo;
    }

    // Método que muestra el menú para interactuar con el árbol
    public void Menu()
    {
        Console.WriteLine("=== MENÚ DE REVISTAS ===");
        int opcion;

        do
        {
            // Muestra las opciones disponibles al usuario
            Console.WriteLine("\n1. Insertar una nueva revista");
            Console.WriteLine("2. Mostrar todas las revistas (In-Order)");
            Console.WriteLine("3. Buscar una revista");
            Console.WriteLine("4. Eliminar una revista");
            Console.WriteLine("0. Salir");
            Console.Write("Seleccione una opción: ");

            // Lee la opción del usuario
            if (!int.TryParse(Console.ReadLine(), out opcion))
            {
                Console.WriteLine("Entrada inválida. Intente nuevamente.");
                continue;
            }

            // Realiza la acción correspondiente según la opción seleccionada
            switch (opcion)
            {
                case 1:
                    Console.Write("Ingrese el título de la revista: ");
                    string valor = Console.ReadLine();  // Lee el título de la revista
                    Insertar(valor);  // Llama al método de inserción
                    break;

                case 2:
                    Console.WriteLine("Revistas en orden:");
                    MostrarInOrden();  // Muestra los títulos de las revistas en orden
                    break;

                case 3:
                    Console.Write("Ingrese el título de la revista a buscar: ");
                    string buscarValor = Console.ReadLine();  // Lee el título de la revista a buscar
                    if (Buscar(buscarValor))  // Llama al método de búsqueda
                        Console.WriteLine("Revista encontrada.");
                    else
                        Console.WriteLine("Revista no encontrada.");
                    break;

                case 4:
                    Console.Write("Ingrese el título de la revista a eliminar: ");
                    string eliminarValor = Console.ReadLine();  // Lee el título de la revista a eliminar
                    Eliminar(eliminarValor);  // Llama al método de eliminación
                    Console.WriteLine("Revista eliminada (si existía).");
                    break;

                case 0:
                    Console.WriteLine("Saliendo del programa.");
                    break;

                default:
                    Console.WriteLine("Opción no válida. Intente de nuevo.");
                    break;
            }

        } while (opcion != 0);  // Continúa hasta que el usuario elija salir
    }
}

// Programa principal para ejecutar el árbol
class Program
{
    static void Main()
    {
        ArbolBinarioBusqueda arbol = new ArbolBinarioBusqueda();  // Crea una instancia del árbol
        arbol.Menu();  // Llama al menú para interactuar con el usuario
    }
}
