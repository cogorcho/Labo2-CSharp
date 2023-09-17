﻿using System;

namespace EJ3 // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            foreach(String s in args) {
                if (s.Equals("uno")) {
                    funcion1();
                }
                else if (s.Equals("dos")) {
                    funcion2();
                }
                else if (s.Equals("tres")) {
                    funcion3();
                }
                else {
                    Console.WriteLine("La funcion {0} no existe!", s);
                }                
            }
        }

        static void funcion1() {
            Console.WriteLine("Soy la funcion uno");
        }
        static void funcion2() {
            Console.WriteLine("Soy la funcion dos");
        }
        static void funcion3() {
            Console.WriteLine("Soy la funcion tres");
        }
    }
}