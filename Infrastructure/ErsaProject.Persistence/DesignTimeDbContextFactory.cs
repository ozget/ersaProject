using ErsaProject.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErsaProject.Persistence
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ErsaContext>
    {
        public ErsaContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<ErsaContext> dbContextOptionsBuilder = new();
            dbContextOptionsBuilder.UseSqlServer(Configuration.ConnectionString);
            return new(dbContextOptionsBuilder.Options);
        }
    }
}
