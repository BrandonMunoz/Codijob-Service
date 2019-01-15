using CodiJobServices.Model.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using Application.IServices;
using Application.DTOs;
using System.Linq;
using Domain;

namespace Application.Services
{
    class ProyectoService : IProyectoService
    {
        IProyectoRepository repository;
        public ProyectoService(IProyectoRepository repo)
        {
            repository = repo;
        }

        public void Delete(Guid entityId)
        {
            repository.Delete(entityId);
        }

        public IList<ProyectoDTO> GetAll()
        {
            IQueryable<TProyecto> proyectoEntities = repository.Items;
            return Builders.GenericBuilder.builderListEntityDTO<ProyectoDTO, TProyecto>(proyectoEntities);
        }
        public void Insert(ProyectoDTO entityDTO)
        {
            TProyecto entity = Builders.
                GenericBuilder.
                builderDTOEntity<TProyecto, ProyectoDTO>
                (entityDTO);
            repository.Save(entity);
        }

        public void Update(ProyectoDTO entityDTO)
        {
            var entity = Builders.
                GenericBuilder.
                builderDTOEntity<TProyecto, ProyectoDTO>
                (entityDTO);
            repository.Save(entity);
        }


    }
}
