using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;

namespace CodiJobServices.Model.Repositories
{
    public class EFGrupoRepository : IGrupoRepository
    {

        public IQueryable<TGrupo> Items => context.TGrupo;
        private CodiJobDbContext context;
        public EFGrupoRepository(CodiJobDbContext ctx)
        {
            context = ctx;
        }
        public void Save(TGrupo grupo)
        {
            if (grupo.Id == Guid.Empty)
            {
                grupo.Id = Guid.NewGuid();
                context.TGrupo.Add(grupo);
            }
            else
            {
                TGrupo dbEntry = context.TGrupo
                .FirstOrDefault(p => p.Id == grupo.Id);
                if (dbEntry != null)
                {
                    dbEntry.GrupoFoto = grupo.GrupoFoto;
                    dbEntry.GrupoNom = grupo.GrupoNom;
                    dbEntry.GrupoProm = grupo.GrupoProm;
                }
            }
            context.SaveChangesAsync();
        }
        public void Delete(Guid GrupoID)
        {
            TGrupo dbEntry = context.TGrupo
            .FirstOrDefault(p => p.Id == GrupoID);
            if (dbEntry != null)
            {
                context.TGrupo.Remove(dbEntry);
                context.SaveChanges();
            }
        }
    }
}
