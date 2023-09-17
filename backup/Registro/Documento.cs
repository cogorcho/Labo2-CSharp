namespace Registro {
    internal class Documento {
        public string? Tipo { get; set; }
        public string? Numero { get; set; }

        public Documento() {}
        public Documento(string tipo, string numero) {
            this.Tipo = tipo;
            this.Numero = numero;
        }

        public override string ToString() {
            return $"Tipo: {Tipo}, Numero: {Numero}";
        }

        public string xml() {
            return @$"<documento><tipo>{Tipo}</tipo><numero>{Numero}</numero></documento>";
        }
    }
}