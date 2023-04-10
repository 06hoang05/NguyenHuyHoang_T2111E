using Microsoft.EntityFrameworkCore;

namespace WebApi.Models
{
    internal class Dbcontext
    {
        private DbContextOptions options;

        public Dbcontext(DbContextOptions options)
        {
            this.options = options;
        }
    }
}