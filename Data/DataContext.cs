using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Caso_Di_Studio.Entities;

namespace Caso_Di_Studio.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options){

        }
        public DbSet<Book> Books { get; set; }
    }
}