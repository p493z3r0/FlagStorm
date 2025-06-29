using FlagStorm.Data.Data;
using FlagStorm.Data.Feature;

public class RegionDto : BaseDto
{
    public string Value { get; set; } = null!;
}

public class BrowserDto : BaseDto
{
    public string Value { get; set; } = null!;
}

public class LocaleDto : BaseDto
{
    public string Value { get; set; } = null!;
}

public class AppVersionDto : BaseDto, IComparable<AppVersionDto>
{
    public string Value { get; set; } = null!;

    public int Major => int.Parse(Value.Split('.')[0]);
    public int Minor => int.Parse(Value.Split('.')[1]);
    public int Patch => int.Parse(Value.Split('.')[2]);

    public int CompareTo(AppVersionDto? other)
    {
        if (other == null) return 1;
        var result = Major.CompareTo(other.Major);
        if (result != 0) return result;
        result = Minor.CompareTo(other.Minor);
        if (result != 0) return result;
        return Patch.CompareTo(other.Patch);
    }
    public static bool operator <(AppVersionDto left, AppVersionDto right) => left.CompareTo(right) < 0;
    public static bool operator >(AppVersionDto left, AppVersionDto right) => left.CompareTo(right) > 0;
    public static bool operator <=(AppVersionDto left, AppVersionDto right) => left.CompareTo(right) <= 0;
    public static bool operator >=(AppVersionDto left, AppVersionDto right) => left.CompareTo(right) >= 0;
}

public class OperatingSystemDto : BaseDto
{
    public string Name { get; set; } = null!;
}

public class EnvironmentNameDto : BaseDto
{
    public string Value { get; set; } = null!;
}

public class AccountIdDto : BaseDto
{
    public string Value { get; set; } = null!;
}

public class DeviceTypeDto : BaseDto
{
    public string Value { get; set; } = null!;
}

public class Customer : BaseDto
{
    public string Value { get; set; } = null!;
}