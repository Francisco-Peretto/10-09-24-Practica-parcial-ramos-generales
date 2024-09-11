using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10_09_24_Practica_parcial_ramos_generales
{
    internal class Producto
    {
        private int _codigo;
        private string _rubro;
        private string _descripcion;
        private float _costo;
        private float _ganancia;
        private float _precio;

        public Producto(int _codigo, string _rubro, string _descripcion, float _costo, float _ganancia)
        {
            this.Codigo = _codigo;
            this.Rubro = _rubro;
            this.Descripcion = _descripcion;
            this.Costo = _costo;
            this.Ganancia = _ganancia;
        }

        public int Codigo
        {
            get { return this._codigo; }
            set { this._codigo = value; }
        }

        public string Rubro
        {
            get { return this._rubro; }
            set { this._rubro = value; }
        }

        public string Descripcion
        {
            get { return this._descripcion; }
            set { this._descripcion = value; }

        }

        public float Costo
        {
            get { return this._costo; }
            set { this._costo = value; }
        }
        public float Ganancia
        {
            get { return this._ganancia; }
            set { this._ganancia = value; }
        }

        public float Precio
        {
            get { return (this.Costo + (this.Costo * this.Ganancia) / 100); }
        }

        public void MostrarDatosProducto()
        {
            Console.WriteLine($"Codigo: {this.Codigo} | Rubro: {this.Rubro} | Descripción: {this.Descripcion} | Costo: ${this.Costo} | Ganancia: ${this.Ganancia} | Precio: ${this.Precio} ");
        }
    }
}
