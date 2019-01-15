using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodiJobServices.Model.Repositories
{
    public class EFSkillRepository : ISkillRepository
    {
        public IQueryable<TSkill> Items => context.TSkill;
        private CodiJobDbContext context;
        public EFSkillRepository(CodiJobDbContext ctx)
        {
            context = ctx;
        }
        public void Save(TSkill skill)
        {
            if (skill.SkillId == Guid.Empty)
            {
                skill.SkillId = Guid.NewGuid();
                context.TSkill.Add(skill);
            }
            else
            {
                TSkill dbEntry = context.TSkill
                .FirstOrDefault(s => s.SkillId == skill.SkillId);
                if (dbEntry != null)
                {
                    dbEntry.SkillNom = skill.SkillNom;
                }
            }
            context.SaveChangesAsync();
        }
        public void Delete(Guid SkillID)
        {
            TSkill dbEntry = context.TSkill
            .FirstOrDefault(p => p.SkillId == SkillID);
            if (dbEntry != null)
            {
                context.TSkill.Remove(dbEntry);
                context.SaveChanges();
            }
        }
    }
}
