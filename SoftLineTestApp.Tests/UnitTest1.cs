using ClassLib.Entities;
using ClassLib.EFContext;

namespace SoftLineTestApp.Tests
{
    public class DBConnect
    {
        [Fact]
        public void ConnectingTest()
        {
            var db = new SqLiteDB();
            var tasklist = db.Tasks.ToList();
            Assert.Equal(4, tasklist.Count);
            var task = db.Tasks.First();
            var task_st = task.StatusId;
            Assert.Equal(1, task_st);
        }
    }
}