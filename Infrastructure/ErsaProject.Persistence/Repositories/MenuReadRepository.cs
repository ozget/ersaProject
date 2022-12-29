
using ErsaProject.Application.Repositories;
using ErsaProject.Domain.Entities.Identity;
using ErsaProject.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ErsaProject.Persistence.Repositories
{
    public class MenuReadRepository : ReadRepository<Menu>, IMenuReadRepository
    {
        public MenuReadRepository(ErsaContext context) : base(context)
        {
        }

       
    }
}
