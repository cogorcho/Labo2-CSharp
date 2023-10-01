using System.Text;
using System.Text.Json;

namespace GeoAr {
    class Departamento {
        string categoria;
        double latitud;
        double longitud;
        string fuente;
        int id;
        string nombre;
        string nombre_completo;
        int provincia_id;
        double provincia_interseccion;
        string provincia_nombre;

        public int Id { get { return this.id; }}
        public string Nombre { get { return this.nombre; }}
        public int Provincia_id { get { return this.provincia_id; }}
        public double Latitud { get { return this.latitud; } }
        public double Longitud { get { return this.longitud; } }

        public Departamento(string data) {
            string[] datos = data.Replace("\"","").Split(',');
            this.categoria = datos[0].Trim();
            this.latitud = Double.Parse(datos[1].Trim());
            this.longitud = Double.Parse(datos[2].Trim());
            this.fuente = datos[3].Trim();
            this.id = int.Parse(datos[4].Trim());
            this.nombre = datos[5].Trim();
            this.nombre_completo = datos[6].Trim();
            this.provincia_id = int.Parse(datos[7].Trim());
            this.provincia_interseccion = Double.Parse(datos[8].Trim());
            this.provincia_nombre = datos[9].Trim();
        }

        public override string ToString() {
            return $"{this.id.ToString().PadLeft(6)} {this.nombre_completo} ({this.latitud},{this.longitud})";
        }
        public string xml() {
            StringBuilder sb = new StringBuilder();
            sb.Append("<departamento>");
            sb.Append($"<categoria>{this.categoria}</categoria>");
            sb.Append($"<latitud>{this.latitud}</latitud>");
            sb.Append($"<longitud>{this.longitud}</longitud>");
            sb.Append($"<fuente>{this.fuente}</fuente>");
            sb.Append($"<id>{this.id}</id>");
            sb.Append($"<nombre>{this.nombre}</nombre>");
            sb.Append($"<nombre_completo>{this.nombre_completo}</nombre_completo>");
            sb.Append($"<provincia_id>{this.provincia_id}</provincia_id>");
            sb.Append($"<provincia_interseccion>{this.provincia_interseccion}</provincia_interseccion>");
            sb.Append($"<provincia_nombre>{this.provincia_nombre}</provincia_nombre>");
            sb.Append("</departamento>");
            return sb.ToString();
        }
        public string json() {
            return JsonSerializer.Serialize(this);
        }
        public static List<Departamento> cargar_datos() {
            string archivo =  Path.Combine(Config.dir_datos, Config.url_departamentos.Split('/').Last());
            List<Departamento> departamentos = new List<Departamento>();
            foreach(string s in Archivo.cargar(archivo).Skip(1)) {
                departamentos.Add(new Departamento(s));
            }
            return departamentos;
        }
    }
}