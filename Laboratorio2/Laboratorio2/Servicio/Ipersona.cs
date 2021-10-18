using Laboratorio2.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Laboratorio2.Servicio
{
    public interface Ipersona
    {
        void Insertar(persona c);

        ICollection<persona> Listardatos();
    }


}
