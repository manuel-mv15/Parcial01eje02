using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Parcial01eje02
{
    internal class Program
    {

        static void Main(string[] args)
        {
            List<Tarea> tareas = new List<Tarea>(); // lista de la tareas
            
            int menu = 0; // variable para obtener que quiere hacer el usuario
            string nombre = ""; // variable para obtener el nombre de la tarea
            string dia = ""; // variable para obtener el dia de la tarea
            string priodidad = ""; // variable para obtener la prioridad de la tarea

            do
            {
                // menu 
                Console.WriteLine("Menu");
                Console.WriteLine("1. agregar una tarea");
                Console.WriteLine("2. eliminar una tarea");
                Console.WriteLine("3. mostrar tareas");
                Console.WriteLine("4, mostrar todas las tareas");
                Console.WriteLine("5. salir");

                menu = validar(1, 5); // llamamos al metodo validar y obtenemos el dato 


                if (menu == 1)// opcion 1 del menu
                {
                    // optenemos todos los datos
                    Console.WriteLine("Nombre de la tarea");
                    nombre = Console.ReadLine();


                    Console.WriteLine("Dia de la tarea");
                    dias(); // mostramos los dias
                    dia = Enum.GetName(typeof(DiasSemana), validar(1, 7)); // del enum optenemos el dia dado el indice de este mismo
                    
                    
                    Console.WriteLine("Prioridad de la tarea");
                    Priorida();
                    priodidad = Enum.GetName(typeof(Prioridad), validar(1, 3)); // del enum optenemos la prioridad dado el indice de este mismo
                    
                    tareas.Add(new Tarea(nombre, dia, priodidad)); // agregamos la tarea atraves del constructor

                }
                else if (menu == 2) // opcion 2 del menu
                {
                    var tarea = new Tarea();
                    bool tareaExiste = false;
                    Console.WriteLine("Desea ver las tareas antes");
                    Console.WriteLine("1. si\n2. no");
                    if (validar(1, 2) == 1)
                    {
                        mostrar(tareas);
                    }
                    Console.WriteLine("Ingrese nombre de la tarea");
                    nombre = Console.ReadLine();
                    foreach (var tar in tareas)
                    {

                        if (nombre.Equals(tar.Getdia()))
                        {
                            tarea = tar;
                            tareaExiste = true;
                        }

                    }

                    if (tareaExiste)
                    {
                        tareas.Remove(tarea);
                    }
                    else
                    {
                        Console.WriteLine("Tarea no encontrada");

                    }

                }
                else if (menu == 3)
                {
                    mostrar(tareas);
                }
                else if (menu == 4)
                {

                    Console.WriteLine("Dia de la tarea");
                    dias();
                    dia = Enum.GetName(typeof(DiasSemana), validar(1, 7));

                    mostrar(tareas, dia);
                }
            } while (menu != 5);

        }
        
        static int validar(int min, int max)
        {
            int numero = 0;

            while (!int.TryParse(Console.ReadLine(), out numero) || !(numero >= min && numero <= max))
            {
                Console.WriteLine($"Ingrese un numero valido entre {min} y {max}");
            }
            return numero;
        }

        static void mostrar(List<Tarea> tareas)
        {
            foreach (var tar in tareas)
            {
                Console.WriteLine(tar.ToString());
            }
        }
        static void mostrar(List<Tarea> tareas, string dia)
        {
            foreach (var tar in tareas)
            {
                if (tar.ToString().Contains(dia))
                {
                    Console.WriteLine(tar.ToString());
                }
            }
        }

        enum DiasSemana
        {
            lunes = 1,
            martes,
            miercoles,
            jueves,
            viernes,
            sabado,
            domingo
        }
        enum Prioridad
        {
            alta = 1,
            media,
            baja
        }
        static public void dias()
        {
            foreach (DiasSemana dia in Enum.GetValues(typeof(DiasSemana)))
            {
                Console.WriteLine($"{(int)dia}. {dia}");
            }

        }
        static public void Priorida()
        {
            foreach (Prioridad pri in Enum.GetValues(typeof(Prioridad)))
            {
                Console.WriteLine($"{(int)pri}. {pri}");
            }
        }
    }

}
