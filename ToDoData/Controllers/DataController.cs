using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ToDoData.Models;

namespace ToDoData.Controllers
{
    [Route("api/[controller]")]
    public class DataController : Controller
    {
        ApplicationContext db = new ApplicationContext();
        static readonly List<Data> data;

        [HttpGet]
        public IEnumerable<Data> Get()
        {
            return db.Tasks.ToList();
        }

        [HttpPost]
        public IActionResult Post(Data dat)
        {
            
            Data task = new Data {  Name = dat.Name, Status = dat.Status};
            db.Tasks.Add(task);
            db.SaveChanges();
            return Ok(dat);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            Data task = db.Tasks.Find(id);
            db.Tasks.Remove(task);
            db.SaveChanges();
            return Ok(id);
        }

        [HttpPost("update")]
        public IActionResult Put(Data dat)
        {
       
            db.Tasks.Update(dat);
            db.SaveChanges();
            return Ok(dat);
        }
       
        

    }
}