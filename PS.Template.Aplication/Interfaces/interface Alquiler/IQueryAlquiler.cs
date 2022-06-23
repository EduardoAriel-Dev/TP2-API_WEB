using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PS.Template.Domain.Models;

namespace PS.Template.Aplication.Interfaces.interface_Alquiler
{
    public interface IQueryAlquiler
    {
        public List<Alquileres> listAlquiler();
        public Alquileres getAlquileresByClientIsbn(int clienteId, string isbnId, int estadoAux);
        public List<Alquileres> ListAlquilerByEstadoCliente(int estado, int cliente);
        public List<Alquileres> ListaAlquiler();
    }
}
