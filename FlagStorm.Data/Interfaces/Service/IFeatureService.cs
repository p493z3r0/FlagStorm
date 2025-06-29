using FlagStorm.Data.Feature;
using FlagStorm.Data.Persistence.Entities;

namespace FlagStorm.Data.Interfaces.Service;

public interface IFeatureService
{
    public Task<ICollection<FlagStormFeatureDto>> GetFeatures();
    public Task<FlagStormFeatureDto?> GetFeature(string id);
    public Task<FlagStormFeatureDto?> CreateFeature(FlagStormFeatureDto flagStormFeature);
    public Task<FlagStormFeatureDto?> UpdateFeature(FlagStormFeatureDto flagStormFeature);
    public Task<FlagStormFeatureDto?> DeleteFeature(string id);
}