using JobServices.BusinessEntities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobServices.BusinessEntities.Models
{
    public class RCMCompensationType : EntityBase
    {
        public int Id
        {
            get; set;
        }

        public string CompensationName
        {
            get; set;
        }
    }
}
