namespace GeoAr {
    class Config {
        public static string dir_datos = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop),"GeoAr");
        public static string url_provincias = "https://infra.datos.gob.ar/catalog/modernizacion/dataset/7/distribution/7.7/download/provincias.csv";
        public static string url_departamentos = "https://infra.datos.gob.ar/catalog/modernizacion/dataset/7/distribution/7.8/download/departamentos.csv";
        public static string url_localidades = "https://infra.datos.gob.ar/catalog/modernizacion/dataset/7/distribution/7.10/download/localidades.csv";
        public static string destino_datos = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
    }
}