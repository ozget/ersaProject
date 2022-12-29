
using ErsaProject.Domain.Entities.Common;
using ErsaProject.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErsaProject.Persistence.Contexts
{
    public class ErsaContext : IdentityDbContext<AppUser, AppRole, string>
    {
        public ErsaContext(DbContextOptions options) : base(options)
        { }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Endpoint> EndPoints { get; set; }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var datas = ChangeTracker.Entries<BaseEntity>();// create veta update de araya girip veriyi doldurmayı saglıyor
            foreach (var item in datas)
            {
                var result = item.State switch
                {
                    EntityState.Added => item.Entity.CreateDate = DateTime.UtcNow,
                    EntityState.Modified => item.Entity.UpdateDate = DateTime.UtcNow,
                    _ => DateTime.UtcNow,
                };
            }
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
