using System.Text;

namespace Provincias {

    public class Provincia {
        string categoria;
        float latitud;
        float longitud;
        string fuente;
        int id;
        string iso_id;
        string iso_nombre;
        string nombre;
        string nombre_completo;

        public Provincia(string data) {
            try {
                string[] datos = data.Replace(@"""","").Split(',');
                this.categoria = datos[0].Trim();
                this.latitud = float.Parse(datos[1].Trim());
                this.longitud = float.Parse(datos[2].Trim());
                this.fuente = datos[3].Trim();
                this.id = int.Parse(datos[4].Trim());
                this.iso_id = datos[5].Trim();
                this.iso_nombre = datos[6].Trim();
                this.nombre = datos[7].Trim();
                this.nombre_completo = datos[8].Trim();
           }
           catch (Exception e) {
                Console.WriteLine("Error procesando linea dela archivo");
                Console.WriteLine(data);
                Console.WriteLine(e.Message);
                return;
           }
        }

        public override string ToString()
        {
            return this.nombre_completo;
        }

        public string xml() {
            StringBuilder sb = new StringBuilder();
            sb.Append("<provincia>");
            sb.Append($"<categoria>{this.categoria}</categoria>");
            sb.Append($"<latitud>{this.latitud}</latitud>");
            sb.Append($"<longitud>{this.longitud}</longitud>");
            sb.Append($"<id>{this.id}</id>");
            sb.Append($"<iso_id>{this.iso_id}</iso_id>");
            sb.Append($"<iso_nombre>{this.iso_nombre}</iso_nombre>");
            sb.Append($"<nombre>{this.nombre}</nombre>");
            sb.Append($"<nombre_completo>{this.nombre_completo}</nombre_completo>");
            sb.Append("</provincia>");
            return sb.ToString();
        }
        
        public string json() {
            StringBuilder sb = new StringBuilder();
            sb.Append("{");
            sb.Append($"\t\"categoria\": \"{this.categoria}\",");
            sb.Append($"\t\"latitud\": {this.latitud},");
            sb.Append($"\t\"longitud\": {this.longitud},");
            sb.Append($"\t\"id\": {this.id},");
            sb.Append($"\t\"iso_id\": \"{this.iso_id}\",");
            sb.Append($"\t\"iso_nombre\": \"{this.iso_nombre}\",");
            sb.Append($"\t\"nombre\": \"{this.nombre}\",");
            sb.Append($"\t\"nombre_completo\": \"{this.nombre_completo}\"");
            sb.Append("}");
            return sb.ToString();
        }
    }
}