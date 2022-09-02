using InstantLoan.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace InstantLoan.DAL
{
    public class ApiDbContext: DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options) { }

        // Mapping Entities (Models)
        public DbSet<Client> Client { get; set; }
    }
}
