  Provincias 

Trabajo en clase
================

#### [Archivo de Provincias (csv)](https://infra.datos.gob.ar/catalog/modernizacion/dataset/7/distribution/7.7/download/provincias.csv)

1.  Bajar el archivo de provincias del link anterior
2.  En la carpeta de descargas deberia quedar el archivo _provincias.csv_
3.  Mover el archivo recibido al escritorio
4.  Crear con Visual Studio un nuevo proyecto de consola y llamarlo _Provincias_
5.  _Program.cs_
    
        using System.Diagnostics.Contracts;
        using System.IO;
        using System.Text;
        
        namespace Provincias {
            class Program {
                public static void Main(string\[\] args) {
                    string escritorio = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                    string archivo = Path.Combine(escritorio,"provincias.csv");
                    string\[\] filas = {};
                    List provincias = new List();
        
                    try {
                        filas = File.ReadAllLines(archivo);
                    } catch (IOException ioe) {
                        Console.WriteLine($"Error abriendo archivo {archivo}");
                        Console.WriteLine(ioe.Message);
                        Environment.Exit(1);
                    }
        
                    int contador = 0;
                    foreach(string s in filas) {
                        if (contador == 0) {
                            contador = 1;
                            continue;
                        }
                        provincias.Add(new Provincia(s));
                    }
        
                    generarXml(escritorio, provincias);
                    generarJson(escritorio, provincias);
                    Environment.Exit(0);
                }
                static void generarXml(string escritorio, List provincias) {
                    string archivox = Path.Combine(escritorio, "Provincias.xml");
                    try {
                        if (File.Exists(archivox)) {
                            File.Delete(archivox);
                        }
                        StreamWriter sw = new StreamWriter(archivox);
                        StringBuilder sb = new StringBuilder();
                        sb.Append("");
                        foreach(Provincia p in provincias)
                            sb.Append(p.xml());
                        sb.Append("");
                        sw.Write(sb.ToString());
                        sw.Close();
                    } catch (IOException ioe) {
                        Console.WriteLine($"Error procesando archivo {archivox}");
                        Console.WriteLine(ioe.Message);
                    }
                }    
                static void generarJson(string escritorio, List provincias) {
                    string archivoj = Path.Combine(escritorio, "Provincias.json");
                    try {
                        if (File.Exists(archivoj)) {
                            File.Delete(archivoj);
                        }
                        StreamWriter sw = new StreamWriter(archivoj);
                        StringBuilder sb = new StringBuilder();
                        sb.Append("\[");
                        int contador = 0;
                        foreach(Provincia p in provincias) {
                            if (contador == 0) {
                                contador = 1;
                                sb.Append(p.json());
                                continue;
                            }
                            sb.Append($",{p.json()}");
                        }
                        sb.Append("\]");
                        sw.Write(sb.ToString());
                        sw.Close();
                    } catch (IOException ioe) {
                        Console.WriteLine($"Error procesando archivo {archivoj}");
                        Console.WriteLine(ioe.Message);
                    }
                }    
            }
        }            
            
    
6.  _Provincia.cs_
    
        using System.Text;
    
        namespace Provincias {
    
            public class Provincia {
                string categoria;
                float latitud;
                float longitud;
                string fuente;
                int id;
                string iso\_id;
                string iso\_nombre;
                string nombre;
                string nombre\_completo;
    
                public Provincia(string data) {
                    try {
                        string\[\] datos = data.Replace(@"""","").Split(',');
                        this.categoria = datos\[0\].Trim();
                        this.latitud = float.Parse(datos\[1\].Trim());
                        this.longitud = float.Parse(datos\[2\].Trim());
                        this.fuente = datos\[3\].Trim();
                        this.id = int.Parse(datos\[4\].Trim());
                        this.iso\_id = datos\[5\].Trim();
                        this.iso\_nombre = datos\[6\].Trim();
                        this.nombre = datos\[7\].Trim();
                        this.nombre\_completo = datos\[8\].Trim();
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
                    return this.nombre\_completo;
                }
    
                public string xml() {
                    StringBuilder sb = new StringBuilder();
                    sb.Append("");
                    sb.Append($"{this.categoria}");
                    sb.Append($"{this.latitud}");
                    sb.Append($"{this.longitud}");
                    sb.Append($"{this.id}");
                    sb.Append($"{this.iso\_id}");
                    sb.Append($"{this.iso\_nombre}");
                    sb.Append($"{this.nombre}");
                    sb.Append($"{this.nombre\_completo}");
                    sb.Append("");
                    return sb.ToString();
                }
                
                public string json() {
                    StringBuilder sb = new StringBuilder();
                    sb.Append("{");
                    sb.Append($"\\t\\"categoria\\": \\"{this.categoria}\\",");
                    sb.Append($"\\t\\"latitud\\": {this.latitud},");
                    sb.Append($"\\t\\"longitud\\": {this.longitud},");
                    sb.Append($"\\t\\"id\\": {this.id},");
                    sb.Append($"\\t\\"iso\_id\\": \\"{this.iso\_id}\\",");
                    sb.Append($"\\t\\"iso\_nombre\\": \\"{this.iso\_nombre}\\",");
                    sb.Append($"\\t\\"nombre\\": \\"{this.nombre}\\",");
                    sb.Append($"\\t\\"nombre\_completo\\": \\"{this.nombre\_completo}\\"");
                    sb.Append("}");
                    return sb.ToString();
                }
            }
        }
            
    
7.  Despues de ejecutar la aplicacion, en el escritorio, buscar los archivos:
    *   Provincias.html
    *   Provincias.jsony abrirlos con el block de notas (Notepad)
8.  [Aqui,](https://jsonlint.com/) pegamos el texto del archivo _Provincias.json_ y validamos que este todo bien
9.  Al archivo _Provincias.xml_ lo podemos abrir con el Chrome

* * *

Trabajo Practico
================

Desde [aqui,](https://infra.datos.gob.ar/catalog/modernizacion/dataset/7/distribution/7.10/download/localidades.csv) bajar el archivo de _Localidades_ y repetir lo hecho para las provincias.