using System.Collections.Generic;
using TaskMate.Core.Entities;
using TaskMate.Data.Repositories;

namespace TaskMate.Services
{
    public class ProyectoService
    {
        private readonly ProyectoRepository _proyectoRepository;

        public ProyectoService()
        {
            _proyectoRepository = new ProyectoRepository();
        }

        public IEnumerable<Proyecto> ObtenerTodosLosProyectos()
        {
            return _proyectoRepository.GetAll();
        }
    }
}
