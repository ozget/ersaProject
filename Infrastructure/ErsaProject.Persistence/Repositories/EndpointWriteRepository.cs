
using ErsaProject.Application.Repositories;
using ErsaProject.Domain.Entities.Identity;
using ErsaProject.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErsaProject.Persistence.Repositories
{
    public class EndpointWriteRepository : WriteRepository<Endpoint>, IEndpointWriteRepository
    {
        public EndpointWriteRepository(ErsaContext context) : base(context)
        {
        }
    }
}
