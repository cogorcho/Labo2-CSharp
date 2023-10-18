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