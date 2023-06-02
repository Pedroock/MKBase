using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MKBase.Models;

namespace MKBase.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        //public DbSet<Model> Models => Set<Model>();
        public DbSet<Question> Questions => Set<Question>();
        public DbSet<Survey> Surveys => Set<Survey>();
        public DbSet<User> Users => Set<User>();
    }
}
