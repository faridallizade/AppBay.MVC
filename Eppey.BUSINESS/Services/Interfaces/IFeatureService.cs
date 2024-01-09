using Eppey.BUSINESS.Viewmodels.Home;
using Eppey.CORE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eppey.BUSINESS.Services.Interfaces
{
    public interface IFeatureService
    {
        Task<IQueryable<Feature>> GetAllAsync();
        Task<Feature> GetById(int id);
        Task Create(CreateFeatureVm createFeatureVM);
        Task Delete(int id);
        Task Update(UpdateFeatureVm updateFeatureVM);
    }
}
