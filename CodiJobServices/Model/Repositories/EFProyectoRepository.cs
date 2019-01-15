using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodiJobServices.Model.Repositories
{
    public class EFProyectoRepository : IProyectoRepository
    {
        public IQueryable<TProyecto> Items => context.TProyecto;
        private CodiJobDbContext context;
        public EFProyectoRepository(CodiJobDbContext ctx)
        {
            context = ctx;
        }
        public void Save(TProyecto proyecto)
        {
            if (proyecto.ProyId == Guid.Empty)
            {
                proyecto.ProyId = Guid.NewGuid();
                context.TProyecto.Add(proyecto);
            }
            else
            {
                TProyecto dbEntry = context.TProyecto
                .FirstOrDefault(p => p.ProyId == proyecto.ProyId);
                if (dbEntry != null)
                {
                    dbEntry.ProyNom = proyecto.ProyNom;
                    dbEntry.ProyDesc = proyecto.ProyDesc;
                    dbEntry.ProyFecha = proyecto.ProyFecha;
                    dbEntry.ProyUrl = proyecto.ProyUrl;
                }
            }
            context.SaveChangesAsync();
        }
        public void Delete(Guid ProyectoID)
        {
            TProyecto dbEntry = context.TProyecto
            .FirstOrDefault(p => p.ProyId == ProyectoID);
            if (dbEntry != null)
            {
                context.TProyecto.Remove(dbEntry);
                context.SaveChanges();
            }
        }
        public IQueryable<TProyecto> FilterProyectos(int pageSize, int page)
        {
            return this.Items
            .Skip((page - 1) * pageSize)
            .Take(pageSize);
        }
    }
}
