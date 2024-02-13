using Microsoft.EntityFrameworkCore;
using ClassLib.Entities;

namespace ClassLib.EFContext
{
    public class SqLiteDB: DbContext
    {
        public DbSet<MyTask> Tasks { get; set; }
        public DbSet<MyStatus> Statuses { get; set; }

        public SqLiteDB(DbContextOptions<SqLiteDB> options): base(options)
        {
            Database.EnsureCreated();
        }

        public SqLiteDB(){
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            /// <summary>
            /// TODO: поправить путь к файлу БД
            /// </summary>
            string path=@"D:\MyGitProjects\SoftLineTestApp\";
            string fname = "TestAppDB.db";
            optionsBuilder.UseSqlite("Filename="+path+fname);
        }
    }
}
