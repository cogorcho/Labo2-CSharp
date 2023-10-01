
using System.Text;
using System.Text.Json;

namespace GeoAr {
    class Localidad {
        string categoria;
        double latitud;
        double longitud;
        double departamento_id;
        string departamento_nombre;
        string fuente;
        double id;
        string localidad_censal_id;
        string localidad_censal_nombre;
        string municipio_id;
        string municipio_nombre;
        string nombre;
        int provincia_id;
        string provincia_nombre;

        public double Id { get { return this.id; }}
        public string Nombre { get { return this.nombre; }}
        public double Departamento_id { get { return this.departamento_id; }}
        public double Latitud { get { return this.latitud; } }
        public double Longitud { get { return this.longitud; } }
        public Localidad(string data) {
            string[] datos = data.Replace("\"","").Split(',');
            try {
                this.categoria = datos[0].Trim();
                this.latitud = Double.Parse(datos[1].Trim());
                this.longitud = Double.Parse(datos[2].Trim());
                this.departamento_id = Double.Parse(datos[3].Trim());
                this.departamento_nombre = datos[4].Trim();
                this.fuente = datos[5].Trim();
                this.id = Double.Parse(datos[6].Trim());
                this.localidad_censal_id = datos[7].Trim();
                this.localidad_censal_nombre = datos[8].Trim();
                this.municipio_id = datos[9].Trim();
                this.municipio_nombre = datos[10].Trim();
                this.nombre = datos[11].Trim();
                this.provincia_id = int.Parse(datos[12].Trim());
                this.provincia_nombre = datos[13].Trim();
            }
            catch(Exception e) {
                TextWriter errorWriter = Console.Error;
                errorWriter.WriteLine($"Error procesando linea: {datos.Length}");
                errorWriter.WriteLine(data);
                errorWriter.WriteLine(e.Message);
            }
        }
        public override string ToString() {
            return $"{this.id.ToString().PadLeft(8)} {this.nombre} ({this.latitud},{this.longitud})";
        }

        public string xml() {
            StringBuilder sb = new StringBuilder();
            sb.Append("<localidad>");
            sb.Append($"<categoria>{this.categoria}</categoria>");
            sb.Append($"<latitud>{this.latitud}</latitud>");
            sb.Append($"<longitud>{this.longitud}</longitud>");
            sb.Append($"<departamento_id>{this.departamento_id}</departamento_id>");
            sb.Append($"<departamento_nombre>{this.categoria}</departamento_nombre>");
            sb.Append($"<fuente>{this.fuente}</fuente>");
            sb.Append($"<id>{this.id}</id>");
            sb.Append($"<localidad_censal_id>{this.localidad_censal_id}</localidad_censal_id>");
            sb.Append($"<localidad_censal_nombre>{this.localidad_censal_nombre}</localidad_censal_nombre>");
            sb.Append($"<municipio_id>{this.municipio_id}</municipio_id>");
            sb.Append($"<municipio_nombre>{this.municipio_nombre}</municipio_nombre>");
            sb.Append($"<nombre>{this.nombre}</nombre>");
            sb.Append($"<provincia_id>{this.provincia_id}</provincia_id>");
            sb.Append($"<provincia_nombre>{this.provincia_nombre}</provincia_nombre>");
            sb.Append("</localidad>");
            return sb.ToString();
        }
        public string json() {
            return JsonSerializer.Serialize(this);
        }
        public static List<Localidad> cargar_datos() {
            string archivo =  Path.Combine(Config.destino_datos, Config.url_localidades.Split('/').Last());
            List<Localidad> localidades = new List<Localidad>();
            foreach(string s in Archivo.cargar(archivo).Skip(1)) {
                localidades.Add(new Localidad(s));
            }
            return localidades;            
        }
    }
}