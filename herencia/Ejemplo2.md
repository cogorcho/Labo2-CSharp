# Herencia en C#

## Ejemplo: Personas

Crear un programa en C# que pida tres nombres de personas al usuario y los guarde en un array de objetos de tipo Persona. Habrán dos personas de tipo Estudiante y una persona de tipo Profesor.

Crear una clase Persona que tenga una propiedad Nombre de tipo string, un constructor que reciba el nombre como parámetro y sobrescriba el método ToString().

Después crear dos clases más que hereden de la clase Persona, se llamarán Estudiante y Profesor. La clase Estudiante tiene un método Estudiar que escribe por consola que el estudiante está estudiando. La clase Profesor tendrá un método Explicar que escribe en consola que el profesor está explicando. 

Crear además dos constructores en las clases hijas que llamen al constructor padre de la clase Persona.

Finalizar el programa leyendo las personas (el profesor y los alumnos) y ejecutar los métodos de Explicar y Estudiar.

Información extra:
- [Property](https://learn.microsoft.com/es-es/dotnet/csharp/programming-guide/classes-and-structs/properties)
- [Destructor](https://learn.microsoft.com/es-es/dotnet/csharp/programming-guide/classes-and-structs/finalizers)
- [Constructores y destructores](https://csharp.net-tutorials.com/es/118/clases/constructores-y-destructores/)
- [Herencia](https://www.udb.edu.sv/udb_files/recursos_guias/informatica-ingenieria/programacion-orientada-a-objetos-(ing)/2019/ii/guia-8.pdf)
- [Modificadores de acceso: public, private, protected y mas...](https://learn.microsoft.com/es-es/dotnet/csharp/language-reference/keywords/access-modifiers)
- [Assembly (Ensamblados)](https://learn.microsoft.com/es-es/dotnet/standard/assembly/)
- [.NET: Información Importante](https://dotnet.microsoft.com/es-es/learn/dotnet/what-is-dotnet-framework#:~:text=NET%20Framework%20se%20escriben%20en,Lenguaje%20intermedio%20com%C3%BAn%20(CIL).)
- [Interfaz gráfica cn C#](https://www.youtube.com/watch?v=lY1Z0Hgo288)

## Entrada
1. Juan
2. Sara
3. Carlos


## Salida
1. Explicar
2. Estudiar
3. Estudiar

```
using System;

namespace Ejemplo2 {

    public class HerenciaObjetos
    {
        public static void Main(string[] args)
        {
            int total = 3;
            Persona[] personas = new Persona[total];
    
            for (int i = 0; i < total; i++)
            {
                if (i == 0)
                {
                    personas[i] = new Profesor(Console.ReadLine());
                }
                else
                {
                    personas[i] = new Estudiante(Console.ReadLine());
                }
            }
    
            for (int i = 0; i < total; i++)
            {
                if (i == 0)
                {
                    ((Profesor)personas[i]).Explicar();
    
                }
                else
                {
                    ((Estudiante)personas[i]).Estudiar();
                }
            }
        }
    
        public class Persona
        {
            protected string Nombre { get; set; }
    
            public Persona(string nombre)
            {
                Nombre = nombre;
            }
    
            public override string ToString()
            {
                return "Hola! Mi nombre es " + Nombre;
            }
    
            ~Persona()
            {
                Nombre = string.Empty;
            }
        }
    
        public class Profesor : Persona
        {
            public Profesor(string nombre) : base(nombre)
            {
                Nombre = nombre;
            }
    
            public void Explicar()
            {
                Console.WriteLine("Explicar");
            }
        }
    
        public class Estudiante : Persona
        {
            public Estudiante(string nombre) : base(nombre)
            {
                Nombre = nombre;
            }
    
            public void Estudiar()
            {
                Console.WriteLine("Estudiar");
            }
        }
    }
}

```