using FlagStorm.Data.Feature;
using FlagStorm.Data.Interfaces.Service;
using FlagStorm.Data.Persistence;
using Microsoft.EntityFrameworkCore;

namespace FlagStorm.Data.Services;

public class FeatureService(FlagStormDbContext db) : IFeatureService
{
    public async Task<ICollection<FlagStormFeatureDto>> GetFeatures()
    {
        return (await db.Features.AsNoTracking().ToListAsync()).Select(f => f.ToDto()).ToList();
    }

    public async Task<FlagStormFeatureDto?> GetFeature(string id)
    {
        return (await db.Features.FirstOrDefaultAsync(f => f.Id == id))?.ToDto();
    }

    public async Task<FlagStormFeatureDto?> CreateFeature(FlagStormFeatureDto flagStormFeature)
    {
        await db.SaveChangesAsync();
        return flagStormFeature;
    }

    public async Task<FlagStormFeatureDto?> UpdateFeature(FlagStormFeatureDto flagStormFeature)
    {
        var entity =  await db.Features.FirstOrDefaultAsync(f => f.Id == flagStormFeature.Id);
        if (entity == null) return null;
        db.Entry(flagStormFeature).State = EntityState.Modified;
        await db.SaveChangesAsync();
        return entity.ToDto();
    }

    public async Task<FlagStormFeatureDto?> DeleteFeature(string id)
    {
        var entity = await db.Features.FirstOrDefaultAsync(f => f.Id == id);
        if (entity == null) return null;
        db.Features.Remove(entity);
        await db.SaveChangesAsync();
        return entity.ToDto();
    }
}