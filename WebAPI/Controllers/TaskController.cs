using System.ComponentModel;
using ClassLib.EFContext;
using ClassLib.Entities;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class TaskController: ControllerBase
{
    SqLiteDB db;
    public TaskController(SqLiteDB context)
    {
        db = context;
        /*
        // если нет данных
        if (!db.Tasks.Any())
        {
            db.Tasks.Add(new Task { Name = "New Task1", Description = "NewTask1_Description" });
            db.Tasks.Add(new Task { Name = "New Task2", Description = "NewTask2_Description" });
            db.SaveChanges();
        }
        */
    }

    [HttpGet]
    public IEnumerable<MyTaskDTO> Get()
    {
        var tasks = from t in db.Tasks.Include(s=>s.Status)
                select new MyTaskDTO()
                {
                    Id = t.Id,
                    Name = t.Name,
                    Description = t.Description,
                    Status = t.Status.Status
                };
        return tasks.ToList();
    }

    // GET api/tasks/5
    [HttpGet("{id}")]
    public MyTaskDTO Get(int id)
    {
        MyTask task = db.Tasks.Include(s=>s.Status).FirstOrDefault(x => x.Id == id);
        if (task==null)
            return new MyTaskDTO {
                Id=0, 
                Name="ERROR", 
                Description=$"No task with id={id} found", 
                Status = "null"
                };            
        
        MyStatus ts = task.Status;
        MyTaskDTO td = new MyTaskDTO {
            Name = task.Name,
            Description = task.Description,
            Status = ts.Status
            };
        return td;
    }

    // POST api/tasks
        [HttpPost]
        public string Post(MyTaskDTO td)
        {
            if (td == null)
            {
                return $"Task '{td.Name}' added!";
            } 
            Dictionary<string, int> statuses = db.Statuses.ToDictionary(s => s.Status, s=> s.Id);
            MyTask task = new MyTask {
                Name = td.Name,
                Description = td.Description,
                StatusId = statuses[td.Status]
            };

            db.Tasks.Add(task);
            db.SaveChanges();
            return $"Task '{td.Name}' added!";
        }

        // PUT api/tasks/
        [HttpPut]
        public string Put(MyTaskDTO td)
        {
            if (td == null)
            {
                return "ERROR: Empty object!";
            }           
            
            if (!db.Tasks.Any(x => x.Id == td.Id))
            {
                return "ERROR: No such task found!";
            }

            Dictionary<string, int> statuses = db.Statuses.ToDictionary(s => s.Status, s=> s.Id);
            MyTask task = new MyTask {
                Name = td.Name,
                Description = td.Description,
                StatusId = statuses[td.Status]
            };

            db.Update(task);
            db.SaveChangesAsync();
            return $"Task '{td.Name}' updated";
        }
        // DELETE api/tasks/5
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            MyTask task = db.Tasks.FirstOrDefault(x => x.Id == id);
            if (task == null)
            {
                return $"No task with id={id} found...";
            }
            db.Tasks.Remove(task);
            db.SaveChangesAsync();
            return $"Task delete success.";
        }


}