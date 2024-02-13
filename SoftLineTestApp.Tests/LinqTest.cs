namespace SoftLineTestApp.Tests;
using ClassLib.EFContext;
using Microsoft.EntityFrameworkCore;


public class LinqTest
{
    [Fact]
        public void AllTasksCount()
        {
            var db = new SqLiteDB();
            var tasklist = db.Tasks.Include(x=>x.Status).ToList();
            Assert.Equal(4, tasklist.Count);
        }
    
    [Fact]
        public void FirstTaskStatus_ShouldBe_Init()
        {
            var db = new SqLiteDB();
            var tasklist = db.Tasks.Include(x=>x.Status).ToList();
            var task_st = tasklist.First().Status;
            Assert.Equal("Init", task_st.Status);            
        }

    [Fact]
        public void GetTasksCount_StatusInit_ShouldBe_2()
        {
            var db = new SqLiteDB();
            var tasklist = db.Tasks.Include(x=>x.Status).Where(s=>s.Status.Status=="Init").ToList();
            Assert.Equal(2, tasklist.Count());            
        }
}
