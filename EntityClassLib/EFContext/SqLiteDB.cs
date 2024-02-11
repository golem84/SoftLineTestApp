using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;
using ClassLib.Entities;

namespace ClassLib.EFContext
{
    public class SqLiteDB: DbContext
    {
        public DbSet<MyTask> Tasks { get; set; }
        public DbSet<MyStatus> Statuses { get; set; }

        public SqLiteDB()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=C:\\Projects\\SoftLineTestApp\\TestAppDB.db");
        }
    }
}
