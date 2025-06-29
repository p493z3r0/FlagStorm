
using FlagStorm.Data.Data;

public class RegionEntity: BaseEntity 
{
    public string Value { get; set; } = null!;
}

public class BrowserEntity: BaseEntity  
{
    public string Value { get; set; } = null!;
}

public class LocaleEntity: BaseEntity  
{
    public string Value { get; set; } = null!;
}

public class AppVersionEntity: BaseEntity, IComparable<AppVersionEntity>
{
    public string Value { get; set; } = null!;

    public int Major => int.Parse(Value.Split('.')[0]);
    public int Minor => int.Parse(Value.Split('.')[1]);
    public int Patch => int.Parse(Value.Split('.')[2]);

    public int CompareTo(AppVersionEntity? other)
    {
        if (other == null) return 1;
        var result = Major.CompareTo(other.Major);
        if (result != 0) return result;
        result = Minor.CompareTo(other.Minor);
        if (result != 0) return result;
        return Patch.CompareTo(other.Patch);
    }
    public static bool operator <(AppVersionEntity left, AppVersionEntity right) => left.CompareTo(right) < 0;
    public static bool operator >(AppVersionEntity left, AppVersionEntity right) => left.CompareTo(right) > 0;
    public static bool operator <=(AppVersionEntity left, AppVersionEntity right) => left.CompareTo(right) <= 0;
    public static bool operator >=(AppVersionEntity left, AppVersionEntity right) => left.CompareTo(right) >= 0;
}

public class OperatingSystemEntity: BaseEntity 
{
    public string Name { get; set; } = null!;
}

public class EnvironmentNameEntity: BaseEntity  
{
    public string Value { get; set; } = null!;
}

public class AccountIdEntity: BaseEntity  
{
    public string Value { get; set; } = null!;
}

public class DeviceTypeEntity: BaseEntity 
{
    public string Value { get; set; } = null!;
}

public class CustomerEntity: BaseEntity 
{
    public string Value { get; set; } = null!;
}