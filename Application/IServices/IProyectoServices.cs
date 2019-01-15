using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.IServices
{
    interface IProyectoServices
    {
        void Insert(ProyectoDTO entityDTO);
        IList<ProyectoDTO> GetAll();
        void Update(ProyectoDTO entityDTO);
        void Delete(Guid entityId);
    }
}
