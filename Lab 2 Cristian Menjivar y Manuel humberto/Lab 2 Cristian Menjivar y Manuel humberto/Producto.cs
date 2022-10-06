using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2_Cristian_Menjivar_y_Manuel_humberto
{
    internal class Producto
    {
        public int idProductos { get; set; }
        public string Marca { get; set; }

        public int Talla { get; set; }

        public string descripcion { get; set; }

        public string Categoria { get; set; }

        public double cantidad { get; set; }


        public double PrecioCompra { get; set; }

        public double PrecioVenta { get; set; }
    }
}
