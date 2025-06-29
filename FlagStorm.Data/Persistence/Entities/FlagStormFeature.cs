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
    public IReadOnlySet<string> Tags { get; init; } = new HashSet<string>();

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
            Tags = Tags,
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
    public virtual ICollection<BrowserDto> Browsers { get; init; } = new List<BrowserDto>();
    public virtual ICollection<RegionDto> Regions { get; init; } = new List<RegionDto>();
    public virtual ICollection<LocaleDto> Locales { get; init; } = new List<LocaleDto>();
    public virtual ICollection<DeviceTypeDto> DeviceTypes { get; init; } = new List<DeviceTypeDto>();
    public virtual ICollection<OperatingSystemDto> OperatingSystems { get; init; } = new List<OperatingSystemDto>();
    public virtual ICollection<EnvironmentNameDto> Environments { get; init; } = new List<EnvironmentNameDto>();
    public virtual ICollection<AccountIdDto> AccountIds { get; init; } = new List<AccountIdDto>();

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
            Browsers = Browsers.ToList(),
            Regions = Regions.ToList(),
            AppVersionRange = AppVersionRange?.ToDto()
        };
    }
}

public class AppVersionRangeEntity : BaseEntity
{
    public virtual required AppVersionDto Min { get; init; }
    public virtual required AppVersionDto Max { get; init; }

    public bool Contains(AppVersionDto version) =>
        version >= Min && version <= Max;

    public AppVersionRangeDto ToDto()
    {
        return new AppVersionRangeDto()
        {
            Min = Min,
            Max = Max
        };
    }
}