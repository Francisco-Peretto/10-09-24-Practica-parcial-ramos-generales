using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10_09_24_Practica_parcial_ramos_generales
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Negocio negocio = new Negocio();
            negocio.llenarListaDeProductos();

            negocio.GenerarReporteProductos();
            Console.ReadKey();
        }
    }
}
