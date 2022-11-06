using JobServices.BusinessEntities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobServices.BusinessEntities.Models
{
    public class RCMEmploymentType : EntityBase
    {
        public int Id
        {
            get; set;
        }

        public string EmploymentTypeName
        {
            get; set;
        }
    }
}
