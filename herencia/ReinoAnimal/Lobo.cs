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