using System;

// Programa de Árbol Binario de Búsqueda
class Nodo
{
public int dato;          // Dato almacenado en el nodo
public Nodo izquierdo;    // Puntero al subárbol izquierdo
public Nodo derecho;      // Puntero al subárbol derecho

// Constructor para inicializar un nuevo nodo
public Nodo(int valor)
{
dato = valor;
izquierdo = null;
derecho = null;
}
}

class ArbolBinarioBusqueda
{
private Nodo raiz;       // Raíz del árbol

// Constructor para inicializar el árbol
public ArbolBinarioBusqueda()
{
raiz = null;         // Inicialmente el árbol está vacío
}

// Método para insertar un nuevo valor en el árbol
public void Insertar(int valor)
{
raiz = Insertar(raiz, valor); // Llama al método de inserción recursiva
}

// Método recursivo para insertar el valor en la posición correcta
private Nodo Insertar(Nodo nodo, int valor)
{
// Si el nodo actual es nulo, se crea un nuevo nodo
if (nodo == null)
{
return new Nodo(valor); // Retorna el nuevo nodo
}

// Compara el valor a insertar con el nodo actual
if (valor < nodo.dato)
{
nodo.izquierdo = Insertar(nodo.izquierdo, valor); // Inserta en el subárbol izquierdo
}
else
{
nodo.derecho = Insertar(nodo.derecho, valor); // Inserta en el subárbol derecho
}

return nodo; // Retorna el nodo actualizado
}

// Método para mostrar los elementos del árbol en orden (In-Order)
public void MostrarInOrden()
{
MostrarInOrden(raiz); // Llama al método de recorrido in orden
Console.WriteLine(); // Nueva línea después de mostrar todos los elementos
}

// Método recursivo para realizar el recorrido in-orden
private void MostrarInOrden(Nodo nodo)
{
// Verifica si el nodo actual no es nulo
if (nodo != null)
{
MostrarInOrden(nodo.izquierdo); // Visita el subárbol izquierdo
Console.Write(nodo.dato + " "); // Muestra el valor del nodo
MostrarInOrden(nodo.derecho); // Visita el subárbol derecho
}
}

// Método para buscar un valor en el árbol
public bool Buscar(int valor)
{
return Buscar(raiz, valor); // Llama al método de búsqueda recursiva
}

// Método recursivo para buscar el valor
private bool Buscar(Nodo nodo, int valor)
{
// Si se llega a un nodo nulo, el valor no está en el árbol
if (nodo == null)
{
return false; // Valor no encontrado
}

// Compara el valor buscando con el nodo actual
if (valor == nodo.dato)
{
return true; // Valor encontrado
}

// Busca en el subárbol izquierdo o derecho según corresponda
if (valor < nodo.dato)
{
return Buscar(nodo.izquierdo, valor); // Busca en la izquierda
}
else
{
return Buscar(nodo.derecho, valor); // Busca en la derecha
}
}

// Método principal para ejecutar el programa
public void Menu()
{
// Muestra el título de la universidad al iniciar
Console.WriteLine(" UNIVERSIDAD ESTATAL AMAZONICA ");

int opcion; // Variable para almacenar la opción del menú

do
{
// Muestra las opciones disponibles al usuario
Console.WriteLine("1. Insertar un número"); // Opción para insertar número
Console.WriteLine("2. Mostrar números (In-Order)"); // Opción para mostrar números
Console.WriteLine("3. Buscar un número"); // Opción para buscar número
Console.WriteLine("0. Salir"); // Opción para salir
Console.Write("Seleccione una opción: ");
opcion = Convert.ToInt32(Console.ReadLine()); // Lee la opción del usuario

// Acción según la opción elegida
switch (opcion)
{
case 1:
Console.Write("Ingrese un número: ");
int valor = Convert.ToInt32(Console.ReadLine()); // Lee el número a insertar
Insertar(valor); // Llama al método de inserción
break;

case 2:
Console.WriteLine("Números en orden:");
MostrarInOrden(); // Muestra los números en orden
break;

case 3:
Console.Write("Ingrese el número a buscar: ");
int buscarValor = Convert.ToInt32(Console.ReadLine()); // Lee el número a buscar
if (Buscar(buscarValor)) // Llama al método de búsqueda
{
Console.WriteLine("Número encontrado."); // Mensaje si se encuentra el número
}
else
{
Console.WriteLine("Número no encontrado."); // Mensaje si no se encuentra el número
}
break;

case 0:
Console.WriteLine("Saliendo del programa."); // Mensaje de salida
break;

default:
Console.WriteLine("Opción no válida. Intente de nuevo."); // Manejo de opción no válida
break;
}

} while (opcion != 0); // Continúa hasta que el usuario elija salir
}
}

class Program
{
static void Main(string[] args)
{
ArbolBinarioBusqueda arbol = new ArbolBinarioBusqueda(); // Crea una instancia del árbol
arbol.Menu(); // Llama al menú para interactuar con el usuario
}
}