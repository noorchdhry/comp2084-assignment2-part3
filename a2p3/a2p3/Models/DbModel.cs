using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace a2p3.Models
{
    public class DbModel : DbContext 
    {
        public DbModel(DbContextOptions<DbModel>options) : base(options)
        {

        }

        public DbSet<TaskList> TaskLists { get; set; }
    }
}
