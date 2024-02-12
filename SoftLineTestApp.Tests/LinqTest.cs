namespace SoftLineTestApp.Tests;
using ClassLib.Entities;
using ClassLib.EFContext;
using Microsoft.EntityFrameworkCore;


public class LinqTest
{
    [Fact]
        public void TaskStatusCount()
        {
            var db = new SqLiteDB();
            var tasklist = db.Tasks.Include(x=>x.Status).ToList();
            Assert.Equal(4, tasklist.Count);
            var task_st = tasklist.First().Status;
            Assert.Equal("Init", task_st.Status);
            tasklist = db.Tasks.Where(x=>x.Status.Status=="InWork").ToList();
            Assert.Equal(1, tasklist.Count);
        }
}
