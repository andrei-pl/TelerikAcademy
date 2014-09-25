using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Core.Objects.DataClasses;

namespace NorthwindDB
{
    public partial class Employee
    {
        private EntityCollection<Territory> entityTerritories;

        public EntityCollection<Territory> EntityTerritories
        {
            get
            {
                var employeeTerritories = this.Territories;
                EntityCollection<Territory> entityTerritories = new EntityCollection<Territory>();
                foreach (var item in employeeTerritories)
                {
                    entityTerritories.Add(item);    //Emi ne shte. Sorry!
                } 
                return entityTerritories;
            }
        }
    }
}
