﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomIdentity
{
    public class ApplicationRoleClaim : IdentityRoleClaim<Guid>
    {
    }
}
