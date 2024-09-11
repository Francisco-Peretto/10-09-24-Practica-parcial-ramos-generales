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
        private float _cantidadProductos;
        private float _promedioPrecios;
        private float productosLibreria;
        private float productosFerreteria;
        private float productosElectronica;
        private float productosKiosco;
        private float acLibreria;
        private float acFerreteria;
        private float acElectronica;
        private float acKiosco;

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
            get {
                foreach (Producto producto in this.listaProductos)
                    {
                    this._promedioPrecios += producto.Precio;
                    }
                return this._promedioPrecios / this.CantidadProductos;
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
            Console.WriteLine("\nInventario de productos:\n");

            foreach (Producto producto in this.listaProductos)
            {
                producto.MostrarDatosProducto();
                if (producto.Rubro == "Libreria")
                {
                    productosLibreria++;
                    acLibreria += producto.Precio;
                }
                else if (producto.Rubro == "Ferreteria")
                {
                    productosFerreteria++;
                    acFerreteria += producto.Precio;
                }
                else if (producto.Rubro == "Electronica")
                {
                    productosElectronica++;
                    acElectronica += producto.Precio;
                }
                else
                {
                    productosKiosco++;
                    acKiosco += producto.Precio;
                }
            }
            Console.WriteLine("\nReporte de artículos:");
            Console.WriteLine($"Cantidad de artículos de libreria: {acLibreria}. Promedio de precio unitario: ${productosLibreria / acLibreria}");
            Console.WriteLine($"Cantidad de artículos de ferretería: {acFerreteria}. Promedio de precio unitario: ${productosFerreteria / acFerreteria}");
            Console.WriteLine($"Cantidad de artículos de electrónica: {acElectronica}. Promedio de precio unitario: ${productosElectronica / acElectronica}");
            Console.WriteLine($"Cantidad de artículos de kiosco: {acKiosco}. Promedio de precio unitario: ${productosKiosco / acKiosco}");
            Console.WriteLine("Precio promedio de todos los productos: " + (acLibreria + acFerreteria + acElectronica + acKiosco) /CantidadProductos);

        }
    }

    

}
