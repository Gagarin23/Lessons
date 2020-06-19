using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLLesson
{
    public class MyDbContext : DbContext
    {
        public MyDbContext() : base("DBConnectionString") //имя коннекта
        {
        }

        public DbSet<Group> Groups { get; set; }
        public DbSet<Song> Songs { get; set; }

    }
}
