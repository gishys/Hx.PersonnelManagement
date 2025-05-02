using ESRI.ArcGIS.Geodatabase;
using Hx.PersonnelManagement.Domain;
using Hx.PropertyRightManagement.Domain;

namespace Hx.PropertyRightManagement.Gdb.Access
{
    public class GdbForestLandSurveyRepository<RHolder>(IWorkspace gdbWorkspace) : IForestLandSurveyRepository<RHolder>
    where RHolder : Person
    {
        private readonly IWorkspace _gdbWorkspace = gdbWorkspace;

        public async Task<ForestLandSurveyInfo<RHolder>?> GetByIdAsync(Guid id)
        {
            var featureClass = await GetFeatureClassAsync();
            var queryFilter = new QueryFilter
            {
                WhereClause = $"GlobalID = '{id}'"
            };

            var featureCursor = featureClass.Search(queryFilter, true);
            IFeature feature;
            while ((feature = featureCursor.NextFeature()) != null)
            {
                return GdbForestLandSurveyRepository<RHolder>.ConvertFeatureToDomain(feature);
            }
            return null;
        }
        public async Task<IFeatureClass> GetFeatureClassAsync()
        {
            return await Task.Run(() =>
            {
                IFeatureWorkspace featureWorkspace = (IFeatureWorkspace)_gdbWorkspace;
                return featureWorkspace.OpenFeatureClass("Parcels");
            });
        }
        private static ForestLandSurveyInfo<RHolder>? ConvertFeatureToDomain(IFeature feature)
        {
            // GIS属性到领域模型的转换逻辑
            return null;
        }
        public bool? IsChangeTrackingEnabled => throw new NotImplementedException();

        public Task DeleteAsync(Guid id, bool autoSave = false, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(ForestLandSurveyInfo<RHolder> entity, bool autoSave = false, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task DeleteManyAsync(IEnumerable<Guid> ids, bool autoSave = false, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task DeleteManyAsync(IEnumerable<ForestLandSurveyInfo<RHolder>> entities, bool autoSave = false, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<ForestLandSurveyInfo<RHolder>?> FindAsync(Guid id, bool includeDetails = true, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<ForestLandSurveyInfo<RHolder>> GetAsync(Guid id, bool includeDetails = true, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<ForestLandSurveyInfo<RHolder>> GetByParcelCodeAsync(string code)
        {
            throw new NotImplementedException();
        }

        public Task<long> GetCountAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<List<ForestLandSurveyInfo<RHolder>>> GetListAsync(bool includeDetails = false, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<List<ForestLandSurveyInfo<RHolder>>> GetPagedListAsync(int skipCount, int maxResultCount, string sorting, bool includeDetails = false, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<ForestLandSurveyInfo<RHolder>> InsertAsync(ForestLandSurveyInfo<RHolder> entity, bool autoSave = false, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task InsertManyAsync(IEnumerable<ForestLandSurveyInfo<RHolder>> entities, bool autoSave = false, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<ForestLandSurveyInfo<RHolder>> UpdateAsync(ForestLandSurveyInfo<RHolder> entity, bool autoSave = false, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task UpdateManyAsync(IEnumerable<ForestLandSurveyInfo<RHolder>> entities, bool autoSave = false, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}