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
    public class SkillController : Controller
    {
       IProyectoRepository repository;
        public SkillController(IProyectoRepository repo)
        {
            this.repository = repo;
        }

        // GET: api/<controller>
        [HttpGet]
        public IQueryable<TProyecto> Get()
        {
            return repository.Items;
        }

        // GET api/<controller>/5
        [HttpGet("{ProyectoId}")]
        public TProyecto Get(Guid ProyectoId)
        {
            return repository.Items.Where(p => p.ProyId == ProyectoId).FirstOrDefault();
        }

        // POST api/<controller>
        [HttpPost]
        public IActionResult Post([FromBody]TProyecto proyecto)
        {
            repository.Save(proyecto);
            return Ok(true);
        }

        // PUT api/<controller>/5
        [HttpPut("{ProyectoId}")]
        public IActionResult Put(Guid ProyectoId, [FromBody]TProyecto proyecto)
        {
            proyecto.ProyId = ProyectoId;
            repository.Save(proyecto);
            return Ok(true);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{ProyectoId}")]
        public IActionResult Delete(Guid ProyectoId)
        {
            repository.Delete(ProyectoId);
            return Ok(true);
        }

        [HttpGet("{pageSize}/{page}")]
        public IQueryable<TProyecto> Get(int pageSize, int page)
        {
            return repository.FilterProyectos(pageSize, page);
        }
    }
}
