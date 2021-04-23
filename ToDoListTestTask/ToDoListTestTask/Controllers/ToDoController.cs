using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoListTestTask.Models;

namespace ToDoListTestTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController : ControllerBase
    {
        private AppDbContext context;
        public ToDoController(AppDbContext context) => this.context = context;



        // GET: api/ToDo
        [HttpGet]
        public IEnumerable<ToDo> Get()
        {
            return context.ToDoList;
        }

        // GET: api/ToDo/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return context.ToDoList.ElementAt(id).Text;
        }

        // GET: api/ToDo/Done/
        [HttpGet("done")]
        public IEnumerable<ToDo> GetDone()
        {
            var toDo = from ToDo in context.ToDoList
                       where ToDo.Done == true
                       select ToDo;
                
            return toDo;
        }

        // GET: api/ToDo/Done/
        [HttpGet("notdone")]
        public IEnumerable<ToDo> GetNotDone()
        {
            var toDo = from ToDo in context.ToDoList
                       where ToDo.Done == false
                       select ToDo;

            return toDo;
        }


        // POST: api/ToDo
        [HttpPost]
        public void Post([FromBody] ToDo toDo)
        {
            context.ToDoList.Add(toDo);
            context.SaveChanges();
        }

        // PUT: api/ToDo/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
            var toDo = context.ToDoList.Find(id);
            toDo.Text = value;

            context.SaveChanges();
        }

        // PUT: api/ToDo/done/5
        [HttpPut("done{id}")]
        public void PutDone(int id, [FromBody] bool value)
        {
            var toDo = context.ToDoList.Find(id);
            toDo.Done = value;

            context.SaveChanges();
        }

        // DELETE: api/ToDo/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var toDo = context.ToDoList.Find(id);
            context.ToDoList.Remove(toDo);

            context.SaveChanges();
        }
    }
}
