using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiPC
{
    class Menu
    {
        String[] opciones =
        {
            " 1. Discos",
            " 2. Video",
            " 3. Procesador",
            " 4. Sistema Operativo",
            " 5. Interfaces de Red",
            " 6. Dirección IP",
            " 7. Audio",
            " 8. Procesos",
            " 9. Placa Madre",
            "10. Memoria RAM",
            "11. Compu",
            "12. Startup Command",
            "13. Logical Program Group",
            " 0. Salir"
        };


        // Constructor; Crea objetos de la clase.
        public Menu()
        {
            // Constructor vacio

        }

        private void pausa()
        {
            Console.Write(String.Format("\n\tPulse Enter: "));
            Console.ReadKey();
        }

        private void pausa(String mensaje)
        {
            Console.Write(String.Format("\n\t{0}. Pulse Enter", mensaje));
            Console.ReadKey();
        }

        public void ejecutar()
        {
            while (true)
            {
                int opc;
                Console.Clear();
                Console.Write(this.encabezado());
                this.mostrarOpciones();

                if (int.TryParse(this.seleccion(), out opc))
                {
                    if (opc == 0)
                    {
                        break;
                    }
                    else if (opc >= 1 && opc <= 13)
                    {
                        this.activarOpcion(opc);
                    }
                    else
                    {
                        pausa("Opcion Inválida.");
                    }
                }
                else
                {
                    pausa("Opcion Inválida.");
                }
            }
        }

        private void activarOpcion(int opc)
        {
            Console.WriteLine("\t\t\t{0} es la opcion elegida", opc);
            switch (opc)
            {
                case 1:
                    {
                        Disco d = new Disco();
                        d.mostrar();
                        break;
                    }
                case 2:
                    {
                        Video video = new Video();
                        video.mostrar();
                        break;
                    }
                case 3:
                    {
                        Cpu cpu = new Cpu();
                        cpu.mostrar();
                        break;
                    }
                case 4:
                    {
                        Os os = new Os();
                        os.mostrar();
                        break;
                    }
                case 5:
                    {
                        Nw nw = new Nw();
                        nw.mostrar();
                        break;
                    }
                case 6:
                    {
                        Ip ip = new Ip();
                        ip.mostrar();
                        break;
                    }
                case 7:
                    {
                        Audio audio = new Audio();
                        audio.mostrar();
                        break;
                    }
                case 8:
                    {
                        Proceso proceso = new Proceso();
                        proceso.mostrar();
                        break;
                    }
                case 9:
                    {
                        Mother mother = new Mother();
                        mother.mostrar();
                        break;
                    }
                case 10:
                    {
                        Ram ram = new Ram();
                        ram.mostrar();
                        break;
                    }
                case 11:
                    {
                        Compu compu = new Compu();
                        compu.mostrar();
                        break;
                    }
                case 12:
                    {
                        Startup startup = new Startup();
                        startup.mostrar();
                        break;
                    }
                case 13:
                    {
                        Lpg lpg = new Lpg();
                        lpg.mostrar();
                        break;
                    }
            }
        }
        private String seleccion()
        {
            String mensaje = String.Format("{0}\t\t\tIngrese su opción: ", Environment.NewLine);
            Console.Write(mensaje);
            return Console.ReadLine();
        }

        private void mostrarOpciones()
        {
            foreach (String opcion in this.opciones)
            {
                String opc = String.Format("\t\t\t{0}{1}", opcion, Environment.NewLine);
                Console.Write(opc);
            }
        }

        private String linea()
        {
            return "\t\t# -------------------------------------------";
        }

        private String titulo()
        {
            return String.Format("{0}\t\t#\tMenú de Opciones de Mi PC{1}",
                Environment.NewLine, Environment.NewLine);
        }

        private String encabezado()
        {
            return String.Format("{0}{1}{2}{3}{4}{5}{6}",
                Environment.NewLine,
                Environment.NewLine,
                Environment.NewLine,
                this.linea(),
                this.titulo(),
                this.linea(),
                Environment.NewLine);
        }
     }
}

