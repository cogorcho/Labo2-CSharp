# Reino Animal

Creacion de una aplicacion de consola aplicando conceptos de herencia.

En Visual Studio, crear una nueva aplicacion de consola llamada ReinoAnimal.
1. Agregar la clase Animal:
```
namespace ReinoAnimal {
    class Animal {
        public Animal() {
            Console.WriteLine("Construyendo un animal...");
        }

        public override string ToString() {
            return "Pertenezco al reino animal";
        }
    }
}
```
2. Agregar la clase Canino:
```
namespace ReinoAnimal {
    class Canino : Animal {
        public Canino() {
            Console.WriteLine("Construyendo un canino");
        }

        public override string ToString()
        {
            return $"{base.ToString()} y soy un canino";
        }
    }
}
```
3. Agregar la clase Lobo:
```
namespace ReinoAnimal {
    class Lobo : Canino {
        public Lobo() {
            Console.WriteLine("Construyendo un lobo");
        }
        public override string ToString()
        {
            return $"{base.ToString()} y soy un lobo";
        }
    }
}
```
4. Agregar la clase Zorro:
```
namespace ReinoAnimal {
    class Zorro : Canino {
        public Zorro() {
            Console.WriteLine("Construyendo un zorro");
        }
        public override string ToString()
        {
            return $"{base.ToString()} y soy un zorro";
        }
    }
}
```
5. Program.cs
```
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
```
En este punto, hacemos el analisis de los efectos de heredar.

6. Agregar la clase Perro:
```
A completar en clase
```
7. Agregar las clases Salchicha, Policia, Boxer.
```
A completar en clase
```