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