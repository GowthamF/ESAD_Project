using JobServices.BusinessEntities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobServices.BusinessEntities.Models
{
    public class DataBaseContext : DbContext
    {

        public DbSet<RCMJobs> RCMJobs
        {
            get; set;
        }

        public DbSet<RCMCompensationType> RCMCompensationTypes
        {
            get; set;
        }

        public DbSet<RCMEmploymentType> RCMEmploymentTypes
        {
            get; set;
        }

        public DataBaseContext(DbContextOptions<DataBaseContext> options)
            : base(options) { }

       
    }
}
