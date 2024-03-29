﻿using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
        }
       
    }

}
