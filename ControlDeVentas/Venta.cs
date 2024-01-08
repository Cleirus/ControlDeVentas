using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDeVentas
{
    internal class Venta
    {
        private string _Producto;
        private int _Cantidad;

        public int Cantidad
        {
            get { return _Cantidad; }
            set { _Cantidad = value; }
        }


        public string Producto
        {
            get { return _Producto; }
            set { _Producto = value; }
        }

        //Asignacion de precio de productos
        public double AsignarPrecio()
        {
            switch (Producto)
            {
                case "Charola": return 30;
                case "Vaso": return 22;
                case "Cuchara": return 10;
                case "Tenedor": return 14;
                case "Servilletas": return 24;

            }
            return 0;
        }
        //CaculaSubtotal
        public double CalcularSubtotal() 
        {
            return AsignarPrecio() * Cantidad;
        }

        //Calcular descuento
        public double CalcularDescuento() 
        {
            double subtotal = CalcularSubtotal();
            if (subtotal <= 300)
            {
                return 5.0 / 100 * subtotal;
            }
            else if (subtotal >= 300 && subtotal <= 500)
            {
                return 10.0 / 100 * subtotal;
            }
            else 
            {
                return 12.5 / 100 * subtotal;
            }
            
        }

        //Calcular Neto
        public double CalcularNeto() 
        {
            return CalcularSubtotal() - CalcularDescuento();
        }
    }
}
