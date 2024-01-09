using Eppey.CORE.Entities;
using Eppey.DAL.Context;
using Eppey.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eppey.DAL.Repositories.Implementations
{
    public class FeatureRepository : Repository<Feature> , IFeatureRepository
    {
        public FeatureRepository(AppDbContext context) : base(context)
        {
        }
    }
}
