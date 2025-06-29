using FlagStorm.Data.Data;


namespace FlagStorm.Data.Feature;

public class BaseDto
{
    public required string Id { get; set; }
    public required DateTimeOffset CreatedAt { get; set; }
    public required DateTimeOffset? UpdatedAt { get; set; }
}

public class FlagStormFeatureDto : BaseDto
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
    public virtual required FlagStormFeatureRuntimeConfigDto RuntimeConfig { get; init; }

    /// <summary>
    /// Optional flag version or schema versioning.
    /// </summary>
    public int Version { get; init; } = 1;

    /// <summary>
    /// When was this feature created.
    /// </summary>

    /// <summary>
    /// Who last edited it (auditing, useful for dashboards).
    /// </summary>
    public string? LastModifiedBy { get; init; }

    /// <summary>
    /// When was it last updated.
    /// </summary>
    public DateTime? LastModifiedAt { get; init; }
}

public class FlagStormFeatureRuntimeConfigDto : BaseDto
{
    /// <summary>
    /// Enables the feature for a random subset of actors.
    /// 0 = disabled for all, 100 = enabled for all.
    /// </summary>
    public int RunPercentage { get; init; } = 0;
    /// <summary>
    /// Targeting rules by actor/environment dimensions.
    /// </summary>
    public virtual ICollection<FlagStormTargetRuleDto> TargetRules { get; init; } = new List<FlagStormTargetRuleDto>();
}

public class FlagStormTargetRuleDto : BaseDto
{
    public ICollection<BrowserDto> Browsers { get; init; } = new List<BrowserDto>();
    public ICollection<RegionDto> Regions { get; init; } = new List<RegionDto>();
    public ICollection<LocaleDto> Locales { get; init; } = new List<LocaleDto>();
    public ICollection<DeviceTypeDto> DeviceTypes { get; init; } = new List<DeviceTypeDto>();
    public  ICollection<OperatingSystemDto> OperatingSystems { get; init; } = new List<OperatingSystemDto>();
    public  ICollection<EnvironmentNameDto> Environments { get; init; } = new List<EnvironmentNameDto>();
    public  ICollection<AccountIdDto> AccountIds { get; init; } = new List<AccountIdDto>();

    public  AppVersionRangeDto? AppVersionRange { get; init; }

    /// <summary>
    /// Whether this rule is inclusive (allow listed) or exclusive (deny listed).
    /// </summary>
    public bool IsAllowRule { get; init; } = true;
}

public class AppVersionRangeDto
{
    public virtual required AppVersionDto Min { get; init; }
    public virtual required AppVersionDto Max { get; init; }

    public bool Contains(AppVersionDto version) =>
        version >= Min && version <= Max;
}