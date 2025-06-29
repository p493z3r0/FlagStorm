
namespace FlagStorm.Data.Feature.Evaluation;

public class EnvironmentSnapshot
{
    public required DeviceTypeDto DeviceType { get; init; }
    public required LocaleDto Locale { get; init; }
    public required RegionDto Region { get; init; }
    public required AppVersionDto AppVersion { get; init; }
    public required global::OperatingSystemDto OperatingSystem { get; init; }
    public required EnvironmentNameDto EnvironmentName { get; init; }
}