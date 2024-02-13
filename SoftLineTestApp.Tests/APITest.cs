using ClassLib.Entities;
using ClassLib.EFContext;
using Microsoft.EntityFrameworkCore;
using WebAPI.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace SoftLineTestApp.Tests;

public class APITest
{
    [Fact]
        public void GetAllTasks_ShouldReturnAllTasks()
        {
            SqLiteDB db = new SqLiteDB();
            TaskController tc = new TaskController(db);
            //ObjectResult response = tc.Get();
            
            
            //Assert.Equal();
        }
}
