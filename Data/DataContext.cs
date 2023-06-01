using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MKBase.Models;
using MKBase.Models.Join;

namespace MKBase.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        //public DbSet<Model> Models => Set<Model>();
        public DbSet<SurveyContent> SurveyContents => Set<SurveyContent>();
        public DbSet<Answer> Answers => Set<Answer>();
        public DbSet<ContentCBX> ContentCBXs => Set<ContentCBX>();
        public DbSet<ContentMPC> ContentMPCs => Set<ContentMPC>();
        public DbSet<ContentSCR> ContentSCRs => Set<ContentSCR>();
        public DbSet<ContentSTR> ContentSTRs => Set<ContentSTR>();
        public DbSet<ContentTXT> ContentTXTs => Set<ContentTXT>();
        public DbSet<Question> Questions => Set<Question>();
        public DbSet<Survey> Surveys => Set<Survey>();
        public DbSet<User> Users => Set<User>();
    }
}
