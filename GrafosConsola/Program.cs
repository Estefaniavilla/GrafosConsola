using System;
using System.Collections.Generic;

class Grafo
{
    private Dictionary<string, List<string>> listaAdyacencia;

    public Grafo()
    {
        listaAdyacencia = new Dictionary<string, List<string>>();
    }

    
    public void AgregarNodo(string nodo)
    {
        if (!listaAdyacencia.ContainsKey(nodo))
        {
            listaAdyacencia[nodo] = new List<string>();
            Console.WriteLine($"Nodo '{nodo}' agregado.");
        }
        else
        {
            Console.WriteLine($"El nodo '{nodo}' ya existe.");
        }
    }

    public void AgregarArista(string origen, string destino)
    {
        if (listaAdyacencia.ContainsKey(origen) && listaAdyacencia.ContainsKey(destino))
        {
            listaAdyacencia[origen].Add(destino);
            listaAdyacencia[destino].Add(origen); 
            Console.WriteLine($"Arista agregada entre '{origen}' y '{destino}'.");
        }
        else
        {
            Console.WriteLine("Ambos nodos deben existir antes de agregar una arista.");
        }
    }

    
    public void MostrarGrafo()
    {
        Console.WriteLine("\nLista de Adyacencia:");
        foreach (var nodo in listaAdyacencia)
        {
            Console.Write($"{nodo.Key}: ");
            foreach (var adyacente in nodo.Value)
            {
                Console.Write($"{adyacente} ");
            }
            Console.WriteLine();
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Grafo grafo = new Grafo();
        int opcion;

        do
        {
            Console.WriteLine("\n--- Menú de Grafos ---");
            Console.WriteLine("1. Agregar Nodo");
            Console.WriteLine("2. Agregar Arista");
            Console.WriteLine("3. Mostrar Grafo");
            Console.WriteLine("4. Salir");
            Console.Write("Seleccione una opción: ");
            opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    Console.Write("Ingrese el nombre del nodo: ");
                    string nodo = Console.ReadLine();
                    grafo.AgregarNodo(nodo);
                    break;

                case 2:
                    Console.Write("Ingrese el nodo de origen: ");
                    string origen = Console.ReadLine();
                    Console.Write("Ingrese el nodo de destino: ");
                    string destino = Console.ReadLine();
                    grafo.AgregarArista(origen, destino);
                    break;

                case 3:
                    grafo.MostrarGrafo();
                    break;

                case 4:
                    Console.WriteLine("Saliendo...");
                    break;

                default:
                    Console.WriteLine("Opción inválida. Intente de nuevo.");
                    break;
            }
        } while (opcion != 4);
    }
}

