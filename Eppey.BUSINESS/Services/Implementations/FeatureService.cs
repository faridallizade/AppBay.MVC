using Eppey.BUSINESS.Services.Interfaces;
using Eppey.BUSINESS.Viewmodels.Home;
using Eppey.CORE.Entities;
using Eppey.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eppey.BUSINESS.Services.Implementations
{
    public class FeatureService : IFeatureService
    {
        private readonly IFeatureRepository _repo;
        public async Task Create(CreateFeatureVm createFeatureVM)
        {
            Feature feature = new Feature();
            await _repo.Create(feature);
            _repo.SaveChanges();
        }

        public async Task Delete(int id)
        {
            _repo.delete(id);   
        }

        public async Task<IQueryable<Feature>> GetAllAsync()
        {
            var features = _repo.GetAllAsync();
            return await features;
        }

        public async Task<Feature> GetById(int id)
        {
            if (id <= 0) throw new Exception("Bad Request");
            return await _repo.GetById(id);
        }

        public async Task Update(UpdateFeatureVm updateFeatureVM)
        {
            if (updateFeatureVM != null && _repo.Check(updateFeatureVM.Id))
            {
                var existingFeat = await _repo.GetById(updateFeatureVM.Id);
                (existingFeat).Title = updateFeatureVM.Title;
                existingFeat.Description = updateFeatureVM.Description;
                existingFeat = await _repo.GetById(updateFeatureVM.Id);
                existingFeat.IsDeleted = false;
                _repo.Update(existingFeat);
                _repo.SaveChanges();

            }
        }
    }
}
