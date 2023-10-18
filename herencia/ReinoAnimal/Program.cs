using System.Diagnostics.Contracts;
using System.Reflection;

namespace ReinoAnimal
{
    public class Program {
        public static void Main(string[] args) {
            Animal animal = new Animal();
            Console.WriteLine(animal);
            Canino canino = new Canino();
            Console.WriteLine(canino);
            Lobo lobo = new Lobo();
            Console.WriteLine(lobo);
            Zorro zorro = new Zorro();
            Console.WriteLine(zorro);
            Animal zorrito = new Zorro();
            Console.WriteLine(zorrito);
        }
    }
}
