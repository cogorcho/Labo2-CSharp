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