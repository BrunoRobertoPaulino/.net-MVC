using Entity.Models;
using Microsoft.EntityFrameworkCore;

namespace MVC.Context
{
    public class DataContatoContext : DbContext
    {
        public DataContatoContext(DbContextOptions<DataContatoContext> options) : base(options) 
        {
        }
        public DbSet<Contato> Contato { get; set; }
    }
}
