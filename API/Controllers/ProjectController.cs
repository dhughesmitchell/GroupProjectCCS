using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using API.Models;
using API.Models.Interfaces;

namespace GroupProjectCCS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        // GET: api/Project
        [EnableCors("AnotherPolicy")]
        [HttpGet]
        public List<Project> Get()
        {
            IGetAll readObject = new ReadData();
            return readObject.GetAllProjects();
        }

        // GET: api/Project/5
        [EnableCors("AnotherPolicy")]
        [HttpGet("{id}", Name = "Get")]
        public Project Get(int id)
        {
            IGet readObject = new ReadData();
            return readObject.GetProject(id);
        }

        // POST: api/Project
        [EnableCors("AnotherPolicy")]
        [HttpPost]
        public void Post([FromBody] Project value)
        {
            DateTime currDate = DateTime.Now;
            value.startDate = currDate.ToString("MM/dd/yyyy");
            IInsert insert = new SaveProject();
            insert.InsertProject(value);

        }

        // PUT: api/Project/5
        [EnableCors("AnotherPolicy")]
        [HttpPut("{id}")]
        public void Put(Project value)
        {
            IEdit edit = new EditProject();
            edit.EditProjectByID(value);
        }

        // DELETE: api/Project/5
        [EnableCors("AnotherPolicy")]
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            IDelete delete = new DeleteProject();
            delete.DeleteProjectByID(id);
        }
    }
}
