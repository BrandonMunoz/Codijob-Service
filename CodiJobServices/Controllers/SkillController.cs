using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using CodiJobServices.Model.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CodiJobServices.Controllers
{
    [Route("api/[controller]")]
    public class ProyectoController : Controller
    {
       ISkillRepository repository;
        public ProyectoController(ISkillRepository repo)
        {
            this.repository = repo;
        }

        // GET: api/<controller>
        [HttpGet]
        public IQueryable<TSkill> Get()
        {
            return repository.Items;
        }

        // GET api/<controller>/5
        [HttpGet("{SkillId}")]
        public TSkill Get(Guid SkillId)
        {
            return repository.Items.Where(p => p.SkillId == SkillId).FirstOrDefault();
        }

        // POST api/<controller>
        [HttpPost]
        public IActionResult Post([FromBody]TSkill proyecto)
        {
            repository.Save(proyecto);
            return Ok(true);
        }

        // PUT api/<controller>/5
        [HttpPut("{SkillId}")]
        public IActionResult Put(Guid SkillId, [FromBody]TSkill proyecto)
        {
            proyecto.SkillId = SkillId;
            repository.Save(proyecto);
            return Ok(true);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{SkillId}")]
        public IActionResult Delete(Guid ProyectoId)
        {
            repository.Delete(ProyectoId);
            return Ok(true);
        }

        
    }
}
