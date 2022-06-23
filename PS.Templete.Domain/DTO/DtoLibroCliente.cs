using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.Template.Domain.DTO
{
    public class DtoLibroCliente
    {
        public string ISBN { get; set; }
        public string Titulo { get; set; }
        public int Stock { get; set; }
        public int cantidad { get; set; }
    }
}
