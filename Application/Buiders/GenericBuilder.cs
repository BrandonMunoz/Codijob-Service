using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Builders
{
    class GenericBuilder
    {
        public static DTO builderEntityDTO<DTO, Entity>(Entity entity)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Entity, DTO>();
            });
            IMapper iMapper = config.CreateMapper();
            var destination = iMapper.Map<Entity, DTO>(entity);
            return destination;
        }

        public static Entity builderDTOEntity<Entity, DTO>(DTO dto)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<DTO, Entity>();
            });
            IMapper iMapper = config.CreateMapper();
            var destination = iMapper.Map< DTO, Entity>(dto);
            return destination;
        }

        public static IList<DTO> builderListEntityDTO<DTO, Entity>
            (IQueryable<Entity> listaInput)
        {
            var listaOutput = new List<DTO>();
            foreach(Entity entity in listaInput)
            {
                listaOutput.Add(builderEntityDTO<DTO, Entity>(entity));
            };
            return listaOutput;
        }
    }
}
