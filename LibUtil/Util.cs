namespace LibUtil;
public class Util
{
    private static void pedirCampo(string campo) {
        Console.Write($"\nIngrese un valor para {campo}: ");
    }

    private static void debeIngresar(string campo) {
        Console.WriteLine($"Debe ingresar un valor para {campo}");
    }

    private static void huboError(string campo) {
        Console.WriteLine($"\nError ingresando valor para {campo}");
    }
    private static void mensajeException(string mensaje) {
        Console.WriteLine(mensaje);
    }

    public static Boolean confirmaSN(string mensaje="S/N?") {
        Boolean valor = false;
        while(true) {
            Console.Write($"Confirma {mensaje}: ");
            try {
                ConsoleKeyInfo cki = Console.ReadKey();
                if (cki.Key.ToString().ToUpper() == "S")
                    valor = true;
                else if (cki.Key.ToString().ToUpper() == "N")
                    valor = false;
                else {
                     huboError($"Confirmación (S/N): {cki.Key.ToString()}");
                     continue;
                }
                break;
            }
            catch(Exception e) {
                huboError("Confirmación (S/N)");
                mensajeException(e.Message);
            }
        }
        return valor;
    } 
    public static string getString(string campo, Boolean nada=false) {
        string str = "";
        while (true) {
            try {
                pedirCampo(campo);
                str = Console.ReadLine();
                if (str.Length == 0 && nada) {
                    debeIngresar(campo);
                }
                else {
                    break;
                }
            } catch(Exception e) {
                huboError(campo);
                mensajeException(e.Message);
            }
        }
        return str;
    }

    public static int getInt(string campo, 
            Boolean positivo=true,
            Boolean cero=true,
            Boolean negativo=true) 
    {
        int valor;
        Boolean chequeo;
        while (true) {
            pedirCampo(campo);
            try {
                String entero = Console.ReadLine();
                chequeo = Int32.TryParse(entero, out valor);
                if (!chequeo) {
                    huboError($"{campo}: {entero} no se pudo convertir a entero");
                }
                else if (valor > 0 && positivo)
                        break;
                else if (valor == 0 && cero) 
                        break;
                else if (valor < 0 && negativo)
                        break;
                else 
                    Console.WriteLine($"El valor ingresado {valor} no cumple lo solicitado");
            } catch(Exception e) {
                Console.WriteLine($"Error ingresando valor para {campo}");
                Console.WriteLine(e.Message);
            }
        }
        return valor;
    }

    public static DateOnly getFecha(string campo) {
        DateOnly fecha;
        String str = "";
        String formato = "dd/mm/aaaa";
        int dia, mes, anio;
        while (true) {
            try {
                pedirCampo($"{campo}: {formato}");
                str = Console.ReadLine();
                string[] partesDeFecha = str.Split('/');

                if (partesDeFecha.Length != 3) {
                    huboError($"{campo}: {str} no cumple el formato {formato}");
                    continue;
                }

                Int32.TryParse(partesDeFecha[1], out mes);
                if (mes < 1 || mes > 12) {
                    huboError($"El mes es incorrecto: {mes}");
                    continue;
                }
                Int32.TryParse(partesDeFecha[0], out dia);
                if (dia < 1 || dia > 31) {
                    huboError($"El día es incorrecto: {dia}");
                    continue;
                }
                Int32.TryParse(partesDeFecha[2], out anio);
                if (anio < 0) {
                    huboError($"El año es incorrecto: {anio}");
                    continue;
                }

                fecha = new DateOnly(anio,mes,dia);
                break;
            } catch(Exception e) {
                Console.WriteLine("Error ingresando valor para {campo}: {str} con formato {formato}");
                Console.WriteLine(e.Message);
            }
        }
        return fecha;
    } 
}
