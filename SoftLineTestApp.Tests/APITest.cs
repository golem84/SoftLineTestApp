using ClassLib.Entities;
using ClassLib.EFContext;
using WebAPI.Controllers;

namespace SoftLineTestApp.Tests;

public class APITest
{
    
    [Fact]
        public void GetAllTasks_ShouldReturnAllTasks()
        {
            SqLiteDB db = new SqLiteDB();
            TaskController tc = new TaskController(db);
            var response = tc.Get();
            Assert.Equal(4, response.Count());
        }
    [Fact]
        public void GetTasksWrongId_ShouldReturnErrorTask()
        {
            SqLiteDB db = new SqLiteDB();
            TaskController tc = new TaskController(db);
            MyTaskDTO response = tc.Get(15);
            Assert.Equal("ERROR", response.Name);
        }
    [Fact]
        public void GetTasksId_1_ShouldReturnOneTask()
        {
            SqLiteDB db = new SqLiteDB();
            TaskController tc = new TaskController(db);
            MyTaskDTO response = tc.Get(2);
            Assert.Equal("Book", response.Name);
        }
}
