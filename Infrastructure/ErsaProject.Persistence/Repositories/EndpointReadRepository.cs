﻿using ErsaProject.Application.Repositories;
using ErsaProject.Domain.Entities.Identity;
using ErsaProject.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErsaProject.Persistence.Repositories
{
    public class EndpointReadRepository : ReadRepository<Endpoint>, IEndpointReadRepository
    {
        public EndpointReadRepository(ErsaContext context) : base(context)
        {
        }
    }
}
