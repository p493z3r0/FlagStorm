using FlagStorm.Data.Data;
using FlagStorm.Data.Feature;

namespace FlagStorm.Data.Persistence.Entities;




public class FlagStormFeatureEntity : BaseEntity
{
    public required string Name { get; init; }

    /// <summary>
    /// Globally disables this feature regardless of targeting rules.
    /// </summary>
    public bool IsDisabled { get; init; } = false;

    /// <summary>
    /// Optional description for documentation or admin UI.
    /// </summary>
    public string? Description { get; init; }

    /// <summary>
    /// Optional tag(s) for grouping features.
    /// </summary>
    public List<string> Tags { get; init; } = new List<string>();

    /// <summary>
    /// Runtime evaluation config: who gets the feature.
    /// </summary>
    public virtual required FlagStormFeatureRuntimeConfigEntity RuntimeConfig { get; init; }

    /// <summary>
    /// Optional flag version or schema versioning.
    /// </summary>
    public int Version { get; init; } = 1;

    /// <summary>
    /// When was this feature created.
    /// </summary>
    public DateTime CreatedAt { get; init; } = DateTime.UtcNow;

    /// <summary>
    /// Who last edited it (auditing, useful for dashboards).
    /// </summary>
    public string? LastModifiedBy { get; init; }

    /// <summary>
    /// When was it last updated.
    /// </summary>
    public DateTime? LastModifiedAt { get; init; }


    public FlagStormFeatureDto ToDto()
    {
        return new FlagStormFeatureDto
        {
            Id = Id,
            CreatedAt = CreatedAt,
            UpdatedAt = UpdatedAt,
            Name = Name,
            IsDisabled = IsDisabled,
            Description = Description,
            Tags = Tags.ToHashSet(),
            Version = Version,
            RuntimeConfig = RuntimeConfig.ToDto(),
        };
    }
    
}

public class FlagStormFeatureRuntimeConfigEntity : BaseEntity
{
    /// <summary>
    /// Enables the feature for a random subset of actors.
    /// 0 = disabled for all, 100 = enabled for all.
    /// </summary>
    public int RunPercentage { get; init; } = 0;
    /// <summary>
    /// Targeting rules by actor/environment dimensions.
    /// </summary>
    public virtual ICollection<FlagStormTargetRuleEntity> TargetRules { get; init; } = new List<FlagStormTargetRuleEntity>();

    public FlagStormFeatureRuntimeConfigDto ToDto()
    {
        return new FlagStormFeatureRuntimeConfigDto()
        {
            Id = Id,
            CreatedAt = CreatedAt,
            UpdatedAt = UpdatedAt,
            RunPercentage = RunPercentage,
            TargetRules = TargetRules.ToList().Select(t => t.ToDto()).ToList()
        };
    }
}

public class FlagStormTargetRuleEntity : BaseEntity
{
    public virtual ICollection<BrowserEntity> Browsers { get; init; } = new List<BrowserEntity>();
    public virtual ICollection<RegionEntity> Regions { get; init; } = new List<RegionEntity>();
    public virtual ICollection<LocaleEntity> Locales { get; init; } = new List<LocaleEntity>();
    public virtual ICollection<DeviceTypeEntity> DeviceTypes { get; init; } = new List<DeviceTypeEntity>();
    public virtual ICollection<OperatingSystemEntity> OperatingSystems { get; init; } = new List<OperatingSystemEntity>();
    public virtual ICollection<EnvironmentNameEntity> Environments { get; init; } = new List<EnvironmentNameEntity>();
    public virtual ICollection<AccountIdEntity> AccountIds { get; init; } = new List<AccountIdEntity>();

    public virtual AppVersionRangeEntity? AppVersionRange { get; init; }

    /// <summary>
    /// Whether this rule is inclusive (allow listed) or exclusive (deny listed).
    /// </summary>
    public bool IsAllowRule { get; init; } = true;

    public FlagStormTargetRuleDto ToDto()
    {
        return new FlagStormTargetRuleDto()
        {
            Id = Id,
            UpdatedAt = UpdatedAt,
            CreatedAt = CreatedAt,
            Browsers = Browsers.ToList().Select(b => b.ToDto()).ToList(),
            Regions = Regions.ToList().Select(r => r.ToDto()).ToList(),
            AppVersionRange = AppVersionRange?.ToDto(),
            IsAllowRule = IsAllowRule,
            OperatingSystems = OperatingSystems.ToList().Select(o => o.ToDto()).ToList(),
            Environments = Environments.ToList().Select(e => e.ToDto()).ToList(),
            AccountIds = AccountIds.ToList().Select(a => a.ToDto()).ToList(),
        };
    }
}

public class AppVersionRangeEntity : BaseEntity
{
    public virtual required AppVersionEntity Min { get; init; }
    public virtual required AppVersionEntity Max { get; init; }

    public bool Contains(AppVersionEntity version) =>
        version >= Min && version <= Max;

    public AppVersionRangeDto ToDto()
    {
        return new AppVersionRangeDto()
        {
            Min = Min.ToDto(),
            Max = Max.ToDto()
        };
    }
}