﻿
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErsaProject.Domain.Entities.Identity
{
    public class AppRole : IdentityRole<string>
    {
        public ICollection<Endpoint> EndPoints { get; set; }
    }
}
