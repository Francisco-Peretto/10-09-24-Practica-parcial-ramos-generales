using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10_09_24_Practica_parcial_ramos_generales
{
    internal class Negocio
    {
        private List<Producto> listaProductos;
        private float _promedioPrecios;
        // private float _cantidadProductos;

        public Negocio()
        {
            this.listaProductos = new List<Producto>();
        }

        public float CantidadProductos
            {
            get { return listaProductos.Count; }
            }

        public float PromedioPrecios
        {
            get 
            {
                float total = 0;
                foreach (Producto producto in this.listaProductos)
                    {
                    total += producto.Precio;
                    }
                return total / this.CantidadProductos;
            }
        }

        public void llenarListaDeProductos()
        {
            listaProductos.Clear();
            FileStream Archivo;
            StreamReader leer;
            Archivo = new FileStream("productos.txt", FileMode.Open);
            leer = new StreamReader(Archivo);

            while (leer.EndOfStream == false)
            {
                string cadena = leer.ReadLine(); string[] datos = cadena.Split(';');
                Producto producto = new Producto(int.Parse(datos[0]), datos[1], (datos[2]), float.Parse(datos[3]), float.Parse(datos[4]));
                listaProductos.Add(producto);
            }
            leer.Close();
            Archivo.Close();
        }

        public void GenerarReporteProductos()
        {
            float productosLibreria = 0;
            float productosFerreteria = 0;
            float productosElectronica = 0;
            float productosKiosco = 0;
            float acLibreria = 0;
            float acFerreteria = 0;
            float acElectronica = 0;
            float acKiosco = 0;
        Console.WriteLine("\nInventario de productos:\n");

            foreach (Producto producto in this.listaProductos)
            {
                producto.MostrarDatosProducto();
                switch (producto.Rubro)
                {
                    case "Libreria":
                        productosLibreria++;
                        acLibreria += producto.Precio;
                        break;
                    case "Ferreteria":
                        productosFerreteria++;
                        acFerreteria += producto.Precio;
                        break;
                    case "Electronica":
                        productosElectronica++;
                        acElectronica += producto.Precio;
                        break;
                    case "Kiosco":
                        productosKiosco++;
                        acKiosco += producto.Precio;
                        break;
                }
            }
            Console.WriteLine("\nReporte de productos:");
            Console.WriteLine($"Cantidad de productos de libreria: {productosLibreria}. Promedio del precio de la categoría: ${acLibreria /productosLibreria:F2}");
            Console.WriteLine($"Cantidad de productos de ferretería: {productosFerreteria}. Promedio del precio de la categoría: ${acFerreteria / productosFerreteria:F2}");
            Console.WriteLine($"Cantidad de productos de electrónica: {productosElectronica}. Promedio del precio de la categoría: ${acElectronica / productosElectronica:F2}");
            Console.WriteLine($"Cantidad de productos de kiosco: {productosKiosco}. Promedio del precio de la categoría: ${acKiosco / productosKiosco:F2}");
            Console.WriteLine("Precio promedio de todos los productos: $" + PromedioPrecios.ToString("F2"));
        }
    }
}
