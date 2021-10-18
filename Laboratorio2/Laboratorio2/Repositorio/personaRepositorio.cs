using Laboratorio2.Data;
using Laboratorio2.Dominio;
using Laboratorio2.Servicio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Laboratorio2.Repositorio
{
    public class personaRepositorio : Ipersona
    {

        private ApplicationDbContext app;
        public personaRepositorio(ApplicationDbContext app)
        {

            this.app = app;
        }
        public void Insertar(persona c)
        {
         
            app.Add(c);
            app.SaveChanges();
        }

        public  ICollection<persona> Listardatos()
        {
            return app.persona.ToList();
        }
    }
}
