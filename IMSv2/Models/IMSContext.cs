using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMSv2.Models
{
    public class IMSContext : DbContext
    {
        public IMSContext()
        {
        }

        public IMSContext(DbContextOptions<IMSContext> options)
            : base(options)
        {
        }
    }
}
