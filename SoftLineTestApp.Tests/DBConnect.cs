using ClassLib.Entities;
using ClassLib.EFContext;
using Microsoft.EntityFrameworkCore;

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
        }
    }
}